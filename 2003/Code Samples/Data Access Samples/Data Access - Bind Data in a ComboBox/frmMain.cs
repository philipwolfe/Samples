//Copyright (C) 2002 Microsoft Corporation

//All rights reserved.

//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 

//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 

//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Data.SqlClient;
using System.Data;
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

    protected DataSet dsProducts = new DataSet();

    protected DataView dvProducts ;

    protected const string SQL_CONNECTION_STRING  ="Server=localhost;" + "DataBase=Northwind;" + "Integrated Security=SSPI" ;

    protected const string MSDE_CONNECTION_STRING  = @"Server=(local)\NetSDK;" + "DataBase=Northwind;" + "Integrated Security=SSPI" ;

    protected const string CAPTION_TITLE  = "Bind Data to a ComboBox";

    protected const string DEFAULT_SORT  = "ProductName ASC";

    protected const string PRODUCT_TABLE_NAME  = "Products";

    //define a structure for a sales division which has

    // a division name and division id.

	protected struct Divisions
	{

		private string divName;
		private int divId;

		public Divisions(string name , int id)
		{
			divName=name;
			divId = id;
		}
		public string getName
		{
			get
			{

				return divName;
			}
		}

		public int getId
		{
			get
			{
				return divId;

			}

		}

	}

    private System.Windows.Forms.Button cmdDV;

    private System.Windows.Forms.Label lblAssociated;

    private System.Windows.Forms.GroupBox GroupBox1;

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

    private System.Windows.Forms.ComboBox ComboBox1;

    private System.Windows.Forms.Button cmdArray;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Button cmdArrayList;

    private System.Windows.Forms.Button cmdArrayListA;

    private System.Windows.Forms.Button cmdDS;

    private System.Windows.Forms.GroupBox GroupBox2;

    private System.Windows.Forms.Label lblSource;

	private void InitializeComponent() 
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.ComboBox1 = new System.Windows.Forms.ComboBox();

        this.cmdArray = new System.Windows.Forms.Button();

        this.Label1 = new System.Windows.Forms.Label();

        this.cmdArrayList = new System.Windows.Forms.Button();

        this.cmdArrayListA = new System.Windows.Forms.Button();

        this.cmdDS = new System.Windows.Forms.Button();

        this.cmdDV = new System.Windows.Forms.Button();

        this.GroupBox1 = new System.Windows.Forms.GroupBox();

        this.lblAssociated = new System.Windows.Forms.Label();

        this.GroupBox2 = new System.Windows.Forms.GroupBox();

        this.lblSource = new System.Windows.Forms.Label();

        this.GroupBox1.SuspendLayout();

        this.GroupBox2.SuspendLayout();

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

        //ComboBox1

        //

        this.ComboBox1.Location = new System.Drawing.Point(32, 40);

        this.ComboBox1.Name = "ComboBox1";

        this.ComboBox1.Size = new System.Drawing.Size(200, 21);

        this.ComboBox1.TabIndex = 0;

		this.ComboBox1.SelectedIndexChanged+=new EventHandler(ComboBox1_SelectedIndexChanged);

        //

        //cmdArray

        //

        this.cmdArray.Location = new System.Drawing.Point(32, 112);

        this.cmdArray.Name = "cmdArray";

        this.cmdArray.Size = new System.Drawing.Size(144, 23);

        this.cmdArray.TabIndex = 1;

        this.cmdArray.Text = "&Array";

		this.cmdArray.Click+=new EventHandler(cmdArray_Click);

        //

        //Label1

        //

        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (Byte) 0);

        this.Label1.Location = new System.Drawing.Point(32, 72);

        this.Label1.Name = "Label1";

        this.Label1.Size = new System.Drawing.Size(200, 24);

        this.Label1.TabIndex = 2;

        this.Label1.Text = "Populate the Combo Box using one of the data sources below. ";

        //

        //cmdArrayList

        //

        this.cmdArrayList.Location = new System.Drawing.Point(32, 136);

        this.cmdArrayList.Name = "cmdArrayList";

        this.cmdArrayList.Size = new System.Drawing.Size(144, 23);

        this.cmdArrayList.TabIndex = 3;

        this.cmdArrayList.Text = "Array&List";

		this.cmdArrayList.Click+=new EventHandler(cmdArrayList_Click);

        //

        //cmdArrayListA

        //

        this.cmdArrayListA.Location = new System.Drawing.Point(32, 160);

        this.cmdArrayListA.Name = "cmdArrayListA";

        this.cmdArrayListA.Size = new System.Drawing.Size(144, 23);

        this.cmdArrayListA.TabIndex = 4;

        this.cmdArrayListA.Text = "A&rrayList - Advanced";

		this.cmdArrayListA.Click+=new EventHandler(cmdArrayListA_Click);

        //

        //cmdDS

        //

        this.cmdDS.Location = new System.Drawing.Point(32, 184);

        this.cmdDS.Name = "cmdDS";

        this.cmdDS.Size = new System.Drawing.Size(144, 23);

        this.cmdDS.TabIndex = 5;

        this.cmdDS.Text = "&DataSet";

		this.cmdDS.Click+=new EventHandler(cmdDS_Click);

        //

        //cmdDV

        //

        this.cmdDV.Location = new System.Drawing.Point(32, 208);

        this.cmdDV.Name = "cmdDV";

        this.cmdDV.Size = new System.Drawing.Size(144, 23);

        this.cmdDV.TabIndex = 6;

        this.cmdDV.Text = "Data&View";

		this.cmdDV.Click+=new EventHandler(cmdDV_Click);

        //

        //GroupBox1

        //

        this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblAssociated});

        this.GroupBox1.Location = new System.Drawing.Point(232, 176);

        this.GroupBox1.Name = "GroupBox1";

        this.GroupBox1.Size = new System.Drawing.Size(128, 48);

        this.GroupBox1.TabIndex = 7;

        this.GroupBox1.TabStop = false;

        this.GroupBox1.Text = "Associated Value";

        this.GroupBox1.Visible = false;

        //

        //lblAssociated

        //

        this.lblAssociated.Location = new System.Drawing.Point(8, 24);

        this.lblAssociated.Name = "lblAssociated";

        this.lblAssociated.Size = new System.Drawing.Size(96, 16);

        this.lblAssociated.TabIndex = 1;

        //

        //GroupBox2

        //

        this.GroupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblSource});

        this.GroupBox2.Location = new System.Drawing.Point(232, 112);

        this.GroupBox2.Name = "GroupBox2";

        this.GroupBox2.Size = new System.Drawing.Size(128, 48);

        this.GroupBox2.TabIndex = 8;

        this.GroupBox2.TabStop = false;

        this.GroupBox2.Text = "Data Source";

        //

        //lblSource

        //

        this.lblSource.Location = new System.Drawing.Point(8, 24);

        this.lblSource.Name = "lblSource";

        this.lblSource.Size = new System.Drawing.Size(112, 16);

        this.lblSource.TabIndex = 1;

        //

        //frmMain

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(410, 251);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.GroupBox2, this.GroupBox1, this.cmdDV, this.cmdDS, this.cmdArrayListA, this.cmdArrayList, this.Label1, this.cmdArray, this.ComboBox1});

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.MaximizeBox = false;

        this.Menu = this.mnuMain;

        this.Name = "frmMain";

        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        this.Text = "Title Comes from Assembly Info";

        this.GroupBox1.ResumeLayout(false);

        this.GroupBox2.ResumeLayout(false);

		this.Load+=new EventHandler(frmMain_Load);

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

    private void cmdArray_Click(object sender, System.EventArgs e) 
	{

       //bind to a simple array of string entries for colors. 

        string[] myColors = {"AQUA","BLACK","BLUE","GREEN","RED","WHITE","YELLOW"};

        ComboBox1.DataSource=myColors;
		
        ComboBox1.SelectedIndex=0;

        GroupBox1.Visible=false;

        lblSource.Text="Array";

    }

    private void cmdArrayList_Click(object sender, System.EventArgs e)
	{

        //bind to a simple arraylist which has entries for different shapes

        ArrayList myShapes = new ArrayList();

	
        myShapes.Add("CIRCLE");

        myShapes.Add("OCTAGON");

        myShapes.Add("RECTANGLE");

        myShapes.Add("SQUARE");

        myShapes.Add("TRAPEZOID");

        myShapes.Add("TRIANGLE");

        ComboBox1.DataSource=myShapes;

        ComboBox1.SelectedIndex=0;

        GroupBox1.Visible=false;

        lblSource.Text="ArrayList";

    }

    private void cmdArrayListA_Click(object sender, System.EventArgs e)
	{

        //bind to an arraylist that contains entries based on the the structure that
        // has been defined sales divisions (divisions).

        ArrayList myDivisions =new ArrayList();

        //add division structure entries to the arraylist

        myDivisions.Add(new Divisions("CENTRAL",1));

        myDivisions.Add(new Divisions("EAST",2));

        myDivisions.Add(new Divisions("NORTH",3));

        myDivisions.Add(new Divisions("SOUTH",4));

        //bind the arraylist to the combo box

        ComboBox1.DataSource=myDivisions;

        ComboBox1.DisplayMember="getName";

        ComboBox1.ValueMember="getId";

        ComboBox1.SelectedIndex=0;

        lblAssociated.Text=ComboBox1.SelectedValue.ToString();

        GroupBox1.Visible=true;

        lblSource.Text="ArrayList-Advanced";

    }

	
    private void cmdDS_Click(object sender, System.EventArgs e)
	{
        //bind to the products table from the Northwind database that has 
        //previously been loaded into the dataset dsProducts.
        //Note that the table has not been sorted in any particular order.

       
        ComboBox1.DataSource=dsProducts.Tables["PRODUCTS"];

        ComboBox1.DisplayMember="ProductName";

        ComboBox1.ValueMember="ProductID";

        ComboBox1.SelectedIndex=0;

        lblAssociated.Text=ComboBox1.SelectedValue.ToString();

        GroupBox1.Visible=true;

        lblSource.Text="DataSet";

    }

    private void frmMain_Load(object sender, System.EventArgs e) 
	{

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

                SqlConnection northwindConnection = new SqlConnection(strConnection);

                // The SqlDataAdapter is used to populate a Dataset 

                SqlDataAdapter ProductAdapter =new SqlDataAdapter("SELECT * " + "FROM products",northwindConnection);

                // Populate the Dataset with the information from the products
                // table.  Since a Dataset can hold multiple result sets, it's
                // a good idea to "name" the result set when you populate the
                // DataSet.  In this case, the result set is named "Products".

                ProductAdapter.Fill(dsProducts, PRODUCT_TABLE_NAME);

                //create the dataview; use a constructor to specify
                // the sort, filter criteria for performance purposes

                dvProducts = new DataView(dsProducts.Tables["products"],"",DEFAULT_SORT,DataViewRowState.OriginalRows);

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

        GroupBox1.Visible=false;

    }

    private void cmdDV_Click(object sender, System.EventArgs e)
	{
        //bind to the sorted view of the products table
        // on the product name column, ascending.  


        ComboBox1.DataSource=dvProducts;

        ComboBox1.DisplayMember="ProductName";

        ComboBox1.ValueMember="ProductID";

        ComboBox1.SelectedIndex=0;

        lblAssociated.Text=ComboBox1.SelectedValue.ToString();

        GroupBox1.Visible=true;

        lblSource.Text="DataView";
    }

    private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e) 
	{
        //display the associated value for the item selected from the combox,
        // if one is available. To determine a value is available
        // check the visibility of the groupbox. This attribute has been set to false
        // during binding by code if a value is not available, to true if it is.

        if (GroupBox1.Visible== true)
		{

            lblAssociated.Text= ComboBox1.SelectedValue.ToString();

        }

    }

}

