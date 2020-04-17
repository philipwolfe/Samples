'--------------------------------------------------------------------------------
' This file is part of the Windows Workflow Foundation Sample Code
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

Imports System.Workflow.Runtime.Hosting
Imports System.Collections.Generic
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim workflowRuntime As System.Workflow.Runtime.WorkflowRuntime = Application("WorkflowRuntime")

        Dim sqlPersistence As SqlWorkflowPersistenceService = workflowRuntime.GetService(Of SqlWorkflowPersistenceService)()
        Dim workflows As List(Of SqlPersistenceWorkflowInstanceDescription) = sqlPersistence.GetAllWorkflows()
        workflowTable.Rows.Clear()

        If workflows.Count > 0 Then
            For Each description As SqlPersistenceWorkflowInstanceDescription In workflows
                Dim linkText As String = String.Format("<a href=Order.aspx?OrderNumber={0}>{0}</a><br/>", description.WorkflowInstanceId.ToString())
                Dim row As TableRow = New TableRow()
                Dim cell As TableCell = New TableCell()
                cell.Text = linkText
                row.Cells.Add(cell)
                workflowTable.Rows.Add(row)
            Next
        Else
            HttpContext.Current.Response.Redirect("Order.aspx")
        End If
    End Sub

    Protected Sub btnCreateNewOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateNewOrder.Click
        HttpContext.Current.Response.Redirect("Order.aspx")
    End Sub
End Class
