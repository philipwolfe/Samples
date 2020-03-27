//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Reflection; // Namespace for Assembly type

public class frmMain: System.Windows.Forms.Form 
{

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
	protected override void Dispose(bool disposing) 
	{
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
	private System.Windows.Forms.Label lblCurrentlyLoadedAssemblies;
	private System.Windows.Forms.Button cmdListLoadedAssemblies;
	private System.Windows.Forms.ListBox lstLoadedAssemblies;
	private System.Windows.Forms.Button cmdAssemblyDetail;
	private System.Windows.Forms.TextBox txtDisplayName;
	private System.Windows.Forms.Label lblDisplayName;
	private System.Windows.Forms.TextBox txtLocation;
	private System.Windows.Forms.Label lblLocation;
	private System.Windows.Forms.GroupBox grpViewMetadata;
	private System.Windows.Forms.ListBox lstTypes;
	private System.Windows.Forms.Label lblTypes;
	private System.Windows.Forms.Label lblMembers;
	private System.Windows.Forms.ListBox lstMembers;
	private System.Windows.Forms.StatusBar sbInfo;
	private System.Windows.Forms.StatusBarPanel pnlAssemblies;
	private System.Windows.Forms.StatusBarPanel pnlTypes;
	private System.Windows.Forms.StatusBarPanel pnlMembers;

	private void InitializeComponent() 
	{	
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

		this.mnuMain = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.mnuExit = new System.Windows.Forms.MenuItem();

		this.mnuHelp = new System.Windows.Forms.MenuItem();

		this.mnuAbout = new System.Windows.Forms.MenuItem();

		this.grpViewMetadata = new System.Windows.Forms.GroupBox();

		this.cmdAssemblyDetail = new System.Windows.Forms.Button();

		this.cmdListLoadedAssemblies = new System.Windows.Forms.Button();

		this.lblCurrentlyLoadedAssemblies = new System.Windows.Forms.Label();

		this.lstLoadedAssemblies = new System.Windows.Forms.ListBox();

		this.txtDisplayName = new System.Windows.Forms.TextBox();

		this.lblDisplayName = new System.Windows.Forms.Label();

		this.txtLocation = new System.Windows.Forms.TextBox();

		this.lblLocation = new System.Windows.Forms.Label();

		this.lstTypes = new System.Windows.Forms.ListBox();

		this.lblTypes = new System.Windows.Forms.Label();

		this.lblMembers = new System.Windows.Forms.Label();

		this.lstMembers = new System.Windows.Forms.ListBox();

		this.sbInfo = new System.Windows.Forms.StatusBar();

		this.pnlAssemblies = new System.Windows.Forms.StatusBarPanel();

		this.pnlTypes = new System.Windows.Forms.StatusBarPanel();

		this.pnlMembers = new System.Windows.Forms.StatusBarPanel();

		this.grpViewMetadata.SuspendLayout();

		((System.ComponentModel.ISupportInitialize) this.pnlAssemblies).BeginInit();

		((System.ComponentModel.ISupportInitialize) this.pnlTypes).BeginInit();

		((System.ComponentModel.ISupportInitialize) this.pnlMembers).BeginInit();

		this.SuspendLayout();

		//

		//mnuMain

		//

		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuHelp});

		//

		//mnuFile

		//

