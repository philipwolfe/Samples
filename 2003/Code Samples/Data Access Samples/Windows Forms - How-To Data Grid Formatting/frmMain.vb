'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Data.SqlClient

Public Class frmMain
    Inherits Form

    ' ProductData will hold order information that is returned from 
    ' SQL Server.
    Protected ProductData As New DataSet()

    ' Used to reference the table containing product information in 
    ' ProductData.
    Protected Const PRODUCT_TABLE_NAME As String = "Products"

    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    'Default values we need to save
    Protected DefaultGridBorderStyle As BorderStyle

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


        'Get the default information for resetting the style later
        DefaultGridBorderStyle = grdProducts.BorderStyle

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
    Friend WithEvents mnuMain As MainMenu
    Friend WithEvents mnuFile As MenuItem
    Friend WithEvents mnuExit As MenuItem
    Friend WithEvents mnuHelp As MenuItem
    Friend WithEvents mnuAbout As MenuItem
    Friend WithEvents grdProducts As DataGrid
    Friend WithEvents btnDefaultFormatting As System.Windows.Forms.Button
    Friend WithEvents btnGridProperties As System.Windows.Forms.Button
    Friend WithEvents btnTableStyle As System.Windows.Forms.Button
    Friend WithEvents lblInstruction As System.Windows.Forms.Label
    Friend WithEvents btnColumnStyles As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.btnDefaultFormatting = New System.Windows.Forms.Button()
        Me.grdProducts = New System.Windows.Forms.DataGrid()
        Me.btnGridProperties = New System.Windows.Forms.Button()
        Me.btnTableStyle = New System.Windows.Forms.Button()
        Me.btnColumnStyles = New System.Windows.Forms.Button()
        Me.lblInstruction = New System.Windows.Forms.Label()
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
        'btnDefaultFormatting
        '
        Me.btnDefaultFormatting.AccessibleDescription = resources.GetString("btnDefaultFormatting.AccessibleDescription")
        Me.btnDefaultFormatting.AccessibleName = resources.GetString("btnDefaultFormatting.AccessibleName")
        Me.btnDefaultFormatting.Anchor = CType(resources.GetObject("btnDefaultFormatting.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnDefaultFormatting.BackgroundImage = CType(resources.GetObject("btnDefaultFormatting.BackgroundImage"), System.Drawing.Image)
        Me.btnDefaultFormatting.Dock = CType(resources.GetObject("btnDefaultFormatting.Dock"), System.Windows.Forms.DockStyle)
        Me.btnDefaultFormatting.Enabled = CType(resources.GetObject("btnDefaultFormatting.Enabled"), Boolean)
        Me.btnDefaultFormatting.FlatStyle = CType(resources.GetObject("btnDefaultFormatting.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnDefaultFormatting.Font = CType(resources.GetObject("btnDefaultFormatting.Font"), System.Drawing.Font)
        Me.btnDefaultFormatting.Image = CType(resources.GetObject("btnDefaultFormatting.Image"), System.Drawing.Image)
        Me.btnDefaultFormatting.ImageAlign = CType(resources.GetObject("btnDefaultFormatting.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnDefaultFormatting.ImageIndex = CType(resources.GetObject("btnDefaultFormatting.ImageIndex"), Integer)
        Me.btnDefaultFormatting.ImeMode = CType(resources.GetObject("btnDefaultFormatting.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnDefaultFormatting.Location = CType(resources.GetObject("btnDefaultFormatting.Location"), System.Drawing.Point)
        Me.btnDefaultFormatting.Name = "btnDefaultFormatting"
        Me.btnDefaultFormatting.RightToLeft = CType(resources.GetObject("btnDefaultFormatting.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnDefaultFormatting.Size = CType(resources.GetObject("btnDefaultFormatting.Size"), System.Drawing.Size)
        Me.btnDefaultFormatting.TabIndex = CType(resources.GetObject("btnDefaultFormatting.TabIndex"), Integer)
        Me.btnDefaultFormatting.Text = resources.GetString("btnDefaultFormatting.Text")
        Me.btnDefaultFormatting.TextAlign = CType(resources.GetObject("btnDefaultFormatting.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnDefaultFormatting.Visible = CType(resources.GetObject("btnDefaultFormatting.Visible"), Boolean)
        '
        'grdProducts
        '
        Me.grdProducts.AccessibleDescription = resources.GetString("grdProducts.AccessibleDescription")
        Me.grdProducts.AccessibleName = resources.GetString("grdProducts.AccessibleName")
        Me.grdProducts.Anchor = CType(resources.GetObject("grdProducts.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grdProducts.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText
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
        'btnGridProperties
        '
        Me.btnGridProperties.AccessibleDescription = resources.GetString("btnGridProperties.AccessibleDescription")
        Me.btnGridProperties.AccessibleName = resources.GetString("btnGridProperties.AccessibleName")
        Me.btnGridProperties.Anchor = CType(resources.GetObject("btnGridProperties.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnGridProperties.BackgroundImage = CType(resources.GetObject("btnGridProperties.BackgroundImage"), System.Drawing.Image)
        Me.btnGridProperties.Dock = CType(resources.GetObject("btnGridProperties.Dock"), System.Windows.Forms.DockStyle)
        Me.btnGridProperties.Enabled = CType(resources.GetObject("btnGridProperties.Enabled"), Boolean)
        Me.btnGridProperties.FlatStyle = CType(resources.GetObject("btnGridProperties.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnGridProperties.Font = CType(resources.GetObject("btnGridProperties.Font"), System.Drawing.Font)
        Me.btnGridProperties.Image = CType(resources.GetObject("btnGridProperties.Image"), System.Drawing.Image)
        Me.btnGridProperties.ImageAlign = CType(resources.GetObject("btnGridProperties.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnGridProperties.ImageIndex = CType(resources.GetObject("btnGridProperties.ImageIndex"), Integer)
        Me.btnGridProperties.ImeMode = CType(resources.GetObject("btnGridProperties.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnGridProperties.Location = CType(resources.GetObject("btnGridProperties.Location"), System.Drawing.Point)
        Me.btnGridProperties.Name = "btnGridProperties"
        Me.btnGridProperties.RightToLeft = CType(resources.GetObject("btnGridProperties.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnGridProperties.Size = CType(resources.GetObject("btnGridProperties.Size"), System.Drawing.Size)
        Me.btnGridProperties.TabIndex = CType(resources.GetObject("btnGridProperties.TabIndex"), Integer)
        Me.btnGridProperties.Text = resources.GetString("btnGridProperties.Text")
        Me.btnGridProperties.TextAlign = CType(resources.GetObject("btnGridProperties.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnGridProperties.Visible = CType(resources.GetObject("btnGridProperties.Visible"), Boolean)
        '
        'btnTableStyle
        '
        Me.btnTableStyle.AccessibleDescription = resources.GetString("btnTableStyle.AccessibleDescription")
        Me.btnTableStyle.AccessibleName = resources.GetString("btnTableStyle.AccessibleName")
        Me.btnTableStyle.Anchor = CType(resources.GetObject("btnTableStyle.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnTableStyle.BackgroundImage = CType(resources.GetObject("btnTableStyle.BackgroundImage"), System.Drawing.Image)
        Me.btnTableStyle.Dock = CType(resources.GetObject("btnTableStyle.Dock"), System.Windows.Forms.DockStyle)
        Me.btnTableStyle.Enabled = CType(resources.GetObject("btnTableStyle.Enabled"), Boolean)
        Me.btnTableStyle.FlatStyle = CType(resources.GetObject("btnTableStyle.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnTableStyle.Font = CType(resources.GetObject("btnTableStyle.Font"), System.Drawing.Font)
        Me.btnTableStyle.Image = CType(resources.GetObject("btnTableStyle.Image"), System.Drawing.Image)
        Me.btnTableStyle.ImageAlign = CType(resources.GetObject("btnTableStyle.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnTableStyle.ImageIndex = CType(resources.GetObject("btnTableStyle.ImageIndex"), Integer)
        Me.btnTableStyle.ImeMode = CType(resources.GetObject("btnTableStyle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnTableStyle.Location = CType(resources.GetObject("btnTableStyle.Location"), System.Drawing.Point)
        Me.btnTableStyle.Name = "btnTableStyle"
        Me.btnTableStyle.RightToLeft = CType(resources.GetObject("btnTableStyle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnTableStyle.Size = CType(resources.GetObject("btnTableStyle.Size"), System.Drawing.Size)
        Me.btnTableStyle.TabIndex = CType(resources.GetObject("btnTableStyle.TabIndex"), Integer)
        Me.btnTableStyle.Text = resources.GetString("btnTableStyle.Text")
        Me.btnTableStyle.TextAlign = CType(resources.GetObject("btnTableStyle.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnTableStyle.Visible = CType(resources.GetObject("btnTableStyle.Visible"), Boolean)
        '
        'btnColumnStyles
        '
        Me.btnColumnStyles.AccessibleDescription = resources.GetString("btnColumnStyles.AccessibleDescription")
        Me.btnColumnStyles.AccessibleName = resources.GetString("btnColumnStyles.AccessibleName")
        Me.btnColumnStyles.Anchor = CType(resources.GetObject("btnColumnStyles.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnColumnStyles.BackgroundImage = CType(resources.GetObject("btnColumnStyles.BackgroundImage"), System.Drawing.Image)
        Me.btnColumnStyles.Dock = CType(resources.GetObject("btnColumnStyles.Dock"), System.Windows.Forms.DockStyle)
        Me.btnColumnStyles.Enabled = CType(resources.GetObject("btnColumnStyles.Enabled"), Boolean)
        Me.btnColumnStyles.FlatStyle = CType(resources.GetObject("btnColumnStyles.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnColumnStyles.Font = CType(resources.GetObject("btnColumnStyles.Font"), System.Drawing.Font)
        Me.btnColumnStyles.Image = CType(resources.GetObject("btnColumnStyles.Image"), System.Drawing.Image)
        Me.btnColumnStyles.ImageAlign = CType(resources.GetObject("btnColumnStyles.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnColumnStyles.ImageIndex = CType(resources.GetObject("btnColumnStyles.ImageIndex"), Integer)
        Me.btnColumnStyles.ImeMode = CType(resources.GetObject("btnColumnStyles.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnColumnStyles.Location = CType(resources.GetObject("btnColumnStyles.Location"), System.Drawing.Point)
        Me.btnColumnStyles.Name = "btnColumnStyles"
        Me.btnColumnStyles.RightToLeft = CType(resources.GetObject("btnColumnStyles.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnColumnStyles.Size = CType(resources.GetObject("btnColumnStyles.Size"), System.Drawing.Size)
        Me.btnColumnStyles.TabIndex = CType(resources.GetObject("btnColumnStyles.TabIndex"), Integer)
        Me.btnColumnStyles.Text = resources.GetString("btnColumnStyles.Text")
        Me.btnColumnStyles.TextAlign = CType(resources.GetObject("btnColumnStyles.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnColumnStyles.Visible = CType(resources.GetObject("btnColumnStyles.Visible"), Boolean)
        '
        'lblInstruction
        '
        Me.lblInstruction.AccessibleDescription = CType(resources.GetObject("lblInstruction.AccessibleDescription"), String)
        Me.lblInstruction.AccessibleName = CType(resources.GetObject("lblInstruction.AccessibleName"), String)
        Me.lblInstruction.Anchor = CType(resources.GetObject("lblInstruction.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblInstruction.AutoSize = CType(resources.GetObject("lblInstruction.AutoSize"), Boolean)
        Me.lblInstruction.Dock = CType(resources.GetObject("lblInstruction.Dock"), System.Windows.Forms.DockStyle)
        Me.lblInstruction.Enabled = CType(resources.GetObject("lblInstruction.Enabled"), Boolean)
        Me.lblInstruction.Font = CType(resources.GetObject("lblInstruction.Font"), System.Drawing.Font)
        Me.lblInstruction.Image = CType(resources.GetObject("lblInstruction.Image"), System.Drawing.Image)
        Me.lblInstruction.ImageAlign = CType(resources.GetObject("lblInstruction.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblInstruction.ImageIndex = CType(resources.GetObject("lblInstruction.ImageIndex"), Integer)
        Me.lblInstruction.ImeMode = CType(resources.GetObject("lblInstruction.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblInstruction.Location = CType(resources.GetObject("lblInstruction.Location"), System.Drawing.Point)
        Me.lblInstruction.Name = "lblInstruction"
        Me.lblInstruction.RightToLeft = CType(resources.GetObject("lblInstruction.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblInstruction.Size = CType(resources.GetObject("lblInstruction.Size"), System.Drawing.Size)
        Me.lblInstruction.TabIndex = CType(resources.GetObject("lblInstruction.TabIndex"), Integer)
        Me.lblInstruction.Text = resources.GetString("lblInstruction.Text")
        Me.lblInstruction.TextAlign = CType(resources.GetObject("lblInstruction.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblInstruction.Visible = CType(resources.GetObject("lblInstruction.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInstruction, Me.btnColumnStyles, Me.btnTableStyle, Me.btnGridProperties, Me.btnDefaultFormatting, Me.grdProducts})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
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

    Private Sub BindDataGrid()

        Static ConnectionString As String = MSDE_CONNECTION_STRING
        Static DidPreviouslyConnect As Boolean = False

        ' Display a status message saying that we're attempting to connect.
        ' This only needs to be done the very first time a connection is
        ' attempted.  After we've determined that MSDE or SQL Server is
        ' installed, this message no longer needs to be displayed.
        Dim frmStatusMessage As New frmStatus()
        If Not DidPreviouslyConnect Then
            frmStatusMessage.Show("Connecting to MSDE")
        End If

        ' Attempt to connect to the local SQL server instance, and a local
        ' MSDE installation (with Northwind).  
        Dim IsConnecting As Boolean = True
        While IsConnecting

            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in SQL Server, or be part of the Administrators
                ' group for this to work.
                Dim northwindConnection As New SqlConnection(ConnectionString)

                ' The SqlDataAdapter is used to move data between SQL Server, 
                ' and a DataSet.
                Dim ProductAdapter As New SqlDataAdapter( _
                    "SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM products", _
                    northwindConnection)

                ' Populate the DataSet with the information from the products
                ' table.  Since a DataSet can hold multiple result sets, it's
                ' a good idea to "name" the result set when you populate the
                ' DataSet.  In this case, the result set is named "Products".
                ProductAdapter.Fill(ProductData, PRODUCT_TABLE_NAME)

                ' Data has been successfully retrieved, so break out of the loop.
                IsConnecting = False
                DidPreviouslyConnect = True

            Catch exc As Exception
                If ConnectionString = MSDE_CONNECTION_STRING Then
                    ' Couldn't connect to SQL Server.  Now try MSDE.
                    ConnectionString = SQL_CONNECTION_STRING
                    frmStatusMessage.Show("Connecting to SQL Server")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    frmStatusMessage.Close()
                    MessageBox.Show("To run this sample, you must have SQL " & _
                        "or MSDE with the Northwind database installed.  For " & _
                        "instructions on installing MSDE, view the ReadMe file.")
                    End
                End If
            End Try
        End While

        frmStatusMessage.Close()

        ' Bind the DataGrid to the desired table in the DataSet. This
        ' will cause the product information to display.
        grdProducts.DataSource = ProductData.Tables(PRODUCT_TABLE_NAME)
    End Sub

    Private Sub FormatGridWithBothTableAndColumnStyles()
        ' Continue to set DataGrid properties directly, but only
        ' those that are not covered by DataGridTableStyle properties.
        With grdProducts
            .BackColor = Color.GhostWhite
            .BackgroundColor = Color.Lavender
            .BorderStyle = BorderStyle.None
            .CaptionBackColor = Color.RoyalBlue
            .CaptionFont = New Font("Tahoma", 10.0!, FontStyle.Bold)
            .CaptionForeColor = Color.Bisque
            .CaptionText = "Northwind Products"
            .Font = New Font("Tahoma", 8.0!)
            .ParentRowsBackColor = Color.Lavender
            .ParentRowsForeColor = Color.MidnightBlue
        End With

        ' Put as much of the formatting as possible here.
        Dim grdTableStyle1 As New DataGridTableStyle()
        With grdTableStyle1
            .AlternatingBackColor = Color.GhostWhite
            .BackColor = Color.GhostWhite
            .ForeColor = Color.MidnightBlue
            .GridLineColor = Color.RoyalBlue
            .HeaderBackColor = Color.MidnightBlue
            .HeaderFont = New Font("Tahoma", 8.0!, FontStyle.Bold)
            .HeaderForeColor = Color.Lavender
            .SelectionBackColor = Color.Teal
            .SelectionForeColor = Color.PaleGreen
            ' Do not forget to set the MappingName property. 
            ' Without this, the DataGridTableStyle properties
            ' and any associated DataGridColumnStyle objects
            ' will have no effect.
            .MappingName = PRODUCT_TABLE_NAME
            .PreferredColumnWidth = 125
            .PreferredRowHeight = 15
        End With

        ' Format each column that you want to appear in the DataGrid.
        ' In most cases, the DataGridTextBoxColumn class is appropriate.
        ' However, you can also use the DataGridBoolColumn class. Both
        ' of these extend the MustInherit DataGridColumnStyle class. Notice
        ' that the column style properties available to you are more limited
        ' than those for the table style. For example, you cannot change
        ' the color of an individual column.
        Dim grdColStyle1 As New DataGridTextBoxColumn()
        With grdColStyle1
            .HeaderText = "ID"
            .MappingName = "ProductID"
            .Width = 50
        End With

        Dim grdColStyle2 As New DataGridTextBoxColumn()
        With grdColStyle2
            .HeaderText = "Name"
            .MappingName = "ProductName"
        End With

        Dim grdColStyle3 As New DataGridTextBoxColumn()
        With grdColStyle3
            .HeaderText = "Price"
            .MappingName = "UnitPrice"
            .Width = 75
            .ReadOnly = True
        End With

        Dim grdColStyle4 As New DataGridTextBoxColumn()
        With grdColStyle4
            .HeaderText = "# In Stock"
            .MappingName = "UnitsInStock"
            .Width = 75
            .Alignment = HorizontalAlignment.Center
        End With

        ' Add the style objects to the table style's collection of 
        ' column styles. Without this the styles do not take effect.        
        grdTableStyle1.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() _
            {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4})
        grdProducts.TableStyles.Add(grdTableStyle1)
    End Sub

    Private Sub FormatGridWithoutTableStyles()
        ' Change the appearance of the DataGrid by directly setting 
        ' its formatting properties.
        With grdProducts
            .AlternatingBackColor = Color.GhostWhite
            .BackColor = Color.GhostWhite
            .BackgroundColor = Color.Lavender
            .BorderStyle = BorderStyle.None
            .CaptionBackColor = Color.RoyalBlue
            .CaptionFont = New Font("Tahoma", 10.0!, FontStyle.Bold)
            .CaptionForeColor = Color.Bisque
            .CaptionText = "Northwind Products"
            .Font = New Font("Tahoma", 8.0!)
            .ForeColor = Color.MidnightBlue
            .GridLineColor = Color.RoyalBlue
            .HeaderBackColor = Color.MidnightBlue
            .HeaderFont = New Font("Tahoma", 8.0!, FontStyle.Bold)
            .HeaderForeColor = Color.Lavender
            .ParentRowsBackColor = Color.Lavender
            .ParentRowsForeColor = Color.MidnightBlue
            .SelectionBackColor = Color.Teal
            .SelectionForeColor = Color.PaleGreen
        End With
    End Sub

    Private Sub FormatGridWithTableStyles()
        ' Continue to set DataGrid properties directly, but only
        ' those that are not covered by DataGridTableStyle properties.
        With grdProducts
            .BackColor = Color.GhostWhite
            .BackgroundColor = Color.Lavender
            .BorderStyle = BorderStyle.None
            .CaptionBackColor = Color.RoyalBlue
            .CaptionFont = New Font("Tahoma", 10.0!, FontStyle.Bold)
            .CaptionForeColor = Color.Bisque
            .CaptionText = "Northwind Products"
            .Font = New Font("Tahoma", 8.0!)
            .ParentRowsBackColor = Color.Lavender
            .ParentRowsForeColor = Color.MidnightBlue
        End With

        ' Set other formatting properties using a DataGridTableStyle object.
        ' Note that some of the DataGrid formatting properties overlap those
        ' of the the DataGridTableStyle. So it is usually desirable to set as
        ' many of the properties as you can in the DataGrid and then make any
        ' other adjustments using a DataGridTableStyle. 
        '
        ' Also, because a DataGrid can contain multiple DataTable objects, a 
        ' different DataGridTableStyle object can be applied to the data in each 
        ' DataTable. To do this, simply set the MappingName property to the name 
        ' of the DataTable containing the data you wish to format.
        Dim grdTableStyle1 As New DataGridTableStyle()
        With grdTableStyle1
            .AlternatingBackColor = Color.GhostWhite
            .BackColor = Color.GhostWhite
            .ForeColor = Color.MidnightBlue
            .GridLineColor = Color.RoyalBlue
            .HeaderBackColor = Color.MidnightBlue
            .HeaderFont = New Font("Tahoma", 8.0!, FontStyle.Bold)
            .HeaderForeColor = Color.Lavender
            .SelectionBackColor = Color.Teal
            .SelectionForeColor = Color.PaleGreen
            ' Do not forget to set the MappingName property. 
            ' Without this, the DataGridTableStyle properties
            ' and any associated DataGridColumnStyle objects
            ' will have no effect.
            .MappingName = PRODUCT_TABLE_NAME
            .PreferredColumnWidth = 125
            .PreferredRowHeight = 15
        End With

        ' Add the style to the DataGrid's table styles collection. 
        ' Without this the styles do not take effect.
        grdProducts.TableStyles.Add(grdTableStyle1)
    End Sub

    Private Sub ResetDemo()
        ' DEMO PURPOSES ONLY: 
        ' Clear the DataTable so that subsequent button clicks keep 
        ' adding to the existing data.
        If Not IsNothing(ProductData.Tables(PRODUCT_TABLE_NAME)) Then
            ProductData.Tables(PRODUCT_TABLE_NAME).Clear()
        End If

        ' Clear out the existing TableStyles and result default formatting.
        With grdProducts
            .BackgroundColor = SystemColors.InactiveCaptionText
            .CaptionText = ""
            .CaptionBackColor = SystemColors.ActiveCaption
            .TableStyles.Clear()
            .ResetAlternatingBackColor()
            .ResetBackColor()
            .ResetForeColor()
            .ResetGridLineColor()
            .ResetHeaderBackColor()
            .ResetHeaderFont()
            .ResetHeaderForeColor()
            .ResetSelectionBackColor()
            .ResetSelectionForeColor()
            .ResetText()
            .BorderStyle = DefaultGridBorderStyle
        End With
    End Sub

    Private Sub btnColumnStyles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColumnStyles.Click
        ResetDemo()
        BindDataGrid()
        ' If you need column-level formatting, add DataGridColumnStyle objects
        ' to a DataGridTableStyle object. Be aware, however, that you 
        ' will have to create a DataGridColumnStyle object for every 
        ' column that you want to appear. You cannot simply tweak a subset
        ' of the columns. In other words, you cannot lay new styles over
        ' existing styles. It's an all or nothing proposition.
        FormatGridWithBothTableAndColumnStyles()
    End Sub

    Private Sub btnDefaultFormatting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefaultFormatting.Click
        ResetDemo()
        ' This displays data in the DataGrid using the default Visual Studio .NET formatting.
        BindDataGrid()
    End Sub

    Private Sub btnGridProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGridProperties.Click
        ResetDemo()
        BindDataGrid()
        ' If you do not need control over the appearance of individual columns
        ' then you can just set the various formatting properties of the DataGrid.
        ' Alternatively, you could create a DataGridTableStyle and achieve
        ' the same look (see the btnTableStyle_Click event handler).
        FormatGridWithoutTableStyles()
    End Sub

    Private Sub btnTableStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTableStyle.Click
        ResetDemo()
        BindDataGrid()
        ' If you do not need control over the appearance of individual columns
        ' then you can create a DataGridTableStyle that is applied to all
        ' columns. You can also just set the DataGrid formatting properties
        ' directly (see the btnGridProperties_Click event handler).
        FormatGridWithTableStyles()
    End Sub

End Class