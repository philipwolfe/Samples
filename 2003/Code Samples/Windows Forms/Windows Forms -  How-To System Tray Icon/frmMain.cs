//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;

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

    private System.Windows.Forms.MenuItem mnuCurrentTimeZone;

    private System.Windows.Forms.MenuItem mnuTimeSinceReboot;

    private System.Windows.Forms.MenuItem mnuFrameworkVersion;

    private System.Windows.Forms.MenuItem mnuCurrentOSVersion;

    private System.Windows.Forms.MenuItem mnuExitApp;

    private System.Windows.Forms.MenuItem mnuCurrentDate;

    private System.Windows.Forms.ContextMenu mnuCtx;

    private System.Windows.Forms.NotifyIcon ntfSystemInfo;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Button btnTray;

    private void InitializeComponent() 
	{
        this.components = new System.ComponentModel.Container();

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.ntfSystemInfo = new System.Windows.Forms.NotifyIcon(this.components);

        this.mnuCtx = new System.Windows.Forms.ContextMenu();

        this.mnuCurrentDate = new System.Windows.Forms.MenuItem();

        this.mnuCurrentTimeZone = new System.Windows.Forms.MenuItem();

        this.mnuTimeSinceReboot = new System.Windows.Forms.MenuItem();

        this.mnuFrameworkVersion = new System.Windows.Forms.MenuItem();

        this.mnuCurrentOSVersion = new System.Windows.Forms.MenuItem();

        this.mnuExitApp = new System.Windows.Forms.MenuItem();

        this.Label1 = new System.Windows.Forms.Label();

        this.btnTray = new System.Windows.Forms.Button();

        this.Label2 = new System.Windows.Forms.Label();

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

        //ntfSystemInfo
		this.ntfSystemInfo.DoubleClick+=new EventHandler(ntfSystemInfo_DoubleClick);

        //

        this.ntfSystemInfo.ContextMenu = this.mnuCtx;

        this.ntfSystemInfo.Icon = (System.Drawing.Icon) resources.GetObject("ntfSystemInfo.Icon");

        this.ntfSystemInfo.Text = resources.GetString("ntfSystemInfo.Text");

        this.ntfSystemInfo.Visible = (bool) resources.GetObject("ntfSystemInfo.Visible");

        //

        //mnuCtx

        //

        this.mnuCtx.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuCurrentDate, this.mnuCurrentTimeZone, this.mnuTimeSinceReboot, this.mnuFrameworkVersion, this.mnuCurrentOSVersion, this.mnuExitApp});

        this.mnuCtx.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("mnuCtx.RightToLeft");

        //

        //mnuCurrentDate

        //

        this.mnuCurrentDate.Enabled = (bool) resources.GetObject("mnuCurrentDate.Enabled");

        this.mnuCurrentDate.Index = 0;

        this.mnuCurrentDate.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuCurrentDate.Shortcut");

        this.mnuCurrentDate.ShowShortcut = (bool) resources.GetObject("mnuCurrentDate.ShowShortcut");

        this.mnuCurrentDate.Text = resources.GetString("mnuCurrentDate.Text");

        this.mnuCurrentDate.Visible = (bool) resources.GetObject("mnuCurrentDate.Visible");
		this.mnuCurrentDate.Click += new EventHandler(mnuCurrentDate_Click);
        //

        //mnuCurrentTimeZone

        //

        this.mnuCurrentTimeZone.Enabled = (bool) resources.GetObject("mnuCurrentTimeZone.Enabled");

        this.mnuCurrentTimeZone.Index = 1;

        this.mnuCurrentTimeZone.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuCurrentTimeZone.Shortcut");

        this.mnuCurrentTimeZone.ShowShortcut = (bool) resources.GetObject("mnuCurrentTimeZone.ShowShortcut");

        this.mnuCurrentTimeZone.Text = resources.GetString("mnuCurrentTimeZone.Text");

        this.mnuCurrentTimeZone.Visible = (bool) resources.GetObject("mnuCurrentTimeZone.Visible");
		this.mnuCurrentTimeZone.Click += new EventHandler(mnuCurrentTimeZone_Click);
        //

        //mnuTimeSinceReboot

        //

        this.mnuTimeSinceReboot.Enabled = (bool) resources.GetObject("mnuTimeSinceReboot.Enabled");

        this.mnuTimeSinceReboot.Index = 2;

        this.mnuTimeSinceReboot.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuTimeSinceReboot.Shortcut");

        this.mnuTimeSinceReboot.ShowShortcut = (bool) resources.GetObject("mnuTimeSinceReboot.ShowShortcut");

        this.mnuTimeSinceReboot.Text = resources.GetString("mnuTimeSinceReboot.Text");

        this.mnuTimeSinceReboot.Visible = (bool) resources.GetObject("mnuTimeSinceReboot.Visible");
		this.mnuTimeSinceReboot.Click += new EventHandler(mnuTimeSinceReboot_Click);
        //

        //mnuFrameworkVersion

        //

        this.mnuFrameworkVersion.Enabled = (bool) resources.GetObject("mnuFrameworkVersion.Enabled");

        this.mnuFrameworkVersion.Index = 3;

        this.mnuFrameworkVersion.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuFrameworkVersion.Shortcut");

        this.mnuFrameworkVersion.ShowShortcut = (bool) resources.GetObject("mnuFrameworkVersion.ShowShortcut");

        this.mnuFrameworkVersion.Text = resources.GetString("mnuFrameworkVersion.Text");

        this.mnuFrameworkVersion.Visible = (bool) resources.GetObject("mnuFrameworkVersion.Visible");
		this.mnuFrameworkVersion.Click += new EventHandler(mnuFrameworkVersion_Click);
        //

        //mnuCurrentOSVersion

        //

        this.mnuCurrentOSVersion.Enabled = (bool) resources.GetObject("mnuCurrentOSVersion.Enabled");

        this.mnuCurrentOSVersion.Index = 4;

        this.mnuCurrentOSVersion.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuCurrentOSVersion.Shortcut");

        this.mnuCurrentOSVersion.ShowShortcut = (bool) resources.GetObject("mnuCurrentOSVersion.ShowShortcut");

        this.mnuCurrentOSVersion.Text = resources.GetString("mnuCurrentOSVersion.Text");

        this.mnuCurrentOSVersion.Visible = (bool) resources.GetObject("mnuCurrentOSVersion.Visible");
		this.mnuCurrentOSVersion.Click += new EventHandler(mnuCurrentOSVersion_Click);
        //

        //mnuExitApp

        //

        this.mnuExitApp.Enabled = (bool) resources.GetObject("mnuExitApp.Enabled");

        this.mnuExitApp.Index = 5;

        this.mnuExitApp.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuExitApp.Shortcut");

        this.mnuExitApp.ShowShortcut = (bool) resources.GetObject("mnuExitApp.ShowShortcut");

        this.mnuExitApp.Text = resources.GetString("mnuExitApp.Text");

        this.mnuExitApp.Visible = (bool) resources.GetObject("mnuExitApp.Visible");
		this.mnuExitApp.Click += new EventHandler(mnuExitApp_Click);
        //

        //Label1

        //

        this.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription");

        this.Label1.AccessibleName = resources.GetString("Label1.AccessibleName");

        this.Label1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label1.Anchor");

        this.Label1.AutoSize = (bool) resources.GetObject("Label1.AutoSize");

        this.Label1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label1.Dock");

        this.Label1.Enabled = (bool) resources.GetObject("Label1.Enabled");

        this.Label1.Font = (System.Drawing.Font) resources.GetObject("Label1.Font");

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

        //btnTray

        //

        this.btnTray.AccessibleDescription = resources.GetString("btnTray.AccessibleDescription");

        this.btnTray.AccessibleName = resources.GetString("btnTray.AccessibleName");

        this.btnTray.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnTray.Anchor");

        this.btnTray.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnTray.BackgroundImage");

        this.btnTray.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnTray.Dock");

        this.btnTray.Enabled = (bool) resources.GetObject("btnTray.Enabled");

        this.btnTray.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnTray.FlatStyle");

        this.btnTray.Font = (System.Drawing.Font) resources.GetObject("btnTray.Font");

        this.btnTray.Image = (System.Drawing.Image) resources.GetObject("btnTray.Image");

        this.btnTray.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnTray.ImageAlign");

        this.btnTray.ImageIndex = (int) resources.GetObject("btnTray.ImageIndex");

        this.btnTray.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnTray.ImeMode");

        this.btnTray.Location = (System.Drawing.Point) resources.GetObject("btnTray.Location");

        this.btnTray.Name = "btnTray";

        this.btnTray.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnTray.RightToLeft");

        this.btnTray.Size = (System.Drawing.Size) resources.GetObject("btnTray.Size");

        this.btnTray.TabIndex = (int) resources.GetObject("btnTray.TabIndex");

        this.btnTray.Text = resources.GetString("btnTray.Text");

        this.btnTray.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnTray.TextAlign");

        this.btnTray.Visible = (bool) resources.GetObject("btnTray.Visible");
		this.btnTray.Click += new EventHandler(btnTray_Click);

        //

        //Label2

        //

        this.Label2.AccessibleDescription = resources.GetString("Label2.AccessibleDescription");

        this.Label2.AccessibleName = resources.GetString("Label2.AccessibleName");

        this.Label2.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label2.Anchor");

        this.Label2.AutoSize = (bool) resources.GetObject("Label2.AutoSize");

        this.Label2.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label2.Dock");

        this.Label2.Enabled = (bool) resources.GetObject("Label2.Enabled");

        this.Label2.Font = (System.Drawing.Font) resources.GetObject("Label2.Font");

        this.Label2.Image = (System.Drawing.Image) resources.GetObject("Label2.Image");

        this.Label2.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label2.ImageAlign");

        this.Label2.ImageIndex = (int) resources.GetObject("Label2.ImageIndex");

        this.Label2.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label2.ImeMode");

        this.Label2.Location = (System.Drawing.Point) resources.GetObject("Label2.Location");

        this.Label2.Name = "Label2";

        this.Label2.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label2.RightToLeft");

        this.Label2.Size = (System.Drawing.Size) resources.GetObject("Label2.Size");

        this.Label2.TabIndex = (int) resources.GetObject("Label2.TabIndex");

        this.Label2.Text = resources.GetString("Label2.Text");

        this.Label2.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label2.TextAlign");

        this.Label2.Visible = (bool) resources.GetObject("Label2.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label2, this.btnTray, this.Label1});

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

        this.ResumeLayout(false);
		this.Load += new System.EventHandler(frmMain_Load);
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
        Shutdown();
	}
