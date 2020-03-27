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
    Protected WithEvents lblTitle As Label
    Protected WithEvents grdProducts As DataGrid
    Protected WithEvents btnAbout, btnAddNew, btnSave As Button
    Protected WithEvents txtProductName, txtQtyUnit, txtPrice, txtInStock As TextBox
    Protected WithEvents chkDiscontinued As CheckBox
    Protected WithEvents htmlHiddenSortExpression As HtmlInputHidden
    Protected WithEvents pnlForm As Panel
    Protected WithEvents rfvQtyUnit, rfvPrice, rfvInStock, rfvProductName As RequiredFieldValidator
    Protected WithEvents revPrice, revInStock As RegularExpressionValidator

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

    Private dvProducts As DataView
    Public strMsg As String
    Public strErrorMsg As String

    ' Initialize constants for connecting to the database.
    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=northwind;" & _
        "Integrated Security=SSPI"

    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=northwind;" & _
        "Integrated Security=SSPI"

    ' This routine handles the Click event for the "About" button.
    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        ' Open the About page
        Response.Redirect("about.aspx")
    End Sub

    ' This routine handles the "Add New Item" button Click event.
    Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        ' Clear any existing values and show the edit form, if hidden.
        If pnlForm.Visible Then
            txtProductName.Text = ""
            txtQtyUnit.Text = ""
            txtPrice.Text = ""
            txtInStock.Text = ""
            chkDiscontinued.Checked = False
        Else
            pnlForm.Visible = True
        End If

        ' Set a CommandArgument value as a flag for the SaveItem method. This
        ' gets reset in the DataGrid_ItemCommand event handler so that if the
        ' user clicks any item in the DataGrid the application ceases to be in
        ' "add" mode.
        btnSave.CommandArgument = "Add"
    End Sub

    ' This routine handles the "Save Changes" button Click event.
    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsValid Then
            SaveItem()
        End If
    End Sub

    ' This routine handles DataGrid ItemCommand event. The event arguments are such
    ' that "source" is the DataGrid and "e" anything in the DataGrid that is 
    ' associated with a Command handler (e.g., paging, sorting, controls in a 
    ' ButtonColumn, etc.) 
    Private Sub grdProducts_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProducts.ItemCommand
        ' All commands first go through the ItemCommand handler. Thus, if the user 
        ' clicks a header to sort a field, or a paging control to page through 
        ' the results, exit immediately as code for these items is in the 
        ' SortCommand And PageIndexChanged event handlers, respectively.
        If e.Item.ItemType = ListItemType.Pager Or _
            e.Item.ItemType = ListItemType.Header Then Exit Sub

        ' To figure out which Button was clicked, cast the CommandSource property 
        ' of the DataGridCommandEventArg "e".
        Dim btn As Button = CType(e.CommandSource, Button)
        If btn.Text = "Edit" Then
            ' The values for each field in the edit form are taken from the Cells
            ' collection of e.Item.
            txtProductName.Text = e.Item.Cells(1).Text
            txtQtyUnit.Text = e.Item.Cells(2).Text
            ' Trim the dollar sign off the price.
            txtPrice.Text = Microsoft.VisualBasic.Right(e.Item.Cells(3).Text, _
                Len(e.Item.Cells(3).Text) - 1)
            txtInStock.Text = e.Item.Cells(4).Text
            chkDiscontinued.Checked = _
                CType(e.Item.Cells(5).FindControl("chkDiscontinuedGrid"), _
                    CheckBox).Checked
            pnlForm.Visible = True
        Else ' Delete the product.
            ' Use the DataKeys collection to access the key values of each record 
            ' (displayed as a datarow) in a data listing control. This allows you to 
            ' store the key field with a data listing control without displaying it in 
            ' the control. This collection is automatically filled with the values from 
            ' the field specified by the DataKeyField property. You can set this on 
            ' the .aspx page or programmatically, as was done in this sample in the
            ' BindProductsGrid method.
            '
            ' The ItemIndex property contains the 0-based datarow index for the 
            ' DataGridItem. Items that are not datarows have an ItemIndex = -1 (a standard 
            ' ASP .NET value indicating that an item is not selected--e.g., to determine
            ' if the user checked a box in a CheckBoxList control, you could check to see
            ' if the value SelectedIndex property was > -1.)
            DeleteItem(grdProducts.DataKeys(e.Item.ItemIndex).ToString)
        End If

        ' Clear out the CommandArgument for the "Save" button. It is set to "Add"
        ' when the "Add New Item" button is clicked and will persist because the
        ' button's ViewState is enabled (also needed for the CommandArgument to 
        ' work properly in the SaveItem method).
        btnSave.CommandArgument = ""
    End Sub

    ' This routine handles the SortCommand event for the DataGrid. It fires whenever
    ' the user clicks one of the column headers with AllowSorting = True for the 
    ' DataGrid and a SortExpression set in the BoundColumn.
    Private Sub grdProducts_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdProducts.SortCommand
        ' Store the current sort expression (column to sort by) in the HTML input 
        ' control or else you will lose the current sorting when paging.
        htmlHiddenSortExpression.Value = e.SortExpression

        ' Rebind the DataGrid.
        BindProductsGrid()
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

            SetupDemo()
            BindProductsGrid()
        End If
    End Sub

    ' This routine handles the PageIndexChanged event for the Products DataGrid.
    ' Handle this event to implement the DataGrid's built-in paging functionality
    ' when the AllowPaging property of the DataGrid is set to True. 
    Private Sub Products_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdProducts.PageIndexChanged
        grdProducts.CurrentPageIndex = e.NewPageIndex
        ' Retrieve the current sort expression (column to sort by) from the HTML 
        ' input control or else you would lose the current sorting when paging.
        BindProductsGrid()
    End Sub

#Region " SetupDemo() "
    ' This routine creates a SQL Server table for demo purposes and dumps any 
    ' existing DataViews from the application cache.
    Private Sub SetupDemo()
        Dim strSQL As String = _
            "USE Northwind" & vbCrLf & _
            "IF EXISTS (" & _
            "SELECT * " & _
            "FROM Northwind.dbo.sysobjects " & _
            "WHERE Name = 'HowToProducts' " & _
            "AND TYPE = 'u')" & vbCrLf & _
            "BEGIN" & vbCrLf & _
            "DROP TABLE HowToProducts" & vbCrLf & _
            "END" & vbCrLf & _
            "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice, " & _
            "   UnitsInStock, Discontinued " & _
            "INTO Northwind.dbo.HowToProducts " & _
            "FROM Products " & _
            "ALTER TABLE HowToProducts " & _
            "ADD CONSTRAINT [ProductID] PRIMARY KEY CLUSTERED (ProductID)"

        Dim scnnNW As New SqlConnection(SQL_CONNECTION_STRING)
        Dim scmd As New SqlCommand(strSQL, scnnNW)
        scnnNW.Open()
        scmd.ExecuteNonQuery()
        scnnNW.Close()

        ' Dump the DataView for this How-To from the application cache. Failure
        ' to do this can cause strange DataGrid behavior when continually re-running
        ' the application or when going to the About page and returning.
        Cache.Remove("dvProducts")
    End Sub
#End Region

    ' This routine gets a DataView and binds it to the Products DataGrid.
    Private Sub BindProductsGrid()
        GetDataSource()

        With grdProducts
            .DataSource = dvProducts
            .DataBind()
        End With
    End Sub

    ' This routine creates a new DataSet.
    Private Function CreateDataSet() As DataSet

        Dim strSQL As String = _
            "SELECT *  " & _
            "FROM HowToProducts"

        ' The SqlConnection class allows you to communicate with SQL Server.
        ' The constructor accepts a connection string as an argument.  This
        ' connection string uses Integrated Security, which means that you 
        ' must have a login in SQL Server, or be part of the Administrators
        ' group for this to work.
        Dim scnnNW As New SqlConnection(SQL_CONNECTION_STRING)

        ' A SqlCommand object is used to execute the SQL commands.
        Dim scmd As New SqlCommand(strSQL, scnnNW)

        ' A SqlDataAdapter uses the SqlCommand object to fill a DataSet.
        Dim sda As New SqlDataAdapter(scmd)

        ' Create and Fill a new DataSet.
        Dim ds As New DataSet()
        sda.Fill(ds)

        Return ds
    End Function

    ' This routine deletes an item from the database.
    Private Sub DeleteItem(ByVal strProductID As String)
        Dim strSQL As String = _
            "DELETE " & vbCrLf & _
            "FROM HowToProducts " & _
            "WHERE ProductID = " & strProductID

        Dim scnnNW As New SqlConnection(SQL_CONNECTION_STRING)
        Dim scmd As New SqlCommand(strSQL, scnnNW)

        ' Normally you can just let the framework bubble errors to the top and
        ' view them in the default ASP .NET error page or handle via settings in
        ' the customErrors element of web.config. In this case, however, it is
        ' nice to anticipate problems and display a message to the user that keeps
        ' them on the same Web page.
        Try
            scnnNW.Open()
            scmd.ExecuteNonQuery()

            ' You must dump the cache of the DataGrid will bind to the existing 
            ' DataView and the product will not appear to have been deleted.
            Cache.Remove("dvProducts")
            BindProductsGrid()

            strMsg = "Product successfully deleted from the database."
            pnlForm.Visible = False
        Catch exp As Exception
            strErrorMsg = "Database error! Product not deleted from database. " & _
                "Error message: " & exp.Message
        Finally
            scnnNW.Close()
        End Try
    End Sub

    ' This routine returns a sorted DataView that was either retrieved from the 
    ' application or newly created. This increases performance by not having to 
    ' connect to the Database and create a new DataSet every time the user pages 
    ' or sorts.
    Private Sub GetDataSource()

        ' If the DataView can be found in the cache, use it.
        If Not IsNothing(Cache("dvProducts")) Then
            ' All items in the cache are of type Object, so you have to explicitly
            ' cast it before working with it further.
            dvProducts = CType(Cache("dvProducts"), DataView)
        Else ' DataView was not found in the cache.
            ' Create a new DataView.
            dvProducts = CreateDataSet().Tables(0).DefaultView

            ' Put the new DataView into the Cache
            Cache("dvProducts") = dvProducts
        End If

        ' Sort the DataView based on the expression stored in the HtmlInputHidden
        ' control. The Value property is set to "ProductID" on the .aspx page, and 
        ' thus serves as the default value until set to a different value in the 
        ' SortCommand event handler, above.
        dvProducts.Sort = htmlHiddenSortExpression.Value
    End Sub

    ' This routine saves an item to the database, either updating an existing
    ' item or adding a new item. The "update" or "add" functionality is governed
    ' by the value of the btnSave.CommandArgument property. See the btnAddItem
    ' Click event handler for more information.
    Private Sub SaveItem()
        Dim strSQL As String

        If btnSave.CommandArgument = "Add" Then
            strSQL = _
                "INSERT INTO HowToProducts " & _
                "   (ProductName, QuantityPerUnit, UnitPrice, UnitsInStock, " & _
                "    Discontinued) " & _
                "VALUES " & _
                "   (@ProductName, @QuantityPerUnit, @UnitPrice, @UnitsInStock, " & _
                "    @Discontinued)"
        Else ' The user is updating an existing item.
            strSQL = _
                "UPDATE HowToProducts " & _
                "SET ProductName = @ProductName, " & _
                "    QuantityPerUnit = @QuantityPerUnit, " & _
                "    UnitPrice = @UnitPrice, " & _
                "    UnitsInStock = @UnitsInStock, " & _
                "    Discontinued = @Discontinued " & _
                "WHERE ProductID = @ProductID"
        End If

        Dim scnnNW As New SqlConnection(SQL_CONNECTION_STRING)
        Dim scmd As New SqlCommand(strSQL, scnnNW)

        ' Add all the required SQL parameters.
        With scmd.Parameters
            ' The ProductID parameter is only needed for updating.
            If btnSave.CommandArgument <> "Add" Then
                .Add(New SqlParameter("@ProductID", _
                    SqlDbType.Int)).Value = _
                    CInt(grdProducts.DataKeys(grdProducts.SelectedIndex).ToString)
            End If

            .Add(New SqlParameter("@ProductName", _
                SqlDbType.NVarChar, 40)).Value = txtProductName.Text
            .Add(New SqlParameter("@QuantityPerUnit", _
                SqlDbType.NVarChar, 20)).Value = txtQtyUnit.Text
            .Add(New SqlParameter("@UnitPrice", _
                SqlDbType.Money)).Value = CDbl(txtPrice.Text)
            .Add(New SqlParameter("@UnitsInStock", _
                SqlDbType.Int)).Value = CInt(txtInStock.Text)
            .Add(New SqlParameter("@Discontinued", _
                SqlDbType.Bit)).Value = chkDiscontinued.Checked
        End With

        ' Normally you can just let the framework bubble errors to the top and
        ' view them in the default ASP .NET error page or handle via settings in
        ' the customErrors element of web.config. In this case, however, it is
        ' nice to anticipate problems and display a message to the user that keeps
        ' them on the same Web page.
        Try
            scnnNW.Open()
            scmd.ExecuteNonQuery()

            ' You must dump the cache of the DataGrid will bind to the existing 
            ' DataView and the product will not appear to have been deleted.
            Cache.Remove("dvProducts")
            BindProductsGrid()

            strMsg = "Product successfully saved to the database."
            pnlForm.Visible = False
        Catch exp As Exception
            strErrorMsg = "Database error! Product not saved to the " & _
                "database. Error message: " & exp.Message
        Finally
            scnnNW.Close()
        End Try
    End Sub
End Class
