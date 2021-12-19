using System;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.HTTP;
using System.Runtime.Remoting.Channels.TCP;

namespace RemotingSamples {
  public class Client {
    
    public bool init = false;
    public static Thread thread1 = null;
    public static Thread thread2 = null;
    
    public static int Main(string [] args)
    {
      Client c = new Client();  
      thread1 = new Thread(new ThreadStart(c.RunMe));
      thread2 = new Thread(new ThreadStart(c.RunMe)); 
      thread1.Start();
      thread2.Start();
      return 0;
    } 
    
    
    public void RunMe()
    {
      if (Thread.CurrentThread == thread1) {
        HTTPChannel chan = new HTTPChannel();
        ChannelServices.RegisterChannel(chan);
        Console.WriteLine("I am thread one");
        HelloServer obj = (HelloServer)Activator.GetObject(typeof(HelloServer), "http://localhost:8086/SayHello");
        for (int i = 0; i < 1000; i++) {
          Console.WriteLine(obj.CountMe() + " - from thread 1 "); 
          Thread.Sleep(0);
        }  
      }  
      else if (Thread.CurrentThread == thread2) {
        TCPChannel chan = new TCPChannel();
        ChannelServices.RegisterChannel(chan);
        Console.WriteLine("I am thread two");
        HelloServer obj = (HelloServer)Activator.GetObject(typeof(HelloServer), "tcp://localhost:8085/SayHello");
        for (int i = 0; i < 1000; i++) {
          Console.WriteLine(obj.CountMe() + " - from thread 2 "); 
          Thread.Sleep(0);
        }  
      }  
    }
  }
}
