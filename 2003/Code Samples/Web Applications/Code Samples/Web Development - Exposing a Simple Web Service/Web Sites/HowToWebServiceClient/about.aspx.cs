//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
using System;

public class about: System.Web.UI.Page
	  {
	protected System.Web.UI.WebControls.Label lblTitle;
	protected System.Web.UI.WebControls.Label lblVersion;
	protected System.Web.UI.WebControls.Label lblCopyright;
	protected System.Web.UI.WebControls.Label lblDescription;
	protected System.Web.UI.WebControls.Label lblCodebase;
	protected System.Web.UI.WebControls.Button btnBack;

#region " Web Form Designer Generated Code ";

	//This call is required by the Web Form Designer.

	private void InitializeComponent() {

		this.Load +=new System.EventHandler(this.Page_Load);
		this.btnBack.Click +=new System.EventHandler(btnBack_Click);

	}

	override protected void OnInit(EventArgs e)
	{
		//
		// CODEGEN: This call is required by the ASP.NET Web Form Designer.
		//
		InitializeComponent();
		base.OnInit(e);
	}

#endregion

	private void Page_Load(object sender, System.EventArgs e)
	{

		//Put user code to initialize the page here

		if (!Page.IsPostBack) {

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

	private void btnBack_Click(object sender, System.EventArgs e)
	{

		// return to the Main page

		Response.Redirect("main.aspx");

	}

}

