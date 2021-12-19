// Copyright (C) Microsoft Corporation.  All Rights reserved.
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using GeoCoordinate;

namespace CensusServer
{
	/// <summary>
	/// CensusService returns Census information by year and political unit.
	/// </summary>
[WebService(Namespace="http://terraservice.net/censusserver/")]
	public class CensusService : System.Web.Services.WebService
	{
		private String connectionString;
		private String Connection
		{
			get 
			{
				return connectionString;
			}
			set
			{ 
				connectionString = value;
			}
		}
	/// <summary>
	/// Constructor
	/// </summary>
		public CensusService()
		{
			Connection = ConfigurationSettings.AppSettings["CensusDatabase"];
			if(connectionString == null)
				Connection = "Server=localhost;database=pubs;uid=guest;pwd=;";
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
		}
	/// <summary>
	/// GetPoliticalUnitFactsByName returns a single CensusFacts structure for the given named item.
	/// </summary>
	/// <param name="pu">An enum identifying the type of political unit, e.g. City, County, State, or CensusTract, to return</param>
	/// <param name="name">The formal name of the political unit, e.g. Washington, San Francisco, King, etc.</param>
	/// <param name="ParentName">The parent political unit.  Specify "USA" if the name is a State.  Specify the State name if the item is a County, CIty, or CensusTract.</param>
	/// <param name="year">Year of the census, e.g. 1990</param>
	/// <returns>A CensusFacts struct containing Census statistics.</returns>
		[WebMethod]
		public CensusFacts GetPoliticalUnitFactsByName( PoliticalUnit pu, String name, String ParentName, Int32 year) 
		{
			CensusFacts cf = new CensusFacts();

			SqlDataReader reader = null;
			// Create a new Connection and DataSetCommand
			SqlConnection cnCon = new SqlConnection(Connection);

			String szQuery = "exec spCNCensusFactsByNameAndParent " + (Int32)pu + ",'" + name + "','" + ParentName + "'," + year ;
			SqlCommand sqlCmd = new SqlCommand(szQuery, cnCon);

			try
			{
				cnCon.Open();					// Open any Database partition
				reader = sqlCmd.ExecuteReader();

				while (reader.Read())
				{
					cf.Pu					= (PoliticalUnit) reader.GetInt32(0);
					cf.Fips					= reader.GetString(1);
					cf.StateFips			= reader.GetString(2);
					cf.CountyFips			= reader.GetString(3);
					cf.Name					= reader.GetString(4);
					cf.SecondaryName		= reader.GetString(5);
					cf.Area					= reader.GetDouble(6);
					cf.Year					= reader.GetInt32(9);
					cf.Population1990		= reader.GetInt32(10);
					cf.Population1999		= reader.GetInt32(11);
					cf.Population1990_PerSquareMile = reader.GetInt32(12);
					cf.Households			= reader.GetInt32(13);
					cf.Males				= reader.GetInt32(14);
					cf.Females				= reader.GetInt32(15);
					cf.White				= reader.GetInt32(16);
					cf.Black				= reader.GetInt32(17);
					cf.NativeAmericans		= reader.GetInt32(18);
					cf.AsianPolynesianIslands = reader.GetInt32(19);
					cf.Hispanic				= reader.GetInt32(20);
					cf.Other				= reader.GetInt32(21);
					cf.Age_Under5			= reader.GetInt32(22);
					cf.Age_5_17				= reader.GetInt32(23);
					cf.Age_18_29			= reader.GetInt32(24);
					cf.Age_30_49			= reader.GetInt32(25);
					cf.Age_50_64			= reader.GetInt32(26);
					cf.Age_65_Up			= reader.GetInt32(27);
					cf.NeverMarry			= reader.GetInt32(28);
					cf.Married				= reader.GetInt32(29);
					cf.Separated			= reader.GetInt32(30);
					cf.Widowed				= reader.GetInt32(31);
					cf.Divorced				= reader.GetInt32(32);
					cf.HouseHolds_1Male		= reader.GetInt32(33);
					cf.HouseHolds_1Female	= reader.GetInt32(34);
					cf.Married_Households_Child = reader.GetInt32(35);
					cf.Married_households_NoChild = reader.GetInt32(36);
					cf.Male_Households_Child = reader.GetInt32(37);
					cf.Female_HouseHolds_Child = reader.GetInt32(38);
					cf.Household_Units		= reader.GetInt32(39);
					cf.Vacant				= reader.GetInt32(40);
					cf.OwnerOccupied		= reader.GetInt32(41);
					cf.RenterOccupied		= reader.GetInt32(42);
					cf.MedianValue			= reader.GetInt32(43);
					cf.MedianRent			= reader.GetInt32(44);
					cf.Units_1Detach		= reader.GetInt32(45);
					cf.Units_1Attach		= reader.GetInt32(46);
					cf.Units_2				= reader.GetInt32(47);
					cf.Units_3_9			= reader.GetInt32(48);
					cf.Units_10_49			= reader.GetInt32(49);
					cf.Units_50_Up			= reader.GetInt32(50);
					cf.MobileHome			= reader.GetInt32(51);
					cf.No_Farms87			= reader.GetInt32(52);
					cf.Avg_Farm_Size87		= reader.GetInt32(53);
					cf.Crop_Acre87			= reader.GetInt32(54);
					cf.Avg_Sale87			= reader.GetInt32(55);
					cf.Shape				= (ShapeType) reader.GetInt32(60);
					cf.Rect.UpperLeft.Lon	= reader.GetDouble(56);
					cf.Rect.LowerRight.Lat	= reader.GetDouble(57);
					cf.Rect.LowerRight.Lon	= reader.GetDouble(58);
					cf.Rect.UpperLeft.Lat	= reader.GetDouble(59);
					break;
				}
			}
			finally
			{
				if(reader!=null) 
				{
					reader.Close();
					cnCon.Close();
				}
			}

			return(cf);
		}
	/// <summary>
	/// GetPoliticalUnitFactsByRect returns an array of CensusFacts structures for all the political units of the specified type 
	/// that overlap the specified bounding rectangle.
	/// </summary>
	/// <param name="pu">An enum identifying the type of political unit, e.g. City, County, State, or CensusTract, to return</param>
	/// <param name="rect">The geographic area to search for overlapping political units.</param>
	/// <param name="year">Year of the census, e.g. 1990</param>
	/// <returns>A CensusFacts struct containing Census statistics.</returns>
	[WebMethod]
		public CensusFacts[] GetPoliticalUnitFactsByRect( PoliticalUnit pu, BoundingRect rect, Int32 year) 
		{
			Int32	iMaxItems = 1, i;
			switch(pu) 
			{
				case PoliticalUnit.State:
					iMaxItems = 52;
					break;
				case PoliticalUnit.County:
					iMaxItems = 3200;
					break;
				case PoliticalUnit.City:
					iMaxItems = 3200;
					break;
				case PoliticalUnit.CensusTract:
					iMaxItems = 5000;
					break;
				case PoliticalUnit.Unknown:
					iMaxItems = 5000;
					break;
			}
			CensusFacts[] cf = new CensusFacts[iMaxItems];

			SqlDataReader reader = null;
			// Create a new Connection and DataSetCommand
			SqlConnection cnCon = new SqlConnection(Connection);

			String szQuery = "exec spCNCensusFactsByBoundingArea " + (Int32)pu + "," + rect.UpperLeft.Lon + "," + rect.LowerRight.Lat + "," + rect.LowerRight.Lon + "," + rect.UpperLeft.Lat + "," + year;
			SqlCommand sqlCmd = new SqlCommand(szQuery, cnCon);

			try
			{
				cnCon.Open();					// Open any Database partition
				reader = sqlCmd.ExecuteReader();

				i = 0;
				while (reader.Read())
				{
					cf[i].Pu				= (PoliticalUnit) reader.GetInt32(0);
					cf[i].Fips				= reader.GetString(1);
					cf[i].StateFips			= reader.GetString(2);
					cf[i].CountyFips		= reader.GetString(3);
					cf[i].Name				= reader.GetString(4);
					cf[i].SecondaryName		= reader.GetString(5);
					cf[i].Area				= reader.GetDouble(6);
					cf[i].Year				= reader.GetInt32(9);
					cf[i].Population1990	= reader.GetInt32(10);
					cf[i].Population1999	= reader.GetInt32(11);
					cf[i].Population1990_PerSquareMile = reader.GetInt32(12);
					cf[i].Households		= reader.GetInt32(13);
					cf[i].Males				= reader.GetInt32(14);
					cf[i].Females			= reader.GetInt32(15);
					cf[i].White				= reader.GetInt32(16);
					cf[i].Black				= reader.GetInt32(17);
					cf[i].NativeAmericans	= reader.GetInt32(18);
					cf[i].AsianPolynesianIslands = reader.GetInt32(19);
					cf[i].Hispanic			= reader.GetInt32(20);
					cf[i].Other				= reader.GetInt32(21);
					cf[i].Age_Under5		= reader.GetInt32(22);
					cf[i].Age_5_17			= reader.GetInt32(23);
					cf[i].Age_18_29			= reader.GetInt32(24);
					cf[i].Age_30_49			= reader.GetInt32(25);
					cf[i].Age_50_64			= reader.GetInt32(26);
					cf[i].Age_65_Up			= reader.GetInt32(27);
					cf[i].NeverMarry		= reader.GetInt32(28);
					cf[i].Married			= reader.GetInt32(29);
					cf[i].Separated			= reader.GetInt32(30);
					cf[i].Widowed			= reader.GetInt32(31);
					cf[i].Divorced			= reader.GetInt32(32);
					cf[i].HouseHolds_1Male	= reader.GetInt32(33);
					cf[i].HouseHolds_1Female = reader.GetInt32(34);
					cf[i].Married_Households_Child = reader.GetInt32(35);
					cf[i].Married_households_NoChild = reader.GetInt32(36);
					cf[i].Male_Households_Child = reader.GetInt32(37);
					cf[i].Female_HouseHolds_Child = reader.GetInt32(38);
					cf[i].Household_Units	= reader.GetInt32(39);
					cf[i].Vacant			= reader.GetInt32(40);
					cf[i].OwnerOccupied		= reader.GetInt32(41);
					cf[i].RenterOccupied	= reader.GetInt32(42);
					cf[i].MedianValue		= reader.GetInt32(43);
					cf[i].MedianRent		= reader.GetInt32(44);
					cf[i].Units_1Detach		= reader.GetInt32(45);
					cf[i].Units_1Attach		= reader.GetInt32(46);
					cf[i].Units_2			= reader.GetInt32(47);
					cf[i].Units_3_9			= reader.GetInt32(48);
					cf[i].Units_10_49		= reader.GetInt32(49);
					cf[i].Units_50_Up		= reader.GetInt32(50);
					cf[i].MobileHome		= reader.GetInt32(51);
					cf[i].No_Farms87		= reader.GetInt32(52);
					cf[i].Avg_Farm_Size87	= reader.GetInt32(53);
					cf[i].Crop_Acre87		= reader.GetInt32(54);
					cf[i].Avg_Sale87		= reader.GetInt32(55);
					cf[i].Shape				= (ShapeType) reader.GetInt32(60);
					cf[i].Rect.UpperLeft.Lon	= reader.GetDouble(56);
					cf[i].Rect.LowerRight.Lat	= reader.GetDouble(57);
					cf[i].Rect.LowerRight.Lon	= reader.GetDouble(58);
					cf[i].Rect.UpperLeft.Lat	= reader.GetDouble(59);
					i++;
					if(i == iMaxItems)
						break;
				}
			}
			finally
			{
				reader.Close();
				cnCon.Close();
			}
			CensusFacts[] outcf = new CensusFacts[i];
			Array.Copy(cf, outcf, i);

			return(outcf);
		}
		/// <summary>
		/// CountofPolicitalUnitByRect returns the count of political units that overlap the specified bounding rectangle.
		/// </summary>
		/// <param name="pu">An enum identifying the type of political unit, e.g. City, County, State, or CensusTract, to return</param>
		/// <param name="rect">The geographic area to search for overlapping political units.</param>
		/// <param name="year">Year of the census, e.g. 1990</param>
	[WebMethod]
		public Int32 CountOfPoliticalUnitByRect( PoliticalUnit pu, BoundingRect rect, Int32 year) 
		{
			Int32 iCount = -1;
			String szQuery = "";
			SqlDataReader reader = null;
			// Create a new Connection and DataSetCOmmand
			SqlConnection cnCon = new SqlConnection(Connection);

			szQuery = "exec spCNCountOfPoliticalUnitByRect " + pu+ "," + rect.UpperLeft.Lon + "," + rect.LowerRight.Lat + "," + rect.LowerRight.Lon + "," + rect.UpperLeft.Lat + "," + year;
			SqlCommand sqlCmd = new SqlCommand(szQuery, cnCon);

			try
			{
				cnCon.Open();					// Open any Database partition
				reader = sqlCmd.ExecuteReader();

				if (reader.Read())
				{
					iCount				= reader.GetInt32(0);
				}
			}
			finally
			{
				reader.Close();
				cnCon.Close();
			}
			return(iCount);
		}
		/// <summary>
		/// CountofPoliticalUnit returns the number of political unit's of the matching type.
		/// </summary>
		/// <param name="pu">An enum identifying the type of political unit, e.g. City, County, State, or CensusTract, to return</param>
		/// <param name="year">Year of the census, e.g. 1990</param>
	[WebMethod]
		public Int32 CountOfPoliticalUnit( PoliticalUnit pu, Int32 year) 
		{
			Int32 iCount = -1;
			String szQuery = "";

			SqlDataReader reader = null;
			// Create a new Connection and DataSetCOmmand
			SqlConnection cnCon = new SqlConnection(Connection);

			if(pu == PoliticalUnit.Unknown) 
			{
				szQuery = "select count(*) from CensusFacts where SurveyYear = " + year;
			}
			else
			{
				szQuery = "select count(*) from CensusFacts where PoliticalUnit = " + (Int32)pu + " and SurveyYear = " + year;
			}
			SqlCommand sqlCmd = new SqlCommand(szQuery, cnCon);

			try
			{
				cnCon.Open();					// Open any Database partition
				reader = sqlCmd.ExecuteReader();

				if (reader.Read())
				{
					iCount				= reader.GetInt32(0);
				}
			}
			finally
			{
				if(reader != null) 
					reader.Close();
				cnCon.Close();
			}
			return(iCount);
		}
#if DEBUG
		[WebMethod]
		public String GetAppSetting(String key)
		{
			String keyValue = ConfigurationSettings.AppSettings[key];
			if(keyValue == null)
				keyValue = "AppSetting key '" + key + "', does not exist";
			return keyValue;

		}
		[WebMethod]
		public String GetConnection()
		{
			if(Connection == null)
				return "connectionString is null";
			else
				return Connection;

		}
#endif
		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

//		[WebMethod]
//		public string HelloWorld()
//		{
//			return "Hello World";
//		}
	}
}
