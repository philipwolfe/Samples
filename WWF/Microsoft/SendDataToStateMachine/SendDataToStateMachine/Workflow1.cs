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
using System.Workflow.Activities;

namespace SendDataToStateMachine
{
	public sealed partial class Workflow1: StateMachineWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

        private void CompletedInvoked(object sender, ExternalDataEventArgs e)
        {
            Console.WriteLine(((CompletedEventArgs)e).Reason);
        }
	}

}
