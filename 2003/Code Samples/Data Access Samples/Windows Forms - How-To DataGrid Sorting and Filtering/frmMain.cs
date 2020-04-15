//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

public class frmMain: System.Windows.Forms.Form {

    // ProductData will hold order information that is returned from 
    // SQL Server.

    protected DataSet ProductData = new DataSet();

    // This sample assumes that you have SQL Server installed on your
    // development machine.  if not, you must have MSDE installed, with
    // Northwind.  See the ReadMe for details.  Optionally, you can
    // modify the connection string to point to a different SQL server
    // by changing the "Server=" below.

    protected const string SQL_CONNECTION_STRING = "Server=localhost;" +
		"DataBase=Northwind;Integrated Security=SSPI";

    protected const string MSDE_CONNECTION_STRING =
        @"Server=(local)\NetSDK;DataBase=Northwind;Integrated Security=SSPI";

    protected const string CONNECTION_ERROR_MSG =
        "To run this sample, you must have SQL or MSDE with the Northwind database installed.  For " +
        "instructions on installing MSDE, view the ReadMe file.";

    protected bool didPreviouslyConnect = false;
    protected string connectionstring = SQL_CONNECTION_STRING;

    // Used to reference the table containing product information in 
    // ProductData.

    protected const string PRODUCT_TABLE_NAME = "Products";


	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Windows Form Designer generated code "

