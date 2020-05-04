/******************************************************************************************
 Author						: Sunil S. Bhambhani
 Created					: 27th June 2003
 Last Modified				: 23rd August 2003
 Language					: C#
 
 Summary: This Program is all about how to get file from other computer on local network
 with the help of another program named as "newftpClient_1.1". This program shows you
 basicaly the concept of how to transfer file from on computer to anothercomputer
 with the help of sockets and filestreambuffers.
******************************************************************************************/

//all required header files
using System;
using System.Net;
using System.IO;
using System.Net.Sockets;

class FtpServer
{
	public static void Main()
	{
		/* Creating Port no 3099 on server for listening the client request*/
		TcpListener listener=new TcpListener(3099);
		Console.WriteLine("        Welcome to Sunil's FTP. Server");
		Console.WriteLine("\n Server Starts and Listening on Port(3099)....");

		/* start listening for any request*/
		listener.Start();

		/* calling function Service*/
		Service(listener);

	}

	public static void Service(TcpListener server)
	{
		while(true)
		{
			//creating object of TcpClient to catch the stream of connected computer
			TcpClient client=server.AcceptTcpClient();

			//getting the networkclient stream object
			NetworkStream clientstream=client.GetStream();

			//creating streamreader object to read messages from client
			StreamReader reader=new StreamReader(clientstream);

			//creating streamwriter object to send messages to client
			StreamWriter writer=new StreamWriter(clientstream);			

			writer.AutoFlush=true;		
		// reading file name from client
			string sourcefile=reader.ReadLine();			
			
			Stream inputstream;
			try
			{
				//opening file in read mode
				inputstream=File.OpenRead(sourcefile);

				//sending file name to the client
				writer.WriteLine(sourcefile);

			}
			catch
			{
				Console.WriteLine("\n\n  File not found named: {0}",sourcefile);

				//sending message to client if file not found
				writer.WriteLine("File not found");
				clientstream.Close();
				continue;
			}
			const int sizebuff=1024;
			try
				{
				/*creating the bufferedstrem object for reading 1024 size of bytes from the 
					file */ 
					BufferedStream bufferedinput=new BufferedStream(inputstream);								

				/*creating the bufferedstrem object for sending bytes which are read 
					from file   */ 	
					BufferedStream bufferedoutput=new BufferedStream(clientstream);

					/* creating array of bytes size is 1024 */	
					byte[] buffer=new Byte[sizebuff];					
					int bytesread;					
					
					/* Reading bytes from the file until the end */
					while((bytesread=bufferedinput.Read(buffer,0,sizebuff))>0)
					{	
						/* sending the bytes to the client */
						bufferedoutput.Write(buffer,0,bytesread);								
					}
					Console.WriteLine("\n\n    file copied name:{0}",sourcefile);

					/* Closing connections*/
					bufferedoutput.Flush();
					bufferedinput.Close();
					bufferedoutput.Close();
				}				
				catch(Exception)
				{
					Console.WriteLine("\n\n Connection Couldnot Esablished  because Client forget to create-\n \"ftpService\" folder in his (C) Drive or his/her harddisk is full or Client close its Connection in between process");																						
					writer.Close();
					reader.Close();
					continue;
				}
			/* Closing connections*/			
			writer.Close();
			reader.Close();

		}
	}
}