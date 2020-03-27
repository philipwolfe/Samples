
//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

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

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Button Button4;

    private System.Windows.Forms.Button Button3;

    private System.Windows.Forms.Button Button2;

    private System.Windows.Forms.Button Button1;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.Label1 = new System.Windows.Forms.Label();

        this.Button4 = new System.Windows.Forms.Button();

        this.Button3 = new System.Windows.Forms.Button();

        this.Button2 = new System.Windows.Forms.Button();

        this.Button1 = new System.Windows.Forms.Button();

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

        //Label1

        //

        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", Convert.ToSingle(8.25), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));

        this.Label1.Location = new System.Drawing.Point(97, 14);

        this.Label1.Name = "Label1";

        this.Label1.Size = new System.Drawing.Size(168, 48);

        this.Label1.TabIndex = 9;

        this.Label1.Text = "Select a localized form to enter information about people, including their name and city.";

        //

        //Button4

        //

        this.Button4.Location = new System.Drawing.Point(137, 118);

        this.Button4.Name = "Button4";

        this.Button4.TabIndex = 7;

        this.Button4.Text = "&Italian";

		this.Button4.Click += new EventHandler(Button4_Click);

        //

        //Button3

        //

        this.Button3.Location = new System.Drawing.Point(137, 94);

        this.Button3.Name = "Button3";

        this.Button3.TabIndex = 6;

        this.Button3.Text = "&Spain";

		this.Button3.Click += new EventHandler(Button3_Click);

        //

        //Button2

        //

        this.Button2.Location = new System.Drawing.Point(137, 70);

        this.Button2.Name = "Button2";

        this.Button2.TabIndex = 5;

        this.Button2.Text = "&France";

		this.Button2.Click += new EventHandler(Button2_Click);

        //

        //Button1

        //

        this.Button1.Location = new System.Drawing.Point(137, 142);

        this.Button1.Name = "Button1";

        this.Button1.TabIndex = 8;

        this.Button1.Text = "&US";

		this.Button1.Click += new EventHandler(Button1_Click);

        //

        //frmMain

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(362, 179);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label1, this.Button4, this.Button3, this.Button2, this.Button1});

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        this.Icon = ( System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.MaximizeBox = false;

        this.Menu = this.mnuMain;

        this.Name = "frmMain";

        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        this.Text = "Title Comes from Assembly Info";

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

    private void Button2_Click(object sender, System.EventArgs e) 
	{
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
        frmDataEntry frmData = new frmDataEntry();
        frmData.ShowDialog();
    }

    private void Button3_Click(object sender, System.EventArgs e) 
	{
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
        frmDataEntry frmData = new frmDataEntry();
        frmData.ShowDialog();
    }

    private void Button4_Click(object sender, System.EventArgs e) 
	{
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("it-IT");
        frmDataEntry frmData = new frmDataEntry();
        frmData.ShowDialog();
    }

    private void Button1_Click(object sender, System.EventArgs e) 
	{
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        frmDataEntry frmData = new frmDataEntry();
        frmData.ShowDialog();
    }

}

