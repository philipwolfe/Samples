using System;
using System.Windows.Forms;
using System.EnterpriseServices;

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
	}
}
