//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Collections;


public class frmMain:System.Windows.Forms.Form 
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}
#region " Windows Form Designer generated code "

	public frmMain() 
	{

		//This call is required by the Windows Designer.

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

	//Do ! modify it using the code editor.

	private System.Windows.Forms.MainMenu mnuMain;

	private System.Windows.Forms.MenuItem mnuFile;

	private System.Windows.Forms.MenuItem mnuExit;

	private System.Windows.Forms.MenuItem mnuHelp;

	private System.Windows.Forms.MenuItem mnuAbout;

	private System.Windows.Forms.Button btnRefreshTickCount;

	private System.Windows.Forms.Button btnStackTrace;

	private System.Windows.Forms.Label lblWorkingset;

	private System.Windows.Forms.Label Label21;

	private System.Windows.Forms.Label lblVersion;

	private System.Windows.Forms.Label Label19;

	private System.Windows.Forms.Label lblUserName;

	private System.Windows.Forms.Label Label17;

	private System.Windows.Forms.Label lblUserDomainName;

	private System.Windows.Forms.Label Label15;

	private System.Windows.Forms.Label lblOSVersion;

	private System.Windows.Forms.Label Label13;

	private System.Windows.Forms.Label lblMachineName;

	private System.Windows.Forms.Label Label11;

	private System.Windows.Forms.Label lblTickCount;

	private System.Windows.Forms.Label Label9;

	private System.Windows.Forms.Label lblSystemDirectory;

	private System.Windows.Forms.Label Label7;

	private System.Windows.Forms.Label lblCurrentDirectory;

	private System.Windows.Forms.Label Label5;

	private System.Windows.Forms.Label lblCommandLine;

	private System.Windows.Forms.Label Label3;

	private System.Windows.Forms.ListBox lstLogicalDrives;

	private System.Windows.Forms.Label Label12;

	private System.Windows.Forms.ListBox lstCommandLineArgs;

	private System.Windows.Forms.Label Label10;

	private System.Windows.Forms.Button btnExpand;

	private System.Windows.Forms.Label lblExpandResults;

	private System.Windows.Forms.Label Label8;

	private System.Windows.Forms.Label Label6;

	private System.Windows.Forms.TextBox txtExpand;

	private System.Windows.Forms.NumericUpDown nudExitCode;

	private System.Windows.Forms.Label Label4;

	private System.Windows.Forms.Button btnExit;

	private System.Windows.Forms.Label lblSystemFolder;

	private System.Windows.Forms.Button btnGetSystemFolder;

	private System.Windows.Forms.Label Label1;

	private System.Windows.Forms.Label lblSpecialFolder;

	private System.Windows.Forms.ListBox lstFolders;

	private System.Windows.Forms.Label lblTEMP;

	private System.Windows.Forms.Button btnGetEnvironmentVariable;

	private System.Windows.Forms.Label Label2;

	private System.Windows.Forms.Label lblEnvironmentVariable;

	private System.Windows.Forms.ListBox lstEnvironmentVariables;

    private System.Windows.Forms.ColumnHeader colProperty;

    private System.Windows.Forms.ColumnHeader colValue;

	private System.Windows.Forms.TabControl tabExplore;

	private System.Windows.Forms.GroupBox grpMethods;

	private System.Windows.Forms.TabPage pgeProperties;

	private System.Windows.Forms.TabPage pgeMethods;

	private System.Windows.Forms.TabPage pgeSpecialFolders;

	private System.Windows.Forms.TabPage pgeEnvironmentVariables;

	private System.Windows.Forms.TabPage pgeSystemInformation;

    private System.Windows.Forms.ListView lvwSystemInformation;

    private void InitializeComponent() 
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.tabExplore = new System.Windows.Forms.TabControl();

        this.pgeProperties = new System.Windows.Forms.TabPage();

        this.btnRefreshTickCount = new System.Windows.Forms.Button();

        this.btnStackTrace = new System.Windows.Forms.Button();

        this.lblWorkingset = new System.Windows.Forms.Label();

        this.Label21 = new System.Windows.Forms.Label();

        this.lblVersion = new System.Windows.Forms.Label();

        this.Label19 = new System.Windows.Forms.Label();

        this.lblUserName = new System.Windows.Forms.Label();

        this.Label17 = new System.Windows.Forms.Label();

        this.lblUserDomainName = new System.Windows.Forms.Label();

        this.Label15 = new System.Windows.Forms.Label();

        this.lblOSVersion = new System.Windows.Forms.Label();

        this.Label13 = new System.Windows.Forms.Label();

        this.lblMachineName = new System.Windows.Forms.Label();

        this.Label11 = new System.Windows.Forms.Label();

        this.lblTickCount = new System.Windows.Forms.Label();

        this.Label9 = new System.Windows.Forms.Label();

        this.lblSystemDirectory = new System.Windows.Forms.Label();

        this.Label7 = new System.Windows.Forms.Label();

        this.lblCurrentDirectory = new System.Windows.Forms.Label();

        this.Label5 = new System.Windows.Forms.Label();

        this.lblCommandLine = new System.Windows.Forms.Label();

        this.Label3 = new System.Windows.Forms.Label();

        this.pgeMethods = new System.Windows.Forms.TabPage();

        this.lstLogicalDrives = new System.Windows.Forms.ListBox();

        this.Label12 = new System.Windows.Forms.Label();

        this.lstCommandLineArgs = new System.Windows.Forms.ListBox();

        this.Label10 = new System.Windows.Forms.Label();

        this.grpMethods = new System.Windows.Forms.GroupBox();

        this.btnExpand = new System.Windows.Forms.Button();

        this.lblExpandResults = new System.Windows.Forms.Label();

        this.Label8 = new System.Windows.Forms.Label();

        this.Label6 = new System.Windows.Forms.Label();

        this.txtExpand = new System.Windows.Forms.TextBox();

        this.nudExitCode = new System.Windows.Forms.NumericUpDown();

        this.Label4 = new System.Windows.Forms.Label();

        this.btnExit = new System.Windows.Forms.Button();

        this.pgeSpecialFolders = new System.Windows.Forms.TabPage();

        this.lblSystemFolder = new System.Windows.Forms.Label();

        this.btnGetSystemFolder = new System.Windows.Forms.Button();

        this.Label1 = new System.Windows.Forms.Label();

        this.lblSpecialFolder = new System.Windows.Forms.Label();

        this.lstFolders = new System.Windows.Forms.ListBox();

        this.pgeEnvironmentVariables = new System.Windows.Forms.TabPage();

        this.lblTEMP = new System.Windows.Forms.Label();

        this.btnGetEnvironmentVariable = new System.Windows.Forms.Button();

        this.Label2 = new System.Windows.Forms.Label();

        this.lblEnvironmentVariable = new System.Windows.Forms.Label();

        this.lstEnvironmentVariables = new System.Windows.Forms.ListBox();

        this.pgeSystemInformation = new System.Windows.Forms.TabPage();

        this.lvwSystemInformation = new System.Windows.Forms.ListView();

        this.colProperty = new System.Windows.Forms.ColumnHeader();

        this.colValue = new System.Windows.Forms.ColumnHeader();

        this.tabExplore.SuspendLayout();

        this.pgeProperties.SuspendLayout();

        this.pgeMethods.SuspendLayout();

        this.grpMethods.SuspendLayout();

		((System.ComponentModel.ISupportInitialize) this.nudExitCode).BeginInit();

		
        this.pgeSpecialFolders.SuspendLayout();

        this.pgeEnvironmentVariables.SuspendLayout();

        this.pgeSystemInformation.SuspendLayout();

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
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);

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
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);

        //

        //tabExplore

        //

        this.tabExplore.Controls.AddRange(new System.Windows.Forms.Control[] {this.pgeProperties, this.pgeSpecialFolders, this.pgeMethods, this.pgeEnvironmentVariables, this.pgeSystemInformation});

        this.tabExplore.Dock = System.Windows.Forms.DockStyle.Fill;

        this.tabExplore.ItemSize = new System.Drawing.Size(59, 18);

        this.tabExplore.Name = "tabExplore";

        this.tabExplore.SelectedIndex = 0;

        this.tabExplore.Size = new System.Drawing.Size(554, 308);

        this.tabExplore.TabIndex = 1;

        //

        //pgeProperties

        //

        this.pgeProperties.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnRefreshTickCount, this.btnStackTrace, this.lblWorkingset, this.Label21, this.lblVersion, this.Label19, this.lblUserName, this.Label17, this.lblUserDomainName, this.Label15, this.lblOSVersion, this.Label13, this.lblMachineName, this.Label11, this.lblTickCount, this.Label9, this.lblSystemDirectory, this.Label7, this.lblCurrentDirectory, this.Label5, this.lblCommandLine, this.Label3});

        this.pgeProperties.Location = new System.Drawing.Point(4, 22);

        this.pgeProperties.Name = "pgeProperties";

        this.pgeProperties.Size = new System.Drawing.Size(546, 282);

        this.pgeProperties.TabIndex = 2;

        this.pgeProperties.Text = "Properties";

        //

        //btnRefreshTickCount

        //

        this.btnRefreshTickCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnRefreshTickCount.Location = new System.Drawing.Point(285, 129);

        this.btnRefreshTickCount.Name = "btnRefreshTickCount";

        this.btnRefreshTickCount.TabIndex = 21;

        this.btnRefreshTickCount.Text = "&Refresh";
		this.btnRefreshTickCount.Click +=new EventHandler(btnRefreshTickCount_Click);

        //

        //btnStackTrace

        //

        this.btnStackTrace.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnStackTrace.Location = new System.Drawing.Point(144, 256);

        this.btnStackTrace.Name = "btnStackTrace";

        this.btnStackTrace.Size = new System.Drawing.Size(224, 23);

        this.btnStackTrace.TabIndex = 20;

        this.btnStackTrace.Text = "&Display Current Stack Trace";
		this.btnStackTrace.Click +=new EventHandler(btnStackTrace_Click);

        //

        //lblWorkingSet

        //

        this.lblWorkingset.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblWorkingset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblWorkingset.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblWorkingset.Location = new System.Drawing.Point(144, 224);

        this.lblWorkingset.Name = "lblWorkingSet";

        this.lblWorkingset.Size = new System.Drawing.Size(394, 23);

        this.lblWorkingset.TabIndex = 19;

        this.lblWorkingset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //Label21

        //

        this.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label21.Location = new System.Drawing.Point(8, 224);

        this.Label21.Name = "Label21";

        this.Label21.Size = new System.Drawing.Size(136, 23);

        this.Label21.TabIndex = 18;

        this.Label21.Text = "WorkingSet";

        this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //lblVersion

        //

        this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblVersion.Location = new System.Drawing.Point(144, 200);

        this.lblVersion.Name = "lblVersion";

        this.lblVersion.Size = new System.Drawing.Size(394, 23);

        this.lblVersion.TabIndex = 17;

        this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //Label19

        //

        this.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label19.Location = new System.Drawing.Point(8, 200);

        this.Label19.Name = "Label19";

        this.Label19.Size = new System.Drawing.Size(136, 23);

        this.Label19.TabIndex = 16;

        this.Label19.Text = "Version";

        this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //lblUserName

        //

        this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblUserName.Location = new System.Drawing.Point(144, 176);

        this.lblUserName.Name = "lblUserName";

        this.lblUserName.Size = new System.Drawing.Size(394, 23);

        this.lblUserName.TabIndex = 15;

        this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //Label17

        //

        this.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label17.Location = new System.Drawing.Point(8, 176);

        this.Label17.Name = "Label17";

        this.Label17.Size = new System.Drawing.Size(136, 23);

        this.Label17.TabIndex = 14;

        this.Label17.Text = "UserName";

        this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //lblUserDomainName

        //

        this.lblUserDomainName.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblUserDomainName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblUserDomainName.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblUserDomainName.Location = new System.Drawing.Point(144, 152);

        this.lblUserDomainName.Name = "lblUserDomainName";

        this.lblUserDomainName.Size = new System.Drawing.Size(394, 23);

        this.lblUserDomainName.TabIndex = 13;

        this.lblUserDomainName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //Label15

        //

        this.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label15.Location = new System.Drawing.Point(8, 152);

        this.Label15.Name = "Label15";

        this.Label15.Size = new System.Drawing.Size(136, 23);

        this.Label15.TabIndex = 12;

        this.Label15.Text = "UserDomainName";

        this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //lblOSVersion

        //

        this.lblOSVersion.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblOSVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblOSVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblOSVersion.Location = new System.Drawing.Point(144, 80);

        this.lblOSVersion.Name = "lblOSVersion";

        this.lblOSVersion.Size = new System.Drawing.Size(394, 23);

        this.lblOSVersion.TabIndex = 11;

        this.lblOSVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //Label13

        //

        this.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label13.Location = new System.Drawing.Point(8, 80);

        this.Label13.Name = "Label13";

        this.Label13.Size = new System.Drawing.Size(136, 23);

        this.Label13.TabIndex = 10;

        this.Label13.Text = "OSVersion";

        this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //lblMachineName

        //

        this.lblMachineName.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblMachineName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblMachineName.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblMachineName.Location = new System.Drawing.Point(144, 56);

        this.lblMachineName.Name = "lblMachineName";

        this.lblMachineName.Size = new System.Drawing.Size(394, 23);

        this.lblMachineName.TabIndex = 9;

        this.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //Label11

        //

        this.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label11.Location = new System.Drawing.Point(8, 56);

        this.Label11.Name = "Label11";

        this.Label11.Size = new System.Drawing.Size(136, 23);

        this.Label11.TabIndex = 8;

        this.Label11.Text = "MachineName";

        this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //lblTickCount

        //

        this.lblTickCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblTickCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblTickCount.Location = new System.Drawing.Point(144, 128);

        this.lblTickCount.Name = "lblTickCount";

        this.lblTickCount.Size = new System.Drawing.Size(128, 23);

        this.lblTickCount.TabIndex = 7;

        this.lblTickCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //Label9

        //

        this.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label9.Location = new System.Drawing.Point(8, 128);

        this.Label9.Name = "Label9";

        this.Label9.Size = new System.Drawing.Size(136, 23);

        this.Label9.TabIndex = 6;

        this.Label9.Text = "TickCount";

        this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //lblSystemDirectory

        //

        this.lblSystemDirectory.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblSystemDirectory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblSystemDirectory.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblSystemDirectory.Location = new System.Drawing.Point(144, 104);

        this.lblSystemDirectory.Name = "lblSystemDirectory";

        this.lblSystemDirectory.Size = new System.Drawing.Size(394, 23);

        this.lblSystemDirectory.TabIndex = 5;

        this.lblSystemDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //Label7

        //

        this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label7.Location = new System.Drawing.Point(8, 104);

        this.Label7.Name = "Label7";

        this.Label7.Size = new System.Drawing.Size(136, 23);

        this.Label7.TabIndex = 4;

        this.Label7.Text = "SystemDirectory";

        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //lblCurrentDirectory

        //

        this.lblCurrentDirectory.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblCurrentDirectory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblCurrentDirectory.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblCurrentDirectory.Location = new System.Drawing.Point(144, 32);

        this.lblCurrentDirectory.Name = "lblCurrentDirectory";

        this.lblCurrentDirectory.Size = new System.Drawing.Size(394, 23);

        this.lblCurrentDirectory.TabIndex = 3;

        this.lblCurrentDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //Label5

        //

        this.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label5.Location = new System.Drawing.Point(8, 32);

        this.Label5.Name = "Label5";

        this.Label5.Size = new System.Drawing.Size(136, 23);

        this.Label5.TabIndex = 2;

        this.Label5.Text = "CurrentDirectory";

        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //lblCommandLine

        //

        this.lblCommandLine.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblCommandLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblCommandLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblCommandLine.Location = new System.Drawing.Point(144, 8);

        this.lblCommandLine.Name = "lblCommandLine";

        this.lblCommandLine.Size = new System.Drawing.Size(394, 23);

        this.lblCommandLine.TabIndex = 1;

        this.lblCommandLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //Label3

        //

        this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label3.Location = new System.Drawing.Point(8, 8);

        this.Label3.Name = "Label3";

        this.Label3.Size = new System.Drawing.Size(136, 23);

        this.Label3.TabIndex = 0;

        this.Label3.Text = "CommandLine:";

        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //pgeMethods

        //

        this.pgeMethods.Controls.AddRange(new System.Windows.Forms.Control[] {this.lstLogicalDrives, this.Label12, this.lstCommandLineArgs, this.Label10, this.grpMethods, this.nudExitCode, this.Label4, this.btnExit});

        this.pgeMethods.Location = new System.Drawing.Point(4, 22);

        this.pgeMethods.Name = "pgeMethods";

        this.pgeMethods.Size = new System.Drawing.Size(546, 282);

        this.pgeMethods.TabIndex = 3;

        this.pgeMethods.Text = "Methods";

        this.pgeMethods.Visible = false;

        //

        //lstLogicalDrives

        //

        this.lstLogicalDrives.Location = new System.Drawing.Point(16, 152);

        this.lstLogicalDrives.Name = "lstLogicalDrives";

        this.lstLogicalDrives.Size = new System.Drawing.Size(56, 95);

        this.lstLogicalDrives.TabIndex = 5;

        //

        //Label12

        //

        this.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label12.Location = new System.Drawing.Point(8, 128);

        this.Label12.Name = "Label12";

        this.Label12.Size = new System.Drawing.Size(120, 23);

        this.Label12.TabIndex = 4;

        this.Label12.Text = "GetLogicalDrives";

        //

        //lstCommandLineArgs

        //

        this.lstCommandLineArgs.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lstCommandLineArgs.HorizontalScrollbar = true;

        this.lstCommandLineArgs.Location = new System.Drawing.Point(144, 152);

        this.lstCommandLineArgs.Name = "lstCommandLineArgs";

        this.lstCommandLineArgs.Size = new System.Drawing.Size(386, 95);

        this.lstCommandLineArgs.TabIndex = 7;

        //

        //Label10

        //

        this.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label10.Location = new System.Drawing.Point(136, 128);

        this.Label10.Name = "Label10";

        this.Label10.Size = new System.Drawing.Size(120, 23);

        this.Label10.TabIndex = 6;

        this.Label10.Text = "GetCommandLineArgs";

        //

        //grpMethods

        //

        this.grpMethods.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.grpMethods.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnExpand, this.lblExpandResults, this.Label8, this.Label6, this.txtExpand});

        this.grpMethods.Location = new System.Drawing.Point(8, 40);

        this.grpMethods.Name = "grpMethods";

        this.grpMethods.Size = new System.Drawing.Size(530, 80);

        this.grpMethods.TabIndex = 3;

        this.grpMethods.TabStop = false;

        this.grpMethods.Text = "ExpandEnvironmentVariables";

        //

        //btnExpand

        //

        this.btnExpand.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);

        this.btnExpand.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnExpand.Location = new System.Drawing.Point(410, 16);

        this.btnExpand.Name = "btnExpand";

        this.btnExpand.Size = new System.Drawing.Size(112, 23);

        this.btnExpand.TabIndex = 2;

        this.btnExpand.Text = "&Expand";
		this.btnExpand.Click +=new EventHandler(btnExpand_Click);

        //

        //lblExpandResults

        //

        this.lblExpandResults.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblExpandResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblExpandResults.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblExpandResults.Location = new System.Drawing.Point(104, 48);

        this.lblExpandResults.Name = "lblExpandResults";

        this.lblExpandResults.Size = new System.Drawing.Size(418, 24);

        this.lblExpandResults.TabIndex = 4;

        this.lblExpandResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //Label8

        //

        this.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label8.Location = new System.Drawing.Point(16, 48);

        this.Label8.Name = "Label8";

        this.Label8.Size = new System.Drawing.Size(88, 16);

        this.Label8.TabIndex = 3;

        this.Label8.Text = "Results:";

        //

        //Label6

        //

        this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label6.Location = new System.Drawing.Point(16, 24);

        this.Label6.Name = "Label6";

        this.Label6.Size = new System.Drawing.Size(88, 16);

        this.Label6.TabIndex = 0;

        this.Label6.Text = "Input:";

        //

        //txtExpand

        //

        this.txtExpand.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.txtExpand.Location = new System.Drawing.Point(104, 16);

        this.txtExpand.Name = "txtExpand";

        this.txtExpand.Size = new System.Drawing.Size(298, 20);

        this.txtExpand.TabIndex = 1;

        this.txtExpand.Text = "windir = %windir%";

        //

        //nudExitCode

        //

        this.nudExitCode.Location = new System.Drawing.Point(192, 8);

        this.nudExitCode.Name = "nudExitCode";

        this.nudExitCode.Size = new System.Drawing.Size(40, 20);

        this.nudExitCode.TabIndex = 2;

        //

        //Label4

        //

        this.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label4.Location = new System.Drawing.Point(104, 8);

        this.Label4.Name = "Label4";

        this.Label4.Size = new System.Drawing.Size(88, 23);

        this.Label4.TabIndex = 1;

        this.Label4.Text = "Exit &Code:";

        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        //

        //btnExit

        //

        this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnExit.Location = new System.Drawing.Point(8, 8);

        this.btnExit.Name = "btnExit";

        this.btnExit.Size = new System.Drawing.Size(88, 24);

        this.btnExit.TabIndex = 0;

        this.btnExit.Text = "E&xit";
		this.btnExit.Click +=new EventHandler(btnExit_Click);

        //

        //pgeSpecialFolders

        //

        this.pgeSpecialFolders.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblSystemFolder, this.btnGetSystemFolder, this.Label1, this.lblSpecialFolder, this.lstFolders});

        this.pgeSpecialFolders.Location = new System.Drawing.Point(4, 22);

        this.pgeSpecialFolders.Name = "pgeSpecialFolders";

        this.pgeSpecialFolders.Size = new System.Drawing.Size(546, 282);

        this.pgeSpecialFolders.TabIndex = 0;

        this.pgeSpecialFolders.Text = "Special Folders";

        this.pgeSpecialFolders.Visible = false;

        //

        //lblSystemFolder

        //

        this.lblSystemFolder.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblSystemFolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblSystemFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblSystemFolder.Location = new System.Drawing.Point(224, 168);

        this.lblSystemFolder.Name = "lblSystemFolder";

        this.lblSystemFolder.Size = new System.Drawing.Size(314, 23);

        this.lblSystemFolder.TabIndex = 4;

        this.lblSystemFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //btnGetSystemFolder

        //

        this.btnGetSystemFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnGetSystemFolder.Location = new System.Drawing.Point(224, 144);

        this.btnGetSystemFolder.Name = "btnGetSystemFolder";

        this.btnGetSystemFolder.Size = new System.Drawing.Size(152, 23);

        this.btnGetSystemFolder.TabIndex = 3;

        this.btnGetSystemFolder.Text = "&get {System Folder";
		this.btnGetSystemFolder.Click +=new EventHandler(btnGetSystemFolder_Click);

        //

        //Label1

        //

        this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label1.Location = new System.Drawing.Point(224, 8);

        this.Label1.Name = "Label1";

        this.Label1.Size = new System.Drawing.Size(200, 23);

        this.Label1.TabIndex = 1;

        this.Label1.Text = "Special Folder Path:";

        //

        //lblSpecialFolder

        //

        this.lblSpecialFolder.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblSpecialFolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblSpecialFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblSpecialFolder.Location = new System.Drawing.Point(224, 32);

        this.lblSpecialFolder.Name = "lblSpecialFolder";

        this.lblSpecialFolder.Size = new System.Drawing.Size(314, 96);

        this.lblSpecialFolder.TabIndex = 2;

        //

        //lstFolders

        //

        this.lstFolders.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left);

        this.lstFolders.Location = new System.Drawing.Point(8, 8);

        this.lstFolders.Name = "lstFolders";

        this.lstFolders.Size = new System.Drawing.Size(208, 251);

        this.lstFolders.TabIndex = 0;
		this.lstFolders.SelectedIndexChanged +=new EventHandler(lstFolders_SelectedIndexChanged);

        //

        //pgeEnvironmentVariables

        //

        this.pgeEnvironmentVariables.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblTEMP, this.btnGetEnvironmentVariable, this.Label2, this.lblEnvironmentVariable, this.lstEnvironmentVariables});

        this.pgeEnvironmentVariables.Location = new System.Drawing.Point(4, 22);

        this.pgeEnvironmentVariables.Name = "pgeEnvironmentVariables";

        this.pgeEnvironmentVariables.Size = new System.Drawing.Size(546, 282);

        this.pgeEnvironmentVariables.TabIndex = 1;

        this.pgeEnvironmentVariables.Text = "Environment Variables";

        this.pgeEnvironmentVariables.Visible = false;

        //

        //lblTEMP

        //

        this.lblTEMP.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblTEMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblTEMP.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblTEMP.Location = new System.Drawing.Point(224, 168);

        this.lblTEMP.Name = "lblTEMP";

        this.lblTEMP.Size = new System.Drawing.Size(314, 23);

        this.lblTEMP.TabIndex = 4;

        this.lblTEMP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //btnGetEnvironmentVariable

        //

        this.btnGetEnvironmentVariable.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnGetEnvironmentVariable.Location = new System.Drawing.Point(224, 144);

        this.btnGetEnvironmentVariable.Name = "btnGetEnvironmentVariable";

        this.btnGetEnvironmentVariable.Size = new System.Drawing.Size(152, 23);

        this.btnGetEnvironmentVariable.TabIndex = 3;

        this.btnGetEnvironmentVariable.Text = "&get {TEMP Variable";
		this.btnGetEnvironmentVariable.Click +=new EventHandler(btnGetEnvironmentVariable_Click);

        //

        //Label2

        //

        this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label2.Location = new System.Drawing.Point(224, 8);

        this.Label2.Name = "Label2";

        this.Label2.Size = new System.Drawing.Size(200, 23);

        this.Label2.TabIndex = 1;

        this.Label2.Text = "Environment Variable Value:";

        //

        //lblEnvironmentVariable

        //

        this.lblEnvironmentVariable.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lblEnvironmentVariable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblEnvironmentVariable.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblEnvironmentVariable.Location = new System.Drawing.Point(224, 32);

        this.lblEnvironmentVariable.Name = "lblEnvironmentVariable";

        this.lblEnvironmentVariable.Size = new System.Drawing.Size(314, 96);

        this.lblEnvironmentVariable.TabIndex = 2;

        //

        //lstEnvironmentVariables

        //

        this.lstEnvironmentVariables.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left);

        this.lstEnvironmentVariables.Location = new System.Drawing.Point(8, 8);

        this.lstEnvironmentVariables.Name = "lstEnvironmentVariables";

        this.lstEnvironmentVariables.Size = new System.Drawing.Size(208, 251);

        this.lstEnvironmentVariables.TabIndex = 0;
		this.lstEnvironmentVariables.SelectedIndexChanged +=new EventHandler(lstEnvironmentVariables_SelectedIndexChanged);

        //

        //pgeSystemInformation

        //

        this.pgeSystemInformation.Controls.AddRange(new System.Windows.Forms.Control[] {this.lvwSystemInformation});

        this.pgeSystemInformation.Location = new System.Drawing.Point(4, 22);

        this.pgeSystemInformation.Name = "pgeSystemInformation";

        this.pgeSystemInformation.Size = new System.Drawing.Size(546, 282);

        this.pgeSystemInformation.TabIndex = 4;

        this.pgeSystemInformation.Text = "System Information";

        this.pgeSystemInformation.Visible = false;

        //

        //lvwSystemInformation

        //
		
        this.lvwSystemInformation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.colProperty, this.colValue});

        this.lvwSystemInformation.Dock = System.Windows.Forms.DockStyle.Fill;

        this.lvwSystemInformation.Name = "lvwSystemInformation";

        this.lvwSystemInformation.Size = new System.Drawing.Size(546, 282);

        this.lvwSystemInformation.TabIndex = 0;

        this.lvwSystemInformation.View = System.Windows.Forms.View.Details;
		this.lvwSystemInformation.Resize +=new EventHandler(lvwSystemInformation_Resize);

        //

        //colProperty

        //

        this.colProperty.Text = "Property";

        this.colProperty.Width = 117;

        //

        //colValue

        //

        this.colValue.Text = "Value";

        this.colValue.Width = 341;

        //

        //frmMain

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(554, 308);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.tabExplore});

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.MaximizeBox = false;

        this.Menu = this.mnuMain;

        this.Name = "frmMain";

        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        this.Text = "Title Comes from Assembly Info";

        this.tabExplore.ResumeLayout(false);

        this.pgeProperties.ResumeLayout(false);

        this.pgeMethods.ResumeLayout(false);

        this.grpMethods.ResumeLayout(false);

		((System.ComponentModel.ISupportInitialize) this.nudExitCode).EndInit();

        this.pgeSpecialFolders.ResumeLayout(false);

        this.pgeEnvironmentVariables.ResumeLayout(false);

        this.pgeSystemInformation.ResumeLayout(false);
		this.Load +=new EventHandler(frmEnvironment_Load);

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

