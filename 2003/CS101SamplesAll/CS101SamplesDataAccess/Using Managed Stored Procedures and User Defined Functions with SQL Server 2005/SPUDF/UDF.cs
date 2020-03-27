using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
	/// <summary>
	/// Here you can define functions that perform manipulations on data and returns a result from SQL Server.
	/// By creating user defined functions here, you can debug within the same IDE and you can deploy to SQL Server
	/// from the IDE without having to execute any command line actions.
	/// </summary>
	/// <param name="longitude1"></param>
	/// <param name="latitude1"></param>
	/// <param name="longitude2"></param>
	/// <param name="latitude2"></param>
	/// <returns></returns>
	[Microsoft.SqlServer.Server.SqlFunction]
	public static double CalculateDistance(double longitude1, double latitude1, double longitude2, double latitude2)
	{
		// calculate the distance
		double x = 69.1 * (latitude2 - latitude1);
		double y = 53.0 * (longitude2 - longitude1);

		
		return (x*x + y*y);
	}
};

