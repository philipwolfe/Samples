//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities.Statements;
using System.Activities.Validation;

namespace Microsoft.Samples.OverloadIsRequired
{ 
    class Program
    {
        static void Main()
        {
            ValidationResults results = ActivityValidationServices.Validate(CreateWorkflow());
            PrintResults(results);

            Console.WriteLine("End of sample. Press <Enter> to exit.");
            Console.ReadLine();
        }

        static Sequence CreateWorkflow()
        {
            return new Sequence
            {
                Activities =
                {   
                    new CreateLocation
                    {
                        //Name is a required argument in both Overload Groups and will generate an error if not assigned.
                        //Name = "Home",
                        Latitude = 223,
                        Longitude = 4234
                    },
                    new CreateLocation
                    {
                        Name = "Movies",
                        Latitude = 34234,
                        //Longitude is a required argument in Overload Group "G1" and will generate an error if not assigned.
                        //Longitude = 8984,
                        //Description is an optional argument in both Overload Groups and will NOT generate an error if not assigned.
                        Description = "The Big Apple"
                    },
                    new CreateLocation
                    {
                        Name = "Gym",
                        //Latitude and City are arguments from different Overload Groups and will generate an error if both are assigned values
                        Latitude = 2342,
                        Street = "2nd Ave",
                        City = "Seattle",
                        State = "Washington"
                    },
                    new CreateLocation
                    {
                        Name = "Work",
                        Street = "1st Ave",
                        City = "Seattle",
                        State = "Washington"
                    },
                    new CreateLocation
                    {
                        Name = "Farmacy",
                        Street = "4th Ave",
                        Zip = 98101
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