    public frmMain() {

        //This call is required by the Windows Form Designer.

        InitializeComponent();

        //Add any initialization after the InitializeComponent() call

        // So that we only need to set the title of the application once,

        // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)

        // to read the AssemblyTitle attribute.

        AssemblyInfo ainfo = new AssemblyInfo();

        this.Text = ainfo.Title;

        this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);

    }

    //Form overrides dispose to clean up the component list.

    protected override void Dispose(bool disposing) {

        if (disposing) {

            if (components != null) {

                components.Dispose();

            }

        }

        base.Dispose(disposing);

    }

    //Required by the Windows Form Designer

    private System.ComponentModel.IContainer components = null;

    //NOTE: The following procedure is required by the Windows Form Designer

    //It can be modified using the Windows Form Designer.  

    //Do not modify it using the code editor.
    private System.Windows.Forms.MainMenu mnuMain;
    private System.Windows.Forms.MenuItem mnuFile;
    private System.Windows.Forms.MenuItem mnuExit;
    private System.Windows.Forms.MenuItem mnuHelp;
    private System.Windows.Forms.MenuItem mnuAbout;
    private System.Windows.Forms.Button btnFilter;
    private System.Windows.Forms.TextBox txtFilter;
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.DataGrid grdProducts;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.btnFilter = new System.Windows.Forms.Button();

        this.txtFilter = new System.Windows.Forms.TextBox();

        this.Label1 = new System.Windows.Forms.Label();

        this.btnLoad = new System.Windows.Forms.Button();

        this.grdProducts = new System.Windows.Forms.DataGrid();

        ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit() ;

        this.SuspendLayout();

        //

        //mnuMain

        //

        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuHelp});

        this.mnuMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("mnuMain.RightToLeft");

        //

        //mnuFile

        //

        this.mnuFile.Enabled = (bool) resources.GetObject("mnuFile.Enabled");

        this.mnuFile.Index = 0;

        this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});

        this.mnuFile.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuFile.Shortcut");

        this.mnuFile.ShowShortcut = (bool) resources.GetObject("mnuFile.ShowShortcut");

        this.mnuFile.Text = resources.GetString("mnuFile.Text");

        this.mnuFile.Visible = (bool) resources.GetObject("mnuFile.Visible");

        //

        //mnuExit

        //

        this.mnuExit.Enabled = (bool) resources.GetObject("mnuExit.Enabled");

        this.mnuExit.Index = 0;

        this.mnuExit.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuExit.Shortcut");

        this.mnuExit.ShowShortcut = (bool) resources.GetObject("mnuExit.ShowShortcut");

        this.mnuExit.Text = resources.GetString("mnuExit.Text");

        this.mnuExit.Visible = (bool) resources.GetObject("mnuExit.Visible");

        //

        //mnuHelp

        //

        this.mnuHelp.Enabled = (bool) resources.GetObject("mnuHelp.Enabled");

        this.mnuHelp.Index = 1;

        this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});

        this.mnuHelp.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuHelp.Shortcut");

        this.mnuHelp.ShowShortcut = (bool) resources.GetObject("mnuHelp.ShowShortcut");

        this.mnuHelp.Text = resources.GetString("mnuHelp.Text");

        this.mnuHelp.Visible = (bool) resources.GetObject("mnuHelp.Visible");

        //

        //mnuAbout

        //

        this.mnuAbout.Enabled = (bool) resources.GetObject("mnuAbout.Enabled");

        this.mnuAbout.Index = 0;

        this.mnuAbout.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuAbout.Shortcut");

        this.mnuAbout.ShowShortcut = (bool) resources.GetObject("mnuAbout.ShowShortcut");

        this.mnuAbout.Text = resources.GetString("mnuAbout.Text");

        this.mnuAbout.Visible = (bool) resources.GetObject("mnuAbout.Visible");

        //

        //btnFilter

        //

        this.btnFilter.AccessibleDescription = (string) resources.GetObject("btnFilter.AccessibleDescription");

        this.btnFilter.AccessibleName = (string) resources.GetObject("btnFilter.AccessibleName");

        this.btnFilter.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnFilter.Anchor");

        this.btnFilter.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnFilter.BackgroundImage");

        this.btnFilter.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnFilter.Dock");

        this.btnFilter.Enabled = (bool) resources.GetObject("btnFilter.Enabled");

        this.btnFilter.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnFilter.FlatStyle");

        this.btnFilter.Font = (System.Drawing.Font) resources.GetObject("btnFilter.Font");

        this.btnFilter.Image = (System.Drawing.Image) resources.GetObject("btnFilter.Image");

        this.btnFilter.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnFilter.ImageAlign");

        this.btnFilter.ImageIndex = (int) resources.GetObject("btnFilter.ImageIndex");

        this.btnFilter.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnFilter.ImeMode");

        this.btnFilter.Location = (System.Drawing.Point) resources.GetObject("btnFilter.Location");

        this.btnFilter.Name = "btnFilter";

        this.btnFilter.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnFilter.RightToLeft");

        this.btnFilter.Size = (System.Drawing.Size) resources.GetObject("btnFilter.Size");

        this.btnFilter.TabIndex = (int) resources.GetObject("btnFilter.TabIndex");

        this.btnFilter.Text = resources.GetString("btnFilter.Text");

        this.btnFilter.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnFilter.TextAlign");

        this.btnFilter.Visible = (bool) resources.GetObject("btnFilter.Visible");

        //

        //txtFilter

        //

        this.txtFilter.AccessibleDescription = (string) resources.GetObject("txtFilter.AccessibleDescription");

        this.txtFilter.AccessibleName = (string) resources.GetObject("txtFilter.AccessibleName");

        this.txtFilter.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtFilter.Anchor");

        this.txtFilter.AutoSize = (bool) resources.GetObject("txtFilter.AutoSize");

        this.txtFilter.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtFilter.BackgroundImage");

        this.txtFilter.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtFilter.Dock");

        this.txtFilter.Enabled = (bool) resources.GetObject("txtFilter.Enabled");

        this.txtFilter.Font = (System.Drawing.Font) resources.GetObject("txtFilter.Font");

        this.txtFilter.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtFilter.ImeMode");

        this.txtFilter.Location = (System.Drawing.Point) resources.GetObject("txtFilter.Location");

        this.txtFilter.MaxLength = (int) resources.GetObject("txtFilter.MaxLength");

        this.txtFilter.Multiline = (bool) resources.GetObject("txtFilter.Multiline");

        this.txtFilter.Name = "txtFilter";

        this.txtFilter.PasswordChar = (char) resources.GetObject("txtFilter.PasswordChar");

        this.txtFilter.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtFilter.RightToLeft");

        this.txtFilter.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtFilter.ScrollBars");

        this.txtFilter.Size = (System.Drawing.Size) resources.GetObject("txtFilter.Size");

        this.txtFilter.TabIndex = (int) resources.GetObject("txtFilter.TabIndex");

        this.txtFilter.Text = resources.GetString("txtFilter.Text");

        this.txtFilter.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtFilter.TextAlign");

        this.txtFilter.Visible = (bool) resources.GetObject("txtFilter.Visible");

        this.txtFilter.WordWrap = (bool) resources.GetObject("txtFilter.WordWrap");

        //

        //Label1

        //

        this.Label1.AccessibleDescription = (string) resources.GetObject("Label1.AccessibleDescription");

        this.Label1.AccessibleName = (string) resources.GetObject("Label1.AccessibleName");

        this.Label1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label1.Anchor");

        this.Label1.AutoSize = (bool) resources.GetObject("Label1.AutoSize");

        this.Label1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label1.Dock");

        this.Label1.Enabled = (bool) resources.GetObject("Label1.Enabled");

        this.Label1.Font = (System.Drawing.Font) resources.GetObject("Label1.Font");

        this.Label1.Image = (System.Drawing.Image) resources.GetObject("Label1.Image");

        this.Label1.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label1.ImageAlign");

        this.Label1.ImageIndex = (int) resources.GetObject("Label1.ImageIndex");

        this.Label1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label1.ImeMode");

        this.Label1.Location = (System.Drawing.Point) resources.GetObject("Label1.Location");

        this.Label1.Name = "Label1";

        this.Label1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label1.RightToLeft");

        this.Label1.Size = (System.Drawing.Size) resources.GetObject("Label1.Size");

        this.Label1.TabIndex = (int) resources.GetObject("Label1.TabIndex");

        this.Label1.Text = resources.GetString("Label1.Text");

        this.Label1.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label1.TextAlign");

        this.Label1.Visible = (bool) resources.GetObject("Label1.Visible");

        //

        //btnLoad

        //

        this.btnLoad.AccessibleDescription = (string) resources.GetObject("btnLoad.AccessibleDescription");

        this.btnLoad.AccessibleName = (string) resources.GetObject("btnLoad.AccessibleName");

        this.btnLoad.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnLoad.Anchor");

        this.btnLoad.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnLoad.BackgroundImage");

        this.btnLoad.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnLoad.Dock");

        this.btnLoad.Enabled = (bool) resources.GetObject("btnLoad.Enabled");

        this.btnLoad.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnLoad.FlatStyle");

        this.btnLoad.Font = (System.Drawing.Font) resources.GetObject("btnLoad.Font");

        this.btnLoad.Image = (System.Drawing.Image) resources.GetObject("btnLoad.Image");

        this.btnLoad.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnLoad.ImageAlign");

        this.btnLoad.ImageIndex = (int) resources.GetObject("btnLoad.ImageIndex");

        this.btnLoad.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnLoad.ImeMode");

        this.btnLoad.Location = (System.Drawing.Point) resources.GetObject("btnLoad.Location");

        this.btnLoad.Name = "btnLoad";

        this.btnLoad.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnLoad.RightToLeft");

        this.btnLoad.Size = (System.Drawing.Size) resources.GetObject("btnLoad.Size");

        this.btnLoad.TabIndex = (int) resources.GetObject("btnLoad.TabIndex");

        this.btnLoad.Text = resources.GetString("btnLoad.Text");

        this.btnLoad.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnLoad.TextAlign");

        this.btnLoad.Visible = (bool) resources.GetObject("btnLoad.Visible");

        //

        //grdProducts

        //

        this.grdProducts.AccessibleDescription = (string) resources.GetObject("grdProducts.AccessibleDescription");

        this.grdProducts.AccessibleName = (string) resources.GetObject("grdProducts.AccessibleName");

        this.grdProducts.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grdProducts.Anchor");

        this.grdProducts.BackgroundImage = (System.Drawing.Image) resources.GetObject("grdProducts.BackgroundImage");

        this.grdProducts.CaptionFont = (System.Drawing.Font) resources.GetObject("grdProducts.CaptionFont");

        this.grdProducts.CaptionText = resources.GetString("grdProducts.CaptionText");

        this.grdProducts.DataMember = string.Empty;

        this.grdProducts.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grdProducts.Dock");

        this.grdProducts.Enabled = (bool) resources.GetObject("grdProducts.Enabled");

        this.grdProducts.Font = (System.Drawing.Font) resources.GetObject("grdProducts.Font");

        this.grdProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText;

        this.grdProducts.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grdProducts.ImeMode");

        this.grdProducts.Location = (System.Drawing.Point) resources.GetObject("grdProducts.Location");

        this.grdProducts.Name = "grdProducts";

        this.grdProducts.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grdProducts.RightToLeft");

        this.grdProducts.Size = (System.Drawing.Size) resources.GetObject("grdProducts.Size");

        this.grdProducts.TabIndex = (int) resources.GetObject("grdProducts.TabIndex");

        this.grdProducts.Visible = (bool) resources.GetObject("grdProducts.Visible");

        //

        //frmMain

        //

        this.AccessibleDescription = (string) resources.GetObject("$this.AccessibleDescription");

        this.AccessibleName = (string) resources.GetObject("$this.AccessibleName");

        this.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("$this.Anchor");

        this.AutoScaleBaseSize = (System.Drawing.Size) resources.GetObject("$this.AutoScaleBaseSize");

        this.AutoScroll = (bool) resources.GetObject("$this.AutoScroll");

        this.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMargin");

        this.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMinSize");

        this.BackgroundImage = (System.Drawing.Image) resources.GetObject("$this.BackgroundImage");

        this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnFilter, this.txtFilter, this.Label1, this.btnLoad, this.grdProducts});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.Menu = this.mnuMain;

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "frmMain";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

        ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();

        this.ResumeLayout(false);

		this.btnFilter.Click +=new EventHandler(btnFilter_Click);
		this.btnLoad.Click +=new EventHandler(btnLoad_Click);
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);

    }

