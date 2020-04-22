using System;
using HelloEnterpriseServices;

namespace TestEnterpriseServices
{
	/// <summary>
	/// Summary description for TestMain.
	/// </summary>
	class TestMain
	{
		const int MAX_CACHE_GET = 100;

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

		public static void GetStuffFromCache()
		{
			DateTime start = DateTime.Now;
			Random r = new Random(DateTime.Now.Millisecond);
		
			for(int i=1; i<MAX_CACHE_GET;i++)
			{
				Console.WriteLine("{0} of {1} - {2}", i, MAX_CACHE_GET, GetRandomCacheValue(r));
			}
			Console.WriteLine("Duration: {0} ", DateTime.Now.Subtract(start));
		}

		public static void PauseForExit()
		{
			Console.WriteLine("Press <Enter> to exit...");
			Console.ReadLine();
		}

		public static string GetRandomCacheValue(Random r)
		{
			using (StuffCache cache = new StuffCache())
			{
				int index;
				index = r.Next(0, 5000);
				return String.Format("Stuff({0})={1}", index, cache.Stuff[index]);
			}
		}



		[STAThread]
		static void Main(string[] args)
		{
			ShowTransaction();
			DoRandomOutcomeTx();
			GetStuffFromCache();
			PauseForExit();
		}
	}
}
