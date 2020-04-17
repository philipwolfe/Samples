//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Activities;
using System.Activities.Statements;
using System.Activities.Validation;

namespace Microsoft.Samples.WorkflowModel
{

    public static class Validation
    {
        public static void Main(string[] args)
        {
            WorkflowElement validationWorkflow = new Sequence
            {
                Activities =
                    {
                        new ValidatableActivity
                        {
                            DaysInAWeek = 3,
                            MonthsInAYear = 12,
                            WarnIfZero = 0
                        }
                    }
            };

            // This will give two violations: one error and one warning 
            Console.WriteLine("1. Validate workflow with build errors and warnings");
            ValidationResults results = ActivityValidationServices.Validate(validationWorkflow);            
            PrintResults(results);

            //This will not give any violations, as we are suppressing the build constraints
            Console.WriteLine("2. Validate workflow with build errors and warnings, but with build constraints suppressed");
            ValidatorSettings validatorSetting = new ValidatorSettings
            {
                SuppressBuildConstraints = true
            };
            results = ActivityValidationServices.Validate(validationWorkflow, validatorSetting);
            PrintResults(results);

            //This will give an error as the sequence does not have 5 children activities and a warning 
            Console.WriteLine("3. Validate workflow with policy violation");
            WorkflowElement policyValidationWorkflow = new Sequence
            {
                DisplayName = "FiveActivitiesSequence",
                Activities =
                {
                    new WriteLine
                    {
                        Text = "Activity 1"
                    }
                }
            };

            validatorSetting = new ValidatorSettings
            {
                AdditionalConstraints =
                    {
                        { typeof(Sequence), new List<Constraint> { ConstraintSequenceMustHaveChildActivities()} }
                    }
            };
            results = ActivityValidationServices.Validate(policyValidationWorkflow, validatorSetting);
            PrintResults(results);
        }

        static Constraint<Sequence> ConstraintSequenceMustHaveChildActivities()
        {
            Variable<Sequence> sequence = new Variable<Sequence>();            

            return new Constraint<Sequence>
            {
                Body = new ActivityAction<Sequence, ValidationContext>
                {
                    Argument1 = sequence,                                        
                    Handler = new AssertValidation
                    {
                        Assertion = new InArgument<bool>((env) => sequence.Get(env).Activities.Count == 5),
                        Message = new InArgument<string>((env) => string.Format("Sequence '{0}' must have 5 children activities.", sequence.Get(env).DisplayName))
                    }
                }
            };
        }

        static void PrintResults(ValidationResults results)
        {
            Console.WriteLine();
            if (results.AllViolations.Count == 0)
            {
                Console.WriteLine("No warnings or errors");
            }
            else
            {
                foreach (ConstraintViolation violation in results.AllViolations)
                {
                    Console.WriteLine((violation.IsWarning ? "Warning " : "Error ") + violation.ErrorCode + ": " + violation.Message);
                }
            }
            Console.WriteLine();
        }   
        
    }
}


