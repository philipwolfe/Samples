using System;

using Asterisk.NET.Manager;
using Asterisk.NET.FastAGI;

namespace Asterisk.NET.Test
{
    class Program
    {
		static void Main()
		{
			checkManagerAPI();
//			checkFastAGI();
		}

		#region checkFastAGI()
		private static void checkFastAGI()
		{
			Console.WriteLine("FastAGI started. Call *100 to test. Ctrl-C to exit");
			AsteriskFastAGI agi = new AsteriskFastAGI();
			agi.Startup();
		}
		#endregion

		#region checkManagerAPI()
		private static void checkManagerAPI()
		{
			AsteriskManager dam = new AsteriskManager("192.168.110.10", 5038, "admin", "amp111");

			// Add or Remove events
            dam.NewChannel += new NewChannelEventHandler(dam_NewChannel);
            dam.Hangup += new HangupEventHandler(dam_Hangup);
			dam.PeerStatus += new PeerStatusEventHandler(dam_PeerStatus);
			dam.Dial += new DialEventHandler(dam_Dial);
			dam.OriginateFailure += new OriginateFailureEventHandler(dam_OriginateFailure);
			dam.OriginateSuccess += new OriginateSuccessEventHandler(dam_OriginateSuccess);
			// Comment next line to display all events from Asterisk (display only event name)
			dam.Events += new ManagerConnectionEventHandler(dam_Events);

			// Disable timeout (debug only)
			// dam.Connection.DefaultTimeout = 0;
			// dam.Connection.DefaultEventTimeout = 0;
			try
			{
				dam.Initialize();
				Console.WriteLine(dam.Version());
				Console.WriteLine("Version of pbx.c : " + dam.VersionString("pbx.c"));
				foreach (Queue q in dam.Queues.Values)
				{
					Console.WriteLine("Queue: " + q.Name);
					Console.WriteLine("\tEntries: " + q.Entries.Count.ToString());
					foreach (Channel channel in q.Entries)
						Console.WriteLine("\t" + channel.Name);
				}
			}
			catch (Exception ex)
			{
				dam.Logoff();
				Console.WriteLine(ex);
				Console.ReadLine();
				return;
			}

			Console.WriteLine("Press ENTER key to originate call.\n"
				+"Start phone (or connect) or make a call to see events.\n"
				+"After all events press a key to originate call."); 
			Console.ReadLine();

			Originate oc = new Originate();
			oc.Channel = "IAX2/5628";
			oc.CallerId = ".NET";
			oc.Exten = "5626";
			oc.Variable = "VAR1=abc|VAR2=def";
			oc.SetVariable("VAR3", "ghi");
			Call call = dam.OriginateCall(oc);
			Console.WriteLine("*** Call from OriginateCall()"
				+"\n\tChannel\t\t" + (call.Channel == null ? "<null>" : call.Channel.Name)
				+"\n\tUniqueId\t" + call.UniqueId
				+"\n\tReason\t\t" + call.Reason
				);
			Console.WriteLine("Press ENTER key to next test.");
			Console.ReadLine();

			dam.Logoff();
		}

		#endregion

		#region Event handlers
		static void dam_Events(object sender, Asterisk.NET.Manager.Event.ManagerEvent e)
		{
			Console.WriteLine("+++ Event : " + e.GetType().FullName);
		}
		static void dam_Reload(object sender, Asterisk.NET.Manager.Event.ReloadEvent e)
		{
			Console.WriteLine("Reload Event"
				+ "\n\tMessage\t\t" + e.Message
			);
		}
		static void dam_ExtensionStatus(object sender, Asterisk.NET.Manager.Event.ExtensionStatusEvent e)
		{
			Console.WriteLine("ExtensionStatus Event"
				+ "\n\tContext\t\t" + e.Context
				+ "\n\tExten\t" + e.Exten
				+ "\n\tStatus\t" + e.Status
			);
		}

		static void dam_Dial(object sender, Asterisk.NET.Manager.Event.DialEvent e)
		{
			Console.WriteLine("Dial Event"
				+ "\n\tCallerId\t" + e.CallerId
				+ "\n\tCallerIdName\t" + e.CallerIdName
				+ "\n\tDestination\t" + e.Destination
				+ "\n\tDestUniqueId\t" + e.DestUniqueId
				+ "\n\tSrc\t\t" + e.Src
				+ "\n\tSrcUniqueId\t" + e.SrcUniqueId
			);
		}
		static void dam_OriginateFailure(object sender, Asterisk.NET.Manager.Event.OriginateFailureEvent e)
		{
			Console.WriteLine("Originate Failure Event"
				+ "\n\tChannel\t\t" + e.Channel
				+ "\n\tUniqueId\t" + e.UniqueId
				+ "\n\tContext\t\t" + e.Context
				);
		}
		static void dam_OriginateSuccess(object sender, Asterisk.NET.Manager.Event.OriginateSuccessEvent e)
		{
			Console.WriteLine("Originate Success Event"
				+ "\n\tChannel\t\t" + e.Channel
				+ "\n\tUniqueId\t" + e.UniqueId
				+ "\n\tContext\t\t" + e.Context
				);
		}

        static void dam_Hangup(object sender, Asterisk.NET.Manager.Event.HangupEvent e)
        {
            Console.WriteLine("Hangup Event"
                + "\n\tChannel\t\t" + e.Channel
				+ "\n\tUniqueId\t" + e.UniqueId
				);
        }

        static void dam_NewExten(object sender, Asterisk.NET.Manager.Event.NewExtenEvent e)
        {
            Console.WriteLine("New Extension Event"
                + "\n\tChannel\t\t" + e.Channel
                + "\n\tExtension\t" + e.Extension
                + "\n\tContext\t\t" + e.Context
                + "\n\tDateReceived\t" + e.DateReceived.ToString()
                + "\n\tPriority\t" + e.Priority.ToString()
                + "\n\tPrivilege\t" + e.Privilege
                + "\n\tUniqueId\t" + e.UniqueId
                + "\n\tAppData\t\t" + e.AppData
                + "\n\tApplication\t" + e.Application
                );
        }

        static void dam_NewChannel(object sender, Asterisk.NET.Manager.Event.NewChannelEvent e)
        {
            Console.WriteLine("New channel Event"
                + "\n\tChannel\t\t" + e.Channel
				+ "\n\tUniqueId\t" + e.UniqueId
                + "\n\tCallerId\t" + e.CallerId
                + "\n\tCallerIdName\t" + e.CallerIdName
                + "\n\tState\t\t" + e.State
                + "\n\tDateReceived\t" + e.DateReceived.ToString()
                );
        }

		static void dam_PeerStatus(object sender, Asterisk.NET.Manager.Event.PeerStatusEvent e)
		{
			Console.WriteLine("Peer Status Event"
				+ "\n\tPeer\t\t" + e.Peer
				+ "\n\tStatus\t\t" + e.PeerStatus
				+ "\n\tDateReceived\t" + e.DateReceived.ToString()
				);
		}
		#endregion
	}
}
