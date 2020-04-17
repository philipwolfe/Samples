using System;
using System.MessageBus;
using System.MessageBus.Services;

namespace LabServer
{
	/* change to DialogPortType */
	[DialogPortType(Name="QuestionService", Namespace="uri:labserver")]
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
			Console.WriteLine("Going to sleep.");
			System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(5));
			Console.WriteLine("I am awake.");

			return ("Question received: " + question);
		}
	}
}
