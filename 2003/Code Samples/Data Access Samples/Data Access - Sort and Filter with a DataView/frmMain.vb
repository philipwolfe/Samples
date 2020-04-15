'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.data.SqlClient

Public Class frmMain
	Inherits System.Windows.Forms.Form
    
    Friend WithEvents grdProducts As System.Windows.Forms.DataGrid
    Friend WithEvents rbtUnitsInStockA As System.Windows.Forms.RadioButton
    Friend WithEvents rbtUnitsInStockD As System.Windows.Forms.RadioButton
    Friend WithEvents rbtUnitsOnOrderA As System.Windows.Forms.RadioButton
    Friend WithEvents rbtUnitsOnOrderD As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboProducts As System.Windows.Forms.ComboBox
    Friend WithEvents cboCompare As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUnits As System.Windows.Forms.TextBox
    Friend WithEvents cmdUnitsInStock As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdProductNames As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFilter As System.Windows.Forms.Label
    Friend WithEvents lblSort As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Protected dsProducts as new DataSet

    Protected dvProducts as DataView

    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI" 
        
    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI" 
        
    Protected Const PRODUCT_TABLE_NAME As String = "Products"
    Protected Const STATUS_MESSAGE as String = "Number of records processed: "
    Protected Const CAPTION_MESSAGE_ORIG as String = "Products"
    Protected Const NO_RECORDS_FOUND_MESSAGE as String = "No records were found that match the filter criteria."
    Protected Const CAPTION_TITLE as String = "Sort and Filter with a DataView"
    Protected Const DEFAULT_FILTER as String = "ProductName like '%'"
    Protected Const DEFAULT_SORT as String = "UnitsInStock ASC, UnitsOnOrder ASC"
    Protected Const NO_RECORDS_TO_SORT_MESSAGE as String = "There are no records to sort."
    Protected Const CAPTION_ICON_BUTTON as MsgBoxStyle = ctype(msgboxstyle.Information + MsgBoxStyle.OKOnly,msgboxstyle)

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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRecords As System.Windows.Forms.Label
    Friend WithEvents cmdSort As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.grdProducts = New System.Windows.Forms.DataGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdUnitsInStock = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdProductNames = New System.Windows.Forms.Button()
        Me.txtUnits = New System.Windows.Forms.TextBox()
        Me.cboCompare = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboProducts = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSort = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbtUnitsOnOrderD = New System.Windows.Forms.RadioButton()
        Me.rbtUnitsOnOrderA = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rbtUnitsInStockD = New System.Windows.Forms.RadioButton()
        Me.rbtUnitsInStockA = New System.Windows.Forms.RadioButton()
        Me.lblRecords = New System.Windows.Forms.Label()
        Me.lblSort = New System.Windows.Forms.Label()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.grdProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
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
        'grdProducts
        '
        Me.grdProducts.AllowNavigation = False
        Me.grdProducts.AllowSorting = False
        Me.grdProducts.DataMember = ""
        Me.grdProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdProducts.Location = New System.Drawing.Point(8, 160)
        Me.grdProducts.Name = "grdProducts"
        Me.grdProducts.ReadOnly = True
        Me.grdProducts.Size = New System.Drawing.Size(368, 152)
        Me.grdProducts.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUnitsInStock, Me.Label2, Me.cmdProductNames, Me.txtUnits, Me.cboCompare, Me.Label1, Me.cboProducts})
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(232, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 136)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Available Filters"
        '
        'cmdUnitsInStock
        '
        Me.cmdUnitsInStock.Location = New System.Drawing.Point(248, 88)
        Me.cmdUnitsInStock.Name = "cmdUnitsInStock"
        Me.cmdUnitsInStock.TabIndex = 10
        Me.cmdUnitsInStock.Text = "Fi&lter"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 23)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Product names that begin with:"
        '
        'cmdProductNames
        '
        Me.cmdProductNames.Location = New System.Drawing.Point(248, 40)
        Me.cmdProductNames.Name = "cmdProductNames"
        Me.cmdProductNames.TabIndex = 8
        Me.cmdProductNames.Text = "F&ilter"
        '
        'txtUnits
        '
        Me.txtUnits.Location = New System.Drawing.Point(176, 88)
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.Size = New System.Drawing.Size(64, 20)
        Me.txtUnits.TabIndex = 7
        Me.txtUnits.Text = ""
        '
        'cboCompare
        '
        Me.cboCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompare.Location = New System.Drawing.Point(120, 88)
        Me.cboCompare.Name = "cboCompare"
        Me.cboCompare.Size = New System.Drawing.Size(48, 21)
        Me.cboCompare.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "UnitsInStock"
        '
        'cboProducts
        '
        Me.cboProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducts.Location = New System.Drawing.Point(176, 40)
        Me.cboProducts.Name = "cboProducts"
        Me.cboProducts.Size = New System.Drawing.Size(64, 21)
        Me.cboProducts.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdSort, Me.Label4, Me.Label3, Me.GroupBox3, Me.GroupBox5})
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(224, 136)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sort by UnitsInStock, UnitsOnOrder"
        '
        'cmdSort
        '
        Me.cmdSort.Location = New System.Drawing.Point(8, 112)
        Me.cmdSort.Name = "cmdSort"
        Me.cmdSort.TabIndex = 15
        Me.cmdSort.Text = "&Sort"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(112, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Secondary Key"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Primary Key"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtUnitsOnOrderD, Me.rbtUnitsOnOrderA})
        Me.GroupBox3.Location = New System.Drawing.Point(112, 32)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(104, 72)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "UnitsOnOrder"
        '
        'rbtUnitsOnOrderD
        '
        Me.rbtUnitsOnOrderD.Location = New System.Drawing.Point(8, 48)
        Me.rbtUnitsOnOrderD.Name = "rbtUnitsOnOrderD"
        Me.rbtUnitsOnOrderD.Size = New System.Drawing.Size(88, 16)
        Me.rbtUnitsOnOrderD.TabIndex = 1
        Me.rbtUnitsOnOrderD.Text = "Descending"
        '
        'rbtUnitsOnOrderA
        '
        Me.rbtUnitsOnOrderA.Checked = True
        Me.rbtUnitsOnOrderA.Location = New System.Drawing.Point(8, 24)
        Me.rbtUnitsOnOrderA.Name = "rbtUnitsOnOrderA"
        Me.rbtUnitsOnOrderA.Size = New System.Drawing.Size(88, 16)
        Me.rbtUnitsOnOrderA.TabIndex = 0
        Me.rbtUnitsOnOrderA.TabStop = True
        Me.rbtUnitsOnOrderA.Text = "Ascending"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtUnitsInStockD, Me.rbtUnitsInStockA})
        Me.GroupBox5.Location = New System.Drawing.Point(8, 32)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(104, 72)
        Me.GroupBox5.TabIndex = 11
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "UnitsInStock"
        '
        'rbtUnitsInStockD
        '
        Me.rbtUnitsInStockD.Location = New System.Drawing.Point(8, 48)
        Me.rbtUnitsInStockD.Name = "rbtUnitsInStockD"
        Me.rbtUnitsInStockD.Size = New System.Drawing.Size(88, 16)
        Me.rbtUnitsInStockD.TabIndex = 1
        Me.rbtUnitsInStockD.Text = "Descending"
        '
        'rbtUnitsInStockA
        '
        Me.rbtUnitsInStockA.Checked = True
        Me.rbtUnitsInStockA.Location = New System.Drawing.Point(8, 24)
        Me.rbtUnitsInStockA.Name = "rbtUnitsInStockA"
        Me.rbtUnitsInStockA.Size = New System.Drawing.Size(88, 16)
        Me.rbtUnitsInStockA.TabIndex = 0
        Me.rbtUnitsInStockA.TabStop = True
        Me.rbtUnitsInStockA.Text = "Ascending"
        '
        'lblRecords
        '
        Me.lblRecords.Location = New System.Drawing.Point(376, 280)
        Me.lblRecords.Name = "lblRecords"
        Me.lblRecords.Size = New System.Drawing.Size(216, 16)
        Me.lblRecords.TabIndex = 6
        '
        'lblSort
        '
        Me.lblSort.Location = New System.Drawing.Point(376, 176)
        Me.lblSort.Name = "lblSort"
        Me.lblSort.Size = New System.Drawing.Size(216, 16)
        Me.lblSort.TabIndex = 7
        '
        'lblFilter
        '
        Me.lblFilter.Location = New System.Drawing.Point(376, 232)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(216, 16)
        Me.lblFilter.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(376, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(216, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Current Sort Order"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(376, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(216, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Current Filter"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(602, 315)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.Label5, Me.lblFilter, Me.lblSort, Me.lblRecords, Me.GroupBox2, Me.GroupBox1, Me.grdProducts})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "="
        CType(Me.grdProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
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

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
        Dim strConnection As String = MSDE_CONNECTION_STRING
        
        ' Display a status message saying that we're attempting to connect to SQL Server.
        ' This only needs to be done the very first time a connection is
        ' attempted.  After we've determined that MSDE or SQL Server is
        ' installed, this message no longer needs to be displayed.
        Dim frmStatusMessage As New frmStatus()
        
        frmStatusMessage.Show("Connecting to MSDE")
        
        ' Attempt to connect first to the local SQL server instance, 
        ' if that is not successful try a local
        ' MSDE installation (with the Northwind DB).  
        Dim IsConnecting As Boolean = True
        While IsConnecting

            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in to SQL Server, or be part of the Administrators
                ' group on your local machine for this to work. No password or user id is 
                ' included in this type of string.
                Dim northwindConnection As New SqlConnection(strConnection)

                ' The SqlDataAdapter is used to populate a DataSet 
                Dim ProductAdapter As New SqlDataAdapter( _
                    "SELECT ProductName, UnitPrice, UnitsInStock, UnitsOnOrder " _
                    & "FROM products", _
                    northwindConnection)

                ' Populate the DataSet with the information from the products
                ' table.  Since a DataSet can hold multiple result sets, it's
                ' a good idea to "name" the result set when you populate the
                ' DataSet.  In this case, the result set is named "Products".
                ProductAdapter.Fill(dsProducts, PRODUCT_TABLE_NAME)

                'create the dataview; use a constructor to specify
                ' the sort, filter criteria for performance purposes
                dvProducts = new dataView(dsProducts.Tables("products"),DEFAULT_FILTER,DEFAULT_SORT,DataViewRowState.OriginalRows)

                ' Data has been retrieved successfully  
                ' Signal to break out of the loop by setting isConnecting to false.
                IsConnecting = False
            
            'Handle the situation where a connection attempt has failed
            Catch exc As Exception
                If strConnection = MSDE_CONNECTION_STRING Then
                    ' Couldn't connect to SQL Server.  Now try MSDE.
                    strConnection = SQL_CONNECTION_STRING
                    frmStatusMessage.Show("Connecting to SQL Server")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    frmStatusMessage.Close()
                    MsgBox("To run this sample, you must have SQL " & _
                    "or MSDE with the Northwind database installed.  For " & _
                    "instructions on installing MSDE, view  ReadMe.", _
                     CAPTION_ICON_BUTTON, CAPTION_TITLE)
                    'quit the program; could not connect to either SQL Server 
                    End
                End If
            End Try
        End While

        frmStatusMessage.Close()

        ' Bind the DataGrid to the dataview created above
        grdProducts.DataSource = dvProducts
       
        'Populate the combo box for productName filtering.
        ' Allow a user to select the first letter of products that they wish to view
        cboProducts.Items.AddRange(New Object() {"<ALL>", "A","B", "C", "D", "E","F","G", _
        "H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"})
        cboProducts.Text = "<ALL>"
        
        'Populate the combo box for UnitsInStock filtering
        ' Allow the usual arithmetic comparision operators
        cboCompare.Items.AddRange(new Object() {"<", "<=","=", ">=", ">"})
        cboCompare.Text="<"

        'Display labeling status information 
        lblRecords.Text = STATUS_MESSAGE & dsproducts.Tables(PRODUCT_TABLE_NAME).Rows.Count.ToString
        grdProducts.Captiontext=CAPTION_MESSAGE_ORIG
        lblSort.text = DEFAULT_SORT
        lblFilter.Text = DEFAULT_FILTER
    End Sub
 
    Private Sub cmdProductNames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProductNames.Click
        Dim strFilter as String

        'Process the row filter criteria based on first character of the product name.
        ' if <ALL> was selected, show all rows in the grid, else show only
        ' those rows beginning with the selected letter.
        If cboProducts.Text = "<ALL>" then
            strFilter = "ProductName like '%'"
        Else
            strFilter = "ProductName like '" & cboProducts.text & "%'"
        End If

        dvProducts.RowFilter=strFilter

         'Display the sorted and filtered view in the datagrid
        grdProducts.DataSource=dvProducts
    
        'Display the number of rows in the view
        lblRecords.Text = STATUS_MESSAGE & dvProducts.Count.ToString
        lblFilter.text = strFilter

        'display a msgbox if no records were found that 
        ' match the user criteria
        If dvProducts.Count = 0 then
            msgbox(NO_RECORDS_FOUND_MESSAGE,CAPTION_ICON_BUTTON,CAPTION_TITLE)
        end if
    End Sub

    Private Sub cmdUnitsInStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnitsInStock.Click
        Dim strFilter as String

        'Process the row filter criteria based on the number of UnitsInStock.
        ' Use the number of units entered and arithmetic operator selected 
        ' to filter the dataView

        'Verify the number of units entered
        if txtUnits.Text.Trim.Length = 0 then
            msgbox(NO_RECORDS_FOUND_MESSAGE,CAPTION_ICON_BUTTON,CAPTION_TITLE)
            exit Sub
        elseif not isnumeric(txtUnits.Text.Trim.tostring) then
            msgbox(NO_RECORDS_FOUND_MESSAGE,CAPTION_ICON_BUTTON,CAPTION_TITLE)
            exit sub
        End If

        strFilter = "UnitsInStock " & cboCompare.Text & " " & txtUnits.text

        'Filter by the UnitsInStock
        dvProducts.RowFilter=strFilter

         'Display the filtered/sorted data
        grdProducts.DataSource=dvProducts
    
        'Display the number of rows in the view
        lblRecords.Text = STATUS_MESSAGE & dvProducts.Count.ToString
        lblFilter.text = strFilter

        'display a msgbox if no records were found that 
        ' match the users criteria
        If dvProducts.Count = 0 then
            'create the button and icon as msgstyle for msgbox
            msgbox(NO_RECORDS_FOUND_MESSAGE,CAPTION_ICON_BUTTON,CAPTION_TITLE)
        end if
    End Sub

    Private Sub cmdSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSort.Click
        
        'Apply the Sort criteria to the dataview

        Dim strSort as String

        'Only sort if the dataview currently has records
        If dvProducts.Count = 0 then
            msgbox(NO_RECORDS_TO_SORT_MESSAGE,CAPTION_ICON_BUTTON,CAPTION_TITLE)
            exit sub
        end if

        'Process the sort criteria selected for the view
        ' construct a sort string for the primary, secondary sort keys
        ' The Primary sort key is the UnitsInStock column, the
        ' secondary sort key is UnitsOnOrder column
        If rbtUnitsInStockA.Checked=True then
            strSort = "UnitsInStock ASC"
        Else
            strSort = "UnitsInStock DESC"
        End If

        If rbtUnitsOnOrderA.Checked=True then
            strSort = strSort & ", UnitsOnOrder ASC"
        Else
            strSort = strSort & ", UnitsOnOrder DESC"
        End If

        'Apply the sort criteria to the dataview
        dvProducts.Sort=strSort
      
        'Display the view in the datagrid
        grdProducts.DataSource=dvProducts
    
        lblRecords.Text = STATUS_MESSAGE & dvProducts.Count.ToString
        lblSort.text = strSort
    End Sub
 
End Class