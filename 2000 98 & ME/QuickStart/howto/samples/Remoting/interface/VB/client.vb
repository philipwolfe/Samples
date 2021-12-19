imports System
imports System.Runtime.Remoting
imports System.Runtime.Remoting.Channels.TCP

namespace RemotingSamples

  public class Client
  
    shared sub main
      dim chan as TCPChannel 
      chan = new TCPChannel()
      ChannelServices.RegisterChannel(chan)
      dim obj as IHello 
      obj = ctype(Activator.GetObject(Type.GetType("RemotingSamples.IHello"), "tcp://localhost:8085/SayHello"),IHello)
      if obj is nothing 
          System.Console.WriteLine("Could not locate server")
        else 
	  Console.WriteLine(obj.HelloMethod("Caveman"))
      end if
          
    end sub
    
  end class
  
end namespace
