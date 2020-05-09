using System;
using System.Collections;
using System.Xml;
using XBLIP.XmlUtil;
using XBLIP.StandardResponse;

namespace XBLIP.DAIL
{
	/// <summary>
	/// standard responses collection. Used in <c>AbstractDAL.retrieve</c>. Apart from just collecting
	/// the response, the collection also can merge the collected responses
	/// to a single merged response. In the merged response all items have the combined
	/// data handed from each response. The megred response is a standard response.
	/// </summary>
	internal class ResponsesCollection
	{
		/// <summary>
		/// struct used to hold merge data for each string
		/// </summary>
		private struct ResponseFlags 
		{
			/// <summary>
			/// don't merge flag. when the matching response is handled in the
			/// merge algorithm, it is ignored, and the merge continue
			/// </summary>
			public bool bNotMerge;
			/// <summary>
			/// intersection merge flag. when the matching response is handled in
			/// the merge algorithm, the result response of this response and the accumulated
			/// response up to that response is combined only of items that reside on
			/// both responses
			/// </summary>
			public bool bIntersect;
		}

		/// <summary>
		/// list of standard responses (the collected responses)
		/// </summary>
		ArrayList arrResponses;
		/// <summary>
		/// collection of flags for the merge algorithm. each cell in the list
		/// matched a cell in the responses collection
		/// </summary>
		ArrayList responsesFlags;
		/// <summary>
		/// dictionary holding the fields names requested in the "Data" section
		/// of the request. The field names are kept so that in a merge, the algrithm
		/// will be able to tell which field comes first
		/// </summary>
		Hashtable hashOrdinals;
		/// <summary>
		/// the accumulated response id
		/// </summary>
		string strResponseID;
		/// <summary>
		/// the accumulated response action
		/// </summary>
		string strResponseAction;

		/// <summary>
		/// default constructor
		/// </summary>
		public ResponsesCollection()
		{
			arrResponses = new ArrayList();
			responsesFlags = new ArrayList();
			hashOrdinals = new Hashtable();
		}

		/// <summary>
		/// reset method for the collection. removes all responses and merge data
		/// </summary>
		public void clear() 
		{
			arrResponses.Clear();
			responsesFlags.Clear();
		}
	
		/// <summary>
		/// get a response accumulated from all the responses in the collection.
		/// if no responses are in the collection it will return an empty string.
		/// if a single response exists it will be returned as is.
		/// otherwise a merge algorithm will take place to return an accumulated response
		/// </summary>
		/// <param name="strRequest">original request that created the responses in the 
		/// collection. Used for retrieving the field names found under Data, in order
		/// to determine the order of them in the merged data sets</param>
		/// <param name="strID">id of a merged response (ignored in the case of 0 or 1 responses)</param>
		/// <param name="strAction">action of a merged response (ignored in the case of 0 or 1 responses)</param>
		/// <returns>a standard response string</returns>
		public string getAccumulatedResponse(string strRequest,string strID, string strAction) 
		{
			string strAccumulated;
			int nResponsesToAccumulate;

			strResponseID = strID;
			strResponseAction = strAction;
			nResponsesToAccumulate = getResponseToAccumulateCount();

			switch(nResponsesToAccumulate)
			{
				case 0:
					strAccumulated = getEmptyResponse();
					break;
				case 1:
					strAccumulated = getSingleResponse();
					break;
				default:
					strAccumulated = getMergedResponse(strRequest);
					break;
			}

			return strAccumulated;
		}

		/// <summary>
		/// get the number of responses to merge. this does not have to be
		/// the number of responses in the collection, since some of them
		/// may be defined as "no merge"
		/// </summary>
		/// <returns>number of mergable responses</returns>
		private int getResponseToAccumulateCount() 
		{
			int nCount = 0;
			int i;

			for(i=0;i<responsesFlags.Count;++i) 
			{
				if(!((ResponseFlags)responsesFlags[i]).bNotMerge) 
					++nCount;
			}

			return nCount;
		}

		/// <summary>
		/// construct an empty response (in the case of no mergable responses)
		/// </summary>
		/// <returns>empty string</returns>
		private string getEmptyResponse() 
		{
			return "";
		}

