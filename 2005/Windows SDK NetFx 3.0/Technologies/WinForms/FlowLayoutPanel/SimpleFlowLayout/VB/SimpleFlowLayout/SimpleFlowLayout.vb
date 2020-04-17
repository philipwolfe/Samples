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

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

'<summary>
' Summary description for form.
'</summary>

Public Class SimpleFlowLayout
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer = Nothing

    Public Sub New()

        Application.EnableVisualStyles()
        InitializeComponent()

    End Sub 'New


    Private Sub radioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioVertical.CheckedChanged, radioHorizontal.CheckedChanged

        Select Case CType(sender, RadioButton).Name
            Case "radioHorizontal"
                Me.Size = New Size(475, 176)
            Case "radioVertical"
                Me.Size = New Size(244, 317)
        End Select

    End Sub 'radioButton_CheckedChanged

End Class 'Form1
