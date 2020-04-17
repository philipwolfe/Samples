'---------------------------------------------------------------------
'  This file is part of the  BPEL for Windows Workflow Foundation Code Samples.
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

Class Program

    Shared WaitHandle As New AutoResetEvent(False)

    Shared Sub Main()
        Using workflowRuntime As New WorkflowRuntime()
            AddHandler workflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
            AddHandler workflowRuntime.WorkflowTerminated, AddressOf OnWorkflowTerminated

            Dim workflowType As Type = GetType(CompensationSample.CompensationWorkflow)

            Dim typeProvider As TypeProvider = New TypeProvider(workflowRuntime)
            typeProvider.AddAssembly(workflowType.Assembly)
            workflowRuntime.AddService(typeProvider)

            Dim messagingService As BpelInMemoryMessagingService = New BpelInMemoryMessagingService()
            messagingService.Runtime = workflowRuntime
            messagingService.RegisterProxy("FileServiceSoap", workflowType.Assembly.Location)
            workflowRuntime.AddService(messagingService)

            Dim workflowInstance As WorkflowInstance
            workflowInstance = workflowRuntime.CreateWorkflow(workflowType)
            workflowInstance.Start()
            WaitHandle.WaitOne()
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

