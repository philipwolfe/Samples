'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports Microsoft.Win32

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
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lstResults As System.Windows.Forms.ListBox
    Friend WithEvents chkFontChanges As System.Windows.Forms.CheckBox
    Friend WithEvents chkUserPreferences As System.Windows.Forms.CheckBox
    Friend WithEvents chkPowerMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkTimeChanges As System.Windows.Forms.CheckBox
    Friend WithEvents chkScreenChanges As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.btnClear = New System.Windows.Forms.Button()
		Me.lstResults = New System.Windows.Forms.ListBox()
		Me.chkFontChanges = New System.Windows.Forms.CheckBox()
		Me.chkUserPreferences = New System.Windows.Forms.CheckBox()
		Me.chkPowerMode = New System.Windows.Forms.CheckBox()
		Me.chkTimeChanges = New System.Windows.Forms.CheckBox()
		Me.chkScreenChanges = New System.Windows.Forms.CheckBox()
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
		'btnClear
		'
		Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
		Me.btnClear.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btnClear.Location = New System.Drawing.Point(448, 8)
		Me.btnClear.Name = "btnClear"
		Me.btnClear.TabIndex = 21
		Me.btnClear.Text = "&Clear"
		'
		'lstResults
		'
		Me.lstResults.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.lstResults.IntegralHeight = False
		Me.lstResults.Location = New System.Drawing.Point(232, 8)
		Me.lstResults.Name = "lstResults"
		Me.lstResults.Size = New System.Drawing.Size(208, 123)
		Me.lstResults.TabIndex = 20
		'
		'chkFontChanges
		'
		Me.chkFontChanges.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.chkFontChanges.Location = New System.Drawing.Point(8, 104)
		Me.chkFontChanges.Name = "chkFontChanges"
		Me.chkFontChanges.Size = New System.Drawing.Size(224, 24)
		Me.chkFontChanges.TabIndex = 19
		Me.chkFontChanges.Text = "Handle Installed Font Changes"
		'
		'chkUserPreferences
		'
		Me.chkUserPreferences.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.chkUserPreferences.Location = New System.Drawing.Point(8, 80)
		Me.chkUserPreferences.Name = "chkUserPreferences"
		Me.chkUserPreferences.Size = New System.Drawing.Size(224, 24)
		Me.chkUserPreferences.TabIndex = 18
		Me.chkUserPreferences.Text = "Handle User Preference Changes"
		'
		'chkPowerMode
		'
		Me.chkPowerMode.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.chkPowerMode.Location = New System.Drawing.Point(8, 56)
		Me.chkPowerMode.Name = "chkPowerMode"
		Me.chkPowerMode.Size = New System.Drawing.Size(224, 24)
		Me.chkPowerMode.TabIndex = 17
		Me.chkPowerMode.Text = "Handle Power Mode Changes"
		'
		'chkTimeChanges
		'
		Me.chkTimeChanges.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.chkTimeChanges.Location = New System.Drawing.Point(8, 32)
		Me.chkTimeChanges.Name = "chkTimeChanges"
		Me.chkTimeChanges.Size = New System.Drawing.Size(224, 24)
		Me.chkTimeChanges.TabIndex = 16
		Me.chkTimeChanges.Text = "Handle Time Changes"
		'
		'chkScreenChanges
		'
		Me.chkScreenChanges.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.chkScreenChanges.Location = New System.Drawing.Point(8, 8)
		Me.chkScreenChanges.Name = "chkScreenChanges"
		Me.chkScreenChanges.Size = New System.Drawing.Size(224, 24)
		Me.chkScreenChanges.TabIndex = 15
		Me.chkScreenChanges.Text = "Handle Screen Changes"
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(530, 161)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.lstResults, Me.chkFontChanges, Me.chkUserPreferences, Me.chkPowerMode, Me.chkTimeChanges, Me.chkScreenChanges})
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.MinimumSize = New System.Drawing.Size(538, 192)
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
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

    End Sub
#End Region

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ' Clear all the items from the list box. 
        lstResults.Items.Clear()
    End Sub

    Private Sub chkFontChanges_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFontChanges.CheckedChanged
        If chkFontChanges.Checked Then
            AddHandler SystemEvents.InstalledFontsChanged, _
             AddressOf FontHandler
        Else
            RemoveHandler SystemEvents.InstalledFontsChanged, _
             AddressOf FontHandler
        End If
    End Sub

    Private Sub chkPowerMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPowerMode.CheckedChanged
        If chkPowerMode.Checked Then
            AddHandler SystemEvents.PowerModeChanged, _
             AddressOf PowerHandler
        Else
            RemoveHandler SystemEvents.PowerModeChanged, _
             AddressOf PowerHandler
        End If
    End Sub

    Private Sub chkScreenChanges_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScreenChanges.CheckedChanged
        If chkScreenChanges.Checked Then
            AddHandler SystemEvents.DisplaySettingsChanged, _
             AddressOf ScreenHandler
        Else
            RemoveHandler SystemEvents.DisplaySettingsChanged, _
             AddressOf ScreenHandler
        End If
    End Sub

    Private Sub chkTimeChanges_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTimeChanges.CheckedChanged
        If chkTimeChanges.Checked Then
            AddHandler SystemEvents.TimeChanged, _
             AddressOf TimeHandler
        Else
            RemoveHandler SystemEvents.TimeChanged, _
             AddressOf TimeHandler
        End If
    End Sub

    Private Sub chkUserPreferences_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUserPreferences.CheckedChanged
        If chkUserPreferences.Checked Then
            AddHandler SystemEvents.UserPreferenceChanged, _
             AddressOf PreferenceChangedHandler
        Else
            RemoveHandler SystemEvents.UserPreferenceChanged, _
             AddressOf PreferenceChangedHandler
        End If
    End Sub

    Private Sub AddToList(ByVal Text As String)
        ' Add an item to the list box on the form.
        lstResults.Items.Insert(0, Text)
    End Sub

    Private Sub FontHandler(ByVal sender As Object, ByVal e As EventArgs)
        ' Use the InstalledFontCollection class to determine the list
        ' of installed fonts.
        AddToList("Installed fonts changed.")
    End Sub

    Private Sub PowerHandler(ByVal sender As Object, ByVal e As PowerModeChangedEventArgs)
        ' e.Mode returns one of Microsoft.Win32.PowerModes.Resume, StatusChange, Suspend.
        ' You'll get StatusChange on most changes (changing from power to battery,
        ' battery power running out, and so on.
        AddToList("Power changed to: " & e.Mode.ToString)
    End Sub

    Private Sub PreferenceChangedHandler(ByVal sender As Object, ByVal e As UserPreferenceChangedEventArgs)
        ' e.Category returns one of Microsoft.Win32.UserPreferenceCategory
        ' enumeration. Values include Accessibility, Color, Desktop, and so on.
        AddToList("You changed a setting: " & e.Category.ToString)
    End Sub

    Private Sub ScreenHandler(ByVal sender As Object, ByVal e As EventArgs)
        ' Use the Screen class to retrieve information
        ' about the screen settings.
        AddToList("Screen resolution changed")
    End Sub

    Private Sub TimeHandler(ByVal sender As Object, ByVal e As EventArgs)
        AddToList("System time changed")
    End Sub
End Class