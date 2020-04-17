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

Module Module1
    Class Program

        Shared WaitHandle As New AutoResetEvent(False)

        Shared Sub Main()
            Using workflowRuntime As New WorkflowRuntime()
                AddHandler workflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
                AddHandler workflowRuntime.WorkflowTerminated, AddressOf OnWorkflowTerminated



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
                Dim workflow2NamedValues As New Dictionary(Of String, Object)()
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

        Shared Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
            WaitHandle.Set()
        End Sub

        Shared Sub OnWorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)
            Console.WriteLine(e.Exception.Message)
            WaitHandle.Set()
        End Sub

    End Class
End Module

