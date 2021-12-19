using System;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.TCP;

namespace RemotingSamples {
  public class Client {

    public static ManualResetEvent e;
    public delegate String MyDelegate(String name);

    public static int Main(string [] args)
    {
      e = new ManualResetEvent(false);

      TCPChannel chan = new TCPChannel();
      ChannelServices.RegisterChannel(chan);
      HelloServer obj = (HelloServer)Activator.GetObject(typeof(RemotingSamples.HelloServer), "tcp://localhost:8085/SayHello");
      if (obj == null) System.Console.WriteLine("Could not locate server");
      else {
        AsyncCallback cb = new AsyncCallback(Client.MyCallBack);
        MyDelegate d = new MyDelegate(obj.HelloMethod);
        IAsyncResult ar = d.BeginInvoke("Caveman", cb, null);
      }

      e.WaitOne();
      return 0;
    }


    public static void MyCallBack(IAsyncResult ar)
    {
      MyDelegate d  = (MyDelegate)ar.AsyncObject;
      Console.WriteLine(d.EndInvoke(ar));
      e.Set();
    }
  }
}
