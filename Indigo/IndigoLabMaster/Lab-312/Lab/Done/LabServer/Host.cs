using System;
using System.MessageBus;
using System.MessageBus.Services;

namespace LabServer
{
    public class Host
    {
        public static void Main (string[] args)
        {
            //The service environment needs to be loaded before it can be used.
            ServiceEnvironment environs = ServiceEnvironment.Load ();
            ServiceManager sm=environs[typeof(ServiceManager)] as ServiceManager;
            sm.ActivatableServices.Add (typeof(LabServer.QuestionService));
			sm.ActivatableServices.Add(typeof(LabServer.RegistrationService));

            //Only once the envrionment is open can connections be established.
            environs.Open ();
			
			/* output DialogProfile properties */
			System.MessageBus.DialogManager dm = environs[typeof(System.MessageBus.DialogManager)] as System.MessageBus.DialogManager;
			foreach (System.MessageBus.DialogProfile dp in dm.Profiles)
			{
				Console.WriteLine(dp.Name);
				Console.WriteLine(dp.MaximumMessageTimeToLive.ToString());
				Console.WriteLine(dp.MinimumAssurances.ToString());
				Console.WriteLine((dm.Stores[dp.StoreName]).GetType());
				Console.WriteLine(dp.GetType().ToString());
			}


			// add customer UserNameAuthenticationModule
			LabServer.PasswordResolver.AddPasswordProvider((System.MessageBus.Security.SecurityManager)environs[typeof(System.MessageBus.Security.SecurityManager)]);

			// Initialize Student Manager 
			System.MessageBus.Security.SecurityManager securityManager = (System.MessageBus.Security.SecurityManager)(environs[typeof(System.MessageBus.Security.SecurityManager)]);
			LabServer.StudentManager.Init(securityManager);
			           
			Console.WriteLine ("Press enter to stop the services...");
            Console.ReadLine ();

            //Closing the environment forces cleanup of server and should not be forgotten.
            environs.Close ();
        }
    }
}

