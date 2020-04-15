//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;

public class Main: System.Web.UI.Page
{
    protected Label lblTitle;
    protected DataGrid grdProducts;
    protected Button btnAbout, btnAddNew, btnSave;
    protected TextBox txtProductName, txtQtyUnit, txtPrice, txtInStock;
    protected CheckBox chkDiscontinued;
    protected HtmlInputHidden htmlHiddenSortExpression;
    protected Panel pnlForm;
    protected RequiredFieldValidator rfvQtyUnit, rfvPrice, rfvInStock, rfvProductName;
    protected RegularExpressionValidator revPrice, revInStock;
	//protected System.Web.UI.WebControls.Button btnAddNew;

#region " Web Form Designer Generated Code ";

    //This call is required by the Web Form Designer.

    private void InitializeComponent() {
		this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
		this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
		this.grdProducts.SelectedIndexChanged += new System.EventHandler(this.grdProducts_SelectedIndexChanged);
		this.Load += new System.EventHandler(this.Page_Load);
		this.grdProducts.ItemCommand+=new DataGridCommandEventHandler(grdProducts_ItemCommand);

	}

	override protected void OnInit(EventArgs e)
	{
		//
		// CODEGEN: This call is required by the ASP.NET Web Form Designer.
		//
		InitializeComponent();
		base.OnInit(e);
	}

#endregion

    private DataView dvProducts;
    public string strMsg;
    public string strErrorMsg;

    // Initialize constants for connecting to the database.

    protected const string MSDE_CONNECTION_STRING = 
        @"Server=(local)\NetSDK;" + 
        "DataBase=northwind;" + 
        "Integrated Security=SSPI";

    protected const string SQL_CONNECTION_STRING = 
        "Server=localhost;" + 
        "DataBase=northwind;" + 
        "Integrated Security=SSPI";

    // This routine handles the Click event for the "About" button.

    private void btnAbout_Click(object sender, System.EventArgs e)
	{
        // Open the About page
        Response.Redirect("about.aspx");
    }

    // This routine handles the "Add new Item" button Click event.

    private void btnAddNew_Click(object sender, System.EventArgs e) 
	{
        // Clear any existing values and show the edit form, if hidden.
		if (pnlForm.Visible)
		{
			txtProductName.Text = string.Empty;
			txtQtyUnit.Text = string.Empty;
			txtPrice.Text = string.Empty;
			txtInStock.Text = string.Empty;
			chkDiscontinued.Checked = false;
		}
		else 
		{
			pnlForm.Visible = true;
		}

        // Set a CommandArgument value a flag for the SaveItem method. This
        // gets reset in the DataGrid_ItemCommand event handler so that if the
        // user clicks any item in the DataGrid the application ceases to be in
        // "add" mode.

        btnSave.CommandArgument = "Add";

    }

    // This routine handles the "Save Changes" button Click event.

    private void btnSave_Click(object sender, System.EventArgs e)
	{
        if (IsValid) {

            SaveItem();

        }

    }

    // This routine handles DataGrid ItemCommand event. The event arguments are such
    // that "source" is the DataGrid and "e" anything in the DataGrid that is 
    // associated with a Command handler (e.g., paging, sorting, controls in a 
    // ButtonColumn, etc.) 

