'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.IO

Public Class frmMain
	Inherits System.Windows.Forms.Form

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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bnLoadDataGridComponent As System.Windows.Forms.Button
    Friend WithEvents bnLoadDataGridUserControl As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents bnLoadDataGridForm As System.Windows.Forms.Button
    Friend WithEvents dgCustomersUserControl As CSVDataGrid.DataGridControl
    Friend WithEvents dgCustomersComponent As System.Windows.Forms.DataGrid
    Friend WithEvents dgCustomersForm As System.Windows.Forms.DataGrid
    Friend WithEvents tpForm As System.Windows.Forms.TabPage
    Friend WithEvents tpComponent As System.Windows.Forms.TabPage
    Friend WithEvents tpUserControl As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.dgCustomersUserControl = New CSVDataGrid.DataGridControl()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpForm = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bnLoadDataGridForm = New System.Windows.Forms.Button()
        Me.dgCustomersForm = New System.Windows.Forms.DataGrid()
        Me.tpComponent = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bnLoadDataGridComponent = New System.Windows.Forms.Button()
        Me.dgCustomersComponent = New System.Windows.Forms.DataGrid()
        Me.tpUserControl = New System.Windows.Forms.TabPage()
        Me.bnLoadDataGridUserControl = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tpForm.SuspendLayout()
        CType(Me.dgCustomersForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpComponent.SuspendLayout()
        CType(Me.dgCustomersComponent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpUserControl.SuspendLayout()
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
        'dgCustomersUserControl
        '
        Me.dgCustomersUserControl.AccessibleDescription = "Displays customers"
        Me.dgCustomersUserControl.AccessibleName = "Customers DataGrid"
        Me.dgCustomersUserControl.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dgCustomersUserControl.FileName = Nothing
        Me.dgCustomersUserControl.Location = New System.Drawing.Point(16, 32)
        Me.dgCustomersUserControl.Name = "dgCustomersUserControl"
        Me.dgCustomersUserControl.Size = New System.Drawing.Size(384, 280)
        Me.dgCustomersUserControl.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.AccessibleDescription = "Display sections of App"
        Me.TabControl1.AccessibleName = "Tab Control"
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpForm, Me.tpComponent, Me.tpUserControl})
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(426, 379)
        Me.TabControl1.TabIndex = 1
        '
        'tpForm
        '
        Me.tpForm.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.bnLoadDataGridForm, Me.dgCustomersForm})
        Me.tpForm.Location = New System.Drawing.Point(4, 22)
        Me.tpForm.Name = "tpForm"
        Me.tpForm.Size = New System.Drawing.Size(418, 353)
        Me.tpForm.TabIndex = 2
        Me.tpForm.Text = "Form"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(17, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(384, 24)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Get customers via Form code - populate grid."
        '
        'bnLoadDataGridForm
        '
        Me.bnLoadDataGridForm.AccessibleDescription = "Gets customers and loads DataGrid"
        Me.bnLoadDataGridForm.AccessibleName = "Get Customers"
        Me.bnLoadDataGridForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bnLoadDataGridForm.Location = New System.Drawing.Point(153, 320)
        Me.bnLoadDataGridForm.Name = "bnLoadDataGridForm"
        Me.bnLoadDataGridForm.Size = New System.Drawing.Size(112, 24)
        Me.bnLoadDataGridForm.TabIndex = 4
        Me.bnLoadDataGridForm.Text = "&Get Customers"
        '
        'dgCustomersForm
        '
        Me.dgCustomersForm.AccessibleDescription = "Displays customers"
        Me.dgCustomersForm.AccessibleName = "Customers DataGrid"
        Me.dgCustomersForm.DataMember = ""
        Me.dgCustomersForm.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCustomersForm.Location = New System.Drawing.Point(17, 32)
        Me.dgCustomersForm.Name = "dgCustomersForm"
        Me.dgCustomersForm.ReadOnly = True
        Me.dgCustomersForm.Size = New System.Drawing.Size(384, 280)
        Me.dgCustomersForm.TabIndex = 3
        '
        'tpComponent
        '
        Me.tpComponent.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.bnLoadDataGridComponent, Me.dgCustomersComponent})
        Me.tpComponent.Location = New System.Drawing.Point(4, 22)
        Me.tpComponent.Name = "tpComponent"
        Me.tpComponent.Size = New System.Drawing.Size(418, 353)
        Me.tpComponent.TabIndex = 0
        Me.tpComponent.Text = "Component"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(384, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Get customers via Data Access Component - populate grid."
        '
        'bnLoadDataGridComponent
        '
        Me.bnLoadDataGridComponent.AccessibleDescription = "Gets customers and loads DataGrid"
        Me.bnLoadDataGridComponent.AccessibleName = "Get Customers"
        Me.bnLoadDataGridComponent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bnLoadDataGridComponent.Location = New System.Drawing.Point(152, 320)
        Me.bnLoadDataGridComponent.Name = "bnLoadDataGridComponent"
        Me.bnLoadDataGridComponent.Size = New System.Drawing.Size(112, 24)
        Me.bnLoadDataGridComponent.TabIndex = 1
        Me.bnLoadDataGridComponent.Text = "&Get Customers"
        '
        'dgCustomersComponent
        '
        Me.dgCustomersComponent.AccessibleDescription = "Displays customers"
        Me.dgCustomersComponent.AccessibleName = "Customers DataGrid"
        Me.dgCustomersComponent.DataMember = ""
        Me.dgCustomersComponent.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCustomersComponent.Location = New System.Drawing.Point(16, 32)
        Me.dgCustomersComponent.Name = "dgCustomersComponent"
        Me.dgCustomersComponent.ReadOnly = True
        Me.dgCustomersComponent.Size = New System.Drawing.Size(384, 280)
        Me.dgCustomersComponent.TabIndex = 0
        '
        'tpUserControl
        '
        Me.tpUserControl.Controls.AddRange(New System.Windows.Forms.Control() {Me.bnLoadDataGridUserControl, Me.Label2, Me.dgCustomersUserControl})
        Me.tpUserControl.Location = New System.Drawing.Point(4, 22)
        Me.tpUserControl.Name = "tpUserControl"
        Me.tpUserControl.Size = New System.Drawing.Size(418, 353)
        Me.tpUserControl.TabIndex = 1
        Me.tpUserControl.Text = "User Control"
        '
        'bnLoadDataGridUserControl
        '
        Me.bnLoadDataGridUserControl.AccessibleDescription = "Gets customers and loads DataGrid"
        Me.bnLoadDataGridUserControl.AccessibleName = "Get Customers"
        Me.bnLoadDataGridUserControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bnLoadDataGridUserControl.Location = New System.Drawing.Point(152, 320)
        Me.bnLoadDataGridUserControl.Name = "bnLoadDataGridUserControl"
        Me.bnLoadDataGridUserControl.Size = New System.Drawing.Size(112, 24)
        Me.bnLoadDataGridUserControl.TabIndex = 4
        Me.bnLoadDataGridUserControl.Text = "&Get Customers"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(16, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(384, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Get customers via User Control - populates grid."
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(426, 379)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        Me.TabControl1.ResumeLayout(False)
        Me.tpForm.ResumeLayout(False)
        CType(Me.dgCustomersForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpComponent.ResumeLayout(False)
        CType(Me.dgCustomersComponent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpUserControl.ResumeLayout(False)
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

    Protected strCustomersFile As String = "../Customers.csv"

    Private Sub bnLoadDataGridComponent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnLoadDataGridComponent.Click
        ' Access the DataAccessComponent directly,
        ' populate the DataGrid with the results.
        ' Gives flexibility, while hiding the details
        ' of accessing the file.
        Dim dtCustomers As DataTable

        ' Instantiate the data access object
        Dim oBusiness As DataAccessComponent.Business = New DataAccessComponent.Business()

        ' Pass the filename to open
        oBusiness.FileName = strCustomersFile

        ' Get a DataTable containing the customers
        ' in the file
        dtCustomers = oBusiness.GetCustomers()

        ' Display results
        dgCustomersComponent.SetDataBinding(dtCustomers, "")
    End Sub

    Private Sub bnLoadDataGridForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnLoadDataGridForm.Click
        ' Access the customers file directly,
        ' populate the DataGrid with the results.
        ' Easy to see what's going on because all choices are made
        ' here, however not re-usable and the developer
        ' must know all of the details.  Contrast with 
        ' code that accesses the component.

        Dim objStreamReader As StreamReader = New StreamReader(strCustomersFile)
        Dim strLine As String
        Dim strColumns() As String

        Dim dtCustomers As New DataTable()
        Dim drCustomer As DataRow

        ' Define the schema of the table,
        ' used to define new rows.
        dtCustomers.Columns.Add("CustomerID")
        dtCustomers.Columns.Add("CompanyName")
        dtCustomers.Columns.Add("ContactName")
        dtCustomers.Columns.Add("Phone")

        ' Extract line from file
        strLine = objStreamReader.ReadLine

        ' Enter loop is data is found
        Do While (Not strLine Is Nothing)
            ' Create a DataRow to hold line
            drCustomer = dtCustomers.NewRow

            ' Create an array of columns separated by commas
            strColumns = Split(strLine, ",")

            ' Quickly fill row with column values
            drCustomer.ItemArray = strColumns

            ' Append row to DataTable
            dtCustomers.Rows.Add(drCustomer)

            'Extract another line
            strLine = objStreamReader.ReadLine
        Loop

        ' Display results
        dgCustomersForm.SetDataBinding(dtCustomers, "")
    End Sub

    Private Sub bnLoadUserControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnLoadDataGridUserControl.Click
        ' Allow the User Control to do all of the work
        ' Not flexible since the results will be accessed and
        ' displayed this DataGrid, however very re-usable and 
        ' very easy for the developer to use.  Contrast with the
        ' component access code.

        ' Pass in the filename to access
        dgCustomersUserControl.FileName = strCustomersFile

        'Display results
        dgCustomersUserControl.BindCustomers()
    End Sub

End Class