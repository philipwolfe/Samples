//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Samples.Rules
{
    using System;
    using System.Activities;
    using System.ComponentModel;
    using System.Workflow.Activities.Rules;
    using System.Workflow.ComponentModel.Compiler;

    [Designer(typeof(Microsoft.Samples.Rules.PolicyDesigner))]
    public sealed class Policy40Activity: NativeActivity
    {
        public RuleSet RuleSet { get; set; }

        [IsRequired]
        public InOutArgument TargetObject { get; set; }
        public OutArgument<ValidationErrorCollection> ValidationErrors { get; set; }
      
        protected override void OnOpen(DeclaredEnvironment environment)
        {
            if (this.RuleSet == null)
            {
                throw new System.ArgumentNullException("RuleSet property can't be null");
            }
        }

        protected override void Execute(ActivityExecutionContext context)
        {            
            // validate before running
            Type targetType = this.TargetObject.Get(context).GetType();
            RuleValidation validation = new RuleValidation(targetType, null);
            if (!this.RuleSet.Validate(validation))
            {
                // set the validation error out argument
                this.ValidationErrors.Set(context, validation.Errors);

                // throw a validation exception
                throw new ValidationException(string.Format("The ruleset is not valid. {0} validation errors found (check the ValidationErrors property for more information).", validation.Errors.Count));                
            }
            
            // execute the ruleset
            object evaluatedTarget = this.TargetObject.Get(context);
            RuleEngine engine = new RuleEngine(this.RuleSet, validation);            
            engine.Execute(evaluatedTarget);

            // update the target object
            this.TargetObject.Set(context, evaluatedTarget);               
        }        
    }
}