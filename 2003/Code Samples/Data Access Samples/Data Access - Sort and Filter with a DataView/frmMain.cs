//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


public class frmMain:System.Windows.Forms.Form 
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

    private System.Windows.Forms.DataGrid grdProducts;

    private System.Windows.Forms.RadioButton rbtUnitsInStockA;

    private System.Windows.Forms.RadioButton rbtUnitsInStockD;

    private System.Windows.Forms.RadioButton rbtUnitsOnOrderA;

    private System.Windows.Forms.RadioButton rbtUnitsOnOrderD;

    private System.Windows.Forms.GroupBox GroupBox1;

    private System.Windows.Forms.ComboBox cboProducts;

    private System.Windows.Forms.ComboBox cboCompare;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.TextBox txtUnits;

    private System.Windows.Forms.Button cmdUnitsInStock;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Button cmdProductNames;

    private System.Windows.Forms.Label Label4;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Label lblFilter;

    private System.Windows.Forms.Label lblSort;

    private System.Windows.Forms.Label Label6;

    private System.Windows.Forms.Label Label5;

    protected DataSet dsProducts = new DataSet();

    protected System.Data.DataView dvProducts ;

    protected const string SQL_CONNECTION_STRING  ="Server=localhost;" + "DataBase=Northwind;" + "Integrated Security=SSPI" ;

    protected const string MSDE_CONNECTION_STRING  =@"Server=(local)\NetSDK;" + "DataBase=Northwind;" + "Integrated Security=SSPI" ;

    protected const string PRODUCT_TABLE_NAME  = "Products";

    protected const string STATUS_MESSAGE  = "Number of records processed: ";

    protected const string CAPTION_MESSAGE_ORIG  = "Products";

    protected const string NO_RECORDS_FOUND_MESSAGE  = "No records were found that match the filter criteria.";

    protected const string CAPTION_TITLE  = "Sort and Filter with a DataView";

    protected const string DEFAULT_FILTER  = "ProductName like '%'";

    protected const string DEFAULT_SORT  = "UnitsInStock ASC, UnitsOnOrder ASC";

    protected const string NO_RECORDS_TO_SORT_MESSAGE  = "There are no records to sort.";



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

    private System.Windows.Forms.GroupBox GroupBox2;

    private System.Windows.Forms.GroupBox GroupBox3;

    private System.Windows.Forms.GroupBox GroupBox5;

    private System.Windows.Forms.Label lblRecords;

    private System.Windows.Forms.Button cmdSort;

	private void InitializeComponent() 
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.grdProducts = new System.Windows.Forms.DataGrid();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.cmdUnitsInStock = new System.Windows.Forms.Button();
		this.Label2 = new System.Windows.Forms.Label();
		this.cmdProductNames = new System.Windows.Forms.Button();
		this.txtUnits = new System.Windows.Forms.TextBox();
		this.cboCompare = new System.Windows.Forms.ComboBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.cboProducts = new System.Windows.Forms.ComboBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.cmdSort = new System.Windows.Forms.Button();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.rbtUnitsOnOrderD = new System.Windows.Forms.RadioButton();
		this.rbtUnitsOnOrderA = new System.Windows.Forms.RadioButton();
		this.GroupBox5 = new System.Windows.Forms.GroupBox();
		this.rbtUnitsInStockD = new System.Windows.Forms.RadioButton();
		this.rbtUnitsInStockA = new System.Windows.Forms.RadioButton();
		this.lblRecords = new System.Windows.Forms.Label();
		this.lblSort = new System.Windows.Forms.Label();
		this.lblFilter = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.GroupBox5.SuspendLayout();
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
		// grdProducts
		// 
		this.grdProducts.AllowNavigation = false;
		this.grdProducts.AllowSorting = false;
		this.grdProducts.DataMember = "";
		this.grdProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.grdProducts.Location = new System.Drawing.Point(8, 160);
		this.grdProducts.Name = "grdProducts";
		this.grdProducts.ReadOnly = true;
		this.grdProducts.Size = new System.Drawing.Size(368, 152);
		this.grdProducts.TabIndex = 0;
		// 
		// GroupBox1
		// 
		this.GroupBox1.Controls.Add(this.cmdUnitsInStock);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Controls.Add(this.cmdProductNames);
		this.GroupBox1.Controls.Add(this.txtUnits);
		this.GroupBox1.Controls.Add(this.cboCompare);
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.Controls.Add(this.cboProducts);
		this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.GroupBox1.Location = new System.Drawing.Point(232, 8);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(352, 136);
		this.GroupBox1.TabIndex = 2;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Available Filters";
		// 
		// cmdUnitsInStock
		// 
		this.cmdUnitsInStock.Location = new System.Drawing.Point(248, 88);
		this.cmdUnitsInStock.Name = "cmdUnitsInStock";
		this.cmdUnitsInStock.TabIndex = 10;
		this.cmdUnitsInStock.Text = "Fi&lter";
		this.cmdUnitsInStock.Click += new System.EventHandler(this.cmdUnitsInStock_Click);
		// 
		// Label2
		// 
		this.Label2.Location = new System.Drawing.Point(8, 40);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(160, 23);
		this.Label2.TabIndex = 9;
		this.Label2.Text = "Product names that begin with:";
		// 
		// cmdProductNames
		// 
		this.cmdProductNames.Location = new System.Drawing.Point(248, 40);
		this.cmdProductNames.Name = "cmdProductNames";
		this.cmdProductNames.TabIndex = 8;
		this.cmdProductNames.Text = "F&ilter";
		this.cmdProductNames.Click += new System.EventHandler(this.cmdProductNames_Click);
		// 
		// txtUnits
		// 
		this.txtUnits.Location = new System.Drawing.Point(176, 88);
		this.txtUnits.Name = "txtUnits";
		this.txtUnits.Size = new System.Drawing.Size(64, 20);
		this.txtUnits.TabIndex = 7;
		this.txtUnits.Text = "";
		// 
		// cboCompare
		// 
		this.cboCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboCompare.Location = new System.Drawing.Point(120, 88);
		this.cboCompare.Name = "cboCompare";
		this.cboCompare.Size = new System.Drawing.Size(48, 21);
		this.cboCompare.TabIndex = 6;
		// 
		// Label1
		// 
		this.Label1.Location = new System.Drawing.Point(8, 88);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(104, 23);
		this.Label1.TabIndex = 5;
		this.Label1.Text = "UnitsInStock";
		// 
		// cboProducts
		// 
		this.cboProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboProducts.Location = new System.Drawing.Point(176, 40);
		this.cboProducts.Name = "cboProducts";
		this.cboProducts.Size = new System.Drawing.Size(64, 21);
		this.cboProducts.TabIndex = 4;
		// 
		// GroupBox2
		// 
		this.GroupBox2.Controls.Add(this.cmdSort);
		this.GroupBox2.Controls.Add(this.Label4);
		this.GroupBox2.Controls.Add(this.Label3);
		this.GroupBox2.Controls.Add(this.GroupBox3);
		this.GroupBox2.Controls.Add(this.GroupBox5);
		this.GroupBox2.Location = new System.Drawing.Point(8, 8);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(224, 136);
		this.GroupBox2.TabIndex = 3;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Sort by UnitsInStock, UnitsOnOrder";
		// 
		// cmdSort
		// 
		this.cmdSort.Location = new System.Drawing.Point(8, 112);
		this.cmdSort.Name = "cmdSort";
		this.cmdSort.TabIndex = 15;
		this.cmdSort.Text = "&Sort";
		this.cmdSort.Click += new System.EventHandler(this.cmdSort_Click);
		// 
		// Label4
		// 
		this.Label4.Location = new System.Drawing.Point(112, 16);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(104, 16);
		this.Label4.TabIndex = 14;
		this.Label4.Text = "Secondary Key";
		// 
		// Label3
		// 
		this.Label3.Location = new System.Drawing.Point(8, 16);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(100, 16);
		this.Label3.TabIndex = 13;
		this.Label3.Text = "Primary Key";
		// 
		// GroupBox3
		// 
		this.GroupBox3.Controls.Add(this.rbtUnitsOnOrderD);
		this.GroupBox3.Controls.Add(this.rbtUnitsOnOrderA);
		this.GroupBox3.Location = new System.Drawing.Point(112, 32);
		this.GroupBox3.Name = "GroupBox3";
		this.GroupBox3.Size = new System.Drawing.Size(104, 72);
		this.GroupBox3.TabIndex = 12;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "UnitsOnOrder";
		// 
		// rbtUnitsOnOrderD
		// 
		this.rbtUnitsOnOrderD.Location = new System.Drawing.Point(8, 48);
		this.rbtUnitsOnOrderD.Name = "rbtUnitsOnOrderD";
		this.rbtUnitsOnOrderD.Size = new System.Drawing.Size(88, 16);
		this.rbtUnitsOnOrderD.TabIndex = 1;
		this.rbtUnitsOnOrderD.Text = "Descending";
		// 
		// rbtUnitsOnOrderA
		// 
		this.rbtUnitsOnOrderA.Checked = true;
		this.rbtUnitsOnOrderA.Location = new System.Drawing.Point(8, 24);
		this.rbtUnitsOnOrderA.Name = "rbtUnitsOnOrderA";
		this.rbtUnitsOnOrderA.Size = new System.Drawing.Size(88, 16);
		this.rbtUnitsOnOrderA.TabIndex = 0;
		this.rbtUnitsOnOrderA.TabStop = true;
		this.rbtUnitsOnOrderA.Text = "Ascending";
		// 
		// GroupBox5
		// 
		this.GroupBox5.Controls.Add(this.rbtUnitsInStockD);
		this.GroupBox5.Controls.Add(this.rbtUnitsInStockA);
		this.GroupBox5.Location = new System.Drawing.Point(8, 32);
		this.GroupBox5.Name = "GroupBox5";
		this.GroupBox5.Size = new System.Drawing.Size(104, 72);
		this.GroupBox5.TabIndex = 11;
		this.GroupBox5.TabStop = false;
		this.GroupBox5.Text = "UnitsInStock";
		// 
		// rbtUnitsInStockD
		// 
		this.rbtUnitsInStockD.Location = new System.Drawing.Point(8, 48);
		this.rbtUnitsInStockD.Name = "rbtUnitsInStockD";
		this.rbtUnitsInStockD.Size = new System.Drawing.Size(88, 16);
		this.rbtUnitsInStockD.TabIndex = 1;
		this.rbtUnitsInStockD.Text = "Descending";
		
		// 
		// rbtUnitsInStockA
		// 
		this.rbtUnitsInStockA.Checked = true;
		this.rbtUnitsInStockA.Location = new System.Drawing.Point(8, 24);
		this.rbtUnitsInStockA.Name = "rbtUnitsInStockA";
		this.rbtUnitsInStockA.Size = new System.Drawing.Size(88, 16);
		this.rbtUnitsInStockA.TabIndex = 0;
		this.rbtUnitsInStockA.TabStop = true;
		this.rbtUnitsInStockA.Text = "Ascending";
		
		// 
		// lblRecords
		// 
		this.lblRecords.Location = new System.Drawing.Point(376, 280);
		this.lblRecords.Name = "lblRecords";
		this.lblRecords.Size = new System.Drawing.Size(216, 16);
		this.lblRecords.TabIndex = 6;
		// 
		// lblSort
		// 
		this.lblSort.Location = new System.Drawing.Point(376, 176);
		this.lblSort.Name = "lblSort";
		this.lblSort.Size = new System.Drawing.Size(216, 16);
		this.lblSort.TabIndex = 7;
		// 
		// lblFilter
		// 
		this.lblFilter.Location = new System.Drawing.Point(376, 232);
		this.lblFilter.Name = "lblFilter";
		this.lblFilter.Size = new System.Drawing.Size(216, 16);
		this.lblFilter.TabIndex = 8;
		// 
		// Label5
		// 
		this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.Label5.Location = new System.Drawing.Point(376, 160);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(216, 16);
		this.Label5.TabIndex = 9;
		this.Label5.Text = "Current Sort Order";
		// 
		// Label6
		// 
		this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.Label6.Location = new System.Drawing.Point(376, 216);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(216, 16);
		this.Label6.TabIndex = 10;
		this.Label6.Text = "Current Filter";
		// 
		// frmMain
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(602, 315);
		this.Controls.Add(this.Label6);
		this.Controls.Add(this.Label5);
		this.Controls.Add(this.lblFilter);
		this.Controls.Add(this.lblSort);
		this.Controls.Add(this.lblRecords);
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.grdProducts);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.Menu = this.mnuMain;
		this.Name = "frmMain";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "=";
		this.Load += new System.EventHandler(this.frmMain_Load);
		((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox5.ResumeLayout(false);
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

    private void frmMain_Load(object sender, System.EventArgs e) {

        string strConnection  = SQL_CONNECTION_STRING;

        // Display a status message saying that we're attempting to connect to SQL Server.

        // This only needs to be done the very first time a connection is

        // attempted.  After we've determined that MSDE or SQL Server is

        // installed, this message no longer needs to be displayed.

        frmStatus frmStatusMessage =new frmStatus();

        frmStatusMessage.Show("Connecting to SQL Server");

        // Attempt to connect first to the local SQL server instance, 

        // if that is not successful try a local

        // MSDE installation (with the Northwind DB).  

        bool IsConnecting  = true;

        while (IsConnecting)
		{

            try 
			{

                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in to SQL Server, or be part of the Administrators
                // group on your local machine for this to work. No password or user id is 
                // included in this type of string.

                SqlConnection northwindConnection =new SqlConnection(strConnection);

                // The SqlDataAdapter is used to populate a Dataset 

                SqlDataAdapter ProductAdapter = new SqlDataAdapter("SELECT ProductName,UnitPrice, UnitsInStock, UnitsOnOrder FROM products", northwindConnection);

                // Populate the Dataset with the information from the products
                // table.  Since a Dataset can hold multiple result sets, it's
                // a good idea to "name" the result set when you populate the
                // DataSet.  In this case, the result set is named "Products".

                ProductAdapter.Fill(dsProducts, PRODUCT_TABLE_NAME);

                //create the dataview; use a constructor to specify
                // the sort, filter criteria for performance purposes

                dvProducts = new DataView(dsProducts.Tables["products"],DEFAULT_FILTER,DEFAULT_SORT,DataViewRowState.OriginalRows);

                // Data has been retrieved successfully  
                // Signal to break out of the loop by setting isConnecting to false.

                IsConnecting = false;

            //Handle the situation where a connection attempt has failed

           } 
			catch(Exception exc)
			{
				if (strConnection == SQL_CONNECTION_STRING)
				{
					// Couldn't connect to SQL Server.  Now try MSDE.

					strConnection = MSDE_CONNECTION_STRING;

					frmStatusMessage.Show("Connecting to MSDE");
				}
				else 
				{

					// Unable to connect to SQL Server or MSDE

					frmStatusMessage.Close();

					MessageBox.Show("To run this sample, you must have SQL " + "or MSDE with the Northwind database installed.  For " + "instructions on installing MSDE, view  Readthis.",CAPTION_TITLE);

					//quit the program; could not connect to either SQL Server 

					Application.Exit();

				}

            }

        }

        frmStatusMessage.Close();

        // Bind the DataGrid to the dataview created above

        grdProducts.DataSource = dvProducts;

        //Populate the combo box for productName filtering.

        // Allow a user to select the first letter of products that they wish to view

        cboProducts.Items.AddRange(new Object[] {"<ALL>", "A","B", "C", "D", "E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"});

        cboProducts.Text = "<ALL>";

        //Populate the combo box for UnitsInStock filtering

        // Allow the usual arithmetic comparision operators

        cboCompare.Items.AddRange(new Object[] {"<", "<=","=", ">=", ">"});

        cboCompare.Text="<";

        //Display labeling status information 

        lblRecords.Text = STATUS_MESSAGE + this.dsProducts.Tables[PRODUCT_TABLE_NAME].Rows.Count.ToString();
		
        grdProducts.CaptionText=CAPTION_MESSAGE_ORIG;

        lblSort.Text = DEFAULT_SORT;

        lblFilter.Text = DEFAULT_FILTER;

    }

    private void cmdProductNames_Click(object sender, System.EventArgs e) 
	{

        string strFilter ;

        //Process the row filter criteria based on first character of the product name.

        // if <ALL> was selected, show all rows in the grid, else show only

        // those rows beginning with the selected letter.

		if (cboProducts.Text == "<ALL>")
		{

			strFilter = "ProductName like '%'";
		}
		else 
		{

			strFilter = "ProductName like '" + cboProducts.Text + "%'";

		}

        dvProducts.RowFilter=strFilter;

         //Display the sorted and filtered view in the datagrid

        grdProducts.DataSource=dvProducts;

        //Display the number of rows in the view

        lblRecords.Text = STATUS_MESSAGE + dvProducts.Count.ToString();

        lblFilter.Text = strFilter;

        //display a MessageBox.Show if no records were found that 

        // match the user criteria

		if (dvProducts.Count == 0)
		{

			MessageBox.Show(NO_RECORDS_FOUND_MESSAGE,CAPTION_TITLE);

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

    private void cmdUnitsInStock_Click(object sender, System.EventArgs e) 
	{
        string strFilter;

        //Process the row filter criteria based on the number of UnitsInStock.
        // Use the number of units entered and arithmetic operator selected 
        // to filter the dataView
        //Verify the number of units entered

		if (txtUnits.Text.Trim().Length == 0)
		{

			MessageBox.Show(NO_RECORDS_FOUND_MESSAGE,CAPTION_TITLE);

			return;
		}

        //else if IsNumeric(txtUnits.Text.Trim.tostring)==false) 
		else if (this.IsNumeric(txtUnits.Text.ToString())==false)
		{

            MessageBox.Show(NO_RECORDS_FOUND_MESSAGE,CAPTION_TITLE);
            return;

        }

        strFilter = "UnitsInStock " + cboCompare.Text + " " + txtUnits.Text;

        //Filter by the UnitsInStock

        dvProducts.RowFilter=strFilter;

         //Display the filtered/sorted data

        grdProducts.DataSource=dvProducts;

        //Display the number of rows in the view

        lblRecords.Text = STATUS_MESSAGE + dvProducts.Count.ToString();

        lblFilter.Text = strFilter;

        //display a MessageBox.Show if no records were found that 

        // match the users criteria

		if (dvProducts.Count == 0)
		{
			//create the button and icon msgstyle for MessageBox.Show

			MessageBox.Show(NO_RECORDS_FOUND_MESSAGE,CAPTION_TITLE);

		}

    }

    private void cmdSort_Click(object sender, System.EventArgs e)
	{
        //Apply the Sort criteria to the dataview

        string strSort;

        //Only sort if the dataview currently has records

		if (dvProducts.Count == 0)
		{

			MessageBox.Show(NO_RECORDS_TO_SORT_MESSAGE,CAPTION_TITLE);

			return;

		}

        //Process the sort criteria selected for the view
        // construct a sort string for the primary, secondary sort keys
        // The Primary sort key is the UnitsInStock column, the
        // secondary sort key is UnitsOnOrder column

		if (rbtUnitsInStockA.Checked==true)
		{

			strSort = "UnitsInStock ASC";
		}
		else 
		{

			strSort = "UnitsInStock DESC";

		}

		if (rbtUnitsOnOrderA.Checked==true) 
		{

			strSort = strSort + ", UnitsOnOrder ASC";
		}
		else 
		{

			strSort = strSort + ", UnitsOnOrder DESC";

		}

        //Apply the sort criteria to the dataview

        dvProducts.Sort=strSort;

        //Display the view in the datagrid

        grdProducts.DataSource=dvProducts;

        lblRecords.Text = STATUS_MESSAGE + dvProducts.Count.ToString();

        lblSort.Text = strSort;

    }

	
}

