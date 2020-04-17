//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Validation;

namespace Microsoft.Samples.ContainmentValidation
{
    class Program
    {
        static void Main()
        {           

            WorkflowElement root1 = new ActivityCity
            {
                Name = "Vancouver"
            };
            ValidationResults results = ActivityValidationServices.Validate(root1);
            PrintResults(results);
            
            WorkflowElement root2 = new ActivityCountry
            {
                Name = "Canada",
                Cities =
                {                            
                    new ActivityCity
                    {
                        Name = "Montreal"
                    }
                }
            };
            results = ActivityValidationServices.Validate(root2);
            PrintResults(results);  
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
                    Console.WriteLine((violation.IsWarning ? "Warning " : "Error ") + violation.ErrorCode + " at " + violation.PropertyName + ": " + violation.Message);
                }
            }

            Console.WriteLine();
        }
    }
}