		this.mnuFile.Index = 0;

		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});

		this.mnuFile.Text = "&File";

		//

		//mnuExit

		//

		this.mnuExit.Index = 0;

		this.mnuExit.Text = "E&xit";
		this.mnuExit.Click += new EventHandler(mnuExit_Click);

		//

		//mnuHelp

		//

		this.mnuHelp.Index = 1;

		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});

		this.mnuHelp.Text = "&Help";

		//

		//mnuAbout

		//

		this.mnuAbout.Index = 0;

		this.mnuAbout.Text = "Text Comes from AssemblyInfo";
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);

		//

		//grpViewMetadata

		//

		this.grpViewMetadata.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdAssemblyDetail, this.cmdListLoadedAssemblies});

		this.grpViewMetadata.Location = new System.Drawing.Point(16, 16);

		this.grpViewMetadata.Name = "grpViewMetadata";

		this.grpViewMetadata.Size = new System.Drawing.Size(248, 104);

		this.grpViewMetadata.TabIndex = 0;

		this.grpViewMetadata.TabStop = false;

		this.grpViewMetadata.Text = "&View Metadata";

		//

		//cmdAssemblyDetail

		//

		this.cmdAssemblyDetail.Enabled = false;

		this.cmdAssemblyDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.cmdAssemblyDetail.Location = new System.Drawing.Point(24, 64);

		this.cmdAssemblyDetail.Name = "cmdAssemblyDetail";

		this.cmdAssemblyDetail.Size = new System.Drawing.Size(200, 24);

		this.cmdAssemblyDetail.TabIndex = 2;

		this.cmdAssemblyDetail.Text = "Show &Detail for Selected Assembly";
		this.cmdAssemblyDetail.Click += new EventHandler(cmdAssemblyDetail_Click);
		
		//

		//cmdListLoadedAssemblies

		//

		this.cmdListLoadedAssemblies.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.cmdListLoadedAssemblies.Location = new System.Drawing.Point(24, 32);

		this.cmdListLoadedAssemblies.Name = "cmdListLoadedAssemblies";

		this.cmdListLoadedAssemblies.Size = new System.Drawing.Size(200, 24);

		this.cmdListLoadedAssemblies.TabIndex = 1;

		this.cmdListLoadedAssemblies.Text = "List &Loaded Assemblies";
		this.cmdListLoadedAssemblies.Click += new EventHandler(cmdListLoadedAssemblies_Click);

		//

		//lblCurrentlyLoadedAssemblies

		//

		this.lblCurrentlyLoadedAssemblies.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblCurrentlyLoadedAssemblies.Location = new System.Drawing.Point(296, 8);

		this.lblCurrentlyLoadedAssemblies.Name = "lblCurrentlyLoadedAssemblies";

		this.lblCurrentlyLoadedAssemblies.Size = new System.Drawing.Size(168, 16);

		this.lblCurrentlyLoadedAssemblies.TabIndex = 3;

		this.lblCurrentlyLoadedAssemblies.Text = "&Currently Loaded Assemblies";

		//

		//lstLoadedAssemblies

		//

		this.lstLoadedAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lstLoadedAssemblies.Location = new System.Drawing.Point(288, 24);

		this.lstLoadedAssemblies.Name = "lstLoadedAssemblies";

		this.lstLoadedAssemblies.Size = new System.Drawing.Size(214, 95);

		this.lstLoadedAssemblies.Sorted = true;

		this.lstLoadedAssemblies.TabIndex = 4;
		this.lstLoadedAssemblies.SelectedIndexChanged += new EventHandler(lstLoadedAssemblies_SelectedIndexChanged);

		//

		//txtDisplayName

		//

		this.txtDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.txtDisplayName.Location = new System.Drawing.Point(16, 152);

		this.txtDisplayName.Name = "txtDisplayName";

		this.txtDisplayName.ReadOnly = true;

		this.txtDisplayName.Size = new System.Drawing.Size(486, 20);

		this.txtDisplayName.TabIndex = 6;

		this.txtDisplayName.Text = "";

		//

		//lblDisplayName

		//

		this.lblDisplayName.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblDisplayName.Location = new System.Drawing.Point(16, 136);

		this.lblDisplayName.Name = "lblDisplayName";

		this.lblDisplayName.Size = new System.Drawing.Size(288, 16);

		this.lblDisplayName.TabIndex = 5;

		this.lblDisplayName.Text = "F&ully qualified name (DisplayName) for Assembly";

		//

		//txtLocation

		//

		this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.txtLocation.Location = new System.Drawing.Point(16, 200);

		this.txtLocation.Name = "txtLocation";

		this.txtLocation.ReadOnly = true;

		this.txtLocation.Size = new System.Drawing.Size(486, 20);

		this.txtLocation.TabIndex = 8;

		this.txtLocation.Text = "";

		//

		//lblLocation

		//

		this.lblLocation.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblLocation.Location = new System.Drawing.Point(16, 184);

		this.lblLocation.Name = "lblLocation";

		this.lblLocation.Size = new System.Drawing.Size(288, 16);

		this.lblLocation.TabIndex = 7;

		this.lblLocation.Text = "&Path and File Name of Assembly";

		//

		//lstTypes

		//

		this.lstTypes.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lstTypes.Location = new System.Drawing.Point(16, 248);

		this.lstTypes.Name = "lstTypes";

		this.lstTypes.Size = new System.Drawing.Size(496, 121);

		this.lstTypes.Sorted = true;

		this.lstTypes.TabIndex = 10;
		this.lstTypes.SelectedIndexChanged += new EventHandler(lstTypes_SelectedIndexChanged);

		//

		//lblTypes

		//

		this.lblTypes.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblTypes.Location = new System.Drawing.Point(16, 232);

		this.lblTypes.Name = "lblTypes";

		this.lblTypes.Size = new System.Drawing.Size(152, 16);

		this.lblTypes.TabIndex = 9;

		this.lblTypes.Text = "&Types in Assembly";

		//

		//lblMembers

		//

		this.lblMembers.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblMembers.Location = new System.Drawing.Point(16, 376);

		this.lblMembers.Name = "lblMembers";

		this.lblMembers.Size = new System.Drawing.Size(152, 16);

		this.lblMembers.TabIndex = 11;

		this.lblMembers.Text = "&Members in Selected Type";

		//

		//lstMembers

		//

		this.lstMembers.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lstMembers.Location = new System.Drawing.Point(16, 392);

		this.lstMembers.Name = "lstMembers";

		this.lstMembers.Size = new System.Drawing.Size(496, 121);

		this.lstMembers.Sorted = true;

		this.lstMembers.TabIndex = 12;

		//

		//sbInfo

		//

		this.sbInfo.Location = new System.Drawing.Point(0, 523);

		this.sbInfo.Name = "sbInfo";

		this.sbInfo.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {this.pnlAssemblies, this.pnlTypes, this.pnlMembers});

		this.sbInfo.ShowPanels = true;

		this.sbInfo.Size = new System.Drawing.Size(520, 22);

		this.sbInfo.TabIndex = 13;

		//

		//pnlAssemblies

		//

		this.pnlAssemblies.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;

		this.pnlAssemblies.Text = "Assemblies: {0}";

		this.pnlAssemblies.Width = 168;

		//

		//pnlTypes

		//

		this.pnlTypes.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;

		this.pnlTypes.Text = "Types: {0}";

		this.pnlTypes.Width = 168;

		//

		//pnlMembers

		//

		this.pnlMembers.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;

		this.pnlMembers.Text = "Members: {0}";

		this.pnlMembers.Width = 168;

		//

		//frmMain

		//

		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

		this.ClientSize = new System.Drawing.Size(520, 545);

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.sbInfo, this.lblMembers, this.lstMembers, this.lblTypes, this.lstTypes, this.lblLocation, this.txtLocation, this.lblDisplayName, this.txtDisplayName, this.lstLoadedAssemblies, this.lblCurrentlyLoadedAssemblies, this.grpViewMetadata});

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.MaximizeBox = false;

		this.Menu = this.mnuMain;

		this.Name = "frmMain";

		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

		this.Text = "Title Comes from Assembly Info";

		this.grpViewMetadata.ResumeLayout(false);

		((System.ComponentModel.ISupportInitialize) this.pnlAssemblies).EndInit();

		((System.ComponentModel.ISupportInitialize) this.pnlTypes).EndInit();

		((System.ComponentModel.ISupportInitialize) this.pnlMembers).EndInit();

		this.ResumeLayout(false);
		this.Load += new EventHandler(frmMain_Load);

	}

