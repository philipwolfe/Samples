Imports System.IO

Public Class Form1

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_zipUtil = New ZipUtil()

        Me.OpenFileDialog1.FileName = ""
        Me.SaveFileDialog1.FileName = ""

        ' add event handler to disable both buttons unless there are paths for both
        AddHandler SourceFile.TextChanged, AddressOf Me.Source_TextChange
        AddHandler DestinationFile.TextChanged, AddressOf Me.Destination_TextChange
    End Sub

    Private Sub Compress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Compress.Click
        If Me.SourceFile.Text.Length > 0 And Me.DestinationFile.Text.Length > 0 Then
            Try
                m_zipUtil.CompressFile(Me.SourceFile.Text, Me.DestinationFile.Text)
                MessageBox.Show("Successfully compressed " & Me.SourceFile.Text & " to " & Me.DestinationFile.Text, "Compression Sample", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DestinationFile.Text = ""
                Me.SourceFile.Text = ""
            Catch ex As Exception
                MessageBox.Show("There was an error compressing the file" & vbCrLf & ex.Message, "Compression Sample", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub Decompress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Decompress.Click
        If Me.SourceFile.Text.Length > 0 And Me.DestinationFile.Text.Length > 0 Then
            Try
                m_zipUtil.DecompressFile(Me.SourceFile.Text, Me.DestinationFile.Text)
                MessageBox.Show("Successfully decompressed " & Me.SourceFile.Text & " to " & Me.DestinationFile.Text, "Compression Sample", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DestinationFile.Text = ""
                Me.SourceFile.Text = ""
            Catch ex As Exception
                MessageBox.Show("There was an error compressing the file" & vbCrLf & ex.Message, "Compression Sample", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub BrowseSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseSource.Click
        If Me.OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Me.SourceFile.Text = Me.OpenFileDialog1.FileName
            Dim newFileName As String = Path.GetFileNameWithoutExtension(Me.SourceFile.Text) + ".zip"
            Me.SaveFileDialog1.FileName = newFileName
        End If
    End Sub

    Private Sub BrowseDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseDestination.Click
        Me.SaveFileDialog1.FileName = ""

        If Me.SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Me.DestinationFile.Text = Me.SaveFileDialog1.FileName
        End If
    End Sub

    ' disable both buttons if there is no path for the source & destination files
    Private Sub Source_TextChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SourceFile.TextChanged
        Dim bEnabled As Boolean
        bEnabled = False
        If (Me.SourceFile.Text.Length > 0 And Me.DestinationFile.Text.Length > 0) Then
            bEnabled = True
        End If

        Me.Decompress.Enabled = bEnabled
        Me.Compress.Enabled = bEnabled
    End Sub

    ' disable both buttons if there is no path for the source & destination files
    Private Sub Destination_TextChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestinationFile.TextChanged
        Dim bEnabled As Boolean
        bEnabled = False
        If (Me.SourceFile.Text.Length > 0 And Me.DestinationFile.Text.Length > 0) Then
            bEnabled = True
        End If

        Me.Decompress.Enabled = bEnabled
        Me.Compress.Enabled = bEnabled
    End Sub

    Private m_zipUtil As ZipUtil

End Class
