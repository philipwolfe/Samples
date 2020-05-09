using System;

namespace XBLIP.DAIL
{
	/// <summary>
	/// An exception that should be used by subclasses of <c>AbstractDAL</c>
	/// in the <c>getDataSource</c> method when a label is given to which
	/// there's no matching IDAILDataSource in the application
	/// </summary>
	public class UnknownDataSourceException : ArgumentException
	{
		/// <summary>
		/// the given data source label
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
		/// constructor. Accepts a data source label, for which no data source matches
		/// </summary>
		/// <param name="strDataSourceLabel">data source label that was not resolved</param>
		public UnknownDataSourceException(string strDataSourceLabel)
		{
			_strDataSourceLabel = strDataSourceLabel;
		}

		/// <summary>
		/// constructor. Accepts a data source label and a descriptive message
		/// </summary>
		/// <param name="message">descriptive message of the exception</param>
		/// <param name="strDataSourceLabel">data source label that was not resolved</param>
		public UnknownDataSourceException(string message,string strDataSourceLabel)
			: base(message)
		{
			_strDataSourceLabel = strDataSourceLabel;
		}

		/// <summary>
		/// constructor. Accepts a data source label, descriptive message
		/// and an internal exception
		/// </summary>
		/// <param name="message">descriptive message of the exception</param>
		/// <param name="inner">an internal exception</param>
		/// <param name="strDataSourceLabel">data source label that was not resolved</param>
		public UnknownDataSourceException(string message, Exception inner,string strDataSourceLabel)
			: base(message, inner)
		{
			_strDataSourceLabel = strDataSourceLabel;
		}
	}
}