    private void grdProducts_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e) 
		//grdProducts.ItemCommand;
	{
        // All commands first go through the ItemCommand handler. Thus, if the user 
        // clicks a header to sort a field, or a paging control to page through 
        // the results, exit immediately code for these items is in the 
        // SortCommand && PageIndexChanged event handlers, respectively.

		if ((e.Item.ItemType == ListItemType.Pager) | (
			e.Item.ItemType == ListItemType.Header)) 
		{
				return;
		}
        // To figure out which Button was clicked, cast the CommandSource property 
        // of the DataGridCommandEventArg "e".

        Button btn = (Button) e.CommandSource;

		if (btn.Text == "Edit") 
		{
			// The values for each field in the edit form are taken from the Cells
			// collection of e.Item.
			txtProductName.Text = e.Item.Cells[1].Text;
			txtQtyUnit.Text = e.Item.Cells[2].Text;
			// Trim the dollar sign off the price.
			txtPrice.Text = e.Item.Cells[3].Text.Substring(1);
			txtInStock.Text = e.Item.Cells[4].Text;
			chkDiscontinued.Checked = 
				((CheckBox)(e.Item.Cells[5].FindControl("chkDiscontinuedGrid"))).Checked;
			pnlForm.Visible = true;
		}
		else 
		{
			// Delete the product.
				   // Use the DataKeys collection to access the key values of each record 
				   // (displayed a datarow) in a data listing control. This allows you to 
				   // store the key field with a data listing control without displaying it in 
				   // the control. This collection is automatically filled with the values from 
				   // the field specified by the DataKeyField property. You can set this on 
				   // the .aspx page or programmatically, was done in this sample in the
				   // BindProductsGrid method.
				   //
				   // The ItemIndex property contains the 0-based datarow index for the 
				   // DataGridItem. Items that are not datarows have an ItemIndex = -1 (a standard 
				   // ASP .NET value indicating that an item is not selected--e.g., to determine
				   // if the user checked a box in a CheckBoxList control, you could check to see
				   // if the value SelectedIndex property was > -1.)

				   DeleteItem(grdProducts.DataKeys[e.Item.ItemIndex].ToString());

				   }
        // Clear out the CommandArgument for the "Save" button. It is set to "Add"
        // when the "Add new Item" button is clicked and will persist because the
        // button's ViewState is enabled (also needed for the CommandArgument to 
        // work properly in the SaveItem method).

        btnSave.CommandArgument = string.Empty;

    }
    // This routine handles the SortCommand event for the DataGrid. It fires whenever
    // the user clicks one of the column headers with AllowSorting = true for the 
    // DataGrid and a SortExpression set in the BoundColumn.

    private void grdProducts_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e) 
		//grdProducts.SortCommand;
	{
        // Store the current sort expression (column to sort by) in the HTML input 
        // control or else you will lose the current sorting when paging.
        htmlHiddenSortExpression.Value = e.SortExpression;
        // Rebind the DataGrid.
        BindProductsGrid();
    }

    // This routine handles the Load event for the Web Form.

    private void Page_Load(object sender, System.EventArgs e)
	{
        // Only do the following if the user is not posting back to the page. In 
        // other words, do this only the first time the user accesses this page.
        // IsPostBack resets to false when the user navigates to a different page
        // and returns, or presses CTRL + F5 (hard refresh).

        if (!Page.IsPostBack) {

            // So that we only need to set the title of the application once,
            // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
            // to read the AssemblyTitle attribute.

            AssemblyInfo ainfo = new AssemblyInfo();

            this.lblTitle.Text = ainfo.Title;

            SetupDemo();

            BindProductsGrid();

        }

    }

    // This routine handles the PageIndexChanged event for the Products DataGrid.
    // Handle this event to implement the DataGrid's built-in paging functionality
    // when the AllowPaging property of the DataGrid is set to true. 

    private void Products_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e) 
		//grdProducts.PageIndexChanged;
	{
        grdProducts.CurrentPageIndex = e.NewPageIndex;

        // Retrieve the current sort expression (column to sort by) from the HTML 

        // input control or else you would lose the current sorting when paging.

        BindProductsGrid();

    }

