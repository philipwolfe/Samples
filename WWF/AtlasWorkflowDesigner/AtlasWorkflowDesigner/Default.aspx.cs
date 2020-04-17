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
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class AtlasWFDesigner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["foo"] = "bar";
        _text.Text = DateTime.Now.ToString();
        if (!IsPostBack)
        {

        }
        else
        {
        
        }
    }
    protected override bool OnBubbleEvent(object source, EventArgs args)
    {
        IButtonControl c = source as IButtonControl;
        if (c != null)
        {
            switch (c.CommandName)
            {
                case "New":
                    Session["xoml"] = null;
                    break;
                case "Save":
                    break;
            }
        }
        return base.OnBubbleEvent(source, args);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["xoml"] = null;
    }
    protected void _saveWF_Click(object sender, ImageClickEventArgs e)
    {
      
    }
    protected void _openWF_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

        Session["xoml"] = ((DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty))[0][4].ToString();
    }
}
