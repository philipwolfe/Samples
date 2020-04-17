//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Linq;
using System.Threading;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel.Activities;
using System.ServiceModel.Description;

namespace Microsoft.Samples.CorrelatedCalculator.CalculatorService
{
    class Program
    {
        static void Main(string[] args)
        {            
            string baseAddress = "http://localhost:8080/CalculatorService";

            using (WorkflowServiceHost host = new WorkflowServiceHost(typeof(Microsoft.Samples.CorrelatedCalculator.CalculatorService.CalculatorService), new Uri(baseAddress)))
            {
                host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
                // adds a default endpoint at baseAddress + ServiceContractName.LocalName
                host.AddDefaultEndpoints(); 

                host.Open();
                Console.WriteLine("CalculatorService waiting at: " + baseAddress);
                Console.WriteLine("Press [ENTER] to exit");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
