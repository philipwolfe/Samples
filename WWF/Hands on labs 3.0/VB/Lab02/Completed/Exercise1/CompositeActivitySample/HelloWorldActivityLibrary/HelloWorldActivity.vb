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
Public Class HelloWorldActivity
    Inherits SequenceActivity
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Private Sub writeHello_ExecuteCode(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.Write("Hello, ")
    End Sub

    Private Sub writeWorld_ExecuteCode(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine("World")
    End Sub
End Class