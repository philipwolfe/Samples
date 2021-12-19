imports System

namespace RemotingSamples

  public class <serializable>ForwardMe

    dim mValue as integer = 1

    public function CallMe()
      mValue = mValue + 1
    end function

    public function getValue() as integer
      getValue = mValue
    end function
    
  end class
  
end namespace
