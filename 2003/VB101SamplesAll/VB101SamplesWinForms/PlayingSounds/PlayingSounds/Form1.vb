Imports System.Media
Imports System.ComponentModel

Public Class Form1
    Private fileName As String
    ' A SoundPlayer control is used for playing system sounds
    ' and .wav files.

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Display available system sounds on the form.
        LoadSystemSounds()
    End Sub

    Public Sub LoadSystemSounds()
        ' These are the system sounds currently supported.
        ' There is no list avaliable for enumerating,
        ' so load them manually
        systemSoundsComboBox.Items.AddRange( _
            New String() {"Asterisk", "Beep", "Exclamation", "Hand"})
    End Sub

    Private Sub browseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseButton.Click
        ' Provide a file dialog for browsing for the sound file.
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = "c:\\windows\\media"
        openFileDialog1.Filter = "WAV files (*.wav)|*.wav"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True
        If (openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            fileName = openFileDialog1.FileName
            soundFileNameTextBox.Text = fileName
        End If
    End Sub

    Private Sub playSyncButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles playSyncButton.Click
        If fileName IsNot Nothing Then
            My.Computer.Audio.Play(fileName)
        End If
    End Sub

    Private Sub playAsyncButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles playAsyncButton.Click
        If loopCheckBox.Checked Then
            'You can also play the sound asynchronously and loop the sound using My.
            My.Computer.Audio.Play(fileName, AudioPlayMode.BackgroundLoop)
        Else
            'You can play the sound synchronously but using the WaitToComplete argument
            My.Computer.Audio.Play(fileName, AudioPlayMode.Background)
        End If
    End Sub
    Private Sub stopAsyncPlayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stopAsyncPlayButton.Click
        'You can stop the audio from playing by simply using the Stop Method.
        My.Computer.Audio.Stop()
    End Sub

    Private Sub playSystemSoundButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles playSystemSoundButton.Click
        Select Case systemSoundsComboBox.Text
            Case "Asterisk"
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
                Exit Select
            Case "Beep"
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Beep)
                Exit Select
            Case "Exclamation"
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                Exit Select
            Case "Hand"
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                Exit Select
            Case Else
                Throw New ApplicationException("Invalid system sound.")
        End Select

    End Sub
End Class
