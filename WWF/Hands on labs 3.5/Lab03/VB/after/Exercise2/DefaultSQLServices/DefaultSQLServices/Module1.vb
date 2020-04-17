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

Imports System.Workflow.Runtime.Tracking
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes


'NOTE: When changing the namespace; please update XmlnsDefinitionAttribute in AssemblyInfo.vb
Module Module1
    Class Program

        Shared connectionString As String = "Initial Catalog=TrackingStore;" & _
                        "Data Source=localhost\SQLExpress; Integrated Security=SSPI;"

        Shared WaitHandle As New AutoResetEvent(False)

        Shared Sub Main()
            Using workflowRuntime As New WorkflowRuntime()
                workflowRuntime.AddService(New SharedConnectionWorkflowCommitWorkBatchService(connectionString))
                workflowRuntime.AddService(New SqlTrackingService(connectionString))
                workflowRuntime.AddService(New SqlWorkflowPersistenceService(connectionString, True, _
                                New TimeSpan(0, 0, 0, 10, 0), New TimeSpan(0, 0, 0, 10, 0)))
                workflowRuntime.AddService(New DefaultWorkflowSchedulerService())

                AddHandler workflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
                AddHandler workflowRuntime.WorkflowTerminated, AddressOf OnWorkflowTerminated

                AddHandler workflowRuntime.WorkflowLoaded, AddressOf OnWorkflowLoaded
                AddHandler workflowRuntime.WorkflowIdled, AddressOf OnWorkflowIdled
                AddHandler workflowRuntime.WorkflowPersisted, AddressOf OnWorkflowPersisted
                AddHandler workflowRuntime.WorkflowUnloaded, AddressOf OnWorkflowUnloaded

                Dim workflowCount As Integer = 0
                Do While (workflowCount < 5)
                    Dim simpleWorkflowInstance As WorkflowInstance = _
                        workflowRuntime.CreateWorkflow(GetType(DefaultSQLServices.SimpleWorkflow))
                    simpleWorkflowInstance.Start()
                    workflowCount = (workflowCount + 1)
                Loop

                System.Threading.Thread.Sleep(New TimeSpan(0, 0, 20))

                Console.WriteLine("Workflow Completed - press ENTER to continue")
                Console.Read()

            End Using
        End Sub

        Shared Sub GetInstanceTrackingEvents(ByVal instanceId As Guid)
            Console.WriteLine("" & vbCrLf & "Instance Tracking Events :")
            Dim sqlTrackingQuery1 As SqlTrackingQuery = New SqlTrackingQuery(connectionString)
            Dim sqlTrackingWorkflowInstance1 As SqlTrackingWorkflowInstance
            sqlTrackingQuery1.TryGetWorkflow(instanceId, sqlTrackingWorkflowInstance1)

            Try
                For Each workflowTrackingRecord As WorkflowTrackingRecord In _
                                            sqlTrackingWorkflowInstance1.WorkflowEvents
                    Console.WriteLine("EventDescription : {0}  DateTime : {1}", _
                                            workflowTrackingRecord.TrackingWorkflowEvent, _
                                            workflowTrackingRecord.EventDateTime)
                Next
            Catch e As Exception
                Console.WriteLine("No Instance Tracking Events Found")
            End Try
        End Sub

        Shared Sub OnWorkflowIdled(ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow {0} idled", e.WorkflowInstance.InstanceId)
            ThreadPool.QueueUserWorkItem(AddressOf UnloadInstance, e.WorkflowInstance)
        End Sub

        Shared Sub OnWorkflowUnloaded(ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow {0} unloaded", e.WorkflowInstance.InstanceId)
        End Sub

        Shared Sub OnWorkflowPersisted(ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow {0} persisted", e.WorkflowInstance.InstanceId)
        End Sub

        Shared Sub OnWorkflowLoaded(ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow {0} loaded", e.WorkflowInstance.InstanceId)
        End Sub

        Shared Sub UnloadInstance(ByVal workflowInstance As Object)
            Dim instance As WorkflowInstance = CType(workflowInstance, WorkflowInstance)

            Try
                Console.WriteLine("UnloadInstance: attempting to unload \'{0}\'", instance.InstanceId)
                instance.Unload()
            Catch ex As Exception
                Console.WriteLine("UnloadInstance: failed " & vbCrLf & "{0}", ex)
            End Try
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

