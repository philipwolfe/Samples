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

                
                'TODO: Add a line to the code similar to the one below and include your workflow type here.
                'dim wType as Type  = typeof(SimpleHost.Workflow1)
                'workflowRuntime.CreateWorkflow(wType).start()
                
                WaitHandle.WaitOne()
            End Using
        End Sub

        Shared Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)

            System.Console.WriteLine("Press Enter to continue...")
            System.Console.ReadLine()
            WaitHandle.Set()

        End Sub

        Shared Sub OnWorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)
            Console.WriteLine(e.Exception.Message)
            WaitHandle.Set()
        End Sub

    End Class
End Module

