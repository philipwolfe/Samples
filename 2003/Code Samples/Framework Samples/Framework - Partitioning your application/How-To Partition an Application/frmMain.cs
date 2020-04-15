//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.IO;
using System.Data;
using System.Windows.Forms;


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

    private System.Windows.Forms.TabControl TabControl1;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Button bnLoadDataGridComponent;

    private System.Windows.Forms.Button bnLoadDataGridUserControl;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Button bnLoadDataGridForm;

    private DataGridControl dgCustomersUserControl;

    private System.Windows.Forms.DataGrid dgCustomersComponent;

    private System.Windows.Forms.DataGrid dgCustomersForm;

    private System.Windows.Forms.TabPage tpForm;

    private System.Windows.Forms.TabPage tpComponent;

    private System.Windows.Forms.TabPage tpUserControl;

    private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.dgCustomersUserControl = new DataGridControl();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.tpForm = new System.Windows.Forms.TabPage();
		this.Label3 = new System.Windows.Forms.Label();
		this.bnLoadDataGridForm = new System.Windows.Forms.Button();
		this.dgCustomersForm = new System.Windows.Forms.DataGrid();
		this.tpComponent = new System.Windows.Forms.TabPage();
		this.Label1 = new System.Windows.Forms.Label();
		this.bnLoadDataGridComponent = new System.Windows.Forms.Button();
		this.dgCustomersComponent = new System.Windows.Forms.DataGrid();
		this.tpUserControl = new System.Windows.Forms.TabPage();
		this.bnLoadDataGridUserControl = new System.Windows.Forms.Button();
		this.Label2 = new System.Windows.Forms.Label();
		this.TabControl1.SuspendLayout();
		this.tpForm.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.dgCustomersForm)).BeginInit();
		this.tpComponent.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.dgCustomersComponent)).BeginInit();
		this.tpUserControl.SuspendLayout();
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
		// dgCustomersUserControl
		// 
		this.dgCustomersUserControl.AccessibleDescription = "Displays customers";
		this.dgCustomersUserControl.AccessibleName = "Customers DataGrid";
		this.dgCustomersUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
		this.dgCustomersUserControl.FileName = null;
		this.dgCustomersUserControl.Location = new System.Drawing.Point(16, 32);
		this.dgCustomersUserControl.Name = "dgCustomersUserControl";
		this.dgCustomersUserControl.Size = new System.Drawing.Size(384, 280);
		this.dgCustomersUserControl.TabIndex = 0;
		// 
		// TabControl1
		// 
		this.TabControl1.AccessibleDescription = "Display sections of App";
		this.TabControl1.AccessibleName = "Tab Control";
		this.TabControl1.Controls.Add(this.tpForm);
		this.TabControl1.Controls.Add(this.tpComponent);
		this.TabControl1.Controls.Add(this.tpUserControl);
		this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TabControl1.Location = new System.Drawing.Point(0, 0);
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.SelectedIndex = 0;
		this.TabControl1.Size = new System.Drawing.Size(426, 379);
		this.TabControl1.TabIndex = 1;
		// 
		// tpForm
		// 
		this.tpForm.Controls.Add(this.Label3);
		this.tpForm.Controls.Add(this.bnLoadDataGridForm);
		this.tpForm.Controls.Add(this.dgCustomersForm);
		this.tpForm.Location = new System.Drawing.Point(4, 22);
		this.tpForm.Name = "tpForm";
		this.tpForm.Size = new System.Drawing.Size(418, 353);
		this.tpForm.TabIndex = 2;
		this.tpForm.Text = "Form";
		// 
		// Label3
		// 
		this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.Label3.ForeColor = System.Drawing.Color.Blue;
		this.Label3.Location = new System.Drawing.Point(17, 8);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(384, 24);
		this.Label3.TabIndex = 5;
		this.Label3.Text = "Get customers via Form code - populate grid.";
		// 
		// bnLoadDataGridForm
		// 
		this.bnLoadDataGridForm.AccessibleDescription = "Gets customers and loads DataGrid";
		this.bnLoadDataGridForm.AccessibleName = "get {Customers";
		this.bnLoadDataGridForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.bnLoadDataGridForm.Location = new System.Drawing.Point(153, 320);
		this.bnLoadDataGridForm.Name = "bnLoadDataGridForm";
		this.bnLoadDataGridForm.Size = new System.Drawing.Size(112, 24);
		this.bnLoadDataGridForm.TabIndex = 4;
		this.bnLoadDataGridForm.Text = "&Get Customers";
		this.bnLoadDataGridForm.Click += new System.EventHandler(this.bnLoadDataGridForm_Click);
		// 
		// dgCustomersForm
		// 
		this.dgCustomersForm.AccessibleDescription = "Displays customers";
		this.dgCustomersForm.AccessibleName = "Customers DataGrid";
		this.dgCustomersForm.DataMember = "";
		this.dgCustomersForm.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgCustomersForm.Location = new System.Drawing.Point(17, 32);
		this.dgCustomersForm.Name = "dgCustomersForm";
		this.dgCustomersForm.ReadOnly = true;
		this.dgCustomersForm.Size = new System.Drawing.Size(384, 280);
		this.dgCustomersForm.TabIndex = 3;
		// 
		// tpComponent
		// 
		this.tpComponent.Controls.Add(this.Label1);
		this.tpComponent.Controls.Add(this.bnLoadDataGridComponent);
		this.tpComponent.Controls.Add(this.dgCustomersComponent);
		this.tpComponent.Location = new System.Drawing.Point(4, 22);
		this.tpComponent.Name = "tpComponent";
		this.tpComponent.Size = new System.Drawing.Size(418, 353);
		this.tpComponent.TabIndex = 0;
		this.tpComponent.Text = "Component";
		// 
		// Label1
		// 
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.Label1.ForeColor = System.Drawing.Color.Blue;
		this.Label1.Location = new System.Drawing.Point(16, 8);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(384, 24);
		this.Label1.TabIndex = 2;
		this.Label1.Text = "Get customers via Data Access Component - populate grid.";
		// 
		// bnLoadDataGridComponent
		// 
		this.bnLoadDataGridComponent.AccessibleDescription = "Gets customers and loads DataGrid";
		this.bnLoadDataGridComponent.AccessibleName = "get {Customers";
		this.bnLoadDataGridComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.bnLoadDataGridComponent.Location = new System.Drawing.Point(152, 320);
		this.bnLoadDataGridComponent.Name = "bnLoadDataGridComponent";
		this.bnLoadDataGridComponent.Size = new System.Drawing.Size(112, 24);
		this.bnLoadDataGridComponent.TabIndex = 1;
		this.bnLoadDataGridComponent.Text = "&Get Customers";
		this.bnLoadDataGridComponent.Click += new System.EventHandler(this.bnLoadDataGridComponent_Click);
		// 
		// dgCustomersComponent
		// 
		this.dgCustomersComponent.AccessibleDescription = "Displays customers";
		this.dgCustomersComponent.AccessibleName = "Customers DataGrid";
		this.dgCustomersComponent.DataMember = "";
		this.dgCustomersComponent.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgCustomersComponent.Location = new System.Drawing.Point(16, 32);
		this.dgCustomersComponent.Name = "dgCustomersComponent";
		this.dgCustomersComponent.ReadOnly = true;
		this.dgCustomersComponent.Size = new System.Drawing.Size(384, 280);
		this.dgCustomersComponent.TabIndex = 0;
		// 
		// tpUserControl
		// 
		this.tpUserControl.Controls.Add(this.bnLoadDataGridUserControl);
		this.tpUserControl.Controls.Add(this.Label2);
		this.tpUserControl.Controls.Add(this.dgCustomersUserControl);
		this.tpUserControl.Location = new System.Drawing.Point(4, 22);
		this.tpUserControl.Name = "tpUserControl";
		this.tpUserControl.Size = new System.Drawing.Size(418, 353);
		this.tpUserControl.TabIndex = 1;
		this.tpUserControl.Text = "User Control";
		// 
		// bnLoadDataGridUserControl
		// 
		this.bnLoadDataGridUserControl.AccessibleDescription = "Gets customers and loads DataGrid";
		this.bnLoadDataGridUserControl.AccessibleName = "get {Customers";
		this.bnLoadDataGridUserControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.bnLoadDataGridUserControl.Location = new System.Drawing.Point(152, 320);
		this.bnLoadDataGridUserControl.Name = "bnLoadDataGridUserControl";
		this.bnLoadDataGridUserControl.Size = new System.Drawing.Size(112, 24);
		this.bnLoadDataGridUserControl.TabIndex = 4;
		this.bnLoadDataGridUserControl.Text = "&Get Customers";
		this.bnLoadDataGridUserControl.Click += new System.EventHandler(this.bnLoadUserControl_Click);
		// 
		// Label2
		// 
		this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.Label2.ForeColor = System.Drawing.Color.Blue;
		this.Label2.Location = new System.Drawing.Point(16, 8);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(384, 24);
		this.Label2.TabIndex = 3;
		this.Label2.Text = "Get customers via User Control - populates grid.";
		// 
		// frmMain
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(426, 379);
		this.Controls.Add(this.TabControl1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.Menu = this.mnuMain;
		this.Name = "frmMain";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Title Comes from Assembly Info";
		this.TabControl1.ResumeLayout(false);
		this.tpForm.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.dgCustomersForm)).EndInit();
		this.tpComponent.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.dgCustomersComponent)).EndInit();
		this.tpUserControl.ResumeLayout(false);
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
	private void mnuExit_Click(object sender, System.EventArgs e)
	{
		// Close the current form
		this.Close();
	}

