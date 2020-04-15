//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

public class frmMain: Form
{

    // ProductData will hold order information that is returned from 
    // SQL Server.

    protected DataSet ProductData = new DataSet();

    // Used to reference the table containing product information in 

    // ProductData.

    protected const string PRODUCT_TABLE_NAME = "Products";

    protected const string SQL_CONNECTION_STRING =
        "Server=localhost;DataBase=Northwind;Integrated Security=SSPI";

    protected const string MSDE_CONNECTION_STRING = 
		@"Server=(local)\NetSDK;DataBase=Northwind;Integrated Security=SSPI";

    //Default values we need to save

    protected BorderStyle DefaultGridBorderStyle;

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Windows Form Designer generated code "

    public frmMain()
	{ 

        //This call is required by the Windows Form Designer.
        InitializeComponent();
        //Add any initialization after the InitializeComponent() call
        // So that we only need to set the title of the application once,
        // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
        // to read the AssemblyTitle attribute.

        AssemblyInfo ainfo = new AssemblyInfo();

        this.Text = ainfo.Title;

        this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);

        //get {the default information for resetting the style later

        DefaultGridBorderStyle = grdProducts.BorderStyle;

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

    private MainMenu mnuMain;
    private MenuItem mnuFile;
    private MenuItem mnuExit;
    private MenuItem mnuHelp;
    private MenuItem mnuAbout;
    private DataGrid grdProducts;
    private System.Windows.Forms.Button btnDefaultFormatting;
    private System.Windows.Forms.Button btnGridProperties;
    private System.Windows.Forms.Button btnTableStyle;
    private System.Windows.Forms.Label lblInstruction;
    private System.Windows.Forms.Button btnColumnStyles;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.btnDefaultFormatting = new System.Windows.Forms.Button();

        this.grdProducts = new System.Windows.Forms.DataGrid();

        this.btnGridProperties = new System.Windows.Forms.Button();

        this.btnTableStyle = new System.Windows.Forms.Button();

        this.btnColumnStyles = new System.Windows.Forms.Button();

        this.lblInstruction = new System.Windows.Forms.Label();

        ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();

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

        //btnDefaultFormatting

        //

        this.btnDefaultFormatting.AccessibleDescription = resources.GetString("btnDefaultFormatting.AccessibleDescription");

        this.btnDefaultFormatting.AccessibleName = resources.GetString("btnDefaultFormatting.AccessibleName");

        this.btnDefaultFormatting.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnDefaultFormatting.Anchor");

        this.btnDefaultFormatting.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnDefaultFormatting.BackgroundImage");

        this.btnDefaultFormatting.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnDefaultFormatting.Dock");

        this.btnDefaultFormatting.Enabled = (bool) resources.GetObject("btnDefaultFormatting.Enabled");

        this.btnDefaultFormatting.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnDefaultFormatting.FlatStyle");

        this.btnDefaultFormatting.Font = (System.Drawing.Font) resources.GetObject("btnDefaultFormatting.Font");

        this.btnDefaultFormatting.Image = (System.Drawing.Image) resources.GetObject("btnDefaultFormatting.Image");

        this.btnDefaultFormatting.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDefaultFormatting.ImageAlign");

        this.btnDefaultFormatting.ImageIndex = (int) resources.GetObject("btnDefaultFormatting.ImageIndex");

        this.btnDefaultFormatting.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnDefaultFormatting.ImeMode");

        this.btnDefaultFormatting.Location = (System.Drawing.Point) resources.GetObject("btnDefaultFormatting.Location");

        this.btnDefaultFormatting.Name = "btnDefaultFormatting";

        this.btnDefaultFormatting.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnDefaultFormatting.RightToLeft");

        this.btnDefaultFormatting.Size = (System.Drawing.Size) resources.GetObject("btnDefaultFormatting.Size");

        this.btnDefaultFormatting.TabIndex = (int) resources.GetObject("btnDefaultFormatting.TabIndex");

        this.btnDefaultFormatting.Text = resources.GetString("btnDefaultFormatting.Text");

        this.btnDefaultFormatting.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDefaultFormatting.TextAlign");

        this.btnDefaultFormatting.Visible = (bool) resources.GetObject("btnDefaultFormatting.Visible");

