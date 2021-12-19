imports System
imports System.Runtime.Remoting
imports System.Runtime.Remoting.Channels.TCP

namespace RemotingSamples

  public class Client
  
    shared sub main
      dim chan as TCPChannel 
      chan = new TCPChannel(8086)
      ChannelServices.RegisterChannel(chan)
      dim param as ForwardMe 
      param = new ForwardMe()
      dim obj as HelloServer 
      obj = ctype(Activator.GetObject(Type.GetType("RemotingSamples.HelloServer"), "tcp://localhost:8085/SayHello"),HelloServer)
      if obj is nothing then
          System.Console.WriteLine("Could not locate server")
        else 
	  Console.WriteLine(obj.HelloMethod("Caveman",param))
      end if
          
    end sub
    
  end class
  
end namespace