#endregion

    protected string strCustomersFile = "../../Customers.CSV";

    private void bnLoadDataGridComponent_Click(object sender, System.EventArgs e) 
	{
        // Access the DataAccessComponent directly,
        // populate the DataGrid with the results.
        // Gives flexibility, while hiding the details
        // of accessing the file.
        DataTable dtCustomers;
        // Instantiate the data access object
        Business oBusiness = new Business();
        // Pass the filename to open
        oBusiness.FileName = strCustomersFile;
        // Get a DataTable containing the customers
        // in the file
        dtCustomers = oBusiness.GetCustomers();
        // Display results
        dgCustomersComponent.SetDataBinding(dtCustomers, "");
    }

    private void bnLoadDataGridForm_Click(object sender, System.EventArgs e) 
	{
        // Access the customers file directly,
        // populate the DataGrid with the results.
        // Easy to see what's going on because all choices are made
        // here, however not re-usable and the developer
        // must know all of the details.  Contrast with 
        // code that accesses the component.
        StreamReader objStreamReader = new StreamReader(strCustomersFile);
        string strLine;
        string[] strColumns;
        DataTable dtCustomers = new DataTable();
        DataRow drCustomer;
        // Define the schema of the table,
        // used to define new rows.
        dtCustomers.Columns.Add("CustomerID");
        dtCustomers.Columns.Add("CompanyName");
        dtCustomers.Columns.Add("ContactName");
        dtCustomers.Columns.Add("Phone");
        // Extract line from file
        strLine = objStreamReader.ReadLine();
        // Enter loop is data is found

        do{
			// Create a DataRow to hold line
			drCustomer = dtCustomers.NewRow();
			// Create an array of columns separated by commas
			strColumns = strLine.Split(',');
			// Quickly fill row with column values
			drCustomer.ItemArray = strColumns;
			// Append row to DataTable
			dtCustomers.Rows.Add(drCustomer);
			//Extract another line
			strLine = objStreamReader.ReadLine();
		}while ( strLine != null);      
        // Display results
        dgCustomersForm.SetDataBinding(dtCustomers, "");
    }

    private void bnLoadUserControl_Click(object sender, System.EventArgs e) 
	{
        // Allow the User Control to do all of the work
        // not flexible since the results will be accessed and
        // displayed this DataGrid, however very re-usable and 
        // very easy for the developer to use.  Contrast with the
        // component access code.
        // Pass in the filename to access
        dgCustomersUserControl.FileName = strCustomersFile;
        //Display results
        dgCustomersUserControl.BindCustomers();
    }
}

