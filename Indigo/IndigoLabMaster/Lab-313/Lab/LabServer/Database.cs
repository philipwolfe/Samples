using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LabServer
{
	public class Database
	{
		private static string _MachineName;
		private static string _DatabaseName;
		private static string _UserName;
		private static string _Password;
		private static string _ConnectString;
		
		static Database()
		{
			_MachineName = System.Configuration.ConfigurationSettings.AppSettings["dbMachineName"];
			_DatabaseName = System.Configuration.ConfigurationSettings.AppSettings["dbName"];
			_UserName = System.Configuration.ConfigurationSettings.AppSettings["dbUserName"];
			_Password = System.Configuration.ConfigurationSettings.AppSettings["dbPassword"];

			_ConnectString =  "Initial Catalog = " + _DatabaseName +
				";Data Source = " +  _MachineName  +
				";User ID = " + _UserName +
				";password= " + _Password + 
				";pooling = false";
		}
		
		internal static SqlConnection ConnectDb()
		{
			try
			{
				SqlConnection Connection = new SqlConnection(_ConnectString);
				Connection.Open();
				return (Connection);
			}
			catch(Exception e)
			{
				throw(e);
			}
		}
	}
}
