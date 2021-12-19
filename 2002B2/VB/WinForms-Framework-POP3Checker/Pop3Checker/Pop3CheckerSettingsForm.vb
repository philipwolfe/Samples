Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

'Dialog that retrieves settings from the registry, allows the user
'to change the settings, and saves the new settings back to the registry.
'This dialog is intended to be called modally.
Public Class Pop3CheckerSettingsForm
    Inherits System.Windows.Forms.Form
    
    'Defaults
    Private Const mcDefaultConnectionTimeout As Integer = 30
    Private Const mcDefaultRefreshInterval As Integer = 600
    Private Const mcDefaultHostPort As Integer = 110
    Private Const mcApplicationName As String = "POP3 Checker"
    
    Public Sub New()
        MyBase.New()
        
        'This call is required by the Win Form Designer.
        InitializeComponent()
        
        'Set up form's controls with default values.
        InitializeSettings()
    End Sub
    
    'Initialize form's controls with default values.
    Public Sub InitializeSettings()
        Me.HostPortEntry.Value = Convert.ToDecimal(mcDefaultHostPort)
        Me.UserNameEntry.Text = SystemInformation.UserName
        Me.ConnectionTimeoutEntry.Value = Convert.ToDecimal(mcDefaultConnectionTimeout)
        Me.RefreshIntervalEntry.Value = Convert.ToDecimal(mcDefaultRefreshInterval)
    End Sub
    
    'Attempts to retrieve settings from the registry and copy them to the form's controls.
    'Returns success.
    Public Function LoadSettings() As Boolean
        Dim failed As Boolean
        Dim key As Microsoft.Win32.RegistryKey = _
            Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", True).OpenSubKey(mcApplicationName, True)
        If key Is Nothing Then
            failed = True
        Else
            Dim val As Object
            With key
                'Pattern: Attempt to get a registry value via its key and set
                'an object variable to the value. Check if the returned value
                'is nothing, which probably means the registry key is not present.
                'If it is nothing, indicate failure. Otherwise, set a form control
                'to the value.
                
                val = .GetValue("Host Name")
                If val Is Nothing Then
                    failed = True
                Else
                    Me.HostNameEntry.Text = val.ToString
                End If
                val = .GetValue("Host Port")
                If val Is Nothing Then
                    failed = True
                Else
                    Me.HostPortEntry.Text = val.ToString
                End If
                val = .GetValue("User Name")
                If val Is Nothing Then
                    failed = True
                Else
                    Me.UserNameEntry.Text = val.ToString
                End If
                val = .GetValue("User Password")
                If val Is Nothing Then
                    failed = True
                Else
                    Me.UserPasswordEntry.Text = val.ToString
                End If
                val = .GetValue("Connection Timeout")
                If val Is Nothing Then
                    failed = True
                Else
                    Me.ConnectionTimeoutEntry.Text = val.ToString
                End If
                val = .GetValue("Refresh Interval")
                If val Is Nothing Then
                    failed = True
                Else
                    Me.RefreshIntervalEntry.Text = val.ToString
                End If
            End With
            Return Not failed
        End If
    End Function
    
    'Saves settings from the form's controls to the registry.
    Public Sub SaveSettings()
        'Cache the parent key because we'll need it twice if our key is not present.
        Dim parentKey As Microsoft.Win32.RegistryKey = _
            Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", True)
        Dim key As Microsoft.Win32.RegistryKey = parentKey.OpenSubKey(mcApplicationName, True)
        
        If key Is Nothing Then
            key = parentKey.CreateSubKey(mcApplicationName)
        End If
        
        With key
            .SetValue("Host Name", Me.HostNameEntry.Text)
            .SetValue("Host Port", Me.HostPortEntry.Text)
            .SetValue("User Name", Me.UserNameEntry.Text)
            .SetValue("User Password", Me.UserPasswordEntry.Text)
            .SetValue("Connection Timeout", Me.ConnectionTimeoutEntry.Text)
            .SetValue("Refresh Interval", Me.RefreshIntervalEntry.Text)
        End With
    End Sub
    
    'Executes when the Cancel button is pressed.
    'Closes the form.
    Protected Sub CancelAction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelAction.click
        Me.Close()
    End Sub

    'Executes when the Apply button is pressed.
    'Saves the settings to the registry.
    Protected Sub ApplyAction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ApplyAction.click
        SaveSettings()
    End Sub

    'Executes when the OK button is pressed.
    'Saves the settings to the registry and closes the form.
    Protected Sub OKAction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OKAction.click
        SaveSettings()
        Me.Close()
    End Sub

