using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.TCP;

namespace RemotingSamples {
  public class HelloServer : MarshalByRefObject {

    public HelloServer()
    {
      Console.WriteLine("HelloServer activated");
    }


    ~HelloServer()
    {
      Console.WriteLine("Object Destroyed");
    }


    public ForwardMe HelloMethod(ForwardMe obj)
    {
      for (int i=0; i < 5; i++) obj.CallMe();
      return obj;
    }
  }
}
