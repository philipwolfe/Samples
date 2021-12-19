imports System
imports System.Threading
imports System.Runtime.Remoting
imports System.Runtime.Remoting.Channels.TCP
imports System.Runtime.Remoting.Channels.HTTP

namespace RemotingSamples

  public class Sample
    shared sub main
      dim chan1 as TCPChannel 
      chan1 = new TCPChannel(8085)
      dim chan2 as HTTPChannel 
      chan2 = new HTTPChannel(8086)
      ChannelServices.RegisterChannel(chan1)
      ChannelServices.RegisterChannel(chan2)
      RemotingServices.RegisterWellKnownType("Object", "RemotingSamples.HelloServer", "SayHello", WellKnownObjectMode.Singleton)
      System.Console.WriteLine("Hit <enter> to exit...")
      System.Console.ReadLine()
    end sub
  end class
  
end namespace
