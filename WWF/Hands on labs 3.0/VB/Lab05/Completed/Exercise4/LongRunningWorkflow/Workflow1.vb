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

Public class Workflow1
    Inherits SequentialWorkflowActivity

    Private Sub BeforeDelay_Execute(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("Beginning Delay")
    End Sub

    Private Sub AfterDelay_Execute(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine(String.Format("Finished Delay ({0} seconds)", Me.delayActivity1.TimeoutDuration.Seconds))
    End Sub

    Private Sub BeforeBranch_Execute(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("Beginning Branch")
    End Sub

    Private Sub AfterBranch_Execute(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("Finished Branch")
    End Sub
End Class
