using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


///Defining stored procedures in this manner is advantageous because you can debug your code here
/// as well as perform actions here that were previously unavailable.
/// You also see that by using the SqlPipe, you can leverage the ExecuteAndSend method for Non-data returning and
/// data returning queries alike.
public partial class StoredProcedures
{
	/// <summary>
	/// This stored procedure inserts the data passed in as parameters into the user table.
	/// You create a SqlPipe to execute and send all queries that are executed in the stored procedure.
	/// </summary>
	/// <param name="longitude1"></param>
	/// <param name="latitude1"></param>
	/// <param name="longitude2"></param>
	/// <param name="latitude2"></param>
	/// <param name="distance"></param>
	[Microsoft.SqlServer.Server.SqlProcedure]
	public static void spInsertData(double longitude1, double latitude1, double longitude2, double latitude2, double distance)
	{
		string myQuery = "";
		
		myQuery = "INSERT INTO GeoCache (longitude1,latitude1,longitude2,latitude2,distance) VALUES(" + longitude1 + "," + latitude1 + "," + longitude2 + "," + latitude2 + "," + distance + ")";

		SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = myQuery;
        SqlPipe myPipe = SqlContext.Pipe;
        
        myPipe.ExecuteAndSend(myCommand);

	}

	/// <summary>
	/// This stored procedure simply returns all the values that are stored
	/// in the user table.  
	/// </summary>
	[Microsoft.SqlServer.Server.SqlProcedure]
	public static void spGetData()
	{
		string myQuery = "SELECT * FROM GeoCache";

		SqlCommand myCommand = new SqlCommand();
		myCommand.CommandText = myQuery;
		SqlPipe myPipe = SqlContext.Pipe;

		myPipe.ExecuteAndSend(myCommand);

	}
};