		/// <summary>
		/// return the first response that is not signaled as no merge
		/// </summary>
		/// <returns>standard response string</returns>
		private string getSingleResponse() 
		{
			int i;
			i = getNextMergeResponseIndex(arrResponses.Count  -1);
			return (string)(arrResponses[i]);
		}

		/// <summary>
		/// get the next mergable response starting from
		/// the given index
		/// </summary>
		/// <param name="nStartFrom">index to start the search from</param>
		/// <returns>index of the next mergable string. -1 if non are found</returns>
		private int getNextMergeResponseIndex(int nStartFrom) 
		{
			int i;
			int nMerge = -1;
			bool bMergeNotFound  = true;

			for(i=nStartFrom;i>=0 && bMergeNotFound;--i) 
			{
				if(!((ResponseFlags)responsesFlags[i]).bNotMerge) 
				{
					nMerge = i;
					bMergeNotFound = false;
				}
			}

			return nMerge;
		}

		/// <summary>
		/// get an accumulated response of all mergable responses in
		/// the collection. The input request is used for analyzing the order
		/// of the items as should be in the resulted response
		/// </summary>
		/// <param name="strRequest">standard request string</param>
		/// <returns>standard response</returns>
		private string getMergedResponse(string strRequest) 
		{
			int nCurrentResponse;
			string strMerged;
			
			analyzeItemsFieldsOrder(strRequest);
			nCurrentResponse = getNextMergeResponseIndex(arrResponses.Count-1);
			strMerged = (string)arrResponses[nCurrentResponse];
			
			while(-1 != (nCurrentResponse = getNextMergeResponseIndex(nCurrentResponse-1))) 
			{
				strMerged = mergeTwoResponses(
					strMerged,
					(string)arrResponses[nCurrentResponse],
					((ResponseFlags)responsesFlags[nCurrentResponse]).bIntersect);
			}

			return strMerged;
		}

		/// <summary>
		/// analyze the order of the fields as should be in the
		/// final response string using the request. Which means - 
		/// run on the fields in "Data" of the request and insert
		/// them in order of appearance to hashOrdinals. Each time a field
		/// is inserted save as its value the index of appearance. later this
		/// dictionary may be used to query this index.
		/// </summary>
		/// <param name="strRequest">standard request string</param>
		private void analyzeItemsFieldsOrder(string strRequest) 
		{
			XmlReaderEntityNavigator entityNavigator;
			XmlTextReader xmlReader;
			xmlReader = new XmlTextReader(strRequest);
			entityNavigator = new XmlReaderEntityNavigator(xmlReader,"Data");
			int nEntityOrdinal = 0;
			hashOrdinals.Clear();

			entityNavigator.moveToEntitiesBegin();
			while(!entityNavigator.isEntitiesEnd()) 
			{
				hashOrdinals.Add(entityNavigator.getEntityName(),nEntityOrdinal);
				++nEntityOrdinal;
				entityNavigator.moveToNextEntity();
			}
			
			xmlReader.Close();
		}

		/// <summary>
		/// merge 2 standard responses. loops the items
		/// and add them to a new response. There are 2 distinct merge forms:
		/// <lu>
		///		<li>intersection - only items that exist on both responses will 
		///		be in the merged response</li>
		///		<li>unification - all items from both responses will be in the merged
		///		response</li>
		/// </lu>
		/// </summary>
		/// <param name="strCurrent">first response (usually will be the result
		/// of previous merges)</param>
		/// <param name="strNew">second response (the algorithm defines this response to be the
		/// one with a lower index in the array the the responses merged in <c>strCurrent</c></param>
		/// <param name="bIntersect">determines if this is an intersection merge or a unification
		/// merge</param>
		/// <returns>standard response. merge of the 2 responses</returns>
		private string mergeTwoResponses(string strCurrent,string strNew,bool bIntersect) 
		{
			string strResult;

			if(bIntersect)
				strResult = mergeIntersectionResponses(strCurrent,strNew);
			else
				strResult = mergeUnificationResponses(strCurrent,strNew);
			return strResult;
		}

