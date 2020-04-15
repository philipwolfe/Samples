//Copyright (C) 2002 btncrosoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIbtnTED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET 
//   Professional (or greater).
// Don't forget to add a reference to the "System.ServiceProcess.dll"
//   Right click the References section to add the reference.

using System;
using System.Windows.Forms;
using System.Data;
using System.ServiceProcess;

public class frmMain : System.Windows.Forms.Form 
{
    // Stores the selected Service
    ServiceController m_SelectedService;
    // Stores the name of the Selected Service
    string m_SelectedServiceName = "No Service Selected";
    // Since the X at the top of the form is used to Minimize
    //   the form, to prevent accidental closing, this flag is used to 
    //   to notify the application that the BUTTON closing the application
    //   was used.
    bool m_isCloseButtonPushed = false;

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

    private System.Windows.Forms.Button btnStop;

    private System.Windows.Forms.Button btnContinue;

    private System.Windows.Forms.Button btnPause;

    private System.Windows.Forms.StatusBar sbrServiceStatus;

    private System.Windows.Forms.Button btnStart;

    private System.Windows.Forms.DataGrid grdServices;

    private System.Windows.Forms.TextBox txtSelectedService;

    private System.Windows.Forms.Timer tmrCheckStatus;

    private System.Windows.Forms.Button btnRefreshServices;

    private System.Windows.Forms.ContextMenu cmnuServiceStatus;

    private System.Windows.Forms.NotifyIcon nicoSvcMgrApp;

    private System.Windows.Forms.MenuItem miServiceName;

    private System.Windows.Forms.MenuItem miLineBreak1;

    private System.Windows.Forms.MenuItem miStart;

    private System.Windows.Forms.MenuItem miPause;

    private System.Windows.Forms.MenuItem miContinue;

    private System.Windows.Forms.MenuItem miStop;

    private System.Windows.Forms.MenuItem miLineBreak2;

    private System.Windows.Forms.MenuItem miSelectService;

    private System.Windows.Forms.Button btnCloseApp;

    private System.Windows.Forms.Button btnMinimizeApp;

    private System.Windows.Forms.Label lblSelectedService;

    private System.Windows.Forms.MenuItem mnuExitApp;

