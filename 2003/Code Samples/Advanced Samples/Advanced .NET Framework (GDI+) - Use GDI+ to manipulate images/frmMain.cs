//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

public class frmMain : System.Windows.Forms.Form 
{
#region " Windows Form Designer generated code "

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

    private bool blnPictureBoxSizeHasChanged  = false;

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

    private System.Windows.Forms.PictureBox picImage;

    private System.Windows.Forms.GroupBox grpSizeMode;

    private System.Windows.Forms.RadioButton optCenterImage;

    private System.Windows.Forms.RadioButton optAutoSize;

    private System.Windows.Forms.RadioButton optStretchImage;

    private System.Windows.Forms.RadioButton optNormal;

    private System.Windows.Forms.Button btnBrowse;

    private System.Windows.Forms.Button btnSave;

    private System.Windows.Forms.OpenFileDialog odlgImage;

    private System.Windows.Forms.SaveFileDialog sdlgImage;

    private System.Windows.Forms.Button btnZoomOut;

    private System.Windows.Forms.Button btnZoomIn;

    private System.Windows.Forms.Button btnFit;

    private System.Windows.Forms.Button btnRotateLeft;

    private System.Windows.Forms.GroupBox grpCropping;

    private System.Windows.Forms.TextBox txtYCoord;

    private System.Windows.Forms.TextBox txtXCoord;

    private System.Windows.Forms.Label lblXCoord;

    private System.Windows.Forms.Label lblYCoord;

    private System.Windows.Forms.TextBox txtHeight;

    private System.Windows.Forms.TextBox txtWidth;

    private System.Windows.Forms.Label lblWidth;

    private System.Windows.Forms.Label lblHeight;

    private System.Windows.Forms.Button btnCrop;

    private System.Windows.Forms.Button btnRotateRight;

    private System.Windows.Forms.Button btnUndo;

    private System.Windows.Forms.Button btnShowBox;

    private System.Windows.Forms.CheckBox chkThumbnail;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.odlgImage = new System.Windows.Forms.OpenFileDialog();

        this.picImage = new System.Windows.Forms.PictureBox();

        this.grpSizeMode = new System.Windows.Forms.GroupBox();

        this.optCenterImage = new System.Windows.Forms.RadioButton();

        this.optAutoSize = new System.Windows.Forms.RadioButton();

        this.optStretchImage = new System.Windows.Forms.RadioButton();

        this.optNormal = new System.Windows.Forms.RadioButton();

        this.btnBrowse = new System.Windows.Forms.Button();

        this.btnSave = new System.Windows.Forms.Button();

        this.sdlgImage = new System.Windows.Forms.SaveFileDialog();

        this.btnZoomOut = new System.Windows.Forms.Button();

        this.btnZoomIn = new System.Windows.Forms.Button();

        this.btnFit = new System.Windows.Forms.Button();

        this.btnRotateLeft = new System.Windows.Forms.Button();

        this.grpCropping = new System.Windows.Forms.GroupBox();

        this.btnShowBox = new System.Windows.Forms.Button();

        this.btnUndo = new System.Windows.Forms.Button();

        this.btnCrop = new System.Windows.Forms.Button();

        this.txtHeight = new System.Windows.Forms.TextBox();

        this.txtWidth = new System.Windows.Forms.TextBox();

        this.lblYCoord = new System.Windows.Forms.Label();

        this.lblXCoord = new System.Windows.Forms.Label();

        this.txtYCoord = new System.Windows.Forms.TextBox();

        this.txtXCoord = new System.Windows.Forms.TextBox();

        this.lblHeight = new System.Windows.Forms.Label();

        this.lblWidth = new System.Windows.Forms.Label();

        this.btnRotateRight = new System.Windows.Forms.Button();

        this.chkThumbnail = new System.Windows.Forms.CheckBox();

        this.grpSizeMode.SuspendLayout();

        this.grpCropping.SuspendLayout();

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

