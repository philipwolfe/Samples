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

    ' ProductData will hold order information that is returned from 
    ' SQL Server.
    Protected ProductData As New DataSet()

    ' This sample assumes that you have SQL Server installed on your
    ' development machine.  If not, you must have MSDE installed, with
    ' Northwing.  See the ReadMe for details.  Optionally, you can
    ' modify the connection string to point to a different SQL server
    ' by changing the "Server=" below.
    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    Protected Const CONNECTION_ERROR_MSG As String = _
        "To run this sample, you must have SQL " & _
        "or MSDE with the Northwind database installed.  For " & _
        "instructions on installing MSDE, view the ReadMe file."

    Protected didPreviouslyConnect As Boolean = False
    Protected connectionString As String = SQL_CONNECTION_STRING

    ' Used to reference the table containing product information in 
    ' ProductData.
    Protected Const PRODUCT_TABLE_NAME As String = "Products"

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
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents grdProducts As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.grdProducts = New System.Windows.Forms.DataGrid()
        CType(Me.grdProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
        Me.mnuMain.RightToLeft = CType(resources.GetObject("mnuMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'mnuFile
        '
        Me.mnuFile.Enabled = CType(resources.GetObject("mnuFile.Enabled"), Boolean)
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Shortcut = CType(resources.GetObject("mnuFile.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuFile.ShowShortcut = CType(resources.GetObject("mnuFile.ShowShortcut"), Boolean)
        Me.mnuFile.Text = resources.GetString("mnuFile.Text")
        Me.mnuFile.Visible = CType(resources.GetObject("mnuFile.Visible"), Boolean)
        '
        'mnuExit
        '
        Me.mnuExit.Enabled = CType(resources.GetObject("mnuExit.Enabled"), Boolean)
        Me.mnuExit.Index = 0
        Me.mnuExit.Shortcut = CType(resources.GetObject("mnuExit.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuExit.ShowShortcut = CType(resources.GetObject("mnuExit.ShowShortcut"), Boolean)
        Me.mnuExit.Text = resources.GetString("mnuExit.Text")
        Me.mnuExit.Visible = CType(resources.GetObject("mnuExit.Visible"), Boolean)
        '
        'mnuHelp
        '
        Me.mnuHelp.Enabled = CType(resources.GetObject("mnuHelp.Enabled"), Boolean)
        Me.mnuHelp.Index = 1
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Shortcut = CType(resources.GetObject("mnuHelp.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuHelp.ShowShortcut = CType(resources.GetObject("mnuHelp.ShowShortcut"), Boolean)
        Me.mnuHelp.Text = resources.GetString("mnuHelp.Text")
        Me.mnuHelp.Visible = CType(resources.GetObject("mnuHelp.Visible"), Boolean)
        '
        'mnuAbout
        '
        Me.mnuAbout.Enabled = CType(resources.GetObject("mnuAbout.Enabled"), Boolean)
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Shortcut = CType(resources.GetObject("mnuAbout.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuAbout.ShowShortcut = CType(resources.GetObject("mnuAbout.ShowShortcut"), Boolean)
        Me.mnuAbout.Text = resources.GetString("mnuAbout.Text")
        Me.mnuAbout.Visible = CType(resources.GetObject("mnuAbout.Visible"), Boolean)
        '
        'btnFilter
        '
        Me.btnFilter.AccessibleDescription = CType(resources.GetObject("btnFilter.AccessibleDescription"), String)
        Me.btnFilter.AccessibleName = CType(resources.GetObject("btnFilter.AccessibleName"), String)
        Me.btnFilter.Anchor = CType(resources.GetObject("btnFilter.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.BackgroundImage = CType(resources.GetObject("btnFilter.BackgroundImage"), System.Drawing.Image)
        Me.btnFilter.Dock = CType(resources.GetObject("btnFilter.Dock"), System.Windows.Forms.DockStyle)
        Me.btnFilter.Enabled = CType(resources.GetObject("btnFilter.Enabled"), Boolean)
        Me.btnFilter.FlatStyle = CType(resources.GetObject("btnFilter.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnFilter.Font = CType(resources.GetObject("btnFilter.Font"), System.Drawing.Font)
        Me.btnFilter.Image = CType(resources.GetObject("btnFilter.Image"), System.Drawing.Image)
        Me.btnFilter.ImageAlign = CType(resources.GetObject("btnFilter.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnFilter.ImageIndex = CType(resources.GetObject("btnFilter.ImageIndex"), Integer)
        Me.btnFilter.ImeMode = CType(resources.GetObject("btnFilter.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnFilter.Location = CType(resources.GetObject("btnFilter.Location"), System.Drawing.Point)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.RightToLeft = CType(resources.GetObject("btnFilter.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnFilter.Size = CType(resources.GetObject("btnFilter.Size"), System.Drawing.Size)
        Me.btnFilter.TabIndex = CType(resources.GetObject("btnFilter.TabIndex"), Integer)
        Me.btnFilter.Text = resources.GetString("btnFilter.Text")
        Me.btnFilter.TextAlign = CType(resources.GetObject("btnFilter.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnFilter.Visible = CType(resources.GetObject("btnFilter.Visible"), Boolean)
        '
        'txtFilter
        '
        Me.txtFilter.AccessibleDescription = CType(resources.GetObject("txtFilter.AccessibleDescription"), String)
        Me.txtFilter.AccessibleName = CType(resources.GetObject("txtFilter.AccessibleName"), String)
        Me.txtFilter.Anchor = CType(resources.GetObject("txtFilter.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.AutoSize = CType(resources.GetObject("txtFilter.AutoSize"), Boolean)
        Me.txtFilter.BackgroundImage = CType(resources.GetObject("txtFilter.BackgroundImage"), System.Drawing.Image)
        Me.txtFilter.Dock = CType(resources.GetObject("txtFilter.Dock"), System.Windows.Forms.DockStyle)
        Me.txtFilter.Enabled = CType(resources.GetObject("txtFilter.Enabled"), Boolean)
        Me.txtFilter.Font = CType(resources.GetObject("txtFilter.Font"), System.Drawing.Font)
        Me.txtFilter.ImeMode = CType(resources.GetObject("txtFilter.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtFilter.Location = CType(resources.GetObject("txtFilter.Location"), System.Drawing.Point)
        Me.txtFilter.MaxLength = CType(resources.GetObject("txtFilter.MaxLength"), Integer)
        Me.txtFilter.Multiline = CType(resources.GetObject("txtFilter.Multiline"), Boolean)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.PasswordChar = CType(resources.GetObject("txtFilter.PasswordChar"), Char)
        Me.txtFilter.RightToLeft = CType(resources.GetObject("txtFilter.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtFilter.ScrollBars = CType(resources.GetObject("txtFilter.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtFilter.Size = CType(resources.GetObject("txtFilter.Size"), System.Drawing.Size)
        Me.txtFilter.TabIndex = CType(resources.GetObject("txtFilter.TabIndex"), Integer)
        Me.txtFilter.Text = resources.GetString("txtFilter.Text")
        Me.txtFilter.TextAlign = CType(resources.GetObject("txtFilter.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtFilter.Visible = CType(resources.GetObject("txtFilter.Visible"), Boolean)
        Me.txtFilter.WordWrap = CType(resources.GetObject("txtFilter.WordWrap"), Boolean)
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = CType(resources.GetObject("Label1.AccessibleDescription"), String)
        Me.Label1.AccessibleName = CType(resources.GetObject("Label1.AccessibleName"), String)
        Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
        Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
        Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
        Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = CType(resources.GetObject("Label1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label1.ImageIndex = CType(resources.GetObject("Label1.ImageIndex"), Integer)
        Me.Label1.ImeMode = CType(resources.GetObject("Label1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.Point)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = CType(resources.GetObject("Label1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label1.Size = CType(resources.GetObject("Label1.Size"), System.Drawing.Size)
        Me.Label1.TabIndex = CType(resources.GetObject("Label1.TabIndex"), Integer)
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = CType(resources.GetObject("Label1.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label1.Visible = CType(resources.GetObject("Label1.Visible"), Boolean)
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = CType(resources.GetObject("btnLoad.AccessibleDescription"), String)
        Me.btnLoad.AccessibleName = CType(resources.GetObject("btnLoad.AccessibleName"), String)
        Me.btnLoad.Anchor = CType(resources.GetObject("btnLoad.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.BackgroundImage = CType(resources.GetObject("btnLoad.BackgroundImage"), System.Drawing.Image)
        Me.btnLoad.Dock = CType(resources.GetObject("btnLoad.Dock"), System.Windows.Forms.DockStyle)
        Me.btnLoad.Enabled = CType(resources.GetObject("btnLoad.Enabled"), Boolean)
        Me.btnLoad.FlatStyle = CType(resources.GetObject("btnLoad.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnLoad.Font = CType(resources.GetObject("btnLoad.Font"), System.Drawing.Font)
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.ImageAlign = CType(resources.GetObject("btnLoad.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnLoad.ImageIndex = CType(resources.GetObject("btnLoad.ImageIndex"), Integer)
        Me.btnLoad.ImeMode = CType(resources.GetObject("btnLoad.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnLoad.Location = CType(resources.GetObject("btnLoad.Location"), System.Drawing.Point)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.RightToLeft = CType(resources.GetObject("btnLoad.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnLoad.Size = CType(resources.GetObject("btnLoad.Size"), System.Drawing.Size)
        Me.btnLoad.TabIndex = CType(resources.GetObject("btnLoad.TabIndex"), Integer)
        Me.btnLoad.Text = resources.GetString("btnLoad.Text")
        Me.btnLoad.TextAlign = CType(resources.GetObject("btnLoad.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnLoad.Visible = CType(resources.GetObject("btnLoad.Visible"), Boolean)
        '
        'grdProducts
        '
        Me.grdProducts.AccessibleDescription = CType(resources.GetObject("grdProducts.AccessibleDescription"), String)
        Me.grdProducts.AccessibleName = CType(resources.GetObject("grdProducts.AccessibleName"), String)
        Me.grdProducts.Anchor = CType(resources.GetObject("grdProducts.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grdProducts.BackgroundImage = CType(resources.GetObject("grdProducts.BackgroundImage"), System.Drawing.Image)
        Me.grdProducts.CaptionFont = CType(resources.GetObject("grdProducts.CaptionFont"), System.Drawing.Font)
        Me.grdProducts.CaptionText = resources.GetString("grdProducts.CaptionText")
        Me.grdProducts.DataMember = ""
        Me.grdProducts.Dock = CType(resources.GetObject("grdProducts.Dock"), System.Windows.Forms.DockStyle)
        Me.grdProducts.Enabled = CType(resources.GetObject("grdProducts.Enabled"), Boolean)
        Me.grdProducts.Font = CType(resources.GetObject("grdProducts.Font"), System.Drawing.Font)
        Me.grdProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdProducts.ImeMode = CType(resources.GetObject("grdProducts.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grdProducts.Location = CType(resources.GetObject("grdProducts.Location"), System.Drawing.Point)
        Me.grdProducts.Name = "grdProducts"
        Me.grdProducts.RightToLeft = CType(resources.GetObject("grdProducts.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grdProducts.Size = CType(resources.GetObject("grdProducts.Size"), System.Drawing.Size)
        Me.grdProducts.TabIndex = CType(resources.GetObject("grdProducts.TabIndex"), Integer)
        Me.grdProducts.Visible = CType(resources.GetObject("grdProducts.Visible"), Boolean)
        '
        'frmMain
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnFilter, Me.txtFilter, Me.Label1, Me.btnLoad, Me.grdProducts})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.Menu = Me.mnuMain
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmMain"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        CType(Me.grdProducts, System.ComponentModel.ISupportInitialize).EndInit()
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

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Const MESSAGEBOX_CAPTION As String = "Filter"

        ' Sanity check to make sure there's data before attempting to
        ' filter
        Debug.Assert(Not ProductData.Tables(PRODUCT_TABLE_NAME) Is Nothing, _
            "No product data loaded in ProductData.Tables(PRODUCT_TABLE_NAME)")

        With ProductData.Tables(PRODUCT_TABLE_NAME)
            ' Filter the view so that only product names starting with a
            ' specified string are available.
            .DefaultView.RowFilter = "ProductName like '" & txtFilter.Text & "%'"

            ' Are there any matching products?
            If .DefaultView.Count = 0 Then
                MessageBox.Show("No matching rows.", _
                    MESSAGEBOX_CAPTION, _
                    MessageBoxButtons.OK, _
                    MessageBoxIcon.Information)
            End If

            ' By binding the grid to the DataView, the grid will now display
            ' only the matching rows.
            grdProducts.DataSource = .DefaultView
        End With
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click

        Dim frmStatusMessage As New frmStatus()
        If Not didPreviouslyConnect Then
            frmStatusMessage.Show("Connecting to SQL Server")
        End If

        frmStatusMessage.Close()

        Dim isConnecting As Boolean = True
        While isConnecting
            Try

                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in SQL Server, or be part of the Administrators
                ' group for this to work.  You must also have Nortiwind installed
                ' in either SQL Server, or the MSDE sample database.  See the
                ' readme for details.
                Dim northwindConnection As New SqlConnection(connectionString)

                ' The SqlDataAdapter is used to move data between SQL Server, 
                ' and a DataSet.
                Dim ProductAdapter As New SqlDataAdapter( _
                    "select * from products", _
                    northwindConnection)

                ' Clear out any old data that has been previously loaded into
                ' the DataSet
                ProductData.Clear()

                ' Populate the DataSet with the information from the products
                ' table.  Since a DataSet can hold multiple result sets, it's
                ' a good idea to "name" the result set when you populate the
                ' DataSet.  In this case, the result set is named "Products".
                ProductAdapter.Fill(ProductData, PRODUCT_TABLE_NAME)

                ' Bind the DataGrid to the desired table in the DataSet. This
                ' will cause the product information to display.
                grdProducts.DataSource = ProductData.Tables(PRODUCT_TABLE_NAME)

                ' Now that the grid is populated, let the user filter the results.
                btnFilter.Enabled = True
                isConnecting = False

            Catch exc As Exception
                If connectionString = SQL_CONNECTION_STRING Then
                    ' Couldn't connect to SQL Server.  Now try MSDE.
                    connectionString = MSDE_CONNECTION_STRING
                    frmStatusMessage.Show("Connecting to MSDE")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    frmStatusMessage.Close()
                    MessageBox.Show(CONNECTION_ERROR_MSG, _
                        "Connection Failed!", MessageBoxButtons.OK, _
                        MessageBoxIcon.Error)
                    End
                End If
            End Try
        End While
    End Sub

End Class