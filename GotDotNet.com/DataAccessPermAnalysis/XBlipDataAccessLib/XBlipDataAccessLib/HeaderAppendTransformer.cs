using System;

namespace XBLIP.Transformers
{
	/// <summary>
	/// simple implementation of transformer for DAIL. Takes a request
	/// string and append it to a header that is set in the constructor.
	/// This is good when the request should be displatched to a single data
	/// source that knows how to handle standard requests. An example to that
	/// would be a web service
	/// </summary>
	public class HeaderAppendTransformer:ITransformer
	{
		/// <summary>
		/// constants
		/// </summary>
		private const string QUERY_SEPERATOR = "QUERY_SEPERATOR";
		private const string SEPERATOR = "-";
		private const string EL = "\n";
		
		/// <summary>
		///  data source label to be appended
		/// </summary>
		public string dataSourceLabel;

		/// <summary>
		/// parameter string. This should be a complete one, with all the
		/// required seperators
		/// </summary>
		public string paramsString;

		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="idataSourceLabel">data source label</param>
		/// <param name="iparamsString">parameters string</param>
		public HeaderAppendTransformer(string idataSourceLabel,string iparamsString)
		{
			dataSourceLabel = idataSourceLabel;
			paramsString = iparamsString;
		}

		/// <summary>
		/// transform a request string to a track version - 
		/// appends a header constructed of the data source label
		/// and the parameters string to the request
		/// </summary>
		/// <param name="toTransform">request to transform</param>
		/// <returns>request as a track</returns>
		public string transform(string toTransform) 
		{
			string transformed;

			transformed = 
				QUERY_SEPERATOR + SEPERATOR + dataSourceLabel + SEPERATOR + paramsString + EL +
				toTransform;

			return transformed;
		}
	}
}
