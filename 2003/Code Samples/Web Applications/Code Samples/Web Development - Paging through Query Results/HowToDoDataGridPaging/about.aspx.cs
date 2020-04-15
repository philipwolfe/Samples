//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

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


	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblVersion;
		protected System.Web.UI.WebControls.Label lblCopyright;
		protected System.Web.UI.WebControls.Label lblDescription;
		protected System.Web.UI.WebControls.Label lblCodebase;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack) 
			{

				// Only load the data once

				// Set the labels identitying the Title, Version, and Description by

				// reading Assembly meta-data originally entered in the AssemblyInfo.cs file

				// using the AssemblyInfo class defined in the same file

				AssemblyInfo ainfo = new AssemblyInfo();

				this.lblTitle.Text = ainfo.Title;

				this.lblVersion.Text = string.Format("Version {0}", ainfo.Version);

				this.lblCopyright.Text = ainfo.Copyright;

				this.lblDescription.Text = ainfo.Description;

				this.lblCodebase.Text = ainfo.CodeBase;

			}
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
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			// return to the Main page

			Response.Redirect("main.aspx");
		}
	}
