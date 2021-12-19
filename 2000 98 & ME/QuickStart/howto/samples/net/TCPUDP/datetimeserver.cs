using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server {
	public static void Main() {
		DateTime now;	 
		String strDateLine; 	
		Encoding ASCII = Encoding.ASCII;

		TCPListener tcpl = new TCPListener(13); // listen on port 13

		tcpl.Start();
		
		Console.WriteLine("Waiting for clients to connect");
		Console.WriteLine("Press Ctrl+c to Quit...");

		while (true)
		{
			// Accept will block until someone connects
			Socket s = tcpl.Accept();

			// Get the current date and time then concatenate it
			// into a string
			now = DateTime.Now;
			strDateLine = now.ToShortDateString() + " " + now.ToLongTimeString();

			// Convert the string to a Byte Array and send it
			Byte[] byteDateLine = ASCII.GetBytes(strDateLine.ToCharArray());
			s.Send(byteDateLine, byteDateLine.Length, 0);
			Console.WriteLine("Sent " + strDateLine);
		}
	}
}
