using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.TCP;
using System.Runtime.Remoting.Channels.HTTP;

namespace RemotingSamples {
  public class HelloServer : MarshalByRefObject {
  
    private static int mCounter = 0;
    
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
    
     
    public int CountMe()
    {
      lock(this) {
        return mCounter++;
      }  
    }
  }
}    
