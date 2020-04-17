'-----------------------------------------------------------------------
'  This file is part of the Microsoft .NET SDK Code Samples.
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
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Class TwoPaneProp
    Inherits System.Windows.Forms.Form

    Public Sub New()

        InitializeComponent()

    End Sub 'New

    Private Sub button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button4.Click

        Me.Close()

    End Sub

    Private Sub button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click

        Me.Close()

    End Sub
End Class 'TwoPaneProp
