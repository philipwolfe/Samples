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
		[ServiceSecurity(Name="NewUserScope", Confidentiality=true)]
		public RegisterResponseType Register(RegisterType registration)
		{
			try
			{
				/* check certificate properties */
				LabServer.CertHelper certHelper = new LabServer.CertHelper(registration.Headers);;
				if (!certHelper.IsValidIssuer())
				{
					throw (new System.Exception("Registration failed - invalid certificate issuer."));
				}

				// Generate password
				string password = System.Guid.NewGuid().ToString();

				// Register user
				bool regStatus = LabServer.StudentManager.RegisterStudent(registration.Name, certHelper.GetEmail(), registration.MachineName, password);
				if (regStatus)
				{
					/* update AZ cache */
					LabServer.StudentManager.AddUserToAZModule(certHelper.GetEmail());
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
