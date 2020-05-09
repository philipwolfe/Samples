using System;

namespace XBLIP.PAL 
{

	/// <summary>
	/// exception thrown when a test provider throws an exception. 
	/// The thrown exception is saved as the inner exception
	/// </summary>
	public class TestProviderActionFailedException : Exception
	{
		/// <summary>
		/// failing test provider label
		/// </summary>
		string _strTestProviderLabel;
		/// <summary>
		/// parameters given to the test provider when the test failed
		/// </summary>
		string _strTestParams;

		/// <summary>
		/// read only property for the name of the test provider
		/// </summary>
		public string testProviderLabel 
		{
			get 
			{
				return _strTestProviderLabel;
			}
		}

		/// <summary>
		/// read only property for the test parameters
		/// </summary>
		public string testParams
		{
			get 
			{
				return _strTestParams;
			}
		}

		/// <summary>
		/// consturctor that accepts a label of a test provider, and the parameters
		/// passed to the test
		/// </summary>
		/// <param name="strTestProviderLabel">a test provider name</param>
		/// <param name="strTestParams">a test parameters</param>
		public TestProviderActionFailedException(string strTestProviderLabel,string strTestParams)
		{
			_strTestProviderLabel = strTestProviderLabel;
			_strTestParams = strTestParams;
		}

		/// <summary>
		/// consturctor that accepts a descriptive message, a label of a test provider, 
		/// and the parameters passed to the test
		/// </summary>
		/// <param name="message">descriptive message</param>
		/// <param name="strTestProviderLabel">a test provider name</param>
		/// <param name="strTestParams">a test parameters</param>
		public TestProviderActionFailedException(string message,string strTestProviderLabel,string strTestParams)
			: base(message)
		{
			_strTestProviderLabel = strTestProviderLabel;
			_strTestParams = strTestParams;
		}

		/// <summary>
		/// consturctor that accepts an inner exception, a descriptive message, 
		/// a label of a test provider, and the parameters passed to the test
		/// </summary>
		/// <param name="message">descriptive message</param>
		/// <param name="inner">inner exception (the exception that caused this one)</param>
		/// <param name="strTestProviderLabel">a test provider name</param>
		/// <param name="strTestParams">a test parameters</param>
		public TestProviderActionFailedException(string message, Exception inner,string strTestProviderLabel,string strTestParams)
			: base(message, inner)
		{
			_strTestProviderLabel = strTestProviderLabel;
			_strTestParams = strTestParams;
		}

	
	}
}
