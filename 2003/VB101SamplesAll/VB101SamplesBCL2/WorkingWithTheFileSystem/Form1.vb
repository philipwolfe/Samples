Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.VisualBasic

Partial Public Class Form1
    Inherits Form

#Region " Declarations "

    ' Initial folder paths.
    Private sourcePath As String = Path.GetFullPath("..\..\DemoDataOne")
    Private destPath As String = Path.GetFullPath("..\..\DemoDataTwo")

#End Region

#Region " Constructor "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

#End Region

#Region " Event Procedures "

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Initialize list box tags.
        sourceListBox.Tag = String.Empty
        destListBox.Tag = String.Empty
        ' Load file lists with initial working folders.
        LoadFileList(sourceListBox, sourcePath)
        LoadFileList(destListBox, destPath)
        If (sourceListBox.Items.Count > 0) Then
            sourceListBox.SelectedIndex = 0
        End If
    End Sub

    Private Sub browseLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseLeft.Click
        ' FolderBrowserDialog lets the user select a folder.
        Dim fbd As FolderBrowserDialog = New FolderBrowserDialog
        fbd.ShowNewFolderButton = False
        If (sourcePathTextBox.Text.Trim.Length = 0) Then
            fbd.SelectedPath = sourcePath
        Else
            fbd.SelectedPath = sourcePathTextBox.Text.Trim
        End If
        If (fbd.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
            LoadFileList(sourceListBox, fbd.SelectedPath)
        End If
    End Sub

    Private Sub browseRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseRight.Click
        ' FolderBrowserDialog lets the user select a folder.
        Dim fbd As FolderBrowserDialog = New FolderBrowserDialog
        fbd.ShowNewFolderButton = False
        If (destPathTextBox.Text.Trim.Length = 0) Then
            fbd.SelectedPath = destPath
        Else
            fbd.SelectedPath = destPathTextBox.Text.Trim
        End If
        If (fbd.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
            LoadFileList(destListBox, fbd.SelectedPath)
        End If
    End Sub

    Private Sub sourceListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles sourceListBox.SelectedIndexChanged
        HandleButtons()
    End Sub

    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub

    Private Sub exitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitToolStripMenuItem.Click
        Me.Close()
    End Sub

#End Region

#Region " File Action Procedures "

    Private Sub copyButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles copyButton.Click
        Dim sourceFilePath As String = Path.Combine(sourceListBox.Tag.ToString, sourceListBox.SelectedItem.ToString)
        Dim destFilePath As String = Path.Combine(destListBox.Tag.ToString, sourceListBox.SelectedItem.ToString)
        ' The Exists method makes it easy to determine whether the 
        ' file's already there.
        If File.Exists(destFilePath) Then
            If Not Confirm("OK to overwrite?") Then
                Return
            End If
        End If
        ' Copy the file. The "true" parameter means "overwrite if necessary."            
        File.Copy(sourceFilePath, destFilePath, True)
        LoadFileList(destListBox)
    End Sub

    Private Sub moveButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles moveButton.Click
        Dim sourceFilePath As String = Path.Combine(sourceListBox.Tag.ToString, sourceListBox.SelectedItem.ToString)
        Dim destFilePath As String = Path.Combine(destListBox.Tag.ToString, sourceListBox.SelectedItem.ToString)
        ' Unlike File.Copy, File.Move has no boolean parameter to permit
        ' overwriting the destination file, so if the file already exists,
        ' you have to delete it before executing the move.
        If File.Exists(destFilePath) Then
            If Confirm("OK to overwrite?") Then
                File.Delete(destFilePath)
            Else
                Return
            End If
        End If
        ' Move the file to the new location. You can choose to give it a new
        ' name in the new folder. For example, you can move "C:\MyFile.txt"
        ' to "D:\MyBrandNewFile.txt."            
        File.Move(sourceFilePath, destFilePath)
        LoadFileList(destListBox)
        LoadFileList(sourceListBox)
    End Sub

    Private Sub deleteButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles deleteButton.Click
        Dim sourceFilePath As String = Path.Combine(sourceListBox.Tag.ToString, sourceListBox.SelectedItem.ToString)
        ' File deletion is easy. Just call the File.Delete method.
        If Confirm("Are you sure?") Then
            File.Delete(sourceFilePath)
            LoadFileList(sourceListBox)
        End If
    End Sub

    Private Sub fileInfoButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fileInfoButton.Click
        Dim selectedFile As String = sourceListBox.SelectedItem.ToString
        Dim selectedFilePath As String = Path.Combine(sourceListBox.Tag.ToString, selectedFile)
        ' Unlike the File class, you must create an instance of the FileInfo 
        ' class in order to access its properties and methods. You need this 
        ' class to get information such as file length, creation date and time, 
        ' and last modified time date and time.
        Dim fi As FileInfo = New FileInfo(selectedFilePath)
        Dim fileInformation As String = String.Format(("File Info for {1}{0}" + ("  Size: {2} bytes{0}" + ("  Created: {3}{0}" + ("  Last modified: {4}{0}" + "  Location: {5}{0}")))), Environment.NewLine, selectedFile, fi.Length, fi.CreationTime, fi.LastWriteTime, fi.DirectoryName)
        ShowInfoMessage(fileInformation)
    End Sub

    Private Sub createButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles createButton.Click
        Dim newFileName As String = Interaction.InputBox("New file name", "Create File", String.Empty, (Me.Left + 225), (Me.Top + 100))
        If (newFileName.Length > 0) Then
            ' Create the file. Using the "using" statement ensures that the
            ' handle representing the new file is released, so you can delete
            ' or move it if you choose to. 
            Using fs As FileStream = File.Create(Path.Combine(sourceListBox.Tag.ToString, newFileName))
            End Using
            LoadFileList(sourceListBox)
        End If
    End Sub

    Private Sub openButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles openButton.Click
        Dim sourceFilePath As String = Path.Combine(sourceListBox.Tag.ToString, _
            sourceListBox.SelectedItem.ToString)

        Try
            ' The File.OpenText method lets you open a text file for reading.
            ' The StreamReader class provides a means for reading a stream of bytes 
            ' from a file. The ReadToEnd method gets all bytes from the current 
            ' position to the end.
            Dim result As String
            Using sr As StreamReader = File.OpenText(sourceFilePath)
                result = sr.ReadToEnd
            End Using

            ' Display the content in a second form.
            Dim frm As Form2 = New Form2
            frm.contentTextBox.Text = result
            frm.ShowDialog(Me)
        Catch ex As Exception
            ShowInfoMessage(ex.Message)
        End Try
    End Sub

    Private Overloads Sub LoadFileList(ByVal lb As ListBox)
        Dim selectedPath As String = lb.Tag.ToString
        LoadFileList(lb, selectedPath)
    End Sub

    Private Overloads Sub LoadFileList(ByVal lb As ListBox, ByVal selectedPath As String)
        lb.Items.Clear()
        lb.Tag = selectedPath
        ' The static/shared GetFiles method of the Directory class returns an 
        ' array containing all the files in the specified folder.
        Dim allFiles() As String = Directory.GetFiles(selectedPath)
        For Each fl As String In allFiles
            lb.Items.Add(Path.GetFileName(fl))
        Next
        sourcePathTextBox.Text = sourceListBox.Tag.ToString
        destPathTextBox.Text = destListBox.Tag.ToString
        HandleButtons()
    End Sub

#End Region

#Region " Utility Procedures "

    Private Function Confirm(ByVal msg As String) As Boolean
        If (MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
            Windows.Forms.DialogResult.Yes) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub HandleButtons()
        ' Enable buttons only when a file is selected.
        Dim fileIsSelected As Boolean = (sourceListBox.SelectedIndex >= 0)
        copyButton.Enabled = fileIsSelected
        moveButton.Enabled = fileIsSelected
        deleteButton.Enabled = fileIsSelected
        fileInfoButton.Enabled = fileIsSelected
        openButton.Enabled = fileIsSelected
    End Sub

    Private Sub ShowInfoMessage(ByVal msg As String)
        MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

End Class