#region " SetupDemo() ";

    // This routine creates a SQL Server table for demo purposes and dumps any 
    // existing DataViews from the application cache.

    private void SetupDemo()
	{

        string strSQL = 
            "USE Northwind" + Environment.NewLine + 
            "IF EXISTS (" + 
            "SELECT * " + 
            "FROM Northwind.dbo.sysobjects " + 
            "WHERE Name = 'HowToProducts' " + 
            "AND TYPE = 'u')" + Environment.NewLine + 
            "BEGIN" + Environment.NewLine + 
            "DROP TABLE HowToProducts" + Environment.NewLine + 
            "END" + Environment.NewLine + 
            "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice, " + 
            "   UnitsInStock, Discontinued " + 
            "INTO Northwind.dbo.HowToProducts " + 
            "FROM Products " + 
            "ALTER TABLE HowToProducts " + 
            "ADD CONSTRAINT [ProductID] PRIMARY KEY CLUSTERED (ProductID)";

        SqlConnection scnnNW = new SqlConnection(SQL_CONNECTION_STRING);
        SqlCommand scmd = new SqlCommand(strSQL, scnnNW);
        scnnNW.Open();
        scmd.ExecuteNonQuery();
        scnnNW.Close();

        // Dump the DataView for this How-To from the application cache. Failure
        // to do this can cause strange DataGrid behavior when continually re-running
        // the application or when going to the About page and returning.

        Cache.Remove("dvProducts");

    }

