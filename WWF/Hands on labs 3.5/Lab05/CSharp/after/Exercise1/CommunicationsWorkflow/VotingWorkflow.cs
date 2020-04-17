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

namespace CommunicationsWorkflow
{
	public sealed partial class VotingWorkflow: SequentialWorkflowActivity
	{
		public VotingWorkflow()
		{
			InitializeComponent();
		}

        private void OnRejected(object sender, ExternalDataEventArgs e)
        {
            Console.WriteLine(string.Format("Proposal Rejected by {0}",
                                votingArgs.Alias));
        }

        private void OnApproved(object sender, ExternalDataEventArgs e)
        {
            Console.WriteLine(string.Format("Proposal Approved by {0}",
                                votingArgs.Alias));
        }

        public static DependencyProperty votingArgsProperty = DependencyProperty.Register("votingArgs", typeof(CommunicationsWorkflow.VotingEventArgs), typeof(CommunicationsWorkflow.VotingWorkflow));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public VotingEventArgs votingArgs
        {
            get
            {
                return ((CommunicationsWorkflow.VotingEventArgs)(base.GetValue(CommunicationsWorkflow.VotingWorkflow.votingArgsProperty)));
            }
            set
            {
                base.SetValue(CommunicationsWorkflow.VotingWorkflow.votingArgsProperty, value);
            }
        }
	}
}
