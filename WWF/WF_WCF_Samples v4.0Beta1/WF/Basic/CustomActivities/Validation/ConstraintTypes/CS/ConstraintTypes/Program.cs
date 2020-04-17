//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Activities.Validation;

namespace Microsoft.Samples.ConstraintTypes
{
    class Program
    {
        static void Main()
        {
            CreateProduct phone = new CreateProduct()
            {
                Price = 20.35,
                Cost = 22.95
            };
            ValidatorSettings validatorSettings = new ValidatorSettings
            {
                AdditionalConstraints =
                    {                        
                        { typeof(CreateProduct), new List<Constraint> {CreateProductConstraints.MaxPrice()} } //Policy Constraint
                    }
            };
            ValidationResults results = ActivityValidationServices.Validate(phone, validatorSettings);
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
                    Console.WriteLine((violation.IsWarning ? "Warning " : "Error ") + violation.ErrorCode + ": " + violation.Message);
                }
            }
            Console.WriteLine();
        }
    }
}
