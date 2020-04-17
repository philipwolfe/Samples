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

Imports System
Imports System.Collections.Generic
Imports System.Threading
Imports System.Workflow.Runtime
Imports System.Workflow.Activities


Module Module1
    Private WaitHandle As New AutoResetEvent(False)

    Sub Main()
        Using workflowRuntime As New WorkflowRuntime()

            AddHandler workflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
            AddHandler workflowRuntime.WorkflowCreated, AddressOf OnWorkflowCreated

            Dim dataService As New ExternalDataExchangeService()
            workflowRuntime.AddService(dataService)

            Dim votingService As New VotingService()
            dataService.AddService(votingService)

            Dim workflowInstance As WorkflowInstance
            workflowInstance = workflowRuntime.CreateWorkflow(GetType(VotingWorkflow))
            workflowInstance.Start()

            WaitHandle.WaitOne()

            Console.WriteLine("Press any key to exit...")
            Console.Read()
        End Using
    End Sub

    Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)

        WaitHandle.Set()

        Console.WriteLine("Workflow " + _
          e.WorkflowInstance.InstanceId.ToString() + _
          " completed.")

    End Sub

    Sub OnWorkflowCreated(ByVal sender As Object, ByVal e As WorkflowEventArgs)

        WaitHandle.Set()

        Console.WriteLine("Workflow " + _
         e.WorkflowInstance.InstanceId.ToString() + " created.")

    End Sub

End Module