    private void InitializeComponent() {
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.btnRefreshServices = new System.Windows.Forms.Button();
		this.btnStop = new System.Windows.Forms.Button();
		this.btnContinue = new System.Windows.Forms.Button();
		this.btnPause = new System.Windows.Forms.Button();
		this.sbrServiceStatus = new System.Windows.Forms.StatusBar();
		this.btnStart = new System.Windows.Forms.Button();
		this.grdServices = new System.Windows.Forms.DataGrid();
		this.lblSelectedService = new System.Windows.Forms.Label();
		this.txtSelectedService = new System.Windows.Forms.TextBox();
		this.tmrCheckStatus = new System.Windows.Forms.Timer(this.components);
		this.cmnuServiceStatus = new System.Windows.Forms.ContextMenu();
		this.miServiceName = new System.Windows.Forms.MenuItem();
		this.miLineBreak1 = new System.Windows.Forms.MenuItem();
		this.miStart = new System.Windows.Forms.MenuItem();
		this.miPause = new System.Windows.Forms.MenuItem();
		this.miContinue = new System.Windows.Forms.MenuItem();
		this.miStop = new System.Windows.Forms.MenuItem();
		this.miLineBreak2 = new System.Windows.Forms.MenuItem();
		this.miSelectService = new System.Windows.Forms.MenuItem();
		this.mnuExitApp = new System.Windows.Forms.MenuItem();
		this.nicoSvcMgrApp = new System.Windows.Forms.NotifyIcon(this.components);
		this.btnCloseApp = new System.Windows.Forms.Button();
		this.btnMinimizeApp = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)(this.grdServices)).BeginInit();
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
		// btnRefreshServices
		// 
		this.btnRefreshServices.AccessibleDescription = "Button used to Verify the Install of the Windows Service.";
		this.btnRefreshServices.AccessibleName = "Verify Install Button";
		this.btnRefreshServices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.btnRefreshServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
		this.btnRefreshServices.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnRefreshServices.Location = new System.Drawing.Point(376, 296);
		this.btnRefreshServices.Name = "btnRefreshServices";
		this.btnRefreshServices.Size = new System.Drawing.Size(96, 40);
		this.btnRefreshServices.TabIndex = 13;
		this.btnRefreshServices.Text = "&Refresh Services";
		this.btnRefreshServices.Click += new System.EventHandler(this.btnRefreshServices_Click);
		// 
		// btnStop
		// 
		this.btnStop.AccessibleDescription = "Button used to Stop the Windows Service.";
		this.btnStop.AccessibleName = "Stop Button";
		this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.btnStop.Enabled = false;
		this.btnStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnStop.Location = new System.Drawing.Point(280, 304);
		this.btnStop.Name = "btnStop";
		this.btnStop.TabIndex = 12;
		this.btnStop.Text = "Sto&p";
		this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
		// 
		// btnContinue
		// 
		this.btnContinue.AccessibleDescription = "Button used to Continue the Windows Service.";
		this.btnContinue.AccessibleName = "Continue Button";
		this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.btnContinue.Enabled = false;
		this.btnContinue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnContinue.Location = new System.Drawing.Point(192, 304);
		this.btnContinue.Name = "btnContinue";
		this.btnContinue.TabIndex = 11;
		this.btnContinue.Text = "&Continue";
		this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
		// 
		// btnPause
		// 
		this.btnPause.AccessibleDescription = "Button used to Pause the Windows Service.";
		this.btnPause.AccessibleName = "Pause Button";
		this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.btnPause.Enabled = false;
		this.btnPause.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnPause.Location = new System.Drawing.Point(104, 304);
		this.btnPause.Name = "btnPause";
		this.btnPause.TabIndex = 10;
		this.btnPause.Text = "&Pause";
		this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
		// 
		// sbrServiceStatus
		// 
		this.sbrServiceStatus.AccessibleDescription = "Status Bar showing status of the windows service.";
		this.sbrServiceStatus.AccessibleName = "Service Status Status Bar";
		this.sbrServiceStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.sbrServiceStatus.Location = new System.Drawing.Point(0, 349);
		this.sbrServiceStatus.Name = "sbrServiceStatus";
		this.sbrServiceStatus.Size = new System.Drawing.Size(594, 22);
		this.sbrServiceStatus.TabIndex = 9;
		// 
		// btnStart
		// 
		this.btnStart.AccessibleDescription = "Button used to Start the Windows Service.";
		this.btnStart.AccessibleName = "Start Button";
		this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.btnStart.Enabled = false;
		this.btnStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnStart.Location = new System.Drawing.Point(16, 304);
		this.btnStart.Name = "btnStart";
		this.btnStart.TabIndex = 8;
		this.btnStart.Text = "&Start";
		this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
		// 
		// grdServices
		// 
		this.grdServices.AccessibleDescription = "DataGrid displaying all the installed Windows Services";
		this.grdServices.AccessibleName = "Services Data Grid";
		this.grdServices.DataMember = "";
		this.grdServices.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.grdServices.Location = new System.Drawing.Point(16, 8);
		this.grdServices.Name = "grdServices";
		this.grdServices.ReadOnly = true;
		this.grdServices.Size = new System.Drawing.Size(560, 232);
		this.grdServices.TabIndex = 14;
		this.grdServices.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdServices_MouseDown);
		// 
		// lblSelectedService
		// 
		this.lblSelectedService.AccessibleDescription = "Label containing text reading Selected Service";
		this.lblSelectedService.AccessibleName = "Selected Service Label";
		this.lblSelectedService.Location = new System.Drawing.Point(16, 256);
		this.lblSelectedService.Name = "lblSelectedService";
		this.lblSelectedService.Size = new System.Drawing.Size(112, 23);
		this.lblSelectedService.TabIndex = 15;
		this.lblSelectedService.Text = "Selected Service: ";
		// 
		// txtSelectedService
		// 
		this.txtSelectedService.AccessibleDescription = "Textbox containing the name of the selected service";
		this.txtSelectedService.AccessibleName = "Selected Service TextBox";
		this.txtSelectedService.Location = new System.Drawing.Point(144, 256);
		this.txtSelectedService.Name = "txtSelectedService";
		this.txtSelectedService.ReadOnly = true;
		this.txtSelectedService.Size = new System.Drawing.Size(328, 23);
		this.txtSelectedService.TabIndex = 16;
		this.txtSelectedService.TabStop = false;
		this.txtSelectedService.Text = "";
		// 
		// tmrCheckStatus
		// 
		this.tmrCheckStatus.Interval = 500;
		this.tmrCheckStatus.Tick += new System.EventHandler(this.tmrCheckStatus_Tick);
		// 
		// cmnuServiceStatus
		// 
		this.cmnuServiceStatus.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.miServiceName,
																						  this.miLineBreak1,
																						  this.miStart,
																						  this.miPause,
																						  this.miContinue,
																						  this.miStop,
																						  this.miLineBreak2,
																						  this.miSelectService,
																						  this.mnuExitApp});
		this.cmnuServiceStatus.Popup += new System.EventHandler(this.cmnuServiceStatus_Popup);
		// 
		// miServiceName
		// 
		this.miServiceName.Index = 0;
		this.miServiceName.Text = "No Service Selected";
		// 
		// miLineBreak1
		// 
		this.miLineBreak1.Index = 1;
		this.miLineBreak1.Text = "-";
		// 
		// miStart
		// 
		this.miStart.Index = 2;
		this.miStart.Text = "Start";
		this.miStart.Click += new System.EventHandler(this.btnStart_Click);
		// 
		// miPause
		// 
		this.miPause.Index = 3;
		this.miPause.Text = "Pause";
		this.miPause.Click += new System.EventHandler(this.btnPause_Click);
		// 
		// miContinue
		// 
		this.miContinue.Index = 4;
		this.miContinue.Text = "Continue";
		this.miContinue.Click += new System.EventHandler(this.btnContinue_Click);
		// 
		// miStop
		// 
		this.miStop.Index = 5;
		this.miStop.Text = "Stop";
		this.miStop.Click += new System.EventHandler(this.btnStop_Click);
		// 
		// miLineBreak2
		// 
		this.miLineBreak2.Index = 6;
		this.miLineBreak2.Text = "-";
		// 
		// miSelectService
		// 
		this.miSelectService.Index = 7;
		this.miSelectService.Text = "Select new Service";
		this.miSelectService.Click += new System.EventHandler(this.miSelectService_Click);
		// 
		// mnuExitApp
		// 
		this.mnuExitApp.Index = 8;
		this.mnuExitApp.Text = "&Exit Application";
		this.mnuExitApp.Click += new System.EventHandler(this.mnuExitApp_Click);
		// 
		// nicoSvcMgrApp
		// 
		this.nicoSvcMgrApp.ContextMenu = this.cmnuServiceStatus;
		this.nicoSvcMgrApp.Icon = ((System.Drawing.Icon)(resources.GetObject("nicoSvcMgrApp.Icon")));
		this.nicoSvcMgrApp.Text = "SvcMgr";
		this.nicoSvcMgrApp.Visible = true;
		this.nicoSvcMgrApp.DoubleClick += new System.EventHandler(this.nicoSvcMgrApp_DoubleClick);
		// 
		// btnCloseApp
		// 
		this.btnCloseApp.AccessibleDescription = "Button to Close the Application";
		this.btnCloseApp.AccessibleName = "Close App Button";
		this.btnCloseApp.Location = new System.Drawing.Point(496, 248);
		this.btnCloseApp.Name = "btnCloseApp";
		this.btnCloseApp.Size = new System.Drawing.Size(80, 40);
		this.btnCloseApp.TabIndex = 17;
		this.btnCloseApp.Text = "&Close Application";
		this.btnCloseApp.Click += new System.EventHandler(this.btnCloseApp_Click);
		// 
		// btnMinimizeApp
		// 
		this.btnMinimizeApp.AccessibleDescription = "Button to Minimize the Application";
		this.btnMinimizeApp.AccessibleName = "Minimize App Button";
		this.btnMinimizeApp.Location = new System.Drawing.Point(496, 296);
		this.btnMinimizeApp.Name = "btnMinimizeApp";
		this.btnMinimizeApp.Size = new System.Drawing.Size(80, 40);
		this.btnMinimizeApp.TabIndex = 18;
		this.btnMinimizeApp.Text = "&Minimize Application";
		this.btnMinimizeApp.Click += new System.EventHandler(this.btnMinimizeApp_Click);
		// 
		// frmMain
		// 
		this.AccessibleDescription = "Main User interface Form";
		this.AccessibleName = "Main Form";
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
		this.ClientSize = new System.Drawing.Size(594, 371);
		this.Controls.Add(this.btnMinimizeApp);
		this.Controls.Add(this.btnCloseApp);
		this.Controls.Add(this.txtSelectedService);
		this.Controls.Add(this.lblSelectedService);
		this.Controls.Add(this.grdServices);
		this.Controls.Add(this.btnRefreshServices);
		this.Controls.Add(this.btnStop);
		this.Controls.Add(this.btnContinue);
		this.Controls.Add(this.btnPause);
		this.Controls.Add(this.sbrServiceStatus);
		this.Controls.Add(this.btnStart);
		this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.Menu = this.mnuMain;
		this.Name = "frmMain";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Title Comes from Assembly Info";
		this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
		((System.ComponentModel.ISupportInitialize)(this.grdServices)).EndInit();
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

