Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

'Periodically obtains information about a specified POP3 account
'and provides a tray icon to interface with the application.
'Pop3CheckerHostForm acts as a host to the tray icon and refresh timer,
'which checks the POP3 account for changes upon each tick.
Public Class Pop3CheckerHostForm
    Inherits System.Windows.Forms.Form
    
    'TrayIcon status icons
    Private mNoMessagesIcon As Icon = New Icon("basket16.ico")
    Private mNewMessagesIcon As Icon = New Icon("newenv16.ico")
    
    'Pop3Client structure that holds number of messages
    Private mAccountSummary As Pop3AccountSummary
    
    'Pop3CheckerSettingsForm properties for Pop3Client
    Private mHostName As String
    Private mHostPort As Integer
    Private mUserName As String
    Private mUserPassword As String
    Private mConnectionTimeout As Integer
    Private mRefreshInterval As Integer
    
    'Disables activity when processing previous commands.
    Private mIsTrayIconDisabled As Boolean
    
    Public Sub New()
        MyBase.New()
        
        Pop3CheckerHostForm = Me
        
        'This call is required by the Win Form Designer.
        InitializeComponent()
        
        'Host form is not used directly,
        'so it can be hidden immediately.
        Me.Hide()
        
        'If settings were obtained, initialize app.
        'Otherwise, exit.
        If GetSettings() Then
            InitializeTrayIcon()
            If GetAccountSummary() Then
                'mAccountSummary info was obtained so change the TrayIcon's status
                'and start the timer.
                UpdateTrayIcon()
                'mRefreshInterval is stored in seconds, so convert to milliseconds.
                RefreshTimer.Interval = mRefreshInterval * 1000
                RefreshTimer.Enabled = True
            End If
        Else
            Me.Close()
        End If
    End Sub
    
    'Obtains settings from Pop3CheckerSettingsForm. If registry entries are
    'absent, it is assumed that this is the first time the app has been run.
    Private Function GetSettings(Optional ByVal alwaysShowDialog As Boolean = False) As Boolean
        Dim isConfigLoaded As Boolean
        Dim settingsForm As Pop3CheckerSettingsForm = New Pop3CheckerSettingsForm()
        
        If alwaysShowDialog Then
            settingsForm.LoadSettings()
            settingsForm.ShowDialog()
        End If
        
        If settingsForm.LoadSettings() Then
            isConfigLoaded = True
        Else
            'Settings could not be loaded, so assume that the app has never been run before.
            msgbox( _
                "It appears that this is the first time you have run POP3 Checker. Welcome." + _
                ControlChars.CrLf + ControlChars.CrLf + _
                "Please note that this version of POP3 Checker DOES NOT ENCRYPT your POP3 " + _
                "account password IN ANY WAY." + _
                ControlChars.CrLf + _
                "Your password is EASILY READABLE in the registry " + _
                "and in network traffic, so choose your settings carefully!" + _
                ControlChars.CrLf + ControlChars.CrLf + _
                "Next, the Settings dialog box will appear " + _
                "where you can customize POP3 Checker.", _
                MsgBoxStyle.Exclamation, _
                "Welcome to POP3 Checker" _
            )
            settingsForm.ShowDialog()
            'The next line will execute only after settingsForm has closed.
            'If settings are still unloadable, exit.
            If settingsForm.LoadSettings() Then
                isConfigLoaded = True
            Else
                msgbox( _
                    "Some settings were not recorded in the registry " + _
                    "so POP3 Checker will now close.", _
                    MsgBoxStyle.Information, _
                    "Some Settings Not Made" _
                )
            End If
        End If
        
        'Settings were eventually loaded, so copy their contents
        'before settingsForm falls out of scope.
        If isConfigLoaded Then
            ImportSettings(settingsForm)
        End If
        
        Return isConfigLoaded
    End Function
    
    'Copies Pop3CheckerSettingsForm properties to local members.
    Private Sub ImportSettings(ByRef settingsForm As Pop3CheckerSettingsForm)
        mHostName = settingsForm.HostName
        mHostPort = settingsForm.HostPort
        mUserName = settingsForm.UserName
        mUserPassword = settingsForm.UserPassword
        mConnectionTimeout = settingsForm.ConnectionTimeout
        mRefreshInterval = settingsForm.RefreshInterval
    End Sub
    
    'Sets up TrayIcon and its context menu
    Private Sub InitializeTrayIcon()
        TrayIcon = New System.Windows.Forms.NotifyIcon()
        TrayIcon.Icon = mNoMessagesIcon
        TrayIcon.Visible = True
        'Insert all MenuItem objects into an array and add them to
        'the context menu simultaneously
        Dim mnuItms(3) As MenuItem
        mnuItms(0) = New MenuItem("Check Now", New EventHandler(AddressOf Me.CheckNowSelect))
        mnuItms(0).DefaultItem = True
        mnuItms(1) = New MenuItem("Settings...", New EventHandler(AddressOf Me.SettingsSelect))
        mnuItms(2) = New MenuItem("-")
        mnuItms(3) = New MenuItem("Exit", New EventHandler(AddressOf Me.ExitSelect))
        Dim trayIconMnu As ContextMenu = New ContextMenu(mnuItms)
        TrayIcon.ContextMenu = trayIconMnu
    End Sub
    
    'Instantiates Pop3Client to populate mAccountSummary
    Private Function GetAccountSummary() As Boolean
        'mConnectionTimeout is stored in seconds, so convert to milliseconds.
        Dim client As New Pop3Client( _
            mHostName, _
            mUserName, _
            mUserPassword, _
            mHostPort, _
            mConnectionTimeout _
        )
        Dim failed As Boolean
        
        If client.Connect() Then
            If client.Authenticate() Then
                mAccountSummary = client.GetAccountSummary()
                'Explicitly quit and disconnect to free resources
                'sooner, but client's Finalize also does this --
                'it just may do it later rather than sooner.
                client.Disconnect()
            Else
                MsgBox( _
                    "Could not authenticate as """ + mUserName + _
                    """ with the specified password.", _
                    MsgBoxStyle.Exclamation, _
                    "Authentication Failed" _
                )
                failed = True
            End If
        Else
            MsgBox( _
                "Could not connect to """ + mHostName + _
                """ on port " + mHostPort.ToString + ".", _
                MsgBoxStyle.Exclamation, _
                "Connection Failed" _
            )
            failed = True
        End If
        
        Return Not failed
    End Function
    
    'Modifies icon and tooltip text to reflect mAccountSummary
    Private Sub UpdateTrayIcon()
        If mAccountSummary.MessageCount = 0 Then
            TrayIcon.Icon = mNoMessagesIcon
            TrayIcon.Text = "No messages"
        Else
            TrayIcon.Icon = mNewMessagesIcon
            'Take care to use singular/plural tooltip text depending on message count
            If mAccountSummary.MessageCount = 1 Then
                TrayIcon.Text = mAccountSummary.MessageCount.ToString + " message"
            Else
                TrayIcon.Text = mAccountSummary.MessageCount.ToString + " messages"
            End If
        End If
    End Sub
    
    'Executes every mRefreshInterval seconds.
    Public Sub RefreshTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles RefreshTimer.Tick
        RefreshTimer.Stop()
        If GetAccountSummary() Then
            UpdateTrayIcon()
            RefreshTimer.Start()
        End If
    End Sub
    
    'Executes when "Check Now" menu item is selected from TrayIcon's context menu.
    Public Sub CheckNowSelect(ByVal sender As Object, ByVal e As System.EventArgs)
        RefreshTimer.Stop()
        If GetAccountSummary() Then
            UpdateTrayIcon()
            RefreshTimer.Start()
        End If
    End Sub
    
    'Executes when TrayIcon is double-clicked.
    Public Sub TrayIcon_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrayIcon.DoubleClick
        RefreshTimer.Stop()
        If GetAccountSummary() Then
            UpdateTrayIcon()
            RefreshTimer.Start()
        End If
    End Sub
    
    'Executes when "Settings" menu item is selected from TrayIcon's context menu.
    Public Sub SettingsSelect(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not mIsTrayIconDisabled Then
            mIsTrayIconDisabled = True
            RefreshTimer.Stop()
            If GetSettings(True) Then
                If GetAccountSummary() Then
                    UpdateTrayIcon()
                    RefreshTimer.Interval = mRefreshInterval * 1000
                    RefreshTimer.Start()
                End If
            End If
            mIsTrayIconDisabled = False
        End If
    End Sub
    
    'Executes when "Exit" menu item is selected from TrayIcon's context menu.
    Public Sub ExitSelect(ByVal sender As Object, ByVal e As System.EventArgs)
        RefreshTimer.Stop()
        TrayIcon.Visible = False
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

    Private WithEvents RefreshTimer As System.Windows.Forms.Timer
    Private WithEvents TrayIcon As System.Windows.Forms.NotifyIcon

    Dim WithEvents Pop3CheckerHostForm As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon()
        Me.RefreshTimer = New System.Windows.Forms.Timer(components)

        '@design Me.TrayHeight = 90
        '@design Me.TrayLargeIcon = False
        '@design Me.SnapToGrid = False
        '@design Me.TrayAutoArrange = True
        '@design TrayIcon.SetLocation(New System.Drawing.Point(7, 7))
        TrayIcon.Text = ""
        TrayIcon.Visible = True

        '@design RefreshTimer.SetLocation(New System.Drawing.Point(90, 7))

        Me.MaximizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.AutoScale = False
        Me.Enabled = False
        Me.AccessibleRole = AccessibleRole.None
        Me.ShowInTaskbar = False
        Me.CausesValidation = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.ControlBox = False
        Me.MinimizeBox = False
        Me.ClientSize = New System.Drawing.Size(0, 0)
        Me.Opacity = 0#

    End Sub

#End Region
End Class
