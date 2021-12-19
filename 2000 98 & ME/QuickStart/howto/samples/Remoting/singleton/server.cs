using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.TCP;
using System.Runtime.Remoting.Channels.HTTP;

namespace RemotingSamples {
  public class Sample {
  
    public static int Main(string [] args) {
    
      TCPChannel chan1 = new TCPChannel(8085);
      HTTPChannel chan2 = new HTTPChannel(8086);
      ChannelServices.RegisterChannel(chan1);
      ChannelServices.RegisterChannel(chan2);
      RemotingServices.RegisterWellKnownType("Object", "RemotingSamples.HelloServer", "SayHello", WellKnownObjectMode.Singleton);
      System.Console.WriteLine("Hit <enter> to exit...");
      System.Console.ReadLine();
      return 0;
    }
  }
}    
