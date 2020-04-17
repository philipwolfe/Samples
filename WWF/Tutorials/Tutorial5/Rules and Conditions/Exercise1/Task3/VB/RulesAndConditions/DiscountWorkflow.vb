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
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Reflection
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.ComponentModel.Serialization
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.Workflow.Activities.Rules

Namespace Microsoft.Samples.Workflow.Tutorials.RulesAndConditions
    Public NotInheritable Class DiscountWorkflow : Inherits SequentialWorkflowActivity
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.Name = "DiscountWorkflow"
        End Sub
    End Class
End Namespace
