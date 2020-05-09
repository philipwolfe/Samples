using System;

namespace XBLIP.DAIL
{

	/// <summary>
	/// class that holds parameters of a track
	/// </summary>
	internal class Track
	{
		/// <summary>
		/// for a retrieve track, should the response of this track be merged
		/// using intersection policy
		/// </summary>
		public bool isIntersect;
	
		/// <summary>
		/// for a retrieve track, should the response of this track be ignored,
		/// when merge occures
		/// </summary>
		public bool isNotMerged;

		/// <summary>
		/// determines if the track requires a pipe (result of another track)
		/// </summary>
		public bool isPipeRequired;

		/// <summary>
		/// if <c>isPipeRequired</c> is true, will hold the index
		/// of the pipe. -1 if instructed to use the previous track
		/// </summary>
		public int pipeIndex;

		/// <summary>
		/// the raw data of the track - the track content
		/// </summary>
		public string rawData;

		/// <summary>
		/// data source label, to be used for executing the track content
		/// </summary>
		public string dataSourceLabel;

		/// <summary>
		/// parameter retrieve flag. if true then this track is 
		/// a parameter retrieve, and should be retrieved and collected
		/// for its fields
		/// </summary>
		public bool isParamRetrieve;
	}
}
