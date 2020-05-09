using System;
using System.Xml;
using System.Xml.XPath;
using System.Collections;

namespace XBLIP.PAL
{
	/// <summary>
	/// A class used for censoring a response. It accepts a response
	/// and a censor policy in its constructor. Later it may be asked to
	/// censor fields of items by handing fields ids (in an array) and
	/// items list (via XPath navigator, or all censorship).
	/// After all censoring is done, the content of the response may be recieved,
	/// for returning to the user.
	/// </summary>
	internal class CensorableResponse
	{
		/// <summary>
		/// delegate for a censoring method. There exists a 
		/// method for each of the 3 censorship policies
		/// </summary>
		private delegate void censorMethodType(XmlNode fieldNode);

		/// <summary>
		/// a label used to mark a censored field (if a mark was asked)
		/// </summary>
		private const string CENSORED_LABAL = "censored";
		
		/// <summary>
		/// XmlDocument holding the Standard respons that is being
		/// censored
		/// </summary>
		private XmlDocument domResponse;

		/// <summary>
		/// censor method that has been chosen via the censor policy handed in
		/// the constructor
		/// </summary>
		private censorMethodType censorMethod;

		/// <summary>
		/// constructor. Accepts a standard response to censor, and a policy
		/// by which the fields should be censored : marked, marked and emptied or removed
		/// </summary>
		/// <param name="strResponse">standard response</param>
		/// <param name="censorPolicy">censor policy enumerator</param>
		public CensorableResponse(string strResponse,CensorPolicy censorPolicy)
		{
			domResponse = new XmlDocument();
			domResponse.LoadXml(strResponse);
			
			switch(censorPolicy) 
			{
				case CensorPolicy.CPRemove:
					censorMethod = new censorMethodType(censorRemove);
					break;
				case CensorPolicy.CPClearMark:
					censorMethod = new censorMethodType(censorClearMark);
					break;
				case CensorPolicy.CPMark:
					censorMethod = new censorMethodType(censorMark);
					break;
			}
		}

		/// <summary>
		/// censor the fields which names are in the given array
		/// for all items in the response
		/// </summary>
		/// <param name="fieldsIDsArray">array holding names of fields to censor</param>
		public void censorForAll(ArrayList fieldsIDsArray) 
		{
			foreach(XmlNode itemNode in domResponse.DocumentElement.ChildNodes)
				censorItemFields(fieldsIDsArray,itemNode);
		}

		/// <summary>
		/// censor the fields which names are given in the array 
		/// for all the items that are not in <c>itemsList</c>
		/// </summary>
		/// <param name="itemsList">a list of items. use the id attribute to identify them</param>
		/// <param name="fieldsIDsArray">an array of field names</param>
		public void censorForItemsNotInList(XPathNavigator itemsList,ArrayList fieldsIDsArray) 
		{
			XPathNodeIterator itemInList;
			string strItemID;

			foreach(XmlNode itemNode in domResponse.DocumentElement.ChildNodes) 
			{
				strItemID = itemNode.Attributes.GetNamedItem("id").Value;
				itemInList = itemsList.Select("Response/Item[@id = \"" + strItemID + "\"]");
				if (itemInList.Count == 0)								
					censorItemFields(fieldsIDsArray,itemNode);

			}
			
		}

		/// <summary>
		/// censor fields in the array for a single item
		/// </summary>
		/// <param name="fieldsIDsArray">array of fields names</param>
		/// <param name="itemNode">an item node</param>
		private void censorItemFields(ArrayList fieldsIDsArray,XmlNode itemNode) 
		{
			foreach(string fieldID in fieldsIDsArray)
				censorItemField(itemNode,fieldID);
		}

		/// <summary>
		/// censor a field in an item (the reason for the loop is that this
		/// may be an inflating field)
		/// </summary>
		/// <param name="itemNode">the item to censor from</param>
		/// <param name="fieldID">id of a field to censor</param>
		private void censorItemField(XmlNode itemNode,string fieldID) 
		{
			XmlNodeList fieldsList = itemNode.SelectNodes(fieldID);
			foreach(XmlNode field in fieldsList)
				censorMethod(field);
		}

		/// <summary>
		/// one of 3 censor methods. This method removes the fields from the
		/// xml
		/// </summary>
		/// <param name="fieldNode">field XML node</param>
		private void censorRemove(XmlNode fieldNode) 
		{
			fieldNode.ParentNode.RemoveChild(fieldNode);
		}

		/// <summary>
		/// one of 3 censor methods. This method clears the field content and
		/// mark it as censored
		/// </summary>
		/// <param name="fieldNode"></param>
		private void censorClearMark(XmlNode fieldNode) 
		{

			if(fieldNode.Value != null)
				fieldNode.Value = "";
			if(fieldNode.HasChildNodes) 
				fieldNode.RemoveAll();				
			censorMark(fieldNode);
		}

		/// <summary>
		/// one of 3 censor methods. This method marks a field as censored. Marking
		/// is made by adding an attribute named "censored" with the value of 1
		/// </summary>
		/// <param name="fieldNode"></param>
		private void censorMark(XmlNode fieldNode) 
		{
			XmlAttribute attrCensored = fieldNode.OwnerDocument.CreateAttribute(CENSORED_LABAL);
			attrCensored.Value = "1";
			fieldNode.Attributes.SetNamedItem(attrCensored);
		}

		/// <summary>
		/// read only property for the Xml Document XML. Should be used after all
		/// censoring is done to get the resulted standard response.
		/// </summary>
		public string processedResponse 
		{
			get 
			{
				return domResponse.OuterXml;
			}
		}
	}
}
