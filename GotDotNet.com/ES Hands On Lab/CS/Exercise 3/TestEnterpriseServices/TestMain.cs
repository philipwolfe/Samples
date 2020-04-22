using System;
using HelloEnterpriseServices;

namespace TestEnterpriseServices
{
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

		public static void DoRandomOutcomeTx()
		{
			for (int x = 1;x<50;x++)
			{
				try
				{
					HelloTx MyTxObj = new HelloTx();
					MyTxObj.RandomOutcome();
				}
				catch(Exception Outcome)
				{
					Console.WriteLine(Outcome.Message);
				}
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
			//
			// TODO: Add call to DoRandomOutcomeTx
			//
			PauseForExit();
		}
	}
}
