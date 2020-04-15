'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Data.SqlClient
Imports System.Text

Public Class Main
	Inherits System.Web.UI.Page
    Protected WithEvents lblTitle, lblChecked, lblSelected As Label
    Protected WithEvents cboProducts As DropDownList
    Protected WithEvents txtNewOption As TextBox
    Protected WithEvents btnAbout, btnBindDropDownList, btnShowSelectedItem, btnShowCheckedItems As Button
    Protected WithEvents clstProducts As CheckBoxList
    Protected WithEvents optlDataSource As RadioButtonList

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

    Private arlProducts As ArrayList
    Private dsProducts As DataSet
    Private sdrProducts As SqlDataReader
    Private strConn As String

    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"
    'Swaped the names of Sqlconnectionstring and Msdeconnectionstring to enforce the use of MSDE connection.
    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    ' This routine handles the "About" button click event.
    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        ' Open the About page.
        Response.Redirect("about.aspx")
    End Sub

    ' This routine handles the "Bind DropDownList" button Click event.
    Private Sub btnBindDropDownList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBindDropDownList.Click
        lblSelected.Text = ""

        If optlDataSource.SelectedIndex = 0 Then
            BindDropDowListUsingDataSet()
        Else
            BindDropDowListUsingDataReader()
        End If
    End Sub

    ' This routine handles the "Show Checked Items" button Click event. It displays
    ' a list of all the checked items in the CheckBoxList control.
    Private Sub btnShowChecked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowCheckedItems.Click
        Dim item As ListItem ' Items in the CheckedListBox are of type DataRowView.
        Dim sb As New StringBuilder()

        ' Comparing this to the similar Windows Forms CheckedListBox control, the
        ' term "Selected" is used when the items are actually being checked. With
        ' the CheckedListBox, a distinction is made between "selected" (which means
        ' "highlighted") and "checked". Also, with the WebControl there is no 
        ' Collection or selected or checked items. You have to iterate through all
        ' items in the collection and determine if it is selected.
        For Each item In clstProducts.Items
            If item.Selected Then
                sb.Append(item.Text)
                sb.Append(" (")
                sb.Append(item.Value)
                sb.Append("), ")
            End If
        Next

        lblChecked.Text = sb.ToString
    End Sub

    ' This routine handles the "Show Selected Item" button Click event. It displays
    ' the index, text, and value of the selected item in the DropDownList control.
    Private Sub btnShowSelectedItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowSelectedItem.Click
        With cboProducts
            lblSelected.Text = "You selected option " & .SelectedIndex.ToString & _
                ". Its value is " & .SelectedItem.Value & " and its " & _
                "text is """ & .SelectedItem.Text & """."
        End With
    End Sub

    ' This routine handles the Page's Load event.
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            ' So that we only need to set the title of the application once,
            ' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
            ' to read the AssemblyTitle attribute.
            Dim ainfo As New AssemblyInfo()

            Me.lblTitle.Text = ainfo.Title
            BindDropDowListUsingDataSet()
            BindCheckBoxListUsingDataSet()
        End If
    End Sub

    ' This subroutine is used within a While...End While iteration through the 
    ' contents of a DataReader. It Binds an ArrayList with instances of the custom
    ' Product class, the property values of which are initialized with data
    ' from the DataReader.
    Private Sub AddItemToDataSource(ByRef arl As ArrayList)
        With arl
            ' See further comments in frmMain.vb.
            .Add(New Helper.Product(sdrProducts.GetInt32(0), _
                sdrProducts("ProductName").ToString))
        End With
    End Sub

    ' This routine binds the CheckBoxList to a DataSet. As the code is identical 
    ' to that for the DropDownList, only binding to a DataSet is demonstrated.
    Private Sub BindCheckBoxListUsingDataSet()
        ' See BindDropDownListUsingDataSet for further comments.
        With clstProducts
            .DataTextField = "Name"
            .DataValueField = "ID"

            If Trim(txtNewOption.Text) <> "" Then
                .DataSource = Helper.UI.AddOption(dsProducts, .DataTextField, _
                    .DataValueField, txtNewOption.Text, "0")
            Else
                .DataSource = dsProducts
            End If

            .DataBind()
        End With
    End Sub

    ' This routine binds the DropDownList to an ArrayList filled by iterating 
    ' through a SqlDataReader. See also the comments in the Helper.Product
    ' class.
    Private Sub BindDropDowListUsingDataReader()

        strConn = SQL_CONNECTION_STRING

        Dim strSQL As String = _
            "SELECT ProductID, ProductName " & _
            "FROM Products"

        Dim scnnNorthwind As New SqlConnection(strConn)
        Dim scmd As New SqlCommand(strSQL, scnnNorthwind)
        arlProducts = New ArrayList()

        scnnNorthwind.Open()
        sdrProducts = scmd.ExecuteReader(CommandBehavior.CloseConnection)

        ' Iterate through the DataReader Items collection. The Read method
        ' returns a Boolean value = True while there are more rows to read.
        While sdrProducts.Read
            ' Fill one of the objects that implements the IList interface
            ' (in this case, an ArrayList) so that complex databinding can
            ' be used.
            AddItemToDataSource(arlProducts)
        End While

        With cboProducts
            .DataValueField = "ID"
            .DataTextField = "Name"

            If Trim(txtNewOption.Text) <> "" Then
                .DataSource = Helper.UI.AddOption(arlProducts, _
                        New Helper.Product(0, txtNewOption.Text))
            Else
                .DataSource = arlProducts
            End If

            ' You must explicitly call DataBind() when using WebControls!
            .DataBind()
        End With

        sdrProducts.Close()
    End Sub

    ' This routine binds the DropDownList to a DataSet.
    Private Sub BindDropDowListUsingDataSet()
        strConn = SQL_CONNECTION_STRING
        ' See comments in frmMain.vb concerning the need for the
        ' column aliases.
        Dim strSQL As String = _
            "SELECT ProductID As ID, ProductName As Name " & _
            "FROM Products " & _
            "ORDER BY ProductName"

        ' See other event handlers for comments about the following
        ' lines of code.
        Dim scnnNorthwind As New SqlConnection(strConn)
        Dim scmd As New SqlCommand(strSQL, scnnNorthwind)
        Dim sda As New SqlDataAdapter(scmd)

        dsProducts = New DataSet()

        ' Bind the DataSet.
        sda.Fill(dsProducts)

        ' Bind the data to the DropDowList control.
        With cboProducts
            .DataTextField = "Name"
            .DataValueField = "ID"

            ' Notice that, unlike the ComboBox, you do not have to access the
            ' particular table in the DataSet (unless there was more than one
            ' DataTable).
            If Trim(txtNewOption.Text) <> "" Then
                .DataSource = Helper.UI.AddOption(dsProducts, .DataTextField, _
                    .DataValueField, txtNewOption.Text, "0")
            Else
                .DataSource = dsProducts
            End If
            ' You must explicitly call DataBind() when using WebControls!
            .DataBind()
        End With
    End Sub

End Class
