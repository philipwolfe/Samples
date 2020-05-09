using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;


namespace RemotingServer
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try {
				RemotingConfiguration.Configure(@"..\..\RemotingServer.exe.config");

				Console.WriteLine("Display well known service types");
				WellKnownServiceTypeEntry[] WellKnownServiceTypeEntries = RemotingConfiguration.GetRegisteredWellKnownServiceTypes();
				foreach(WellKnownServiceTypeEntry entry in WellKnownServiceTypeEntries)
					Console.WriteLine("{0}", entry);

				Console.WriteLine();
				Console.WriteLine("Display registerd channels");
				IChannel[] Channels = ChannelServices.RegisteredChannels;
				foreach(IChannel chn in Channels)
					Console.WriteLine("Channel-Name='{0}'; Priority='{1}'", chn.ChannelName, chn.ChannelPriority);

			} catch(Exception e) {
				Console.WriteLine(e);
			}

			Console.WriteLine();
			Console.WriteLine("Press ENTER to quit...");
			Console.ReadLine();
		}
	}
}
