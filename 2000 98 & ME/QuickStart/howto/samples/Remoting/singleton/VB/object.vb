imports System
imports System.Threading
imports System.Runtime.Remoting
imports System.Runtime.Remoting.Channels.TCP
imports System.Runtime.Remoting.Channels.HTTP

namespace RemotingSamples

  public class HelloServer 
    inherits MarshalByRefObject
  
    public shared mCounter as integer = 0
    
    public sub HelloServer()
      Console.WriteLine("HelloServer activated")
    end sub
    
    
    public function HelloMethod(name as String) as String 
      Console.WriteLine("Hello.HelloMethod : {0}", name)
      HelloMethod = "Hi there " + name
    end function
    
     
    public function CountMe() as integer
      Monitor.Enter(Me)
        mCounter = mCounter + 1
        CountMe = mCounter
      Monitor.Exit(Me)
    end function
    
  end class
  
end namespace
