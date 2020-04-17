//Copyright (c) 2006 Jon Flanders - http://www.masteringbiztalk.com/
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
//associated documentation files (the "Software"), to deal in the Software without restriction, 
//including without limitation the rights to use, copy, modify, merge, publish, distribute, 
//sublicense, and/or sell copies of the Software, and to permit persons to whom the Software 
//is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included 
//in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
//INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
//PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
//FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Web.UI.Controls;
using Microsoft.Web.UI;
using System.ComponentModel;
using System.Drawing.Design;
//TODO:Properties for workflow
//TODO:Way to change between sequential and statemachine
//TODO: area tag for "alternate" design views
//TODO: way to navigate around statemachine workflow
namespace WorkflowAtlasDesigner
{
    public class ToolboxControl :ListControl
    {
        protected override void OnInit(EventArgs e)
        {
            this.EnsureChildControls();
            base.OnInit(e);
        }
        protected override void CreateChildControls()
        {



            for (int i = 0; i < this.Items.Count; i++)
            {
                HtmlGenericControl item = new HtmlGenericControl("li");
                item.Attributes.Add("class",ItemClassName);
                item.ID = this.ClientID + "item" + i.ToString();
                HtmlImage img = new HtmlImage();
                img.Src = "toolboximages/foo.png?name=" + this.Items[i].Text;
              
                HtmlGenericControl div = new HtmlGenericControl("div");
              
                item.Controls.Add(div);
                div.Attributes.Add("class",TitleClassName);
                HtmlGenericControl idiv = new HtmlGenericControl("div");
                idiv.Controls.Add(img);
                idiv.Controls.Add(new LiteralControl("&nbsp"));
                div.Controls.Add(idiv);
                HtmlGenericControl span = new HtmlGenericControl("span");
                idiv.Controls.Add(span);
                span.InnerText = this.Items[i].Text;
                this.Controls.Add(item);
            }



        }
        //<ul id="atlasControl2">
        //           <li id="item1" runat="server">
        //               <div class="list">
        //                   <div id="item1Title" class="listTitle">
        //                       <span>Delay</span>
        //                   </div>
        //               </div>
        //           </li>
        protected override void Render(HtmlTextWriter tw)
        {
            tw.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
            tw.RenderBeginTag(HtmlTextWriterTag.Ul);
        
            base.RenderChildren(tw);
            tw.RenderEndTag();
        }

        
        public string ItemClassName
        {

            get { return (string)ViewState["ItemClassName"] ?? ""; }

            set { ViewState["ItemClassName"] = value; }

        }


        public string TitleClassName
        {

            get { return (string)ViewState["TitleClass"] ?? "listTitle"; }

            set { ViewState["TitleClass"] = value; }

        }



    }
    
    /// <summary>
    /// Summary description for DraggableControlExtender
    /// </summary>
    public class DraggableControlExtender : ExtenderControl<DraggableControlTargetProperties>
    {


        public string ControlID
        {

            get { return (string)ViewState["ControlID"] ?? ""; }

            set { ViewState["ControlID"] = value; }

        }


        public DraggableControlExtender()
        {
       
        }
        protected override void OnInit(EventArgs e)
        {
            ToolboxControl tbc = this.Page.FindControl(ControlID) as ToolboxControl;
            if (tbc != null)
            {
                foreach (Control c in tbc.Controls)
                {
                    DraggableControlTargetProperties prop = new DraggableControlTargetProperties();
                    prop.TargetControlID = c.ClientID;
                    this.TargetProperties.Add(prop);
                }
            }   
            base.OnInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {
         
            base.OnLoad(e);
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }
        protected override void RenderScript(Microsoft.Web.Script.ScriptTextWriter writer, Control targetControl)
        {

            DraggableControlTargetProperties prop = base.GetTargetProperties(targetControl);
            writer.WriteStartElement("draggableListItem");
            writer.WriteAttributeString("handle", targetControl.ClientID);
            writer.WriteEndElement();
            //<control id="webPart4">
            //              <behaviors>
            //                  <draggableListItem handle="webPart4Title" />
            //              </behaviors>
            //          </control>
        }
    }
    public class DraggableControlTargetProperties : TargetControlProperties
    {
        protected override bool IsEmpty
        {
            get { return false; }
        }

    }
}
