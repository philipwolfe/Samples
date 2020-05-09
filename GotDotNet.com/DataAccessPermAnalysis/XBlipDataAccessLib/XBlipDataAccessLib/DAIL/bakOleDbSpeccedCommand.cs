using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Xml;
using XBLIP.XmlUtil;
using XBLIP.StandardResponse;


namespace XBLIP.DAIL.DataSources
{
	/// <summary>
	/// A OleDB command wrapper that returns the command result as string
	/// according to the specs of the command.
	/// An OleDbSpeccedCommand may execute a regular SQL, bind variables query or
	/// a stored procedure/function.
	/// <newPara>
	/// To use the class, instance it with an open connection (created and later openned).
	/// Later use either <c>initCommandFromSpec</c> with XML specifications for bind variables
	/// or a stored procedure/function execution or use <c>initCommandFromSQL</c>
	/// with an SQL string to initialize the command variables.
	/// Last thing to do is to execute the command using <c>executeCommand</c>
	/// to get its result string.
	/// The result string format depends on the query:
	/// <lu>
	///		<li>data set retrieve query - a standard response</li>
	///		<li>stored function - its return value in string representation</li>
	///		<li>stored procedure or non-query actions - number of modified rows</li>
	/// </lu>
	/// <newPara>
	/// It is important to note that in the first case, the SQL must return in each row
	/// one or more cells whose string concatanation gives a single "Item" XML definition which
	/// represents the row.
	/// </newPara>
	/// </newPara>
	/// </summary>
	internal class OleDbSpeccedCommand
	{
		/// <summary>
		/// connection used by the command
		/// </summary>
		private OleDbConnection aConnection;
		/// <summary>
		/// wrapped command object
		/// </summary>
		private OleDbCommand aCommand;
		/// <summary>
		/// determines whether this is a command that returns a data set or not
		/// </summary>
		private bool bReturnDataSet;
		/// <summary>
		/// determines whether this command has a return value parameter
		/// </summary>
		private bool bSpeccedReturnValue;
		/// <summary>
		/// if <c>bSpeccedReturnValue</c> is true will point to the
		/// return parameter index in the parameter array
		/// </summary>
		private int nReturnParmIndex;
		/// <summary>
		/// for a data set retrieve will hold the value for id attribute in response
		/// tag
		/// </summary>
		private string strResponseID;
		/// <summary>
		/// for a data set retrieve will hold the value for action attribute in response
		/// tag
		/// </summary>
		private string strResponseAction;

		/// <summary>
		///	Constructor
		/// </summary>
		/// <param name="conCommand">
		/// open connection to be used by the command
		/// </param>
		public OleDbSpeccedCommand(OleDbConnection conCommand)
		{
			aConnection = conCommand;
			strResponseID = "";
			strResponseAction = "";
		}

		/// <summary>
		/// call <c>initCommandFromSpec</c> with invalid id and action. use this
		/// method when a data set retrieve is never expected (for example, when
		/// calling from a modification query)
		/// </summary>
		/// <param name="strCommandSpec">command specification string</param>
		public void initCommandFromSpec(string strCommandSpec) 
		{
			initCommandFromSpec(strCommandSpec,"","");			
		}

		/// <summary>
 		///	set the command values according to a spec (as defined by in the
		///	data source driver spec). This method is used when executing a bind
		///	variable query or a stored procedure. strID and strAction are used when
		///	this method returns a data set, for creating a standard response
		/// </summary>
		/// <param name="strCommandSpec">command specification string</param>
		/// <param name="strID">id to use when this is a data set retrieval method</param>
		/// <param name="strAction">action to use when this is a data set retrieveal method</param>
		public void initCommandFromSpec(string strCommandSpec,string strID,string strAction) 
		{
			StringReader stringReader = new StringReader(strCommandSpec);
			XmlTextReader xmlReader = new XmlTextReader(stringReader);
			strResponseID = strID;
			strResponseAction = strAction;

			bSpeccedReturnValue = false;
			aCommand = new OleDbCommand();
			aCommand.Connection = aConnection;
			moveToTopElement(xmlReader);
			if(xmlReader.GetAttribute("type") == "procedure")
				aCommand.CommandType = CommandType.StoredProcedure;

			setCommandContent(xmlReader);
		}

