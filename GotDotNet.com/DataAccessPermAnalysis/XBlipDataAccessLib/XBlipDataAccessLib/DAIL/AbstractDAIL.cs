using System;
using System.Collections;
using System.Text;

namespace XBLIP.DAIL
{

	/// <summary>
	/// Main class of <c>XBLIP.DAIL</c> namespace. The class manages queries to the
	/// data layer of an application using standard Requests And Responses. 
	/// ITransformer is used to get the actual queries out of an XML request, and in return
	/// the class hands a standard response for each query.
	/// <newPara>
	/// The class has 3 main methods:
	/// <lu>
	///		<li><c>retieve</c> - used for retrieving data, in the form of a list of items</li>
	///		<li><c>modify</c> - used for modifying data. The return value depends on the underlying
	///		data sources</li>
	///		<li><c>getDataSource</c> - an abstract method that should be implemented to
	///		get a data source driver from a given label (the label is determined by the transformer
	///		operating on the request
	///		</li>
	/// </lu>
	/// Each of the 2 first methods is used by buisness logic objects to fetch and modify
	/// data from the data layer via XML. This way the bl objects are ignorent to the
	/// actual sources of the data (this is especially important when they are numerous, and
	/// of different types). Only the transformer knows.
	/// </newPara>
	/// <newPara>
	///	The following example shows how to use the class. XSL is used as the transform
	///	mechanism:
	///	<pre>
	///	AbstractDAIL myDail = new MyApplicationDAIL(); 
	///		// notice that the instancieated class is not of the library, but
	///		// of the application. This class should implement <c>getDataSource</c>
	///	string strXSLFilePath = "c:\\myApplicationXSL\\Employees\\EmployeeRetrieve.xsl";
	///	string strQuery =
	///		@"&lt;Request id=\"Employee\" action=\"Retrieve\"&gt;
	///			&lt;Data&gt;
	///				&lt;Name/&gt;
	///				&lt;Address/&gt;
	///			&lt;/Data&gt;
	///			&lt;Profile&gt;
	///				&lt;Department&gt;
	///					&lt;Item&gt; A &lt;/Item&gt;
	///				&lt;/Department&gt;
	///			&lt;/Profile&gt;
	///		&lt;/Request&gt;";
	///	
	///	ITransformer transformer = new XSLTransformer(strXSLFilePath);
	///			
	///	string strResponse = myDail.retrieve(strQuery,transformer,"Employee","Retrieve");
	///	
	///	/* use an XmlReader to build a table out of the retrieve or whatever... */
	///	</pre>
	/// </newPara>
	/// </summary>
	public abstract class AbstractDAIL
	{

		/// <summary>
		/// return a <c>IDAILDataSource</c> class that matches the input label.
		/// If no data source exists that matches the label, subclasses should throw
		/// the <c>XBLIP.DAIL.UnknownDataSourceException</c> exception
		/// </summary>
		/// <param name="strDSLabel">data source label</param>
		/// <returns>a data source driver</returns>
		protected abstract IDAILDataSource getDataSource(string strDSLabel);

		/// <summary>
		/// retrieve data from the data layer. The method is given an XML of a request
		/// and a transformer that converts the XML to a list of tracks. Each
		/// track is a "retrieve track - meaning that it returns data. The tracks responses
		/// are merged to a single response and returned to the user as a single
		/// Standard response.
		/// The method throws a <c>XBLIP.DAIL.DataSourceActionFailedException</c>
		/// if the call to executing data source fails.
		/// </summary>
		/// <param name="strXML">Standard Request XML</param>
		/// <param name="transformer">request transformer</param>
		/// <param name="strID">id attribute value required from the returned response</param>
		/// <param name="strAction">action attribute value required from the returned response</param>
		/// <returns>a standard response</returns>
		public string retrieve(string strXML,ITransformer transformer,string strID,string strAction) 
		{
			ResponsesCollection responsesCollection;
			string strResponse;

			responsesCollection = new ResponsesCollection();
			retrieveResponses(responsesCollection,strXML,transformer,strID,strAction);
			strResponse = responsesCollection.getAccumulatedResponse(strXML,strID,strAction);

			return strResponse;
		}

		/// <summary>
		/// iterate the tracks created by applying the transformer to the XML request, and
		/// load <c>responsesCollection</c> with the responses. strID and strAction
		/// are used by each track response
		/// </summary>
		/// <param name="responsesCollection">a collection to place the responses in</param>
		/// <param name="strXML">XML standard request</param>
		/// <param name="transformer">request transformer</param>
		/// <param name="strID">id to place in the id of each track response</param>
		/// <param name="strAction">action to place in the actio of each track response</param>
		private void retrieveResponses(ResponsesCollection responsesCollection,string strXML,ITransformer transformer,string strID,string strAction) 
		{
			ParamsCollection parameters;
			TrackIterator trackIterator;
			Track track;
			string strResponse;
			
			parameters = new ParamsCollection();
			trackIterator = new TrackIterator(strXML,transformer);

			while(null != (track = trackIterator.nextValue())) 
			{
				strResponse = executeRetrieveTrack(responsesCollection.responses,parameters,track,strID,strAction);
				if(track.isParamRetrieve)
					parameters.add(strResponse);
				responsesCollection.add(strResponse,track.isNotMerged,track.isIntersect);
			}
		}

