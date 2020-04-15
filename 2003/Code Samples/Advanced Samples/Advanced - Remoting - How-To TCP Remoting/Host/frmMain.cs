//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Remoting;

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

	private System.Windows.Forms.ListBox lstOutput;

	private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.lstOutput = new System.Windows.Forms.ListBox();
		this.SuspendLayout();
		// 
		// mnuMain
		// 
		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuFile,
																				this.mnuHelp});
		// 
		// mnuFile
		// 
		this.mnuFile.Index = 0;
		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuExit});
		this.mnuFile.Text = "&File";
		// 
		// mnuExit
		// 
		this.mnuExit.Index = 0;
		this.mnuExit.Text = "E&xit";
		this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
		// 
		// mnuHelp
		// 
		this.mnuHelp.Index = 1;
		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuAbout});
		this.mnuHelp.Text = "&Help";
		// 
		// mnuAbout
		// 
		this.mnuAbout.Index = 0;
		this.mnuAbout.Text = "Text Comes from AssemblyInfo";
		this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
		// 
		// lstOutput
		// 
		this.lstOutput.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lstOutput.Location = new System.Drawing.Point(0, 0);
		this.lstOutput.Name = "lstOutput";
		this.lstOutput.ScrollAlwaysVisible = true;
		this.lstOutput.Size = new System.Drawing.Size(480, 225);
		this.lstOutput.TabIndex = 2;
		// 
		// frmMain
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(480, 233);
		this.Controls.Add(this.lstOutput);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.Menu = this.mnuMain;
		this.Name = "frmMain";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Title Comes from Assembly Info";
		this.Load += new System.EventHandler(this.frmMain_Load);
		this.ResumeLayout(false);

	}

#endregion

#region " Standard Menu Code "

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

	// This function iterates through all the ClientActivatedService types
	// that were loaded via the RemotingConfiguration.Configure(Remoting.config)
	// file.
	private void ListClientActivatedServiceTypes()
	{
		foreach(ActivatedServiceTypeEntry entry in RemotingConfiguration.GetRegisteredActivatedServiceTypes())
		{
			this.lstOutput.Items.Add("Registered ActivatedServiceType: " + entry.TypeName);
		}
	}

	// This function iterates through all the WellKnownService types
	// that were loaded via the RemotingConfiguration.Configure(Remoting.config)
	// file.
	private void ListWellKnownServiceTypes()
	{
		foreach(WellKnownServiceTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownServiceTypes())
		{
			this.lstOutput.Items.Add(entry.TypeName + " is available at " + entry.ObjectUri);
		}
	}

	private void frmMain_Load(object sender, System.EventArgs e) 
	{
		try 
		{
			//Read in Host.exe.config file
			//The call to RemotingConfiguration.Configure loads in the xml configuration file
			//and lets the remoting architecture know what types to make available via remoting
			this.lstOutput.Items.Add("Loading Activated Configuration File");
			RemotingConfiguration.Configure("Host.exe.config");
			//After loading the remoting.config file enumerate the list of ClientActivated
			//types and WellKnown types and list them in the list box on the form.
			this.ListClientActivatedServiceTypes();
			this.ListWellKnownServiceTypes();
		}
		catch (Exception exp) 
		{
			// Will catch any generic exception
			string txt;
			txt = "I was unable to load the file remoting.config or it is not in the correct format." + Environment.NewLine + 
			"Please make sure it is located in the same directory this exe " + 
			" and that it is in the correct format." + Environment.NewLine + 
			"Please see the Help, About box for the location of this exe." + Environment.NewLine + Environment.NewLine + 
			"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
			"  Message: " + exp.Message + Environment.NewLine + 
			"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
			"  Stack Trace:" + Environment.NewLine + 
			exp.StackTrace;
			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			this.lstOutput.Items.Add("Unabled to load objects.");
		}
	}
}

