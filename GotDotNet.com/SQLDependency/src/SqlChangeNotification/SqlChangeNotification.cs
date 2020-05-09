using System;
using System.Data;
using System.Data.SqlClient;

namespace System.Web.Caching {

	public class SqlChangeNotification {

		private string callbackHandler = "NotificationHandler.axd";
		private string dsn;
		private SqlConnection connection;
		private SqlCommand command;

		// CallbackHandler property
		public string CallbackHttpHandler {
			get { 
				return callbackHandler; 
			}
			set { 
				callbackHandler = value; 
			}
		}

		public string DataSourceName {
			get {
				return dsn;
			}
			set {
				dsn = value;
			}
		}

		public bool OnChangeInvalidateCache(string callBackPath, string cacheKey, string sqlTable) {
			// Eventually throw an exception
			
			// Establish connection to the DB
			connection = new SqlConnection(dsn);

			callBackPath = callBackPath + callbackHandler;

			try {
				CreateTrigger(sqlTable);
				RegisterNotification(callBackPath, sqlTable, cacheKey);
			}
			catch (Exception e) {
				//				throw e;
				//				e = null;
				return false;
			}

			return true;
		}

		// We'll bulid a sql table to allow multiple notifications for one trigger
		// Thus in a server farm environment multiple servers can listen for the same event
		private void RegisterNotification(string AppPath, string Table, string CacheKey) {
			SqlParameter workParam;

			command = new SqlCommand("sp_register_notify", connection);
			command.CommandType = CommandType.StoredProcedure;

			workParam = command.Parameters.Add(new SqlParameter("@trigger_table",  SqlDbType.VarChar, 100));
			workParam.Direction = ParameterDirection.Input;
			workParam.Value = Table;

			workParam = command.Parameters.Add(new SqlParameter("@callback_url", SqlDbType.VarChar, 100));
			workParam.Direction = ParameterDirection.Input;
			workParam.Value = AppPath;

			workParam = command.Parameters.Add(new SqlParameter("@cachekey", SqlDbType.VarChar, 100));
			workParam.Direction = ParameterDirection.Input;
			workParam.Value = CacheKey;

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}

		// At some point we should create an enum to support different trigger types
		private void CreateTrigger(string Table) {
			String Trigger = "create trigger T_" + Table + " on " + Table + " after insert, delete, update as begin exec master..sp_posts '" + Table + "' end";

			command = new SqlCommand(Trigger, connection);

			// Catch exceptions raised when we execute
			try {
				connection.Open();
				command.ExecuteNonQuery();
			}
			catch (SqlException e) {
				// Error number 2714 means the object (trigger) already exists
				// We'll ignore this error since a server farm would want to 
				// have multiple triggers on the same table for various cache instances
				connection.Close();

				if (2714 != e.Number)
					throw e;
			}

			connection.Close();
		}
	}
}