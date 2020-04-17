//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
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
using System.Workflow.Activities;

namespace BaseStateMachineLibrary
{
	public partial class BaseWorkflow: StateMachineWorkflowActivity
	{
		public BaseWorkflow()
		{
			InitializeComponent();
        }

        public void codeActivity_ExecuteCode(object sender, EventArgs e)
        {
            if (purchaseOrder != null)
                Console.WriteLine(purchaseOrder.Amount.ToString());
            else
                Console.WriteLine("purchaseOrder is null");
        }

        public void Greater(object sender, EventArgs e)
        {
            Console.WriteLine("PurchaseOrder greater than 5000");
        }

        public void Less(object sender, EventArgs e)
        {
            Console.WriteLine("PurchaseOrder less than 5000");
        }

        private PurchaseOrder purchaseOrder = null;

        public PurchaseOrder PurchaseOrder
        {
            get
            {
                return this.purchaseOrder;
            }
            set
            {
                this.purchaseOrder = value;
            }
        }
	}

}
