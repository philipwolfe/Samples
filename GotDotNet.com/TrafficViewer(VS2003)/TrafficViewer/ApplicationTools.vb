Option Strict On
Friend Class ApplicationTools
    Implements IDisposable
    Private Reader As IO.StreamReader
    Private Writer As IO.StreamWriter
    Private CallingAssembly As System.Reflection.Assembly
    Private Client As Net.WebClient
    Private CurrentVersion, UploadedVersion As Single
    Private NewViewer As String = "trafficviewer.cab"
    Private Updater As String = "updater.cab"
    Private ReadString As String
    Private TempFolder As String
    Private RandomURL As New Random
    Protected Friend ErrorReturn As Boolean

#Region " Install New Version "
    Private ProgressForm As Form
    Friend CancelUpdate As System.Windows.Forms.Button
    Friend ProgressText As System.Windows.Forms.TextBox
    Private UpdateThread As Threading.Thread
    Private UpdateError As Boolean
    Private Closing As Boolean
    Private PauseInterval As Short = 1700
    Private Delegate Sub Close_Form(ByVal FormToClose As Form)
    Private CloseFormDelegate As New Close_Form(AddressOf CloseProgressForm)
    Private AppendedText As String
    Private Delegate Sub Append_Text()
    Private AppendTextDelegate As New Append_Text(AddressOf ProgressText_AppendText)
    Private ProcessInf As New Diagnostics.ProcessStartInfo
    Private ExpandFiles As New Diagnostics.Process
    Private Elapsed As Integer


    Private Sub UpdateProgressText(ByVal NewText As String)
        AppendedText = NewText & Environment.NewLine
        ProgressForm.Invoke(AppendTextDelegate)
    End Sub

    Private Sub DownLoadFiles()
        Try
            'set flag to delete the temp directory next time application runs
            Dim w As IO.StreamWriter
            Dim SettingsFile As String
            Try
                SettingsFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TrafficViewer\Settings.dat"
                w = New IO.StreamWriter(SettingsFile)
                w.Write("TempFilesDirty")
            Catch ex As IO.IOException
            Catch ex As Security.SecurityException
            Finally
                If Not w Is Nothing Then
                    w.Close()
                End If
            End Try
            'Set temp folder path.
            TempFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TrafficViewer\Temp\"
            IO.Directory.CreateDirectory(TempFolder)
            If Closing Then Exit Sub
            'Download the updater
            Client.DownloadFile(ServerURL() & Updater, TempFolder & Updater)
            If Closing Then Exit Sub
            UpdateThread.Sleep(PauseInterval)
            UpdateProgressText(Environment.NewLine & "Download complete. ")
            'verify the download
            If Closing Then Exit Sub
            UpdateThread.Sleep(PauseInterval - 1000)
            UpdateProgressText("Verifying Updater download... ")
            If Closing Then Exit Sub
            UpdateThread.Sleep(PauseInterval - 1000)
            If IO.File.Exists(TempFolder & Updater) Then
                UpdateProgressText("Updater Verified. ")
            Else
                UpdateProgressText("Updater download failed.  Aborting update... " & Environment.NewLine)
                ProgressForm.Invoke(CloseFormDelegate)
                Exit Sub
            End If
            If Closing Then Exit Sub
            UpdateThread.Sleep(PauseInterval - 1000)
            UpdateProgressText("Downloading New TrafficViewer... ")
            'download the new executable
            Client.DownloadFile(ServerURL() & NewViewer, TempFolder & NewViewer)
            If Closing Then Exit Sub
            UpdateThread.Sleep(PauseInterval)
            UpdateProgressText("Download complete. ")
            If Closing Then Exit Sub
            UpdateThread.Sleep(PauseInterval - 1000)
            'verify the download
            UpdateProgressText("Verifying TrafficViewer download... ")
            If Closing Then Exit Sub
            UpdateThread.Sleep(PauseInterval - 1000)
            If IO.File.Exists(TempFolder & NewViewer) Then
                'Success. At this point both files were downloaded without exceeding bandwidth.
                UpdateProgressText("TrafficViewer Verified. ")
            Else
                UpdateProgressText("TrafficViewer.cab File download failed.  Aborting update... ")
                'pause to give user time to read failure message
                UpdateThread.Sleep(PauseInterval)
                'Delete the temp directory, and any files in it.
                DeleteTempFiles()
                'Close the progress form.
                ProgressForm.Invoke(CloseFormDelegate)
                Exit Sub
            End If
            If Closing Then Exit Sub
            'expand cab files in hidden processes
            ProcessInf.FileName = "expand"
            ProcessInf.WindowStyle = Diagnostics.ProcessWindowStyle.Hidden
            'set argument to expand Updater cab file
            ProcessInf.Arguments = """" & TempFolder & Updater & """" & " " & """" & TempFolder & "Updater.exe" & """"
            ExpandFiles.StartInfo = ProcessInf
            'expand updater cab file
            If Closing Then Exit Sub
            ExpandFiles.Start()
            UpdateProgressText("Expanding downloaded cab files... ")
            UpdateThread.Sleep(PauseInterval - 500)
            Elapsed = 0
            'wait maximum of 20 seconds, for the user's OS to expand "Updater.cab".
            'Updater.exe is a very small PE, so 20 seconds should provide enough
            'time for the process to exit.
            Do Until ExpandFiles.HasExited OrElse Elapsed > 200 'wait 20 seconds max.
                UpdateThread.Sleep(100)
                Elapsed += 1
            Loop
            If Not ExpandFiles.HasExited Then
                MessageBox.Show(ProgressForm, "There was a problem expanding the downloaded cab file.  Update has been cancelled.")
                'Delete the temp directory, and any files in it.
                DeleteTempFiles()
                'Close the progress form.
                ProgressForm.Invoke(CloseFormDelegate)
            Else
                'set argument to expand downloaded TrafficViewer cab file
                ProcessInf.Arguments = """" & TempFolder & NewViewer & """" & " " & """" & TempFolder & "NewTrafficViewer.exe" & """"
                ExpandFiles.StartInfo = ProcessInf
                If Closing Then Exit Sub
                'expand trafficviewer cab file
                ExpandFiles.Start()
            End If
            Elapsed = 0
            'wait maximum of 40 seconds, for the user's OS to expand "Trafficviewer.cab".
            'Trafficviewer.exe is larger, so wait 45 seconds in order to provide enough
            'time for the process to exit.
            Do Until ExpandFiles.HasExited OrElse Elapsed > 450 'wait 45 seconds max.
                UpdateThread.Sleep(100)
                Elapsed += 1
            Loop
            If Not ExpandFiles.HasExited Then
                MessageBox.Show(ProgressForm, "There was a problem expanding the downloaded cab file.  Update has been cancelled.")
                DeleteTempFiles()
                CloseFormDelegate.Invoke(ProgressForm)
                Exit Sub
            Else
                If Closing Then Exit Sub
                UpdateProgressText("Finshed expanding cab files. ")
                If Closing Then Exit Sub
                UpdateThread.Sleep(PauseInterval - 1000)
                UpdateProgressText("Verifying expanded files... ")
                If Closing Then Exit Sub
                UpdateThread.Sleep(PauseInterval - 1000)
                'verify the executables were expanded and exist in the Temp Folder
                If IO.File.Exists(TempFolder & "Updater.exe") AndAlso IO.File.Exists(TempFolder & "NewTrafficViewer.exe") Then
                    UpdateProgressText("Expanded Files verified. " & Environment.NewLine)
                    If Closing Then Exit Sub
                    UpdateThread.Sleep(PauseInterval)
                    'remove closing event from form, and add closed event
                    RemoveHandler ProgressForm.Closing, AddressOf ProgressForm_Closing
                    'hide cancel button
                    CancelUpdate.Visible = False
                    AddHandler ProgressForm.Closed, AddressOf ProgressForm_Closed
                    UpdateProgressText("Updates Successfully Downloaded. The Updater program will now start. ")
                    If Closing Then Exit Sub
                    'hide this application and start the installer.
                    UpdateThread.Sleep(2500)
                    MainViewerForm.MainForm.Hide()
                    Closing = True
                    'The added closed event of ProgressForm starts updater.exe, in case
                    'the user manually closes the form the moment before we close it.
                    CloseFormDelegate.Invoke(ProgressForm)
                Else
                    CloseFormDelegate.Invoke(ProgressForm)
                    MessageBox.Show("The update operation has failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    DeleteTempFiles()
                End If
            End If
        Catch ex As System.ComponentModel.Win32Exception
            CloseFormDelegate.Invoke(ProgressForm)
            DeleteTempFiles()
            MessageBox.Show("The update operation has failed.  " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MainViewerForm.MainForm.Show()
        Catch ex As IO.IOException
            CloseFormDelegate.Invoke(ProgressForm)
            DeleteTempFiles()
            MessageBox.Show(ex.ToString)
            MainViewerForm.MainForm.Show()
        Catch ex As Net.WebException
            CloseFormDelegate.Invoke(ProgressForm)
            DeleteTempFiles()
            'check for Web error 503, which happens when allocated bandwidth is exceeded.
            If ex.Message.IndexOf("503") > -1 Then
                MessageBox.Show("Unable to complete the download, because the web site has exceeded it alloctated bandwidth. Please try again later.", _
                "Allocated Bandwidth Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                MessageBox.Show(ex.ToString)
            End If
            MainViewerForm.MainForm.Show()
        Catch ex As NullReferenceException
            CloseFormDelegate.Invoke(ProgressForm)
            DeleteTempFiles()
            MessageBox.Show(ex.ToString)
            MainViewerForm.MainForm.Show()
        End Try
    End Sub
#Region " ProgressForm "

    Private Sub InitializeProgressForm()
        ProgressForm = New Form
        With ProgressForm
            .SuspendLayout()
            ProgressText = New System.Windows.Forms.TextBox
            CancelUpdate = New System.Windows.Forms.Button
            AddHandler .Closing, AddressOf ProgressForm_Closing
            AddHandler CancelUpdate.Click, AddressOf CancelUpdate_Click
            'ProgressText, textbox
            ProgressText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            ProgressText.Location = New System.Drawing.Point(8, 40)
            ProgressText.Multiline = True
            ProgressText.Name = "ProgressText"
            ProgressText.Size = New System.Drawing.Size(448, 240)
            ProgressText.ScrollBars = ScrollBars.Vertical
            ProgressText.TabIndex = 0
            ProgressText.Text = "Downloading Updater..."
            'CancelUpdate, button
            CancelUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            CancelUpdate.Location = New System.Drawing.Point(376, 300)
            CancelUpdate.Name = "CancelUpdate"
            CancelUpdate.Size = New System.Drawing.Size(80, 25)
            CancelUpdate.TabIndex = 1
            CancelUpdate.Text = "Cancel"
            'ProgressForm
            .AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            .ClientSize = New System.Drawing.Size(464, 333)
            .Controls.Add(CancelUpdate)
            .Controls.Add(ProgressText)
            .FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            .MaximizeBox = False
            .MinimizeBox = False
            .Name = "ProgressForm"
            .ShowInTaskbar = False
            .StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            .Text = "  Updating TrafficViewer..."
            .ResumeLayout(False)
        End With
    End Sub

    Private Sub ProgressText_AppendText()
        ProgressText.AppendText(AppendedText)
        ProgressText.Select(ProgressText.Text.LastIndexOf(".") + 1, 0)
    End Sub

    Private Sub ProgressForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not Closing Then e.Cancel = KeepOpenedOrCancel()
    End Sub

    Private Sub ProgressForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
        Diagnostics.Process.Start(TempFolder & "Updater.exe")
        Application.Exit()
    End Sub

    Private Sub CloseProgressForm(ByVal F As Form)
        F.Close()
    End Sub

    Private Function KeepOpenedOrCancel() As Boolean
        UpdateThread.Suspend()
        If MessageBox.Show("Are you sure you want to cancel the update?", "Verify Cancel Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Closing = True
            ProgressForm.Dispose()
        Else
            UpdateThread.Resume()
            Return True
        End If
    End Function

    Private Sub CancelUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If KeepOpenedOrCancel() = False Then
            Closing = True
            ProgressForm.Dispose()
        End If
    End Sub
#End Region

    Protected Friend Sub StartUpdate()
        Closing = False
        InitializeProgressForm()
        UpdateThread = New Threading.Thread(AddressOf Get_New_Version)
        UpdateThread.IsBackground = True
        UpdateThread.Start()
        ProgressForm.ShowDialog()
    End Sub

    Protected Friend Sub Get_New_Version()
        Try
            If Not ProgressForm Is Nothing Then
                DownLoadFiles()
            Else
                MessageBox.Show("ProgressForm was not instanciated.  """"StartUpdate"""" must be called. """"Get_New_Version"""" should not be called directly. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            End If
        Catch ex As System.ComponentModel.Win32Exception
            MessageBox.Show("The update operation has failed.  " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As IO.IOException
            MessageBox.Show(ex.ToString)
        Catch ex As Net.WebException
            MessageBox.Show(ex.ToString)
        Catch ex As NullReferenceException
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
#End Region

    Private ReadOnly Property ServerURL() As String
        Get
            Select Case RandomURL.Next(0, 4)
                Case 0
                    Return "http://www.geocities.com/trafficviewer/"
                Case 1
                    Return "http://www.geocities.com/trafficviewermirror_1/"
                Case 2
                    Return "http://www.geocities.com/trafficviewermirror_2/"
                Case 3
                    Return "http://www.geocities.com/trafficviewermirror_3/"
            End Select
        End Get
    End Property

    Protected Friend ReadOnly Property NewerVersionCheck() As Boolean
        Get
            ErrorReturn = False
            'Check website for a newer version.
            Try
                Client = New Net.WebClient
                Reader = New IO.StreamReader(New IO.MemoryStream(Client.DownloadData(ServerURL() & "TrafficViewerVersion.htm")))
                ReadString = Reader.ReadToEnd
                UploadedVersion = Convert.ToSingle(ReadString.Substring(ReadString.IndexOf("||") + 2, 3))
                CurrentVersion = Convert.ToSingle(Application.ProductVersion().Substring(0, 3))
                Reader.Close()
            Catch ex As IO.IOException
                ' MessageBox.Show(ex.ToString)
                ErrorReturn = True
            Catch ex As ArgumentException
                ' MessageBox.Show(ex.ToString)
                ErrorReturn = True
            Catch ex As Net.WebException
                ' MessageBox.Show(ex.ToString)
                ErrorReturn = True
            End Try
            If Not ErrorReturn Then Return UploadedVersion > CurrentVersion
        End Get
    End Property

    Protected Friend Sub DeleteTempFiles()
        TempFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TrafficViewer\Temp\"
        Dim HelpFolder As String = TempFolder.Replace("Temp\", "")
        If IO.Directory.Exists(HelpFolder) Then
            If IO.File.Exists(HelpFolder & "TrafficViewerHelp.htm") Then
                IO.File.Delete(HelpFolder & "TrafficViewerHelp.htm")
            End If
        End If
        If IO.Directory.Exists(TempFolder) Then
            IO.Directory.Delete(TempFolder, True)
        End If
        Try
            Microsoft.Win32.Registry.LocalMachine.DeleteSubKey("Software\TrafficViewer", False)
        Catch ex As Security.SecurityException 'User does not have RegistryPermission.SetInclude(delete, currentKey) access
            MessageBox.Show(ex.ToString)
        Catch ex As InvalidOperationException 'subkey has child subkeys
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private disposedValue As Boolean = False

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                If Not ExpandFiles Is Nothing Then
                    ExpandFiles.Dispose()
                End If
                If Not ProgressForm Is Nothing Then
                    ProgressForm.Dispose()
                End If
                If Not Client Is Nothing Then
                    Client.Dispose()
                End If
            End If
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
