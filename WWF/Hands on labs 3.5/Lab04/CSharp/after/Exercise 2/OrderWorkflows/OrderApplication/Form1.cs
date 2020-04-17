//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Workflow.ComponentModel;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;
using System.Threading;
using StateMachineTracking;

namespace OrderApplication
{
	public partial class Form1 : Form
	{

		private WorkflowRuntime _WFRuntime;
		private OrderLocalServices.OrderService _OrderService;

		private delegate void UpdateListItemDelegate(WorkflowInstance wfinstance, string WorkflowState, string WorkflowStatus);
		private delegate void UpdateButtonStatusDelegate();
        private StateMachineTrackingService stateMachineTrackingService;
        private Dictionary<string, StateMachineInstance> stateMachineInstances;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
            this.stateMachineInstances = new Dictionary<string, StateMachineInstance>();
            this.DisableButtons();

            // Create and start the WorkflowRuntime
			this.StartWorkflowRuntime();
		}

        private void StartWorkflowRuntime()
		{
			// Create a new Workflow Runtime for this application
			_WFRuntime = new WorkflowRuntime();

			// Create EventHandlers for the WorkflowRuntime
			_WFRuntime.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(WorkflowRuntime_WorkflowTerminated);
			_WFRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(WorkflowRuntime_WorkflowCompleted);

            stateMachineTrackingService = new StateMachineTrackingService(_WFRuntime);


			// Add a new instance of the OrderService to the runtime
            ExternalDataExchangeService dataService = new ExternalDataExchangeService();
            _WFRuntime.AddService(dataService);
			_OrderService = new OrderLocalServices.OrderService();
			dataService.AddService(_OrderService);
		}

		private void btnOrderCreated_Click(object sender, EventArgs e)
		{
			// Get the OrderId that was entered by the user
			string strOrderId = this.txtOrderID.Text;

			// Start the Order Workflow
			System.Guid WorkflowInstanceId =
				this.StartOrderWorkflow(strOrderId);

			// Raise an OrderCreated event using the Order Local Service
			_OrderService.RaiseOrderCreatedEvent(strOrderId, WorkflowInstanceId);

			// Add a new item to the ListView for the new workflow
			AddListViewItem(strOrderId, WorkflowInstanceId);

			// Reset the form for adding another Order
			this.txtOrderID.Text = "";
		}

        private void UpdateButtonStatus()
        {
            if (this.InvokeRequired)
            {
                UpdateButtonStatusDelegate updateButtonStatus =
                    new UpdateButtonStatusDelegate(this.UpdateButtonStatus);
                this.Invoke(updateButtonStatus);
            }
            else
            {
                DisableButtons();
                EnableButtons();
            }
        }

        protected void StateMachineInstance_StateChanged(object sender,
                                                 ActivityEventArgs e)
        {
            StateMachineInstance stateMachineInstance =
                                                   (StateMachineInstance)sender;

            if (e.QualifiedId != stateMachineInstance.CompletedState)
            {
                WorkflowInstance workflowInstance =
                                           stateMachineInstance.WorkflowInstance;

                this.UpdateListItem(workflowInstance,
                                      e.QualifiedId.ToString(), "Running");
                this.UpdateButtonStatus();
            }
        } 

		private void btnOrderEvent_Click(object sender, EventArgs e)
        {
			// Get the Name for the button that was clicked
			string strButtonName = ((Button)sender).Name;

			// Get the WorkflowInstanceId for the selected order
			System.Guid WorkflowInstanceId = this.GetSelectedWorkflowInstanceID();

			// Get the OrderID for the selected order
			string strOrderId = this.GetSelectedOrderId();

            this.DisableButtons();

			switch (strButtonName)
			{
				case "btnOrderShipped":
					// Raise an OrderShipped event using the Order Local Service
					_OrderService.RaiseOrderShippedEvent(strOrderId, WorkflowInstanceId);
					break;


				case "btnOrderUpdated":
					// Raise an OrderUpdated event using the Order Local Service
					_OrderService.RaiseOrderUpdatedEvent(strOrderId, WorkflowInstanceId);
					break;

				case "btnOrderCanceled":
					// Raise an OrderCanceled event using the Order Local Service
					_OrderService.RaiseOrderCanceledEvent(strOrderId, WorkflowInstanceId);
					break;


				case "btnOrderProcessed":
					// Raise an OrderProcessed event using the Order Local Service
					_OrderService.RaiseOrderProcessedEvent(strOrderId, WorkflowInstanceId);
					break;
			}
        }

		private System.Guid StartOrderWorkflow(string strOrderID)
		{
			// Create a new GUID for the WorkflowInstanceId
			System.Guid WorkflowInstanceId = System.Guid.NewGuid();

            StateMachineInstance stateMachineInstance =
                stateMachineTrackingService.RegisterInstance(
                    typeof(OrderWorkflows.Workflow1), WorkflowInstanceId);
            stateMachineInstance.StateChanged +=
              new EventHandler<ActivityEventArgs>(StateMachineInstance_StateChanged);

            stateMachineInstance.StartWorkflow();
            stateMachineInstances.Add(WorkflowInstanceId.ToString(),
                                        stateMachineInstance);

			// Return the WorkflowInstanceId
			return WorkflowInstanceId;
		}

