//Copyright (C) 2002 Microsoft Corporation

//All rights reserved.

//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 

//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 

//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.IO;
using System.Net;
using System.Threading;
using Microsoft.Uddi;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using HowTo;

public class frmMain:System.Windows.Forms.Form 
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

    const string WS_DATA_RETRIEVAL_ERROR  = 

        "An error occurred trying to retrieve the data from the Web Service." + 
        "The Web service may currently be down. You might attempt to access " + 
        "it directly: ";

    const string WS_CONNECTION_STATUS  = 
        "Contacting the Web Service and retrieving data. Please stand by...";

    // For the Fallback (UDDI) tab.

    const string SERVICE_KEY  = "906e9751-6677-454e-ad7c-dca3c6699ccd";

    protected frmStatus frmStatus;

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

    internal System.Windows.Forms.Label Label1;

    internal System.Windows.Forms.ColumnHeader chAmazonPrice;

    internal System.Windows.Forms.ColumnHeader chAmazonRank;

    internal System.Windows.Forms.ColumnHeader chBNPrice;

    internal System.Windows.Forms.ColumnHeader chBNRank;

    internal System.Windows.Forms.ColumnHeader chISBN;

    internal System.Windows.Forms.Label Label2;

    internal System.Windows.Forms.Label Label3;

    internal System.Windows.Forms.Label Label4;

    internal System.Windows.Forms.Label Label5;

    internal System.Windows.Forms.Label Label10;

    internal System.Windows.Forms.Button btnCartoon;

    private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.tabWebServices = new System.Windows.Forms.TabControl();
		this.pgeBooks = new System.Windows.Forms.TabPage();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.txtISBN = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.btnGetBookData = new System.Windows.Forms.Button();
		this.lvwBooks = new System.Windows.Forms.ListView();
		this.chISBN = new System.Windows.Forms.ColumnHeader();
		this.chAmazonPrice = new System.Windows.Forms.ColumnHeader();
		this.chAmazonRank = new System.Windows.Forms.ColumnHeader();
		this.chBNPrice = new System.Windows.Forms.ColumnHeader();
		this.chBNRank = new System.Windows.Forms.ColumnHeader();
		this.pgeDilbert = new System.Windows.Forms.TabPage();
		this.btnCartoon = new System.Windows.Forms.Button();
		this.txtAsyncWaitPeriod = new System.Windows.Forms.TextBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.picDilbert = new System.Windows.Forms.PictureBox();
		this.Label10 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.tabWebServices.SuspendLayout();
		this.pgeBooks.SuspendLayout();
		this.pgeDilbert.SuspendLayout();
		this.SuspendLayout();
		// 
		// mnuMain
		// 
		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuFile,
																				this.mnuHelp});
		this.mnuMain.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("mnuMain.RightToLeft")));
		// 
		// mnuFile
		// 
		this.mnuFile.Enabled = ((bool)(resources.GetObject("mnuFile.Enabled")));
		this.mnuFile.Index = 0;
		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuExit});
		this.mnuFile.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuFile.Shortcut")));
		this.mnuFile.ShowShortcut = ((bool)(resources.GetObject("mnuFile.ShowShortcut")));
		this.mnuFile.Text = resources.GetString("mnuFile.Text");
		this.mnuFile.Visible = ((bool)(resources.GetObject("mnuFile.Visible")));
		// 
		// mnuExit
		// 
		this.mnuExit.Enabled = ((bool)(resources.GetObject("mnuExit.Enabled")));
		this.mnuExit.Index = 0;
		this.mnuExit.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuExit.Shortcut")));
		this.mnuExit.ShowShortcut = ((bool)(resources.GetObject("mnuExit.ShowShortcut")));
		this.mnuExit.Text = resources.GetString("mnuExit.Text");
		this.mnuExit.Visible = ((bool)(resources.GetObject("mnuExit.Visible")));
		this.mnuExit.Click+=new EventHandler(mnuExit_Click);
		// 
		// mnuHelp
		// 
		this.mnuHelp.Enabled = ((bool)(resources.GetObject("mnuHelp.Enabled")));
		this.mnuHelp.Index = 1;
		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuAbout});
		this.mnuHelp.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuHelp.Shortcut")));
		this.mnuHelp.ShowShortcut = ((bool)(resources.GetObject("mnuHelp.ShowShortcut")));
		this.mnuHelp.Text = resources.GetString("mnuHelp.Text");
		this.mnuHelp.Visible = ((bool)(resources.GetObject("mnuHelp.Visible")));
		// 
		// mnuAbout
		// 
		this.mnuAbout.Enabled = ((bool)(resources.GetObject("mnuAbout.Enabled")));
		this.mnuAbout.Index = 0;
		this.mnuAbout.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuAbout.Shortcut")));
		this.mnuAbout.ShowShortcut = ((bool)(resources.GetObject("mnuAbout.ShowShortcut")));
		this.mnuAbout.Text = resources.GetString("mnuAbout.Text");
		this.mnuAbout.Visible = ((bool)(resources.GetObject("mnuAbout.Visible")));
		this.mnuAbout.Click+=new EventHandler(mnuAbout_Click);
		// 
		// tabWebServices
		// 
		this.tabWebServices.AccessibleDescription = resources.GetString("tabWebServices.AccessibleDescription");
		this.tabWebServices.AccessibleName = resources.GetString("tabWebServices.AccessibleName");
		this.tabWebServices.Alignment = ((System.Windows.Forms.TabAlignment)(resources.GetObject("tabWebServices.Alignment")));
		this.tabWebServices.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabWebServices.Anchor")));
		this.tabWebServices.Appearance = ((System.Windows.Forms.TabAppearance)(resources.GetObject("tabWebServices.Appearance")));
		this.tabWebServices.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabWebServices.BackgroundImage")));
		this.tabWebServices.Controls.Add(this.pgeBooks);
		this.tabWebServices.Controls.Add(this.pgeDilbert);
		this.tabWebServices.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabWebServices.Dock")));
		this.tabWebServices.Enabled = ((bool)(resources.GetObject("tabWebServices.Enabled")));
		this.tabWebServices.Font = ((System.Drawing.Font)(resources.GetObject("tabWebServices.Font")));
		this.tabWebServices.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabWebServices.ImeMode")));
		this.tabWebServices.ItemSize = ((System.Drawing.Size)(resources.GetObject("tabWebServices.ItemSize")));
		this.tabWebServices.Location = ((System.Drawing.Point)(resources.GetObject("tabWebServices.Location")));
		this.tabWebServices.Name = "tabWebServices";
		this.tabWebServices.Padding = ((System.Drawing.Point)(resources.GetObject("tabWebServices.Padding")));
		this.tabWebServices.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabWebServices.RightToLeft")));
		this.tabWebServices.SelectedIndex = 0;
		this.tabWebServices.ShowToolTips = ((bool)(resources.GetObject("tabWebServices.ShowToolTips")));
		this.tabWebServices.Size = ((System.Drawing.Size)(resources.GetObject("tabWebServices.Size")));
		this.tabWebServices.TabIndex = ((int)(resources.GetObject("tabWebServices.TabIndex")));
		this.tabWebServices.Text = resources.GetString("tabWebServices.Text");
		this.tabWebServices.Visible = ((bool)(resources.GetObject("tabWebServices.Visible")));
		// 
		// pgeBooks
		// 
		this.pgeBooks.AccessibleDescription = resources.GetString("pgeBooks.AccessibleDescription");
		this.pgeBooks.AccessibleName = resources.GetString("pgeBooks.AccessibleName");
		this.pgeBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("pgeBooks.Anchor")));
		this.pgeBooks.AutoScroll = ((bool)(resources.GetObject("pgeBooks.AutoScroll")));
		this.pgeBooks.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("pgeBooks.AutoScrollMargin")));
		this.pgeBooks.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("pgeBooks.AutoScrollMinSize")));
		this.pgeBooks.BackColor = System.Drawing.SystemColors.Control;
		this.pgeBooks.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pgeBooks.BackgroundImage")));
		this.pgeBooks.Controls.Add(this.Label4);
		this.pgeBooks.Controls.Add(this.Label3);
		this.pgeBooks.Controls.Add(this.txtISBN);
		this.pgeBooks.Controls.Add(this.Label2);
		this.pgeBooks.Controls.Add(this.btnGetBookData);
		this.pgeBooks.Controls.Add(this.lvwBooks);
		this.pgeBooks.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("pgeBooks.Dock")));
		this.pgeBooks.Enabled = ((bool)(resources.GetObject("pgeBooks.Enabled")));
		this.pgeBooks.Font = ((System.Drawing.Font)(resources.GetObject("pgeBooks.Font")));
		this.pgeBooks.ImageIndex = ((int)(resources.GetObject("pgeBooks.ImageIndex")));
		this.pgeBooks.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("pgeBooks.ImeMode")));
		this.pgeBooks.Location = ((System.Drawing.Point)(resources.GetObject("pgeBooks.Location")));
		this.pgeBooks.Name = "pgeBooks";
		this.pgeBooks.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("pgeBooks.RightToLeft")));
		this.pgeBooks.Size = ((System.Drawing.Size)(resources.GetObject("pgeBooks.Size")));
		this.pgeBooks.TabIndex = ((int)(resources.GetObject("pgeBooks.TabIndex")));
		this.pgeBooks.Text = resources.GetString("pgeBooks.Text");
		this.pgeBooks.ToolTipText = resources.GetString("pgeBooks.ToolTipText");
		this.pgeBooks.Visible = ((bool)(resources.GetObject("pgeBooks.Visible")));
		// 
		// Label4
		// 
		this.Label4.AccessibleDescription = resources.GetString("Label4.AccessibleDescription");
		this.Label4.AccessibleName = resources.GetString("Label4.AccessibleName");
		this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label4.Anchor")));
		this.Label4.AutoSize = ((bool)(resources.GetObject("Label4.AutoSize")));
		this.Label4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label4.Dock")));
		this.Label4.Enabled = ((bool)(resources.GetObject("Label4.Enabled")));
		this.Label4.Font = ((System.Drawing.Font)(resources.GetObject("Label4.Font")));
		this.Label4.Image = ((System.Drawing.Image)(resources.GetObject("Label4.Image")));
		this.Label4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label4.ImageAlign")));
		this.Label4.ImageIndex = ((int)(resources.GetObject("Label4.ImageIndex")));
		this.Label4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label4.ImeMode")));
		this.Label4.Location = ((System.Drawing.Point)(resources.GetObject("Label4.Location")));
		this.Label4.Name = "Label4";
		this.Label4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label4.RightToLeft")));
		this.Label4.Size = ((System.Drawing.Size)(resources.GetObject("Label4.Size")));
		this.Label4.TabIndex = ((int)(resources.GetObject("Label4.TabIndex")));
		this.Label4.Text = resources.GetString("Label4.Text");
		this.Label4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label4.TextAlign")));
		this.Label4.Visible = ((bool)(resources.GetObject("Label4.Visible")));
		// 
		// Label3
		// 
		this.Label3.AccessibleDescription = resources.GetString("Label3.AccessibleDescription");
		this.Label3.AccessibleName = resources.GetString("Label3.AccessibleName");
		this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label3.Anchor")));
		this.Label3.AutoSize = ((bool)(resources.GetObject("Label3.AutoSize")));
		this.Label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label3.Dock")));
		this.Label3.Enabled = ((bool)(resources.GetObject("Label3.Enabled")));
		this.Label3.Font = ((System.Drawing.Font)(resources.GetObject("Label3.Font")));
		this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
		this.Label3.Image = ((System.Drawing.Image)(resources.GetObject("Label3.Image")));
		this.Label3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label3.ImageAlign")));
		this.Label3.ImageIndex = ((int)(resources.GetObject("Label3.ImageIndex")));
		this.Label3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label3.ImeMode")));
		this.Label3.Location = ((System.Drawing.Point)(resources.GetObject("Label3.Location")));
		this.Label3.Name = "Label3";
		this.Label3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label3.RightToLeft")));
		this.Label3.Size = ((System.Drawing.Size)(resources.GetObject("Label3.Size")));
		this.Label3.TabIndex = ((int)(resources.GetObject("Label3.TabIndex")));
		this.Label3.Text = resources.GetString("Label3.Text");
		this.Label3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label3.TextAlign")));
		this.Label3.Visible = ((bool)(resources.GetObject("Label3.Visible")));
		// 
		// txtISBN
		// 
		this.txtISBN.AccessibleDescription = resources.GetString("txtISBN.AccessibleDescription");
		this.txtISBN.AccessibleName = resources.GetString("txtISBN.AccessibleName");
		this.txtISBN.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtISBN.Anchor")));
		this.txtISBN.AutoSize = ((bool)(resources.GetObject("txtISBN.AutoSize")));
		this.txtISBN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtISBN.BackgroundImage")));
		this.txtISBN.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtISBN.Dock")));
		this.txtISBN.Enabled = ((bool)(resources.GetObject("txtISBN.Enabled")));
		this.txtISBN.Font = ((System.Drawing.Font)(resources.GetObject("txtISBN.Font")));
		this.txtISBN.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtISBN.ImeMode")));
		this.txtISBN.Location = ((System.Drawing.Point)(resources.GetObject("txtISBN.Location")));
		this.txtISBN.MaxLength = ((int)(resources.GetObject("txtISBN.MaxLength")));
		this.txtISBN.Multiline = ((bool)(resources.GetObject("txtISBN.Multiline")));
		this.txtISBN.Name = "txtISBN";
		this.txtISBN.PasswordChar = ((char)(resources.GetObject("txtISBN.PasswordChar")));
		this.txtISBN.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtISBN.RightToLeft")));
		this.txtISBN.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtISBN.ScrollBars")));
		this.txtISBN.Size = ((System.Drawing.Size)(resources.GetObject("txtISBN.Size")));
		this.txtISBN.TabIndex = ((int)(resources.GetObject("txtISBN.TabIndex")));
		this.txtISBN.Text = resources.GetString("txtISBN.Text");
		this.txtISBN.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtISBN.TextAlign")));
		this.txtISBN.Visible = ((bool)(resources.GetObject("txtISBN.Visible")));
		this.txtISBN.WordWrap = ((bool)(resources.GetObject("txtISBN.WordWrap")));
		// 
		// Label2
		// 
		this.Label2.AccessibleDescription = resources.GetString("Label2.AccessibleDescription");
		this.Label2.AccessibleName = resources.GetString("Label2.AccessibleName");
		this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label2.Anchor")));
		this.Label2.AutoSize = ((bool)(resources.GetObject("Label2.AutoSize")));
		this.Label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label2.Dock")));
		this.Label2.Enabled = ((bool)(resources.GetObject("Label2.Enabled")));
		this.Label2.Font = ((System.Drawing.Font)(resources.GetObject("Label2.Font")));
		this.Label2.Image = ((System.Drawing.Image)(resources.GetObject("Label2.Image")));
		this.Label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label2.ImageAlign")));
		this.Label2.ImageIndex = ((int)(resources.GetObject("Label2.ImageIndex")));
		this.Label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label2.ImeMode")));
		this.Label2.Location = ((System.Drawing.Point)(resources.GetObject("Label2.Location")));
		this.Label2.Name = "Label2";
		this.Label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label2.RightToLeft")));
		this.Label2.Size = ((System.Drawing.Size)(resources.GetObject("Label2.Size")));
		this.Label2.TabIndex = ((int)(resources.GetObject("Label2.TabIndex")));
		this.Label2.Text = resources.GetString("Label2.Text");
		this.Label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label2.TextAlign")));
		this.Label2.Visible = ((bool)(resources.GetObject("Label2.Visible")));
		// 
		// btnGetBookData
		// 
		this.btnGetBookData.AccessibleDescription = resources.GetString("btnGetBookData.AccessibleDescription");
		this.btnGetBookData.AccessibleName = resources.GetString("btnGetBookData.AccessibleName");
		this.btnGetBookData.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnGetBookData.Anchor")));
		this.btnGetBookData.BackColor = System.Drawing.SystemColors.Control;
		this.btnGetBookData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGetBookData.BackgroundImage")));
		this.btnGetBookData.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnGetBookData.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnGetBookData.Dock")));
		this.btnGetBookData.Enabled = ((bool)(resources.GetObject("btnGetBookData.Enabled")));
		this.btnGetBookData.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnGetBookData.FlatStyle")));
		this.btnGetBookData.Font = ((System.Drawing.Font)(resources.GetObject("btnGetBookData.Font")));
		this.btnGetBookData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetBookData.Image")));
		this.btnGetBookData.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnGetBookData.ImageAlign")));
		this.btnGetBookData.ImageIndex = ((int)(resources.GetObject("btnGetBookData.ImageIndex")));
		this.btnGetBookData.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnGetBookData.ImeMode")));
		this.btnGetBookData.Location = ((System.Drawing.Point)(resources.GetObject("btnGetBookData.Location")));
		this.btnGetBookData.Name = "btnGetBookData";
		this.btnGetBookData.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnGetBookData.RightToLeft")));
		this.btnGetBookData.Size = ((System.Drawing.Size)(resources.GetObject("btnGetBookData.Size")));
		this.btnGetBookData.TabIndex = ((int)(resources.GetObject("btnGetBookData.TabIndex")));
		this.btnGetBookData.Text = resources.GetString("btnGetBookData.Text");
		this.btnGetBookData.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnGetBookData.TextAlign")));
		this.btnGetBookData.Visible = ((bool)(resources.GetObject("btnGetBookData.Visible")));
		this.btnGetBookData.Click+=new EventHandler(btnGetBookData_Click);
		// 
		// lvwBooks
		// 
		this.lvwBooks.AccessibleDescription = resources.GetString("lvwBooks.AccessibleDescription");
		this.lvwBooks.AccessibleName = resources.GetString("lvwBooks.AccessibleName");
		this.lvwBooks.Alignment = ((System.Windows.Forms.ListViewAlignment)(resources.GetObject("lvwBooks.Alignment")));
		this.lvwBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lvwBooks.Anchor")));
		this.lvwBooks.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lvwBooks.BackgroundImage")));
		this.lvwBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																				   this.chISBN,
																				   this.chAmazonPrice,
																				   this.chAmazonRank,
																				   this.chBNPrice,
																				   this.chBNRank});
		this.lvwBooks.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lvwBooks.Dock")));
		this.lvwBooks.Enabled = ((bool)(resources.GetObject("lvwBooks.Enabled")));
		this.lvwBooks.Font = ((System.Drawing.Font)(resources.GetObject("lvwBooks.Font")));
		this.lvwBooks.FullRowSelect = true;
		this.lvwBooks.GridLines = true;
		this.lvwBooks.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lvwBooks.ImeMode")));
		this.lvwBooks.LabelWrap = ((bool)(resources.GetObject("lvwBooks.LabelWrap")));
		this.lvwBooks.Location = ((System.Drawing.Point)(resources.GetObject("lvwBooks.Location")));
		this.lvwBooks.Name = "lvwBooks";
		this.lvwBooks.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lvwBooks.RightToLeft")));
		this.lvwBooks.Size = ((System.Drawing.Size)(resources.GetObject("lvwBooks.Size")));
		this.lvwBooks.Sorting = System.Windows.Forms.SortOrder.Ascending;
		this.lvwBooks.TabIndex = ((int)(resources.GetObject("lvwBooks.TabIndex")));
		this.lvwBooks.Text = resources.GetString("lvwBooks.Text");
		this.lvwBooks.View = System.Windows.Forms.View.Details;
		this.lvwBooks.Visible = ((bool)(resources.GetObject("lvwBooks.Visible")));
		// 
		// chISBN
		// 
		this.chISBN.Text = resources.GetString("chISBN.Text");
		this.chISBN.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("chISBN.TextAlign")));
		this.chISBN.Width = ((int)(resources.GetObject("chISBN.Width")));
		// 
		// chAmazonPrice
		// 
		this.chAmazonPrice.Text = resources.GetString("chAmazonPrice.Text");
		this.chAmazonPrice.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("chAmazonPrice.TextAlign")));
		this.chAmazonPrice.Width = ((int)(resources.GetObject("chAmazonPrice.Width")));
		// 
		// chAmazonRank
		// 
		this.chAmazonRank.Text = resources.GetString("chAmazonRank.Text");
		this.chAmazonRank.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("chAmazonRank.TextAlign")));
		this.chAmazonRank.Width = ((int)(resources.GetObject("chAmazonRank.Width")));
		// 
		// chBNPrice
		// 
		this.chBNPrice.Text = resources.GetString("chBNPrice.Text");
		this.chBNPrice.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("chBNPrice.TextAlign")));
		this.chBNPrice.Width = ((int)(resources.GetObject("chBNPrice.Width")));
		// 
		// chBNRank
		// 
		this.chBNRank.Text = resources.GetString("chBNRank.Text");
		this.chBNRank.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("chBNRank.TextAlign")));
		this.chBNRank.Width = ((int)(resources.GetObject("chBNRank.Width")));
		// 
		// pgeDilbert
		// 
		this.pgeDilbert.AccessibleDescription = resources.GetString("pgeDilbert.AccessibleDescription");
		this.pgeDilbert.AccessibleName = resources.GetString("pgeDilbert.AccessibleName");
		this.pgeDilbert.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("pgeDilbert.Anchor")));
		this.pgeDilbert.AutoScroll = ((bool)(resources.GetObject("pgeDilbert.AutoScroll")));
		this.pgeDilbert.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("pgeDilbert.AutoScrollMargin")));
		this.pgeDilbert.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("pgeDilbert.AutoScrollMinSize")));
		this.pgeDilbert.BackColor = System.Drawing.SystemColors.Control;
		this.pgeDilbert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pgeDilbert.BackgroundImage")));
		this.pgeDilbert.Controls.Add(this.btnCartoon);
		this.pgeDilbert.Controls.Add(this.txtAsyncWaitPeriod);
		this.pgeDilbert.Controls.Add(this.Label5);
		this.pgeDilbert.Controls.Add(this.picDilbert);
		this.pgeDilbert.Controls.Add(this.Label10);
		this.pgeDilbert.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("pgeDilbert.Dock")));
		this.pgeDilbert.Enabled = ((bool)(resources.GetObject("pgeDilbert.Enabled")));
		this.pgeDilbert.Font = ((System.Drawing.Font)(resources.GetObject("pgeDilbert.Font")));
		this.pgeDilbert.ImageIndex = ((int)(resources.GetObject("pgeDilbert.ImageIndex")));
		this.pgeDilbert.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("pgeDilbert.ImeMode")));
		this.pgeDilbert.Location = ((System.Drawing.Point)(resources.GetObject("pgeDilbert.Location")));
		this.pgeDilbert.Name = "pgeDilbert";
		this.pgeDilbert.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("pgeDilbert.RightToLeft")));
		this.pgeDilbert.Size = ((System.Drawing.Size)(resources.GetObject("pgeDilbert.Size")));
		this.pgeDilbert.TabIndex = ((int)(resources.GetObject("pgeDilbert.TabIndex")));
		this.pgeDilbert.Text = resources.GetString("pgeDilbert.Text");
		this.pgeDilbert.ToolTipText = resources.GetString("pgeDilbert.ToolTipText");
		this.pgeDilbert.Visible = ((bool)(resources.GetObject("pgeDilbert.Visible")));
		// 
		// btnCartoon
		// 
		this.btnCartoon.AccessibleDescription = resources.GetString("btnCartoon.AccessibleDescription");
		this.btnCartoon.AccessibleName = resources.GetString("btnCartoon.AccessibleName");
		this.btnCartoon.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnCartoon.Anchor")));
		this.btnCartoon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCartoon.BackgroundImage")));
		this.btnCartoon.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnCartoon.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnCartoon.Dock")));
		this.btnCartoon.Enabled = ((bool)(resources.GetObject("btnCartoon.Enabled")));
		this.btnCartoon.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnCartoon.FlatStyle")));
		this.btnCartoon.Font = ((System.Drawing.Font)(resources.GetObject("btnCartoon.Font")));
		this.btnCartoon.Image = ((System.Drawing.Image)(resources.GetObject("btnCartoon.Image")));
		this.btnCartoon.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnCartoon.ImageAlign")));
		this.btnCartoon.ImageIndex = ((int)(resources.GetObject("btnCartoon.ImageIndex")));
		this.btnCartoon.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnCartoon.ImeMode")));
		this.btnCartoon.Location = ((System.Drawing.Point)(resources.GetObject("btnCartoon.Location")));
		this.btnCartoon.Name = "btnCartoon";
		this.btnCartoon.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnCartoon.RightToLeft")));
		this.btnCartoon.Size = ((System.Drawing.Size)(resources.GetObject("btnCartoon.Size")));
		this.btnCartoon.TabIndex = ((int)(resources.GetObject("btnCartoon.TabIndex")));
		this.btnCartoon.Text = resources.GetString("btnCartoon.Text");
		this.btnCartoon.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnCartoon.TextAlign")));
		this.btnCartoon.Visible = ((bool)(resources.GetObject("btnCartoon.Visible")));
		this.btnCartoon.Click+=new EventHandler(btnCartoon_Click);
		// 
		// txtAsyncWaitPeriod
		// 
		this.txtAsyncWaitPeriod.AccessibleDescription = resources.GetString("txtAsyncWaitPeriod.AccessibleDescription");
		this.txtAsyncWaitPeriod.AccessibleName = resources.GetString("txtAsyncWaitPeriod.AccessibleName");
		this.txtAsyncWaitPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtAsyncWaitPeriod.Anchor")));
		this.txtAsyncWaitPeriod.AutoSize = ((bool)(resources.GetObject("txtAsyncWaitPeriod.AutoSize")));
		this.txtAsyncWaitPeriod.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtAsyncWaitPeriod.BackgroundImage")));
		this.txtAsyncWaitPeriod.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtAsyncWaitPeriod.Dock")));
		this.txtAsyncWaitPeriod.Enabled = ((bool)(resources.GetObject("txtAsyncWaitPeriod.Enabled")));
		this.txtAsyncWaitPeriod.Font = ((System.Drawing.Font)(resources.GetObject("txtAsyncWaitPeriod.Font")));
		this.txtAsyncWaitPeriod.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtAsyncWaitPeriod.ImeMode")));
		this.txtAsyncWaitPeriod.Location = ((System.Drawing.Point)(resources.GetObject("txtAsyncWaitPeriod.Location")));
		this.txtAsyncWaitPeriod.MaxLength = ((int)(resources.GetObject("txtAsyncWaitPeriod.MaxLength")));
		this.txtAsyncWaitPeriod.Multiline = ((bool)(resources.GetObject("txtAsyncWaitPeriod.Multiline")));
		this.txtAsyncWaitPeriod.Name = "txtAsyncWaitPeriod";
		this.txtAsyncWaitPeriod.PasswordChar = ((char)(resources.GetObject("txtAsyncWaitPeriod.PasswordChar")));
		this.txtAsyncWaitPeriod.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtAsyncWaitPeriod.RightToLeft")));
		this.txtAsyncWaitPeriod.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtAsyncWaitPeriod.ScrollBars")));
		this.txtAsyncWaitPeriod.Size = ((System.Drawing.Size)(resources.GetObject("txtAsyncWaitPeriod.Size")));
		this.txtAsyncWaitPeriod.TabIndex = ((int)(resources.GetObject("txtAsyncWaitPeriod.TabIndex")));
		this.txtAsyncWaitPeriod.Text = resources.GetString("txtAsyncWaitPeriod.Text");
		this.txtAsyncWaitPeriod.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtAsyncWaitPeriod.TextAlign")));
		this.txtAsyncWaitPeriod.Visible = ((bool)(resources.GetObject("txtAsyncWaitPeriod.Visible")));
		this.txtAsyncWaitPeriod.WordWrap = ((bool)(resources.GetObject("txtAsyncWaitPeriod.WordWrap")));
		// 
		// Label5
		// 
		this.Label5.AccessibleDescription = resources.GetString("Label5.AccessibleDescription");
		this.Label5.AccessibleName = resources.GetString("Label5.AccessibleName");
		this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label5.Anchor")));
		this.Label5.AutoSize = ((bool)(resources.GetObject("Label5.AutoSize")));
		this.Label5.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label5.Dock")));
		this.Label5.Enabled = ((bool)(resources.GetObject("Label5.Enabled")));
		this.Label5.Font = ((System.Drawing.Font)(resources.GetObject("Label5.Font")));
		this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
		this.Label5.Image = ((System.Drawing.Image)(resources.GetObject("Label5.Image")));
		this.Label5.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label5.ImageAlign")));
		this.Label5.ImageIndex = ((int)(resources.GetObject("Label5.ImageIndex")));
		this.Label5.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label5.ImeMode")));
		this.Label5.Location = ((System.Drawing.Point)(resources.GetObject("Label5.Location")));
		this.Label5.Name = "Label5";
		this.Label5.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label5.RightToLeft")));
		this.Label5.Size = ((System.Drawing.Size)(resources.GetObject("Label5.Size")));
		this.Label5.TabIndex = ((int)(resources.GetObject("Label5.TabIndex")));
		this.Label5.Text = resources.GetString("Label5.Text");
		this.Label5.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label5.TextAlign")));
		this.Label5.Visible = ((bool)(resources.GetObject("Label5.Visible")));
		// 
		// picDilbert
		// 
		this.picDilbert.AccessibleDescription = resources.GetString("picDilbert.AccessibleDescription");
		this.picDilbert.AccessibleName = resources.GetString("picDilbert.AccessibleName");
		this.picDilbert.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("picDilbert.Anchor")));
		this.picDilbert.BackColor = System.Drawing.SystemColors.Menu;
		this.picDilbert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picDilbert.BackgroundImage")));
		this.picDilbert.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("picDilbert.Dock")));
		this.picDilbert.Enabled = ((bool)(resources.GetObject("picDilbert.Enabled")));
		this.picDilbert.Font = ((System.Drawing.Font)(resources.GetObject("picDilbert.Font")));
		this.picDilbert.Image = ((System.Drawing.Image)(resources.GetObject("picDilbert.Image")));
		this.picDilbert.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("picDilbert.ImeMode")));
		this.picDilbert.Location = ((System.Drawing.Point)(resources.GetObject("picDilbert.Location")));
		this.picDilbert.Name = "picDilbert";
		this.picDilbert.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("picDilbert.RightToLeft")));
		this.picDilbert.Size = ((System.Drawing.Size)(resources.GetObject("picDilbert.Size")));
		this.picDilbert.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode)(resources.GetObject("picDilbert.SizeMode")));
		this.picDilbert.TabIndex = ((int)(resources.GetObject("picDilbert.TabIndex")));
		this.picDilbert.TabStop = false;
		this.picDilbert.Text = resources.GetString("picDilbert.Text");
		this.picDilbert.Visible = ((bool)(resources.GetObject("picDilbert.Visible")));
		// 
		// Label10
		// 
		this.Label10.AccessibleDescription = resources.GetString("Label10.AccessibleDescription");
		this.Label10.AccessibleName = resources.GetString("Label10.AccessibleName");
		this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label10.Anchor")));
		this.Label10.AutoSize = ((bool)(resources.GetObject("Label10.AutoSize")));
		this.Label10.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label10.Dock")));
		this.Label10.Enabled = ((bool)(resources.GetObject("Label10.Enabled")));
		this.Label10.Font = ((System.Drawing.Font)(resources.GetObject("Label10.Font")));
		this.Label10.Image = ((System.Drawing.Image)(resources.GetObject("Label10.Image")));
		this.Label10.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label10.ImageAlign")));
		this.Label10.ImageIndex = ((int)(resources.GetObject("Label10.ImageIndex")));
		this.Label10.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label10.ImeMode")));
		this.Label10.Location = ((System.Drawing.Point)(resources.GetObject("Label10.Location")));
		this.Label10.Name = "Label10";
		this.Label10.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label10.RightToLeft")));
		this.Label10.Size = ((System.Drawing.Size)(resources.GetObject("Label10.Size")));
		this.Label10.TabIndex = ((int)(resources.GetObject("Label10.TabIndex")));
		this.Label10.Text = resources.GetString("Label10.Text");
		this.Label10.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label10.TextAlign")));
		this.Label10.Visible = ((bool)(resources.GetObject("Label10.Visible")));
		// 
		// Label1
		// 
		this.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription");
		this.Label1.AccessibleName = resources.GetString("Label1.AccessibleName");
		this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label1.Anchor")));
		this.Label1.AutoSize = ((bool)(resources.GetObject("Label1.AutoSize")));
		this.Label1.BackColor = System.Drawing.SystemColors.Control;
		this.Label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label1.Dock")));
		this.Label1.Enabled = ((bool)(resources.GetObject("Label1.Enabled")));
		this.Label1.Font = ((System.Drawing.Font)(resources.GetObject("Label1.Font")));
		this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
		this.Label1.Image = ((System.Drawing.Image)(resources.GetObject("Label1.Image")));
		this.Label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label1.ImageAlign")));
		this.Label1.ImageIndex = ((int)(resources.GetObject("Label1.ImageIndex")));
		this.Label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label1.ImeMode")));
		this.Label1.Location = ((System.Drawing.Point)(resources.GetObject("Label1.Location")));
		this.Label1.Name = "Label1";
		this.Label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label1.RightToLeft")));
		this.Label1.Size = ((System.Drawing.Size)(resources.GetObject("Label1.Size")));
		this.Label1.TabIndex = ((int)(resources.GetObject("Label1.TabIndex")));
		this.Label1.Text = resources.GetString("Label1.Text");
		this.Label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label1.TextAlign")));
		this.Label1.Visible = ((bool)(resources.GetObject("Label1.Visible")));
		// 
		// frmMain
		// 
		this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
		this.AccessibleName = resources.GetString("$this.AccessibleName");
		this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
		this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
		this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
		this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
		this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
		this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.tabWebServices);
		this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
		this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
		this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
		this.MaximizeBox = false;
		this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
		this.Menu = this.mnuMain;
		this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
		this.Name = "frmMain";
		this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
		this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
		this.Text = resources.GetString("$this.Text");
		this.tabWebServices.ResumeLayout(false);
		this.pgeBooks.ResumeLayout(false);
		this.pgeDilbert.ResumeLayout(false);
		this.Load+=new EventHandler(frmMain_Load);
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

    // Uses classes that inherit WebRequest to retrieve a response stream

    // containing an image that is used to generate a Bitmap for the Weather

    // Web service current conditions PictureBox.

    private System.Drawing.Image GetImage(string url )
	{

         HttpWebRequest httpRequest;
         HttpWebResponse httpResponse;
		 Bitmap MyBitmap =null;

        // Create the request using the WebRequestFactory.
        httpRequest = (HttpWebRequest) WebRequest.Create(url);
        httpRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0b; Windows NT 5.1)";
        httpRequest.Method = "GET";
        httpRequest.Timeout = 10000;

		try 
		{

			// Get the response stream and return a Bitmap generated from it.

			httpResponse = (HttpWebResponse) httpRequest.GetResponse();
			MyBitmap =new Bitmap(httpResponse.GetResponseStream());
			httpResponse.Close();
			return MyBitmap;
		} 
		catch(Exception exp )
		{

			MessageBox.Show("An error occurred trying to retrieve the weather " + 
				"conditions picture.", "Web Service Demo Error", 
				MessageBoxButtons.OK, MessageBoxIcon.Error);
			return MyBitmap;
				
		}
		

    }

    // Retrieves a Url from the Microsoft UDDI service.

    public string GetUrlFromUDDI() 
	{

        string strnewUrl  = string.Empty;

        //Use the live UDDI registry.

        Inquire.Url = "http://uddi.microsoft.com/inquire";

        try 
		{

            GetServiceDetail gsd = new GetServiceDetail();
            gsd.ServiceKeys.Add(SERVICE_KEY);

            // Call UDDI and get the service details.

            ServiceDetail sd  = gsd.Send();

            // return the returned URL, simulating an updated URL for the Alethea
            // Local Time Web service.

            strnewUrl = sd.BusinessServices[0].BindingTemplates[0].AccessPoint.Text;
			
            return strnewUrl;

		} 
		catch(Exception ex)
		{

            MessageBox.Show("Unable to retrieve an updated Url for the " + 
                "Web Service. Please try again later.",
                "Web Service UDDI Demo Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            return strnewUrl;

        }

    }

    // Calls the EuroConvert Web service to get a Dataset of all the possible
    // currencies that can be converted from the Euro dollar. The Dataset is then
    // bound to a ComboBox for use on the Currency tab.

    
#region " PersistCurrencyConverterCountriesToXML ";

    // Loads a Dataset from an XML file that contains the ECC-member nations and then
    // binds the Dataset to a ComboBox for display. This is for use on the Currency
    // tab.

    
#endregion

    // Turns off the status indicators activated by ShowStatusIndicators().

    private void ResetStatusIndicators()
	{

        // Reset the status indicators, no matter what happens.

        this.Cursor = Cursors.Default;
        frmStatus.Hide();
    }

    // Displays various Web service connection and data status indicators for UI 

    // feedback.

    private void ShowStatusIndicators(string strMessage )
	{

        // Display status text and appropriate cursor. Make sure you call DoEvents()
        // or this code will not run until the entire Click event is processed, at 
        // which point it will not matter (nor will it even be visible).

        frmStatus = new frmStatus();
        frmStatus.Show(strMessage);
        this.Cursor = Cursors.WaitCursor;
        Application.DoEvents();

    }

    // the "Convert" button click event for the Currency tab. This handler 
    // connects to a Web service, passes in the country that the currency is being
    // converted from and the country the currency is being converted to, and 
    // returns the exchange rate. This is then used to calculate the final value.

    
    // the "get {Cartoon!" button click event for the Dilbert tab. 
    // This handler connects to a Web service asynchronously using the 
    // AsyncWaitHandle.WaitOne method found in the System.Threading namespace.
    // The user can enter the number of seconds they are willing to wait for the
    // cartoon to be retrieved from the Web service.

    private void btnCartoon_Click(object sender, System.EventArgs e) 
	{

        if (txtAsyncWaitPeriod.Text == "")
		{

            MessageBox.Show("You must enter a number of seconds you wish to wait.",
							"Web Service Demo Information", 
							MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;

        }

        // Create an instance of the Web service proxy class.
		
        HowTo.Esynaps.DailyDilbert wsDailyDilbert = new HowTo.Esynaps.DailyDilbert();

        // Display a status form so that the delay caused by accessing the Web 
        // service is not mistaken the Form not loading properly or some other
        // problem.

        ShowStatusIndicators("Connecting to the Daily Dilbert Web Service and " + 
							 "downloading today's cartoon. Please stand by...");

        // Retrieve the data from the Web service. The Web service also exposes a 
        // method that returns a Url to the image, but using that method here would 
        // not have been instructive.

		Byte[] arrPicture;

		try 
		{

			// Call the Web method asynchronously by calling the Begin___ proxy

			// method.

			IAsyncResult result  = wsDailyDilbert.BeginDailyDilbertImage(null, null);

			// Wait many seconds the user entered in the TextBox.

			result.AsyncWaitHandle.WaitOne(new TimeSpan(0, 0, Convert.ToInt32(txtAsyncWaitPeriod.Text)), false);
			
			// if result completed in time, display the cartoon, if not, display
			// the message.
			
			if (result.IsCompleted) 
			{

				// Load the byte array into a memory stream by calling the End__
				// async proxy method.

				arrPicture =(Byte[]) wsDailyDilbert.EndDailyDilbertImage(result);
				MemoryStream ms = new MemoryStream(arrPicture);

				// Display in the PictureBox control with a simple call to the 
				// FromStream method.

				picDilbert.Image = Image.FromStream(ms);
				picDilbert.SizeMode = PictureBoxSizeMode.CenterImage;
				picDilbert.BorderStyle = BorderStyle.Fixed3D;

			}
			else 
			{

				MessageBox.Show("The cartoon was not retrieved in the " + 
					"time you specified.", "Web Service Demo Information",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		} 
		catch(Exception exp)
		{
			MessageBox.Show(WS_DATA_RETRIEVAL_ERROR + 
				wsDailyDilbert.Url, 
				"Web Service Demo Error", 
				MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

        finally
		{

            // Hide the status form, whether the cartoon is retrieved or an error
            // occurred.

            ResetStatusIndicators();
        }

    }

    // the "get {Time!" button click event for the Fallback tab. 
    // This handler simulates connecting to a Web service with a bad Url. It then
    // implements a "fallback plan" by contacting the UDDI service. It simulates 
    // getting an updated Url for the Web service and then reconnects to finally
    // display the time.

    
    // "get {Data" button click event for the Books tab. This handler connects
    // to the SalesRankNPrice Web service and downloads Amazon and Barnes + Noble 
    // sales ranking and price for a given book by ISBN number.

    private void btnGetBookData_Click(object sender, System.EventArgs e)
	{

        // Create an instance of the Web service proxy class and the All class, also
        // provided by the Web service a convenient type for holding the data
        // returned by the GetAll method.
		
		
        HowTo.PerfectXML.SalesRankNPrice wsSalesRankNPrice =new HowTo.PerfectXML.SalesRankNPrice();
        HowTo.PerfectXML.All strBookData;
        ShowStatusIndicators(WS_CONNECTION_STATUS);

        // Retrieve the data from the Web service.

		try 
		{

			strBookData = wsSalesRankNPrice.GetAll(txtISBN.Text);

		} 
		catch(Exception exp)
		{

			MessageBox.Show(WS_DATA_RETRIEVAL_ERROR +
							wsSalesRankNPrice.Url, 
							"Web Service Demo Error", 
							MessageBoxButtons.OK, MessageBoxIcon.Error);

			return;
		}

        finally
		{

            // Reset the status indicators, no matter what happens.

            ResetStatusIndicators();

        }

        // Create a ListViewItem object and set the first column's text.

        ListViewItem lvItem =new ListViewItem();
        lvItem.Text = txtISBN.Text;

        // Set the text in the remaining columns and add the ListViewItem object
        // to the ListView.

        lvItem.SubItems.Add(strBookData.AmazonPrice);
        lvItem.SubItems.Add(strBookData.AmazonSalesRank);
        lvItem.SubItems.Add(strBookData.BNPrice);
        lvItem.SubItems.Add(strBookData.BNSalesRank);
        lvwBooks.Items.Add(lvItem);

    }

    // "get {Time" button click event for the Local Time tab. This handler 
    // connects to the Local Time Web service and downloads the date and time for a 
    // given zip code. It's a good example of a very easy Web service to implement. 
    // Like many Web services, you could consume this Web service with only two lines 
    // of code:
    // 
    //   wsLocalTime new Alethea.LocalTime()
    //   lblTime.Text = wsLocalTime.LocalTimeByZipCode(txtZipCodeForTime.Text)
    //
    // However, the code that follows is in keeping with the rest of the event handlers, 
    // providing structured error handling and user interface feedback.

    
    // the "get {Weather" button click event for the Weather tab. This handler 
    // connects to the LearningXMLws Web service and downloads current weather
    // conditions for a Zip code entered by the user.

    
    // the Form's load event which binds a ComboBox used on the Currency
    // tab.

    private void frmMain_Load(object sender, System.EventArgs e) 
	{

       

    }

    internal System.Windows.Forms.PictureBox picDilbert;

    internal System.Windows.Forms.TextBox txtAsyncWaitPeriod;

    internal System.Windows.Forms.ListView lvwBooks;

    internal System.Windows.Forms.TextBox txtISBN;

    internal System.Windows.Forms.TabPage pgeDilbert;

    internal System.Windows.Forms.TabPage pgeBooks;

    internal System.Windows.Forms.TabControl tabWebServices;

    internal System.Windows.Forms.Button btnGetBookData;

}

