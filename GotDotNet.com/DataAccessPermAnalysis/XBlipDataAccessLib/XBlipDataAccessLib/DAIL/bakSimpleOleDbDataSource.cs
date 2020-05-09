using System;
using System.Data.OleDb;

namespace XBLIP.DAIL.DataSources
{
	/// <summary>
	/// OleDB data source. The data source implements <c>XBLIP.DAIL.IDAILDataSource</c>
	/// to run SQL queries and stored procedure commands. 
	/// <newPara>
	/// Each of the interface methods - <c>modify</c> and <c>retrieve</c> -
	/// accepts a track content that may either be an SQL query, or an XML specification
	/// that defines a stored procedure/function or a bind variables query call.
	/// </newPara>
	/// <newPara>
	/// The return value in the case of a data set query (either a bind
	/// variables query a stored function call or a retrieve call with regular SQL)
	/// is a Standard response, with the id and action attributes as defined by the context.
	/// In the case of such a return value, the command or SQL are exepcted to return a
	/// data set when in each row the fields (either by concatanation, or by having a single
	/// field) form a single "Item" tag definition. This way, the data source driver can
	/// build a standard response easily.
	/// </newPara>
	/// <newPara>
	/// In the case where a stored function is called, the track definition must surround
	/// the XML definition of the stored procedure with an XML definition of a standard
	/// response.
	/// </newPara>
	/// <newPara>
	/// An example of usage (notice that the track selects for each row a string definition
	/// of an item combined of data and constant strings):
	///<pre>
	///	IDAILDataSource myDataSource = new SimpleOleDbDataSource("/*database connection string*/");
	///	string strTrackContent =
	///		"select 
	///			'&lt;Item id=''' || p.id || ''' &gt;' || 
	///				'&lt;Name&gt;' || p.name || '&lt;/Name&gt;' ||
	///				'&lt;Address&gt;' || p.address || '&lt;/Address&gt;' ||				
	///			'&lt;/Item&gt;'
	///		from employees
	///		where department = 'A'"
	///	string strStandardResponse = myDataSource.retrieve(strTrackContent);
	///	
	///	/* load the result reponse to an XmlReader and loop it to display the values */
	///	</pre>
	/// </newPara>
	/// </summary>
	public class SimpleOleDbDataSource : XBLIP.DAIL.IDAILDataSource
	{
		/// <summary>
		/// constant value that signals a bind variable or stored function
		/// spec definition end
		/// </summary>
		private const string DB_FUNC_START = "DB_FUNC_START";
		/// <summary>
		/// constant value that signals a bind variable or stored function
		/// spec definition start
		/// </summary>
		private const string DB_FUNC_END = "DB_FUNC_END";

		/// <summary>
		/// connection string used for this data source connections
		/// </summary>
		private string _strConnectionString;

		/// <summary>
		/// constructor accepting a connection string for the database
		/// data source
		/// </summary>
		/// <param name="strConnectionString">connection string</param>
		public SimpleOleDbDataSource(string strConnectionString)
		{
			_strConnectionString = strConnectionString;
		}

		/// <summary>
		///		execute the track content for a retrieve query
		/// </summary>
		/// <param name="strTrackContent">track content to execute (sql query or
		/// xml spec of a bind variable query/stored procedure call
		/// </param>
		/// <param name="strTrackContent">track content string</param>
		/// <param name="strPipe">pipe string (never used)</param>
		/// <param name="strID">id attribute value used when this is a data set retrieve</param>
		/// <param name="strAction">action attribute value used when this is a data set retrieve</param>
		/// <returns></returns>
		public string retrieve(string strTrackContent, string strPipe,string strID,string strAction) 
		{
			return executeTrackContent(strTrackContent,true,strID,strAction);
		}

		/// <summary>
		/// execute a track content. use <c>OleDbSpeccedCommand</c> to execute
		/// a query.
		/// <newPara>
		/// If it's a specification of a stored procedure/bind
		/// variables query initialize the command with the spec, and concatanate to
		/// the result the sorrounding strings to form a standard response.
		/// </newPara>
		/// <newPara>
		/// If it's a regular SQL, then it must be a "select" clause. run it
		/// and return the standard response built with the returned data set
		/// </newPara>
		/// </summary>
		/// <param name="strTrackContent">track content (specs or SQL)</param>
		/// <param name="bMayReturnDataSet">a flag saying that if this track is not specs, SQL returns a data set</param>
		/// <param name="strID">for a data set retrieve use this value as the response id attribute</param>
		/// <param name="strAction">for a data set retrieve use this value as the response action attribute</param>
		/// <returns>standard response string</returns>
		private string executeTrackContent(string strTrackContent,bool bMayReturnDataSet,string strID,string strAction) 
		{
			OleDbConnection aConnection =	getOpenConnection();
			OleDbSpeccedCommand cmdSpecced = new OleDbSpeccedCommand(aConnection);
			int nSpecStart;
			int nSpecEnd;
			string strResponse;

			if(isCommandTrack(strTrackContent)) 
			{
				nSpecStart = strTrackContent.IndexOf(DB_FUNC_START) + DB_FUNC_START.Length;
				nSpecEnd = strTrackContent.LastIndexOf(DB_FUNC_END);
				if(bMayReturnDataSet)
					cmdSpecced.initCommandFromSpec(strTrackContent.Substring(nSpecStart,nSpecEnd-nSpecStart),strID,strAction);
				else
					cmdSpecced.initCommandFromSpec(strTrackContent.Substring(nSpecStart,nSpecEnd-nSpecStart));
				strResponse = 
					strTrackContent.Substring(0,nSpecStart) +
					cmdSpecced.executeCommand() +
					strTrackContent.Substring(nSpecEnd + DB_FUNC_END.Length);
			} 
			else 
			{
				if(bMayReturnDataSet)
					cmdSpecced.initCommandFromSQL(strTrackContent,strID,strAction);
				else
					cmdSpecced.initCommandFromSQL(strTrackContent);
				strResponse = cmdSpecced.executeCommand();
			}

			aConnection.Close();
			return strResponse;

		}

		/// <summary>
		///	checks if this is a specced track (bind variables query/
		///	stored procedure call
		/// </summary>
		/// <param name="strTrackContent">track content string</param>
		/// <returns>true for a specced track, false for regular SQL</returns>
		private bool isCommandTrack(string strTrackContent) 
		{
			return (strTrackContent.IndexOf(DB_FUNC_START) != -1);
		}

		/// <summary>
		///	get an open connection as defined by the connection string given
		///	when this object was instanciated
		/// </summary>
		/// <returns></returns>
		private OleDbConnection getOpenConnection() 
		{
			OleDbConnection aConnection = new OleDbConnection(_strConnectionString);
			aConnection.Open();
			return aConnection;
		}

		/// <summary>
		/// perform a modify action. calls <c>executeTrackContent</c> denying
		/// regular SQL from retrieving. regular SQL will result in a string
		/// handing the number of modified records.
		/// </summary>
		/// <param name="strTrackContent">track content string</param>
		/// <returns></returns>
		public string modify(string strTrackContent)
		{
			return executeTrackContent(strTrackContent,false,"","");
		}

	}
}
