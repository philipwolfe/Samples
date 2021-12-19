// Copyright (C) Microsoft Corporation.  All Rights reserved.
// TerraServerConnection.cs
//

namespace TerraServer 
{

    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
	using GeoCoordinate;

	/// <summary>
	/// An internal class used to connect to the TerraServer database using a SqlConnection object.
	/// TerraServer 
	/// The actual connection returned/opened is dependent on the Theme and Scale of the data being accessed. 
	/// Thus the TerraService class uses the TerraServerConnection class instead of a SqlConnection object directly.
	/// </summary>
    public class TerraServerConnection {
		private SqlConnection sqlCon;
		/// <summary>
		/// The parameterless/default constructor.
		/// </summary>
		public TerraServerConnection ()
		{
			sqlCon = new SqlConnection();
		}
		private void InitializeComponent ()
		{
		}
		/// <summary>
		/// Connection property to retrieve the connection string to the TerraServer database
		/// </summary>
		public SqlConnection Connection 
		{
			get 
			{
				return sqlCon;
			}
		}
		private void Open(String primaryconnection, String secondaryconnection) {
	    	sqlCon.ConnectionString = primaryconnection;
		    try {
			    sqlCon.Open();
    		}
	    	catch (Exception) {
			    sqlCon.ConnectionString = secondaryconnection;
    			sqlCon.Open();
	    	}
		}
		/// <summary>
		/// Connect to a TerraServer database by Theme and center Longitude and Latitude point.
		/// </summary>
		/// <param name="theme">Data theme of the data to query.</param>
		/// <param name="point">The longitude and latitude point to query.</param>
		public void Open(Theme theme, LonLatPt point) {
			Open(TerraServerUtility.PrimaryConnection(theme, point), TerraServerUtility.SecondaryConnection(theme, point) );
		}
		/// <summary>
		/// Connect to a TerraServer database by Theme and Longitude only.
		/// </summary>
		/// <param name="theme">Data theme of the data to query.</param>
		/// <param name="lon">The longitude line to query.</param>
		public void Open(Theme theme, Double lon) {
			Open(TerraServerUtility.PrimaryConnection(theme, lon), TerraServerUtility.SecondaryConnection(theme, lon) );
		}
		/// <summary>
		/// Connect to a TerraServer database by Theme and Scene only.
		/// </summary>
		/// <param name="theme">Data theme of the data to query.</param>
		/// <param name="scene">Scene id of the data to query.</param>
    	public void Open(Theme theme, int scene) {
			Open(TerraServerUtility.PrimaryConnection(theme, scene), TerraServerUtility.SecondaryConnection(theme, scene) );
		}
		/// <summary>
		/// Connect to a TerraSErver database by partition identifier.
		/// </summary>
		/// <param name="partition">The integer identifier of the partition to connect to.</param>
    	public void Open(int partition) {
			Open(TerraServerUtility.PrimaryConnection(partition), TerraServerUtility.SecondaryConnection(partition) );
		}
		/// <summary>
		/// Close the database connection
		/// </summary>
		public void Close() 
		{
			sqlCon.Close();
		}
    }
}

