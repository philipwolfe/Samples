using System;
using System.MessageBus;
using System.MessageBus.Services;
//Note: This project has Indigo security disabled by default
//see the Indigo WindowsAuthRequestReply quickstart for an example 
//of adding Indigo security to this application
namespace LabClient
{
    public class Host
    {
        public static void Main (string[] args)
        {
            //The service environment needs to be loaded before it can be used.
            //The Load method loads whatever configuration is available in the configuration file.
            ServiceEnvironment environs = ServiceEnvironment.Load ();
            ServiceManager sm=environs[typeof(ServiceManager)] as ServiceManager;
           
            //Only once the envrionment is open can connections be established.
            environs.Open ();
          
			Console.Write("What is your question? ");
			string question = Console.ReadLine();
			Console.WriteLine();

			System.Uri uriLabServer = new System.Uri("soap.tcp://localhost:46001/LabServer/");
			labserver.IQuestionServiceChannel channel = (labserver.IQuestionServiceChannel)(sm.CreateChannel(typeof(labserver.IQuestionServiceChannel), uriLabServer));
			
			string response = channel.AskQuestion(question);
			Console.WriteLine("LabServer responded with: {0}", response);


            Console.ReadLine ();

            //Closing the environment forces cleanup of server and should not be forgotten.
            environs.Close ();
        }
    }
}

