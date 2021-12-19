
namespace HelloWorld {
using System;
using System.Text;

  public class HelloObj 
  {
    private String _name;

    public HelloObj() {
        _name = null;      
    }

    public String FirstName 
    {
      get 
      {
        return _name;
      }
      set 
      {
        _name = value;
      }
    }

    public String SayHello() 
    {
      StringBuilder sb = new StringBuilder("Hello ");
      if (_name != null)
         sb.Append(_name);
      else
         sb.Append("World");
      sb.Append("!");
      return sb.ToString();
    }
  }
}