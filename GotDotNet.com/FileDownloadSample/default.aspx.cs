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

namespace FileDownloadSample
{
	/// <summary>
	/// Summary description for _default.
	/// </summary>
	public class _default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton btnDownload;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to send the file directly to the user
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDownload_Click(object sender, System.EventArgs e)
		{
			//Get our filename, we must have the full server file path for output,
			// or you may write to a stream if you are dynamically pulling data
			string strFilePath = Server.MapPath("~/SampleFile.xls");

			//Now simply send the doc to the user via the response object
			//Use append header to specify that the response content is an attachment.  The "filename"
			// attribute allows you to specify a filename for the download, this filename is the name that the
			// user will be given when they are prompted to either open or save the file
			Response.AppendHeader("content-disposition","attachment; filename=MyReport.xls");

			//Now set your content type, in this case it is excel, to find content types you can search 
			//  google for HTML content types and receive a list
			Response.ContentType = "application/vnd.ms-excel";

			//Now we need to write the file out to the response
			Response.WriteFile(strFilePath);

			//Now you end the response
			Response.End();
		}
	}
}
