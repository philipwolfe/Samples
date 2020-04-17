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

Imports System.Drawing.Imaging

Public Class AsyncPictureBoxForm

    ''' <summary>
    ''' Handle the Click event on btnLoad. 
    ''' Start the async load of the bitmap file pointed to by txtLocation - this can be 
    ''' a file name or url
    ''' </summary>
    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        ImageLoadProgressBar.Value = 0
        BigImagePictureBox.Image = Nothing
        btnLoad.Enabled = False
        btnCancel.Enabled = True
        BigImagePictureBox.LoadAsync(txtLocation.Text)
    End Sub

    ''' <summary>
    ''' Handle the Click event on btnCancel.
    ''' Cancel the async loading of the bitmap file
    ''' Note: It is possible that the load may have completed by the time cancel is processed
    '''       - you will need to take this into account in your applications
    ''' </summary>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            BigImagePictureBox.CancelAsync()
    End Sub

    ''' <summary>
    ''' Handle the LoadCompleted event. This event is raised when the PictureBox has 
    ''' finished async loading the bitmap.
    ''' The AsyncCompletedEventArgs contains information about the async operation 
    ''' - whether it was canceled, if there was an error and so on
    ''' </summary>
    Private Sub BigImagePictureBox_LoadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles BigImagePictureBox.LoadCompleted
        btnCancel.Enabled = False
        btnLoad.Enabled = True
        If Not (e.Error Is Nothing) Then
            MsgBox(e.Error.Message, MsgBoxStyle.Exclamation, "Async PictureBox Sample")
        ElseIf (e.Cancelled = True) Then
            MsgBox("Load of picture canceled", MsgBoxStyle.Exclamation, "Async PictureBox Sample")
        Else
            MsgBox("Load of picture completed", MsgBoxStyle.Exclamation, "Async PictureBox Sample")
        End If
    End Sub

    ''' <summary>
    ''' Handle the ProgressChanged event. This event is raised during the async loading
    ''' of the bitmap. It can be used to give progress feedback to the user.
    ''' The ProgressChangedEventArgs contains information about the progress of 
    ''' the async operation - in this case the percentage complete
    ''' </summary>
    Private Sub BigImagePictureBox_LoadProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BigImagePictureBox.LoadProgressChanged
        ImageLoadProgressBar.Value = e.ProgressPercentage
    End Sub


    ''' <summary> 
    ''' Utility method that generates a 35MB bitmap for the sample
    ''' This should really be done asynchronously as well but to keep the sample
    ''' simple we'll simply do it in line
    ''' </summary>
    Private Sub InstructionsLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles InstructionsLinkLabel.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim startingBmp As Bitmap = My.Resources.SampleBitmap
        Dim bigBmp As New Bitmap(3000, 3000, PixelFormat.Format32bppRgb)
        Dim gBmp As Graphics = Graphics.FromImage(bigBmp)
        Dim bmpBrush As New TextureBrush(startingBmp)
        Try
            gBmp.FillRectangle(bmpBrush, gBmp.ClipBounds)
            gBmp.FillRectangle(New SolidBrush(Color.FromArgb(70, Color.White)), gBmp.ClipBounds)
            bigBmp.Save("big.bmp", ImageFormat.Bmp)
        Finally
            If Not (gBmp Is Nothing) Then gBmp.Dispose()
            If Not (bigBmp Is Nothing) Then bigBmp.Dispose()
            If Not (bmpBrush Is Nothing) Then bmpBrush.Dispose()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub txtLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocation.TextChanged

        If (Len(Me.txtLocation.Text) = 0) Then
            Me.btnLoad.Enabled = False
        Else
            Me.btnLoad.Enabled = True
        End If

    End Sub

End Class
