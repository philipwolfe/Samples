'-------------------------------------------------------------------
' Copyright (c) Microsoft Corporation. All rights reserved
'-------------------------------------------------------------------

Imports System.Activities

Public Class SimpleNativeActivity
    Inherits NativeActivity

    Public Property Body As WorkflowElement

    Protected Overloads Overrides Sub Execute(ByVal context As System.Activities.ActivityExecutionContext)
        context.ScheduleActivity(Body)
    End Sub
End Class
