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

namespace AuthenticationSample
{
	/// <summary>
	/// Summary description for CDefault.
	/// </summary>
	public class CDefault : System.Web.UI.Page
	{
		
		protected System.Web.UI.HtmlControls.HtmlGenericControl divMessage;

		public CDefault()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			//Display the authenticated user name from the User.Identity object
			divMessage.InnerHtml = "Authentication was successful for User:&nbsp;<STRONG>" + User.Identity.Name + "</STRONG>";
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
