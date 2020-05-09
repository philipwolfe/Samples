using System;
using XBLIP.Transformers;



namespace DABuisnessLogic
{
	/// <summary>
	/// Summary description for PersonBO.
	/// </summary>
	public class PersonBO
	{
		public PersonBO()
		{

		}

		public string retrieve(string strXML) 
		{
			DADAIL aDail = new DADAIL();
			XSLTransformer transformer = new XSLTransformer(@"D:\userFolder\Lang - c#\XBLIP\DailAccessApplication\XSLs\PersonRetrieve.xsl");
			string strResult;

			strResult = aDail.retrieve(strXML,transformer,"Person","Retrieve");

			return strResult;

		}
	}
}
