//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;


public class frmMain : System.Windows.Forms.Form 
{

    // Initialize constants for connecting to the database
    // and displaying a connection error to the user.

    protected const string SQL_CONNECTION_STRING  = "Server=localhost;DataBase=Northwind;Integrated Security=SSPI";

    protected const string MSDE_CONNECTION_STRING  = "Server=(local)/NetSDK;DataBase=Northwind;Integrated Security=SSPI";

    protected const string CONNECTION_ERROR_MSG  = "To run this sample, you must have SQL " + 
		"or MSDE with the Northwind database installed.  For " + 
        "instructions on installing MSDE, view the ReadMe file.";

    protected SqlDataAdapter da;

    protected SqlCommandBuilder cbd;

    protected DataSet dsPictures;

    protected bool didPreviouslyConnect = false;

    protected string connectionstring = SQL_CONNECTION_STRING;

#region " Windows Form Designer generated code "

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}


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

    internal System.Windows.Forms.TabControl TabControl1;

    internal System.Windows.Forms.TabPage TabPage1;

    internal System.Windows.Forms.TabPage TabPage2;

    internal System.Windows.Forms.TabPage TabPage3;

    internal System.Windows.Forms.Label Label1;

    internal System.Windows.Forms.PictureBox PictureBox1;

    internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;

    internal System.Windows.Forms.Button btnBrowse;

    internal System.Windows.Forms.Label Label2;

    internal System.Windows.Forms.Label Label3;

    internal System.Windows.Forms.Button btnSave;

    internal System.Windows.Forms.Label lblFilePath;

    internal System.Windows.Forms.PictureBox PictureBox2;

    internal System.Windows.Forms.Label Label4;

    internal System.Windows.Forms.Label Label5;

    internal System.Windows.Forms.Button btnDelete;

    internal System.Windows.Forms.Button btnDisplay;

    internal System.Windows.Forms.ListBox lstPictures;

    internal System.Windows.Forms.Button btnModifyDB;

    internal System.Windows.Forms.Label Label7;

    internal System.Windows.Forms.Label Label6;

    internal System.Windows.Forms.Label lblFileName;

    private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.Label7 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.btnModifyDB = new System.Windows.Forms.Button();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.lblFilePath = new System.Windows.Forms.Label();
		this.btnSave = new System.Windows.Forms.Button();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.btnBrowse = new System.Windows.Forms.Button();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.TabPage3 = new System.Windows.Forms.TabPage();
		this.lblFileName = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.PictureBox2 = new System.Windows.Forms.PictureBox();
		this.btnDelete = new System.Windows.Forms.Button();
		this.btnDisplay = new System.Windows.Forms.Button();
		this.lstPictures = new System.Windows.Forms.ListBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
		this.TabControl1.SuspendLayout();
		this.TabPage1.SuspendLayout();
		this.TabPage2.SuspendLayout();
		this.TabPage3.SuspendLayout();
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
		this.mnuExit.Click += new EventHandler(mnuExit_Click);
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
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);
		// 
		// TabControl1
		// 
		this.TabControl1.AccessibleDescription = resources.GetString("TabControl1.AccessibleDescription");
		this.TabControl1.AccessibleName = resources.GetString("TabControl1.AccessibleName");
		this.TabControl1.Alignment = ((System.Windows.Forms.TabAlignment)(resources.GetObject("TabControl1.Alignment")));
		this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("TabControl1.Anchor")));
		this.TabControl1.Appearance = ((System.Windows.Forms.TabAppearance)(resources.GetObject("TabControl1.Appearance")));
		this.TabControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TabControl1.BackgroundImage")));
		this.TabControl1.Controls.Add(this.TabPage1);
		this.TabControl1.Controls.Add(this.TabPage2);
		this.TabControl1.Controls.Add(this.TabPage3);
		this.TabControl1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("TabControl1.Dock")));
		this.TabControl1.Enabled = ((bool)(resources.GetObject("TabControl1.Enabled")));
		this.TabControl1.Font = ((System.Drawing.Font)(resources.GetObject("TabControl1.Font")));
		this.TabControl1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("TabControl1.ImeMode")));
		this.TabControl1.ItemSize = ((System.Drawing.Size)(resources.GetObject("TabControl1.ItemSize")));
		this.TabControl1.Location = ((System.Drawing.Point)(resources.GetObject("TabControl1.Location")));
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.Padding = ((System.Drawing.Point)(resources.GetObject("TabControl1.Padding")));
		this.TabControl1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("TabControl1.RightToLeft")));
		this.TabControl1.SelectedIndex = 0;
		this.TabControl1.ShowToolTips = ((bool)(resources.GetObject("TabControl1.ShowToolTips")));
		this.TabControl1.Size = ((System.Drawing.Size)(resources.GetObject("TabControl1.Size")));
		this.TabControl1.TabIndex = ((int)(resources.GetObject("TabControl1.TabIndex")));
		this.TabControl1.Text = resources.GetString("TabControl1.Text");
		this.TabControl1.Visible = ((bool)(resources.GetObject("TabControl1.Visible")));
		this.TabControl1.SelectedIndexChanged += new EventHandler(TabControl1_SelectedIndexChanged);
		// 
		// TabPage1
		// 
		this.TabPage1.AccessibleDescription = resources.GetString("TabPage1.AccessibleDescription");
		this.TabPage1.AccessibleName = resources.GetString("TabPage1.AccessibleName");
		this.TabPage1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("TabPage1.Anchor")));
		this.TabPage1.AutoScroll = ((bool)(resources.GetObject("TabPage1.AutoScroll")));
		this.TabPage1.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("TabPage1.AutoScrollMargin")));
		this.TabPage1.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("TabPage1.AutoScrollMinSize")));
		this.TabPage1.BackColor = System.Drawing.SystemColors.Info;
		this.TabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TabPage1.BackgroundImage")));
		this.TabPage1.Controls.Add(this.Label7);
		this.TabPage1.Controls.Add(this.Label6);
		this.TabPage1.Controls.Add(this.btnModifyDB);
		this.TabPage1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("TabPage1.Dock")));
		this.TabPage1.Enabled = ((bool)(resources.GetObject("TabPage1.Enabled")));
		this.TabPage1.Font = ((System.Drawing.Font)(resources.GetObject("TabPage1.Font")));
		this.TabPage1.ImageIndex = ((int)(resources.GetObject("TabPage1.ImageIndex")));
		this.TabPage1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("TabPage1.ImeMode")));
		this.TabPage1.Location = ((System.Drawing.Point)(resources.GetObject("TabPage1.Location")));
		this.TabPage1.Name = "TabPage1";
		this.TabPage1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("TabPage1.RightToLeft")));
		this.TabPage1.Size = ((System.Drawing.Size)(resources.GetObject("TabPage1.Size")));
		this.TabPage1.TabIndex = ((int)(resources.GetObject("TabPage1.TabIndex")));
		this.TabPage1.Text = resources.GetString("TabPage1.Text");
		this.TabPage1.ToolTipText = resources.GetString("TabPage1.ToolTipText");
		this.TabPage1.Visible = ((bool)(resources.GetObject("TabPage1.Visible")));
		// 
		// Label7
		// 
		this.Label7.AccessibleDescription = resources.GetString("Label7.AccessibleDescription");
		this.Label7.AccessibleName = resources.GetString("Label7.AccessibleName");
		this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label7.Anchor")));
		this.Label7.AutoSize = ((bool)(resources.GetObject("Label7.AutoSize")));
		this.Label7.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label7.Dock")));
		this.Label7.Enabled = ((bool)(resources.GetObject("Label7.Enabled")));
		this.Label7.Font = ((System.Drawing.Font)(resources.GetObject("Label7.Font")));
		this.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
		this.Label7.Image = ((System.Drawing.Image)(resources.GetObject("Label7.Image")));
		this.Label7.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label7.ImageAlign")));
		this.Label7.ImageIndex = ((int)(resources.GetObject("Label7.ImageIndex")));
		this.Label7.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label7.ImeMode")));
		this.Label7.Location = ((System.Drawing.Point)(resources.GetObject("Label7.Location")));
		this.Label7.Name = "Label7";
		this.Label7.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label7.RightToLeft")));
		this.Label7.Size = ((System.Drawing.Size)(resources.GetObject("Label7.Size")));
		this.Label7.TabIndex = ((int)(resources.GetObject("Label7.TabIndex")));
		this.Label7.Text = resources.GetString("Label7.Text");
		this.Label7.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label7.TextAlign")));
		this.Label7.Visible = ((bool)(resources.GetObject("Label7.Visible")));
		// 
		// Label6
		// 
		this.Label6.AccessibleDescription = resources.GetString("Label6.AccessibleDescription");
		this.Label6.AccessibleName = resources.GetString("Label6.AccessibleName");
		this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label6.Anchor")));
		this.Label6.AutoSize = ((bool)(resources.GetObject("Label6.AutoSize")));
		this.Label6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label6.Dock")));
		this.Label6.Enabled = ((bool)(resources.GetObject("Label6.Enabled")));
		this.Label6.Font = ((System.Drawing.Font)(resources.GetObject("Label6.Font")));
		this.Label6.Image = ((System.Drawing.Image)(resources.GetObject("Label6.Image")));
		this.Label6.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label6.ImageAlign")));
		this.Label6.ImageIndex = ((int)(resources.GetObject("Label6.ImageIndex")));
		this.Label6.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label6.ImeMode")));
		this.Label6.Location = ((System.Drawing.Point)(resources.GetObject("Label6.Location")));
		this.Label6.Name = "Label6";
		this.Label6.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label6.RightToLeft")));
		this.Label6.Size = ((System.Drawing.Size)(resources.GetObject("Label6.Size")));
		this.Label6.TabIndex = ((int)(resources.GetObject("Label6.TabIndex")));
		this.Label6.Text = resources.GetString("Label6.Text");
		this.Label6.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label6.TextAlign")));
		this.Label6.Visible = ((bool)(resources.GetObject("Label6.Visible")));
		// 
		// btnModifyDB
		// 
		this.btnModifyDB.AccessibleDescription = resources.GetString("btnModifyDB.AccessibleDescription");
		this.btnModifyDB.AccessibleName = resources.GetString("btnModifyDB.AccessibleName");
		this.btnModifyDB.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnModifyDB.Anchor")));
		this.btnModifyDB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
		this.btnModifyDB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnModifyDB.BackgroundImage")));
		this.btnModifyDB.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnModifyDB.Dock")));
		this.btnModifyDB.Enabled = ((bool)(resources.GetObject("btnModifyDB.Enabled")));
		this.btnModifyDB.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnModifyDB.FlatStyle")));
		this.btnModifyDB.Font = ((System.Drawing.Font)(resources.GetObject("btnModifyDB.Font")));
		this.btnModifyDB.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyDB.Image")));
		this.btnModifyDB.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnModifyDB.ImageAlign")));
		this.btnModifyDB.ImageIndex = ((int)(resources.GetObject("btnModifyDB.ImageIndex")));
		this.btnModifyDB.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnModifyDB.ImeMode")));
		this.btnModifyDB.Location = ((System.Drawing.Point)(resources.GetObject("btnModifyDB.Location")));
		this.btnModifyDB.Name = "btnModifyDB";
		this.btnModifyDB.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnModifyDB.RightToLeft")));
		this.btnModifyDB.Size = ((System.Drawing.Size)(resources.GetObject("btnModifyDB.Size")));
		this.btnModifyDB.TabIndex = ((int)(resources.GetObject("btnModifyDB.TabIndex")));
		this.btnModifyDB.Text = resources.GetString("btnModifyDB.Text");
		this.btnModifyDB.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnModifyDB.TextAlign")));
		this.btnModifyDB.Visible = ((bool)(resources.GetObject("btnModifyDB.Visible")));
		this.btnModifyDB.Click += new EventHandler(btnModifyDB_Click);
		// 
		// TabPage2
		// 
		this.TabPage2.AccessibleDescription = resources.GetString("TabPage2.AccessibleDescription");
		this.TabPage2.AccessibleName = resources.GetString("TabPage2.AccessibleName");
		this.TabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("TabPage2.Anchor")));
		this.TabPage2.AutoScroll = ((bool)(resources.GetObject("TabPage2.AutoScroll")));
		this.TabPage2.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("TabPage2.AutoScrollMargin")));
		this.TabPage2.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("TabPage2.AutoScrollMinSize")));
		this.TabPage2.BackColor = System.Drawing.SystemColors.Info;
		this.TabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TabPage2.BackgroundImage")));
		this.TabPage2.Controls.Add(this.lblFilePath);
		this.TabPage2.Controls.Add(this.btnSave);
		this.TabPage2.Controls.Add(this.Label3);
		this.TabPage2.Controls.Add(this.Label2);
		this.TabPage2.Controls.Add(this.btnBrowse);
		this.TabPage2.Controls.Add(this.PictureBox1);
		this.TabPage2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("TabPage2.Dock")));
		this.TabPage2.Enabled = ((bool)(resources.GetObject("TabPage2.Enabled")));
		this.TabPage2.Font = ((System.Drawing.Font)(resources.GetObject("TabPage2.Font")));
		this.TabPage2.ImageIndex = ((int)(resources.GetObject("TabPage2.ImageIndex")));
		this.TabPage2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("TabPage2.ImeMode")));
		this.TabPage2.Location = ((System.Drawing.Point)(resources.GetObject("TabPage2.Location")));
		this.TabPage2.Name = "TabPage2";
		this.TabPage2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("TabPage2.RightToLeft")));
		this.TabPage2.Size = ((System.Drawing.Size)(resources.GetObject("TabPage2.Size")));
		this.TabPage2.TabIndex = ((int)(resources.GetObject("TabPage2.TabIndex")));
		this.TabPage2.Text = resources.GetString("TabPage2.Text");
		this.TabPage2.ToolTipText = resources.GetString("TabPage2.ToolTipText");
		this.TabPage2.Visible = ((bool)(resources.GetObject("TabPage2.Visible")));
		// 
		// lblFilePath
		// 
		this.lblFilePath.AccessibleDescription = resources.GetString("lblFilePath.AccessibleDescription");
		this.lblFilePath.AccessibleName = resources.GetString("lblFilePath.AccessibleName");
		this.lblFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblFilePath.Anchor")));
		this.lblFilePath.AutoSize = ((bool)(resources.GetObject("lblFilePath.AutoSize")));
		this.lblFilePath.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblFilePath.Dock")));
		this.lblFilePath.Enabled = ((bool)(resources.GetObject("lblFilePath.Enabled")));
		this.lblFilePath.Font = ((System.Drawing.Font)(resources.GetObject("lblFilePath.Font")));
		this.lblFilePath.ForeColor = System.Drawing.SystemColors.ActiveCaption;
		this.lblFilePath.Image = ((System.Drawing.Image)(resources.GetObject("lblFilePath.Image")));
		this.lblFilePath.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblFilePath.ImageAlign")));
		this.lblFilePath.ImageIndex = ((int)(resources.GetObject("lblFilePath.ImageIndex")));
		this.lblFilePath.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblFilePath.ImeMode")));
		this.lblFilePath.Location = ((System.Drawing.Point)(resources.GetObject("lblFilePath.Location")));
		this.lblFilePath.Name = "lblFilePath";
		this.lblFilePath.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblFilePath.RightToLeft")));
		this.lblFilePath.Size = ((System.Drawing.Size)(resources.GetObject("lblFilePath.Size")));
		this.lblFilePath.TabIndex = ((int)(resources.GetObject("lblFilePath.TabIndex")));
		this.lblFilePath.Text = resources.GetString("lblFilePath.Text");
		this.lblFilePath.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblFilePath.TextAlign")));
		this.lblFilePath.Visible = ((bool)(resources.GetObject("lblFilePath.Visible")));
		// 
		// btnSave
		// 
		this.btnSave.AccessibleDescription = resources.GetString("btnSave.AccessibleDescription");
		this.btnSave.AccessibleName = resources.GetString("btnSave.AccessibleName");
		this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnSave.Anchor")));
		this.btnSave.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
		this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
		this.btnSave.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnSave.Dock")));
		this.btnSave.Enabled = ((bool)(resources.GetObject("btnSave.Enabled")));
		this.btnSave.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnSave.FlatStyle")));
		this.btnSave.Font = ((System.Drawing.Font)(resources.GetObject("btnSave.Font")));
		this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
		this.btnSave.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSave.ImageAlign")));
		this.btnSave.ImageIndex = ((int)(resources.GetObject("btnSave.ImageIndex")));
		this.btnSave.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnSave.ImeMode")));
		this.btnSave.Location = ((System.Drawing.Point)(resources.GetObject("btnSave.Location")));
		this.btnSave.Name = "btnSave";
		this.btnSave.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnSave.RightToLeft")));
		this.btnSave.Size = ((System.Drawing.Size)(resources.GetObject("btnSave.Size")));
		this.btnSave.TabIndex = ((int)(resources.GetObject("btnSave.TabIndex")));
		this.btnSave.Text = resources.GetString("btnSave.Text");
		this.btnSave.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSave.TextAlign")));
		this.btnSave.Visible = ((bool)(resources.GetObject("btnSave.Visible")));
		this.btnSave.Click += new EventHandler(btnSave_Click);
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
		this.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
		// btnBrowse
		// 
		this.btnBrowse.AccessibleDescription = resources.GetString("btnBrowse.AccessibleDescription");
		this.btnBrowse.AccessibleName = resources.GetString("btnBrowse.AccessibleName");
		this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnBrowse.Anchor")));
		this.btnBrowse.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
		this.btnBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowse.BackgroundImage")));
		this.btnBrowse.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnBrowse.Dock")));
		this.btnBrowse.Enabled = ((bool)(resources.GetObject("btnBrowse.Enabled")));
		this.btnBrowse.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnBrowse.FlatStyle")));
		this.btnBrowse.Font = ((System.Drawing.Font)(resources.GetObject("btnBrowse.Font")));
		this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
		this.btnBrowse.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBrowse.ImageAlign")));
		this.btnBrowse.ImageIndex = ((int)(resources.GetObject("btnBrowse.ImageIndex")));
		this.btnBrowse.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnBrowse.ImeMode")));
		this.btnBrowse.Location = ((System.Drawing.Point)(resources.GetObject("btnBrowse.Location")));
		this.btnBrowse.Name = "btnBrowse";
		this.btnBrowse.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnBrowse.RightToLeft")));
		this.btnBrowse.Size = ((System.Drawing.Size)(resources.GetObject("btnBrowse.Size")));
		this.btnBrowse.TabIndex = ((int)(resources.GetObject("btnBrowse.TabIndex")));
		this.btnBrowse.Text = resources.GetString("btnBrowse.Text");
		this.btnBrowse.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBrowse.TextAlign")));
		this.btnBrowse.Visible = ((bool)(resources.GetObject("btnBrowse.Visible")));
		this.btnBrowse.Click += new EventHandler(btnBrowse_Click);
		// 
		// PictureBox1
		// 
		this.PictureBox1.AccessibleDescription = resources.GetString("PictureBox1.AccessibleDescription");
		this.PictureBox1.AccessibleName = resources.GetString("PictureBox1.AccessibleName");
		this.PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("PictureBox1.Anchor")));
		this.PictureBox1.BackColor = System.Drawing.SystemColors.Menu;
		this.PictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox1.BackgroundImage")));
		this.PictureBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("PictureBox1.Dock")));
		this.PictureBox1.Enabled = ((bool)(resources.GetObject("PictureBox1.Enabled")));
		this.PictureBox1.Font = ((System.Drawing.Font)(resources.GetObject("PictureBox1.Font")));
		this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
		this.PictureBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("PictureBox1.ImeMode")));
		this.PictureBox1.Location = ((System.Drawing.Point)(resources.GetObject("PictureBox1.Location")));
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("PictureBox1.RightToLeft")));
		this.PictureBox1.Size = ((System.Drawing.Size)(resources.GetObject("PictureBox1.Size")));
		this.PictureBox1.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode)(resources.GetObject("PictureBox1.SizeMode")));
		this.PictureBox1.TabIndex = ((int)(resources.GetObject("PictureBox1.TabIndex")));
		this.PictureBox1.TabStop = false;
		this.PictureBox1.Text = resources.GetString("PictureBox1.Text");
		this.PictureBox1.Visible = ((bool)(resources.GetObject("PictureBox1.Visible")));
		// 
		// TabPage3
		// 
		this.TabPage3.AccessibleDescription = resources.GetString("TabPage3.AccessibleDescription");
		this.TabPage3.AccessibleName = resources.GetString("TabPage3.AccessibleName");
		this.TabPage3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("TabPage3.Anchor")));
		this.TabPage3.AutoScroll = ((bool)(resources.GetObject("TabPage3.AutoScroll")));
		this.TabPage3.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("TabPage3.AutoScrollMargin")));
		this.TabPage3.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("TabPage3.AutoScrollMinSize")));
		this.TabPage3.BackColor = System.Drawing.SystemColors.Info;
		this.TabPage3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TabPage3.BackgroundImage")));
		this.TabPage3.Controls.Add(this.lblFileName);
		this.TabPage3.Controls.Add(this.Label5);
		this.TabPage3.Controls.Add(this.Label4);
		this.TabPage3.Controls.Add(this.PictureBox2);
		this.TabPage3.Controls.Add(this.btnDelete);
		this.TabPage3.Controls.Add(this.btnDisplay);
		this.TabPage3.Controls.Add(this.lstPictures);
		this.TabPage3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("TabPage3.Dock")));
		this.TabPage3.Enabled = ((bool)(resources.GetObject("TabPage3.Enabled")));
		this.TabPage3.Font = ((System.Drawing.Font)(resources.GetObject("TabPage3.Font")));
		this.TabPage3.ImageIndex = ((int)(resources.GetObject("TabPage3.ImageIndex")));
		this.TabPage3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("TabPage3.ImeMode")));
		this.TabPage3.Location = ((System.Drawing.Point)(resources.GetObject("TabPage3.Location")));
		this.TabPage3.Name = "TabPage3";
		this.TabPage3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("TabPage3.RightToLeft")));
		this.TabPage3.Size = ((System.Drawing.Size)(resources.GetObject("TabPage3.Size")));
		this.TabPage3.TabIndex = ((int)(resources.GetObject("TabPage3.TabIndex")));
		this.TabPage3.Text = resources.GetString("TabPage3.Text");
		this.TabPage3.ToolTipText = resources.GetString("TabPage3.ToolTipText");
		this.TabPage3.Visible = ((bool)(resources.GetObject("TabPage3.Visible")));
		// 
		// lblFileName
		// 
		this.lblFileName.AccessibleDescription = resources.GetString("lblFileName.AccessibleDescription");
		this.lblFileName.AccessibleName = resources.GetString("lblFileName.AccessibleName");
		this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblFileName.Anchor")));
		this.lblFileName.AutoSize = ((bool)(resources.GetObject("lblFileName.AutoSize")));
		this.lblFileName.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblFileName.Dock")));
		this.lblFileName.Enabled = ((bool)(resources.GetObject("lblFileName.Enabled")));
		this.lblFileName.Font = ((System.Drawing.Font)(resources.GetObject("lblFileName.Font")));
		this.lblFileName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
		this.lblFileName.Image = ((System.Drawing.Image)(resources.GetObject("lblFileName.Image")));
		this.lblFileName.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblFileName.ImageAlign")));
		this.lblFileName.ImageIndex = ((int)(resources.GetObject("lblFileName.ImageIndex")));
		this.lblFileName.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblFileName.ImeMode")));
		this.lblFileName.Location = ((System.Drawing.Point)(resources.GetObject("lblFileName.Location")));
		this.lblFileName.Name = "lblFileName";
		this.lblFileName.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblFileName.RightToLeft")));
		this.lblFileName.Size = ((System.Drawing.Size)(resources.GetObject("lblFileName.Size")));
		this.lblFileName.TabIndex = ((int)(resources.GetObject("lblFileName.TabIndex")));
		this.lblFileName.Text = resources.GetString("lblFileName.Text");
		this.lblFileName.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblFileName.TextAlign")));
		this.lblFileName.Visible = ((bool)(resources.GetObject("lblFileName.Visible")));
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
		// Label4
		// 
		this.Label4.AccessibleDescription = resources.GetString("Label4.AccessibleDescription");
		this.Label4.AccessibleName = resources.GetString("Label4.AccessibleName");
		this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label4.Anchor")));
		this.Label4.AutoSize = ((bool)(resources.GetObject("Label4.AutoSize")));
		this.Label4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label4.Dock")));
		this.Label4.Enabled = ((bool)(resources.GetObject("Label4.Enabled")));
		this.Label4.Font = ((System.Drawing.Font)(resources.GetObject("Label4.Font")));
		this.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
		// PictureBox2
		// 
		this.PictureBox2.AccessibleDescription = resources.GetString("PictureBox2.AccessibleDescription");
		this.PictureBox2.AccessibleName = resources.GetString("PictureBox2.AccessibleName");
		this.PictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("PictureBox2.Anchor")));
		this.PictureBox2.BackColor = System.Drawing.SystemColors.Menu;
		this.PictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox2.BackgroundImage")));
		this.PictureBox2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("PictureBox2.Dock")));
		this.PictureBox2.Enabled = ((bool)(resources.GetObject("PictureBox2.Enabled")));
		this.PictureBox2.Font = ((System.Drawing.Font)(resources.GetObject("PictureBox2.Font")));
		this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
		this.PictureBox2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("PictureBox2.ImeMode")));
		this.PictureBox2.Location = ((System.Drawing.Point)(resources.GetObject("PictureBox2.Location")));
		this.PictureBox2.Name = "PictureBox2";
		this.PictureBox2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("PictureBox2.RightToLeft")));
		this.PictureBox2.Size = ((System.Drawing.Size)(resources.GetObject("PictureBox2.Size")));
		this.PictureBox2.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode)(resources.GetObject("PictureBox2.SizeMode")));
		this.PictureBox2.TabIndex = ((int)(resources.GetObject("PictureBox2.TabIndex")));
		this.PictureBox2.TabStop = false;
		this.PictureBox2.Text = resources.GetString("PictureBox2.Text");
		this.PictureBox2.Visible = ((bool)(resources.GetObject("PictureBox2.Visible")));
		// 
		// btnDelete
		// 
		this.btnDelete.AccessibleDescription = resources.GetString("btnDelete.AccessibleDescription");
		this.btnDelete.AccessibleName = resources.GetString("btnDelete.AccessibleName");
		this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnDelete.Anchor")));
		this.btnDelete.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
		this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
		this.btnDelete.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnDelete.Dock")));
		this.btnDelete.Enabled = ((bool)(resources.GetObject("btnDelete.Enabled")));
		this.btnDelete.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnDelete.FlatStyle")));
		this.btnDelete.Font = ((System.Drawing.Font)(resources.GetObject("btnDelete.Font")));
		this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
		this.btnDelete.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnDelete.ImageAlign")));
		this.btnDelete.ImageIndex = ((int)(resources.GetObject("btnDelete.ImageIndex")));
		this.btnDelete.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnDelete.ImeMode")));
		this.btnDelete.Location = ((System.Drawing.Point)(resources.GetObject("btnDelete.Location")));
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnDelete.RightToLeft")));
		this.btnDelete.Size = ((System.Drawing.Size)(resources.GetObject("btnDelete.Size")));
		this.btnDelete.TabIndex = ((int)(resources.GetObject("btnDelete.TabIndex")));
		this.btnDelete.Text = resources.GetString("btnDelete.Text");
		this.btnDelete.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnDelete.TextAlign")));
		this.btnDelete.Visible = ((bool)(resources.GetObject("btnDelete.Visible")));
		this.btnDelete.Click += new EventHandler(btnDelete_Click);
		// 
		// btnDisplay
		// 
		this.btnDisplay.AccessibleDescription = resources.GetString("btnDisplay.AccessibleDescription");
		this.btnDisplay.AccessibleName = resources.GetString("btnDisplay.AccessibleName");
		this.btnDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnDisplay.Anchor")));
		this.btnDisplay.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
		this.btnDisplay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDisplay.BackgroundImage")));
		this.btnDisplay.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnDisplay.Dock")));
		this.btnDisplay.Enabled = ((bool)(resources.GetObject("btnDisplay.Enabled")));
		this.btnDisplay.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnDisplay.FlatStyle")));
		this.btnDisplay.Font = ((System.Drawing.Font)(resources.GetObject("btnDisplay.Font")));
		this.btnDisplay.Image = ((System.Drawing.Image)(resources.GetObject("btnDisplay.Image")));
		this.btnDisplay.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnDisplay.ImageAlign")));
		this.btnDisplay.ImageIndex = ((int)(resources.GetObject("btnDisplay.ImageIndex")));
		this.btnDisplay.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnDisplay.ImeMode")));
		this.btnDisplay.Location = ((System.Drawing.Point)(resources.GetObject("btnDisplay.Location")));
		this.btnDisplay.Name = "btnDisplay";
		this.btnDisplay.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnDisplay.RightToLeft")));
		this.btnDisplay.Size = ((System.Drawing.Size)(resources.GetObject("btnDisplay.Size")));
		this.btnDisplay.TabIndex = ((int)(resources.GetObject("btnDisplay.TabIndex")));
		this.btnDisplay.Text = resources.GetString("btnDisplay.Text");
		this.btnDisplay.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnDisplay.TextAlign")));
		this.btnDisplay.Visible = ((bool)(resources.GetObject("btnDisplay.Visible")));
		this.btnDisplay.Click += new EventHandler(btnDisplay_Click);
		// 
		// lstPictures
		// 
		this.lstPictures.AccessibleDescription = resources.GetString("lstPictures.AccessibleDescription");
		this.lstPictures.AccessibleName = resources.GetString("lstPictures.AccessibleName");
		this.lstPictures.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lstPictures.Anchor")));
		this.lstPictures.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lstPictures.BackgroundImage")));
		this.lstPictures.ColumnWidth = ((int)(resources.GetObject("lstPictures.ColumnWidth")));
		this.lstPictures.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lstPictures.Dock")));
		this.lstPictures.Enabled = ((bool)(resources.GetObject("lstPictures.Enabled")));
		this.lstPictures.Font = ((System.Drawing.Font)(resources.GetObject("lstPictures.Font")));
		this.lstPictures.HorizontalExtent = ((int)(resources.GetObject("lstPictures.HorizontalExtent")));
		this.lstPictures.HorizontalScrollbar = ((bool)(resources.GetObject("lstPictures.HorizontalScrollbar")));
		this.lstPictures.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lstPictures.ImeMode")));
		this.lstPictures.IntegralHeight = ((bool)(resources.GetObject("lstPictures.IntegralHeight")));
		this.lstPictures.ItemHeight = ((int)(resources.GetObject("lstPictures.ItemHeight")));
		this.lstPictures.Location = ((System.Drawing.Point)(resources.GetObject("lstPictures.Location")));
		this.lstPictures.Name = "lstPictures";
		this.lstPictures.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lstPictures.RightToLeft")));
		this.lstPictures.ScrollAlwaysVisible = ((bool)(resources.GetObject("lstPictures.ScrollAlwaysVisible")));
		this.lstPictures.Size = ((System.Drawing.Size)(resources.GetObject("lstPictures.Size")));
		this.lstPictures.TabIndex = ((int)(resources.GetObject("lstPictures.TabIndex")));
		this.lstPictures.Visible = ((bool)(resources.GetObject("lstPictures.Visible")));
		// 
		// Label1
		// 
		this.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription");
		this.Label1.AccessibleName = resources.GetString("Label1.AccessibleName");
		this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label1.Anchor")));
		this.Label1.AutoSize = ((bool)(resources.GetObject("Label1.AutoSize")));
		this.Label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label1.Dock")));
		this.Label1.Enabled = ((bool)(resources.GetObject("Label1.Enabled")));
		this.Label1.Font = ((System.Drawing.Font)(resources.GetObject("Label1.Font")));
		this.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
		// OpenFileDialog1
		// 
		this.OpenFileDialog1.Filter = resources.GetString("OpenFileDialog1.Filter");
		this.OpenFileDialog1.Title = resources.GetString("OpenFileDialog1.Title");
		// 
		// frmMain
		// 
		this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
		this.AccessibleName = resources.GetString("$this.AccessibleName");
		this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
		this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
		this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
		this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
		this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
		this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
		this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.TabControl1);
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
		this.Load += new System.EventHandler(this.frmMain_Load_1);
		this.TabControl1.ResumeLayout(false);
		this.TabPage1.ResumeLayout(false);
		this.TabPage2.ResumeLayout(false);
		this.TabPage3.ResumeLayout(false);
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

    // the Browse button click event, allowing the user to find an image, 

    // display it in a PictureBox control, and save the image to the database.

    private void btnBrowse_Click(object sender, System.EventArgs e)
	{
        // Use an OpenFileDialog to enable the user to find an image to save to the 
        // database. Provide a pipe-delimited set of pipe-delimited pairs of file 
        // types that will appear in the dialog. set {the FilterIndex to the default 
        // file type.

            OpenFileDialog1.InitialDirectory = "C:/";
            OpenFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg";
            OpenFileDialog1.FilterIndex = 2;

        // When the user clicks the Open button (DialogResult.OK is the only option;
        // there is not DialogResult.Open), display the image centered in the 
        // PictureBox and display the full path of the image.

        if (OpenFileDialog1.ShowDialog() == DialogResult.OK )
		{
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName);
            PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            PictureBox1.BorderStyle = BorderStyle.Fixed3D;
            lblFilePath.Text = OpenFileDialog1.FileName;
        }
    }

    // the Delete button click event, allowing the user to delete an image 
    // stored in the database.

    private void btnDelete_Click(object sender, System.EventArgs e)
	{
        // When nothing is selected in the ListBox, the SelectedIndex = -1.
		if (lstPictures.SelectedIndex < 0) 
		{

			MessageBox.Show("There are no images in the database to delete.", "Empty Database!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		else 
		{
			// Use the SqlCommandBuilder to get a delete command and update the DataSet
			// after you delete the row in the Dataset that corresponds with the picture
			// the user has selected.

			dsPictures.Tables[0].Rows[lstPictures.SelectedIndex].Delete();
			da.UpdateCommand = cbd.GetDeleteCommand();
			da.Update(dsPictures);

			// Clear the image and filename
			lblFileName.Text = string.Empty;
			PictureBox2.Image = null;
		}
    }

    // the Display button click event, allowing the user to display an image 
    // stored in the database.
    private void btnDisplay_Click(object sender, System.EventArgs e)
	{
        // When nothing is selected in the ListBox, the SelectedIndex = -1.

		if (lstPictures.SelectedIndex < 0) 
		{
			MessageBox.Show("There are no images in the database to display.", "Empty Database!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		else 
		{

			// The SQL Server Image datatype is a binary datatype. Therefore, to 
			// generate an image from it you must first create a stream object 
			// containing the binary data. { you can generate the image by 
			// calling Image.FromStream().
			byte[] arrPicture = ((byte[]) (dsPictures.Tables[0].Rows[lstPictures.SelectedIndex]["Picture"]));

			MemoryStream ms = new MemoryStream(arrPicture);
			PictureBox2.Image = Image.FromStream(ms);
			PictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
			PictureBox2.BorderStyle = BorderStyle.Fixed3D;
        
			lblFileName.Text = dsPictures.Tables[0].Rows[lstPictures.SelectedIndex]["FileName"].ToString();

			// Close the stream object to release the resource.
			ms.Close();
		}
    }

    // the Create Table button click event, allowing the user to drop (if it exists)
    // and create the Picture table in the Northwind database.

    private void btnModifyDB_Click(object sender, System.EventArgs e)
	{
        string strSQL  = "IF EXISTS (" + 
            "SELECT * " + 
            "FROM northwind.dbo.sysobjects " +  
            "WHERE NAME = 'Picture' " +  
            "AND TYPE = 'u')" + Environment.NewLine +  
            "BEGIN" + Environment.NewLine +  
            "DROP TABLE northwind.dbo.picture" + Environment.NewLine +  
            "END" + Environment.NewLine +  
            "CREATE TABLE Picture (" +  
            "PictureID Int IDENTITY(1,1) NOT NULL," +  
            "[FileName] Varchar(255) NOT NULL," +  
            "Picture Image NOT NULL," +  
            "CONSTRAINT [PK_Picture] PRIMARY KEY CLUSTERED" +  
            "(PictureID))";

        // Display a status message saying that we're attempting to connect.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

        frmStatus frmStatusMessage = new frmStatus();

        if (!didPreviouslyConnect) {
            frmStatusMessage.Show("Connecting to SQL Server");
        }

        // Attempt to connect to the local SQL server instance, and a local
        // MSDE installation (with Northwind).  

        bool isConnecting  = true;

        while (isConnecting)
		{
			try 
			{

				// The SqlConnection class allows you to communicate with SQL Server.
				// The constructor accepts a connection string an argument.  This
				// connection string uses Integrated Security, which means that you 
				// must have a login in SQL Server, or be part of the Administrators
				// group for this to work.
                
				SqlConnection northwindConnection = new SqlConnection(connectionstring);
				// A SqlCommand object is used to execute the SQL commands.

				SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
				// Open the connection, execute the command, and close the connection.
				// It is more efficient to ExecuteNonQuery when data is not being 
				// returned.

				northwindConnection.Open();
				cmd.ExecuteNonQuery();
				northwindConnection.Close();

				// Data has been successfully submitted, so break out of the loop
				// and close the status form.

				isConnecting = false;
				didPreviouslyConnect = true;
				frmStatusMessage.Close();
				MessageBox.Show("Table successfully created.", "Table Creation Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

			} 
			catch( SqlException sqlExc)
			{
				MessageBox.Show(Convert.ToString(sqlExc), "SQL Exception Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				break;
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
					frmStatusMessage.Close();
					MessageBox.Show(CONNECTION_ERROR_MSG, "Connection Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
            }
        }
        frmStatusMessage.Close();
    }

    // the Save button click event, allowing the user to save the image
    // viewed in the PictureBox to the database.

    private void btnSave_Click(object sender, System.EventArgs e)
	{
        // PREPARE DATA TO BE PASSED TO DATABASE:
        // You only need to save the filename, not the entire path. Therefore, 
        // Split the path, creating an array of strings. Make sure you pass in 
        // the delimiter. { reverse the array so that you can assign the 
        // first string in the array to the SQL parameter.

        string[] arrFilename = Regex.Split(lblFilePath.Text, "/");
		Array.Reverse(arrFilename);
        // The SQL Server Image datatype is a binary datatype. Therefore, to save 
        // it to the database you must convert the image to an array of bytes. You
        // could use a FileStream object to open the image file and then read it to 
        // the stream, but a MemoryStream with the Image.Save method is a bit easier.

        MemoryStream ms = new MemoryStream();

        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat);

        byte[] arrImage = ms.GetBuffer();

        // Close the stream object to release the resource.
        ms.Close();

        // Display a status message saying that we're attempting to connect.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

        frmStatus frmStatusMessage = new frmStatus();

        if (!didPreviouslyConnect) {
            frmStatusMessage.Show("Connecting to SQL Server");
        }

        // Attempt to connect to the local SQL server instance, and a local
        // MSDE installation (with Northwind).  

        bool isConnecting  = true;

        while (isConnecting)
		{
            try {
                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in SQL Server, or be part of the Administrators
                // group for this to work.

                SqlConnection northwindConnection = new SqlConnection(connectionstring);

                string strSQL = "INSERT INTO Picture (Filename, Picture)" + 
                    "VALUES (@Filename, @Picture)";

                // A SqlCommand object is used to execute the SQL statement.
                SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);

                    // Add parameters required by SQL statement. PictureID is an 
                    // identity field (in Microsoft Access, an AutoNumber field), 
                    // so you only need to pass values for the two remaining fields.

                    cmd.Parameters.Add(new SqlParameter("@Filename", SqlDbType.NVarChar, 50)).Value = arrFilename[0];
                    cmd.Parameters.Add(new SqlParameter("@Picture", SqlDbType.Image)).Value = arrImage;

                // Open the connection, execute the command, and close the 
                // connection. It is more efficient to ExecuteNonQuery when data 
                // is not being returned.

                northwindConnection.Open();
                cmd.ExecuteNonQuery();
                northwindConnection.Close();

                // Data has been successfully submitted, so break out of the loop
                // and close the status form.

                isConnecting = false;
                didPreviouslyConnect = true;
                frmStatusMessage.Close();

                MessageBox.Show(arrFilename[0] + " saved to the database.", "Image Save Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

           } 
			catch( SqlException sqlExc)
			{
                MessageBox.Show(Convert.ToString(sqlExc), "SQL Exception Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;
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
					frmStatusMessage.Close();
					MessageBox.Show(CONNECTION_ERROR_MSG, "Connection Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
            }
        }
    }

    // the SelectedIndexChanged event of the TabControl, causing a Dataset to 
    // be created and bound to a ListBox control when the user clicks the Manage tab.

    private void TabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
	{
        if (TabControl1.SelectedIndex == 2) {
            // Display a status message saying that we're attempting to connect.
            // This only needs to be done the very first time a connection is
            // attempted.  After we've determined that MSDE or SQL Server is
            // installed, this message no longer needs to be displayed.

            frmStatus frmStatusMessage = new frmStatus();

            if (!didPreviouslyConnect) {
                frmStatusMessage.Show("Connecting to SQL Server");
            }

            // Attempt to connect to the local SQL server instance, and a local
            // MSDE installation (with Northwind).  

            bool isConnecting  = true;

            while (isConnecting)
			{
                try {
                    // The SqlConnection class allows you to communicate with SQL 
                    // Server. The constructor accepts a connection string an 
                    // argument.This connection string uses Integrated Security, 
                    // which means that you must have a login in SQL Server, or be 
                    // part of the Administrators group for this to work.

                    SqlConnection northwindConnection = new SqlConnection(connectionstring);

                    // A SqlCommand object is used to execute the SQL commands.

                    SqlCommand cmd = new SqlCommand("SELECT * " + "FROM Picture", northwindConnection);

                    // The SqlDataAdapter is responsible for filling a DataSet.
                    da = new SqlDataAdapter(cmd);

                    // TheSqlCommandBuilder will be used for deleting pictures from 
                    // the database in the btnDelete click event handler.

                    cbd = new SqlCommandBuilder(da);
                    dsPictures = new DataSet();
                    da.Fill(dsPictures);

                    // Data has been successfully retrieved, so break out of the loop
                    // and close the status form.

                    isConnecting = false;
                    didPreviouslyConnect = true;
                    frmStatusMessage.Close();

                    // Display the filenames of the pictures in the DataSet.
                        lstPictures.DataSource = dsPictures.Tables[0];
                        lstPictures.DisplayMember = "FileName";

               } 
				catch( SqlException sqlExc)
				{
                    MessageBox.Show(Convert.ToString(sqlExc), "SQL Exception Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
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
						frmStatusMessage.Close();
						MessageBox.Show(CONNECTION_ERROR_MSG, "Connection Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
                }
            }
        }
    }

    private void frmMain_Load(object sender, System.EventArgs e) {

    }

	private void frmMain_Load_1(object sender, System.EventArgs e)
	{
	
	}

}

