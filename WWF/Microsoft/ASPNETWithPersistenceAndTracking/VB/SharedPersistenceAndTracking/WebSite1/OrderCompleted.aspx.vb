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

Partial Class OrderCompleted
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblOrderNumber.Text = HttpContext.Current.Request.QueryString("OrderNumber")
        lblWorkflowInstanceId.Text = HttpContext.Current.Request.QueryString("InstanceID")
    End Sub

    Protected Sub btnExistingOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExistingOrder.Click
        HttpContext.Current.Response.Redirect("Default.aspx", False)
    End Sub

    Protected Sub btnNewOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewOrder.Click
        HttpContext.Current.Response.Redirect("Order.aspx", True)
    End Sub
End Class