        //

        //grdProducts

        //

        this.grdProducts.AccessibleDescription = resources.GetString("grdProducts.AccessibleDescription");

        this.grdProducts.AccessibleName = resources.GetString("grdProducts.AccessibleName");

        this.grdProducts.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grdProducts.Anchor");

        this.grdProducts.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText;

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

        //btnGridProperties

        //

        this.btnGridProperties.AccessibleDescription = resources.GetString("btnGridProperties.AccessibleDescription");

        this.btnGridProperties.AccessibleName = resources.GetString("btnGridProperties.AccessibleName");

        this.btnGridProperties.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnGridProperties.Anchor");

        this.btnGridProperties.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnGridProperties.BackgroundImage");

        this.btnGridProperties.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnGridProperties.Dock");

        this.btnGridProperties.Enabled = (bool) resources.GetObject("btnGridProperties.Enabled");

        this.btnGridProperties.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnGridProperties.FlatStyle");

        this.btnGridProperties.Font = (System.Drawing.Font) resources.GetObject("btnGridProperties.Font");

        this.btnGridProperties.Image = (System.Drawing.Image) resources.GetObject("btnGridProperties.Image");

        this.btnGridProperties.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGridProperties.ImageAlign");

        this.btnGridProperties.ImageIndex = (int) resources.GetObject("btnGridProperties.ImageIndex");

        this.btnGridProperties.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnGridProperties.ImeMode");

        this.btnGridProperties.Location = (System.Drawing.Point) resources.GetObject("btnGridProperties.Location");

        this.btnGridProperties.Name = "btnGridProperties";

        this.btnGridProperties.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnGridProperties.RightToLeft");

        this.btnGridProperties.Size = (System.Drawing.Size) resources.GetObject("btnGridProperties.Size");

        this.btnGridProperties.TabIndex = (int) resources.GetObject("btnGridProperties.TabIndex");

        this.btnGridProperties.Text = resources.GetString("btnGridProperties.Text");

        this.btnGridProperties.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGridProperties.TextAlign");

        this.btnGridProperties.Visible = (bool) resources.GetObject("btnGridProperties.Visible");

        //

        //btnTableStyle

        //

        this.btnTableStyle.AccessibleDescription = resources.GetString("btnTableStyle.AccessibleDescription");

        this.btnTableStyle.AccessibleName = resources.GetString("btnTableStyle.AccessibleName");

        this.btnTableStyle.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnTableStyle.Anchor");

        this.btnTableStyle.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnTableStyle.BackgroundImage");

        this.btnTableStyle.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnTableStyle.Dock");

        this.btnTableStyle.Enabled = (bool) resources.GetObject("btnTableStyle.Enabled");

        this.btnTableStyle.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnTableStyle.FlatStyle");

        this.btnTableStyle.Font = (System.Drawing.Font) resources.GetObject("btnTableStyle.Font");

        this.btnTableStyle.Image = (System.Drawing.Image) resources.GetObject("btnTableStyle.Image");

        this.btnTableStyle.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnTableStyle.ImageAlign");

        this.btnTableStyle.ImageIndex = (int) resources.GetObject("btnTableStyle.ImageIndex");

        this.btnTableStyle.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnTableStyle.ImeMode");

        this.btnTableStyle.Location = (System.Drawing.Point) resources.GetObject("btnTableStyle.Location");

        this.btnTableStyle.Name = "btnTableStyle";

        this.btnTableStyle.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnTableStyle.RightToLeft");

        this.btnTableStyle.Size = (System.Drawing.Size) resources.GetObject("btnTableStyle.Size");

        this.btnTableStyle.TabIndex = (int) resources.GetObject("btnTableStyle.TabIndex");

        this.btnTableStyle.Text = resources.GetString("btnTableStyle.Text");

        this.btnTableStyle.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnTableStyle.TextAlign");

        this.btnTableStyle.Visible = (bool) resources.GetObject("btnTableStyle.Visible");

        //

        //btnColumnStyles

        //

        this.btnColumnStyles.AccessibleDescription = resources.GetString("btnColumnStyles.AccessibleDescription");

