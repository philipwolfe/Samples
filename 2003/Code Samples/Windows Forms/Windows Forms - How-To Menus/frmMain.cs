//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;

public class frmMain:System.Windows.Forms.Form 
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}
	int intChild;

#region " Windows Form Designer generated code "

	public frmMain() 
{

		//This call is required by the Windows Form Designer.

		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		
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

    private System.Windows.Forms.MenuItem mnuWindow;

    private System.Windows.Forms.MenuItem mnuCascade;

    private System.Windows.Forms.MenuItem mnunew;

    private System.Windows.Forms.MenuItem mnuTileVertical;

    private System.Windows.Forms.MenuItem mnuTileHorizontal;

    private System.Windows.Forms.StatusBar sbarEdit;

    private System.Windows.Forms.MenuItem mnuView;

    private System.Windows.Forms.MenuItem mnuStatusBar;

    private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnunew = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuView = new System.Windows.Forms.MenuItem();
		this.mnuStatusBar = new System.Windows.Forms.MenuItem();
		this.mnuWindow = new System.Windows.Forms.MenuItem();
		this.mnuCascade = new System.Windows.Forms.MenuItem();
		this.mnuTileVertical = new System.Windows.Forms.MenuItem();
		this.mnuTileHorizontal = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.sbarEdit = new System.Windows.Forms.StatusBar();
		this.SuspendLayout();
		// 
		// mnuMain
		// 
		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuFile,
																				this.mnuView,
																				this.mnuWindow,
																				this.mnuHelp});
		// 
		// mnuFile
		// 
		this.mnuFile.Index = 0;
		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnunew,
																				this.mnuExit});
		this.mnuFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
		this.mnuFile.Text = "&File";
		this.mnuFile.Click += new System.EventHandler(this.ClearStatus);
		this.mnuFile.Select += new System.EventHandler(this.HandleSelect);
		// 
		// mnunew
		// 
		this.mnunew.DefaultItem = true;
		this.mnunew.Index = 0;
		this.mnunew.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
		this.mnunew.Text = "&New";
		this.mnunew.Click += new System.EventHandler(mnunew_Click);
		this.mnunew.Click += new System.EventHandler(this.ClearStatus);
		this.mnunew.Select += new System.EventHandler(this.HandleSelect);
		// 
		// mnuExit
		// 
		this.mnuExit.Index = 1;
		this.mnuExit.MergeOrder = 10;
		this.mnuExit.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
		this.mnuExit.Text = "E&xit";
		this.mnuExit.Click += new System.EventHandler(this.ClearStatus);
		this.mnuExit.Select += new System.EventHandler(this.HandleSelect);
		// 
		// mnuView
		// 
		this.mnuView.Index = 1;
		this.mnuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuStatusBar});
		this.mnuView.MergeOrder = 10;
		this.mnuView.Text = "&View";
		this.mnuView.Popup += new System.EventHandler(this.mnuView_Popup);
		this.mnuView.Click += new System.EventHandler(this.ClearStatus);
		this.mnuView.Select += new System.EventHandler(this.HandleSelect);
		// 
		// mnuStatusBar
		// 
		this.mnuStatusBar.Checked = true;
		this.mnuStatusBar.Index = 0;
		this.mnuStatusBar.Text = "&Status Bar";
		this.mnuStatusBar.Click+=new EventHandler(mnuStatusBar_Click);
		this.mnuStatusBar.Click += new System.EventHandler(this.ClearStatus);
		this.mnuStatusBar.Select += new System.EventHandler(this.HandleSelect);
		// 
		// mnuWindow
		// 
		this.mnuWindow.Index = 2;
		this.mnuWindow.MdiList = true;
		this.mnuWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				  this.mnuCascade,
																				  this.mnuTileVertical,
																				  this.mnuTileHorizontal});
		this.mnuWindow.MergeOrder = 20;
		this.mnuWindow.Text = "&Window";
		this.mnuWindow.Popup += new System.EventHandler(this.mnuWindow_Popup);
		this.mnuWindow.Click += new System.EventHandler(this.ClearStatus);
		this.mnuWindow.Select += new System.EventHandler(this.HandleSelect);
		// 
		// mnuCascade
		// 
		this.mnuCascade.Index = 0;
		this.mnuCascade.Text = "&Cascade";
		this.mnuCascade.Click += new System.EventHandler(this.mnuCascade_Click);
		this.mnuCascade.Select += new System.EventHandler(this.HandleSelect);
		// 
		// mnuTileVertical
		// 
		this.mnuTileVertical.Index = 1;
		this.mnuTileVertical.Text = "Tile &Vertical";
		this.mnuTileVertical.Click += new System.EventHandler(this.mnuTileVertical_Click);
		this.mnuTileVertical.Select += new System.EventHandler(this.HandleSelect);
		// 
		// mnuTileHorizontal
		// 
		this.mnuTileHorizontal.Index = 2;
		this.mnuTileHorizontal.Text = "Tile &Horizontal";
		this.mnuTileHorizontal.Click += new System.EventHandler(this.mnuTileHorizontal_Click);
		this.mnuTileHorizontal.Select += new System.EventHandler(this.HandleSelect);
		// 
		// mnuHelp
		// 
		this.mnuHelp.Index = 3;
		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuAbout});
		this.mnuHelp.MergeOrder = 30;
		this.mnuHelp.Text = "&Help";
		this.mnuHelp.Click += new System.EventHandler(this.ClearStatus);
		this.mnuHelp.Select += new System.EventHandler(this.HandleSelect);
		// 
		// mnuAbout
		// 
		this.mnuAbout.Index = 0;
		this.mnuAbout.Text = "Text Comes from AssemblyInfo";
		this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
		this.mnuAbout.Select += new System.EventHandler(this.HandleSelect);
		// 
		// sbarEdit
		// 
		this.sbarEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.sbarEdit.Location = new System.Drawing.Point(0, 268);
		this.sbarEdit.Name = "sbarEdit";
		this.sbarEdit.Size = new System.Drawing.Size(424, 22);
		this.sbarEdit.TabIndex = 1;
		// 
		// frmMain
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(424, 290);
		this.Controls.Add(this.sbarEdit);
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.IsMdiContainer = true;
		this.Menu = this.mnuMain;
		this.Name = "frmMain";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Title Comes from Assembly Info";
		this.Load += new System.EventHandler(this.frmMain_Load);
		this.ResumeLayout(false);

	}