		/// <summary>
		/// perform an intersection merge and return its result. an intersection merge
		/// creates in the result merged response items that appear only in
		/// both responses. loop the items and for each item that is found
		/// on both responses write its fields from both responses in the
		/// result response
		/// </summary>
		/// <param name="strResponseA">standard response A</param>
		/// <param name="strResponseB">standard response B</param>
		/// <returns>a merged standard response</returns>
		private string mergeIntersectionResponses(string strResponseA,string strResponseB) 
		{
			XmlReaderResponseReader responseReaderA = new XmlReaderResponseReader(strResponseA);
			XPathResponseReader responseReaderB = new XPathResponseReader(strResponseB);
			ResponseWriter responseWriter= new ResponseWriter();
			IResponseEntityIterator responseItemsA = responseReaderA.getItemsIterator();
			IResponseItem responseMatchingItemB;

			String strItemID;

			responseWriter.writeResponseStart(strResponseID,strResponseAction);
			while(!responseItemsA.eof()) 
			{
				strItemID = ((IResponseItem)responseItemsA.current).getID();
				responseMatchingItemB = responseReaderB.getItem(strItemID);
				if(null != responseMatchingItemB)
					writeMatchingItems(responseWriter,strItemID,
						(IResponseItem)(responseItemsA.current),responseMatchingItemB);
				responseItemsA.nextValue();
			}
			responseWriter.writeResponseEnd();
			return responseWriter.ToString();
		}

		/// <summary>
		/// write the fields of an item (and its id) in a response, where the fields
		/// come from 2 sources
		/// </summary>
		/// <param name="responseWriter">response writer holding the written merged response</param>
		/// <param name="strItemID">the item id</param>
		/// <param name="responseItemA">item fields from response A</param>
		/// <param name="responseItemB">item fields from response B</param>
		private void writeMatchingItems(ResponseWriter responseWriter,
			string strItemID,
			IResponseItem responseItemA,
			IResponseItem responseItemB) 
		{
			responseWriter.writeItemStart(strItemID);
			writeItemFields(responseWriter,responseItemA.getSubEntityIterator(),responseItemB.getSubEntityIterator());
			responseWriter.writeItemEnd();

		}

		/// <summary>
		/// write into an item definition the item fields from 2 sources.
		/// The fields in each source are expected to be ordered in a manner that
		/// honors the order of the fields as required by the original request data section.
		/// The merge algorithm creates a new item and merges the 2 sources to a single
		/// item by iterating togather the 2 sources fields. Each field is placed in
		/// the final item. Duplicate fields (that appear on both sources) are handled
		/// using the duplicate policy defined for them. Inflating fields from 2 sources
		/// are ordered using the "order" property of the fields.
		/// </summary>
		/// <param name="responseWriter">response writer holding the written merged response</param>
		/// <param name="responseItemFieldsA">an iterator of the item fields from response A</param>
		/// <param name="responseItemFieldsB">an iterator of the item fields from response B</param>
		private void writeItemFields(ResponseWriter responseWriter,
			IResponseEntityIterator responseItemFieldsA,
			IResponseEntityIterator responseItemFieldsB) 
		{
			IResponseEntityIterator[]	arrIterators = 
				new IResponseEntityIterator[2]{responseItemFieldsA,responseItemFieldsB};
			int[] arrOrdinals = new int[2];
			int[] arrOrder = new int[2];
			int nIndex = 0;
			int i;
			IResponseEntityIterator notExhaustedIterator;
			
			if(!arrIterators[0].eof() && !arrIterators[1].eof()) 
			{
				arrOrdinals[0] = getFieldOrdinal(((IResponseItemField)arrIterators[0].current).getName());
				arrOrdinals[1] = getFieldOrdinal(((IResponseItemField)arrIterators[1].current).getName());
				while(!arrIterators[0].eof() && !arrIterators[1].eof()) 
				{
					if(arrOrdinals[0] == arrOrdinals[1]) 
					{
						arrOrder[0] = ((IResponseItemField)arrIterators[0].current).getOrder();
						arrOrder[1] = ((IResponseItemField)arrIterators[1].current).getOrder();
						if(arrOrder[0] == arrOrder[1]) 
						{
							writeDuplicateFields(responseWriter,
								((IResponseItemField)arrIterators[0].current),
								((IResponseItemField)arrIterators[1].current));
							for(i=0;i<2;++i) 
							{
								if(arrIterators[i].nextValue() == null) 
									nIndex = i;
								else
									arrOrdinals[i] = getFieldOrdinal(((IResponseItemField)arrIterators[i].current).getName());
							}
						} 
						else 
						{
							nIndex = (arrOrder[0] < arrOrder[1] ?  0:1);
							responseWriter.writeField(arrIterators[nIndex].current.getDefinition());
							if(arrIterators[nIndex].nextValue() != null)
								arrOrdinals[nIndex] = getFieldOrdinal(((IResponseItemField)arrIterators[nIndex].current).getName());
						}
					} 
					else 
					{
						nIndex = (arrOrdinals[0] < arrOrdinals[1] ?  0:1);
						responseWriter.writeField(arrIterators[nIndex].current.getDefinition());
						if(arrIterators[nIndex].nextValue() != null)
							arrOrdinals[nIndex] = getFieldOrdinal(((IResponseItemField)arrIterators[nIndex].current).getName());
					}
				}

				notExhaustedIterator = arrIterators[1 - nIndex];
				for(;!notExhaustedIterator.eof();notExhaustedIterator.nextValue())
					responseWriter.writeField(notExhaustedIterator.current.getDefinition());
			}
		}