		this.mnuExit.Click += new EventHandler(mnuExit_Click);

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

		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);

        //

        //odlgImage

        //

        this.odlgImage.Filter = resources.GetString("odlgImage.Filter");

        this.odlgImage.Title = resources.GetString("odlgImage.Title");

        //

        //picImage

        //

        this.picImage.AccessibleDescription = resources.GetString("picImage.AccessibleDescription");

        this.picImage.AccessibleName = resources.GetString("picImage.AccessibleName");

        this.picImage.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("picImage.Anchor");

        this.picImage.BackgroundImage = (System.Drawing.Image) resources.GetObject("picImage.BackgroundImage");

        this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.picImage.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("picImage.Dock");

        this.picImage.Enabled = (bool) resources.GetObject("picImage.Enabled");

        this.picImage.Font = (System.Drawing.Font) resources.GetObject("picImage.Font");

        this.picImage.Image = (System.Drawing.Bitmap) resources.GetObject("picImage.Image");

        this.picImage.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("picImage.ImeMode");

        this.picImage.Location = (System.Drawing.Point) resources.GetObject("picImage.Location");

        this.picImage.Name = "picImage";

        this.picImage.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("picImage.RightToLeft");

        this.picImage.Size = (System.Drawing.Size) resources.GetObject("picImage.Size");

        this.picImage.SizeMode = (System.Windows.Forms.PictureBoxSizeMode) resources.GetObject("picImage.SizeMode");

        this.picImage.TabIndex = (int) resources.GetObject("picImage.TabIndex");

        this.picImage.TabStop = false;

        this.picImage.Text = resources.GetString("picImage.Text");

        this.picImage.Visible = (bool) resources.GetObject("picImage.Visible");

        //

        //grpSizeMode

        //

        this.grpSizeMode.AccessibleDescription = resources.GetString("grpSizeMode.AccessibleDescription");

        this.grpSizeMode.AccessibleName = resources.GetString("grpSizeMode.AccessibleName");

        this.grpSizeMode.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grpSizeMode.Anchor");

        this.grpSizeMode.BackgroundImage = (System.Drawing.Image) resources.GetObject("grpSizeMode.BackgroundImage");

        this.grpSizeMode.Controls.AddRange(new System.Windows.Forms.Control[] {this.optCenterImage, this.optAutoSize, this.optStretchImage, this.optNormal});

        this.grpSizeMode.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grpSizeMode.Dock");

        this.grpSizeMode.Enabled = (bool) resources.GetObject("grpSizeMode.Enabled");

        this.grpSizeMode.Font = (System.Drawing.Font) resources.GetObject("grpSizeMode.Font");

        this.grpSizeMode.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grpSizeMode.ImeMode");

        this.grpSizeMode.Location = (System.Drawing.Point) resources.GetObject("grpSizeMode.Location");

        this.grpSizeMode.Name = "grpSizeMode";

        this.grpSizeMode.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grpSizeMode.RightToLeft");

        this.grpSizeMode.Size = (System.Drawing.Size) resources.GetObject("grpSizeMode.Size");

        this.grpSizeMode.TabIndex = (int) resources.GetObject("grpSizeMode.TabIndex");

        this.grpSizeMode.TabStop = false;

        this.grpSizeMode.Text = resources.GetString("grpSizeMode.Text");

        this.grpSizeMode.Visible = (bool) resources.GetObject("grpSizeMode.Visible");

        //

        //optCenterImage

        //

        this.optCenterImage.AccessibleDescription = resources.GetString("optCenterImage.AccessibleDescription");

        this.optCenterImage.AccessibleName = resources.GetString("optCenterImage.AccessibleName");

        this.optCenterImage.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optCenterImage.Anchor");

        this.optCenterImage.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optCenterImage.Appearance");

        this.optCenterImage.BackgroundImage = (System.Drawing.Image) resources.GetObject("optCenterImage.BackgroundImage");

        this.optCenterImage.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCenterImage.CheckAlign");

        this.optCenterImage.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optCenterImage.Dock");

        this.optCenterImage.Enabled = (bool) resources.GetObject("optCenterImage.Enabled");

        this.optCenterImage.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optCenterImage.FlatStyle");

        this.optCenterImage.Font = (System.Drawing.Font) resources.GetObject("optCenterImage.Font");

        this.optCenterImage.Image = (System.Drawing.Image) resources.GetObject("optCenterImage.Image");

        this.optCenterImage.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCenterImage.ImageAlign");

        this.optCenterImage.ImageIndex = (int) resources.GetObject("optCenterImage.ImageIndex");

        this.optCenterImage.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optCenterImage.ImeMode");

        this.optCenterImage.Location = (System.Drawing.Point) resources.GetObject("optCenterImage.Location");

        this.optCenterImage.Name = "optCenterImage";

        this.optCenterImage.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optCenterImage.RightToLeft");

        this.optCenterImage.Size = (System.Drawing.Size) resources.GetObject("optCenterImage.Size");

        this.optCenterImage.TabIndex = (int) resources.GetObject("optCenterImage.TabIndex");

        this.optCenterImage.Tag = "3";

        this.optCenterImage.Text = resources.GetString("optCenterImage.Text");

        this.optCenterImage.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCenterImage.TextAlign");

        this.optCenterImage.Visible = (bool) resources.GetObject("optCenterImage.Visible");

		this.optCenterImage.CheckedChanged += new EventHandler(SizeModeRadioButtons_CheckedChanged);

        //

        //optAutoSize

        //

        this.optAutoSize.AccessibleDescription = resources.GetString("optAutoSize.AccessibleDescription");

        this.optAutoSize.AccessibleName = resources.GetString("optAutoSize.AccessibleName");

        this.optAutoSize.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optAutoSize.Anchor");

        this.optAutoSize.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optAutoSize.Appearance");

        this.optAutoSize.BackgroundImage = (System.Drawing.Image) resources.GetObject("optAutoSize.BackgroundImage");

        this.optAutoSize.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optAutoSize.CheckAlign");

        this.optAutoSize.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optAutoSize.Dock");

        this.optAutoSize.Enabled = (bool) resources.GetObject("optAutoSize.Enabled");

        this.optAutoSize.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optAutoSize.FlatStyle");

        this.optAutoSize.Font = (System.Drawing.Font) resources.GetObject("optAutoSize.Font");

        this.optAutoSize.Image = (System.Drawing.Image) resources.GetObject("optAutoSize.Image");

        this.optAutoSize.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optAutoSize.ImageAlign");

        this.optAutoSize.ImageIndex = (int) resources.GetObject("optAutoSize.ImageIndex");

        this.optAutoSize.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optAutoSize.ImeMode");

        this.optAutoSize.Location = (System.Drawing.Point) resources.GetObject("optAutoSize.Location");

        this.optAutoSize.Name = "optAutoSize";

        this.optAutoSize.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optAutoSize.RightToLeft");

        this.optAutoSize.Size = (System.Drawing.Size) resources.GetObject("optAutoSize.Size");

        this.optAutoSize.TabIndex = (int) resources.GetObject("optAutoSize.TabIndex");

        this.optAutoSize.Tag = "2";

        this.optAutoSize.Text = resources.GetString("optAutoSize.Text");

        this.optAutoSize.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optAutoSize.TextAlign");

        this.optAutoSize.Visible = (bool) resources.GetObject("optAutoSize.Visible");

		this.optAutoSize.CheckedChanged += new EventHandler(SizeModeRadioButtons_CheckedChanged);

        //

        //optStretchImage

        //

        this.optStretchImage.AccessibleDescription = resources.GetString("optStretchImage.AccessibleDescription");

        this.optStretchImage.AccessibleName = resources.GetString("optStretchImage.AccessibleName");

        this.optStretchImage.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optStretchImage.Anchor");

        this.optStretchImage.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optStretchImage.Appearance");

        this.optStretchImage.BackgroundImage = (System.Drawing.Image) resources.GetObject("optStretchImage.BackgroundImage");

        this.optStretchImage.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optStretchImage.CheckAlign");

        this.optStretchImage.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optStretchImage.Dock");

        this.optStretchImage.Enabled = (bool) resources.GetObject("optStretchImage.Enabled");

        this.optStretchImage.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optStretchImage.FlatStyle");

        this.optStretchImage.Font = (System.Drawing.Font) resources.GetObject("optStretchImage.Font");

        this.optStretchImage.Image = (System.Drawing.Image) resources.GetObject("optStretchImage.Image");

        this.optStretchImage.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optStretchImage.ImageAlign");

        this.optStretchImage.ImageIndex = (int) resources.GetObject("optStretchImage.ImageIndex");

        this.optStretchImage.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optStretchImage.ImeMode");

        this.optStretchImage.Location = (System.Drawing.Point) resources.GetObject("optStretchImage.Location");

        this.optStretchImage.Name = "optStretchImage";

        this.optStretchImage.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optStretchImage.RightToLeft");

        this.optStretchImage.Size = (System.Drawing.Size) resources.GetObject("optStretchImage.Size");

        this.optStretchImage.TabIndex = (int) resources.GetObject("optStretchImage.TabIndex");

        this.optStretchImage.Tag = "1";

        this.optStretchImage.Text = resources.GetString("optStretchImage.Text");

        this.optStretchImage.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optStretchImage.TextAlign");

        this.optStretchImage.Visible = (bool) resources.GetObject("optStretchImage.Visible");

		this.optStretchImage.CheckedChanged += new EventHandler(SizeModeRadioButtons_CheckedChanged);

        //

        //optNormal

        //

        this.optNormal.AccessibleDescription = resources.GetString("optNormal.AccessibleDescription");

        this.optNormal.AccessibleName = resources.GetString("optNormal.AccessibleName");

        this.optNormal.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optNormal.Anchor");

        this.optNormal.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optNormal.Appearance");

        this.optNormal.BackgroundImage = (System.Drawing.Image) resources.GetObject("optNormal.BackgroundImage");

        this.optNormal.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optNormal.CheckAlign");

        this.optNormal.Checked = true;

        this.optNormal.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optNormal.Dock");

        this.optNormal.Enabled = (bool) resources.GetObject("optNormal.Enabled");

        this.optNormal.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optNormal.FlatStyle");

        this.optNormal.Font = (System.Drawing.Font) resources.GetObject("optNormal.Font");

        this.optNormal.Image = (System.Drawing.Image) resources.GetObject("optNormal.Image");

        this.optNormal.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optNormal.ImageAlign");

        this.optNormal.ImageIndex = (int) resources.GetObject("optNormal.ImageIndex");

        this.optNormal.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optNormal.ImeMode");

        this.optNormal.Location = (System.Drawing.Point) resources.GetObject("optNormal.Location");

        this.optNormal.Name = "optNormal";

        this.optNormal.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optNormal.RightToLeft");

        this.optNormal.Size = (System.Drawing.Size) resources.GetObject("optNormal.Size");

        this.optNormal.TabIndex = (int) resources.GetObject("optNormal.TabIndex");

        this.optNormal.TabStop = true;

        this.optNormal.Tag = "0";

        this.optNormal.Text = resources.GetString("optNormal.Text");

        this.optNormal.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optNormal.TextAlign");

        this.optNormal.Visible = (bool) resources.GetObject("optNormal.Visible");

		this.optNormal.CheckedChanged += new EventHandler(SizeModeRadioButtons_CheckedChanged);

        //

        //btnBrowse

        //

        this.btnBrowse.AccessibleDescription = resources.GetString("btnBrowse.AccessibleDescription");

        this.btnBrowse.AccessibleName = resources.GetString("btnBrowse.AccessibleName");

        this.btnBrowse.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnBrowse.Anchor");

        this.btnBrowse.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnBrowse.BackgroundImage");

        this.btnBrowse.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnBrowse.Dock");

        this.btnBrowse.Enabled = (bool) resources.GetObject("btnBrowse.Enabled");

        this.btnBrowse.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnBrowse.FlatStyle");

        this.btnBrowse.Font = (System.Drawing.Font) resources.GetObject("btnBrowse.Font");

        this.btnBrowse.Image = (System.Drawing.Image) resources.GetObject("btnBrowse.Image");

        this.btnBrowse.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBrowse.ImageAlign");

        this.btnBrowse.ImageIndex = (int) resources.GetObject("btnBrowse.ImageIndex");

        this.btnBrowse.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnBrowse.ImeMode");

        this.btnBrowse.Location = (System.Drawing.Point) resources.GetObject("btnBrowse.Location");

        this.btnBrowse.Name = "btnBrowse";

        this.btnBrowse.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnBrowse.RightToLeft");

        this.btnBrowse.Size = (System.Drawing.Size) resources.GetObject("btnBrowse.Size");

        this.btnBrowse.TabIndex = (int) resources.GetObject("btnBrowse.TabIndex");

        this.btnBrowse.Text = resources.GetString("btnBrowse.Text");

        this.btnBrowse.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBrowse.TextAlign");

        this.btnBrowse.Visible = (bool) resources.GetObject("btnBrowse.Visible");

		this.btnBrowse.Click += new EventHandler(btnBrowse_Click);

        //

        //btnSave

        //

        this.btnSave.AccessibleDescription = resources.GetString("btnSave.AccessibleDescription");

        this.btnSave.AccessibleName = resources.GetString("btnSave.AccessibleName");

        this.btnSave.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnSave.Anchor");

        this.btnSave.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnSave.BackgroundImage");

        this.btnSave.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnSave.Dock");

        this.btnSave.Enabled = (bool) resources.GetObject("btnSave.Enabled");

        this.btnSave.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnSave.FlatStyle");

        this.btnSave.Font = (System.Drawing.Font) resources.GetObject("btnSave.Font");

        this.btnSave.Image = (System.Drawing.Image) resources.GetObject("btnSave.Image");

        this.btnSave.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSave.ImageAlign");

        this.btnSave.ImageIndex = (int) resources.GetObject("btnSave.ImageIndex");

        this.btnSave.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnSave.ImeMode");

        this.btnSave.Location = (System.Drawing.Point) resources.GetObject("btnSave.Location");

        this.btnSave.Name = "btnSave";

        this.btnSave.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnSave.RightToLeft");

        this.btnSave.Size = (System.Drawing.Size) resources.GetObject("btnSave.Size");

        this.btnSave.TabIndex = (int) resources.GetObject("btnSave.TabIndex");

        this.btnSave.Text = resources.GetString("btnSave.Text");

        this.btnSave.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSave.TextAlign");

        this.btnSave.Visible = (bool) resources.GetObject("btnSave.Visible");

		this.btnSave.Click += new EventHandler(btnSave_Click);

        //

        //sdlgImage

        //

        this.sdlgImage.FileName = "doc1";

        this.sdlgImage.Filter = resources.GetString("sdlgImage.Filter");

        this.sdlgImage.Title = resources.GetString("sdlgImage.Title");

        //

        //btnZoomOut

        //

        this.btnZoomOut.AccessibleDescription = resources.GetString("btnZoomOut.AccessibleDescription");

        this.btnZoomOut.AccessibleName = resources.GetString("btnZoomOut.AccessibleName");

        this.btnZoomOut.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnZoomOut.Anchor");

        this.btnZoomOut.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnZoomOut.BackgroundImage");

        this.btnZoomOut.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnZoomOut.Dock");

        this.btnZoomOut.Enabled = (bool) resources.GetObject("btnZoomOut.Enabled");

        this.btnZoomOut.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnZoomOut.FlatStyle");

        this.btnZoomOut.Font = (System.Drawing.Font) resources.GetObject("btnZoomOut.Font");

        this.btnZoomOut.Image = (System.Drawing.Image) resources.GetObject("btnZoomOut.Image");

        this.btnZoomOut.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnZoomOut.ImageAlign");

        this.btnZoomOut.ImageIndex = (int) resources.GetObject("btnZoomOut.ImageIndex");

        this.btnZoomOut.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnZoomOut.ImeMode");

        this.btnZoomOut.Location = (System.Drawing.Point) resources.GetObject("btnZoomOut.Location");

        this.btnZoomOut.Name = "btnZoomOut";

        this.btnZoomOut.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnZoomOut.RightToLeft");

        this.btnZoomOut.Size = (System.Drawing.Size) resources.GetObject("btnZoomOut.Size");

        this.btnZoomOut.TabIndex = (int) resources.GetObject("btnZoomOut.TabIndex");

        this.btnZoomOut.Text = resources.GetString("btnZoomOut.Text");

        this.btnZoomOut.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnZoomOut.TextAlign");

        this.btnZoomOut.Visible = (bool) resources.GetObject("btnZoomOut.Visible");

		this.btnZoomOut.Click += new EventHandler(btnZoomOut_Click);

        //

        //btnZoomIn

        //

        this.btnZoomIn.AccessibleDescription = resources.GetString("btnZoomIn.AccessibleDescription");

        this.btnZoomIn.AccessibleName = resources.GetString("btnZoomIn.AccessibleName");

        this.btnZoomIn.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnZoomIn.Anchor");

        this.btnZoomIn.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnZoomIn.BackgroundImage");

        this.btnZoomIn.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnZoomIn.Dock");

        this.btnZoomIn.Enabled = (bool) resources.GetObject("btnZoomIn.Enabled");

        this.btnZoomIn.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnZoomIn.FlatStyle");

        this.btnZoomIn.Font = (System.Drawing.Font) resources.GetObject("btnZoomIn.Font");

        this.btnZoomIn.Image = (System.Drawing.Image) resources.GetObject("btnZoomIn.Image");

        this.btnZoomIn.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnZoomIn.ImageAlign");

        this.btnZoomIn.ImageIndex = (int) resources.GetObject("btnZoomIn.ImageIndex");

        this.btnZoomIn.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnZoomIn.ImeMode");

        this.btnZoomIn.Location = (System.Drawing.Point) resources.GetObject("btnZoomIn.Location");

        this.btnZoomIn.Name = "btnZoomIn";

        this.btnZoomIn.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnZoomIn.RightToLeft");

        this.btnZoomIn.Size = (System.Drawing.Size) resources.GetObject("btnZoomIn.Size");

        this.btnZoomIn.TabIndex = (int) resources.GetObject("btnZoomIn.TabIndex");

        this.btnZoomIn.Text = resources.GetString("btnZoomIn.Text");

        this.btnZoomIn.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnZoomIn.TextAlign");

        this.btnZoomIn.Visible = (bool) resources.GetObject("btnZoomIn.Visible");

		this.btnZoomIn.Click += new EventHandler(btnZoomIn_Click);

        //

        //btnFit

        //

        this.btnFit.AccessibleDescription = resources.GetString("btnFit.AccessibleDescription");

        this.btnFit.AccessibleName = resources.GetString("btnFit.AccessibleName");

        this.btnFit.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnFit.Anchor");

        this.btnFit.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnFit.BackgroundImage");

        this.btnFit.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnFit.Dock");

        this.btnFit.Enabled = (bool) resources.GetObject("btnFit.Enabled");

        this.btnFit.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnFit.FlatStyle");

        this.btnFit.Font = (System.Drawing.Font) resources.GetObject("btnFit.Font");

        this.btnFit.Image = (System.Drawing.Image) resources.GetObject("btnFit.Image");

        this.btnFit.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnFit.ImageAlign");

        this.btnFit.ImageIndex = (int) resources.GetObject("btnFit.ImageIndex");

        this.btnFit.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnFit.ImeMode");

        this.btnFit.Location = (System.Drawing.Point) resources.GetObject("btnFit.Location");

        this.btnFit.Name = "btnFit";

        this.btnFit.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnFit.RightToLeft");

        this.btnFit.Size = (System.Drawing.Size) resources.GetObject("btnFit.Size");

        this.btnFit.TabIndex = (int) resources.GetObject("btnFit.TabIndex");

        this.btnFit.Text = resources.GetString("btnFit.Text");

        this.btnFit.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnFit.TextAlign");

        this.btnFit.Visible = (bool) resources.GetObject("btnFit.Visible");

		this.btnFit.Click += new EventHandler(btnFit_Click);

        //

        //btnRotateLeft

        //

        this.btnRotateLeft.AccessibleDescription = resources.GetString("btnRotateLeft.AccessibleDescription");

        this.btnRotateLeft.AccessibleName = resources.GetString("btnRotateLeft.AccessibleName");

        this.btnRotateLeft.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnRotateLeft.Anchor");

        this.btnRotateLeft.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnRotateLeft.BackgroundImage");

        this.btnRotateLeft.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnRotateLeft.Dock");

        this.btnRotateLeft.Enabled = (bool) resources.GetObject("btnRotateLeft.Enabled");

        this.btnRotateLeft.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnRotateLeft.FlatStyle");

        this.btnRotateLeft.Font = (System.Drawing.Font) resources.GetObject("btnRotateLeft.Font");

        this.btnRotateLeft.Image = (System.Drawing.Image) resources.GetObject("btnRotateLeft.Image");

        this.btnRotateLeft.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRotateLeft.ImageAlign");

        this.btnRotateLeft.ImageIndex = (int) resources.GetObject("btnRotateLeft.ImageIndex");

        this.btnRotateLeft.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnRotateLeft.ImeMode");

        this.btnRotateLeft.Location = (System.Drawing.Point) resources.GetObject("btnRotateLeft.Location");

        this.btnRotateLeft.Name = "btnRotateLeft";

        this.btnRotateLeft.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnRotateLeft.RightToLeft");

        this.btnRotateLeft.Size = (System.Drawing.Size) resources.GetObject("btnRotateLeft.Size");

        this.btnRotateLeft.TabIndex = (int) resources.GetObject("btnRotateLeft.TabIndex");

        this.btnRotateLeft.Text = resources.GetString("btnRotateLeft.Text");

        this.btnRotateLeft.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRotateLeft.TextAlign");

        this.btnRotateLeft.Visible = (bool) resources.GetObject("btnRotateLeft.Visible");

		this.btnRotateLeft.Click += new EventHandler(btnRotateLeft_Click);

        //

        //grpCropping

        //

        this.grpCropping.AccessibleDescription = resources.GetString("grpCropping.AccessibleDescription");

        this.grpCropping.AccessibleName = resources.GetString("grpCropping.AccessibleName");

        this.grpCropping.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grpCropping.Anchor");

        this.grpCropping.BackgroundImage = (System.Drawing.Image) resources.GetObject("grpCropping.BackgroundImage");

        this.grpCropping.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnShowBox, this.btnUndo, this.btnCrop, this.txtHeight, this.txtWidth, this.lblYCoord, this.lblXCoord, this.txtYCoord, this.txtXCoord, this.lblHeight, this.lblWidth});

        this.grpCropping.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grpCropping.Dock");

        this.grpCropping.Enabled = (bool) resources.GetObject("grpCropping.Enabled");

        this.grpCropping.Font = (System.Drawing.Font) resources.GetObject("grpCropping.Font");

        this.grpCropping.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grpCropping.ImeMode");

        this.grpCropping.Location = (System.Drawing.Point) resources.GetObject("grpCropping.Location");

        this.grpCropping.Name = "grpCropping";

        this.grpCropping.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grpCropping.RightToLeft");

        this.grpCropping.Size = (System.Drawing.Size) resources.GetObject("grpCropping.Size");

        this.grpCropping.TabIndex = (int) resources.GetObject("grpCropping.TabIndex");

        this.grpCropping.TabStop = false;

        this.grpCropping.Text = resources.GetString("grpCropping.Text");

        this.grpCropping.Visible = (bool) resources.GetObject("grpCropping.Visible");

        //

        //btnShowBox

        //

        this.btnShowBox.AccessibleDescription = resources.GetString("btnShowBox.AccessibleDescription");

        this.btnShowBox.AccessibleName = resources.GetString("btnShowBox.AccessibleName");

        this.btnShowBox.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnShowBox.Anchor");

        this.btnShowBox.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnShowBox.BackgroundImage");

        this.btnShowBox.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnShowBox.Dock");

        this.btnShowBox.Enabled = (bool) resources.GetObject("btnShowBox.Enabled");

        this.btnShowBox.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnShowBox.FlatStyle");

        this.btnShowBox.Font = (System.Drawing.Font) resources.GetObject("btnShowBox.Font");

        this.btnShowBox.Image = (System.Drawing.Image) resources.GetObject("btnShowBox.Image");

        this.btnShowBox.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShowBox.ImageAlign");

        this.btnShowBox.ImageIndex = (int) resources.GetObject("btnShowBox.ImageIndex");

        this.btnShowBox.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnShowBox.ImeMode");

        this.btnShowBox.Location = (System.Drawing.Point) resources.GetObject("btnShowBox.Location");

        this.btnShowBox.Name = "btnShowBox";

        this.btnShowBox.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnShowBox.RightToLeft");

        this.btnShowBox.Size = (System.Drawing.Size) resources.GetObject("btnShowBox.Size");

        this.btnShowBox.TabIndex = (int) resources.GetObject("btnShowBox.TabIndex");

        this.btnShowBox.Text = resources.GetString("btnShowBox.Text");

        this.btnShowBox.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShowBox.TextAlign");

        this.btnShowBox.Visible = (bool) resources.GetObject("btnShowBox.Visible");

		this.btnShowBox.Click += new EventHandler(btnShowBox_Click);

        //

        //btnUndo

        //

        this.btnUndo.AccessibleDescription = resources.GetString("btnUndo.AccessibleDescription");

        this.btnUndo.AccessibleName = resources.GetString("btnUndo.AccessibleName");

        this.btnUndo.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnUndo.Anchor");

        this.btnUndo.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnUndo.BackgroundImage");

        this.btnUndo.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnUndo.Dock");

        this.btnUndo.Enabled = (bool) resources.GetObject("btnUndo.Enabled");

        this.btnUndo.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnUndo.FlatStyle");

        this.btnUndo.Font = (System.Drawing.Font) resources.GetObject("btnUndo.Font");

        this.btnUndo.Image = (System.Drawing.Image) resources.GetObject("btnUndo.Image");

        this.btnUndo.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnUndo.ImageAlign");

        this.btnUndo.ImageIndex = (int) resources.GetObject("btnUndo.ImageIndex");

        this.btnUndo.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnUndo.ImeMode");

        this.btnUndo.Location = (System.Drawing.Point) resources.GetObject("btnUndo.Location");

        this.btnUndo.Name = "btnUndo";

        this.btnUndo.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnUndo.RightToLeft");

        this.btnUndo.Size = (System.Drawing.Size) resources.GetObject("btnUndo.Size");

        this.btnUndo.TabIndex = (int) resources.GetObject("btnUndo.TabIndex");

        this.btnUndo.Text = resources.GetString("btnUndo.Text");

        this.btnUndo.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnUndo.TextAlign");

        this.btnUndo.Visible = (bool) resources.GetObject("btnUndo.Visible");

		this.btnUndo.Click += new EventHandler(btnUndo_Click);

        //

        //btnCrop

        //

        this.btnCrop.AccessibleDescription = resources.GetString("btnCrop.AccessibleDescription");

        this.btnCrop.AccessibleName = resources.GetString("btnCrop.AccessibleName");

        this.btnCrop.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCrop.Anchor");

        this.btnCrop.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCrop.BackgroundImage");

        this.btnCrop.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCrop.Dock");

        this.btnCrop.Enabled = (bool) resources.GetObject("btnCrop.Enabled");

        this.btnCrop.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCrop.FlatStyle");

        this.btnCrop.Font = (System.Drawing.Font) resources.GetObject("btnCrop.Font");

        this.btnCrop.Image = (System.Drawing.Image) resources.GetObject("btnCrop.Image");

        this.btnCrop.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCrop.ImageAlign");

        this.btnCrop.ImageIndex = (int) resources.GetObject("btnCrop.ImageIndex");

        this.btnCrop.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCrop.ImeMode");

        this.btnCrop.Location = (System.Drawing.Point) resources.GetObject("btnCrop.Location");

        this.btnCrop.Name = "btnCrop";

        this.btnCrop.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCrop.RightToLeft");

        this.btnCrop.Size = (System.Drawing.Size) resources.GetObject("btnCrop.Size");

        this.btnCrop.TabIndex = (int) resources.GetObject("btnCrop.TabIndex");

        this.btnCrop.Text = resources.GetString("btnCrop.Text");

        this.btnCrop.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCrop.TextAlign");

        this.btnCrop.Visible = (bool) resources.GetObject("btnCrop.Visible");

		this.btnCrop.Click += new EventHandler(btnCrop_Click);

        //

        //txtHeight

        //

        this.txtHeight.AccessibleDescription = resources.GetString("txtHeight.AccessibleDescription");

        this.txtHeight.AccessibleName = resources.GetString("txtHeight.AccessibleName");

        this.txtHeight.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtHeight.Anchor");

        this.txtHeight.AutoSize = (bool) resources.GetObject("txtHeight.AutoSize");

        this.txtHeight.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtHeight.BackgroundImage");

        this.txtHeight.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtHeight.Dock");

        this.txtHeight.Enabled = (bool) resources.GetObject("txtHeight.Enabled");

        this.txtHeight.Font = (System.Drawing.Font) resources.GetObject("txtHeight.Font");

        this.txtHeight.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtHeight.ImeMode");

        this.txtHeight.Location = (System.Drawing.Point) resources.GetObject("txtHeight.Location");

        this.txtHeight.MaxLength = (int) resources.GetObject("txtHeight.MaxLength");

        this.txtHeight.Multiline = (bool) resources.GetObject("txtHeight.Multiline");

        this.txtHeight.Name = "txtHeight";

        this.txtHeight.PasswordChar = (char) resources.GetObject("txtHeight.PasswordChar");

        this.txtHeight.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtHeight.RightToLeft");

        this.txtHeight.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtHeight.ScrollBars");

        this.txtHeight.Size = (System.Drawing.Size) resources.GetObject("txtHeight.Size");

        this.txtHeight.TabIndex = (int) resources.GetObject("txtHeight.TabIndex");

        this.txtHeight.Tag = "Height";

        this.txtHeight.Text = resources.GetString("txtHeight.Text");

        this.txtHeight.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtHeight.TextAlign");

        this.txtHeight.Visible = (bool) resources.GetObject("txtHeight.Visible");

        this.txtHeight.WordWrap = (bool) resources.GetObject("txtHeight.WordWrap");

        //

        //txtWidth

        //

        this.txtWidth.AccessibleDescription = resources.GetString("txtWidth.AccessibleDescription");

        this.txtWidth.AccessibleName = resources.GetString("txtWidth.AccessibleName");

        this.txtWidth.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtWidth.Anchor");

        this.txtWidth.AutoSize = (bool) resources.GetObject("txtWidth.AutoSize");

        this.txtWidth.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtWidth.BackgroundImage");

        this.txtWidth.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtWidth.Dock");

        this.txtWidth.Enabled = (bool) resources.GetObject("txtWidth.Enabled");

        this.txtWidth.Font = (System.Drawing.Font) resources.GetObject("txtWidth.Font");

        this.txtWidth.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtWidth.ImeMode");

        this.txtWidth.Location = (System.Drawing.Point) resources.GetObject("txtWidth.Location");

        this.txtWidth.MaxLength = (int) resources.GetObject("txtWidth.MaxLength");

        this.txtWidth.Multiline = (bool) resources.GetObject("txtWidth.Multiline");

        this.txtWidth.Name = "txtWidth";

        this.txtWidth.PasswordChar = (char) resources.GetObject("txtWidth.PasswordChar");

        this.txtWidth.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtWidth.RightToLeft");

        this.txtWidth.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtWidth.ScrollBars");

        this.txtWidth.Size = (System.Drawing.Size) resources.GetObject("txtWidth.Size");

        this.txtWidth.TabIndex = (int) resources.GetObject("txtWidth.TabIndex");

        this.txtWidth.Tag = "Width";

        this.txtWidth.Text = resources.GetString("txtWidth.Text");

        this.txtWidth.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtWidth.TextAlign");

        this.txtWidth.Visible = (bool) resources.GetObject("txtWidth.Visible");

        this.txtWidth.WordWrap = (bool) resources.GetObject("txtWidth.WordWrap");

        //

        //lblYCoord

        //

        this.lblYCoord.AccessibleDescription = resources.GetString("lblYCoord.AccessibleDescription");

        this.lblYCoord.AccessibleName = resources.GetString("lblYCoord.AccessibleName");

        this.lblYCoord.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblYCoord.Anchor");

        this.lblYCoord.AutoSize = (bool) resources.GetObject("lblYCoord.AutoSize");

        this.lblYCoord.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblYCoord.Dock");

        this.lblYCoord.Enabled = (bool) resources.GetObject("lblYCoord.Enabled");

        this.lblYCoord.Font = (System.Drawing.Font) resources.GetObject("lblYCoord.Font");

        this.lblYCoord.Image = (System.Drawing.Image) resources.GetObject("lblYCoord.Image");

        this.lblYCoord.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblYCoord.ImageAlign");

        this.lblYCoord.ImageIndex = (int) resources.GetObject("lblYCoord.ImageIndex");

        this.lblYCoord.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblYCoord.ImeMode");

        this.lblYCoord.Location = (System.Drawing.Point) resources.GetObject("lblYCoord.Location");

        this.lblYCoord.Name = "lblYCoord";

        this.lblYCoord.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblYCoord.RightToLeft");

        this.lblYCoord.Size = (System.Drawing.Size) resources.GetObject("lblYCoord.Size");

        this.lblYCoord.TabIndex = (int) resources.GetObject("lblYCoord.TabIndex");

        this.lblYCoord.Text = resources.GetString("lblYCoord.Text");

        this.lblYCoord.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblYCoord.TextAlign");

        this.lblYCoord.Visible = (bool) resources.GetObject("lblYCoord.Visible");

        //

        //lblXCoord

        //

        this.lblXCoord.AccessibleDescription = resources.GetString("lblXCoord.AccessibleDescription");

        this.lblXCoord.AccessibleName = resources.GetString("lblXCoord.AccessibleName");

        this.lblXCoord.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblXCoord.Anchor");

        this.lblXCoord.AutoSize = (bool) resources.GetObject("lblXCoord.AutoSize");

        this.lblXCoord.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblXCoord.Dock");

        this.lblXCoord.Enabled = (bool) resources.GetObject("lblXCoord.Enabled");

        this.lblXCoord.Font = (System.Drawing.Font) resources.GetObject("lblXCoord.Font");

        this.lblXCoord.Image = (System.Drawing.Image) resources.GetObject("lblXCoord.Image");

        this.lblXCoord.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblXCoord.ImageAlign");

        this.lblXCoord.ImageIndex = (int) resources.GetObject("lblXCoord.ImageIndex");

        this.lblXCoord.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblXCoord.ImeMode");

        this.lblXCoord.Location = (System.Drawing.Point) resources.GetObject("lblXCoord.Location");

        this.lblXCoord.Name = "lblXCoord";

        this.lblXCoord.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblXCoord.RightToLeft");

        this.lblXCoord.Size = (System.Drawing.Size) resources.GetObject("lblXCoord.Size");

        this.lblXCoord.TabIndex = (int) resources.GetObject("lblXCoord.TabIndex");

        this.lblXCoord.Text = resources.GetString("lblXCoord.Text");

        this.lblXCoord.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblXCoord.TextAlign");

        this.lblXCoord.Visible = (bool) resources.GetObject("lblXCoord.Visible");

        //

        //txtYCoord

        //

        this.txtYCoord.AccessibleDescription = resources.GetString("txtYCoord.AccessibleDescription");

        this.txtYCoord.AccessibleName = resources.GetString("txtYCoord.AccessibleName");

        this.txtYCoord.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtYCoord.Anchor");

        this.txtYCoord.AutoSize = (bool) resources.GetObject("txtYCoord.AutoSize");

        this.txtYCoord.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtYCoord.BackgroundImage");

        this.txtYCoord.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtYCoord.Dock");

        this.txtYCoord.Enabled = (bool) resources.GetObject("txtYCoord.Enabled");

        this.txtYCoord.Font = (System.Drawing.Font) resources.GetObject("txtYCoord.Font");

        this.txtYCoord.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtYCoord.ImeMode");

        this.txtYCoord.Location = (System.Drawing.Point) resources.GetObject("txtYCoord.Location");

        this.txtYCoord.MaxLength = (int) resources.GetObject("txtYCoord.MaxLength");

        this.txtYCoord.Multiline = (bool) resources.GetObject("txtYCoord.Multiline");

        this.txtYCoord.Name = "txtYCoord";

        this.txtYCoord.PasswordChar = (char) resources.GetObject("txtYCoord.PasswordChar");

        this.txtYCoord.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtYCoord.RightToLeft");

        this.txtYCoord.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtYCoord.ScrollBars");

        this.txtYCoord.Size = (System.Drawing.Size) resources.GetObject("txtYCoord.Size");

        this.txtYCoord.TabIndex = (int) resources.GetObject("txtYCoord.TabIndex");

        this.txtYCoord.Tag = "The Y Coordinate";

        this.txtYCoord.Text = resources.GetString("txtYCoord.Text");

        this.txtYCoord.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtYCoord.TextAlign");

        this.txtYCoord.Visible = (bool) resources.GetObject("txtYCoord.Visible");

        this.txtYCoord.WordWrap = (bool) resources.GetObject("txtYCoord.WordWrap");

        //

        //txtXCoord

        //

        this.txtXCoord.AccessibleDescription = resources.GetString("txtXCoord.AccessibleDescription");

        this.txtXCoord.AccessibleName = resources.GetString("txtXCoord.AccessibleName");

        this.txtXCoord.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtXCoord.Anchor");

        this.txtXCoord.AutoSize = (bool) resources.GetObject("txtXCoord.AutoSize");

        this.txtXCoord.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtXCoord.BackgroundImage");

        this.txtXCoord.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtXCoord.Dock");

        this.txtXCoord.Enabled = (bool) resources.GetObject("txtXCoord.Enabled");

        this.txtXCoord.Font = (System.Drawing.Font) resources.GetObject("txtXCoord.Font");

        this.txtXCoord.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtXCoord.ImeMode");

        this.txtXCoord.Location = (System.Drawing.Point) resources.GetObject("txtXCoord.Location");

        this.txtXCoord.MaxLength = (int) resources.GetObject("txtXCoord.MaxLength");

        this.txtXCoord.Multiline = (bool) resources.GetObject("txtXCoord.Multiline");

        this.txtXCoord.Name = "txtXCoord";

        this.txtXCoord.PasswordChar = (char) resources.GetObject("txtXCoord.PasswordChar");

        this.txtXCoord.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtXCoord.RightToLeft");

        this.txtXCoord.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtXCoord.ScrollBars");

        this.txtXCoord.Size = (System.Drawing.Size) resources.GetObject("txtXCoord.Size");

        this.txtXCoord.TabIndex = (int) resources.GetObject("txtXCoord.TabIndex");

        this.txtXCoord.Tag = "The X Coordinate";

        this.txtXCoord.Text = resources.GetString("txtXCoord.Text");

        this.txtXCoord.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtXCoord.TextAlign");

        this.txtXCoord.Visible = (bool) resources.GetObject("txtXCoord.Visible");

        this.txtXCoord.WordWrap = (bool) resources.GetObject("txtXCoord.WordWrap");

        //

        //lblHeight

        //

        this.lblHeight.AccessibleDescription = resources.GetString("lblHeight.AccessibleDescription");

        this.lblHeight.AccessibleName = resources.GetString("lblHeight.AccessibleName");

        this.lblHeight.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblHeight.Anchor");

        this.lblHeight.AutoSize = (bool) resources.GetObject("lblHeight.AutoSize");

        this.lblHeight.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblHeight.Dock");

        this.lblHeight.Enabled = (bool) resources.GetObject("lblHeight.Enabled");

        this.lblHeight.Font = (System.Drawing.Font) resources.GetObject("lblHeight.Font");

        this.lblHeight.Image = (System.Drawing.Image) resources.GetObject("lblHeight.Image");

        this.lblHeight.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblHeight.ImageAlign");

        this.lblHeight.ImageIndex = (int) resources.GetObject("lblHeight.ImageIndex");

        this.lblHeight.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblHeight.ImeMode");

        this.lblHeight.Location = (System.Drawing.Point) resources.GetObject("lblHeight.Location");

        this.lblHeight.Name = "lblHeight";

        this.lblHeight.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblHeight.RightToLeft");

        this.lblHeight.Size = (System.Drawing.Size) resources.GetObject("lblHeight.Size");

        this.lblHeight.TabIndex = (int) resources.GetObject("lblHeight.TabIndex");

        this.lblHeight.Text = resources.GetString("lblHeight.Text");

        this.lblHeight.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblHeight.TextAlign");

        this.lblHeight.Visible = (bool) resources.GetObject("lblHeight.Visible");

        //

        //lblWidth

        //

        this.lblWidth.AccessibleDescription = resources.GetString("lblWidth.AccessibleDescription");

        this.lblWidth.AccessibleName = resources.GetString("lblWidth.AccessibleName");

        this.lblWidth.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblWidth.Anchor");

        this.lblWidth.AutoSize = (bool) resources.GetObject("lblWidth.AutoSize");

        this.lblWidth.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblWidth.Dock");

        this.lblWidth.Enabled = (bool) resources.GetObject("lblWidth.Enabled");

        this.lblWidth.Font = (System.Drawing.Font) resources.GetObject("lblWidth.Font");

        this.lblWidth.Image = (System.Drawing.Image) resources.GetObject("lblWidth.Image");

        this.lblWidth.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblWidth.ImageAlign");

        this.lblWidth.ImageIndex = (int) resources.GetObject("lblWidth.ImageIndex");

        this.lblWidth.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblWidth.ImeMode");

        this.lblWidth.Location = (System.Drawing.Point) resources.GetObject("lblWidth.Location");

        this.lblWidth.Name = "lblWidth";

        this.lblWidth.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblWidth.RightToLeft");

        this.lblWidth.Size = (System.Drawing.Size) resources.GetObject("lblWidth.Size");

        this.lblWidth.TabIndex = (int) resources.GetObject("lblWidth.TabIndex");

        this.lblWidth.Text = resources.GetString("lblWidth.Text");

        this.lblWidth.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblWidth.TextAlign");

        this.lblWidth.Visible = (bool) resources.GetObject("lblWidth.Visible");

        //

        //btnRotateRight

        //

        this.btnRotateRight.AccessibleDescription = resources.GetString("btnRotateRight.AccessibleDescription");

        this.btnRotateRight.AccessibleName = resources.GetString("btnRotateRight.AccessibleName");

        this.btnRotateRight.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnRotateRight.Anchor");

        this.btnRotateRight.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnRotateRight.BackgroundImage");

        this.btnRotateRight.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnRotateRight.Dock");

        this.btnRotateRight.Enabled = (bool) resources.GetObject("btnRotateRight.Enabled");

        this.btnRotateRight.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnRotateRight.FlatStyle");

        this.btnRotateRight.Font = (System.Drawing.Font) resources.GetObject("btnRotateRight.Font");

        this.btnRotateRight.Image = (System.Drawing.Image) resources.GetObject("btnRotateRight.Image");

        this.btnRotateRight.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRotateRight.ImageAlign");

        this.btnRotateRight.ImageIndex = (int) resources.GetObject("btnRotateRight.ImageIndex");

        this.btnRotateRight.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnRotateRight.ImeMode");

        this.btnRotateRight.Location = (System.Drawing.Point) resources.GetObject("btnRotateRight.Location");

        this.btnRotateRight.Name = "btnRotateRight";

        this.btnRotateRight.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnRotateRight.RightToLeft");

        this.btnRotateRight.Size = (System.Drawing.Size) resources.GetObject("btnRotateRight.Size");

        this.btnRotateRight.TabIndex = (int) resources.GetObject("btnRotateRight.TabIndex");

        this.btnRotateRight.Text = resources.GetString("btnRotateRight.Text");

        this.btnRotateRight.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRotateRight.TextAlign");

        this.btnRotateRight.Visible = (bool) resources.GetObject("btnRotateRight.Visible");

		this.btnRotateRight.Click += new EventHandler(btnRotateRight_Click);

        //

        //chkThumbnail

        //

        this.chkThumbnail.AccessibleDescription = resources.GetString("chkThumbnail.AccessibleDescription");

        this.chkThumbnail.AccessibleName = resources.GetString("chkThumbnail.AccessibleName");

        this.chkThumbnail.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkThumbnail.Anchor");

        this.chkThumbnail.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkThumbnail.Appearance");

        this.chkThumbnail.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkThumbnail.BackgroundImage");

        this.chkThumbnail.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkThumbnail.CheckAlign");

        this.chkThumbnail.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkThumbnail.Dock");

        this.chkThumbnail.Enabled = (bool) resources.GetObject("chkThumbnail.Enabled");

        this.chkThumbnail.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkThumbnail.FlatStyle");

        this.chkThumbnail.Font = (System.Drawing.Font) resources.GetObject("chkThumbnail.Font");

        this.chkThumbnail.Image = (System.Drawing.Image) resources.GetObject("chkThumbnail.Image");

        this.chkThumbnail.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkThumbnail.ImageAlign");

        this.chkThumbnail.ImageIndex = (int) resources.GetObject("chkThumbnail.ImageIndex");

        this.chkThumbnail.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkThumbnail.ImeMode");

        this.chkThumbnail.Location = (System.Drawing.Point) resources.GetObject("chkThumbnail.Location");

        this.chkThumbnail.Name = "chkThumbnail";

        this.chkThumbnail.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkThumbnail.RightToLeft");

        this.chkThumbnail.Size = (System.Drawing.Size) resources.GetObject("chkThumbnail.Size");

        this.chkThumbnail.TabIndex = (int) resources.GetObject("chkThumbnail.TabIndex");

        this.chkThumbnail.Text = resources.GetString("chkThumbnail.Text");

        this.chkThumbnail.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkThumbnail.TextAlign");

        this.chkThumbnail.Visible = (bool) resources.GetObject("chkThumbnail.Visible");

        //

        //frmMain

        //

        this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");

        this.AccessibleName = resources.GetString("$this.AccessibleName");

        this.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("$this.Anchor");

        this.AutoScaleBaseSize = (System.Drawing.Size) resources.GetObject("$this.AutoScaleBaseSize");

        this.AutoScroll = (bool) resources.GetObject("$this.AutoScroll");

        this.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMargin");

        this.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMinSize");

        this.BackgroundImage = (System.Drawing.Image) resources.GetObject("$this.BackgroundImage");

        this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.chkThumbnail, this.btnRotateRight, this.grpCropping, this.btnRotateLeft, this.btnZoomOut, this.btnZoomIn, this.btnFit, this.btnSave, this.grpSizeMode, this.btnBrowse, this.picImage});

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

        this.grpSizeMode.ResumeLayout(false);

        this.grpCropping.ResumeLayout(false);

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

    const int PICTUREBOX_WIDTH  = 608;
    const int PICTUREBOX_HEIGHT  = 380;
    const int THUMBNAIL_MIN_SIZE  = 64;
    private bool IsFitForZoomIn  = false;
    private Image imgUndo ;
    private int intVal;

    // the Browse button click event, allowing the user to find an image, 
    // display it in a PictureBox control, and save the image to the database.
    private void btnBrowse_Click(object sender, System.EventArgs e) 
	{
        // Use an OpenFileDialog to enable the user to browse for an image to open
        // in the PictureBox. Provide a pipe-delimited set of file name-type pairs 
        // to filter what the user can load into the PictureBox. set {the FilterIndex 
        // to the default file type.

        odlgImage.InitialDirectory = "C:\\";
        odlgImage.Filter = "All Image Formats (*.bmp;*.jpg;*.jpeg;*.gif;*.tif)|" + 
            "*.bmp;*.jpg;*.jpeg;*.gif;*.tif|Bitmaps (*.bmp)|*.bmp|" + 
            "GIFs (*.gif)|*.gif|JPEGs (*.jpg)|*.jpg;*.jpeg|TIFs (*.tif)|*.tif";
        odlgImage.FilterIndex = 1;

        // When the user clicks the Open button (DialogResult.OK is the only option;
        // there is not DialogResult.Open), display the image centered in the 
        // PictureBox and display the full path of the image.

        if (odlgImage.ShowDialog() == DialogResult.OK) 
		{
            // Keep the original width and height of the PictureBox, regardless
            // of the image size being loaded.
            picImage.Width = PICTUREBOX_WIDTH;
            picImage.Height = PICTUREBOX_HEIGHT;
            picImage.Image = Image.FromFile(odlgImage.FileName);
            picImage.SizeMode = PictureBoxSizeMode.Normal;
            optNormal.Checked = true;
        }
    }

    // the Click event for the Fit button.
    private void btnFit_Click(object sender, System.EventArgs e) 
	{
        // SizeMode controls work well after an image has been fit.
        grpSizeMode.Enabled = true;
        // Reset the PictureBox dimensions. Fitting and zooming work best with
        // StretchImage SizeMode.
        picImage.Width = PICTUREBOX_WIDTH;
        picImage.Height = PICTUREBOX_HEIGHT;
        picImage.SizeMode = PictureBoxSizeMode.StretchImage;

        // Update the UI to reflect the SizeMode change.
        optStretchImage.Checked = true;
        Fit();
    }

    // the Click event of the Crop button.

    private void btnCrop_Click(object sender, System.EventArgs e) 
	{
        if (IsValidCropValues())
		{
            // Initialize the variable that holds a copy of the bitmap before 
            // cropping, so the crop can be undone.
            imgUndo = picImage.Image;
            btnUndo.Enabled = true;

            // Create a rectangle defined by the user's X,Y coordinates relative
            // to the upper left corner of the PictureBox, and the desired width
            // and length.
            Rectangle recSource = new Rectangle(Convert.ToInt32(txtXCoord.Text), Convert.ToInt32(txtYCoord.Text), Convert.ToInt32(txtWidth.Text), Convert.ToInt32(txtHeight.Text));

            // Create a new, blank Bitmap on which you will draw the cropped 
            // image. Note: It is worth mentioning here a pitfall to avoid. You might
            // be led to think that the process should involve creating a Graphics
            // object off the PictureBox (! a new Bitmap) and then drawing the
            // cropped image onto the PictureBox after clearing it, such:
            //
            //   grPicImage Graphics = picImage.CreateGraphics
            //   grPicImage.Clear(picImage.BackColor)
            //   grPicImage.DrawImage(picImage.Image, 0, 0, recSource, _
            //        GraphicsUnit.Pixel)
            //
            // This will appear to work. However, soon you use any of the other
            // controls it will become apparent that the PictureBox image is still 
            // set to the original image, not the cropped image.

            Bitmap bmpCropped = new Bitmap(Convert.ToInt32(txtWidth.Text), Convert.ToInt32(txtHeight.Text));
            // Get a Graphics object from the Bitmap for drawing.
            Graphics grBitmap = Graphics.FromImage(bmpCropped);
            // Draw the image on the Bitmap anchored at the upper left corner.
            grBitmap.DrawImage(picImage.Image, 0, 0, recSource, GraphicsUnit.Pixel);
            // Set the PictureBox image to the new cropped image.
            picImage.Image = bmpCropped;
        }
    }

    // the Click event of the Rotate Left button.
    private void btnRotateLeft_Click(object sender, System.EventArgs e) 
	{
        // Rotating 270 degrees is equivalent to rotating -90 degrees.
        picImage.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
        picImage.Refresh();
    }

    // the Click event of the Rotate Right button.
    private void btnRotateRight_Click(object sender, System.EventArgs e) 
	{
        picImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
        picImage.Refresh();
    }

    // the Click event for the Save button, which allows the user to save
    // the image displayed in the PictureBox to a file.
    private void btnSave_Click(object sender, System.EventArgs e)
	{
        sdlgImage.InitialDirectory = "C:\\";
        sdlgImage.FileName = "myimage";
        sdlgImage.Filter = "Bitmap (*.bmp)|*.bmp|GIF (*.gif)|*.gif|" +
            "JPEG (*.jpg)|*.jpg;*.jpeg|TIF (*.tif)|*.tif";
        sdlgImage.FilterIndex = 3;

        if (sdlgImage.ShowDialog() == DialogResult.OK )
		{
            string strMsg ;
            try {
				if (chkThumbnail.Checked) 
				{
					// Save image a Thumbnail.
					double ratio = CalculateAspectRatioAndSetDimensions();
					int intThumbWidth = THUMBNAIL_MIN_SIZE;
					int intThumbHeight = THUMBNAIL_MIN_SIZE;
					Image imgSource = picImage.Image;
					Image imgThumbnail;

					if (picImage.Image.Width > picImage.Image.Height) 
					{
						intThumbWidth = Convert.ToInt32(Convert.ToDouble(intThumbWidth * ratio));
						imgThumbnail = imgSource.GetThumbnailImage(intThumbWidth, intThumbHeight, null, IntPtr.Zero);
					}
					else 
					{
						intThumbHeight = Convert.ToInt32(Convert.ToDouble(intThumbHeight * ratio));
						imgThumbnail = imgSource.GetThumbnailImage(intThumbWidth,
							intThumbHeight, null, IntPtr.Zero);
					}
					imgThumbnail.Save(sdlgImage.FileName, GetImageFormat());
					strMsg = "Image successfully saved thumbnail to " + sdlgImage.FileName;
				}
				else 
				{
					// Save the image to the file name specified in the SaveFileDialog.
					// Get the image format based on the FilterIndex set above.
					picImage.Image.Save(sdlgImage.FileName, GetImageFormat());
					strMsg = "Image successfully saved to " + sdlgImage.FileName;
				}
                MessageBox.Show("Image successfully saved to " + 
                    sdlgImage.FileName, this.Text, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
			catch(Exception exp)
			{
                MessageBox.Show("The following error occurred while trying to " + 
                    "save the image: " + exp.Message, this.Text,
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // the Click event of the Show button. Displays the cropping rectangle.
    private void btnShowBox_Click(object sender, System.EventArgs e) 
	{
        if (IsValidCropValues())
		{
            // Call Refresh to erase the rectangle, if one already exists.
            picImage.Refresh();
            // Draw a red rectangle to show where the image will be cropped.
            Rectangle recCropBox = new Rectangle(Convert.ToInt32(txtXCoord.Text), 
                Convert.ToInt32(txtYCoord.Text), Convert.ToInt32(txtWidth.Text), Convert.ToInt32(txtHeight.Text));
            picImage.CreateGraphics().DrawRectangle(Pens.Red, recCropBox);
        }
    }

    // the Click event of the Undo button. (For use with cropping.)
    private void btnUndo_Click(object sender, System.EventArgs e) 
	{
        picImage.Image = imgUndo;
        picImage.Refresh();
        // Disable the button until the Crop button is clicked again.
        btnUndo.Enabled = false;
    }

    // the Click event for the Zoom In button.
    private void btnZoomIn_Click(object sender, System.EventArgs e) 
	{
        // When zooming in or out the SizeMode controls are disabled or the zooming
        // doesn't work anticipated. This check ensures that the initial Zoom in 
        // transition is smooth. Without this, if the SizeMode = something other
        // than AutoSize, the image can appear to get smaller on the first click, 
        // and then begin zooming in, which is not expected behavior.
        if (grpSizeMode.Enabled)
		{
            picImage.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        // Set UI and UI flags.
        grpSizeMode.Enabled = false;
        btnFit.Enabled = true;
        IsFitForZoomIn = true;
        // StretchMode works best for zooming. When Zooming In, the SizeMode should 
        // be set prior to calling Fit(). The reason for this becomes apparent only
        // when loading images that are smaller than the PictureBox dimensions.
        picImage.SizeMode = PictureBoxSizeMode.StretchImage;
        // Zoom works best if you first fit the image according to its true aspect 
        // ratio.
        Fit();
        // Make the PictureBox dimensions larger by 25% to effect the Zoom.
        picImage.Width = Convert.ToInt32(picImage.Width * 1.25);
        picImage.Height = Convert.ToInt32(picImage.Height * 1.25);
    }

    // the Click event for the Zoom Out button.
    private void btnZoomOut_Click(object sender, System.EventArgs e) 
	{
        // Set UI and UI flags.
        grpSizeMode.Enabled = false;
        btnFit.Enabled = true;
        // Zoom works best if you first fit the image according to its true aspect 
        // ratio.
        Fit();
        // StretchImage SizeMode works best for zooming.
        picImage.SizeMode = PictureBoxSizeMode.StretchImage;
        // Make the PictureBox dimensions smaller by 25% to effect the Zoom.
        picImage.Width = Convert.ToInt32(picImage.Width / 1.25);
        picImage.Height = Convert.ToInt32(picImage.Height / 1.25);
    }

    // the CheckedChanged event for the group of RadioButton controls, 
    // which causes the PictureBox.SizeMode property to change in response to
    // RadioButton selection.
    private void SizeModeRadioButtons_CheckedChanged(object sender, System.EventArgs e) 
	{
       RadioButton opt = (RadioButton) sender;
		PictureBoxSizeMode sm =PictureBoxSizeMode.Normal;
		// Each RadioButton stores the value of the PictureBoxSizeMode enum in its 
        // Tag property. 
		
			
		switch((string) opt.Tag)
		{
			case "0":
				sm = PictureBoxSizeMode.Normal;
				break;
			case "1":
				sm = PictureBoxSizeMode.StretchImage;
				break;
			case "2":
				sm = PictureBoxSizeMode.AutoSize;
				break;
			case "3":
				sm = PictureBoxSizeMode.CenterImage;
				break;
		}
       //PictureBoxSizeMode sm = (PictureBoxSizeMode) opt.Tag;
		  

        if (opt.Checked)
		{
            picImage.SizeMode = sm;
            // You must reset the PictureBox to its original size if AutoSize has 
            // been set. It will not automatically return to the size set in the 
            // Designer.
			if (sm == PictureBoxSizeMode.AutoSize)
			{
				btnFit.Enabled = false;
			}
			else 
			{
				btnFit.Enabled = true;
				picImage.Width = PICTUREBOX_WIDTH;
				picImage.Height = PICTUREBOX_HEIGHT;
			}
        }
    }

    // This method makes the image fit properly in the PictureBox. You might think 
    // that the AutoSize SizeMode enum would make the image appear in the PictureBox 
    // according to its true aspect ratio within the fixed bounds of the PictureBox.
    // However, it merely expands or shrinks the PictureBox.
    private void Fit()
	{
        // if Fit was called by the Zoom In button, then center the image. This is
        // only needed when working with images that are smaller than the PictureBox.
        // Feel free to uncomment the line that sets the SizeMode and then see how
        // it causes Zoom In for small images to show unexpected behavior.

        if ((picImage.Image.Width < picImage.Width) && 
            (picImage.Image.Height < picImage.Height))
		{
            if (! IsFitForZoomIn)
			{
                picImage.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
        CalculateAspectRatioAndSetDimensions();
    }

    // Calculates and returns the image's aspect ratio, and sets 
    // its proper dimensions. This is used for Fit() and for saving thumbnails
    // of images.
    private double CalculateAspectRatioAndSetDimensions()
	{
        // Calculate the proper aspect ratio and set the image's dimensions.
        double ratio ;

		if (picImage.Image.Width > picImage.Image.Height)
		{
			ratio = picImage.Image.Width / picImage.Image.Height;
			picImage.Height = Convert.ToInt32(Convert.ToDouble(picImage.Width) / ratio);
		}
		else 
		{
			ratio = picImage.Image.Height / picImage.Image.Width;
			picImage.Width = Convert.ToInt32(Convert.ToDouble(picImage.Height) / ratio);
		}
        return ratio;
    }

    // Sets the proper image format for saving images by referencing the Filter
    // index of the SaveFileDialog.
    private ImageFormat GetImageFormat()
	{
		switch( sdlgImage.FilterIndex)
		{
			case 1:
				return ImageFormat.Bmp;
			case 2:
				return ImageFormat.Jpeg;
			case 3:
				return ImageFormat.Gif;
			default: 
			{
				return ImageFormat.Tiff;
			}
		}
    }

    // Validates the data entered by the user in the Cropping TextBox controls.
    private bool IsValidCropValues()
	{
        // Loop through all the TextBox controls and perform the validation.
        // This allows the same routine to be used by all four controls.
     
        foreach(Object objControl in grpCropping.Controls)
		{
            if (objControl.GetType().ToString() == "System.Windows.Forms.TextBox")
			{
                TextBox txt = (TextBox) objControl;
                string ValidationMsg = txt.Tag.ToString() + " must be a positive integer";

				if ((txt.Name == "txtXCoord") || (txt.Name == "txtYCoord"))
				{
					ValidationMsg += " or zero.";
				}
				else 
				{
					ValidationMsg += ".";
				}
                if (txt.Text.Trim() == "")
				{
                    MessageBox.Show(ValidationMsg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt.SelectAll();
                    txt.Focus();
                    return false;
                }
				if (Convert.ToBoolean(Int32.Parse(txt.Text.Trim()))) 
				{
					MessageBox.Show(ValidationMsg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					txt.SelectAll();
					txt.Focus();
					return false;
				}
				else 
				{
					try 
					{
						intVal = Convert.ToInt32(txt.Text.Trim());
						if ((txt.Name == "txtXCoord") || (txt.Name == "txtYCoord")) 
						{
							if (intVal < 0) 
							{
								MessageBox.Show(ValidationMsg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
								txt.SelectAll();
								txt.Focus();
								return false;
							}
						} 
						else if ( intVal <= 0) 
						{
							MessageBox.Show(ValidationMsg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
							txt.SelectAll();
							txt.Focus();
							return false;
						}
					} 
					catch(Exception Exp)
					{
						MessageBox.Show("Value must be a positive " +
							"integer.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
						txt.SelectAll();
						txt.Focus();
						return false;
					}
				}
        }
    }
    return true;
    }
}

