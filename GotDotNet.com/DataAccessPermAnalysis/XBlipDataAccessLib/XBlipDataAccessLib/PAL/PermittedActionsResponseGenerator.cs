using System;
using System.Collections;
using XBLIP.StandardResponse;
using XBLIP.XmlUtil;

namespace XBLIP.PAL
{
	/// <summary>
	/// a class used in <c>AbstractPAL.retrievePermissions</c> to generate
	/// a response to a permission query. The class is initiated with items, and
	/// later may accepts actions names to add to each item (those should be actions
	/// that are permitted to that item). Finally a call to <c>generateResponse</c>
	/// generates a Standard response in which all the items have a field for each
	/// action that is allowed for that item
	/// </summary>
	internal class PermittedActionsResponseGenerator
	{

		/// <summary>
		/// dictionary holding items. For each item an array will be saved with
		/// the actions that are allowed for that item
		/// </summary>
		Hashtable dictItems;

		/// <summary>
		/// constructor. creates dictItems
		/// </summary>
		public PermittedActionsResponseGenerator()
		{
			dictItems = new Hashtable();
		}

		/// <summary>
		/// add a single item to the generator
		/// </summary>
		/// <param name="strItemID">item id to add</param>
		public void addItem(string strItemID) 
		{
			dictItems.Add(strItemID,new ArrayList());
		}

		/// <summary>
		/// add item through a navigator. The method loops
		/// the items and add each item id to the items dictionary
		/// </summary>
		/// <param name="itemsNavigator">navigator holding items</param>
		public void addItems(XmlReaderEntityNavigator itemsNavigator) 
		{
			if(itemsNavigator.moveToEntitiesBegin()) 
			{
				while(!itemsNavigator.isEntitiesEnd()) 
				{
					addItem(itemsNavigator.getEntityAttribute("id"));
					itemsNavigator.moveToNextEntity();
				} 
			}
		}

		/// <summary>
		/// add a permitted action id to the permitted actions array for a given
		/// item id.
		/// </summary>
		/// <param name="strItemID">an item id to add the action to</param>
		/// <param name="strActionID">an action id to add as permitted</param>
		public void AddPermittedAction(string strItemID,string strActionID) 
		{
			ArrayList itemActionsList;
			itemActionsList = (ArrayList) dictItems[strItemID];
			itemActionsList.Add(strActionID);
		}

		/// <summary>
		/// add a permitted action id to the permitted actions array for each of the
		/// listed items
		/// </summary>
		/// <param name="itemsNavigator">an items list to add the permitted action to</param>
		/// <param name="strActionID">an action id to add as permitted</param>
		public void addPermittedAction(XmlReaderEntityNavigator itemsNavigator,string strActionID) 
		{
			if(itemsNavigator.moveToEntitiesBegin()) 
			{
				while(!itemsNavigator.isEntitiesEnd()) 
				{
					AddPermittedAction(itemsNavigator.getEntityAttribute("id"),strActionID);
					itemsNavigator.moveToNextEntity();
				} 
			}
		}

		/// <summary>
		/// add a permitted action id to the permitted actions array for all items
		/// </summary>
		/// <param name="strActionID">an action id to add as permitted</param>
		public void AddPermittedAction(string strActionID) 
		{
			foreach(DictionaryEntry itemEntry in dictItems) 
				((ArrayList) itemEntry.Value).Add(strActionID);
		}

		/// <summary>
		/// checks if the item id matches any item that has been added before
		/// </summary>
		/// <param name="strItemID">an item id</param>
		/// <returns>true if this id matches an item in dictItems. false otherwise</returns>
		public bool isItemExists(string strItemID) 
		{
			return dictItems.Contains(strItemID);
		}

		/// <summary>
		/// generate a standard response out of the collected items and actions
		/// </summary>
		/// <param name="strItemTypeID">id that should be placed in the "Response" tag</param>
		/// <returns>a standard response listing all items and for each item an "ActionPermitted" tag
		/// with an "id" attribute including the name of a permitted action</returns>
		public string generateResponse(string strItemTypeID) 
		{
			ResponseWriter responseWriter = new ResponseWriter();
			ArrayList itemActionsList;


			responseWriter.writeResponseStart(strItemTypeID,"PermissionRetrieve");

			foreach(DictionaryEntry itemEntry in dictItems) 
			{
				responseWriter.writeItemStart((string) itemEntry.Key);
				itemActionsList = (ArrayList) itemEntry.Value;
				foreach(string actionID in itemActionsList)
					responseWriter.writeField(
						"<ActionPermitted id=\"" +
							actionID +
						"\"/>");
				responseWriter.writeItemEnd();
			}
			responseWriter.writeResponseEnd();

			return responseWriter.ToString();
		}
	}
}
