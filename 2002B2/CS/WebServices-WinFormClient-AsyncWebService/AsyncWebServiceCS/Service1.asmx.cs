using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Threading;


namespace AsyncWebService
{
	/// <summary>
	/// Summary description for Service1.
	/// </summary>
	public class Service1 : System.Web.Services.WebService
	{
		public Service1()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
		}

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

//		[WebMethod]
//		public string HelloWorld()
//		{
//			return "Hello World";
//		}

		[WebMethod()] public int DoSomeWork(int Delay) 
		{
			//System.Threading.Thread oThread;
			Random oRandom;

			//Have the thread sleep for the number of milliseconds passed in as a parameter
			Thread.Sleep(Delay);
								
			//Generate a random number to return as the results of the method call
			oRandom = new Random(Convert.ToInt16(Thread.CurrentThread.Name) + System.DateTime.Now.Second);
			return Convert.ToInt16(oRandom.NextDouble() * 100);

		}
	}
}
