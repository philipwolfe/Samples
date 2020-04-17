//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.WorkflowModel
{
    using System;
    using System.Collections.Generic;
    using System.Activities;    
    using System.Activities.Statements;
    using System.Activities.Validation;

    public sealed class ValidatableActivity : CodeActivity
    {
        public int DaysInAWeek { get; set; }
        public int MonthsInAYear { get; set; }
        public int WarnIfZero { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            // not needed for the sample
        }

        protected override void OnGetConstraints(IList<Constraint> constraints)
        {
            //build constraints
            constraints.Add(ConstraintDaysInAWeek());
            constraints.Add(ConstraintMonthsInAYear());
            constraints.Add(ConstraintWarnIfZero());
        }

        static Constraint ConstraintDaysInAWeek()
        {
            Variable<ValidatableActivity> element = new Variable<ValidatableActivity>();

            return new Constraint<ValidatableActivity>
            {
                Body = new ActivityAction<ValidatableActivity, ValidationContext>
                {
                    Argument1 = element,
                    Handler = new AssertValidation
                    {
                        Assertion = new InArgument<bool>((env) => element.Get(env).DaysInAWeek == 7),
                        Message = new InArgument<string>((env) => "Days in a week cannot be " + element.Get(env).DaysInAWeek)
                    }
                }
            };
        }

        static Constraint ConstraintMonthsInAYear()
        {
            Variable<ValidatableActivity> element = new Variable<ValidatableActivity>();

            return new Constraint<ValidatableActivity>
            {
                Body = new ActivityAction<ValidatableActivity,ValidationContext>
                {
                    Argument1 = element,
                    Handler = new If
                    {
                        Condition = new InArgument<bool>((env) => element.Get(env).MonthsInAYear != 12),
                        Then = new AddViolation
                        {
                            Message = new InArgument<string>((env) => "Months In a year cannot be " + element.Get(env).MonthsInAYear)
                        }
                    }
                }
            };
        }

        static Constraint ConstraintWarnIfZero()
        {
            Variable<ValidatableActivity> element = new Variable<ValidatableActivity>();

            return new Constraint<ValidatableActivity>
            {
                Body = new ActivityAction<ValidatableActivity, ValidationContext>
                {
                    Argument1 = element,
                    Handler = new Sequence
                    {
                        Activities =
                            {
                                new AssertValidation
                                {
                                    IsWarning = true,
                                    Assertion = new InArgument<bool>((env) => element.Get(env).WarnIfZero != 0),
                                    Message = "Consider changing WarnIfZero to not be 0"
                                }
                            }
                    }
                }
            };
        }
    }
}
