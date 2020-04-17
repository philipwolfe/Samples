using System;
using System.MessageBus;
using System.MessageBus.Services;

namespace LabServer
{
	/* change to DialogPortType */
	[DatagramPortType(Name="QuestionService", Namespace="uri:labserver")]
	public class QuestionService
	{
		public QuestionService()
		{
		}

		[ServiceMethod]
		[System.MessageBus.Security.ServiceSecurity(Name = "ExistingUserScope", Role = "Student", Confidentiality = false)]
		public string AskQuestion(string question)
		{
			Console.WriteLine("New question: {0}", question);

			/* add sleep code here */


			return ("Question received: " + question);
		}
	}
}
