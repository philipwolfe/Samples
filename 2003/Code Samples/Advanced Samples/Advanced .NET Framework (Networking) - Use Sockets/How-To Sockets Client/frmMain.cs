//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.IO;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;

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

    private System.Windows.Forms.TextBox txtDisplay;

    private System.Windows.Forms.TextBox txtSend;

    private System.Windows.Forms.Button btnSend;

    private System.Windows.Forms.TabPage tpChatPage;

    private System.Windows.Forms.TabPage tpListUsers;

    private System.Windows.Forms.ListBox lstUsers;

    private System.Windows.Forms.Button btnListUsers;

    private System.Windows.Forms.Label lblInstructions;

    private System.Windows.Forms.Label Label1;

    private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.tpChatPage = new System.Windows.Forms.TabPage();
		this.lblInstructions = new System.Windows.Forms.Label();
		this.btnSend = new System.Windows.Forms.Button();
		this.txtSend = new System.Windows.Forms.TextBox();
		this.txtDisplay = new System.Windows.Forms.TextBox();
		this.tpListUsers = new System.Windows.Forms.TabPage();
		this.Label1 = new System.Windows.Forms.Label();
		this.btnListUsers = new System.Windows.Forms.Button();
		this.lstUsers = new System.Windows.Forms.ListBox();
		this.TabControl1.SuspendLayout();
		this.tpChatPage.SuspendLayout();
		this.tpListUsers.SuspendLayout();
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
		this.TabControl1.Controls.Add(this.tpChatPage);
		this.TabControl1.Controls.Add(this.tpListUsers);
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
		// tpChatPage
		// 
		this.tpChatPage.AccessibleDescription = resources.GetString("tpChatPage.AccessibleDescription");
		this.tpChatPage.AccessibleName = resources.GetString("tpChatPage.AccessibleName");
		this.tpChatPage.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tpChatPage.Anchor")));
		this.tpChatPage.AutoScroll = ((bool)(resources.GetObject("tpChatPage.AutoScroll")));
		this.tpChatPage.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("tpChatPage.AutoScrollMargin")));
		this.tpChatPage.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("tpChatPage.AutoScrollMinSize")));
		this.tpChatPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tpChatPage.BackgroundImage")));
		this.tpChatPage.Controls.Add(this.lblInstructions);
		this.tpChatPage.Controls.Add(this.btnSend);
		this.tpChatPage.Controls.Add(this.txtSend);
		this.tpChatPage.Controls.Add(this.txtDisplay);
		this.tpChatPage.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tpChatPage.Dock")));
		this.tpChatPage.Enabled = ((bool)(resources.GetObject("tpChatPage.Enabled")));
		this.tpChatPage.Font = ((System.Drawing.Font)(resources.GetObject("tpChatPage.Font")));
		this.tpChatPage.ImageIndex = ((int)(resources.GetObject("tpChatPage.ImageIndex")));
		this.tpChatPage.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tpChatPage.ImeMode")));
		this.tpChatPage.Location = ((System.Drawing.Point)(resources.GetObject("tpChatPage.Location")));
		this.tpChatPage.Name = "tpChatPage";
		this.tpChatPage.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tpChatPage.RightToLeft")));
		this.tpChatPage.Size = ((System.Drawing.Size)(resources.GetObject("tpChatPage.Size")));
		this.tpChatPage.TabIndex = ((int)(resources.GetObject("tpChatPage.TabIndex")));
		this.tpChatPage.Text = resources.GetString("tpChatPage.Text");
		this.tpChatPage.ToolTipText = resources.GetString("tpChatPage.ToolTipText");
		this.tpChatPage.Visible = ((bool)(resources.GetObject("tpChatPage.Visible")));
		// 
		// lblInstructions
		// 
		this.lblInstructions.AccessibleDescription = resources.GetString("lblInstructions.AccessibleDescription");
		this.lblInstructions.AccessibleName = resources.GetString("lblInstructions.AccessibleName");
		this.lblInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblInstructions.Anchor")));
		this.lblInstructions.AutoSize = ((bool)(resources.GetObject("lblInstructions.AutoSize")));
		this.lblInstructions.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblInstructions.Dock")));
		this.lblInstructions.Enabled = ((bool)(resources.GetObject("lblInstructions.Enabled")));
		this.lblInstructions.Font = ((System.Drawing.Font)(resources.GetObject("lblInstructions.Font")));
		this.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
		this.lblInstructions.Image = ((System.Drawing.Image)(resources.GetObject("lblInstructions.Image")));
		this.lblInstructions.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblInstructions.ImageAlign")));
		this.lblInstructions.ImageIndex = ((int)(resources.GetObject("lblInstructions.ImageIndex")));
		this.lblInstructions.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblInstructions.ImeMode")));
		this.lblInstructions.Location = ((System.Drawing.Point)(resources.GetObject("lblInstructions.Location")));
		this.lblInstructions.Name = "lblInstructions";
		this.lblInstructions.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblInstructions.RightToLeft")));
		this.lblInstructions.Size = ((System.Drawing.Size)(resources.GetObject("lblInstructions.Size")));
		this.lblInstructions.TabIndex = ((int)(resources.GetObject("lblInstructions.TabIndex")));
		this.lblInstructions.Text = resources.GetString("lblInstructions.Text");
		this.lblInstructions.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblInstructions.TextAlign")));
		this.lblInstructions.Visible = ((bool)(resources.GetObject("lblInstructions.Visible")));
		// 
		// btnSend
		// 
		this.btnSend.AccessibleDescription = resources.GetString("btnSend.AccessibleDescription");
		this.btnSend.AccessibleName = resources.GetString("btnSend.AccessibleName");
		this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnSend.Anchor")));
		this.btnSend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSend.BackgroundImage")));
		this.btnSend.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnSend.Dock")));
		this.btnSend.Enabled = ((bool)(resources.GetObject("btnSend.Enabled")));
		this.btnSend.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnSend.FlatStyle")));
		this.btnSend.Font = ((System.Drawing.Font)(resources.GetObject("btnSend.Font")));
		this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
		this.btnSend.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSend.ImageAlign")));
		this.btnSend.ImageIndex = ((int)(resources.GetObject("btnSend.ImageIndex")));
		this.btnSend.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnSend.ImeMode")));
		this.btnSend.Location = ((System.Drawing.Point)(resources.GetObject("btnSend.Location")));
		this.btnSend.Name = "btnSend";
		this.btnSend.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnSend.RightToLeft")));
		this.btnSend.Size = ((System.Drawing.Size)(resources.GetObject("btnSend.Size")));
		this.btnSend.TabIndex = ((int)(resources.GetObject("btnSend.TabIndex")));
		this.btnSend.Text = resources.GetString("btnSend.Text");
		this.btnSend.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSend.TextAlign")));
		this.btnSend.Visible = ((bool)(resources.GetObject("btnSend.Visible")));
		this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
		// 
		// txtSend
		// 
		this.txtSend.AccessibleDescription = resources.GetString("txtSend.AccessibleDescription");
		this.txtSend.AccessibleName = resources.GetString("txtSend.AccessibleName");
		this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtSend.Anchor")));
		this.txtSend.AutoSize = ((bool)(resources.GetObject("txtSend.AutoSize")));
		this.txtSend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSend.BackgroundImage")));
		this.txtSend.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtSend.Dock")));
		this.txtSend.Enabled = ((bool)(resources.GetObject("txtSend.Enabled")));
		this.txtSend.Font = ((System.Drawing.Font)(resources.GetObject("txtSend.Font")));
		this.txtSend.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtSend.ImeMode")));
		this.txtSend.Location = ((System.Drawing.Point)(resources.GetObject("txtSend.Location")));
		this.txtSend.MaxLength = ((int)(resources.GetObject("txtSend.MaxLength")));
		this.txtSend.Multiline = ((bool)(resources.GetObject("txtSend.Multiline")));
		this.txtSend.Name = "txtSend";
		this.txtSend.PasswordChar = ((char)(resources.GetObject("txtSend.PasswordChar")));
		this.txtSend.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtSend.RightToLeft")));
		this.txtSend.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtSend.ScrollBars")));
		this.txtSend.Size = ((System.Drawing.Size)(resources.GetObject("txtSend.Size")));
		this.txtSend.TabIndex = ((int)(resources.GetObject("txtSend.TabIndex")));
		this.txtSend.Text = resources.GetString("txtSend.Text");
		this.txtSend.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtSend.TextAlign")));
		this.txtSend.Visible = ((bool)(resources.GetObject("txtSend.Visible")));
		this.txtSend.WordWrap = ((bool)(resources.GetObject("txtSend.WordWrap")));
		// 
		// txtDisplay
		// 
		this.txtDisplay.AccessibleDescription = resources.GetString("txtDisplay.AccessibleDescription");
		this.txtDisplay.AccessibleName = resources.GetString("txtDisplay.AccessibleName");
		this.txtDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtDisplay.Anchor")));
		this.txtDisplay.AutoSize = ((bool)(resources.GetObject("txtDisplay.AutoSize")));
		this.txtDisplay.BackColor = System.Drawing.SystemColors.Window;
		this.txtDisplay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtDisplay.BackgroundImage")));
		this.txtDisplay.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtDisplay.Dock")));
		this.txtDisplay.Enabled = ((bool)(resources.GetObject("txtDisplay.Enabled")));
		this.txtDisplay.Font = ((System.Drawing.Font)(resources.GetObject("txtDisplay.Font")));
		this.txtDisplay.ForeColor = System.Drawing.SystemColors.WindowText;
		this.txtDisplay.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtDisplay.ImeMode")));
		this.txtDisplay.Location = ((System.Drawing.Point)(resources.GetObject("txtDisplay.Location")));
		this.txtDisplay.MaxLength = ((int)(resources.GetObject("txtDisplay.MaxLength")));
		this.txtDisplay.Multiline = ((bool)(resources.GetObject("txtDisplay.Multiline")));
		this.txtDisplay.Name = "txtDisplay";
		this.txtDisplay.PasswordChar = ((char)(resources.GetObject("txtDisplay.PasswordChar")));
		this.txtDisplay.ReadOnly = true;
		this.txtDisplay.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtDisplay.RightToLeft")));
		this.txtDisplay.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtDisplay.ScrollBars")));
		this.txtDisplay.Size = ((System.Drawing.Size)(resources.GetObject("txtDisplay.Size")));
		this.txtDisplay.TabIndex = ((int)(resources.GetObject("txtDisplay.TabIndex")));
		this.txtDisplay.Text = resources.GetString("txtDisplay.Text");
		this.txtDisplay.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtDisplay.TextAlign")));
		this.txtDisplay.Visible = ((bool)(resources.GetObject("txtDisplay.Visible")));
		this.txtDisplay.WordWrap = ((bool)(resources.GetObject("txtDisplay.WordWrap")));
		// 
		// tpListUsers
		// 
		this.tpListUsers.AccessibleDescription = resources.GetString("tpListUsers.AccessibleDescription");
		this.tpListUsers.AccessibleName = resources.GetString("tpListUsers.AccessibleName");
		this.tpListUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tpListUsers.Anchor")));
		this.tpListUsers.AutoScroll = ((bool)(resources.GetObject("tpListUsers.AutoScroll")));
		this.tpListUsers.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("tpListUsers.AutoScrollMargin")));
		this.tpListUsers.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("tpListUsers.AutoScrollMinSize")));
		this.tpListUsers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tpListUsers.BackgroundImage")));
		this.tpListUsers.Controls.Add(this.Label1);
		this.tpListUsers.Controls.Add(this.btnListUsers);
		this.tpListUsers.Controls.Add(this.lstUsers);
		this.tpListUsers.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tpListUsers.Dock")));
		this.tpListUsers.Enabled = ((bool)(resources.GetObject("tpListUsers.Enabled")));
		this.tpListUsers.Font = ((System.Drawing.Font)(resources.GetObject("tpListUsers.Font")));
		this.tpListUsers.ImageIndex = ((int)(resources.GetObject("tpListUsers.ImageIndex")));
		this.tpListUsers.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tpListUsers.ImeMode")));
		this.tpListUsers.Location = ((System.Drawing.Point)(resources.GetObject("tpListUsers.Location")));
		this.tpListUsers.Name = "tpListUsers";
		this.tpListUsers.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tpListUsers.RightToLeft")));
		this.tpListUsers.Size = ((System.Drawing.Size)(resources.GetObject("tpListUsers.Size")));
		this.tpListUsers.TabIndex = ((int)(resources.GetObject("tpListUsers.TabIndex")));
		this.tpListUsers.Text = resources.GetString("tpListUsers.Text");
		this.tpListUsers.ToolTipText = resources.GetString("tpListUsers.ToolTipText");
		this.tpListUsers.Visible = ((bool)(resources.GetObject("tpListUsers.Visible")));
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
		this.Label1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
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
		// btnListUsers
		// 
		this.btnListUsers.AccessibleDescription = resources.GetString("btnListUsers.AccessibleDescription");
		this.btnListUsers.AccessibleName = resources.GetString("btnListUsers.AccessibleName");
		this.btnListUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnListUsers.Anchor")));
		this.btnListUsers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnListUsers.BackgroundImage")));
		this.btnListUsers.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnListUsers.Dock")));
		this.btnListUsers.Enabled = ((bool)(resources.GetObject("btnListUsers.Enabled")));
		this.btnListUsers.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnListUsers.FlatStyle")));
		this.btnListUsers.Font = ((System.Drawing.Font)(resources.GetObject("btnListUsers.Font")));
		this.btnListUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnListUsers.Image")));
		this.btnListUsers.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnListUsers.ImageAlign")));
		this.btnListUsers.ImageIndex = ((int)(resources.GetObject("btnListUsers.ImageIndex")));
		this.btnListUsers.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnListUsers.ImeMode")));
		this.btnListUsers.Location = ((System.Drawing.Point)(resources.GetObject("btnListUsers.Location")));
		this.btnListUsers.Name = "btnListUsers";
		this.btnListUsers.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnListUsers.RightToLeft")));
		this.btnListUsers.Size = ((System.Drawing.Size)(resources.GetObject("btnListUsers.Size")));
		this.btnListUsers.TabIndex = ((int)(resources.GetObject("btnListUsers.TabIndex")));
		this.btnListUsers.Text = resources.GetString("btnListUsers.Text");
		this.btnListUsers.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnListUsers.TextAlign")));
		this.btnListUsers.Visible = ((bool)(resources.GetObject("btnListUsers.Visible")));
		this.btnListUsers.Click += new System.EventHandler(this.btnListUsers_Click);
		// 
		// lstUsers
		// 
		this.lstUsers.AccessibleDescription = resources.GetString("lstUsers.AccessibleDescription");
		this.lstUsers.AccessibleName = resources.GetString("lstUsers.AccessibleName");
		this.lstUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lstUsers.Anchor")));
		this.lstUsers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lstUsers.BackgroundImage")));
		this.lstUsers.ColumnWidth = ((int)(resources.GetObject("lstUsers.ColumnWidth")));
		this.lstUsers.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lstUsers.Dock")));
		this.lstUsers.Enabled = ((bool)(resources.GetObject("lstUsers.Enabled")));
		this.lstUsers.Font = ((System.Drawing.Font)(resources.GetObject("lstUsers.Font")));
		this.lstUsers.HorizontalExtent = ((int)(resources.GetObject("lstUsers.HorizontalExtent")));
		this.lstUsers.HorizontalScrollbar = ((bool)(resources.GetObject("lstUsers.HorizontalScrollbar")));
		this.lstUsers.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lstUsers.ImeMode")));
		this.lstUsers.IntegralHeight = ((bool)(resources.GetObject("lstUsers.IntegralHeight")));
		this.lstUsers.ItemHeight = ((int)(resources.GetObject("lstUsers.ItemHeight")));
		this.lstUsers.Location = ((System.Drawing.Point)(resources.GetObject("lstUsers.Location")));
		this.lstUsers.Name = "lstUsers";
		this.lstUsers.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lstUsers.RightToLeft")));
		this.lstUsers.ScrollAlwaysVisible = ((bool)(resources.GetObject("lstUsers.ScrollAlwaysVisible")));
		this.lstUsers.Size = ((System.Drawing.Size)(resources.GetObject("lstUsers.Size")));
		this.lstUsers.TabIndex = ((int)(resources.GetObject("lstUsers.TabIndex")));
		this.lstUsers.Visible = ((bool)(resources.GetObject("lstUsers.Visible")));
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
		this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
		this.Load += new System.EventHandler(this.frmMain_Load);
		this.TabControl1.ResumeLayout(false);
		this.tpChatPage.ResumeLayout(false);
		this.tpListUsers.ResumeLayout(false);
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

    const int READ_BUFFER_SIZE = 255;
    const int PORT_NUM = 10000;
    private TcpClient client;
	private byte[] readBuffer = new byte[READ_BUFFER_SIZE];
  
    // Pop up a Connect user dialog and send a message requesting user to log in to chat.
    void AttemptLogin()
	{
        frmConnectUser frmConnectUser = new frmConnectUser();
        frmConnectUser.StartPosition = FormStartPosition.CenterParent;
        frmConnectUser.ShowDialog(this);
        SendData("CONNECT|" + frmConnectUser.txtUserLogin.Text);
        frmConnectUser.Dispose();
    }

    // Clear the Users listbox, and request the server to send the list of users.
    private void btnListUsers_Click(object sender, System.EventArgs e) 
	{
        lstUsers.Items.Clear();
        SendData("REQUESTUSERS");
    }

    // Send the contents of the Send textbox if it isn't blank.
    private void btnSend_Click(object sender, System.EventArgs e)
	{
        if (txtSend.Text != "") 
		{
            DisplayText("You say: " + txtSend.Text + (char) 13 + (char) 10);
            SendData("CHAT|" + txtSend.Text);
            txtSend.Text = string.Empty;
        }
    }

    // Writes text to the output textbox.
    private void DisplayText(string text)
	{
        txtDisplay.AppendText(text);
    }

    // This is the callback function for TcpClient.GetStream.Begin to get an
    // asynchronous read.
    private void DoRead(IAsyncResult ar)
	{
        int BytesRead;
        string strMessage;

        try
		{
            // Finish asynchronous read into readBuffer and return number of bytes read.
            BytesRead = client.GetStream().EndRead(ar);
            if (BytesRead < 1) {
                // if no bytes were read server has close.  Disable input window.
                MarkAsDisconnected();
                return;
            }
            // Convert the byte array the message was saved into, minus two for the
            // Chr(13) and Chr(10)
            strMessage = Encoding.ASCII.GetString(readBuffer, 0, BytesRead - 2);
            ProcessCommands(strMessage);
            // Start a new asynchronous read into readBuffer.
            client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(DoRead), null);

       } 
		catch( Exception e)
		{
            MarkAsDisconnected();
        }
    }

    // Send the server a disconnect message  
    private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e) //base.Closing;
	{
        // Send only if server is still running.
        if (btnSend.Enabled == true)
		{
            SendData("DISCONNECT");
        }
    }

    // When the form starts, this subroutine will connect to the server and attempt to
    // log in.
    private void frmMain_Load(object sender, System.EventArgs e) 
	{
        frmConnectUser frmConnectUser = new frmConnectUser();
        try 
		{
            // The TcpClient is a subclass of Socket, providing higher level 
            // functionality like streaming.
            client = new TcpClient("localhost", PORT_NUM);
            // Start an asynchronous read invoking DoRead to avoid lagging the user
            // interface.
            client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(DoRead), null);
            // Make sure the window is showing before popping up connection dialog.
            this.Show();
            AttemptLogin();
       } 
		catch( Exception Ex)
		{
            MessageBox.Show("Server is not active.  Please start server and try again.",
                   this.Text,MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
            this.Dispose();
        }
    }

    // This subroutine adds a list of users to listbox.
    private void ListUsers(string[] users)
	{
        int I;

        for (I = 1; I <= (users.Length - 1); I++)
		{
            lstUsers.Items.Add(users[I]);
        }
    }

    // When the server disconnects, prevent further chat messages from being sent.
    private void MarkAsDisconnected()
	{
        txtSend.ReadOnly = true;
        btnSend.Enabled = false;
    }

    // Process the command received from the server, and take appropriate action.
    private void ProcessCommands(string strMessage)
	{
        string[] dataArray;
        // Message parts are divided by "|"  Break the string into an array accordingly.
        dataArray = strMessage.Split((char) 124);
        // dataArray(0) is the command.
        switch( dataArray[0])
		{
            case "JOIN":
                // Server acknowledged login.
                DisplayText("You have joined the chat" + (char) 13 + (char) 10);
				break;
            case "CHAT":
                // Received chat message, display it.
                DisplayText(dataArray[1] + (char) 13 + (char) 10);
				break;
            case "REFUSE":
                // Server refused login with this user name, try to log in with another.
                AttemptLogin();
				break;
            case "LISTUSERS":
                // Server sent a list of users.
                ListUsers(dataArray);
				break;
            case "BROAD":
                // Server sent a broadcast message
                DisplayText("ServerMessage: " + dataArray[1] + (char) 13 + (char) 10);
				break;
        }
    }

    // Use a StreamWriter to send a message to server.
    private void SendData(string data)
	{
        StreamWriter writer = new StreamWriter(client.GetStream());
        writer.Write(data + (char) 13);
        writer.Flush();
    }
}

