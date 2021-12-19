imports System
imports System.Threading
imports System.Runtime.Remoting
imports System.Runtime.Remoting.Channels.HTTP
imports System.Runtime.Remoting.Channels.TCP

namespace RemotingSamples

  public class Client
    
    dim init as boolean = false
    public shared thread1 as Thread
    public shared thread2 as Thread
    
    shared sub main
      dim c as Client 
      c = new Client()
      thread1 = new Thread(new ThreadStart(AddressOf c.RunMe))
      thread2 = new Thread(new ThreadStart(AddressOf c.RunMe))
      thread1.Start()
      thread2.Start()
    end sub 
    
    
    public sub RunMe()
      if Thread.CurrentThread = thread1 then
        dim chan as HTTPChannel 
	chan = new HTTPChannel()
        ChannelServices.RegisterChannel(chan)
        Console.WriteLine("I am thread one")
        dim obj as HelloServer 
	obj = ctype(Activator.GetObject(Type.GetType("RemotingSamples.HelloServer"), "http://localhost:8086/SayHello"),HelloServer)
	dim i as integer
        for i = 0 to 1000
          Console.WriteLine(Int32.ToString(obj.CountMe()) + " - from thread 1 ")
          Thread.Sleep(0)
        next i
      else if Thread.CurrentThread = thread2 then
        dim chan as TCPChannel 
	chan = new TCPChannel()
        ChannelServices.RegisterChannel(chan)
        Console.WriteLine("I am thread two")
        dim obj as HelloServer 
	obj = ctype(Activator.GetObject(Type.GetType("RemotingSamples.HelloServer"), "tcp://localhost:8085/SayHello"),HelloServer)
	dim i as integer
        for i = 0 to 1000
          Console.WriteLine(Int32.ToString(obj.CountMe()) + " - from thread 2 ")
          Thread.Sleep(0)
        next i  
      end if  
    end sub
    
  end class
  
end namespace
