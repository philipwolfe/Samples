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
using System.Drawing;

public class frmMain:System.Windows.Forms.Form 
{
	
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}


    // Initialize constants for connecting to the database
    // and displaying a connection error to the user.

    protected const string SQL_CONNECTION_STRING  = "Server=localhost;" + 
													"DataBase=;" + 
													"Integrated Security=SSPI";

    protected const string  MSDE_CONNECTION_STRING = @"Server=(local)\NetSDK;" + 
													 "DataBase=;" + 
													 "Integrated Security=SSPI";

    protected const string  CONNECTION_ERROR_MSG = "To run this sample, you must have SQL " + 
												   "or MSDE with the Northwind database installed.  For " + 
												   "instructions on installing MSDE, view the ReadMe file.";

    protected bool bolDidPreviouslyConnect  = false;

    protected bool bolDidCreateTable = false;

    protected string connectionstring  = SQL_CONNECTION_STRING;

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

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Label lblArrow1;

    private System.Windows.Forms.Label lblStep1;

    private System.Windows.Forms.Label lblStep2;

    private System.Windows.Forms.Label lblArrow2;

    private System.Windows.Forms.Label lblArrow3;

    private System.Windows.Forms.Label lblStep3;

    private System.Windows.Forms.Label lblStep4;

    private System.Windows.Forms.Label lblStep6;

    private System.Windows.Forms.Label lblArrow5;

    private System.Windows.Forms.Label lblStep5;

    private System.Windows.Forms.Button btnCreateDB;

    private System.Windows.Forms.Button btnCreateTable;

    private System.Windows.Forms.Button btnCreateSP;

    private System.Windows.Forms.Button btnDisplay;

    private System.Windows.Forms.Button btnPopulate;

    private System.Windows.Forms.Button btnCreateView;

    private System.Windows.Forms.Label lblArrow4;

    private System.Windows.Forms.DataGrid dgSeafood;

    private void InitializeComponent() 
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.Label1 = new System.Windows.Forms.Label();

        this.btnCreateDB = new System.Windows.Forms.Button();

        this.lblStep1 = new System.Windows.Forms.Label();

        this.lblArrow1 = new System.Windows.Forms.Label();

        this.lblArrow2 = new System.Windows.Forms.Label();

        this.lblStep2 = new System.Windows.Forms.Label();

        this.btnCreateTable = new System.Windows.Forms.Button();

        this.lblArrow3 = new System.Windows.Forms.Label();

        this.lblStep3 = new System.Windows.Forms.Label();

        this.btnCreateSP = new System.Windows.Forms.Button();

        this.lblStep6 = new System.Windows.Forms.Label();

        this.btnDisplay = new System.Windows.Forms.Button();

        this.lblArrow5 = new System.Windows.Forms.Label();

        this.lblStep5 = new System.Windows.Forms.Label();

        this.btnPopulate = new System.Windows.Forms.Button();

        this.lblArrow4 = new System.Windows.Forms.Label();

        this.lblStep4 = new System.Windows.Forms.Label();

        this.btnCreateView = new System.Windows.Forms.Button();

        this.dgSeafood = new System.Windows.Forms.DataGrid();

        ((System.ComponentModel.ISupportInitialize) this.dgSeafood).BeginInit();

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

        //Label1

        //

        this.Label1.AccessibleDescription = (string) resources.GetObject("Label1.AccessibleDescription");

        this.Label1.AccessibleName = (string) resources.GetObject("Label1.AccessibleName");

        this.Label1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label1.Anchor");

        this.Label1.AutoSize = (bool) resources.GetObject("Label1.AutoSize");

        this.Label1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label1.Dock");

        this.Label1.Enabled = (bool) resources.GetObject("Label1.Enabled");

        this.Label1.Font = (System.Drawing.Font) resources.GetObject("Label1.Font");

        this.Label1.ForeColor = System.Drawing.SystemColors.Desktop;

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

        //btnCreateDB

        //

        this.btnCreateDB.AccessibleDescription = (string) resources.GetObject("btnCreateDB.AccessibleDescription");

        this.btnCreateDB.AccessibleName = (string) resources.GetObject("btnCreateDB.AccessibleName");

        this.btnCreateDB.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCreateDB.Anchor");

        this.btnCreateDB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;

        this.btnCreateDB.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCreateDB.BackgroundImage");

        this.btnCreateDB.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCreateDB.Dock");

        this.btnCreateDB.Enabled = (bool) resources.GetObject("btnCreateDB.Enabled");

        this.btnCreateDB.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCreateDB.FlatStyle");

        this.btnCreateDB.Font = (System.Drawing.Font) resources.GetObject("btnCreateDB.Font");

        this.btnCreateDB.Image = (System.Drawing.Image) resources.GetObject("btnCreateDB.Image");

        this.btnCreateDB.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateDB.ImageAlign");

        this.btnCreateDB.ImageIndex = (int) resources.GetObject("btnCreateDB.ImageIndex");

        this.btnCreateDB.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCreateDB.ImeMode");

        this.btnCreateDB.Location = (System.Drawing.Point) resources.GetObject("btnCreateDB.Location");

        this.btnCreateDB.Name = "btnCreateDB";

        this.btnCreateDB.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCreateDB.RightToLeft");

        this.btnCreateDB.Size = (System.Drawing.Size) resources.GetObject("btnCreateDB.Size");

        this.btnCreateDB.TabIndex = (int) resources.GetObject("btnCreateDB.TabIndex");

        this.btnCreateDB.Text = resources.GetString("btnCreateDB.Text");

        this.btnCreateDB.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateDB.TextAlign");

        this.btnCreateDB.Visible = (bool) resources.GetObject("btnCreateDB.Visible");

		this.btnCreateDB.Click+=new EventHandler(btnCreateDB_Click);

        //

        //lblStep1

        //

        this.lblStep1.AccessibleDescription = (string) resources.GetObject("lblStep1.AccessibleDescription");

        this.lblStep1.AccessibleName = (string) resources.GetObject("lblStep1.AccessibleName");

        this.lblStep1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblStep1.Anchor");

        this.lblStep1.AutoSize = (bool) resources.GetObject("lblStep1.AutoSize");

        this.lblStep1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblStep1.Dock");

        this.lblStep1.Enabled = (bool) resources.GetObject("lblStep1.Enabled");

        this.lblStep1.Font = (System.Drawing.Font) resources.GetObject("lblStep1.Font");

        this.lblStep1.Image = (System.Drawing.Image) resources.GetObject("lblStep1.Image");

        this.lblStep1.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStep1.ImageAlign");

        this.lblStep1.ImageIndex = (int) resources.GetObject("lblStep1.ImageIndex");

        this.lblStep1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblStep1.ImeMode");

        this.lblStep1.Location = (System.Drawing.Point) resources.GetObject("lblStep1.Location");

        this.lblStep1.Name = "lblStep1";

        this.lblStep1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblStep1.RightToLeft");

        this.lblStep1.Size = (System.Drawing.Size) resources.GetObject("lblStep1.Size");

        this.lblStep1.TabIndex = (int) resources.GetObject("lblStep1.TabIndex");

        this.lblStep1.Text = resources.GetString("lblStep1.Text");

        this.lblStep1.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStep1.TextAlign");

        this.lblStep1.Visible = (bool) resources.GetObject("lblStep1.Visible");

        //

        //lblArrow1

        //

        this.lblArrow1.AccessibleDescription = (string) resources.GetObject("lblArrow1.AccessibleDescription");

        this.lblArrow1.AccessibleName = (string) resources.GetObject("lblArrow1.AccessibleName");

        this.lblArrow1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblArrow1.Anchor");

        this.lblArrow1.AutoSize = (bool) resources.GetObject("lblArrow1.AutoSize");

        this.lblArrow1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblArrow1.Dock");

        this.lblArrow1.Enabled = (bool) resources.GetObject("lblArrow1.Enabled");

        this.lblArrow1.Font = (System.Drawing.Font) resources.GetObject("lblArrow1.Font");

        this.lblArrow1.Image = (System.Drawing.Image) resources.GetObject("lblArrow1.Image");

        this.lblArrow1.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblArrow1.ImageAlign");

        this.lblArrow1.ImageIndex = (int) resources.GetObject("lblArrow1.ImageIndex");

        this.lblArrow1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblArrow1.ImeMode");

        this.lblArrow1.Location = (System.Drawing.Point) resources.GetObject("lblArrow1.Location");

        this.lblArrow1.Name = "lblArrow1";

        this.lblArrow1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblArrow1.RightToLeft");

        this.lblArrow1.Size = (System.Drawing.Size) resources.GetObject("lblArrow1.Size");

        this.lblArrow1.TabIndex = (int) resources.GetObject("lblArrow1.TabIndex");

        this.lblArrow1.Text = resources.GetString("lblArrow1.Text");

        this.lblArrow1.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblArrow1.TextAlign");

        this.lblArrow1.Visible = (bool) resources.GetObject("lblArrow1.Visible");

        //

        //lblArrow2

        //

        this.lblArrow2.AccessibleDescription = (string) resources.GetObject("lblArrow2.AccessibleDescription");

        this.lblArrow2.AccessibleName = (string) resources.GetObject("lblArrow2.AccessibleName");

        this.lblArrow2.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblArrow2.Anchor");

        this.lblArrow2.AutoSize = (bool) resources.GetObject("lblArrow2.AutoSize");

        this.lblArrow2.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblArrow2.Dock");

        this.lblArrow2.Enabled = (bool) resources.GetObject("lblArrow2.Enabled");

        this.lblArrow2.Font = (System.Drawing.Font) resources.GetObject("lblArrow2.Font");

        this.lblArrow2.Image = (System.Drawing.Image) resources.GetObject("lblArrow2.Image");

        this.lblArrow2.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblArrow2.ImageAlign");

        this.lblArrow2.ImageIndex = (int) resources.GetObject("lblArrow2.ImageIndex");

        this.lblArrow2.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblArrow2.ImeMode");

        this.lblArrow2.Location = (System.Drawing.Point) resources.GetObject("lblArrow2.Location");

        this.lblArrow2.Name = "lblArrow2";

        this.lblArrow2.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblArrow2.RightToLeft");

        this.lblArrow2.Size = (System.Drawing.Size) resources.GetObject("lblArrow2.Size");

        this.lblArrow2.TabIndex = (int) resources.GetObject("lblArrow2.TabIndex");

        this.lblArrow2.Text = resources.GetString("lblArrow2.Text");

        this.lblArrow2.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblArrow2.TextAlign");

        this.lblArrow2.Visible = (bool) resources.GetObject("lblArrow2.Visible");

        //

        //lblStep2

        //

        this.lblStep2.AccessibleDescription = (string) resources.GetObject("lblStep2.AccessibleDescription");

        this.lblStep2.AccessibleName = (string) resources.GetObject("lblStep2.AccessibleName");

        this.lblStep2.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblStep2.Anchor");

        this.lblStep2.AutoSize = (bool) resources.GetObject("lblStep2.AutoSize");

        this.lblStep2.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblStep2.Dock");

        this.lblStep2.Enabled = (bool) resources.GetObject("lblStep2.Enabled");

        this.lblStep2.Font = (System.Drawing.Font) resources.GetObject("lblStep2.Font");

        this.lblStep2.Image = (System.Drawing.Image) resources.GetObject("lblStep2.Image");

        this.lblStep2.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStep2.ImageAlign");

        this.lblStep2.ImageIndex = (int) resources.GetObject("lblStep2.ImageIndex");

        this.lblStep2.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblStep2.ImeMode");

        this.lblStep2.Location = (System.Drawing.Point) resources.GetObject("lblStep2.Location");

        this.lblStep2.Name = "lblStep2";

        this.lblStep2.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblStep2.RightToLeft");

        this.lblStep2.Size = (System.Drawing.Size) resources.GetObject("lblStep2.Size");

        this.lblStep2.TabIndex = (int) resources.GetObject("lblStep2.TabIndex");

        this.lblStep2.Text = resources.GetString("lblStep2.Text");

        this.lblStep2.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStep2.TextAlign");

        this.lblStep2.Visible = (bool) resources.GetObject("lblStep2.Visible");

        //

        //btnCreateTable

        //

        this.btnCreateTable.AccessibleDescription = (string) resources.GetObject("btnCreateTable.AccessibleDescription");

        this.btnCreateTable.AccessibleName = (string) resources.GetObject("btnCreateTable.AccessibleName");

        this.btnCreateTable.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCreateTable.Anchor");

        this.btnCreateTable.BackColor = System.Drawing.SystemColors.InactiveCaptionText;

        this.btnCreateTable.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCreateTable.BackgroundImage");

        this.btnCreateTable.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCreateTable.Dock");

        this.btnCreateTable.Enabled = (bool) resources.GetObject("btnCreateTable.Enabled");

        this.btnCreateTable.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCreateTable.FlatStyle");

        this.btnCreateTable.Font = (System.Drawing.Font) resources.GetObject("btnCreateTable.Font");

        this.btnCreateTable.Image = (System.Drawing.Image) resources.GetObject("btnCreateTable.Image");

        this.btnCreateTable.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateTable.ImageAlign");

        this.btnCreateTable.ImageIndex = (int) resources.GetObject("btnCreateTable.ImageIndex");

        this.btnCreateTable.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCreateTable.ImeMode");

        this.btnCreateTable.Location = (System.Drawing.Point) resources.GetObject("btnCreateTable.Location");

        this.btnCreateTable.Name = "btnCreateTable";

        this.btnCreateTable.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCreateTable.RightToLeft");

        this.btnCreateTable.Size = (System.Drawing.Size) resources.GetObject("btnCreateTable.Size");

        this.btnCreateTable.TabIndex = (int) resources.GetObject("btnCreateTable.TabIndex");

        this.btnCreateTable.Text = resources.GetString("btnCreateTable.Text");

        this.btnCreateTable.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateTable.TextAlign");

        this.btnCreateTable.Visible = (bool) resources.GetObject("btnCreateTable.Visible");

		this.btnCreateTable.Click+=new EventHandler(btnCreateTable_Click);

        //

        //lblArrow3

        //

        this.lblArrow3.AccessibleDescription = (string) resources.GetObject("lblArrow3.AccessibleDescription");

        this.lblArrow3.AccessibleName = (string) resources.GetObject("lblArrow3.AccessibleName");

        this.lblArrow3.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblArrow3.Anchor");

        this.lblArrow3.AutoSize = (bool) resources.GetObject("lblArrow3.AutoSize");

        this.lblArrow3.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblArrow3.Dock");

        this.lblArrow3.Enabled = (bool) resources.GetObject("lblArrow3.Enabled");

        this.lblArrow3.Font = (System.Drawing.Font) resources.GetObject("lblArrow3.Font");

        this.lblArrow3.Image = (System.Drawing.Image) resources.GetObject("lblArrow3.Image");

        this.lblArrow3.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblArrow3.ImageAlign");

        this.lblArrow3.ImageIndex = (int) resources.GetObject("lblArrow3.ImageIndex");

        this.lblArrow3.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblArrow3.ImeMode");

        this.lblArrow3.Location = (System.Drawing.Point) resources.GetObject("lblArrow3.Location");

        this.lblArrow3.Name = "lblArrow3";

        this.lblArrow3.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblArrow3.RightToLeft");

        this.lblArrow3.Size = (System.Drawing.Size) resources.GetObject("lblArrow3.Size");

        this.lblArrow3.TabIndex = (int) resources.GetObject("lblArrow3.TabIndex");

        this.lblArrow3.Text = resources.GetString("lblArrow3.Text");

        this.lblArrow3.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblArrow3.TextAlign");

        this.lblArrow3.Visible = (bool) resources.GetObject("lblArrow3.Visible");

        //

        //lblStep3

        //

        this.lblStep3.AccessibleDescription = (string) resources.GetObject("lblStep3.AccessibleDescription");

        this.lblStep3.AccessibleName = (string) resources.GetObject("lblStep3.AccessibleName");

        this.lblStep3.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblStep3.Anchor");

        this.lblStep3.AutoSize = (bool) resources.GetObject("lblStep3.AutoSize");

        this.lblStep3.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblStep3.Dock");

        this.lblStep3.Enabled = (bool) resources.GetObject("lblStep3.Enabled");

        this.lblStep3.Font = (System.Drawing.Font) resources.GetObject("lblStep3.Font");

        this.lblStep3.Image = (System.Drawing.Image) resources.GetObject("lblStep3.Image");

        this.lblStep3.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStep3.ImageAlign");

        this.lblStep3.ImageIndex = (int) resources.GetObject("lblStep3.ImageIndex");

        this.lblStep3.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblStep3.ImeMode");

        this.lblStep3.Location = (System.Drawing.Point) resources.GetObject("lblStep3.Location");

        this.lblStep3.Name = "lblStep3";

        this.lblStep3.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblStep3.RightToLeft");

        this.lblStep3.Size = (System.Drawing.Size) resources.GetObject("lblStep3.Size");

        this.lblStep3.TabIndex = (int) resources.GetObject("lblStep3.TabIndex");

        this.lblStep3.Text = resources.GetString("lblStep3.Text");

        this.lblStep3.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStep3.TextAlign");

        this.lblStep3.Visible = (bool) resources.GetObject("lblStep3.Visible");

        //

        //btnCreateSP

        //

        this.btnCreateSP.AccessibleDescription = (string) resources.GetObject("btnCreateSP.AccessibleDescription");

        this.btnCreateSP.AccessibleName = (string) resources.GetObject("btnCreateSP.AccessibleName");

        this.btnCreateSP.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCreateSP.Anchor");

        this.btnCreateSP.BackColor = System.Drawing.SystemColors.InactiveCaptionText;

        this.btnCreateSP.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCreateSP.BackgroundImage");

        this.btnCreateSP.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCreateSP.Dock");

        this.btnCreateSP.Enabled = (bool) resources.GetObject("btnCreateSP.Enabled");

        this.btnCreateSP.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCreateSP.FlatStyle");

        this.btnCreateSP.Font = (System.Drawing.Font) resources.GetObject("btnCreateSP.Font");

        this.btnCreateSP.Image = (System.Drawing.Image) resources.GetObject("btnCreateSP.Image");

        this.btnCreateSP.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateSP.ImageAlign");

        this.btnCreateSP.ImageIndex = (int) resources.GetObject("btnCreateSP.ImageIndex");

        this.btnCreateSP.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCreateSP.ImeMode");

        this.btnCreateSP.Location = (System.Drawing.Point) resources.GetObject("btnCreateSP.Location");

        this.btnCreateSP.Name = "btnCreateSP";

        this.btnCreateSP.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCreateSP.RightToLeft");

        this.btnCreateSP.Size = (System.Drawing.Size) resources.GetObject("btnCreateSP.Size");

        this.btnCreateSP.TabIndex = (int) resources.GetObject("btnCreateSP.TabIndex");

        this.btnCreateSP.Text = resources.GetString("btnCreateSP.Text");

        this.btnCreateSP.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateSP.TextAlign");

        this.btnCreateSP.Visible = (bool) resources.GetObject("btnCreateSP.Visible");

		this.btnCreateSP.Click+=new EventHandler(btnCreateSP_Click);

        //

        //lblStep6

        //

        this.lblStep6.AccessibleDescription = (string) resources.GetObject("lblStep6.AccessibleDescription");

        this.lblStep6.AccessibleName = (string) resources.GetObject("lblStep6.AccessibleName");

        this.lblStep6.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblStep6.Anchor");

        this.lblStep6.AutoSize = (bool) resources.GetObject("lblStep6.AutoSize");

        this.lblStep6.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblStep6.Dock");

        this.lblStep6.Enabled = (bool) resources.GetObject("lblStep6.Enabled");

        this.lblStep6.Font = (System.Drawing.Font) resources.GetObject("lblStep6.Font");

        this.lblStep6.Image = (System.Drawing.Image) resources.GetObject("lblStep6.Image");

        this.lblStep6.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStep6.ImageAlign");

        this.lblStep6.ImageIndex = (int) resources.GetObject("lblStep6.ImageIndex");

        this.lblStep6.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblStep6.ImeMode");

        this.lblStep6.Location = (System.Drawing.Point) resources.GetObject("lblStep6.Location");

        this.lblStep6.Name = "lblStep6";

        this.lblStep6.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblStep6.RightToLeft");

        this.lblStep6.Size = (System.Drawing.Size) resources.GetObject("lblStep6.Size");

        this.lblStep6.TabIndex = (int) resources.GetObject("lblStep6.TabIndex");

        this.lblStep6.Text = resources.GetString("lblStep6.Text");

        this.lblStep6.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStep6.TextAlign");

        this.lblStep6.Visible = (bool) resources.GetObject("lblStep6.Visible");

        //

        //btnDisplay

        //

        this.btnDisplay.AccessibleDescription = (string) resources.GetObject("btnDisplay.AccessibleDescription");

        this.btnDisplay.AccessibleName = (string) resources.GetObject("btnDisplay.AccessibleName");

        this.btnDisplay.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnDisplay.Anchor");

        this.btnDisplay.BackColor = System.Drawing.SystemColors.InactiveCaptionText;

        this.btnDisplay.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnDisplay.BackgroundImage");

        this.btnDisplay.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnDisplay.Dock");

        this.btnDisplay.Enabled = (bool) resources.GetObject("btnDisplay.Enabled");

        this.btnDisplay.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnDisplay.FlatStyle");

        this.btnDisplay.Font = (System.Drawing.Font) resources.GetObject("btnDisplay.Font");

        this.btnDisplay.Image = (System.Drawing.Image) resources.GetObject("btnDisplay.Image");

        this.btnDisplay.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDisplay.ImageAlign");

        this.btnDisplay.ImageIndex = (int) resources.GetObject("btnDisplay.ImageIndex");

        this.btnDisplay.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnDisplay.ImeMode");

        this.btnDisplay.Location = (System.Drawing.Point) resources.GetObject("btnDisplay.Location");

        this.btnDisplay.Name = "btnDisplay";

        this.btnDisplay.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnDisplay.RightToLeft");

        this.btnDisplay.Size = (System.Drawing.Size) resources.GetObject("btnDisplay.Size");

        this.btnDisplay.TabIndex = (int) resources.GetObject("btnDisplay.TabIndex");

        this.btnDisplay.Text = resources.GetString("btnDisplay.Text");

        this.btnDisplay.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDisplay.TextAlign");

        this.btnDisplay.Visible = (bool) resources.GetObject("btnDisplay.Visible");

		this.btnDisplay.Click+=new EventHandler(btnDisplay_Click);

        //

        //lblArrow5

        //

        this.lblArrow5.AccessibleDescription = (string) resources.GetObject("lblArrow5.AccessibleDescription");

        this.lblArrow5.AccessibleName = (string) resources.GetObject("lblArrow5.AccessibleName");

        this.lblArrow5.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblArrow5.Anchor");

        this.lblArrow5.AutoSize = (bool) resources.GetObject("lblArrow5.AutoSize");

        this.lblArrow5.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblArrow5.Dock");

        this.lblArrow5.Enabled = (bool) resources.GetObject("lblArrow5.Enabled");

        this.lblArrow5.Font = (System.Drawing.Font) resources.GetObject("lblArrow5.Font");

        this.lblArrow5.Image = (System.Drawing.Image) resources.GetObject("lblArrow5.Image");

        this.lblArrow5.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblArrow5.ImageAlign");

        this.lblArrow5.ImageIndex = (int) resources.GetObject("lblArrow5.ImageIndex");

        this.lblArrow5.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblArrow5.ImeMode");

        this.lblArrow5.Location = (System.Drawing.Point) resources.GetObject("lblArrow5.Location");

        this.lblArrow5.Name = "lblArrow5";

        this.lblArrow5.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblArrow5.RightToLeft");

        this.lblArrow5.Size = (System.Drawing.Size) resources.GetObject("lblArrow5.Size");

        this.lblArrow5.TabIndex = (int) resources.GetObject("lblArrow5.TabIndex");

        this.lblArrow5.Text = resources.GetString("lblArrow5.Text");

        this.lblArrow5.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblArrow5.TextAlign");

        this.lblArrow5.Visible = (bool) resources.GetObject("lblArrow5.Visible");

        //

        //lblStep5

        //

        this.lblStep5.AccessibleDescription = (string) resources.GetObject("lblStep5.AccessibleDescription");

        this.lblStep5.AccessibleName = (string) resources.GetObject("lblStep5.AccessibleName");

        this.lblStep5.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblStep5.Anchor");

        this.lblStep5.AutoSize = (bool) resources.GetObject("lblStep5.AutoSize");

        this.lblStep5.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblStep5.Dock");

        this.lblStep5.Enabled = (bool) resources.GetObject("lblStep5.Enabled");

        this.lblStep5.Font = (System.Drawing.Font) resources.GetObject("lblStep5.Font");

        this.lblStep5.Image = (System.Drawing.Image) resources.GetObject("lblStep5.Image");

        this.lblStep5.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStep5.ImageAlign");

        this.lblStep5.ImageIndex = (int) resources.GetObject("lblStep5.ImageIndex");

        this.lblStep5.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblStep5.ImeMode");

        this.lblStep5.Location = (System.Drawing.Point) resources.GetObject("lblStep5.Location");

        this.lblStep5.Name = "lblStep5";

        this.lblStep5.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblStep5.RightToLeft");

        this.lblStep5.Size = (System.Drawing.Size) resources.GetObject("lblStep5.Size");

        this.lblStep5.TabIndex = (int) resources.GetObject("lblStep5.TabIndex");

        this.lblStep5.Text = resources.GetString("lblStep5.Text");

        this.lblStep5.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStep5.TextAlign");

        this.lblStep5.Visible = (bool) resources.GetObject("lblStep5.Visible");

        //

        //btnPopulate

        //

        this.btnPopulate.AccessibleDescription = (string) resources.GetObject("btnPopulate.AccessibleDescription");

        this.btnPopulate.AccessibleName = (string) resources.GetObject("btnPopulate.AccessibleName");

        this.btnPopulate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnPopulate.Anchor");

        this.btnPopulate.BackColor = System.Drawing.SystemColors.InactiveCaptionText;

        this.btnPopulate.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnPopulate.BackgroundImage");

        this.btnPopulate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnPopulate.Dock");

        this.btnPopulate.Enabled = (bool) resources.GetObject("btnPopulate.Enabled");

        this.btnPopulate.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnPopulate.FlatStyle");

        this.btnPopulate.Font = (System.Drawing.Font) resources.GetObject("btnPopulate.Font");

        this.btnPopulate.Image = (System.Drawing.Image) resources.GetObject("btnPopulate.Image");

        this.btnPopulate.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPopulate.ImageAlign");

        this.btnPopulate.ImageIndex = (int) resources.GetObject("btnPopulate.ImageIndex");

        this.btnPopulate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnPopulate.ImeMode");

        this.btnPopulate.Location = (System.Drawing.Point) resources.GetObject("btnPopulate.Location");

        this.btnPopulate.Name = "btnPopulate";

        this.btnPopulate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnPopulate.RightToLeft");

        this.btnPopulate.Size = (System.Drawing.Size) resources.GetObject("btnPopulate.Size");

        this.btnPopulate.TabIndex = (int) resources.GetObject("btnPopulate.TabIndex");

        this.btnPopulate.Text = resources.GetString("btnPopulate.Text");

        this.btnPopulate.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPopulate.TextAlign");

        this.btnPopulate.Visible = (bool) resources.GetObject("btnPopulate.Visible");

		this.btnPopulate.Click+=new EventHandler(btnPopulate_Click);

        //

        //lblArrow4

        //

        this.lblArrow4.AccessibleDescription = (string) resources.GetObject("lblArrow4.AccessibleDescription");

        this.lblArrow4.AccessibleName = (string) resources.GetObject("lblArrow4.AccessibleName");

        this.lblArrow4.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblArrow4.Anchor");

        this.lblArrow4.AutoSize = (bool) resources.GetObject("lblArrow4.AutoSize");

        this.lblArrow4.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblArrow4.Dock");

        this.lblArrow4.Enabled = (bool) resources.GetObject("lblArrow4.Enabled");

        this.lblArrow4.Font = (System.Drawing.Font) resources.GetObject("lblArrow4.Font");

        this.lblArrow4.Image = (System.Drawing.Image) resources.GetObject("lblArrow4.Image");

        this.lblArrow4.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblArrow4.ImageAlign");

        this.lblArrow4.ImageIndex = (int) resources.GetObject("lblArrow4.ImageIndex");

        this.lblArrow4.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblArrow4.ImeMode");

        this.lblArrow4.Location = (System.Drawing.Point) resources.GetObject("lblArrow4.Location");

        this.lblArrow4.Name = "lblArrow4";

        this.lblArrow4.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblArrow4.RightToLeft");

        this.lblArrow4.Size = (System.Drawing.Size) resources.GetObject("lblArrow4.Size");

        this.lblArrow4.TabIndex = (int) resources.GetObject("lblArrow4.TabIndex");

        this.lblArrow4.Text = resources.GetString("lblArrow4.Text");

        this.lblArrow4.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblArrow4.TextAlign");

        this.lblArrow4.Visible = (bool) resources.GetObject("lblArrow4.Visible");

        //

        //lblStep4

        //

        this.lblStep4.AccessibleDescription = (string) resources.GetObject("lblStep4.AccessibleDescription");

        this.lblStep4.AccessibleName = (string) resources.GetObject("lblStep4.AccessibleName");

        this.lblStep4.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblStep4.Anchor");

        this.lblStep4.AutoSize = (bool) resources.GetObject("lblStep4.AutoSize");

        this.lblStep4.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblStep4.Dock");

        this.lblStep4.Enabled = (bool) resources.GetObject("lblStep4.Enabled");

        this.lblStep4.Font = (System.Drawing.Font) resources.GetObject("lblStep4.Font");

        this.lblStep4.Image = (System.Drawing.Image) resources.GetObject("lblStep4.Image");

        this.lblStep4.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStep4.ImageAlign");

        this.lblStep4.ImageIndex = (int) resources.GetObject("lblStep4.ImageIndex");

        this.lblStep4.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblStep4.ImeMode");

        this.lblStep4.Location = (System.Drawing.Point) resources.GetObject("lblStep4.Location");

        this.lblStep4.Name = "lblStep4";

        this.lblStep4.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblStep4.RightToLeft");

        this.lblStep4.Size = (System.Drawing.Size) resources.GetObject("lblStep4.Size");

        this.lblStep4.TabIndex = (int) resources.GetObject("lblStep4.TabIndex");

        this.lblStep4.Text = resources.GetString("lblStep4.Text");

        this.lblStep4.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStep4.TextAlign");

        this.lblStep4.Visible = (bool) resources.GetObject("lblStep4.Visible");

        //

        //btnCreateView

        //

        this.btnCreateView.AccessibleDescription = (string) resources.GetObject("btnCreateView.AccessibleDescription");

        this.btnCreateView.AccessibleName = (string) resources.GetObject("btnCreateView.AccessibleName");

        this.btnCreateView.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCreateView.Anchor");

        this.btnCreateView.BackColor = System.Drawing.SystemColors.InactiveCaptionText;

        this.btnCreateView.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCreateView.BackgroundImage");

        this.btnCreateView.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCreateView.Dock");

        this.btnCreateView.Enabled = (bool) resources.GetObject("btnCreateView.Enabled");

        this.btnCreateView.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCreateView.FlatStyle");

        this.btnCreateView.Font = (System.Drawing.Font) resources.GetObject("btnCreateView.Font");

        this.btnCreateView.Image = (System.Drawing.Image) resources.GetObject("btnCreateView.Image");

        this.btnCreateView.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateView.ImageAlign");

        this.btnCreateView.ImageIndex = (int) resources.GetObject("btnCreateView.ImageIndex");

        this.btnCreateView.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCreateView.ImeMode");

        this.btnCreateView.Location = (System.Drawing.Point) resources.GetObject("btnCreateView.Location");

        this.btnCreateView.Name = "btnCreateView";

        this.btnCreateView.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCreateView.RightToLeft");

        this.btnCreateView.Size = (System.Drawing.Size) resources.GetObject("btnCreateView.Size");

        this.btnCreateView.TabIndex = (int) resources.GetObject("btnCreateView.TabIndex");

        this.btnCreateView.Text = resources.GetString("btnCreateView.Text");

        this.btnCreateView.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateView.TextAlign");

        this.btnCreateView.Visible = (bool) resources.GetObject("btnCreateView.Visible");
		
		this.btnCreateView.Click+=new EventHandler(btnCreateView_Click);

        //

        //dgSeafood

        //

        this.dgSeafood.AccessibleDescription = (string) resources.GetObject("dgSeafood.AccessibleDescription");

        this.dgSeafood.AccessibleName = (string) resources.GetObject("dgSeafood.AccessibleName");

        this.dgSeafood.AlternatingBackColor = System.Drawing.SystemColors.Window;

        this.dgSeafood.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("dgSeafood.Anchor");

        this.dgSeafood.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;

        this.dgSeafood.BackgroundImage = (System.Drawing.Image) resources.GetObject("dgSeafood.BackgroundImage");

        this.dgSeafood.CaptionFont = (System.Drawing.Font) resources.GetObject("dgSeafood.CaptionFont");

        this.dgSeafood.CaptionText = resources.GetString("dgSeafood.CaptionText");

        this.dgSeafood.DataMember = string.Empty;

        this.dgSeafood.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("dgSeafood.Dock");

        this.dgSeafood.Enabled = (bool) resources.GetObject("dgSeafood.Enabled");

        this.dgSeafood.Font = (System.Drawing.Font) resources.GetObject("dgSeafood.Font");

        this.dgSeafood.GridLineColor = System.Drawing.SystemColors.Control;

        this.dgSeafood.HeaderBackColor = System.Drawing.SystemColors.Control;

        this.dgSeafood.HeaderForeColor = System.Drawing.SystemColors.ControlText;

        this.dgSeafood.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("dgSeafood.ImeMode");

        this.dgSeafood.LinkColor = System.Drawing.SystemColors.HotTrack;

        this.dgSeafood.Location = (System.Drawing.Point) resources.GetObject("dgSeafood.Location");

        this.dgSeafood.Name = "dgSeafood";

        this.dgSeafood.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("dgSeafood.RightToLeft");

        this.dgSeafood.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;

        this.dgSeafood.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;

        this.dgSeafood.Size = (System.Drawing.Size) resources.GetObject("dgSeafood.Size");

        this.dgSeafood.TabIndex = (int) resources.GetObject("dgSeafood.TabIndex");

        this.dgSeafood.Visible = (bool) resources.GetObject("dgSeafood.Visible");

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

        this.BackColor = System.Drawing.SystemColors.Info;

        this.BackgroundImage = (System.Drawing.Image) resources.GetObject("$this.BackgroundImage");

        this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.dgSeafood, this.lblStep6, this.btnDisplay, this.lblArrow5, this.lblStep5, this.btnPopulate, this.lblArrow4, this.lblStep4, this.btnCreateView, this.lblArrow3, this.lblStep3, this.btnCreateSP, this.lblArrow2, this.lblStep2, this.btnCreateTable, this.lblArrow1, this.lblStep1, this.btnCreateDB, this.Label1});

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

        ((System.ComponentModel.ISupportInitialize) this.dgSeafood).EndInit();
		
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

    // This routine executes a SQL statement that drops the database (if it exists) 
    // and then creates it. 

    private void CreateTable()
	{

        string strSQL  = "IF EXISTS (" + 
						"SELECT * " + 
						"FROM master..sysdatabases " + 
						"WHERE Name = 'HowToDemo')" + Environment.NewLine + 
						"DROP DATABASE HowToDemo" + Environment.NewLine + 
						"CREATE DATABASE HowToDemo";

        // Display a status message saying that we're attempting to connect.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

        frmStatus frmStatusMessage = new frmStatus();

        if (bolDidPreviouslyConnect==false) 
		{

            frmStatusMessage.Show("Connecting to SQL Server");

        }

        // Attempt to connect to the local SQL server instance, and a local
        // MSDE installation (with Northwind).  

        bool bolIsConnecting  = true;

        while (bolIsConnecting)
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

                // Open the connection, execute the command, and close the 
                // connection. It is more efficient to ExecuteNonQuery when data is 
                // not being returned.

                northwindConnection.Open();
                cmd.ExecuteNonQuery();
                northwindConnection.Close();

                // Data has been successfully submitted, so break out of the loop
                // and close the status form.

                bolIsConnecting = false;
                bolDidPreviouslyConnect = true;
                bolDidCreateTable = true;
                frmStatusMessage.Close();

                // Show the controls for the next step.

                lblArrow1.Visible = true;
                lblStep2.Enabled = true;
                btnCreateTable.Enabled = true;
                MessageBox.Show("Database 'HowToDemo' successfully created!", "Database Creation Status", MessageBoxButtons.OK,MessageBoxIcon.Information);

			} 
			catch(SqlException sqlExc)
			{

                MessageBox.Show(sqlExc.ToString(), "SQL Exception Error!",MessageBoxButtons.OK, MessageBoxIcon.Error);
			} 
			catch(Exception exc)
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
                    MessageBox.Show(CONNECTION_ERROR_MSG,"Connection Failed!", MessageBoxButtons.OK,MessageBoxIcon.Error);

                    Application.Exit();

                }

            }

        }

        frmStatusMessage.Close();

    }

    // Sets up the user interface so that the user proceeds in proper order

    // through the steps.

    private void ResetUI()
	{

        lblArrow1.Visible = false;

        lblStep2.Enabled = false;

        btnCreateTable.Enabled = false;

        lblArrow2.Visible = false;

        lblStep3.Enabled = false;

        btnCreateSP.Enabled = false;

        lblArrow3.Visible = false;

        lblStep4.Enabled = false;

        btnCreateView.Enabled = false;

        lblArrow4.Visible = false;

        lblStep5.Enabled = false;

        btnPopulate.Enabled = false;

        lblArrow5.Visible = false;

        lblStep6.Enabled = false;

        btnDisplay.Enabled = false;

        dgSeafood.Visible = false;

        dgSeafood.DataSource = null;

        dgSeafood.TableStyles.Clear();
    
		dgSeafood.Visible = false;

    }

    // the click event for the Create Database button.

    private void btnCreateDB_Click(object sender, System.EventArgs e)
	{

        // if the "Create Table" button is enabled this means the user is trying to
        // recreate the database again in the same application run. Warn the user of
        // how this will affect things, and if they want to proceed, reset the UI to
        // the initial state so that errors are not induced if currently enabled 
        // buttons are clicked out of order.

        if (btnCreateTable.Enabled)
		{

            DialogResult dr  = MessageBox.Show("Recreating the database " + 
											  "will undo the other database object creation steps you have " + 
											  "made so far. Do you wish to proceed?", "Database Re-creation " + 
											  "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
			{

                ResetUI();
                CreateTable();

            }
		}

        else {

            CreateTable();

        }

    }

    // the click event for the Create Procedure button. This handler executes
    // two SQL statements, one that drops the Procedure (if it exists) and another 
    // that creates the Procedure. The statements are broken up in this manner 
    // because SQL Server doesn't allow them to be combined in one batch. (You can 
    // combine them when using the GO keyword and executing from SQL Query Analyzer 
    // or another tool, but not from code.)

    private void btnCreateSP_Click(object sender, System.EventArgs e)
	{

        // The SqlConnection class allows you to communicate with SQL Server.
        // The constructor accepts a connection string an argument.  This
        // connection string uses Integrated Security, which means that you 
        // must have a login in SQL Server, or be part of the Administrators
        // group for this to work.

        SqlConnection northwindConnection  = new SqlConnection(connectionstring);

        string strSQL  = "USE HowToDemo" + Environment.NewLine + "IF EXISTS (" + 
						 "SELECT * " + 
						 "FROM HowToDemo.dbo.sysobjects " + 
						 "WHERE Name = 'AddSeafood' " + 
						 "AND TYPE = 'p')" + Environment.NewLine + 
						 "BEGIN" + Environment.NewLine +
						 "DROP PROCEDURE AddSeafood" + Environment.NewLine + 
						 "END";

        // A SqlCommand object is used to execute the SQL commands.

        SqlCommand cmd  = new SqlCommand(strSQL, northwindConnection);

        try 
		{

            // Open the connection, execute the command, and close the connection.
            // It is more efficient to ExecuteNonQuery when data is not being 
            // returned.

            northwindConnection.Open();

            cmd.ExecuteNonQuery();

		} 
		catch(SqlException sqlExc)
		{

            MessageBox.Show(sqlExc.ToString(), "SQL Exception Error!",MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        try 
		{

            cmd.CommandText = "CREATE PROCEDURE AddSeafood AS" + Environment.NewLine + 
							  "INSERT INTO NW_Seafood" + Environment.NewLine + 
							  "(ProductID, ProductName, QuantityPerUnit, UnitPrice)" + 
							  "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice " + 
							  "FROM Northwind.dbo.Products " + 
							  "WHERE CategoryID = 8";

            cmd.ExecuteNonQuery();

            northwindConnection.Close();

            // Show the controls for the next step.

            lblArrow3.Visible = true;

            lblStep4.Enabled = true;

            btnCreateView.Enabled = true;

            MessageBox.Show("Stored Procedure 'AddSeafood' successfully " +
							"created.", "SPROC Creation Status",
							MessageBoxButtons.OK, MessageBoxIcon.Information);

		} 
		catch(SqlException sqlExc)
		{
            MessageBox.Show(sqlExc.ToString(), "SQL Exception Error!",
							MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }

    // the click event for the Create Table button.

    private void btnCreateTable_Click(object sender, System.EventArgs e)
	{

        string strSQL  = "USE HowToDemo" + Environment.NewLine + 
							"IF EXISTS (" + 
							"SELECT * " + 
							"FROM HowToDemo.dbo.sysobjects " + 
							"WHERE Name = 'NW_Seafood' " + 
							"AND TYPE = 'u')" + Environment.NewLine + 
							"BEGIN" + Environment.NewLine + 
							"DROP TABLE HowToDemo.dbo.NW_Seafood" + Environment.NewLine + 
							"END" + Environment.NewLine + 
							"CREATE TABLE NW_Seafood (" + 
							"ProductID Int NOT NULL," + 
							"ProductName NVarChar(40) NOT NULL," + 
							"QuantityPerUnit NVarChar(20) NOT NULL," + 
							"UnitPrice Money NOT NULL," + 
							"CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED" + 
							"(ProductID))";

        try 
		{

            // The SqlConnection class allows you to communicate with SQL Server.
            // The constructor accepts a connection string an argument.  This
            // connection string uses Integrated Security, which means that you 
            // must have a login in SQL Server, or be part of the Administrators
            // group for this to work.

            SqlConnection northwindConnection  = new SqlConnection(connectionstring);

            // A SqlCommand object is used to execute the SQL commands.

            SqlCommand cmd =  new SqlCommand(strSQL, northwindConnection);

            // Open the connection, execute the command, and close the connection.
            // It is more efficient to ExecuteNonQuery when data is not being 
            // returned.

            northwindConnection.Open();
            cmd.ExecuteNonQuery();
            northwindConnection.Close();

            // Show the controls for the next step.

            lblArrow2.Visible = true;
            lblStep3.Enabled = true;
            btnCreateSP.Enabled = true;
            MessageBox.Show("Table 'NW_Seafood' successfully created.", 
							"Table Creation Status", 
							MessageBoxButtons.OK, MessageBoxIcon.Information);

		} 
		catch(SqlException sqlExc)
		{
            MessageBox.Show(sqlExc.ToString(), "SQL Exception Error!",
							MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }

    // the click event for the Create View button. This handler executes
    // two SQL statements, one that drops the View (if it exists) and another 
    // that creates the View. The statements are broken up in this manner because
    // SQL Server doesn't allow them to be combined in one batch. (You can combine
    // them when using the GO keyword and executing from SQL Query Analyzer or 
    // another tool, but not from code.)

    private void btnCreateView_Click(object sender, System.EventArgs e)
	{
        // The SqlConnection class allows you to communicate with SQL Server.
        // The constructor accepts a connection string an argument.  This
        // connection string uses Integrated Security, which means that you 
        // must have a login in SQL Server, or be part of the Administrators
        // group for this to work.

        SqlConnection northwindConnection = new SqlConnection(connectionstring);

        string strSQL  = "USE HowToDemo" + Environment.NewLine + 
							"IF EXISTS (" + 
							"SELECT * " + 
							"FROM HowToDemo.dbo.sysobjects " + 
							"WHERE Name = 'GetSeafood' " + 
							"AND TYPE = 'v')" + Environment.NewLine + 
							"BEGIN" + Environment.NewLine + 
							"DROP VIEW GetSeafood" + Environment.NewLine + 
							"END";

        // A SqlCommand object is used to execute the SQL commands.

        SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);

        try 
		{

            // Open the connection, execute the command. Do not close the
            // connection yet it will be used in the next try {...catch blocl.

            northwindConnection.Open();
            cmd.ExecuteNonQuery();

		} 
		catch(SqlException sqlExc)
		{

            MessageBox.Show(sqlExc.ToString(), "SQL Exception Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        try 
		{

            // Change the SQL statement for the next query.

            cmd.CommandText = "CREATE VIEW GetSeafood AS " + 
							  "SELECT * " + 
							  "FROM NW_Seafood";
            
			cmd.ExecuteNonQuery();
            northwindConnection.Close();

            // Show the controls for the next step.

            lblArrow4.Visible = true;
            lblStep5.Enabled = true;
            btnPopulate.Enabled = true;

            MessageBox.Show("View 'GetSeafood' successfully " + 
							"created.", "SQL View Creation Status", 
							MessageBoxButtons.OK, MessageBoxIcon.Information);

		} 
		catch(SqlException sqlExc)
		{
            MessageBox.Show(sqlExc.ToString(), "SQL Exception Error!",
							MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }

    // the click event for the Display button. This handler gets the product
    // information from the NW_Seafood table puts it into a Dataset which is used to
    // bind to a DataGrid for display. Custom style objects are used to give the 
    // DataGrid a nice appearance.

    private void btnDisplay_Click(object sender, System.EventArgs e)
	{
        if (dgSeafood.DataSource==null)
		{

            string strSQL  = "USE HowToDemo" + Environment.NewLine + 
							 "SELECT * " + 
							 "FROM GetSeafood";

            try 
			{

                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in SQL Server, or be part of the Administrators
                // group for this to work.

                SqlConnection northwindConnection  = new SqlConnection(connectionstring);

                // A SqlCommand object is used to execute the SQL commands.

                SqlCommand cmd  = new SqlCommand(strSQL, northwindConnection);

                // The SqlDataAdapter is responsible for using a SqlCommand object to 

                // fill a DataSet.

                SqlDataAdapter da  = new SqlDataAdapter(cmd);

                DataSet dsSeafood  = new DataSet();

                da.Fill(dsSeafood, "Seafood");

                // Set the DataGrid caption, bind it to the DataSet, and then make it
                // Visible (recall Visible was set to false in the Form load event 
                // handler). if you don't set Visible = true when it was previously 
                // set to false, the DataGrid will still appear, but the scroll bar 
                // will be missing, which can be rather puzzling.

                dgSeafood.CaptionText = "Northwind Seafood";

                // Notice here that instead of using the Dataset table name, 
                // "Seafood", the alternate syntax of table index is used.

                dgSeafood.DataSource = dsSeafood.Tables[0];
                dgSeafood.Visible = true;

                // Use a table style object to apply custom formatting to the 
                // DataGrid.

                DataGridTableStyle dgTableStyle1 = new DataGridTableStyle();
                dgTableStyle1.AlternatingBackColor = Color.Lavender;
                dgTableStyle1.BackColor = Color.WhiteSmoke;
                dgTableStyle1.ForeColor = Color.MidnightBlue;
                dgTableStyle1.GridLineColor = Color.Gainsboro;
                dgTableStyle1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
                dgTableStyle1.HeaderBackColor = Color.MidnightBlue;
                dgTableStyle1.HeaderFont = new Font("Tahoma", 8.0F, FontStyle.Bold);
                dgTableStyle1.HeaderForeColor = Color.WhiteSmoke;
                dgTableStyle1.LinkColor = Color.Teal;

                // Do not forget to set the MappingName property. 
                // Without this, the DataGridTableStyle properties
                // and any associated DataGridColumnStyle objects
                // will have no effect.

                 dgTableStyle1.MappingName = "Seafood";
                 dgTableStyle1.SelectionBackColor = Color.CadetBlue;
                 dgTableStyle1.SelectionForeColor = Color.WhiteSmoke;
                
                // Use column style objects to apply formatting specific to each 
                // column.

                DataGridTextBoxColumn grdColStyle1 = new DataGridTextBoxColumn();

                grdColStyle1.HeaderText = "ID#";
                grdColStyle1.MappingName = "ProductID";
                grdColStyle1.Width = 50;
                
                DataGridTextBoxColumn grdColStyle2 = new DataGridTextBoxColumn();

                grdColStyle2.HeaderText = "Name";
                grdColStyle2.MappingName = "ProductName";
                grdColStyle2.Width = 180;
                
                DataGridTextBoxColumn grdColStyle3  = new DataGridTextBoxColumn();

                grdColStyle3.HeaderText = "Quantity/Unit";
                grdColStyle3.MappingName = "QuantityPerUnit";
                grdColStyle3.Width = 140;

                DataGridTextBoxColumn grdColStyle4 = new DataGridTextBoxColumn();

                grdColStyle4.HeaderText = "Price";
                grdColStyle4.MappingName = "UnitPrice";
                grdColStyle4.Width = 70;

                // Add the column style objects to the tables style's column styles 
                // collection. if you fail to do this the column styles will not 
                // apply.

                dgTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[] 
													    {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4});

                // Add the table style object to the DataGrid's table styles 
                // collection. Again, failure to add the style to the collection 
                // will cause the style to not take effect.

                dgSeafood.TableStyles.Add(dgTableStyle1);

			} 
			catch(SqlException sqlExc)
			{

                MessageBox.Show(sqlExc.ToString(), "SQL Exception Error!",
								MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

    }

    // the click event for the Populate button. This handler executes the
    // stored procedure that fills the NW_Seafood table with product info from the
    // Northwind database Products table.

    private void btnPopulate_Click(object sender, System.EventArgs e)
	{

        string strSQL  = "EXECUTE HowToDemo.dbo.AddSeafood";

        try 
		{
            // The SqlConnection class allows you to communicate with SQL Server.
            // The constructor accepts a connection string an argument.  This
            // connection string uses Integrated Security, which means that you 
            // must have a login in SQL Server, or be part of the Administrators
            // group for this to work.

			SqlConnection northwindConnection  = new SqlConnection(connectionstring);

            // A SqlCommand object is used to execute the SQL commands.

            SqlCommand cmd  = new SqlCommand(strSQL, northwindConnection);

            // Open the connection, execute the command, and close the connection.
            // It is more efficient to ExecuteNonQuery when data is not being 
            // returned.

            northwindConnection.Open();
            cmd.ExecuteNonQuery();
            northwindConnection.Close();

            // Show the controls for the next step.

            lblArrow5.Visible = true;
            lblStep6.Enabled = true;
            btnDisplay.Enabled = true;
            MessageBox.Show("Table successfully populated.", 
							"Data Addition Status", 
							MessageBoxButtons.OK, MessageBoxIcon.Information);

		} 
		catch(SqlException sqlExc)
		{

            MessageBox.Show(sqlExc.ToString(), "SQL Exception Error!", 
							MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }

    // the Form load event.

    private void frmMain_Load(object sender, System.EventArgs e) 
	{

        ResetUI();

    }

}

