using System;
using System.Web;
using System.Web.UI;

namespace CustomParsingControlSamples {

    public class Item : Control {

       private String _message;

       public String Message {
          get {
             return _message;
          }
          set {
             _message = value;
          }
       }
    }
}