#endregion

#region " Standard Menu Code "

	// has been added to some procedures since they are

	// not the focus of the demo. Remove them if you wish to debug the procedures.

	// This code simply shows the About form.

	private void mnuAbout_Click(object sender, System.EventArgs e) 
	{

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

#region " Form Load ";

	// has been added to some procedures since they are

	// not the focus of the demo. Remove them if you wish to debug the procedures.

	private void frmMain_Load(object sender, System.EventArgs e) {

		// So that we only need to set the title of the application once,

		// we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)

		// to read the AssemblyTitle attribute.

		AssemblyInfo ainfo = new AssemblyInfo();

		this.Text = ainfo.Title;

		this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);

    }

#endregion

    private void mnuCascade_Click(object sender, System.EventArgs e)
	{

        this.LayoutMdi(MdiLayout.Cascade);

    }

	
    private void mnunew_Click(object sender, System.EventArgs e)
	{
        // Attempt to create a new child form.
        Addnew();
    }

	private void Addnew()
	{
		try 
		{
			            frmEdit frm =  new frmEdit();
						intChild += 1;
			            frm.MdiParent = this;
			            frm.Text = "Child " + intChild;
			            frm.Show();
		}
			
		catch(System.Exception exp) 
		{
			MessageBox.Show(exp.Message, this.Text);
		}
			
		}

    private void mnuStatusBar_Click(object sender, System.EventArgs e)
	{

        // Toggle the visibility of the status bar.

        bool blnShow  = ! mnuStatusBar.Checked;

        mnuStatusBar.Checked = blnShow;

        sbarEdit.Visible = blnShow;

    }

    private void mnuTileHorizontal_Click(object sender, System.EventArgs e) 
	{
        this.LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void mnuTileVertical_Click(object sender, System.EventArgs e) 
	{
        this.LayoutMdi(MdiLayout.TileVertical);
    }

    private void mnuView_Popup(object sender, System.EventArgs e)
	{

        // Determine how to treat items on the View menu.

        mnuStatusBar.Checked = sbarEdit.Visible;

    }

    private void mnuWindow_Popup(object sender, System.EventArgs e)
	{

        // Enable/disable child form-handling menu items.

        bool blnEnable  = (this.MdiChildren.Length > 0);

        mnuCascade.Enabled = blnEnable;

        mnuTileHorizontal.Enabled = blnEnable;

        mnuTileVertical.Enabled = blnEnable;

    }

    private void ClearStatus(object sender, System.EventArgs e)
	{
        // Once you click a menu item, clear the status bar.

        ClearStatusBar();

    }

    public void ClearStatusBar()
	{
        sbarEdit.Text = string.Empty;

    }

    private void HandleSelect(object sender, System.EventArgs e) 
	{
        string strText ;

		if (sender == mnuStatusBar)
		{

			strText = "Toggle display of the status bar";

		} 
		else if ( sender == mnuAbout)
		{

			strText = "Display the About dialog box";

		} 
		else if ( sender == mnuCascade)
		{

			strText = "Cascade child windows";

		} 
		else if ( sender == mnuExit)
		{

			strText = "Exit demonstration";

		} 
		else if ( sender == mnunew)
		{

			strText = "Create new child window";

		} 
		else if ( sender == mnuTileHorizontal)
		{

			strText = "Tile windows horizontally";

		} 
		else if ( sender == mnuTileVertical)
		{

			strText = "Tile windows vertically";
		}
		else 
		{
			strText = string.Empty;

		}

        WriteToStatusBar(strText);

    }

    public void WriteToStatusBar(string Text )
	{
        // Make this procedure public so that the child form(s)

        // can call it, as well.

        sbarEdit.Text = Text;

    }

	

}

