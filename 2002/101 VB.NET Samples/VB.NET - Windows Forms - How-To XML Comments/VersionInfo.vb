'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

Imports System.Reflection
Imports System.Windows.Forms


Public Class VersionInfo : Inherits Form
    ' A form for comparing the version info between the Assembly and
    ' XML Documentation files.  A property grid is used to display an instance
    ' of the VersionProperties class.

    Private m_VersionProperties As VersionProperties    'The instance to display in the property grid.


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal versionProperties As VersionProperties)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        m_VersionProperties = versionProperties

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
    Public WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents VersionInfoPropertyGrid As System.Windows.Forms.PropertyGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VersionInfo))
        Me.VersionInfoPropertyGrid = New System.Windows.Forms.PropertyGrid()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'VersionInfoPropertyGrid
        '
        Me.VersionInfoPropertyGrid.AccessibleDescription = CType(resources.GetObject("VersionInfoPropertyGrid.AccessibleDescription"), String)
        Me.VersionInfoPropertyGrid.AccessibleName = CType(resources.GetObject("VersionInfoPropertyGrid.AccessibleName"), String)
        Me.VersionInfoPropertyGrid.Anchor = CType(resources.GetObject("VersionInfoPropertyGrid.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.VersionInfoPropertyGrid.BackgroundImage = CType(resources.GetObject("VersionInfoPropertyGrid.BackgroundImage"), System.Drawing.Image)
        Me.VersionInfoPropertyGrid.CommandsVisibleIfAvailable = True
        Me.VersionInfoPropertyGrid.Dock = CType(resources.GetObject("VersionInfoPropertyGrid.Dock"), System.Windows.Forms.DockStyle)
        Me.VersionInfoPropertyGrid.Enabled = CType(resources.GetObject("VersionInfoPropertyGrid.Enabled"), Boolean)
        Me.VersionInfoPropertyGrid.Font = CType(resources.GetObject("VersionInfoPropertyGrid.Font"), System.Drawing.Font)
        Me.VersionInfoPropertyGrid.HelpVisible = CType(resources.GetObject("VersionInfoPropertyGrid.HelpVisible"), Boolean)
        Me.VersionInfoPropertyGrid.ImeMode = CType(resources.GetObject("VersionInfoPropertyGrid.ImeMode"), System.Windows.Forms.ImeMode)
        Me.VersionInfoPropertyGrid.LargeButtons = False
        Me.VersionInfoPropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar
        Me.VersionInfoPropertyGrid.Location = CType(resources.GetObject("VersionInfoPropertyGrid.Location"), System.Drawing.Point)
        Me.VersionInfoPropertyGrid.Name = "VersionInfoPropertyGrid"
        Me.VersionInfoPropertyGrid.RightToLeft = CType(resources.GetObject("VersionInfoPropertyGrid.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.VersionInfoPropertyGrid.Size = CType(resources.GetObject("VersionInfoPropertyGrid.Size"), System.Drawing.Size)
        Me.VersionInfoPropertyGrid.TabIndex = CType(resources.GetObject("VersionInfoPropertyGrid.TabIndex"), Integer)
        Me.VersionInfoPropertyGrid.Text = resources.GetString("VersionInfoPropertyGrid.Text")
        Me.VersionInfoPropertyGrid.ToolbarVisible = False
        Me.VersionInfoPropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window
        Me.VersionInfoPropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText
        Me.VersionInfoPropertyGrid.Visible = CType(resources.GetObject("VersionInfoPropertyGrid.Visible"), Boolean)
        '
        'Button1
        '
        Me.Button1.AccessibleDescription = CType(resources.GetObject("Button1.AccessibleDescription"), String)
        Me.Button1.AccessibleName = CType(resources.GetObject("Button1.AccessibleName"), String)
        Me.Button1.Anchor = CType(resources.GetObject("Button1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Dock = CType(resources.GetObject("Button1.Dock"), System.Windows.Forms.DockStyle)
        Me.Button1.Enabled = CType(resources.GetObject("Button1.Enabled"), Boolean)
        Me.Button1.FlatStyle = CType(resources.GetObject("Button1.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.Button1.Font = CType(resources.GetObject("Button1.Font"), System.Drawing.Font)
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = CType(resources.GetObject("Button1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Button1.ImageIndex = CType(resources.GetObject("Button1.ImageIndex"), Integer)
        Me.Button1.ImeMode = CType(resources.GetObject("Button1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Button1.Location = CType(resources.GetObject("Button1.Location"), System.Drawing.Point)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = CType(resources.GetObject("Button1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Button1.Size = CType(resources.GetObject("Button1.Size"), System.Drawing.Size)
        Me.Button1.TabIndex = CType(resources.GetObject("Button1.TabIndex"), Integer)
        Me.Button1.Text = resources.GetString("Button1.Text")
        Me.Button1.TextAlign = CType(resources.GetObject("Button1.TextAlign"), System.Drawing.ContentAlignment)
        Me.Button1.Visible = CType(resources.GetObject("Button1.Visible"), Boolean)
        '
        'VersionInfo
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.VersionInfoPropertyGrid})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimizeBox = False
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "VersionInfo"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub VersionInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'When the form is loaded, put the object in the property grid.
        VersionInfoPropertyGrid.SelectedObject = m_VersionProperties
    End Sub

End Class

Public Class VersionData
    ' This class holds the version data for a file.

    Public Name As String
    Public Version As String
    Public FullName As String

    Sub New(ByVal Name As String, ByVal Version As String, ByVal FullName As String)
        'Build version info from strings.
        Me.Name = Name
        Me.Version = Version
        Me.FullName = FullName
    End Sub

    Sub New(ByVal AsmInfo As AssemblyName)
        'Build version info from a reflection object.
        Me.Name = AsmInfo.Name
        Me.Version = AsmInfo.Version.ToString
        Me.FullName = AsmInfo.FullName
    End Sub
End Class

Public Class VersionProperties
    ' A class specifically designed for use in a property grid.  It exposes
    ' the fields of a VersionData object as unique properties.

    Private m_AsmData As VersionData
    Private m_XMLData As VersionData

    Sub New(ByVal AsmData As VersionData)
        'Use just the assembly version info.
        m_AsmData = AsmData
        m_XMLData = New VersionData("Not Loaded", "Not Loaded", "Not Loaded")
    End Sub

    Sub New(ByVal AsmData As VersionData, ByVal XMLData As VersionData)
        'Use version info from both files.
        m_AsmData = AsmData
        m_XMLData = XMLData
    End Sub

    <System.ComponentModel.Category("Assembly")> _
    Public ReadOnly Property AssemblyName() As String
        Get
            Return m_AsmData.Name
        End Get
    End Property

    <System.ComponentModel.Category("Assembly")> _
    Public ReadOnly Property AssemblyVersion() As String
        Get
            Return m_AsmData.Version
        End Get
    End Property

    <System.ComponentModel.Category("Assembly")> _
    Public ReadOnly Property AssemblyFullName() As String
        Get
            Return m_AsmData.FullName
        End Get
    End Property

    <System.ComponentModel.Category("XML Documentation File")> _
    Public ReadOnly Property XMLName() As String
        Get
            Return m_XMLData.Name
        End Get
    End Property

    <System.ComponentModel.Category("XML Documentation File")> _
    Public ReadOnly Property XMLVersion() As String
        Get
            Return m_XMLData.Version
        End Get
    End Property

    <System.ComponentModel.Category("XML Documentation File")> _
    Public ReadOnly Property XMLFullName() As String
        Get
            Return m_XMLData.FullName
        End Get
    End Property

End Class
