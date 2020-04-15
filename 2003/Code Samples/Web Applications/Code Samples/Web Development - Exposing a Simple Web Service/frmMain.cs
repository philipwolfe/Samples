//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

public class frmMain: System.Windows.Forms.Form {

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Windows Form Designer generated code "

	public frmMain () {

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
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.Button btnGetOrderHistory;
    private System.Windows.Forms.TextBox txtCustID;
    private System.Windows.Forms.DataGrid grdOrders;
    private System.Windows.Forms.Label lblNoResults;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.grdOrders = new System.Windows.Forms.DataGrid();

        this.btnGetOrderHistory = new System.Windows.Forms.Button();

        this.txtCustID = new System.Windows.Forms.TextBox();

        this.Label1 = new System.Windows.Forms.Label();

        this.lblNoResults = new System.Windows.Forms.Label();

        ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();

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

        //grdOrders

        //

        this.grdOrders.AccessibleDescription = (string) resources.GetObject("grdOrders.AccessibleDescription");

        this.grdOrders.AccessibleName = (string) resources.GetObject("grdOrders.AccessibleName");

        this.grdOrders.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grdOrders.Anchor");

        this.grdOrders.BackgroundImage = (System.Drawing.Image) resources.GetObject("grdOrders.BackgroundImage");

        this.grdOrders.CaptionFont = (System.Drawing.Font) resources.GetObject("grdOrders.CaptionFont");

        this.grdOrders.CaptionText = resources.GetString("grdOrders.CaptionText");

        this.grdOrders.DataMember = string.Empty;

        this.grdOrders.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grdOrders.Dock");

        this.grdOrders.Enabled = (bool) resources.GetObject("grdOrders.Enabled");

        this.grdOrders.Font = (System.Drawing.Font) resources.GetObject("grdOrders.Font");

        this.grdOrders.HeaderForeColor = System.Drawing.SystemColors.ControlText;

        this.grdOrders.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grdOrders.ImeMode");

        this.grdOrders.Location = (System.Drawing.Point) resources.GetObject("grdOrders.Location");

        this.grdOrders.Name = "grdOrders";

        this.grdOrders.ReadOnly = true;

        this.grdOrders.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grdOrders.RightToLeft");

        this.grdOrders.Size = (System.Drawing.Size) resources.GetObject("grdOrders.Size");

        this.grdOrders.TabIndex = (int) resources.GetObject("grdOrders.TabIndex");

        this.grdOrders.Visible = (bool) resources.GetObject("grdOrders.Visible");

        //

        //btnGetOrderHistory

        //

        this.btnGetOrderHistory.AccessibleDescription = (string) resources.GetObject("btnGetOrderHistory.AccessibleDescription");

        this.btnGetOrderHistory.AccessibleName = (string) resources.GetObject("btnGetOrderHistory.AccessibleName");

        this.btnGetOrderHistory.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnGetOrderHistory.Anchor");

        this.btnGetOrderHistory.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnGetOrderHistory.BackgroundImage");

        this.btnGetOrderHistory.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnGetOrderHistory.Dock");

        this.btnGetOrderHistory.Enabled = (bool) resources.GetObject("btnGetOrderHistory.Enabled");

        this.btnGetOrderHistory.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnGetOrderHistory.FlatStyle");

        this.btnGetOrderHistory.Font = (System.Drawing.Font) resources.GetObject("btnGetOrderHistory.Font");

        this.btnGetOrderHistory.Image = (System.Drawing.Image) resources.GetObject("btnGetOrderHistory.Image");

        this.btnGetOrderHistory.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetOrderHistory.ImageAlign");

        this.btnGetOrderHistory.ImageIndex = (int) resources.GetObject("btnGetOrderHistory.ImageIndex");

        this.btnGetOrderHistory.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnGetOrderHistory.ImeMode");

        this.btnGetOrderHistory.Location = (System.Drawing.Point) resources.GetObject("btnGetOrderHistory.Location");

        this.btnGetOrderHistory.Name = "btnGetOrderHistory";

        this.btnGetOrderHistory.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnGetOrderHistory.RightToLeft");

        this.btnGetOrderHistory.Size = (System.Drawing.Size) resources.GetObject("btnGetOrderHistory.Size");

        this.btnGetOrderHistory.TabIndex = (int) resources.GetObject("btnGetOrderHistory.TabIndex");

        this.btnGetOrderHistory.Text = resources.GetString("btnGetOrderHistory.Text");

        this.btnGetOrderHistory.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetOrderHistory.TextAlign");

        this.btnGetOrderHistory.Visible = (bool) resources.GetObject("btnGetOrderHistory.Visible");

        //

        //txtCustID

        //

        this.txtCustID.AccessibleDescription = (string) resources.GetObject("txtCustID.AccessibleDescription");

        this.txtCustID.AccessibleName = (string) resources.GetObject("txtCustID.AccessibleName");

        this.txtCustID.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtCustID.Anchor");

        this.txtCustID.AutoSize = (bool) resources.GetObject("txtCustID.AutoSize");

        this.txtCustID.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtCustID.BackgroundImage");

        this.txtCustID.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtCustID.Dock");

        this.txtCustID.Enabled = (bool) resources.GetObject("txtCustID.Enabled");

        this.txtCustID.Font = (System.Drawing.Font) resources.GetObject("txtCustID.Font");

        this.txtCustID.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtCustID.ImeMode");

        this.txtCustID.Location = (System.Drawing.Point) resources.GetObject("txtCustID.Location");

        this.txtCustID.MaxLength = (int) resources.GetObject("txtCustID.MaxLength");

        this.txtCustID.Multiline = (bool) resources.GetObject("txtCustID.Multiline");

        this.txtCustID.Name = "txtCustID";

        this.txtCustID.PasswordChar = (char) resources.GetObject("txtCustID.PasswordChar");

        this.txtCustID.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtCustID.RightToLeft");

        this.txtCustID.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtCustID.ScrollBars");

        this.txtCustID.Size = (System.Drawing.Size) resources.GetObject("txtCustID.Size");

        this.txtCustID.TabIndex = (int) resources.GetObject("txtCustID.TabIndex");

        this.txtCustID.Text = resources.GetString("txtCustID.Text");

        this.txtCustID.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtCustID.TextAlign");

        this.txtCustID.Visible = (bool) resources.GetObject("txtCustID.Visible");

        this.txtCustID.WordWrap = (bool) resources.GetObject("txtCustID.WordWrap");

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

        //lblNoResults

        //

        this.lblNoResults.AccessibleDescription = (string) resources.GetObject("lblNoResults.AccessibleDescription");

        this.lblNoResults.AccessibleName = (string) resources.GetObject("lblNoResults.AccessibleName");

        this.lblNoResults.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblNoResults.Anchor");

        this.lblNoResults.AutoSize = (bool) resources.GetObject("lblNoResults.AutoSize");

        this.lblNoResults.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblNoResults.Dock");

        this.lblNoResults.Enabled = (bool) resources.GetObject("lblNoResults.Enabled");

        this.lblNoResults.Font = (System.Drawing.Font) resources.GetObject("lblNoResults.Font");

        this.lblNoResults.Image = (System.Drawing.Image) resources.GetObject("lblNoResults.Image");

        this.lblNoResults.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblNoResults.ImageAlign");

        this.lblNoResults.ImageIndex = (int) resources.GetObject("lblNoResults.ImageIndex");

        this.lblNoResults.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblNoResults.ImeMode");

        this.lblNoResults.Location = (System.Drawing.Point) resources.GetObject("lblNoResults.Location");

        this.lblNoResults.Name = "lblNoResults";

        this.lblNoResults.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblNoResults.RightToLeft");

        this.lblNoResults.Size = (System.Drawing.Size) resources.GetObject("lblNoResults.Size");

        this.lblNoResults.TabIndex = (int) resources.GetObject("lblNoResults.TabIndex");

        this.lblNoResults.Text = resources.GetString("lblNoResults.Text");

        this.lblNoResults.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblNoResults.TextAlign");

        this.lblNoResults.Visible = (bool) resources.GetObject("lblNoResults.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtCustID, this.Label1, this.btnGetOrderHistory, this.grdOrders, this.lblNoResults});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

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

        ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit() ;

        this.ResumeLayout(false);

		this.btnGetOrderHistory.Click +=new EventHandler(btnGetOrderHistory_Click);
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

    // This routine handles the Click event for the "get {Orders" button. It shows

    // how to instantiate Web service proxy classes and bind data returned from a

    // Web service to a DataGrid. DataGrid formatting is also demonstrated.

    private void btnGetOrderHistory_Click(object sender, System.EventArgs e) 
	
	{
		HowTo.localhost.CustomerAndOrderHistoryInfo cohi = null;
		HowTo.localhost.Main ws = new HowTo.localhost.Main();

        if (!CustIDIsValid()) {
            return;
        }

        string strCustID = txtCustID.Text.Trim();

        // Create an instance of the Web service proxy class.

        

        // Create a variable to hold the custom return type.

        

		try 
		{

			cohi = ws.GetCustomerOrderHistory(txtCustID.Text);
       } 
		catch(Exception exp)
		{	
            MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK,MessageBoxIcon.Warning);

        }

		if (cohi.Orders.CustOrderHist.Rows.Count > 0) 
		{
			grdOrders.CaptionText = "Order History for " + cohi.Company + ":";
			grdOrders.CaptionFont = new Font("Microsoft Sans Serif", 10);
			grdOrders.DataSource = cohi.Orders.CustOrderHist;
			// Clear all existing styles or subsequent databinding will cause 
			// runtime exception.
			grdOrders.TableStyles.Clear();

			DataGridTableStyle grdTableStyle1 = new DataGridTableStyle();

			// You must always set the MappingName, even with a DataView that has
			// only one Table. if not, you will get no errors but the formatting
			// will not appear. To avoid mistakes, instead of typing the name of 
			// the table used when creating the DataSet, you can access the 
			// TableName property.

			grdTableStyle1.MappingName = cohi.Orders.Tables[0].TableName;
            
			// The use of column styles overrides the automatic generation of columns 
			// for every column in the DataTable. When column style objects are used,
			// every column you want to display has to have an associate column style 
			// object.

			DataGridTextBoxColumn grdColStyle1 = new DataGridTextBoxColumn();
			grdColStyle1.MappingName = "ProductName";
			grdColStyle1.HeaderText = "Product Name";
			grdColStyle1.Width = 230;

			DataGridTextBoxColumn grdColStyle2 = new DataGridTextBoxColumn();
			grdColStyle2.MappingName = "Total";
			grdColStyle2.HeaderText = "Total";
			grdColStyle2.Format = "c";
			grdColStyle2.Width = 75;

			// Add the column style objects to the table style's collection of 
			// column styles. Without this the styles do not take effect.        

			grdTableStyle1.GridColumnStyles.AddRange
				(new DataGridColumnStyle[] {grdColStyle1, grdColStyle2});

			grdOrders.TableStyles.Add(grdTableStyle1);
			grdOrders.Visible = true;
			lblNoResults.Visible = false;
		}
		else 
		{

			lblNoResults.Text = "No data was returned for the Customer ID you " + 
			"entered. Please check the value and try again. Examples are " + 
			"COMMI, GODOS, and ISLAT.";
			lblNoResults.Visible = true;
			grdOrders.Visible = false;

		}

    }

    // This routine validates the CustomerID.

    private bool CustIDIsValid()
	{

        // Use a regular expression object to check for a pattern match.

        if (!Regex.IsMatch(txtCustID.Text, @"^\s*(\D){5}\s*$")) 
			{
            MessageBox.Show("You must enter a five-letter CustomerID. " + 
                "Examples are COMMI, GODOS, and ISLAT.", this.Text, 
				MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

            return false;

        }

        return true;

    }

}

