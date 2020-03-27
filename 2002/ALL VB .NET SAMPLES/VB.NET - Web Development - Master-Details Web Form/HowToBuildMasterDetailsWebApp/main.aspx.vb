'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Data.SqlClient

Public Class Main
	Inherits System.Web.UI.Page
	Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents grdCustomers, grdOrders, grdOrderDetails As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAbout As System.Web.UI.WebControls.Button

#Region " Web Form Designer Generated Code "

	'This call is required by the Web Form Designer.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

	Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
		'CODEGEN: This method call is required by the Web Form Designer
		'Do not modify it using the code editor.
		InitializeComponent()
	End Sub

#End Region

    ' Initialize constants for connecting to the database
    ' and displaying a connection error to the user.
    Protected Const CONNECTION_ERROR_MSG As String = _
        "To run this sample, you must have SQL " & _
        "or MSDE with the Northwind database installed.  For " & _
        "instructions on installing MSDE, view the ReadMe file."

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=northwind;" & _
        "Integrated Security=SSPI"

    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=northwind;" & _
        "Integrated Security=SSPI"

    Protected strConn As String = SQL_CONNECTION_STRING

    ' This routine handles the "About" button click event.
    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        ' Open the About page
        Response.Redirect("about.aspx")
    End Sub

    ' This routine handles the main master DataGrid (grdCustomers) ItemCommand event.
    ' This event fires when any button is clicked in the DataGrid control, including
    ' LinkButton controls. It is the key event to handle for a Master-Details Web
    ' application, for in it is placed the logic to bind the next-level details 
    ' DataGrid based on the user's selection.
    Private Sub grdCustomers_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdCustomers.ItemCommand
        ' e.Item is a DataGridItem object that represents the selected item. These
        ' objects are not just the datarows but also the header (e.g., column names
        ' the user clicks for sorting) or footer (e.g., LinkButton controls used for
        ' paging). Therefore, check the ListItemType and exit early if you don't 
        ' want the remaining logic to apply. In this case if a user clicks a paging 
        ' control, exit the sub routine.
        If e.Item.ItemType = ListItemType.Pager Then Exit Sub

        ' The user must have clicked one of the "Orders" buttons, so proceed. Create
        ' a SqlParameter object to pass to the sub routine for binding the next-level
        ' details DataGrid.
        Dim param As New SqlParameter("@CustomerID", SqlDbType.NChar, 5)
        ' Use the DataKeys collection to access the key values of each record 
        ' (displayed as a datarow) in a data listing control. This allows you to 
        ' store the key field with a data listing control without displaying it in 
        ' the control. This collection is automatically filled with the values from 
        ' the field specified by the DataKeyField property. You can set this on 
        ' the .aspx page or programmatically, as was done in this sample in the
        ' BindOrderGrid method.
        '
        ' The ItemIndex property contains the 0-based datarow index for the 
        ' DataGridItem. Items that are not datarows have an ItemIndex = -1 (a standard 
        ' ASP .NET value indicating that an item is not selected--e.g., to determine
        ' if the user checked a box in a CheckBoxList control, you could check to see
        ' if the value SelectedIndex property was > -1.)
        param.Value = grdCustomers.DataKeys(e.Item.ItemIndex)
        BindOrdersGrid(param)
    End Sub

    ' This routine handles the PageIndexChanged event for the Customers DataGrid.
    ' Handle this event to implement the DataGrid's built-in paging functionality
    ' when the AllowPaging property of the DataGrid is set to True. 
    Private Sub grdCustomers_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdCustomers.PageIndexChanged
        grdCustomers.CurrentPageIndex = e.NewPageIndex
        BindCustomersGrid()
    End Sub

    ' This routine handles the "second-level" master DataGrid (grdOrders) 
    ' ItemCommand event. This event fires when any button is clicked in the 
    ' DataGrid control, including LinkButton controls. It is the key event to 
    ' handle for a Master-Details Web application, for in it is placed the logic
    ' to bind the next-level details DataGrid based on the user's selection.
    Private Sub grdOrders_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdOrders.ItemCommand
        ' See comments in grdCustomers_ItemCommand for all code in this handler.
        If e.Item.ItemType = ListItemType.Pager Then Exit Sub

        Dim param As New SqlParameter("@OrderID", SqlDbType.Int)
        param.Value = grdOrders.DataKeys(e.Item.ItemIndex)
        BindOrderDetailsGrid(param)
    End Sub

    ' This routine handles the PageIndexChanged event for the Orders DataGrid.
    ' Handle this event to implement the DataGrid's built-in paging functionality
    ' when the AllowPaging property of the DataGrid is set to True. 
    Private Sub grdOrders_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdOrders.PageIndexChanged
        grdOrders.CurrentPageIndex = e.NewPageIndex

        Dim param As New SqlParameter("@CustomerID", SqlDbType.NChar, 5)
        param.Value = grdCustomers.DataKeys(grdCustomers.SelectedIndex)
        BindOrdersGrid(param)
    End Sub

    ' This routine handles the Load event for the Web Form.
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Only do the following if the user is not posting back to the page. In 
        ' other words, do this only the first time the user accesses this page.
        ' IsPostBack resets to False when the user navigates to a different page
        ' and returns, or presses CTRL + F5 (hard refresh).
        If Not Page.IsPostBack Then
            ' So that we only need to set the title of the application once,
            ' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
            ' to read the AssemblyTitle attribute.
            Dim ainfo As New AssemblyInfo()

            Me.lblTitle.Text = ainfo.Title

            ' Initially display only the main master DataGrid.
            BindCustomersGrid()
        End If
    End Sub

    ' This routine calls CreateDataSet and binds the Customers DataGrid to the 
    ' return value.
    Sub BindCustomersGrid()

        Dim strSQL As String = _
            "SELECT c.CustomerID, c.CompanyName, c.City, " & _
            "   COUNT(o.OrderDate) AS OrderCount " & _
            "FROM Customers c " & _
            "INNER JOIN Orders o ON c.CustomerID = o.CustomerID " & _
            "GROUP BY c.CustomerID, c.CompanyName, c.City"

        With grdCustomers
            ' Set the DataKeyField so that the DataKeys collection is filled and
            ' usable in the ItemCommand event handler. See further comments in 
            ' grdCustomers_ItemCommand(), above.
            .DataKeyField = "CustomerID"
            .DataSource = CreateDataSet(strSQL)
            .DataBind()
        End With
    End Sub

    ' This routine calls CreateDataSet and binds the OrderDetails DataGrid to the 
    ' return value.
    Sub BindOrderDetailsGrid(ByVal param As SqlParameter)

        Dim strSQL As String = _
            "SELECT p.ProductName, od.UnitPrice, od.Quantity, " & _
            "   od.Discount, c.CategoryName " & _
            "FROM [Order Details] od " & _
            "INNER JOIN Products p ON od.ProductID = p.ProductID " & _
            "INNER JOIN Categories c ON p.CategoryID = c.CategoryID " & _
            "WHERE OrderID = @OrderID"

        With grdOrderDetails
            .DataSource = CreateDataSet(strSQL, param)
            .DataBind()
            .Visible = True
        End With
    End Sub

    ' This routine calls CreateDataSet and binds the Orders DataGrid to the 
    ' return value.
    Sub BindOrdersGrid(ByVal param As SqlParameter)

        Dim strSQL As String = _
            "SELECT o.OrderID, o.OrderDate, o.ShippedDate, " & _
            "   o.Freight, s.CompanyName As ShippedVia " & _
            "FROM Orders o " & _
            "INNER JOIN Shippers s ON o.ShipVia = s.ShipperID " & _
            "WHERE CustomerID = @CustomerID"

        With grdOrders
            ' Set the DataKeyField so that the DataKeys collection is filled and
            ' usable in the ItemCommand event handler. See further comments in 
            ' grdCustomers_ItemCommand(), above.
            .DataKeyField = "OrderID"
            .DataSource = CreateDataSet(strSQL, param)
            .DataBind()
            .Visible = True
        End With
    End Sub

    ' This routine is used by all three DataGrid binding routines to create a
    ' DataSet for databinding.
    Private Function CreateDataSet(ByVal strSQL As String, _
        Optional ByVal sqlParam As SqlParameter = Nothing) As DataSet

        ' The SqlConnection class allows you to communicate with SQL Server.
        ' The constructor accepts a connection string as an argument.  This
        ' connection string uses Integrated Security, which means that you 
        ' must have a login in SQL Server, or be part of the Administrators
        ' group for this to work.
        Dim scnnNW As New SqlConnection(strConn)

        ' A SqlCommand object is used to execute the SQL commands.
        Dim scmd As New SqlCommand(strSQL, scnnNW)

        If Not IsNothing(sqlParam) Then
            scmd.Parameters.Add(sqlParam)
        End If

        ' A SqlDataAdapter uses the SqlCommand object to fill a DataSet.
        Dim sda As New SqlDataAdapter(scmd)

        ' Create and Fill a new DataSet.
        Dim ds As New DataSet()
        sda.Fill(ds)

        Return ds
    End Function

End Class