#region " enum Handling ";

	private void LoadList(ListBox lst , Type typ)
	{
		lst.DataSource = System.Enum.GetNames(typ);
	}

	private Environment.SpecialFolder GetSpecialFolderFromList() 
	{

		// lstFolders.SelectedItem returns the name of the 
		// special folder. System.Enum.Parse will turn that
		// into an object corresponding to the enumerated value
		// matching the specific text. CType then converts the
		// object into an Environment.SpecialFolder object.
		// This is all required because Option Strict is on.

		//return CType(System.Enum.Parse(typeof(Environment.SpecialFolder),lstFolders.SelectedItem.ToString(),Environment.SpecialFolder);
		return  (Environment.SpecialFolder) System.Enum.Parse(typeof(Environment.SpecialFolder),lstFolders.SelectedItem.ToString());
	}

	private void LoadList(ListBox lst , ICollection ic )
	{

		// This procedure sets the data source 

		// for a list box to be the contents

		// of an object that implements

		// the ICollection interface. You must

		// first copy the contents to something

		// that implements IList (such an array)

		// and then bind to that.

		string[] astrItems =  new string[ic.Count];
		//string[] astrItems =  new string[ic.Count-1];
		ic.CopyTo(astrItems, 0);
		lst.DataSource = astrItems;

	}

