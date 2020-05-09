using System;

namespace XBLIP.DAIL {

	/// <summary>
	/// exception class used by <c>AbstractDAIL</c> to signal that the
	/// call to a data source failed. The exception will normally hold
	/// the orgiginal exception as its internal exception
	/// </summary>
	public class DataSourceActionFailedException : Exception
	{
		/// <summary>
		/// data source on which the call has been failed
		/// </summary>
		private string _strDataSourceLabel;

		/// <summary>
		/// read only property for the data source label
		/// </summary>
		public string dataSourceLabel 
		{
			get 
			{
				return _strDataSourceLabel;
			}
		}

		/// <summary>
		/// constructor. accepts a data source label
		/// </summary>
		/// <param name="strDataSourceLabel">data source that failed label</param>
		public DataSourceActionFailedException(string strDataSourceLabel)
		{
			_strDataSourceLabel = strDataSourceLabel;
		}

		/// <summary>
		/// constructor. Accepts a message and the data source that failed label
		/// </summary>
		/// <param name="message">exception description message</param>
		/// <param name="strDataSourceLabel">data source that failed label</param>
		public DataSourceActionFailedException(string message,string strDataSourceLabel)
			: base(message)
		{
			_strDataSourceLabel = strDataSourceLabel;
		}
		
		/// <summary>
		/// constructor. Accepts a message, data source label and the exception that
		/// caused this one raise
		/// </summary>
		/// <param name="message">exception description message</param>
		/// <param name="inner">internal exception</param>
		/// <param name="strDataSourceLabel">data source that failed label</param>
		public DataSourceActionFailedException(string message, Exception inner,string strDataSourceLabel)
			: base(message, inner)
		{
			_strDataSourceLabel = strDataSourceLabel;
		}

	
	}
}
