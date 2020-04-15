//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HowToDoDataGridPaging
{

	public class Main: System.Web.UI.Page
	{

		protected Label lblTitle, lblCurrentPage, lblTotalPages;
		protected LinkButton lbtnFirstPage, lbtnPreviousPage, lbtnNextPage, lbtnLastPage;
		protected DataGrid grdOrderDetails;
		protected Button btnAbout;
		protected System.Web.UI.WebControls.CheckBox chkUseCustomPaging;
		protected HtmlInputHidden htmlHiddenSortExpression;
		protected Panel pnlCustomPaging;

		#region " Web Form Designer Generated Code ";

		//This call is required by the Web Form Designer.

		private void InitializeComponent() 
		{

			this.Load +=new System.EventHandler(this.Page_Load);
			this.btnAbout.Click +=new EventHandler(btnAbout_Click);
			this.chkUseCustomPaging.CheckedChanged +=new EventHandler(chkUseCustomPaging_CheckedChanged);
			this.grdOrderDetails.PageIndexChanged +=new DataGridPageChangedEventHandler(OrderDetails_PageIndexChanged);
			this.grdOrderDetails.SortCommand +=new DataGridSortCommandEventHandler(grdOrderDetails_SortCommand);

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

		private DataView dvOrderDetails;
		// Used only with custom paging.
		private Int32 intCurrentPage = 1;

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

		// This routine handles the CheckedChanged event for the CheckBox control.
		// This is all code that is needed for the How-To but which would not need
		// to be implemented in a real-world scenario.

		private void chkUseCustomPaging_CheckedChanged(object sender, System.EventArgs e) 
		{
			// Reset the CurrentPageIndex and dump the DataView from the Cache.

			grdOrderDetails.CurrentPageIndex = 0;
			Cache.Remove("dvOrderDetails");
			BindOrderDetailsGrid();

		}

		// This routine handles the PageIndexChanged event for the OrderDetails DataGrid.
		// Handle this event to implement the DataGrid's built-in paging functionality
		// when the AllowPaging property of the DataGrid is set to true. 

		private void OrderDetails_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e) 
		{
			grdOrderDetails.CurrentPageIndex = e.NewPageIndex;

			// Retrieve the current sort expression (column to sort by) from the HTML 
			// input control or else you would lose the current sorting when paging.
			BindOrderDetailsGrid();

		}

		// This routine handles the SortCommand event for the DataGrid. It fires whenever
		// the user clicks one of the column headers with AllowSorting = true for the 
		// DataGrid and a SortExpression set in the BoundColumn.

		private void grdOrderDetails_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e) 
		{
			// Store the current sort expression (column to sort by) in the HTML input 
			// control or else you will lose the current sorting when paging.

			htmlHiddenSortExpression.Value = e.SortExpression;

			if (chkUseCustomPaging.Checked) 
			{
				// Set the current page.
				intCurrentPage = Convert.ToInt32(lblCurrentPage.Text);
			}
			// Rebind the DataGrid.
			BindOrderDetailsGrid();
		}

		// This routine handles the Click event for the four custom paging LinkButton
		// controls.

		protected void NavigationLink_Click(object sender, CommandEventArgs e)
		{

			switch( e.CommandName)
			{
				case "First":
				{
					intCurrentPage = 1;
					break;
				}
				case "Last":
				{
					intCurrentPage = Convert.ToInt32(lblTotalPages.Text);
					break;
				}
				case "Next":
				{
					intCurrentPage = Convert.ToInt32(lblCurrentPage.Text) + 1;
					break;
				}
				case "Prev":
				{
					intCurrentPage = Convert.ToInt32(lblCurrentPage.Text) - 1;
					break;
				}
			}

			BindOrderDetailsGrid();

		}

		// This routine handles the Load event for the Web Form.

		private void Page_Load(object sender, System.EventArgs e)
		{

			// Only do the following if the user is not posting back to the page. In 
			// other words, do this only the first time the user accesses this page.
			// IsPostBack resets to false when the user navigates to a different page
			// and returns, or presses CTRL + F5 (hard refresh).
			if (!Page.IsPostBack) 
			{
				// So that we only need to set the title of the application once,
				// we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
				// to read the AssemblyTitle attribute.
				AssemblyInfo ainfo = new AssemblyInfo();
				this.lblTitle.Text = ainfo.Title;
				// For demo purposes only: Dump the cache to fully reset.
				Cache.Remove("dvOrderDetails");
				BindOrderDetailsGrid();
			}
		}
		// This routine binds the OrderDetails DataGrid to a DataView that is either
		// filtered or unfiltered determined in the SetPagingControls method.

		private void BindOrderDetailsGrid()
		{
			GetDataSource();
			SetPagingControls();
			grdOrderDetails.DataSource = dvOrderDetails;
			grdOrderDetails.DataBind();
        
		}
		// Returns a Dataset with an extra RowID column added.
		private DataSet CreateDataSet()
		{

			string strSQL = 
				"SELECT od.OrderID, p.ProductName, od.UnitPrice, od.Quantity, " + 
				"   od.Discount, c.CategoryName " + 
				"FROM [Order Details] od " + 
				"INNER JOIN Products p ON od.ProductID = p.ProductID " + 
				"INNER JOIN Categories c ON p.CategoryID = c.CategoryID " + 
				"GROUP BY od.OrderID, p.ProductName, od.UnitPrice, od.Quantity, " + 
				"   od.Discount, c.CategoryName";
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
			// Add a RowID column for custom paging. To keep from having to cache two
			// different versions of the DataView, one with a RowID and one without, add
			// the RowID column to the Dataset regardless of whether the user checked
			// the "Use Custom Paging" CheckBox. This code is really needed, however, 
			// only for custom paging.
			DataTable dt = ds.Tables[0];
			dt.Columns.Add("RowID", typeof(System.Int32));
			dt.AcceptChanges();
			return ds;
		}

		// This routine returns a sorted and renumbered DataView that was retrieved from
		// the application cache. if the DataView could not be found in the cache, then
		// it is newly created. This increases performance by not having to connect to the
		// Database and create a new Dataset every time the user pages or sorts.
		private void GetDataSource()
		{

			// if the DataView can be found in the cache, use it.
			if (Cache["dvOrderDetails"] != null) 
			{
				// All items in the cache are of type Object, so you have to explicitly
				// cast it before working with it further.
				dvOrderDetails = (DataView) Cache["dvOrderDetails"];
			}
			else 
			{
				// DataView was not found in the cache.;
				// Create a new DataView.
				dvOrderDetails = CreateDataSet().Tables[0].DefaultView;
				// Put the new DataView into the Cache
				Cache["dvOrderDetails"] = dvOrderDetails;
			}
			// Sort the DataView based on the expression stored in the HtmlInputHidden
			// control. The Value property is set to "OrderID" on the .aspx page, and thus
			// serves the default value until set to a different value in the 
			// SortCommand event handler, above.
			dvOrderDetails.Sort = htmlHiddenSortExpression.Value;
			// Because the RowID numbers have already been added, if you don't renumber
			// them then after a new sort these numbers are out of order and useless for
			// custom paging.
			if (chkUseCustomPaging.Checked) 
			{
				RenumberRowsForPaging(ref dvOrderDetails);
			}
		}
		// This routine renumbers the RowID field in the DataView after sorting. Notice
		// the DataView is passed ref to keep from having to use up memory to copy and
		// pass ByVal.
		private void RenumberRowsForPaging(ref DataView dv)
		{
			// Reset the DataView to have on RowFilter before applying a new RowFilter. 
			// if you do not do this, the previous RowFilter will be in effect, and your 
			// dv.Count will be equal to the PageSize, which will cause a runtime error.
			dvOrderDetails.RowFilter = string.Empty;

			int i = 0;
			foreach(DataRowView drwv in dv)
			{
				drwv["RowID"] = i;
				i += 1;
			}
		}

		// This routine sets up the paging controls--either the standard, built-in paging
		// DataGrid paging, or custom paging.
		private void SetPagingControls()
		{
			// if custom paging is not being used then turn on the built-in DataGrid
			// paging, hide the custom paging controls and exit the routine.
			if (!chkUseCustomPaging.Checked) 
			{
				pnlCustomPaging.Visible = false;
				grdOrderDetails.AllowPaging = true;
				return;
			}
			// The rest of this code applies only to custom paging.
			pnlCustomPaging.Visible = true;
			grdOrderDetails.AllowPaging = false;
			// Determine the RowID values for the first and last record of the current 
			// page of DataGrid results.
			string strFirstRec = 
				((intCurrentPage - 1) * grdOrderDetails.PageSize).ToString();
			string strLastRec = 
				((intCurrentPage * grdOrderDetails.PageSize) + 1).ToString();
			// Determine the total number of DataGrid results pages. Do this before 
			// applying the RowFilter to the DataView.
			Int32 intTotalPages = 
				Convert.ToInt32(System.Math.Ceiling(dvOrderDetails.Count / grdOrderDetails.PageSize));
			// Apply the newly calculate RowFilter.
			dvOrderDetails.RowFilter = "RowID > " + strFirstRec + 
				" AND RowID < " + strLastRec;
			// All the values are calculated, now set how the custom paging controls
			// appear to the user.
			lblCurrentPage.Text = intCurrentPage.ToString();
			lblTotalPages.Text = intTotalPages.ToString();
			if (intCurrentPage == 1) 
			{
				lbtnPreviousPage.Enabled = false;
				if (intTotalPages > 1) 
				{
					lbtnNextPage.Enabled = true;
				}
				else 
				{
					lbtnNextPage.Enabled = false;
				}
			}
			else 
			{
				lbtnPreviousPage.Enabled = true;
				if (intCurrentPage == intTotalPages)
				{
					lbtnNextPage.Enabled = false;
				}
				else 
				{
					lbtnNextPage.Enabled = true;
				}
			}
		}
	}
}
