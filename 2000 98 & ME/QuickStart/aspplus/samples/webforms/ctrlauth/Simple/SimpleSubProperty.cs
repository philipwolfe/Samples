using System;
using System.Web;
using System.Web.UI;

namespace SimpleControlSamples {

    public class Formater {
        public int     Size;
        public String  Color;

        public Formater(int size, String color) {
           this.Size = size;
           this.Color = color;
        }
    }

    public class SimpleSubProperty : Control {

       private Formater _format  = new Formater(3, "black");
       private String   _message = null;

       public String Message {
           get {
              return _message;
           }
           set {
              _message = value;
           }
       }

       public Formater Format {
           get {
              return _format;
           }
       }

       protected override void Render(HtmlTextWriter output) {

           output.Write("<font size=" + Format.Size + " color=" + Format.Color + ">");
           output.Write(_message);
           output.Write("</font>");
       }
    }    
}