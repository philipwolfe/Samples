//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Data.SqlClient;
using System;
using System.Web.UI.WebControls;
using System.Data;

public class Main: System.Web.UI.Page
	  {

	protected System.Web.UI.WebControls.Label lblTitle;
    protected System.Web.UI.WebControls.DataGrid grdCustomers, grdOrders, grdOrderDetails;
    protected System.Web.UI.WebControls.Button btnAbout;

#region " Web Form Designer Generated Code ";

	//This call is required by the Web Form Designer.

	private void InitializeComponent() {
		
		this.btnAbout.Click +=new EventHandler(btnAbout_Click);
		this.grdCustomers.ItemCommand +=new DataGridCommandEventHandler(grdCustomers_ItemCommand);
		this.grdOrders.ItemCommand +=new DataGridCommandEventHandler(grdOrders_ItemCommand);
		this.grdCustomers.PageIndexChanged +=new DataGridPageChangedEventHandler(grdCustomers_PageIndexChanged);
		this.grdOrders.ItemCommand +=new DataGridCommandEventHandler(grdOrders_ItemCommand);
		this.grdOrders.PageIndexChanged +=new DataGridPageChangedEventHandler(grdOrders_PageIndexChanged);
		this.Load +=new EventHandler(this.Page_Load);

    }

	override protected void OnInit(EventArgs e)
	{

		//CODEGEN: This method call is required by the Web Form Designer
		//Do not modify it using the code editor.

		InitializeComponent();
		base.OnInit(e);

	}

#endregion

    // Initialize constants for connecting to the database

    // and displaying a connection error to the user.

    protected const  string CONNECTION_ERROR_MSG= 
        "To run this sample, you must have SQL " + 
        "or MSDE with the Northwind database installed.  For " + 
        "instructions on installing MSDE, view the ReadMe file.";

	protected const string MSDE_CONNECTION_STRING = 
	@"Server=(local)\NetSDK;" + 
	"DataBase=northwind;" + 
	"Integrated Security=SSPI";

	protected const string SQL_CONNECTION_STRING = 
	"Server=localhost;" + 
	"DataBase=northwind;" + 
	"Integrated Security=SSPI";

    protected string strConn = SQL_CONNECTION_STRING;

    // This routine handles the "About" button click event.

    private void btnAbout_Click(object sender, System.EventArgs e) 
	{
        // Open the About page

        Response.Redirect("about.aspx");

    }

    // This routine handles the main master DataGrid (grdCustomers) ItemCommand event.
    // This event fires when any button is clicked in the DataGrid control, including
    // LinkButton controls. It is the key event to handle for a Master-Details Web
    // application, for in it is placed the logic to bind the next-level details 
    // DataGrid based on the user's selection.

    private void grdCustomers_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e) 
	{
        // e.Item is a DataGridItem object that represents the selected item. These
        // objects are not just the datarows but also the header (e.g., column names
        // the user clicks for sorting) or footer (e.g., LinkButton controls used for
        // paging). Therefore, check the ListItemType and exit early if you don't 
        // want the remaining logic to apply. In this case if a user clicks a paging 
        // control, exit the sub routine.

		if (e.Item.ItemType == ListItemType.Pager) 
		{ 
			return;
		}

        // The user must have clicked one of the "Orders" buttons, so proceed. Create
        // a SqlParameter object to pass to the sub routine for binding the next-level
        // details DataGrid.

        SqlParameter param = new SqlParameter("@CustomerID", SqlDbType.NChar, 5);

        // Use the DataKeys collection to access the key values of each record 
        // (displayed a datarow) in a data listing control. This allows you to 
        // store the key field with a data listing control without displaying it in 
        // the control. This collection is automatically filled with the values from 
        // the field specified by the DataKeyField property. You can set this on 
        // the .aspx page or programmatically, was done in this sample in the
        // BindOrderGrid method.
        //
        // The ItemIndex property contains the 0-based datarow index for the 
        // DataGridItem. Items that are not datarows have an ItemIndex = -1 (a standard 
        // ASP .NET value indicating that an item is not selected--e.g., to determine
        // if the user checked a box in a CheckBoxList control, you could check to see
        // if the value SelectedIndex property was > -1.)

        param.Value = grdCustomers.DataKeys[e.Item.ItemIndex];

        BindOrdersGrid(param);

    }

    // This routine handles the PageIndexChanged event for the Customers DataGrid.
    // Handle this event to implement the DataGrid's built-in paging functionality
    // when the AllowPaging property of the DataGrid is set to true.

    void grdCustomers_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e) 
{
        grdCustomers.CurrentPageIndex = e.NewPageIndex;
        BindCustomersGrid();

    }

    // This routine handles the "second-level" master DataGrid (grdOrders) 

    // ItemCommand event. This event fires when any button is clicked in the 

    // DataGrid control, including LinkButton controls. It is the key event to 

    // handle for a Master-Details Web application, for in it is placed the logic

    // to bind the next-level details DataGrid based on the user's selection.

    private void grdOrders_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e) 
	{
        // See comments in grdCustomers_ItemCommand for all code in this handler.

		if (e.Item.ItemType == ListItemType.Pager)
		{
				return;
		}

        SqlParameter param =new SqlParameter("@OrderID", SqlDbType.Int);

        param.Value = grdOrders.DataKeys[e.Item.ItemIndex];

        BindOrderDetailsGrid(param);

    }

    // This routine handles the PageIndexChanged event for the Orders DataGrid.
    // Handle this event to implement the DataGrid's built-in paging functionality
    // when the AllowPaging property of the DataGrid is set to true. 

    private void grdOrders_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e) 
	{
        grdOrders.CurrentPageIndex = e.NewPageIndex;

        SqlParameter param = new SqlParameter("@CustomerID", SqlDbType.NChar, 5);
        param.Value = grdCustomers.DataKeys[grdCustomers.SelectedIndex];
        BindOrdersGrid(param);

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
            // Initially display only the main master DataGrid.
            BindCustomersGrid();

        }

    }

    // This routine calls CreateDataset and binds the Customers DataGrid to the 
    // return value.

	void BindCustomersGrid()
	{

        string strSQL = 
            "SELECT c.CustomerID, c.CompanyName, c.City, " + 
            "   COUNT(o.OrderDate) AS OrderCount " + 
            "FROM Customers c " + 
            "INNER JOIN Orders o ON c.CustomerID = o.CustomerID " + 
            "GROUP BY c.CustomerID, c.CompanyName, c.City";

            // Set the DataKeyField so that the DataKeys collection is filled and
            // usable in the ItemCommand event handler. See further comments in 
            // grdCustomers_ItemCommand(), above.
            grdCustomers.DataKeyField = "CustomerID";
            grdCustomers.DataSource = CreateDataSet(strSQL,null);
            grdCustomers.DataBind();
        
    }

    // This routine calls CreateDataset and binds the OrderDetails DataGrid to the 
    // return value.

    void BindOrderDetailsGrid(SqlParameter param)
	{

        string strSQL = 
            "SELECT p.ProductName, od.UnitPrice, od.Quantity, " + 
            "   od.Discount, c.CategoryName " + 
            "FROM [Order Details] od " + 
            "INNER JOIN Products p ON od.ProductID = p.ProductID " + 
            "INNER JOIN Categories c ON p.CategoryID = c.CategoryID " + 
            "WHERE OrderID = @OrderID";

            grdOrderDetails.DataSource = CreateDataSet(strSQL, param);
            grdOrderDetails.DataBind();
            grdOrderDetails.Visible = true;
        

    }

    // This routine calls CreateDataset and binds the Orders DataGrid to the 
    // return value.

    void BindOrdersGrid(SqlParameter param)
	{

        string strSQL = 
            "SELECT o.OrderID, o.OrderDate, o.ShippedDate, " + 
            "   o.Freight, s.CompanyName ShippedVia " + 
            "FROM Orders o " + 
            "INNER JOIN Shippers s ON o.ShipVia = s.ShipperID " + 
            "WHERE CustomerID = @CustomerID";

            // Set the DataKeyField so that the DataKeys collection is filled and
            // usable in the ItemCommand event handler. See further comments in 
            // grdCustomers_ItemCommand(), above.

            grdOrders.DataKeyField = "OrderID";
            grdOrders.DataSource = CreateDataSet(strSQL, param);
            grdOrders.DataBind();
            grdOrders.Visible = true;

    }

    // This routine is used by all three DataGrid binding routines to create a
    // Dataset for databinding.

    private DataSet CreateDataSet(string strSQL, SqlParameter sqlParam)
	{

        // The SqlConnection class allows you to communicate with SQL Server.
        // The constructor accepts a connection string an argument.  This
        // connection string uses Integrated Security, which means that you 
        // must have a login in SQL Server, or be part of the Administrators
        // group for this to work.
        SqlConnection scnnNW = new SqlConnection(strConn);

        // A SqlCommand object is used to execute the SQL commands.

        SqlCommand scmd = new SqlCommand(strSQL, scnnNW);

        if (sqlParam != null) {
            scmd.Parameters.Add(sqlParam);
        }

        // A SqlDataAdapter uses the SqlCommand object to fill a DataSet.
        SqlDataAdapter sda = new SqlDataAdapter(scmd);

        // Create and Fill a new DataSet.

        DataSet ds = new DataSet();
        sda.Fill(ds);
        return ds;

    }

}

