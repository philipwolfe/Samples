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
using System.Threading;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Windows.Forms;

namespace CommunicationsWorkflow
{
    [Serializable]
    public class VotingEventArgs : ExternalDataEventArgs
    {
        private string alias;

        public VotingEventArgs(Guid InstanceID, string alias)
            : base(InstanceID)
        {
            this.alias = alias;
        }

        public string Alias
        {
            get { return this.alias; }
            set { this.alias = value; }
        }
    }

    [ExternalDataExchange]
    [CorrelationParameter("alias")]
    internal interface IVotingServiceCorrelated
    {
        [CorrelationAlias("alias", "e.Alias")]
        event EventHandler<VotingEventArgs> ApproveProposal;

        [CorrelationAlias("alias", "e.Alias")]
        event EventHandler<VotingEventArgs> RejectProposal;

        [CorrelationInitializer]
        void CreateBallot(string alias);
    }

    [ExternalDataExchange]
    internal interface IVotingService
    {
        event EventHandler<VotingEventArgs> ApproveProposal;
        event EventHandler<VotingEventArgs> RejectProposal;

        void CreateBallot(string alias);
    }

    internal class VotingService : IVotingServiceCorrelated
    {
        public event EventHandler<VotingEventArgs> ApproveProposal;
        public event EventHandler<VotingEventArgs> RejectProposal;

        public void CreateBallot(string alias)
        {
            Console.WriteLine("Ballot created for " + alias + ".");
            ThreadPool.QueueUserWorkItem(ShowVotingDialog, new VotingEventArgs(WorkflowEnvironment.WorkflowInstanceId, alias));
        }

        public void ShowVotingDialog(object o)
        {
            DialogResult result;
            VotingEventArgs votingEventArgs = o as VotingEventArgs;
            Guid instanceId = votingEventArgs.InstanceId;
            string alias = votingEventArgs.Alias;

            result = MessageBox.Show("Approve Proposal, " + alias + "?", alias + " Ballot", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (ApproveProposal != null)
                    ApproveProposal(null, votingEventArgs);
            }
            else
            {
                if (RejectProposal != null)
                    RejectProposal(null, votingEventArgs);
            }
        }
    }
}
