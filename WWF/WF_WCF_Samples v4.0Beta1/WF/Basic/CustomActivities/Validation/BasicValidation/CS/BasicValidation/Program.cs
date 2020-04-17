//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities.Validation;

namespace Microsoft.Samples.BasicValidation
{
    class Program
    {
        static void Main()
        {
            CreateProduct radio = new CreateProduct()
            {
                Price = 14,  
                Cost = 11,                           
            };        
            ValidationResults results = ActivityValidationServices.Validate(radio);            
            PrintResults(results);

            CreateProduct phone = new CreateProduct()
            {
                Price = 11,
                Cost = 14,
            };            
            results = ActivityValidationServices.Validate(phone);
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
                    Console.WriteLine((violation.IsWarning?"Warning ": "Error ") + violation.ErrorCode + ": " + violation.Message);
                }
            }
            Console.WriteLine();
        }
    }
}
