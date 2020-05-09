using System;
using System.Xml;

namespace XBLIP.XmlUtil
{
	/// <summary>
	/// wrapper class for an XmlReader. The class helps users of a reader
	/// to loop child nodes of a given node by defining the bounderies of the loop.
	/// The bounderies is the string name of the parent node. Using this method eases
	/// very much the use of an XmlReader with respect of going only into elements that
	/// interest the user. The class allows also for a replacement of the bounderies label
	/// so that it may be reused recursively.
	/// <newPara>
	///	The following example shows how to use the class:
	///	<pre>
	///	assume the following XML:
	///	&lt;tests&gt;
	///		&lt;test id="A"&gt; <i>test params</i> &lt;/test&gt;
	///		&lt;test id="B"&gt; <i>test params</i> &lt;/test&gt;
	///		<i>... more tests...</i>
	///	&lt;/tests&gt;
	///	
	///	XmlReaderEntityNavigator aNavigator = new XmlReaderEntityNavigator(xmlReader,"tests");
	///		// xmlReader loaded the above xml...
	///	
	///	if(aNavigator.moveToEntitiesBegin())  // move to the first test
	///	{
	///		while(!aNavigator.isEntitiesEnd())
	///		{
	///			performTest(aNavigator); 
	///				// perform the test on the navigator pointing to a test
	///			aNavigator.moveToNextEntity(); 
	///				// use this only if the internals of the test are not
	///				// read in performTest()
	///			
	///		}
	///	}
	///	</pre>
	/// </newPara>
	/// </summary>
	public class XmlReaderEntityNavigator
	{
		/// <summary>
		/// entities bound label the navigator starts and stops when
		/// an element with the bound label is found 
		/// </summary>
		string strEntitiesBoundNodeLabel;

		/// <summary>
		/// the underlying reader
		/// </summary>
		XmlReader readerEntities;

		/// <summary>
		/// constructor. accepts the underlying reader, and a bound label
		/// </summary>
		/// <param name="xmlReader">underlying reader</param>
		/// <param name="strBound">element bounding label</param>
		public XmlReaderEntityNavigator(XmlReader xmlReader,string strBound)
		{
			readerEntities = xmlReader;
			strEntitiesBoundNodeLabel = strBound;
		}

		/// <summary>
		/// read only property for the underlying reader
		/// </summary>
		public XmlReader underlyingReader 
		{
			get 
			{
				return readerEntities;
			}
		}

		/// <summary>
		/// r/w property for the bound element name
		/// </summary>
		public string entitiesBoundLabel 
		{
			set 
			{
				strEntitiesBoundNodeLabel = value;
			}

			get 
			{
				return strEntitiesBoundNodeLabel;
			}
		}

		/// <summary>
		/// move to entities begin. This method should be used to get to the first
		/// element that is a child element of the bounding element (which name is the label)
		/// </summary>
		/// <returns>boolean if the bounding element was found</returns>
		public bool moveToEntitiesBegin() 
		{
			bool bEntitiessBeginNotFound = ((readerEntities.NodeType != XmlNodeType.Element) || (strEntitiesBoundNodeLabel != readerEntities.Name));

			while(bEntitiessBeginNotFound && readerEntities.Read()) 
			{
				if((readerEntities.NodeType == XmlNodeType.Element) && (strEntitiesBoundNodeLabel == readerEntities.Name))
					bEntitiessBeginNotFound = false;
			}

			if(!bEntitiessBeginNotFound)
				readerEntities.Read();

			readToNearestEntity();

			return !bEntitiessBeginNotFound;
		}

		/// <summary>
		/// read to the nearest entity, or to entities end if no 
		/// entity is found
		/// </summary>
		private void readToNearestEntity() 
		{
			bool bContinue;
			
			if((readerEntities.NodeType == XmlNodeType.EndElement) && (strEntitiesBoundNodeLabel == readerEntities.Name))
				bContinue = false;
			else
				bContinue = (readerEntities.NodeType != XmlNodeType.Element);

			while(bContinue && readerEntities.Read()) 
			{
				if((readerEntities.NodeType == XmlNodeType.EndElement) && (strEntitiesBoundNodeLabel == readerEntities.Name))
					bContinue = false;

				if(readerEntities.NodeType == XmlNodeType.Element)
					bContinue = false;
			}
		}

		/// <summary>
		/// check if arrived to the end element tag of the bounding element
		/// </summary>
		/// <returns>indication for entities end</returns>
		public bool isEntitiesEnd() 
		{
			 return ((readerEntities.NodeType == XmlNodeType.EndElement &&
				readerEntities.Name == strEntitiesBoundNodeLabel) || 
				 readerEntities.EOF);
		}

		/// <summary>
		/// get this entity content. Will result in an advancement to the
		/// next entity
		/// </summary>
		/// <returns>internals of an element tag</returns>
		public string getEntityContent() 
		{
			string strResult = readerEntities.ReadInnerXml();
			readToNearestEntity();
			return strResult;

		}

		/// <summary>
		/// get this entity definition. Will result in an advancement to the
		/// next entity
		/// </summary>
		/// <returns>xml definition of an element tag</returns>
		public string getEntityDefinition() 
		{
			string strResult = readerEntities.ReadOuterXml();
			readToNearestEntity();
			return strResult;
		}

		/// <summary>
		/// get the current entity name
		/// </summary>
		/// <returns>the current element name</returns>
		public string getEntityName() 
		{
			return readerEntities.Name;
		}
			
		/// <summary>
		///	move to the next entity. skip this element and advance to the
		///	next element which is under the bounding of the binding element 
		/// </summary>
		public void moveToNextEntity() 
		{
			readerEntities.Skip();
			readToNearestEntity();
		}

		/// <summary>
		/// get an attribute value of the current entity
		/// </summary>
		/// <param name="strAttrName">attribute name which value should be returned</param>
		/// <returns>requested attribute value (empty if attribute does not exists)</returns>
		public string getEntityAttribute(string strAttrName) 
		{
			return readerEntities.GetAttribute(strAttrName);
		}
	
	}
}
