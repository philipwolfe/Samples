'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI;Connect Timeout=5"

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NETSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI;Connect Timeout=5"

    Private ConnectionString As String = MSDE_CONNECTION_STRING
    Private HasConnected As Boolean = False

    ' Define the typed dataset
    Private tdsNorthwind As Northwind

    ' Define the dataset
    Private dsNorthwind As DataSet

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

		' So that we only need to set the title of the application once,
		' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
		' to read the AssemblyTitle attribute.
		Dim ainfo As New AssemblyInfo()

		Me.Text = ainfo.Title
        Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

        InitDataSets()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents btnInsertTDS As System.Windows.Forms.Button
    Friend WithEvents btnInsertDS As System.Windows.Forms.Button
    Friend WithEvents btnUpdateTDS As System.Windows.Forms.Button
    Friend WithEvents btnUpdateDS As System.Windows.Forms.Button
    Friend WithEvents btnDeleteTDS As System.Windows.Forms.Button
    Friend WithEvents btnDeleteDS As System.Windows.Forms.Button
    Friend WithEvents btnSelectTDS As System.Windows.Forms.Button
    Friend WithEvents btnSelectDS As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpSelect As System.Windows.Forms.TabPage
    Friend WithEvents tpInsert As System.Windows.Forms.TabPage
    Friend WithEvents tpUpdate As System.Windows.Forms.TabPage
    Friend WithEvents tpDelete As System.Windows.Forms.TabPage
    Friend WithEvents lstResults As System.Windows.Forms.ListBox
    Friend WithEvents lstUpdateFromTDS As System.Windows.Forms.Button
    Friend WithEvents lstUpdateFromDS As System.Windows.Forms.Button
    Friend WithEvents btnUpdateDataTDS As System.Windows.Forms.Button
    Friend WithEvents btnUpdateDataDS As System.Windows.Forms.Button
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.btnInsertTDS = New System.Windows.Forms.Button()
        Me.btnInsertDS = New System.Windows.Forms.Button()
        Me.btnUpdateTDS = New System.Windows.Forms.Button()
        Me.btnUpdateDS = New System.Windows.Forms.Button()
        Me.btnDeleteTDS = New System.Windows.Forms.Button()
        Me.btnDeleteDS = New System.Windows.Forms.Button()
        Me.btnSelectTDS = New System.Windows.Forms.Button()
        Me.btnSelectDS = New System.Windows.Forms.Button()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.lstResults = New System.Windows.Forms.ListBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpSelect = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpInsert = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tpUpdate = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tpDelete = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lstUpdateFromTDS = New System.Windows.Forms.Button()
        Me.lstUpdateFromDS = New System.Windows.Forms.Button()
        Me.btnUpdateDataTDS = New System.Windows.Forms.Button()
        Me.btnUpdateDataDS = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tpSelect.SuspendLayout()
        Me.tpInsert.SuspendLayout()
        Me.tpUpdate.SuspendLayout()
        Me.tpDelete.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Text = "&File"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 0
        Me.mnuExit.Text = "E&xit"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 1
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Text = "&Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
        '
        'btnInsertTDS
        '
        Me.btnInsertTDS.AccessibleDescription = "Insert Record into Typed DataSet"
        Me.btnInsertTDS.AccessibleName = "Insert Record into Typed DataSet"
        Me.btnInsertTDS.Location = New System.Drawing.Point(16, 112)
        Me.btnInsertTDS.Name = "btnInsertTDS"
        Me.btnInsertTDS.Size = New System.Drawing.Size(128, 48)
        Me.btnInsertTDS.TabIndex = 38
        Me.btnInsertTDS.Text = "&Insert Record into Typed Dataset"
        '
        'btnInsertDS
        '
        Me.btnInsertDS.AccessibleDescription = "Insert Record into Un-Typed DataSet"
        Me.btnInsertDS.AccessibleName = "Insert Record into Un-Typed DataSet"
        Me.btnInsertDS.Location = New System.Drawing.Point(160, 112)
        Me.btnInsertDS.Name = "btnInsertDS"
        Me.btnInsertDS.Size = New System.Drawing.Size(120, 48)
        Me.btnInsertDS.TabIndex = 39
        Me.btnInsertDS.Text = "Insert Record into &Untyped Dataset"
        '
        'btnUpdateTDS
        '
        Me.btnUpdateTDS.AccessibleDescription = "Update record from typed DataSet"
        Me.btnUpdateTDS.AccessibleName = "Update record from typed DataSet"
        Me.btnUpdateTDS.Location = New System.Drawing.Point(16, 112)
        Me.btnUpdateTDS.Name = "btnUpdateTDS"
        Me.btnUpdateTDS.Size = New System.Drawing.Size(128, 48)
        Me.btnUpdateTDS.TabIndex = 40
        Me.btnUpdateTDS.Text = "&Update Record from Typed Dataset"
        '
        'btnUpdateDS
        '
        Me.btnUpdateDS.AccessibleDescription = "Update record from Untyped DataSet"
        Me.btnUpdateDS.AccessibleName = "Update record from Untyped DataSet"
        Me.btnUpdateDS.Location = New System.Drawing.Point(160, 112)
        Me.btnUpdateDS.Name = "btnUpdateDS"
        Me.btnUpdateDS.Size = New System.Drawing.Size(120, 48)
        Me.btnUpdateDS.TabIndex = 41
        Me.btnUpdateDS.Text = "Update Record from &Untyped Dataset"
        '
        'btnDeleteTDS
        '
        Me.btnDeleteTDS.AccessibleDescription = "Delete Record from Typed DataSet"
        Me.btnDeleteTDS.AccessibleName = "Delete Record from Typed DataSet"
        Me.btnDeleteTDS.Location = New System.Drawing.Point(16, 112)
        Me.btnDeleteTDS.Name = "btnDeleteTDS"
        Me.btnDeleteTDS.Size = New System.Drawing.Size(128, 48)
        Me.btnDeleteTDS.TabIndex = 42
        Me.btnDeleteTDS.Text = "&Delete Record from Typed Dataset"
        '
        'btnDeleteDS
        '
        Me.btnDeleteDS.AccessibleDescription = "Delete record from untyped Dataset"
        Me.btnDeleteDS.AccessibleName = "Delete record from untyped Dataset"
        Me.btnDeleteDS.Location = New System.Drawing.Point(160, 112)
        Me.btnDeleteDS.Name = "btnDeleteDS"
        Me.btnDeleteDS.Size = New System.Drawing.Size(120, 48)
        Me.btnDeleteDS.TabIndex = 43
        Me.btnDeleteDS.Text = "Delete Record from &Untyped Dataset"
        '
        'btnSelectTDS
        '
        Me.btnSelectTDS.AccessibleDescription = "Populate List from Typed DataSet"
        Me.btnSelectTDS.AccessibleName = "Populate List from Typed DataSet"
        Me.btnSelectTDS.Location = New System.Drawing.Point(16, 112)
        Me.btnSelectTDS.Name = "btnSelectTDS"
        Me.btnSelectTDS.Size = New System.Drawing.Size(128, 48)
        Me.btnSelectTDS.TabIndex = 2
        Me.btnSelectTDS.Text = "&Populate List from Typed Dataset"
        '
        'btnSelectDS
        '
        Me.btnSelectDS.AccessibleDescription = "Populate List from Un-Typed DataSet"
        Me.btnSelectDS.AccessibleName = "Populate List from Un-Typed DataSet"
        Me.btnSelectDS.Location = New System.Drawing.Point(160, 112)
        Me.btnSelectDS.Name = "btnSelectDS"
        Me.btnSelectDS.Size = New System.Drawing.Size(120, 48)
        Me.btnSelectDS.TabIndex = 2
        Me.btnSelectDS.Text = "Populate List from &UnTyped Dataset"
        '
        'lblResult
        '
        Me.lblResult.Location = New System.Drawing.Point(16, 216)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(72, 16)
        Me.lblResult.TabIndex = 49
        Me.lblResult.Text = "Results"
        '
        'lstResults
        '
        Me.lstResults.Location = New System.Drawing.Point(16, 232)
        Me.lstResults.Name = "lstResults"
        Me.lstResults.Size = New System.Drawing.Size(304, 147)
        Me.lstResults.TabIndex = 50
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpSelect, Me.tpInsert, Me.tpUpdate, Me.tpDelete})
        Me.TabControl1.Location = New System.Drawing.Point(16, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(304, 200)
        Me.TabControl1.TabIndex = 0
        '
        'tpSelect
        '
        Me.tpSelect.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.btnSelectDS, Me.btnSelectTDS})
        Me.tpSelect.Location = New System.Drawing.Point(4, 22)
        Me.tpSelect.Name = "tpSelect"
        Me.tpSelect.Size = New System.Drawing.Size(296, 174)
        Me.tpSelect.TabIndex = 0
        Me.tpSelect.Text = "Select"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 72)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "At anytime you can get an update on the state of the datasets by clicking the Rep" & _
        "opulate buttons at the bottom.  The buttons on the left side only effect the typ" & _
        "ed dataset and the buttons on the right only effect the Untyped Dataset"
        '
        'tpInsert
        '
        Me.tpInsert.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.btnInsertDS, Me.btnInsertTDS})
        Me.tpInsert.Location = New System.Drawing.Point(4, 22)
        Me.tpInsert.Name = "tpInsert"
        Me.tpInsert.Size = New System.Drawing.Size(296, 174)
        Me.tpInsert.TabIndex = 1
        Me.tpInsert.Text = "Insert"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(264, 72)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "At anytime you can get an update on the state of the datasets by clicking the Rep" & _
        "opulate buttons at the bottom.  The buttons on the left side only effect the typ" & _
        "ed dataset and the buttons on the right only effect the Untyped Dataset"
        '
        'tpUpdate
        '
        Me.tpUpdate.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.btnUpdateTDS, Me.btnUpdateDS})
        Me.tpUpdate.Location = New System.Drawing.Point(4, 22)
        Me.tpUpdate.Name = "tpUpdate"
        Me.tpUpdate.Size = New System.Drawing.Size(296, 174)
        Me.tpUpdate.TabIndex = 2
        Me.tpUpdate.Text = "Update"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(264, 72)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "At anytime you can get an update on the state of the datasets by clicking the Rep" & _
        "opulate buttons at the bottom.  The buttons on the left side only effect the typ" & _
        "ed dataset and the buttons on the right only effect the Untyped Dataset"
        '
        'tpDelete
        '
        Me.tpDelete.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.btnDeleteDS, Me.btnDeleteTDS})
        Me.tpDelete.Location = New System.Drawing.Point(4, 22)
        Me.tpDelete.Name = "tpDelete"
        Me.tpDelete.Size = New System.Drawing.Size(296, 174)
        Me.tpDelete.TabIndex = 3
        Me.tpDelete.Text = "Delete"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(264, 72)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "At anytime you can get an update on the state of the datasets by clicking the Rep" & _
        "opulate buttons at the bottom.  The buttons on the left side only effect the typ" & _
        "ed dataset and the buttons on the right only effect the Untyped Dataset"
        '
        'lstUpdateFromTDS
        '
        Me.lstUpdateFromTDS.AccessibleDescription = "Repopulate List from Typed Data Set"
        Me.lstUpdateFromTDS.AccessibleName = "Repopulate List from Typed Data Set"
        Me.lstUpdateFromTDS.Location = New System.Drawing.Point(16, 384)
        Me.lstUpdateFromTDS.Name = "lstUpdateFromTDS"
        Me.lstUpdateFromTDS.Size = New System.Drawing.Size(128, 40)
        Me.lstUpdateFromTDS.TabIndex = 4
        Me.lstUpdateFromTDS.Text = "&Repopulate list from Typed Dataset"
        '
        'lstUpdateFromDS
        '
        Me.lstUpdateFromDS.AccessibleDescription = "Repopulate List from Un-Typed Data Set"
        Me.lstUpdateFromDS.AccessibleName = "Repopulate List from Un-Typed Data Set"
        Me.lstUpdateFromDS.Location = New System.Drawing.Point(192, 384)
        Me.lstUpdateFromDS.Name = "lstUpdateFromDS"
        Me.lstUpdateFromDS.Size = New System.Drawing.Size(128, 40)
        Me.lstUpdateFromDS.TabIndex = 54
        Me.lstUpdateFromDS.Text = "Repopulate &list from Untyped Dataset"
        '
        'btnUpdateDataTDS
        '
        Me.btnUpdateDataTDS.AccessibleDescription = "Update Datasource from Typed DataSet"
        Me.btnUpdateDataTDS.AccessibleName = "Update Datasource from Typed DataSet"
        Me.btnUpdateDataTDS.Location = New System.Drawing.Point(16, 432)
        Me.btnUpdateDataTDS.Name = "btnUpdateDataTDS"
        Me.btnUpdateDataTDS.Size = New System.Drawing.Size(128, 40)
        Me.btnUpdateDataTDS.TabIndex = 55
        Me.btnUpdateDataTDS.Text = "&Update Datasource from Typed Dataset"
        '
        'btnUpdateDataDS
        '
        Me.btnUpdateDataDS.AccessibleDescription = "Update Datasource from Un-Typed DataSet"
        Me.btnUpdateDataDS.AccessibleName = "Update Datasource from Un-Typed DataSet"
        Me.btnUpdateDataDS.Location = New System.Drawing.Point(192, 432)
        Me.btnUpdateDataDS.Name = "btnUpdateDataDS"
        Me.btnUpdateDataDS.Size = New System.Drawing.Size(128, 40)
        Me.btnUpdateDataDS.TabIndex = 56
        Me.btnUpdateDataDS.Text = "Update Datasource from Untyped Dataset"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(338, 483)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnUpdateDataDS, Me.btnUpdateDataTDS, Me.lstUpdateFromDS, Me.lstUpdateFromTDS, Me.TabControl1, Me.lstResults, Me.lblResult})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        Me.TabControl1.ResumeLayout(False)
        Me.tpSelect.ResumeLayout(False)
        Me.tpInsert.ResumeLayout(False)
        Me.tpUpdate.ResumeLayout(False)
        Me.tpDelete.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Standard Menu Code "
	' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
	' not the focus of the demo. Remove them if you wish to debug the procedures.
	' This code simply shows the About form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
		' Open the About form in Dialog Mode
		Dim frm As New frmAbout()
		frm.ShowDialog(Me)
		frm.Dispose()
	End Sub

	' This code will close the form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
		' Close the current form
		Me.Close()
	End Sub