		/// <summary>
		/// get a field ordinal value. The field ordinal is determined by
		/// the dictionary holding the fields order data as analyzed in <c>analyzeItemFieldsOrder</c>
		/// </summary>
		/// <param name="strFieldName">a field name</param>
		/// <returns>a number, index of the field in the original "Data" tag of the request</returns>
		private int getFieldOrdinal(string strFieldName) 
		{
			int nResult;

			if(hashOrdinals.ContainsKey(strFieldName)) 
				nResult = (int)(hashOrdinals[strFieldName]);
			else 
				nResult = -1;
			return nResult;
		}

		/// <summary>
		/// write duplicate fields as defined by the policy for those fields.
		/// The policy may either be:
		/// <lu>
		///		<li>append - append the 2 fields text to create a new field</li>
		///		<li>priority - the field with the higher priority (that also holds contents
		///			is the result field value</li>
		///		<li>sum - for numeral values this may be used to create a field
		///		that holds the summery of the 2 fields values</li>
		/// </lu>
		/// </summary>
		/// <param name="responseWriter">response writer holding the written merged response</param>
		/// <param name="fieldA">duplicate field from responseA</param>
		/// <param name="fieldB">duplicate field from responseB</param>
		private void writeDuplicateFields(ResponseWriter responseWriter,
			IResponseItemField fieldA,IResponseItemField fieldB) 
		{
			int nPriorityA = fieldA.getPriority();
			int nPriorityB = fieldB.getPriority();
			string strType = fieldB.getTypeAttribute();
			string strFieldName = fieldA.getName();
			string strDefinitionA = fieldA.getDefinition();
			string strDefinitionB = fieldB.getDefinition();
			string strContentA = getTagContent(strDefinitionA);
			string strContentB = getTagContent(strDefinitionB);
			string strPriority;

			if(nPriorityA == nPriorityB) 
			{
				strPriority = (nPriorityA == 0 ? "":" priority=\"" + nPriorityA + "\"");

				responseWriter.writeField(
					"<" + strFieldName + strPriority + ">" + 
					getCombinedContent(strContentA,strContentB,strType) +
					"</" + strFieldName + ">");
			} 
			else 
			{
				if(strContentA == "" && strContentB == "")
					responseWriter.writeField("<" + strFieldName + " priority=\"" + 
						(nPriorityB>nPriorityA ? nPriorityB:nPriorityA) + "\"/>");
				else
					if(strContentB == "")
						responseWriter.writeField(strDefinitionA);
					else 
						if(strContentA == "")
							responseWriter.writeField(strDefinitionB);
						else 
							responseWriter.writeField(
								(nPriorityB>nPriorityA ? strDefinitionB:strDefinitionA));
			}
		}

