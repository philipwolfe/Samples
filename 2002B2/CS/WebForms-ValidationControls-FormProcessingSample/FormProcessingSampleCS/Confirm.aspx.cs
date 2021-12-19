using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace FormProcessingSample
{
	/// <summary>
	/// Summary description for Confirm.
	/// </summary>
	public class Confirm : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl divSubscriberInfo;

		public Confirm()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			 System.Text.StringBuilder sbSubscriberInfo = new System.Text.StringBuilder();

             sbSubscriberInfo.Append(Server.HtmlEncode(Request.QueryString["txtName"]));
             sbSubscriberInfo.Append("<BR>");
             sbSubscriberInfo.Append(Server.HtmlEncode(Request.QueryString["txtCity"]));
             sbSubscriberInfo.Append(", ");
             sbSubscriberInfo.Append(Server.HtmlEncode(Request.QueryString["ddlState"]));
             sbSubscriberInfo.Append(" ");
             sbSubscriberInfo.Append(Server.HtmlEncode(Request.QueryString["txtZipCode"]));
             sbSubscriberInfo.Append("<BR>");
             sbSubscriberInfo.Append(Server.HtmlEncode(Request.QueryString["txtEmail"]));
            			 
             divSubscriberInfo.InnerHtml = sbSubscriberInfo.ToString(); 
					
			}

		protected void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Windows Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
