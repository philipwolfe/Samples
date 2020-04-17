using System;
using System.Data.SqlClient;
using System.Transactions;
using System.EnterpriseServices;
using System.MessageBus;
using System.MessageBus.Services;

namespace LabServer
{
	[DialogPortType(Name="QuestionService", Namespace="uri:labserver")]
	public class QuestionService
	{
		public QuestionService()
		{
		}

		[ServiceMethod]
		[System.MessageBus.Security.ServiceSecurity(Name = "ExistingUserScope", Role = "Student", Confidentiality = false)]
		/* add TransactedServiceAttribute */
		/* add TransactedServiceContractAttribute */
			
		[TransactedServiceAttribute]
		[TransactedServiceContractAttribute(TransactionContract.Mandatory)]

		public int AskQuestion(string emailAddress, string question)
		{
			System.Transactions.Transaction tx = null;

			try
			{
				/* Acquire transaction */
				tx = System.Transactions.Transaction.Current;
				tx.TransactionCompleted += new TransactionCompletedEventHandler(OnTransactionCompleted);
				Console.WriteLine();
				Console.WriteLine(tx.Description);
				Console.WriteLine("Transaction information:");
				Console.WriteLine("ID:             {0}", tx.Identifier);
				Console.WriteLine("status:         {0}", tx.Status);
				Console.WriteLine("isolationlevel: {0}", tx.IsolationLevel);
				Console.WriteLine("timeout:        {0}", tx.Timeout);
				Console.WriteLine("can commit:     {0}", tx.CanCommit);
				Console.WriteLine();



				// Get student info
				LabServer.StudentManager studentResolver = new LabServer.StudentManager();
				LabServer.MessageTypes.RegisterType studentInfo = studentResolver.GetStudent(emailAddress);
				if (studentInfo == null)
				{
					throw (new System.Exception("Student does not exist"));
				}

				// Create connection to write question
				SqlConnection conn = LabServer.Database.ConnectDb();

				/* Enlist in transaction */
				System.EnterpriseServices.ITransaction esTx = (System.EnterpriseServices.ITransaction)tx.Marshal(MarshaledTransactionTypeNamespaceUri.ITransaction);
				conn.EnlistDistributedTransaction(esTx);



				// Create command
				SqlCommand command = new SqlCommand("usp_InsertQuestion", conn);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@Question", question);
				command.Parameters.AddWithValue("@StudentId", studentInfo.StudentId);
				int questionId = Convert.ToInt32(command.ExecuteScalar());

				command.Connection.Close();

				// respond with new questionId
				Console.WriteLine("Question created: {0}", questionId);
				return questionId;
			}
			catch (Exception e)
			{
				if (tx != null)
				{
					tx.Rollback();
				}

				throw (e);
			}
			finally
			{
				Console.WriteLine("---------------------------------------------------------------------------------");
			}
		}

		static void OnTransactionCompleted(object sender, TransactionCompletedEventArgs args)
		{
			Console.WriteLine("Distributed transaction outcome: {0}", args.Outcome.ToString());
		}
	}
}
