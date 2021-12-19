using System;

namespace CustomExceptions
{
	/// <summary>
	/// Summary description for InsufficientFundsException.
	/// </summary>
	public class InsufficientFundsException : System.ApplicationException
	{
		public InsufficientFundsException()
		{
		}
		public InsufficientFundsException(string message): base(message)
		{
		}
		public InsufficientFundsException(string message, Exception inner): base(message, inner)
		{
		}
	}
}
