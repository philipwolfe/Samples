using System;
using System.Collections;
using System.Web;
using System.Web.UI;

namespace CustomParsingControlSamples {

    public class CustomParse2ControlBuilder : ControlBuilder {

       public override Type GetChildControlType(String tagName, IDictionary attributes) {

          if (String.Compare(tagName, "customitem", true) == 0) {
             return typeof(CustomParsingControlSamples.Item);
          }

          return null;
       }
    }

    [ 
       ControlBuilderAttribute(typeof(CustomParse2ControlBuilder)) 
    ]
    public class CustomParse2 : Control {

       private ArrayList _items         = new ArrayList();
       private int       _selectedIndex = 0;

       public int SelectedIndex { 
           get {
              return _selectedIndex;
           }
           set {
              _selectedIndex = value;
           }
       }

       public override void AddParsedSubObject(Object obj) {

           if (obj is Item) {
              _items.Add(obj);
           }
       }

       protected override void Render(HtmlTextWriter output) {

           if (SelectedIndex < _items.Count) {
              output.Write( ((Item) _items[SelectedIndex]).Message );
           }
       }
    }    
}