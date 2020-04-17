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

Public class PromptActivity
    Inherits Activity

    Private m_question As String
    Public Property Question() As String
        Get
            Return m_question
        End Get
        Set(ByVal value As String)
            m_question = value
        End Set
    End Property

    Public Shared AnswerProperty As DependencyProperty = DependencyProperty.Register("Answer", GetType(String), GetType(PromptActivity))

    <Description("The answer to the question")> _
    <Browsable(False)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property Answer() As String
        Get
            Return (CType((MyBase.GetValue(PromptActivity.AnswerProperty)), String))
        End Get
        Set(ByVal Value As String)
            MyBase.SetValue(PromptActivity.AnswerProperty, Value)
        End Set
    End Property

    Protected Overrides Function Execute(ByVal executionContext As ActivityExecutionContext) As ActivityExecutionStatus
        Dim form As New PromptForm(Me.question)
        form.ShowDialog()
        Me.Answer = form.Answer
        Return ActivityExecutionStatus.Closed
    End Function


End Class
