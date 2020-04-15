'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Data.SqlClient

Public Class frmMain
	Inherits System.Windows.Forms.Form

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

    Protected Const CAPTION_TITLE as String = "Bind Data to a ComboBox"
    Protected Const DEFAULT_SORT as String = "ProductName ASC"
    Protected Const CAPTION_ICON_BUTTON as MsgBoxStyle = ctype(msgboxstyle.Information + MsgBoxStyle.OKOnly,msgboxstyle)
    Protected Const PRODUCT_TABLE_NAME As String = "Products"
    
    'define a structure for a sales division which has
    ' a division name and division id.
    protected structure Divisions
        private divName as String
        private divId as Integer
        public sub new(name as String, id as Integer)
            divName=name
            divId = id
        End Sub

        public  readonly property getName() as String
            get
                return divName
            End Get
        end property

        public readonly property getId() as Integer
            get
                return divID
            End Get
        End Property
    End structure

    Friend WithEvents cmdDV As System.Windows.Forms.Button
    Friend WithEvents lblAssociated As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox


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
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmdArray As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdArrayList As System.Windows.Forms.Button
    Friend WithEvents cmdArrayListA As System.Windows.Forms.Button
    Friend WithEvents cmdDS As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSource As System.Windows.Forms.Label
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.cmdArray = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdArrayList = New System.Windows.Forms.Button()
        Me.cmdArrayListA = New System.Windows.Forms.Button()
        Me.cmdDS = New System.Windows.Forms.Button()
        Me.cmdDV = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblAssociated = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblSource = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(32, 40)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(200, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'cmdArray
        '
        Me.cmdArray.Location = New System.Drawing.Point(32, 112)
        Me.cmdArray.Name = "cmdArray"
        Me.cmdArray.Size = New System.Drawing.Size(144, 23)
        Me.cmdArray.TabIndex = 1
        Me.cmdArray.Text = "&Array"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Populate the Combo Box using one of the data sources below. "
        '
        'cmdArrayList
        '
        Me.cmdArrayList.Location = New System.Drawing.Point(32, 136)
        Me.cmdArrayList.Name = "cmdArrayList"
        Me.cmdArrayList.Size = New System.Drawing.Size(144, 23)
        Me.cmdArrayList.TabIndex = 3
        Me.cmdArrayList.Text = "Array&List"
        '
        'cmdArrayListA
        '
        Me.cmdArrayListA.Location = New System.Drawing.Point(32, 160)
        Me.cmdArrayListA.Name = "cmdArrayListA"
        Me.cmdArrayListA.Size = New System.Drawing.Size(144, 23)
        Me.cmdArrayListA.TabIndex = 4
        Me.cmdArrayListA.Text = "A&rrayList - Advanced"
        '
        'cmdDS
        '
        Me.cmdDS.Location = New System.Drawing.Point(32, 184)
        Me.cmdDS.Name = "cmdDS"
        Me.cmdDS.Size = New System.Drawing.Size(144, 23)
        Me.cmdDS.TabIndex = 5
        Me.cmdDS.Text = "&DataSet"
        '
        'cmdDV
        '
        Me.cmdDV.Location = New System.Drawing.Point(32, 208)
        Me.cmdDV.Name = "cmdDV"
        Me.cmdDV.Size = New System.Drawing.Size(144, 23)
        Me.cmdDV.TabIndex = 6
        Me.cmdDV.Text = "Data&View"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblAssociated})
        Me.GroupBox1.Location = New System.Drawing.Point(232, 176)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(128, 48)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Associated Value"
        Me.GroupBox1.Visible = False
        '
        'lblAssociated
        '
        Me.lblAssociated.Location = New System.Drawing.Point(8, 24)
        Me.lblAssociated.Name = "lblAssociated"
        Me.lblAssociated.Size = New System.Drawing.Size(96, 16)
        Me.lblAssociated.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSource})
        Me.GroupBox2.Location = New System.Drawing.Point(232, 112)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(128, 48)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data Source"
        '
        'lblSource
        '
        Me.lblSource.Location = New System.Drawing.Point(8, 24)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(112, 16)
        Me.lblSource.TabIndex = 1
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(410, 251)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.GroupBox1, Me.cmdDV, Me.cmdDS, Me.cmdArrayListA, Me.cmdArrayList, Me.Label1, Me.cmdArray, Me.ComboBox1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
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

   
    Private Sub cmdArray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdArray.Click
       'bind to a simple array of string entries for colors. 
        dim myColors() as String = {"AQUA","BLACK","BLUE","GREEN","RED","WHITE","YELLOW"}
        combobox1.DataSource=myColors

        combobox1.SelectedIndex=0
        groupbox1.Visible=False
        lblSource.Text="Array"

    End Sub

    Private Sub cmdArrayList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdArrayList.Click
        'bind to a simple arraylist which has entries for different shapes
        dim myShapes as new ArrayList
        with myShapes
            .Add("CIRCLE")
            .Add("OCTAGON")
            .Add("RECTANGLE")
            .Add("SQUARE")
            .Add("TRAPEZOID")
            .Add("TRIANGLE")
        End With

        combobox1.DataSource=myShapes

        combobox1.SelectedIndex=0
        groupbox1.Visible=False
        lblSource.Text="ArrayList"
    End Sub

    Private Sub cmdArrayListA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdArrayListA.Click
        'bind to an arraylist that contains entries based on the the structure that
        ' has been defined sales divisions (divisions).
        dim myDivisions as new ArrayList
        
        'add division structure entries to the arraylist
        with myDivisions
            .Add(new divisions("CENTRAL",1))
            .Add(new Divisions("EAST",2))
            .Add(new Divisions("NORTH",3))
            .Add(new Divisions("SOUTH",4))
        end With
        
        'bind the arraylist to the combo box
        With combobox1
            .datasource=myDivisions
            .Displaymember="getName"
            .ValueMember="getId"
        End With
        
        combobox1.SelectedIndex=0
        lblAssociated.Text=ctype(combobox1.SelectedValue,String)
        groupbox1.Visible=True
        lblSource.Text="ArrayList-Advanced"
    End Sub

    Private Sub cmdDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDS.Click
        'bind to the products table from the Northwind database that has 
        '  previously been loaded into the dataset dsProducts.
        ' Note that the table has not been sorted in any particular order.
        With combobox1
            .Datasource=dsproducts.Tables("PRODUCTS")
            .Displaymember="ProductName"
            .ValueMember="ProductID"
        End With

        combobox1.SelectedIndex=0
        lblAssociated.Text=ctype(combobox1.SelectedValue,String)
        groupbox1.Visible=True
        lblSource.Text="DataSet"
    End Sub

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
                    "SELECT * " _
                    & "FROM products", _
                    northwindConnection)

                ' Populate the DataSet with the information from the products
                ' table.  Since a DataSet can hold multiple result sets, it's
                ' a good idea to "name" the result set when you populate the
                ' DataSet.  In this case, the result set is named "Products".
                ProductAdapter.Fill(dsProducts, PRODUCT_TABLE_NAME)

                'create the dataview; use a constructor to specify
                ' the sort, filter criteria for performance purposes
                dvProducts = new dataView(dsProducts.Tables("products"),"",DEFAULT_SORT,DataViewRowState.OriginalRows)
                
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

        groupbox1.Visible=false
    End Sub

    Private Sub cmdDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDV.Click
        
        'bind to the sorted view of the products table
        ' on the product name column, ascending.  

        With combobox1
            .Datasource=dvProducts
            .Displaymember="ProductName"
            .ValueMember="ProductID"
        End With

        combobox1.SelectedIndex=0
        lblAssociated.Text=ctype(combobox1.SelectedValue,String)
        groupbox1.Visible=True
        lblSource.Text="DataView"

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        'display the associated value for the item selected from the combox,
        ' if one is available. To determine a value is available
        ' check the visibility of the groupbox. This attribute has been set to false
        ' during binding by code if a value is not available, to true if it is.

        if groupbox1.Visible= True then
            lblAssociated.Text=ctype(combobox1.SelectedValue,String)
        End If

    End Sub
End Class