// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#define NULL 0

#using <mscorlib.dll>
#using <system.dll>

using namespace System;
using namespace System::Net::Sockets;
using namespace System::IO;
using namespace System::Text;

// Class implements simple POP3 client that connects to the POP3
// mail server and retrieves number of messages in your mailbox.
__gc class CPOP3Client
{
public:
	// Default constructor.
	CPOP3Client():	m_Client(NULL),
					m_strPOP3HostName(String::Empty),
					m_strUserName(String::Empty),
					m_strPassword(String::Empty),
					m_strStatus(new String("OK"))

	{
	}
	
	void Close()
	{
		if (m_Client != NULL)
		{
			m_Client->Close();
			m_Client = NULL;
		}
	}

protected:
	//**********************************************************
	//	Connects to the POP3 server.
	//
	//	RETURNS:true - if succeeded,
	//			false - if failed.
	//**********************************************************
	bool ConnectToServer()
	{
		String *strReadBuffer;
		StreamReader *streamRead;

		// Close existing connection.
		Close();

		// Create connection to the server.
		m_Client = new TcpClient(m_strPOP3HostName, 110);

		// Create stream to read.
		streamRead = new StreamReader(m_Client->GetStream(), Encoding::ASCII );

		strReadBuffer = streamRead->ReadLine();

		// Ignore rest of the buffer.
		streamRead->DiscardBufferedData();

		// Check response for +OK reply.
		if(strReadBuffer->StartsWith("+OK"))
			return true;
		else
		{
			Close();
			return false;
		}
	}

	//**********************************************************
	// Disconnects to the POP3 server.
	//**********************************************************
	void DisconnectFromServer()
	{
		String *strResponse = String::Empty;

		SendCommand("QUIT", &strResponse);
		
		Close();
	}

	//**********************************************************
	// Sends command passed as a parameter to the server,
	// passes response from the server as out parameter.
	//
	//	PARAMS:	strCommand - command to send to server.
	//			pstrOutput - returns response from server.
	//
	//	RETURNS:true - if succeeded,
	//			false - if failed.
	//**********************************************************
	bool SendCommand(String *strCommand, String** pstrOutput)
	{
		Byte outbuffer __gc[];

		StreamReader	*streamRead;
		NetworkStream	*streamWrite;
		String			*strRequest;

		if (m_Client == NULL)
			return false;

		// Add crlf to the command.
		strRequest = String::Concat(strCommand, S"\r\n");

		// Create streams to read from socket and write to it.
		streamWrite = m_Client->GetStream();
		streamRead = new StreamReader(streamWrite, Encoding::ASCII);

		// Convert from the string to the byte stream and write to socket.
		outbuffer = Encoding::ASCII->GetBytes(strRequest);
		streamWrite->Write(outbuffer, 0, outbuffer->Length);

		// read response from the socket.
		*pstrOutput = streamRead->ReadLine();

		// Ignore rest of the buffer.
		streamRead->DiscardBufferedData();

		return (*pstrOutput)->StartsWith(S"+OK") ? true : false;
	}

public:
	//-----------------------------------------------------------
	// Properties.
		
	// POP3 server address.
	__property String* get_POP3HostName()
	{
			return m_strPOP3HostName;
	}

	__property void set_POP3HostName(String* strPOP3HostName)
	{
		m_strPOP3HostName = strPOP3HostName;
	}

	// User name.
	__property String* get_UserName()
	{
		return m_strUserName;
	}

    __property void set_UserName(String *strUserName)
	{
		m_strUserName = strUserName;
	}

	// User password.
	__property String* get_Password()
	{
		return m_strPassword;
	}

	 __property void set_Password(String *strPassword)
	{
		m_strPassword = strPassword;
	}

	// Status.
	__property String* get_Status()
	{
		return m_strStatus;
	}

	// The number of messages in the mailbox.
	__property int get_NumberOfMessages()
	{
		String *strResponse = String::Empty;
		String *strNrOfMessages;

		// Create array of separators to parse response from server.
		Char separator __gc[] = new Char __gc[1];
		separator[0] = ' ';

		try
		{
			if(!ConnectToServer())
				return -1;

			if(!SendCommand(String::Concat(S"USER ", m_strUserName),
							&strResponse))
			{
				return -1;
			}


			if(!SendCommand(String::Concat(S"PASS ", m_strPassword),
							&strResponse))
			{
				return -1;
			}

			if(!SendCommand(S"STAT", &strResponse))
			{
				return -1;
			}


			// Extract number of messages from the string.
			strNrOfMessages = strResponse->Split(separator)[1];

			return Convert::ToInt32(strNrOfMessages);
		}
		catch(Exception* e)
		{
			m_strStatus = String::Concat(S"Error: ", e->Message);
			return -1;
		}
		__finally
		{
			DisconnectFromServer();
		}
	}

private:
		TcpClient *m_Client;
		String *m_strPOP3HostName;
		String *m_strUserName;
		String *m_strPassword;
		String *m_strStatus;

};

// This is the entry point for this application
int main(int argc, char *argv[ ])
{
	CPOP3Client* pPOP3Client;
	int nNrOfMessages;

	// Check parameters.
	if(argc != 4)
	{
		Console::WriteLine(S"Wrong argument number.");
		Console::WriteLine(S"Use following command line:");
		Console::WriteLine(S"pop3client.exe POP3Hostname username password");

		Console::Write("Press Enter to continue");
		Console::ReadLine();

		return 0;
	}

	// Create POP3Client object.
	pPOP3Client = new CPOP3Client();

	// Set properties from command line.
	pPOP3Client->POP3HostName = new String(argv[1]);
	pPOP3Client->UserName = new String(argv[2]);
	pPOP3Client->Password = new String(argv[3]);

	// Get number of messages in the mailbox.
	nNrOfMessages = pPOP3Client->NumberOfMessages;

	// If -1 returned, error occurred, then print error message.
	// otherwise 
	if(nNrOfMessages < 0)
		Console::Write(String::Concat(S"Error occured: ", pPOP3Client->Status));
	else
	{
		Console::Write(S"You have ");
		Console::Write(nNrOfMessages);
		Console::WriteLine(S" messages in your mailbox.");
	}


	Console::Write("Press Enter to continue");
	Console::ReadLine();

	return 0;
}