using System;
using System.Xml.XPath;
using System.Text;

namespace XBLIP.DAIL
{
	/// <summary>
	/// a class that implements <c>IResponseEntityIterator</c>, <c>IResponseItem</c>
	/// and <c>IResponseItemField</c> on a underlying XPathDocument implementation.
	/// The class uses XPathNavigator to iterate items, fields etc.
	/// The class may be iterating fields or items, depends on the context.
	/// </summary>
	internal class XPathItemsFields : IResponseEntityIterator,IResponseItem,IResponseItemField
	{
		/// <summary>
		/// the underlying entity iterator
		/// </summary>
		XPathNodeIterator underlyingIterator;

		/// <summary>
		/// a flag indicating whether the iteratation is not done
		/// </summary>
		bool bHasMoreFields;

		/// <summary>
		/// constructor. Accepts an <c>XPathNodeIterator</c> that
		/// is used for iterating the items/fields
		/// </summary>
		/// <param name="xpathNodeIterator">iterator to iterate on</param>
		public XPathItemsFields(XPathNodeIterator xpathNodeIterator)
		{
			underlyingIterator = xpathNodeIterator;
			bHasMoreFields = underlyingIterator.MoveNext();
		}

		/// <summary>
		/// move to the next entity. If no more entities are found
		/// in the iteration, return null. Otherwise return this
		/// </summary>
		/// <returns>IResponseItem or IResponseField</returns>
		public IResponseEntity nextValue()
		{

			if(bHasMoreFields)
				bHasMoreFields = underlyingIterator.MoveNext();

			if(bHasMoreFields)
				return this;
			else
				return null;
		}

		/// <summary>
		/// current pointed iterated item/field. return this if
		/// iteration not done, or null otherwise
		/// </summary>
		public IResponseEntity current 
		{
			get 
			{
				if(bHasMoreFields)
					return this;
				else
					return null;
			}
		}

		/// <summary>
		/// boolean method returning whether the iteration is over
		/// </summary>
		/// <returns>true if iteration is over, false otherwise</returns>
		public bool eof() 
		{
			return !bHasMoreFields;
		}

		/// <summary>
		/// get the ID of the current iterated Item.
		/// implements <c>IResponseItem.getID()</c>
		/// </summary>
		/// <returns>id property of the current pointed entity</returns>
		public string getID() 
		{
			return underlyingIterator.Current.GetAttribute("id","");
		}

		/// <summary>
		/// return an iterator of the child nodes of this entity (normally
		/// executed on an Item to get its fields)
		/// </summary>
		/// <returns>xml node list of the iterated entity children</returns>
		public IResponseEntityIterator getSubEntityIterator() 
		{
			return new XPathItemsFields(underlyingIterator.Current.SelectChildren(XPathNodeType.Element));
		}

		/// <summary>
		/// get the current iterated item node name
		/// </summary>
		/// <returns>a node name</returns>		
		public string getName() 
		{
			if(bHasMoreFields)
				return underlyingIterator.Current.Name;
			else
				return "";
		}

		/// <summary>
		/// get the content of the current pointed item (inner xml/text)
		/// </summary>
		/// <returns>content of a node</returns>
		public string getContent() 
		{
			if(bHasMoreFields)
				return underlyingIterator.Current.Value;
			else
				return "";
		}

		/// <summary>
		/// get the definition of a node (all of the tag content including bounding
		/// tags)
		/// </summary>
		/// <returns>definition of current pointed entity</returns>
		public string getDefinition() 
		{
			if(bHasMoreFields)
				return getXPathNodeDefinition(underlyingIterator.Current);
			else
				return "";
		}

		/// <summary>
		/// alas! ther's no simple method to get the "innerXML" of a node in the
		/// XPath methodology. This method builds the "innerXML" of an XPath node - which
		/// means the internals of this tag.
		/// </summary>
		/// <param name="xpathNavigator">a current navigator object to work on</param>
		/// <returns>a string that represents the internal value/text of the node</returns>
		private string getXPathNodeDefinition(XPathNavigator xpathNavigator) 
		{
			StringBuilder stbBuilder = new StringBuilder();
			bool bMoreAttributes;

			if(xpathNavigator.NodeType == XPathNodeType.Element) 
			{
				stbBuilder.Append("<");
				stbBuilder.Append(xpathNavigator.Name);
				
				if(bMoreAttributes = xpathNavigator.MoveToFirstAttribute()) 
				{
					while(bMoreAttributes) 
					{
						stbBuilder.Append(" ");
						stbBuilder.Append(xpathNavigator.Name);
						stbBuilder.Append("=\"");
						stbBuilder.Append(xpathNavigator.Value);
						stbBuilder.Append("\"");
						bMoreAttributes = xpathNavigator.MoveToNextAttribute();
					}
					xpathNavigator.MoveToParent();
				}

				stbBuilder.Append(">");

				if ( xpathNavigator.MoveToFirstChild() )
				{
					do
					{
						stbBuilder.Append(getXPathNodeDefinition(xpathNavigator));
					} while ( xpathNavigator.MoveToNext() );

					xpathNavigator.MoveToParent();
				} 
				else
					stbBuilder.Append(xpathNavigator.Value);
				
				stbBuilder.Append("</");
				stbBuilder.Append(xpathNavigator.Name);
				stbBuilder.Append(">");
			} else
				stbBuilder.Append(xpathNavigator.Value);
			return stbBuilder.ToString();
		}	

		/// <summary>
		/// return a numeral attribute - if the attribute is found return
		/// its numeral value. otherwise return 0
		/// </summary>
		/// <param name="strName">attribute name</param>
		/// <returns>value of a numeral attribute</returns>
		private int getNumeralAttribute(string strName) 
		{
			int nAttrVal;
			string strAttrVal = underlyingIterator.Current.GetAttribute(strName,"");

			if (String.Empty == strAttrVal)
				nAttrVal = 0;
			else
				nAttrVal = Int32.Parse(strAttrVal);
					
			return nAttrVal;

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
			return underlyingIterator.Current.GetAttribute("type","");
		}

	}
}
