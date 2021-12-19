'  -----------------------------------------------------------------
'  File:      ThreadMarshal.Cs
'
'  Summary:   This example demonstrates a simple WinForms application
'                                           
'---------------------------------------------------------------------
'  This file is part of the Microsoft COM+ 2.0 SDK Code Samples.
'
'  Copyright (C) 1999 Microsoft Corporation.  All rights reserved.
'
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
'
'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'=====================================================================*/
'

Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms
Imports System.Threading

Option Explicit

Namespace Microsoft.Samples.WinForms.Vb.ThreadMarshal 

    Public Class ThreadMarshal
    Inherits System.WinForms.Form 
        Private components As System.ComponentModel.Container 
        Private button1, button2 As System.WinForms.Button 
        Private progressBar1 As System.WinForms.ProgressBar 

        Private timerThread As Thread 

        Public Sub New() 
	    MyBase.New()
            ' Required by the Win Forms Designer
            InitializeComponent()
	End Sub

        'This function is executed on a background thread - it marshalls calls to 
        'update the UI back to the foreground thread
        Public Sub ThreadProc() 
            
            Try 
                Dim mi As new MethodInvoker(AddressOf Me.UpdateProgress)
                While (true)        
                    'Call BeginInvoke on the Form
                    Me.BeginInvoke(mi)
                    Thread.Sleep(500) 
                End While
            
            'Thrown when the thread is interupted by the main thread - exiting the loop
            catch e As ThreadInterruptedException
                'Simply exit....
            
            Catch we As Exception

            End Try
        End Sub

        'This function is called from the background thread
        Private Sub UpdateProgress() 

            'Reset to start if required
            If (progressBar1.Value = progressBar1.Maximum) Then
                progressBar1.Value = progressBar1.Minimum 
            End If

            progressBar1.PerformStep() 
        End Sub

        'Start the background thread to update the progress bar
        Private Sub button1_Click(sender As Object, e As System.EventArgs) 
            timerThread = new Thread(AddressOf ThreadProc)
            timerThread.IsBackground = true
            timerThread.Start()
        End Sub

        'Stop the background thread to update the progress bar
        Private Sub button2_Click(sender As Object, e As System.EventArgs) 
            If (timerThread <> Nothing) Then
                timerThread.Interrupt()
                timerThread = Nothing
            End If
        End Sub


        Overrides Public Sub Dispose() 
            If (timerThread <> Nothing) Then
                timerThread.Interrupt()
                timerThread = Nothing
            End If

            MyBase.Dispose()
        End Sub

        Private Sub InitializeComponent() 
            Me.components = new System.ComponentModel.Container()
            Me.button1 = new System.WinForms.Button()
            Me.button2 = new System.WinForms.Button()
            Me.progressBar1 = new System.WinForms.ProgressBar()

            Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
            Me.Text = "Built using the Designer"
            Me.ClientSize = new System.Drawing.Size(392, 117)

            button1.Size = new System.Drawing.Size(120, 40)
            button1.TabIndex = 1
            button1.Font = new System.Drawing.Font("TAHOMA", 8f, System.Drawing.FontStyle.Bold)
            button1.Text = "Start!"
            button1.Location = new System.Drawing.Point(130, 64)
            button1.AddOnClick(new System.EventHandler(AddressOf button1_Click))

            button2.Size = new System.Drawing.Size(120, 40)
            button2.TabIndex = 1
            button2.Font = new System.Drawing.Font("TAHOMA", 8f, System.Drawing.FontStyle.Bold)
            button2.Text = "Stop!"
            button2.Location = new System.Drawing.Point(256, 64)
            button2.AddOnClick(new System.EventHandler(AddressOf button2_Click))

            progressBar1.Size = new System.Drawing.Size(350, 40)
            progressBar1.TabIndex = 2
            progressBar1.Font = new System.Drawing.Font("TAHOMA", 8f, System.Drawing.FontStyle.Bold)
            progressBar1.Text = "Start!"
            progressBar1.Location = new System.Drawing.Point(10, 10)
            progressBar1.Step = 10
            progressBar1.Minimum = 0
            progressBar1.Maximum = 100

            Me.Controls.Add(button1)
            Me.Controls.Add(button2)
            Me.Controls.Add(progressBar1)
	End Sub

        Public Shared Sub Main() 
            Application.Run(new ThreadMarshal())
        End Sub
    End Class

End Namespace