#endregion

	private void btnExit_Click(object sender, System.EventArgs e) 
	{

		Environment.Exit((int) nudExitCode.Value);

	}

	private void btnExpand_Click(object sender, System.EventArgs e) 
	{

		lblExpandResults.Text = Environment.ExpandEnvironmentVariables(txtExpand.Text);

	}

	private void btnGetEnvironmentVariable_Click(object sender, System.EventArgs e) 
	{

		lblTEMP.Text = Environment.GetEnvironmentVariable("TEMP");

	}

	private void btnGetSystemFolder_Click(object sender, System.EventArgs e) 
	{

		// if you just want to retrieve a single 
		// special folder path, pass in one of the
		// SpecialFolder enumeration values.
		// GetFolderPath is actually System.Environment.GetFolderPath.
		// See the using statement at the top of this file.

		lblSystemFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.System);

	}

	private void btnRefreshTickCount_Click(object sender, System.EventArgs e) 
	{
		lblTickCount.Text = Environment.TickCount.ToString();

	}

	private void btnStackTrace_Click(object sender, System.EventArgs e)
	{

		try 
		{
		
			MessageBox.Show(Environment.StackTrace,this.Text);
		}
		catch (System.Security.SecurityException exp)
		{
			MessageBox.Show("A security exception occurred." + Environment.NewLine + exp.Message,exp.Source);

		} 
	catch(System.Exception exp) 
{

	MessageBox.Show("An unexpected error occurred accessing the StackTrace." + Environment.NewLine + exp.Message, exp.Source);

}

	}

	private void frmEnvironment_Load(object sender, System.EventArgs e)
	{

		// The LoadList procedure is in 
		// the "enum Handling" region above.
		// It loads a list box  all the 
		// elements of an enumeration. if you're
		// interested, give it a look. You could load
		// the list  items one at a time, but this
		// technique is far simpler.

		LoadList(lstFolders, typeof(Environment.SpecialFolder));

		// LoadList (in the "enum Handling" 
		// region) also loads a list box given
		// an ICollection object. The alternative would be 
		// to loop through all the elements of the collection.

		//LoadList(lstEnvironmentVariables, Environment.GetEnvironmentVariables.Keys);
		LoadList(lstEnvironmentVariables, ((System.Collections.IDictionary) Environment.GetEnvironmentVariables()).Keys);
		
		// Display properties on the Properties tab.
		
		LoadProperties();

		// Set up simple methods.

		RunMethods();

		// Load values from SystemInformation class

		LoadSystemInformation();

	}

	private void lstEnvironmentVariables_SelectedIndexChanged(object sender, System.EventArgs e) 
	{

		// GetEnvironmentVariable is actually 
		// System.Environment.GetEnvironmentVariable.
		// lstEnvironmentVariables contains a list
		// of all the current environment variables.
		// GetEnvironmentVariable returns the value
		// associated  an environment variable.

		lblEnvironmentVariable.Text = Environment.GetEnvironmentVariable(lstEnvironmentVariables.SelectedItem.ToString());

	}

	private void lstFolders_SelectedIndexChanged(object sender, System.EventArgs e) 
	{

		Environment.SpecialFolder sf ;

		// GetSpecialFolderFromList is a method
		// in the hidden "enum Handling" region 
		// above. It returns a member of the
		// Environment.SpecialFolder enumeration, 
		// and is specific to this demonstration.

		sf = GetSpecialFolderFromList();

		// GetFolderPath is a method provided by 
		// the System.Environment namespace.
		// Specifically, you could call the GetFolderPath
		// method like this:
		// YourPath = GetFolderPath(SpecialFolder.Favorites)
		// GetFolderPath is actually System.Environment.GetFolderPath.
		// See the using statement at the top of this file.

		lblSpecialFolder.Text = Environment.GetFolderPath(sf);

	}

    private void lvwSystemInformation_Resize(object sender, System.EventArgs e)
	{

		lvwSystemInformation.Columns[1].Width = lvwSystemInformation.ClientRectangle.Width - lvwSystemInformation.Columns[0].Width;

    }

    private void LoadProperties()
	{

        // This procedure fills in items
        // on the Properties tab. These are
        // most of the properties provided by the 
        // Environment class.

        lblWorkingset.Text = Environment.WorkingSet.ToString();

        lblVersion.Text = Environment.Version.ToString();

        lblUserName.Text = Environment.UserName;

        lblUserDomainName.Text = Environment.UserDomainName;

        lblTickCount.Text = Environment.TickCount.ToString();

        lblSystemDirectory.Text = Environment.SystemDirectory;

        lblOSVersion.Text = Environment.OSVersion.ToString();

        lblMachineName.Text = Environment.MachineName;

        lblCurrentDirectory.Text = Environment.CurrentDirectory;

        lblCommandLine.Text = Environment.CommandLine;

    }

    private void LoadSystemInformation()
	{

        // Add information about the static properties
        // of the SystemInformation class to a ListView control.
        // The text for the item is the name 
        // of the property provided by the 
        // SystemInformation class. The first (and only)
        // subitem is the value of the property.
        // See help on the SystemInformation class
        // for more details about each individual 
        // property.


            lvwSystemInformation.Items.Add("ArrangeDirection").SubItems.Add(SystemInformation.ArrangeDirection.ToString());
    
            lvwSystemInformation.Items.Add("ArrangeStartingPosition").SubItems.Add(SystemInformation.ArrangeStartingPosition.ToString());

            lvwSystemInformation.Items.Add("BootMode").SubItems.Add(SystemInformation.BootMode.ToString());
   
            lvwSystemInformation.Items.Add("Border3DSize").SubItems.Add(SystemInformation.Border3DSize.ToString());

            lvwSystemInformation.Items.Add("BorderSize").SubItems.Add(SystemInformation.BorderSize.ToString());

            lvwSystemInformation.Items.Add("CaptionButtonSize").SubItems.Add(SystemInformation.CaptionButtonSize.ToString());

            lvwSystemInformation.Items.Add("CaptionHeight").SubItems.Add(SystemInformation.CaptionHeight.ToString());

            lvwSystemInformation.Items.Add("ComputerName").SubItems.Add(SystemInformation.ComputerName.ToString());

            lvwSystemInformation.Items.Add("CursorSize").SubItems.Add(SystemInformation.CursorSize.ToString());

            lvwSystemInformation.Items.Add("DbcsEnabled").SubItems.Add(SystemInformation.DbcsEnabled.ToString());

            lvwSystemInformation.Items.Add("DebugOS").SubItems.Add(SystemInformation.DebugOS.ToString());

            lvwSystemInformation.Items.Add("DoubleClickSize").SubItems.Add(SystemInformation.DoubleClickSize.ToString());

            lvwSystemInformation.Items.Add("DoubleClickTime").SubItems.Add(SystemInformation.DoubleClickTime.ToString());

            lvwSystemInformation.Items.Add("DragFullWindows").SubItems.Add(SystemInformation.DragFullWindows.ToString());

            lvwSystemInformation.Items.Add("DragSize").SubItems.Add(SystemInformation.DragSize.ToString());     

            lvwSystemInformation.Items.Add("FixedFrameBorderSize").SubItems.Add(SystemInformation.FixedFrameBorderSize.ToString());

            lvwSystemInformation.Items.Add("FrameBorderSize").SubItems.Add(SystemInformation.FrameBorderSize.ToString());

            lvwSystemInformation.Items.Add("HighContrast").SubItems.Add(SystemInformation.HighContrast.ToString());

            lvwSystemInformation.Items.Add("HorizontalScrollBarArrowWidth").SubItems.Add(SystemInformation.HorizontalScrollBarArrowWidth.ToString());

            lvwSystemInformation.Items.Add("HorizontalScrollBarHeight").SubItems.Add(SystemInformation.HorizontalScrollBarHeight.ToString());

            lvwSystemInformation.Items.Add("HorizontalScrollBarThumbWidth").SubItems.Add(SystemInformation.HorizontalScrollBarThumbWidth.ToString());

            lvwSystemInformation.Items.Add("IconSize").SubItems.Add(SystemInformation.IconSize.ToString());

            lvwSystemInformation.Items.Add("IconSpacingSize").SubItems.Add(SystemInformation.IconSpacingSize.ToString());

            lvwSystemInformation.Items.Add("KanjiWindowHeight").SubItems.Add(SystemInformation.KanjiWindowHeight.ToString());

            lvwSystemInformation.Items.Add("MaxWindowTrackSize").SubItems.Add(SystemInformation.MaxWindowTrackSize.ToString());         

            lvwSystemInformation.Items.Add("MenuButtonSize").SubItems.Add(SystemInformation.MenuButtonSize.ToString());

            lvwSystemInformation.Items.Add("MenuCheckSize").SubItems.Add(SystemInformation.MenuCheckSize.ToString());

            lvwSystemInformation.Items.Add("MenuFont").SubItems.Add(SystemInformation.MenuFont.ToString());

            lvwSystemInformation.Items.Add("MenuHeight").SubItems.Add(SystemInformation.MenuHeight.ToString());

            lvwSystemInformation.Items.Add("MidEastEnabled").SubItems.Add(SystemInformation.MidEastEnabled.ToString());

            lvwSystemInformation.Items.Add("MinimizedWindowSize").SubItems.Add(SystemInformation.MinimizedWindowSize.ToString());

            lvwSystemInformation.Items.Add("MinimizedWindowSpacingSize").SubItems.Add(SystemInformation.MinimizedWindowSpacingSize.ToString());

            lvwSystemInformation.Items.Add("MinimumWindowSize").SubItems.Add(SystemInformation.MinimumWindowSize.ToString());

            lvwSystemInformation.Items.Add("MinWindowTrackSize").SubItems.Add(SystemInformation.MinWindowTrackSize.ToString());

            lvwSystemInformation.Items.Add("MonitorCount").SubItems.Add(SystemInformation.MonitorCount.ToString());

            lvwSystemInformation.Items.Add("MonitorsSameDisplayFormat").SubItems.Add(SystemInformation.MonitorsSameDisplayFormat.ToString());

            lvwSystemInformation.Items.Add("MouseButtons").SubItems.Add(SystemInformation.MouseButtons.ToString());

            lvwSystemInformation.Items.Add("MouseButtonsSwapped").SubItems.Add(SystemInformation.MouseButtonsSwapped.ToString());

            lvwSystemInformation.Items.Add("MousePresent").SubItems.Add(SystemInformation.MousePresent.ToString());

            lvwSystemInformation.Items.Add("MouseWheelPresent").SubItems.Add(SystemInformation.MouseWheelPresent.ToString());

            lvwSystemInformation.Items.Add("MouseWheelScrollLines").SubItems.Add(SystemInformation.MouseWheelScrollLines.ToString());

            lvwSystemInformation.Items.Add("NativeMouseWheelSupport").SubItems.Add(SystemInformation.NativeMouseWheelSupport.ToString());

            lvwSystemInformation.Items.Add("Network").SubItems.Add(SystemInformation.Network.ToString());

            lvwSystemInformation.Items.Add("PenWindows").SubItems.Add(SystemInformation.PenWindows.ToString());

            lvwSystemInformation.Items.Add("PrimaryMonitorMaximizedWindowSize").SubItems.Add(SystemInformation.PrimaryMonitorMaximizedWindowSize.ToString());

            lvwSystemInformation.Items.Add("PrimaryMonitorSize").SubItems.Add(SystemInformation.PrimaryMonitorSize.ToString());

            lvwSystemInformation.Items.Add("RightAlignedMenus").SubItems.Add(SystemInformation.RightAlignedMenus.ToString());

            lvwSystemInformation.Items.Add("Secure").SubItems.Add(SystemInformation.Secure.ToString());

            lvwSystemInformation.Items.Add("ShowSounds").SubItems.Add(SystemInformation.ShowSounds.ToString());

            lvwSystemInformation.Items.Add("SmallIconSize").SubItems.Add(SystemInformation.SmallIconSize.ToString());

            lvwSystemInformation.Items.Add("ToolWindowCaptionButtonSize").SubItems.Add(SystemInformation.ToolWindowCaptionButtonSize.ToString());

            lvwSystemInformation.Items.Add("ToolWindowCaptionHeight").SubItems.Add(SystemInformation.ToolWindowCaptionHeight.ToString());

            lvwSystemInformation.Items.Add("UserDomainName").SubItems.Add(SystemInformation.UserDomainName.ToString());

            lvwSystemInformation.Items.Add("UserInteractive").SubItems.Add(SystemInformation.UserInteractive.ToString());

            lvwSystemInformation.Items.Add("UserName").SubItems.Add(SystemInformation.UserName.ToString());

            lvwSystemInformation.Items.Add("VerticalScrollBarArrowHeight").SubItems.Add(SystemInformation.VerticalScrollBarArrowHeight.ToString());

            lvwSystemInformation.Items.Add("VerticalScrollBarThumbHeight").SubItems.Add(SystemInformation.VerticalScrollBarThumbHeight.ToString());

            lvwSystemInformation.Items.Add("VerticalScrollBarWidth").SubItems.Add(SystemInformation.VerticalScrollBarWidth.ToString());

            lvwSystemInformation.Items.Add("VirtualScreen").SubItems.Add(SystemInformation.VirtualScreen.ToString());         

			lvwSystemInformation.Items.Add("WorkingArea").SubItems.Add(SystemInformation.WorkingArea.ToString());

	}

	private void RunMethods()
	{

		// Environment.GetLogicalDrives returns an 
		// array of drive names. You can iterate
		// through the array just like you would  
		// any other array, or you can use the array
		// the data source for a list, seen here.
		// Once you have a list of drives, you might
		// want to retrieve information about the files
		// on those drives. See the File and Directory
		// classes for more infomation on working 
		//  those logical entities.

		lstLogicalDrives.DataSource = Environment.GetLogicalDrives();

		lstCommandLineArgs.DataSource = Environment.GetCommandLineArgs();

	}

}

