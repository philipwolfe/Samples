using System;
using System.Windows.Forms;
using System.EnterpriseServices;
using System.Collections;
using System.Diagnostics;

namespace HelloEnterpriseServices
{
	[Transaction]
	public class HelloTx : ServicedComponent
	{
		public HelloTx()
		{
		}

		public void SayHello(string Name)
		{
			Guid txID = ContextUtil.TransactionId;
			string Msg = string.Format("Hello {0} - Commit transaction {1}?", Name, txID);
			switch (MessageBox.Show(Msg,"Transaction", MessageBoxButtons.YesNo))
			{
				case DialogResult.Yes:
					ContextUtil.SetComplete();
					break;
				case DialogResult.No:
					ContextUtil.SetAbort();
					break;
			}
		}

		private bool RandomCommit(out string Message)
		{
			bool Commit;
			Random r = new Random(DateTime.Now.Millisecond);
			// Commit if an even number is returned from the random generator
			Commit = ((r.Next() % 2) == 0) ? true : false;
			Message = String.Format("RandomOutcome Result: {0} Transaction ID: {1}", Commit ? "commit" : "abort", ContextUtil.TransactionId);
			return Commit;
		}

		[AutoComplete]
		public void RandomOutcome()
		{
			string Message;
			if (!RandomCommit(out Message))
				throw new Exception(Message);
			else
				Console.WriteLine(Message);
		}
	}

// TODO: Add ObjectPooling and JustInTimeActivation after testing without them
	public class StuffCache : ServicedComponent
	{
		const int MAX_CACHE_SIZE = 5000;
		private Hashtable _stuff = new Hashtable(MAX_CACHE_SIZE);

		public StuffCache()
		{
			DateTime start;
			start = DateTime.Now;
			// Populate our stuff with lots of data
			Random r = new Random(DateTime.Now.Millisecond);
			for(int i = 1; i< MAX_CACHE_SIZE; i++)
			{
				_stuff.Add(i, String.Format("Value {0}", r.Next()));
			}
			Debug.WriteLine(String.Format("Stuff Cache Construct Duration {0} ", DateTime.Now.Subtract(start)));
		}

		// TODO: add overridde for CanBePooled

		public Hashtable Stuff
		{
			get
			{
				return _stuff;
			}
		}
	}
}
