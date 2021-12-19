imports System
imports System.Runtime.Remoting
imports System.Runtime.Remoting.Channels.TCP

namespace RemotingSamples

  public class HelloServer 
    inherits MarshalByRefObject

    public sub HelloServer()
      Console.WriteLine("HelloServer activated")
    end sub


    public function HelloMethod(obj as ForwardMe) as ForwardMe 
      
      dim i as integer
      
      for i = 0 to 5
        obj.CallMe()
      next i
        
      HelloMethod = obj
    end function
    
  end class
  
end namespace
