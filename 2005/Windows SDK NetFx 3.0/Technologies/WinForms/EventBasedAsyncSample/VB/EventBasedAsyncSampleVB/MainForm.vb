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

Public Class MainForm

    Shared Sub New()
        Application.EnableVisualStyles()
    End Sub

    ''' <summary>
    ''' Displays the PictureBox Async sample form
    ''' </summary>
    Private Sub btnAsyncPictureBoxSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsyncPictureBoxSample.Click
        If My.Forms.AsyncPictureBoxForm.Visible = True Then
            My.Forms.AsyncPictureBoxForm.BringToFront()
        Else
            My.Forms.AsyncPictureBoxForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' Displays the WebClient Async sample form
    ''' </summary>
    Private Sub btnAsyncWebClientSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsyncWebClientSample.Click
        If My.Forms.AsyncWebClientForm.Visible = True Then
            My.Forms.AsyncWebClientForm.BringToFront()
        Else
            My.Forms.AsyncWebClientForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' Displays the WebService Async sample form
    ''' </summary>
    Private Sub btnAsyncWebServiceSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsyncWebServiceSample.Click
        If My.Forms.AsyncWebServiceForm.Visible = True Then
            My.Forms.AsyncWebServiceForm.BringToFront()
        Else
            My.Forms.AsyncWebServiceForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' Displays the BackgroundWorker sample form
    ''' </summary>
    Private Sub btnBackgroundWorkerSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackgroundWorkerSample.Click
        If My.Forms.SimpleBackgroundWorkerForm.Visible = True Then
            My.Forms.SimpleBackgroundWorkerForm.BringToFront()
        Else
            My.Forms.SimpleBackgroundWorkerForm.Show()
        End If
    End Sub
End Class
