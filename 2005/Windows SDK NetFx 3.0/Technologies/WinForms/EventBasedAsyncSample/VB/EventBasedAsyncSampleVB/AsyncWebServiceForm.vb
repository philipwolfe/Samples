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

Public Class AsyncWebServiceForm

    'Key used to identify the Web service call - see comments below for details
    Private webServiceCallKey As New Object

    ''' <summary>
    ''' Handle the Form load event
    ''' Sets the default selected item in the ComboBox of questions
    ''' </summary>
    Private Sub AsyncWebServiceForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtWebServiceUrl.Text = My.Settings.EventBasedAsyncSampleVB_SimpleWebServices_SimpleWebService
        cmbQuestion.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Handle the Click event on btnAskTheQuestion. 
    ''' Start the async Web service call using the Web service pointed to by txtWebServiceUrl
    ''' </summary>
    Private Sub btnAskTheQuestion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAskTheQuestion.Click
        btnCancel.Enabled = True
        btnAskTheQuestion.Enabled = False
        txtAnswer.Text = ""
        SimpleWebService1.Url = txtWebServiceUrl.Text

        StartProgress("Calling Web Service...") 'See StartProgress below for an explanation of this method

        'Although our UI only supports one outstanding call at a time, the webservice supports 
        'multiple outstanding requests. We want to be able to cancel an outstanding request and the 
        'Web service requires that we identify the request to be cancelled using the userState 
        'parameter. Therefore we need to pass in a unique userState identifier to the webservice call 
        'so that we can pass the same identifier into CancelAsync (see below). 

        'Because we only support one outstanding call at a time we can re-use the same identifier however 
        'if we supported issuing multiple requests at once we would need to generate a unique identifier 
        'for each request.
        SimpleWebService1.GetAnswerAsync(cmbQuestion.Text, webServiceCallKey)
    End Sub

    ''' <summary>
    ''' Handle the Click event on btnCancel.
    ''' Cancel the async call of the webservice
    ''' Note: It is possible that the Web service may have completed by the time cancel is processed
    '''       - you will need to take this into account in your applications
    ''' </summary>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'More than one async request can be running at a time 
        'So pass in the key that identifies this operation
        'In our case we only have one operation running at a time so pass in the standard key
        SimpleWebService1.CancelAsync(webServiceCallKey)
    End Sub

    ''' <summary>
    ''' Handle the LoadCompleted event. This event is raised when the Web service has 
    ''' finished async execution
    ''' The AsyncCompletedEventArgs contains information about the async operation 
    ''' - the result, whether it was canceled, if there was an error and so on
    ''' </summary>
    Private Sub SimpleWebService1_GetAnswerCompleted(ByVal sender As Object, ByVal e As SimpleWebServices.GetAnswerCompletedEventArgs) Handles SimpleWebService1.GetAnswerCompleted
        btnCancel.Enabled = False
        btnAskTheQuestion.Enabled = True
        StopProgress("Ready") 'See StartProgress below for an explanation of this method

        If (e.Cancelled = True) Then
            MsgBox("Web Service call canceled", MsgBoxStyle.Exclamation, "Async Web Service Sample")
        Else

            '
            'Note: If the Web service returned an error e.Result will throw the exception associated with the error
            '
            '      You can also check for e.Error:
            '
            '           If Not (e.Error Is Nothing) Then
            '           End If
            '
            Try
                txtAnswer.Text = e.Result
                MsgBox("Web Service completed", MsgBoxStyle.Exclamation, "Async Web Service Sample")
            Catch ex As Exception
                MsgBox("Web Service request error:" + ex.Message, MsgBoxStyle.Exclamation, "Async Web Service Sample")
            End Try
        End If
    End Sub

    ''' <summary> 
    ''' Web Services do not return progress information and so we will simulate progress
    ''' with a progress bar that slowly increments based on a timer
    ''' This method sets the status text and starts the timer
    ''' </summary>
    Private Sub StartProgress(ByVal progressText As String)
        WebServiceOperationToolStripProgressBar.Value = 0
        WebServiceOperationToolStripProgressBar.Visible = True
        WebServiceOperationToolStripTextProgressPanel.Text = progressText
        SimulateProgressTimer.Start()
    End Sub

    ''' <summary> 
    ''' This method sets the status text and stops the timer by incrementing 
    ''' it quickly to the end 
    ''' </summary>
    Private Sub StopProgress(ByVal status As String)
        SimulateProgressTimer.Stop()
        Dim i As Integer
        For i = WebServiceOperationToolStripProgressBar.Value To WebServiceOperationToolStripProgressBar.Maximum
            WebServiceOperationToolStripProgressBar.Value = i
            System.Threading.Thread.Sleep(5)
        Next
        WebServiceOperationToolStripProgressBar.Visible = False
        WebServiceOperationToolStripTextProgressPanel.Text = status
    End Sub

    ''' <summary> 
    ''' The timer tick event - used to increment the progress bar
    ''' </summary>
    Private Sub SimulateProgressTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimulateProgressTimer.Tick
        If (WebServiceOperationToolStripProgressBar.Value = WebServiceOperationToolStripProgressBar.Maximum) Then
            WebServiceOperationToolStripProgressBar.Value = 0
        End If
        WebServiceOperationToolStripProgressBar.Value += 1
    End Sub

    ''' <summary> 
    ''' Utility method that displays the source code for the Web service
    ''' </summary>
    Private Sub ViewWebServiceSourceLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ViewWebServiceSourceLinkLabel.LinkClicked
        My.Forms.SampleCodeForm.SampleCodeRtf = My.Resources.SimpleWebServiceSourceCode
        If My.Forms.SampleCodeForm.Visible = True Then
            My.Forms.SampleCodeForm.BringToFront()
        Else
            My.Forms.SampleCodeForm.Show()
        End If
    End Sub

End Class
