using System;
using System.Web;
using System.Web.UI;

namespace TemplateControlSamples {

    public class Template1 : Control, INamingContainer {

        private ITemplate  _messageTemplate = null;      
        private String     _message         = null;   

        public String Message {

           get {
              return _message;
           }
           set {
              _message = value;
           }
        }

        [
            Template(typeof(Template1))
        ]
        public ITemplate MessageTemplate {

           get {
              return _messageTemplate;
           }
           set {
              _messageTemplate = value;
           }
        }

        protected override void CreateChildControls() {

           // If a template has been specified, use it to create children.
           // Otherwise, create a single literalcontrol with message value

           if (MessageTemplate != null) {
              MessageTemplate.Initialize(this);
           }
           else {
              this.Controls.Add(new LiteralControl(this.Message));
           }
        }
    }    
}