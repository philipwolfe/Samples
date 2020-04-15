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
using System.Collections;


public class frmMain : System.Windows.Forms.Form 
{

    protected const string CONNECTION_ERROR_MSG = "To run this sample, you must have SQL " + 
    "or MSDE with the Northwind database installed.  For " + 
    "instructions on installing MSDE, view the ReadMe file.";

    protected const string MSDE_CONNECTION_STRING = "Server=(local)\\NetSDK;" +
        "DataBase=Northwind;" + 
        "Integrated Security=SSPI";

    protected const string SQL_CONNECTION_STRING = "Server=localhost;" + 
        "DataBase=Northwind;" + 
        "Integrated Security=SSPI";

    //private ArrayList arlProducts ;

    private DataSet dsProducts ;

    private bool FormHasLoaded  = false;

    private SqlDataReader sdrProducts ;
	internal System.Windows.Forms.TextBox textBox1;

    private string strConn ;

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

    private System.Windows.Forms.TabControl TabControl1;

    private System.Windows.Forms.TabPage TabPage1;

    private System.Windows.Forms.TabPage TabPage2;

    private System.Windows.Forms.Label lblSelected;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.TextBox txtnewOption;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.RadioButton optDataSet;

    private System.Windows.Forms.RadioButton optDataReader;

    private System.Windows.Forms.ComboBox cboProducts;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.TextBox txtChecked;

    private System.Windows.Forms.CheckedListBox clstProducts;

    private System.Windows.Forms.Button btnBindComboBox;

    private System.Windows.Forms.Button btnShowSelectedItem;

    private System.Windows.Forms.Button btnShowCheckedItems;

