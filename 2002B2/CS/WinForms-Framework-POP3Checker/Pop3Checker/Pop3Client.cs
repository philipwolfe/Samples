using System;
using System.Net.Sockets;
using System.Text;

namespace Pop3Checker
{
	//Stores account-wide information, including number of messages
	//and number of bytes these messages consume on the server.
	public struct Pop3AccountSummary
	{
		public int MessageCount;
		public int TotalBytes;
	}

//	Manages simple interaction with a POP3 server.
//	Following is a sample telnet session with a POP3 server called "server.domain"
//	where the user name is "gmb", the password is "dmbsjuz05",
//	and the account has 20 messages consuming 35000 bytes.
//	
//	telnet server.domain 110
//	----------------------------------------------------------------------------------
//	+OK Microsoft Exchange 2000 POP3 server version 6.0.4417.0 (server.domain) ready.
//	user gmb
//	+OK
//	pass dmbsjuz05
//	+OK User successfully logged on.
//	stat
//	+OK 20 35000
//	quit
//	+OK Microsoft Exchange 2000 POP3 server version 6.0.4417.0 signing off.
//	----------------------------------------------------------------------------------
//	Connection to host lost.

	/// <summary>
	/// Summary description for Pop3Client.
	/// </summary>
	public class Pop3Client
	{
		//Defaults
		private const int mcBufferLength = 32;
		private const int mcMaxReadRetries = 15;
		private const int mcReadPause = 1000;
		private const int mcDefaultConnectionTimeout = 30;
		private const int mcDefaultHostPort = 110;

		//Connection state possibilities
		public enum ConnectionStates {Disconnected = 0,Connected = 1,Authenticated = 2};

		private string mHostName;
		private int mHostPort = mcDefaultHostPort;
		private string mUserName;
		private string mUserPassword;
		private int mConnectionTimeout = mcDefaultConnectionTimeout;
		private string mFriendlyName;
		private TcpClient mClient;
		private NetworkStream mStream;
		private byte[] mBuffer;
		private string mConnectionMessage;
		private ConnectionStates mConnectionState;
		private Pop3AccountSummary mAccountSummary;


		public Pop3Client()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Pattern: Members are set with specified arguments.
		public Pop3Client(string hstName, string usrName, string usrPwd)
		{
			mHostName = hstName;
			mUserName = usrName;
			mUserPassword = usrPwd;
		}
    
		public Pop3Client(string hstName, string usrName, string usrPwd, int hstPort)
		{
			mHostName = hstName;
			mHostPort = hstPort;
			mUserName = usrName;
			mUserPassword = usrPwd;
		}

		public Pop3Client(string hstName, string usrName, string usrPwd, int hstPort, int connTimeout)
		{
			mHostName = hstName;
			mHostPort = hstPort;
			mUserName = usrName;
			mUserPassword = usrPwd;
			mConnectionTimeout = connTimeout;
		}

		//Destruct not implemented as of Beta 1 according to documentation.
		//Otherwise, we would've used that, but this works, too.
		protected void Dispose()
		//protected override void Finalize()
		{
			Quit();
			Disconnect();
		}
    
		//Sends a string to mStream as bytes. Returns number of sent bytes.
		private int Send(string msg)
		{
			byte[] buf = Encoding.ASCII.GetBytes(msg);
			try
			{
				mStream.Write(buf, 0, buf.Length);
				return msg.Length;
			}
			catch
			{
				return 0;
			}
		}
    
		//Receives pieces of message from mStream and concatenates them
		//into a string, which is returned.
		private string Receive()
		{
			string msg= "";
			byte[] buf = new byte[mcBufferLength];
			//int bytes;
			int retries=0;
			bool done=false;

			do
			{
				if (mStream.CanRead)
				{
					mStream.Read(buf, 0, buf.Length);
					msg += Encoding.ASCII.GetString(buf);
					done = !mStream.DataAvailable;
				}
				else
				{
					retries += 1;
					System.Threading.Thread.Sleep(mcReadPause);
				}
			}
			while (!done | retries >= mcMaxReadRetries);

			return msg;
		}

