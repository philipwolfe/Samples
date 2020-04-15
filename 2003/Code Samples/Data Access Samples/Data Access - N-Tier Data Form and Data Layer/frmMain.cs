//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


public class frmMain:System.Windows.Forms.Form 
{
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

    private System.Windows.Forms.MenuItem MenuItem1;

    private System.Windows.Forms.Button btnNext;

    private System.Windows.Forms.Button btnPrevious;

    private System.Windows.Forms.MenuItem MenuItem2;

    private System.Windows.Forms.MenuItem MenuItem3;

    private System.Windows.Forms.MenuItem MenuItem4;

    private System.Windows.Forms.DataGrid grdSuppliers;

    private System.Windows.Forms.DataGrid grdProducts;

    private System.Windows.Forms.Button btnUpdate;

    private System.Windows.Forms.Button btnRefresh;

    private System.Windows.Forms.Label lblTitle;

    private void InitializeComponent() 
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.MenuItem1 = new System.Windows.Forms.MenuItem();

        this.btnNext = new System.Windows.Forms.Button();

        this.btnPrevious = new System.Windows.Forms.Button();

        this.MenuItem2 = new System.Windows.Forms.MenuItem();

        this.MenuItem3 = new System.Windows.Forms.MenuItem();

        this.MenuItem4 = new System.Windows.Forms.MenuItem();

        this.grdSuppliers = new System.Windows.Forms.DataGrid();

        this.grdProducts = new System.Windows.Forms.DataGrid();

        this.btnUpdate = new System.Windows.Forms.Button();

        this.btnRefresh = new System.Windows.Forms.Button();

        this.lblTitle = new System.Windows.Forms.Label();

        ((System.ComponentModel.ISupportInitialize) this.grdSuppliers).BeginInit() ;

        ((System.ComponentModel.ISupportInitialize) this.grdProducts).BeginInit() ;

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

		this.mnuExit.Click+=new EventHandler(mnuExit_Click);

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

		this.mnuAbout.Click+=new EventHandler(mnuAbout_Click);

        //

        //MenuItem1

        //

        this.MenuItem1.Enabled = (bool) resources.GetObject("MenuItem1.Enabled");

        this.MenuItem1.Index = 0;

        this.MenuItem1.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem1.Shortcut");

        this.MenuItem1.ShowShortcut = (bool) resources.GetObject("MenuItem1.ShowShortcut");

        this.MenuItem1.Text = resources.GetString("MenuItem1.Text");

        this.MenuItem1.Visible = (bool) resources.GetObject("MenuItem1.Visible");

        //

        //btnNext

        //

        this.btnNext.AccessibleDescription = resources.GetString("btnNext.AccessibleDescription");

        this.btnNext.AccessibleName = resources.GetString("btnNext.AccessibleName");

        this.btnNext.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnNext.Anchor");

        this.btnNext.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnNext.BackgroundImage");

        this.btnNext.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnNext.Dock");

        this.btnNext.Enabled = (bool) resources.GetObject("btnNext.Enabled");

        this.btnNext.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnNext.FlatStyle");

        this.btnNext.Font = (System.Drawing.Font) resources.GetObject("btnNext.Font");

        this.btnNext.Image = (System.Drawing.Image) resources.GetObject("btnNext.Image");

        this.btnNext.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnNext.ImageAlign");

        this.btnNext.ImageIndex = (int) resources.GetObject("btnNext.ImageIndex");

        this.btnNext.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnNext.ImeMode");

        this.btnNext.Location = (System.Drawing.Point) resources.GetObject("btnNext.Location");

        this.btnNext.Name = "btnNext";

        this.btnNext.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnNext.RightToLeft");

        this.btnNext.Size = (System.Drawing.Size) resources.GetObject("btnNext.Size");

        this.btnNext.TabIndex = (int) resources.GetObject("btnNext.TabIndex");

        this.btnNext.Text = resources.GetString("btnNext.Text");

        this.btnNext.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnNext.TextAlign");

        this.btnNext.Visible = (bool) resources.GetObject("btnNext.Visible");

		this.btnNext.Click+=new EventHandler(btnNext_Click);

