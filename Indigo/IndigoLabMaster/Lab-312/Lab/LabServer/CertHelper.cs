using System;
using System.Security.Cryptography;

namespace LabServer
{
	internal class CertHelper
	{
		System.Security.Cryptography.X509Certificates.X509CertificateEx _cert;

		internal CertHelper(System.MessageBus.MessageHeaderCollection headers)
		{
			System.MessageBus.Security.SignatureTokenProperty stp = (System.MessageBus.Security.SignatureTokenProperty)(headers[typeof(System.MessageBus.Security.SignatureTokenProperty)]);
			System.MessageBus.Security.AuthenticationResultsProperty arp = (System.MessageBus.Security.AuthenticationResultsProperty)(headers[typeof(System.MessageBus.Security.AuthenticationResultsProperty)]);
			System.Authorization.X509Token token = (System.Authorization.X509Token)(arp.AuthenticatedTokens[0]);

			_cert = (System.Security.Cryptography.X509Certificates.X509CertificateEx)token.Certificate;
		}

		public bool IsValidIssuer()
		{
			string issuer = _cert.Issuer;

			if (issuer == System.Configuration.ConfigurationSettings.AppSettings["TrustedIssuer"])
			{
				return (true);
			}

			return (false);
		}

		public string GetEmail()
		{
			string name = _cert.GetName();
			int emailstart = name.IndexOf("E=");
			int emailend = name.IndexOf(",", emailstart);
			string email = name.Substring(emailstart + 2, emailend - 2);
			
			return (email);
		}
	}
}
