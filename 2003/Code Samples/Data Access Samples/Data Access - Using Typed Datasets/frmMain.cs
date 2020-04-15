//Copyright (C) 2002 Microsoft Corporation

//All rights reserved.

//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 

//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 

//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Data;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using HowTo;

public class frmMain:System.Windows.Forms.Form 
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}


    protected const string SQL_CONNECTION_STRING = "Server=localhost;" + "DataBase=Northwind;" + "Integrated Security=SSPI;Connect Timeout=5";

    protected const  string MSDE_CONNECTION_STRING =@"Server=(local)\NETSDK;" + "DataBase=Northwind;" + "Integrated Security=SSPI;Connect Timeout=5";

    private string Connectionstring  = SQL_CONNECTION_STRING;

    private bool HasConnected  = false;

    // Define the typed dataset

    private Northwind tdsNorthwind;
	
    // Define the dataset

    private DataSet dsNorthwind;

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

        InitDataSets();

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

    private System.Windows.Forms.Button btnInsertTDS;

    private System.Windows.Forms.Button btnInsertDS;

    private System.Windows.Forms.Button btnUpdateTDS;

    private System.Windows.Forms.Button btnUpdateDS;

    private System.Windows.Forms.Button btnDeleteTDS;

    private System.Windows.Forms.Button btnDeleteDS;

    private System.Windows.Forms.Button btnSelectTDS;

    private System.Windows.Forms.Button btnSelectDS;

    private System.Windows.Forms.TabControl TabControl1;

    private System.Windows.Forms.TabPage tpSelect;

    private System.Windows.Forms.TabPage tpInsert;

    private System.Windows.Forms.TabPage tpUpdate;

    private System.Windows.Forms.TabPage tpDelete;

    private System.Windows.Forms.ListBox lstResults;

    private System.Windows.Forms.Button lstUpdateFromTDS;

    private System.Windows.Forms.Button lstUpdateFromDS;

    private System.Windows.Forms.Button btnUpdateDataTDS;

    private System.Windows.Forms.Button btnUpdateDataDS;

    private System.Windows.Forms.Label lblResult;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Label Label4;

    private void InitializeComponent() 
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.btnInsertTDS = new System.Windows.Forms.Button();

        this.btnInsertDS = new System.Windows.Forms.Button();

        this.btnUpdateTDS = new System.Windows.Forms.Button();

        this.btnUpdateDS = new System.Windows.Forms.Button();

        this.btnDeleteTDS = new System.Windows.Forms.Button();

        this.btnDeleteDS = new System.Windows.Forms.Button();

        this.btnSelectTDS = new System.Windows.Forms.Button();

        this.btnSelectDS = new System.Windows.Forms.Button();

        this.lblResult = new System.Windows.Forms.Label();

        this.lstResults = new System.Windows.Forms.ListBox();

        this.TabControl1 = new System.Windows.Forms.TabControl();

        this.tpSelect = new System.Windows.Forms.TabPage();

        this.Label1 = new System.Windows.Forms.Label();

        this.tpInsert = new System.Windows.Forms.TabPage();

        this.Label2 = new System.Windows.Forms.Label();

        this.tpUpdate = new System.Windows.Forms.TabPage();

        this.Label3 = new System.Windows.Forms.Label();

        this.tpDelete = new System.Windows.Forms.TabPage();

        this.Label4 = new System.Windows.Forms.Label();

        this.lstUpdateFromTDS = new System.Windows.Forms.Button();

        this.lstUpdateFromDS = new System.Windows.Forms.Button();

        this.btnUpdateDataTDS = new System.Windows.Forms.Button();

        this.btnUpdateDataDS = new System.Windows.Forms.Button();

        this.TabControl1.SuspendLayout();

        this.tpSelect.SuspendLayout();

        this.tpInsert.SuspendLayout();

        this.tpUpdate.SuspendLayout();

        this.tpDelete.SuspendLayout();

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

		this.mnuExit.Click+=new EventHandler(mnuExit_Click);

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

		this.mnuAbout.Click+=new EventHandler(mnuAbout_Click);
        
		//

        //btnInsertTDS

        //

        this.btnInsertTDS.AccessibleDescription = "Insert Record into Typed DataSet";

        this.btnInsertTDS.AccessibleName = "Insert Record into Typed DataSet";

        this.btnInsertTDS.Location = new System.Drawing.Point(16, 112);

        this.btnInsertTDS.Name = "btnInsertTDS";

        this.btnInsertTDS.Size = new System.Drawing.Size(128, 48);

        this.btnInsertTDS.TabIndex = 38;

        this.btnInsertTDS.Text = "&Insert Record into Typed Dataset";

		this.btnInsertTDS.Click+=new EventHandler(btnInsertTDS_Click);

        //

        //btnInsertDS

        //

        this.btnInsertDS.AccessibleDescription = "Insert Record into Un-Typed DataSet";

        this.btnInsertDS.AccessibleName = "Insert Record into Un-Typed DataSet";

        this.btnInsertDS.Location = new System.Drawing.Point(160, 112);

        this.btnInsertDS.Name = "btnInsertDS";

        this.btnInsertDS.Size = new System.Drawing.Size(120, 48);

        this.btnInsertDS.TabIndex = 39;

        this.btnInsertDS.Text = "Insert Record into &Untyped Dataset";

		this.btnInsertDS.Click+=new EventHandler(btnInsertDS_Click);

        //

        //btnUpdateTDS

        //

        this.btnUpdateTDS.AccessibleDescription = "Update record from typed DataSet";

        this.btnUpdateTDS.AccessibleName = "Update record from typed DataSet";

        this.btnUpdateTDS.Location = new System.Drawing.Point(16, 112);

        this.btnUpdateTDS.Name = "btnUpdateTDS";

        this.btnUpdateTDS.Size = new System.Drawing.Size(128, 48);

        this.btnUpdateTDS.TabIndex = 40;

        this.btnUpdateTDS.Text = "&Update Record from Typed Dataset";

		this.btnUpdateTDS.Click+=new EventHandler(btnUpdateTDS_Click);

        //

        //btnUpdateDS

        //

        this.btnUpdateDS.AccessibleDescription = "Update record from Untyped DataSet";

        this.btnUpdateDS.AccessibleName = "Update record from Untyped DataSet";

        this.btnUpdateDS.Location = new System.Drawing.Point(160, 112);

        this.btnUpdateDS.Name = "btnUpdateDS";

        this.btnUpdateDS.Size = new System.Drawing.Size(120, 48);

        this.btnUpdateDS.TabIndex = 41;

        this.btnUpdateDS.Text = "Update Record from &Untyped Dataset";

		this.btnUpdateDS.Click+=new EventHandler(btnUpdateDS_Click);

        //

        //btnDeleteTDS

        //

        this.btnDeleteTDS.AccessibleDescription = "Delete Record from Typed DataSet";

        this.btnDeleteTDS.AccessibleName = "Delete Record from Typed DataSet";

        this.btnDeleteTDS.Location = new System.Drawing.Point(16, 112);

        this.btnDeleteTDS.Name = "btnDeleteTDS";

        this.btnDeleteTDS.Size = new System.Drawing.Size(128, 48);

        this.btnDeleteTDS.TabIndex = 42;

        this.btnDeleteTDS.Text = "&Delete Record from Typed Dataset";

		this.btnDeleteTDS.Click+=new EventHandler(btnDeleteTDS_Click);

        //

        //btnDeleteDS

        //

        this.btnDeleteDS.AccessibleDescription = "Delete record from untyped Dataset";

        this.btnDeleteDS.AccessibleName = "Delete record from untyped Dataset";

        this.btnDeleteDS.Location = new System.Drawing.Point(160, 112);

        this.btnDeleteDS.Name = "btnDeleteDS";

        this.btnDeleteDS.Size = new System.Drawing.Size(120, 48);

        this.btnDeleteDS.TabIndex = 43;

        this.btnDeleteDS.Text = "Delete Record from &Untyped Dataset";

		this.btnDeleteDS.Click+=new EventHandler(btnDeleteDS_Click);

        //

        //btnSelectTDS

        //

        this.btnSelectTDS.AccessibleDescription = "Populate List from Typed DataSet";

        this.btnSelectTDS.AccessibleName = "Populate List from Typed DataSet";

        this.btnSelectTDS.Location = new System.Drawing.Point(16, 112);

        this.btnSelectTDS.Name = "btnSelectTDS";

        this.btnSelectTDS.Size = new System.Drawing.Size(128, 48);

        this.btnSelectTDS.TabIndex = 2;

        this.btnSelectTDS.Text = "&Populate List from Typed Dataset";

		this.btnSelectTDS.Click+=new EventHandler(btnSelectTDS_Click);

        //

        //btnSelectDS

        //

        this.btnSelectDS.AccessibleDescription = "Populate List from Un-Typed DataSet";

        this.btnSelectDS.AccessibleName = "Populate List from Un-Typed DataSet";

        this.btnSelectDS.Location = new System.Drawing.Point(160, 112);

        this.btnSelectDS.Name = "btnSelectDS";

        this.btnSelectDS.Size = new System.Drawing.Size(120, 48);

        this.btnSelectDS.TabIndex = 2;

		this.btnSelectDS.Click+=new EventHandler(btnSelectDS_Click);

        this.btnSelectDS.Text = "Populate List from &UnTyped Dataset";

        //

        //lblResult

        //

        this.lblResult.Location = new System.Drawing.Point(16, 216);

        this.lblResult.Name = "lblResult";

        this.lblResult.Size = new System.Drawing.Size(72, 16);

        this.lblResult.TabIndex = 49;

        this.lblResult.Text = "Results";

        //

        //lstResults

        //

        this.lstResults.Location = new System.Drawing.Point(16, 232);

        this.lstResults.Name = "lstResults";

        this.lstResults.Size = new System.Drawing.Size(304, 147);

        this.lstResults.TabIndex = 50;

        //

        //TabControl1

        //

        this.TabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {this.tpSelect, this.tpInsert, this.tpUpdate, this.tpDelete});

        this.TabControl1.Location = new System.Drawing.Point(16, 8);

        this.TabControl1.Name = "TabControl1";

        this.TabControl1.SelectedIndex = 0;

        this.TabControl1.Size = new System.Drawing.Size(304, 200);

        this.TabControl1.TabIndex = 0;

        //

        //tpSelect

        //

        this.tpSelect.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label1, this.btnSelectDS, this.btnSelectTDS});

        this.tpSelect.Location = new System.Drawing.Point(4, 22);

        this.tpSelect.Name = "tpSelect";

        this.tpSelect.Size = new System.Drawing.Size(296, 174);

        this.tpSelect.TabIndex = 0;

        this.tpSelect.Text = "Select";

        //

        //Label1

        //

        this.Label1.Location = new System.Drawing.Point(16, 24);

        this.Label1.Name = "Label1";

        this.Label1.Size = new System.Drawing.Size(264, 72);

        this.Label1.TabIndex = 1;

        this.Label1.Text = "At anytime you can get an update on the state of the datasets by clicking the Rep" + "opulate buttons at the bottom.  The buttons on the left side only effect the typ" + "ed dataset and the buttons on the right only effect the Untyped Dataset";

        //

        //tpInsert

        //

        this.tpInsert.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label2, this.btnInsertDS, this.btnInsertTDS});

        this.tpInsert.Location = new System.Drawing.Point(4, 22);

        this.tpInsert.Name = "tpInsert";

        this.tpInsert.Size = new System.Drawing.Size(296, 174);

        this.tpInsert.TabIndex = 1;

        this.tpInsert.Text = "Insert";

        //

        //Label2

        //

        this.Label2.Location = new System.Drawing.Point(16, 24);

        this.Label2.Name = "Label2";

        this.Label2.Size = new System.Drawing.Size(264, 72);

        this.Label2.TabIndex = 47;

        this.Label2.Text = "At anytime you can get an update on the state of the datasets by clicking the Rep" + "opulate buttons at the bottom.  The buttons on the left side only effect the typ" + "ed dataset and the buttons on the right only effect the Untyped Dataset";

        //

        //tpUpdate

        //

        this.tpUpdate.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label3, this.btnUpdateTDS, this.btnUpdateDS});

        this.tpUpdate.Location = new System.Drawing.Point(4, 22);

        this.tpUpdate.Name = "tpUpdate";

        this.tpUpdate.Size = new System.Drawing.Size(296, 174);

        this.tpUpdate.TabIndex = 2;

        this.tpUpdate.Text = "Update";

        //

        //Label3

        //

        this.Label3.Location = new System.Drawing.Point(16, 24);

        this.Label3.Name = "Label3";

        this.Label3.Size = new System.Drawing.Size(264, 72);

        this.Label3.TabIndex = 47;

        this.Label3.Text = "At anytime you can get an update on the state of the datasets by clicking the Rep" + "opulate buttons at the bottom.  The buttons on the left side only effect the typ" + "ed dataset and the buttons on the right only effect the Untyped Dataset";

        //

        //tpDelete

        //

        this.tpDelete.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label4, this.btnDeleteDS, this.btnDeleteTDS});

        this.tpDelete.Location = new System.Drawing.Point(4, 22);

        this.tpDelete.Name = "tpDelete";

        this.tpDelete.Size = new System.Drawing.Size(296, 174);

        this.tpDelete.TabIndex = 3;

        this.tpDelete.Text = "Delete";

        //

        //Label4

        //

        this.Label4.Location = new System.Drawing.Point(16, 24);

        this.Label4.Name = "Label4";

        this.Label4.Size = new System.Drawing.Size(264, 72);

        this.Label4.TabIndex = 47;

        this.Label4.Text = "At anytime you can get an update on the state of the datasets by clicking the Rep" + "opulate buttons at the bottom.  The buttons on the left side only effect the typ" + "ed dataset and the buttons on the right only effect the Untyped Dataset";

        //

        //lstUpdateFromTDS

        //

        this.lstUpdateFromTDS.AccessibleDescription = "Repopulate List from Typed Data Set";

        this.lstUpdateFromTDS.AccessibleName = "Repopulate List from Typed Data Set";

        this.lstUpdateFromTDS.Location = new System.Drawing.Point(16, 384);

        this.lstUpdateFromTDS.Name = "lstUpdateFromTDS";

        this.lstUpdateFromTDS.Size = new System.Drawing.Size(128, 40);

        this.lstUpdateFromTDS.TabIndex = 4;

        this.lstUpdateFromTDS.Text = "&Repopulate list from Typed Dataset";

		this.lstUpdateFromTDS.Click+=new EventHandler(lstUpdateFromTDS_Click);

        //

        //lstUpdateFromDS

        //

        this.lstUpdateFromDS.AccessibleDescription = "Repopulate List from Un-Typed Data Set";

        this.lstUpdateFromDS.AccessibleName = "Repopulate List from Un-Typed Data Set";

        this.lstUpdateFromDS.Location = new System.Drawing.Point(192, 384);

        this.lstUpdateFromDS.Name = "lstUpdateFromDS";

        this.lstUpdateFromDS.Size = new System.Drawing.Size(128, 40);

        this.lstUpdateFromDS.TabIndex = 54;

        this.lstUpdateFromDS.Text = "Repopulate &list from Untyped Dataset";

		this.lstUpdateFromDS.Click+=new EventHandler(lstUpdateFromDS_Click);

        //

        //btnUpdateDataTDS

        //

        this.btnUpdateDataTDS.AccessibleDescription = "Update Datasource from Typed DataSet";

        this.btnUpdateDataTDS.AccessibleName = "Update Datasource from Typed DataSet";

        this.btnUpdateDataTDS.Location = new System.Drawing.Point(16, 432);

        this.btnUpdateDataTDS.Name = "btnUpdateDataTDS";

        this.btnUpdateDataTDS.Size = new System.Drawing.Size(128, 40);

        this.btnUpdateDataTDS.TabIndex = 55;

        this.btnUpdateDataTDS.Text = "&Update Datasource from Typed Dataset";

		this.btnUpdateDataTDS.Click+=new EventHandler(btnUpdateDataTDS_Click);

        //

        //btnUpdateDataDS

        //

        this.btnUpdateDataDS.AccessibleDescription = "Update Datasource from Un-Typed DataSet";

        this.btnUpdateDataDS.AccessibleName = "Update Datasource from Un-Typed DataSet";

        this.btnUpdateDataDS.Location = new System.Drawing.Point(192, 432);

        this.btnUpdateDataDS.Name = "btnUpdateDataDS";

        this.btnUpdateDataDS.Size = new System.Drawing.Size(128, 40);

        this.btnUpdateDataDS.TabIndex = 56;

        this.btnUpdateDataDS.Text = "Update Datasource from Untyped Dataset";

		this.btnUpdateDataDS.Click+=new EventHandler(btnUpdateDataDS_Click);

        //

        //frmMain

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(338, 483);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnUpdateDataDS, this.btnUpdateDataTDS, this.lstUpdateFromDS, this.lstUpdateFromTDS, this.TabControl1, this.lstResults, this.lblResult});

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.MaximizeBox = false;

        this.Menu = this.mnuMain;

        this.Name = "frmMain";

        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        this.Text = "Title Comes from Assembly Info";

        this.TabControl1.ResumeLayout(false);

        this.tpSelect.ResumeLayout(false);

        this.tpInsert.ResumeLayout(false);

        this.tpUpdate.ResumeLayout(false);

        this.tpDelete.ResumeLayout(false);

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

    private void btnDeleteDS_Click(object sender, System.EventArgs e) 
	{

        // Delete the selected row in the products table.

		if (lstResults.SelectedIndex >= 0)
		{
	
			dsNorthwind.Tables["ProductsDS"].Rows[lstResults.SelectedIndex].Delete();
		}
		else 
		{

			MessageBox.Show("No item selected.", this.Text);

		}

        PopulateListFromDS();

    }

    private void btnDeleteTDS_Click(object sender, System.EventArgs e)
	{

        // Delete the selected row in the products table.

		if (lstResults.SelectedIndex >= 0)
		{

			tdsNorthwind.ProductsTDS[lstResults.SelectedIndex].Delete();
		}
		else 
		{

			MessageBox.Show("No item selected.", this.Text);

		}

        PopulateListFromTDS();

    }

    private void btnInsertTDS_Click(object sender, System.EventArgs e)
	{

        // Insert a new row into the typed dataset and
        // populate it with values.

        Northwind.ProductsTDSRow Row;

        Row = tdsNorthwind.ProductsTDS.NewProductsTDSRow();

        Row.ProductName = "Typed Dataset Inserted Record";

        Row.Discontinued = true;

        Row.QuantityPerUnit = string.Empty;

        Row.UnitPrice = 50;

        Row.UnitsInStock = 20;

        Row.UnitsOnOrder = 0;

        Row.ReorderLevel = 25;

        tdsNorthwind.ProductsTDS.AddProductsTDSRow(Row);

        PopulateListFromTDS();

        lstResults.SelectedIndex = lstResults.Items.Count - 1;

    }

    private void btnInsertDS_Click(object sender, System.EventArgs e)
	{

        // Insert a new row into the untyped dataset and
        // populate it with values.

        DataRow Row;

        Row = dsNorthwind.Tables["ProductsDS"].NewRow();

        Row["ProductName"] = "Typed Dataset Inserted Record";

        Row["Discontinued"] = true;

        Row["QuantityPerUnit"] = string.Empty;

        Row["UnitPrice"] = 50;

        Row["UnitsInStock"] = 20;

        Row["UnitsOnOrder"] = 0;

        Row["ReorderLevel"] = 25;

        dsNorthwind.Tables["ProductsDS"].Rows.Add(Row);

        PopulateListFromDS();

        lstResults.SelectedIndex = lstResults.Items.Count - 1;

    }

    private void btnSelectDS_Click(object sender, System.EventArgs e)
	{

        PopulateListFromDS();

    }

    private void btnSelectTDS_Click(object sender, System.EventArgs e)
	{

        PopulateListFromTDS();

    }

    private void btnUpdateDataDS_Click(object sender, System.EventArgs e)
	{

        // Update the data source table with any changes that
        // were made to the untyped dataset.

        try 
		{

            // Open a connection

            SqlConnection con = new SqlConnection(Connectionstring);

            con.Open();

            //Create the DataAdapter

            SqlDataAdapter daProductsDS = new SqlDataAdapter("Select * from ProductsDS", con);

            SqlCommandBuilder oCommandBuilder = new SqlCommandBuilder(daProductsDS);

            daProductsDS.DeleteCommand = oCommandBuilder.GetDeleteCommand();

            daProductsDS.InsertCommand = oCommandBuilder.GetInsertCommand();

            daProductsDS.UpdateCommand = oCommandBuilder.GetUpdateCommand();

            //Apply the updates

            daProductsDS.Update(dsNorthwind, "ProductsDS");

       } 
		catch(Exception exp)
		{
			
            MessageBox.Show(exp.Message, this.Text);

        }

    }

    private void btnUpdateDataTDS_Click(object sender, System.EventArgs e)
	{

        // Update the data source table with any changes that
        // were made to the typed dataset.

        try 
		{

            // Open a connection

            SqlConnection con = new SqlConnection(Connectionstring);

            con.Open();

            //Create the DataAdapter

            SqlDataAdapter daProductsTDS = new SqlDataAdapter("Select * from ProductsTDS", con);

            SqlCommandBuilder oCommandBuilder = new SqlCommandBuilder(daProductsTDS);

            daProductsTDS.DeleteCommand = oCommandBuilder.GetDeleteCommand();

            daProductsTDS.InsertCommand = oCommandBuilder.GetInsertCommand();

            daProductsTDS.UpdateCommand = oCommandBuilder.GetUpdateCommand();

            //Apply the updates

            daProductsTDS.Update(tdsNorthwind, "ProductsTDS");

		} 
		catch(Exception exp)
		{

            MessageBox.Show(exp.Message, this.Text);

        }

    }

    private void btnUpdateDS_Click(object sender, System.EventArgs e)
	{

        // Update the selected record in the products table.

		if (lstResults.SelectedIndex >= 0)
		{

			string ProductName  = Convert.ToString(dsNorthwind.Tables["ProductsDS"].Rows[lstResults.SelectedIndex]["ProductName"]);

			dsNorthwind.Tables["ProductsDS"].Rows[lstResults.SelectedIndex]["ProductName"] = ProductName + " - Updated";
		}
		else 
		{

			MessageBox.Show("No item selected.", this.Text);

		}

        PopulateListFromDS();

    }

    private void btnUpdateTDS_Click(object sender, System.EventArgs e)
	{
        // Update the first record in the products table.

		if (lstResults.SelectedIndex >= 0)
		{

			string ProductName  = tdsNorthwind.ProductsTDS[lstResults.SelectedIndex].ProductName;

			tdsNorthwind.ProductsTDS[0].ProductName = ProductName + " - Updated";
		}
		else 
		{

			MessageBox.Show("No item selected.", this.Text);

		}

        PopulateListFromTDS();

    }

    private void lstUpdateFromDS_Click(object sender, System.EventArgs e)
	{

        PopulateListFromDS();

    }

    private void lstUpdateFromTDS_Click(object sender, System.EventArgs e)
	{

        PopulateListFromTDS();

    }

    private void InitDataSets()
	{

        // Display a status message box saying that we are attempting to connect.
        // This only needs to be done the first time a connection is attempted.
        // After we have determined that MSDE or SQL Server is installed, this 

        // message no longer needs to be displayed

        frmStatus frmStatusMessage = new frmStatus();

        if (HasConnected==false)
		{

            frmStatusMessage.Show("Connecting to SQL Server");

        }

        // Attempt to connect to SQL server or MSDE

        bool IsConnecting  = true;

        while (IsConnecting)
		{
            try 
			{

                SqlConnection con = new SqlConnection(Connectionstring);

                con.Open();

                // Connection successful

                IsConnecting = false;

                HasConnected = true;

                frmStatusMessage.Close();

                // Since this the first time a conection is made
                // The table being used for this How-To must be created
                // Instantiate Command Object to execute SQL Statements

                SqlCommand cmInitSQL = new SqlCommand();

                // Attach the command to the connection

                cmInitSQL.Connection = con;

                // Set the command type to Text

                cmInitSQL.CommandType = CommandType.Text;

                // Drop ProductsDS table if it exists.

                cmInitSQL.CommandText = "IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ProductsDS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) " + "DROP TABLE [dbo].[ProductsDS] ";

                // Execute the statement

                cmInitSQL.ExecuteNonQuery();

                // Drop ProductsTDS table if it exists.

                cmInitSQL.CommandText = "IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ProductsTDS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) " + "DROP TABLE [dbo].[ProductsTDS] ";

                // Execute the statement

                cmInitSQL.ExecuteNonQuery();

                // Create ProductsDS Table

                cmInitSQL.CommandText = "CREATE TABLE [dbo].[ProductsDS] ( " + "[ProductID] [int] IDENTITY (1, 1) PRIMARY KEY ," + "[ProductName] [nvarchar] (40) NOT NULL , " + "[SupplierID] [int] NULL , " + "[CategoryID] [int] NULL , " + "[QuantityPerUnit] [nvarchar] (20) NULL , " + "[UnitPrice] [money] NULL , " + "[UnitsInStock] [smallint] NULL , " + "[UnitsOnOrder] [smallint] NULL , " + "[ReorderLevel] [smallint] NULL , " + "[Discontinued] [bit] NOT NULL )";

                // Execute the statement

                cmInitSQL.ExecuteNonQuery();

                // Create ProductsTDS Table

                cmInitSQL.CommandText = "CREATE TABLE [dbo].[ProductsTDS] ( " + "[ProductID] [int] IDENTITY (1, 1) PRIMARY KEY ," + "[ProductName] [nvarchar] (40) NOT NULL , " + "[SupplierID] [int] NULL , " + "[CategoryID] [int] NULL , " + "[QuantityPerUnit] [nvarchar] (20) NULL , " + "[UnitPrice] [money] NULL , " + "[UnitsInStock] [smallint] NULL , " + "[UnitsOnOrder] [smallint] NULL , " + "[ReorderLevel] [smallint] NULL , " + "[Discontinued] [bit] NOT NULL )";

                // Execute the statement

                cmInitSQL.ExecuteNonQuery();

                // Insert data into new table from products table in northwind

                cmInitSQL.CommandText = "INSERT INTO ProductsDS " + "(ProductName,SupplierID,CategoryID," + "QuantityPerUnit,UnitPrice,UnitsInStock," + "UnitsOnOrder,ReorderLevel, Discontinued) " + "SELECT ProductName,SupplierID,CategoryID," + "QuantityPerUnit,UnitPrice,UnitsInStock," + "UnitsOnOrder,ReorderLevel, Discontinued FROM Products";

                cmInitSQL.ExecuteNonQuery();

                // Insert data into new table from products table in northwind

                cmInitSQL.CommandText = "INSERT INTO ProductsTDS " + "(ProductName,SupplierID,CategoryID," + "QuantityPerUnit,UnitPrice,UnitsInStock," + "UnitsOnOrder,ReorderLevel, Discontinued) " + "SELECT ProductName,SupplierID,CategoryID," + "QuantityPerUnit,UnitPrice,UnitsInStock," + "UnitsOnOrder,ReorderLevel, Discontinued FROM Products";

                cmInitSQL.ExecuteNonQuery();

                cmInitSQL.Dispose();

                // Create command object to pull data for datasets

                SqlCommand cmdProductsDS = new SqlCommand("SELECT * FROM ProductsDS", con);

                SqlCommand cmdProductsTDS = new SqlCommand("SELECT * FROM ProductsTDS", con);

                // create instances of the dataset and typed dataset

                tdsNorthwind = new Northwind();

                dsNorthwind = new DataSet();

                // Use the sqldataadapter to fill datasets

                SqlDataAdapter daLocal  = new SqlDataAdapter();

                // Select command for Typed Dataset

                daLocal.SelectCommand = cmdProductsTDS;

                // Fill typed Dataset

                daLocal.Fill(tdsNorthwind, "ProductsTDS");

                // Select command for Untyped Dataset

                daLocal.SelectCommand = cmdProductsDS;

                // Fill untyped Dataset

                daLocal.Fill(dsNorthwind, "ProductsDS");

                con.Close();

           } 
			catch( SqlException e)
			{

				if (Connectionstring == SQL_CONNECTION_STRING)
				{

					// Couldn't connect to SQL server. Now try MSDE

					Connectionstring = MSDE_CONNECTION_STRING;

					frmStatusMessage.Show("Connecting to MSDE");
				}
				else 
				{

					// Unable to connect to SQL Server or MSDE

					frmStatusMessage.Close();

					MessageBox.Show("To run this sample you must have SQL Server ot MSDE with " + "the Northwind database installed.  For instructions on " + "installing MSDE, view the Readme file.", "SQL Server/MSDE not found");

					// Quit program if neither connection method was successful.
					Application.Exit();

				}

           } 
			catch(Exception e)
			{

                MessageBox.Show(e.Message, "General Error");

            }

        }

    }

    private void PopulateListFromDS()
	{

        // A table in a dataset is used to populate a list box with 
        // product name from the products table.
        // With the dataset the name of the table and field must be known
        // at design time. if they are misspelled or mistyped
        // an error will be generated only at runtime.

        string s;

        int i;

        lstResults.Items.Clear();

		for(i=0; i <=dsNorthwind.Tables["ProductsDS"].Rows.Count - 1; i++)
		{
			// Check to see if row is flagged deleted.

			if (dsNorthwind.Tables["ProductsDS"].Rows[i].RowState != DataRowState.Deleted)
			{

				// Get the product name for each record.

				s = dsNorthwind.Tables["ProductsDS"].Rows[i]["ProductName"].ToString();

				// Add product name to the list box

				lstResults.Items.Add(s);

			}

		}
    }

    private void PopulateListFromTDS()
	{

        // A table in a typed dataset is used to populate a list box with 
        // product name from the products table.
        // a typed dataset provides design time verification
        // of table names and field names before the program
        // is run.

        string s;

        int i;

        lstResults.Items.Clear();

        
		for(i=0;i<=tdsNorthwind.ProductsTDS.Count - 1;i++)
		{
			// Check to see if row is flagged deleted.

			if (tdsNorthwind.ProductsTDS[i].RowState != DataRowState.Deleted)
			{
				s = tdsNorthwind.ProductsTDS[i].ProductName.ToString();

				lstResults.Items.Add(s);

			}
		}
    }

}