#region "CloseApp Button";

    // This sub is used to Close the application when the Close button is pushed.
    private void btnCloseApp_Click(object sender, System.EventArgs e) 
	{
        m_isCloseButtonPushed = true;
        this.Close();
    }

#endregion

    // This sub forces the service to Continue
    // Notice this event handles both the Button and the MenuItem
    private void btnContinue_Click(object sender, System.EventArgs e) //btnContinue.Click, miContinue.Click;
	{
        m_SelectedService.Continue();
        UpdateServiceStatus();
    }

#region "MinimizeApp Button";

    // This sub causes the application to be minimized
    private void btnMinimizeApp_Click(object sender, System.EventArgs e) 
	{
        this.WindowState = FormWindowState.Minimized;
    }

#endregion

    // This sub forces the service to Pause
    // Notice this event handles both the Button and the MenuItem
    private void btnPause_Click(object sender, System.EventArgs e) //btnPause.Click, miPause.Click;
	{
        m_SelectedService.Pause();
        UpdateServiceStatus();
    }

    // This sub forces the service to Stop
    // Notice this event handles both the Button and the MenuItem
    private void btnStop_Click(object sender, System.EventArgs e) //btnStop.Click, miStop.Click;
	{
        m_SelectedService.Stop();
        UpdateServiceStatus();
    }

    // This sub forces the service to Start
    // Notice this event handles both the Button and the MenuItem
    private void btnStart_Click(object sender, System.EventArgs e) //btnStart.Click, miStart.Click;
	{
        m_SelectedService.Start();
        UpdateServiceStatus();
    }

    // This sub is used to find if the Service is currently installed, and to
    //   force the DataGrid to refresh itself
    private void btnRefreshServices_Click(object sender, System.EventArgs e) 
	{
        grdServices.DataSource = GetServicesTable();
        grdServices.Refresh();
    }

