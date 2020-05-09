using System;
using System.Data.OleDb;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	/// <summary>
	/// Summary description for DataAccesProvider.
	/// </summary>
	public class DataAccessProvider
	{
		public string label;
		public string username;
		public string password;
		public string DBName;
		private bool _resolved;

		private string _testConnectionErrorMessage;

		public DataAccessProvider():this("","",""){}

		public DataAccessProvider(string iLabel,string iUsername,string iDBName) 
		{
			username = iUsername;
			DBName = iDBName;
			label = iLabel;
			_resolved = false;
			_testConnectionErrorMessage = "";
		}

		public DataAccessProvider(string iLabel,string iUsername,string iPassword,string iDBName) 
		{
			username = iUsername;
			password = iPassword;
			DBName = iDBName;
			label = iLabel;
			_resolved = true;
			_testConnectionErrorMessage = "";
		}

		public string testConnectionErrorMessage 
		{
			get 
			{
				return _testConnectionErrorMessage;
			}
		}

		public bool resolved 
		{
			get 
			{
				return _resolved;
			}
		}

		public OleDbConnection getOpenConnection() 
		{
			OleDbConnection aConnection = new OleDbConnection(
				"Provider=MSDAORA.1;Password=" +
					password +
				";User ID=" +
					username +
				";Data Source=" +
					DBName +
				";Persist Security Info=True");

			aConnection.Open();
			return aConnection;
		}	

		public bool testConnection()  
		{
			OleDbConnection aConnection;
			bool result;

			try 
			{
				aConnection = getOpenConnection();
				aConnection.Close();
				result = true;
			} 
			catch(Exception e) 
			{
				result = false;
				_testConnectionErrorMessage = e.Message;
			}

			return result;
		}

		public bool sameDBUser(DataAccessProvider matchedProvider) 
		{
			return
				(matchedProvider.DBName == DBName &&
				 matchedProvider.username == username 
				 );
		}

		public void serialize(XmlTextWriter output) 
		{
			output.WriteElementString("Label",label);
			output.WriteElementString("Username",username);
			output.WriteElementString("DBName",DBName);
		}

		public void load(XmlReaderEntityNavigator input) 
		{
			input.moveToEntitiesBegin();
			label = input.getEntityContent();
			username = input.getEntityContent();
			DBName = input.getEntityContent();
		}

		public void setProviderValues(DataAccessProvider provider) 
		{
			label = provider.label;
			username = provider.username;
			password = provider.password;
			DBName = provider.DBName;
			_resolved = provider._resolved;
			
		}

		public override string ToString() 
		{
			return label;
		}
	}
}