#endregion

    // This routine gets a DataView and binds it to the Products DataGrid.

    private void BindProductsGrid()
{

        GetDataSource();

            grdProducts.DataSource = dvProducts;

            grdProducts.DataBind();

    }

    // This routine creates a new DataSet.

    private DataSet CreateDataSet()
	{

        string strSQL = "SELECT * FROM HowToProducts";

        // The SqlConnection class allows you to communicate with SQL Server.
        // The constructor accepts a connection string an argument.  This
        // connection string uses Integrated Security, which means that you 
        // must have a login in SQL Server, or be part of the Administrators
        // group for this to work.

        SqlConnection scnnNW = new SqlConnection(SQL_CONNECTION_STRING);

        // A SqlCommand object is used to execute the SQL commands.

        SqlCommand scmd = new SqlCommand(strSQL, scnnNW);

        // A SqlDataAdapter uses the SqlCommand object to fill a DataSet.

        SqlDataAdapter sda = new SqlDataAdapter(scmd);

        // Create and Fill a new DataSet.

        DataSet ds = new DataSet();

        sda.Fill(ds);

        return ds;

    }

    // This routine deletes an item from the database.

    private void DeleteItem(string strProductID)
	{

        string strSQL = 
            "DELETE " + Environment.NewLine + 
            "FROM HowToProducts " + 
            "WHERE ProductID = " + strProductID;
        SqlConnection scnnNW = new SqlConnection(SQL_CONNECTION_STRING);
        SqlCommand scmd = new SqlCommand(strSQL, scnnNW);

        // Normally you can just let the framework bubble errors to the top and
        // view them in the default ASP .NET error page or handle via settings in
        // the customErrors element of web.config. In this case, however, it is
        // nice to anticipate problems and display a message to the user that keeps
        // them on the same Web page.

		try 
		{

			scnnNW.Open();
			scmd.ExecuteNonQuery();

			// You must dump the cache of the DataGrid will bind to the existing 
			// DataView and the product will not appear to have been deleted.

			Cache.Remove("dvProducts");
			BindProductsGrid();
			strMsg = "Product successfully deleted from the database.";
			pnlForm.Visible = false;

		} 
		catch(Exception exp)
		{
			strErrorMsg = "Database error! Product not deleted from database. " + 
				"Error message: " + exp.Message;
		}
	finally
{
	scnnNW.Close();

}

    }

    // This routine returns a sorted DataView that was either retrieved from the 
    // application or newly created. This increases performance by not having to 
    // connect to the Database and create a new Dataset every time the user pages 
    // or sorts.

    private void GetDataSource()
	{

        // if the DataView can be found in the cache, use it.

		if (Cache["dvProducts"] != null) 
		{

			// All items in the cache are of type Object, so you have to explicitly
			// cast it before working with it further.

			dvProducts = (DataView) Cache["dvProducts"];
		}
		else 
		{
			// DataView was not found in the cache.;

				   // Create a new DataView.

				   dvProducts = CreateDataSet().Tables[0].DefaultView;

			// Put the new DataView into the Cache

			Cache["dvProducts"] = dvProducts;

		}

        // Sort the DataView based on the expression stored in the HtmlInputHidden
        // control. The Value property is set to "ProductID" on the .aspx page, and 
        // thus serves the default value until set to a different value in the 
        // SortCommand event handler, above.

        dvProducts.Sort = htmlHiddenSortExpression.Value;

    }

    // This routine saves an item to the database, either updating an existing
    // item or adding a new item. The "update" or "add" functionality is governed
    // by the value of the btnSave.CommandArgument property. See the btnAddItem
    // Click event handler for more information.

    private void SaveItem()
	{

        string strSQL;

		if (btnSave.CommandArgument == "Add") 
		{
			strSQL = 
				"INSERT INTO HowToProducts " + 
				"   (ProductName, QuantityPerUnit, UnitPrice, UnitsInStock, " + 
				"    Discontinued) " + 
				"VALUES " + 
				"   (@ProductName, @QuantityPerUnit, @UnitPrice, @UnitsInStock, " + 
				"    @Discontinued)";
		}
		else 
		{
			// The user is updating an existing item.

				   strSQL = 
					   "UPDATE HowToProducts " + 
					   "SET ProductName = @ProductName, " + 
					   "    QuantityPerUnit = @QuantityPerUnit, " + 
					   "    UnitPrice = @UnitPrice, " + 
					   "    UnitsInStock = @UnitsInStock, " + 
					   "    Discontinued = @Discontinued " + 
					   "WHERE ProductID = @ProductID";
		}

        SqlConnection scnnNW = new SqlConnection(SQL_CONNECTION_STRING);
        SqlCommand scmd = new SqlCommand(strSQL, scnnNW);
        // Add all the required SQL parameters.
            // The ProductID parameter is only needed for updating.

            if (btnSave.CommandArgument != "Add") 
			{
                scmd.Parameters.Add(new SqlParameter("@ProductID", 
                    SqlDbType.Int)).Value = 
                Convert.ToInt32(grdProducts.DataKeys[grdProducts.SelectedIndex].ToString());

            }

            scmd.Parameters.Add(new SqlParameter("@ProductName", 
                SqlDbType.NVarChar, 40)).Value = txtProductName.Text;
            scmd.Parameters.Add(new SqlParameter("@QuantityPerUnit", 
                SqlDbType.NVarChar, 20)).Value = txtQtyUnit.Text;
            scmd.Parameters.Add(new SqlParameter("@UnitPrice", 
                SqlDbType.Money)).Value = Convert.ToDouble(txtPrice.Text);
            scmd.Parameters.Add(new SqlParameter("@UnitsInStock", 
                SqlDbType.Int)).Value = Convert.ToInt32(txtInStock.Text);
            scmd.Parameters.Add(new SqlParameter("@Discontinued", 
                SqlDbType.Bit)).Value = chkDiscontinued.Checked;
        
        // Normally you can just let the framework bubble errors to the top and
        // view them in the default ASP .NET error page or handle via settings in
        // the customErrors element of web.config. In this case, however, it is
        // nice to anticipate problems and display a message to the user that keeps
        // them on the same Web page.

		try 
		{
			scnnNW.Open();
			scmd.ExecuteNonQuery();
			// You must dump the cache of the DataGrid will bind to the existing 
			// DataView and the product will not appear to have been deleted.
			Cache.Remove("dvProducts");
			BindProductsGrid();
			strMsg = "Product successfully saved to the database.";
			pnlForm.Visible = false;
		}
		catch(Exception exp)
		{
			strErrorMsg = "Database error! Product not saved to the " + 
				"database. Error message: " + exp.Message;
		}
        finally
		{
            scnnNW.Close();
        }

    }

	private void grdProducts_SelectedIndexChanged(object sender, System.EventArgs e)
	{
	
	}

}

