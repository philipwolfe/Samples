Imports System.IO
Imports System.Net

Public Class Form1

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_ftpClient = New SimpleFTPClient
        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.InitialDirectory = Path.GetTempPath
        Me.SaveFileDialog1.FileName = ""
        Me.SaveFileDialog1.InitialDirectory = Path.GetTempPath
        Me.downloadURI.Text = "ftp://localhost/testfile.txt"
        Me.checkBox1.Checked = True

    End Sub

    Private Sub Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub Browse2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse2.Click
        Me.SaveFileDialog1.ShowDialog()
        Me.DownloadFileName.Text = Me.SaveFileDialog1.FileName
    End Sub

    Private Sub Download_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Download.Click

        If Me.DownloadFileName.Text.Length > 0 And Me.downloadURI.Text.Length > 0 Then
            Try
                ShowFTPResult(m_ftpClient.Download(Me.DownloadFileName.Text, New Uri(Me.downloadURI.Text)))
            Catch ex As Exception
                MessageBox.Show("There was an error in the download" & vbCrLf & ex.Message, "FTP Sample", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub SetCredentials_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetCredentials.Click
        m_ftpClient.UserName = Me.userName.Text
        m_ftpClient.Password = Me.password.Text
    End Sub

    Private Sub checkBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkBox1.CheckedChanged
        m_ftpClient.IsAnonymousUser = checkBox1.Checked
    End Sub

    Private Sub ShowFTPResult(ByVal statusCode As FtpStatusCode)
        MessageBox.Show("The FTP Server returned the following status: " + statusCode.ToString, "Simple FTP Client", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private m_ftpClient As SimpleFTPClient

End Class
