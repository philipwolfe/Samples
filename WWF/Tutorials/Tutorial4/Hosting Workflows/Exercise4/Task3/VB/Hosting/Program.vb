'---------------------------------------------------------------------
'  This file is part of the Windows Workflow Foundation SDK Code Samples.
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
'---------------------------------------------------------------------

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Threading
Imports System.Workflow.Runtime
Imports System.Workflow.Runtime.Hosting

Namespace Microsoft.Samples.Workflow.Tutorials.Hosting
    Class Program
        Private Shared waitHandle As AutoResetEvent = New AutoResetEvent(False)
        Private Shared parameters As Dictionary(Of String, Object) = _
                  New Dictionary(Of String, Object)()

        Shared Sub Main(ByVal args As String())
            Dim workflowRuntime As WorkflowRuntime = _
                New WorkflowRuntime("HostingWorkflowRuntime")

            ' workflow runtime events
            AddHandler workflowRuntime.Started, AddressOf workflowRuntime_Started
            AddHandler workflowRuntime.Stopped, AddressOf workflowRuntime_Stopped

            ' workflow events
            AddHandler workflowRuntime.WorkflowSuspended, _
                AddressOf workflowRuntime_WorkflowSuspended
            AddHandler workflowRuntime.WorkflowResumed, _
                AddressOf workflowRuntime_WorkflowResumed
            AddHandler workflowRuntime.WorkflowTerminated, _
                AddressOf workflowRuntime_WorkflowTerminated
            AddHandler workflowRuntime.WorkflowCompleted, _
                AddressOf workflowRuntime_WorkflowCompleted

            AddHandler workflowRuntime.WorkflowLoaded, _
                AddressOf workflowRuntime_WorkflowLoaded
            AddHandler workflowRuntime.WorkflowIdled, _
                AddressOf workflowRuntime_WorkflowIdled
            AddHandler workflowRuntime.WorkflowPersisted, _
                AddressOf workflowRuntime_WorkflowPersisted
            AddHandler workflowRuntime.WorkflowUnloaded, _
                AddressOf workflowRuntime_WorkflowUnloaded

            workflowRuntime.StartRuntime()

            ' retrieve workflow parameters
            Do
                Try
                    Console.Write("Enter a value for operand1: ")
                    parameters("Operand1") = Int32.Parse(Console.ReadLine())
                Catch ex As Exception
                    Console.WriteLine(ex.Message + Environment.NewLine)
                End Try
            Loop While parameters.ContainsKey("Operand1") = False

            Do
                Try
                    Console.Write("Enter a value for operand2: ")
                    parameters("Operand2") = Int32.Parse(Console.ReadLine())
                Catch ex As Exception
                    Console.WriteLine(ex.Message + Environment.NewLine)
                End Try
            Loop While parameters.ContainsKey("Operand2") = False

            Dim type As Type = GetType(HostingWorkflows)
            Dim workflowInstance As WorkflowInstance = _
                         workflowRuntime.CreateWorkflow(type, parameters)

            workflowInstance.Start()

            waitHandle.WaitOne()

            workflowRuntime.StopRuntime()
        End Sub

        Private Shared Sub workflowRuntime_Started _
                  (ByVal sender As Object, ByVal e As WorkflowRuntimeEventArgs)
            Console.WriteLine("Workflow runtime started")
        End Sub

        Private Shared Sub workflowRuntime_Stopped _
                  (ByVal sender As Object, ByVal e As WorkflowRuntimeEventArgs)
            Console.WriteLine("Workflow runtime stopped")
        End Sub

        Private Shared Sub workflowRuntime_WorkflowSuspended _
                  (ByVal sender As Object, ByVal e As WorkflowSuspendedEventArgs)
            Console.WriteLine("Workflow suspended: {0}", e.Error)
            e.WorkflowInstance.Resume()
        End Sub

        Private Shared Sub workflowRuntime_WorkflowResumed _
                  (ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow resumed")
        End Sub

        Private Shared Sub workflowRuntime_WorkflowTerminated _
                  (ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)
            Console.WriteLine("Workflow Terminated : {0}", e.Exception.Message)
            waitHandle.Set()
        End Sub

        Private Shared Sub workflowRuntime_WorkflowCompleted _
                  (ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
            Console.WriteLine("Result: {0}", e.OutputParameters("Result"))
            waitHandle.Set()
        End Sub

        Private Shared Sub workflowRuntime_WorkflowLoaded _
            (ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow {0} loaded", e.WorkflowInstance.InstanceId)
        End Sub

        Private Shared Sub workflowRuntime_WorkflowIdled _
            (ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow {0} idled", e.WorkflowInstance.InstanceId)
            e.WorkflowInstance.Unload()
        End Sub

        Private Shared Sub workflowRuntime_WorkflowPersisted _
            (ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow {0} persisted", e.WorkflowInstance.InstanceId)
        End Sub

        Private Shared Sub workflowRuntime_WorkflowUnloaded _
            (ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow {0} unloaded", e.WorkflowInstance.InstanceId)
        End Sub
    End Class
End Namespace
