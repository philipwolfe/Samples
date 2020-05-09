using System;
using System.Collections;
using XBLIP.XmlUtil;
using System.Xml;
using System.IO;

namespace XBLIP.PAL
{
	/// <summary>
	/// a class used in <c>AbstractPAL.retrievePermissions</c> to be a "proxy" of the
	/// request. The class may be initiated with a "PermissionRetrieve" request, and later
	/// fetched for different properties of the request
	/// </summary>
	internal class PermittedActionsRequestParams
	{
		/// <summary>
		/// dictionary holding for each queried action its "Data" property
		/// </summary>
		private Hashtable _dictQueriedActions;

		/// <summary>
		/// indication to whether an "All" item should be added to the response
		/// of the query
		/// </summary>
		private bool bAddAllItem;

		/// <summary>
		/// indication to whether a profile is used in this query
		/// </summary>
		private bool bUsesProfile;

		/// <summary>
		/// profile string of the query, in the case a profile is 
		/// </summary>
		private string strProfile;

		/// <summary>
		/// dirty flag used when resetting the object (yes... it is reusable)
		/// </summary>
		private bool bDirty;

		/// <summary>
		/// id of the request. This is the object id to which dummy requests for each
		/// action will be sent
		/// </summary>
		private string strTypeID;

		/// <summary>
		/// read only attribute that indicates whether an "All" item should be included
		/// in the response
		/// </summary>
		public bool isAddAllItem 
		{
			get 
			{
				return bAddAllItem;
			}
		}

		/// <summary>
		/// read only attribute that indicates whether the query uses a profile
		/// </summary>
		public bool isUsesProfile 
		{
			get
			{
				return bUsesProfile;
			}
		}

		/// <summary>
		/// the query profile parameters, if it has one. Profile
		/// parameters are the contents of a "Profile" tag
		/// </summary>
		public string profileParams 
		{
			get 
			{
				return strProfile;
			}

		}

		/// <summary>
		/// read only property for the dictionary of actions, and their
		/// "Data" attribute value
		/// </summary>
		public Hashtable dictQueriedActions 
		{
			get 
			{
				return _dictQueriedActions;
			}
		}

		/// <summary>
		/// read only property for the id of the object on which the query is being
		/// made
		/// </summary>
		public string id 
		{
			get 
			{
				return strTypeID;
			}
		}

		/// <summary>
		/// constructor. does some defaults 
		/// </summary>
		public PermittedActionsRequestParams()
		{
			bDirty = false;
			_dictQueriedActions = new Hashtable();
			bAddAllItem = true;
			bUsesProfile = false;
		}

		/// <summary>
		/// reset the parameters object. after resetting (you can count construction
		/// as reset also) you may reuse this class and call <c>initWithRequest</c>
		/// again
		/// </summary>
		private void reset() 
		{
			_dictQueriedActions.Clear();
			bDirty = false;
			bAddAllItem = true;
			bUsesProfile = false;
		}

		/// <summary>
		/// initiate the class properties with a "PermissionRetrieve" query. The
		/// class is used as a proxy to the query. To make things a bit more comfortable
		/// for the overworked programmer (boo-hoo)
		/// </summary>
		/// <param name="strRequest"></param>
		public void initWithRequest(string strRequest) 
		{
			StringReader stringReader = new StringReader(strRequest);
			XmlTextReader xmlReader = new XmlTextReader(stringReader);
			XmlReaderEntityNavigator requestDataProfileFetcher = new XmlReaderEntityNavigator(xmlReader,"Request");
			string strEntityName;

			if(bDirty)
				reset();

			strTypeID = getItemTypeID(xmlReader);

			requestDataProfileFetcher.moveToEntitiesBegin();
			while(!requestDataProfileFetcher.isEntitiesEnd()) 
			{
				strEntityName = requestDataProfileFetcher.getEntityName();
				if(strEntityName == "Data")
					initDataParams(requestDataProfileFetcher);
				else
					if(strEntityName == "Profile")
						initProfileParams(requestDataProfileFetcher);
					else
						requestDataProfileFetcher.moveToNextEntity();
			}
			bDirty = true;
		}

		/// <summary>
		/// loop to the beginning of the request (those XmlReader read everything these
		/// days) and get the "id" attribute of the request tag. If, for some reason
		/// a "Request" tag is not found return an empty string
		/// </summary>
		/// <param name="requestReader">XmlReader into which the request was read</param>
		/// <returns>an id of an object (or a request)</returns>
		private string getItemTypeID(XmlReader requestReader) 
		{
			string strID;
			bool bRequestTagNotFound = ((requestReader.NodeType != XmlNodeType.Element) || ("Request" != requestReader.Name));

			while(bRequestTagNotFound && requestReader.Read()) 
			{
				if((requestReader.NodeType == XmlNodeType.Element) && ("Request" == requestReader.Name))
					bRequestTagNotFound = false;
			}

			if(bRequestTagNotFound)
				strID = "";
			else
				strID = requestReader.GetAttribute("id");

			return strID;
		}

		/// <summary>
		/// loop the "Data" tag of the request and dig the actions out of there.
		/// Add all actions and their matching "Data" properties into <c>_dictQueriedActions</c>
		/// </summary>
		/// <param name="actionsNavigator">Navigator of a request, that is positioned before (or on) the
		/// "Data" tag of the request</param>
		private void initDataParams(XmlReaderEntityNavigator actionsNavigator) 
		{
			string strCurrentBound = actionsNavigator.entitiesBoundLabel;
			actionsNavigator.entitiesBoundLabel = "Data";
			actionsNavigator.moveToEntitiesBegin();
			while(!actionsNavigator.isEntitiesEnd()) 
				addQueriedAction(actionsNavigator);
			actionsNavigator.entitiesBoundLabel = strCurrentBound;
			actionsNavigator.moveToNextEntity();
		}

		/// <summary>
		/// add a single queried action. look for its "Action" param to get the action
		/// name, and its "Data" param to get the "Data" section that should be used
		/// when building this action dummy query to get the permissions on it
		/// </summary>
		/// <param name="actionParamsNavigator">a navigator pointing to the field holding the
		/// action parameters</param>
		private void addQueriedAction(XmlReaderEntityNavigator actionParamsNavigator) 
		{
			string strCurrentBound = actionParamsNavigator.entitiesBoundLabel;
			string strParamID;
			string strAction = String.Empty;
			string strData = String.Empty;

			actionParamsNavigator.entitiesBoundLabel = "Params";
			actionParamsNavigator.moveToEntitiesBegin();
			while(!actionParamsNavigator.isEntitiesEnd()) 
			{
				strParamID = actionParamsNavigator.getEntityAttribute("id");
				if(strParamID == "Action")
					strAction = actionParamsNavigator.getEntityContent();
				else
					if(strParamID == "Data")
						strData = actionParamsNavigator.getEntityContent();
					else
						actionParamsNavigator.moveToNextEntity();

			}
			_dictQueriedActions.Add(strAction,strData);
			actionParamsNavigator.entitiesBoundLabel = strCurrentBound;
			actionParamsNavigator.moveToNextEntity();
		}

		/// <summary>
		/// save the profile parameters, if a "Profile" tag exists in the query
		/// </summary>
		/// <param name="requestProfileEntity"></param>
		private void initProfileParams(XmlReaderEntityNavigator requestProfileEntity) 
		{
			string strType = requestProfileEntity.getEntityAttribute("type");
			bAddAllItem =  (strType == "IncludeAll");
			bUsesProfile = true;
			strProfile = requestProfileEntity.getEntityContent();
		}

	}
}
