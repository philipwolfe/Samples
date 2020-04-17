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

Imports System.Workflow.Activities

Module Module1
    Private WaitHandle As New AutoResetEvent(False)

    Sub Main()
        Using workflowRuntime As New WorkflowRuntime()

            AddHandler workflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
            AddHandler workflowRuntime.WorkflowTerminated, AddressOf OnWorkflowTerminated

            Dim dataService As New ExternalDataExchangeService()
            workflowRuntime.AddService(dataService)

            dataService.AddService(New FactoringService())

            Dim workflowInstance As WorkflowInstance
            workflowInstance = workflowRuntime.CreateWorkflow(GetType(Workflow1))
            workflowInstance.Start()

            WaitHandle.WaitOne()
            Console.WriteLine("press any key to continue")
            Console.ReadLine()
        End Using
    End Sub

    Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
        WaitHandle.Set()
    End Sub

    Sub OnWorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)
        Console.WriteLine(e.Exception.Message)
        WaitHandle.Set()
    End Sub

End Module

