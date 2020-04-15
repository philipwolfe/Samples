//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
using System;
using System.Web.UI.WebControls;

public class Main: System.Web.UI.Page
	  {
	protected System.Web.UI.WebControls.Label lblTitle;
    protected System.Web.UI.WebControls.DataGrid grdProducts;
    protected System.Web.UI.WebControls.Button btnTenMost;
    protected System.Web.UI.WebControls.Button btnAbout;

#region " Web Form Designer Generated Code ";

	//This call is required by the Web Form Designer.

	private void InitializeComponent() {
		this.Load +=new System.EventHandler(Page_Load);
		this.btnAbout.Click +=new System.EventHandler(btnAbout_Click);
		this.btnTenMost.Click +=new EventHandler(btnTenMost_Click);

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

    // This routine handles the click event for the "About..." button.

    private void btnAbout_Click(object sender, System.EventArgs e)
	{
        // Open the About page
        Response.Redirect("about.aspx");
    }

    // This routine handles the click event for the "get {Ten Most Expensive Products"
    // button. The Web service proxy class is instantiated. The results of the Web 
    // method call are then bound to the DataGrid.

    private void btnTenMost_Click(object sender, System.EventArgs e) 
	{
        HowToWebServiceClient.localhost.Main ws = new HowToWebServiceClient.localhost.Main();
        grdProducts.DataSource = ws.GetTenMostExpensiveProducts();
        grdProducts.DataBind();

    }

    // This routine handles the Web page's Load event.

    private void Page_Load(object sender, System.EventArgs e)
	{

        //Put user code to initialize the page here

        if (!Page.IsPostBack) {

            // So that we only need to set the title of the application once, we use 
            // the AssemblyInfo class (defined in the AssemblyInfo.cs file) to read the 
            // AssemblyTitle attribute.

            AssemblyInfo ainfo = new AssemblyInfo();

            this.lblTitle.Text = ainfo.Title;

        }

    }

}

