using System;
using System.Data.SqlClient;
using System.Data.Common;
using System.MessageBus;

namespace LabServer
{
	public class PasswordResolver: System.Authorization.IPasswordResolver
	{
		public PasswordResolver() { }
		
		public string LookupPassword(string emailaddress)
		{
			try
			{
				SqlCommand command = new SqlCommand();

				command.Connection = LabServer.Database.ConnectDb();
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.CommandText = "usp_GetPassword";
				command.Parameters.AddWithValue("@EmailAddress", emailaddress);

				string password = null;
				object ret = command.ExecuteScalar();
				password = Convert.ToString(ret);

				return (password);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw (e);
			}
		}
		public bool CompletesSynchronously
		{
			get
			{
				return true;
			}
		}

		public IAsyncResult BeginLookupPassword(string username, System.AsyncCallback async, object state)
		{
			return null;
		}

		public string EndLookupPassword(System.IAsyncResult async)
		{
			return null;
		}

		public static void AddPasswordProvider(System.MessageBus.Security.SecurityManager securityManager)
		{
			System.MessageBus.Security.SecurityScopeCollection scoll = securityManager.Scopes;
			System.MessageBus.Security.SecurityReceiverScope src = null;

			foreach (System.MessageBus.Security.SecurityScope sc in scoll)
			{
				if (sc.Name == "ExistingUserScope")
				{
					src = (System.MessageBus.Security.SecurityReceiverScope)(sc);
				}
			}

			System.MessageBus.Security.SecurityReceiverProfile srf = (System.MessageBus.Security.SecurityReceiverProfile)src.Profile;

			foreach (System.Authorization.AuthenticationModuleCollection amc in srf.AuthenticationChoices)
			{
				System.Authorization.UserNameAuthenticationModule unam = null;

				foreach (System.Authorization.IAuthenticationModule imz in amc)
				{
					if (imz.GetType() == typeof(System.Authorization.UserNameAuthenticationModule))
					{
						unam = (System.Authorization.UserNameAuthenticationModule)(imz);
					}
				}

				amc.Remove(unam);

				/* Add an instance of the LabServer.PasswordResolver to the AuthenticationModuleCollection*/
				amc.Add(new System.Authorization.UserNameAuthenticationModule(new LabServer.PasswordResolver(), 24));

				Console.WriteLine("Custom password provider registered");
			}
		}
	}
}