        //

        //btnPrevious

        //

        this.btnPrevious.AccessibleDescription = resources.GetString("btnPrevious.AccessibleDescription");

        this.btnPrevious.AccessibleName = resources.GetString("btnPrevious.AccessibleName");

        this.btnPrevious.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnPrevious.Anchor");

        this.btnPrevious.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnPrevious.BackgroundImage");

        this.btnPrevious.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnPrevious.Dock");

        this.btnPrevious.Enabled = (bool) resources.GetObject("btnPrevious.Enabled");

        this.btnPrevious.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnPrevious.FlatStyle");

        this.btnPrevious.Font = (System.Drawing.Font) resources.GetObject("btnPrevious.Font");

        this.btnPrevious.Image = (System.Drawing.Image) resources.GetObject("btnPrevious.Image");

        this.btnPrevious.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPrevious.ImageAlign");

        this.btnPrevious.ImageIndex = (int) resources.GetObject("btnPrevious.ImageIndex");

        this.btnPrevious.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnPrevious.ImeMode");

        this.btnPrevious.Location = (System.Drawing.Point) resources.GetObject("btnPrevious.Location");

        this.btnPrevious.Name = "btnPrevious";

        this.btnPrevious.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnPrevious.RightToLeft");

        this.btnPrevious.Size = (System.Drawing.Size) resources.GetObject("btnPrevious.Size");

        this.btnPrevious.TabIndex = (int) resources.GetObject("btnPrevious.TabIndex");

        this.btnPrevious.Text = resources.GetString("btnPrevious.Text");

        this.btnPrevious.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPrevious.TextAlign");

        this.btnPrevious.Visible = (bool) resources.GetObject("btnPrevious.Visible");
		
		this.btnPrevious.Click+=new EventHandler(btnPrevious_Click);

        //

        //MenuItem2

        //

        this.MenuItem2.Enabled = (bool) resources.GetObject("MenuItem2.Enabled");

        this.MenuItem2.Index = 0;

        this.MenuItem2.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem2.Shortcut");

        this.MenuItem2.ShowShortcut = (bool) resources.GetObject("MenuItem2.ShowShortcut");

        this.MenuItem2.Text = resources.GetString("MenuItem2.Text");

        this.MenuItem2.Visible = (bool) resources.GetObject("MenuItem2.Visible");

        //

        //MenuItem3

        //

        this.MenuItem3.Enabled = (bool) resources.GetObject("MenuItem3.Enabled");

        this.MenuItem3.Index = -1;

