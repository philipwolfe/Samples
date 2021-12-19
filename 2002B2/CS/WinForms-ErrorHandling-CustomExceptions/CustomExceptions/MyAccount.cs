using System;
using System.Windows.Forms;

namespace CustomExceptions
{
	/// <summary>
	/// Summary description for MyAccount.
	/// </summary>
	public class MyAccount
	{
	
		private float Balance;

		public MyAccount()
		{
			Balance = 5;
		}
	
		public void WithDraw(float amount)
		{
        
			try
			{
				//Check to see if funds are available
				if (amount > Balance)
				{
					// Throw a new InsufficientFundsException
					throw new InsufficientFundsException();
				}
				else
				{
					//Reduce balance
					Balance = Balance - amount;
				}	
			}
			catch (System.Exception exc)
			{
				//Any necessary tasks can be done before the exception is sent back to the caller
				MessageBox.Show("Exception Caught in MyAccount.WithDraw");
					
				//Throw the exception back to the caller
				throw exc;
			}
			
		}

	}
}
