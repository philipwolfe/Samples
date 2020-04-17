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
using System.Web.UI.WebControls;
using System.Workflow.Runtime;
using OrderLocalServices;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;
using System.Web;
using System.Workflow.Runtime.Tracking;
using System.Collections.Generic;
using System.Configuration;

public partial class Default2 : System.Web.UI.Page
{
    private void StartWorkflow()
    {
        WorkflowRuntime workflowRuntime = GetRuntimeAndSubscribeWorkflowCompleted();

        // Now get a reference to the ManualWorkflowSchedulerService
        ManualWorkflowSchedulerService scheduler = workflowRuntime.GetService<ManualWorkflowSchedulerService>();
        
        System.Xml.XmlReader reader = System.Xml.XmlReader.Create(Page.MapPath("Workflow1.xoml"));

        WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(reader);
        workflowInstance.Start();

        // Now run the workflow.  This is necessary when 
        // ...using the ManualWorkflowSchedulerService
        scheduler.RunWorkflow(workflowInstance.InstanceId);

        lblWorkflowInstanceId.Text = workflowInstance.InstanceId.ToString();
        lblOrderStatus.Text = GetCurrentState(workflowInstance.InstanceId);
    }

    private WorkflowRuntime GetRuntimeAndSubscribeWorkflowCompleted()
    {
        WorkflowRuntime workflowRuntime = Application["WorkflowRuntime"] as WorkflowRuntime;

        // Attach to the WorkflowCompleted event
        workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(WorkflowRuntime_WorkflowCompleted);
        return workflowRuntime;
    }

    private string GetCurrentState(Guid instanceId)
    {
        StateMachineWorkflowInstance stateInstance = new StateMachineWorkflowInstance(Application["WorkflowRuntime"] as WorkflowRuntime, instanceId);
        return stateInstance.CurrentStateName;
    }

    void WorkflowRuntime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
    {
        // Release the WorkflowCompleted event
        e.WorkflowInstance.WorkflowRuntime.WorkflowCompleted -= new EventHandler<WorkflowCompletedEventArgs>(WorkflowRuntime_WorkflowCompleted);
        HttpContext.Current.Response.Redirect(string.Format("OrderCompleted.aspx?OrderNumber={0}&InstanceID={1}", txtOrderNumber.Text, lblWorkflowInstanceId.Text), false);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string orderNumber = HttpContext.Current.Request.QueryString["OrderNumber"];
        if (!IsPostBack )
        {
            if (orderNumber == null)
            {
                lblWorkflowInstanceId.Text = string.Empty;
                StartWorkflow();
                btnCreateOrder.Enabled = true;
            }
            else
            {
                GetRuntimeAndSubscribeWorkflowCompleted();
                lblWorkflowInstanceId.Text = orderNumber;
                lblOrderStatus.Text = GetCurrentState(new Guid(orderNumber));
                txtOrderNumber.Text = GetOrderNumber(orderNumber);

                switch (lblOrderStatus.Text)
                {
                    case "WaitingForOrderState":
                        btnCreateOrder.Enabled = true;
                        break;
                    case "OrderOpenState":
                        btnProcessOrder.Enabled = true;
                        break;
                    case "OrderProcessedState":
                        btnShipOrder.Enabled = true;
                        break;
                }
            }
        }
    }

    private string GetOrderNumber(string orderId)
    { 
        IList<SqlTrackingWorkflowInstance> queriedWorkflows = new List<SqlTrackingWorkflowInstance>();

        SqlTrackingQuery sqlTrackingQuery = new SqlTrackingQuery(ConfigurationManager.ConnectionStrings["TrackingStoreConnectionString"].ConnectionString);

        queriedWorkflows = sqlTrackingQuery.GetWorkflows(new SqlTrackingQueryOptions());

        foreach (SqlTrackingWorkflowInstance sqlTrackingWorkflowInstance in queriedWorkflows)
        {
            if (sqlTrackingWorkflowInstance.WorkflowInstanceId.ToString().Equals(orderId))
            {
                IList<ActivityTrackingRecord> records = sqlTrackingWorkflowInstance.ActivityEvents;

                ActivityTrackingRecord record = (ActivityTrackingRecord)records[records.Count - 1];

                OrderLocalServices.OrderEventArgs ordEventArgs = (OrderLocalServices.OrderEventArgs)record.Body[0].Data;
                if (ordEventArgs == null)
                    break;
                return ordEventArgs.OrderId;
            }
        }

        //  If we didn't find it send back the default value.
        return "12345";
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        Button currentButton = sender as Button;
        Guid instanceId = new Guid(this.lblWorkflowInstanceId.Text);
        OrderService orderService = (Application["WorkflowRuntime"] as WorkflowRuntime).GetService<OrderService>();
        ManualWorkflowSchedulerService scheduler = (Application["WorkflowRuntime"] as WorkflowRuntime).GetService<ManualWorkflowSchedulerService>();

        switch (currentButton.ID)
        { 
            case "btnCreateOrder":
                currentButton.Enabled = false;

                orderService.RaiseOrderCreatedEvent(txtOrderNumber.Text, instanceId);
                scheduler.RunWorkflow(instanceId);
                lblOrderStatus.Text = GetCurrentState(instanceId);

                btnProcessOrder.Enabled = true;
                break;
            case "btnProcessOrder":
                currentButton.Enabled = false;

                orderService.RaiseOrderProcessedEvent(txtOrderNumber.Text, instanceId);
                scheduler.RunWorkflow(instanceId);
                lblOrderStatus.Text = GetCurrentState(instanceId);

                btnShipOrder.Enabled = true; 
                break;
            case "btnShipOrder":
                currentButton.Enabled = false;
                orderService.RaiseOrderShippedEvent(txtOrderNumber.Text, instanceId);
                scheduler.RunWorkflow(instanceId);
                break;
        }
    }
}
