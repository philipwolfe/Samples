using System;
using System.Windows.Forms;

namespace HelloEnterpriseServices
{
	public class HelloTx
	{
		public HelloTx()
		{
		}

		public void SayHello(string Name)
		{
			MessageBox.Show(string.Format("Hello {0}", Name));
		}
	}
}
