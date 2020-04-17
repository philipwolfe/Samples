//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.ServiceModel.Activities.Description;
using System.ServiceModel.Description;
using System.Activities;
using System.Xml.Linq;

using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;
using Microsoft.Samples.DocumentApprovalProcess.ApprovalManagerActivityLibrary;
using System.ServiceModel.Persistence;

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalManager
{
    class Program
    {
        static string PersistenceConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SampleInstanceStore;Integrated Security=True;Asynchronous Processing=True";

        static void Main(string[] args)
        {
            WorkflowElement element = new ApprovalRouteAndExecute();

            Service shservice = new Service
            {
                Implementation = new WorkflowServiceImplementation
                {
                    Name = "ApprovalManager",
                    ConfigurationName = "Microsoft.Samples.DocumentApprovalProcess.ApprovalManager.ApprovalManager",
                    Body = element
                },
            };

            // Cleanup old table of users from previous run
            UserManager.DeleteAllUsers();

            ServiceHost sh = new ServiceHost(typeof(Microsoft.Samples.DocumentApprovalProcess.ApprovalManager.SubscriptionManager));
            sh.Open();

            System.ServiceModel.Activities.WorkflowServiceHost wsh = new System.ServiceModel.Activities.WorkflowServiceHost(shservice);
            wsh.AddServiceEndpoint("IApprovalProcess", new BasicHttpBinding(), "");

            wsh.Extensions.Add(new SHExceptionOutput());

            // Setup persistence
            wsh.Description.Behaviors.Add(new PersistenceProviderBehavior(new SqlPersistenceProviderFactory(PersistenceConnectionString, true, true, new TimeSpan(0, 1, 0))));
            wsh.Description.Behaviors.Add(new UnloadInstanceBehavior(new TimeSpan(0, 0, 2)));

            wsh.Open();

            Console.WriteLine("All services ready, press any key to close the services and exit.");

            Console.ReadLine();
            wsh.Close();
            sh.Close();
        }
    }


}