        this.MenuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.MenuItem2});

        this.MenuItem3.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem3.Shortcut");

        this.MenuItem3.ShowShortcut = (bool) resources.GetObject("MenuItem3.ShowShortcut");

        this.MenuItem3.Text = resources.GetString("MenuItem3.Text");

        this.MenuItem3.Visible = (bool) resources.GetObject("MenuItem3.Visible");

        //

        //MenuItem4

        //

        this.MenuItem4.Enabled = (bool) resources.GetObject("MenuItem4.Enabled");

        this.MenuItem4.Index = -1;

        this.MenuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.MenuItem1});

        this.MenuItem4.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem4.Shortcut");

        this.MenuItem4.ShowShortcut = (bool) resources.GetObject("MenuItem4.ShowShortcut");

        this.MenuItem4.Text = resources.GetString("MenuItem4.Text");

        this.MenuItem4.Visible = (bool) resources.GetObject("MenuItem4.Visible");

        //

        //grdSuppliers

        //

        this.grdSuppliers.AccessibleDescription = resources.GetString("grdSuppliers.AccessibleDescription");

        this.grdSuppliers.AccessibleName = resources.GetString("grdSuppliers.AccessibleName");

        this.grdSuppliers.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grdSuppliers.Anchor");

        this.grdSuppliers.BackgroundImage = (System.Drawing.Image) resources.GetObject("grdSuppliers.BackgroundImage");

        this.grdSuppliers.CaptionFont = (System.Drawing.Font) resources.GetObject("grdSuppliers.CaptionFont");

        this.grdSuppliers.CaptionText = resources.GetString("grdSuppliers.CaptionText");

        this.grdSuppliers.DataMember = string.Empty;

        this.grdSuppliers.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grdSuppliers.Dock");

        this.grdSuppliers.Enabled = (bool) resources.GetObject("grdSuppliers.Enabled");

        this.grdSuppliers.Font = (System.Drawing.Font) resources.GetObject("grdSuppliers.Font");

        this.grdSuppliers.HeaderForeColor = System.Drawing.SystemColors.ControlText;

        this.grdSuppliers.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grdSuppliers.ImeMode");

        this.grdSuppliers.Location = (System.Drawing.Point) resources.GetObject("grdSuppliers.Location");

        this.grdSuppliers.Name = "grdSuppliers";

        this.grdSuppliers.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grdSuppliers.RightToLeft");

        this.grdSuppliers.Size = (System.Drawing.Size) resources.GetObject("grdSuppliers.Size");

        this.grdSuppliers.TabIndex = (int) resources.GetObject("grdSuppliers.TabIndex");

        this.grdSuppliers.Visible = (bool) resources.GetObject("grdSuppliers.Visible");

		this.grdSuppliers.Click+=new EventHandler(grdSuppliers_Click);

		this.grdSuppliers.CurrentCellChanged+=new EventHandler(grdSuppliers_CurrentCellChanged);

        //

        //grdProducts

        //

        this.grdProducts.AccessibleDescription = resources.GetString("grdProducts.AccessibleDescription");

        this.grdProducts.AccessibleName = resources.GetString("grdProducts.AccessibleName");

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

		this.grdProducts.Click+=new EventHandler(grdProducts_Click);

		this.grdProducts.CurrentCellChanged+=new EventHandler(grdProducts_CurrentCellChanged);

        //

        //btnUpdate

        //

        this.btnUpdate.AccessibleDescription = resources.GetString("btnUpdate.AccessibleDescription");

        this.btnUpdate.AccessibleName = resources.GetString("btnUpdate.AccessibleName");

        this.btnUpdate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnUpdate.Anchor");

        this.btnUpdate.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnUpdate.BackgroundImage");

        this.btnUpdate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnUpdate.Dock");

        this.btnUpdate.Enabled = (bool) resources.GetObject("btnUpdate.Enabled");

        this.btnUpdate.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnUpdate.FlatStyle");

        this.btnUpdate.Font = (System.Drawing.Font) resources.GetObject("btnUpdate.Font");

        this.btnUpdate.Image = (System.Drawing.Image) resources.GetObject("btnUpdate.Image");

        this.btnUpdate.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnUpdate.ImageAlign");

        this.btnUpdate.ImageIndex = (int) resources.GetObject("btnUpdate.ImageIndex");

        this.btnUpdate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnUpdate.ImeMode");

        this.btnUpdate.Location = (System.Drawing.Point) resources.GetObject("btnUpdate.Location");

        this.btnUpdate.Name = "btnUpdate";

        this.btnUpdate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnUpdate.RightToLeft");

        this.btnUpdate.Size = (System.Drawing.Size) resources.GetObject("btnUpdate.Size");

        this.btnUpdate.TabIndex = (int) resources.GetObject("btnUpdate.TabIndex");

        this.btnUpdate.Text = resources.GetString("btnUpdate.Text");

        this.btnUpdate.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnUpdate.TextAlign");

        this.btnUpdate.Visible = (bool) resources.GetObject("btnUpdate.Visible");

		this.btnUpdate.Click+=new EventHandler(btnUpdate_Click);

        //

        //btnRefresh

        //

        this.btnRefresh.AccessibleDescription = resources.GetString("btnRefresh.AccessibleDescription");

        this.btnRefresh.AccessibleName = resources.GetString("btnRefresh.AccessibleName");

        this.btnRefresh.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnRefresh.Anchor");

        this.btnRefresh.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnRefresh.BackgroundImage");

        this.btnRefresh.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnRefresh.Dock");

        this.btnRefresh.Enabled = (bool) resources.GetObject("btnRefresh.Enabled");

        this.btnRefresh.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnRefresh.FlatStyle");

        this.btnRefresh.Font = (System.Drawing.Font) resources.GetObject("btnRefresh.Font");

        this.btnRefresh.Image = (System.Drawing.Image) resources.GetObject("btnRefresh.Image");

        this.btnRefresh.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRefresh.ImageAlign");

        this.btnRefresh.ImageIndex = (int) resources.GetObject("btnRefresh.ImageIndex");

        this.btnRefresh.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnRefresh.ImeMode");

        this.btnRefresh.Location = (System.Drawing.Point) resources.GetObject("btnRefresh.Location");

        this.btnRefresh.Name = "btnRefresh";

        this.btnRefresh.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnRefresh.RightToLeft");

        this.btnRefresh.Size = (System.Drawing.Size) resources.GetObject("btnRefresh.Size");

        this.btnRefresh.TabIndex = (int) resources.GetObject("btnRefresh.TabIndex");

        this.btnRefresh.Text = resources.GetString("btnRefresh.Text");

        this.btnRefresh.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRefresh.TextAlign");

        this.btnRefresh.Visible = (bool) resources.GetObject("btnRefresh.Visible");
		
		this.btnRefresh.Click+=new EventHandler(btnRefresh_Click);

        //

        //lblTitle

        //

        this.lblTitle.AccessibleDescription = resources.GetString("lblTitle.AccessibleDescription");

        this.lblTitle.AccessibleName = resources.GetString("lblTitle.AccessibleName");

        this.lblTitle.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblTitle.Anchor");

        this.lblTitle.AutoSize = (bool) resources.GetObject("lblTitle.AutoSize");

        this.lblTitle.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblTitle.Dock");

        this.lblTitle.Enabled = (bool) resources.GetObject("lblTitle.Enabled");

        this.lblTitle.Font = (System.Drawing.Font) resources.GetObject("lblTitle.Font");

        this.lblTitle.Image = (System.Drawing.Image) resources.GetObject("lblTitle.Image");

        this.lblTitle.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblTitle.ImageAlign");

        this.lblTitle.ImageIndex = (int) resources.GetObject("lblTitle.ImageIndex");

        this.lblTitle.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblTitle.ImeMode");

        this.lblTitle.Location = (System.Drawing.Point) resources.GetObject("lblTitle.Location");

        this.lblTitle.Name = "lblTitle";

        this.lblTitle.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblTitle.RightToLeft");

        this.lblTitle.Size = (System.Drawing.Size) resources.GetObject("lblTitle.Size");

        this.lblTitle.TabIndex = (int) resources.GetObject("lblTitle.TabIndex");

        this.lblTitle.Text = resources.GetString("lblTitle.Text");

        this.lblTitle.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblTitle.TextAlign");

        this.lblTitle.Visible = (bool) resources.GetObject("lblTitle.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblTitle, this.btnRefresh, this.btnUpdate, this.grdProducts, this.grdSuppliers, this.btnNext, this.btnPrevious});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.KeyPreview = true;

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

        ((System.ComponentModel.ISupportInitialize) this.grdSuppliers).EndInit();

        ((System.ComponentModel.ISupportInitialize) this.grdProducts).EndInit();

		this.Load+=new EventHandler(frmMain_Load);

		this.KeyDown+=new KeyEventHandler(frmMain_KeyDown);

        this.ResumeLayout(false);

	

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

    protected bool DidPreviouslyConnect  = false;

    private DataSet dsSupplierProducts;

    private DataTable dtSupplier;

    private DataTable dtProduct;

    private DataView dvSupplier;

    private DataView dvProduct;

    public DataAccess m_DAL;

	public DataAccess.ConnectionCompletedDelegate myD1;

    frmStatus frmStatusMessage;

    // Handle the > Button click event.

    private void btnNext_Click(object sender, System.EventArgs e)
	{

        // Move to the next record

        NextRecord();

    }

    // Handle the < Button click event.

    private void btnPrevious_Click(object sender, System.EventArgs e)
	{

        // Move to the previous record

        PreviousRecord();

    }

    // Refresh the data by telling the form to reload. This will get data from the 
    //   database without sending any changes. All changes are abandoned.

    private void btnRefresh_Click(object sender, System.EventArgs e)
	{

        // Simply tell the Form to reload

        frmMain_Load(this, new System.EventArgs());

    }

    // This button sends any updates to the DataAccessLayer object, and then
    //   reloads the data.

    private void btnUpdate_Click(object sender, System.EventArgs e)
	{

        
		m_DAL = new DataAccess();
		m_DAL.ConnectionCompleted+=new DataAccess.ConnectionCompletedDelegate(m_DAL_ConnectionCompleted);
		m_DAL.ConnectionFailure+=new DataAccess.ConnectionFailureDelegate(m_DAL_ConnectionFailure);
		m_DAL.ConnectionStatusChange+=new DataAccess.ConnectionStatusChangeDelegate(m_DAL_ConnectionStatusChange);
			
		
	
        m_DAL.UpdateDataSet(dsSupplierProducts.GetChanges());
        frmMain_Load(this, new System.EventArgs());

    }

    // Handle the PositionChanged event. 

    protected void dtSupplier_PositionChanged(object sender, System.EventArgs e)
	{

        BindSuppliersGrid();
        BindProductsGrid();

    }

    // Handle the KeyDown event for the Form. For this event to fire the KeyPreview
    // property on the Form must be set to true. It is false by default.

    private void frmMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
	{

        // Let the user scroll through the records using the cursor keys.
        // Left and right are next and previous. Home and end are first and last.

		if (e.KeyCode == Keys.Right)
		{
			NextRecord();
		}
		if (e.KeyCode == Keys.Left)
		{
			PreviousRecord();
		}
        
    }

    // Handle the Form load event.

    private void frmMain_Load(object sender, System.EventArgs e) 
	{
		
        //frmStatus frmStatusMessage = new frmStatus();
        GetDataSet();
        BindSuppliersGrid();
        BindProductsGrid();
		


		

    }

    // This subroutine ensures that if a new row is being added, the correct
    //   SupplierID is automatically added. Note: You should also provide an 
    //   event handler for the grdProducts.CurrentCellChanged event.

    private void grdProducts_Click(object sender, System.EventArgs e)
	{

        // if the row is a new row, that is being added, you should automatically
        //   put in the SupplierID Field (since this is a Master/Detail grid.

			if (grdProducts[grdProducts.CurrentRowIndex, 2]==DBNull.Value)
			{
				// This is a new row, so insert the proper SupplierID
				grdProducts[grdProducts.CurrentRowIndex, 2] = grdSuppliers[grdSuppliers.CurrentRowIndex, 0];

			}

    }

    // This subroutine ensures that if a new row is being added, the correct
    //   SupplierID is automatically added. It is in addition to the 
    //   grdProducts_Click event handler, since if the user clicks inside of a
    //   cell, this event is raised instead.

    private void grdProducts_CurrentCellChanged(object sender, System.EventArgs e) 
	{

        grdProducts.Select(grdProducts.CurrentCell.RowNumber);

        // if the row is a new row, that is being added, you should automatically
        //   put in the SupplierID Field (since this is a Master/Detail grid.

        if (grdProducts[grdProducts.CurrentRowIndex, 2] == DBNull.Value) 
		{

            // This is a new row, so insert the proper SupplierID

            grdProducts[grdProducts.CurrentRowIndex, 2] = grdSuppliers[grdSuppliers.CurrentRowIndex, 0];

        }

    }

    // Handle the DataGrid Click event, which fires only when the DataGrid control 
    // frame--! the rows or cells--is clicked. Therefore, it's also a good idea 
    // to handle the CurrentCellChanged event.

    private void grdSuppliers_Click(object sender, System.EventArgs e)
	{

        // Bind the Products grid based on the selection in grdSuppliers.

        BindProductsGrid();

    }

    // Handle the CurrentCellChanged event, which fires when the user clicks a 
    // different cell on the grid. Along with the DataGrid Click event, this ensures 
    // that the Products grid will update no matter where the user clicks on the 
    // Suppliers grid.

    private void grdSuppliers_CurrentCellChanged(object sender, System.EventArgs e)
	{

        // Highlight the entire row for user feedback.

        grdSuppliers.Select(grdSuppliers.CurrentCell.RowNumber);

        // Bind the Products grid based on the selection in grdSuppliers.

        BindProductsGrid();

    }

    // Close the frmStatusMessage when the connection is completed, regardless
    //   of success.

    private void m_DAL_ConnectionCompleted(string success) 
	{
		
        frmStatusMessage.Close();

    }

    // Alert the user if the DAL failed to connect for some reason.

    private void m_DAL_ConnectionFailure(string reason)
	{

        MessageBox.Show(reason, this.Text);
        Application.Exit();

    }

    // Show frmStatus to display connection status.

    private void m_DAL_ConnectionStatusChange(string status)
	{
		frmStatusMessage = new frmStatus();
        frmStatusMessage.Show(status);

    }

    // Bind and format the Products grid based on the user's current selection
    // in the Orders grid.

    void BindProductsGrid()
	{

        // Get the current SupplierID by using the DataGrid's CurrentRowIndex, i.e.,
        // the currently selected row, and using it to match the row in the 
        // DataView. { access the "SupplierID" column to get the SupplierID 
        // for that DataRowView.

        string strCurrentSupplierID  = dvSupplier[grdSuppliers.CurrentRowIndex]["SupplierID"].ToString();

        // Filter the OrderDetails data based on the currently selected OrderID.
        //   Since empty SupplierID's are possible (if the user is adding a new supplier)
        //   these must be taken into consideration

        if (strCurrentSupplierID == "")
		{

            strCurrentSupplierID = "-1";

        }

        // Filter the products to display only those with the appropriate
        //   SupplierID

        dvProduct.RowFilter = "SupplierID = " + strCurrentSupplierID;

        // Put a caption on the Grid, and attach a DataSource

        grdProducts.CaptionText = "Products";
        grdProducts.DataSource = dvProduct;
       

    }

    // Bind and format the Products grid

    void BindSuppliersGrid()
	{

        // Put a caption on the Grid, and attach a DataSource
        grdSuppliers.CaptionText = "Suppliers";
        grdSuppliers.DataSource = dvSupplier;
    }

    // Create the Dataset used in this sample. It contains two tables consisting of 
    // Supplier info and the Products info.
    // The Dataset is retrieved from a DataAccessLayer object.

    void GetDataSet()
	{

        
        // Create an instance of the DataAccessLayer and 
        //   retrieve the data (if it hasn't already been created).

        if (m_DAL == null) 
		{

            m_DAL = new DataAccess();
			m_DAL.ConnectionCompleted+=new DataAccess.ConnectionCompletedDelegate(m_DAL_ConnectionCompleted);
			m_DAL.ConnectionFailure+=new DataAccess.ConnectionFailureDelegate(m_DAL_ConnectionFailure);
			m_DAL.ConnectionStatusChange+=new DataAccess.ConnectionStatusChangeDelegate(m_DAL_ConnectionStatusChange);
			
        }

        // Call the CreateDataset to fill our local Dataset with data

        dsSupplierProducts = m_DAL.CreateDataSet();

        // Set variables for the DataTables for use later.

        dtSupplier = dsSupplierProducts.Tables["Supplier"];
        dtProduct = dsSupplierProducts.Tables["Product"];

        // Set up DataViews for the DataGrids 

        dvSupplier = dtSupplier.DefaultView;
        dvProduct = dtProduct.DefaultView;

    }

    // Move the selected Supplier Position to the next record.

    public void NextRecord()
	{

        grdSuppliers.UnSelect(grdSuppliers.CurrentRowIndex);
        grdSuppliers.CurrentRowIndex += 1;
        grdSuppliers.Select(grdSuppliers.CurrentRowIndex);

    }

    // Move the selected Supplier Position to the previous record.

    public void PreviousRecord()
	{

        grdSuppliers.UnSelect(grdSuppliers.CurrentRowIndex);
        if (grdSuppliers.CurrentRowIndex > 0)
		{

            grdSuppliers.CurrentRowIndex -= 1;

        }

        grdSuppliers.Select(grdSuppliers.CurrentRowIndex);

    }

}

