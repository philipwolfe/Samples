using System;
using System.Threading;
using System.Runtime.Remoting;

namespace Toub.Remoting
{
	class DemoClient
	{
		[STAThread]
		static void Main(string[] args)
		{
			RemotingConfiguration.Configure(@"..\..\client.config");
			Console.WriteLine("Starting...");

			System.Diagnostics.Debug.WriteLine("Sleeping for a few seconds to allow server to startup...");
			System.Threading.Thread.Sleep(1000); // wait for server to startup

			while(true)
			{
				// Create objects and make method calls
				for(int i=0; i<10; i++) MakeRemoteRequests();

				Console.WriteLine("'q' to quit, anything else to continue...");
				if (Console.ReadLine().Equals("q")) break;
			}
		}

		/// <summary>Create a remote object and make a bunch of method calls on it.</summary>
		public static void MakeRemoteRequests()
		{
			SampleObject obj = new SampleObject();
			for(int i=0; i<5; i++) Console.WriteLine("{0,2}: {1}", i, obj.GetString(i));
			for(int i=5; i<10; i++) Console.WriteLine("{0,2}: {1}", i, obj.GetString2(i));
		}
	}
}
