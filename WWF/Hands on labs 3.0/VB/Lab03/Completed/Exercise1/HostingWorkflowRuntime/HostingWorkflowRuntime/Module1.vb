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
Module Module1
    Class Program

        Shared WaitHandle As New AutoResetEvent(False)

        Shared Sub Main()
            Using workflowRuntime As New WorkflowRuntime()

                Dim connectionString As String = "Initial Catalog=TrackingStore; " & "Data Source=localhost\SQLExpress; " & "Integrated Security=SSPI;"
                workflowRuntime.AddService(New System.Workflow.Runtime.Tracking.SqlTrackingService(connectionString))

                AddHandler workflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
                AddHandler workflowRuntime.WorkflowTerminated, AddressOf OnWorkflowTerminated

                AddHandler workflowRuntime.Started, AddressOf workflowRuntime_Started
                AddHandler workflowRuntime.Stopped, AddressOf workflowRuntime_Stopped
                AddHandler workflowRuntime.WorkflowResumed, AddressOf workflowRuntime_WorkflowResumed
                AddHandler workflowRuntime.WorkflowSuspended, AddressOf workflowRuntime_WorkflowSuspended

                Dim workflowInstance As WorkflowInstance
                workflowInstance = workflowRuntime.CreateWorkflow(GetType(HostingWorkflowRuntime.SimpleWorkflow))
                workflowInstance.Start()

                workflowInstance.Suspend("Reason we are suspending the workflow.")
                workflowInstance.Resume()

                WaitHandle.WaitOne()

                Console.WriteLine("Workflow Completed - press ENTER to continue")
                Console.Read()

            End Using
        End Sub

        Shared Sub workflowRuntime_Stopped(ByVal sender As Object, ByVal e As WorkflowRuntimeEventArgs)
            Console.WriteLine("Runtime stopped event.")
        End Sub

        Shared Sub workflowRuntime_Started(ByVal sender As Object, ByVal e As WorkflowRuntimeEventArgs)
            Dim w As WorkflowRuntime = CType(sender, WorkflowRuntime)
            Dim services As ICollection = w.GetAllServices(GetType(System.Object))
            For Each o As Object In services
                Console.WriteLine("Service of type " & o.ToString & " started.")
            Next
        End Sub

        Shared Sub workflowRuntime_WorkflowSuspended(ByVal sender As Object, ByVal e As WorkflowSuspendedEventArgs)
            Console.WriteLine("In WorkflowSuspended, reason: " & e.Error)
        End Sub

        Shared Sub workflowRuntime_WorkflowResumed(ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("In WorkflowResumed")
        End Sub

        Shared Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
            WaitHandle.Set()
        End Sub

        Shared Sub OnWorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)
            Console.WriteLine(e.Exception.Message)
            WaitHandle.Set()
        End Sub

    End Class
End Module

