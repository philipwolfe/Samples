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
Imports System.Workflow.Activities.Rules
Imports System.CodeDom


Module Module1


    Class Program

        Shared WaitHandle As New AutoResetEvent(False)
        Shared rulesChanged As Boolean = False

        Shared Sub Main()
            Using workflowRuntime As New WorkflowRuntime()

                AddHandler workflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
                AddHandler workflowRuntime.WorkflowTerminated, AddressOf OnWorkflowTerminated
                AddHandler workflowRuntime.WorkflowIdled, AddressOf OnWorkflowIdled
                AddHandler workflowRuntime.WorkflowResumed, AddressOf OnWorkflowResumed
                AddHandler workflowRuntime.WorkflowSuspended, AddressOf OnWorkflowSuspended



                ' The "Amount" parameter is used to determine which branch of the IfElse should be executed
                ' a value less than 10,000 will execute branch 1 - Get Manager Approval; any other value will execute branch 2 - Get VP Approval
                Dim workflowAmount As Integer = 9000
                Dim workflowNamedValues As New Dictionary(Of String, Object)()
                workflowNamedValues.Add("Amount", workflowAmount)
                Dim workflowInstance As WorkflowInstance = workflowRuntime.CreateWorkflow(GetType(DynamicUpdateChangingRules.DynamicRulesWorkflow), workflowNamedValues)
                workflowInstance.Start()
                WaitHandle.WaitOne()
                Console.WriteLine("press ENTER to continue")
                Console.ReadLine()
            End Using
        End Sub




        Shared Sub changeRulesForWorkflow(ByVal workflowInstance As WorkflowInstance)

            If (Not rulesChanged) Then
                rulesChanged = True

                ' our new validation amount
                Dim newAmount As Integer = 8000
                Console.WriteLine(vbTab & "Dynamically change approved amount to {0}", newAmount)

                'Dynamic update of order rule
                Dim workflowchanges As New WorkflowChanges(workflowInstance.GetWorkflowDefinition())

                Dim transient As CompositeActivity = workflowchanges.TransientWorkflow
                Dim ruleDefinitions As RuleDefinitions = CType(transient.GetValue(ruleDefinitions.RuleDefinitionsProperty), RuleDefinitions)
                Dim conditions As RuleConditionCollection = ruleDefinitions.Conditions
                Dim condition1 As RuleExpressionCondition = CType(conditions("Condition1"), RuleExpressionCondition)
                CType(condition1.Expression, CodeBinaryOperatorExpression).Right = New CodePrimitiveExpression(newAmount)


                'Apply our changes to the workflow

                workflowInstance.ApplyWorkflowChanges(workflowchanges)

            Else
                Console.WriteLine(vbTab & "Rules for Workflow already changed")
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
            'idling this workflow so we can modify it
            e.WorkflowInstance.Suspend("suspending to modify IfElse1")
            changeRulesForWorkflow(e.WorkflowInstance)
            e.WorkflowInstance.Resume()
        End Sub
        Shared Sub OnWorkflowSuspended(ByVal sender As Object, ByVal e As WorkflowSuspendedEventArgs)
            Dim reason As String = e.Error
            Dim workflowID As String = e.WorkflowInstance.InstanceId.ToString()
            Console.WriteLine(vbTab & "Workflow '{0}' Suspended, reason '{1}'", workflowID, reason)
        End Sub
        Shared Sub OnWorkflowResumed(ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Dim workflowID As String = e.WorkflowInstance.InstanceId.ToString()
            Console.WriteLine(vbTab & "Workflow '{0}' Resumed", workflowID)
        End Sub

    End Class
End Module

