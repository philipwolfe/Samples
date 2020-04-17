using System;
using System.Authorization;
using System.Collections;
using System.Data.SqlClient;

namespace LabServer
{
	public class StudentManager
	{
		private static System.Authorization.MemoryAuthorizationModule _studentAZModule;

		public StudentManager()
		{
		}

		public static void AddUserToAZModule(string emailName)
		{
			System.Xml.XmlQualifiedName qname = new System.Xml.XmlQualifiedName("Student");
			System.Authorization.RoleClaim roleClaim = new System.Authorization.RoleClaim(qname);
			System.Authorization.UserNameClaim userClaim = new System.Authorization.UserNameClaim(emailName);
			System.Authorization.AuthorizationEntry ae = new System.Authorization.AuthorizationEntry();

			ae.DerivedClaims.Add(roleClaim);
			ae.PrerequisiteClaims.Add(userClaim);
			_studentAZModule.GlobalEntries.Add(ae);
		}

		public static bool RegisterStudent(string name, string emailAddress, string machineName, string password)
		{
			// Create local trans and connection
			SqlConnection conn = LabServer.Database.ConnectDb();

			// Create command
			SqlTransaction localTransaction = conn.BeginTransaction();
			SqlCommand command = new SqlCommand("usp_RegisterStudent");
			command.Connection = conn;
			command.CommandType = System.Data.CommandType.StoredProcedure;
			command.Transaction = localTransaction;
			command.Parameters.AddWithValue("@Name", name);
			command.Parameters.AddWithValue("@EmailAddress", emailAddress);
			command.Parameters.AddWithValue("@MachineName", machineName);
			command.Parameters.AddWithValue("@Password", password);
			int regCount = Convert.ToInt32(command.ExecuteScalar());

			// Check if there are already entries for this person
			Console.WriteLine(regCount.ToString());
			if (regCount == 1)
			{
				command.Transaction.Commit();
			}
			else
			{
				command.Transaction.Rollback();
			}

			return (Convert.ToBoolean(regCount));
		}

		public static  void Init(System.MessageBus.Security.SecurityManager securityManager)
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
			System.Authorization.MemoryAuthorizationModule mam = null;

			foreach (System.Authorization.IAuthorizationModule imz in srf.AuthorizationModules)
			{
				if (imz.GetType() == typeof(System.Authorization.MemoryAuthorizationModule))
				{
					mam = (System.Authorization.MemoryAuthorizationModule)(imz);
				}
			}

			_studentAZModule = mam;
		}

		public ArrayList GetAllStudents(bool addToAZModule)
		{
			// Create connection
			SqlConnection conn = LabServer.Database.ConnectDb();

			// Create command
			SqlCommand command = new SqlCommand("usp_GetAllStudents");
			command.Connection = conn;
			command.CommandType = System.Data.CommandType.StoredProcedure;
			SqlDataReader reader = command.ExecuteReader();

			// Read the student info
			ArrayList studentList = new ArrayList();

			while (reader.Read())
			{
				LabServer.MessageTypes.RegisterType registerInfo = new LabServer.MessageTypes.RegisterType();
				registerInfo.StudentId = reader.GetInt32(0);
				registerInfo.EmailName = reader.GetString(1);
				studentList.Add(registerInfo);
				if (addToAZModule)
				{
					StudentManager.AddUserToAZModule(registerInfo.EmailName);
					Console.WriteLine("Student {0} added to StudentRole.", registerInfo.EmailName);
				}
			}

			command.Connection.Close();

			// Return student - it will be null if the student does not exist
			return (studentList);
		}

		public LabServer.MessageTypes.RegisterType GetStudent(string emailAddress)
		{
			// Create connection
			SqlConnection conn = LabServer.Database.ConnectDb();
			
			// Create command
			SqlCommand command = new SqlCommand("usp_GetStudent");
			command.Connection = conn;
			command.CommandType = System.Data.CommandType.StoredProcedure;
			command.Parameters.AddWithValue("@EmailAddress", emailAddress);
			SqlDataReader reader = command.ExecuteReader();

			// Read the student info
			LabServer.MessageTypes.RegisterType registerInfo = null;
			while (reader.Read())
			{
				registerInfo = new LabServer.MessageTypes.RegisterType();
				registerInfo.StudentId = reader.GetInt32(0);
			}

			command.Connection.Close();

			// Return student - it will be null if the student does not exist
			return (registerInfo);
		}

		public void DeleteAllStudents()
		{
			// Create connection
			SqlConnection conn = LabServer.Database.ConnectDb();

			// Create command
			SqlCommand command = new SqlCommand("usp_DeleteAllStudents");
			command.Connection = conn;
			command.ExecuteNonQuery();
			command.Connection.Close();

			Console.WriteLine("~Students deleted");

			return;
		}
	}
}
