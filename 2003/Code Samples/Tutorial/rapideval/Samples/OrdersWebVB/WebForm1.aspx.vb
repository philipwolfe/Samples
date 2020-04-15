Option Strict On
Option Explicit On 
Imports System.Data
Imports System.Web.UI.WebControls


Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected dvOrders As New DataView
    Protected WithEvents dsOrders As New dsCustOrder
    Protected WithEvents txtStartDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents CompareVal_StartDate As System.Web.UI.WebControls.CompareValidator

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgOrders As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlCustomers As System.Web.UI.WebControls.DropDownList
    Protected WithEvents OrderDateStart As System.Web.UI.WebControls.Calendar
    Protected WithEvents OrderDateEnd As System.Web.UI.WebControls.Calendar
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents cmdShow As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Load XML data file into DataSet
        dsOrders.ReadXml(Server.MapPath("CustOrder.xml"))

        If Not IsPostBack Then
            ' Bind drop down list to Customers DropDownList
            ddlCustomers.DataBind()

            ' Populate TextBoxes with selected dates in the Calendar controls
            txtStartDate.Text = OrderDateStart.SelectedDate.ToShortDateString
            txtEndDate.Text = OrderDateEnd.SelectedDate.ToShortDateString
        End If
    End Sub


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

        ' Filter and display orders for the selected customer and date range
        FilterOrders()

    End Sub

    Private Sub FilterOrders()

        Dim tableFilter As New System.Text.StringBuilder

        tableFilter.Append("CustomerID='")
        tableFilter.Append(ddlCustomers.SelectedItem.Value.ToString())
        tableFilter.Append("' AND OrderDate >='")
        tableFilter.Append(txtStartDate.Text)
        tableFilter.Append("' AND OrderDate <='")
        tableFilter.Append(txtEndDate.Text)
        tableFilter.Append("'")

        dvOrders = dsOrders.Orders.DefaultView
        dvOrders.RowFilter = tableFilter.ToString
        Session("dvOrders") = dvOrders
        If dvOrders.Count > 0 Then
            dgOrders.CurrentPageIndex = 0
            dgOrders.Visible = True
        Else
            dgOrders.Visible = False
        End If
        BindGrid()


    End Sub

    Private Sub BindGrid()

        ' Determine if we have a current dataview in Session
        If (Session("dvOrders") Is Nothing) Then
            ' if not, use default view
            dvOrders = dsOrders.Orders.DefaultView
        Else
            ' if so, use dataview previously stored in session
            dvOrders = CType(Session("dvOrders"), DataView)
        End If

        ' Bind and display results in datagrid
        Try
            dgOrders.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub

    Protected Sub OrderDateStart_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderDateStart.SelectionChanged

        ' Update the TextBox with the selected date in the Calendar control
        txtStartDate.Text = OrderDateStart.SelectedDate.ToShortDateString

    End Sub

    Private Sub OrderDateEnd_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderDateEnd.SelectionChanged

        ' Update the TextBox with the selected date in the Calendar control
        txtEndDate.Text = OrderDateEnd.SelectedDate.ToShortDateString

    End Sub

    Protected Sub dgOrders_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgOrders.PageIndexChanged

        ' Respond to user paging through datagrid by setting the new page index and re-binding
        dgOrders.CurrentPageIndex = e.NewPageIndex
        BindGrid()

    End Sub

    Private Sub dgOrders_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgOrders.ItemDataBound

        Dim itemType As ListItemType
        Dim intCell As TableCell

        itemType = CType(e.Item.ItemType, ListItemType)

        ' Format the date values from the XML file in a Short Date format to remove the time portion
        If ((itemType = ListItemType.Item) Or (itemType = ListItemType.AlternatingItem)) Then
            intCell = e.Item.Cells(3)
            intCell.Text = Format(intCell.Text, "Short Date")
            intCell = e.Item.Cells(4)
            intCell.Text = Format(intCell.Text, "Short Date")
            intCell = e.Item.Cells(5)
            intCell.Text = Format(intCell.Text, "Short Date")
        End If

    End Sub

    Private Sub dgOrders_EditCommand(ByVal source As Object, _
        ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgOrders.EditCommand

        ' Set the EditItemIndex to enable editing in the row the user clicked on
        dgOrders.EditItemIndex = e.Item.ItemIndex
        BindGrid()

    End Sub

    Private Sub dgOrders_CancelCommand(ByVal source As Object, _
        ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgOrders.CancelCommand

        ' Respond to user canceling the edit of a row by setting EditItemIndex to -1 and re-binding
        dgOrders.EditItemIndex = -1
        BindGrid()

    End Sub

    Private Sub dgOrders_UpdateCommand(ByVal source As Object, _
        ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgOrders.UpdateCommand

        ' For the online version of the sample, disable updates
        Label4.Text = "Updating Has Been Disabled In This Online Sample."
        dgOrders.EditItemIndex = -1
        BindGrid()
        Exit Sub

        ' Retrieve OrderID of row to be updated
        Dim key As Integer = Convert.ToInt32(dgOrders.DataKeys(e.Item.ItemIndex))

        ' Find the row that represents the Order
        Dim r As dsCustOrder.OrdersRow = dsOrders.Orders.FindByOrderID(key)

        ' Update row with changed information in the datagrid
        r.CustomerID = CType(e.Item.Cells(2).Controls(0), TextBox).Text
        r.OrderDate = Convert.ToDateTime(CType(e.Item.Cells(3).Controls(0), TextBox).Text)
        r.ShipName = CType(e.Item.Cells(4).Controls(0), TextBox).Text
        r.ShipAddress = CType(e.Item.Cells(5).Controls(0), TextBox).Text
        r.ShipCity = CType(e.Item.Cells(6).Controls(0), TextBox).Text
        r.ShipRegion = CType(e.Item.Cells(7).Controls(0), TextBox).Text
        r.ShipPostalCode = CType(e.Item.Cells(8).Controls(0), TextBox).Text

        ' Save changes in underlying dataset
        dsOrders.AcceptChanges()

        ' Persist changes made in the datagrid by writing out the results back into the XML data file
        dsOrders.WriteXml(Server.MapPath("CustOrder.xml"))

        ' Exit out of edit mode
        dgOrders.EditItemIndex = -1

        ' Refresh datagrid
        FilterOrders()

    End Sub

End Class
