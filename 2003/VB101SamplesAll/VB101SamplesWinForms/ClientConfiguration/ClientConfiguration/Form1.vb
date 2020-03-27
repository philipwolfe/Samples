Imports system.Configuration

Public Class Form1

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add a setting at runtime.
        PrepareSettings()

    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisplayUser()
        LoadSettings()
    End Sub

    Public Sub DisplayUser()
        Dim currentUser As System.Security.Principal.WindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
        userIdentityTextBox.Text = currentUser.Name
    End Sub

    ' Typically, Application and User settings will be 
    ' defined at design time, in which case they are
    ' accessible via the strongly typed Settings class.
    ' But, it is possible to add settings programmatically,
    ' though they will not be saved with the 
    ' Properties.Settings.Default.Properties.Save method call.
    Public Sub PrepareSettings()

        ' For dynamically added setings, make sure the setting doesn't 
        ' exist already, for future proofing.
        If My.Settings.Properties("comboBox1DefaultSetting") Is Nothing Then

            ' Create a new setting based upon the checkBox1 setting
            ' and change only those properties that are different
            ' Alternately, if building up a SettingsProperty from scratch,
            ' then you need to set the attribute for user or attribute scoped.
            Dim comboBox1DefaultSetting As New SettingsProperty("comboBox1DefaultSetting")
            comboBox1DefaultSetting.PropertyType = GetType(String)
            comboBox1DefaultSetting.DefaultValue = "Ipsum"
            My.Settings.Properties.Add(comboBox1DefaultSetting)
        End If
    End Sub

    Public Sub LoadSettings()

        ' Retrieve and set the location of the ToolStrips
        ToolStripManager.LoadSettings(Me)

        ' userBoolSetting was defined at design time using the Settings Designer window.
        ' So its value is available via the Settings class.
        ' Note the setting value is a boolean.  Settings in 
        ' Visual Studio 2005 are strongly typed, and support custom types and objects.
        Me.checkBox1.Checked = My.Settings.userBoolSetting

        ' comboBox1DefaultSetting was defined above, dynamically,
        ' and so it is not available in the Settings class.
        ' Must use My.Settings.Properties
        Me.comboBox1.Text = My.Settings.Properties("comboBox1DefaultSetting").DefaultValue.ToString()

        Me.userStringTextBox.Text = My.Settings.userStringSetting
        Me.userIntNumPicker.Value = My.Settings.userIntSetting

        Me.appStringTextBox.Text = My.Settings.appStringSetting
        Me.appIntNumPicker.Value = My.Settings.appIntSetting
    End Sub

    Public Sub SaveSettings()

        ' Save the location of the ToolStrips
        ToolStripManager.SaveSettings(Me)

        ' Save changed settings
        My.Settings.Save()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveSettings()
    End Sub

    Private Sub saveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveToolStripButton.Click
        SaveSettings()
    End Sub

    Private Sub setCheckBox1DefaultButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setCheckBox1DefaultButton.Click
        My.Settings.userBoolSetting = checkBox1.Checked
    End Sub

    Private Sub setUserStringDefaultButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setUserStringDefaultButton.Click
        My.Settings.userStringSetting = userStringTextBox.Text
    End Sub

    Private Sub setUserIntDefaultButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setUserIntDefaultButton.Click
        My.Settings.userIntSetting = CInt(userIntNumPicker.Value)
    End Sub

End Class