		/// <summary>
		/// either sum or append the 2 input contents
		/// </summary>
		/// <param name="strContentA">content A</param>
		/// <param name="strContentB">content B</param>
		/// <param name="strType">type attribute determining whether to sum or append</param>
		/// <returns></returns>
		private string getCombinedContent(string strContentA,string strContentB,string strType) 
		{
			int nContentA;
			int nContentB;
			int nSum;
			string strResult;

			if("sum" == strType) 
			{
				nContentA = Int32.Parse(strContentA);
				nContentB = Int32.Parse(strContentB);
				nSum = nContentA + nContentB;

				strResult = "" + nSum;
			} else
				strResult = strContentB + strContentA;

			return strResult;
		}

		/// <summary>
		/// get a tag content from its definition (the text without
		/// the sorronding tags)
		/// </summary>
		/// <param name="strTagDefinition">a tag definition</param>
		/// <returns>the tag content</returns>
		private string getTagContent(string strTagDefinition) 
		{
			int nStart = strTagDefinition.IndexOf(">") + 1;
			int nEnd = strTagDefinition.LastIndexOf("<");

			return strTagDefinition.Substring(nStart,nEnd-nStart);
		}

		/// <summary>
		/// merge using a unification policy. The result response of the 2 merged
		/// response will contain all items from both responses
		/// </summary>
		/// <param name="strResponseA">standard response A</param>
		/// <param name="strResponseB">standard response B</param>
		/// <returns>merged standard response</returns>
		private string mergeUnificationResponses(string strResponseA,string strResponseB) 
		{
			XmlReaderResponseReader responseReaderA = new XmlReaderResponseReader(strResponseA);
			XmlDomResponseReader responseReaderB = new XmlDomResponseReader(strResponseB);
			ResponseWriter responseWriter= new ResponseWriter();
			IResponseEntityIterator responseItemsA = responseReaderA.getItemsIterator();
			IResponseItem responseMatchingItemB;
			IResponseEntityIterator responseItemsB;
			String strItemID;

			responseWriter.writeResponseStart(strResponseID,strResponseAction);
			while(!responseItemsA.eof()) {
				strItemID = ((IResponseItem)responseItemsA.current).getID();
				responseMatchingItemB = responseReaderB.getItem(strItemID);
				if(null == responseMatchingItemB)
					responseWriter.writeFullItem(responseItemsA.current.getDefinition());
				else 
				{
					writeMatchingItems(responseWriter,strItemID,
						((IResponseItem)responseItemsA.current),responseMatchingItemB);
					responseReaderB.removeItem((XmlDomItemsFields)responseMatchingItemB);
				}
				responseItemsA.nextValue();
			}
			responseItemsB = responseReaderB.getItemsIterator();
			for(;!responseItemsB.eof();responseItemsB.nextValue()) 
				responseWriter.writeFullItem(responseItemsB.current.getDefinition());

			responseWriter.writeResponseEnd();
			return responseWriter.ToString();
		}

		/// <summary>
		/// read only property returning the collection of responses
		/// </summary>
		public ArrayList responses 
		{
			get
			{
				return arrResponses;
			}
		}
		
		/// <summary>
		/// add a single standard response to the collection (it is added
		/// as the last member of the collection). Define flags for merge.
		/// </summary>
		/// <param name="strResponse">a standard response</param>
		/// <param name="bNotMerge">no merge flag. if true will ignore this
		/// response when it is merged</param>
		/// <param name="bIntersect">intersect flag. When merging this response
		/// into the accumulated responses use this flag to set the policy of merge (
		/// intersection or unification)</param>
		public void add(string strResponse,bool bNotMerge,bool bIntersect) 
		{
			ResponseFlags responseFlags = new ResponseFlags();

			responseFlags.bIntersect = bIntersect;
			responseFlags.bNotMerge = bNotMerge;

			arrResponses.Add(strResponse);
			responsesFlags.Add(responseFlags);
		}


	}
}
