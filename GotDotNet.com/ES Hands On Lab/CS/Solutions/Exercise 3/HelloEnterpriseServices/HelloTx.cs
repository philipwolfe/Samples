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
			//
			// TODO: Add constructor logic here
			//
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
}
