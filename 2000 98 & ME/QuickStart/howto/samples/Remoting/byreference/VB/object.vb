imports System
imports System.Runtime.Remoting
imports System.Runtime.Remoting.Channels.TCP

namespace RemotingSamples

  public class HelloServer 
    inherits MarshalByRefObject

    public sub HelloServer()
      Console.WriteLine("HelloServer activated")
    end sub


    public function HelloMethod(name as String,obj as ForwardMe) as String
      obj.CallMe("Regards from the server")
      Console.WriteLine("Hello.HelloMethod : {0}", name)
      HelloMethod = "Hi there " + name
    end function
    
  end class
  
end namespace
