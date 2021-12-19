using System;
using System.Web;
using System.Web.UI;

namespace SimpleControlSamples {

    public class Simple : Control {

       protected override void Render(HtmlTextWriter output) {
           output.Write("<H2>Welcome to Control Development!</H2>");
       }
    }    
}