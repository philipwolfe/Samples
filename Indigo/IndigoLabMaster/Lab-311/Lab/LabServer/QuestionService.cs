using System;
using System.MessageBus;
using System.MessageBus.Services;

namespace LabServer
{
	[DatagramPortType(Name="QuestionService", Namespace="uri:labserver")]
	public class QuestionService
	{
		public QuestionService()
		{
		}

		[ServiceMethod]
		/* add ServiceSecurity attribute */
		
		public string AskQuestion(string question)
		{
			Console.WriteLine("New question: {0}", question);
			return ("Question received: " + question);
		}
	}
}
