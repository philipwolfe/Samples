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
    Protected WithEvents lblTitle, lblCurrentPage, lblTotalPages As Label
    Protected WithEvents lbtnFirstPage, lbtnPreviousPage, lbtnNextPage, lbtnLastPage As LinkButton
    Protected WithEvents grdOrderDetails As DataGrid
    Protected WithEvents btnAbout As Button
    Protected WithEvents chkUseCustomPaging As System.Web.UI.WebControls.CheckBox
    Protected WithEvents htmlHiddenSortExpression As HtmlInputHidden
    Protected WithEvents pnlCustomPaging As Panel

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

    Private dvOrderDetails As DataView
    ' Used only with custom paging.
    Private intCurrentPage As Int32 = 1

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

    ' This routine handles the CheckedChanged event for the CheckBox control.
    ' This is all code that is needed for the How-To but which would not need
    ' to be implemented in a real-world scenario.
    Private Sub chkUseCustomPaging_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseCustomPaging.CheckedChanged
        ' Reset the CurrentPageIndex and dump the DataView from the Cache.
        grdOrderDetails.CurrentPageIndex = 0
        Cache.Remove("dvOrderDetails")
        BindOrderDetailsGrid()
    End Sub

    ' This routine handles the PageIndexChanged event for the OrderDetails DataGrid.
    ' Handle this event to implement the DataGrid's built-in paging functionality
    ' when the AllowPaging property of the DataGrid is set to True. 
    Private Sub OrderDetails_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdOrderDetails.PageIndexChanged
        grdOrderDetails.CurrentPageIndex = e.NewPageIndex
        ' Retrieve the current sort expression (column to sort by) from the HTML 
        ' input control or else you would lose the current sorting when paging.
        BindOrderDetailsGrid()
    End Sub

    ' This routine handles the SortCommand event for the DataGrid. It fires whenever
    ' the user clicks one of the column headers with AllowSorting = True for the 
    ' DataGrid and a SortExpression set in the BoundColumn.
    Private Sub grdOrderDetails_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdOrderDetails.SortCommand
        ' Store the current sort expression (column to sort by) in the HTML input 
        ' control or else you will lose the current sorting when paging.
        htmlHiddenSortExpression.Value = e.SortExpression

        If chkUseCustomPaging.Checked Then
            ' Set the current page.
            intCurrentPage = CInt(lblCurrentPage.Text)
        End If

        ' Rebind the DataGrid.
        BindOrderDetailsGrid()
    End Sub

    ' This routine handles the Click event for the four custom paging LinkButton
    ' controls.
    Protected Sub NavigationLink_Click(ByVal sender As [Object], ByVal e As CommandEventArgs)
        Select Case e.CommandName
            Case "First"
                intCurrentPage = 1
            Case "Last"
                intCurrentPage = CInt(lblTotalPages.Text)
            Case "Next"
                intCurrentPage = CInt(lblCurrentPage.Text) + 1
            Case "Prev"
                intCurrentPage = CInt(lblCurrentPage.Text) - 1
        End Select

        BindOrderDetailsGrid()
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

            ' For demo purposes only: Dump the cache to fully reset.
            Cache.Remove("dvOrderDetails")
            BindOrderDetailsGrid()
        End If
    End Sub

    ' This routine binds the OrderDetails DataGrid to a DataView that is either
    ' filtered or unfiltered as determined in the SetPagingControls method.
    Private Sub BindOrderDetailsGrid()
        GetDataSource()
        SetPagingControls()

        With grdOrderDetails
            .DataSource = dvOrderDetails
            .DataBind()
        End With
    End Sub

    ' Returns a DataSet with an extra RowID column added.
    Private Function CreateDataSet() As DataSet

        Dim strSQL As String = _
            "SELECT od.OrderID, p.ProductName, od.UnitPrice, od.Quantity, " & _
            "   od.Discount, c.CategoryName " & _
            "FROM [Order Details] od " & _
            "INNER JOIN Products p ON od.ProductID = p.ProductID " & _
            "INNER JOIN Categories c ON p.CategoryID = c.CategoryID " & _
            "GROUP BY od.OrderID, p.ProductName, od.UnitPrice, od.Quantity, " & _
            "   od.Discount, c.CategoryName"

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

        ' Add a RowID column for custom paging. To keep from having to cache two
        ' different versions of the DataView, one with a RowID and one without, add
        ' the RowID column to the DataSet regardless of whether the user checked
        ' the "Use Custom Paging" CheckBox. This code is really needed, however, 
        ' only for custom paging.
        Dim dt As DataTable = ds.Tables(0)
        dt.Columns.Add("RowID", Type.GetType("System.Int32"))
        dt.AcceptChanges()

        Return ds
    End Function

    ' This routine returns a sorted and renumbered DataView that was retrieved from
    ' the application cache. If the DataView could not be found in the cache, then
    ' it is newly created. This increases performance by not having to connect to the
    ' Database and create a new DataSet every time the user pages or sorts.
    Private Sub GetDataSource()

        ' If the DataView can be found in the cache, use it.
        If Not IsNothing(Cache("dvOrderDetails")) Then
            ' All items in the cache are of type Object, so you have to explicitly
            ' cast it before working with it further.
            dvOrderDetails = CType(Cache("dvOrderDetails"), DataView)
        Else ' DataView was not found in the cache.
            ' Create a new DataView.
            dvOrderDetails = CreateDataSet().Tables(0).DefaultView

            ' Put the new DataView into the Cache
            Cache("dvOrderDetails") = dvOrderDetails
        End If

        ' Sort the DataView based on the expression stored in the HtmlInputHidden
        ' control. The Value property is set to "OrderID" on the .aspx page, and thus
        ' serves as the default value until set to a different value in the 
        ' SortCommand event handler, above.
        dvOrderDetails.Sort = htmlHiddenSortExpression.Value
        ' Because the RowID numbers have already been added, if you don't renumber
        ' them then after a new sort these numbers are out of order and useless for
        ' custom paging.
        If chkUseCustomPaging.Checked Then
            RenumberRowsForPaging(dvOrderDetails)
        End If
    End Sub

    ' This routine renumbers the RowID field in the DataView after sorting. Notice
    ' the DataView is passed ByRef to keep from having to use up memory to copy and
    ' pass ByVal.
    Private Sub RenumberRowsForPaging(ByRef dv As DataView)
        ' Reset the DataView to have on RowFilter before applying a new RowFilter. 
        ' If you do not do this, the previous RowFilter will be in effect, and your 
        ' dv.Count will be equal to the PageSize, which will cause a runtime error.
        dvOrderDetails.RowFilter = ""

        Dim drwv As DataRowView
        Dim i As Int32
        For Each drwv In dv
            drwv("RowID") = i
            i += 1
        Next
    End Sub

    ' This routine sets up the paging controls--either the standard, built-in paging
    ' DataGrid paging, or custom paging.
    Private Sub SetPagingControls()
        ' If custom paging is not being used then turn on the built-in DataGrid
        ' paging, hide the custom paging controls and exit the routine.
        If Not chkUseCustomPaging.Checked Then
            pnlCustomPaging.Visible = False
            grdOrderDetails.AllowPaging = True
            Exit Sub
        End If

        ' The rest of this code applies only to custom paging.
        pnlCustomPaging.Visible = True
        grdOrderDetails.AllowPaging = False

        ' Determine the RowID values for the first and last record of the current 
        ' page of DataGrid results.
        Dim strFirstRec As String = _
            ((intCurrentPage - 1) * grdOrderDetails.PageSize).ToString
        Dim strLastRec As String = _
            ((intCurrentPage * grdOrderDetails.PageSize) + 1).ToString

        ' Determine the total number of DataGrid results pages. Do this before 
        ' applying the RowFilter to the DataView.
        Dim intTotalPages As Int32 = _
            CInt(System.Math.Ceiling(dvOrderDetails.Count / grdOrderDetails.PageSize))

        ' Apply the newly calculate RowFilter.
        dvOrderDetails.RowFilter = "RowID > " & strFirstRec & _
            " AND RowID < " & strLastRec

        ' All the values are calculated, now set how the custom paging controls
        ' appear to the user.
        lblCurrentPage.Text = intCurrentPage.ToString
        lblTotalPages.Text = intTotalPages.ToString

        If intCurrentPage = 1 Then
            lbtnPreviousPage.Enabled = False

            If intTotalPages > 1 Then
                lbtnNextPage.Enabled = True
            Else
                lbtnNextPage.Enabled = False
            End If
        Else
            lbtnPreviousPage.Enabled = True

            If intCurrentPage = intTotalPages Then
                lbtnNextPage.Enabled = False
            Else
                lbtnNextPage.Enabled = True
            End If
        End If
    End Sub

End Class
