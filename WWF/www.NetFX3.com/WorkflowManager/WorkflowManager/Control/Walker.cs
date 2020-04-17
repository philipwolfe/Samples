//---------------------------------------------------------------------
//  This file is part of the NetFx3.com web site samples.
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
#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel;
using System.Collections;

#endregion

namespace Microsoft.Workflow.Samples.WorkflowManager
{
	#region class Walker
	public delegate void WalkerEventHandler(Walker walker, WalkerEventArgs eventArgs);

	public sealed class WalkerEventArgs : EventArgs
	{
		private Activity currentActivity = null;

		public WalkerEventArgs(Activity currentActivity)
		{
			this.currentActivity = currentActivity;
		}

		public Activity CurrentActivity
		{
			get
			{
				return this.currentActivity;
			}
		}
	}

	public class Walker
	{
		internal event WalkerEventHandler FoundActivity;

		public Walker()
		{
		}

		public void Walk(Activity seedActivity)
		{
			Queue queue = new Queue();

			queue.Enqueue(seedActivity);
			while (queue.Count > 0)
			{
				Activity activity = queue.Dequeue() as Activity;

				if (FoundActivity != null)
				{
					WalkerEventArgs args = new WalkerEventArgs(activity);
					FoundActivity(this, args);
				}

				if (activity is CompositeActivity)
					foreach (Activity activity2 in ((CompositeActivity)activity).Activities)
						queue.Enqueue(activity2);
			}
		}
	}
	#endregion
}
