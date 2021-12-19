using System;
using System.Web;
using System.Web.UI;

namespace SimpleControlSamples {

    public class SimpleInnerContent : Control {

       protected override void Render(HtmlTextWriter output) {

           if ( (HasControls()) && (Controls[0] is LiteralControl) ) {
              output.Write("<H2>Your Message: " + ((LiteralControl) Controls[0]).Text + "</H2>");
           }
       }
    }    
}