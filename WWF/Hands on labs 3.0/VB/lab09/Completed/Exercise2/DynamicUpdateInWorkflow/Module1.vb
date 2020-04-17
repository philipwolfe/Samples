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

Imports System.Workflow.ComponentModel
Imports System.Workflow.Activities

Module Module1
    Class Program

        Shared WaitHandle As New AutoResetEvent(False)
        Shared workflowUpdated As Boolean = False

        Shared Sub Main()
            Using workflowRuntime As New WorkflowRuntime()

                AddHandler workflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
                AddHandler workflowRuntime.WorkflowTerminated, AddressOf OnWorkflowTerminated
                AddHandler workflowRuntime.WorkflowIdled, AddressOf OnWorkflowIdled
                AddHandler workflowRuntime.WorkflowSuspended, AddressOf OnWorkflowSuspended
                AddHandler workflowRuntime.WorkflowResumed, AddressOf OnWorkflowResumed

                'start PO approval workflow with purchase less than $1000
                Console.WriteLine("Workflow test 1 (purchase less than $1000) :")
                Dim workflow1Amount As Integer = 750
                Dim workflow1NamedValues As New Dictionary(Of String, Object)()
                workflow1NamedValues.Add("Amount", workflow1Amount)
                Dim workflow1Instance As WorkflowInstance = workflowRuntime.CreateWorkflow(GetType(DynamicUpdateInWorkflow.Workflow1), workflow1NamedValues)
                workflow1Instance.Start()
                WaitHandle.WaitOne()

                'waiting for the workflow to complete so the console output makes sence
                System.Threading.Thread.Sleep(New TimeSpan(0, 0, 0, 10, 0))

                Console.WriteLine("")

                ' start PO approval workflow with purchase greater than $1000
                Console.WriteLine("Workflow test 2 (purchase greater than $1000) :")
                Dim workflow2Amount As Integer = 1200
                Dim workflow2NamedValues As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
                workflow2NamedValues.Add("Amount", workflow2Amount)
                Dim workflow2Instance As WorkflowInstance = workflowRuntime.CreateWorkflow(GetType(DynamicUpdateInWorkflow.Workflow1), workflow2NamedValues)
                workflow2Instance.Start()
                WaitHandle.WaitOne()

                'waiting for the workflow to complete so the console output makes sence
                System.Threading.Thread.Sleep(New TimeSpan(0, 0, 0, 10, 0))
                Console.WriteLine("")
                Console.WriteLine("press ENTER to continue")
                Console.ReadLine()

            End Using
        End Sub




        Shared Sub ModifyWorkflowFromHost(ByVal workflowInstance As WorkflowInstance)

            If (Not workflowUpdated) Then

                workflowUpdated = True

                Dim workflowInstanceDefinition As Activity = workflowInstance.GetWorkflowDefinition()
                Dim workflowChangesToMake As WorkflowChanges = New WorkflowChanges(workflowInstanceDefinition)

                ' remove ifelse
                Console.WriteLine(vbTab & "Host change to always require approval for")
                Console.WriteLine(vbTab & "InstanceId: " + workflowInstance.InstanceId.ToString())

                Dim ifelse As CompositeActivity = CType(workflowChangesToMake.TransientWorkflow.Activities("ifElse1Activity"), CompositeActivity)
                workflowChangesToMake.TransientWorkflow.Activities.Remove(ifelse)

                ' setup to invoke NewStepWorkflow type
                Dim invokeNewStepWorkflow As InvokeWorkflowActivity = New InvokeWorkflowActivity()
                invokeNewStepWorkflow.Name = "AddNewStepWorkflow"
                invokeNewStepWorkflow.TargetWorkflow = GetType(DynamicUpdateInWorkflow.Workflow2)

                ' insert approval workflow
                workflowChangesToMake.TransientWorkflow.Activities.Insert(1, invokeNewStepWorkflow)

                ' apply transient changes to instance
                workflowInstance.ApplyWorkflowChanges(workflowChangesToMake)
            Else
                Console.WriteLine(vbTab & "Workflow has already been updated by the Host")
            End If
        End Sub




        Shared Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
            WaitHandle.Set()
        End Sub

        Shared Sub OnWorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)
            Console.WriteLine(e.Exception.Message)
            WaitHandle.Set()
        End Sub



        Shared Sub OnWorkflowIdled(ByVal sender As Object, ByVal e As WorkflowEventArgs)
            e.WorkflowInstance.Suspend("suspending to modify workflow")
            ModifyWorkflowFromHost(e.WorkflowInstance)
            e.WorkflowInstance.Resume()
        End Sub

        Shared Sub OnWorkflowSuspended(ByVal sender As Object, _
                                              ByVal e As WorkflowSuspendedEventArgs)
            Dim reason As String = e.Error
            Dim workflowID As String = e.WorkflowInstance.InstanceId.ToString()
            Console.WriteLine(vbTab & "Workflow '{0}' Suspended, reason '{1}'", _
                                                                     workflowID, reason)
        End Sub

        Shared Sub OnWorkflowResumed(ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Dim workflowID As String = e.WorkflowInstance.InstanceId.ToString()
            Console.WriteLine(vbTab & "Workflow '{0}' Resumed", workflowID)
        End Sub



    End Class
End Module

