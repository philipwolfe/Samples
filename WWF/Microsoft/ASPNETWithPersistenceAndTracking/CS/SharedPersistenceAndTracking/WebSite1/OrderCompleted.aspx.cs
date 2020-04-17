//--------------------------------------------------------------------------------
// This file is part of the Windows Workflow Foundation Sample Code
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Web;

public partial class OrderCompleted : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblOrderNumber.Text = HttpContext.Current.Request.QueryString["OrderNumber"];
        lblWorkflowInstanceId.Text = HttpContext.Current.Request.QueryString["InstanceID"];
    }

    protected void btnNewOrder_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Redirect("Order.aspx", true);
    }

    protected void btnExistingOrder_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Redirect("Default.aspx", false);
    }
}
