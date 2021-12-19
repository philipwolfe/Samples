using System;

namespace RemotingSamples {

  [serializable]
  public class ForwardMe {

    private int mValue = 1;

    public void CallMe()
    {
      mValue++;
    }

    public int getValue()
    {
      return mValue;
    }
  }
}
