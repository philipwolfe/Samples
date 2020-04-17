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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace OrderWorkflows
{
	public sealed partial class Workflow1: StateMachineWorkflowActivity
	{
        private string orderCanceledError = "Order has been canceled";

        public string OrderCanceledError
        {
            get { return orderCanceledError; }
        }

        public Workflow1()
		{
			InitializeComponent();
		}

        public static DependencyProperty OrderEvtArgsProperty = DependencyProperty.Register("OrderEvtArgs", typeof(OrderLocalServices.OrderEventArgs), typeof(OrderWorkflows.Workflow1));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public OrderLocalServices.OrderEventArgs OrderEvtArgs
        {
            get
            {
                return ((OrderLocalServices.OrderEventArgs)(base.GetValue(OrderWorkflows.Workflow1.OrderEvtArgsProperty)));
            }
            set
            {
                base.SetValue(OrderWorkflows.Workflow1.OrderEvtArgsProperty, value);
            }
        }

        public static DependencyProperty OrderSenderProperty = DependencyProperty.Register("OrderSender", typeof(System.Object), typeof(OrderWorkflows.Workflow1));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public Object OrderSender
        {
            get
            {
                return ((object)(base.GetValue(OrderWorkflows.Workflow1.OrderSenderProperty)));
            }
            set
            {
                base.SetValue(OrderWorkflows.Workflow1.OrderSenderProperty, value);
            }
        }

        private void OrderCreated_Invoked(object sender, ExternalDataEventArgs e)
        {

        }

        private void OrderShipped_Invoked(object sender, ExternalDataEventArgs e)
        {

        }
	}

}
