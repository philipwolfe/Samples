'=====================================================================
'  File:      TXForm.vb
'
'  Summary:   Windows.Forms Code for .NET COM+ Transactions Sample
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
Imports System.Collections
Imports System.Globalization
Imports System.ComponentModel
Imports System.Windows.Forms


Namespace Microsoft.Samples.Technologies.ComponentServices.Transactions
    _
    'This class handles the UI for the Transaction Sample
    Public Class TXForm
        Inherits System.Windows.Forms.Form


        Friend WithEvents currentValueLabel As System.Windows.Forms.Label
#Region " Windows Form Designer generated code "
        Friend WithEvents currentValue As System.Windows.Forms.TextBox
        Friend WithEvents post As System.Windows.Forms.Button
        Friend WithEvents autoCompletePost As System.Windows.Forms.Button
        Friend WithEvents newValue As System.Windows.Forms.TextBox
        Friend WithEvents newValueLabel As System.Windows.Forms.Label

        Public Sub New()
            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub 'New


        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.Container

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.currentValueLabel = New System.Windows.Forms.Label
            Me.currentValue = New System.Windows.Forms.TextBox
            Me.post = New System.Windows.Forms.Button
            Me.autoCompletePost = New System.Windows.Forms.Button
            Me.newValue = New System.Windows.Forms.TextBox
            Me.newValueLabel = New System.Windows.Forms.Label
            Me.SuspendLayout()
            '
            'currentValueLabel
            '
            Me.currentValueLabel.Location = New System.Drawing.Point(8, 8)
            Me.currentValueLabel.Name = "currentValueLabel"
            Me.currentValueLabel.Size = New System.Drawing.Size(80, 16)
            Me.currentValueLabel.TabIndex = 0
            Me.currentValueLabel.Text = "Current Value:"
            '
            'currentValue
            '
            Me.currentValue.Location = New System.Drawing.Point(88, 8)
            Me.currentValue.Name = "currentValue"
            Me.currentValue.ReadOnly = True
            Me.currentValue.TabIndex = 1
            Me.currentValue.TabStop = False
            '
            'post
            '
            Me.post.Location = New System.Drawing.Point(8, 72)
            Me.post.Name = "post"
            Me.post.Size = New System.Drawing.Size(88, 23)
            Me.post.TabIndex = 3
            Me.post.Text = "&Post"
            '
            'autoCompletePost
            '
            Me.autoCompletePost.Location = New System.Drawing.Point(104, 72)
            Me.autoCompletePost.Name = "autoCompletePost"
            Me.autoCompletePost.Size = New System.Drawing.Size(88, 23)
            Me.autoCompletePost.TabIndex = 4
            Me.autoCompletePost.Text = "&AutoComplete"
            '
            'newValue
            '
            Me.newValue.Location = New System.Drawing.Point(88, 40)
            Me.newValue.Name = "newValue"
            Me.newValue.TabIndex = 2
            Me.newValue.Text = "5"
            '
            'newValueLabel
            '
            Me.newValueLabel.Location = New System.Drawing.Point(8, 40)
            Me.newValueLabel.Name = "newValueLabel"
            Me.newValueLabel.Size = New System.Drawing.Size(80, 16)
            Me.newValueLabel.TabIndex = 5
            Me.newValueLabel.Text = "New Value:"
            '
            'TXForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
            Me.ClientSize = New System.Drawing.Size(200, 101)
            Me.Controls.Add(Me.newValue)
            Me.Controls.Add(Me.newValueLabel)
            Me.Controls.Add(Me.autoCompletePost)
            Me.Controls.Add(Me.post)
            Me.Controls.Add(Me.currentValue)
            Me.Controls.Add(Me.currentValueLabel)
            Me.Name = "TXForm"
            Me.Text = "TXForm"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub 'InitializeComponent

