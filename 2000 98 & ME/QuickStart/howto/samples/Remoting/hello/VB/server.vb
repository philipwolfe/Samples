imports System
imports System.Runtime.Remoting
imports System.Runtime.Remoting.Channels.TCP

namespace RemotingSamples

  public class Sample

    shared sub main
      dim chan as TCPChannel
      chan = new TCPChannel(8085)
      ChannelServices.RegisterChannel(chan)
      RemotingServices.RegisterWellKnownType("Object", "RemotingSamples.HelloServer", "SayHello", WellKnownObjectMode.SingleCall)
      System.Console.WriteLine("Hit <enter> to exit...")
      System.Console.ReadLine()
    end sub
    
  end class
  
end namespace


