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

namespace ExpenseLocalServices
{
	using System;
	using System.ComponentModel;
	using System.Collections;
	using System.Security.Principal;

	using System.Workflow.ComponentModel;
	using System.Workflow.Activities;
	using System.Workflow.Runtime;

	[Serializable]
	public class InitiatePOArgs : ExternalDataEventArgs
	{
		int itemId;
		string itemName;
		float amount;

		public InitiatePOArgs()
			: base(Guid.NewGuid())
		{
		}

		public InitiatePOArgs(Guid instanceId, int itemID, string itemName, float amount)
			: base(instanceId)
		{
			this.itemId = itemID;
			this.itemName = itemName;
			this.amount = amount;
		}

		public int ItemId
		{
			get
			{
				return this.itemId;
			}
			set
			{
				this.itemId = value;
			}
		}

		public string ItemName
		{
			get
			{
				return this.itemName;
			}
			set
			{
				this.itemName = value;
			}
		}

		public float Amount
		{
			get
			{
				return this.amount;
			}
			set
			{
				this.amount = value;
			}
		}
	}

	[ExternalDataExchangeAttribute()]
	public interface IStartPurchaseOrder
	{
		event EventHandler<InitiatePOArgs> InitiatePurchaseOrder;
	}

	// Use the code example below to register the workflow communications interface with WorkflowServiceContainer
	// WorkflowRuntime container = new WorkflowRuntime(new WorkflowRuntimeSection());
	//
	// container.AddService(new IStartPurchaseOrderImpl());
	public class IStartPurchaseOrderImpl : IStartPurchaseOrder
	{

		public event EventHandler<InitiatePOArgs> InitiatePurchaseOrder;

		public void InvokePORequest(Guid instanceId, int itemId, float itemCost, string itemName, IIdentity identity)
		{
			InitiatePOArgs args = new InitiatePOArgs(instanceId, itemId, itemName, itemCost);

			args.Identity = identity.ToString();
			Console.WriteLine("Purchase Order initiated by: {0}", identity.Name);

			if (InitiatePurchaseOrder != null)
				InitiatePurchaseOrder(null, args);
		}
	}
}

