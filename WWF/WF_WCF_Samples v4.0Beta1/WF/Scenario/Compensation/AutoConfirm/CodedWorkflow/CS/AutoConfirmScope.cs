//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Sample.Compensation.AutoConfirmSample
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.IO;
    
    public sealed class AutoConfirmScope : Activity
    {
        WorkflowElement body;
        
        new public WorkflowElement Body
        {
            get
            {
                return this.body;
            }
            set
            {
                this.body = value;
            }
        }

        protected override WorkflowElement CreateBody()
        {
            Variable<CompensationToken> token = new Variable<CompensationToken>() { Name = "Token" };

            return new TryCatch()
            {
                Variables = { token },
                Try = new CompensableActivity()
                {
                    Result = token,
                    Body = this.Body,
                },
                Finally = new If()
                {
                    //Checks to see if the CompensableActivity completed and has not already been compensated
                    Condition = new VisualBasicValue<bool> { ExpressionText = "Token Is Nothing" },
                    Else = new Confirm() { Target = token },
                },
            };
        }
    }
}
