//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

public class frmMain: System.Windows.Forms.Form {

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Windows Form Designer generated code "

	public frmMain() {
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
    private System.Windows.Forms.RichTextBox DisplayText;
    private System.Windows.Forms.Button btnCurrentProcessInfo;
    private System.Windows.Forms.Button btnStartProcess;
    private System.Windows.Forms.Button btnProcessStartInfo;
    private System.Windows.Forms.Button btnTaskManager;
    private System.Windows.Forms.Button btnShellExecute;
    private System.Windows.Forms.Button btnCommandLine;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.btnStartProcess = new System.Windows.Forms.Button();

        this.btnProcessStartInfo = new System.Windows.Forms.Button();

        this.btnCurrentProcessInfo = new System.Windows.Forms.Button();

        this.btnTaskManager = new System.Windows.Forms.Button();

        this.DisplayText = new System.Windows.Forms.RichTextBox();

        this.btnShellExecute = new System.Windows.Forms.Button();

        this.btnCommandLine = new System.Windows.Forms.Button();

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

        //

        //btnStartProcess

        //

        this.btnStartProcess.AccessibleDescription = (string) resources.GetObject("btnStartProcess.AccessibleDescription");

        this.btnStartProcess.AccessibleName = (string) resources.GetObject("btnStartProcess.AccessibleName");

        this.btnStartProcess.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnStartProcess.Anchor");

        this.btnStartProcess.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnStartProcess.BackgroundImage");

        this.btnStartProcess.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnStartProcess.Dock");

        this.btnStartProcess.Enabled = (bool) resources.GetObject("btnStartProcess.Enabled");

        this.btnStartProcess.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnStartProcess.FlatStyle");

        this.btnStartProcess.Font = (System.Drawing.Font) resources.GetObject("btnStartProcess.Font");

        this.btnStartProcess.Image = (System.Drawing.Image) resources.GetObject("btnStartProcess.Image");

        this.btnStartProcess.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStartProcess.ImageAlign");

        this.btnStartProcess.ImageIndex = (int) resources.GetObject("btnStartProcess.ImageIndex");

        this.btnStartProcess.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnStartProcess.ImeMode");

        this.btnStartProcess.Location = (System.Drawing.Point) resources.GetObject("btnStartProcess.Location");

        this.btnStartProcess.Name = "btnStartProcess";

        this.btnStartProcess.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnStartProcess.RightToLeft");

        this.btnStartProcess.Size = (System.Drawing.Size) resources.GetObject("btnStartProcess.Size");

        this.btnStartProcess.TabIndex = (int) resources.GetObject("btnStartProcess.TabIndex");

        this.btnStartProcess.Text = resources.GetString("btnStartProcess.Text");

        this.btnStartProcess.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStartProcess.TextAlign");

        this.btnStartProcess.Visible = (bool) resources.GetObject("btnStartProcess.Visible");

        //

        //btnProcessStartInfo

        //

        this.btnProcessStartInfo.AccessibleDescription = (string) resources.GetObject("btnProcessStartInfo.AccessibleDescription");

        this.btnProcessStartInfo.AccessibleName = (string) resources.GetObject("btnProcessStartInfo.AccessibleName");

        this.btnProcessStartInfo.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnProcessStartInfo.Anchor");

        this.btnProcessStartInfo.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnProcessStartInfo.BackgroundImage");

        this.btnProcessStartInfo.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnProcessStartInfo.Dock");

        this.btnProcessStartInfo.Enabled = (bool) resources.GetObject("btnProcessStartInfo.Enabled");

        this.btnProcessStartInfo.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnProcessStartInfo.FlatStyle");

        this.btnProcessStartInfo.Font = (System.Drawing.Font) resources.GetObject("btnProcessStartInfo.Font");

        this.btnProcessStartInfo.Image = (System.Drawing.Image) resources.GetObject("btnProcessStartInfo.Image");

        this.btnProcessStartInfo.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnProcessStartInfo.ImageAlign");

        this.btnProcessStartInfo.ImageIndex = (int) resources.GetObject("btnProcessStartInfo.ImageIndex");

        this.btnProcessStartInfo.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnProcessStartInfo.ImeMode");

        this.btnProcessStartInfo.Location = (System.Drawing.Point) resources.GetObject("btnProcessStartInfo.Location");

        this.btnProcessStartInfo.Name = "btnProcessStartInfo";

        this.btnProcessStartInfo.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnProcessStartInfo.RightToLeft");

        this.btnProcessStartInfo.Size = (System.Drawing.Size) resources.GetObject("btnProcessStartInfo.Size");

        this.btnProcessStartInfo.TabIndex = (int) resources.GetObject("btnProcessStartInfo.TabIndex");

        this.btnProcessStartInfo.Text = resources.GetString("btnProcessStartInfo.Text");

        this.btnProcessStartInfo.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnProcessStartInfo.TextAlign");

        this.btnProcessStartInfo.Visible = (bool) resources.GetObject("btnProcessStartInfo.Visible");

        //

        //btnCurrentProcessInfo

        //

        this.btnCurrentProcessInfo.AccessibleDescription = (string) resources.GetObject("btnCurrentProcessInfo.AccessibleDescription");

        this.btnCurrentProcessInfo.AccessibleName = (string) resources.GetObject("btnCurrentProcessInfo.AccessibleName");

        this.btnCurrentProcessInfo.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCurrentProcessInfo.Anchor");

        this.btnCurrentProcessInfo.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCurrentProcessInfo.BackgroundImage");

        this.btnCurrentProcessInfo.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCurrentProcessInfo.Dock");

        this.btnCurrentProcessInfo.Enabled = (bool) resources.GetObject("btnCurrentProcessInfo.Enabled");

        this.btnCurrentProcessInfo.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCurrentProcessInfo.FlatStyle");

        this.btnCurrentProcessInfo.Font = (System.Drawing.Font) resources.GetObject("btnCurrentProcessInfo.Font");

        this.btnCurrentProcessInfo.Image = (System.Drawing.Image) resources.GetObject("btnCurrentProcessInfo.Image");

        this.btnCurrentProcessInfo.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCurrentProcessInfo.ImageAlign");

        this.btnCurrentProcessInfo.ImageIndex = (int) resources.GetObject("btnCurrentProcessInfo.ImageIndex");

        this.btnCurrentProcessInfo.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCurrentProcessInfo.ImeMode");

        this.btnCurrentProcessInfo.Location = (System.Drawing.Point) resources.GetObject("btnCurrentProcessInfo.Location");

        this.btnCurrentProcessInfo.Name = "btnCurrentProcessInfo";

        this.btnCurrentProcessInfo.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCurrentProcessInfo.RightToLeft");

        this.btnCurrentProcessInfo.Size = (System.Drawing.Size) resources.GetObject("btnCurrentProcessInfo.Size");

        this.btnCurrentProcessInfo.TabIndex = (int) resources.GetObject("btnCurrentProcessInfo.TabIndex");

        this.btnCurrentProcessInfo.Text = resources.GetString("btnCurrentProcessInfo.Text");

        this.btnCurrentProcessInfo.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCurrentProcessInfo.TextAlign");

        this.btnCurrentProcessInfo.Visible = (bool) resources.GetObject("btnCurrentProcessInfo.Visible");

        //

        //btnTaskManager

        //

        this.btnTaskManager.AccessibleDescription = (string) resources.GetObject("btnTaskManager.AccessibleDescription");

        this.btnTaskManager.AccessibleName = (string) resources.GetObject("btnTaskManager.AccessibleName");

        this.btnTaskManager.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnTaskManager.Anchor");

        this.btnTaskManager.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnTaskManager.BackgroundImage");

        this.btnTaskManager.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnTaskManager.Dock");

        this.btnTaskManager.Enabled = (bool) resources.GetObject("btnTaskManager.Enabled");

        this.btnTaskManager.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnTaskManager.FlatStyle");

        this.btnTaskManager.Font = (System.Drawing.Font) resources.GetObject("btnTaskManager.Font");

        this.btnTaskManager.Image = (System.Drawing.Image) resources.GetObject("btnTaskManager.Image");

        this.btnTaskManager.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnTaskManager.ImageAlign");

        this.btnTaskManager.ImageIndex = (int) resources.GetObject("btnTaskManager.ImageIndex");

        this.btnTaskManager.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnTaskManager.ImeMode");

        this.btnTaskManager.Location = (System.Drawing.Point) resources.GetObject("btnTaskManager.Location");

        this.btnTaskManager.Name = "btnTaskManager";

        this.btnTaskManager.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnTaskManager.RightToLeft");

        this.btnTaskManager.Size = (System.Drawing.Size) resources.GetObject("btnTaskManager.Size");

        this.btnTaskManager.TabIndex = (int) resources.GetObject("btnTaskManager.TabIndex");

        this.btnTaskManager.Text = resources.GetString("btnTaskManager.Text");

        this.btnTaskManager.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnTaskManager.TextAlign");

        this.btnTaskManager.Visible = (bool) resources.GetObject("btnTaskManager.Visible");

        //

        //DisplayText

        //

        this.DisplayText.AccessibleDescription = (string) resources.GetObject("DisplayText.AccessibleDescription");

        this.DisplayText.AccessibleName = (string) resources.GetObject("DisplayText.AccessibleName");

        this.DisplayText.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("DisplayText.Anchor");

        this.DisplayText.AutoSize = (bool) resources.GetObject("DisplayText.AutoSize");

        this.DisplayText.BackgroundImage = (System.Drawing.Image) resources.GetObject("DisplayText.BackgroundImage");

        this.DisplayText.BulletIndent = (int) resources.GetObject("DisplayText.BulletIndent");

        this.DisplayText.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("DisplayText.Dock");

        this.DisplayText.Enabled = (bool) resources.GetObject("DisplayText.Enabled");

        this.DisplayText.Font = (System.Drawing.Font) resources.GetObject("DisplayText.Font");

        this.DisplayText.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("DisplayText.ImeMode");

        this.DisplayText.Location = (System.Drawing.Point) resources.GetObject("DisplayText.Location");

        this.DisplayText.MaxLength = (int) resources.GetObject("DisplayText.MaxLength");

        this.DisplayText.Multiline = (bool) resources.GetObject("DisplayText.Multiline");

        this.DisplayText.Name = "DisplayText";

        this.DisplayText.RightMargin = (int) resources.GetObject("DisplayText.RightMargin");

        this.DisplayText.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("DisplayText.RightToLeft");

        this.DisplayText.ScrollBars = (System.Windows.Forms.RichTextBoxScrollBars) resources.GetObject("DisplayText.ScrollBars");

        this.DisplayText.Size = (System.Drawing.Size) resources.GetObject("DisplayText.Size");

        this.DisplayText.TabIndex = (int) resources.GetObject("DisplayText.TabIndex");

        this.DisplayText.Text = resources.GetString("DisplayText.Text");

        this.DisplayText.Visible = (bool) resources.GetObject("DisplayText.Visible");

        this.DisplayText.WordWrap = (bool) resources.GetObject("DisplayText.WordWrap");

        this.DisplayText.ZoomFactor = (Single) resources.GetObject("DisplayText.ZoomFactor");

        //

        //btnShellExecute

        //

        this.btnShellExecute.AccessibleDescription = (string) resources.GetObject("btnShellExecute.AccessibleDescription");

        this.btnShellExecute.AccessibleName = (string) resources.GetObject("btnShellExecute.AccessibleName");

        this.btnShellExecute.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnShellExecute.Anchor");

        this.btnShellExecute.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnShellExecute.BackgroundImage");

        this.btnShellExecute.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnShellExecute.Dock");

        this.btnShellExecute.Enabled = (bool) resources.GetObject("btnShellExecute.Enabled");

        this.btnShellExecute.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnShellExecute.FlatStyle");

        this.btnShellExecute.Font = (System.Drawing.Font) resources.GetObject("btnShellExecute.Font");

        this.btnShellExecute.Image = (System.Drawing.Image) resources.GetObject("btnShellExecute.Image");

        this.btnShellExecute.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShellExecute.ImageAlign");

        this.btnShellExecute.ImageIndex = (int) resources.GetObject("btnShellExecute.ImageIndex");

        this.btnShellExecute.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnShellExecute.ImeMode");

        this.btnShellExecute.Location = (System.Drawing.Point) resources.GetObject("btnShellExecute.Location");

        this.btnShellExecute.Name = "btnShellExecute";

        this.btnShellExecute.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnShellExecute.RightToLeft");

        this.btnShellExecute.Size = (System.Drawing.Size) resources.GetObject("btnShellExecute.Size");

        this.btnShellExecute.TabIndex = (int) resources.GetObject("btnShellExecute.TabIndex");

        this.btnShellExecute.Text = resources.GetString("btnShellExecute.Text");

        this.btnShellExecute.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShellExecute.TextAlign");

        this.btnShellExecute.Visible = (bool) resources.GetObject("btnShellExecute.Visible");

        //

        //btnCommandLine

        //

        this.btnCommandLine.AccessibleDescription = (string) resources.GetObject("btnCommandLine.AccessibleDescription");

        this.btnCommandLine.AccessibleName = (string) resources.GetObject("btnCommandLine.AccessibleName");

        this.btnCommandLine.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCommandLine.Anchor");

        this.btnCommandLine.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCommandLine.BackgroundImage");

        this.btnCommandLine.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCommandLine.Dock");

        this.btnCommandLine.Enabled = (bool) resources.GetObject("btnCommandLine.Enabled");

        this.btnCommandLine.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCommandLine.FlatStyle");

        this.btnCommandLine.Font = (System.Drawing.Font) resources.GetObject("btnCommandLine.Font");

        this.btnCommandLine.Image = (System.Drawing.Image) resources.GetObject("btnCommandLine.Image");

        this.btnCommandLine.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCommandLine.ImageAlign");

        this.btnCommandLine.ImageIndex = (int) resources.GetObject("btnCommandLine.ImageIndex");

        this.btnCommandLine.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCommandLine.ImeMode");

        this.btnCommandLine.Location = (System.Drawing.Point) resources.GetObject("btnCommandLine.Location");

        this.btnCommandLine.Name = "btnCommandLine";

        this.btnCommandLine.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCommandLine.RightToLeft");

        this.btnCommandLine.Size = (System.Drawing.Size) resources.GetObject("btnCommandLine.Size");

        this.btnCommandLine.TabIndex = (int) resources.GetObject("btnCommandLine.TabIndex");

        this.btnCommandLine.Text = resources.GetString("btnCommandLine.Text");

        this.btnCommandLine.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCommandLine.TextAlign");

        this.btnCommandLine.Visible = (bool) resources.GetObject("btnCommandLine.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnCommandLine, this.btnShellExecute, this.DisplayText, this.btnTaskManager, this.btnCurrentProcessInfo, this.btnProcessStartInfo, this.btnStartProcess});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

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

        this.ResumeLayout(false);

		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
		this.btnCommandLine.Click +=new EventHandler(btnCommandLine_Click);
		this.btnCurrentProcessInfo.Click +=new EventHandler(CurrentProcessInfo_Click);
		this.btnProcessStartInfo.Click +=new EventHandler(btnProcessStartInfo_Click);
		this.btnShellExecute.Click +=new EventHandler(btnShellExecute_Click);
		this.btnStartProcess.Click +=new EventHandler(btnStartProcess_Click);
		this.btnTaskManager.Click +=new EventHandler(btnTaskManager_Click);

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

    private void CurrentProcessInfo_Click(object sender, System.EventArgs e) 
	{
        // Shows how to retrieve information about the current Process.

        Process curProc = Process.GetCurrentProcess();
        string s = "The total working set of the current process is: " + 
                curProc.WorkingSet.ToString() + Environment.NewLine;

        s += "The minimum working set of the current process is: " + 
                curProc.MinWorkingSet.ToString() + Environment.NewLine;

        s += "The max working set of the current process is: " + 
                curProc.MaxWorkingSet.ToString() + Environment.NewLine;

        s += "The start time of the current process is: " + 
                curProc.StartTime.ToLongTimeString() + Environment.NewLine;

        s += "The processor time used by the current process is: " + 
        curProc.TotalProcessorTime.ToString() + Environment.NewLine;

        DisplayText.Text = s;

    }

    private void btnStartProcess_Click(object sender, System.EventArgs e) 
	{
        // Simple Demonstration of starting a process using the process class.

        Process.Start("notepad.exe");

    }

    private void btnProcessStartInfo_Click(object sender, System.EventArgs e) 
		
	{
        // The StartInfo object allows you to pass additional parameters to your application 
        // before starting it.  In this case the default window state of the application is set.

        ProcessStartInfo startInfo = new ProcessStartInfo("notepad.exe");
        startInfo.WindowStyle = ProcessWindowStyle.Maximized;
        Process.Start(startInfo);

    }

    private void btnTaskManager_Click(object sender, System.EventArgs e) 
	{
        // Using the process class you can get access to additional information such the 
        // modules loaded by a process.  The form shown by this code illustrates this.

        frmTaskManager f = new frmTaskManager();
        f.Show();

    }

    private void btnShellExecute_Click(object sender, System.EventArgs e) 
	{

        if (!System.IO.File.Exists(@"c:\demofile_shell.txt")) {
            StreamWriter sw = new StreamWriter(@"c:\demofile_shell.txt");
            sw.WriteLine("Shell Execute Demo");
            sw.Close();

        }

        // The StartInfo class can also be used to specify that you wish Operating System Shell 
        // to execute the process.  'This means that you can pass file names with extensions that
        // are known by the operating system and the operating system will launch the appropriate
        // application type.

        ProcessStartInfo startInfo = new ProcessStartInfo(@"c:\demofile_shell.txt");

        // The default for UseShellExecute is false. if this is not set an exception would be 
        // thrown when the start method is executed.

        startInfo.UseShellExecute = true;

        Process.Start(startInfo);

    }

    private void btnCommandLine_Click(object sender, System.EventArgs e) 
	{
        // Starts Windows Explorer with two different command line arguments.

        ProcessStartInfo startInfo = new ProcessStartInfo("explorer.exe");

        // Opens a new single-pane Window for the default selection. 
        // This is usually the root of the drive on which Windows is installed. 

        startInfo.Arguments = "/n";

        Process.Start(startInfo);

    }

}

