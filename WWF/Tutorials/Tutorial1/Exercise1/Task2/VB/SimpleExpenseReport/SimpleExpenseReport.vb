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
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.Workflow.Activities.Rules
Imports System.Workflow.ComponentModel

Namespace Microsoft.Samples.Workflow.Tutorials.SequentialWorkflow
	Public Class ExpenseReportWorkflow : Inherits SequentialWorkflowActivity

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub InitializeComponent()
			Me.CanModifyActivities = True
			Me.Name = "ExpenseReportWorkflow"
			Me.CanModifyActivities = False
		End Sub
	End Class
End Namespace
