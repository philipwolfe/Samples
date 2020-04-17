//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation Sample Code.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------
 
using System;
using System.Web.UI.WebControls;
using System.Workflow.Runtime;
using OrderLocalServices;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;
using System.Web;

public partial class Default2 : System.Web.UI.Page
{
    private void StartWorkflow()
    {
        WorkflowRuntime workflowRuntime = Application["WorkflowRuntime"] as WorkflowRuntime;

        // Now get a refernece to the ManualWorkflowSchedulerService
        ManualWorkflowSchedulerService scheduler =
            workflowRuntime.GetService<ManualWorkflowSchedulerService>();

        ExternalDataExchangeService dataService = workflowRuntime.GetService<ExternalDataExchangeService>();
        OrderLocalServices.OrderService orderService = workflowRuntime.GetService<OrderLocalServices.OrderService>();
        if (orderService == null)
        {
            orderService = new OrderLocalServices.OrderService();
            dataService.AddService(orderService);
        }

        //// Attach to the WorkflowCompleted event
        workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(WorkflowRuntime_WorkflowCompleted);
        WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(typeof(OrderWorkflows.Workflow1));
        workflowInstance.Start();

        // Now run the workflow.  This is necessary when 
        // ...using the ManualWorkflowSchedulerService
        scheduler.RunWorkflow(workflowInstance.InstanceId);

        this.lblWorkflowInstanceId.Text = workflowInstance.InstanceId.ToString();
        this.lblOrderStatus.Text = GetCurrentState(workflowInstance.InstanceId);
    }

    private string GetCurrentState(Guid instanceId)
    {
        StateMachineWorkflowInstance stateInstance = new StateMachineWorkflowInstance(Application["WorkflowRuntime"] as WorkflowRuntime, instanceId);
        return stateInstance.CurrentStateName;
    }

    void WorkflowRuntime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
    {
        HttpContext.Current.Response.Redirect(string.Format("OrderCompleted.aspx?OrderNumber={0}&InstanceID={1}", txtOrderNumber.Text, lblWorkflowInstanceId.Text), false);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack )
        {
            lblWorkflowInstanceId.Text = string.Empty;
            this.StartWorkflow();
            this.btnCreateOrder.Enabled = true;
        }
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

                this.btnProcessOrder.Enabled = true;
                break;
            case "btnProcessOrder":
                currentButton.Enabled = false;

                orderService.RaiseOrderProcessedEvent(txtOrderNumber.Text, instanceId);
                scheduler.RunWorkflow(instanceId);
                lblOrderStatus.Text = GetCurrentState(instanceId);

                this.btnShipOrder.Enabled = true; 
                break;
            case "btnShipOrder":
                currentButton.Enabled = false;
                orderService.RaiseOrderShippedEvent(txtOrderNumber.Text, instanceId);
                scheduler.RunWorkflow(instanceId);
                break;
        }
    }
}