    private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.btnShowSelectedItem = new System.Windows.Forms.Button();
		this.lblSelected = new System.Windows.Forms.Label();
		this.btnBindComboBox = new System.Windows.Forms.Button();
		this.Label3 = new System.Windows.Forms.Label();
		this.txtnewOption = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.optDataSet = new System.Windows.Forms.RadioButton();
		this.optDataReader = new System.Windows.Forms.RadioButton();
		this.cboProducts = new System.Windows.Forms.ComboBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.txtChecked = new System.Windows.Forms.TextBox();
		this.btnShowCheckedItems = new System.Windows.Forms.Button();
		this.clstProducts = new System.Windows.Forms.CheckedListBox();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.TabControl1.SuspendLayout();
		this.TabPage1.SuspendLayout();
		this.TabPage2.SuspendLayout();
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
		this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
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
		this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
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
		// 
		// TabPage1
		// 
		this.TabPage1.AccessibleDescription = resources.GetString("TabPage1.AccessibleDescription");
		this.TabPage1.AccessibleName = resources.GetString("TabPage1.AccessibleName");
		this.TabPage1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("TabPage1.Anchor")));
		this.TabPage1.AutoScroll = ((bool)(resources.GetObject("TabPage1.AutoScroll")));
		this.TabPage1.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("TabPage1.AutoScrollMargin")));
		this.TabPage1.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("TabPage1.AutoScrollMinSize")));
		this.TabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TabPage1.BackgroundImage")));
		this.TabPage1.Controls.Add(this.textBox1);
		this.TabPage1.Controls.Add(this.btnShowSelectedItem);
		this.TabPage1.Controls.Add(this.lblSelected);
		this.TabPage1.Controls.Add(this.btnBindComboBox);
		this.TabPage1.Controls.Add(this.Label3);
		this.TabPage1.Controls.Add(this.txtnewOption);
		this.TabPage1.Controls.Add(this.Label2);
		this.TabPage1.Controls.Add(this.optDataSet);
		this.TabPage1.Controls.Add(this.optDataReader);
		this.TabPage1.Controls.Add(this.cboProducts);
		this.TabPage1.Controls.Add(this.Label1);
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
		// btnShowSelectedItem
		// 
		this.btnShowSelectedItem.AccessibleDescription = resources.GetString("btnShowSelectedItem.AccessibleDescription");
		this.btnShowSelectedItem.AccessibleName = resources.GetString("btnShowSelectedItem.AccessibleName");
		this.btnShowSelectedItem.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnShowSelectedItem.Anchor")));
		this.btnShowSelectedItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowSelectedItem.BackgroundImage")));
		this.btnShowSelectedItem.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnShowSelectedItem.Dock")));
		this.btnShowSelectedItem.Enabled = ((bool)(resources.GetObject("btnShowSelectedItem.Enabled")));
		this.btnShowSelectedItem.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnShowSelectedItem.FlatStyle")));
		this.btnShowSelectedItem.Font = ((System.Drawing.Font)(resources.GetObject("btnShowSelectedItem.Font")));
		this.btnShowSelectedItem.Image = ((System.Drawing.Image)(resources.GetObject("btnShowSelectedItem.Image")));
		this.btnShowSelectedItem.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnShowSelectedItem.ImageAlign")));
		this.btnShowSelectedItem.ImageIndex = ((int)(resources.GetObject("btnShowSelectedItem.ImageIndex")));
		this.btnShowSelectedItem.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnShowSelectedItem.ImeMode")));
		this.btnShowSelectedItem.Location = ((System.Drawing.Point)(resources.GetObject("btnShowSelectedItem.Location")));
		this.btnShowSelectedItem.Name = "btnShowSelectedItem";
		this.btnShowSelectedItem.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnShowSelectedItem.RightToLeft")));
		this.btnShowSelectedItem.Size = ((System.Drawing.Size)(resources.GetObject("btnShowSelectedItem.Size")));
		this.btnShowSelectedItem.TabIndex = ((int)(resources.GetObject("btnShowSelectedItem.TabIndex")));
		this.btnShowSelectedItem.Text = resources.GetString("btnShowSelectedItem.Text");
		this.btnShowSelectedItem.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnShowSelectedItem.TextAlign")));
		this.btnShowSelectedItem.Visible = ((bool)(resources.GetObject("btnShowSelectedItem.Visible")));
		this.btnShowSelectedItem.Click += new System.EventHandler(this.btnShowSelectedItem_Click);
		// 
		// lblSelected
		// 
		this.lblSelected.AccessibleDescription = resources.GetString("lblSelected.AccessibleDescription");
		this.lblSelected.AccessibleName = resources.GetString("lblSelected.AccessibleName");
		this.lblSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblSelected.Anchor")));
		this.lblSelected.AutoSize = ((bool)(resources.GetObject("lblSelected.AutoSize")));
		this.lblSelected.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblSelected.Dock")));
		this.lblSelected.Enabled = ((bool)(resources.GetObject("lblSelected.Enabled")));
		this.lblSelected.Font = ((System.Drawing.Font)(resources.GetObject("lblSelected.Font")));
		this.lblSelected.Image = ((System.Drawing.Image)(resources.GetObject("lblSelected.Image")));
		this.lblSelected.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblSelected.ImageAlign")));
		this.lblSelected.ImageIndex = ((int)(resources.GetObject("lblSelected.ImageIndex")));
		this.lblSelected.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblSelected.ImeMode")));
		this.lblSelected.Location = ((System.Drawing.Point)(resources.GetObject("lblSelected.Location")));
		this.lblSelected.Name = "lblSelected";
		this.lblSelected.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblSelected.RightToLeft")));
		this.lblSelected.Size = ((System.Drawing.Size)(resources.GetObject("lblSelected.Size")));
		this.lblSelected.TabIndex = ((int)(resources.GetObject("lblSelected.TabIndex")));
		this.lblSelected.Text = resources.GetString("lblSelected.Text");
		this.lblSelected.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblSelected.TextAlign")));
		this.lblSelected.Visible = ((bool)(resources.GetObject("lblSelected.Visible")));
		// 
		// btnBindComboBox
		// 
		this.btnBindComboBox.AccessibleDescription = resources.GetString("btnBindComboBox.AccessibleDescription");
		this.btnBindComboBox.AccessibleName = resources.GetString("btnBindComboBox.AccessibleName");
		this.btnBindComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnBindComboBox.Anchor")));
		this.btnBindComboBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBindComboBox.BackgroundImage")));
		this.btnBindComboBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnBindComboBox.Dock")));
		this.btnBindComboBox.Enabled = ((bool)(resources.GetObject("btnBindComboBox.Enabled")));
		this.btnBindComboBox.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnBindComboBox.FlatStyle")));
		this.btnBindComboBox.Font = ((System.Drawing.Font)(resources.GetObject("btnBindComboBox.Font")));
		this.btnBindComboBox.Image = ((System.Drawing.Image)(resources.GetObject("btnBindComboBox.Image")));
		this.btnBindComboBox.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBindComboBox.ImageAlign")));
		this.btnBindComboBox.ImageIndex = ((int)(resources.GetObject("btnBindComboBox.ImageIndex")));
		this.btnBindComboBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnBindComboBox.ImeMode")));
		this.btnBindComboBox.Location = ((System.Drawing.Point)(resources.GetObject("btnBindComboBox.Location")));
		this.btnBindComboBox.Name = "btnBindComboBox";
		this.btnBindComboBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnBindComboBox.RightToLeft")));
		this.btnBindComboBox.Size = ((System.Drawing.Size)(resources.GetObject("btnBindComboBox.Size")));
		this.btnBindComboBox.TabIndex = ((int)(resources.GetObject("btnBindComboBox.TabIndex")));
		this.btnBindComboBox.Text = resources.GetString("btnBindComboBox.Text");
		this.btnBindComboBox.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBindComboBox.TextAlign")));
		this.btnBindComboBox.Visible = ((bool)(resources.GetObject("btnBindComboBox.Visible")));
		this.btnBindComboBox.Click += new System.EventHandler(this.btnBindComboBox_Click);
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
		// txtnewOption
		// 
		this.txtnewOption.AccessibleDescription = resources.GetString("txtnewOption.AccessibleDescription");
		this.txtnewOption.AccessibleName = resources.GetString("txtnewOption.AccessibleName");
		this.txtnewOption.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtnewOption.Anchor")));
		this.txtnewOption.AutoSize = ((bool)(resources.GetObject("txtnewOption.AutoSize")));
		this.txtnewOption.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtnewOption.BackgroundImage")));
		this.txtnewOption.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtnewOption.Dock")));
		this.txtnewOption.Enabled = ((bool)(resources.GetObject("txtnewOption.Enabled")));
		this.txtnewOption.Font = ((System.Drawing.Font)(resources.GetObject("txtnewOption.Font")));
		this.txtnewOption.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtnewOption.ImeMode")));
		this.txtnewOption.Location = ((System.Drawing.Point)(resources.GetObject("txtnewOption.Location")));
		this.txtnewOption.MaxLength = ((int)(resources.GetObject("txtnewOption.MaxLength")));
		this.txtnewOption.Multiline = ((bool)(resources.GetObject("txtnewOption.Multiline")));
		this.txtnewOption.Name = "txtnewOption";
		this.txtnewOption.PasswordChar = ((char)(resources.GetObject("txtnewOption.PasswordChar")));
		this.txtnewOption.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtnewOption.RightToLeft")));
		this.txtnewOption.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtnewOption.ScrollBars")));
		this.txtnewOption.Size = ((System.Drawing.Size)(resources.GetObject("txtnewOption.Size")));
		this.txtnewOption.TabIndex = ((int)(resources.GetObject("txtnewOption.TabIndex")));
		this.txtnewOption.Text = resources.GetString("txtnewOption.Text");
		this.txtnewOption.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtnewOption.TextAlign")));
		this.txtnewOption.Visible = ((bool)(resources.GetObject("txtnewOption.Visible")));
		this.txtnewOption.WordWrap = ((bool)(resources.GetObject("txtnewOption.WordWrap")));
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
		// optDataSet
		// 
		this.optDataSet.AccessibleDescription = resources.GetString("optDataSet.AccessibleDescription");
		this.optDataSet.AccessibleName = resources.GetString("optDataSet.AccessibleName");
		this.optDataSet.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("optDataSet.Anchor")));
		this.optDataSet.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("optDataSet.Appearance")));
		this.optDataSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("optDataSet.BackgroundImage")));
		this.optDataSet.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optDataSet.CheckAlign")));
		this.optDataSet.Checked = true;
		this.optDataSet.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("optDataSet.Dock")));
		this.optDataSet.Enabled = ((bool)(resources.GetObject("optDataSet.Enabled")));
		this.optDataSet.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("optDataSet.FlatStyle")));
		this.optDataSet.Font = ((System.Drawing.Font)(resources.GetObject("optDataSet.Font")));
		this.optDataSet.Image = ((System.Drawing.Image)(resources.GetObject("optDataSet.Image")));
		this.optDataSet.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optDataSet.ImageAlign")));
		this.optDataSet.ImageIndex = ((int)(resources.GetObject("optDataSet.ImageIndex")));
		this.optDataSet.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("optDataSet.ImeMode")));
		this.optDataSet.Location = ((System.Drawing.Point)(resources.GetObject("optDataSet.Location")));
		this.optDataSet.Name = "optDataSet";
		this.optDataSet.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("optDataSet.RightToLeft")));
		this.optDataSet.Size = ((System.Drawing.Size)(resources.GetObject("optDataSet.Size")));
		this.optDataSet.TabIndex = ((int)(resources.GetObject("optDataSet.TabIndex")));
		this.optDataSet.TabStop = true;
		this.optDataSet.Text = resources.GetString("optDataSet.Text");
		this.optDataSet.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optDataSet.TextAlign")));
		this.optDataSet.Visible = ((bool)(resources.GetObject("optDataSet.Visible")));
		// 
		// optDataReader
		// 
		this.optDataReader.AccessibleDescription = resources.GetString("optDataReader.AccessibleDescription");
		this.optDataReader.AccessibleName = resources.GetString("optDataReader.AccessibleName");
		this.optDataReader.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("optDataReader.Anchor")));
		this.optDataReader.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("optDataReader.Appearance")));
		this.optDataReader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("optDataReader.BackgroundImage")));
		this.optDataReader.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optDataReader.CheckAlign")));
		this.optDataReader.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("optDataReader.Dock")));
		this.optDataReader.Enabled = ((bool)(resources.GetObject("optDataReader.Enabled")));
		this.optDataReader.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("optDataReader.FlatStyle")));
		this.optDataReader.Font = ((System.Drawing.Font)(resources.GetObject("optDataReader.Font")));
		this.optDataReader.Image = ((System.Drawing.Image)(resources.GetObject("optDataReader.Image")));
		this.optDataReader.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optDataReader.ImageAlign")));
		this.optDataReader.ImageIndex = ((int)(resources.GetObject("optDataReader.ImageIndex")));
		this.optDataReader.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("optDataReader.ImeMode")));
		this.optDataReader.Location = ((System.Drawing.Point)(resources.GetObject("optDataReader.Location")));
		this.optDataReader.Name = "optDataReader";
		this.optDataReader.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("optDataReader.RightToLeft")));
		this.optDataReader.Size = ((System.Drawing.Size)(resources.GetObject("optDataReader.Size")));
		this.optDataReader.TabIndex = ((int)(resources.GetObject("optDataReader.TabIndex")));
		this.optDataReader.Text = resources.GetString("optDataReader.Text");
		this.optDataReader.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("optDataReader.TextAlign")));
		this.optDataReader.Visible = ((bool)(resources.GetObject("optDataReader.Visible")));
		// 
		// cboProducts
		// 
		this.cboProducts.AccessibleDescription = resources.GetString("cboProducts.AccessibleDescription");
		this.cboProducts.AccessibleName = resources.GetString("cboProducts.AccessibleName");
		this.cboProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cboProducts.Anchor")));
		this.cboProducts.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cboProducts.BackgroundImage")));
		this.cboProducts.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cboProducts.Dock")));
		this.cboProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboProducts.Enabled = ((bool)(resources.GetObject("cboProducts.Enabled")));
		this.cboProducts.Font = ((System.Drawing.Font)(resources.GetObject("cboProducts.Font")));
		this.cboProducts.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cboProducts.ImeMode")));
		this.cboProducts.IntegralHeight = ((bool)(resources.GetObject("cboProducts.IntegralHeight")));
		this.cboProducts.ItemHeight = ((int)(resources.GetObject("cboProducts.ItemHeight")));
		this.cboProducts.Location = ((System.Drawing.Point)(resources.GetObject("cboProducts.Location")));
		this.cboProducts.MaxDropDownItems = ((int)(resources.GetObject("cboProducts.MaxDropDownItems")));
		this.cboProducts.MaxLength = ((int)(resources.GetObject("cboProducts.MaxLength")));
		this.cboProducts.Name = "cboProducts";
		this.cboProducts.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cboProducts.RightToLeft")));
		this.cboProducts.Size = ((System.Drawing.Size)(resources.GetObject("cboProducts.Size")));
		this.cboProducts.TabIndex = ((int)(resources.GetObject("cboProducts.TabIndex")));
		this.cboProducts.Text = resources.GetString("cboProducts.Text");
		this.cboProducts.Visible = ((bool)(resources.GetObject("cboProducts.Visible")));
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
		// TabPage2
		// 
		this.TabPage2.AccessibleDescription = resources.GetString("TabPage2.AccessibleDescription");
		this.TabPage2.AccessibleName = resources.GetString("TabPage2.AccessibleName");
		this.TabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("TabPage2.Anchor")));
		this.TabPage2.AutoScroll = ((bool)(resources.GetObject("TabPage2.AutoScroll")));
		this.TabPage2.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("TabPage2.AutoScrollMargin")));
		this.TabPage2.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("TabPage2.AutoScrollMinSize")));
		this.TabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TabPage2.BackgroundImage")));
		this.TabPage2.Controls.Add(this.txtChecked);
		this.TabPage2.Controls.Add(this.btnShowCheckedItems);
		this.TabPage2.Controls.Add(this.clstProducts);
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
		// txtChecked
		// 
		this.txtChecked.AccessibleDescription = resources.GetString("txtChecked.AccessibleDescription");
		this.txtChecked.AccessibleName = resources.GetString("txtChecked.AccessibleName");
		this.txtChecked.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtChecked.Anchor")));
		this.txtChecked.AutoSize = ((bool)(resources.GetObject("txtChecked.AutoSize")));
		this.txtChecked.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtChecked.BackgroundImage")));
		this.txtChecked.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtChecked.Dock")));
		this.txtChecked.Enabled = ((bool)(resources.GetObject("txtChecked.Enabled")));
		this.txtChecked.Font = ((System.Drawing.Font)(resources.GetObject("txtChecked.Font")));
		this.txtChecked.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtChecked.ImeMode")));
		this.txtChecked.Location = ((System.Drawing.Point)(resources.GetObject("txtChecked.Location")));
		this.txtChecked.MaxLength = ((int)(resources.GetObject("txtChecked.MaxLength")));
		this.txtChecked.Multiline = ((bool)(resources.GetObject("txtChecked.Multiline")));
		this.txtChecked.Name = "txtChecked";
		this.txtChecked.PasswordChar = ((char)(resources.GetObject("txtChecked.PasswordChar")));
		this.txtChecked.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtChecked.RightToLeft")));
		this.txtChecked.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtChecked.ScrollBars")));
		this.txtChecked.Size = ((System.Drawing.Size)(resources.GetObject("txtChecked.Size")));
		this.txtChecked.TabIndex = ((int)(resources.GetObject("txtChecked.TabIndex")));
		this.txtChecked.Text = resources.GetString("txtChecked.Text");
		this.txtChecked.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtChecked.TextAlign")));
		this.txtChecked.Visible = ((bool)(resources.GetObject("txtChecked.Visible")));
		this.txtChecked.WordWrap = ((bool)(resources.GetObject("txtChecked.WordWrap")));
		// 
		// btnShowCheckedItems
		// 
		this.btnShowCheckedItems.AccessibleDescription = resources.GetString("btnShowCheckedItems.AccessibleDescription");
		this.btnShowCheckedItems.AccessibleName = resources.GetString("btnShowCheckedItems.AccessibleName");
		this.btnShowCheckedItems.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnShowCheckedItems.Anchor")));
		this.btnShowCheckedItems.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowCheckedItems.BackgroundImage")));
		this.btnShowCheckedItems.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnShowCheckedItems.Dock")));
		this.btnShowCheckedItems.Enabled = ((bool)(resources.GetObject("btnShowCheckedItems.Enabled")));
		this.btnShowCheckedItems.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnShowCheckedItems.FlatStyle")));
		this.btnShowCheckedItems.Font = ((System.Drawing.Font)(resources.GetObject("btnShowCheckedItems.Font")));
		this.btnShowCheckedItems.Image = ((System.Drawing.Image)(resources.GetObject("btnShowCheckedItems.Image")));
		this.btnShowCheckedItems.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnShowCheckedItems.ImageAlign")));
		this.btnShowCheckedItems.ImageIndex = ((int)(resources.GetObject("btnShowCheckedItems.ImageIndex")));
		this.btnShowCheckedItems.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnShowCheckedItems.ImeMode")));
		this.btnShowCheckedItems.Location = ((System.Drawing.Point)(resources.GetObject("btnShowCheckedItems.Location")));
		this.btnShowCheckedItems.Name = "btnShowCheckedItems";
		this.btnShowCheckedItems.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnShowCheckedItems.RightToLeft")));
		this.btnShowCheckedItems.Size = ((System.Drawing.Size)(resources.GetObject("btnShowCheckedItems.Size")));
		this.btnShowCheckedItems.TabIndex = ((int)(resources.GetObject("btnShowCheckedItems.TabIndex")));
		this.btnShowCheckedItems.Text = resources.GetString("btnShowCheckedItems.Text");
		this.btnShowCheckedItems.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnShowCheckedItems.TextAlign")));
		this.btnShowCheckedItems.Visible = ((bool)(resources.GetObject("btnShowCheckedItems.Visible")));
		this.btnShowCheckedItems.Click += new System.EventHandler(this.btnShowCheckedItems_Click);
		// 
		// clstProducts
		// 
		this.clstProducts.AccessibleDescription = resources.GetString("clstProducts.AccessibleDescription");
		this.clstProducts.AccessibleName = resources.GetString("clstProducts.AccessibleName");
		this.clstProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("clstProducts.Anchor")));
		this.clstProducts.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("clstProducts.BackgroundImage")));
		this.clstProducts.CheckOnClick = true;
		this.clstProducts.ColumnWidth = ((int)(resources.GetObject("clstProducts.ColumnWidth")));
		this.clstProducts.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("clstProducts.Dock")));
		this.clstProducts.Enabled = ((bool)(resources.GetObject("clstProducts.Enabled")));
		this.clstProducts.Font = ((System.Drawing.Font)(resources.GetObject("clstProducts.Font")));
		this.clstProducts.HorizontalExtent = ((int)(resources.GetObject("clstProducts.HorizontalExtent")));
		this.clstProducts.HorizontalScrollbar = ((bool)(resources.GetObject("clstProducts.HorizontalScrollbar")));
		this.clstProducts.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("clstProducts.ImeMode")));
		this.clstProducts.IntegralHeight = ((bool)(resources.GetObject("clstProducts.IntegralHeight")));
		this.clstProducts.Location = ((System.Drawing.Point)(resources.GetObject("clstProducts.Location")));
		this.clstProducts.MultiColumn = true;
		this.clstProducts.Name = "clstProducts";
		this.clstProducts.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("clstProducts.RightToLeft")));
		this.clstProducts.ScrollAlwaysVisible = ((bool)(resources.GetObject("clstProducts.ScrollAlwaysVisible")));
		this.clstProducts.Size = ((System.Drawing.Size)(resources.GetObject("clstProducts.Size")));
		this.clstProducts.TabIndex = ((int)(resources.GetObject("clstProducts.TabIndex")));
		this.clstProducts.Visible = ((bool)(resources.GetObject("clstProducts.Visible")));
		// 
		// textBox1
		// 
		this.textBox1.AccessibleDescription = resources.GetString("textBox1.AccessibleDescription");
		this.textBox1.AccessibleName = resources.GetString("textBox1.AccessibleName");
		this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("textBox1.Anchor")));
		this.textBox1.AutoSize = ((bool)(resources.GetObject("textBox1.AutoSize")));
		this.textBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("textBox1.BackgroundImage")));
		this.textBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("textBox1.Dock")));
		this.textBox1.Enabled = ((bool)(resources.GetObject("textBox1.Enabled")));
		this.textBox1.Font = ((System.Drawing.Font)(resources.GetObject("textBox1.Font")));
		this.textBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("textBox1.ImeMode")));
		this.textBox1.Location = ((System.Drawing.Point)(resources.GetObject("textBox1.Location")));
		this.textBox1.MaxLength = ((int)(resources.GetObject("textBox1.MaxLength")));
		this.textBox1.Multiline = ((bool)(resources.GetObject("textBox1.Multiline")));
		this.textBox1.Name = "textBox1";
		this.textBox1.PasswordChar = ((char)(resources.GetObject("textBox1.PasswordChar")));
		this.textBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("textBox1.RightToLeft")));
		this.textBox1.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("textBox1.ScrollBars")));
		this.textBox1.Size = ((System.Drawing.Size)(resources.GetObject("textBox1.Size")));
		this.textBox1.TabIndex = ((int)(resources.GetObject("textBox1.TabIndex")));
		this.textBox1.Text = resources.GetString("textBox1.Text");
		this.textBox1.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("textBox1.TextAlign")));
		this.textBox1.Visible = ((bool)(resources.GetObject("textBox1.Visible")));
		this.textBox1.WordWrap = ((bool)(resources.GetObject("textBox1.WordWrap")));
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
		this.TabControl1.ResumeLayout(false);
		this.TabPage1.ResumeLayout(false);
		this.TabPage2.ResumeLayout(false);
		this.ResumeLayout(false);
		this.Load +=new EventHandler(frmMain_Load);

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

    // This routine handles the "Bind ComboBox" button Click event.
    private void btnBindComboBox_Click(object sender, System.EventArgs e)
	{
        lblSelected.Text = string.Empty;
		if (optDataReader.Checked)
		{
			BindComboBoxUsingDataReader();
		}
		else 
		{
			BindComboBoxUsingDataSet();
		}
    }

    // This routine handles the "Show Checked Items" button Click event. It displays
    // a list of all the checked items in the CheckedListBox control.
    private void btnShowCheckedItems_Click(object sender, System.EventArgs e)
	{
        StringBuilder sb = new StringBuilder();

        // DataRowView is the Type of the objects stored in the CheckedItemCollection
        // object exposed by the CheckedItems property.
        //DataRowView drwvItem;

        // Make sure you access the CheckedItems property, not the SelectedItems 
        // property. The latter contains only up to one item, the SelectionMode
        // for a CheckedListBox can only be set to "One" or "None". "Selected" means
        // "highlighted", not "checked".

        foreach(DataRowView drwvItem in clstProducts.CheckedItems)
		{
            // Because the objects in the collection are of type DataRowView, you
            // can! access the Text and Value like you would with a ComboBox
            // (e.g., using .SelectedValue or .Text).
            sb.Append(drwvItem["Name"]);
            sb.Append(" (");
            sb.Append(drwvItem["ID"]);
            sb.Append("), ");
        }
        txtChecked.Text = sb.ToString();
    }

    // This routine handles the "Show Selected Item" button Click event. It displays
    // the index, text, and value of the selected item in the ComboBox control.
    private void btnShowSelectedItem_Click(object sender, System.EventArgs e)
	{
            // Notice that to show the text of the selected item you do not access the
            // SelectedText property (as you might think, because you accessed the
            // SelectedValue property). Rather, this property is only for highlighted
            // text when the DropDownStyle property of the ComboBox is not set to 
            // DropDownList (an uneditable mode). This seems unintuitive. However, it 
            // is consistent with the naming conventions of other controls with a 
            // SelectedText property (e.g., the TextBox).

            lblSelected.Text = "You selected option " + cboProducts.SelectedIndex.ToString() +
                ". Its value is " + cboProducts.SelectedValue.ToString() + " and its " + 
                "text is " + cboProducts.Text + ".";
    }

    // This routine handles the Form's Load event.
    private void frmMain_Load(object sender, System.EventArgs e) 
	{
        FormHasLoaded = true;
        BindComboBoxUsingDataSet();
        BindCheckedListBoxUsingDataSet();
    }

    // This subroutine is used within a While...End while iteration through the 
    // contents of a DataReader. It fills an ArrayList with instances of the custom
    // Product class, the property values of which are initialized with data
    // from the DataReader.

    private void AddItemToDataSource(ref ArrayList arl)
	{
            // The DataReader value in the first column is retrieved in its native 
            // datatype, which is the fastest way to retrieve data because it avoids
            // late binding. You will notice that all of the Get____ methods take
            // only the index an argument.
            //
            // For demonstration purposes, the second column is referenced by its 
            // column name and late binding is implicitly used because the data is
            // being retrieved an Object type and Tostring() invoked. In this case 
            // you can use either an index or a column name. Using an index iis faster 
            // a column name lookup does not have to take place.
            //
            // There is, however, a pitfall when only using ordinal values.
            // if the field order changes in the SQL SELECT statement, the 
            // data will be out of sync with the code. Using field names to
            // reference the data in the DataReader ensures that the data properly 
            // corresponds to the code (unless, of course, the field name is changed 
            // in the database or a SQL "AS" keyword is used to alias the column.
            //
            // For ProductName you could also use sdrProducts.GetString(1).
		
            arl.Add(new Product(sdrProducts.GetInt32(0), sdrProducts["ProductName"].ToString()));
    }

    // This routine binds the CheckedListBox to a DataSet. the code is identical 
    // to that for the ComboBox, only binding to a Dataset is demonstrated.

    private void BindCheckedListBoxUsingDataSet()
	{
        // See BindComboBoxUsingDataset for further comments.
		clstProducts.DisplayMember = "Name";
        clstProducts.ValueMember = "ID";

		if (txtnewOption.Text.Trim() != "")
		{
			string sNewOption = txtnewOption.Text;
		
			clstProducts.DataSource = UI.AddOption(dsProducts, clstProducts.DisplayMember,
				clstProducts.ValueMember, ref sNewOption, "0").Tables[0];
		}
		else 
		{
			clstProducts.DataSource = dsProducts.Tables[0];
		}
    }

    // This routine binds the ComboBox to an ArrayList filled by iterating 
    // through a SqlDataReader. See also the comments in the Helper.Product
    // class.

    private void BindComboBoxUsingDataReader()
	{
        strConn = SQL_CONNECTION_STRING;

        string strSQL  = "SELECT ProductID, ProductName " + 
            "FROM Products " + 
            "ORDER BY ProductName";

        SqlConnection scnnNorthwind = new SqlConnection(strConn);

        SqlCommand scmd = new SqlCommand(strSQL, scnnNorthwind);

        ArrayList arlProducts = new ArrayList();

        frmStatus frmStatusMessage = new frmStatus();

        try 
		{
            frmStatusMessage.Show("Connecting to SQL Server to load Products " + 
                "using a DataReader");

            // Demo purposes only: Wait 1 second so the user can see the status 
            // message and verify that the ComboBox is loading from a DataReader.

            System.Threading.Thread.Sleep(1000);
            scnnNorthwind.Open();
            sdrProducts = scmd.ExecuteReader(CommandBehavior.CloseConnection);

            // Iterate through the DataReader Items collection. The Read method
            // returns a bool value = true while there are more rows to read.

            while (sdrProducts.Read())
			{
                // Fill one of the objects that implements the IList interface
                // (in this case, an ArrayList) so that complex databinding can
                // be used.
                AddItemToDataSource(ref arlProducts);
            }

            cboProducts.ValueMember = "ID";
            cboProducts.DisplayMember = "Name";

			if (txtnewOption.Text.Trim() != "")
			{
				cboProducts.DataSource = UI.AddOption(arlProducts, new Product(0, txtnewOption.Text));
			}
			else 
			{
				cboProducts.DataSource = arlProducts;
			}
            // Close the DataReader and the status form.
            sdrProducts.Close();
            frmStatusMessage.Close();
       } 
		catch(SqlException expSql)
		{
            MessageBox.Show(expSql.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // This routine binds the ComboBox to a DataTable in a DataSet.
    private void BindComboBoxUsingDataSet()
	{
		
        strConn = SQL_CONNECTION_STRING;
        // Note: Column aliases are used so that the DisplayMember and
        // ValueMember names are the same for both the SqlDataReader example
        // and the Dataset example. if they are different a runtime error is
        // thrown when switching back and forth between the two types of 
        // databinding.

        string strSQL  = "SELECT ProductID ID, ProductName Name " + 
            "FROM Products " + 
            "ORDER BY ProductName";

        SqlConnection scnnNorthwind = new SqlConnection(strConn);
        SqlCommand scmd = new SqlCommand(strSQL, scnnNorthwind);
        SqlDataAdapter sda = new SqlDataAdapter(scmd);
        dsProducts = new DataSet();

        // Display a status message saying that we're attempting to connect.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

        frmStatus frmStatusMessage = new frmStatus();
        frmStatusMessage.Show("Connecting to SQL Server to load Products using a DataSet");

        // Attempt to connect to the local SQL server instance, or a local
        // MSDE installation.

        bool IsConnecting = true;

        while (IsConnecting)
		{
            try {
                // Bind the DataSet.
                sda.Fill(dsProducts);

                // Connection successful so break out of the while loop and close 
                // the status form.
                IsConnecting = false;

                // Wait 1 second so the user can see the status message.
                System.Threading.Thread.Sleep(1000);
                frmStatusMessage.Close();
           } 
			catch(SqlException expSql)
			{
                MessageBox.Show(expSql.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            cboProducts.DisplayMember = "Name";
            cboProducts.ValueMember = "ID";

            // Unlike the DropDownList WebControl, you have to access the 
            // DataSet's Tables collection to databind, even if there is only 
            // one DataTable in the DataSet.

		if (txtnewOption.Text.Trim() != "") 
		{
			string sNewOption = txtnewOption.Text;
			cboProducts.DataSource = UI.AddOption(dsProducts, cboProducts.DisplayMember,
				cboProducts.ValueMember, ref sNewOption, "0").Tables[0];
		}
		else 
		{
			cboProducts.DataSource = dsProducts.Tables[0];
		}

    }

}

