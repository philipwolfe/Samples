///
///  This source code is freeware and is provided on an "as is" basis without warranties of any kind, 
///  whether express or implied, including without limitation warranties that the code is free of defect, 
///  fit for a particular purpose or non-infringing.  The entire risk as to the quality and performance of 
///  the code is with the end user.
///
///  Created by Stefan Goﬂner (stefang@microsoft.com)
///
///  Latest Updates: 
///      V1.0  include Mac client support
///      V1.1  correct buffer size problem 1
///      V1.2  correct buffer size problem 2
///

using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Microsoft.ContentManagement.Publishing;
using Microsoft.ContentManagement.WebControls;


namespace StefanG.ASPNET20_HttpModule
{

	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    public class ASPNET20_CrossPostbackCorrection : IHttpModule 
	{
		public void Init(HttpApplication httpApp) 
		{
			httpApp.PreRequestHandlerExecute += new EventHandler(this.OnPreRequestHandlerExecute);
		}

		public void Dispose() 
		{
			// Nothing to do.
		}

		public void OnPreRequestHandlerExecute(object sender, EventArgs e) 
		{
			HttpContext ctx = ((HttpApplication)sender).Context;
			IHttpHandler handler = ctx.Handler;

            // only execute for ASP.NET handler - not for custom http handlers or for the ASP.NET 2.0 resource handlers.
            if (handler.GetType().ToString().StartsWith("ASP."))
            {
                try
                {
                    if (CmsHttpContext.Current.ChannelItem != null)
                        ((System.Web.UI.Page)handler).Init += new EventHandler(this.OnInit);
                }
                catch
                {
                    // this will happen if the request is in the middle of an expired forms authentication login
                    // we just ignore this.
                }
            }
        }

        string Override_WebForm_DoPostBackWithOptions =
            "   if ( typeof WebForm_DoPostBackWithOptions != \"undefined\" )\n" +
            "   {\n" +
            "       __CrossPostBack_Backup_WebForm_DoPostBackWithOptions = WebForm_DoPostBackWithOptions;\n" +
            "       WebForm_DoPostBackWithOptions = __CrossPostBack_Redirect_WebForm_DoPostBackWithOptions;\n" +
            "   }\n" +
            "   function __CrossPostBack_Redirect_WebForm_DoPostBackWithOptions(options)" +
            "   {\n" +
            "       __CMS_PostbackFormBeenReset = true;\n" +
            "       __CrossPostBack_Backup_WebForm_DoPostBackWithOptions(options);\n" +
            "   }\n";


		public void OnInit(object sender, EventArgs eventArgs)
		{
			System.Web.UI.Page currentPage = sender as System.Web.UI.Page;
            currentPage.ClientScript.RegisterStartupScript(this.GetType(), 
                "Override_WebForm_DoPostBackWithOptions",		// now lets register our script 
                Override_WebForm_DoPostBackWithOptions, true);

		}

	}
}