#region "Context Menu Creation";

    // This sub ensures that the first MenuItem is the name of the selected Service
    private void cmnuServiceStatus_Popup(object sender, System.EventArgs e) 
	{
        //Build the menu
        this.cmnuServiceStatus.MenuItems[0].Text = this.m_SelectedServiceName;
    }

#endregion

#region "Closing application event handler";

    // This sub handles the Closing event
    private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e) //base.Closing;
	{
        if (! m_isCloseButtonPushed) {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }
    }

#endregion

    // This sub causes the data to be loaded into the DataGrid, so it 
    //   can properly display all of the current Windows Services
    //   on the local machine.
    private void frmMain_Load(object sender, System.EventArgs e) 
	{
        //Fix the column widths 
        grdServices.PreferredColumnWidth = grdServices.Width / 4;
        // Get the Windows Services and display them in the DataGrid
        grdServices.DataSource = GetServicesTable();
        grdServices.Refresh();
        // Enable the timer so that the interface is refreshed.
        tmrCheckStatus.Enabled = true;
    }

    // This sub locates the user selected Service and sets it the 
    //   selected Service
    private void grdServices_MouseDown(object sender,System.Windows.Forms.MouseEventArgs e) 
	{
        // Create a hit test info variable to determine selected row
        System.Windows.Forms.DataGrid.HitTestInfo hit = grdServices.HitTest(e.X, e.Y);
        // Find the Service based on the selected row
        if (hit.Row >= 0)
		{
            this.grdServices.Select(hit.Row);
            m_SelectedServiceName = this.grdServices[hit.Row, 0].ToString();
            RefreshSelectedService();
            UpdateServiceStatus();
        }
    }

