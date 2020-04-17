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
'-----------------------------------------------------------------------
'  File:      OCForm.vb
'
'  Summary:   .Net client code for COM+ Object Construction Sample
'
'---------------------------------------------------------------------

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Microsoft.Samples.Technologies.ComponentServices.ObjectConstruction

    Public Class OCForm
        Inherits Form
        Private WithEvents constructButton As Button



        Public Sub New()
            InitializeComponent()
        End Sub 'New



        Private Sub InitializeComponent()
            Me.constructButton = New Button

            constructButton.Location = New System.Drawing.Point(80, 40)
            constructButton.Size = New System.Drawing.Size(96, 24)
            constructButton.TabIndex = 1
            constructButton.Text = "Create Object"

            Me.Text = "Object Construction String Demo"
            Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
            Me.ClientSize = New System.Drawing.Size(270, 120)
            Me.Controls.Add(constructButton)
        End Sub 'InitializeComponent



        Private Sub Construct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles constructButton.Click
            Me.Cursor = Cursors.WaitCursor
            Dim order As ObjectConstructionTest = Nothing
            Try
                ' this call will result in a call to the ObjectConstructionTest
                ' constructor, after which, COM+ will call the object's
                ' IObjectConstruct::Construct implementation and provide
                ' if the object construction string
                order = New ObjectConstructionTest


                ' this method will throw up a single message box
                ' but does not meaningful work.
                order.DoWork()

            Catch ex As Exception
                MessageBox.Show(("An exception was caught : " & ex.Message), "Error")

            Finally
                'It is important to dispose COM+ objects as soon as possible so that
                'COM+ metadata such as context does not remain in memory unnecessarily
                'and so that COM+ services such as Object Pooling work properly.
                If Not order Is Nothing Then
                    order.Dispose()
                End If
                Me.Cursor = Cursors.Arrow

            End Try
        End Sub 'Construct_Click

        Public Shared Sub Main(ByVal args() As String)
            Application.Run(New OCForm)
        End Sub 'Main

    End Class 'OCForm
End Namespace
