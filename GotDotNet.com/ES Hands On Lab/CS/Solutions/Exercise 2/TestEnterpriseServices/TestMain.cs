using System;
using HelloEnterpriseServices;

namespace TestEnterpriseServices
{
	/// <summary>
	/// Summary description for TestMain.
	/// </summary>
	class TestMain
	{
		public static void ShowTransaction()
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

		public static void PauseForExit()
		{
			Console.WriteLine("Press <Enter> to exit...");
			Console.ReadLine();
		}

		[STAThread]
		static void Main(string[] args)
		{
			ShowTransaction();
			PauseForExit();
		}
	}
}
