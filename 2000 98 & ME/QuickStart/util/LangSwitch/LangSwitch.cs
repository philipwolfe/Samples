namespace Acme
{
    using System;
    using System.Web.UI;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Collections;

    public class Content : Control, INamingContainer {
    }

    public class LangSwitch: WebControl {

        private ITemplate csTemplate    = null;      
        private ITemplate vbTemplate    = null;      
        private ITemplate jsTemplate    = null;      
        private string showCodeLang     = null;

        [ Template(typeof(Content))]
        public ITemplate CsTemplate {
           get { return csTemplate; }
           set { csTemplate = value; }
        }

        [ Template(typeof(Content))]
        public ITemplate VBTemplate {
           get { return vbTemplate; }
           set { vbTemplate = value; }
        }

        [ Template(typeof(Content))]
        public ITemplate JsTemplate {
           get { return jsTemplate; }
           set { jsTemplate = value; }
        }

        public string Language { 
            get { 
                
                //If lang type is not set explicitly then look for the cookie 
                //If no cookie default to VB
                string retval = showCodeLang;
                if (null == retval) {
                    HttpCookie langCookie = Page.Request.Cookies["langpref"];
                    if (null != langCookie) {
                        retval = langCookie.Value;
                    } 

                    if (null == retval) {
                        retval = "VB";
                    }
                }
                Page.Trace.Write("LangSwitch", "Language is " + retval);
                return retval  ;
            }
            set { showCodeLang = value ;}
        }

        protected override void CreateChildControls() {

            // Create new container for Content item
            Control content = new Content();

            // Initialize its inner contents

            string lang = this.Language;

            Page.Trace.Write("LangSwitch", "Language is " + lang);

            if ((lang=="VB")&&(null != vbTemplate))
                vbTemplate.Initialize(content);
            else if ((lang=="JScript")&&(null != jsTemplate))
                jsTemplate.Initialize(content);
            else if (null != csTemplate)
                csTemplate.Initialize(content);
            else
                content = new LiteralControl("<div><b>Error: Content not available</b></div>");

            // Add it to the child collection
            this.Controls.Add(content);
        }

    }
}
