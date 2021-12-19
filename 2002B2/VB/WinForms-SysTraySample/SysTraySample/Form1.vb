Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
    Inherits System.Windows.Forms.Form
    
    'notifyicon icons
    Private mSmileIcon As Icon = New Icon("face02.ico")
    Private mFrownIcon As Icon = New Icon("face04.ico")
    Private mSmileDisplayed As Boolean
    
    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

        'TODO: Add any initialization after the InitializeComponent() call
        
        'this form isn't used directly so hide it immediately
        Me.Hide()
        
        'setup the tray icon
        Initializenotifyicon()
    End Sub
    
    Private Sub Initializenotifyicon()
        'setup the default icon
        notifyicon = New System.Windows.Forms.NotifyIcon()
        NotifyIcon.Icon = mSmileIcon
        NotifyIcon.Text = "Right Click for the menu"
        NotifyIcon.Visible = True
        mSmileDisplayed = True

        'Insert all MenuItem objects into an array and add them to
        'the context menu simultaneously
        Dim MenuItems(3) As MenuItem
        MenuItems(0) = New MenuItem("Show Form...", New EventHandler(AddressOf Me.ShowFormSelect))
        MenuItems(0).DefaultItem = True
        MenuItems(1) = New MenuItem("Toggle Image", New EventHandler(AddressOf Me.ToggleImageSelect))
        MenuItems(2) = New MenuItem("-")
        MenuItems(3) = New MenuItem("Exit", New EventHandler(AddressOf Me.ExitSelect))
        Dim notifyiconMnu As ContextMenu = New ContextMenu(MenuItems)
        notifyicon.ContextMenu = notifyiconMnu
    End Sub

    Public Sub ShowFormSelect(ByVal sender As Object, ByVal e As System.EventArgs)
        'Display the settings dialog
        Dim SettingsForm As New SettingsForm()
        SettingsForm.ShowDialog()

    End Sub

    Public Sub ToggleImageSelect(ByVal sender As Object, ByVal e As System.EventArgs)
        'called when the user selects the 'Toggle Image' context menu

        'determine which icon is currently visible and switch it
        If mSmileDisplayed Then
            'called when the user selects the 'Show Form' context menu
            NotifyIcon.Icon = mFrownIcon
            NotifyIcon.Text = "Sad"
            mSmileDisplayed = False
        Else
            NotifyIcon.Icon = mSmileIcon
            NotifyIcon.Text = "Happy"
            mSmileDisplayed = True
        End If

    End Sub

    Public Sub ExitSelect(ByVal sender As Object, ByVal e As System.EventArgs)
        'called when the user selects the 'Exit' context menu

        'hide the tray icon
        NotifyIcon.Visible = False

        'close up
        Me.Close()
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents notifyicon As System.Windows.Forms.NotifyIcon

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.notifyicon = New System.Windows.Forms.NotifyIcon()

        '@design Me.TrayHeight = 90
        '@design Me.TrayLargeIcon = False
        '@design Me.SnapToGrid = False
        '@design Me.TrayAutoArrange = True
        '@design notifyicon.SetLocation(New System.Drawing.Point(7, 7))
        notifyicon.Text = ""
        notifyicon.Visible = True

        Me.MaximizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Enabled = False
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.ControlBox = False
        Me.MinimizeBox = False
        Me.ClientSize = New System.Drawing.Size(1, 7)
        Me.Opacity = 0#

    End Sub

#End Region

End Class