		//return true if response indicates success; otherwise, return false.
		//POP3 responses begin with "+" or "-" if sent command succeeds
		//or fails, respectively.
		private bool IsOkay(string msg)
		{
			return msg.Substring(0, 1) == "+";
		}

		//Attempt to connect to POP3 server within mConnectionTimeout window.
		//Populate mConnectionMessage with initial welcome message.
		//Set mConnectionState and return true if connected and
		//welcome message indicates success
		//[response begins with "+" -- see IsOkay()].
		//Otherwise, return false.
		public bool Connect()
		{
			bool succeeded=false;
			if (mConnectionState == ConnectionStates.Disconnected)
			{
				try
				{
					int connTimeout = mConnectionTimeout * 1000;
					mClient = new TcpClient();
					mClient.ReceiveTimeout = connTimeout;
					mClient.SendTimeout = connTimeout;
					mClient.Connect(mHostName, mHostPort);
					mConnectionState = ConnectionStates.Connected;
					mStream = mClient.GetStream();
					string rec = Receive();
					if (IsOkay(rec))
					{
						mConnectionMessage = rec;
						succeeded = true;
					}
					else
					{
						Quit();
					}
				}
				catch (Exception exp)
				{
					System.Windows.Forms.MessageBox.Show(exp.Message);
				}
			}

			if (succeeded)
			{
				return true;
			}
			else
			{
				//Just in case we connected, but the welcome message indicates failure,
				//we should disconnect.
				Disconnect();
				return false;
			}

		}

		//Closes any open resources and sets mConnectionState.
		public bool Disconnect()
		{
			if (mConnectionState != ConnectionStates.Disconnected)
			{
				mStream.Close();
				mClient.Close();
				mConnectionState = ConnectionStates.Disconnected;
				return true;
			}
			return false;
		}

		//Send "user" (mUserName) and "pass" (mPassword) to server.
		//Change mConnectionState and return true if all responses indicate success;
		//return false otherwise.
		public bool Authenticate()
		{
			if (mConnectionState == ConnectionStates.Connected)
			{
				string msg = "user " + mUserName + "\r\n";
				if (Send(msg) == msg.Length && IsOkay(Receive()))
				{
					msg = "pass " + mUserPassword + "\r\n";
					if (Send(msg) == msg.Length && IsOkay(Receive()))
					{
						mConnectionState = ConnectionStates.Authenticated;
						return true;
					}
				}
			}
			return false;
		}

		//Send "quit" request. return true if response indicate success;
		//return false otherwise.
		public bool Quit()
		{
			if (mConnectionState == ConnectionStates.Authenticated | mConnectionState == ConnectionStates.Connected)
			{
				string msg = "quit" + "\r\n";
				if (Send(msg) == msg.Length)
				{
					return IsOkay(Receive());
				}
			}
			return false;
		}

		//Send "stat" request. Populate mAccountSummary structure if all
		//responses indicated success; return false otherwise.
		public Pop3AccountSummary GetAccountSummary()
		{
			if (mConnectionState == ConnectionStates.Authenticated)
			{
				string msg = "stat" + "\r\n";
				if (Send(msg) == msg.Length)
				{
					string rec = Receive();
					if (IsOkay(rec))
					{
						string[] strArr = rec.Split(" ".ToCharArray());
						if (strArr.Length == 3)
						{
							mAccountSummary.MessageCount = Convert.ToInt32(strArr[1]);
							mAccountSummary.TotalBytes = Convert.ToInt32(strArr[2]);
							return mAccountSummary;
						}
					}
				}
			}
			return mAccountSummary;
		}

		//Pattern: Read-only properties return member values.
		public Pop3AccountSummary AccountSummary
		{
			get
			{
				return mAccountSummary;
			}
		}
		
		public ConnectionStates ConnectionState
		{
			get
			{
				return mConnectionState;
			}
		}
		public string ConnectionMessage
		{
			get
			{
				return mConnectionMessage;
			}
		}
	}
}
