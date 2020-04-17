//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Sample.Transaction.TransactedParallelConvoy.Common
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.ServiceModel.Activities;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using Parallel = System.Activities.Statements.Parallel;

    public sealed class TransactedConvoyScope : Activity
    {
        public TransactedConvoyScope() : base()
        {
            this.Variables = new DesignTimeAwareCollection<Variable>(this);
            this.Convoy = new DesignTimeAwareCollection<TransactedReceiveScope>(this);
            this.CompletionCondition = true;
            this.Body = InternalImplementation;
        }
        
        public Collection<Variable> Variables { get; set; }
        public Collection<TransactedReceiveScope> Convoy { get; set; }
        public WorkflowElement<bool> CompletionCondition { get; set; }
        public WorkflowElement ConvoyBody { get; set; }	

        protected override void OnOpen(DeclaredEnvironment environment)
        {
            if (Convoy.Count == 0)
            {
                throw new ValidationException("There must be at least one TransactedReceiveScope in the convoy.");
            }

            ValidateChildren();

            base.OnOpen(environment);
        }

        private void ValidateChildren()
        {
            foreach (TransactedReceiveScope trs in this.Convoy)
            {
                if (trs.ReceiveActivity.CanCreateInstance == true)
                {
                    throw new ApplicationException("CanCreateInstance for receives in the convoy must be false");
                }
            }
        }

        private WorkflowElement InternalImplementation()
        {
            Variable<RuntimeTransactionHandle> rth = new Variable<RuntimeTransactionHandle>();
            Parallel p = new Parallel();
            Sequence s = new Sequence();

            p.CompletionCondition = this.CompletionCondition;
            
            foreach (TransactedReceiveScope trs in this.Convoy)
            {
                p.Branches.Add(trs);
            }

            foreach (Variable v in this.Variables)
            {
                s.Variables.Add(v);
            }

            s.Activities.Add(p);
            s.Activities.Add(this.ConvoyBody);

            return new Sequence
            {
                Variables = { rth },
                Activities =
                {
                    new HandleScope<RuntimeTransactionHandle>
                    {
                        Body = s,
                        Handle = new InArgument<RuntimeTransactionHandle>(rth),
                    }
                }
            };
        }
    }    
}
