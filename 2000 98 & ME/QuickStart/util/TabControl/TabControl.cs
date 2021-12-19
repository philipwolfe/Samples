using System;
using System.Collections;
using System.Web;
using System.Web.UI;

namespace Acme {

    public class TabControlBuilder: ControlBuilder {

       public override Type GetChildControlType(String tagName, IDictionary attributes) {

          if (String.Compare(tagName, "Tab", true) == 0) {
             return typeof(Acme.Tab);
          }

          return null;
       }
    }

    [ 
       ControlBuilderAttribute(typeof(TabControlBuilder)) 
    ]
    public class TabControl : Control {

       private ArrayList _tabs = new ArrayList();
       private bool _encode = false; 

       public override void AddParsedSubObject(Object obj) {

           if (obj is Tab) {
              _tabs.Add(obj);
           }
       }

       private String Encode(String text) {

           if (!_encode) return text;
           return Page.Server.HtmlEncode(text);
       }

       public bool HtmlEncode {
          get {
             return _encode;
          }
          set {
             _encode = value;
          }
       }

       protected override void Render(HtmlTextWriter output) {

           int _numTabs = _tabs.Count;

           output.WriteLine("");
           output.WriteLine("  <script language=\"JavaScript\">");

           output.WriteLine("    function doClick(index, id) {");

           output.WriteLine("        var numTabs = " + _numTabs + ";");
           output.WriteLine("        document.all(\"tab\" + id, index).className = \"tab\";");
           output.WriteLine("        for (var i=1; i < numTabs; i++) {");
           output.WriteLine("            document.all(\"tab\" + id, (index + i) % numTabs).className = \"backtab\";");
           output.WriteLine("        }");

           output.WriteLine("        document.all(\"code\" + id, index).style.display = \"\";");
           output.WriteLine("        for (var j=1; j < numTabs; j++) {");
           output.WriteLine("          document.all(\"code\" + id, (index + j) % numTabs).style.display = \"none\";");
           output.WriteLine("        }");

           output.WriteLine("    }");

           output.WriteLine("  </script>");

           output.WriteLine("  <style>");

           output.WriteLine("    td.code {");
           output.WriteLine("      padding:0,10,0,10;");
           output.WriteLine("      border-style:solid;");
           output.WriteLine("      border-width:1;");
           output.WriteLine("      border-bottom:0;");
           output.WriteLine("      border-top:0;");
           output.WriteLine("      border-right:0;");
           output.WriteLine("      border-color:cccccc;");
           output.WriteLine("      background-color:ffffee");
           output.WriteLine("    }");

           output.WriteLine("    td.tab {");
           output.WriteLine("      text-align:center;");
           output.WriteLine("      font:8pt verdana;");
           output.WriteLine("      width:15%;");
           output.WriteLine("      padding:3,3,3,3;");
           output.WriteLine("      border-style:solid;");
           output.WriteLine("      border-width:1;");
//           output.WriteLine("      border-top:0;");
           output.WriteLine("      border-right:0;");
           output.WriteLine("      border-color:black;");
           output.WriteLine("      background-color:eeeeee");
           output.WriteLine("    }");

           output.WriteLine("    td.backtab {");
           output.WriteLine("      text-align:center;");
           output.WriteLine("      font: 8pt verdana;");
           output.WriteLine("      width:15%;");
           output.WriteLine("      padding:3,3,3,3;");
           output.WriteLine("      border-style:solid;");
           output.WriteLine("      border-width:1;");
           output.WriteLine("      border-right:0;");
           output.WriteLine("      border-color:black;");
           output.WriteLine("      background-color:cccccc");
           output.WriteLine("    }");

           output.WriteLine("    td.space {");
           output.WriteLine("      width:" + (100 - _numTabs * 15).ToString() + "%;");
           output.WriteLine("      font: 8pt verdana;");
           output.WriteLine("      padding:0,0,0,0;");
           output.WriteLine("      border-style:solid;");
           output.WriteLine("      border-bottom:0;");
           output.WriteLine("      border-right:0;");
           output.WriteLine("      border-width:1;");
           output.WriteLine("      border-color:cccccc;");
           output.WriteLine("      border-left-color:black;");
           output.WriteLine("      background-color:white");
           output.WriteLine("    }");

           output.WriteLine("  </style>");

           output.WriteLine("    <table cellpadding=0 cellspacing=0 width=\"95%\">");
           output.WriteLine("      <tr>");
           output.WriteLine("        <td class=\"code\" colspan=\"" + (_numTabs + 1).ToString() + "\">");
 
           int _selectedindex = 0;
 
          for (int i=0; i< _numTabs; i++) {
              Tab _tab = (Tab) _tabs[i];

              HttpCookie codeCookie = Page.Request.Cookies["langpref"];

              String value = "VB";
              if (codeCookie != null)
                  value = codeCookie.Value;

              if (_tab.Name==value)
                   _selectedindex = i;
           }

           for (int i=0; i< _numTabs; i++) {

               Tab _tab = (Tab) _tabs[i];
 
               String _display = "none";
               if (i == _selectedindex)
                   _display = "";

               output.WriteLine("<pre id=\"code" + this.UniqueID + "\" style=\"display:" + _display + "\">");

               if (_tab.HasControls()) {
                   for (int x=0; x<_tab.Controls.Count; x++) {
                       if (_tab.Controls[x] is LiteralControl)
                       output.Write(Encode(((LiteralControl) _tab.Controls[x]).Text));
                   }
               }
               output.WriteLine("</pre>");
           }

           output.WriteLine("        </td>");
           output.WriteLine("      </tr>");
           output.WriteLine("      <tr>");

           for (int i=0; i< _numTabs; i++) {

               Tab _tab = (Tab) _tabs[i];

               String _className = "backtab";
               if (i == _selectedindex)
                   _className = "tab";

               output.WriteLine("        <td class=\"" + _className + "\" id=\"tab" + this.UniqueID + "\" onclick=\"doClick(" + i.ToString() + ", '" + this.UniqueID + "')\">");
               output.WriteLine("          <b>" + _tab.Name);
               output.WriteLine("        </td>");
           }

           output.WriteLine("        <td class=\"space\">&nbsp;</td>");
           output.WriteLine("      </tr>");
           output.WriteLine("    </table>");

       }
   }
}