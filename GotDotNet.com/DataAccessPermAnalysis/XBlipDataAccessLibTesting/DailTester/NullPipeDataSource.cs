using System;

namespace XSLTesterApp
{
	/// <summary>
	/// 
	/// </summary>
	internal class NullPipeDataSource : XBLIP.DAIL.IDAILDataSource
	{
		public string modify(String strTrackContent) {return "doesNothing";}

		public string retrieve(String strTrackContent, string strPipe, string strID, string strAction) {
			string strResult;
			
			if(strPipe == "")
				strResult = strTrackContent;
			else
				strResult = strPipe;

			return strResult;
		}
	
	}
}
