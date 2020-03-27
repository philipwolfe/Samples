'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports EnvDTE

' This class provides the main user interface for the How-To.
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
    Friend WithEvents btnCheckForAddIn As System.Windows.Forms.Button
    Friend WithEvents txtInstalled As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblLogDescription As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblLogDescription = New System.Windows.Forms.Label()
        Me.btnCheckForAddIn = New System.Windows.Forms.Button()
        Me.txtInstalled = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
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
        'lblDescription
        '
        Me.lblDescription.AccessibleDescription = resources.GetString("lblDescription.AccessibleDescription")
        Me.lblDescription.AccessibleName = resources.GetString("lblDescription.AccessibleName")
        Me.lblDescription.Anchor = CType(resources.GetObject("lblDescription.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblDescription.AutoSize = CType(resources.GetObject("lblDescription.AutoSize"), Boolean)
        Me.lblDescription.Dock = CType(resources.GetObject("lblDescription.Dock"), System.Windows.Forms.DockStyle)
        Me.lblDescription.Enabled = CType(resources.GetObject("lblDescription.Enabled"), Boolean)
        Me.lblDescription.Font = CType(resources.GetObject("lblDescription.Font"), System.Drawing.Font)
        Me.lblDescription.Image = CType(resources.GetObject("lblDescription.Image"), System.Drawing.Image)
        Me.lblDescription.ImageAlign = CType(resources.GetObject("lblDescription.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblDescription.ImageIndex = CType(resources.GetObject("lblDescription.ImageIndex"), Integer)
        Me.lblDescription.ImeMode = CType(resources.GetObject("lblDescription.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblDescription.Location = CType(resources.GetObject("lblDescription.Location"), System.Drawing.Point)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.RightToLeft = CType(resources.GetObject("lblDescription.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblDescription.Size = CType(resources.GetObject("lblDescription.Size"), System.Drawing.Size)
        Me.lblDescription.TabIndex = CType(resources.GetObject("lblDescription.TabIndex"), Integer)
        Me.lblDescription.Text = resources.GetString("lblDescription.Text")
        Me.lblDescription.TextAlign = CType(resources.GetObject("lblDescription.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblDescription.Visible = CType(resources.GetObject("lblDescription.Visible"), Boolean)
        '
        'lblLogDescription
        '
        Me.lblLogDescription.AccessibleDescription = resources.GetString("lblLogDescription.AccessibleDescription")
        Me.lblLogDescription.AccessibleName = resources.GetString("lblLogDescription.AccessibleName")
        Me.lblLogDescription.Anchor = CType(resources.GetObject("lblLogDescription.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblLogDescription.AutoSize = CType(resources.GetObject("lblLogDescription.AutoSize"), Boolean)
        Me.lblLogDescription.Dock = CType(resources.GetObject("lblLogDescription.Dock"), System.Windows.Forms.DockStyle)
        Me.lblLogDescription.Enabled = CType(resources.GetObject("lblLogDescription.Enabled"), Boolean)
        Me.lblLogDescription.Font = CType(resources.GetObject("lblLogDescription.Font"), System.Drawing.Font)
        Me.lblLogDescription.Image = CType(resources.GetObject("lblLogDescription.Image"), System.Drawing.Image)
        Me.lblLogDescription.ImageAlign = CType(resources.GetObject("lblLogDescription.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblLogDescription.ImageIndex = CType(resources.GetObject("lblLogDescription.ImageIndex"), Integer)
        Me.lblLogDescription.ImeMode = CType(resources.GetObject("lblLogDescription.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblLogDescription.Location = CType(resources.GetObject("lblLogDescription.Location"), System.Drawing.Point)
        Me.lblLogDescription.Name = "lblLogDescription"
        Me.lblLogDescription.RightToLeft = CType(resources.GetObject("lblLogDescription.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblLogDescription.Size = CType(resources.GetObject("lblLogDescription.Size"), System.Drawing.Size)
        Me.lblLogDescription.TabIndex = CType(resources.GetObject("lblLogDescription.TabIndex"), Integer)
        Me.lblLogDescription.Text = resources.GetString("lblLogDescription.Text")
        Me.lblLogDescription.TextAlign = CType(resources.GetObject("lblLogDescription.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblLogDescription.Visible = CType(resources.GetObject("lblLogDescription.Visible"), Boolean)
        '
        'btnCheckForAddIn
        '
        Me.btnCheckForAddIn.AccessibleDescription = resources.GetString("btnCheckForAddIn.AccessibleDescription")
        Me.btnCheckForAddIn.AccessibleName = resources.GetString("btnCheckForAddIn.AccessibleName")
        Me.btnCheckForAddIn.Anchor = CType(resources.GetObject("btnCheckForAddIn.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCheckForAddIn.BackgroundImage = CType(resources.GetObject("btnCheckForAddIn.BackgroundImage"), System.Drawing.Image)
        Me.btnCheckForAddIn.Dock = CType(resources.GetObject("btnCheckForAddIn.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCheckForAddIn.Enabled = CType(resources.GetObject("btnCheckForAddIn.Enabled"), Boolean)
        Me.btnCheckForAddIn.FlatStyle = CType(resources.GetObject("btnCheckForAddIn.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCheckForAddIn.Font = CType(resources.GetObject("btnCheckForAddIn.Font"), System.Drawing.Font)
        Me.btnCheckForAddIn.Image = CType(resources.GetObject("btnCheckForAddIn.Image"), System.Drawing.Image)
        Me.btnCheckForAddIn.ImageAlign = CType(resources.GetObject("btnCheckForAddIn.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCheckForAddIn.ImageIndex = CType(resources.GetObject("btnCheckForAddIn.ImageIndex"), Integer)
        Me.btnCheckForAddIn.ImeMode = CType(resources.GetObject("btnCheckForAddIn.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCheckForAddIn.Location = CType(resources.GetObject("btnCheckForAddIn.Location"), System.Drawing.Point)
        Me.btnCheckForAddIn.Name = "btnCheckForAddIn"
        Me.btnCheckForAddIn.RightToLeft = CType(resources.GetObject("btnCheckForAddIn.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCheckForAddIn.Size = CType(resources.GetObject("btnCheckForAddIn.Size"), System.Drawing.Size)
        Me.btnCheckForAddIn.TabIndex = CType(resources.GetObject("btnCheckForAddIn.TabIndex"), Integer)
        Me.btnCheckForAddIn.Text = resources.GetString("btnCheckForAddIn.Text")
        Me.btnCheckForAddIn.TextAlign = CType(resources.GetObject("btnCheckForAddIn.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCheckForAddIn.Visible = CType(resources.GetObject("btnCheckForAddIn.Visible"), Boolean)
        '
        'txtInstalled
        '
        Me.txtInstalled.AccessibleDescription = resources.GetString("txtInstalled.AccessibleDescription")
        Me.txtInstalled.AccessibleName = resources.GetString("txtInstalled.AccessibleName")
        Me.txtInstalled.Anchor = CType(resources.GetObject("txtInstalled.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtInstalled.AutoSize = CType(resources.GetObject("txtInstalled.AutoSize"), Boolean)
        Me.txtInstalled.BackgroundImage = CType(resources.GetObject("txtInstalled.BackgroundImage"), System.Drawing.Image)
        Me.txtInstalled.Dock = CType(resources.GetObject("txtInstalled.Dock"), System.Windows.Forms.DockStyle)
        Me.txtInstalled.Enabled = CType(resources.GetObject("txtInstalled.Enabled"), Boolean)
        Me.txtInstalled.Font = CType(resources.GetObject("txtInstalled.Font"), System.Drawing.Font)
        Me.txtInstalled.ImeMode = CType(resources.GetObject("txtInstalled.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtInstalled.Location = CType(resources.GetObject("txtInstalled.Location"), System.Drawing.Point)
        Me.txtInstalled.MaxLength = CType(resources.GetObject("txtInstalled.MaxLength"), Integer)
        Me.txtInstalled.Multiline = CType(resources.GetObject("txtInstalled.Multiline"), Boolean)
        Me.txtInstalled.Name = "txtInstalled"
        Me.txtInstalled.PasswordChar = CType(resources.GetObject("txtInstalled.PasswordChar"), Char)
        Me.txtInstalled.RightToLeft = CType(resources.GetObject("txtInstalled.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtInstalled.ScrollBars = CType(resources.GetObject("txtInstalled.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtInstalled.Size = CType(resources.GetObject("txtInstalled.Size"), System.Drawing.Size)
        Me.txtInstalled.TabIndex = CType(resources.GetObject("txtInstalled.TabIndex"), Integer)
        Me.txtInstalled.TabStop = False
        Me.txtInstalled.Text = resources.GetString("txtInstalled.Text")
        Me.txtInstalled.TextAlign = CType(resources.GetObject("txtInstalled.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtInstalled.Visible = CType(resources.GetObject("txtInstalled.Visible"), Boolean)
        Me.txtInstalled.WordWrap = CType(resources.GetObject("txtInstalled.WordWrap"), Boolean)
        '
        'lblStatus
        '
        Me.lblStatus.AccessibleDescription = resources.GetString("lblStatus.AccessibleDescription")
        Me.lblStatus.AccessibleName = resources.GetString("lblStatus.AccessibleName")
        Me.lblStatus.Anchor = CType(resources.GetObject("lblStatus.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = CType(resources.GetObject("lblStatus.AutoSize"), Boolean)
        Me.lblStatus.Dock = CType(resources.GetObject("lblStatus.Dock"), System.Windows.Forms.DockStyle)
        Me.lblStatus.Enabled = CType(resources.GetObject("lblStatus.Enabled"), Boolean)
        Me.lblStatus.Font = CType(resources.GetObject("lblStatus.Font"), System.Drawing.Font)
        Me.lblStatus.Image = CType(resources.GetObject("lblStatus.Image"), System.Drawing.Image)
        Me.lblStatus.ImageAlign = CType(resources.GetObject("lblStatus.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblStatus.ImageIndex = CType(resources.GetObject("lblStatus.ImageIndex"), Integer)
        Me.lblStatus.ImeMode = CType(resources.GetObject("lblStatus.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblStatus.Location = CType(resources.GetObject("lblStatus.Location"), System.Drawing.Point)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = CType(resources.GetObject("lblStatus.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblStatus.Size = CType(resources.GetObject("lblStatus.Size"), System.Drawing.Size)
        Me.lblStatus.TabIndex = CType(resources.GetObject("lblStatus.TabIndex"), Integer)
        Me.lblStatus.Text = resources.GetString("lblStatus.Text")
        Me.lblStatus.TextAlign = CType(resources.GetObject("lblStatus.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblStatus.Visible = CType(resources.GetObject("lblStatus.Visible"), Boolean)
        '
        'frmMain
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblStatus, Me.txtInstalled, Me.btnCheckForAddIn, Me.lblLogDescription, Me.lblDescription})
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


    ' This subroutine checks for the existence of the Add-In. The status of the
    '   installation is reported to the user.
    Private Sub btnCheckForAddIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckForAddIn.Click

        Dim myDTE As EnvDTE.DTE
        Dim myAddIns As EnvDTE.AddIns
        Dim myAddIn As EnvDTE.AddIn
        Dim isInstalled As Boolean = False

        ' Create a DTE object, to get the Add-In informations.
        myDTE = New EnvDTE.DTE()

        ' Create a collection of all the AddIn objects.
        myAddIns = myDTE.AddIns

        ' Iterate through the AddIns to determine if the VB.NET How To
        '   Example Add-in is installed.
        For Each myAddIn In myAddIns
            If myAddIn.Name = "VB.NET How-To Example Add-In" Then
                isInstalled = True
            End If
        Next

        ' Report installation status to the user.
        If isInstalled Then
            txtInstalled.Text = "VB.NET How To Example Add-in is installed!"
        Else
            txtInstalled.Text = "VB.NET How To Example Add-in is not installed!"
        End If

    End Sub

    ' This subroutine executes when the main form is loaded. It simply calls
    '   the btnCheckForAddIn_Click subroutine to determine if the Add-in
    '   is loaded.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Call the btnCheckForAddIn_Click subroutine.
        btnCheckForAddIn_Click(Me, New System.EventArgs())
    End Sub
End Class