using System;

namespace RemotingSamples {

  public class ForwardMe : MarshalByRefObject {

    public void CallMe(String text)
    {
      Console.WriteLine(text);
    }
  }
}