		/// <summary>
		///	on a fresh xmlReader, move to the document element
		/// </summary>
		/// <param name="xmlReader">
		/// reader to work on
		/// </param>
		private void moveToTopElement(XmlReader xmlReader) 
		{
			bool bElementNotFound = true;

			while(bElementNotFound && xmlReader.Read()) 
				if(xmlReader.NodeType == XmlNodeType.Element)
					bElementNotFound = false;
		}

		/// <summary>
		///	setup the command text and parameters (input and return (if
		///	exists)) according to the specification in xmlReader
		/// </summary>
		/// <param name="xmlReader">
		/// specifications XML reader
		/// </param>
		private void setCommandContent(XmlReader xmlReader) 
		{
			XmlReaderEntityNavigator readerCommandContent = new XmlReaderEntityNavigator(xmlReader,"Function");

			readerCommandContent.moveToEntitiesBegin();

			do
			{
				switch(readerCommandContent.getEntityName()) 
				{
					case "Param":
						addInputParam(readerCommandContent);
						break;
					case "Return":
						addReturnParam(readerCommandContent);
						break;
					case "Text":
						setCommandText(readerCommandContent);
						break;
				}
			} while(!readerCommandContent.isEntitiesEnd());

		}

		/// <summary>
		///	add a single input param, according to the specifications.
		///	an input param in the xml defines a "type" attribute
		///	which value may be one of the allowed type. see <see cref="getParamType"/>
		///	for the available values. a "name" attribute must also be defined with the
		///	name of the param
		/// </summary>
		/// <param name="readerNavigator">
		/// navigator pointing on the param specifications
		/// </param>
		private void addInputParam(XmlReaderEntityNavigator readerNavigator) 
		{	
			string strParamName = readerNavigator.getEntityAttribute("name");
			OleDbType paramType = getParamType(readerNavigator.getEntityAttribute("type"));
			string strParamValue = readerNavigator.getEntityContent();
			int nSize = (strParamValue.Length > 0 ? strParamValue.Length:1);
			OleDbParameter aParam = aCommand.Parameters.Add(strParamName,nSize);
			
			aParam.Value = strParamValue;
		}

		/// <summary>
		/// add a single return value param. This should be defined only for stored function
		/// calls. a return param must define in it a "name" and "type" attribute, like
		/// an input param (see <see cref="addInputParam"/>. For a varChar type another
		/// attribute named "size" must be defined with the size of the expected string
		/// to be returned (maximum value. does not have to be exact!)
		/// </summary>
		/// <param name="readerNavigator">
		/// navigator pointing on the param specifications
		/// </param>
		private void addReturnParam(XmlReaderEntityNavigator readerNavigator) 
		{	
			string strParamName = readerNavigator.getEntityAttribute("name");
			OleDbType paramType = getParamType(readerNavigator.getEntityAttribute("type"));
			OleDbParameter aParam;

			nReturnParmIndex = aCommand.Parameters.Count;
			bSpeccedReturnValue = true;

			if(OleDbType.VarChar == paramType)
				aParam = aCommand.Parameters.Add(strParamName,paramType,Int32.Parse(readerNavigator.getEntityAttribute("size")));
			else
				aParam = aCommand.Parameters.Add(strParamName,paramType);

			aParam.Direction = ParameterDirection.ReturnValue;
		}

		/// <summary>
		/// get a <c>OleDbType</c> matching the input label.
		/// The allowed values are : varChar, integer or double.
		/// </summary>
		/// <param name="strParamType">parameter type label</param>
		/// <returns>a matching OleDbType</returns>
		private OleDbType getParamType(string strParamType) 
		{
			OleDbType paramType;

			switch(strParamType) 
			{
				case "varChar":
					paramType = OleDbType.VarChar;
					break;
				case "integer":
					paramType = OleDbType.Integer;
					break;
				case "double":
					paramType = OleDbType.Double;
					break;
				default:
					paramType = OleDbType.Empty;
					break;
			}

			return paramType;
		}

		/// <summary>
		/// set the command text to the current pointed element content
		/// </summary>
		/// <param name="readerNavigator">
		/// a navigator pointing to a "Text" node
		/// </param>
		private void setCommandText(XmlReaderEntityNavigator readerNavigator) 
		{
			aCommand.CommandText = readerNavigator.getEntityContent();
		}