#Region " Read-only properties "
    'Pattern: Read-only properties return form control values.

    ReadOnly Property HostName() As String
        Get
            Return Me.HostNameEntry.Text
        End Get
    End Property

    ReadOnly Property HostPort() As Integer
        Get
            Return Convert.ToInt32(Me.HostPortEntry.Value)
        End Get
    End Property

    ReadOnly Property UserName() As String
        Get
            Return Me.UserNameEntry.Text
        End Get
    End Property

    ReadOnly Property UserPassword() As String
        Get
            Return Me.UserPasswordEntry.Text
        End Get
    End Property

    ReadOnly Property ConnectionTimeout() As Integer
        Get
            Return Convert.ToInt32(Me.ConnectionTimeoutEntry.Value)

        End Get
    End Property

    ReadOnly Property RefreshInterval() As Integer
        Get
            Return Convert.ToInt32(Me.RefreshIntervalEntry.Value)
        End Get
    End Property

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub
#End Region

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container



    Private WithEvents HostGroup As System.Windows.Forms.GroupBox
    Private WithEvents UserGroup As System.Windows.Forms.GroupBox
    Private WithEvents MiscellaneousGroup As System.Windows.Forms.GroupBox

    Private WithEvents HostNameLabel As System.Windows.Forms.Label
    Private WithEvents HostPortLabel As System.Windows.Forms.Label
    Private WithEvents UserNameLabel As System.Windows.Forms.Label
    Private WithEvents UserPasswordLabel As System.Windows.Forms.Label
    Private WithEvents ConnectionTimeoutLabel As System.Windows.Forms.Label
    Private WithEvents RefreshIntervalLabel As System.Windows.Forms.Label

    Private WithEvents HostNameEntry As System.Windows.Forms.TextBox
    Private WithEvents HostPortEntry As System.Windows.Forms.NumericUpDown
    Private WithEvents UserNameEntry As System.Windows.Forms.TextBox
    Private WithEvents UserPasswordEntry As System.Windows.Forms.TextBox
    Private WithEvents ConnectionTimeoutEntry As System.Windows.Forms.NumericUpDown
    Private WithEvents RefreshIntervalEntry As System.Windows.Forms.NumericUpDown

    Private WithEvents OKAction As System.Windows.Forms.Button
    Private WithEvents CancelAction As System.Windows.Forms.Button
    Private WithEvents ApplyAction As System.Windows.Forms.Button

    Dim WithEvents Pop3Checker As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Pop3CheckerSettingsForm))

        Me.components = New System.ComponentModel.Container()
        Me.ConnectionTimeoutLabel = New System.Windows.Forms.Label()
        Me.UserGroup = New System.Windows.Forms.GroupBox()
        Me.UserPasswordLabel = New System.Windows.Forms.Label()
        Me.HostNameEntry = New System.Windows.Forms.TextBox()
        Me.UserNameLabel = New System.Windows.Forms.Label()
        Me.CancelAction = New System.Windows.Forms.Button()
        Me.HostGroup = New System.Windows.Forms.GroupBox()
        Me.RefreshIntervalLabel = New System.Windows.Forms.Label()
        Me.ApplyAction = New System.Windows.Forms.Button()
        Me.UserPasswordEntry = New System.Windows.Forms.TextBox()
        Me.UserNameEntry = New System.Windows.Forms.TextBox()
        Me.OKAction = New System.Windows.Forms.Button()
        Me.HostNameLabel = New System.Windows.Forms.Label()
        Me.HostPortEntry = New System.Windows.Forms.NumericUpDown()
        Me.MiscellaneousGroup = New System.Windows.Forms.GroupBox()
        Me.ConnectionTimeoutEntry = New System.Windows.Forms.NumericUpDown()
        Me.RefreshIntervalEntry = New System.Windows.Forms.NumericUpDown()
        Me.HostPortLabel = New System.Windows.Forms.Label()

        HostPortEntry.BeginInit()
        ConnectionTimeoutEntry.BeginInit()
        RefreshIntervalEntry.BeginInit()

        '@design Me.TrayHeight = 90
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        '@design Me.GridSize = New System.Drawing.Size(4, 4)
        ConnectionTimeoutLabel.Location = New System.Drawing.Point(8, 20)
        ConnectionTimeoutLabel.Text = "&Seconds to Wait for Response:"
        ConnectionTimeoutLabel.Size = New System.Drawing.Size(155, 13)
        ConnectionTimeoutLabel.AutoSize = True
        ConnectionTimeoutLabel.TabIndex = 0

        UserGroup.Location = New System.Drawing.Point(8, 84)
        UserGroup.TabIndex = 1
        UserGroup.TabStop = False
        UserGroup.Text = "User"
        UserGroup.Size = New System.Drawing.Size(276, 76)

        UserPasswordLabel.Location = New System.Drawing.Point(8, 48)
        UserPasswordLabel.Text = "User Pass&word:"
        UserPasswordLabel.Size = New System.Drawing.Size(81, 13)
        UserPasswordLabel.AutoSize = True
        UserPasswordLabel.TabIndex = 2

        HostNameEntry.Location = New System.Drawing.Point(72, 16)
        HostNameEntry.TabIndex = 1
        HostNameEntry.Size = New System.Drawing.Size(192, 20)

        UserNameLabel.Location = New System.Drawing.Point(8, 20)
        UserNameLabel.Text = "&User Name:"
        UserNameLabel.Size = New System.Drawing.Size(63, 13)
        UserNameLabel.AutoSize = True
        UserNameLabel.TabIndex = 0

        CancelAction.Location = New System.Drawing.Point(108, 248)
        CancelAction.DialogResult = System.Windows.Forms.DialogResult.Cancel
        CancelAction.Size = New System.Drawing.Size(75, 23)
        CancelAction.TabIndex = 4
        CancelAction.Text = "Cancel"

        HostGroup.Location = New System.Drawing.Point(8, 4)
        HostGroup.TabIndex = 0
        HostGroup.TabStop = False
        HostGroup.Text = "Host"
        HostGroup.Size = New System.Drawing.Size(276, 76)

        RefreshIntervalLabel.Location = New System.Drawing.Point(8, 48)
        RefreshIntervalLabel.Text = "Seconds &between Checks:"
        RefreshIntervalLabel.Size = New System.Drawing.Size(134, 13)
        RefreshIntervalLabel.AutoSize = True
        RefreshIntervalLabel.TabIndex = 2

        ApplyAction.Location = New System.Drawing.Point(208, 248)
        ApplyAction.Size = New System.Drawing.Size(75, 23)
        ApplyAction.TabIndex = 5
        ApplyAction.Text = "&Apply"

        UserPasswordEntry.Location = New System.Drawing.Point(92, 44)
        UserPasswordEntry.PasswordChar = ChrW(8226)
        UserPasswordEntry.TabIndex = 3
        UserPasswordEntry.Size = New System.Drawing.Size(172, 20)

        UserNameEntry.Location = New System.Drawing.Point(92, 16)
        UserNameEntry.TabIndex = 1
        UserNameEntry.Size = New System.Drawing.Size(172, 20)

        OKAction.Location = New System.Drawing.Point(8, 248)
        OKAction.Size = New System.Drawing.Size(75, 23)
        OKAction.TabIndex = 3
        OKAction.Text = "OK"

        HostNameLabel.Location = New System.Drawing.Point(8, 20)
        HostNameLabel.Text = "&Host Name:"
        HostNameLabel.Size = New System.Drawing.Size(62, 13)
        HostNameLabel.AutoSize = True
        HostNameLabel.TabIndex = 0

        HostPortEntry.Location = New System.Drawing.Point(72, 44)
        HostPortEntry.Maximum = New Decimal(65536#)
        HostPortEntry.Size = New System.Drawing.Size(72, 20)
        HostPortEntry.TabIndex = 3

        MiscellaneousGroup.Location = New System.Drawing.Point(8, 164)
        MiscellaneousGroup.TabIndex = 2
        MiscellaneousGroup.TabStop = False
        MiscellaneousGroup.Text = "Miscellaneous"
        MiscellaneousGroup.Size = New System.Drawing.Size(276, 76)

        ConnectionTimeoutEntry.Value = New Decimal(30#)
        ConnectionTimeoutEntry.Location = New System.Drawing.Point(164, 16)
        ConnectionTimeoutEntry.Maximum = New Decimal(300#)
        ConnectionTimeoutEntry.Size = New System.Drawing.Size(72, 20)
        ConnectionTimeoutEntry.Minimum = New Decimal(30#)
        ConnectionTimeoutEntry.TabIndex = 1
        ConnectionTimeoutEntry.Increment = New Decimal(30#)

        RefreshIntervalEntry.Value = New Decimal(1800#)
        RefreshIntervalEntry.Location = New System.Drawing.Point(164, 44)
        RefreshIntervalEntry.Maximum = New Decimal(3600#)
        RefreshIntervalEntry.Size = New System.Drawing.Size(72, 20)
        RefreshIntervalEntry.TabIndex = 3
        RefreshIntervalEntry.Increment = New Decimal(300#)

        HostPortLabel.Location = New System.Drawing.Point(8, 48)
        HostPortLabel.Text = "Host &Port:"
        HostPortLabel.Size = New System.Drawing.Size(53, 13)
        HostPortLabel.AutoSize = True
        HostPortLabel.TabIndex = 2
        Me.Text = "POP3 Checker Settings"
        Me.MaximizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = CancelAction
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.AcceptButton = OKAction
        Me.CausesValidation = False
        Me.MinimizeBox = False
        Me.ClientSize = New System.Drawing.Size(290, 279)

        Me.Controls.Add(ApplyAction)
        Me.Controls.Add(CancelAction)
        Me.Controls.Add(OKAction)
        Me.Controls.Add(HostGroup)
        Me.Controls.Add(UserGroup)
        Me.Controls.Add(MiscellaneousGroup)
        MiscellaneousGroup.Controls.Add(RefreshIntervalEntry)
        MiscellaneousGroup.Controls.Add(ConnectionTimeoutEntry)
        MiscellaneousGroup.Controls.Add(RefreshIntervalLabel)
        MiscellaneousGroup.Controls.Add(ConnectionTimeoutLabel)
        UserGroup.Controls.Add(UserPasswordLabel)
        UserGroup.Controls.Add(UserPasswordEntry)
        UserGroup.Controls.Add(UserNameEntry)
        UserGroup.Controls.Add(UserNameLabel)
        HostGroup.Controls.Add(HostPortEntry)
        HostGroup.Controls.Add(HostPortLabel)
        HostGroup.Controls.Add(HostNameEntry)
        HostGroup.Controls.Add(HostNameLabel)

        HostPortEntry.EndInit()
        ConnectionTimeoutEntry.EndInit()
        RefreshIntervalEntry.EndInit()
    End Sub

#End Region

End Class
