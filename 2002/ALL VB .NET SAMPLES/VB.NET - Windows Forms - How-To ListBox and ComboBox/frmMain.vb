'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Diagnostics
Imports System.IO

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents lstProcessesAddItem As System.Windows.Forms.ListBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnFill1 As System.Windows.Forms.Button
    Friend WithEvents lblFileName1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblFileName2 As System.Windows.Forms.Label
    Friend WithEvents btnFill2 As System.Windows.Forms.Button
    Friend WithEvents lstProcessesDataSource As System.Windows.Forms.ListBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lblFileInfo As System.Windows.Forms.Label
    Friend WithEvents lstFiles As System.Windows.Forms.ListBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents lstMultiSelect As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSelectionMode As System.Windows.Forms.ComboBox
    Friend WithEvents btnFill3 As System.Windows.Forms.Button
    Friend WithEvents btnFill4 As System.Windows.Forms.Button
    Friend WithEvents lstSelected As System.Windows.Forms.ListBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDropDownStyle As System.Windows.Forms.ComboBox
    Friend WithEvents cboDemo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudDropDownWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnFill5 As System.Windows.Forms.Button
    Friend WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nudDropDownItems As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblResults As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lstSelectedItems As System.Windows.Forms.ListBox
    '<System.Diagnostics.DebuggerStepThrough()> 
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.lstProcessesAddItem = New System.Windows.Forms.ListBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblFileName1 = New System.Windows.Forms.Label()
        Me.btnFill1 = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lblFileInfo = New System.Windows.Forms.Label()
        Me.btnFill3 = New System.Windows.Forms.Button()
        Me.lstFiles = New System.Windows.Forms.ListBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lstSelectedItems = New System.Windows.Forms.ListBox()
        Me.lstSelected = New System.Windows.Forms.ListBox()
        Me.btnFill4 = New System.Windows.Forms.Button()
        Me.cboSelectionMode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstMultiSelect = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblFileName2 = New System.Windows.Forms.Label()
        Me.btnFill2 = New System.Windows.Forms.Button()
        Me.lstProcessesDataSource = New System.Windows.Forms.ListBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.nudDropDownItems = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnFill5 = New System.Windows.Forms.Button()
        Me.nudDropDownWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDropDownStyle = New System.Windows.Forms.ComboBox()
        Me.cboDemo = New System.Windows.Forms.ComboBox()
        Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.nudDropDownItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDropDownWidth, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'lstProcessesAddItem
        '
        Me.lstProcessesAddItem.Location = New System.Drawing.Point(8, 8)
        Me.lstProcessesAddItem.Name = "lstProcessesAddItem"
        Me.lstProcessesAddItem.Size = New System.Drawing.Size(232, 173)
        Me.lstProcessesAddItem.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage3, Me.TabPage4, Me.TabPage2, Me.TabPage5})
        Me.TabControl1.ItemSize = New System.Drawing.Size(59, 18)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(528, 264)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFileName1, Me.btnFill1, Me.lstProcessesAddItem})
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(520, 238)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Add Items"
        '
        'lblFileName1
        '
        Me.lblFileName1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFileName1.Location = New System.Drawing.Point(8, 184)
        Me.lblFileName1.Name = "lblFileName1"
        Me.lblFileName1.Size = New System.Drawing.Size(504, 48)
        Me.lblFileName1.TabIndex = 2
        '
        'btnFill1
        '
        Me.btnFill1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFill1.Location = New System.Drawing.Point(250, 8)
        Me.btnFill1.Name = "btnFill1"
        Me.btnFill1.TabIndex = 1
        Me.btnFill1.Text = "Fill"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFileInfo, Me.btnFill3, Me.lstFiles})
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(520, 238)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Bind to DataTable"
        '
        'lblFileInfo
        '
        Me.lblFileInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFileInfo.Location = New System.Drawing.Point(8, 208)
        Me.lblFileInfo.Name = "lblFileInfo"
        Me.lblFileInfo.Size = New System.Drawing.Size(504, 23)
        Me.lblFileInfo.TabIndex = 8
        '
        'btnFill3
        '
        Me.btnFill3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFill3.Location = New System.Drawing.Point(250, 8)
        Me.btnFill3.Name = "btnFill3"
        Me.btnFill3.TabIndex = 7
        Me.btnFill3.Text = "Fill"
        '
        'lstFiles
        '
        Me.lstFiles.Location = New System.Drawing.Point(8, 8)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.Size = New System.Drawing.Size(232, 186)
        Me.lstFiles.TabIndex = 6
        '
        'TabPage4
        '
        Me.TabPage4.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstSelectedItems, Me.lstSelected, Me.btnFill4, Me.cboSelectionMode, Me.Label1, Me.lstMultiSelect})
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(520, 238)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Selection Mode"
        '
        'lstSelectedItems
        '
        Me.lstSelectedItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSelectedItems.Location = New System.Drawing.Point(320, 64)
        Me.lstSelectedItems.Name = "lstSelectedItems"
        Me.lstSelectedItems.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstSelectedItems.Size = New System.Drawing.Size(192, 106)
        Me.lstSelectedItems.TabIndex = 10
        '
        'lstSelected
        '
        Me.lstSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSelected.Location = New System.Drawing.Point(250, 64)
        Me.lstSelected.Name = "lstSelected"
        Me.lstSelected.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstSelected.Size = New System.Drawing.Size(64, 106)
        Me.lstSelected.TabIndex = 9
        '
        'btnFill4
        '
        Me.btnFill4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFill4.Location = New System.Drawing.Point(250, 8)
        Me.btnFill4.Name = "btnFill4"
        Me.btnFill4.TabIndex = 8
        Me.btnFill4.Text = "Fill"
        '
        'cboSelectionMode
        '
        Me.cboSelectionMode.ItemHeight = 13
        Me.cboSelectionMode.Items.AddRange(New Object() {"One", "MultiSimple", "MultiExtended"})
        Me.cboSelectionMode.Location = New System.Drawing.Point(8, 176)
        Me.cboSelectionMode.Name = "cboSelectionMode"
        Me.cboSelectionMode.Size = New System.Drawing.Size(232, 21)
        Me.cboSelectionMode.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(250, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "You selected:"
        '
        'lstMultiSelect
        '
        Me.lstMultiSelect.Location = New System.Drawing.Point(8, 8)
        Me.lstMultiSelect.Name = "lstMultiSelect"
        Me.lstMultiSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstMultiSelect.Size = New System.Drawing.Size(232, 160)
        Me.lstMultiSelect.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFileName2, Me.btnFill2, Me.lstProcessesDataSource})
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(520, 238)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Bind to Array"
        '
        'lblFileName2
        '
        Me.lblFileName2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFileName2.Location = New System.Drawing.Point(8, 184)
        Me.lblFileName2.Name = "lblFileName2"
        Me.lblFileName2.Size = New System.Drawing.Size(504, 48)
        Me.lblFileName2.TabIndex = 5
        '
        'btnFill2
        '
        Me.btnFill2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFill2.Location = New System.Drawing.Point(250, 8)
        Me.btnFill2.Name = "btnFill2"
        Me.btnFill2.TabIndex = 4
        Me.btnFill2.Text = "Fill"
        '
        'lstProcessesDataSource
        '
        Me.lstProcessesDataSource.Location = New System.Drawing.Point(8, 8)
        Me.lstProcessesDataSource.Name = "lstProcessesDataSource"
        Me.lstProcessesDataSource.Size = New System.Drawing.Size(232, 173)
        Me.lstProcessesDataSource.TabIndex = 3
        '
        'TabPage5
        '
        Me.TabPage5.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.lblResults, Me.nudDropDownItems, Me.Label4, Me.btnFill5, Me.nudDropDownWidth, Me.Label3, Me.Label2, Me.cboDropDownStyle, Me.cboDemo})
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(520, 238)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "ComboBox"
        '
        'Label5
        '
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(256, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Selected Value"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblResults
        '
        Me.lblResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblResults.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblResults.Location = New System.Drawing.Point(384, 136)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.Size = New System.Drawing.Size(48, 23)
        Me.lblResults.TabIndex = 9
        '
        'nudDropDownItems
        '
        Me.nudDropDownItems.Location = New System.Drawing.Point(384, 104)
        Me.nudDropDownItems.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.nudDropDownItems.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nudDropDownItems.Name = "nudDropDownItems"
        Me.nudDropDownItems.Size = New System.Drawing.Size(64, 20)
        Me.nudDropDownItems.TabIndex = 7
        Me.nudDropDownItems.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(256, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "MaxDropDownItems"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnFill5
        '
        Me.btnFill5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFill5.Location = New System.Drawing.Point(250, 8)
        Me.btnFill5.Name = "btnFill5"
        Me.btnFill5.TabIndex = 1
        Me.btnFill5.Text = "Fill"
        '
        'nudDropDownWidth
        '
        Me.nudDropDownWidth.Location = New System.Drawing.Point(384, 72)
        Me.nudDropDownWidth.Maximum = New Decimal(New Integer() {400, 0, 0, 0})
        Me.nudDropDownWidth.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nudDropDownWidth.Name = "nudDropDownWidth"
        Me.nudDropDownWidth.Size = New System.Drawing.Size(64, 20)
        Me.nudDropDownWidth.TabIndex = 5
        Me.nudDropDownWidth.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(256, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "DropDownWidth"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(256, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "DropDownStyle"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboDropDownStyle
        '
        Me.cboDropDownStyle.ItemHeight = 13
        Me.cboDropDownStyle.Location = New System.Drawing.Point(384, 40)
        Me.cboDropDownStyle.Name = "cboDropDownStyle"
        Me.cboDropDownStyle.Size = New System.Drawing.Size(96, 21)
        Me.cboDropDownStyle.TabIndex = 3
        '
        'cboDemo
        '
        Me.cboDemo.DropDownWidth = 200
        Me.cboDemo.ItemHeight = 13
        Me.cboDemo.Location = New System.Drawing.Point(8, 8)
        Me.cboDemo.MaxDropDownItems = 10
        Me.cboDemo.Name = "cboDemo"
        Me.cboDemo.Size = New System.Drawing.Size(200, 21)
        Me.cboDemo.TabIndex = 0
        '
        'SqlDataAdapter1
        '
        Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
        Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Products", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ProductID", "ProductID"), New System.Data.Common.DataColumnMapping("ProductName", "ProductName")})})
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT ProductID, ProductName FROM Products"
        Me.SqlSelectCommand1.Connection = Me.SqlConnection1
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "data source=.;initial catalog=Northwind;persist security info=False;user id=sa;pa" & _
        "cket size=4096"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(546, 275)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        CType(Me.nudDropDownItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDropDownWidth, System.ComponentModel.ISupportInitialize).EndInit()
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

