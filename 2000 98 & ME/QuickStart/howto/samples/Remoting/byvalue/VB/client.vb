imports System
imports System.Runtime.Remoting
imports System.Runtime.Remoting.Channels.TCP

namespace RemotingSamples

  public class Client
  
    shared sub main
      dim chan as TCPChannel 
      chan = new TCPChannel()
      ChannelServices.RegisterChannel(chan)
      dim param as ForwardMe 
      param = new ForwardMe()
      dim obj as HelloServer 
      obj = ctype(Activator.GetObject(Type.GetType("RemotingSamples.HelloServer"), "tcp://localhost:8085/SayHello"),HelloServer)
      if obj is nothing 
          System.Console.WriteLine("Could not locate server")
        else
          Console.WriteLine("The value is " + Int32.ToString(param.getValue()))
          dim after as ForwardMe 
	  after = obj.HelloMethod(param)
          Console.WriteLine("The value after the call is " + Int32.ToString(after.getValue()))
      end if  
      
    end sub
    
  end class
  
end namespace
