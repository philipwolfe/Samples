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

Public Class SimpleBackgroundWorkerForm

    ' Note: In order to support Cancellation and Progress reporting the following
    '       properties have been set to true on BackgroundWorker1
    ' 
    '           Me.BackgroundWorker1.WorkerReportsProgress = True
    '           Me.BackgroundWorker1.WorkerSupportsCancellation = True
    ' 

    ''' <summary>
    ''' Handle the Form load event
    ''' Sets the default value of the masked text box
    ''' </summary>
    Private Sub SimpleBackgroundWorkerForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, MyBase.Load
        Me.mtxtInput.Text = "2"
    End Sub

    ''' <summary>
    ''' Handle the Click event on btnStart. 
    ''' Start the background worker task passing mtxtInput as the input to the task
    ''' via RunWorkerAsync
    ''' </summary>
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        btnCancel.Enabled = True
        btnStart.Enabled = False
        OperationToolStripProgressBar.Value = 0
        OperationToolStripProgressBar.Visible = True
        OperationToolStripTextProgressPanel.Text = "Calculating result"

        Dim inputNumber As Integer = CInt(Me.mtxtInput.Text)
        BackgroundWorker1.RunWorkerAsync(inputNumber)
    End Sub

    ''' <summary>
    ''' Handle the Click event on btnCancel.
    ''' Cancel the background worker task
    ''' 
    ''' Note: It is possible that the task may have completed by the time cancel is processed
    '''       - you will need to take this into account in your applications
    ''' 
    ''' Note: This is only supported if 
    ''' 
    '''       (1) you set WorkerSupportsCancellation = true 
    '''       (2) you respond to CancellationPending in the DoWork event (see below)
    ''' 
    ''' </summary>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        BackgroundWorker1.CancelAsync()
    End Sub

    ''' <summary>
    ''' Handle the DoWork event on the BackgroundWorker.
    ''' 
    ''' Note well: This event runs on a seperate thread not on the UI thread
    '''            You put your long running task in this event handler and it is 
    '''            invoked via RunWorkerAsync.
    ''' 
    ''' As this event runs on a background thread you should not directly access
    ''' controls in this event.
    ''' 
    ''' You can call ReportProgress to raise the progress event on the UI thread 
    ''' You can set the Result which is returned to the UI thread in the Completed event 
    ''' You can use Control.Invoke/Control.BeginInvoke to set the state of controls on the UI thread
    ''' 
    ''' When this event handler exits the Completed event is raised on the UI thread
    ''' 
    ''' </summary>
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'This method will run on a thread other than the UI thread.
        'Be sure not to manipulate any Windows Forms controls created
        'on the UI thread from this method.

        'Get the input argument from the event args
        Dim inputNumber As Integer = CInt(e.Argument)

        'Throw an exception if input is greater than 1000
        'This causes the Completed event to be raised with e.Error containing
        'this exception
        If (inputNumber > 1000) Then
            Throw New ArgumentException("We only support numbers up to 1000")
        End If

        'Do the operation - simply double the number
        Dim result As Integer = inputNumber * 2

        'Now simulate a long running task by looping for 2000 milliseconds
        'If CancelAsync is called CancellationPending is true. Look for this and 
        'terminate the task if CancellationPending is true
        Dim i As Integer = 1
        While (i < 100 And Not BackgroundWorker1.CancellationPending)

            'Sleep for 5 milliseconds
            System.Threading.Thread.Sleep(20)

            'Report progress back to the UI thread via ReportProgress
            BackgroundWorker1.ReportProgress(i)

            i += 1

        End While

        'If the user canceled the task then set e.Cancel to true
        'so that in the Completed we can detect that the cancellation
        'suceeded
        If (BackgroundWorker1.CancellationPending) Then
            e.Cancel = True
        End If

        'Set the result into the event args to be picked up by Completed event
        e.Result = result

    End Sub


    ''' <summary>
    ''' Handle the LoadCompleted event. This event is raised when the BackgroundWorker DoWork event 
    ''' handler has finished executing
    ''' The RunWorkerCompletedEventArgs contains information about the task
    ''' - the result, whether it was canceled, if there was an error and so on
    ''' </summary>
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        btnCancel.Enabled = False
        btnStart.Enabled = True
        OperationToolStripProgressBar.Visible = False
        OperationToolStripTextProgressPanel.Text = "Ready"

        If (e.Cancelled = True) Then
            MsgBox("Background task canceled", MsgBoxStyle.Exclamation, "Async BackgroundWorker Sample")
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
                txtOutput.Text = e.Result.ToString()
                MsgBox("Background task completed", MsgBoxStyle.Exclamation, "Async BackgroundWorker Sample")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Async BackgroundWorker Sample")
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Handle the ProgressChanged event. This event is raised during the execution of 
    ''' DoWork is ReportProgress is called. It can be used to give progress feedback to the 
    ''' user.
    ''' 
    ''' The ProgressChangedEventArgs contains the percentage complete as reported by ReportProgress.
    ''' 
    ''' Note: This is only supported if you set WorkerReportsProgress = true 
    ''' 
    ''' </summary>
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        OperationToolStripProgressBar.Value = e.ProgressPercentage
    End Sub

End Class
