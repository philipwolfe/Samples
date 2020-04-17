using System;
using System.Data.SqlClient;
using System.MessageBus;
using System.MessageBus.Services;
using System.MessageBus.Security;
using LabServer.MessageTypes;

namespace LabServer
{
	[DatagramPortType(Name = "RegistrationService", Namespace = "uri:labserver")]
	public class RegistrationService : System.MessageBus.Services.Service
	{
		public RegistrationService()
		{
		}
		
		[ServiceMethod]
		/* add ServiceSecurity attribute */

		public RegisterResponseType Register(RegisterType registration)
		{
			try
			{
				/* check certificate properties */
				

				// Generate password
				string password = System.Guid.NewGuid().ToString();

				// Register user
				bool regStatus = LabServer.StudentManager.RegisterStudent(registration.Name, certHelper.GetEmail(), registration.MachineName, password);
				if (regStatus)
				{
					/* update AZ cache */
					
				}
				else
				{
					throw (new System.Exception("Registration failed - user already registered."));
				}

				// Create response message
				LabServer.MessageTypes.RegisterResponseType response = new LabServer.MessageTypes.RegisterResponseType(password);

				return (response);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw (e);
			}
		}
	}
}
