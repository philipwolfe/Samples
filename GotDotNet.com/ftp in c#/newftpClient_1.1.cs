/******************************************************************************************
 Author						: Sunil S. Bhambhani
 Created					: 27th June 2003
 Last Modified				: 23rd August 2003
 Language					: C#
 
 Summary: This Program is all about how to get file from other computer on local network
 with the help of another program named as "newftpServer_1.1". This program shows you
 basicaly the concept of how to transfer file from on computer to anothercomputer
 with the help of sockets and filestreambuffers.
******************************************************************************************/
//all required header files
using System;
using System.IO;
using System.Net.Sockets;
using System.Net;

//declearing class
class FtpClient
{	
	public  static void Main()
	{
		Console.WriteLine("\n\n                 WelCome to Sunil's FTP. Client\n\n");
		Console.Write("\n Create a folder in (C) drive named as \"ftpService\" in which the files will-\n be downloaded from the Server.\n\n");
		Console.Write(" Enter IP Address of Computer Where Server is Running: ");
		string ipaddr=Console.ReadLine();		
		Console.Write("\n\n Enter File Name or Path use this(/) slash for path: \n ");
		string fname=Console.ReadLine();
		
		//creating object of TcpClient to catch the stream of connected computer
		TcpClient Server=null;			
		try
		{	
			IPAddress myIP = IPAddress.Parse(ipaddr);
			//sending the computer IPAddress and port number on the network			
			
			IPHostEntry entry=Dns.GetHostByAddress(myIP);
			
				Server = new TcpClient(entry.HostName,3099);			
			
		}
		catch(Exception)
		{
			Console.WriteLine("\n\n    Server Not found Enter Correct Machine Name");
			return;
			
		}
		//getting the networkserver stream object
		NetworkStream serverstream=Server.GetStream();		
		//creating streamreader object to read messages from server
		StreamReader reader=new StreamReader(serverstream);
		//creating streamwriter object to send messages to server
		StreamWriter writer=new StreamWriter(serverstream);				
		writer.AutoFlush=true;			
		//sending file name to server 
		writer.WriteLine(fname);
		
		string name="c:\\ftpService\\";
		string temp=null;
		//reading the message from server that file found or filename
		string name1=reader.ReadLine();
		if(name1=="File not found")
		{
			Console.WriteLine("\n\n    File not found");			
			writer.Close();
			reader.Close();
			return;
		}		
		//logic of extracting file name from the given path
		for(int i=name1.Length;i>=1;i--)
		{
			char c=name1[i-1];
			if(c=='/') break;
			temp+=c;
		}
		//setting the path for opening file at the client side like "c:\ftpService\xyz.cs"
		for(int i=temp.Length;i>=1;i--)
		{
			char c=temp[i-1];			
			name+=c;
		}
		
	
		Stream destinationfilestream;		
		try
		{
			//getting the file stream of destinationfile
			destinationfilestream=File.OpenWrite(name);

		}
		catch
		{
			
			Console.WriteLine("\n\n      Please Create a folder in (C) drive named as \"ftpService\" ");
			writer.WriteLine("File not found");
			serverstream.Close();
			return; 
		}

		
		const int buffsize=1024;
		try
		{			
			/*creating the bufferedstrem object for reading 1024 size of bytes from the 
			  server stream   */
			BufferedStream bufferedinput=new BufferedStream(serverstream);	

			/*creating the bufferedstrem object for write bytes which are read 
			  from server   */ 									
			BufferedStream bufferedoutput=new BufferedStream(destinationfilestream);
			int bytesread;	
			/* creating array of bytes size is 1024 */		
			byte[] buffer=new Byte[buffsize];	
			
			/* Reading bytes from the server until the end */
			while((bytesread=bufferedinput.Read(buffer,0,buffsize))>0)		
			{
				/* writing the bytes in the destination file*/
				bufferedoutput.Write(buffer,0,bytesread);
			}

			Console.WriteLine("\n\n    file copied in {0}",name);
			
			/* flushing the last buffer bytes from RAM*/
			bufferedoutput.Flush();

			/* Closing connections*/
			bufferedinput.Close();
			bufferedoutput.Close();
			Console.WriteLine("\n\n  Press Enter.....");
			Console.ReadLine();

			
			
			
		}
		catch(Exception)
		{
			Console.WriteLine("\n\n    Please check you harddisk space or someone shutdown the server");			
			writer.Close();
			reader.Close();			
		}

		/* Closing Connections*/
		reader.Close();
		writer.Close();
				
	}
	
}