#End Region

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            Dim TXDemoServer As TXDemoServer = Nothing
            Try
                TXDemoServer = New TXDemoServer

                currentValue.Text = TXDemoServer.RetrieveCurrentValue().ToString(CultureInfo.CurrentCulture)
            Catch cv As CurrentValueNotReadException
                MessageBox.Show("Unable to read the current value from " & _
                  "the database", "Error")
                Application.Exit()
            Catch ex As Exception
                MessageBox.Show("An exception was caught : " & ex.Message & _
                 " Unable to launch the COM+ Server. Closing the " & _
                  "application.", "Error")
                Application.Exit()
            Finally
                'It is important to dispose COM+ objects as soon as possible so that
                'COM+ metadata such as context does not remain in memory unnecessarily
                'and so that COM+ services such as Object Pooling work properly.
                If Not TXDemoServer Is Nothing Then
                    TXDemoServer.Dispose()
                End If
            End Try
        End Sub

        'Start the Post with a manual transaction if the user clicks on the 
        'Post button
        Private Sub Post_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles post.Click

            Dim val As Integer = 0
            Try
                val = Integer.Parse(newValue.Text, CultureInfo.CurrentCulture)
            Catch
                MessageBox.Show("Please enter a value to post!")
            End Try

            Dim TXDemoServer As TXDemoServer = Nothing
            Try
                TXDemoServer = New TXDemoServer
                TXDemoServer.Post(val)
            Catch de As DatabaseExecutionException
                MessageBox.Show("Unable to update the database", "Error")
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("An exception was caught : " + ex.Message)
                Exit Sub
            Finally
                'It is important to dispose COM+ objects as soon as possible so that
                'COM+ metadata such as context does not remain in memory unnecessarily
                'and so that COM+ services such as Object Pooling work properly.
                If Not TXDemoServer Is Nothing Then
                    TXDemoServer.Dispose()
                End If
            End Try
            Try
                TXDemoServer = New TXDemoServer
                currentValue.Text = TXDemoServer.RetrieveCurrentValue().ToString(CultureInfo.CurrentCulture)
            Catch cv As CurrentValueNotReadException
                MessageBox.Show("Unable to read the current value from the database", _
                 "Error")
                Exit Sub
            Finally
                'It is important to dispose COM+ objects as soon as possible so that
                'COM+ metadata such as context does not remain in memory unnecessarily
                'and so that COM+ services such as Object Pooling work properly.
                If Not TXDemoServer Is Nothing Then
                    TXDemoServer.Dispose()
                End If
            End Try
        End Sub


        'Start the Post with automatic transaction if the user clicks on the 
        'AutoCompletePost button
        Private Sub AutoComplete_PostClick(ByVal sender As Object, ByVal e As _
          System.EventArgs) Handles autoCompletePost.Click
            Dim val As Integer = 0
            Try
                val = Integer.Parse(newValue.Text, CultureInfo.CurrentCulture)
            Catch
                MessageBox.Show("Please enter a value to post!")
            End Try

            Dim TXDemoServer As TXDemoServer = Nothing
            Try
                TXDemoServer = New TXDemoServer
                TXDemoServer.AutoCompletePost(val)
            Catch at As ValueOutOfRangeException
                MessageBox.Show("The transaction has been aborted by " & _
                  "throwing an AbortTransactionException", "No Error")
            Catch db As DatabaseExecutionException
                MessageBox.Show("Unable to update the database", "Error")
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("An exception was caught : " + ex.Message)
                Exit Sub
            Finally
                'It is important to dispose COM+ objects as soon as possible so that
                'COM+ metadata such as context does not remain in memory unnecessarily
                'and so that COM+ services such as Object Pooling work properly.
                If Not TXDemoServer Is Nothing Then
                    TXDemoServer.Dispose()
                End If
            End Try
            Try
                TXDemoServer = New TXDemoServer
                currentValue.Text = TXDemoServer.RetrieveCurrentValue().ToString(CultureInfo.CurrentCulture)
            Catch cv As CurrentValueNotReadException
                MessageBox.Show("Unable to read the current value from " & _
                 "the database", "Error")
                Exit Sub
            Finally
                'It is important to dispose COM+ objects as soon as possible so that
                'COM+ metadata such as context does not remain in memory unnecessarily
                'and so that COM+ services such as Object Pooling work properly.
                If Not TXDemoServer Is Nothing Then
                    TXDemoServer.Dispose()
                End If
            End Try
        End Sub

        Public Shared Sub Main(ByVal args() As String)
            Application.Run(New TXForm)
        End Sub

    End Class
End Namespace
