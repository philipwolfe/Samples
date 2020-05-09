using System;
using XBLIP.XmlUtil;

namespace XBLIP.DAIL
{
	/// <summary>
	/// a class that implements <c>IResponseEntityIterator</c>, <c>IResponseItem</c>
	/// and <c>IResponseItemField</c> on a underlying XmlReader implementation.
	/// One thing to remmember about such an implementation is that its forward only
	/// and that after reading an entity (item or field) definition or content, the entity
	/// is gone now...
	/// </summary>
	internal class XmlReaderItemsFields: IResponseEntityIterator,IResponseItem,IResponseItemField
	{

		/// <summary>
		/// the underlying navigator to the items/fields
		/// </summary>
		XmlReaderEntityNavigator underlyingIterator;

		/// <summary>
		/// a flag that tells if the current entity has been thorougly read or not.
		/// this is important when the content/definition of an entity has been read,
		/// so that no <c>XmlReaderEntityNavigator.moveToNextEntity()</c> is required for
		/// the next item to be approached
		/// </summary>
		bool bEntityRead;
		
		/// <summary>
		/// constructor that accepts a navigator to iterate on (may
		/// be a navigator of items or of fields)
		/// </summary>
		/// <param name="xmlReaderEntityNavigator">navigator to iterate on</param>
		public XmlReaderItemsFields(XmlReaderEntityNavigator xmlReaderEntityNavigator)
		{
			underlyingIterator = xmlReaderEntityNavigator;
			underlyingIterator.moveToEntitiesBegin();
			bEntityRead = false;
		}

		/// <summary>
		/// move to the next entity. If the current entity has already
		/// been flushed (this happens when the definition/content of an entity
		/// has been read already) no advance is done. return this
		/// if the iteration is not done, otherwise null
		/// </summary>
		/// <returns>IResponseItem or IResponseField</returns>
		public IResponseEntity nextValue()
		{

			if(!bEntityRead) 
				underlyingIterator.moveToNextEntity();
			bEntityRead = false;

			if(underlyingIterator.isEntitiesEnd())
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
				if(underlyingIterator.isEntitiesEnd())
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
			return underlyingIterator.isEntitiesEnd();
		}

		/// <summary>
		/// get the ID of the current iterated Item.
		/// implements <c>IResponseItem.getID()</c>
		/// </summary>
		/// <returns>id property of the current pointed entity</returns>
		public string getID() 
		{
			return underlyingIterator.getEntityAttribute("id");
		}

		/// <summary>
		/// return an iterator of the child nodes of this entity (normally
		/// executed on an Item to get its fields)
		/// </summary>
		/// <returns>xml node list of the iterated entity children</returns>
		public IResponseEntityIterator getSubEntityIterator() 
		{
			return new XmlReaderItemsFields(new XmlReaderEntityNavigator(underlyingIterator.underlyingReader,"Item"));
		}

		/// <summary>
		/// get the current iterated item node name
		/// </summary>
		/// <returns>a node name</returns>
		public string getName() 
		{
			if(underlyingIterator.isEntitiesEnd())
				return "";
			else
				return underlyingIterator.getEntityName();
		}

		/// <summary>
		/// get the content of the current pointed item (inner xml/text).
		/// results in an advance of the reader pointer to the next item
		/// </summary>
		/// <returns>content of a node</returns>
		public string getContent() 
		{
			if(underlyingIterator.isEntitiesEnd() || bEntityRead)
				return "";
			else 
			{
				bEntityRead = true;
				return underlyingIterator.getEntityContent();
			}
		}

		/// <summary>
		/// get the definition of a node (all of the tag content including bounding
		/// tags).
		/// results in an advance of the reader pointer to the next item
		/// </summary>
		/// <returns>definition of current pointed entity</returns>
		public string getDefinition() 
		{
			if(underlyingIterator.isEntitiesEnd() || bEntityRead)
				return "";
			else 
			{
				bEntityRead = true;
				return underlyingIterator.getEntityDefinition();
			}
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
			string strAttrVal = underlyingIterator.getEntityAttribute(strName);

			if (null == strAttrVal)
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
			return underlyingIterator.getEntityAttribute("type");
		}
	}
}
