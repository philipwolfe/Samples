using System;
using XBLIP.XmlUtil;

namespace XBLIP.DAIL
{
	/// <summary>
	/// An iterator of tracks. The class starts with a standard request, and a
	/// transformer. The request is transformed using the transformer to produce tracks.
	/// Later the class is used as an iterator of the tracks, parsing tracks data
	/// as it goes.
	/// </summary>
	internal class TrackIterator
	{
		/// <summary>
		/// integer constant symboling a pipe reference to the previous
		/// track
		/// </summary>
		public const int PIPE_PREV_TRACK = -1;

		/// <summary>
		/// constant symboling a track beginning, which serves as a separator
		/// between tracks
		/// </summary>
		private const string QUERY_SEPERATOR = "QUERY_SEPERATOR";

		/// <summary>
		/// a separator that surround a track data source label
		/// </summary>
		private const string DATA_SOURCE_SEPERATOR = "-";

		/// <summary>
		/// a separator between track parameters
		/// </summary>
		private const string PARAM_SEPERATOR = "_";

		/// <summary>
		/// a symbol for dont merge parameter
		/// </summary>
		private const string PARAM_DONT_MERGE = "dontMerge";
		/// <summary>
		/// a symbol for merge intersection policy parameter
		/// </summary>
		private const string PARAM_INTERSECT = "intersect";
		/// <summary>
		/// a symbol for pipe parameter
		/// </summary>
		private const string PARAM_PIPE = "pipe";
		/// <summary>
		/// a symbol signaling the track as a parameters retrieve
		/// </summary>
		private const string PARAM_PARAM_RETRIEVE ="paramRetrieve";

		/// <summary>
		/// standard request to build tracks from
		/// </summary>
		private string strXML;
		
		/// <summary>
		/// the current position of the iterator in the tracks stream
		/// </summary>
		private int nCurrentPos;

		/// <summary>
		/// The tracks stream
		/// </summary>
		private string strTransformed;

		/// <summary>
		/// a buffer for track parameters
		/// </summary>
		private Track trackBuffer;

		/// <summary>
		/// constructor. creates a track stream from the standard request and transformer
		/// </summary>
		/// <param name="istrXML">standard request to build tracks from</param>
		/// <param name="iTransformer">request transformer</param>
		public TrackIterator(string istrXML,ITransformer iTransformer)
		{
			strXML = istrXML;
			trackBuffer = new Track();
			nCurrentPos = 0;
			strTransformed = iTransformer.transform(strXML);
		}

		/// <summary>
		/// get the next track in the tracks stream. return null if non
		/// are found
		/// </summary>
		/// <returns>a track parameters class</returns>
		public Track nextValue() {
			Track trackResult;

			nCurrentPos = findTrackStart();

			if(-1 == nCurrentPos) 
			{
				trackResult = null;
			} 
			else 
			{
				setTrackDefaultValues();
				parseTrackData();
				trackResult = trackBuffer;
			}

			return trackResult;
		}

		/// <summary>
		/// find track start from the current index.
		/// If no track start is found, return -1
		/// </summary>
		/// <returns>index of the next track begin</returns>
		private int findTrackStart() 
		{
			int nResult;

			if(-1 == nCurrentPos)
				nResult = -1;
			else
				nResult = strTransformed.IndexOf(QUERY_SEPERATOR,nCurrentPos);
			return nResult;
		}

		/// <summary>
		/// set track parameters default values
		/// </summary>
		private void setTrackDefaultValues() 
		{
			trackBuffer.isPipeRequired = false;
			trackBuffer.isNotMerged = false;
			trackBuffer.isIntersect = false;
			trackBuffer.isParamRetrieve = false;
		}

		/// <summary>
		/// parse a found track data. Parse its data source label, then
		/// it's parameter flags and then the track content (raw data)
		/// </summary>
		private void parseTrackData() 
		{
			parseDataSourceLabel();
			parseParams();
			parseRawData();
		}

		/// <summary>
		/// parse the track data source label
		/// </summary>
		private void parseDataSourceLabel() 
		{
			int nDataSourceEnd;

			nCurrentPos+= (QUERY_SEPERATOR.Length + DATA_SOURCE_SEPERATOR.Length);
			nDataSourceEnd = strTransformed.IndexOf(DATA_SOURCE_SEPERATOR,nCurrentPos);

			trackBuffer.dataSourceLabel = strTransformed.Substring(nCurrentPos,nDataSourceEnd - nCurrentPos);
			nCurrentPos = nDataSourceEnd + 1;
		}

