//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Collections;

public class frmMain : System.Windows.Forms.Form 
{
	// Used to access an instance of the selected service.
	private ServiceController msvc;
	private ListViewItem ViewItem;

	private Hashtable mcolSvcs = new Hashtable();

	// Used to control UI updates.

	private bool fUpdatingUI ;

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

	private System.Windows.Forms.StatusBar sbInfo;

	private System.Windows.Forms.Panel pnlCommands;

	private System.Windows.Forms.ListView lvServices;

	private System.Windows.Forms.ColumnHeader chName;

	private System.Windows.Forms.ColumnHeader chStatus;

	private System.Windows.Forms.Button cmdStart;

	private System.Windows.Forms.Button cmdStop;

	private System.Windows.Forms.Button cmdPause;

	private System.Windows.Forms.Button cmdResume;

	private System.Windows.Forms.ColumnHeader chSvcType;

	private System.Windows.Forms.Timer tmrStatus;

	private System.Windows.Forms.CheckBox chkAutoRefresh;

	private System.Windows.Forms.MenuItem mnuTools;

	private System.Windows.Forms.MenuItem mnuRelist;

	private System.Windows.Forms.MenuItem MenuItem3;

	private System.Windows.Forms.MenuItem mnuRefresh;

	private void InitializeComponent() {
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuTools = new System.Windows.Forms.MenuItem();
		this.mnuRelist = new System.Windows.Forms.MenuItem();
		this.MenuItem3 = new System.Windows.Forms.MenuItem();
		this.mnuRefresh = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.sbInfo = new System.Windows.Forms.StatusBar();
		this.pnlCommands = new System.Windows.Forms.Panel();
		this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
		this.cmdResume = new System.Windows.Forms.Button();
		this.cmdPause = new System.Windows.Forms.Button();
		this.cmdStop = new System.Windows.Forms.Button();
		this.cmdStart = new System.Windows.Forms.Button();
		this.lvServices = new System.Windows.Forms.ListView();
		this.chName = new System.Windows.Forms.ColumnHeader();
		this.chStatus = new System.Windows.Forms.ColumnHeader();
		this.chSvcType = new System.Windows.Forms.ColumnHeader();
		this.tmrStatus = new System.Windows.Forms.Timer(this.components);
		this.pnlCommands.SuspendLayout();
		this.SuspendLayout();
		// 
		// mnuMain
		// 
		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuFile,
																				this.mnuTools,
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
		// mnuTools
		// 
		this.mnuTools.Index = 1;
		this.mnuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				 this.mnuRelist,
																				 this.MenuItem3,
																				 this.mnuRefresh});
		this.mnuTools.Text = "&Tools";
		// 
		// mnuRelist
		// 
		this.mnuRelist.Index = 0;
		this.mnuRelist.Text = "Relist &All Services";
		this.mnuRelist.Click += new System.EventHandler(this.mnuRelist_Click);
		// 
		// MenuItem3
		// 
		this.MenuItem3.Index = 1;
		this.MenuItem3.Text = "-";
		// 
		// mnuRefresh
		// 
		this.mnuRefresh.Index = 2;
		this.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;
		this.mnuRefresh.Text = "&Refresh";
		this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
		// 
		// mnuHelp
		// 
		this.mnuHelp.Index = 2;
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
		// sbInfo
		// 
		this.sbInfo.Location = new System.Drawing.Point(0, 192);
		this.sbInfo.Name = "sbInfo";
		this.sbInfo.Size = new System.Drawing.Size(552, 22);
		this.sbInfo.TabIndex = 2;
		this.sbInfo.Text = "Ready";
		// 
		// pnlCommands
		// 
		this.pnlCommands.Controls.Add(this.chkAutoRefresh);
		this.pnlCommands.Controls.Add(this.cmdResume);
		this.pnlCommands.Controls.Add(this.cmdPause);
		this.pnlCommands.Controls.Add(this.cmdStop);
		this.pnlCommands.Controls.Add(this.cmdStart);
		this.pnlCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.pnlCommands.Location = new System.Drawing.Point(0, 152);
		this.pnlCommands.Name = "pnlCommands";
		this.pnlCommands.Size = new System.Drawing.Size(552, 40);
		this.pnlCommands.TabIndex = 1;
		this.pnlCommands.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCommands_Paint);
		// 
		// chkAutoRefresh
		// 
		this.chkAutoRefresh.Checked = true;
		this.chkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkAutoRefresh.Location = new System.Drawing.Point(336, 8);
		this.chkAutoRefresh.Name = "chkAutoRefresh";
		this.chkAutoRefresh.TabIndex = 4;
		this.chkAutoRefresh.Text = "&Auto Refresh";
		this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
		// 
		// cmdResume
		// 
		this.cmdResume.Location = new System.Drawing.Point(248, 8);
		this.cmdResume.Name = "cmdResume";
		this.cmdResume.TabIndex = 3;
		this.cmdResume.Text = "&Resume";
		this.cmdResume.Click += new System.EventHandler(this.cmdResume_Click);
		// 
		// cmdPause
		// 
		this.cmdPause.Location = new System.Drawing.Point(168, 8);
		this.cmdPause.Name = "cmdPause";
		this.cmdPause.TabIndex = 2;
		this.cmdPause.Text = "&Pause";
		this.cmdPause.Click += new System.EventHandler(this.cmdPause_Click);
		// 
		// cmdStop
		// 
		this.cmdStop.Location = new System.Drawing.Point(88, 8);
		this.cmdStop.Name = "cmdStop";
		this.cmdStop.TabIndex = 1;
		this.cmdStop.Text = "S&top";
		this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
		// 
		// cmdStart
		// 
		this.cmdStart.Location = new System.Drawing.Point(8, 8);
		this.cmdStart.Name = "cmdStart";
		this.cmdStart.TabIndex = 0;
		this.cmdStart.Text = "&Start";
		this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
		// 
		// lvServices
		// 
		this.lvServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					 this.chName,
																					 this.chStatus,
																					 this.chSvcType});
		this.lvServices.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lvServices.FullRowSelect = true;
		this.lvServices.HideSelection = false;
		this.lvServices.Location = new System.Drawing.Point(0, 0);
		this.lvServices.MultiSelect = false;
		this.lvServices.Name = "lvServices";
		this.lvServices.Size = new System.Drawing.Size(552, 152);
		this.lvServices.Sorting = System.Windows.Forms.SortOrder.Ascending;
		this.lvServices.TabIndex = 0;
		this.lvServices.View = System.Windows.Forms.View.Details;
		this.lvServices.SelectedIndexChanged += new System.EventHandler(this.lvServices_SelectedIndexChanged);
		// 
		// chName
		// 
		this.chName.Text = "Name";
		this.chName.Width = 200;
		// 
		// chStatus
		// 
		this.chStatus.Text = "Status";
		this.chStatus.Width = 100;
		// 
		// chSvcType
		// 
		this.chSvcType.Text = "Service Type";
		this.chSvcType.Width = 225;
		// 
		// tmrStatus
		// 
		this.tmrStatus.Enabled = true;
		this.tmrStatus.Interval = 5000;
		this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
		// 
		// frmMain
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(552, 214);
		this.Controls.Add(this.lvServices);
		this.Controls.Add(this.pnlCommands);
		this.Controls.Add(this.sbInfo);
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.Menu = this.mnuMain;
		this.Name = "frmMain";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Title Comes from Assembly Info";
		this.pnlCommands.ResumeLayout(false);
		this.ResumeLayout(false);
		this.Load+=new EventHandler(frmMain_Load);

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

	private void chkAutoRefresh_CheckedChanged(object sender, System.EventArgs e)
	{
		// Turn the timer on or off
		if (this.chkAutoRefresh.CheckState == CheckState.Checked) 
		{
			this.tmrStatus.Enabled = true;
		}
		else 
		{
			this.tmrStatus.Enabled = false;
		}
	}

	private void cmdPause_Click(object sender, System.EventArgs e)
	{
		try 
		{
			msvc.Pause();
			fUpdatingUI = true;
			UpdateUIForSelectedService();
			fUpdatingUI = false;
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void cmdResume_Click(object sender, System.EventArgs e)
	{
		try 
		{
			msvc.Continue();
			fUpdatingUI = true;
			UpdateUIForSelectedService();
			fUpdatingUI = false;
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void cmdStart_Click(object sender, System.EventArgs e)
	{
		try 
		{
			msvc.Start();
			fUpdatingUI = true;
			UpdateUIForSelectedService();
			fUpdatingUI = false;
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void cmdStop_Click(object sender, System.EventArgs e)
	{
		try 
		{
			msvc.Stop();
			fUpdatingUI = true;
			UpdateUIForSelectedService();
			fUpdatingUI = false;
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void frmMain_Load(object sender, System.EventArgs e) 
	{
		EnumServices();
	}

	private void lvServices_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		fUpdatingUI = true;
		UpdateUIForSelectedService();
		fUpdatingUI = false;
	}

	private void tmrStatus_Tick(object sender, System.EventArgs e)
	{
		if ( !fUpdatingUI) 
		{
			UpdateServiceStatus();
		}
	}

	private void EnumServices()
	{
		// Get the list of available services and
		// load the list view control with the information
		try 
		{
			fUpdatingUI = true;
			this.sbInfo.Text = "Loading Service List, pleasse wait";
			this.sbInfo.Refresh();
			this.lvServices.Items.Clear();
			if (!(mcolSvcs == null)) 
			{
				mcolSvcs = new Hashtable();
			}

			 //svcs  = new ServiceController[];
			ServiceController[] svcs = ServiceController.GetServices();

			foreach(ServiceController svc in svcs)
			{
				ViewItem = this.lvServices.Items.Add(svc.DisplayName);
				ViewItem.SubItems.Add(svc.Status.ToString());
				ViewItem.SubItems.Add(svc.ServiceType.ToString());
				

				//mcolSvcs.Add(svc, svc.DisplayName);
				mcolSvcs.Add(svc.DisplayName,svc);
				
				//Next svc++;
			}
		}
		catch (Exception exp) 
		{

			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			this.sbInfo.Text = "Ready";
			fUpdatingUI = false;
		}
	}

	private void UpdateServiceStatus()
	{
		// Check each service
		try 
		{
			fUpdatingUI = true;
			this.sbInfo.Text = "Checking Service Status . . ";
			this.sbInfo.Refresh();
			
			// We could walk through the collection of services
			// two ways. One would be to enumerate all the services
			// via mcolSvc and then find the particular item in the
			// list view control to update its status.
			// The second method is to do the following code which
			// seems a bit easier since the collection is keyed by
			// the service display name which we get from the list view 
			// control.

			foreach(ListViewItem lvi in this.lvServices.Items)
			{
				msvc = ((ServiceController) (mcolSvcs[lvi.Text]));
				msvc.Refresh();
				lvi.SubItems[1].Text = msvc.Status.ToString();
				//Next lvi;
			}
			UpdateUIForSelectedService();
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			this.sbInfo.Text = "Ready";
			fUpdatingUI = false;
		}
	}

	private void UpdateUIForSelectedService()
	{
		// Update the command buttons for the selected service.
		string strName;
		int ItemIndex;
		
		try 
		{
			if (this.lvServices.SelectedItems.Count == 1) 
			{

				strName = this.lvServices.SelectedItems[0].SubItems[0].Text;
				ItemIndex = this.lvServices.FocusedItem.Index;
				msvc = ((ServiceController) (mcolSvcs[strName]) );
				//msvc = ((ServiceController) (mcolSvcs[ItemIndex]) );

				// if it's stopped, we should be able to start it
				this.cmdStart.Enabled = (msvc.Status == ServiceControllerStatus.Stopped);

				// Check if we're allowed to try and stop it and make sure it's not
				// already stopped.
				this.cmdStop.Enabled = (msvc.CanStop && (!(msvc.Status == ServiceControllerStatus.Stopped)));

				// Check if we're allowed to pause it and see if it is not paused
				// already.
				this.cmdPause.Enabled = (msvc.CanPauseAndContinue && (!(msvc.Status == ServiceControllerStatus.Paused)));

				// if it's paused, we must be able to resume it.
				this.cmdResume.Enabled = (msvc.Status == ServiceControllerStatus.Paused);
			}
				
		}

		catch (Exception exp) {
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void mnuRefresh_Click(object sender, System.EventArgs e)
	{
		if (! fUpdatingUI) 
		{
			UpdateServiceStatus();
		}
	}

	private void mnuRelist_Click(object sender, System.EventArgs e)
	{
		if (! fUpdatingUI) 
		{
			EnumServices();
		}
	}

	private void pnlCommands_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
	{
	
	}
}

