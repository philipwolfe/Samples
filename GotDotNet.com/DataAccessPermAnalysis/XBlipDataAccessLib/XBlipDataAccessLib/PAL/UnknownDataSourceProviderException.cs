using System;

namespace XBLIP.PAL 
{

	/// <summary>
	/// An exception that should be used by subclasses of <c>AbstractPAL</c>
	/// in the <c>getTestProvider</c> method when a label is given to which
	/// there's no matching IPALTestProvider in the application
	/// </summary>
	public class UnknownTestProviderException : Exception
	{

		/// <summary>
		/// the given test provider label
		/// </summary>
		string _strTestProviderLabel;

		/// <summary>
		/// read only property for the test provider label
		/// </summary>
		public string testProviderLabel 
		{
			get 
			{
				return _strTestProviderLabel;
			}
		}

		/// <summary>
		/// constructor. Accepts a test provider label, for which no test provider matches
		/// </summary>
		/// <param name="strTestProviderLabel">test provider label that was not resolved</param>
		public UnknownTestProviderException(string strTestProviderLabel)
		{
			_strTestProviderLabel = strTestProviderLabel;
		}

		/// <summary>
		/// constructor. Accepts a test provider label and a descriptive message
		/// </summary>
		/// <param name="message">descriptive message of the exception</param>
		/// <param name="strTestProviderLabel">test provider label that was not resolved</param>
		public UnknownTestProviderException(string message,string strTestProviderLabel)
			: base(message)
		{
			_strTestProviderLabel = strTestProviderLabel;
		}

		/// <summary>
		/// constructor. Accepts a test provider label, descriptive message
		/// and an internal exception
		/// </summary>
		/// <param name="message">descriptive message of the exception</param>
		/// <param name="inner">an internal exception</param>
		/// <param name="strTestProviderLabel">test provider label that was not resolved</param>
		public UnknownTestProviderException(string message, Exception inner,string strTestProviderLabel)
			: base(message, inner)
		{
			_strTestProviderLabel = strTestProviderLabel;
		}

	
	}
}
