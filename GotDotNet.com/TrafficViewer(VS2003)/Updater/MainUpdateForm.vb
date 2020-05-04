Option Strict On
Public Class MainUpdateForm
    Inherits System.Windows.Forms.Form
    Private Count As Integer = 1
    Private SettingsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TrafficViewer\Settings.dat"
    Private TempFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TrafficViewer\Temp\"
    Private NewTrafficViewerFullPath As String = TempFolder & "NewTrafficViewer.exe"
    Private Key As Microsoft.Win32.RegistryKey
    Private InstalledPath As String
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'Enable visual styles for systems running Windows XP.
        If Environment.OSVersion.Version.ToString(2) > "5.0" AndAlso OSFeature.Feature.IsPresent(OSFeature.Themes) Then
            Application.EnableVisualStyles()
            Application.DoEvents()
        End If
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
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents BrowseButton As System.Windows.Forms.Button
    Friend WithEvents InstallFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents InstallPath As System.Windows.Forms.TextBox
    Friend WithEvents Message As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.NextButton = New System.Windows.Forms.Button
        Me.Message = New System.Windows.Forms.Label
        Me.InstallPath = New System.Windows.Forms.TextBox
        Me.BrowseButton = New System.Windows.Forms.Button
        Me.InstallFolder = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'NextButton
        '
        Me.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NextButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NextButton.Location = New System.Drawing.Point(323, 208)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(93, 32)
        Me.NextButton.TabIndex = 0
        Me.NextButton.Text = " Next >"
        '
        'Message
        '
        Me.Message.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Message.Location = New System.Drawing.Point(16, 8)
        Me.Message.Name = "Message"
        Me.Message.Size = New System.Drawing.Size(408, 112)
        Me.Message.TabIndex = 1
        Me.Message.Text = "Welcome to the TrafficViewer Updater.  Click Next to continue."
        Me.Message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InstallPath
        '
        Me.InstallPath.Location = New System.Drawing.Point(24, 128)
        Me.InstallPath.Name = "InstallPath"
        Me.InstallPath.Size = New System.Drawing.Size(384, 20)
        Me.InstallPath.TabIndex = 3
        Me.InstallPath.Text = "C:\Program Files\TrafficViewer"
        Me.InstallPath.Visible = False
        '
        'BrowseButton
        '
        Me.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BrowseButton.Location = New System.Drawing.Point(328, 156)
        Me.BrowseButton.Name = "BrowseButton"
        Me.BrowseButton.Size = New System.Drawing.Size(80, 24)
        Me.BrowseButton.TabIndex = 4
        Me.BrowseButton.Text = "Browse"
        Me.BrowseButton.Visible = False
        '
        'InstallFolder
        '
        Me.InstallFolder.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'MainUpdateForm
        '
        Me.AcceptButton = Me.NextButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 253)
        Me.Controls.Add(Me.BrowseButton)
        Me.Controls.Add(Me.InstallPath)
        Me.Controls.Add(Me.Message)
        Me.Controls.Add(Me.NextButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "MainUpdateForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traffic Viewer Updater."
        Me.ResumeLayout(False)

    End Sub

#End Region
   
    Private Sub MainUpdateForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Check that the new executable exists.
        If Not IO.File.Exists(NewTrafficViewerFullPath) Then
            MessageBox.Show("Unable to locate the new downloaded executable.  Updater will now close", _
            "New TrafficViewer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End If
    End Sub

    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click
        Select Case Count
            Case 1
                Message.Text = "Please wait..."
                Me.Refresh()
                'kill any instances of TrafficViewer
                Dim p As Process
                If Diagnostics.Process.GetProcessesByName("TrafficViewer").Length > 0 Then
                    For Each p In Diagnostics.Process.GetProcessesByName("TrafficViewer")
                        p.Kill()
                    Next
                End If
                Try
                    'get installed path of current TrafficViewer
                    Key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\TrafficViewer", False)
                    If Not Key Is Nothing Then
                        InstalledPath = Key.GetValue("Path", "Not Found").ToString
                    End If
                    'verify path
                    If InstalledPath = "Not Found" OrElse Not IO.Directory.Exists(InstalledPath) Then
                        InstalledPath = ""
                    End If
                Catch ex As Security.SecurityException
                    InstalledPath = ""
                End Try
                'Set path to copy application to
                If Not InstalledPath = "" Then
                    InstallPath.Text = InstalledPath
                End If
                Message.Text = "Updater will now install the newest TrafficViewer " & _
                "to the path listed in the box below.  To install to another path, type " & _
                "the new path, or click the browse button.  Click Next to continue."
                InstallPath.Show()
                BrowseButton.Show()
                Count = 2
            Case 2
                Message.Text = "Please wait..."
                'Check installpath prefix.
                If InstallPath.Text.Substring(1, 2) = ":\" Then
                    'Check if drive letter is valid.
                    If IO.Directory.Exists(InstallPath.Text.Substring(0, 3)) Then
                        Message.Text = "Installing the new executable, Please wait..."
                        Try
                            'add backslash
                            If Not InstallPath.Text.EndsWith("\"c) Then
                                InstallPath.Text &= "\"
                            End If
                            'check/create new directory
                            IO.Directory.CreateDirectory(InstallPath.Text)
                            'copy new program to install path
                            IO.File.Copy(NewTrafficViewerFullPath, InstallPath.Text & "TrafficViewer.exe", True)
                            'set flag to delete temp directory and temp files
                            Dim Writer As New IO.StreamWriter(SettingsFile, False)
                            Writer.WriteLine("TempFilesDirty")
                            Writer.Close()
                        Catch ex As ArgumentException
                            MessageBox.Show(ex.Message & "  Please check the text in the path, and make the needed corrections.")
                            Exit Sub
                        Catch ex As IO.IOException
                            MessageBox.Show(ex.Message)
                            Exit Sub
                        Catch ex As Security.SecurityException
                            MessageBox.Show(ex.Message & "  Please select a path that you have access to.")
                            Exit Sub
                        End Try
                        If IO.File.Exists(InstallPath.Text & "TrafficViewer.exe") Then
                            InstallPath.Hide()
                            BrowseButton.Hide()
                            Message.Text = "TrafficViewer was updated successfully. "
                            NextButton.Text = "Finished"
                        Else
                            Message.Text = "Update has failed.  "
                            NextButton.Text = "Close"
                        End If
                        Count = 3
                    Else
                        MessageBox.Show("Invalid drive letter.  Please select an installed drive.")
                        Exit Sub
                    End If
                End If
            Case 3
                Application.Exit()
        End Select
    End Sub

    Private Sub BrowseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseButton.Click
        With InstallFolder
            .Description = "Select Install Path"
        End With
        If InstallFolder.ShowDialog() = DialogResult.OK Then
            InstallPath.Text = InstallFolder.SelectedPath
        End If
    End Sub
End Class
