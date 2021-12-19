'  -----------------------------------------------------------------
'  File:      ErrorHandler.vb
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
    Imports System
    Imports System.ComponentModel
    Imports System.Drawing
    Imports System.WinForms
    Imports System.Threading

    Imports Microsoft.VisualBasic.ControlChars
    
Option Explicit

Namespace Microsoft.Samples.WinForms.Cs.ErrorHandler 

    'The Error Handler class
    'We need a class because event handling methods can't be static
    Private Class CustomExceptionHandler 

        'Handle the exception  event
        public Sub OnThreadException(sender As Object, t As ThreadExceptionEventArgs) 

            Dim result As DialogResult = DialogResult.Cancel
            Try 
                result = Me.ShowThreadExceptionDialog(t.exception)
            
            catch 
                Try 
                    MessageBox.Show("Fatal Error", "Fatal Error", MessageBox.IconStop + MessageBox.AbortRetryIgnore)
                
                Finally 
                    Application.Exit()
                End Try
            End Try

            if (result = DialogResult.Abort) Then Application.Exit()

        End Sub

        private Function ShowThreadExceptionDialog(e As Exception) As DialogResult
            Dim errorMsg As String = "An error occurred please contact the adminstrator with the following information:" & CrLf & CrLf
            errorMsg = errorMsg & e.Message & CrLf & CrLf & "Stack Trace:" & CrLf & e.StackTrace
            return MessageBox.Show(errorMsg, "Application Error", MessageBox.IconStop + MessageBox.AbortRetryIgnore)
        end Function
    End Class

    public class ErrorHandler 
    Inherits System.WinForms.Form 
        private components As System.ComponentModel.Container 
        private button1 As System.WinForms.Button 

        public Sub New() 
            MyBase.New()

            ' Required by the Win Forms Designer
            InitializeComponent()

            ' TODO: Add any constructor code after InitializeComponent call

        End Sub

        Overrides public Sub Dispose() 
            MyBase.Dispose()
        End Sub

        private Sub InitializeComponent() 
            Me.components = new System.ComponentModel.Container()
            Me.button1 = new System.WinForms.Button()

            Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
            Me.Text = "Exception Handling Sample"
            Me.ClientSize = new System.Drawing.Size(392, 117)

            button1.Size = new System.Drawing.Size(120, 40)
            button1.TabIndex = 1
            button1.Font = new System.Drawing.Font("TAHOMA", 8f, System.Drawing.FontStyle.Bold)
            button1.Text = "Click Me!"
            button1.Location = new System.Drawing.Point(256, 64)
            button1.AddOnClick(new System.EventHandler(AddressOf button1_Click))

            Me.Controls.Add(button1)
	End Sub

        private Sub button1_Click(sender As Object, e As System.EventArgs) 
            throw new ArgumentException("The parameter was invalid")
        End Sub


        public shared Sub Main() 
            Dim eh As new CustomExceptionHandler()
            Application.AddOnThreadException(new ThreadExceptionEventHandler(AddressOf eh.OnThreadException))
            Application.Run(new ErrorHandler())
        End Sub


    End Class

End Namespace











