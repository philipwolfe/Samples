using System;
using System.Windows.Forms;
//TODO: Add using System.EnterpriseServices;

namespace HelloEnterpriseServices
{
	//
	// TODO: Add a Transaction attribute to the HelloTx class
	// TODO: Derive HelloTx from ServicedComponent
	//
	public class HelloTx
	{
		public HelloTx()
		{
		}

		public void SayHello(string Name)
		{
			//
			// TODO: Get the transaction ID
			//

			//
			// TODO: Ask the user if they want to commit the transaction
			//
			MessageBox.Show(string.Format("Hello {0}", Name));

			// 
			// TODO: Call ContextUtil SetComplete or SetAbort
			//
		}
	}
}
