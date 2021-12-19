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
    
    public String HelloMethod(String name) 
    {
      Console.WriteLine("Hello.HelloMethod : {0}", name);                        
      return "Hi there " + name;
    }
  }
}    
