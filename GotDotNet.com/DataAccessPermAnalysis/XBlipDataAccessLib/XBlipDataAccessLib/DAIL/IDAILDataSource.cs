using System;

namespace XBLIP.DAIL
{
	/// <summary>
	/// An interface for data source driver. 
	/// <newpara>A single data source driver object relates to a single data source It may
	/// be a data base link, a web service or just a functional data source (returning a 
	/// simple manipulation on the track string). The data source driver knows how to use
	/// the data source in order to manipulate data or retrieve it, using the input track
	/// string as the parameters for those actions.
	/// </newpara>
	/// <newpara>
	/// The 2 methods defined by this interface allow for a separation of the above mentioned
	/// functionality, The retrieve method is used by <see cref="XBLIP.DAIL.AbstractDAIL">AbstractDAIL</see>
	/// to return a data set to merge with other results to a single result, or as a parameters
	/// retrieve. The modify method is used by <see cref="XBLIP.DAIL.AbstractDAIL">AbstractDAIL</see> to manipulate
	/// the data in the data source. The result of modify is used as the result returning to the
	/// user to signal the modification. Normally the expected result is the number of modified
	/// items of the type that is signaled by the request ID.
	/// </newpara>
	/// </summary>
	public interface IDAILDataSource
	{
		/// <summary>
		///	retrieve data from the data source, using the track content (given in strTrackContent)
		///	as the parameter for the retrieve. One may also recieve a "Pipe" response of a
		///	previosly retrieved response as more input to the retrieve.
		///	<newpara>
		///	The method is expected to return a response string in the DAIL standard
		///	</newpara>
		/// </summary>
		/// <param name="strTrackContent">parameter string given to the method. The string 
		/// content is dependent of the data source type. For a DB data source it may be
		/// an SQL string, For a web service it may be an XML etc.
		/// </param>
		/// <param name="strPipe">
		/// a response string from another response, or an empty string. The existance of
		/// such a string is defined by the user. Its usage is determined by the concrete class
		/// (as with strTrackContent)
		/// </param>
		/// <param name="strID">
		/// id string expected to be as the "id" attribute of the response tag in the returned
		/// response string
		/// </param>
		/// <param name="strAction">
		/// action string expected to be as the "action" attribute of the response tag in the returned
		/// response string
		/// </param>
		/// <returns>a response string in the DAIL form</returns>
		string retrieve(string strTrackContent, string strPipe,string strID,string strAction);

		/// <summary>manipulate data on the data source. This method is used in the
		/// modify method of <see cref="XBLIP.DAIL.AbstractDAIL">AbstractDAIL</see> to
		/// modify data as instructed by a given track
		/// </summary>
		/// <param name="strTrackContent">parameter string given to the method. The string 
		/// content is dependent of the data source type. For a DB data source it may be
		/// an SQL string, For a web service it may be an XML etc.
		/// </param>
		/// <returns>a response string (any!)</returns>
		string modify(string strTrackContent);
	}
}
