using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.TCP;

namespace RemotingSamples {
  public class Sample {

    public static int Main(string [] args) {

      TCPChannel chan = new TCPChannel(8085);
      ChannelServices.RegisterChannel(chan);
      RemotingServices.RegisterWellKnownType("Object", "RemotingSamples.HelloServer", "SayHello", WellKnownObjectMode.SingleCall);
      System.Console.WriteLine("Hit <enter> to exit...");
      System.Console.ReadLine();
      return 0;
    }

  }
}
