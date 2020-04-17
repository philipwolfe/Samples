using System;
using System.MessageBus;
using System.MessageBus.Services;

namespace LabServer
{
	/// <summary>
	/// Summary description for QuestionService.
	/// </summary>
	[DatagramPortType(Name="QuestionService", Namespace="uri:labserver")]
	public class QuestionService
	{
		public QuestionService()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[ServiceMethod]
		public string AskQuestion(string question)
		{
			Console.WriteLine("New question: {0}", question);
			return ("Question received: " + question);
		}
	}
}
