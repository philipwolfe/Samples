using System;
using System.Runtime.Remoting;
using System.Reflection;

namespace Toub.Remoting
{
	class DemoServer
	{
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("Configuring remoting for specified objects...");
			RemotingConfiguration.Configure(@"..\..\server.config");
			Console.WriteLine("Hit <enter> key to exit");
			Console.ReadLine();
		}
	}
}