		/// <summary>
		/// parse the track parameters. loop until no more parameters are defined
		/// </summary>
		private void parseParams() 
		{
			while(PARAM_SEPERATOR == strTransformed.Substring(nCurrentPos,PARAM_SEPERATOR.Length)) 
			{
				nCurrentPos+=PARAM_SEPERATOR.Length;
				parseParam();
			}
		}

		/// <summary>
		/// parse a single param. choose between the parameters to
		/// get the correct handler
		/// </summary>
		private void parseParam() 
		{
			do 
			{
				if(parseMergeParam())
					continue;
				if(parsePipeParam())
					continue;
				if(parseIntersectParam())
					continue;
				if(parseParamRetrieve())
					continue;

			} while(false);
		}

		/// <summary>
		/// parse a no merge param
		/// </summary>
		/// <returns>a boolean indicating whether a no merge param has been parsed</returns>
		private bool parseMergeParam() 
		{
			return parseFlagParam(ref trackBuffer.isNotMerged,PARAM_DONT_MERGE);
		}

		/// <summary>
		/// parse a flag parameter. A flag parameter is a boolean flag,
		/// which the existance of it determines its value as true.
		/// </summary>
		/// <param name="bFlag">by ref boolean variable that stored the flag value</param>
		/// <param name="strFlagIndicator">the flag symbol, indicating its valus</param>
		/// <returns>boolean value indicating whether the flag was indeed parsed</returns>
		private bool parseFlagParam(ref bool bFlag,string strFlagIndicator) 
		{
			bool bParsed;

			if(nCurrentPos + strFlagIndicator.Length > strTransformed.Length) 
				bParsed = false;
			else
				if(strFlagIndicator == strTransformed.Substring(nCurrentPos,strFlagIndicator.Length)) 
				{
					bParsed = true;
					bFlag = true;
					nCurrentPos+=strFlagIndicator.Length;
				} 
				else 
					bParsed = false;
	
			return bParsed;
		}

		/// <summary>
		/// parse a pipe parameter. Determine whether this pipe uses the previous
		/// track as its pipe, or an indexed track is used for the pipe
		/// </summary>
		/// <returns>a boolean indicating whether the parameter was parsed</returns>
		private bool parsePipeParam() 
		{
			bool bParsed;
			int nPipeParamEndPos;
			string strPipeIndex;

			if(nCurrentPos + PARAM_PIPE.Length > strTransformed.Length) 
				bParsed = false;
			else
				if(PARAM_PIPE == strTransformed.Substring(nCurrentPos,PARAM_PIPE.Length)) 
				{

					bParsed = true;
					trackBuffer.isPipeRequired = true;
					nCurrentPos+=PARAM_PIPE.Length;
					nPipeParamEndPos = strTransformed.IndexOf(PARAM_SEPERATOR,nCurrentPos);
					if(nPipeParamEndPos == nCurrentPos)
						trackBuffer.pipeIndex = PIPE_PREV_TRACK;
					else 
					{
						strPipeIndex = strTransformed.Substring(nCurrentPos,nPipeParamEndPos - nCurrentPos);
						trackBuffer.pipeIndex = Int32.Parse(strPipeIndex);
						nCurrentPos = nPipeParamEndPos;
					}
				} 
				else 
					bParsed = false;

			return bParsed;
		}

		/// <summary>
		/// parse an intersection flag
		/// </summary>
		/// <returns>a boolean indicating whether an intersection flag was parsed</returns>
		private bool parseIntersectParam() 
		{
			return parseFlagParam(ref trackBuffer.isIntersect,PARAM_INTERSECT);
		}

		/// <summary>
		/// a param retrieve flag parse
		/// </summary>
		/// <returns>indication that the retrieve param flag was parsed</returns>
		private bool parseParamRetrieve() 
		{
			return parseFlagParam(ref trackBuffer.isParamRetrieve,PARAM_PARAM_RETRIEVE);
		}

		/// <summary>
		/// get the raw data of the track. The raw data is the string
		/// from the header end to the next track header begin
		/// </summary>
		private void parseRawData() 
		{
			int nNextTrackBegin;
			nNextTrackBegin = findTrackStart();

			if(-1 == nNextTrackBegin) 
			{
				trackBuffer.rawData = strTransformed.Substring(nCurrentPos);
				nCurrentPos = strTransformed.Length;
			}
			else 
			{
				trackBuffer.rawData = strTransformed.Substring(nCurrentPos,nNextTrackBegin - nCurrentPos);
				nCurrentPos = nNextTrackBegin;
			}
		}
	}
}
