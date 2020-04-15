//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Collections;


public class Main : System.Web.UI.Page
{
    protected Label lblTitle, lblChecked, lblSelected;

    protected DropDownList cboProducts;

    protected Button btnAbout, btnBindDropDownList, btnShowSelectedItem, btnShowCheckedItems;
	
    protected CheckBoxList clstProducts;
	protected System.Web.UI.WebControls.TextBox txtNewOption;

    protected RadioButtonList optlDataSource;
	

#region " Web Form Designer Generated Code ";

    //This call is required by the Web Form Designer.

	[System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent() {
		this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
		this.btnBindDropDownList.Click+=new EventHandler(btnBindDropDownList_Click);
		this.btnShowSelectedItem.Click += new System.EventHandler(this.btnShowSelectedItem_Click);
		this.btnShowCheckedItems.Click += new System.EventHandler(this.btnShowCheckedItems_Click);
		this.Load+=new EventHandler(Page_Load);
		
	

	}
	override protected void OnInit(EventArgs e)
	{
		//
		// CODEGEN: This call is required by the ASP.NET Web Form Designer.
		//
		InitializeComponent();
		base.OnInit(e);
	}
//    private void Page_Init(object sender, System.EventArgs e) 
//	{
//        //CODEGEN: This method call is required by the Web Form Designer
//        //Do not modify it using the code editor.
//        InitializeComponent();
//    }

#endregion

    //private ArrayList arlProducts;

    DataSet dsProducts = new DataSet();

    private SqlDataReader sdrProducts;

    private string strConn;

    protected const string MSDE_CONNECTION_STRING = "Server=(local)\\NetSDK;" + 
        "DataBase=Northwind;" + 
        "Integrated Security=SSPI";

    protected const string SQL_CONNECTION_STRING = "Server=localhost;" + 
        "DataBase=Northwind;" + 
        "Integrated Security=SSPI";

    // This routine handles the "About" button click event.
    private void btnAbout_Click(object sender, System.EventArgs e) 
	{
        // Open the About page.
        Response.Redirect("about.aspx");
    }

    // This routine handles the "Bind DropDownList" button Click event.
    private void btnBindDropDownList_Click(object sender, System.EventArgs e) 
	{
        lblSelected.Text = string.Empty;
		if (optlDataSource.SelectedIndex == 0) 
		{
			BindDropDowListUsingDataSet();
		}
		else 
		{
			BindDropDowListUsingDataReader();
		}
    }

    // This routine handles the "Show Checked Items" button Click event. It displays
    // a list of all the checked items in the CheckBoxList control.
    private void btnShowCheckedItems_Click(object sender, System.EventArgs e) 
	{
        //ListItem item ;  //Items in the CheckedListBox are of type DataRowView.;
        StringBuilder sb = new StringBuilder();

        // Comparing this to the similar Windows Forms CheckedListBox control, the
        // term "Selected" is used when the items are actually being checked. With
        // the CheckedListBox, a distinction is made between "selected" (which means
        // "highlighted") and "checked". Also, with the WebControl there is no 
        // Collection or selected or checked items. You have to iterate through all
        // items in the collection and determine if it is selected.

        foreach(ListItem item in clstProducts.Items)
		{
            if (item.Selected)
			{
                sb.Append(item.Text);
                sb.Append(" (");
                sb.Append(item.Value);
                sb.Append("), ");
            }
        }
        lblChecked.Text = sb.ToString();
    }

    // This routine handles the "Show Selected Item" button Click event. It displays
    // the index, text, and value of the selected item in the DropDownList control.
    private void btnShowSelectedItem_Click(object sender, System.EventArgs e) 
	{
       lblSelected.Text = "You selected option " + cboProducts.SelectedIndex.ToString() + 
                ". Its value is " + cboProducts.SelectedItem.Value + " and its " + 
                "text is " + cboProducts.SelectedItem.Text + ".";
    }

    // This routine handles the Page's Load event.
    private void Page_Load(object sender, System.EventArgs e) 
	{
        //Put user code to initialize the page here

        if (!(Page.IsPostBack)) {
            // So that we only need to set the title of the application once,
            // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
            // to read the AssemblyTitle attribute.
            AssemblyInfo ainfo = new AssemblyInfo();
            this.lblTitle.Text = ainfo.Title;
            BindDropDowListUsingDataSet();
            BindCheckBoxListUsingDataSet();
        }
    }

    // This subroutine is used within a While...End while iteration through the 
    // contents of a DataReader. It Binds an ArrayList with instances of the custom
    // Product class, the property values of which are initialized with data
    // from the DataReader.
    private void AddItemToDataSource(ref ArrayList arl)
	{
        // See further comments in frmMain.vb.
		arl.Add(new Product(sdrProducts.GetInt32(0), sdrProducts["ProductName"].ToString()));
	}
	
	// This routine binds the CheckBoxList to a DataSet. the code is identical 
	// to that for the DropDownList, only binding to a Dataset is demonstrated.
	private void BindCheckBoxListUsingDataSet()
	{
		// See BindDropDownListUsingDataset for further comments.
		clstProducts.DataTextField = "Name";
		clstProducts.DataValueField = "ID";

		if (txtNewOption.Text.Trim() != "") 
		{
			string sNewOption = txtNewOption.Text;
			clstProducts.DataSource = UI.AddOption(dsProducts, clstProducts.DataTextField,
				clstProducts.DataValueField, ref sNewOption, "0");
		}
		else 
		{
			clstProducts.DataSource = dsProducts;
		}
            clstProducts.DataBind();
    }

    // This routine binds the DropDownList to an ArrayList filled by iterating 
    // through a SqlDataReader. See also the comments in the Helper.Product
    // class.
    private void BindDropDowListUsingDataReader()
	{
        strConn = SQL_CONNECTION_STRING;
        string strSQL  = "SELECT ProductID, ProductName FROM Products";
        SqlConnection scnnNorthwind = new SqlConnection(strConn);
        SqlCommand scmd = new SqlCommand(strSQL, scnnNorthwind);
        ArrayList arlProducts = new ArrayList();
        scnnNorthwind.Open();
        sdrProducts = scmd.ExecuteReader(CommandBehavior.CloseConnection);

        // Iterate through the DataReader Items collection. The Read method
        // returns a bool value = true while there are more rows to read.

        while (sdrProducts.Read())
		{
            // Fill one of the objects that implements the IList interface
            // (in this case, an ArrayList) so that complex databinding can
            // be used.
            AddItemToDataSource(ref arlProducts);
        }

        cboProducts.DataValueField = "ID";
        cboProducts.DataTextField = "Name";

		if (txtNewOption.Text.Trim() != "") 
		{
			cboProducts.DataSource = UI.AddOption(arlProducts, new Product(0, txtNewOption.Text));
		}
		else 
		{
			cboProducts.DataSource = arlProducts;
		}
        // You must explicitly call DataBind() when using WebControls!
        cboProducts.DataBind();
        sdrProducts.Close();
    }

    // This routine binds the DropDownList to a DataSet.

    private void BindDropDowListUsingDataSet()
	{
        strConn = SQL_CONNECTION_STRING;

        // See comments in frmMain.vb concerning the need for the
        // column aliases.

        string strSQL = "SELECT ProductID ID, ProductName Name " +
            "FROM Products " + 
            "ORDER BY ProductName";

        // See other event handlers for comments about the following
        // lines of code.

        SqlConnection scnnNorthwind = new SqlConnection(strConn);
        SqlCommand scmd = new SqlCommand(strSQL, scnnNorthwind);
        SqlDataAdapter sda = new SqlDataAdapter(scmd);
        

        // Bind the DataSet.
        sda.Fill(dsProducts);

        // Bind the data to the DropDowList control.
        cboProducts.DataTextField = "Name";
        cboProducts.DataValueField = "ID";
            // Notice that, unlike the ComboBox, you do not have to access the
            // particular table in the Dataset (unless there was more than one
            // DataTable).

		if (txtNewOption.Text.Trim() != "")
		{
			string sNewOption = txtNewOption.Text;
			cboProducts.DataSource = UI.AddOption(dsProducts, cboProducts.DataTextField, cboProducts.DataValueField, ref sNewOption, "0");
		}
		else 
		{
			cboProducts.DataSource = dsProducts;
		}

            // You must explicitly call DataBind() when using WebControls!
            cboProducts.DataBind();
    }
}

