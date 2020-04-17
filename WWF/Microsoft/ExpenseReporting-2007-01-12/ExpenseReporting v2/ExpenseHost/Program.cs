//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.ServiceModel;

using ExpenseServices;
using WcfExtensions;

namespace ExpenseHost
{
    internal class Program
    {
        private static void Main()
        {
            ExpenseService service = new ExpenseService();
            
            using (ServiceHost serviceHost =
                new ServiceHost(service))
            {
                // Instantiate and add the extension which hosts our workflow runtime

                WfWcfExtension wfWcfExtension =
                    new WfWcfExtension("WorkflowRuntimeConfig");

                serviceHost.Extensions.Add(wfWcfExtension);
                serviceHost.Open();

                // We use Console.ReadLine() to block this thread so that the host
                // instances remains open. Service calls are recieved and processed on
                // background threads.

                Console.WriteLine("The Expense Reporting WCF service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                serviceHost.Close();
            }
        }
    }
}