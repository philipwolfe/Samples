//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using Microsoft.Win32;

public class frmMain: System.Windows.Forms.Form 
{
	#region " Windows Form Designer generated code "

	public frmMain() 
	{
		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing) 
	{
		if (disposing) 
		{
			if (components != null) 
			{
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
	private System.Windows.Forms.MainMenu mnuMain ;
	private System.Windows.Forms.MenuItem mnuFile;
	private System.Windows.Forms.MenuItem mnuExit;
	private System.Windows.Forms.MenuItem mnuHelp;
	private System.Windows.Forms.MenuItem mnuAbout;
	private System.Windows.Forms.Button btnClear;
	private System.Windows.Forms.ListBox lstResults;
	private System.Windows.Forms.CheckBox chkFontChanges;
	private System.Windows.Forms.CheckBox chkUserPreferences;
	private System.Windows.Forms.CheckBox chkPowerMode;
	private System.Windows.Forms.CheckBox chkTimeChanges;
	private System.Windows.Forms.CheckBox chkScreenChanges;

	private void InitializeComponent() 
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
	
		this.mnuMain = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.mnuExit = new System.Windows.Forms.MenuItem();

		this.mnuHelp = new System.Windows.Forms.MenuItem();

		this.mnuAbout = new System.Windows.Forms.MenuItem();

		this.btnClear = new System.Windows.Forms.Button();

		this.lstResults = new System.Windows.Forms.ListBox();

		this.chkFontChanges = new System.Windows.Forms.CheckBox();

		this.chkUserPreferences = new System.Windows.Forms.CheckBox();

		this.chkPowerMode = new System.Windows.Forms.CheckBox();

		this.chkTimeChanges = new System.Windows.Forms.CheckBox();

		this.chkScreenChanges = new System.Windows.Forms.CheckBox();

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

		//btnClear

		//

		this.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);

		this.btnClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.btnClear.Location = new System.Drawing.Point(448, 8);

		this.btnClear.Name = "btnClear";

		this.btnClear.TabIndex = 21;

		this.btnClear.Text = "&Clear";
		this.btnClear.Click += new EventHandler(btnClear_Click);

		//

		//lstResults

		//

		this.lstResults.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lstResults.IntegralHeight = false;

		this.lstResults.Location = new System.Drawing.Point(232, 8);

		this.lstResults.Name = "lstResults";

		this.lstResults.Size = new System.Drawing.Size(208, 123);

		this.lstResults.TabIndex = 20;

		//

		//chkFontChanges

		//

		this.chkFontChanges.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.chkFontChanges.Location = new System.Drawing.Point(8, 104);

		this.chkFontChanges.Name = "chkFontChanges";

		this.chkFontChanges.Size = new System.Drawing.Size(224, 24);

		this.chkFontChanges.TabIndex = 19;

		this.chkFontChanges.Text = "Handle Installed Font Changes";
		this.chkFontChanges.CheckedChanged += new EventHandler(chkFontChanges_CheckedChanged);

		//

		//chkUserPreferences

		//

		this.chkUserPreferences.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.chkUserPreferences.Location = new System.Drawing.Point(8, 80);

		this.chkUserPreferences.Name = "chkUserPreferences";

		this.chkUserPreferences.Size = new System.Drawing.Size(224, 24);

		this.chkUserPreferences.TabIndex = 18;

		this.chkUserPreferences.Text = "Handle User Preference Changes";
		this.chkUserPreferences.CheckedChanged += new EventHandler(chkUserPreferences_CheckedChanged);
		//

		//chkPowerMode

		//

		this.chkPowerMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.chkPowerMode.Location = new System.Drawing.Point(8, 56);

		this.chkPowerMode.Name = "chkPowerMode";

		this.chkPowerMode.Size = new System.Drawing.Size(224, 24);

		this.chkPowerMode.TabIndex = 17;

		this.chkPowerMode.Text = "Handle Power Mode Changes";
		this.chkPowerMode.CheckedChanged += new EventHandler(chkPowerMode_CheckedChanged);

		//

		//chkTimeChanges

		//

		this.chkTimeChanges.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.chkTimeChanges.Location = new System.Drawing.Point(8, 32);

		this.chkTimeChanges.Name = "chkTimeChanges";

		this.chkTimeChanges.Size = new System.Drawing.Size(224, 24);

		this.chkTimeChanges.TabIndex = 16;

		this.chkTimeChanges.Text = "Handle Time Changes";
		this.chkTimeChanges.CheckedChanged += new EventHandler(chkTimeChanges_CheckedChanged);
		//

		//chkScreenChanges

		//

		this.chkScreenChanges.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.chkScreenChanges.Location = new System.Drawing.Point(8, 8);

		this.chkScreenChanges.Name = "chkScreenChanges";

		this.chkScreenChanges.Size = new System.Drawing.Size(224, 24);

		this.chkScreenChanges.TabIndex = 15;

		this.chkScreenChanges.Text = "Handle Screen Changes";
		this.chkScreenChanges.CheckedChanged += new EventHandler(chkScreenChanges_CheckedChanged);
		//

		//frmMain

		//

		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

		this.ClientSize = new System.Drawing.Size(530, 161);

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnClear, this.lstResults, this.chkFontChanges, this.chkUserPreferences, this.chkPowerMode, this.chkTimeChanges, this.chkScreenChanges});

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.MaximizeBox = false;

