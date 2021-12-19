imports System
imports System.Threading
imports System.Runtime.Remoting
imports System.Runtime.Remoting.Channels.TCP

namespace RemotingSamples

  public class Client 

    public shared e as ManualResetEvent
    public delegate function MyDelegate(name as String) as String

    shared sub main
      e = new ManualResetEvent(false)
    
      dim chan as TCPChannel 
      chan = new TCPChannel()
      ChannelServices.RegisterChannel(chan)
      dim obj as HelloServer 
      obj = ctype(Activator.GetObject(Type.GetType("RemotingSamples.HelloServer"), "tcp://localhost:8085/SayHello"),HelloServer)
      if obj is nothing then
          System.Console.WriteLine("Could not locate server")
        else
          dim cb as AsyncCallback 
	  cb = new AsyncCallback(AddressOf Client.MyCallBack)
          dim d as MyDelegate 
	  d = new MyDelegate(AddressOf obj.HelloMethod)
          dim ar as IAsyncResult 
	  ar = d.BeginInvoke("Caveman", cb, 0)
      end if
    
      e.WaitOne()
    end sub


    shared sub MyCallBack(ar as IAsyncResult)
    '  MyDelegate d  = (MyDelegate)ar.AsyncObject;
    '  Console.WriteLine(d.EndInvoke(ar));
    '  e.Set();
    end sub
    
  end class
  
end namespace
