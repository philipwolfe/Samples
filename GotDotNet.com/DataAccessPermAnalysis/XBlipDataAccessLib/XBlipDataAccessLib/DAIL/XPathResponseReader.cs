using System;
using System.Xml.XPath;
using System.IO;

namespace XBLIP.DAIL
{

	/// <summary>
	/// Standard response reader based on an XPath navigator implementation.
	/// apart from implementing <c>IResponseReader</c> the reader also allows
	/// to get an <c>IResponseItem</c> directly via <c>getItem</c>
	/// </summary>
	internal class XPathResponseReader : IResponseReader
	{
		/// <summary>
		/// the underlying navigator object 
		/// </summary>
		XPathNavigator underlyingNavigator;

		/// <summary>
		/// constructor. Takes a standard response and
		/// load it to a document, to get its root tag navigator
		/// </summary>
		/// <param name="strResponse">Standard response XML</param>
		public XPathResponseReader(string strResponse) 
		{
			StringReader stringReader = new StringReader(strResponse);
			XPathDocument xpathDocument= new XPathDocument(stringReader);
			underlyingNavigator = xpathDocument.CreateNavigator();
		}

		/// <summary>
		/// get an iterator of items (child nodes of main tag)
		/// </summary>
		/// <returns>iterator of items</returns>
		public IResponseEntityIterator getItemsIterator() 
		{
			return new XPathItemsFields(underlyingNavigator.SelectChildren(XPathNodeType.Element));
		}

		/// <summary>
		/// get an IResponseItem which id matches the input id. Return null
		/// if none are found
		/// </summary>
		/// <param name="strID">id of an item</param>
		/// <returns>IResponseItem of the matching item</returns>
		public IResponseItem getItem(string strID) 
		{
			XPathNodeIterator xpathItem = underlyingNavigator.Select("Response/Item[@id = \"" + strID + "\"]");
			if (xpathItem.Count > 0)
				return new XPathItemsFields(xpathItem);
			else 
				return null;
		}
	}
}