		/// <summary>
		/// set the command values according to an SQL query. Use this command
		/// when the SQL retrieves a data set (a select statement). the strID and
		/// strAction parameters will be the id and the action on the standard response
		/// that will be recieved when this command is executed
		/// </summary>
		/// <param name="strSQL">SQL string to execute</param>
		/// <param name="strID">standard response id</param>
		/// <param name="strAction">standard response action</param>
		public void initCommandFromSQL(string strSQL,string strID,string strAction) 
		{
			bSpeccedReturnValue = false;
			bReturnDataSet = true;
			strResponseID = strID;
			strResponseAction = strAction;
			aCommand = new OleDbCommand(strSQL,aConnection);
		}
		
		/// <summary>
		/// set the command values according to an SQL query. Use this command
		/// for non-data set retriaval SQLs or when you don't care about the
		/// id and action for a retrieval query.
		/// </summary>
		/// <param name="strSQL">SQL string to execute</param>
		public void initCommandFromSQL(string strSQL) 
		{
			bSpeccedReturnValue = false;
			bReturnDataSet = false;
			aCommand = new OleDbCommand(strSQL,aConnection);
		}

		/// <summary>
		///	execute the command (has to be called after calling one of the
		///	initialization methods) and return its result string. The result is
		///	either a simple value or a standard response (for a data set retrieval
		///	query).
		/// </summary>
		/// <returns>command result</returns>
		public string executeCommand() 
		{
			string strResponse;

			if(bReturnDataSet) 
				strResponse = getDataSetResponse();
			else
				strResponse = getNonQueryResponse();

			return strResponse;
		}

		/// <summary>
		/// execute the command using ExecuteReader and return a standard response based
		/// upon the returning data set
		/// </summary>
		/// <returns>a standard response representation of the data set</returns>
		private string getDataSetResponse() 
		{
			OleDbDataReader aReader = aCommand.ExecuteReader();
			return flushReaderToStandardResponse(aReader,strResponseID,strResponseAction);
		}

		/// <summary>
		/// serialize a reader values to a standard response
		/// </summary>
		/// <param name="aReader">reader to serialize</param>
		/// <param name="strID">id attribute value for the Response tag</param>
		/// <param name="strAction">action attribute value for the response tag</param>
		/// <returns>standard response</returns>
		private string flushReaderToStandardResponse(OleDbDataReader aReader,string strID,string strAction) 
		{
			ResponseWriter responseWriter = new ResponseWriter();
			string strItemDescription;

			responseWriter.writeResponseStart(strID,strAction);
			while (aReader.Read()) 
			{
				if(1 == aReader.FieldCount)
					strItemDescription = aReader.GetString(0);
				else 
					strItemDescription = getItemDescriptionFromCompositeRow(aReader);
				responseWriter.writeFullItem(strItemDescription);
			}
			responseWriter.writeResponseEnd();
			return responseWriter.ToString();
		}

		/// <summary>
		/// in the case of more then one field in a row, use this command to concatenate
		/// the fields values to a single string which represents
		/// the item definition
		/// </summary>
		/// <param name="aReader">reader pointing to a row</param>
		/// <returns>item definition</returns>
		private string getItemDescriptionFromCompositeRow(OleDbDataReader aReader) 
		{
			int i;
			StringBuilder itemDescriptionBuilder = new StringBuilder();

			for(i=0;i<aReader.FieldCount;++i) 
				itemDescriptionBuilder.Append(aReader.GetString(i));

			return itemDescriptionBuilder.ToString();
		}

		/// <summary>
		/// execute a non-data set retrieval query. the return value
		/// is either the modified rows as given form ExecuteNonQuery
		/// or if a return param is defined on the command, its value will
		/// be returned
		/// </summary>
		/// <returns>a string value</returns>
		private string getNonQueryResponse() 
		{
			int nResult = aCommand.ExecuteNonQuery();
			string strResult;
			
			if(bSpeccedReturnValue)
				strResult = aCommand.Parameters[nReturnParmIndex].Value.ToString();
			else
				strResult = nResult.ToString();

			return strResult;
		}

		/// <summary>
		/// reset the command values. after issuing this command one may
		/// reuse this method: call an initizalization method
		/// and later execute
		/// </summary>
		public void resetCommand() 
		{
			aCommand.Parameters.Clear();
			aCommand.CommandType = CommandType.Text;
		}
	}
}