#End Region

    Private Sub btnDeleteDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDS.Click
        ' Delete the selected row in the products table.
        If lstResults.SelectedIndex >= 0 Then
            dsNorthwind.Tables("ProductsDS").Rows(lstResults.SelectedIndex).Delete()
        Else
            MsgBox("No item selected.", MsgBoxStyle.Information, Me.Text)
        End If
        PopulateListFromDS()
    End Sub

    Private Sub btnDeleteTDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteTDS.Click
        ' Delete the selected row in the products table.
        If lstResults.SelectedIndex >= 0 Then
            tdsNorthwind.ProductsTDS(lstResults.SelectedIndex).Delete()
        Else
            MsgBox("No item selected.", MsgBoxStyle.Information, Me.Text)
        End If
        PopulateListFromTDS()
    End Sub

    Private Sub btnInsertTDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertTDS.Click
        ' Insert a new row into the typed dataset and
        ' populate it with values.
        Dim Row As Northwind.ProductsTDSRow

        Row = tdsNorthwind.ProductsTDS.NewProductsTDSRow()

        Row.ProductName = "Typed Dataset Inserted Record"
        Row.Discontinued = True
        Row.QuantityPerUnit = ""
        Row.UnitPrice = 50
        Row.UnitsInStock = 20
        Row.UnitsOnOrder = 0
        Row.ReorderLevel = 25

        tdsNorthwind.ProductsTDS.AddProductsTDSRow(Row)

        PopulateListFromTDS()
        lstResults.SelectedIndex = lstResults.Items.Count - 1

    End Sub

    Private Sub btnInsertDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertDS.Click
        ' Insert a new row into the untyped dataset and
        ' populate it with values.
        Dim Row As DataRow

        Row = dsNorthwind.Tables("ProductsDS").NewRow()

        Row("ProductName") = "Typed Dataset Inserted Record"
        Row("Discontinued") = True
        Row("QuantityPerUnit") = ""
        Row("UnitPrice") = 50
        Row("UnitsInStock") = 20
        Row("UnitsOnOrder") = 0
        Row("ReorderLevel") = 25

        dsNorthwind.Tables("ProductsDS").Rows.Add(Row)

        PopulateListFromDS()

        lstResults.SelectedIndex = lstResults.Items.Count - 1
    End Sub

    Private Sub btnSelectDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectDS.Click
        PopulateListFromDS()
    End Sub

    Private Sub btnSelectTDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectTDS.Click
        PopulateListFromTDS()
    End Sub

    Private Sub btnUpdateDataDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateDataDS.Click
        ' Update the data source table with any changes that
        ' were made to the untyped dataset.

        Try
            ' Open a connection
            Dim con As New SqlConnection(ConnectionString)
            con.Open()

            'Create the DataAdapter
            Dim daProductsDS As New SqlDataAdapter("Select * from ProductsDS", con)

            Dim oCommandBuilder As New SqlCommandBuilder(daProductsDS)

            daProductsDS.DeleteCommand = oCommandBuilder.GetDeleteCommand
            daProductsDS.InsertCommand = oCommandBuilder.GetInsertCommand
            daProductsDS.UpdateCommand = oCommandBuilder.GetUpdateCommand

            'Apply the updates
            daProductsDS.Update(dsNorthwind, "ProductsDS")
        Catch exp As Exception
            MsgBox(exp.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub btnUpdateDataTDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateDataTDS.Click
        ' Update the data source table with any changes that
        ' were made to the typed dataset.

        Try
            ' Open a connection
            Dim con As New SqlConnection(ConnectionString)
            con.Open()

            'Create the DataAdapter
            Dim daProductsTDS As New SqlDataAdapter("Select * from ProductsTDS", con)

            Dim oCommandBuilder As New SqlCommandBuilder(daProductsTDS)

            daProductsTDS.DeleteCommand = oCommandBuilder.GetDeleteCommand
            daProductsTDS.InsertCommand = oCommandBuilder.GetInsertCommand
            daProductsTDS.UpdateCommand = oCommandBuilder.GetUpdateCommand

            'Apply the updates
            daProductsTDS.Update(tdsNorthwind, "ProductsTDS")
        Catch exp As Exception
            MsgBox(exp.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub btnUpdateDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateDS.Click
        ' Update the selected record in the products table.
        If lstResults.SelectedIndex >= 0 Then
            Dim ProductName As String = CStr(dsNorthwind.Tables("ProductsDS").Rows(lstResults.SelectedIndex)("ProductName"))
            dsNorthwind.Tables("ProductsDS").Rows(lstResults.SelectedIndex)("ProductName") = ProductName & " - Updated"
        Else
            MsgBox("No item selected.", MsgBoxStyle.Information, Me.Text)
        End If

        PopulateListFromDS()
    End Sub

    Private Sub btnUpdateTDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateTDS.Click
        ' Update the first record in the products table.
        If lstResults.SelectedIndex >= 0 Then
            Dim ProductName As String = tdsNorthwind.ProductsTDS(lstResults.SelectedIndex).ProductName
            tdsNorthwind.ProductsTDS(0).ProductName = ProductName & " - Updated"
        Else
            MsgBox("No item selected.", MsgBoxStyle.Information, Me.Text)
        End If
        PopulateListFromTDS()
    End Sub

    Private Sub lstUpdateFromDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUpdateFromDS.Click
        PopulateListFromDS()
    End Sub

    Private Sub lstUpdateFromTDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUpdateFromTDS.Click
        PopulateListFromTDS()
    End Sub

    Private Sub InitDataSets()

        ' Display a status message box saying that we are attempting to connect.
        ' This only needs to be done the first time a connection is attempted.
        ' After we have determined that MSDE or SQL Server is installed, this 
        ' message no longer needs to be displayed
        Dim frmStatusMessage As New frmStatus()
        If Not HasConnected Then
            frmStatusMessage.Show("Connecting to MSDE")
        End If

        ' Attempt to connect to SQL server or MSDE
        Dim IsConnecting As Boolean = True
        While IsConnecting
            Try
                Dim con As New SqlConnection(ConnectionString)
                con.Open()

                ' Connection successful
                IsConnecting = False
                HasConnected = True
                frmStatusMessage.Close()

                ' Since this the first time a conection is made
                ' The table being used for this How-To must be created
                ' Instantiate Command Object to execute SQL Statements
                Dim cmInitSQL As New SqlCommand()

                ' Attach the command to the connection
                cmInitSQL.Connection = con

                ' Set the command type to Text
                cmInitSQL.CommandType = CommandType.Text


                ' Drop ProductsDS table if it exists.
                cmInitSQL.CommandText = "IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ProductsDS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) " & _
                                        "DROP TABLE [dbo].[ProductsDS] "

                ' Execute the statement
                cmInitSQL.ExecuteNonQuery()

                ' Drop ProductsTDS table if it exists.
                cmInitSQL.CommandText = "IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[ProductsTDS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) " & _
                                        "DROP TABLE [dbo].[ProductsTDS] "

                ' Execute the statement
                cmInitSQL.ExecuteNonQuery()

                ' Create ProductsDS Table
                cmInitSQL.CommandText = "CREATE TABLE [dbo].[ProductsDS] ( " & _
                                        "[ProductID] [int] IDENTITY (1, 1) PRIMARY KEY ," & _
                                        "[ProductName] [nvarchar] (40) NOT NULL , " & _
                                        "[SupplierID] [int] NULL , " & _
                                        "[CategoryID] [int] NULL , " & _
                                        "[QuantityPerUnit] [nvarchar] (20) NULL , " & _
                                        "[UnitPrice] [money] NULL , " & _
                                        "[UnitsInStock] [smallint] NULL , " & _
                                        "[UnitsOnOrder] [smallint] NULL , " & _
                                        "[ReorderLevel] [smallint] NULL , " & _
                                        "[Discontinued] [bit] NOT NULL )"

                ' Execute the statement
                cmInitSQL.ExecuteNonQuery()

                ' Create ProductsTDS Table
                cmInitSQL.CommandText = "CREATE TABLE [dbo].[ProductsTDS] ( " & _
                                        "[ProductID] [int] IDENTITY (1, 1) PRIMARY KEY ," & _
                                        "[ProductName] [nvarchar] (40) NOT NULL , " & _
                                        "[SupplierID] [int] NULL , " & _
                                        "[CategoryID] [int] NULL , " & _
                                        "[QuantityPerUnit] [nvarchar] (20) NULL , " & _
                                        "[UnitPrice] [money] NULL , " & _
                                        "[UnitsInStock] [smallint] NULL , " & _
                                        "[UnitsOnOrder] [smallint] NULL , " & _
                                        "[ReorderLevel] [smallint] NULL , " & _
                                        "[Discontinued] [bit] NOT NULL )"

                ' Execute the statement
                cmInitSQL.ExecuteNonQuery()

                ' Insert data into new table from products table in northwind
                cmInitSQL.CommandText = "INSERT INTO ProductsDS " & _
                                        "(ProductName,SupplierID,CategoryID," & _
                                        "QuantityPerUnit,UnitPrice,UnitsInStock," & _
                                        "UnitsOnOrder,ReorderLevel, Discontinued) " & _
                                        "SELECT ProductName,SupplierID,CategoryID," & _
                                        "QuantityPerUnit,UnitPrice,UnitsInStock," & _
                                        "UnitsOnOrder,ReorderLevel, Discontinued FROM Products"

                cmInitSQL.ExecuteNonQuery()

                ' Insert data into new table from products table in northwind
                cmInitSQL.CommandText = "INSERT INTO ProductsTDS " & _
                                        "(ProductName,SupplierID,CategoryID," & _
                                        "QuantityPerUnit,UnitPrice,UnitsInStock," & _
                                        "UnitsOnOrder,ReorderLevel, Discontinued) " & _
                                        "SELECT ProductName,SupplierID,CategoryID," & _
                                        "QuantityPerUnit,UnitPrice,UnitsInStock," & _
                                        "UnitsOnOrder,ReorderLevel, Discontinued FROM Products"

                cmInitSQL.ExecuteNonQuery()
                cmInitSQL.Dispose()

                ' Create command object to pull data for datasets
                Dim cmdProductsDS As New SqlCommand("SELECT * FROM ProductsDS", con)
                Dim cmdProductsTDS As New SqlCommand("SELECT * FROM ProductsTDS", con)

                ' create instances of the dataset and typed dataset
                tdsNorthwind = New Northwind()
                dsNorthwind = New DataSet()

                ' Use the sqldataadapter to fill datasets
                Dim daLocal As SqlDataAdapter = New SqlDataAdapter()

                ' Select command for Typed Dataset
                daLocal.SelectCommand = cmdProductsTDS

                ' Fill typed Dataset
                daLocal.Fill(tdsNorthwind, "ProductsTDS")

                ' Select command for Untyped Dataset
                daLocal.SelectCommand = cmdProductsDS

                ' Fill untyped Dataset
                daLocal.Fill(dsNorthwind, "ProductsDS")

                con.Close()

            Catch e As SqlException
                If ConnectionString = MSDE_CONNECTION_STRING Then
                    ' Couldn't connect to SQL server. Now try MSDE
                    ConnectionString = SQL_CONNECTION_STRING
                    frmStatusMessage.Show("Connecting to SQL Server")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    frmStatusMessage.Close()
                    MsgBox("To run this sample you must have SQL Server ot MSDE with " & _
                           "the Northwind database installed.  For instructions on " & _
                           "installing MSDE, view the Readme file.", MsgBoxStyle.Critical, _
                           "SQL Server/MSDE not found")
                    ' Quit program if neither connection method was successful.
                    End

                End If
            Catch e As Exception
                MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
            End Try
        End While
    End Sub

    Private Sub PopulateListFromDS()
        ' A table in a dataset is used to populate a list box with 
        ' product name from the products table.
        ' With the dataset the name of the table and field must be known
        ' at design time. If they are misspelled or mistyped
        ' an error will be generated only at runtime.

        Dim s As String
        Dim i As Integer

        lstResults.Items.Clear()

        For i = 0 To dsNorthwind.Tables("ProductsDS").Rows.Count - 1
            ' Check to see if row is flagged as deleted.
            If Not dsNorthwind.Tables("ProductsDS").Rows(i).RowState = DataRowState.Deleted Then
                ' Get the product name for each record.
                s = dsNorthwind.Tables("ProductsDS").Rows(i)("ProductName").ToString()
                ' Add product name to the list box
                lstResults.Items.Add(s)
            End If
        Next i
    End Sub

    Private Sub PopulateListFromTDS()
        ' A table in a typed dataset is used to populate a list box with 
        ' product name from the products table.
        ' a typed dataset provides design time verification
        ' of table names and field names before the program
        ' is run.

        Dim s As String
        Dim i As Integer

        lstResults.Items.Clear()

        For i = 0 To tdsNorthwind.ProductsTDS.Count - 1
            ' Check to see if row is flagged as deleted.
            If Not tdsNorthwind.ProductsTDS(i).RowState = DataRowState.Deleted Then
                s = tdsNorthwind.ProductsTDS(i).ProductName.ToString()
                lstResults.Items.Add(s)
            End If
        Next i
    End Sub

End Class