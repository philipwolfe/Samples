using System;
using System.Xml;
using System.IO;
using XBLIP.XmlUtil;

namespace XBLIP.DAIL
{
	/// <summary>
	/// a standard response reader implemented using an XmlReader.
	/// This reader is charachtered by its forward-only read. This means
	/// that no direct finding of elements is allowed, and that after an
	/// entity content/definition is read one can't get its attributes. but
	/// its the fastest and most cheep of all implementations
	/// </summary>
	internal class XmlReaderResponseReader : IResponseReader
	{
		/// <summary>
		/// the underlying reader object which reads the standard
		/// response
		/// </summary>
		XmlReader underlyingReader;

		/// <summary>
		/// constructor. Accepts a standard response XML string
		/// and loads it
		/// </summary>
		/// <param name="strResponse"></param>
		public XmlReaderResponseReader(string strResponse) 
		{
			StringReader stringReader = new StringReader(strResponse);
			underlyingReader = new XmlTextReader(stringReader);
		}

		/// <summary>
		/// return an iterator of the items, based on a navigator
		/// of the underlying reader
		/// </summary>
		/// <returns>an XmlReaderItemsFields iterator </returns>
		public IResponseEntityIterator getItemsIterator() 
		{
			return new XmlReaderItemsFields(new XmlReaderEntityNavigator(underlyingReader,"Response"));
		}

	}
}
