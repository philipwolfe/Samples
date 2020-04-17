using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel.Compiler;

namespace CustomActivities
{
    public class PartialCompletionActivityValidator : CompositeActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors =  base.Validate(manager, obj);

            PartialCompletionActivity act = obj as PartialCompletionActivity;

            if (act != null && act.Parent != null)
            {
                if (act.EnabledActivities.Count < act.RequiredCompletions)
                {
                    errors.Add(new ValidationError("The value must be less than or equal to the number of child activities", 999, false, "RequiredCompletions"));

                }
            }

            return errors;
        }
    }
}
