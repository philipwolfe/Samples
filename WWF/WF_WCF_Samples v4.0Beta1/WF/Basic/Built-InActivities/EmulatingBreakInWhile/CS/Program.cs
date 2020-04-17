//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.EmulatingBreakInWhile
{
    using System;
    using System.Activities;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            // create a list of vendors
            List<Vendor> vendorList = new List<Vendor>()
            {
                new Vendor { Id = 1, Name = "Bad Vendor", Reliability = 30 },
                new Vendor { Id = 2, Name = "Very Bad Vendor", Reliability = 10 },
                new Vendor { Id = 3, Name = "Acceptable Vendor", Reliability = 50 },
                new Vendor { Id = 4, Name = "Great Vendor", Reliability = 95 },
                new Vendor { Id = 5, Name = "OK Vendor", Reliability = 75 },
                new Vendor { Id = 6, Name = "Good Vendor", Reliability = 80 }
            };

            // create dictionary with input arguments for the workflow
            IDictionary<string, object> input = new Dictionary<string, object> 
            {
                { "Vendors" , vendorList },
                { "MinimumReliability", 90 }
            };

            // execute the workflow
            IDictionary<string, object> output = WorkflowInvoker.Invoke(new FindReliableVendor(), input);

            // display results
            Vendor reliableVendor = (Vendor)output["Result"];
            if (reliableVendor == null)
            {
                Console.Write("No reliable vendor found");
            }
            else
            {
                Console.WriteLine("Best Vendor: {0}", reliableVendor.ToString());
            }

            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }             
    }
}
