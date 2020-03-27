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

    ' Initialize constants for connecting to the database
    ' and displaying a connection error to the user.
    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=;" & _
        "Integrated Security=SSPI"

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=;" & _
        "Integrated Security=SSPI"

    Protected Const CONNECTION_ERROR_MSG As String = _
        "To run this sample, you must have SQL " & _
        "or MSDE with the Northwind database installed.  For " & _
        "instructions on installing MSDE, view the ReadMe file."

    Protected bolDidPreviouslyConnect As Boolean = False
    Protected bolDidCreateTable As Boolean = False
    Protected connectionString As String = SQL_CONNECTION_STRING

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
    Friend WithEvents lblArrow1 As System.Windows.Forms.Label
    Friend WithEvents lblStep1 As System.Windows.Forms.Label
    Friend WithEvents lblStep2 As System.Windows.Forms.Label
    Friend WithEvents lblArrow2 As System.Windows.Forms.Label
    Friend WithEvents lblArrow3 As System.Windows.Forms.Label
    Friend WithEvents lblStep3 As System.Windows.Forms.Label
    Friend WithEvents lblStep4 As System.Windows.Forms.Label
    Friend WithEvents lblStep6 As System.Windows.Forms.Label
    Friend WithEvents lblArrow5 As System.Windows.Forms.Label
    Friend WithEvents lblStep5 As System.Windows.Forms.Label
    Friend WithEvents btnCreateDB As System.Windows.Forms.Button
    Friend WithEvents btnCreateTable As System.Windows.Forms.Button
    Friend WithEvents btnCreateSP As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents btnPopulate As System.Windows.Forms.Button
    Friend WithEvents btnCreateView As System.Windows.Forms.Button
    Friend WithEvents lblArrow4 As System.Windows.Forms.Label
    Friend WithEvents dgSeafood As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCreateDB = New System.Windows.Forms.Button()
        Me.lblStep1 = New System.Windows.Forms.Label()
        Me.lblArrow1 = New System.Windows.Forms.Label()
        Me.lblArrow2 = New System.Windows.Forms.Label()
        Me.lblStep2 = New System.Windows.Forms.Label()
        Me.btnCreateTable = New System.Windows.Forms.Button()
        Me.lblArrow3 = New System.Windows.Forms.Label()
        Me.lblStep3 = New System.Windows.Forms.Label()
        Me.btnCreateSP = New System.Windows.Forms.Button()
        Me.lblStep6 = New System.Windows.Forms.Label()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.lblArrow5 = New System.Windows.Forms.Label()
        Me.lblStep5 = New System.Windows.Forms.Label()
        Me.btnPopulate = New System.Windows.Forms.Button()
        Me.lblArrow4 = New System.Windows.Forms.Label()
        Me.lblStep4 = New System.Windows.Forms.Label()
        Me.btnCreateView = New System.Windows.Forms.Button()
        Me.dgSeafood = New System.Windows.Forms.DataGrid()
        CType(Me.dgSeafood, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label1
        '
        Me.Label1.AccessibleDescription = CType(resources.GetObject("Label1.AccessibleDescription"), String)
        Me.Label1.AccessibleName = CType(resources.GetObject("Label1.AccessibleName"), String)
        Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
        Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
        Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
        Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
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
        'btnCreateDB
        '
        Me.btnCreateDB.AccessibleDescription = CType(resources.GetObject("btnCreateDB.AccessibleDescription"), String)
        Me.btnCreateDB.AccessibleName = CType(resources.GetObject("btnCreateDB.AccessibleName"), String)
        Me.btnCreateDB.Anchor = CType(resources.GetObject("btnCreateDB.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCreateDB.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnCreateDB.BackgroundImage = CType(resources.GetObject("btnCreateDB.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateDB.Dock = CType(resources.GetObject("btnCreateDB.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCreateDB.Enabled = CType(resources.GetObject("btnCreateDB.Enabled"), Boolean)
        Me.btnCreateDB.FlatStyle = CType(resources.GetObject("btnCreateDB.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCreateDB.Font = CType(resources.GetObject("btnCreateDB.Font"), System.Drawing.Font)
        Me.btnCreateDB.Image = CType(resources.GetObject("btnCreateDB.Image"), System.Drawing.Image)
        Me.btnCreateDB.ImageAlign = CType(resources.GetObject("btnCreateDB.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateDB.ImageIndex = CType(resources.GetObject("btnCreateDB.ImageIndex"), Integer)
        Me.btnCreateDB.ImeMode = CType(resources.GetObject("btnCreateDB.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCreateDB.Location = CType(resources.GetObject("btnCreateDB.Location"), System.Drawing.Point)
        Me.btnCreateDB.Name = "btnCreateDB"
        Me.btnCreateDB.RightToLeft = CType(resources.GetObject("btnCreateDB.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCreateDB.Size = CType(resources.GetObject("btnCreateDB.Size"), System.Drawing.Size)
        Me.btnCreateDB.TabIndex = CType(resources.GetObject("btnCreateDB.TabIndex"), Integer)
        Me.btnCreateDB.Text = resources.GetString("btnCreateDB.Text")
        Me.btnCreateDB.TextAlign = CType(resources.GetObject("btnCreateDB.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateDB.Visible = CType(resources.GetObject("btnCreateDB.Visible"), Boolean)
        '
        'lblStep1
        '
        Me.lblStep1.AccessibleDescription = CType(resources.GetObject("lblStep1.AccessibleDescription"), String)
        Me.lblStep1.AccessibleName = CType(resources.GetObject("lblStep1.AccessibleName"), String)
        Me.lblStep1.Anchor = CType(resources.GetObject("lblStep1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblStep1.AutoSize = CType(resources.GetObject("lblStep1.AutoSize"), Boolean)
        Me.lblStep1.Dock = CType(resources.GetObject("lblStep1.Dock"), System.Windows.Forms.DockStyle)
        Me.lblStep1.Enabled = CType(resources.GetObject("lblStep1.Enabled"), Boolean)
        Me.lblStep1.Font = CType(resources.GetObject("lblStep1.Font"), System.Drawing.Font)
        Me.lblStep1.Image = CType(resources.GetObject("lblStep1.Image"), System.Drawing.Image)
        Me.lblStep1.ImageAlign = CType(resources.GetObject("lblStep1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblStep1.ImageIndex = CType(resources.GetObject("lblStep1.ImageIndex"), Integer)
        Me.lblStep1.ImeMode = CType(resources.GetObject("lblStep1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblStep1.Location = CType(resources.GetObject("lblStep1.Location"), System.Drawing.Point)
        Me.lblStep1.Name = "lblStep1"
        Me.lblStep1.RightToLeft = CType(resources.GetObject("lblStep1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblStep1.Size = CType(resources.GetObject("lblStep1.Size"), System.Drawing.Size)
        Me.lblStep1.TabIndex = CType(resources.GetObject("lblStep1.TabIndex"), Integer)
        Me.lblStep1.Text = resources.GetString("lblStep1.Text")
        Me.lblStep1.TextAlign = CType(resources.GetObject("lblStep1.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblStep1.Visible = CType(resources.GetObject("lblStep1.Visible"), Boolean)
        '
        'lblArrow1
        '
        Me.lblArrow1.AccessibleDescription = CType(resources.GetObject("lblArrow1.AccessibleDescription"), String)
        Me.lblArrow1.AccessibleName = CType(resources.GetObject("lblArrow1.AccessibleName"), String)
        Me.lblArrow1.Anchor = CType(resources.GetObject("lblArrow1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblArrow1.AutoSize = CType(resources.GetObject("lblArrow1.AutoSize"), Boolean)
        Me.lblArrow1.Dock = CType(resources.GetObject("lblArrow1.Dock"), System.Windows.Forms.DockStyle)
        Me.lblArrow1.Enabled = CType(resources.GetObject("lblArrow1.Enabled"), Boolean)
        Me.lblArrow1.Font = CType(resources.GetObject("lblArrow1.Font"), System.Drawing.Font)
        Me.lblArrow1.Image = CType(resources.GetObject("lblArrow1.Image"), System.Drawing.Image)
        Me.lblArrow1.ImageAlign = CType(resources.GetObject("lblArrow1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblArrow1.ImageIndex = CType(resources.GetObject("lblArrow1.ImageIndex"), Integer)
        Me.lblArrow1.ImeMode = CType(resources.GetObject("lblArrow1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblArrow1.Location = CType(resources.GetObject("lblArrow1.Location"), System.Drawing.Point)
        Me.lblArrow1.Name = "lblArrow1"
        Me.lblArrow1.RightToLeft = CType(resources.GetObject("lblArrow1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblArrow1.Size = CType(resources.GetObject("lblArrow1.Size"), System.Drawing.Size)
        Me.lblArrow1.TabIndex = CType(resources.GetObject("lblArrow1.TabIndex"), Integer)
        Me.lblArrow1.Text = resources.GetString("lblArrow1.Text")
        Me.lblArrow1.TextAlign = CType(resources.GetObject("lblArrow1.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblArrow1.Visible = CType(resources.GetObject("lblArrow1.Visible"), Boolean)
        '
        'lblArrow2
        '
        Me.lblArrow2.AccessibleDescription = CType(resources.GetObject("lblArrow2.AccessibleDescription"), String)
        Me.lblArrow2.AccessibleName = CType(resources.GetObject("lblArrow2.AccessibleName"), String)
        Me.lblArrow2.Anchor = CType(resources.GetObject("lblArrow2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblArrow2.AutoSize = CType(resources.GetObject("lblArrow2.AutoSize"), Boolean)
        Me.lblArrow2.Dock = CType(resources.GetObject("lblArrow2.Dock"), System.Windows.Forms.DockStyle)
        Me.lblArrow2.Enabled = CType(resources.GetObject("lblArrow2.Enabled"), Boolean)
        Me.lblArrow2.Font = CType(resources.GetObject("lblArrow2.Font"), System.Drawing.Font)
        Me.lblArrow2.Image = CType(resources.GetObject("lblArrow2.Image"), System.Drawing.Image)
        Me.lblArrow2.ImageAlign = CType(resources.GetObject("lblArrow2.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblArrow2.ImageIndex = CType(resources.GetObject("lblArrow2.ImageIndex"), Integer)
        Me.lblArrow2.ImeMode = CType(resources.GetObject("lblArrow2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblArrow2.Location = CType(resources.GetObject("lblArrow2.Location"), System.Drawing.Point)
        Me.lblArrow2.Name = "lblArrow2"
        Me.lblArrow2.RightToLeft = CType(resources.GetObject("lblArrow2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblArrow2.Size = CType(resources.GetObject("lblArrow2.Size"), System.Drawing.Size)
        Me.lblArrow2.TabIndex = CType(resources.GetObject("lblArrow2.TabIndex"), Integer)
        Me.lblArrow2.Text = resources.GetString("lblArrow2.Text")
        Me.lblArrow2.TextAlign = CType(resources.GetObject("lblArrow2.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblArrow2.Visible = CType(resources.GetObject("lblArrow2.Visible"), Boolean)
        '
        'lblStep2
        '
        Me.lblStep2.AccessibleDescription = CType(resources.GetObject("lblStep2.AccessibleDescription"), String)
        Me.lblStep2.AccessibleName = CType(resources.GetObject("lblStep2.AccessibleName"), String)
        Me.lblStep2.Anchor = CType(resources.GetObject("lblStep2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblStep2.AutoSize = CType(resources.GetObject("lblStep2.AutoSize"), Boolean)
        Me.lblStep2.Dock = CType(resources.GetObject("lblStep2.Dock"), System.Windows.Forms.DockStyle)
        Me.lblStep2.Enabled = CType(resources.GetObject("lblStep2.Enabled"), Boolean)
        Me.lblStep2.Font = CType(resources.GetObject("lblStep2.Font"), System.Drawing.Font)
        Me.lblStep2.Image = CType(resources.GetObject("lblStep2.Image"), System.Drawing.Image)
        Me.lblStep2.ImageAlign = CType(resources.GetObject("lblStep2.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblStep2.ImageIndex = CType(resources.GetObject("lblStep2.ImageIndex"), Integer)
        Me.lblStep2.ImeMode = CType(resources.GetObject("lblStep2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblStep2.Location = CType(resources.GetObject("lblStep2.Location"), System.Drawing.Point)
        Me.lblStep2.Name = "lblStep2"
        Me.lblStep2.RightToLeft = CType(resources.GetObject("lblStep2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblStep2.Size = CType(resources.GetObject("lblStep2.Size"), System.Drawing.Size)
        Me.lblStep2.TabIndex = CType(resources.GetObject("lblStep2.TabIndex"), Integer)
        Me.lblStep2.Text = resources.GetString("lblStep2.Text")
        Me.lblStep2.TextAlign = CType(resources.GetObject("lblStep2.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblStep2.Visible = CType(resources.GetObject("lblStep2.Visible"), Boolean)
        '
        'btnCreateTable
        '
        Me.btnCreateTable.AccessibleDescription = CType(resources.GetObject("btnCreateTable.AccessibleDescription"), String)
        Me.btnCreateTable.AccessibleName = CType(resources.GetObject("btnCreateTable.AccessibleName"), String)
        Me.btnCreateTable.Anchor = CType(resources.GetObject("btnCreateTable.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCreateTable.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnCreateTable.BackgroundImage = CType(resources.GetObject("btnCreateTable.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateTable.Dock = CType(resources.GetObject("btnCreateTable.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCreateTable.Enabled = CType(resources.GetObject("btnCreateTable.Enabled"), Boolean)
        Me.btnCreateTable.FlatStyle = CType(resources.GetObject("btnCreateTable.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCreateTable.Font = CType(resources.GetObject("btnCreateTable.Font"), System.Drawing.Font)
        Me.btnCreateTable.Image = CType(resources.GetObject("btnCreateTable.Image"), System.Drawing.Image)
        Me.btnCreateTable.ImageAlign = CType(resources.GetObject("btnCreateTable.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateTable.ImageIndex = CType(resources.GetObject("btnCreateTable.ImageIndex"), Integer)
        Me.btnCreateTable.ImeMode = CType(resources.GetObject("btnCreateTable.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCreateTable.Location = CType(resources.GetObject("btnCreateTable.Location"), System.Drawing.Point)
        Me.btnCreateTable.Name = "btnCreateTable"
        Me.btnCreateTable.RightToLeft = CType(resources.GetObject("btnCreateTable.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCreateTable.Size = CType(resources.GetObject("btnCreateTable.Size"), System.Drawing.Size)
        Me.btnCreateTable.TabIndex = CType(resources.GetObject("btnCreateTable.TabIndex"), Integer)
        Me.btnCreateTable.Text = resources.GetString("btnCreateTable.Text")
        Me.btnCreateTable.TextAlign = CType(resources.GetObject("btnCreateTable.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateTable.Visible = CType(resources.GetObject("btnCreateTable.Visible"), Boolean)
        '
        'lblArrow3
        '
        Me.lblArrow3.AccessibleDescription = CType(resources.GetObject("lblArrow3.AccessibleDescription"), String)
        Me.lblArrow3.AccessibleName = CType(resources.GetObject("lblArrow3.AccessibleName"), String)
        Me.lblArrow3.Anchor = CType(resources.GetObject("lblArrow3.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblArrow3.AutoSize = CType(resources.GetObject("lblArrow3.AutoSize"), Boolean)
        Me.lblArrow3.Dock = CType(resources.GetObject("lblArrow3.Dock"), System.Windows.Forms.DockStyle)
        Me.lblArrow3.Enabled = CType(resources.GetObject("lblArrow3.Enabled"), Boolean)
        Me.lblArrow3.Font = CType(resources.GetObject("lblArrow3.Font"), System.Drawing.Font)
        Me.lblArrow3.Image = CType(resources.GetObject("lblArrow3.Image"), System.Drawing.Image)
        Me.lblArrow3.ImageAlign = CType(resources.GetObject("lblArrow3.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblArrow3.ImageIndex = CType(resources.GetObject("lblArrow3.ImageIndex"), Integer)
        Me.lblArrow3.ImeMode = CType(resources.GetObject("lblArrow3.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblArrow3.Location = CType(resources.GetObject("lblArrow3.Location"), System.Drawing.Point)
        Me.lblArrow3.Name = "lblArrow3"
        Me.lblArrow3.RightToLeft = CType(resources.GetObject("lblArrow3.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblArrow3.Size = CType(resources.GetObject("lblArrow3.Size"), System.Drawing.Size)
        Me.lblArrow3.TabIndex = CType(resources.GetObject("lblArrow3.TabIndex"), Integer)
        Me.lblArrow3.Text = resources.GetString("lblArrow3.Text")
        Me.lblArrow3.TextAlign = CType(resources.GetObject("lblArrow3.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblArrow3.Visible = CType(resources.GetObject("lblArrow3.Visible"), Boolean)
        '
        'lblStep3
        '
        Me.lblStep3.AccessibleDescription = CType(resources.GetObject("lblStep3.AccessibleDescription"), String)
        Me.lblStep3.AccessibleName = CType(resources.GetObject("lblStep3.AccessibleName"), String)
        Me.lblStep3.Anchor = CType(resources.GetObject("lblStep3.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblStep3.AutoSize = CType(resources.GetObject("lblStep3.AutoSize"), Boolean)
        Me.lblStep3.Dock = CType(resources.GetObject("lblStep3.Dock"), System.Windows.Forms.DockStyle)
        Me.lblStep3.Enabled = CType(resources.GetObject("lblStep3.Enabled"), Boolean)
        Me.lblStep3.Font = CType(resources.GetObject("lblStep3.Font"), System.Drawing.Font)
        Me.lblStep3.Image = CType(resources.GetObject("lblStep3.Image"), System.Drawing.Image)
        Me.lblStep3.ImageAlign = CType(resources.GetObject("lblStep3.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblStep3.ImageIndex = CType(resources.GetObject("lblStep3.ImageIndex"), Integer)
        Me.lblStep3.ImeMode = CType(resources.GetObject("lblStep3.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblStep3.Location = CType(resources.GetObject("lblStep3.Location"), System.Drawing.Point)
        Me.lblStep3.Name = "lblStep3"
        Me.lblStep3.RightToLeft = CType(resources.GetObject("lblStep3.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblStep3.Size = CType(resources.GetObject("lblStep3.Size"), System.Drawing.Size)
        Me.lblStep3.TabIndex = CType(resources.GetObject("lblStep3.TabIndex"), Integer)
        Me.lblStep3.Text = resources.GetString("lblStep3.Text")
        Me.lblStep3.TextAlign = CType(resources.GetObject("lblStep3.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblStep3.Visible = CType(resources.GetObject("lblStep3.Visible"), Boolean)
        '
        'btnCreateSP
        '
        Me.btnCreateSP.AccessibleDescription = CType(resources.GetObject("btnCreateSP.AccessibleDescription"), String)
        Me.btnCreateSP.AccessibleName = CType(resources.GetObject("btnCreateSP.AccessibleName"), String)
        Me.btnCreateSP.Anchor = CType(resources.GetObject("btnCreateSP.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCreateSP.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnCreateSP.BackgroundImage = CType(resources.GetObject("btnCreateSP.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateSP.Dock = CType(resources.GetObject("btnCreateSP.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCreateSP.Enabled = CType(resources.GetObject("btnCreateSP.Enabled"), Boolean)
        Me.btnCreateSP.FlatStyle = CType(resources.GetObject("btnCreateSP.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCreateSP.Font = CType(resources.GetObject("btnCreateSP.Font"), System.Drawing.Font)
        Me.btnCreateSP.Image = CType(resources.GetObject("btnCreateSP.Image"), System.Drawing.Image)
        Me.btnCreateSP.ImageAlign = CType(resources.GetObject("btnCreateSP.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateSP.ImageIndex = CType(resources.GetObject("btnCreateSP.ImageIndex"), Integer)
        Me.btnCreateSP.ImeMode = CType(resources.GetObject("btnCreateSP.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCreateSP.Location = CType(resources.GetObject("btnCreateSP.Location"), System.Drawing.Point)
        Me.btnCreateSP.Name = "btnCreateSP"
        Me.btnCreateSP.RightToLeft = CType(resources.GetObject("btnCreateSP.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCreateSP.Size = CType(resources.GetObject("btnCreateSP.Size"), System.Drawing.Size)
        Me.btnCreateSP.TabIndex = CType(resources.GetObject("btnCreateSP.TabIndex"), Integer)
        Me.btnCreateSP.Text = resources.GetString("btnCreateSP.Text")
        Me.btnCreateSP.TextAlign = CType(resources.GetObject("btnCreateSP.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateSP.Visible = CType(resources.GetObject("btnCreateSP.Visible"), Boolean)
        '
        'lblStep6
        '
        Me.lblStep6.AccessibleDescription = CType(resources.GetObject("lblStep6.AccessibleDescription"), String)
        Me.lblStep6.AccessibleName = CType(resources.GetObject("lblStep6.AccessibleName"), String)
        Me.lblStep6.Anchor = CType(resources.GetObject("lblStep6.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblStep6.AutoSize = CType(resources.GetObject("lblStep6.AutoSize"), Boolean)
        Me.lblStep6.Dock = CType(resources.GetObject("lblStep6.Dock"), System.Windows.Forms.DockStyle)
        Me.lblStep6.Enabled = CType(resources.GetObject("lblStep6.Enabled"), Boolean)
        Me.lblStep6.Font = CType(resources.GetObject("lblStep6.Font"), System.Drawing.Font)
        Me.lblStep6.Image = CType(resources.GetObject("lblStep6.Image"), System.Drawing.Image)
        Me.lblStep6.ImageAlign = CType(resources.GetObject("lblStep6.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblStep6.ImageIndex = CType(resources.GetObject("lblStep6.ImageIndex"), Integer)
        Me.lblStep6.ImeMode = CType(resources.GetObject("lblStep6.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblStep6.Location = CType(resources.GetObject("lblStep6.Location"), System.Drawing.Point)
        Me.lblStep6.Name = "lblStep6"
        Me.lblStep6.RightToLeft = CType(resources.GetObject("lblStep6.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblStep6.Size = CType(resources.GetObject("lblStep6.Size"), System.Drawing.Size)
        Me.lblStep6.TabIndex = CType(resources.GetObject("lblStep6.TabIndex"), Integer)
        Me.lblStep6.Text = resources.GetString("lblStep6.Text")
        Me.lblStep6.TextAlign = CType(resources.GetObject("lblStep6.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblStep6.Visible = CType(resources.GetObject("lblStep6.Visible"), Boolean)
        '
        'btnDisplay
        '
        Me.btnDisplay.AccessibleDescription = CType(resources.GetObject("btnDisplay.AccessibleDescription"), String)
        Me.btnDisplay.AccessibleName = CType(resources.GetObject("btnDisplay.AccessibleName"), String)
        Me.btnDisplay.Anchor = CType(resources.GetObject("btnDisplay.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnDisplay.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnDisplay.BackgroundImage = CType(resources.GetObject("btnDisplay.BackgroundImage"), System.Drawing.Image)
        Me.btnDisplay.Dock = CType(resources.GetObject("btnDisplay.Dock"), System.Windows.Forms.DockStyle)
        Me.btnDisplay.Enabled = CType(resources.GetObject("btnDisplay.Enabled"), Boolean)
        Me.btnDisplay.FlatStyle = CType(resources.GetObject("btnDisplay.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnDisplay.Font = CType(resources.GetObject("btnDisplay.Font"), System.Drawing.Font)
        Me.btnDisplay.Image = CType(resources.GetObject("btnDisplay.Image"), System.Drawing.Image)
        Me.btnDisplay.ImageAlign = CType(resources.GetObject("btnDisplay.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnDisplay.ImageIndex = CType(resources.GetObject("btnDisplay.ImageIndex"), Integer)
        Me.btnDisplay.ImeMode = CType(resources.GetObject("btnDisplay.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnDisplay.Location = CType(resources.GetObject("btnDisplay.Location"), System.Drawing.Point)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.RightToLeft = CType(resources.GetObject("btnDisplay.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnDisplay.Size = CType(resources.GetObject("btnDisplay.Size"), System.Drawing.Size)
        Me.btnDisplay.TabIndex = CType(resources.GetObject("btnDisplay.TabIndex"), Integer)
        Me.btnDisplay.Text = resources.GetString("btnDisplay.Text")
        Me.btnDisplay.TextAlign = CType(resources.GetObject("btnDisplay.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnDisplay.Visible = CType(resources.GetObject("btnDisplay.Visible"), Boolean)
        '
        'lblArrow5
        '
        Me.lblArrow5.AccessibleDescription = CType(resources.GetObject("lblArrow5.AccessibleDescription"), String)
        Me.lblArrow5.AccessibleName = CType(resources.GetObject("lblArrow5.AccessibleName"), String)
        Me.lblArrow5.Anchor = CType(resources.GetObject("lblArrow5.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblArrow5.AutoSize = CType(resources.GetObject("lblArrow5.AutoSize"), Boolean)
        Me.lblArrow5.Dock = CType(resources.GetObject("lblArrow5.Dock"), System.Windows.Forms.DockStyle)
        Me.lblArrow5.Enabled = CType(resources.GetObject("lblArrow5.Enabled"), Boolean)
        Me.lblArrow5.Font = CType(resources.GetObject("lblArrow5.Font"), System.Drawing.Font)
        Me.lblArrow5.Image = CType(resources.GetObject("lblArrow5.Image"), System.Drawing.Image)
        Me.lblArrow5.ImageAlign = CType(resources.GetObject("lblArrow5.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblArrow5.ImageIndex = CType(resources.GetObject("lblArrow5.ImageIndex"), Integer)
        Me.lblArrow5.ImeMode = CType(resources.GetObject("lblArrow5.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblArrow5.Location = CType(resources.GetObject("lblArrow5.Location"), System.Drawing.Point)
        Me.lblArrow5.Name = "lblArrow5"
        Me.lblArrow5.RightToLeft = CType(resources.GetObject("lblArrow5.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblArrow5.Size = CType(resources.GetObject("lblArrow5.Size"), System.Drawing.Size)
        Me.lblArrow5.TabIndex = CType(resources.GetObject("lblArrow5.TabIndex"), Integer)
        Me.lblArrow5.Text = resources.GetString("lblArrow5.Text")
        Me.lblArrow5.TextAlign = CType(resources.GetObject("lblArrow5.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblArrow5.Visible = CType(resources.GetObject("lblArrow5.Visible"), Boolean)
        '
        'lblStep5
        '
        Me.lblStep5.AccessibleDescription = CType(resources.GetObject("lblStep5.AccessibleDescription"), String)
        Me.lblStep5.AccessibleName = CType(resources.GetObject("lblStep5.AccessibleName"), String)
        Me.lblStep5.Anchor = CType(resources.GetObject("lblStep5.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblStep5.AutoSize = CType(resources.GetObject("lblStep5.AutoSize"), Boolean)
        Me.lblStep5.Dock = CType(resources.GetObject("lblStep5.Dock"), System.Windows.Forms.DockStyle)
        Me.lblStep5.Enabled = CType(resources.GetObject("lblStep5.Enabled"), Boolean)
        Me.lblStep5.Font = CType(resources.GetObject("lblStep5.Font"), System.Drawing.Font)
        Me.lblStep5.Image = CType(resources.GetObject("lblStep5.Image"), System.Drawing.Image)
        Me.lblStep5.ImageAlign = CType(resources.GetObject("lblStep5.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblStep5.ImageIndex = CType(resources.GetObject("lblStep5.ImageIndex"), Integer)
        Me.lblStep5.ImeMode = CType(resources.GetObject("lblStep5.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblStep5.Location = CType(resources.GetObject("lblStep5.Location"), System.Drawing.Point)
        Me.lblStep5.Name = "lblStep5"
        Me.lblStep5.RightToLeft = CType(resources.GetObject("lblStep5.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblStep5.Size = CType(resources.GetObject("lblStep5.Size"), System.Drawing.Size)
        Me.lblStep5.TabIndex = CType(resources.GetObject("lblStep5.TabIndex"), Integer)
        Me.lblStep5.Text = resources.GetString("lblStep5.Text")
        Me.lblStep5.TextAlign = CType(resources.GetObject("lblStep5.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblStep5.Visible = CType(resources.GetObject("lblStep5.Visible"), Boolean)
        '
        'btnPopulate
        '
        Me.btnPopulate.AccessibleDescription = CType(resources.GetObject("btnPopulate.AccessibleDescription"), String)
        Me.btnPopulate.AccessibleName = CType(resources.GetObject("btnPopulate.AccessibleName"), String)
        Me.btnPopulate.Anchor = CType(resources.GetObject("btnPopulate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnPopulate.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnPopulate.BackgroundImage = CType(resources.GetObject("btnPopulate.BackgroundImage"), System.Drawing.Image)
        Me.btnPopulate.Dock = CType(resources.GetObject("btnPopulate.Dock"), System.Windows.Forms.DockStyle)
        Me.btnPopulate.Enabled = CType(resources.GetObject("btnPopulate.Enabled"), Boolean)
        Me.btnPopulate.FlatStyle = CType(resources.GetObject("btnPopulate.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnPopulate.Font = CType(resources.GetObject("btnPopulate.Font"), System.Drawing.Font)
        Me.btnPopulate.Image = CType(resources.GetObject("btnPopulate.Image"), System.Drawing.Image)
        Me.btnPopulate.ImageAlign = CType(resources.GetObject("btnPopulate.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnPopulate.ImageIndex = CType(resources.GetObject("btnPopulate.ImageIndex"), Integer)
        Me.btnPopulate.ImeMode = CType(resources.GetObject("btnPopulate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnPopulate.Location = CType(resources.GetObject("btnPopulate.Location"), System.Drawing.Point)
        Me.btnPopulate.Name = "btnPopulate"
        Me.btnPopulate.RightToLeft = CType(resources.GetObject("btnPopulate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnPopulate.Size = CType(resources.GetObject("btnPopulate.Size"), System.Drawing.Size)
        Me.btnPopulate.TabIndex = CType(resources.GetObject("btnPopulate.TabIndex"), Integer)
        Me.btnPopulate.Text = resources.GetString("btnPopulate.Text")
        Me.btnPopulate.TextAlign = CType(resources.GetObject("btnPopulate.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnPopulate.Visible = CType(resources.GetObject("btnPopulate.Visible"), Boolean)
        '
        'lblArrow4
        '
        Me.lblArrow4.AccessibleDescription = CType(resources.GetObject("lblArrow4.AccessibleDescription"), String)
        Me.lblArrow4.AccessibleName = CType(resources.GetObject("lblArrow4.AccessibleName"), String)
        Me.lblArrow4.Anchor = CType(resources.GetObject("lblArrow4.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblArrow4.AutoSize = CType(resources.GetObject("lblArrow4.AutoSize"), Boolean)
        Me.lblArrow4.Dock = CType(resources.GetObject("lblArrow4.Dock"), System.Windows.Forms.DockStyle)
        Me.lblArrow4.Enabled = CType(resources.GetObject("lblArrow4.Enabled"), Boolean)
        Me.lblArrow4.Font = CType(resources.GetObject("lblArrow4.Font"), System.Drawing.Font)
        Me.lblArrow4.Image = CType(resources.GetObject("lblArrow4.Image"), System.Drawing.Image)
        Me.lblArrow4.ImageAlign = CType(resources.GetObject("lblArrow4.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblArrow4.ImageIndex = CType(resources.GetObject("lblArrow4.ImageIndex"), Integer)
        Me.lblArrow4.ImeMode = CType(resources.GetObject("lblArrow4.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblArrow4.Location = CType(resources.GetObject("lblArrow4.Location"), System.Drawing.Point)
        Me.lblArrow4.Name = "lblArrow4"
        Me.lblArrow4.RightToLeft = CType(resources.GetObject("lblArrow4.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblArrow4.Size = CType(resources.GetObject("lblArrow4.Size"), System.Drawing.Size)
        Me.lblArrow4.TabIndex = CType(resources.GetObject("lblArrow4.TabIndex"), Integer)
        Me.lblArrow4.Text = resources.GetString("lblArrow4.Text")
        Me.lblArrow4.TextAlign = CType(resources.GetObject("lblArrow4.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblArrow4.Visible = CType(resources.GetObject("lblArrow4.Visible"), Boolean)
        '
        'lblStep4
        '
        Me.lblStep4.AccessibleDescription = CType(resources.GetObject("lblStep4.AccessibleDescription"), String)
        Me.lblStep4.AccessibleName = CType(resources.GetObject("lblStep4.AccessibleName"), String)
        Me.lblStep4.Anchor = CType(resources.GetObject("lblStep4.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblStep4.AutoSize = CType(resources.GetObject("lblStep4.AutoSize"), Boolean)
        Me.lblStep4.Dock = CType(resources.GetObject("lblStep4.Dock"), System.Windows.Forms.DockStyle)
        Me.lblStep4.Enabled = CType(resources.GetObject("lblStep4.Enabled"), Boolean)
        Me.lblStep4.Font = CType(resources.GetObject("lblStep4.Font"), System.Drawing.Font)
        Me.lblStep4.Image = CType(resources.GetObject("lblStep4.Image"), System.Drawing.Image)
        Me.lblStep4.ImageAlign = CType(resources.GetObject("lblStep4.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblStep4.ImageIndex = CType(resources.GetObject("lblStep4.ImageIndex"), Integer)
        Me.lblStep4.ImeMode = CType(resources.GetObject("lblStep4.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblStep4.Location = CType(resources.GetObject("lblStep4.Location"), System.Drawing.Point)
        Me.lblStep4.Name = "lblStep4"
        Me.lblStep4.RightToLeft = CType(resources.GetObject("lblStep4.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblStep4.Size = CType(resources.GetObject("lblStep4.Size"), System.Drawing.Size)
        Me.lblStep4.TabIndex = CType(resources.GetObject("lblStep4.TabIndex"), Integer)
        Me.lblStep4.Text = resources.GetString("lblStep4.Text")
        Me.lblStep4.TextAlign = CType(resources.GetObject("lblStep4.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblStep4.Visible = CType(resources.GetObject("lblStep4.Visible"), Boolean)
        '
        'btnCreateView
        '
        Me.btnCreateView.AccessibleDescription = CType(resources.GetObject("btnCreateView.AccessibleDescription"), String)
        Me.btnCreateView.AccessibleName = CType(resources.GetObject("btnCreateView.AccessibleName"), String)
        Me.btnCreateView.Anchor = CType(resources.GetObject("btnCreateView.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCreateView.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnCreateView.BackgroundImage = CType(resources.GetObject("btnCreateView.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateView.Dock = CType(resources.GetObject("btnCreateView.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCreateView.Enabled = CType(resources.GetObject("btnCreateView.Enabled"), Boolean)
        Me.btnCreateView.FlatStyle = CType(resources.GetObject("btnCreateView.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCreateView.Font = CType(resources.GetObject("btnCreateView.Font"), System.Drawing.Font)
        Me.btnCreateView.Image = CType(resources.GetObject("btnCreateView.Image"), System.Drawing.Image)
        Me.btnCreateView.ImageAlign = CType(resources.GetObject("btnCreateView.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateView.ImageIndex = CType(resources.GetObject("btnCreateView.ImageIndex"), Integer)
        Me.btnCreateView.ImeMode = CType(resources.GetObject("btnCreateView.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCreateView.Location = CType(resources.GetObject("btnCreateView.Location"), System.Drawing.Point)
        Me.btnCreateView.Name = "btnCreateView"
        Me.btnCreateView.RightToLeft = CType(resources.GetObject("btnCreateView.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCreateView.Size = CType(resources.GetObject("btnCreateView.Size"), System.Drawing.Size)
        Me.btnCreateView.TabIndex = CType(resources.GetObject("btnCreateView.TabIndex"), Integer)
        Me.btnCreateView.Text = resources.GetString("btnCreateView.Text")
        Me.btnCreateView.TextAlign = CType(resources.GetObject("btnCreateView.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateView.Visible = CType(resources.GetObject("btnCreateView.Visible"), Boolean)
        '
        'dgSeafood
        '
        Me.dgSeafood.AccessibleDescription = CType(resources.GetObject("dgSeafood.AccessibleDescription"), String)
        Me.dgSeafood.AccessibleName = CType(resources.GetObject("dgSeafood.AccessibleName"), String)
        Me.dgSeafood.AlternatingBackColor = System.Drawing.SystemColors.Window
        Me.dgSeafood.Anchor = CType(resources.GetObject("dgSeafood.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.dgSeafood.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgSeafood.BackgroundImage = CType(resources.GetObject("dgSeafood.BackgroundImage"), System.Drawing.Image)
        Me.dgSeafood.CaptionFont = CType(resources.GetObject("dgSeafood.CaptionFont"), System.Drawing.Font)
        Me.dgSeafood.CaptionText = resources.GetString("dgSeafood.CaptionText")
        Me.dgSeafood.DataMember = ""
        Me.dgSeafood.Dock = CType(resources.GetObject("dgSeafood.Dock"), System.Windows.Forms.DockStyle)
        Me.dgSeafood.Enabled = CType(resources.GetObject("dgSeafood.Enabled"), Boolean)
        Me.dgSeafood.Font = CType(resources.GetObject("dgSeafood.Font"), System.Drawing.Font)
        Me.dgSeafood.GridLineColor = System.Drawing.SystemColors.Control
        Me.dgSeafood.HeaderBackColor = System.Drawing.SystemColors.Control
        Me.dgSeafood.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSeafood.ImeMode = CType(resources.GetObject("dgSeafood.ImeMode"), System.Windows.Forms.ImeMode)
        Me.dgSeafood.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.dgSeafood.Location = CType(resources.GetObject("dgSeafood.Location"), System.Drawing.Point)
        Me.dgSeafood.Name = "dgSeafood"
        Me.dgSeafood.RightToLeft = CType(resources.GetObject("dgSeafood.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.dgSeafood.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgSeafood.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgSeafood.Size = CType(resources.GetObject("dgSeafood.Size"), System.Drawing.Size)
        Me.dgSeafood.TabIndex = CType(resources.GetObject("dgSeafood.TabIndex"), Integer)
        Me.dgSeafood.Visible = CType(resources.GetObject("dgSeafood.Visible"), Boolean)
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
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgSeafood, Me.lblStep6, Me.btnDisplay, Me.lblArrow5, Me.lblStep5, Me.btnPopulate, Me.lblArrow4, Me.lblStep4, Me.btnCreateView, Me.lblArrow3, Me.lblStep3, Me.btnCreateSP, Me.lblArrow2, Me.lblStep2, Me.btnCreateTable, Me.lblArrow1, Me.lblStep1, Me.btnCreateDB, Me.Label1})
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
        CType(Me.dgSeafood, System.ComponentModel.ISupportInitialize).EndInit()
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

    ' This routine executes a SQL statement that drops the database (if it exists) 
    ' and then creates it. 
    Private Sub CreateTable()
        Dim strSQL As String = _
            "IF EXISTS (" & _
            "SELECT * " & _
            "FROM master..sysdatabases " & _
            "WHERE Name = 'HowToDemo')" & vbCrLf & _
            "DROP DATABASE HowToDemo" & vbCrLf & _
            "CREATE DATABASE HowToDemo"

        ' Display a status message saying that we're attempting to connect.
        ' This only needs to be done the very first time a connection is
        ' attempted.  After we've determined that MSDE or SQL Server is
        ' installed, this message no longer needs to be displayed.
        Dim frmStatusMessage As New frmStatus()
        If Not bolDidPreviouslyConnect Then
            frmStatusMessage.Show("Connecting to SQL Server")
        End If

        ' Attempt to connect to the local SQL server instance, and a local
        ' MSDE installation (with Northwind).  
        Dim bolIsConnecting As Boolean = True
        While bolIsConnecting
            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in SQL Server, or be part of the Administrators
                ' group for this to work.
                Dim northwindConnection As New SqlConnection(connectionString)

                ' A SqlCommand object is used to execute the SQL commands.
                Dim cmd As New SqlCommand(strSQL, northwindConnection)

                ' Open the connection, execute the command, and close the 
                ' connection. It is more efficient to ExecuteNonQuery when data is 
                ' not being returned.
                northwindConnection.Open()
                cmd.ExecuteNonQuery()
                northwindConnection.Close()

                ' Data has been successfully submitted, so break out of the loop
                ' and close the status form.
                bolIsConnecting = False
                bolDidPreviouslyConnect = True
                bolDidCreateTable = True
                frmStatusMessage.Close()

                ' Show the controls for the next step.
                lblArrow1.Visible = True
                lblStep2.Enabled = True
                btnCreateTable.Enabled = True

                MessageBox.Show("Database 'HowToDemo' successfully created!", _
                    "Database Creation Status", MessageBoxButtons.OK, _
                    MessageBoxIcon.Information)

            Catch sqlExc As SqlException
                MessageBox.Show(sqlExc.ToString, "SQL Exception Error!", _
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit While
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
        frmStatusMessage.Close()
    End Sub

    ' Sets up the user interface so that the user proceeds in proper order
    ' through the steps.
    Private Sub ResetUI()
        lblArrow1.Visible = False
        lblStep2.Enabled = False
        btnCreateTable.Enabled = False
        lblArrow2.Visible = False
        lblStep3.Enabled = False
        btnCreateSP.Enabled = False
        lblArrow3.Visible = False
        lblStep4.Enabled = False
        btnCreateView.Enabled = False
        lblArrow4.Visible = False
        lblStep5.Enabled = False
        btnPopulate.Enabled = False
        lblArrow5.Visible = False
        lblStep6.Enabled = False
        btnDisplay.Enabled = False

        With dgSeafood
            .Visible = False
            .DataSource = Nothing
            .TableStyles.Clear()
            .Visible = False
        End With
    End Sub

    ' Handles the click event for the Create Database button.
    Private Sub btnCreateDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateDB.Click

        ' If the "Create Table" button is enabled this means the user is trying to
        ' recreate the database again in the same application run. Warn the user of
        ' how this will affect things, and if they want to proceed, reset the UI to
        ' the initial state so that errors are not induced if currently enabled 
        ' buttons are clicked out of order.
        If btnCreateTable.Enabled Then
            Dim dr As DialogResult = MessageBox.Show("Recreating the database " & _
                "will undo the other database object creation steps you have " & _
                "made so far. Do you wish to proceed?", "Database Re-creation " & _
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If dr = DialogResult.Yes Then
                ResetUI()
                CreateTable()
            End If
        Else
            CreateTable()
        End If

    End Sub

    ' Handles the click event for the Create Procedure button. This handler executes
    ' two SQL statements, one that drops the Procedure (if it exists) and another 
    ' that creates the Procedure. The statements are broken up in this manner 
    ' because SQL Server doesn't allow them to be combined in one batch. (You can 
    ' combine them when using the GO keyword and executing from SQL Query Analyzer 
    ' or another tool, but not from code.)
    Private Sub btnCreateSP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateSP.Click
        ' The SqlConnection class allows you to communicate with SQL Server.
        ' The constructor accepts a connection string as an argument.  This
        ' connection string uses Integrated Security, which means that you 
        ' must have a login in SQL Server, or be part of the Administrators
        ' group for this to work.
        Dim northwindConnection As New SqlConnection(connectionString)

        Dim strSQL As String = _
            "USE HowToDemo" & vbCrLf & _
            "IF EXISTS (" & _
            "SELECT * " & _
            "FROM HowToDemo.dbo.sysobjects " & _
            "WHERE Name = 'AddSeafood' " & _
            "AND TYPE = 'p')" & vbCrLf & _
            "BEGIN" & vbCrLf & _
            "DROP PROCEDURE AddSeafood" & vbCrLf & _
            "END"

        ' A SqlCommand object is used to execute the SQL commands.
        Dim cmd As New SqlCommand(strSQL, northwindConnection)

        Try
            ' Open the connection, execute the command, and close the connection.
            ' It is more efficient to ExecuteNonQuery when data is not being 
            ' returned.
            northwindConnection.Open()
            cmd.ExecuteNonQuery()

        Catch sqlExc As SqlException
            MessageBox.Show(sqlExc.ToString, "SQL Exception Error!", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            cmd.CommandText = _
                "CREATE PROCEDURE AddSeafood AS" & vbCrLf & _
                "INSERT INTO NW_Seafood" & vbCrLf & _
                "(ProductID, ProductName, QuantityPerUnit, UnitPrice)" & _
                "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice " & _
                "FROM Northwind.dbo.Products " & _
                "WHERE CategoryID = 8"

            cmd.ExecuteNonQuery()
            northwindConnection.Close()

            ' Show the controls for the next step.
            lblArrow3.Visible = True
            lblStep4.Enabled = True
            btnCreateView.Enabled = True

            MessageBox.Show("Stored Procedure 'AddSeafood' successfully " & _
                "created.", "SPROC Creation Status", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch sqlExc As SqlException
            MessageBox.Show(sqlExc.ToString, "SQL Exception Error!", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Handles the click event for the Create Table button.
    Private Sub btnCreateTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateTable.Click

        Dim strSQL As String = _
            "USE HowToDemo" & vbCrLf & _
            "IF EXISTS (" & _
            "SELECT * " & _
            "FROM HowToDemo.dbo.sysobjects " & _
            "WHERE Name = 'NW_Seafood' " & _
            "AND TYPE = 'u')" & vbCrLf & _
            "BEGIN" & vbCrLf & _
            "DROP TABLE HowToDemo.dbo.NW_Seafood" & vbCrLf & _
            "END" & vbCrLf & _
            "CREATE TABLE NW_Seafood (" & _
            "ProductID Int NOT NULL," & _
            "ProductName NVarChar(40) NOT NULL," & _
            "QuantityPerUnit NVarChar(20) NOT NULL," & _
            "UnitPrice Money NOT NULL," & _
            "CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED" & _
            "(ProductID))"

        Try
            ' The SqlConnection class allows you to communicate with SQL Server.
            ' The constructor accepts a connection string as an argument.  This
            ' connection string uses Integrated Security, which means that you 
            ' must have a login in SQL Server, or be part of the Administrators
            ' group for this to work.
            Dim northwindConnection As New SqlConnection(connectionString)

            ' A SqlCommand object is used to execute the SQL commands.
            Dim cmd As New SqlCommand(strSQL, northwindConnection)

            ' Open the connection, execute the command, and close the connection.
            ' It is more efficient to ExecuteNonQuery when data is not being 
            ' returned.
            northwindConnection.Open()
            cmd.ExecuteNonQuery()
            northwindConnection.Close()

            ' Show the controls for the next step.
            lblArrow2.Visible = True
            lblStep3.Enabled = True
            btnCreateSP.Enabled = True

            MessageBox.Show("Table 'NW_Seafood' successfully created.", _
                "Table Creation Status", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch sqlExc As SqlException
            MessageBox.Show(sqlExc.ToString, "SQL Exception Error!", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Handles the click event for the Create View button. This handler executes
    ' two SQL statements, one that drops the View (if it exists) and another 
    ' that creates the View. The statements are broken up in this manner because
    ' SQL Server doesn't allow them to be combined in one batch. (You can combine
    ' them when using the GO keyword and executing from SQL Query Analyzer or 
    ' another tool, but not from code.)
    Private Sub btnCreateView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateView.Click
        ' The SqlConnection class allows you to communicate with SQL Server.
        ' The constructor accepts a connection string as an argument.  This
        ' connection string uses Integrated Security, which means that you 
        ' must have a login in SQL Server, or be part of the Administrators
        ' group for this to work.
        Dim northwindConnection As New SqlConnection(connectionString)

        Dim strSQL As String = _
            "USE HowToDemo" & vbCrLf & _
            "IF EXISTS (" & _
            "SELECT * " & _
            "FROM HowToDemo.dbo.sysobjects " & _
            "WHERE Name = 'GetSeafood' " & _
            "AND TYPE = 'v')" & vbCrLf & _
            "BEGIN" & vbCrLf & _
            "DROP VIEW GetSeafood" & vbCrLf & _
            "END"

        ' A SqlCommand object is used to execute the SQL commands.
        Dim cmd As New SqlCommand(strSQL, northwindConnection)

        Try
            ' Open the connection, execute the command. Do not close the
            ' connection yet as it will be used in the next Try...Catch blocl.
            northwindConnection.Open()
            cmd.ExecuteNonQuery()

        Catch sqlExc As SqlException
            MessageBox.Show(sqlExc.ToString, "SQL Exception Error!", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            ' Change the SQL statement for the next query.
            cmd.CommandText = _
                "CREATE VIEW GetSeafood AS " & _
                "SELECT * " & _
                "FROM NW_Seafood"

            cmd.ExecuteNonQuery()
            northwindConnection.Close()

            ' Show the controls for the next step.
            lblArrow4.Visible = True
            lblStep5.Enabled = True
            btnPopulate.Enabled = True

            MessageBox.Show("View 'GetSeafood' successfully " & _
                "created.", "SQL View Creation Status", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch sqlExc As SqlException
            MessageBox.Show(sqlExc.ToString, "SQL Exception Error!", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Handles the click event for the Display button. This handler gets the product
    ' information from the NW_Seafood table puts it into a DataSet which is used to
    ' bind to a DataGrid for display. Custom style objects are used to give the 
    ' DataGrid a nice appearance.
    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        If IsNothing(dgSeafood.DataSource) Then

            Dim strSQL As String = _
                "USE HowToDemo" & vbCrLf & _
                "SELECT * " & _
                "FROM GetSeafood"

            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in SQL Server, or be part of the Administrators
                ' group for this to work.
                Dim northwindConnection As New SqlConnection(connectionString)

                ' A SqlCommand object is used to execute the SQL commands.
                Dim cmd As New SqlCommand(strSQL, northwindConnection)

                ' The SqlDataAdapter is responsible for using a SqlCommand object to 
                ' fill a DataSet.
                Dim da As New SqlDataAdapter(cmd)
                Dim dsSeafood As New DataSet()
                da.Fill(dsSeafood, "Seafood")

                ' Set the DataGrid caption, bind it to the DataSet, and then make it
                ' Visible (recall Visible was set to False in the Form load event 
                ' handler). If you don't set Visible = True when it was previously 
                ' set to false, the DataGrid will still appear, but the scroll bar 
                ' will be missing, which can be rather puzzling.
                With dgSeafood
                    .CaptionText = "Northwind Seafood"
                    ' Notice here that instead of using the DataSet table name, 
                    ' "Seafood", the alternate syntax of table index is used.
                    .DataSource = dsSeafood.Tables(0)
                    .Visible = True
                End With


                ' Use a table style object to apply custom formatting to the 
                ' DataGrid.
                Dim dgTableStyle1 As New DataGridTableStyle()
                With dgTableStyle1
                    .AlternatingBackColor = Color.Lavender
                    .BackColor = Color.WhiteSmoke
                    .ForeColor = Color.MidnightBlue
                    .GridLineColor = Color.Gainsboro
                    .GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
                    .HeaderBackColor = Color.MidnightBlue
                    .HeaderFont = New Font("Tahoma", 8.0!, FontStyle.Bold)
                    .HeaderForeColor = Color.WhiteSmoke
                    .LinkColor = Color.Teal
                    ' Do not forget to set the MappingName property. 
                    ' Without this, the DataGridTableStyle properties
                    ' and any associated DataGridColumnStyle objects
                    ' will have no effect.
                    .MappingName = "Seafood"
                    .SelectionBackColor = Color.CadetBlue
                    .SelectionForeColor = Color.WhiteSmoke
                End With

                ' Use column style objects to apply formatting specific to each 
                ' column.
                Dim grdColStyle1 As New DataGridTextBoxColumn()
                With grdColStyle1
                    .HeaderText = "ID#"
                    .MappingName = "ProductID"
                    .Width = 50
                End With

                Dim grdColStyle2 As New DataGridTextBoxColumn()
                With grdColStyle2
                    .HeaderText = "Name"
                    .MappingName = "ProductName"
                    .Width = 180
                End With

                Dim grdColStyle3 As New DataGridTextBoxColumn()
                With grdColStyle3
                    .HeaderText = "Quantity/Unit"
                    .MappingName = "QuantityPerUnit"
                    .Width = 140
                End With

                Dim grdColStyle4 As New DataGridTextBoxColumn()
                With grdColStyle4
                    .HeaderText = "Price"
                    .MappingName = "UnitPrice"
                    .Width = 70
                End With

                ' Add the column style objects to the tables style's column styles 
                ' collection. If you fail to do this the column styles will not 
                ' apply.
                dgTableStyle1.GridColumnStyles.AddRange _
                    (New DataGridColumnStyle() _
                    {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4})
                ' Add the table style object to the DataGrid's table styles 
                ' collection. Again, failure to add the style to the collection 
                ' will cause the style to not take effect.
                dgSeafood.TableStyles.Add(dgTableStyle1)

            Catch sqlExc As SqlException
                MessageBox.Show(sqlExc.ToString, "SQL Exception Error!", _
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    ' Handles the click event for the Populate button. This handler executes the
    ' stored procedure that fills the NW_Seafood table with product info from the
    ' Northwind database Products table.
    Private Sub btnPopulate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPopulate.Click

        Dim strSQL As String = "EXECUTE HowToDemo.dbo.AddSeafood"

        Try
            ' The SqlConnection class allows you to communicate with SQL Server.
            ' The constructor accepts a connection string as an argument.  This
            ' connection string uses Integrated Security, which means that you 
            ' must have a login in SQL Server, or be part of the Administrators
            ' group for this to work.
            Dim northwindConnection As New SqlConnection(connectionString)

            ' A SqlCommand object is used to execute the SQL commands.
            Dim cmd As New SqlCommand(strSQL, northwindConnection)

            ' Open the connection, execute the command, and close the connection.
            ' It is more efficient to ExecuteNonQuery when data is not being 
            ' returned.
            northwindConnection.Open()
            cmd.ExecuteNonQuery()
            northwindConnection.Close()

            ' Show the controls for the next step.
            lblArrow5.Visible = True
            lblStep6.Enabled = True
            btnDisplay.Enabled = True

            MessageBox.Show("Table successfully populated.", _
                "Data Addition Status", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch sqlExc As SqlException
            MessageBox.Show(sqlExc.ToString, "SQL Exception Error!", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Handles the Form load event.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResetUI()
    End Sub
End Class