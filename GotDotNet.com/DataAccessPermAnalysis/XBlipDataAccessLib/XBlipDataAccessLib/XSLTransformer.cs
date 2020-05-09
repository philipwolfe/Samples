using System;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Text;
using System.IO;

namespace XBLIP.Transformers
{
	/// <summary>
	/// XSL transformer. transforms a given string (request/response)
	/// to a series of tracks, tests (whatever) via XSL transformation.
	/// The object can either get a file path or an actuall XSL object and
	/// used it for the transformation. The transform method simply applies the
	/// XSL to the given string
	/// </summary>
	public class XSLTransformer:ITransformer
	{
		/// <summary>
		/// XSL transformer object
		/// </summary>
		public XslTransform xslTransform;

		/// <summary>
		/// constructor that takes a file path. The transformer object
		/// is built in the constructor
		/// </summary>
		/// <param name="xslFilePath">(VALID) xsl file path</param>
		public XSLTransformer(string xslFilePath)
		{
			xslTransform = new XslTransform();
			xslTransform.Load(xslFilePath);
		}

		/// <summary>
		/// a constructor the accepts a ready XSL object
		/// </summary>
		/// <param name="ixslTransform">object to use as transformer</param>
		public XSLTransformer(XslTransform ixslTransform) 
		{
			xslTransform = ixslTransform;
		}

		/// <summary>
		/// transform the given string to another via the XSL object
		/// </summary>
		/// <param name="toTransform">string to transform</param>
		/// <returns>transformed string</returns>
		public string transform(string toTransform) 
		{
			StringBuilder stbBuffer = new StringBuilder();
			StringReader stringReader = new StringReader(toTransform);
			XPathDocument xpathTransformed;
			StringWriter stmWriter;
		
			xpathTransformed = new XPathDocument(stringReader);
			stmWriter = new StringWriter(stbBuffer);
			xslTransform.Transform(xpathTransformed,null,stmWriter);
			return stbBuffer.ToString();
		}
	}
}
