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

Imports System
Imports System.Threading
Imports System.Workflow.Runtime


Class WorkflowApplication
    Shared WaitHandle As New AutoResetEvent(False)

    Shared Sub Main()
        Using runtime As New WorkflowRuntime()
            runtime.AddService(New FileWatcherService(runtime))

            AddHandler runtime.WorkflowCompleted, AddressOf OnWorkflowCompleted
            AddHandler runtime.WorkflowTerminated, AddressOf OnWorkflowTerminated

            Dim workflowInstance As WorkflowInstance
            workflowInstance = runtime.CreateWorkflow(GetType(FileWatcherWorkflow))
            workflowInstance.Start()

            WaitHandle.WaitOne()

            Console.WriteLine("The workflow is complete.")
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