#endregion

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

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
	private void mnuExit_Click(object sender, System.EventArgs e) 
	{
		// Close the current form
		this.Close();
	}
#endregion

	//This will be used to track the current assembly being investigated.
	private Assembly CurrentAsm;

	private void cmdListLoadedAssemblies_Click(object sender, System.EventArgs e)
	{
		//This method will enumerate and list all currently loaded assemblies into 
		//the adjacent list box. Listed assemblies can subsequently be clicked on 
		//to display further details.

		Assembly[] asms;

		//Retrieve the loaded assemblies from the current AppDomain.
		asms = AppDomain.CurrentDomain.GetAssemblies();

		//Clear out any current listbox entries
		lstLoadedAssemblies.Items.Clear();

		//Enumerate and display the assemblies
		foreach(Assembly asm in asms)
		{
			lstLoadedAssemblies.Items.Add(asm.GetName().Name);
		}

		this.UpdatePanels(this.lstLoadedAssemblies.Items.Count);

		//if there are assemblies listed, allow viewing of details
		cmdAssemblyDetail.Enabled = (lstLoadedAssemblies.Items.Count > 0);

		//Clear out previous details
		txtDisplayName.Text = string.Empty;
		txtLocation.Text = string.Empty;
		lstTypes.Items.Clear();
		lstMembers.Items.Clear();
		CurrentAsm = null;
	}

	private void frmMain_Load(object sender, System.EventArgs e)
	{
		UpdatePanels(0, 0, 0);
	}

	private void lstLoadedAssemblies_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		//Clear out previous details
		txtDisplayName.Text = string.Empty;
		txtLocation.Text = string.Empty;
		lstTypes.Items.Clear();
		lstMembers.Items.Clear();
		
		// Let go of earlier used reference
		CurrentAsm = null;
	}

	private void lstTypes_SelectedIndexChanged(object sender, System.EventArgs e)
	{
	    // This method loads the members for the selected type.
		// Turn on hourglass
		this.Cursor = Cursors.WaitCursor;

		// Get a type reference for the selected type
		Type t = CurrentAsm.GetType(lstTypes.Text);

		// Clear out the old info
		lstMembers.Items.Clear();

		// Load in the new info, displaying the name and kind of member (field, method, etc.)
		foreach(MemberInfo mi in t.GetMembers())
		{
            lstMembers.Items.Add(mi.Name + " - " + mi.MemberType.ToString());
		}
		
		this.UpdatePanels(this.lstLoadedAssemblies.Items.Count, this.lstTypes.Items.Count, this.lstMembers.Items.Count);

		// Turn off hourglass
		this.Cursor = Cursors.Default;
	}
	
	private void cmdAssemblyDetail_Click(object sender, System.EventArgs e) 
	{
		//Display metadata for the selected assembly. Note that this method handles
		//both the assembly detail button's click event and the assemblies list box's
		//double-click event.

		//Make sure an assembly is selected
		if (lstLoadedAssemblies.SelectedIndex == -1) 
		{
			MessageBox.Show("Please select an assembly to view from the list", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return;
		}

		// Turn on hourglass
		this.Cursor = Cursors.WaitCursor;

		//Assign asm to the correct assembly from the collection of 
		//currently loaded(assemblies)
		foreach(Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
		{
			if (asm.GetName().Name == lstLoadedAssemblies.Text) 
			{
				//Retain a longer-lived reference to the selected assembly
				CurrentAsm = asm;
				break;
			}
		}

		//Display details
		txtDisplayName.Text = CurrentAsm.FullName;
		txtLocation.Text = CurrentAsm.Location;

		//Display list of types in the assembly
		foreach(Type t in CurrentAsm.GetTypes())
		{
			lstTypes.Items.Add(t.FullName);
		}

		this.UpdatePanels(this.lstLoadedAssemblies.Items.Count, this.lstTypes.Items.Count);

		// Turn off hourglass
		this.Cursor = Cursors.Default;
	}

	// The following three overloaded methods (UpdatePanels) update the status bar's three panels text
	// with the count of the loaded assemblies, types, and members respectively.
	private void UpdatePanels(int AsmCount)
	{
		UpdatePanels(AsmCount, 0);
	}

	private void UpdatePanels(int AsmCount, int TypeCount)
	{
		UpdatePanels(AsmCount, TypeCount, 0);
	}

	private void UpdatePanels(int AsmCount, int TypeCount, int MethodCount)
	{
		StatusBarPanel pAsm = this.sbInfo.Panels[0];
		StatusBarPanel pTyp = this.sbInfo.Panels[1];
		StatusBarPanel pMbr = this.sbInfo.Panels[2];
		const string ASM_TEXT = "Assemblies: {0}";
		const string TYP_TEXT = "Types: {0}";
		const string MBR_TEXT = "Members: {0}";
		pAsm.Text = string.Format(ASM_TEXT, AsmCount.ToString());
		pTyp.Text = string.Format(TYP_TEXT, TypeCount.ToString());
		pMbr.Text = string.Format(MBR_TEXT, MethodCount.ToString());
	}
}
