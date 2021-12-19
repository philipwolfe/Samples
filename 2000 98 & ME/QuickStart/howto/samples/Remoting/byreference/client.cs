using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.TCP;

namespace RemotingSamples {
  public class Client
  {
    public static int Main(string [] args)
    {
      TCPChannel chan = new TCPChannel(8086);
      ChannelServices.RegisterChannel(chan);
      ForwardMe param = new ForwardMe();
      HelloServer obj = (HelloServer)Activator.GetObject(typeof(RemotingSamples.HelloServer), "tcp://localhost:8085/SayHello");
      if (obj == null) System.Console.WriteLine("Could not locate server");
      else Console.WriteLine(obj.HelloMethod("Caveman",param));
      return 0;
    }
  }
}
