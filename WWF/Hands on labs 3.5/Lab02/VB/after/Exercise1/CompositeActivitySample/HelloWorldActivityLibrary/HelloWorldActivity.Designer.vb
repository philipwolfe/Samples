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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HelloWorldActivity

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Private Sub InitializeComponent()
        Me.CanModifyActivities = True
        Me.writeWorld = New System.Workflow.Activities.CodeActivity
        Me.writeHello = New System.Workflow.Activities.CodeActivity
        '
        'writeWorld
        '
        Me.writeWorld.Name = "writeWorld"
        AddHandler Me.writeWorld.ExecuteCode, AddressOf Me.writeWorld_ExecuteCode
        '
        'writeHello
        '
        Me.writeHello.Name = "writeHello"
        AddHandler Me.writeHello.ExecuteCode, AddressOf Me.writeHello_ExecuteCode
        '
        'HelloWorldActivity
        '
        Me.Activities.Add(Me.writeHello)
        Me.Activities.Add(Me.writeWorld)
        Me.Name = "HelloWorldActivity"
        Me.CanModifyActivities = False

    End Sub
    Private writeWorld As System.Workflow.Activities.CodeActivity
    Private writeHello As System.Workflow.Activities.CodeActivity

End Class