		/// <summary>
		/// execute a retrieve track. Meaning that this track should be executed by addressing
		/// the <c>retrieve</c> method of the data source driver. Use this method over the other
		/// overload, if there's no importance for the id and action of the repsonse (for example, in
		/// a parameter retrieve track)
		/// </summary>
		/// <param name="pipes">pipes array to be used by retrieve track, in the case it
		/// asks for a pipe</param>
		/// <param name="parameters">parameters collection to be use by the track, in the
		/// case it has parameters references</param>
		/// <param name="track">track class, holding the properties of the track</param>
		/// <returns>standard response of the track</returns>
		private string executeRetrieveTrack(ArrayList pipes,ParamsCollection parameters,Track track) 
		{
			return executeRetrieveTrack(pipes,parameters,track,"","");
		}

		/// <summary>
		/// execute a retrieve track. Meaning that this track should be executed by addressing
		/// the <c>retrieve</c> method of the data source driver. This method uses id and action
		/// as the values of the id and action in the response string of the track
		/// </summary>
		/// <param name="pipes">pipes array to be used by retrieve track, in the case it
		/// asks for a pipe</param>
		/// <param name="parameters">parameters collection to be use by the track, in the
		/// case it has parameters references</param>
		/// <param name="track">track class, holding the properties of the track</param>
		/// <param name="strID">required id of the response from the track</param>
		/// <param name="strAction">required action of the response from the track</param>
		/// <returns>standard response of the track</returns>
		private string executeRetrieveTrack(ArrayList pipes,ParamsCollection parameters,Track track,string strID,string strAction) 
		{
			string strResolvedRawData;
			string strPipe;
			IDAILDataSource dataSource;
			string strResponse;

			strResolvedRawData = parameters.resolveStringParams(track.rawData);
			strPipe = getPipeString(pipes,track);
			dataSource = getDataSource(track.dataSourceLabel);
			try 
			{
				strResponse = dataSource.retrieve(strResolvedRawData,strPipe,strID,strAction);
			} 
			catch (Exception e) 
			{
				throw new DataSourceActionFailedException(
					"Error in executing retrieve for data source",
					e,track.dataSourceLabel);
			}

			return strResponse;
		}

		/// <summary>
		/// get the pipe from <c>pipes</c> that the track requests
		/// </summary>
		/// <param name="pipes">pipes array (previous tracks standard responses)</param>
		/// <param name="track">track requesting a pipe</param>
		/// <returns>standard response of the requested pipe</returns>
		private string getPipeString(ArrayList pipes,Track track) 
		{
			string strResult;

			if(null == pipes  || !track.isPipeRequired)
				strResult = "";
			else
				if(track.pipeIndex == TrackIterator.PIPE_PREV_TRACK)
					strResult = (string)(pipes[pipes.Count -1]);
				else
					strResult = (string)(pipes[track.pipeIndex]);

			return strResult;
		}

		/// <summary>
		/// execute a modification request. The XML request is converted using the transformer
		/// to a series of tracks (modify and parameter retrieves). Each track
		/// is executed. The return result is a standard response in the modify form,
		/// where it's content is a combination of the last track result and the parameter
		/// retrieves results
		/// </summary>
		/// <param name="strXML">standard request XML</param>
		/// <param name="transformer">request transformer</param>
		/// <param name="strID">id for the standard response</param>
		/// <param name="strAction">action for the standard response</param>
		/// <returns>a stanard response for the modify action</returns>
		public string modify(string strXML, ITransformer transformer,string strID,string strAction) 
		{
			ParamsCollection parameters;
			TrackIterator trackIterator;
			Track track;
			string strResponse = "";
			
			parameters = new ParamsCollection();
			trackIterator = new TrackIterator(strXML,transformer);

			while(null != (track = trackIterator.nextValue())) 
			{
				if(track.isParamRetrieve) 
				{
					strResponse = executeRetrieveTrack(null,parameters,track);
					parameters.add(strResponse);
				} 
				else 
				{
					strResponse = executeModifyTrack(parameters,track);
				}
			}

			return buildModifyResponse(strResponse,parameters,strID,strAction);
		}

		/// <summary>
		/// execute a modify track.
		/// The method throws a <c>XBLIP.DAIL.DataSourceActionFailedException</c>
		/// if the call to executing data source fails.
		/// </summary>
		/// <param name="parameters">parameters collection to be used by a track that .
		/// references parameters</param>
		/// <param name="track">modify track to execute</param>
		/// <returns>modify track value (non-standard)</returns>
		private string executeModifyTrack(ParamsCollection parameters,Track track) 
		{
			string strResolvedRawData;
			IDAILDataSource dataSource;
			string strResponse;

			strResolvedRawData = parameters.resolveStringParams(track.rawData);
			dataSource = getDataSource(track.dataSourceLabel);
			
			try 
			{
				strResponse = dataSource.modify(strResolvedRawData);
			} 
			catch(Exception e) 
			{
				throw new DataSourceActionFailedException(
					"Error in executing modify for data source",
					e,track.dataSourceLabel);
			}

			return strResponse;
		}

		/// <summary>
		/// build the final response for a modify action. combine the last response
		/// of a track, and the parameters retrieve
		/// </summary>
		/// <param name="strResponse">the last track response (non-standard)</param>
		/// <param name="parameters">parameters collection</param>
		/// <param name="strID">id of the built response</param>
		/// <param name="strAction">action of the built response</param>
		/// <returns>a standard response</returns>
		private string buildModifyResponse(string strResponse,ParamsCollection parameters,string strID,string strAction) 
		{
			StringBuilder stbBuffer = new StringBuilder();

			stbBuffer.Append("<Response id=\"");
			stbBuffer.Append(strID);
			stbBuffer.Append("\" action=\"");
			stbBuffer.Append(strAction);
			stbBuffer.Append("\"><Item><OK>");
			stbBuffer.Append(strResponse);
			stbBuffer.Append("</OK>");
			stbBuffer.Append(parameters.ToString());
			stbBuffer.Append("</Item></Response>");

			return stbBuffer.ToString();
		}

	}
}
