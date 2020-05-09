using System;
using System.Xml;

namespace XBLIP.DAIL
{
	/// <summary>
	/// Standard response reader implemented in DOM. apart from <c>IReseponseReader</c>
	/// implementation it offers also to get an item directly through an id,
	/// and also to remove an item by handing an iterator pointing to that item.
	/// </summary>
	internal class XmlDomResponseReader : XBLIP.DAIL.IResponseReader
	{
		/// <summary>
		/// the underlying document element pointing to the "Response" element
		/// </summary>
		XmlNode underlyingNode;

		/// <summary>
		/// constructor. Accepts a standard response string and loads
		/// it
		/// </summary>
		/// <param name="strResponse">standard response to load</param>
		public XmlDomResponseReader(string strResponse)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(strResponse);
			underlyingNode = xmlDocument.DocumentElement;
		}

		/// <summary>
		/// get an iterator of items (child nodes of main tag)
		/// </summary>
		/// <returns>xml nodes list</returns>
		public IResponseEntityIterator getItemsIterator() 
		{
			return new XmlDomItemsFields(underlyingNode.ChildNodes);
		}

		/// <summary>
		/// get an item directly using its id. return null if
		/// the id does not match any item
		/// </summary>
		/// <param name="strID">an item id</param>
		/// <returns>an IResponseItem of the matching id</returns>
		public IResponseItem getItem(string strID) 
		{
			XmlNodeList xmlItem = underlyingNode.SelectNodes("Item[@id = \"" + strID + "\"]");
			if (0 == xmlItem.Count)
				return null;
			else 
				return new XmlDomItemsFields(xmlItem);
		}

		/// <summary>
		/// remove the item that is the current of the input
		/// iterator
		/// </summary>
		/// <param name="xmlItem">an iterator pointing to the item to remove</param>
		public void removeItem(XmlDomItemsFields xmlItem) 
		{
			underlyingNode.RemoveChild(((XmlDomItemsFields)xmlItem.current).getNode());
		}

	}
}
