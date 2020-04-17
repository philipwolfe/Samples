using System;
using System.MessageBus;
using System.MessageBus.Services;
//Note: This project has Indigo security disabled by default
//see the Indigo WindowsAuthRequestReply quickstart for an example 
//of adding Indigo security to this application
namespace LabServer
{
    public class Host
    {
        public static void Main (string[] args)
        {
            //The service environment needs to be loaded before it can be used.
            //The Load method loads whatever configuration is available in the configuration file.
            ServiceEnvironment environs = ServiceEnvironment.Load ();
            ServiceManager sm=environs[typeof(ServiceManager)] as ServiceManager;
            sm.ActivatableServices.Add (typeof(LabServer.QuestionService));

            //Only once the envrionment is open can connections be established.
            environs.Open ();
            Console.WriteLine ("Press enter to stop the services...");
            Console.ReadLine ();

            //Closing the environment forces cleanup of server and should not be forgotten.
            environs.Close ();
        }
    }
}