#Region " Form Load "
    ' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
    ' not the focus of the demo. Remove them if you wish to debug the procedures.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' So that we only need to set the title of the application once,
        ' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
        ' to read the AssemblyTitle attribute.
        Dim ainfo As New AssemblyInfo()

        Me.Text = ainfo.Title
        Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

        LoadValues()
    End Sub
#End Region

    Private Sub btnFill1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFill1.Click
        AddItems()
    End Sub

    Private Sub btnFill2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFill2.Click
        BindToArray()
    End Sub

    Private Sub btnFill3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFill3.Click
        ' Bind a ListBox to a DataTable containing information about files. 
        ' This could just as easily come from a real data source (such as SQL Server).
        '  In addition, you can bind a ListBox or ComboBox to many other 
        ' data sources -- see the IList interface in Help.
        Try
            Dim dt As DataTable = FillTable("C:\")

            If Not (dt Is Nothing) Then
                With lstFiles
                    .DisplayMember = "FileName"
                    .ValueMember = "Length"
                    .DataSource = dt
                End With
            End If

        Catch exp As Exception
            MessageBox.Show(exp.Message, Me.Text)
        End Try
    End Sub

    Private Sub btnFill4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFill4.Click
        FillSelectionMode()
    End Sub

    Private Sub btnFill5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFill5.Click
        BindToDataSet()
    End Sub

    Private Sub cboDemo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDemo.SelectedIndexChanged
        lblResults.Text = cboDemo.SelectedValue.ToString
    End Sub

    Private Sub cboDropDownStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDropDownStyle.SelectedIndexChanged
        ' Retrieve the enumerated value from the combo box, 
        ' parsing the text in the combo box.
        cboDemo.DropDownStyle = _
         CType(System.Enum.Parse(GetType(ComboBoxStyle), _
         cboDropDownStyle.Text), ComboBoxStyle)
    End Sub

    Private Sub cboSelectionMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSelectionMode.SelectedIndexChanged
        ' Allow the user to select from one of the selection modes:
        ' One, MultipleSimple, MultipleExtended
        Try
            lstMultiSelect.ClearSelected()
            lstMultiSelect.SelectionMode = _
             CType(System.Enum.Parse(GetType(SelectionMode), cboSelectionMode.Text), _
             SelectionMode)

        Catch exp As Exception
            MessageBox.Show(exp.Message, Me.Text)
        End Try
    End Sub

    Private Sub lstFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFiles.SelectedIndexChanged
        ' Display information about the selected file.
        ' The ValueMember property is set to the Length field in the 
        ' DataTable filling the control.
        lblFileInfo.Text = "Length: " & lstFiles.SelectedValue.ToString
    End Sub

    Private Sub lstMultiSelect_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstMultiSelect.SelectedIndexChanged
        ' Display a list of selected indices.
        ' The SelectedIndices property returns a SelectedIndexCollection
        ' object. Use its CopyTo method to copy the items to 
        ' an array, so you can bind the list to a ListBox control.
        Try
            Dim aIndices(lstMultiSelect.SelectedIndices.Count - 1) As Integer
            lstMultiSelect.SelectedIndices.CopyTo(aIndices, 0)
            lstSelected.DataSource = aIndices

            ' Demonstrate how to "walk" the selected items list.
            With lstSelectedItems
                .Items.Clear()
                ' Begin/EndUpdate turn off/on display of the control
                ' as you're adding items. Just makes the update "cleaner".
                .BeginUpdate()
                Dim fi As FileInfo
                For Each fi In lstMultiSelect.SelectedItems
                    .Items.Add(fi.Name)
                Next
                .EndUpdate()
            End With

        Catch exp As Exception
            lstSelected.DataSource = Nothing
        End Try
    End Sub

    Private Sub lstProcessesAddItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProcessesAddItem.SelectedIndexChanged
        ' Because you haven't set the DataSource property of the control, you can't
        ' retrieve the SelectedValue property. Instead, use the SelectedItem property,'
        ' and display the property you want.
        Try
            lblFileName1.Text = CType(lstProcessesAddItem.SelectedItem, Process).MainModule.FileName
        Catch exp As Exception
            ' In this case, do nothing if an exception occurs.
            lblFileName1.Text = String.Empty
        End Try
    End Sub

    Private Sub lstProcessesDataSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProcessesDataSource.SelectedIndexChanged
        ' Because the ValueMember property was set to MainModule
        ' you can retrieve the SelectedValue property of the 
        ' control. 
        Try
            lblFileName2.Text = CType(lstProcessesDataSource.SelectedValue, ProcessModule).FileName

        Catch exp As Exception
            ' In this case, do nothing if an exception occurs.
            lblFileName2.Text = String.Empty
        End Try
    End Sub

    Private Sub nudDropDownItems_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudDropDownItems.ValueChanged
        cboDemo.MaxDropDownItems = CInt(nudDropDownItems.Value)
    End Sub

    Private Sub nudDropDownWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDropDownWidth.ValueChanged
        cboDemo.DropDownWidth = CInt(nudDropDownWidth.Value)
    End Sub

    Private Sub AddItems()
        ' You can add items individually to a list or combo box.
        ' Because you can add any type of object, it's up to you to determine
        ' which property of the object is to be displayed. Set the 
        ' DisplayMember property to indicate the name of the property to display.
        ' In this case, set the DisplayMember property to display the ProcessName
        ' property.

        ' ValueMember property only works if you specify the DataSource
        ' property of the control.

        Try
            Dim prc As Process
            ' Remove existing items from the control.
            lstProcessesAddItem.Items.Clear()

            ' Fill the control. Indicate which member of 
            ' the items added to the list box should be
            ' displayed.
			lstProcessesAddItem.DisplayMember = "ProcessName"
			For Each prc In Process.GetProcesses()
				lstProcessesAddItem.Items.Add(prc)
			Next
			lstProcessesAddItem.Sorted = True
		Catch exp As Exception
            MessageBox.Show(exp.Message, Me.Text)
        End Try
    End Sub

    Private Sub BindToArray()
        ' Binding to an array is simpler -- just set the 
        ' DataSource property of the control. In this case, you 
        ' can also set the ValueMember property:

        Try
            Dim prc As Process
            With lstProcessesDataSource
                .ValueMember = "MainModule"
                .DisplayMember = "ProcessName"
                .DataSource = Process.GetProcesses()
            End With

        Catch exp As Exception
            MessageBox.Show(exp.Message, Me.Text)
        End Try
    End Sub

    Private Sub BindToDataSet()
        Try
            ' Bind to a DataTable
            Dim ds As New DataSet()

            ' SqlDataAdapter1 gets its data from SQL Server's
            ' Northwind sample database, using the 
            ' Products table.
            SqlDataAdapter1.Fill(ds)


            cboDemo.ValueMember = "ProductID"
            cboDemo.DisplayMember = "ProductName"
            cboDemo.DataSource = ds.Tables(0)

        Catch exp As Exception
            MessageBox.Show(exp.Message, Me.Text)
        End Try
    End Sub

    Private Sub FillSelectionMode()
        Try
            Dim di As New DirectoryInfo("C:\")
            With lstMultiSelect
                .DisplayMember = "Name"
                .ValueMember = "Length"
                .DataSource = di.GetFiles()

                ' Initialize the combo box containing the 
                ' different selection modes:
                cboSelectionMode.Text = .SelectionMode.ToString
            End With

        Catch exp As Exception
            MessageBox.Show(exp.Message, Me.Text)
        End Try
    End Sub

    Private Function FillTable(ByVal Path As String) As DataTable
        ' Build a DataTable filled with information
        ' about files on your hard drive. 

        Dim dt As New DataTable()
        Dim dr As DataRow

        Try
            dt.Columns.Add("FileName", GetType(System.String))
            dt.Columns.Add("Length", GetType(System.Int64))

            ' The DirectoryInfo class comes from the System.IO namespace.
            Dim di As New DirectoryInfo(Path)
            ' Load the DataTable with all files 
            ' that aren't marked with System and/or Hidden attributes,
            ' just to show that you can.
            Dim fi As FileInfo
            For Each fi In di.GetFiles()
                If (fi.Attributes And (FileAttributes.Hidden Or FileAttributes.System)) = 0 Then
                    dr = dt.NewRow()
                    dr("FileName") = fi.Name
                    dr("Length") = fi.Length
                    dt.Rows.Add(dr)
                End If
            Next

        Catch exp As Exception
            MessageBox.Show(exp.Message, Me.Text)
        End Try

        Return dt
    End Function

    Private Sub LoadValues()
        '' Fill cboSelectionMode (on the Selection Mode page)
        '' with a list of available selection modes.
        'cboSelectionMode.DataSource = _
        ' System.Enum.GetNames(GetType(SelectionMode))
        cboDropDownStyle.DataSource = _
         System.Enum.GetNames(GetType(ComboBoxStyle))

        ' Handle properties of cboDemo.
        With nudDropDownWidth
            .Value = cboDemo.DropDownWidth
            .Minimum = cboDemo.Width
            .Maximum = cboDemo.Width * 2
        End With

        nudDropDownItems.Value = cboDemo.MaxDropDownItems
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        ' Make sure the selected items list is cleared when 
        ' you leave the tab -- otherwise, because the SelectionMode
        ' is set to Nothing, things get ugly when you renavigate
        ' back to the same page.
        lstSelected.DataSource = Nothing
    End Sub
End Class