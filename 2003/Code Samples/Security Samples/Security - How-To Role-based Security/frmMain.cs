//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Security.Principal;
using System.Security.Permissions;

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

	private System.Windows.Forms.TabControl TabControl1;

	private System.Windows.Forms.TabPage pagWindows;

	private System.Windows.Forms.TextBox txtLogin;

	private System.Windows.Forms.CheckBox ckUsers;

	private System.Windows.Forms.Button btnLogin;

	private System.Windows.Forms.CheckBox ckManagers;

	private System.Windows.Forms.CheckBox ckPowerUsers;

	private System.Windows.Forms.CheckBox ckAdministrator;

	private System.Windows.Forms.TabPage pagDemand;

	private System.Windows.Forms.Label Label1;

	private System.Windows.Forms.TextBox txtDisplay;

	private System.Windows.Forms.Button btnUnion;

	private System.Windows.Forms.Button btnManagerRun;

	private System.Windows.Forms.Button btnPowerRun;

	private System.Windows.Forms.Button btnAdminRun;

	private System.Windows.Forms.Label lblProperties;

	private void InitializeComponent() 
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

		this.mnuMain = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.mnuExit = new System.Windows.Forms.MenuItem();

		this.mnuHelp = new System.Windows.Forms.MenuItem();

		this.mnuAbout = new System.Windows.Forms.MenuItem();

		this.TabControl1 = new System.Windows.Forms.TabControl();

		this.pagWindows = new System.Windows.Forms.TabPage();

		this.lblProperties = new System.Windows.Forms.Label();

		this.txtLogin = new System.Windows.Forms.TextBox();

		this.ckUsers = new System.Windows.Forms.CheckBox();

		this.btnLogin = new System.Windows.Forms.Button();

		this.ckManagers = new System.Windows.Forms.CheckBox();

		this.ckPowerUsers = new System.Windows.Forms.CheckBox();

		this.ckAdministrator = new System.Windows.Forms.CheckBox();

		this.pagDemand = new System.Windows.Forms.TabPage();

		this.Label1 = new System.Windows.Forms.Label();

		this.txtDisplay = new System.Windows.Forms.TextBox();

		this.btnUnion = new System.Windows.Forms.Button();

		this.btnManagerRun = new System.Windows.Forms.Button();

		this.btnPowerRun = new System.Windows.Forms.Button();

		this.btnAdminRun = new System.Windows.Forms.Button();

		this.TabControl1.SuspendLayout();

		this.pagWindows.SuspendLayout();

		this.pagDemand.SuspendLayout();

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

		//

		//TabControl1

		//

		this.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.TabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {this.pagWindows, this.pagDemand});

		this.TabControl1.ItemSize = new System.Drawing.Size(86, 18);

		this.TabControl1.Location = new System.Drawing.Point(25, 14);

		this.TabControl1.Name = "TabControl1";

		this.TabControl1.SelectedIndex = 0;

		this.TabControl1.Size = new System.Drawing.Size(408, 225);

		this.TabControl1.TabIndex = 1;

		//

		//pagWindows

		//

		this.pagWindows.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblProperties, this.txtLogin, this.ckUsers, this.btnLogin, this.ckManagers, this.ckPowerUsers, this.ckAdministrator});

		this.pagWindows.Location = new System.Drawing.Point(4, 22);

		this.pagWindows.Name = "pagWindows";

		this.pagWindows.Size = new System.Drawing.Size(400, 199);

		this.pagWindows.TabIndex = 0;

		this.pagWindows.Text = "WindowsIdentity and WindowsPrincipal";

		//

		//lblProperties

		//

		this.lblProperties.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblProperties.Location = new System.Drawing.Point(192, 17);

		this.lblProperties.Name = "lblProperties";

		this.lblProperties.Size = new System.Drawing.Size(192, 23);

		this.lblProperties.TabIndex = 15;

		this.lblProperties.Text = "WindowsIdentity Properties:";

		this.lblProperties.Visible = false;

		//

		//txtLogin

		//

		this.txtLogin.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.txtLogin.Location = new System.Drawing.Point(192, 40);

		this.txtLogin.Multiline = true;

		this.txtLogin.Name = "txtLogin";

		this.txtLogin.Size = new System.Drawing.Size(200, 144);

		this.txtLogin.TabIndex = 14;

		this.txtLogin.Text = "";

		//

		//ckUsers

		//

		this.ckUsers.AutoCheck = false;

		this.ckUsers.CausesValidation = false;

		this.ckUsers.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.ckUsers.Location = new System.Drawing.Point(16, 88);

		this.ckUsers.Name = "ckUsers";

		this.ckUsers.Size = new System.Drawing.Size(176, 24);

		this.ckUsers.TabIndex = 12;

		this.ckUsers.Text = "Is in Users group";

		//

		//btnLogin

		//

		this.btnLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.btnLogin.Location = new System.Drawing.Point(16, 8);

		this.btnLogin.Name = "btnLogin";

		this.btnLogin.Size = new System.Drawing.Size(160, 23);

		this.btnLogin.TabIndex = 0;

		this.btnLogin.Text = "Retrieve User Information";

		this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//ckManagers

		//

		this.ckManagers.AutoCheck = false;

		this.ckManagers.CausesValidation = false;

		this.ckManagers.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.ckManagers.Location = new System.Drawing.Point(16, 112);

		this.ckManagers.Name = "ckManagers";

		this.ckManagers.Size = new System.Drawing.Size(176, 24);

		this.ckManagers.TabIndex = 13;

		this.ckManagers.Text = "Is in custom Managers group";

		//

		//ckPowerUsers

		//

		this.ckPowerUsers.AutoCheck = false;

		this.ckPowerUsers.CausesValidation = false;

		this.ckPowerUsers.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.ckPowerUsers.Location = new System.Drawing.Point(16, 64);

		this.ckPowerUsers.Name = "ckPowerUsers";

		this.ckPowerUsers.Size = new System.Drawing.Size(176, 24);

		this.ckPowerUsers.TabIndex = 11;

		this.ckPowerUsers.Text = "Is in Power Users group";

		//

		//ckAdministrator

		//

		this.ckAdministrator.AutoCheck = false;

		this.ckAdministrator.CausesValidation = false;

		this.ckAdministrator.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.ckAdministrator.Location = new System.Drawing.Point(16, 40);

		this.ckAdministrator.Name = "ckAdministrator";

		this.ckAdministrator.Size = new System.Drawing.Size(176, 24);

		this.ckAdministrator.TabIndex = 10;

		this.ckAdministrator.Text = "Is in Administrators group";

		//

		//pagDemand

		//

		this.pagDemand.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label1, this.txtDisplay, this.btnUnion, this.btnManagerRun, this.btnPowerRun, this.btnAdminRun});

		this.pagDemand.Location = new System.Drawing.Point(4, 22);

		this.pagDemand.Name = "pagDemand";

		this.pagDemand.Size = new System.Drawing.Size(400, 199);

		this.pagDemand.TabIndex = 1;

		this.pagDemand.Text = "Role-Based Demands";

		this.pagDemand.Visible = false;

		//

		//Label1

		//

		this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.Label1.Location = new System.Drawing.Point(16, 16);

		this.Label1.Name = "Label1";

		this.Label1.Size = new System.Drawing.Size(144, 23);

		this.Label1.TabIndex = 17;

		this.Label1.Text = "Click button to run code";

		//

		//txtDisplay

		//

		this.txtDisplay.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.txtDisplay.Location = new System.Drawing.Point(184, 40);

		this.txtDisplay.Multiline = true;

		this.txtDisplay.Name = "txtDisplay";

		this.txtDisplay.Size = new System.Drawing.Size(208, 144);

		this.txtDisplay.TabIndex = 16;

		this.txtDisplay.Text = "";

		//

		//btnUnion

		//

		this.btnUnion.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) 8.25);

		this.btnUnion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

		this.btnUnion.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.btnUnion.Location = new System.Drawing.Point(16, 112);

		this.btnUnion.Name = "btnUnion";

		this.btnUnion.Size = new System.Drawing.Size(152, 23);

		this.btnUnion.TabIndex = 15;

		this.btnUnion.Text = "Power Users or Managers";

		this.btnUnion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//btnManagerRun

		//

		this.btnManagerRun.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) 8.25);

		this.btnManagerRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

		this.btnManagerRun.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.btnManagerRun.Location = new System.Drawing.Point(16, 88);

		this.btnManagerRun.Name = "btnManagerRun";

		this.btnManagerRun.Size = new System.Drawing.Size(152, 23);

		this.btnManagerRun.TabIndex = 13;

		this.btnManagerRun.Text = "Custom Managers";

		this.btnManagerRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//btnPowerRun

		//

		this.btnPowerRun.Font = new System.Drawing.Font("Microsoft Sans Serif",  (float) 8.25);

		this.btnPowerRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

		this.btnPowerRun.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.btnPowerRun.Location = new System.Drawing.Point(16, 64);

		this.btnPowerRun.Name = "btnPowerRun";

		this.btnPowerRun.Size = new System.Drawing.Size(152, 23);

		this.btnPowerRun.TabIndex = 11;

		this.btnPowerRun.Text = "Power Users";

		this.btnPowerRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//btnAdminRun

		//

		this.btnAdminRun.Font = new System.Drawing.Font("Microsoft Sans Serif",(float) 8.25);

		this.btnAdminRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

		this.btnAdminRun.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.btnAdminRun.Location = new System.Drawing.Point(16, 40);

		this.btnAdminRun.Name = "btnAdminRun";

		this.btnAdminRun.Size = new System.Drawing.Size(152, 23);

		this.btnAdminRun.TabIndex = 10;

		this.btnAdminRun.Text = "Administrators";

		this.btnAdminRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//frmMain

		//

		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

		this.ClientSize = new System.Drawing.Size(458, 253);

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.TabControl1});

		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.MaximizeBox = false;

		this.Menu = this.mnuMain;

		this.Name = "frmMain";

		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

		this.Text = "Title Comes from Assembly Info";

		this.TabControl1.ResumeLayout(false);

		this.pagWindows.ResumeLayout(false);

		this.pagDemand.ResumeLayout(false);

		this.ResumeLayout(false);
		this.Load += new EventHandler(frmMain_Load);
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);
		this.mnuExit.Click += new EventHandler(mnuExit_Click);
		this.btnAdminRun.Click += new EventHandler(btnAdminRun_Click);
		this.btnPowerRun.Click += new EventHandler(btnPowerRun_Click);
		this.btnLogin.Click += new EventHandler(btnLogin_Click);
		this.btnManagerRun.Click += new EventHandler(btnManagerRun_Click);
		this.btnUnion.Click += new EventHandler(btnUnion_Click);
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
		this.Close();
	}
	#endregion

	// Declare the WindowsIdentity and WindowsPrincipal objects
	// with class scope so that they can be called by any procedures
	private WindowsIdentity idWindows;
	private WindowsPrincipal prinWindows;

	// Retrieve the computer name 
	private string machName = System.Environment.MachineName;

	private void btnAdminRun_Click(object sender, System.EventArgs e) 
	{
		// Clear Textbox
		this.txtDisplay.Text = string.Empty;

		// The PrincipalPermission object allows security checks against the active
		// principal by passing the user name and the group (or role) name. if you pass
		// null, then all members of the specified role are considered, not individual users.
		// Note that you can't use the WindowsBuiltInRole enumerations here--you must
		// pass a string using the BUILTIN keyword and the Windows group name.
		PrincipalPermission op = new PrincipalPermission(null, @"BUILTIN\Administrators");

		// Placing the security Demand in a try {-catch block allows you to gracefully
		// handle the security exception that will be thrown if the current user is not
		// a member of the specified group.

		try 
		{
			op.Demand();
			frmProtected frm = new frmProtected();
			frm.Show();

			frm.txtProtected.Text = string.Format("Demand succeeded.{0}User is a member of the Administrators group.", Environment.NewLine);
		}
		catch (System.Security.SecurityException ex)
		{
			// The catch block handles the exception thrown if someone who is not a member
			// of the Administrators group tries to run the code. A message is displayed in
			// the TextBox control on the form.
			txtDisplay.Text = string.Format("Security Exception:{0}{1}{2}Not a member of the Administrators group.", Environment.NewLine, ex.Message, Environment.NewLine);
		}
	}

	private void btnLogin_Click(object sender, System.EventArgs e) 
	{
		// Create a WindowsIdentity object for the current user 
		// using the GetCurrent method 
		idWindows = WindowsIdentity.GetCurrent();

		// Create a WindowsPrincipal object based
		// on the WindowsIdentity object. The WindowsPrincipal
		// object contains the current user's Group membership.
		prinWindows = new WindowsPrincipal(idWindows);

		// Set the Checked property of each Checkbox control
		// based on whether the user is a member of a specific role. 
		// The WindowsBuiltInRole has enumerations for the built-in roles.
		// Note that these enumerations are not spelled exactly the same as
		// the Windows groups they represent. Instead of using the enumerations,
		// you may use the BUILTIN keyword with the group name, which must
		// be spelled the same way it is in Windows. For example, the
		// enumeration WindowsBuildInRole.Administrator would be passed
		// "BUILTIN\Administrators":
		//   ckAdministrator.Checked = _
		//    prinWindows.IsInRole("BUILTIN\Administrators")

		ckAdministrator.Checked = prinWindows.IsInRole(WindowsBuiltInRole.Administrator);
		ckPowerUsers.Checked = prinWindows.IsInRole(WindowsBuiltInRole.PowerUser);
		ckUsers.Checked = prinWindows.IsInRole(WindowsBuiltInRole.User);

		// The machine name is needed to work with custom
		// group names. 
		// if a custom Managers group does not exist,
		// the CheckBox will not be checked and no exception
		// will occur.

		ckManagers.Checked = prinWindows.IsInRole(machName + @"\Managers");
		
		// Display the WindowsIdentity properties 
		txtLogin.AppendText(string.Format("Name:  {0}{1}", idWindows.Name, Environment.NewLine));
		txtLogin.AppendText(string.Format("AuthenticationType:  {0}{1}", idWindows.AuthenticationType, Environment.NewLine));
		txtLogin.AppendText(string.Format("IsAuthenticated:  {0}{1}", idWindows.IsAuthenticated, Environment.NewLine));
		txtLogin.AppendText(string.Format("IsAnonymous:  {0}{1}", idWindows.IsAnonymous, Environment.NewLine));
		txtLogin.AppendText(string.Format("IsGuest:  {0}{1}", idWindows.IsGuest, Environment.NewLine));
		txtLogin.AppendText(string.Format("IsSystem:  {0}{1}", idWindows.IsSystem, Environment.NewLine));
		txtLogin.AppendText(string.Format("Token:  {0}{1}", idWindows.Token, Environment.NewLine));

		lblProperties.Visible = true;
	}

	private void btnManagerRun_Click(object sender, System.EventArgs e)
	{
		// Clear Textbox
		txtDisplay.Text = string.Empty;

		// The MachineName is required for custom groups. if the user is not a member of the 
		// group, or if the group does not exist, then a security exception will be thrown
		// and the Demand will fail.
		PrincipalPermission op = new PrincipalPermission(null, machName + @"\Managers");

		try 
		{
			op.Demand();
			frmProtected frm = new frmProtected();
			frm.Show();

			frm.txtProtected.Text = string.Format("Demand succeeded.{0}User is a member of the Managers group.", Environment.NewLine);
		}
		catch(System.Security.SecurityException ex)
		{
			txtDisplay.Text = string.Format("Security Exception:{0}{1}{2}Not a member of the Managers group.", Environment.NewLine, ex.Message, Environment.NewLine);
		}
	}

	private void btnPowerRun_Click(object sender, System.EventArgs e)
	{
		// Clear Textbox
		txtDisplay.Text = string.Empty;

		// The Power Users group is also a built-in group. 
		PrincipalPermission op = new PrincipalPermission(null, @"BUILTIN\PowerUsers");

		try 
		{
			op.Demand();
			frmProtected frm = new frmProtected();
			frm.Show();
			frm.txtProtected.Text = string.Format("Demand succeeded.{0}User is a member of the Power Users group.", Environment.NewLine);
		}
		catch (System.Security.SecurityException ex)
		{
			txtDisplay.Text = string.Format("Security Exception:{0}{1}{2}Not a member of the Power Users group.", Environment.NewLine, ex.Message, Environment.NewLine);
		}
	}

	private void btnUnion_Click(object sender, System.EventArgs e)
	{
		// Clear Textbox
		txtDisplay.Text = string.Empty;

		// You can create a Demand that checks for multiple groups by using the Union method.
		// This example requires that the user be a member of the built-in Power Users group
		// or the custom Managers group. if the user is not a member of either one, a security
		// exception will be thrown.

		// Instantiate PrincipalPermission objects for PowerUsers and Managers
		PrincipalPermission opPower = new PrincipalPermission(null, @"BUILTIN\PowerUsers");
		PrincipalPermission opMgr = new PrincipalPermission(null, machName + @"\Managers");

		// Use the Union operator to combine Managers and Power Users.
		try 
		{
			opPower.Union(opMgr).Demand();
			frmProtected frm = new frmProtected();
			frm.Show();
			frm.txtProtected.Text = string.Format("Demand succeeded.{0}User is a member of the Power Users or the Managers group.", Environment.NewLine);

			// An exception will be thrown if the user belongs to neither group.
		}
		catch(System.Security.SecurityException ex)
		{
			txtDisplay.Text = string.Format("Security Exception:{0}{1}{2}Not a member of Managers or Power Users.", Environment.NewLine, ex.Message, Environment.NewLine);
		}
	}

	private void frmMain_Load(object sender, System.EventArgs e) 
	{
		// Setting the PrincipalPolicy to WindowsPrincipal specifies how principal 
		// and identity objects should be attached to a thread if the thread 
		// attempts to bind to a principal. In this case, we set the PrincipalPolicy 
		// enumeration to WindowsPrincipal, which maps operating system groups to roles.
		// This statement is needed for role-based security demands.
		AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
	}
}