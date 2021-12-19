using System;
using System.Web;
using System.Web.UI;

namespace Acme {

    public class Tab : Control {

       private String _name;

       public String Name {
          get {
             return _name;
          }
          set {
             _name = value;
          }
       }
    }
}