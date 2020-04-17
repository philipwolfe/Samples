'=====================================================================
'  File:      RBSecForm.vb
'
'  Summary:   Client for Role-Based Security Demo
'
'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
'
'  Copyright (C) Microsoft Corporation.  All rights reserved.
'
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
'
'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'=====================================================================

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
'Imports System.EnterpriseServices


Namespace Microsoft.Samples.Technologies.ComponentServices.RoleBasedSecurity

    Public Class RBSecForm
        Inherits Form
        Private WithEvents whoAmI As Button
        Private WithEvents amInRole As Button
        Private label As Label


        Public Sub New()
            InitializeComponent()
        End Sub 'New



        Private Sub InitializeComponent()
            Me.whoAmI = New Button
            Me.amInRole = New Button
            Me.label = New Label

            whoAmI.Location = New System.Drawing.Point(40, 40)
            whoAmI.Size = New System.Drawing.Size(150, 24)
            whoAmI.TabIndex = 1
            whoAmI.Text = "Display Logged On User"

            amInRole.Location = New System.Drawing.Point(40, 70)
            amInRole.Size = New System.Drawing.Size(150, 24)
            amInRole.TabIndex = 1
            amInRole.Text = "Is Caller In Demo Role?"

            label.Location = New System.Drawing.Point(24, 10)
            label.Size = New System.Drawing.Size(210, 24)

            Me.Text = "Role-Based Security Demo"
            Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
            Me.ClientSize = New System.Drawing.Size(250, 150)
            Me.Controls.Add(whoAmI)
            Me.Controls.Add(amInRole)
            Me.Controls.Add(label)
        End Sub 'InitializeComponent



        Private Sub WhoAmI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles whoAmI.Click
            label.Text = ""
            Me.Cursor = Cursors.WaitCursor
            Dim test As RBSecurityObject = Nothing

            Try
                test = New RBSecurityObject

                label.Text = test.WhoIsCaller()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Could not create RBSecurityObject")
            Finally
                'It is important to dispose COM+ objects as soon as possible so that
                'COM+ metadata such as context does not remain in memory unnecessarily
                'and so that COM+ services such as Object Pooling work properly.
                If Not test is Nothing
			test.Dispose()
		End If
                Me.Cursor = Cursors.Arrow
            End Try
        End Sub 'WhoAmI_Click



        Private Sub AmInRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles amInRole.Click
            label.Text = ""
            Me.Cursor = Cursors.WaitCursor
            Dim test As RBSecurityObject = Nothing
            Try
                test = New RBSecurityObject

                If test.IsCallerInDemoRole() Then
                    label.Text = "You ARE in RBSecurityDemoRole"
                Else
                    label.Text = "You are NOT in RBSecurityDemoRole"
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Could not create RBSecurityObject")
            Finally
                'It is important to dispose COM+ objects as soon as possible so that
                'COM+ metadata such as context does not remain in memory unnecessarily
                'and so that COM+ services such as Object Pooling work properly.
                If Not test is Nothing
			test.Dispose()
		End If
                Me.Cursor = Cursors.Arrow
            End Try
        End Sub 'AmInRole_Click

        Public Shared Sub Main(ByVal args() As String)
            Application.Run(New RBSecForm)
        End Sub 'Main
    End Class 'RBSecForm
End Namespace