#region "Context Menu and Notify Icon events";

    // This sub shows the window when the user selects it from the context menu
    private void miSelectService_Click(object sender, System.EventArgs e) 
	{
        this.WindowState = FormWindowState.Normal;
    }

    // This sub shows the window when the user double clicks the NotifyIcon
    private void nicoSvcMgrApp_DoubleClick(object sender, System.EventArgs e) 
	{
        this.WindowState = FormWindowState.Normal;
    }

#endregion

    // This sub refreshes the User interface every 1/2 second
    private void tmrCheckStatus_Tick(object sender, System.EventArgs e) 
	{
        RefreshSelectedService();
        UpdateServiceStatus();
    }

    private void mnuExitApp_Click(object sender, System.EventArgs e) 
	{
        Application.Exit();
    }

#region "CreateDataTable routine to define necessary DataTable";

    // This method creates the DataTable that will store all of the 
    //   Windows Services on the local machine.
    private DataTable CreateDataTable() 
	{
        DataTable myTable = new DataTable("WindowsServiceTable");
        DataColumn myColumn ;
        Type typestring = "".GetType();
        // Create the necessary columns
        myTable.Columns.Add("Service Name", typestring);
        myTable.Columns.Add("Display Name", typestring);
        myTable.Columns.Add("Status", typestring);
        return myTable;
    }

