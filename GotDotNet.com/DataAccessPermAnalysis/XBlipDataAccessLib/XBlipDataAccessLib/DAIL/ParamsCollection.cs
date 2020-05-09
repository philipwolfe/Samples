using System;
using System.Collections;
using System.Xml;
using System.IO;
using System.Text;
using XBLIP.XmlUtil;

namespace XBLIP.DAIL
{
	/// <summary>
	/// parameters collection that is fed from "parameter retrieves".
	/// a "paremter retrieve" query. The collection is used before a call to a
	/// data source to resolve all parameter references in the track contents.
	/// The collection can also serialize its valus in an XML form looking like this:
	/// <pre>
	///	&lt;Params&gt;
	///		&lt;Param id="0"&gt;
	///		<i>parameter 0 value</i>
	///		&lt;/Param&gt;
	///		&lt;Param id="1"&gt;
	///		<i>parameter 1 value</i>
	///		&lt;/Param&gt;
	///	&lt;/Params&gt;
	/// </pre>
	/// </summary>
	internal class ParamsCollection
	{
		/// <summary>
		/// constant value symboling a parameter reference in a track content
		/// beginning section
		/// </summary>
		private const string PARAM_REF = "PARAM_REF_";
		/// <summary>
		/// constant value symboling a prameter referece ending section
		/// </summary>
		private const string PARAM_END = "_";

		/// <summary>
		/// array of collected parameters
		/// </summary>
		ArrayList parameters;

		/// <summary>
		/// read only property for recieving the collected parameters array
		/// </summary>
		public ParamsCollection()
		{
			parameters = new ArrayList();
		}

		/// <summary>
		/// add the parameters defined in the standard response. The parameters
		/// are taken only from the first item of the repsonse (parameter retrieves
		/// should have only a single item anyways)
		/// </summary>
		/// <param name="strResponse">standard response string</param>
		public void add(string strResponse)
		{
			XmlTextReader xmlReader;
			StringReader stmReader = new StringReader(strResponse);

			xmlReader = new XmlTextReader(stmReader);
			readParams(xmlReader);
			xmlReader.Close();
		}

		/// <summary>
		/// read the fields of the first item in the parameters string given
		/// in xmlReader and insert them to the paremters array
		/// </summary>
		/// <param name="xmlReader">reader holding a standard response</param>
		private void readParams(XmlTextReader xmlReader) 
		{
			XmlReaderEntityNavigator entityNavigator = 
					new XmlReaderEntityNavigator(xmlReader,"Item");

			if(entityNavigator.moveToEntitiesBegin()) 
			{
				while(!entityNavigator.isEntitiesEnd()) 
				{
					parameters.Add(entityNavigator.getEntityContent());
				}
			}
		}

		/// <summary>
		/// find all occurrences of parameter references in the input
		/// string and replace themm with the referenced parameter value
		/// </summary>
		/// <param name="aString">a string that may contain parameters references</param>
		/// <returns>the input string with the parameters references resolved to the
		/// parameter value</returns>
		public string resolveStringParams(string aString) 
		{
			StringBuilder stbBuffer = new StringBuilder();
			int nCurrentPos = 0;
			int nParamPos;

			while( -1 != (nParamPos = aString.IndexOf(PARAM_REF,nCurrentPos)))
			{
				stbBuffer.Append(aString.Substring(nCurrentPos,nParamPos - nCurrentPos));
				nCurrentPos = nParamPos + PARAM_REF.Length;
				nParamPos = aString.IndexOf(PARAM_END,nCurrentPos);
				stbBuffer.Append((string)parameters[
						Int32.Parse(
							aString.Substring(nCurrentPos,nParamPos - nCurrentPos)
						)
					]);
				nCurrentPos = nParamPos + 1;
			}
			stbBuffer.Append(aString.Substring(nCurrentPos));
			return stbBuffer.ToString();
		}

		/// <summary>
		/// override that serializes the parameters list to an XML string representing
		/// the collection
		/// </summary>
		/// <returns>XML representation of the parameters collection</returns>
		public override string ToString() 
		{
			StringBuilder stbBuffer = new StringBuilder();
			int i;

			stbBuffer.Append("<Params>");
			for(i=0;i<parameters.Count;++i) 
			{
				stbBuffer.Append("<Param id=\"");
				stbBuffer.Append(i);
				stbBuffer.Append("\">");
				stbBuffer.Append((string)parameters[i]);
				stbBuffer.Append("</Param>");
			}
			stbBuffer.Append("</Params>");
			return stbBuffer.ToString();
		}
	}
}
