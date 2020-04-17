using System;
using System.MessageBus;
using System.MessageBus.Services;

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

			// Create uri for LavServer
			System.Uri uriLabServer = new System.Uri("soap.tcp://localhost:46001/LabServer/");
          
			// Create channel to call register service
			labserver.IRegistrationServiceChannel channel = (labserver.IRegistrationServiceChannel)sm.CreateChannel(typeof(labserver.IRegistrationServiceChannel), uriLabServer);
			LabServer_Types.RegisterType register = new LabServer_Types.RegisterType("demo name", "mymachine");
			Console.WriteLine("Sending register message...");

			LabServer_Types.RegisterResponseType registerResonse = channel.Register(register);

			Console.WriteLine("Your password is: {0}", registerResonse.Password);

			/* add UserNameToken here */
			

			Console.Write("What is your question? ");
			string question = Console.ReadLine();
			Console.WriteLine();

			labserver.IQuestionServiceChannel questionChannel = (labserver.IQuestionServiceChannel)(sm.CreateChannel(typeof(labserver.IQuestionServiceChannel), uriLabServer));
			
			string response = questionChannel.AskQuestion(question);
			Console.WriteLine("LabServer responded with: {0}", response);


            Console.ReadLine ();

            //Closing the environment forces cleanup of server and should not be forgotten.
            environs.Close ();
        }
    }
}

