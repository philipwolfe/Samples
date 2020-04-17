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
Public Class SampleCodeForm

    Public Sub ShowOrBringToFront()
        If Me.Visible = True Then
            Me.BringToFront()
        Else
            Me.Show()
        End If
    End Sub

    Public Property SampleCodeRtf() As String
        Get
            Return RichTextBox1.Rtf
        End Get
        Set(ByVal value As String)
            RichTextBox1.Rtf = value
        End Set
    End Property

    Public Property SampleCodeText() As String
        Get
            Return RichTextBox1.Text
        End Get
        Set(ByVal value As String)
            RichTextBox1.Text = value
        End Set
    End Property

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If (SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            RichTextBox1.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
        End If
    End Sub
End Class
