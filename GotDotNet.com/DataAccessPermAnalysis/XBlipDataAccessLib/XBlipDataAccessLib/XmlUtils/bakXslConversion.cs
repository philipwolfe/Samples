using System;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Text;
using System.IO;

namespace XBLIP.XmlUtil
{
	/// <summary>
	/// a static class for a single XSL conversion method
	/// </summary>
	public class XslConversion
	{

		/// <summary>
		/// get a string that is the result of transforming and XML string
		/// given via <c>strToTransform</c> by an XSL transformation (which is
		/// given as a file path)
		/// </summary>
		/// <param name="strXSLPath">XSL transformation file path</param>
		/// <param name="strToTransform">XML string to transform</param>
		/// <returns>transformed string</returns>
		public static string getTransformedXML(string strXSLPath,string strToTransform) 
		{
			StringBuilder stbBuffer = new StringBuilder();
			XslTransform xslTranform;
			XPathDocument xpathTransformed;
			StringWriter stmWriter;
		
			xslTranform = new XslTransform();
			xslTranform.Load(strXSLPath);
			xpathTransformed = new XPathDocument(strToTransform);
			stmWriter = new StringWriter(stbBuffer);
			xslTranform.Transform(xpathTransformed,null,stmWriter);
			return stbBuffer.ToString();
		}
	}
}
