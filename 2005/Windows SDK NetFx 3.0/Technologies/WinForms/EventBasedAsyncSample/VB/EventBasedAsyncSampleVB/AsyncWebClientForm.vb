'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------

Imports System.Net
Imports System.IO

Public Class AsyncWebClientForm

    ''' The WebClient component used to download a file
    Private WithEvents myWebClient As New WebClient

    ''' Store full file name
    Private fullTargetFileName As String = ""

    ''' <summary>
    ''' Handle the Click event on btnBrowse. 
    ''' Allow the user to set the name of the file when it has been downloaded
    ''' </summary>
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        If (SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            txtToLocation.Text = SaveFileDialog1.FileName
        End If
    End Sub

    ''' <summary>
    ''' Handle the Click event on btnDownloadFile. 
    ''' Start the async download of the text file pointed to by txtFromLocation - this can be 
    ''' a file name or url. The file is downloaded to the name in txtToLocation
    ''' </summary>
    Private Sub btnDownloadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownloadFile.Click
        WebClientOperationToolStripProgressBar.Value = 0
        WebClientOperationToolStripTextProgressPanel.Text = ""
        btnDownloadFile.Enabled = False
        btnCancel.Enabled = True
        fullTargetFileName = Path.GetFullPath(txtToLocation.Text)
        myWebClient.DownloadFileAsync(New Uri(txtFromLocation.Text), fullTargetFileName)
    End Sub

    ''' <summary>
    ''' Handle the Click event on btnCancel.
    ''' Cancel the async loading of the text file
    ''' Note: It is possible that the load may have completed by the time cancel is processed
    '''       - you will need to take this into account in your applications
    ''' </summary>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        myWebClient.CancelAsync()
        fullTargetFileName = ""
    End Sub

    ''' <summary>
    ''' Handle the DownloadFileCompleted event. This event is raised when the WebClient component
    ''' has finished async downloading the file.
    ''' The AsyncCompletedEventArgs contains information about the async operation 
    ''' - whether it was canceled, if there was an error and so on
    ''' </summary>
    Private Sub myWebClient_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles myWebClient.DownloadFileCompleted
        btnCancel.Enabled = False
        btnDownloadFile.Enabled = True
        If Not (e.Error Is Nothing) Then
            MsgBox(e.Error.Message, MsgBoxStyle.Exclamation, "Async Web Client Sample")
        ElseIf (e.Cancelled = True) Then
            MsgBox("Download of file canceled", MsgBoxStyle.Exclamation, "Async Web Client Sample")
        Else
            Dim msg As String = String.Format("Download of file completed. File is located at: {0}", fullTargetFileName)
            MsgBox(msg, MsgBoxStyle.Exclamation, "Async Web Client Sample")
        End If
        fullTargetFileName = ""
    End Sub

    ''' <summary>
    ''' Handle the ProgressChanged event. This event is raised during the async download 
    ''' of the file. It can be used to give progress feedback to the user.
    ''' The ProgressChangedEventArgs contains information about the progress of 
    ''' the async operation - the percentage complete, the number of bytes downloaded and so on
    ''' </summary>
    Private Sub myWebClient_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles myWebClient.DownloadProgressChanged
        WebClientOperationToolStripProgressBar.Value = e.ProgressPercentage
        WebClientOperationToolStripTextProgressPanel.Text = "Downloaded " & e.BytesReceived.ToString & " bytes of " & e.TotalBytesToReceive.ToString
    End Sub

    ''' <summary> 
    ''' Utility method that generates a 24MB text file for the sample
    ''' This should really be done asynchronously as well but to keep the sample
    ''' simple we'll simply do it in line
    ''' </summary>
    Private Sub InstructionsLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles InstructionsLinkLabel.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim sw As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter("big.txt", False)
        Try
            Dim i as Integer
            For i = 1 To 300000
                With sw
                    .Write(i)
                    .WriteLine(" this is a line of text in a big file that we are generating for our sample")
                End With
            Next
        Finally
            If Not (sw Is Nothing) Then sw.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