		this.Menu = this.mnuMain;

		this.MinimumSize = new System.Drawing.Size(538, 192);

		this.Name = "frmMain";

		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

		this.Text = "Title Comes from Assembly Info";

		this.ResumeLayout(false);
		this.Load += new EventHandler(frmMain_Load);
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
	private void mnuExit_Click(object sender, System.EventArgs e) 
	{
		// Close the current form
		this.Close();
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

	#region " Form Load "
	private void frmMain_Load(object sender, System.EventArgs e) 
	{
		// So that we only need to set the title of the application once,
		// we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
		// to read the AssemblyTitle attribute.

		AssemblyInfo ainfo = new AssemblyInfo();

		this.Text = ainfo.Title;
		this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
	}
	#endregion

	private void btnClear_Click(object sender, System.EventArgs e)
	{
		// Clear all the items from the list box. 
		lstResults.Items.Clear();
	}

	private void chkFontChanges_CheckedChanged(object sender, System.EventArgs e)
	{
		if (chkFontChanges.Checked)
		{			
			SystemEvents.InstalledFontsChanged += new EventHandler(FontHandler);
		}
		else 
		{
			SystemEvents.InstalledFontsChanged -= new EventHandler(FontHandler);
		}
	}

	private void chkPowerMode_CheckedChanged(object sender, System.EventArgs e)
	{
		if (chkPowerMode.Checked) 
		{	
			SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(PowerHandler);
		}
		else
		{	
			SystemEvents.PowerModeChanged -= new PowerModeChangedEventHandler(PowerHandler);
        }
    }

    private void chkScreenChanges_CheckedChanged(object sender, System.EventArgs e)
	{
		if (chkScreenChanges.Checked)
		{
			SystemEvents.DisplaySettingsChanged += new EventHandler(ScreenHandler);
		}
        else 
		{
			SystemEvents.DisplaySettingsChanged -= new EventHandler(ScreenHandler);
		}
    }

    private void chkTimeChanges_CheckedChanged(object sender, System.EventArgs e)
	{
        if (chkTimeChanges.Checked)
		{
            SystemEvents.TimeChanged += new EventHandler(TimeHandler);
		}
        else 
		{
            SystemEvents.TimeChanged -= new EventHandler(TimeHandler);
        }
    }

    private void chkUserPreferences_CheckedChanged(object sender, System.EventArgs e)
	{
        if (chkUserPreferences.Checked) 
		{
            SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(PreferenceChangedHandler);
		}
        else 
		{
            SystemEvents.UserPreferenceChanged -= new UserPreferenceChangedEventHandler(PreferenceChangedHandler);
        }
    }

    private void AddToList(string Text)
	{
        // Add an item to the list box on the form.
        lstResults.Items.Insert(0, Text);
    }

    private void FontHandler(object sender, EventArgs e)
	{
        // Use the InstalledFontCollection class to determine the list
        // of installed fonts.
        AddToList("Installed fonts changed.");
    }

    private void PowerHandler(object sender, PowerModeChangedEventArgs e)
	{
        // e.Mode returns one of Microsoft.Win32.PowerModes.Resume, StatusChange, Suspend.
        // You'll get StatusChange on most changes (changing from power to battery,
        // battery power running out, and so on.
        AddToList("Power changed to: " + e.Mode.ToString());
    }

    private void PreferenceChangedHandler(object sender, UserPreferenceChangedEventArgs e)
	{
        // e.Category returns one of Microsoft.Win32.UserPreferenceCategory
        // enumeration. Values include Accessibility, Color, Desktop, and so on.
        AddToList("You changed a setting: " + e.Category.ToString());
    }

    private void ScreenHandler(object sender, EventArgs e)
	{
        // Use the Screen class to retrieve information
        // about the screen settings.

        AddToList("Screen resolution changed");
    }

    private void TimeHandler(object sender, EventArgs e)
	{
        AddToList("System time changed");
    }
}