        this.btnColumnStyles.AccessibleName = resources.GetString("btnColumnStyles.AccessibleName");

        this.btnColumnStyles.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnColumnStyles.Anchor");

        this.btnColumnStyles.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnColumnStyles.BackgroundImage");

        this.btnColumnStyles.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnColumnStyles.Dock");

        this.btnColumnStyles.Enabled = (bool) resources.GetObject("btnColumnStyles.Enabled");

        this.btnColumnStyles.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnColumnStyles.FlatStyle");

        this.btnColumnStyles.Font = (System.Drawing.Font) resources.GetObject("btnColumnStyles.Font");

        this.btnColumnStyles.Image = (System.Drawing.Image) resources.GetObject("btnColumnStyles.Image");

        this.btnColumnStyles.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnColumnStyles.ImageAlign");

        this.btnColumnStyles.ImageIndex = (int) resources.GetObject("btnColumnStyles.ImageIndex");

        this.btnColumnStyles.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnColumnStyles.ImeMode");

        this.btnColumnStyles.Location = (System.Drawing.Point) resources.GetObject("btnColumnStyles.Location");

        this.btnColumnStyles.Name = "btnColumnStyles";

        this.btnColumnStyles.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnColumnStyles.RightToLeft");

        this.btnColumnStyles.Size = (System.Drawing.Size) resources.GetObject("btnColumnStyles.Size");

        this.btnColumnStyles.TabIndex = (int) resources.GetObject("btnColumnStyles.TabIndex");

        this.btnColumnStyles.Text = resources.GetString("btnColumnStyles.Text");

        this.btnColumnStyles.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnColumnStyles.TextAlign");

        this.btnColumnStyles.Visible = (bool) resources.GetObject("btnColumnStyles.Visible");

        //

        //lblInstruction

        //

        this.lblInstruction.AccessibleDescription = (string) resources.GetObject("lblInstruction.AccessibleDescription");

        this.lblInstruction.AccessibleName = (string) resources.GetObject("lblInstruction.AccessibleName");

        this.lblInstruction.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblInstruction.Anchor");

        this.lblInstruction.AutoSize = (bool) resources.GetObject("lblInstruction.AutoSize");

        this.lblInstruction.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblInstruction.Dock");

        this.lblInstruction.Enabled = (bool) resources.GetObject("lblInstruction.Enabled");

        this.lblInstruction.Font = (System.Drawing.Font) resources.GetObject("lblInstruction.Font");

        this.lblInstruction.Image = (System.Drawing.Image) resources.GetObject("lblInstruction.Image");

        this.lblInstruction.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblInstruction.ImageAlign");

        this.lblInstruction.ImageIndex = (int) resources.GetObject("lblInstruction.ImageIndex");

        this.lblInstruction.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblInstruction.ImeMode");

        this.lblInstruction.Location = (System.Drawing.Point) resources.GetObject("lblInstruction.Location");

        this.lblInstruction.Name = "lblInstruction";

        this.lblInstruction.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblInstruction.RightToLeft");

        this.lblInstruction.Size = (System.Drawing.Size) resources.GetObject("lblInstruction.Size");

        this.lblInstruction.TabIndex = (int) resources.GetObject("lblInstruction.TabIndex");

        this.lblInstruction.Text = resources.GetString("lblInstruction.Text");

        this.lblInstruction.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblInstruction.TextAlign");

