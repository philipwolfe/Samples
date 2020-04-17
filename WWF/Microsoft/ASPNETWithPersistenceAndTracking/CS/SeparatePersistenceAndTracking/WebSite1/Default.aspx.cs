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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WorkflowRuntime workflowRuntime = Application["WorkflowRuntime"] as WorkflowRuntime;

        SqlWorkflowPersistenceService sqlPersistence = workflowRuntime.GetService<SqlWorkflowPersistenceService>();
        List<SqlPersistenceWorkflowInstanceDescription> workflows = sqlPersistence.GetAllWorkflows() as List<SqlPersistenceWorkflowInstanceDescription>;
        workflowTable.Rows.Clear();

        if (workflows.Count > 0)
        {
            foreach (SqlPersistenceWorkflowInstanceDescription description in workflows)
            {
                string linkText = string.Format("<a href=Order.aspx?OrderNumber={0}>{0}</a><br/>", description.WorkflowInstanceId.ToString());
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = linkText;
                row.Cells.Add(cell);
                workflowTable.Rows.Add(row);
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("Order.aspx");
        }
    }
    protected void btnCreateNewOrder_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Redirect("Order.aspx");
    }
}