#endregion

    // This function returns a DataTable filled with all of the services
    //   that are currently installed on the local machine.
    private DataTable GetServicesTable() 
	{
        DataTable myTable; //' Temporarily stores the services;
        ServiceController[] myServicesArray;
        //ServiceController myService ;
        DataRow myRow ;  //' Used to add rows to the DataTable;
        // Create a DataTable with the proper columns
        myTable = CreateDataTable();
        // Gets an array of all Services (except Device Drivers) that are 
        //   installed on the local machine.
        myServicesArray = ServiceController.GetServices();
        // For each Windows Service, add useful information to the DataGrid

        foreach(ServiceController myService in myServicesArray)
		{
            myRow = myTable.NewRow(); //' Creates a new Row from the DataTable;
            myRow["Service Name"] = myService.ServiceName;
            myRow["Display Name"] = myService.DisplayName;
            myRow["Status"] = myService.Status.ToString();
            myTable.Rows.Add(myRow); //' Adds the new Row to the DataTable;
        }
        // return the filled table
        return myTable;
    }

    // RefreshSelectedService verifies that the service is actually
    //   installed on the system. It also assigns the service
    //   to the myService class variable if it is. 
    // The assignment to m_SelectedService is important and must be refreshed, 
    //   since unlike most objects, the myService doesn't get changes to the
    //   status of the actual service. So it must be continually reassigned.
    private void RefreshSelectedService()
	{
        ServiceController[] installedServices;
        //tmpService ServiceController;
        bool isServiceInstalled  = false;
        int i = 0;
        // Shut off the timer so it doesn't raise events while were
        //   in this code
        this.tmrCheckStatus.Enabled = false;
        // Get a list of all Running Services
        installedServices = ServiceController.GetServices();
        // Got through each service to see ensure it is installed, and if it
        //   is, then assign it to m_SelectedService

		foreach(ServiceController tmpService in installedServices)
		{
			if (tmpService.ServiceName == m_SelectedServiceName)
			{
				isServiceInstalled = true;
				// Assign the service to myService, so we can use it later.
				m_SelectedService = tmpService;
			}
		}
        // Re-enable the timer
        this.tmrCheckStatus.Enabled = true;
    }

    // This sub refreshes most of the UI (except for the DataGrid) to show the
    //   latest status of the Windows Service.
    private void UpdateServiceStatus()
	{
        // Shut off the timer so it doesn't raise events while were
        //   in this code
        this.tmrCheckStatus.Enabled = false;

		if (!(m_SelectedService == null)) 
		{
			// Recreate mySelectedServer, otherwise the status for myServer never
			//   changes, despite changes in the status of the 
			//   windows service
			RefreshSelectedService();
			// Rebuild the UI, enabling and disabling buttons and menu items
			//   necessary.

			switch( m_SelectedService.Status)
			{
				case ServiceControllerStatus.Stopped:
					this.btnContinue.Enabled = false;
					this.btnPause.Enabled = false;
					this.btnStart.Enabled = true;
					this.btnStop.Enabled = false;
					this.miContinue.Enabled = false;
					this.miPause.Enabled = false;
					this.miStart.Enabled = true;
					this.miStop.Enabled = false;
					break;
				case ServiceControllerStatus.Running:
					this.btnContinue.Enabled = false;

					if (m_SelectedService.CanPauseAndContinue)
					{
						this.btnPause.Enabled = true;
					}
					this.btnStart.Enabled = false;
					this.btnStop.Enabled = true;
					this.miContinue.Enabled = false;

					if (m_SelectedService.CanPauseAndContinue) 
					{
						this.miPause.Enabled = true;
					}
					this.miStart.Enabled = false;
					this.miStop.Enabled = true;
					break;
				case ServiceControllerStatus.Paused:
					if (m_SelectedService.CanPauseAndContinue)
					{
						this.btnContinue.Enabled = true;
					}
					this.btnPause.Enabled = false;
					this.btnStart.Enabled = false;
					this.btnStop.Enabled = true;

					if (m_SelectedService.CanPauseAndContinue)
					{
						this.miContinue.Enabled = true;
					}
					this.miPause.Enabled = false;
					this.miStart.Enabled = false;
					this.miStop.Enabled = true;
					break;
				default: 
					// This can occur when an action is pending. In this case
					//   don't allow the user to push any buttons.
					this.btnContinue.Enabled = false;
					this.btnPause.Enabled = false;
					this.btnStart.Enabled = false;
					this.btnStop.Enabled = false;
					this.miContinue.Enabled = false;
					this.miPause.Enabled = false;
					this.miStart.Enabled = false;
					this.miStop.Enabled = false;
					break;
			}
			// Output the status to the Status Bar
			this.sbrServiceStatus.Text = "Service Status: " + 
				m_SelectedService.Status.ToString();
		}
		else 
		{
			// The service isn't running so disable everything but refresh.
			this.btnContinue.Enabled = false;
			this.btnPause.Enabled = false;
			this.btnStart.Enabled = false;
			this.btnStop.Enabled = false;
			this.miContinue.Enabled = false;
			this.miPause.Enabled = false;
			this.miStart.Enabled = false;
			this.miStop.Enabled = false;
		}
        // Set the selected service name to the text box
        this.txtSelectedService.Text = m_SelectedServiceName;
        // Re-enable the timer.
        this.tmrCheckStatus.Enabled = true;
    }
}