        this.lblInstruction.Visible = (bool) resources.GetObject("lblInstruction.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblInstruction, this.btnColumnStyles, this.btnTableStyle, this.btnGridProperties, this.btnDefaultFormatting, this.grdProducts});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximizeBox = false;

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
		this.btnColumnStyles.Click +=new EventHandler(btnColumnStyles_Click);
		this.btnDefaultFormatting.Click +=new EventHandler(btnDefaultFormatting_Click);
		this.btnGridProperties.Click +=new EventHandler(btnGridProperties_Click);
		this.btnTableStyle.Click +=new EventHandler(btnTableStyle_Click);
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

	static string Connectionstring = SQL_CONNECTION_STRING;
	static bool DidPreviouslyConnect = false;

    private void BindDataGrid()
		{
        // Display a status message saying that we're attempting to connect.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

        frmStatus frmStatusMessage = new frmStatus();

        if (!DidPreviouslyConnect) 
			{
            frmStatusMessage.Show("Connecting to SQL Server");
        }

        // Attempt to connect to the local SQL server instance, and a local
        // MSDE installation (with Northwind).  

        bool IsConnecting = true;

        while (IsConnecting)
			{
            try {

                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in SQL Server, or be part of the Administrators
                // group for this to work.

                SqlConnection northwindConnection = new SqlConnection(Connectionstring);

                // The SqlDataAdapter is used to move data between SQL Server, 

                // and a DataSet.

                SqlDataAdapter ProductAdapter = new SqlDataAdapter(
                    "SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM products", northwindConnection);

                // Populate the Dataset with the information from the products

                // table.  Since a Dataset can hold multiple result sets, it's

                // a good idea to "name" the result set when you populate the

                // DataSet.  In this case, the result set is named "Products".

                ProductAdapter.Fill(ProductData, PRODUCT_TABLE_NAME);

                // Data has been successfully retrieved, so break out of the loop.

                IsConnecting = false;

                DidPreviouslyConnect = true;

           } catch
			{
				if (Connectionstring == SQL_CONNECTION_STRING) 
				{
					// Couldn't connect to SQL Server.  Now try MSDE.
					Connectionstring = MSDE_CONNECTION_STRING;
					frmStatusMessage.Show("Connecting to MSDE");
				}
				else 
				{

					// Unable to connect to SQL Server or MSDE
					frmStatusMessage.Close();
					MessageBox.Show("To run this sample, you must have SQL " + 
					"or MSDE with the Northwind database installed.  For " +
					"instructions on installing MSDE, view the ReadMe file.");
					Application.Exit();

				}

            }

        }

        frmStatusMessage.Close();

        // Bind the DataGrid to the desired table in the DataSet. This

        // will cause the product information to display.

        grdProducts.DataSource = ProductData.Tables[PRODUCT_TABLE_NAME];

    }

    private void FormatGridWithBothTableAndColumnStyles()
	{

        // Continue to set DataGrid properties directly, but only

        // those that are not covered by DataGridTableStyle properties.

            grdProducts.BackColor = Color.GhostWhite;
            grdProducts.BackgroundColor = Color.Lavender;
            grdProducts.BorderStyle = BorderStyle.None;
            grdProducts.CaptionBackColor = Color.RoyalBlue;
            grdProducts.CaptionFont = new Font("Tahoma", (float)10.0, FontStyle.Bold);
            grdProducts.CaptionForeColor = Color.Bisque;
            grdProducts.CaptionText = "Northwind Products";
            grdProducts.Font = new Font("Tahoma", (float)8.0);
            grdProducts.ParentRowsBackColor = Color.Lavender;
            grdProducts.ParentRowsForeColor = Color.MidnightBlue;

        // Put much of the formatting possible here.

        DataGridTableStyle grdTableStyle1 = new DataGridTableStyle();
        grdTableStyle1.AlternatingBackColor = Color.GhostWhite;
        grdTableStyle1.BackColor = Color.GhostWhite;
        grdTableStyle1.ForeColor = Color.MidnightBlue;
        grdTableStyle1.GridLineColor = Color.RoyalBlue;
        grdTableStyle1.HeaderBackColor = Color.MidnightBlue;
        grdTableStyle1.HeaderFont = new Font("Tahoma", (float)8.0, FontStyle.Bold);
        grdTableStyle1.HeaderForeColor = Color.Lavender;
        grdTableStyle1.SelectionBackColor = Color.Teal;
        grdTableStyle1.SelectionForeColor = Color.PaleGreen;

            // Do not forget to set the MappingName property. 
            // Without this, the DataGridTableStyle properties
            // and any associated DataGridColumnStyle objects
            // will have no effect.

        grdTableStyle1.MappingName = PRODUCT_TABLE_NAME;
        grdTableStyle1.PreferredColumnWidth = 125;
        grdTableStyle1.PreferredRowHeight = 15;

        // Format each column that you want to appear in the DataGrid.
        // In most cases, the DataGridTextBoxColumn class is appropriate.
        // However, you can also use the DataGridBoolColumn class. Both
        // of these extend the MustInherit DataGridColumnStyle class. Notice
        // that the column style properties available to you are more limited
        // than those for the table style. For example, you can! change
        // the color of an individual column.

        DataGridTextBoxColumn grdColStyle1 = new DataGridTextBoxColumn();

        grdColStyle1.HeaderText = "ID";
        grdColStyle1.MappingName = "ProductID";
        grdColStyle1.Width = 50;

        DataGridTextBoxColumn grdColStyle2 = new DataGridTextBoxColumn();

        grdColStyle2.HeaderText = "Name";
        grdColStyle2.MappingName = "ProductName";

        DataGridTextBoxColumn grdColStyle3 = new DataGridTextBoxColumn();
        grdColStyle3.HeaderText = "Price";
        grdColStyle3.MappingName = "UnitPrice";
        grdColStyle3.Width = 75;
        grdColStyle3.ReadOnly = true;

        DataGridTextBoxColumn grdColStyle4 = new DataGridTextBoxColumn();
        grdColStyle4.HeaderText = "# In Stock";
        grdColStyle4.MappingName = "UnitsInStock";
        grdColStyle4.Width = 75;
        grdColStyle4.Alignment = HorizontalAlignment.Center;

        // Add the style objects to the table style's collection of 
        // column styles. Without this the styles do not take effect.        

        grdTableStyle1.GridColumnStyles.AddRange
            (new DataGridColumnStyle[]
            {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4});

        grdProducts.TableStyles.Add(grdTableStyle1);

    }

    private void FormatGridWithoutTableStyles()
	{
        // Change the appearance of the DataGrid by directly setting 

        // its formatting properties.

            grdProducts.AlternatingBackColor = Color.GhostWhite;
            grdProducts.BackColor = Color.GhostWhite;
            grdProducts.BackgroundColor = Color.Lavender;
            grdProducts.BorderStyle = BorderStyle.None;
            grdProducts.CaptionBackColor = Color.RoyalBlue;
            grdProducts.CaptionFont = new Font("Tahoma", (float)10.0, FontStyle.Bold);
            grdProducts.CaptionForeColor = Color.Bisque;
            grdProducts.CaptionText = "Northwind Products";
            grdProducts.Font = new Font("Tahoma", (float)8.0);
            grdProducts.ForeColor = Color.MidnightBlue;
            grdProducts.GridLineColor = Color.RoyalBlue;
            grdProducts.HeaderBackColor = Color.MidnightBlue;
            grdProducts.HeaderFont = new Font("Tahoma", (float)8.0, FontStyle.Bold);
            grdProducts.HeaderForeColor = Color.Lavender;
            grdProducts.ParentRowsBackColor = Color.Lavender;
            grdProducts.ParentRowsForeColor = Color.MidnightBlue;
            grdProducts.SelectionBackColor = Color.Teal;
            grdProducts.SelectionForeColor = Color.PaleGreen;

        

    }

    private void FormatGridWithTableStyles()
	{

        // Continue to set DataGrid properties directly, but only

        // those that are not covered by DataGridTableStyle properties.

            grdProducts.BackColor = Color.GhostWhite;
            grdProducts.BackgroundColor = Color.Lavender;
            grdProducts.BorderStyle = BorderStyle.None;
            grdProducts.CaptionBackColor = Color.RoyalBlue;
            grdProducts.CaptionFont = new Font("Tahoma", (float) 10.0, FontStyle.Bold);
            grdProducts.CaptionForeColor = Color.Bisque;
            grdProducts.CaptionText = "Northwind Products";
            grdProducts.Font = new Font("Tahoma", (float) 8.0);
            grdProducts.ParentRowsBackColor = Color.Lavender;
            grdProducts.ParentRowsForeColor = Color.MidnightBlue;

        

        // Set other formatting properties using a DataGridTableStyle object.
        // Note that some of the DataGrid formatting properties overlap those
        // of the the DataGridTableStyle. So it is usually desirable to set as
        // many of the properties you can in the DataGrid and then make any
        // other adjustments using a DataGridTableStyle. 
        //
        // Also, because a DataGrid can contain multiple DataTable objects, a 
        // different DataGridTableStyle object can be applied to the data in each 
        // DataTable. To do this, simply set the MappingName property to the name 
        // of the DataTable containing the data you wish to format.
        DataGridTableStyle grdTableStyle1 = new DataGridTableStyle();
            grdTableStyle1.AlternatingBackColor = Color.GhostWhite;
            grdTableStyle1.BackColor = Color.GhostWhite;
            grdTableStyle1.ForeColor = Color.MidnightBlue;
            grdTableStyle1.GridLineColor = Color.RoyalBlue;
            grdTableStyle1.HeaderBackColor = Color.MidnightBlue;
            grdTableStyle1.HeaderFont = new Font("Tahoma", (float) 8.0, FontStyle.Bold);
            grdTableStyle1.HeaderForeColor = Color.Lavender;
            grdTableStyle1.SelectionBackColor = Color.Teal;
            grdTableStyle1.SelectionForeColor = Color.PaleGreen;

            // Do not forget to set the MappingName property. 
            // Without this, the DataGridTableStyle properties
            // and any associated DataGridColumnStyle objects
            // will have no effect.

            grdTableStyle1.MappingName = PRODUCT_TABLE_NAME;
            grdTableStyle1.PreferredColumnWidth = 125;
            grdTableStyle1.PreferredRowHeight = 15;

        // Add the style to the DataGrid's table styles collection. 
        // Without this the styles do not take effect.
        grdProducts.TableStyles.Add(grdTableStyle1);

    }

    private void ResetDemo()
	{

        // DEMO PURPOSES ONLY: 
        // Clear the DataTable so that subsequent button clicks keep 
        // adding to the existing data.

        if (ProductData.Tables[PRODUCT_TABLE_NAME] != null) {
            ProductData.Tables[PRODUCT_TABLE_NAME].Clear();
        }

        // Clear out the existing TableStyles and result default formatting.
            grdProducts.BackgroundColor = SystemColors.InactiveCaptionText;
            grdProducts.CaptionText = string.Empty;
            grdProducts.CaptionBackColor = SystemColors.ActiveCaption;
            grdProducts.TableStyles.Clear();
            grdProducts.ResetAlternatingBackColor();
            grdProducts.ResetBackColor();
            grdProducts.ResetForeColor();
            grdProducts.ResetGridLineColor();
            grdProducts.ResetHeaderBackColor();
            grdProducts.ResetHeaderFont();
            grdProducts.ResetHeaderForeColor();
            grdProducts.ResetSelectionBackColor();
            grdProducts.ResetSelectionForeColor();
            grdProducts.ResetText();
            grdProducts.BorderStyle = DefaultGridBorderStyle;
    }

    private void btnColumnStyles_Click(object sender, System.EventArgs e) 
	{
        ResetDemo();
        BindDataGrid();

        // if you need column-level formatting, add DataGridColumnStyle objects
        // to a DataGridTableStyle object. Be aware, however, that you 
        // will have to create a DataGridColumnStyle object for every 
        // column that you want to appear. You can! simply tweak a subset
        // of the columns. In other words, you can! lay new styles over
        // existing styles. It's an all or nothing proposition.
        FormatGridWithBothTableAndColumnStyles();

    }

    private void btnDefaultFormatting_Click(object sender, System.EventArgs e) 
	{

        ResetDemo();

        // This displays data in the DataGrid using the default Visual Studio .NET formatting.

        BindDataGrid();

    }

    private void btnGridProperties_Click(object sender, System.EventArgs e) 
	{

        ResetDemo();

        BindDataGrid();

        // if you do not need control over the appearance of individual columns
        // then you can just set the various formatting properties of the DataGrid.
        // Alternatively, you could create a DataGridTableStyle and achieve
        // the same look (see the btnTableStyle_Click event handler)
        FormatGridWithoutTableStyles();

    }

    private void btnTableStyle_Click(object sender, System.EventArgs e) 
	{
        ResetDemo();

        BindDataGrid();

        // if you do not need control over the appearance of individual columns
        // then you can create a DataGridTableStyle that is applied to all
        // columns. You can also just set the DataGrid formatting properties
        // directly (see the btnGridProperties_Click event handler).
        FormatGridWithTableStyles();

    }

}

