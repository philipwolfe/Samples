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

        Shared Sub Main(ByVal args As String())
            Dim workflowRuntime As WorkflowRuntime = New WorkflowRuntime()
            workflowRuntime.StartRuntime()
            AddHandler workflowRuntime.WorkflowCompleted, _
                AddressOf workflowRuntime_WorkflowCompleted

            Dim type As Type = GetType(HostingWorkflows)
            Dim workflowInstance As WorkflowInstance = workflowRuntime.CreateWorkflow(type)
            workflowInstance.Start()

            waitHandle.WaitOne()
            workflowRuntime.StopRuntime()
        End Sub

        Private Shared Sub workflowRuntime_WorkflowCompleted _
            (ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
            waitHandle.Set()
        End Sub
    End Class
End Namespace
