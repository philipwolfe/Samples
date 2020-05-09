using System;

namespace XBLIP.DAIL.DataSources
{
	/// <summary>
	/// a data source that for each of the methods return the track content as is.
	/// This data source is usefull when trying to merge constant values to another 
	/// data set. 
	/// <newPara>
	/// For example : to build a table showing the salary avarage of
	/// people according to different age ranges, use this data source
	/// with a track content that is equal to a response string returning for each
	/// item the age ranges. The other tracks should contain actuall calculated values.
	/// merging them will result a single XML that for each item will have the age
	/// ranges as one of the fields - ready for display...
	/// </newPara>
	/// <newPara>
	///	The following example shows how to use the class:
	///	<pre>
	///	IDAILDataSource myDataSource = new NullDataSource();
	///	string strTrackContent =
	///		"&lt;Response id=\"test\" action=\"retrieve\"&gt;
	///			&lt;Item id="1"&gt;1-10&lt;/Item&gt;
	///			&lt;Item id="2"&gt;11-20&lt;/Item&gt;
	///			&lt;Item id="3"&gt;21-30&lt;/Item&gt;
	///		&lt;/Response&gt;";
	///	string strResponse = myDataSource.retrieve(strTrackContent);
	///	Console.Write("{0} is equal to {1}",strTrackContent,strResponse);
	///	</pre>
	/// </newPara>
	/// </summary>
	public class NullDataSource : IDAILDataSource
	{
		/// <summary>
		/// implements <c>IDailDataSource.modify</c> to return the given track content
		/// </summary>
		/// <param name="strTrackContent">track content string</param>
		/// <returns>strTrackContent</returns>
		public string modify(string strTrackContent)
		{
			return strTrackContent;
		}

		/// <summary>
		/// implements <c>IDailDataSource.retrieve</c> to return the given track content
		/// </summary>
		/// <param name="strTrackContent">track content string</param>
		/// <param name="strPipe">pipe string (never used)</param>
		/// <param name="strID">id attribute value (never used)</param>
		/// <param name="strAction">action attribute value (never used)</param>
		/// <returns>strTrackContent</returns>
		public string retrieve(string strTrackContent, string strPipe,string strID,string strAction)
		{
			return strTrackContent;
		}
	}
}