#endregion

#region " Standard Menu Code "

    

    

    // This code simply shows the About form.

    private void mnuAbout_Click(object sender, System.EventArgs e) {

        // Open the About form in Dialog Mode

        frmAbout frm = new frmAbout();

        frm.ShowDialog(this);

        frm.Dispose();

    }

    // This code will close the form.

    private void mnuExit_Click(object sender, System.EventArgs e) {

        // Close the current form

        this.Close();

    }

#endregion

    private void btnFilter_Click(object sender, System.EventArgs e) 
	{
        const string MESSAGEBOX_CAPTION = "Filter";

        // Sanity check to make sure there's data before attempting to
        // filter

        Debug.Assert(ProductData.Tables[PRODUCT_TABLE_NAME] != null, 
		"No product data loaded in " + ProductData.Tables[PRODUCT_TABLE_NAME]);

            // Filter the view so that only product names starting with a
            // specified string are available.

            ProductData.Tables[PRODUCT_TABLE_NAME].DefaultView.RowFilter = "ProductName like '" + txtFilter.Text + "%'";

            // Are there any matching products?

            if (ProductData.Tables[PRODUCT_TABLE_NAME].DefaultView.Count == 0) 
				{

                MessageBox.Show("No matching rows.",
                    MESSAGEBOX_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }

            // By binding the grid to the DataView, the grid will now display
            // only the matching rows.

            grdProducts.DataSource = ProductData.Tables[PRODUCT_TABLE_NAME].DefaultView;

        

    }

    private void btnLoad_Click(object sender, System.EventArgs e) 
	{
        frmStatus frmStatusMessage =  new frmStatus();

        if (!didPreviouslyConnect) 
			{
            frmStatusMessage.Show("Connecting to SQL Server");
        }

        bool isConnecting = true;

        while (isConnecting)
		{
            try {

                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in SQL Server, or be part of the Administrators
                // group for this to work.  You must also have Nortiwind installed
                // in either SQL Server, or the MSDE sample database.  See the
                // readme for details.

                SqlConnection northwindConnection = new SqlConnection(connectionstring);

                // The SqlDataAdapter is used to move data between SQL Server, 
                // and a DataSet.

                SqlDataAdapter ProductAdapter = new SqlDataAdapter(
                    "select * from products",
                    northwindConnection);

                // Clear out any old data that has been previously loaded into
                // the DataSet

                ProductData.Clear();

                // Populate the Dataset with the information from the products
                // table.  Since a Dataset can hold multiple result sets, it's
                // a good idea to "name" the result set when you populate the
                // DataSet.  In this case, the result set is named "Products".

                ProductAdapter.Fill(ProductData, PRODUCT_TABLE_NAME);

                // Bind the DataGrid to the desired table in the DataSet. This
                // will cause the product information to display.

                grdProducts.DataSource = ProductData.Tables[PRODUCT_TABLE_NAME];

                // Now that the grid is populated, let the user filter the results.

                btnFilter.Enabled = true;
                isConnecting = false;

           } 
			catch
			{

				if (connectionstring == SQL_CONNECTION_STRING) 
				{

					// Couldn't connect to SQL Server.  Now try MSDE.
					connectionstring = MSDE_CONNECTION_STRING;
					frmStatusMessage.Show("Connecting to MSDE");
				}
				else 
				{

					// Unable to connect to SQL Server or MSDE
					MessageBox.Show(CONNECTION_ERROR_MSG, 
						"Connection Failed!", MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				Application.Exit();

				}

            }

        }

        frmStatusMessage.Close();

    }

}

