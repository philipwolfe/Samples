using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

class Client {
	public static void Main(String[] args) {

		TCPClient tcpc = new TCPClient();
		Byte[] read = new Byte[32];

		if (args.Length != 1) {
			Console.WriteLine("Please specify a server name in the command line");
			return;
		}

		String server = args[0];

		// Verify that the server exists
		if (DNS.GetHostByName(server) == null) {
			Console.WriteLine("Cannot find server: " + server);
			return;
		}

		// Try to connect to the server
		if (tcpc.Connect(server, 13) == -1) {
			Console.WriteLine("Cannot connect to server: " + server);
			return;
		}

		// Get the stream
		Stream s = tcpc.GetStream();

		// Read the stream and convert it to ASII
		int bytes = s.Read(read, 0, read.Length);
		String Time = Encoding.ASCII.GetString(read);

		// Display the data
		Console.WriteLine("Received " + bytes + " bytes");
		Console.WriteLine("Current date and time is: " + Time);

		tcpc.Close();

		// Wait for user response to exit
		Console.WriteLine("Press Return to exit");
		Console.Read();
	}
}
