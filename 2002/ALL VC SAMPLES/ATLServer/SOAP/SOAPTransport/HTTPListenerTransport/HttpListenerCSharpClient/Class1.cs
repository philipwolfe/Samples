using System;

namespace HttpListenerCSharpClient
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		static void Main(string[] args)
		{
			/*	This is just a very simple client showing how to use the HttpListener SoapTransport from a C# application,
				without having to write any custom transport code on the client side
			  
				To regenerate the Web Reference, just start the HttpListenerServer, then launch Add Web Reference wizard and make it
				point to http://localhost:333/disco
				
			
				To generate a native client for HttpListenerServer, use the following URL:
				http://localhost:333/SimpleSoapAppService?wsdl
			
			  
			*/


			try
			{
				localhost.SimpleSoapAppService	srv	=	new localhost.SimpleSoapAppService();

				string	strResult	=	srv.HelloWorld("Test String");

				Console.WriteLine("Mathod invocation result : " + strResult);
			}
			catch(System.Web.Services.Protocols.SoapException e)
			{
				
				Console.WriteLine("SoapException caught: ");
				Console.WriteLine("	Actor:"+ e.Actor);
				Console.WriteLine("	Code:"	+ e.Code);
				Console.WriteLine("	Detail:"+ e.Detail.InnerText);
			}
			catch(System.Exception e)
			{
				Console.WriteLine("Exception caught: " + e.ToString());
			}

		}
	}
}