        private StateMachineInstance GetSelectedStateMachineInstance()
        {
            // Get the WorkflowInstanceId for the selected item
            string workflowInstanceId = this.lstvwOrders.SelectedItems[0].Text;

            // Return the StateMachineInstance object 
            return stateMachineInstances[workflowInstanceId];
        }

        private void EnableButtons()
        {
            if (this.lstvwOrders.SelectedItems.Count == 0)
            {
                return;
            }

            string workflowStatus =
                               this.lstvwOrders.SelectedItems[0].SubItems[3].Text;

            if ((workflowStatus.Equals("Completed"))
                || (workflowStatus.Equals("Terminated")))
            {
                return;
            }


            // Return the StateMachineInstance object 
            StateMachineInstance stateMachineInstance =
                                          this.GetSelectedStateMachineInstance();

            if (stateMachineInstance.CurrentState == null)
            {
                return;
            }


            if (stateMachineInstance.MessagesAllowed.Contains("OrderCanceled"))
                this.btnOrderCanceled.Enabled = true;

            if (stateMachineInstance.MessagesAllowed.Contains("OrderProcessed"))
                this.btnOrderProcessed.Enabled = true;

            if (stateMachineInstance.MessagesAllowed.Contains("OrderShipped"))
                this.btnOrderShipped.Enabled = true;

            if (stateMachineInstance.MessagesAllowed.Contains("OrderUpdated"))
                this.btnOrderUpdated.Enabled = true;

        }

        private void DisableButtons()
        {
            this.btnOrderCanceled.Enabled = false;
            this.btnOrderProcessed.Enabled = false;
            this.btnOrderShipped.Enabled = false;
            this.btnOrderUpdated.Enabled = false;
        }

		private ListViewItem AddListViewItem(string strOrderID, System.Guid WorkflowInstanceId)
		{
			// Add a new item to the Listview control using the WorkflowInstanceId
			// ...as the Text and Key value
			ListViewItem lstvwitem =
				this.lstvwOrders.Items.Add(WorkflowInstanceId.ToString(),
				WorkflowInstanceId.ToString(), "");

			// add the OrderId, Workflow State, and Workflow Status columns
			lstvwitem.SubItems.Add(txtOrderID.Text);
			lstvwitem.SubItems.Add("");
			lstvwitem.SubItems.Add("");
			lstvwitem.Tag = WorkflowInstanceId.ToString();

			// Select the new ListItem, which will cause the buttons to refresh.
			lstvwitem.Selected = true;

			// Return the new ListViewItem
			return lstvwitem;
		}


		void WorkflowRuntime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
		{
			this.UpdateListItem(e.WorkflowInstance, "", "Completed");
		}

		void WorkflowRuntime_WorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
		{
			this.UpdateListItem(e.WorkflowInstance, "", "Terminated");
		}


		private System.Guid GetSelectedWorkflowInstanceID()
		{
			if (this.lstvwOrders.SelectedItems.Count == 0)
			{
				throw new ApplicationException("No Orders are selected");
			}

			// Get the WorkflowInstanceId for the selected ListItem
			string strWorkflowInstanceId = 
				this.lstvwOrders.SelectedItems[0].Text;

			// Create a new GUID for the WorkflowInstanceID
			return new System.Guid(strWorkflowInstanceId);
		}

		private string GetSelectedOrderId()
		{
			if (this.lstvwOrders.SelectedItems.Count == 0)
			{
				throw new ApplicationException("No Orders are selected");
			}

			// Get the OrderID for the selected order
			return this.lstvwOrders.SelectedItems[0].SubItems[1].Text;
		}


		private void UpdateListItem(WorkflowInstance wfinstance, string WorkflowState, string WorkflowStatus)
		{

			if (this.lstvwOrders.InvokeRequired)
			{
				// This code is executing on a different thread than the one that
				// ...created the ListView, so we need to use the Invoke method.
				
				// Create an instance of the delegate for invoking this method
				UpdateListItemDelegate dlgtUpdateListViewItem =
					new UpdateListItemDelegate(this.UpdateListItem);

				// Create the array of parameters for this method
				object[] args = new object[3] { wfinstance, WorkflowState, WorkflowStatus };

				// Invoke this method on the UI thread
				this.lstvwOrders.Invoke(dlgtUpdateListViewItem, args);
			}
			else
			{
				// Get the ListViewItem for the specified WorkflowInstance
				string strInstanceId = wfinstance.InstanceId.ToString();
				ListViewItem lvitemOrder = lstvwOrders.Items[strInstanceId];

				if (lvitemOrder == null)
				{
					return;
				}

				// Update the Workflow State & Status column values
				lvitemOrder.SubItems[2].Text = WorkflowState;
				lvitemOrder.SubItems[3].Text = WorkflowStatus;
			}
		}

		private void lstvwOrders_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
            if (e.Item.Selected)
            {
                this.UpdateButtonStatus();
            }
            else
            {
                this.DisableButtons();
            }
		}
	}
}