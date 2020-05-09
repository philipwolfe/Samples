using System;
using System.Xml;

namespace XBLIP.DAIL
{
	/// <summary>
	/// a class that implements <c>IResponseEntityIterator</c>, <c>IResponseItem</c>
	/// and <c>IResponseItemField</c> on a underlying XmlDom implementation.
	/// The class uses DOM to iterate items, fields etc.
	/// The class may be iterating fields or items, depends on the context.
	/// </summary>
	internal class XmlDomItemsFields : IResponseEntityIterator,IResponseItem,IResponseItemField
	{
		/// <summary>
		/// list of items or fields of an item
		/// </summary>
		XmlNodeList underlyingIterator;
		/// <summary>
		/// current item/field index in the iteration
		/// </summary>
		int nFieldsIndex;

		/// <summary>
		/// constructor of iterator, accepts the node list to iterate on
		/// </summary>
		/// <param name="xmlNodeList">iterated list</param>
		public XmlDomItemsFields(XmlNodeList xmlNodeList)
		{
			underlyingIterator = xmlNodeList;
			nFieldsIndex = 0;
		}

		/// <summary>
		/// move to the next value in the iteration, also returns
		/// the iterated item/field - which is implemented in this class
		/// - so actually <c>this</c> is returned.
		/// return null when iteration is done
		/// </summary>
		/// <returns>IResponseItem or IResponseFields, depends on the context</returns>
		public IResponseEntity nextValue()
		{

			++nFieldsIndex;

			if(nFieldsIndex >= underlyingIterator.Count)
				return null;
			else
				return this;
		}

		/// <summary>
		/// current pointed iterated item/field. return this if
		/// iteration not done, or null otherwise
		/// </summary>
		public IResponseEntity current 
		{
			get 
			{
				if(nFieldsIndex >= underlyingIterator.Count)
					return null;
				else
					return this;
			}
		}

		/// <summary>
		/// boolean method returning whether the iteration is over
		/// </summary>
		/// <returns>true if iteration is over, false otherwise</returns>
		public bool eof() 
		{
			return nFieldsIndex >= underlyingIterator.Count;
		}
	
		/// <summary>
		/// get the XML node pointed currently in the iteration
		/// </summary>
		/// <returns>xml node iterated</returns>
		public XmlNode getNode() 
		{
			return underlyingIterator[nFieldsIndex];
		}

		/// <summary>
		/// get the ID of the current iterated Item.
		/// implements <c>IResponseItem.getID()</c>
		/// </summary>
		/// <returns>id property of the current pointed entity</returns>
		public string getID() 
		{
			return underlyingIterator[nFieldsIndex].Attributes.GetNamedItem("id").Value;
		}

		/// <summary>
		/// return an iterator of the child nodes of this entity (normally
		/// executed on an Item to get its fields)
		/// </summary>
		/// <returns>xml node list of the iterated entity children</returns>
		public IResponseEntityIterator getSubEntityIterator() 
		{
			return new XmlDomItemsFields(underlyingIterator[nFieldsIndex].ChildNodes);
		}

		/// <summary>
		/// get the current iterated item node name
		/// </summary>
		/// <returns>a node name</returns>
		public string getName() 
		{
			if(nFieldsIndex >= underlyingIterator.Count)
				return "";
			else
				return underlyingIterator[nFieldsIndex].Name;
		}

		/// <summary>
		/// get the content of the current pointed item (inner xml/text)
		/// </summary>
		/// <returns>content of a node</returns>
		public string getContent() 
		{
			if(nFieldsIndex >= underlyingIterator.Count)
				return "";
			else
				return underlyingIterator[nFieldsIndex].InnerXml;
		}

		/// <summary>
		/// get the definition of a node (all of the tag content including bounding
		/// tags)
		/// </summary>
		/// <returns>definition of current pointed entity</returns>
		public string getDefinition() 
		{
			if(nFieldsIndex >= underlyingIterator.Count)
				return "";
			else
				return underlyingIterator[nFieldsIndex].OuterXml;
		}

		/// <summary>
		/// return a numeral attribute - if the attribute is found return
		/// its numeral value. otherwise return 0
		/// </summary>
		/// <param name="strName">attribute name</param>
		/// <returns>value of a numeral attribute</returns>
		private int getNumeralAttribute(string strName) 
		{
			int nPriority;
			XmlNode  xmlAttrPriority = underlyingIterator[nFieldsIndex].Attributes.GetNamedItem(strName);

			if (null == xmlAttrPriority)
				nPriority = 0;
			else
				nPriority = Int32.Parse(xmlAttrPriority.Value);
					
			return nPriority;
		}

		/// <summary>
		/// get the priority of the current iterated field
		/// </summary>
		/// <returns>priority of a field</returns>
		public int getPriority() 
		{
			return getNumeralAttribute("priority");
		}

		/// <summary>
		/// get the order of the current iterated field
		/// </summary>
		/// <returns>order of a field</returns>
		public int getOrder() 
		{
			return getNumeralAttribute("order");
		}

		/// <summary>
		/// get the type attribute of the current pointed field
		/// </summary>
		/// <returns>type of field</returns>
		public string getTypeAttribute() 
		{
			XmlNode xmlAttrType = underlyingIterator[nFieldsIndex].Attributes.GetNamedItem("type");

			if(null == xmlAttrType)
				return "";
			else
				return xmlAttrType.Value;
		}
	}
}
