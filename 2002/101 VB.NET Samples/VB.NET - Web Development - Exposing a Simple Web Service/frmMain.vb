'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Text.RegularExpressions

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGetOrderHistory As System.Windows.Forms.Button
    Friend WithEvents txtCustID As System.Windows.Forms.TextBox
    Friend WithEvents grdOrders As System.Windows.Forms.DataGrid
    Friend WithEvents lblNoResults As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.grdOrders = New System.Windows.Forms.DataGrid()
        Me.btnGetOrderHistory = New System.Windows.Forms.Button()
        Me.txtCustID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNoResults = New System.Windows.Forms.Label()
        CType(Me.grdOrders, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'grdOrders
        '
        Me.grdOrders.AccessibleDescription = CType(resources.GetObject("grdOrders.AccessibleDescription"), String)
        Me.grdOrders.AccessibleName = CType(resources.GetObject("grdOrders.AccessibleName"), String)
        Me.grdOrders.Anchor = CType(resources.GetObject("grdOrders.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grdOrders.BackgroundImage = CType(resources.GetObject("grdOrders.BackgroundImage"), System.Drawing.Image)
        Me.grdOrders.CaptionFont = CType(resources.GetObject("grdOrders.CaptionFont"), System.Drawing.Font)
        Me.grdOrders.CaptionText = resources.GetString("grdOrders.CaptionText")
        Me.grdOrders.DataMember = ""
        Me.grdOrders.Dock = CType(resources.GetObject("grdOrders.Dock"), System.Windows.Forms.DockStyle)
        Me.grdOrders.Enabled = CType(resources.GetObject("grdOrders.Enabled"), Boolean)
        Me.grdOrders.Font = CType(resources.GetObject("grdOrders.Font"), System.Drawing.Font)
        Me.grdOrders.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdOrders.ImeMode = CType(resources.GetObject("grdOrders.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grdOrders.Location = CType(resources.GetObject("grdOrders.Location"), System.Drawing.Point)
        Me.grdOrders.Name = "grdOrders"
        Me.grdOrders.ReadOnly = True
        Me.grdOrders.RightToLeft = CType(resources.GetObject("grdOrders.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grdOrders.Size = CType(resources.GetObject("grdOrders.Size"), System.Drawing.Size)
        Me.grdOrders.TabIndex = CType(resources.GetObject("grdOrders.TabIndex"), Integer)
        Me.grdOrders.Visible = CType(resources.GetObject("grdOrders.Visible"), Boolean)
        '
        'btnGetOrderHistory
        '
        Me.btnGetOrderHistory.AccessibleDescription = CType(resources.GetObject("btnGetOrderHistory.AccessibleDescription"), String)
        Me.btnGetOrderHistory.AccessibleName = CType(resources.GetObject("btnGetOrderHistory.AccessibleName"), String)
        Me.btnGetOrderHistory.Anchor = CType(resources.GetObject("btnGetOrderHistory.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnGetOrderHistory.BackgroundImage = CType(resources.GetObject("btnGetOrderHistory.BackgroundImage"), System.Drawing.Image)
        Me.btnGetOrderHistory.Dock = CType(resources.GetObject("btnGetOrderHistory.Dock"), System.Windows.Forms.DockStyle)
        Me.btnGetOrderHistory.Enabled = CType(resources.GetObject("btnGetOrderHistory.Enabled"), Boolean)
        Me.btnGetOrderHistory.FlatStyle = CType(resources.GetObject("btnGetOrderHistory.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnGetOrderHistory.Font = CType(resources.GetObject("btnGetOrderHistory.Font"), System.Drawing.Font)
        Me.btnGetOrderHistory.Image = CType(resources.GetObject("btnGetOrderHistory.Image"), System.Drawing.Image)
        Me.btnGetOrderHistory.ImageAlign = CType(resources.GetObject("btnGetOrderHistory.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnGetOrderHistory.ImageIndex = CType(resources.GetObject("btnGetOrderHistory.ImageIndex"), Integer)
        Me.btnGetOrderHistory.ImeMode = CType(resources.GetObject("btnGetOrderHistory.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnGetOrderHistory.Location = CType(resources.GetObject("btnGetOrderHistory.Location"), System.Drawing.Point)
        Me.btnGetOrderHistory.Name = "btnGetOrderHistory"
        Me.btnGetOrderHistory.RightToLeft = CType(resources.GetObject("btnGetOrderHistory.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnGetOrderHistory.Size = CType(resources.GetObject("btnGetOrderHistory.Size"), System.Drawing.Size)
        Me.btnGetOrderHistory.TabIndex = CType(resources.GetObject("btnGetOrderHistory.TabIndex"), Integer)
        Me.btnGetOrderHistory.Text = resources.GetString("btnGetOrderHistory.Text")
        Me.btnGetOrderHistory.TextAlign = CType(resources.GetObject("btnGetOrderHistory.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnGetOrderHistory.Visible = CType(resources.GetObject("btnGetOrderHistory.Visible"), Boolean)
        '
        'txtCustID
        '
        Me.txtCustID.AccessibleDescription = CType(resources.GetObject("txtCustID.AccessibleDescription"), String)
        Me.txtCustID.AccessibleName = CType(resources.GetObject("txtCustID.AccessibleName"), String)
        Me.txtCustID.Anchor = CType(resources.GetObject("txtCustID.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtCustID.AutoSize = CType(resources.GetObject("txtCustID.AutoSize"), Boolean)
        Me.txtCustID.BackgroundImage = CType(resources.GetObject("txtCustID.BackgroundImage"), System.Drawing.Image)
        Me.txtCustID.Dock = CType(resources.GetObject("txtCustID.Dock"), System.Windows.Forms.DockStyle)
        Me.txtCustID.Enabled = CType(resources.GetObject("txtCustID.Enabled"), Boolean)
        Me.txtCustID.Font = CType(resources.GetObject("txtCustID.Font"), System.Drawing.Font)
        Me.txtCustID.ImeMode = CType(resources.GetObject("txtCustID.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtCustID.Location = CType(resources.GetObject("txtCustID.Location"), System.Drawing.Point)
        Me.txtCustID.MaxLength = CType(resources.GetObject("txtCustID.MaxLength"), Integer)
        Me.txtCustID.Multiline = CType(resources.GetObject("txtCustID.Multiline"), Boolean)
        Me.txtCustID.Name = "txtCustID"
        Me.txtCustID.PasswordChar = CType(resources.GetObject("txtCustID.PasswordChar"), Char)
        Me.txtCustID.RightToLeft = CType(resources.GetObject("txtCustID.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtCustID.ScrollBars = CType(resources.GetObject("txtCustID.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtCustID.Size = CType(resources.GetObject("txtCustID.Size"), System.Drawing.Size)
        Me.txtCustID.TabIndex = CType(resources.GetObject("txtCustID.TabIndex"), Integer)
        Me.txtCustID.Text = resources.GetString("txtCustID.Text")
        Me.txtCustID.TextAlign = CType(resources.GetObject("txtCustID.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtCustID.Visible = CType(resources.GetObject("txtCustID.Visible"), Boolean)
        Me.txtCustID.WordWrap = CType(resources.GetObject("txtCustID.WordWrap"), Boolean)
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
        'lblNoResults
        '
        Me.lblNoResults.AccessibleDescription = CType(resources.GetObject("lblNoResults.AccessibleDescription"), String)
        Me.lblNoResults.AccessibleName = CType(resources.GetObject("lblNoResults.AccessibleName"), String)
        Me.lblNoResults.Anchor = CType(resources.GetObject("lblNoResults.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblNoResults.AutoSize = CType(resources.GetObject("lblNoResults.AutoSize"), Boolean)
        Me.lblNoResults.Dock = CType(resources.GetObject("lblNoResults.Dock"), System.Windows.Forms.DockStyle)
        Me.lblNoResults.Enabled = CType(resources.GetObject("lblNoResults.Enabled"), Boolean)
        Me.lblNoResults.Font = CType(resources.GetObject("lblNoResults.Font"), System.Drawing.Font)
        Me.lblNoResults.Image = CType(resources.GetObject("lblNoResults.Image"), System.Drawing.Image)
        Me.lblNoResults.ImageAlign = CType(resources.GetObject("lblNoResults.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblNoResults.ImageIndex = CType(resources.GetObject("lblNoResults.ImageIndex"), Integer)
        Me.lblNoResults.ImeMode = CType(resources.GetObject("lblNoResults.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblNoResults.Location = CType(resources.GetObject("lblNoResults.Location"), System.Drawing.Point)
        Me.lblNoResults.Name = "lblNoResults"
        Me.lblNoResults.RightToLeft = CType(resources.GetObject("lblNoResults.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblNoResults.Size = CType(resources.GetObject("lblNoResults.Size"), System.Drawing.Size)
        Me.lblNoResults.TabIndex = CType(resources.GetObject("lblNoResults.TabIndex"), Integer)
        Me.lblNoResults.Text = resources.GetString("lblNoResults.Text")
        Me.lblNoResults.TextAlign = CType(resources.GetObject("lblNoResults.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblNoResults.Visible = CType(resources.GetObject("lblNoResults.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtCustID, Me.Label1, Me.btnGetOrderHistory, Me.grdOrders, Me.lblNoResults})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
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
        CType(Me.grdOrders, System.ComponentModel.ISupportInitialize).EndInit()
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

    ' This routine handles the Click event for the "Get Orders" button. It shows
    ' how to instantiate Web service proxy classes and bind data returned from a
    ' Web service to a DataGrid. DataGrid formatting is also demonstrated.
    Private Sub btnGetOrderHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetOrderHistory.Click
        If Not CustIDIsValid() Then
            Exit Sub
        End If

        Dim strCustID As String = Trim(txtCustID.Text)
        ' Create an instance of the Web service proxy class.
        Dim ws As New localhost.Main()
        ' Create a variable to hold the custom return type.
        Dim cohi As localhost.CustomerAndOrderHistoryInfo
        Try
            cohi = ws.GetCustomerOrderHistory(txtCustID.Text)
        Catch exp As Exception
            MsgBox(exp.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

        If cohi.Orders.CustOrderHist.Rows.Count > 0 Then

            With grdOrders
                .CaptionText = "Order History for " & cohi.Company & ":"
                .CaptionFont = New Font("Microsoft Sans Serif", 10)
                .DataSource = cohi.Orders.CustOrderHist
                ' Clear all existing styles or subsequent databinding will cause 
                ' runtime exception.
                .TableStyles.Clear()
            End With

            Dim grdTableStyle1 As New DataGridTableStyle()
            With grdTableStyle1
                ' You must always set the MappingName, even with a DataView that has
                ' only one Table. If not, you will get no errors but the formatting
                ' will not appear. To avoid mistakes, instead of typing the name of 
                ' the table used when creating the DataSet, you can access the 
                ' TableName property.
                .MappingName = cohi.Orders.Tables(0).TableName
            End With

            ' The use of column styles overrides the automatic generation of columns 
            ' for every column in the DataTable. When column style objects are used,
            ' every column you want to display has to have an associate column style 
            ' object.
            Dim grdColStyle1 As New DataGridTextBoxColumn()
            With grdColStyle1
                .MappingName = "ProductName"
                .HeaderText = "Product Name"
                .Width = 230
            End With

            Dim grdColStyle2 As New DataGridTextBoxColumn()
            With grdColStyle2
                .MappingName = "Total"
                .HeaderText = "Total"
                .Format = "c"
                .Width = 75
            End With

            ' Add the column style objects to the table style's collection of 
            ' column styles. Without this the styles do not take effect.        
            grdTableStyle1.GridColumnStyles.AddRange _
                (New DataGridColumnStyle() {grdColStyle1, grdColStyle2})
            grdOrders.TableStyles.Add(grdTableStyle1)

            grdOrders.Visible = True
            lblNoResults.Visible = False
        Else
            lblNoResults.Text = "No data was returned for the Customer ID you " & _
                "entered. Please check the value and try again. Examples are " & _
                "COMMI, GODOS, and ISLAT."
            lblNoResults.Visible = True
            grdOrders.Visible = False
        End If
    End Sub

    ' This routine validates the CustomerID.
    Private Function CustIDIsValid() As Boolean
        ' Use a regular expression object to check for a pattern match.
        If Not Regex.IsMatch(txtCustID.Text, "^\s*(\D){5}\s*$") Then
            MsgBox("You must enter a five-letter CustomerID. " & _
                "Examples are COMMI, GODOS, and ISLAT.", _
                MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        Return True
    End Function
End Class