imports System

namespace RemotingSamples

  public class ForwardMe 
    inherits MarshalByRefObject

    public function CallMe(name as String)
      Console.WriteLine(name)
    end function  
    
  end class
  
end namespace
