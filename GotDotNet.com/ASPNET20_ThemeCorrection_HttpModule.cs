///
///  This source code is freeware and is provided on an "as is" basis without warranties of any kind, 
///  whether express or implied, including without limitation warranties that the code is free of defect, 
///  fit for a particular purpose or non-infringing.  The entire risk as to the quality and performance of 
///  the code is with the end user.
///
///  Created by Stefan Goﬂner (stefang@microsoft.com)
///
///  Latest Updates: 
///      V1.0  initial version
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
	public class ASPNET20_ThemeCorrection_HttpModule : IHttpModule 
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

			try
			{
				if (CmsHttpContext.Current.ChannelItem != null)
					((System.Web.UI.Page)handler).PreRender += new EventHandler( this.OnPreRender );
			}
			catch
			{
				// this will happen if the request is in the middle of an expired forms authentication login
				// we just ignore this.
			}
		}

		public void OnPreRender(object sender, EventArgs eventArgs)
		{
            string a = "hh";
            Page currentPage = sender as Page;
            HtmlHead pageHeader = currentPage.Header as HtmlHead;
            if (pageHeader != null)
            foreach (Control control in pageHeader.Controls)
            {
                HtmlLink link = control as HtmlLink;
                if (link != null && VirtualPathUtility.IsAppRelative(link.Href))
                {
                    link.Href = VirtualPathUtility.ToAbsolute(link.Href);
                }
            }
        }

	}
}
