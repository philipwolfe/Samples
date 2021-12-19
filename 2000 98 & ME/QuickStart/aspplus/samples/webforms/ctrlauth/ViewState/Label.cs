using System;
using System.Web;
using System.Web.UI;

namespace ViewStateControlSamples {

    public class Label: Control {

       public String Text {
          get {
              return (String) State["Text"];
          }
          set {
              State["Text"] = value;
          }
       }

       public int FontSize {
          get {
              return (int) State["FontSize"];
          }
          set {
              State["FontSize"] = value;
          }
       }

       protected override void Render(HtmlTextWriter output) {
           output.Write("<font size=" + this.FontSize + ">" + this.Text + "</font>");
       }
    }    
}