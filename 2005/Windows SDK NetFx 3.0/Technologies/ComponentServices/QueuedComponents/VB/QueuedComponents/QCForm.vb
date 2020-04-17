'-----------------------------------------------------------------------
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
'=====================================================================
'  File:  QCForm.vb
'
'  Summary:   .NET Client App For Generating Queued Messages
'
'=====================================================================

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic

Namespace Microsoft.Samples.Technologies.ComponentServices.QueuedComponents

    Public Class QCForm
        Inherits Form
        Private WithEvents sendMsg As Button
        Private msgToSend As TextBox


        Public Sub New()
            InitializeComponent()
        End Sub 'New



        Private Sub InitializeComponent()
            Me.sendMsg = New Button
            Me.msgToSend = New TextBox

            sendMsg.Location = New System.Drawing.Point(24, 40)
            sendMsg.Size = New System.Drawing.Size(140, 24)
            sendMsg.TabIndex = 1
            sendMsg.Text = "Send Queued Msg"

            msgToSend.Location = New System.Drawing.Point(24, 80)
            msgToSend.Size = New System.Drawing.Size(140, 24)
            msgToSend.Text = "Hello Queued Component!"

            Me.Text = "Queued components"
            Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
            Me.ClientSize = New System.Drawing.Size(200, 150)
            Me.Controls.Add(sendMsg)
            Me.Controls.Add(msgToSend)
        End Sub 'InitializeComponent



        ' Create the queued component, call it, and release it
        Private Sub SendMsg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sendMsg.Click
            Dim iQC As IQComponent

            Me.Cursor = Cursors.WaitCursor

            Try
                ' invoke an instance of our queued component using a queue moniker
                ' this provides a client reference that's called into as if it were an actual
                ' instance of the server component
                iQC = CType(Marshal.BindToMoniker("queue:/new:Microsoft.Samples.Technologies.ComponentServices.QueuedComponents.QComponent"), IQComponent)

                ' Call into the queued component. if we're not connected to an activated
                ' server object, this will place a packaged message in the QCDemoSvr queue.
                iQC.DisplayMessage(msgToSend.Text)

                ' appropriate method for releasing our queued component
                Marshal.ReleaseComObject(iQC)

            Catch ex As Exception
                MessageBox.Show(("An exception was caught : " & ex.Message & ControlChars.CrLf & "Make sure you installed MSMQ and runned REGSVCS.EXE as explained in the README of this sample!"), "Error")

            Finally
                Me.Cursor = Cursors.Arrow

            End Try

        End Sub 'SendMsg_Click

        <STAThread()> _
        Public Shared Sub Main(ByVal args() As String)
            Application.Run(New QCForm)
        End Sub 'Main
    End Class 'QCForm
End Namespace
