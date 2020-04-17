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

    Public Sub replicatorActivity1_Initialized(ByVal sender As Object, ByVal e As EventArgs)

        ' Populate the data used for each instance of the Replicator's 
        ' child instance that are created
        Dim children As ArrayList = New ArrayList()
        children.Add("Child Instance 1")
        children.Add("Child Instance 2")
        children.Add("Child Instance 3")
        children.Add("Child Instance 4")
        children.Add("Child Instance 5")
        children.Add("Child Instance 6")
        replicatorActivity1.InitialChildData = children

        ' Specify how the child instances should be created - in parallel 
        ' or in a sequence
        replicatorActivity1.ExecutionType = ExecutionType.Sequence

    End Sub




    Private Sub codeActivity1_ExecuteCode(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine("In codeActivity1_ExecuteCode")
    End Sub


    Private Sub childCompleted(ByVal sender As Object, ByVal e As ReplicatorChildEventArgs)
        Console.WriteLine("Completed {0}", e.InstanceData.ToString())
    End Sub
    Private Sub childInitialized(ByVal sender As Object, ByVal e As ReplicatorChildEventArgs)
        Console.WriteLine("Initialized {0}", e.InstanceData.ToString())
    End Sub





    Private Sub WorkflowCompleted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine("Workflow finished")
    End Sub


End Class
