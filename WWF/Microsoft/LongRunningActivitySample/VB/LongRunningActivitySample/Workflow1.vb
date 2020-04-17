'--------------------------------------------------------------------------------
' This file is a "Sample" from Windows Workflow Foundation
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
Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Collections
Imports System.Drawing
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.ComponentModel.Serialization
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.Workflow.Activities.Rules

Namespace LongRunningWorkflow
    Partial Public NotInheritable Class Workflow1
        Inherits SequentialWorkflowActivity
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub BeforeDelay_Execute(ByVal sender As Object, ByVal e As EventArgs)
            Console.WriteLine("Beginning Delay")
        End Sub

        Private Sub AfterDelay_Execute(ByVal sender As Object, ByVal e As EventArgs)
            Console.WriteLine(String.Format("Finished Delay ({0} seconds)", Me.delayActivity1.TimeoutDuration.Seconds))
        End Sub

        Private Sub AfterBranch_Execute(ByVal sender As Object, ByVal e As EventArgs)
            Console.WriteLine("Finished Branch")
        End Sub

        Private Sub BeforeBranch_Execute(ByVal sender As Object, ByVal e As EventArgs)
            Console.WriteLine("Beginning Branch")
        End Sub
    End Class

End Namespace
