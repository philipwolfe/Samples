using System;
using HelloEnterpriseServices;

namespace TestEnterpriseServices
{
	/// <summary>
	/// Summary description for TestMain.
	/// </summary>
	class TestMain
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				HelloTx MyTxObj = new HelloTx();
				MyTxObj.SayHello("<Your Name>");
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