#endregion

    private void btnExit_Click(object sender, System.EventArgs e)
	{
        Shutdown();
    }

    private void btnTray_Click(object sender, System.EventArgs e)
	{
        // Hide the main form, as a program running as a tray icon doesn't typically 
        // have a visible form.
        this.Hide();
        ntfSystemInfo.Visible = true;
        ntfSystemInfo.Text = "System Information";
    }

	private void frmMain_Load(object sender, System.EventArgs e) 
	{
        // Make sure that the tray icon doesn't appear until the user clicks Start.
        // Otherwise the tray icon will be visible at the same time as the main form.
        ntfSystemInfo.Visible = false;
    }

    private void mnuCurrentOSVersion_Click(object sender, System.EventArgs e) 
	{
        // Grab the OS Information.  Outputs the Build, Major, Minor, and Revision 
        // Information() for the current OS.  This information can also be accessed 
        // individually via properties.  Eliminates the need to make API calls for 
        // some of this information.
        MessageBox.Show("OS Version: " + Environment.OSVersion.ToString(), "Operating System", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void mnuCurrentDate_Click(object sender, System.EventArgs e) 
	{
        // Displays the current Date.
        MessageBox.Show("Today's Date is: " + DateTime.Now.ToLongDateString(), "Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void mnuCurrentTimeZone_Click(object sender, System.EventArgs e) 
	{
        // Using the TimeZone class display the name of the user's current timezone.  
        // The(Time Zone) class can also be used to determine if the user's location 
        // is currently using daylight savings time as well as the time that daylight 
        // savings time is active for a given time zone.

		if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(DateTime.Now)) 
		{
			MessageBox.Show("The current time zone is: " + TimeZone.CurrentTimeZone.DaylightName, "Time Zone", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		else 
		{
			MessageBox.Show("The current time zone is: " + TimeZone.CurrentTimeZone.StandardName, "Time Zone", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
    }

    private void mnuExitApp_Click(object sender, System.EventArgs e)
	{
        Shutdown();
    }

    private void mnuFrameworkVersion_Click(object sender, System.EventArgs e) 
	{
        // Grab the current .NET Framework Version.  Outputs the Build, Major, 
        // Minor information. This information can also be accessed individually 
        // by properties.
        MessageBox.Show("Framework Version: " + Environment.Version.ToString(), ".NET Framework Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
	}

    private void mnuTimeSinceReboot_Click(object sender, System.EventArgs e)
	{
        // Displays the amount of time that the machine has been up since last being rebooted.
        // The time retrieved from TickCount is in Milliseconds.  This is converted to minutes.
        double timeSinceLastRebootMinutes = ((Environment.TickCount / 1000) / 60);

        MessageBox.Show("It has been : " + timeSinceLastRebootMinutes.ToString() + " minutes since your last reboot.", "Last Reboot", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ntfSystemInfo_DoubleClick(object sender, System.EventArgs e)
	{
        // When the user double-clicks the tray icon, display the main form again.
        // Also, make the tray icon disappear while the form is visible.
        ntfSystemInfo.Visible = false;
        this.Show();
    }

    protected void Shutdown()
	{
		// It's a good idea to make the system tray icon invisible before ending
        // the application, otherwise, it can linger in the tray when the application
        // is no longer running.

        ntfSystemInfo.Visible = false;
        Application.Exit();
    }
}