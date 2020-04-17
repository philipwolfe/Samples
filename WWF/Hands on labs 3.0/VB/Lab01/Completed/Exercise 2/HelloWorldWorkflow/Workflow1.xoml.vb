'--------------------------------------------------------------------------------
' This file is a "Sample" as from Windows Workflow Foundation
' Hands on Labs RC
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
' 
' THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'--------------------------------------------------------------------------------

'NOTE: When changing the namespace; please update XmlnsDefinitionAttribute in AssemblyInfo.vb
Public Class Workflow1
    Inherits SequentialWorkflowActivity

    Private Sub codeActivity1_CodeHandler(ByVal sender As System.Object, _
                                                ByVal e As System.EventArgs)
        System.Windows.Forms.MessageBox.Show _
        ("Hello World: " & myFirstName & " " & myLastName)
    End Sub


    Private myFirstName As String
    Public Property FirstName() As String
        Get
            Return myFirstName
        End Get
        Set(ByVal value As String)
            myFirstName = value
        End Set
    End Property


    Private myLastName As String
    Public Property LastName() As String
        Get
            Return myLastName
        End Get
        Set(ByVal value As String)
            myLastName = value
        End Set
    End Property


End Class
