using System;
using System.MessageBus;
using System.MessageBus.Services;
using System.Data.SqlClient;
using System.MessageBus.Security;
using System.Authorization;
using System.Transactions;

namespace LabClient
{
    public class Host
    {
		static string EmailName = "labclient@demo.com";

        public static void Main (string[] args)
        {
			try
			{
				// Create ServiceEnvironment
				System.MessageBus.ServiceEnvironment se = System.MessageBus.ServiceEnvironment.Load();

				// Acquire SecurityManager
				System.MessageBus.Security.SecurityManager secManager = se[typeof(System.MessageBus.Security.SecurityManager)] as System.MessageBus.Security.SecurityManager;
				secManager.IsEnabledForReceive = false;

				// Open environment
				se.Open();
				Console.WriteLine("ServiceEnvironemt opened.");

				// Create channel to register
				System.MessageBus.Services.ServiceManager manager = (System.MessageBus.Services.ServiceManager)(se[typeof(System.MessageBus.Services.ServiceManager)]);
				Uri uri = new Uri("soap.tcp://localhost:46001/LabServer/");
				labserver.IRegistrationServiceChannel registerChannel = (labserver.IRegistrationServiceChannel)manager.CreateChannel(typeof(labserver.IRegistrationServiceChannel), uri);

				Console.WriteLine("Channel for registration created.");

				// Send register message
				LabServer_Types.RegisterType registerInfo = new LabServer_Types.RegisterType();

				registerInfo.Name = "Bob Smith";
				registerInfo.MachineName = System.Net.Dns.GetHostName();

				LabServer_Types.RegisterResponseType registerResponse = registerChannel.Register(registerInfo);
				
				Console.WriteLine("You were registered with password {0}.", registerResponse.Password);

				/* ---------------------   Register process completed   ---------------------------------------------  */
				
				// Create quesion channel
				labserver.IQuestionServiceChannel questionChannel = (labserver.IQuestionServiceChannel)manager.CreateChannel(typeof(labserver.IQuestionServiceChannel), uri);
				Console.WriteLine("Channel for question created.");

				// Get question from input
				Console.Write("Ask question: ");
				string question = Console.ReadLine();

				/* Create transaction context  - this will be used for a distrbuted transaction */
				System.Transactions.Transaction tx = System.Transactions.Transaction.Create("Distributed Registration TX", IsolationLevel.Serializable, TimeSpan.FromSeconds(10));
				tx.TransactionCompleted += new TransactionCompletedEventHandler(OnTransactionCompleted);
				Transaction.Current = tx;
				Console.WriteLine("Transaction created");
				Console.WriteLine();
				Console.WriteLine(tx.Description);
				Console.WriteLine("Transaction information:");
				Console.WriteLine("ID:             {0}", tx.Identifier);
				Console.WriteLine("status:         {0}", tx.Status);
				Console.WriteLine("isolationlevel: {0}", tx.IsolationLevel);
				Console.WriteLine("timeout:        {0}", tx.Timeout);
				Console.WriteLine("can commit:     {0}", tx.CanCommit);
				Console.WriteLine();

				// Add usrnameToken
				System.Authorization.UserNameToken token = new System.Authorization.UserNameToken(EmailName, registerResponse.Password, 24);
				secManager.EndpointSettings.TokenCache.AddToken(token);

				// Ask question
				int serverQuestionId = questionChannel.AskQuestion(EmailName, question);
				Console.WriteLine("Question was delivered securely and reliably delivered - pending ID is: {0}", serverQuestionId);

				// Create connection to write question
				SqlConnection conn = new SqlConnection();
				conn.ConnectionString = "Initial Catalog = dbLabClient;Data Source = localhost;User ID = sa;password= pass@word1;Enlist=false;pooling = false";
				conn.Open();

				/* Enlist in current transaction */
				System.EnterpriseServices.ITransaction esTx = (System.EnterpriseServices.ITransaction)tx.Marshal(MarshaledTransactionTypeNamespaceUri.ITransaction);
				conn.EnlistDistributedTransaction(esTx);

				// Create command
				SqlCommand command = new SqlCommand("usp_InsertQuestion", conn);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@Question", question);
				command.Parameters.AddWithValue("@IsMine", true);
				command.Parameters.AddWithValue("@ServerQuestionId", serverQuestionId);
				int localQuestionId = Convert.ToInt32(command.ExecuteScalar());

				Console.WriteLine("Local question saved pending commit: {0}", localQuestionId);
				
				Console.WriteLine("Do you want to commit this transaction true/false");
				bool commit = Convert.ToBoolean(Console.ReadLine());

				/* commit */
				if (commit)
				{
					tx.Commit();
				}
				else
				{
					tx.Rollback();
				}

				Console.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.ReadLine();
			}
        }

		static void OnTransactionCompleted(object sender, TransactionCompletedEventArgs args)
		{
			Console.WriteLine("Distributed transaction outcome: {0}", args.Outcome.ToString());
		}
    }
}

