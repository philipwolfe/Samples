
using System.Data;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing;

public class frmMain:System.Windows.Forms.Form 
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

    protected const string MSDE_SERVER  = @"(local)\VSdotNET";

    protected const string SQL_CONNECTION_STRING  =	"Server=localhost;" + 
													"DataBase=Northwind;" + 
													"Integrated Security=SSPI;Connect Timeout=5";

    protected const string MSDE_CONNECTION_STRING  = "Server=" + MSDE_SERVER + ";" + 
													 "DataBase=Northwind;" + 
													 "Integrated Security=SSPI;Connect Timeout=5";

    private string Connectionstring  = SQL_CONNECTION_STRING;

    private bool HasConnected  = false;

    private string ServerName  = "localhost";

#region " Windows Form Designer generated code "

    public frmMain() 
	{

        //This call is required by the Windows Form Designer.

        InitializeComponent();

        // So that we only need to set the title of the application once,
        // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
        // to read the AssemblyTitle attribute.

        AssemblyInfo ainfo = new AssemblyInfo();

        this.Text = ainfo.Title;

        this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);

        crvBasic.DisplayToolbar = true;

        crvParameter.DisplayToolbar = true;

        crvDynamicFormat.DisplayToolbar = true;

        crvGraphDrillDown.DisplayToolbar = true;

        // Here we need to populate the combo box with the customer names found in the
        // customers table in the northwind databse.

        SqlConnection cnSQL ;

        SqlCommand cmSQL ;

        // Create a datareader object to read the data from the command object.

        SqlDataReader drSQL ;

        // Display a status message box saying that we are attempting to connect.
        // This only needs to be done the first time a connection is attempted.
        // After we have determined that MSDE or SQL Server is installed, this 
        // message no longer needs to be displayed

        frmStatus frmStatusMessage =new frmStatus();

        if (!HasConnected)
		{

            frmStatusMessage.Show("Connecting to SQL Server");

        }

        // Attempt to connect to SQL server or MSDE

        bool IsConnecting  = true;

        while (IsConnecting)
		{

			try 
			{

				// Define connection string.
				// You may need to change this for your environment.

				cnSQL = new SqlConnection(Connectionstring);
				cnSQL.Open();

				// Instantiate Command Object to execute SQL Statements

				cmSQL = new SqlCommand();

				// Attach the command to the connection

				cmSQL.Connection = cnSQL;

				// Set the command type to Text

				cmSQL.CommandType = CommandType.Text;

				// START: Commands are for this How-To only.
				// Drop GetAllCustomerOrders Store Procedure if it exists.

				cmSQL.CommandText = "IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GetAllCustomerOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) " + 

					"DROP PROCEDURE [dbo].[GetAllCustomerOrders] ";

				// Execute the statement

				cmSQL.ExecuteNonQuery();

				// Create GetAllCustomerOrders Stored Procedure

				cmSQL.CommandText = "CREATE PROCEDURE dbo.GetAllCustomerOrders " + "AS " + 
					"SELECT CUST.CompanyName, " + 
					"ORD.OrderID, " + 
					"ORD.OrderDate, " + 
					"ORD.ShippedDate, " + 
					"PROD.ProductName, " + 
					"ORD_D.UnitPrice, " + 
					"ORD_D.Quantity " + 
					"FROM Customers CUST " + 
					"INNER JOIN Orders ORD " + 
					"ON CUST.CustomerID = ORD.CustomerID " + 
					"INNER JOIN [Order Details] ORD_D " + 
					"ON ORD.OrderID = ORD_D.OrderID " + 
					"INNER JOIN Products PROD " + 
					"ON ORD_D.ProductID = PROD.ProductID " + 
					"ORDER BY ORD.OrderDate	" + 
					"Return";

				// Execute the statement

				cmSQL.ExecuteNonQuery();

				// Drop GetCustomerOrders Store Procedure if it exists.  This How-To Only

				cmSQL.CommandText = "IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) " + 
					"DROP PROCEDURE [dbo].[GetCustomerOrders] ";

				// Execute the statement

				cmSQL.ExecuteNonQuery();

				cmSQL.CommandText = "CREATE PROCEDURE dbo.GetCustomerOrders " + 
					"@CustomerName nvarchar(50) " + 
					"AS " + 
					"SELECT ORD.OrderID, " + 
					"ORD.ShippedDate, " + 
					"ORD.OrderDate, " + 
					"PROD.ProductName, " + 
					"ORD_D.UnitPrice, " + 
					"ORD_D.Quantity " + 
					"FROM Customers CUST " + 
					"INNER JOIN Orders ORD " + 
					"ON CUST.CustomerID = ORD.CustomerID " + 
					"INNER JOIN [Order Details] ORD_D " + 
					"ON ORD.OrderID = ORD_D.OrderID " + 
					"INNER JOIN Products PROD " + 
					"ON ORD_D.ProductID = PROD.ProductID " + 
					"WHERE CUST.CompanyName = @CustomerName " + 
					"ORDER BY ORD.OrderDate	" + 
					"RETURN";

				// Execute the statement

				cmSQL.ExecuteNonQuery();

				// END: Commands for this How-To only.             
				// Select statement to pull all the customers from
				// the customer table in the northwind databse.

				cmSQL.CommandText = "SELECT CompanyName " + 
					"FROM Customers";

				// Execute the query we defined in the command object.

				drSQL = cmSQL.ExecuteReader();

				// Loop through the records while there is still records to 
				// retrieve.

				while (drSQL.Read())
				{

					// Add the Customers Company Name to the combo box.
					cbCustomers.Items.Add(drSQL["CompanyName"].ToString());

				}

                // Set the combo box to the first item.

                cbCustomers.SelectedIndex = 0;
                IsConnecting = false;
                HasConnected = true;

                // Close Connection.

                drSQL.Close();
                cnSQL.Close();

                // Clean up.

                cnSQL.Dispose();
                cmSQL.Dispose();

			} 
			catch( SqlException Err)
			{

				if (Connectionstring == SQL_CONNECTION_STRING)
				{

					// Couldn't connect to SQL server. Now try MSDE
					Connectionstring = MSDE_CONNECTION_STRING;
					ServerName = MSDE_SERVER;
					frmStatusMessage.Show("Connecting to MSDE");
				}
				else 
				{

					// Unable to connect to SQL Server or MSDE

					frmStatusMessage.Close();
					MessageBox.Show("To run this sample you must have SQL Server ot MSDE with " + 
									"the Northwind database installed.  For instructions on " + 
									"installing MSDE, view the Readme file.", 
									"SQL Server/MSDE not found");

					// Quit program if neither connection method was successful.

					
					Application.Exit();

				}

           } 
			catch(Exception Err) 
			{

                // Report Non SQL Error to the user.
                MessageBox.Show(Err.ToString(),  "General Error");

            }

        }

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

    internal System.Windows.Forms.MenuItem MenuItem1;

    internal System.Windows.Forms.MenuItem MenuItem2;

    private System.Windows.Forms.MenuItem mnuAbout;

    private System.Windows.Forms.MenuItem mnuExit;

    internal System.Windows.Forms.TabControl TabControl1;

    internal System.Windows.Forms.TabPage tpReportBasic;

    internal CrystalDecisions.Windows.Forms.CrystalReportViewer crvBasic;

    internal System.Windows.Forms.TabPage tpParameterReport;

    internal CrystalDecisions.Windows.Forms.CrystalReportViewer crvParameter;

    internal System.Windows.Forms.Label lblCustomer;

    internal System.Windows.Forms.ComboBox cbCustomers;

    internal System.Windows.Forms.Button btnPreviewCustomerReport;

    internal System.Windows.Forms.TabPage tpDynamicFormatReport;

    internal System.Windows.Forms.TabPage tpGraphDrillDownReport;

    internal CrystalDecisions.Windows.Forms.CrystalReportViewer crvDynamicFormat;

    internal CrystalDecisions.Windows.Forms.CrystalReportViewer crvGraphDrillDown;

    internal System.Windows.Forms.TextBox txtUnitsToHighlight;

    internal System.Windows.Forms.ComboBox cbHighlightColor;

    internal System.Windows.Forms.Label Label1;

    internal System.Windows.Forms.Label Label2;

    internal System.Windows.Forms.Button btnPreviewDrillDownReport;

    internal System.Windows.Forms.Label Label3;

    internal System.Windows.Forms.Label Label4;

    internal System.Windows.Forms.Button btnPreviewBasicReport;

    internal System.Windows.Forms.Button btnPreviewDynamicReport;

    private void InitializeComponent() 
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.MenuItem1 = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.MenuItem2 = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.TabControl1 = new System.Windows.Forms.TabControl();

        this.tpReportBasic = new System.Windows.Forms.TabPage();

        this.btnPreviewBasicReport = new System.Windows.Forms.Button();

        this.crvBasic = new CrystalDecisions.Windows.Forms.CrystalReportViewer();

        this.tpDynamicFormatReport = new System.Windows.Forms.TabPage();

        this.Label4 = new System.Windows.Forms.Label();

        this.btnPreviewDynamicReport = new System.Windows.Forms.Button();

        this.Label2 = new System.Windows.Forms.Label();

        this.Label1 = new System.Windows.Forms.Label();

        this.cbHighlightColor = new System.Windows.Forms.ComboBox();

        this.txtUnitsToHighlight = new System.Windows.Forms.TextBox();

        this.crvDynamicFormat = new CrystalDecisions.Windows.Forms.CrystalReportViewer();

        this.tpParameterReport = new System.Windows.Forms.TabPage();

        this.btnPreviewCustomerReport = new System.Windows.Forms.Button();

        this.lblCustomer = new System.Windows.Forms.Label();

        this.cbCustomers = new System.Windows.Forms.ComboBox();

        this.crvParameter = new CrystalDecisions.Windows.Forms.CrystalReportViewer();

        this.tpGraphDrillDownReport = new System.Windows.Forms.TabPage();

        this.Label3 = new System.Windows.Forms.Label();

        this.btnPreviewDrillDownReport = new System.Windows.Forms.Button();

        this.crvGraphDrillDown = new CrystalDecisions.Windows.Forms.CrystalReportViewer();

        this.TabControl1.SuspendLayout();

        this.tpReportBasic.SuspendLayout();

        this.tpDynamicFormatReport.SuspendLayout();

        this.tpParameterReport.SuspendLayout();

        this.tpGraphDrillDownReport.SuspendLayout();

        this.SuspendLayout();

        //

        //mnuMain

        //

        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.MenuItem1, this.MenuItem2});

        this.mnuMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("mnuMain.RightToLeft");

        //

        //MenuItem1

        //

        this.MenuItem1.Enabled = (bool) resources.GetObject("MenuItem1.Enabled");

        this.MenuItem1.Index = 0;

        this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});

        this.MenuItem1.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem1.Shortcut");

        this.MenuItem1.ShowShortcut = (bool) resources.GetObject("MenuItem1.ShowShortcut");

        this.MenuItem1.Text = resources.GetString("MenuItem1.Text");

        this.MenuItem1.Visible = (bool) resources.GetObject("MenuItem1.Visible");

        //

        //mnuExit

        //

        this.mnuExit.Enabled = (bool) resources.GetObject("mnuExit.Enabled");

        this.mnuExit.Index = 0;

        this.mnuExit.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuExit.Shortcut");

        this.mnuExit.ShowShortcut = (bool) resources.GetObject("mnuExit.ShowShortcut");

        this.mnuExit.Text = resources.GetString("mnuExit.Text");

        this.mnuExit.Visible = (bool) resources.GetObject("mnuExit.Visible");

		this.mnuExit.Click+=new EventHandler(mnuExit_Click);

        //

        //MenuItem2

        //

        this.MenuItem2.Enabled = (bool) resources.GetObject("MenuItem2.Enabled");

        this.MenuItem2.Index = 1;

        this.MenuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});

        this.MenuItem2.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem2.Shortcut");

        this.MenuItem2.ShowShortcut = (bool) resources.GetObject("MenuItem2.ShowShortcut");

        this.MenuItem2.Text = resources.GetString("MenuItem2.Text");

        this.MenuItem2.Visible = (bool) resources.GetObject("MenuItem2.Visible");

        //

        //mnuAbout

        //

        this.mnuAbout.Enabled = (bool) resources.GetObject("mnuAbout.Enabled");

        this.mnuAbout.Index = 0;

        this.mnuAbout.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuAbout.Shortcut");

        this.mnuAbout.ShowShortcut = (bool) resources.GetObject("mnuAbout.ShowShortcut");

        this.mnuAbout.Text = resources.GetString("mnuAbout.Text");

        this.mnuAbout.Visible = (bool) resources.GetObject("mnuAbout.Visible");

		this.mnuAbout.Click+=new EventHandler(mnuAbout_Click);

        //

        //TabControl1

        //

        this.TabControl1.AccessibleDescription = (string) resources.GetObject("TabControl1.AccessibleDescription");

        this.TabControl1.AccessibleName = (string) resources.GetObject("TabControl1.AccessibleName");

        this.TabControl1.Alignment = (System.Windows.Forms.TabAlignment) resources.GetObject("TabControl1.Alignment");

        this.TabControl1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("TabControl1.Anchor");

        this.TabControl1.Appearance = (System.Windows.Forms.TabAppearance) resources.GetObject("TabControl1.Appearance");

        this.TabControl1.BackgroundImage = (System.Drawing.Image) resources.GetObject("TabControl1.BackgroundImage");

        this.TabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {this.tpReportBasic, this.tpDynamicFormatReport, this.tpParameterReport, this.tpGraphDrillDownReport});

        this.TabControl1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("TabControl1.Dock");

        this.TabControl1.Enabled = (bool) resources.GetObject("TabControl1.Enabled");

        this.TabControl1.Font = (System.Drawing.Font) resources.GetObject("TabControl1.Font");

        this.TabControl1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("TabControl1.ImeMode");

        this.TabControl1.ItemSize = (System.Drawing.Size) resources.GetObject("TabControl1.ItemSize");

        this.TabControl1.Location = (System.Drawing.Point) resources.GetObject("TabControl1.Location");

        this.TabControl1.Name = "TabControl1";

        this.TabControl1.Padding = (System.Drawing.Point) resources.GetObject("TabControl1.Padding");

        this.TabControl1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("TabControl1.RightToLeft");

        this.TabControl1.SelectedIndex = 0;

        this.TabControl1.ShowToolTips = (bool) resources.GetObject("TabControl1.ShowToolTips");

        this.TabControl1.Size = (System.Drawing.Size) resources.GetObject("TabControl1.Size");

        this.TabControl1.TabIndex = (int) resources.GetObject("TabControl1.TabIndex");

        this.TabControl1.Text = resources.GetString("TabControl1.Text");

        this.TabControl1.Visible = (bool) resources.GetObject("TabControl1.Visible");

        //

        //tpReportBasic

        //

        this.tpReportBasic.AccessibleDescription = (string) resources.GetObject("tpReportBasic.AccessibleDescription");

        this.tpReportBasic.AccessibleName = (string) resources.GetObject("tpReportBasic.AccessibleName");

        this.tpReportBasic.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpReportBasic.Anchor");

        this.tpReportBasic.AutoScroll = (bool) resources.GetObject("tpReportBasic.AutoScroll");

        this.tpReportBasic.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpReportBasic.AutoScrollMargin");

        this.tpReportBasic.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpReportBasic.AutoScrollMinSize");

        this.tpReportBasic.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpReportBasic.BackgroundImage");

        this.tpReportBasic.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnPreviewBasicReport, this.crvBasic});

        this.tpReportBasic.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpReportBasic.Dock");

        this.tpReportBasic.Enabled = (bool) resources.GetObject("tpReportBasic.Enabled");

        this.tpReportBasic.Font = (System.Drawing.Font) resources.GetObject("tpReportBasic.Font");

        this.tpReportBasic.ImageIndex = (int) resources.GetObject("tpReportBasic.ImageIndex");

        this.tpReportBasic.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpReportBasic.ImeMode");

        this.tpReportBasic.Location = (System.Drawing.Point) resources.GetObject("tpReportBasic.Location");

        this.tpReportBasic.Name = "tpReportBasic";

        this.tpReportBasic.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpReportBasic.RightToLeft");

        this.tpReportBasic.Size = (System.Drawing.Size) resources.GetObject("tpReportBasic.Size");

        this.tpReportBasic.TabIndex = (int) resources.GetObject("tpReportBasic.TabIndex");

        this.tpReportBasic.Text = resources.GetString("tpReportBasic.Text");

        this.tpReportBasic.ToolTipText = resources.GetString("tpReportBasic.ToolTipText");

        this.tpReportBasic.Visible = (bool) resources.GetObject("tpReportBasic.Visible");

        //

        //btnPreviewBasicReport

        //

        this.btnPreviewBasicReport.AccessibleDescription = resources.GetString("btnPreviewBasicReport.AccessibleDescription");

        this.btnPreviewBasicReport.AccessibleName = resources.GetString("btnPreviewBasicReport.AccessibleName");

        this.btnPreviewBasicReport.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnPreviewBasicReport.Anchor");

        this.btnPreviewBasicReport.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnPreviewBasicReport.BackgroundImage");

        this.btnPreviewBasicReport.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnPreviewBasicReport.Dock");

        this.btnPreviewBasicReport.Enabled = (bool) resources.GetObject("btnPreviewBasicReport.Enabled");

        this.btnPreviewBasicReport.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnPreviewBasicReport.FlatStyle");

        this.btnPreviewBasicReport.Font = (System.Drawing.Font) resources.GetObject("btnPreviewBasicReport.Font");

        this.btnPreviewBasicReport.Image = (System.Drawing.Image) resources.GetObject("btnPreviewBasicReport.Image");

        this.btnPreviewBasicReport.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPreviewBasicReport.ImageAlign");

        this.btnPreviewBasicReport.ImageIndex = (int) resources.GetObject("btnPreviewBasicReport.ImageIndex");

        this.btnPreviewBasicReport.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnPreviewBasicReport.ImeMode");

        this.btnPreviewBasicReport.Location = (System.Drawing.Point) resources.GetObject("btnPreviewBasicReport.Location");

        this.btnPreviewBasicReport.Name = "btnPreviewBasicReport";

        this.btnPreviewBasicReport.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnPreviewBasicReport.RightToLeft");

        this.btnPreviewBasicReport.Size = (System.Drawing.Size) resources.GetObject("btnPreviewBasicReport.Size");

        this.btnPreviewBasicReport.TabIndex = (int) resources.GetObject("btnPreviewBasicReport.TabIndex");

        this.btnPreviewBasicReport.Text = resources.GetString("btnPreviewBasicReport.Text");

        this.btnPreviewBasicReport.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPreviewBasicReport.TextAlign");

        this.btnPreviewBasicReport.Visible = (bool) resources.GetObject("btnPreviewBasicReport.Visible");

		this.btnPreviewBasicReport.Click+=new EventHandler(btnPreviewBasicReport_Click);
        //

        //crvBasic

        //

        this.crvBasic.AccessibleDescription = (string) resources.GetObject("crvBasic.AccessibleDescription");

        this.crvBasic.AccessibleName = (string) resources.GetObject("crvBasic.AccessibleName");

        this.crvBasic.ActiveViewIndex = -1;

        this.crvBasic.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("crvBasic.Anchor");

        this.crvBasic.AutoScroll = (bool) resources.GetObject("crvBasic.AutoScroll");

        this.crvBasic.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("crvBasic.AutoScrollMargin");

        this.crvBasic.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("crvBasic.AutoScrollMinSize");

        this.crvBasic.BackgroundImage = (System.Drawing.Image) resources.GetObject("crvBasic.BackgroundImage");

        this.crvBasic.DisplayBackgroundEdge = (bool) resources.GetObject("crvBasic.DisplayBackgroundEdge");

        this.crvBasic.DisplayGroupTree = (bool) resources.GetObject("crvBasic.DisplayGroupTree");

        this.crvBasic.DisplayToolbar = (bool) resources.GetObject("crvBasic.DisplayToolbar");

        this.crvBasic.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("crvBasic.Dock");

        this.crvBasic.Enabled = (bool) resources.GetObject("crvBasic.Enabled");

        this.crvBasic.EnableDrillDown = (bool) resources.GetObject("crvBasic.EnableDrillDown");

        this.crvBasic.Font = (System.Drawing.Font) resources.GetObject("crvBasic.Font");

        this.crvBasic.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("crvBasic.ImeMode");

        this.crvBasic.Location = (System.Drawing.Point) resources.GetObject("crvBasic.Location");

        this.crvBasic.Name = "crvBasic";

        this.crvBasic.ReportSource = null;

        this.crvBasic.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("crvBasic.RightToLeft");

        this.crvBasic.ShowCloseButton = (bool) resources.GetObject("crvBasic.ShowCloseButton");

        this.crvBasic.ShowExportButton = (bool) resources.GetObject("crvBasic.ShowExportButton");

        this.crvBasic.ShowGotoPageButton = (bool) resources.GetObject("crvBasic.ShowGotoPageButton");

        this.crvBasic.ShowGroupTreeButton = (bool) resources.GetObject("crvBasic.ShowGroupTreeButton");

        this.crvBasic.ShowPageNavigateButtons = (bool) resources.GetObject("crvBasic.ShowPageNavigateButtons");

        this.crvBasic.ShowPrintButton = (bool) resources.GetObject("crvBasic.ShowPrintButton");

        this.crvBasic.ShowRefreshButton = (bool) resources.GetObject("crvBasic.ShowRefreshButton");

        this.crvBasic.ShowTextSearchButton = (bool) resources.GetObject("crvBasic.ShowTextSearchButton");

        this.crvBasic.ShowZoomButton = (bool) resources.GetObject("crvBasic.ShowZoomButton");

        this.crvBasic.Size = (System.Drawing.Size) resources.GetObject("crvBasic.Size");

        this.crvBasic.TabIndex = (int) resources.GetObject("crvBasic.TabIndex");

        this.crvBasic.Visible = (bool) resources.GetObject("crvBasic.Visible");

        //

        //tpDynamicFormatReport

        //

        this.tpDynamicFormatReport.AccessibleDescription = (string) resources.GetObject("tpDynamicFormatReport.AccessibleDescription");

        this.tpDynamicFormatReport.AccessibleName = (string) resources.GetObject("tpDynamicFormatReport.AccessibleName");

        this.tpDynamicFormatReport.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpDynamicFormatReport.Anchor");

        this.tpDynamicFormatReport.AutoScroll = (bool) resources.GetObject("tpDynamicFormatReport.AutoScroll");

        this.tpDynamicFormatReport.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpDynamicFormatReport.AutoScrollMargin");

        this.tpDynamicFormatReport.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpDynamicFormatReport.AutoScrollMinSize");

        this.tpDynamicFormatReport.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpDynamicFormatReport.BackgroundImage");

        this.tpDynamicFormatReport.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label4, this.btnPreviewDynamicReport, this.Label2, this.Label1, this.cbHighlightColor, this.txtUnitsToHighlight, this.crvDynamicFormat});

        this.tpDynamicFormatReport.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpDynamicFormatReport.Dock");

        this.tpDynamicFormatReport.Enabled = (bool) resources.GetObject("tpDynamicFormatReport.Enabled");

        this.tpDynamicFormatReport.Font = (System.Drawing.Font) resources.GetObject("tpDynamicFormatReport.Font");

        this.tpDynamicFormatReport.ImageIndex = (int) resources.GetObject("tpDynamicFormatReport.ImageIndex");

        this.tpDynamicFormatReport.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpDynamicFormatReport.ImeMode");

        this.tpDynamicFormatReport.Location = (System.Drawing.Point) resources.GetObject("tpDynamicFormatReport.Location");

        this.tpDynamicFormatReport.Name = "tpDynamicFormatReport";

        this.tpDynamicFormatReport.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpDynamicFormatReport.RightToLeft");

        this.tpDynamicFormatReport.Size = (System.Drawing.Size) resources.GetObject("tpDynamicFormatReport.Size");

        this.tpDynamicFormatReport.TabIndex = (int) resources.GetObject("tpDynamicFormatReport.TabIndex");

        this.tpDynamicFormatReport.Text = resources.GetString("tpDynamicFormatReport.Text");

        this.tpDynamicFormatReport.ToolTipText = resources.GetString("tpDynamicFormatReport.ToolTipText");

        this.tpDynamicFormatReport.Visible = (bool) resources.GetObject("tpDynamicFormatReport.Visible");

        //

        //Label4

        //

        this.Label4.AccessibleDescription = (string) resources.GetObject("Label4.AccessibleDescription");

        this.Label4.AccessibleName = (string) resources.GetObject("Label4.AccessibleName");

        this.Label4.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label4.Anchor");

        this.Label4.AutoSize = (bool) resources.GetObject("Label4.AutoSize");

        this.Label4.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label4.Dock");

        this.Label4.Enabled = (bool) resources.GetObject("Label4.Enabled");

        this.Label4.Font = (System.Drawing.Font) resources.GetObject("Label4.Font");

        this.Label4.Image = (System.Drawing.Image) resources.GetObject("Label4.Image");

        this.Label4.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label4.ImageAlign");

        this.Label4.ImageIndex = (int) resources.GetObject("Label4.ImageIndex");

        this.Label4.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label4.ImeMode");

        this.Label4.Location = (System.Drawing.Point) resources.GetObject("Label4.Location");

        this.Label4.Name = "Label4";

        this.Label4.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label4.RightToLeft");

        this.Label4.Size = (System.Drawing.Size) resources.GetObject("Label4.Size");

        this.Label4.TabIndex = (int) resources.GetObject("Label4.TabIndex");

        this.Label4.Text = resources.GetString("Label4.Text");

        this.Label4.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label4.TextAlign");

        this.Label4.Visible = (bool) resources.GetObject("Label4.Visible");

        //

        //btnPreviewDynamicReport

        //

        this.btnPreviewDynamicReport.AccessibleDescription = resources.GetString("btnPreviewDynamicReport.AccessibleDescription");

        this.btnPreviewDynamicReport.AccessibleName = resources.GetString("btnPreviewDynamicReport.AccessibleName");

        this.btnPreviewDynamicReport.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnPreviewDynamicReport.Anchor");

        this.btnPreviewDynamicReport.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnPreviewDynamicReport.BackgroundImage");

        this.btnPreviewDynamicReport.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnPreviewDynamicReport.Dock");

        this.btnPreviewDynamicReport.Enabled = (bool) resources.GetObject("btnPreviewDynamicReport.Enabled");

        this.btnPreviewDynamicReport.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnPreviewDynamicReport.FlatStyle");

        this.btnPreviewDynamicReport.Font = (System.Drawing.Font) resources.GetObject("btnPreviewDynamicReport.Font");

        this.btnPreviewDynamicReport.Image = (System.Drawing.Image) resources.GetObject("btnPreviewDynamicReport.Image");

        this.btnPreviewDynamicReport.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPreviewDynamicReport.ImageAlign");

        this.btnPreviewDynamicReport.ImageIndex = (int) resources.GetObject("btnPreviewDynamicReport.ImageIndex");

        this.btnPreviewDynamicReport.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnPreviewDynamicReport.ImeMode");

        this.btnPreviewDynamicReport.Location = (System.Drawing.Point) resources.GetObject("btnPreviewDynamicReport.Location");

        this.btnPreviewDynamicReport.Name = "btnPreviewDynamicReport";

        this.btnPreviewDynamicReport.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnPreviewDynamicReport.RightToLeft");

        this.btnPreviewDynamicReport.Size = (System.Drawing.Size) resources.GetObject("btnPreviewDynamicReport.Size");

        this.btnPreviewDynamicReport.TabIndex = (int) resources.GetObject("btnPreviewDynamicReport.TabIndex");

        this.btnPreviewDynamicReport.Text = resources.GetString("btnPreviewDynamicReport.Text");

        this.btnPreviewDynamicReport.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPreviewDynamicReport.TextAlign");

        this.btnPreviewDynamicReport.Visible = (bool) resources.GetObject("btnPreviewDynamicReport.Visible");

		this.btnPreviewDynamicReport.Click+=new EventHandler(btnPreviewDynamicReport_Click);
		//

        //Label2

        //

        this.Label2.AccessibleDescription = (string) resources.GetObject("Label2.AccessibleDescription");

        this.Label2.AccessibleName = (string) resources.GetObject("Label2.AccessibleName");

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

        //Label1

        //

        this.Label1.AccessibleDescription = (string) resources.GetObject("Label1.AccessibleDescription");

        this.Label1.AccessibleName = (string) resources.GetObject("Label1.AccessibleName");

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

        //cbHighlightColor

        //

        this.cbHighlightColor.AccessibleDescription = resources.GetString("cbHighlightColor.AccessibleDescription");

        this.cbHighlightColor.AccessibleName = resources.GetString("cbHighlightColor.AccessibleName");

        this.cbHighlightColor.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cbHighlightColor.Anchor");

        this.cbHighlightColor.BackgroundImage = (System.Drawing.Image) resources.GetObject("cbHighlightColor.BackgroundImage");

        this.cbHighlightColor.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cbHighlightColor.Dock");

        this.cbHighlightColor.Enabled = (bool) resources.GetObject("cbHighlightColor.Enabled");

        this.cbHighlightColor.Font = (System.Drawing.Font) resources.GetObject("cbHighlightColor.Font");

        this.cbHighlightColor.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cbHighlightColor.ImeMode");

        this.cbHighlightColor.IntegralHeight = (bool) resources.GetObject("cbHighlightColor.IntegralHeight");

        this.cbHighlightColor.ItemHeight = (int) resources.GetObject("cbHighlightColor.ItemHeight");

        this.cbHighlightColor.Items.AddRange(new Object[] {resources.GetString("cbHighlightColor.Items.Items"), resources.GetString("cbHighlightColor.Items.Items1"), resources.GetString("cbHighlightColor.Items.Items2")});

        this.cbHighlightColor.Location = (System.Drawing.Point) resources.GetObject("cbHighlightColor.Location");

        this.cbHighlightColor.MaxDropDownItems = (int) resources.GetObject("cbHighlightColor.MaxDropDownItems");

        this.cbHighlightColor.MaxLength = (int) resources.GetObject("cbHighlightColor.MaxLength");

        this.cbHighlightColor.Name = "cbHighlightColor";

        this.cbHighlightColor.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cbHighlightColor.RightToLeft");

        this.cbHighlightColor.Size = (System.Drawing.Size) resources.GetObject("cbHighlightColor.Size");

        this.cbHighlightColor.TabIndex = (int) resources.GetObject("cbHighlightColor.TabIndex");

        this.cbHighlightColor.Text = resources.GetString("cbHighlightColor.Text");

        this.cbHighlightColor.Visible = (bool) resources.GetObject("cbHighlightColor.Visible");

        //

        //txtUnitsToHighlight

        //

        this.txtUnitsToHighlight.AccessibleDescription = resources.GetString("txtUnitsToHighlight.AccessibleDescription");

        this.txtUnitsToHighlight.AccessibleName = resources.GetString("txtUnitsToHighlight.AccessibleName");

        this.txtUnitsToHighlight.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtUnitsToHighlight.Anchor");

        this.txtUnitsToHighlight.AutoSize = (bool) resources.GetObject("txtUnitsToHighlight.AutoSize");

        this.txtUnitsToHighlight.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtUnitsToHighlight.BackgroundImage");

        this.txtUnitsToHighlight.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtUnitsToHighlight.Dock");

        this.txtUnitsToHighlight.Enabled = (bool) resources.GetObject("txtUnitsToHighlight.Enabled");

        this.txtUnitsToHighlight.Font = (System.Drawing.Font) resources.GetObject("txtUnitsToHighlight.Font");

        this.txtUnitsToHighlight.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtUnitsToHighlight.ImeMode");

        this.txtUnitsToHighlight.Location = (System.Drawing.Point) resources.GetObject("txtUnitsToHighlight.Location");

        this.txtUnitsToHighlight.MaxLength = (int) resources.GetObject("txtUnitsToHighlight.MaxLength");

        this.txtUnitsToHighlight.Multiline = (bool) resources.GetObject("txtUnitsToHighlight.Multiline");

        this.txtUnitsToHighlight.Name = "txtUnitsToHighlight";

        this.txtUnitsToHighlight.PasswordChar = (char) resources.GetObject("txtUnitsToHighlight.PasswordChar");

        this.txtUnitsToHighlight.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtUnitsToHighlight.RightToLeft");

        this.txtUnitsToHighlight.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtUnitsToHighlight.ScrollBars");

        this.txtUnitsToHighlight.Size = (System.Drawing.Size) resources.GetObject("txtUnitsToHighlight.Size");

        this.txtUnitsToHighlight.TabIndex = (int) resources.GetObject("txtUnitsToHighlight.TabIndex");

        this.txtUnitsToHighlight.Text = resources.GetString("txtUnitsToHighlight.Text");

        this.txtUnitsToHighlight.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtUnitsToHighlight.TextAlign");

        this.txtUnitsToHighlight.Visible = (bool) resources.GetObject("txtUnitsToHighlight.Visible");

        this.txtUnitsToHighlight.WordWrap = (bool) resources.GetObject("txtUnitsToHighlight.WordWrap");

        //

        //crvDynamicFormat

        //

        this.crvDynamicFormat.AccessibleDescription = (string) resources.GetObject("crvDynamicFormat.AccessibleDescription");

        this.crvDynamicFormat.AccessibleName = (string) resources.GetObject("crvDynamicFormat.AccessibleName");

        this.crvDynamicFormat.ActiveViewIndex = -1;

        this.crvDynamicFormat.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("crvDynamicFormat.Anchor");

        this.crvDynamicFormat.AutoScroll = (bool) resources.GetObject("crvDynamicFormat.AutoScroll");

        this.crvDynamicFormat.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("crvDynamicFormat.AutoScrollMargin");

        this.crvDynamicFormat.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("crvDynamicFormat.AutoScrollMinSize");

        this.crvDynamicFormat.BackgroundImage = (System.Drawing.Image) resources.GetObject("crvDynamicFormat.BackgroundImage");

        this.crvDynamicFormat.DisplayBackgroundEdge = (bool) resources.GetObject("crvDynamicFormat.DisplayBackgroundEdge");

        this.crvDynamicFormat.DisplayGroupTree = (bool) resources.GetObject("crvDynamicFormat.DisplayGroupTree");

        this.crvDynamicFormat.DisplayToolbar = (bool) resources.GetObject("crvDynamicFormat.DisplayToolbar");

        this.crvDynamicFormat.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("crvDynamicFormat.Dock");

        this.crvDynamicFormat.Enabled = (bool) resources.GetObject("crvDynamicFormat.Enabled");

        this.crvDynamicFormat.EnableDrillDown = (bool) resources.GetObject("crvDynamicFormat.EnableDrillDown");

        this.crvDynamicFormat.Font = (System.Drawing.Font) resources.GetObject("crvDynamicFormat.Font");

        this.crvDynamicFormat.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("crvDynamicFormat.ImeMode");

        this.crvDynamicFormat.Location = (System.Drawing.Point) resources.GetObject("crvDynamicFormat.Location");

        this.crvDynamicFormat.Name = "crvDynamicFormat";

        this.crvDynamicFormat.ReportSource = null;

        this.crvDynamicFormat.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("crvDynamicFormat.RightToLeft");

        this.crvDynamicFormat.ShowCloseButton = (bool) resources.GetObject("crvDynamicFormat.ShowCloseButton");

        this.crvDynamicFormat.ShowExportButton = (bool) resources.GetObject("crvDynamicFormat.ShowExportButton");

        this.crvDynamicFormat.ShowGotoPageButton = (bool) resources.GetObject("crvDynamicFormat.ShowGotoPageButton");

        this.crvDynamicFormat.ShowGroupTreeButton = (bool) resources.GetObject("crvDynamicFormat.ShowGroupTreeButton");

        this.crvDynamicFormat.ShowPageNavigateButtons = (bool) resources.GetObject("crvDynamicFormat.ShowPageNavigateButtons");

        this.crvDynamicFormat.ShowPrintButton = (bool) resources.GetObject("crvDynamicFormat.ShowPrintButton");

        this.crvDynamicFormat.ShowRefreshButton = (bool) resources.GetObject("crvDynamicFormat.ShowRefreshButton");

        this.crvDynamicFormat.ShowTextSearchButton = (bool) resources.GetObject("crvDynamicFormat.ShowTextSearchButton");

        this.crvDynamicFormat.ShowZoomButton = (bool) resources.GetObject("crvDynamicFormat.ShowZoomButton");

        this.crvDynamicFormat.Size = (System.Drawing.Size) resources.GetObject("crvDynamicFormat.Size");

        this.crvDynamicFormat.TabIndex = (int) resources.GetObject("crvDynamicFormat.TabIndex");

        this.crvDynamicFormat.Visible = (bool) resources.GetObject("crvDynamicFormat.Visible");

        //

        //tpParameterReport

        //

        this.tpParameterReport.AccessibleDescription = (string) resources.GetObject("tpParameterReport.AccessibleDescription");

        this.tpParameterReport.AccessibleName = (string) resources.GetObject("tpParameterReport.AccessibleName");

        this.tpParameterReport.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpParameterReport.Anchor");

        this.tpParameterReport.AutoScroll = (bool) resources.GetObject("tpParameterReport.AutoScroll");

        this.tpParameterReport.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpParameterReport.AutoScrollMargin");

        this.tpParameterReport.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpParameterReport.AutoScrollMinSize");

        this.tpParameterReport.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpParameterReport.BackgroundImage");

        this.tpParameterReport.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnPreviewCustomerReport, this.lblCustomer, this.cbCustomers, this.crvParameter});

        this.tpParameterReport.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpParameterReport.Dock");

        this.tpParameterReport.Enabled = (bool) resources.GetObject("tpParameterReport.Enabled");

        this.tpParameterReport.Font = (System.Drawing.Font) resources.GetObject("tpParameterReport.Font");

        this.tpParameterReport.ImageIndex = (int) resources.GetObject("tpParameterReport.ImageIndex");

        this.tpParameterReport.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpParameterReport.ImeMode");

        this.tpParameterReport.Location = (System.Drawing.Point) resources.GetObject("tpParameterReport.Location");

        this.tpParameterReport.Name = "tpParameterReport";

        this.tpParameterReport.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpParameterReport.RightToLeft");

        this.tpParameterReport.Size = (System.Drawing.Size) resources.GetObject("tpParameterReport.Size");

        this.tpParameterReport.TabIndex = (int) resources.GetObject("tpParameterReport.TabIndex");

        this.tpParameterReport.Text = resources.GetString("tpParameterReport.Text");

        this.tpParameterReport.ToolTipText = resources.GetString("tpParameterReport.ToolTipText");

        this.tpParameterReport.Visible = (bool) resources.GetObject("tpParameterReport.Visible");

        //

        //btnPreviewCustomerReport

        //

        this.btnPreviewCustomerReport.AccessibleDescription = resources.GetString("btnPreviewCustomerReport.AccessibleDescription");

        this.btnPreviewCustomerReport.AccessibleName = resources.GetString("btnPreviewCustomerReport.AccessibleName");

        this.btnPreviewCustomerReport.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnPreviewCustomerReport.Anchor");

        this.btnPreviewCustomerReport.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnPreviewCustomerReport.BackgroundImage");

        this.btnPreviewCustomerReport.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnPreviewCustomerReport.Dock");

        this.btnPreviewCustomerReport.Enabled = (bool) resources.GetObject("btnPreviewCustomerReport.Enabled");

        this.btnPreviewCustomerReport.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnPreviewCustomerReport.FlatStyle");

        this.btnPreviewCustomerReport.Font = (System.Drawing.Font) resources.GetObject("btnPreviewCustomerReport.Font");

        this.btnPreviewCustomerReport.Image = (System.Drawing.Image) resources.GetObject("btnPreviewCustomerReport.Image");

        this.btnPreviewCustomerReport.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPreviewCustomerReport.ImageAlign");

        this.btnPreviewCustomerReport.ImageIndex = (int) resources.GetObject("btnPreviewCustomerReport.ImageIndex");

        this.btnPreviewCustomerReport.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnPreviewCustomerReport.ImeMode");

        this.btnPreviewCustomerReport.Location = (System.Drawing.Point) resources.GetObject("btnPreviewCustomerReport.Location");

        this.btnPreviewCustomerReport.Name = "btnPreviewCustomerReport";

        this.btnPreviewCustomerReport.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnPreviewCustomerReport.RightToLeft");

        this.btnPreviewCustomerReport.Size = (System.Drawing.Size) resources.GetObject("btnPreviewCustomerReport.Size");

        this.btnPreviewCustomerReport.TabIndex = (int) resources.GetObject("btnPreviewCustomerReport.TabIndex");

        this.btnPreviewCustomerReport.Text = resources.GetString("btnPreviewCustomerReport.Text");

        this.btnPreviewCustomerReport.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPreviewCustomerReport.TextAlign");

        this.btnPreviewCustomerReport.Visible = (bool) resources.GetObject("btnPreviewCustomerReport.Visible");

		this.btnPreviewCustomerReport.Click+=new EventHandler(btnPreviewCustomerReport_Click);
        //

        //lblCustomer

        //

        this.lblCustomer.AccessibleDescription = (string) resources.GetObject("lblCustomer.AccessibleDescription");

        this.lblCustomer.AccessibleName = (string) resources.GetObject("lblCustomer.AccessibleName");

        this.lblCustomer.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblCustomer.Anchor");

        this.lblCustomer.AutoSize = (bool) resources.GetObject("lblCustomer.AutoSize");

        this.lblCustomer.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblCustomer.Dock");

        this.lblCustomer.Enabled = (bool) resources.GetObject("lblCustomer.Enabled");

        this.lblCustomer.Font = (System.Drawing.Font) resources.GetObject("lblCustomer.Font");

        this.lblCustomer.Image = (System.Drawing.Image) resources.GetObject("lblCustomer.Image");

        this.lblCustomer.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblCustomer.ImageAlign");

        this.lblCustomer.ImageIndex = (int) resources.GetObject("lblCustomer.ImageIndex");

        this.lblCustomer.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblCustomer.ImeMode");

        this.lblCustomer.Location = (System.Drawing.Point) resources.GetObject("lblCustomer.Location");

        this.lblCustomer.Name = "lblCustomer";

        this.lblCustomer.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblCustomer.RightToLeft");

        this.lblCustomer.Size = (System.Drawing.Size) resources.GetObject("lblCustomer.Size");

        this.lblCustomer.TabIndex = (int) resources.GetObject("lblCustomer.TabIndex");

        this.lblCustomer.Text = resources.GetString("lblCustomer.Text");

        this.lblCustomer.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblCustomer.TextAlign");

        this.lblCustomer.Visible = (bool) resources.GetObject("lblCustomer.Visible");

        //

        //cbCustomers

        //

        this.cbCustomers.AccessibleDescription = resources.GetString("cbCustomers.AccessibleDescription");

        this.cbCustomers.AccessibleName = resources.GetString("cbCustomers.AccessibleName");

        this.cbCustomers.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cbCustomers.Anchor");

        this.cbCustomers.BackgroundImage = (System.Drawing.Image) resources.GetObject("cbCustomers.BackgroundImage");

        this.cbCustomers.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cbCustomers.Dock");

        this.cbCustomers.Enabled = (bool) resources.GetObject("cbCustomers.Enabled");

        this.cbCustomers.Font = (System.Drawing.Font) resources.GetObject("cbCustomers.Font");

        this.cbCustomers.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cbCustomers.ImeMode");

        this.cbCustomers.IntegralHeight = (bool) resources.GetObject("cbCustomers.IntegralHeight");

        this.cbCustomers.ItemHeight = (int) resources.GetObject("cbCustomers.ItemHeight");

        this.cbCustomers.Location = (System.Drawing.Point) resources.GetObject("cbCustomers.Location");

        this.cbCustomers.MaxDropDownItems = (int) resources.GetObject("cbCustomers.MaxDropDownItems");

        this.cbCustomers.MaxLength = (int) resources.GetObject("cbCustomers.MaxLength");

        this.cbCustomers.Name = "cbCustomers";

        this.cbCustomers.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cbCustomers.RightToLeft");

        this.cbCustomers.Size = (System.Drawing.Size) resources.GetObject("cbCustomers.Size");

        this.cbCustomers.TabIndex = (int) resources.GetObject("cbCustomers.TabIndex");

        this.cbCustomers.Text = resources.GetString("cbCustomers.Text");

        this.cbCustomers.Visible = (bool) resources.GetObject("cbCustomers.Visible");

        //

        //crvParameter

        //

        this.crvParameter.AccessibleDescription = (string) resources.GetObject("crvParameter.AccessibleDescription");

        this.crvParameter.AccessibleName = (string) resources.GetObject("crvParameter.AccessibleName");

        this.crvParameter.ActiveViewIndex = -1;

        this.crvParameter.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("crvParameter.Anchor");

        this.crvParameter.AutoScroll = (bool) resources.GetObject("crvParameter.AutoScroll");

        this.crvParameter.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("crvParameter.AutoScrollMargin");

        this.crvParameter.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("crvParameter.AutoScrollMinSize");

        this.crvParameter.BackgroundImage = (System.Drawing.Image) resources.GetObject("crvParameter.BackgroundImage");

        this.crvParameter.DisplayBackgroundEdge = (bool) resources.GetObject("crvParameter.DisplayBackgroundEdge");

        this.crvParameter.DisplayGroupTree = (bool) resources.GetObject("crvParameter.DisplayGroupTree");

        this.crvParameter.DisplayToolbar = (bool) resources.GetObject("crvParameter.DisplayToolbar");

        this.crvParameter.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("crvParameter.Dock");

        this.crvParameter.Enabled = (bool) resources.GetObject("crvParameter.Enabled");

        this.crvParameter.EnableDrillDown = (bool) resources.GetObject("crvParameter.EnableDrillDown");

        this.crvParameter.Font = (System.Drawing.Font) resources.GetObject("crvParameter.Font");

        this.crvParameter.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("crvParameter.ImeMode");

        this.crvParameter.Location = (System.Drawing.Point) resources.GetObject("crvParameter.Location");

        this.crvParameter.Name = "crvParameter";

        this.crvParameter.ReportSource = null;

        this.crvParameter.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("crvParameter.RightToLeft");

        this.crvParameter.ShowCloseButton = (bool) resources.GetObject("crvParameter.ShowCloseButton");

        this.crvParameter.ShowExportButton = (bool) resources.GetObject("crvParameter.ShowExportButton");

        this.crvParameter.ShowGotoPageButton = (bool) resources.GetObject("crvParameter.ShowGotoPageButton");

        this.crvParameter.ShowGroupTreeButton = (bool) resources.GetObject("crvParameter.ShowGroupTreeButton");

        this.crvParameter.ShowPageNavigateButtons = (bool) resources.GetObject("crvParameter.ShowPageNavigateButtons");

        this.crvParameter.ShowPrintButton = (bool) resources.GetObject("crvParameter.ShowPrintButton");

        this.crvParameter.ShowRefreshButton = (bool) resources.GetObject("crvParameter.ShowRefreshButton");

        this.crvParameter.ShowTextSearchButton = (bool) resources.GetObject("crvParameter.ShowTextSearchButton");

        this.crvParameter.ShowZoomButton = (bool) resources.GetObject("crvParameter.ShowZoomButton");

        this.crvParameter.Size = (System.Drawing.Size) resources.GetObject("crvParameter.Size");

        this.crvParameter.TabIndex = (int) resources.GetObject("crvParameter.TabIndex");

        this.crvParameter.Visible = (bool) resources.GetObject("crvParameter.Visible");

        //

        //tpGraphDrillDownReport

        //

        this.tpGraphDrillDownReport.AccessibleDescription = (string) resources.GetObject("tpGraphDrillDownReport.AccessibleDescription");

        this.tpGraphDrillDownReport.AccessibleName = (string) resources.GetObject("tpGraphDrillDownReport.AccessibleName");

        this.tpGraphDrillDownReport.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpGraphDrillDownReport.Anchor");

        this.tpGraphDrillDownReport.AutoScroll = (bool) resources.GetObject("tpGraphDrillDownReport.AutoScroll");

        this.tpGraphDrillDownReport.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpGraphDrillDownReport.AutoScrollMargin");

        this.tpGraphDrillDownReport.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpGraphDrillDownReport.AutoScrollMinSize");

        this.tpGraphDrillDownReport.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpGraphDrillDownReport.BackgroundImage");

        this.tpGraphDrillDownReport.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label3, this.btnPreviewDrillDownReport, this.crvGraphDrillDown});

        this.tpGraphDrillDownReport.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpGraphDrillDownReport.Dock");

        this.tpGraphDrillDownReport.Enabled = (bool) resources.GetObject("tpGraphDrillDownReport.Enabled");

        this.tpGraphDrillDownReport.Font = (System.Drawing.Font) resources.GetObject("tpGraphDrillDownReport.Font");

        this.tpGraphDrillDownReport.ImageIndex = (int) resources.GetObject("tpGraphDrillDownReport.ImageIndex");

        this.tpGraphDrillDownReport.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpGraphDrillDownReport.ImeMode");

        this.tpGraphDrillDownReport.Location = (System.Drawing.Point) resources.GetObject("tpGraphDrillDownReport.Location");

        this.tpGraphDrillDownReport.Name = "tpGraphDrillDownReport";

        this.tpGraphDrillDownReport.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpGraphDrillDownReport.RightToLeft");

        this.tpGraphDrillDownReport.Size = (System.Drawing.Size) resources.GetObject("tpGraphDrillDownReport.Size");

        this.tpGraphDrillDownReport.TabIndex = (int) resources.GetObject("tpGraphDrillDownReport.TabIndex");

        this.tpGraphDrillDownReport.Text = resources.GetString("tpGraphDrillDownReport.Text");

        this.tpGraphDrillDownReport.ToolTipText = resources.GetString("tpGraphDrillDownReport.ToolTipText");

        this.tpGraphDrillDownReport.Visible = (bool) resources.GetObject("tpGraphDrillDownReport.Visible");

        //

        //Label3

        //

        this.Label3.AccessibleDescription = (string) resources.GetObject("Label3.AccessibleDescription");

        this.Label3.AccessibleName = (string) resources.GetObject("Label3.AccessibleName");

        this.Label3.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label3.Anchor");

        this.Label3.AutoSize = (bool) resources.GetObject("Label3.AutoSize");

        this.Label3.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label3.Dock");

        this.Label3.Enabled = (bool) resources.GetObject("Label3.Enabled");

        this.Label3.Font = (System.Drawing.Font) resources.GetObject("Label3.Font");

        this.Label3.Image = (System.Drawing.Image) resources.GetObject("Label3.Image");

        this.Label3.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label3.ImageAlign");

        this.Label3.ImageIndex = (int) resources.GetObject("Label3.ImageIndex");

        this.Label3.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label3.ImeMode");

        this.Label3.Location = (System.Drawing.Point) resources.GetObject("Label3.Location");

        this.Label3.Name = "Label3";

        this.Label3.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label3.RightToLeft");

        this.Label3.Size = (System.Drawing.Size) resources.GetObject("Label3.Size");

        this.Label3.TabIndex = (int) resources.GetObject("Label3.TabIndex");

        this.Label3.Text = resources.GetString("Label3.Text");

        this.Label3.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label3.TextAlign");

        this.Label3.Visible = (bool) resources.GetObject("Label3.Visible");

        //

        //btnPreviewDrillDownReport

        //

        this.btnPreviewDrillDownReport.AccessibleDescription = resources.GetString("btnPreviewDrillDownReport.AccessibleDescription");

        this.btnPreviewDrillDownReport.AccessibleName = resources.GetString("btnPreviewDrillDownReport.AccessibleName");

        this.btnPreviewDrillDownReport.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnPreviewDrillDownReport.Anchor");

        this.btnPreviewDrillDownReport.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnPreviewDrillDownReport.BackgroundImage");

        this.btnPreviewDrillDownReport.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnPreviewDrillDownReport.Dock");

        this.btnPreviewDrillDownReport.Enabled = (bool) resources.GetObject("btnPreviewDrillDownReport.Enabled");

        this.btnPreviewDrillDownReport.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnPreviewDrillDownReport.FlatStyle");

        this.btnPreviewDrillDownReport.Font = (System.Drawing.Font) resources.GetObject("btnPreviewDrillDownReport.Font");

        this.btnPreviewDrillDownReport.Image = (System.Drawing.Image) resources.GetObject("btnPreviewDrillDownReport.Image");

        this.btnPreviewDrillDownReport.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPreviewDrillDownReport.ImageAlign");

        this.btnPreviewDrillDownReport.ImageIndex = (int) resources.GetObject("btnPreviewDrillDownReport.ImageIndex");

        this.btnPreviewDrillDownReport.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnPreviewDrillDownReport.ImeMode");

        this.btnPreviewDrillDownReport.Location = (System.Drawing.Point) resources.GetObject("btnPreviewDrillDownReport.Location");

        this.btnPreviewDrillDownReport.Name = "btnPreviewDrillDownReport";

        this.btnPreviewDrillDownReport.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnPreviewDrillDownReport.RightToLeft");

        this.btnPreviewDrillDownReport.Size = (System.Drawing.Size) resources.GetObject("btnPreviewDrillDownReport.Size");

        this.btnPreviewDrillDownReport.TabIndex = (int) resources.GetObject("btnPreviewDrillDownReport.TabIndex");

        this.btnPreviewDrillDownReport.Text = resources.GetString("btnPreviewDrillDownReport.Text");

        this.btnPreviewDrillDownReport.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPreviewDrillDownReport.TextAlign");

        this.btnPreviewDrillDownReport.Visible = (bool) resources.GetObject("btnPreviewDrillDownReport.Visible");

		this.btnPreviewDrillDownReport.Click+=new EventHandler(btnPreviewDrillDownReport_Click);
        //

        //crvGraphDrillDown

        //

        this.crvGraphDrillDown.AccessibleDescription = (string) resources.GetObject("crvGraphDrillDown.AccessibleDescription");

        this.crvGraphDrillDown.AccessibleName = (string) resources.GetObject("crvGraphDrillDown.AccessibleName");

        this.crvGraphDrillDown.ActiveViewIndex = -1;

        this.crvGraphDrillDown.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("crvGraphDrillDown.Anchor");

        this.crvGraphDrillDown.AutoScroll = (bool) resources.GetObject("crvGraphDrillDown.AutoScroll");

        this.crvGraphDrillDown.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("crvGraphDrillDown.AutoScrollMargin");

        this.crvGraphDrillDown.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("crvGraphDrillDown.AutoScrollMinSize");

        this.crvGraphDrillDown.BackgroundImage = (System.Drawing.Image) resources.GetObject("crvGraphDrillDown.BackgroundImage");

        this.crvGraphDrillDown.DisplayBackgroundEdge = (bool) resources.GetObject("crvGraphDrillDown.DisplayBackgroundEdge");

        this.crvGraphDrillDown.DisplayGroupTree = (bool) resources.GetObject("crvGraphDrillDown.DisplayGroupTree");

        this.crvGraphDrillDown.DisplayToolbar = (bool) resources.GetObject("crvGraphDrillDown.DisplayToolbar");

        this.crvGraphDrillDown.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("crvGraphDrillDown.Dock");

        this.crvGraphDrillDown.Enabled = (bool) resources.GetObject("crvGraphDrillDown.Enabled");

        this.crvGraphDrillDown.EnableDrillDown = (bool) resources.GetObject("crvGraphDrillDown.EnableDrillDown");

        this.crvGraphDrillDown.Font = (System.Drawing.Font) resources.GetObject("crvGraphDrillDown.Font");

        this.crvGraphDrillDown.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("crvGraphDrillDown.ImeMode");

        this.crvGraphDrillDown.Location = (System.Drawing.Point) resources.GetObject("crvGraphDrillDown.Location");

        this.crvGraphDrillDown.Name = "crvGraphDrillDown";

        this.crvGraphDrillDown.ReportSource = null;

        this.crvGraphDrillDown.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("crvGraphDrillDown.RightToLeft");

        this.crvGraphDrillDown.ShowCloseButton = (bool) resources.GetObject("crvGraphDrillDown.ShowCloseButton");

        this.crvGraphDrillDown.ShowExportButton = (bool) resources.GetObject("crvGraphDrillDown.ShowExportButton");

        this.crvGraphDrillDown.ShowGotoPageButton = (bool) resources.GetObject("crvGraphDrillDown.ShowGotoPageButton");

        this.crvGraphDrillDown.ShowGroupTreeButton = (bool) resources.GetObject("crvGraphDrillDown.ShowGroupTreeButton");

        this.crvGraphDrillDown.ShowPageNavigateButtons = (bool) resources.GetObject("crvGraphDrillDown.ShowPageNavigateButtons");

        this.crvGraphDrillDown.ShowPrintButton = (bool) resources.GetObject("crvGraphDrillDown.ShowPrintButton");

        this.crvGraphDrillDown.ShowRefreshButton = (bool) resources.GetObject("crvGraphDrillDown.ShowRefreshButton");

        this.crvGraphDrillDown.ShowTextSearchButton = (bool) resources.GetObject("crvGraphDrillDown.ShowTextSearchButton");

        this.crvGraphDrillDown.ShowZoomButton = (bool) resources.GetObject("crvGraphDrillDown.ShowZoomButton");

        this.crvGraphDrillDown.Size = (System.Drawing.Size) resources.GetObject("crvGraphDrillDown.Size");

        this.crvGraphDrillDown.TabIndex = (int) resources.GetObject("crvGraphDrillDown.TabIndex");

        this.crvGraphDrillDown.Visible = (bool) resources.GetObject("crvGraphDrillDown.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.TabControl1});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.Menu = this.mnuMain;

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "frmMain";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        this.TabControl1.ResumeLayout(false);

        this.tpReportBasic.ResumeLayout(false);

        this.tpDynamicFormatReport.ResumeLayout(false);

        this.tpParameterReport.ResumeLayout(false);

        this.tpGraphDrillDownReport.ResumeLayout(false);

		

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

    private void btnPreviewBasicReport_Click(object sender, System.EventArgs e) 
	{

        // In this event the Ten Most Expensive Products Report is loaded 

        // and displayed in the crystal reports viewer.

        // Objects used to set the proper database connection information

		
        CrystalDecisions.Shared.TableLogOnInfo tliCurrent;

        // Create a report document instance to hold the report

        ReportDocument rptExpensiveProducts =new ReportDocument();

        try 
		{

            // Load the report

            rptExpensiveProducts.Load(@"..\..\TenMostExpensiveProducts.rpt");

            // Set the connection information for all the tables used in the report
            // Leave UserID and Password blank for trusted connection

			foreach(CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptExpensiveProducts.Database.Tables)
			{

				tliCurrent = tbCurrent.LogOnInfo;
				
				tliCurrent.ConnectionInfo.ServerName = ServerName;
				tliCurrent.ConnectionInfo.UserID = string.Empty;
				tliCurrent.ConnectionInfo.Password = string.Empty;
				tliCurrent.ConnectionInfo.DatabaseName = "Northwind";
				tbCurrent.ApplyLogOnInfo(tliCurrent);

			}

            // Set the report source for the crystal reports 
            // viewer to the report instance.

            crvBasic.ReportSource = rptExpensiveProducts;

            // Zoom viewer to fit to the whole page so the user can see the report

            crvBasic.Zoom(2);

		} 
		catch( LoadSaveReportException Exp )
		{

            MessageBox.Show("Incorrect path for loading report.", "Load Report Error");

		} 
		catch( Exception Exp)
		{
            MessageBox.Show(Exp.Message, "General Error");
        }

    }
	public bool IsNumeric(string val)
	{
		try
		{
			double result = 0;
			return Double.TryParse(val, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.CurrentInfo, out result);
		}
		catch
		{
			return false;
		}
	}

    private void btnPreviewCustomerReport_Click(object sender, System.EventArgs e)
	{

        // In this event the Customer Orders Report is loaded 
        // and displayed in the crystal reports viewer.
        // This report calls for a parameter which is pulled
        // from the customer name combo box (cbCustomers).
        // Objects used to set the parameters in the report

        CrystalDecisions.Shared.ParameterValues pvCollection =new CrystalDecisions.Shared.ParameterValues();

        CrystalDecisions.Shared.ParameterDiscreteValue pdvCustomerName = new CrystalDecisions.Shared.ParameterDiscreteValue();

        // Objects used to set the proper database connection information


        CrystalDecisions.Shared.TableLogOnInfo tliCurrent;

        // Create a report document instance to hold the report

        ReportDocument rptCustomersOrders = new ReportDocument();

        try 
		{

            // Load the report

            rptCustomersOrders.Load(@"..\..\CustomerOrders.rpt");

            // Set the connection information for all the tables used in the report
            // Leave UserID and Password blank for trusted connection

			foreach(CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
			{

				tliCurrent = tbCurrent.LogOnInfo;
				
				tliCurrent.ConnectionInfo.ServerName = ServerName;
				tliCurrent.ConnectionInfo.UserID = string.Empty;
				tliCurrent.ConnectionInfo.Password = string.Empty;
				tliCurrent.ConnectionInfo.DatabaseName = "Northwind";
				tbCurrent.ApplyLogOnInfo(tliCurrent);

			}

            // Set the discreet value to the customers name.

            pdvCustomerName.Value = cbCustomers.Text;

            // Add it to the parameter collection.

            pvCollection.Add(pdvCustomerName);

            // Apply the current parameter values.

            rptCustomersOrders.DataDefinition.ParameterFields["@CustomerName"].ApplyCurrentValues(pvCollection);

            // Hide group tree for this report

            crvParameter.DisplayGroupTree = false;

            // Set the report source for the crystal reports viewer to the 
            // report instance.

            crvParameter.ReportSource = rptCustomersOrders;

            // Zoom viewer to fit to the whole page so the user can see the report

            crvParameter.Zoom(2);

		} 
		catch(LoadSaveReportException Exp)
		{

            MessageBox.Show("Incorrect path for loading report.", "Load Report Error");

		} 
		catch( Exception Exp)
		{
            MessageBox.Show(Exp.Message, "General Error");
        }
    }

    private void btnPreviewDrillDownReport_Click(object sender, System.EventArgs e)
	{

        // In this event the Top 5 Products Sold Report is loaded 
        // and displayed in the crystal reports viewer.
        // This Report has a graph which can be used to drill down to the detail
        // of the report.
        // Create a report document instance to hold the report

        ReportDocument rptDrillDown = new ReportDocument();

        // Objects used to set the proper database connection information

       
        CrystalDecisions.Shared.TableLogOnInfo tliCurrent;

        try 
		{

            // Load the report
            rptDrillDown.Load(@"..\..\Top5ProductsSold.rpt");

            // Set the connection information for all the tables used in the report
            // Leave UserID and Password blank for trusted connection

			foreach( CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptDrillDown.Database.Tables)
			{
				tliCurrent = tbCurrent.LogOnInfo;
				
				tliCurrent.ConnectionInfo.ServerName = ServerName;
				tliCurrent.ConnectionInfo.UserID = string.Empty;
				tliCurrent.ConnectionInfo.Password = string.Empty;
				tliCurrent.ConnectionInfo.DatabaseName = "Northwind";
				tbCurrent.ApplyLogOnInfo(tliCurrent);

			}

            // Set the report source for the crystal reports viewer to 
            // the report instance.

            crvGraphDrillDown.ReportSource = rptDrillDown;

            // Hide group tree for this report

            crvParameter.DisplayGroupTree = false;

            // Zoom viewer to fit to the whole page so the user can see the report

            crvGraphDrillDown.Zoom(2);

       } 
		catch(LoadSaveReportException  Exp)
		{

            MessageBox.Show("Incorrect path for loading report.", "Load Report Error");

		} 
		catch(Exception  Exp )
		{

            MessageBox.Show(Exp.Message, "General Error");

        }

    }

    private void btnPreviewDynamicReport_Click(object sender, System.EventArgs e)
	{

        // In this event the All Customers Orders Report is loaded 
        // and displayed in the crystal reports viewer.  On this report
        // the user can set a unit price and a color.  These parameters
        // are passed into the report to determine if a row is highlighted
        // in the selected color.  During the design of the report
        // a formula was added to the details section which controls
        // background color.  The formula says that if the unit price is
        // greater than the value passed in then that detail lines background
        // color will be the color passed in else no color.
        // This report is also a landscape report.  Inorder to display and print 
        // a landscape report correctly a report document object must be created at 
        // runtime and the report then needs to be assigned to
        // it.  This is an error in Crystal and more information can be
        // found at:  
        // http://support.crystaldecisions/library/kbase/articles/c2011099.asp
        // Create a report document instance to hold the report

        ReportDocument rptAllCustomersOrders = new ReportDocument();

        // Objects used to set the parameters in the report

        CrystalDecisions.Shared.ParameterValues pvCollection = new CrystalDecisions.Shared.ParameterValues();

        CrystalDecisions.Shared.ParameterDiscreteValue pdvColor = new CrystalDecisions.Shared.ParameterDiscreteValue();

        CrystalDecisions.Shared.ParameterDiscreteValue pdvUnitPrice = new CrystalDecisions.Shared.ParameterDiscreteValue();

        // Objects used to set the proper database connection information

      

        CrystalDecisions.Shared.TableLogOnInfo tliCurrent;

        // Set the proper values for the colors
	
		int red = 255;
		int green = 65280;
		int blue = 16711680;
		
        if (!IsNumeric(txtUnitsToHighlight.Text))
			{

            MessageBox.Show("Please enter a number into the unit price text box.", this.Text);
            return;
        }

        try 
		{

            // Load the report

            rptAllCustomersOrders.Load(@"..\..\AllCustomersOrders.rpt");

            // Set the connection information for all the tables used in the report
            // Leave UserID and Password blank for trusted connection

			foreach(CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptAllCustomersOrders.Database.Tables)
			{

				tliCurrent = tbCurrent.LogOnInfo;
				
				tliCurrent.ConnectionInfo.ServerName = ServerName;
				tliCurrent.ConnectionInfo.UserID = string.Empty;
				tliCurrent.ConnectionInfo.Password = string.Empty;
				tliCurrent.ConnectionInfo.DatabaseName = "Northwind";
				tbCurrent.ApplyLogOnInfo(tliCurrent);

			}

            // Set the discreet value to the selected color.

            switch( cbHighlightColor.Text)
			{
			
                case "Red":

                    pdvColor.Value = red;
					break;

                case "Green":

                    pdvColor.Value = green;
					break;
                case "Blue":

                    pdvColor.Value = blue;
					break;
			}

            // Set the discreet value to the Unit Price.
            pdvUnitPrice.Value = txtUnitsToHighlight.Text;

            // Add the color value to the parameter collection.

            pvCollection.Add(pdvColor);

            // Apply the color parameter value.

            rptAllCustomersOrders.DataDefinition.ParameterFields["ColorToHighlight"].ApplyCurrentValues(pvCollection);

            // Clear for next parameter

            pvCollection.Clear();

            // Add the unit price value to the parameter collection.

            pvCollection.Add(pdvUnitPrice);

            // Apply the unit price parameter value.

            rptAllCustomersOrders.DataDefinition.ParameterFields["PriceToCheck"].ApplyCurrentValues(pvCollection);

            // Show group tree for this report

            crvDynamicFormat.DisplayGroupTree = true;

            // Set the report source for the crystal reports viewer to 

            // the report instance.

            crvDynamicFormat.ReportSource = rptAllCustomersOrders;

            // Zoom viewer to fit whole page so the user can see the report

            crvDynamicFormat.Zoom(2);

		} 
		catch(LoadSaveReportException Exp)
		{
            MessageBox.Show("Incorrect path for loading report.", 
							"Load Report Error");

		} 
		catch(Exception Exp)
		{
            MessageBox.Show(Exp.Message, "General Error");
        }

    }

}

