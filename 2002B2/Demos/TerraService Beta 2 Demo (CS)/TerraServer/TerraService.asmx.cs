// Copyright (C) Microsoft Corporation.  All Rights reserved.
// TerraService.asmx.cs
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

namespace TerraServer
{
	/// <summary>
	/// TerraServer is a web service that provides a set of methods to query the TerraServer relational database
	/// containing high resolution imagery and scanned maps of the earth.  To use the TerraService, it is 
	/// important to have an understanding of how TerraServer stores imagery within the database.  There
	/// are methods within the TerraServer that enable the web service user to (1) search the TerraServer
	/// place name tables known as the "gazetteer", (2) identify the imagery "tiles" that cover a specified
	/// geographic region on earth, and (3) perform several mapping conversion functions.
	/// <para>
	/// Conceptually, TerraServer stores 
	/// a set of seamless scenes that are divided into a mosaic of regular size image "tiles".  Each image tile 
	/// is a 200 by 200 pixel image compressed in the Jpeg or GIF format.  Five integer components form the 
	/// unique identifier for any image tile in the TerraServer system--  Theme, Scale, X, Y, and Scene.
	/// </para>
	/// <para>
	/// The Theme identifies the type of image and the data provider.  For example, Theme 1 is high resolution
	/// grayscale aerial imagery provided by the US Geological Survey.  The imagery is known as "Digital Ortho
	/// Quadrangles", a.k.a. "DOQ",  and is geo-rectified to the UTM Nad83 map projection standard.  For DOQ
	/// imagery, a Scene id represents the 	UTM Zone number.  There are 60 UTM zones numbered 1 to 60 and 
	/// each is 6 degrees wide.  Zone 1 starts at the International Date Line thru -174.   Zones 10 thru 19 
	/// cover the continental United States.  Note, a Scene identifier is not guaranteed to the UTM Zone identifier.
	/// The Scene identifier scheme is dependent on the projection type of a data theme.  For example, satellite 
	/// imagery is generally not geo-rectified to a map projection.  Usually a Scene identifier for satellite
	/// imagery represents a single photograph captured by the satellite.
	/// </para><para>
	/// The X and Y values identify the relative position of a tile within a scene.  X and Y values begin at
	/// 0 from the lower left hand corner of the scene, a.k.a. the southwest corner.  X values increment by 1 
	/// moving left to right or west to east.  Y values increment by 1 moving bottom to top or south to north.
	/// </para><para>
	/// The Scale identifier describes the image resolution of each pixel in the image tile.  The resolution 
	/// identifies the ground area covered by each "side" of a pixel.  For example, 1 meter resolution imagery
	/// means each pixel "covers" 1 meter of ground on each "side" of the pixel.  2 meter resolution imagery 
	/// covers 2 meters on each side of the pixel or 4 square meters.  Within TerraServer, imagery is stored at
	/// regular 2x (2 times) intervals from 1 meter.  Usually there are 7 image resolutions stored for each
	/// image theme.  For example, TerraServer stores 7 resolutions of DOQ imagery at 1, 2, 4, 8, 16, 32, and 64
	/// meters per pixel.  For USGS Topographic map data, TerraServer stores 7 resolution at 2, 4, 8, 16, 32, 64,
	/// and 128 meters per pixel.
	/// </para><para>
	/// From an image processing perspective, the multiple image resolution scales form an "image pyramid".  
	/// 1 meter resolution imagery is said a "higher resolution" than 2 meter resolution imagery.  Four 1 meter 
	/// resolution tiles are used to create 1 tile at 2 meter resolution.  A 2 meter resolution tile at
	/// 5,6 (X=5,Y=6) is created from 1 meter tiles 10,12, 11,12, 10,13, and 11,13.  This simple 2x math at each 
	/// level can be used to compute the "zoom in and out" addresses for any set of tiles.
	/// </para><para>
	/// The purpose of the TerraServer web service is to enable you the user to construct your own image scenes
	/// from a subset of tiles that form a complete TerraServer image scene.  In your application, you must
	/// decide what data theme/type your interested in, the size in pixels of the image you want to create, the
	/// resolution of the image, and the location on the earth of the image.  The first task is to query the
	/// TerraServer database to obtain the meta-data about the tiles that "cover" your specified region of 
	/// interest.  There are two methods at your disposal -- GetAreaFromPoint and GetAreaFromRect -- which differ
	/// only in how you specify your region of interest.  With GetAreaFromPoint, you specifiy the longitude and 
	/// latitude of the center of the image you wish to create, and the size of the image in pixels.  With 
	/// GetAreaFromRect, you specify the longitude and latitude of the top left and lower right corner points of 
	/// the image you are trying to build and the image resolution that you are interested in.
	/// </para>
	/// <para>Both methods return tile meta-data for the four corner points and the center point.  GetAreaFromPoint
	/// meta-data covers the corner points of the image area you are trying to build.  The pixel offset within the 
	/// corner tiles identifies where you need to crop the edge tiles in order to build an image of the specified 
	/// size.  The offset in the center tile identfies the pixel that contains the longitude and latitude you
	/// specified in the calling parameter.  The GetAreaFromRect returns meta data for the tiles that cover
	/// your geographic region of interest.  The meta-data for the corner tiles identify the tiles that cover the
	/// corner point of your geographic area.  The offset in the NorthWest tile meta data identifies the pixel
	/// containing the top-left corner point you specified in the calling parameter.  The SouthEast tile meta
	/// data identifies the pixel that contains the lower-right corner point you specified.  The Center tile meta
	/// data identifies the computed center longitude and latitude and the pixel it occurs in within the tile.
	/// </para>
	/// 
	/// </summary>
	[WebService(Namespace="http://terraservice.net/terraserver/")]
	public class TerraService : System.Web.Services.WebService
	{
		/// <summary>
		/// TerraService public constructor.
		/// </summary>
		public TerraService()
		{
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
		/// The ConvertLonLatPtToNearestPlace method does a geo-spatial search of the TerraServer
		/// Gazetteer to find the nearest populated place to the longitude and latitude specified.
		/// The returned string contains the distance and direction to the named point unless you 
		/// happen to specify a point "right over" the centroid for a named place.  Note, this method
		/// calls the same database function as the TerraServer web application that emits a place name
		/// above TerraServer image pages.
		/// </summary>
		/// <param name="point">The longitude and latitude to find the nearest location of.</param>
		[WebMethod]
		public string ConvertLonLatPtToNearestPlace(LonLatPt point) 
		{
			string s = "";

			// Create a new Connection and DataSetCOmmand
			TerraServerConnection tsCon = new TerraServerConnection();

			SqlCommand tsCmd = new SqlCommand("spTSClosestCity", tsCon.Connection);
			tsCmd.CommandType = CommandType.StoredProcedure;


			// fill the parameters collection based upon stord procedure
			SqlParameter workParam = null;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@LatDegree", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@LonDegree", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@GrainSize", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@ClosestCity", SqlDbType.VarChar, 255));
			workParam.Direction = ParameterDirection.Output;

			tsCmd.Parameters["@LatDegree"].Value = point.Lat;
			tsCmd.Parameters["@LonDegree"].Value = point.Lon;
			tsCmd.Parameters["@GrainSize"].Value = 1;
			tsCmd.Parameters["@Debug"].Value = 0;
			
			try
			{
				tsCon.Open(0);				// Open on any database partition
				tsCmd.ExecuteNonQuery();
				s = tsCmd.Parameters["@ClosestCity"].Value.ToString();
			}
			finally
			{
				tsCon.Close();
			}

			return(s);
		}
		/// <summary>
		/// ConvertLonLatPtToUtmPt method returns a UtmPt using the Nad83 Datum for the specified
		/// longitude and latitude point. 
		/// </summary>
		/// <param name="point">The longitude and latitude of compute the Utm Point for.</param>
		/// <returns>The UtmPt using the Nad83 Datum.</returns>
		[WebMethod]
		public UtmPt ConvertLonLatPtToUtmPt(LonLatPt point) 
		{
			UtmPt utm = new UtmPt();
			utm = Projection.LonLatPtToUtmNad83Pt(point);
			return (utm);
		}
		/// <summary>
		/// Computes the Longitude and Latitude from a UtmPt that is assumed to be in the Nad83 Datum.
		/// </summary>
		/// <param name="utm">The Utm value to compute a longitude and latitude for.</param>
		/// <returns>The computed longitude and latitude.</returns>
		[WebMethod]
		public LonLatPt ConvertUtmPtToLonLatPt(UtmPt utm) 
		{
			LonLatPt point = new LonLatPt();

			point = Projection.UtmNad83PtToLonLatPt(utm);
			return(point);
		}

		/// <summary>
		/// ConvertPlaceToLonLatPt searches the TerraServer Gazetteer for the specified place name and
		/// returns the Longitude and Latitude.  If a place name is not found, then 0,0 is returned.
		/// </summary>
		/// <param name="place">The name of the place (name, state, country) to search for.</param>
		/// <returns>A Longitude and Latitude value.</returns>
		[WebMethod]
		public LonLatPt ConvertPlaceToLonLatPt(Place place) 
		{
			LonLatPt point = new LonLatPt();
			point.Lon = 0.0;
			point.Lat = 0.0;

			SqlDataReader reader = null;
			// Create a new Connection and DataSetCommand
			TerraServerConnection tsCon = new TerraServerConnection();

			//string szQuery = "exec spTSNFindAnyPlaceFirst '" + place.City + "',0,'" + place.State + "','" + place.Country + "',1";
			//SqlCommand tsCmd = new SqlCommand(szQuery, tsCon);
			SqlCommand tsCmd = new SqlCommand("spTSNFindAnyPlaceFirst", tsCon.Connection);
			tsCmd.CommandType = CommandType.StoredProcedure;


			// fill the parameters collection based upon stord procedure
			SqlParameter workParam = null;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@PlaceName", SqlDbType.VarChar, 100));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@PlaceTypeId", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@StateName", SqlDbType.VarChar, 40));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@CountryName", SqlDbType.VarChar, 40));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@MaxPlaces", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			tsCmd.Parameters["@PlaceName"].Value			= place.City;
			tsCmd.Parameters["@PlaceTypeId"].Value			= 0;
			tsCmd.Parameters["@StateName"].Value			= place.State;
			tsCmd.Parameters["@CountryName"].Value			= place.Country;
			tsCmd.Parameters["@MaxPlaces"].Value			= 1;


			try 
			{
				tsCon.Open(0);					// Open any Database partition
				reader = tsCmd.ExecuteReader();

				while (reader.Read()) 
				{
					point.Lon	= reader.GetFloat(3);
					point.Lat	= reader.GetFloat(4);
					break;
				}
			}
			finally 
			{
				reader.Close();
				tsCon.Close();
			}

			return(point);
		}
		/// <summary>
		/// Counts the number of named places in the area bounded by parameters upperLeft and lowerright 
		/// Longitude and Latitude values.  Pass a UnknownPlaceType enum value if you want to count 
		/// places of any type.  Otherwise, pass a "known" place type enum value to count a specific type
		/// of place in the bounding area.
		/// </summary>
		/// <param name="upperleft">Longitude and Latitude of the upper left corner point of the bounding area to search.</param>
		/// <param name="lowerright">Longitude and Latitude of the lower right corner point of the bounding area to search.</param>
		/// <param name="ptype">The type of place to count.  Pass UnkownPlaceType to count all place types in the bounding area.</param>
		/// <returns>Count of the places matching the type in the bounding area.</returns>
		[WebMethod]
		public int CountPlacesInRect(LonLatPt upperleft, LonLatPt lowerright, PlaceType ptype) 
		{
			int	iCount = 0;

			// Create a new Connection and DataSetCOmmand
			SqlDataReader reader = null;
			TerraServerConnection tsCon = new TerraServerConnection();

			SqlCommand tsCmd = new SqlCommand("spTSNCountPlaceInRect", tsCon.Connection);
			tsCmd.CommandType = CommandType.StoredProcedure;


			// fill the parameters collection based upon stord procedure
			SqlParameter workParam = null;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dUpperLeftLon", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dUpperLeftLat", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dLowerRightLon", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dLowerRightLat", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@PlaceTypeId", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			tsCmd.Parameters["@dUpperLeftLon"].Value = upperleft.Lon;
			tsCmd.Parameters["@dUpperLeftLat"].Value = upperleft.Lat;
			tsCmd.Parameters["@dLowerRightLon"].Value = lowerright.Lon;
			tsCmd.Parameters["@dLowerRightLat"].Value = lowerright.Lat;
			tsCmd.Parameters["@PlaceTypeId"].Value = 0; //(int)ptype;
			try
			{
				tsCon.Open(0);				// Open on any database partition
				reader = tsCmd.ExecuteReader();
				if(reader.Read()) 
				{
					iCount		= reader.GetInt32(0);
				}
				//iCount = Convert.ToInt32(tsCmd.Parameters["@RowCount"].Value.ToString());
			}
			finally
			{
				reader.Close();
				tsCon.Close();
			}

			return(iCount);
		}

		//	Ordinal to field map:
		//		FoundFlag(0), Theme(1), Scale(2), X(3), Y(4), Zone(5), Version(6), DisplayStatus(7)
		//		EncryptKey(8), ImgType(9), ProdStatus(10), BlankValue(11), PlaceId(12), XSearch(13),
		//		YSearch(14), PixWidth(15), PixHeight(16), PixDepth(17), ModifierId(18), CNLon(19),
		//		CNLat(20), NWLon(21), NWLat(22), NELon(23), NELat(24), SELon(25), SELat(26), 
		//		SWLon(27), SWLat(28), ImageDate(29), Insertdate(30), ChangeDate(31), OrigMetaTag(32),
		//		ImageFilename(33), PlaceName(34), XPixOffset(35), YPixOffset(36), ExecutionMs(37),
		//		StartTime(38), EndTime(39)
		private AreaCoordinate SetAreaCoordinate(SqlDataReader reader) 
		{
			
			AreaCoordinate ac = new AreaCoordinate();
			//throw new Exception("Tom: 21=" + reader[21] + " 21.GetFloat=" + reader.GetFloat(21));
			ac.TileMeta.Id.Theme			= (Theme) reader.GetInt32(1);
			ac.TileMeta.Id.Scale			= (Scale) reader.GetInt32(2);
			ac.TileMeta.Id.Scene			= reader.GetInt32(5);
			ac.TileMeta.Id.X				= reader.GetInt32(3);
			ac.TileMeta.Id.Y				= reader.GetInt32(4);
			ac.TileMeta.NorthWest.Lon		= reader.GetFloat(21);
			ac.TileMeta.NorthWest.Lat		= reader.GetFloat(22);
			ac.TileMeta.NorthEast.Lon		= reader.GetFloat(23);
			ac.TileMeta.NorthEast.Lat		= reader.GetFloat(24);
			ac.TileMeta.SouthEast.Lon		= reader.GetFloat(25);
			ac.TileMeta.SouthEast.Lat		= reader.GetFloat(26);
			ac.TileMeta.SouthWest.Lon		= reader.GetFloat(27);
			ac.TileMeta.SouthWest.Lat		= reader.GetFloat(28);
			ac.TileMeta.Center.Lon			= reader.GetFloat(19);
			ac.TileMeta.Center.Lat			= reader.GetFloat(20);
			ac.TileMeta.Capture				= (DateTime)reader.GetSqlDateTime(29);	//Convert.ToDateTime(reader["ImageDate"].ToString());
			//ac.Offset.Lon					= reader.GetInt32(35);
			//ac.Offset.Lat					= reader.GetInt32(36);
			if(reader.GetInt32(0) == 1)
				ac.TileMeta.TileExists		= true;
			else
				ac.TileMeta.TileExists		= false;
			//
			//		Calculate Longitude and Latitude of the offset point
			//
			ac.Offset.XOffset				= reader.GetInt32(35);
			ac.Offset.YOffset				= reader.GetInt32(36);
			UtmPt utmPoint = new UtmPt();
			Int32 metersPerPixel			= (1 << ((Int32) ac.TileMeta.Id.Scale - 10));
			utmPoint.Zone					= ac.TileMeta.Id.Scene;
			utmPoint.X						= (Double)((ac.TileMeta.Id.X * 200 * metersPerPixel) + (ac.Offset.XOffset * metersPerPixel));
			utmPoint.Y						= (Double)((ac.TileMeta.Id.Y * 200 * metersPerPixel) + ((200 - ac.Offset.YOffset) * metersPerPixel));
			ac.Offset.Point					= Projection.UtmNad83PtToLonLatPt(utmPoint);
			return(ac);
		}
		/// <summary>
		/// GetAreaFromPt returns a Tile meta-data of the four corner tiles and the center tile which overlap
		/// the image pixel area specified in a calling parameter.  Use GetAreaFromPt to determine the 
		/// addresses of the image tiles to fetch from TerraServer when you wish to fill a pre-determined 
		/// screen/image area and you want to keep a specific longitude and latitude centered in the window/image
		/// area.
		/// </summary>
		/// <param name="center">The Longitude and Latitude that should be in the center of the image area.  Note,
		/// the pixel offset to this point will be returned in the Center TileMeta structure of the returned AreaBoundingBox.</param>
		/// <param name="theme">The enum of the data theme to search for at the center point.</param>
		/// <param name="scale">The image resolution Scale enum of the imagery to search for.</param>
		/// <param name="displayPixWidth">The width of the screen/image area that you will be filling with image tiles.</param>
		/// <param name="displayPixHeight">The height of the screen/image area that you will be filling with image tiles.</param>
		/// <returns>An AreaBoundingBox structure which is a container for TileMeta structures of the four corner tiles, the center tile, 
		/// distance and direction to the closest named place to the center point.</returns>
		[WebMethod]
		public AreaBoundingBox GetAreaFromPt(LonLatPt center, Theme theme, Scale scale, int displayPixWidth, int displayPixHeight) 
		{

			TerraServerUtility.ValidateScale(theme, scale);
			TerraServerUtility.ValidateLonLatPt(center);

			AreaBoundingBox abb = new AreaBoundingBox();
			abb.NorthWest.TileMeta.Id.Theme = Theme.Photo;
			abb.NorthWest.TileMeta.Id.Scale = Scale.Scale1mm;
			abb.NorthWest.TileMeta.Id.Scene = 1;
			abb.NorthWest.TileMeta.Id.X = 0;
			abb.NorthWest.TileMeta.Id.Y = 0;
			abb.NorthWest.TileMeta.TileExists = false;
			abb.NorthWest.TileMeta.NorthWest.Lon = 0;
			abb.NorthWest.TileMeta.NorthWest.Lat = 0;
			abb.NorthWest.TileMeta.NorthEast.Lon = 0;
			abb.NorthWest.TileMeta.NorthEast.Lat = 0;
			abb.NorthWest.TileMeta.SouthEast.Lon = 0;
			abb.NorthWest.TileMeta.SouthEast.Lat = 0;
			abb.NorthWest.TileMeta.SouthWest.Lon = 0;
			abb.NorthWest.TileMeta.SouthWest.Lat = 0;
			abb.NorthWest.TileMeta.Center.Lon = 0;
			abb.NorthWest.TileMeta.Center.Lat = 0;
			abb.NorthWest.TileMeta.Capture = DateTime.Now;
			abb.NorthWest.Offset.Point.Lon = 0;
			abb.NorthWest.Offset.Point.Lat = 0;
			abb.NorthWest.Offset.XOffset = 0;
			abb.NorthWest.Offset.YOffset = 0;

			abb.NorthEast = abb.NorthWest;
			abb.SouthEast = abb.NorthWest;
			abb.SouthWest = abb.NorthWest;
			abb.Center = abb.NorthWest;

			SqlDataReader reader = null;
			TerraServerConnection tsCon = new TerraServerConnection();	// SqlConnection("server=fab4web;uid=ts4_dbo;pwd=;database=ts4");

			//String szQuery = "exec spTSNTileRectByPt " + theme + "," + scale + "," + center.Lon + "," + center.Lat + "," + displayPixWidth + "," + displayPixHeight;
			//throw new Exception(szQuery);
			//SqlCommand mySqlCommand = new SqlCommand(szQuery, tsCon);
			SqlCommand tsCmd = new SqlCommand("spTSNTileRectByPt", tsCon.Connection);
			tsCmd.CommandType = CommandType.StoredProcedure;

			// fill the parameters collection based upon stord procedure
			SqlParameter workParam = null;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iTheme", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iScale", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dLon", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dLat", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iPixWidth", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iPixHeight", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			tsCmd.Parameters["@iTheme"].Value		= (int)theme;
			tsCmd.Parameters["@iScale"].Value		= (int)scale;
			tsCmd.Parameters["@dLon"].Value			= center.Lon;
			tsCmd.Parameters["@dLat"].Value			= center.Lat;
			tsCmd.Parameters["@iPixWidth"].Value	= displayPixWidth;
			tsCmd.Parameters["@iPixHeight"].Value	= displayPixHeight;
			//DEBUG throw new Exception("iTheme=" + tsCmd.Parameters["@iTheme"].Value + " iScale=" + tsCmd.Parameters["@iScale"].Value + " dLon=" + tsCmd.Parameters["@dLon"].Value + " dLat=" + tsCmd.Parameters["@dLat"].Value + " Width=" + tsCmd.Parameters["@iPixWidth"].Value + " Height=" + tsCmd.Parameters["@iPixHeight"].Value);
			try
			{
				tsCon.Open(theme, center);					// Open any Database partition  theme,10
				reader = tsCmd.ExecuteReader();

				if (reader.Read()) 
				{			// Fetch Northwest values
					abb.NorthWest = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Northeast values
					abb.NorthEast = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Southeast values
					abb.SouthEast = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Southwest values
					abb.SouthWest = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Center point values
					abb.Center = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Nearest Place string
					abb.NearestPlace = reader.GetString(0);
				}
				if(reader.NextResult()) 
				{
					ArrayList otis = new ArrayList();
					while(reader.Read()) 
					{
						Int32 iTheme			= reader.GetInt32(0);
						OverlappingThemeInfo oti = new OverlappingThemeInfo();
						oti.LocalTheme			= (iTheme < 100) ? true : false; // reader.GetBoolean(14);
						if(iTheme < 100)
							oti.Theme			= (Theme)iTheme;
						else
							oti.Theme			= Theme.Relief;
						oti.Point.Lon			= reader.GetFloat(8);
						oti.Point.Lat			= reader.GetFloat(9);
						oti.ThemeName			= reader.GetString(10);
						//oti.Capture				= Convert.ToDateTime(reader[5].ToString());
						oti.Capture				= (DateTime)reader.GetSqlDateTime(5);
						oti.ProjectionId		= ProjectionType.UtmNad83;  //(Projection)reader.GetInt32(6);
						oti.LoScale				= (Scale)reader.GetInt32(11);
						oti.HiScale				= (Scale)reader.GetInt32(12);
						oti.Url					= reader.GetString(13);					// Link to the remote web server
						otis.Add(oti);
					}
					abb.OverlappingThemeInfos = (OverlappingThemeInfo[]) otis.ToArray(typeof(OverlappingThemeInfo));
				} 
				else 
				{
					abb.OverlappingThemeInfos = null;
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				if (tsCon  != null) tsCon.Close();
			}
			return(abb);
		}
		/// <summary>
		/// GetAreaFromRect returns Tile meta-data for the geographic area specified in the upperLeft thru
		/// lowerRight bounding area in the specified theme and scale.  The NorthWest TileMeta structure 
		/// will identify the pixel offset to the upperLeft point.  THe SouthEast TileMeta structure 
		/// will identify the pixel offset to the lowerRight point. 
		/// </summary>
		/// <param name="upperLeft">The top-left corner point defining the bounding area to search.</param>
		/// <param name="lowerRight">The lower-right corner point defining the bounding area to search.</param>
		/// <param name="theme">The data theme enum to search for.</param>
		/// <param name="scale">The image resolution Scale to search for.</param>
		/// <returns>An AreaBoundingBox structure which is a container for TileMeta structures of the four corner tiles, the center tile, 
		/// distance and direction to the closest named place to the point halfway between the upperLeft and lowerRight points.</returns>
		[WebMethod]
		public AreaBoundingBox GetAreaFromRect(LonLatPt upperLeft, LonLatPt lowerRight, Theme theme, Scale scale) 
		{

			TerraServerUtility.ValidateScale(theme, scale);
			TerraServerUtility.ValidateLonLatPt(upperLeft);
			TerraServerUtility.ValidateLonLatPt(lowerRight);

			AreaBoundingBox abb = new AreaBoundingBox();
			abb.NorthWest.TileMeta.Id.Theme = Theme.Photo;
			abb.NorthWest.TileMeta.Id.Scale = Scale.Scale1mm;
			abb.NorthWest.TileMeta.Id.Scene = 1;
			abb.NorthWest.TileMeta.Id.X = 0;
			abb.NorthWest.TileMeta.Id.Y = 0;
			abb.NorthWest.TileMeta.TileExists = false;
			abb.NorthWest.TileMeta.NorthWest.Lon = 0;
			abb.NorthWest.TileMeta.NorthWest.Lat = 0;
			abb.NorthWest.TileMeta.NorthEast.Lon = 0;
			abb.NorthWest.TileMeta.NorthEast.Lat = 0;
			abb.NorthWest.TileMeta.SouthEast.Lon = 0;
			abb.NorthWest.TileMeta.SouthEast.Lat = 0;
			abb.NorthWest.TileMeta.SouthWest.Lon = 0;
			abb.NorthWest.TileMeta.SouthWest.Lat = 0;
			abb.NorthWest.TileMeta.Center.Lon = 0;
			abb.NorthWest.TileMeta.Center.Lat = 0;
			abb.NorthWest.TileMeta.Capture = DateTime.Now;
			abb.NorthWest.Offset.Point.Lon = 0;
			abb.NorthWest.Offset.Point.Lat = 0;
			abb.NorthWest.Offset.XOffset = 0;
			abb.NorthWest.Offset.YOffset = 0;

			abb.NorthEast = abb.NorthWest;
			abb.SouthEast = abb.NorthWest;
			abb.SouthWest = abb.NorthWest;
			abb.Center = abb.NorthWest;

			SqlDataReader reader = null;
			TerraServerConnection tsCon = new TerraServerConnection();	// SqlConnection("server=fab4web;uid=ts4_dbo;pwd=;database=ts4");

			//string szQuery = "exec spTSNTileRectByCorner " + theme + "," + scale + "," + upperLeft.Lon + "," + upperLeft.Lat + "," + lowerRight.Lon + "," + lowerRight.Lat;
			//SqlCommand mySqlCommand = new SqlCommand(szQuery, tsCon);
			SqlCommand tsCmd = new SqlCommand("spTSNTileRectByCorner", tsCon.Connection);
			tsCmd.CommandType = CommandType.StoredProcedure;

			// fill the parameters collection based upon stord procedure
			SqlParameter workParam = null;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iTheme", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iScale", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dUpperLeftLon", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dUpperLeftLat", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dLowerRightLon", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dLowerRightLat", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			tsCmd.Parameters["@iTheme"].Value			= (int)theme;
			tsCmd.Parameters["@iScale"].Value			= (int)scale;
			tsCmd.Parameters["@dUpperLeftLon"].Value	= upperLeft.Lon;
			tsCmd.Parameters["@dUpperLeftLat"].Value	= upperLeft.Lat;
			tsCmd.Parameters["@dLowerRightLon"].Value	= lowerRight.Lon;
			tsCmd.Parameters["@dLowerRightLat"].Value	= lowerRight.Lat;

			try
			{
				tsCon.Open(0);					// Open any Database partition
				reader = tsCmd.ExecuteReader();

				if (reader.Read()) 
				{			// Fetch Northwest values
					abb.NorthWest = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Northeast values
					abb.NorthEast = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Southeast values
					abb.SouthEast = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Southwest values
					abb.SouthWest = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Center point values
					abb.Center = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Nearest Place string
					abb.NearestPlace							= reader.GetString(0);
				}
				if(reader.NextResult()) 
				{
					ArrayList otis = new ArrayList();
					while(reader.Read()) 
					{
						Int32 iTheme			= reader.GetInt32(0);
						OverlappingThemeInfo oti = new OverlappingThemeInfo();
						oti.LocalTheme			= (iTheme < 100) ? true : false; // reader.GetBoolean(14);
						if(iTheme < 100)
							oti.Theme			= (Theme)iTheme;
						else
							oti.Theme			= Theme.Relief;
						oti.Point.Lon			= reader.GetFloat(8);
						oti.Point.Lat			= reader.GetFloat(9);
						oti.ThemeName			= reader.GetString(10);
						//oti.Capture				= Convert.ToDateTime(reader[5].ToString());
						oti.Capture				= (DateTime)reader.GetSqlDateTime(5);
						oti.ProjectionId		= ProjectionType.UtmNad83;  //(Projection)reader.GetInt32(6);
						oti.LoScale				= (Scale)reader.GetInt32(11);
						oti.HiScale				= (Scale)reader.GetInt32(12);
						oti.Url					= reader.GetString(13);					// Link to the remote web server
						otis.Add(oti);
					}
					abb.OverlappingThemeInfos = (OverlappingThemeInfo[]) otis.ToArray(typeof(OverlappingThemeInfo));
				} 
				else 
				{
					abb.OverlappingThemeInfos = null;
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				if (tsCon  != null) tsCon.Close();
			}
			return(abb);
		}
		/// <summary>
		/// GetAreaFromTileId is similar to the GetAreaFromPt method except that a Tile identifier (theme,
		/// scale, x, y, and scene) is used as the center the area to return.
		/// </summary>
		/// <param name="id">The Tile identifier to locate.</param>
		/// <param name="displayPixWidth">The pixel width of the display area you are trying to fill.</param>
		/// <param name="displayPixHeight">The pixel height of the display area you are trying to fill.</param>
		[WebMethod]
		public AreaBoundingBox GetAreaFromTileId(TileId id, int displayPixWidth, int displayPixHeight) 
		{
			TerraServerUtility.ValidateScale(id.Theme, id.Scale);

			AreaBoundingBox abb = new AreaBoundingBox();
			abb.NorthWest.TileMeta.Id.Theme = Theme.Photo;
			abb.NorthWest.TileMeta.Id.Scale = Scale.Scale1mm;
			abb.NorthWest.TileMeta.Id.Scene = 1;
			abb.NorthWest.TileMeta.Id.X = 0;
			abb.NorthWest.TileMeta.Id.Y = 0;
			abb.NorthWest.TileMeta.TileExists = false;
			abb.NorthWest.TileMeta.NorthWest.Lon = 0;
			abb.NorthWest.TileMeta.NorthWest.Lat = 0;
			abb.NorthWest.TileMeta.NorthEast.Lon = 0;
			abb.NorthWest.TileMeta.NorthEast.Lat = 0;
			abb.NorthWest.TileMeta.SouthEast.Lon = 0;
			abb.NorthWest.TileMeta.SouthEast.Lat = 0;
			abb.NorthWest.TileMeta.SouthWest.Lon = 0;
			abb.NorthWest.TileMeta.SouthWest.Lat = 0;
			abb.NorthWest.TileMeta.Center.Lon = 0;
			abb.NorthWest.TileMeta.Center.Lat = 0;
			abb.NorthWest.TileMeta.Capture = DateTime.Now;
			abb.NorthWest.Offset.Point.Lon = 0;
			abb.NorthWest.Offset.Point.Lat = 0;
			abb.NorthWest.Offset.XOffset = 0;
			abb.NorthWest.Offset.YOffset = 0;

			abb.NorthEast = abb.NorthWest;
			abb.SouthEast = abb.NorthWest;
			abb.SouthWest = abb.NorthWest;
			abb.Center = abb.NorthWest;

			SqlDataReader reader = null;
			TerraServerConnection tsCon = new TerraServerConnection();	// SqlConnection("server=fab4web;uid=ts4_dbo;pwd=;database=ts4");

			//string szQuery = "exec spTSNTileRectByPt " + id.Theme + "," + id.Scale + "," + id.X + "," + id.Y + "," + id.Scene + "," + displayPixWidth + "," + displayPixHeight;
			//SqlCommand mySqlCommand = new SqlCommand(szQuery, tsCon);
			SqlCommand tsCmd = new SqlCommand("spTSNTileRectByTileId", tsCon.Connection);
			tsCmd.CommandType = CommandType.StoredProcedure;

			// fill the parameters collection based upon stord procedure
			SqlParameter workParam = null;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iTheme", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iScale", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iX", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iY", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iZone", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iPixWidth", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iPixHeight", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			tsCmd.Parameters["@iTheme"].Value		= (int)id.Theme;
			tsCmd.Parameters["@iScale"].Value		= (int)id.Scale;
			tsCmd.Parameters["@iX"].Value			= id.X;
			tsCmd.Parameters["@iY"].Value			= id.Y;
			tsCmd.Parameters["@iZone"].Value		= id.Scene;
			tsCmd.Parameters["@iPixWidth"].Value	= displayPixWidth;
			tsCmd.Parameters["@iPixHeight"].Value	= displayPixHeight;

			//	Ordinal to field map:
			//		FoundFlag(0), Theme(1), Scale(2), X(3), Y(4), Zone(5), Version(6), DisplayStatus(7)
			//		EncryptKey(8), ImgType(9), ProdStatus(10), BlankValue(11), PlaceId(12), XSearch(13),
			//		YSearch(14), PixWidth(15), PixHeight(16), PixDepth(17), ModifierId(18), CNLon(19),
			//		CNLat(20), NWLon(21), NWLat(22), NELon(23), NELat(24), SELon(25), SELat(26), 
			//		SWLon(27), SWLat(28), ImageDate(29), Insertdate(30), ChangeDate(31), OrigMetaTag(32),
			//		ImageFilename(33), PlaceName(34), XPixOffset(35), YPixOffset(36), ExecutionMs(37),
			//		StartTime(38), EndTime(39)
			try
			{
				tsCon.Open(id.Theme, id.Scene);					// Open any Database partition
				reader = tsCmd.ExecuteReader();

				if (reader.Read()) 
				{			// Fetch Northwest values
					abb.NorthWest = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Northeast values
					abb.NorthEast = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Southeast values
					abb.SouthEast = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Southwest values
					abb.SouthWest = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Center point values
					abb.Center = SetAreaCoordinate(reader);
				}
				if(!reader.NextResult()) throw new Exception();
				if (reader.Read()) 
				{			// Fetch Nearest Place string
					abb.NearestPlace = reader.GetString(0);
				}
				if(reader.NextResult()) 
				{
					ArrayList otis = new ArrayList();
					while(reader.Read()) 
					{
						Int32 iTheme			= reader.GetInt32(0);
						OverlappingThemeInfo oti = new OverlappingThemeInfo();
						oti.LocalTheme			= (iTheme < 100) ? true : false; // reader.GetBoolean(14);
						if(iTheme < 100)
							oti.Theme			= (Theme)iTheme;
						else
							oti.Theme			= Theme.Relief;
						oti.Point.Lon			= reader.GetFloat(8);
						oti.Point.Lat			= reader.GetFloat(9);
						oti.ThemeName			= reader.GetString(10);
						//oti.Capture				= Convert.ToDateTime(reader[5].ToString());
						oti.Capture				= (DateTime)reader.GetSqlDateTime(5);
						oti.ProjectionId		= ProjectionType.UtmNad83;  //(Projection)reader.GetInt32(6);
						oti.LoScale				= (Scale)reader.GetInt32(11);
						oti.HiScale				= (Scale)reader.GetInt32(12);
						oti.Url					= reader.GetString(13);					// Link to the remote web server
						otis.Add(oti);
					}
					abb.OverlappingThemeInfos = (OverlappingThemeInfo[]) otis.ToArray(typeof(OverlappingThemeInfo));
				} 
				else 
				{
					abb.OverlappingThemeInfos = null;
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				if (tsCon  != null) tsCon.Close();
			}
			return(abb);
		}
		/// <summary>
		/// GetLatLonMetrics is used to identify the data themes that are available in a geographic area.
		/// This method is generally used to present a drop-down list of available data themes.  Note, 
		/// this method is currently a placeholder and is not implemented.  Effectively, TerraServer only 
		/// supports the USGS DOQ (aerial imagery) and DRG (topographic map) data over the United States.
		/// </summary>
		[WebMethod]
		public ThemeBoundingBox[] GetLatLonMetrics(LonLatPt point) 
		{
			ThemeBoundingBox[] themeBoundingBox = new ThemeBoundingBox[10];
			return(themeBoundingBox);
		}
		/// <summary>
		/// GetPlaceFacts returns detailes of the first matching place. 
		/// </summary>
		/// <param name="place">The place name to search for (name, state, and country).</param>
		[WebMethod]
		public PlaceFacts GetPlaceFacts(Place place) 
		{
			PlaceFacts placeFacts = new PlaceFacts();

			SqlDataReader reader = null;
			// Create a new Connection and DataSetCommand
			TerraServerConnection tsCon = new TerraServerConnection();

			//string szQuery = "exec spTSNFindPlaceFirst '" + place.City + "',0,'" + place.State + "','" + place.Country + "',1";
			//SqlCommand mySqlCommand = new SqlCommand(szQuery, tsCon);
			SqlCommand tsCmd = new SqlCommand("spTSNFindPlaceFirst", tsCon.Connection);
			tsCmd.CommandType = CommandType.StoredProcedure;


			// fill the parameters collection based upon stord procedure
			SqlParameter workParam = null;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@PlaceName", SqlDbType.VarChar, 100));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@PlaceTypeId", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@StateName", SqlDbType.VarChar, 40));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@CountryName", SqlDbType.VarChar, 40));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@MaxPlaces", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			tsCmd.Parameters["@PlaceName"].Value			= place.City;
			tsCmd.Parameters["@PlaceTypeId"].Value			= 0;
			tsCmd.Parameters["@StateName"].Value			= place.State;
			tsCmd.Parameters["@CountryName"].Value			= place.Country;
			tsCmd.Parameters["@MaxPlaces"].Value			= 1;

			try
			{
				tsCon.Open(0);					// Open any available database
				reader = tsCmd.ExecuteReader();

				while (reader.Read())
				{
					placeFacts.Place.City			= reader.GetString(5);
					placeFacts.Place.State			= reader.GetString(6);
					placeFacts.Place.Country		= reader.GetString(7);
					placeFacts.Center.Lon			= reader.GetFloat(3);
					placeFacts.Center.Lat			= reader.GetFloat(4);
					placeFacts.AvailableThemeMask	= (Themes)reader.GetInt32(18);
					placeFacts.PlaceTypeId			= (PlaceType)reader.GetInt32(15);
					break;
				}
			}
			finally
			{
				reader.Close();
				tsCon.Close();
			}

			return(placeFacts);
		}
		/// <summary>
		/// GetPlaceList searches the TerraServer Gazetteer for the name matching the string placeName.
		/// The function emulates the Find functionality found the Microsoft TerraServer web slite.  The
		/// placeName can contain any combination of place name, state, and country separated by commas.
		/// The system will do a wildcard search on the placeName and find all matching places within the state 
		/// and county if specified.  A maximum of MaxItems will be returned to the caller.
		/// </summary>
		/// <param name="placeName">A free formatted string containing the name, state, and country.</param>
		/// <param name="MaxItems">The maximum number of matching places to return.</param>
		/// <param name="imagePresence">A boolean value to restrict the search to places that overlap imagery (true) or all places. (false)</param>
		[WebMethod]
		public PlaceFacts[] GetPlaceList(string placeName, int MaxItems, Boolean imagePresence) 
		{
			PlaceFacts[] placeFacts = new PlaceFacts[MaxItems];
			int i = 0, iRowType = 0;
			SqlDataReader reader = null;

			// Create a new Connection and DataSetCOmmand
			TerraServerConnection tsCon = new TerraServerConnection();

			//string szQuery = "exec spTSNFindPlaceFirst '" + placeName + "',-1,' ',' '," + MaxItems;
			//SqlCommand mySqlCommand = new SqlCommand(szQuery, tsCon);
			SqlCommand tsCmd = new SqlCommand("spTSNFindPlaceFirst", tsCon.Connection);
			tsCmd.CommandType = CommandType.StoredProcedure;


			// fill the parameters collection based upon stord procedure
			SqlParameter workParam = null;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@PlaceName", SqlDbType.VarChar, 100));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@PlaceTypeId", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@StateName", SqlDbType.VarChar, 40));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@CountryName", SqlDbType.VarChar, 40));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@MaxPlaces", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			tsCmd.Parameters["@PlaceName"].Value			= placeName;
			tsCmd.Parameters["@PlaceTypeId"].Value			= -1;
			tsCmd.Parameters["@StateName"].Value			= " ";
			tsCmd.Parameters["@CountryName"].Value			= " ";
			tsCmd.Parameters["@MaxPlaces"].Value			= MaxItems;


			try
			{
				tsCon.Open(0);					// Open any available database
				reader = tsCmd.ExecuteReader();

				while (reader.Read())
				{
					iRowType							= reader.GetInt32(1);
					if(iRowType != 0) 
						break;
					placeFacts[i].Place.City			= reader.GetString(5);
					placeFacts[i].Place.State			= reader.GetString(6);
					placeFacts[i].Place.Country			= reader.GetString(7);
					placeFacts[i].Center.Lon			= reader.GetFloat(3);
					placeFacts[i].Center.Lat			= reader.GetFloat(4);
					placeFacts[i].AvailableThemeMask	= (Themes)reader.GetInt32(18);
					placeFacts[i].PlaceTypeId			= (PlaceType)reader.GetInt32(15);
					i++;
					if(i == MaxItems) break;
					if(!reader.NextResult()) break;
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				if (tsCon  != null) tsCon.Close();
			}
			PlaceFacts[] pf = new PlaceFacts[i];
			Array.Copy(placeFacts, pf, i);
			return(pf);
		}
		/// <summary>
		/// Similar to GetPlaceList but returns known places in a geographic region 
		/// bounded by upperleft and lowerright longitude and latitude values. 
		/// </summary>
		/// <param name="upperleft">The top-left point of the bounding area to search.</param>
		/// <param name="lowerright">The lower-right point of the bounding area to search.</param>
		/// <param name="ptype">The PlaceType enum to search for.  Pass UnknownPlaceType to find places of all types.</param>
		/// <param name="MaxItems">The maximum items to return in the list.</param>
		
		[WebMethod]
		public PlaceFacts[] GetPlaceListInRect(LonLatPt upperleft, LonLatPt lowerright, PlaceType ptype, int MaxItems) 
		{
			PlaceFacts[] placeFacts = new PlaceFacts[MaxItems];
			int i = 0, iRowType = 0;

			SqlDataReader reader = null;

			// Create a new Connection and DataSetCOmmand
			TerraServerConnection tsCon = new TerraServerConnection();

			//string szQuery = "exec spTSNFindPlaceInRect " + upperleft.Lon + "," + upperleft.Lat + "," + lowerright.Lon + "," + lowerright.Lat + "," + ptype + "," + MaxItems;
			//SqlCommand mySqlCommand = new SqlCommand(szQuery, tsCon);
			SqlCommand tsCmd = new SqlCommand("spTSNFindPlaceInRect", tsCon.Connection);
			tsCmd.CommandType = CommandType.StoredProcedure;


			// fill the parameters collection based upon stord procedure
			SqlParameter workParam = null;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dUpperLeftLon", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dUpperLeftLat", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dLowerRightLon", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dLowerRightLat", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@PlaceTypeId", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@MaxPlaces", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			tsCmd.Parameters["@dUpperLeftLon"].Value			= upperleft.Lon;
			tsCmd.Parameters["@dUpperLeftLat"].Value			= upperleft.Lat;
			tsCmd.Parameters["@dLowerRightLon"].Value			= lowerright.Lon;
			tsCmd.Parameters["@dLowerRightLat"].Value			= lowerright.Lat;
			tsCmd.Parameters["@PlaceTypeId"].Value				= (int)ptype;
			tsCmd.Parameters["@MaxPlaces"].Value				= MaxItems;

			try
			{
				tsCon.Open(0);					// Open any available database
				reader = tsCmd.ExecuteReader();

				while (reader.Read())
				{
					iRowType = reader.GetInt32(0);
					if(iRowType != 1) 
						break;
					placeFacts[i].Place.City			= reader.GetString(5);
					placeFacts[i].Place.State			= reader.GetString(6);
					placeFacts[i].Place.Country			= reader.GetString(7);
					placeFacts[i].Center.Lon			= reader.GetFloat(3);
					placeFacts[i].Center.Lat			= reader.GetFloat(4);
					placeFacts[i].AvailableThemeMask	= (Themes)0; //reader.GetInt32(18);
					placeFacts[i].PlaceTypeId			= (PlaceType)reader.GetInt32(9);
					placeFacts[i].Population			= reader.GetInt32(11);				// Population
					i++;
					if(i == MaxItems) break;
					if(!reader.NextResult()) break;
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				if (tsCon  != null) tsCon.Close();
			}
			if(i==0) 
			{
				placeFacts[i].Place.City			= "City field"; //reader.GetString(5);
				placeFacts[i].Place.State			= "State field"; //reader.GetString(6);
				placeFacts[i].Place.Country			= "Country field"; //reader.GetString(7);
				placeFacts[i].Center.Lon			= 0.0;  //reader.GetFloat(3);
				placeFacts[i].Center.Lat			= 0.0; // reader.GetFloat(4);
				placeFacts[i].AvailableThemeMask	= (Themes)0; //reader.GetInt32(18);
				placeFacts[i].PlaceTypeId			= PlaceType.UnknownPlaceType; //(PlaceType)reader.GetInt32(15);
				placeFacts[i].Population			= -1; //reader.GetInt32(11);				// Population
				i++;
			}
			PlaceFacts[] pf = new PlaceFacts[i];
			Array.Copy(placeFacts, pf, i);
			return(pf);
		}
		/// <summary>
		/// Obtains the meta-data about a data Theme enum.
		/// </summary>
		/// <param name="theme">The data Theme to return meta-data about.</param>
		/// <returns>A ThemeInfo structure containing the meta-data facts.</returns>
		[WebMethod]
		public ThemeInfo GetTheme(Theme theme) 
		{

			ThemeInfo ti = new ThemeInfo();
			switch(theme)
			{
				case Theme.Photo:
					ti.Theme			= Theme.Photo;
					ti.Name				= "Photo";
					ti.Description		= "DOQ, Digital Ortho Quadrangle";
					ti.Supplier			= "USGS";
					ti.LoScale			= Scale.Scale1m;
					ti.HiScale			= Scale.Scale64m;
					ti.ProjectionId		= ProjectionType.UtmNad83;
					ti.ProjectionName	= "UTM NAD83";
					break;
				case Theme.Topo:
					ti.Theme			= Theme.Topo;
					ti.Name				= "Topo";
					ti.Description		= "DRG, Digital Raster Graphics";
					ti.Supplier			= "USGS";
					ti.LoScale			= Scale.Scale2m;
					ti.HiScale			= Scale.Scale128m;
					ti.ProjectionId		= ProjectionType.UtmNad83;
					ti.ProjectionName	= "UTM NAD83";
					break;
				case Theme.Relief:
					ti.Theme			= Theme.Relief;
					ti.Name				= "Relief";
					ti.Description		= "DEM, Digital Elevation Model";
					ti.Supplier			= "USGS";
					ti.LoScale			= Scale.Scale32m;
					ti.HiScale			= Scale.Scale16km;
					ti.ProjectionId		= ProjectionType.Geographic;
					ti.ProjectionName	= "Geographic";
					break;
				default:
					throw new Exception("Invalid theme");
			}
			return(ti);
		}
		/// <summary>
		/// GetTileMetaFromLonLatPt returns the longitude and latitude corner points for
		/// the tile in the specified Theme and Scale that overlaps the point longitude and latitude.
		/// </summary>
		/// <param name="point">The longitude and latitude point within the tile of interest.</param>
		/// <param name="theme">The data Theme of the Tile to search for.</param>
		/// <param name="scale">The image resolution Scale of the Tile to search for.</param>
		/// <returns>A TileMeta structure of meta-data.</returns>
		[WebMethod] 
		public TileMeta GetTileMetaFromLonLatPt(LonLatPt point, Theme theme, Scale scale) 
		{

			TerraServerUtility.ValidateScale(theme, scale);
			TerraServerUtility.ValidateLonLatPt(point);

			TileMeta tm = new TileMeta();
			SqlDataReader reader = null;
			// Create a new Connection and DataSetCOmmand
			//SqlConnection tsCon = new SqlConnection("server=fab4web;uid=ts4_dbo;pwd=;database=ts4");
			TerraServerConnection tsCon = new TerraServerConnection();	// SqlConnection("server=fab4web;uid=ts4_dbo;pwd=;database=ts4");

			//string szQuery = "exec spTSNTileMetaByPt " + theme + "," + scale + "," + point.Lon + "," + point.Lat;
			//SqlCommand mySqlCommand = new SqlCommand(szQuery, tsCon);
			SqlCommand tsCmd = new SqlCommand("spTSNTileMetaByPt", tsCon.Connection);
			tsCmd.CommandType = CommandType.StoredProcedure;

			// fill the parameters collection based upon stord procedure
			SqlParameter workParam = null;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iTheme", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iScale", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dLon", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@dLat", SqlDbType.Float));
			workParam.Direction = ParameterDirection.Input;


			tsCmd.Parameters["@iTheme"].Value			= (int)theme;
			tsCmd.Parameters["@iScale"].Value			= (int)scale;
			tsCmd.Parameters["@dLon"].Value				= point.Lon;
			tsCmd.Parameters["@dLat"].Value				= point.Lat;
			//	Ordinal Field Name map:
			//		FoundFlag(0), Theme (1), Scale(2), X(3), Y(4), Zone(5), Version(6), DisplayStatus(7),
			//		EncryptKey(8), ImgTypeId(9), ProdStatus(10), BlankValue(11), PlaceId(12),
			//		XSearch(13), YSearch(14), PixWidth(15), PixHeight(16), PixDepth(17), ModifierId(18),
			//		CNLon(19), CNLat(20), NWLon(21), NWLat(22), NELon(23), NELat(24), SELon(25), SELat(26)
			//		SWLon(27), SWLat(28), ImageDate(29), InsertDate(30), ChangeDate(31), OrigMetaTag(32),
			//		ImageFilename(33), PlaceName(34), XOffset(35), YOffset(36), ExecMs(37), StartTime(38), EndTime(39)
			//

			try
			{
				tsCon.Open(theme, 10);					// Open specific database, TODO: Need to fix scene here
				reader = tsCmd.ExecuteReader();

				while (reader.Read())
				{
					tm.Id.Theme				= (Theme) reader.GetInt32(1);
					tm.Id.Scale				= (Scale) reader.GetInt32(2);
					tm.Id.Scene				= reader.GetInt32(5);
					tm.Id.X					= reader.GetInt32(3);
					tm.Id.Y					= reader.GetInt32(4);
					if(reader.GetInt32(0) == 1) 
					{
						tm.TileExists		= true;
					} 
					else 
					{
						tm.TileExists		= false;
					}
					tm.NorthWest.Lon		= reader.GetFloat(21);
					tm.NorthWest.Lat		= reader.GetFloat(22);
					tm.NorthEast.Lon		= reader.GetFloat(23);
					tm.NorthEast.Lat		= reader.GetFloat(24);
					tm.SouthEast.Lon		= reader.GetFloat(25);
					tm.SouthEast.Lat		= reader.GetFloat(26);
					tm.SouthWest.Lon		= reader.GetFloat(27);
					tm.SouthWest.Lat		= reader.GetFloat(28);
					tm.Center.Lon			= reader.GetFloat(19);
					tm.Center.Lat			= reader.GetFloat(20);
					tm.Capture				= (DateTime)reader.GetSqlDateTime(29); //Convert.ToDateTime(reader["ImageDate"].ToString());
					break;
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				if (tsCon  != null) tsCon.Close();
			}
			return(tm);
		}
		/// <summary>
		/// GetTileMetaFromTileId returns the meta-data for a tile using the Tile's unique id as
		/// the search criteria.
		/// </summary>
		/// <param name="id">The five part unique tile identifier (Theme, Scale, X, Y, and Scene).</param>
		/// <returns>A TileMeta structure containing the tile's meta-data.</returns>
		[WebMethod]
		public TileMeta GetTileMetaFromTileId(TileId id) 
		{

			TerraServerUtility.ValidateScene(id.Theme, id.Scene);
			TerraServerUtility.ValidateScale(id.Theme, id.Scale);

			TileMeta tm = new TileMeta();
			SqlDataReader reader = null;
			// Create a new Connection and DataSetCOmmand
			//SqlConnection tsCon = new SqlConnection("server=fab4web;uid=ts4_dbo;pwd=;database=ts4");
			TerraServerConnection tsCon = new TerraServerConnection();	// SqlConnection("server=fab4web;uid=ts4_dbo;pwd=;database=ts4");

			//string szQuery = "exec spTSNTileMeta " + id.Theme + "," + id.Scale + "," + id.X + "," + id.Y + "," + id.Scene;
			//SqlCommand mySqlCommand = new SqlCommand(szQuery, tsCon);
			SqlCommand tsCmd = new SqlCommand("spTSNTileMeta", tsCon.Connection);
			tsCmd.CommandType = CommandType.StoredProcedure;

			// fill the parameters collection based upon stord procedure
			SqlParameter workParam = null;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iTheme", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iScale", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iX", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iY", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iZone", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iXOffset", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			workParam = tsCmd.Parameters.Add(new SqlParameter("@iYOffset", SqlDbType.Int));
			workParam.Direction = ParameterDirection.Input;

			tsCmd.Parameters["@iTheme"].Value			= (int)id.Theme;
			tsCmd.Parameters["@iScale"].Value			= (int)id.Scale;
			tsCmd.Parameters["@iX"].Value				= id.X;
			tsCmd.Parameters["@iY"].Value				= id.Y;
			tsCmd.Parameters["@iZone"].Value			= id.Scene;
			tsCmd.Parameters["@iXOffset"].Value			= 0;
			tsCmd.Parameters["@iYOffset"].Value			= 0;

			//	Ordinal Field Name map:
			//		FoundFlag(0), Theme (1), Scale(2), X(3), Y(4), Zone(5), Version(6), DisplayStatus(7),
			//		EncryptKey(8), ImgTypeId(9), ProdStatus(10), BlankValue(11), PlaceId(12),
			//		XSearch(13), YSearch(14), PixWidth(15), PixHeight(16), PixDepth(17), ModifierId(18),
			//		CNLon(19), CNLat(20), NWLon(21), NWLat(22), NELon(23), NELat(24), SELon(25), SELat(26)
			//		SWLon(27), SWLat(28), ImageDate(29), InsertDate(30), ChangeDate(31), OrigMetaTag(32),
			//		ImageFilename(33), PlaceName(34), XOffset(35), YOffset(36), ExecMs(37), StartTime(38), EndTime(39)
			//
			try
			{
				tsCon.Open(id.Theme, id.Scene);				// Open specific database
				reader = tsCmd.ExecuteReader();

				while (reader.Read())
				{
					tm.Id.Theme				= (Theme) reader.GetInt32(1);
					tm.Id.Scale				= (Scale) reader.GetInt32(2);
					tm.Id.Scene				= reader.GetInt32(5);
					tm.Id.X					= reader.GetInt32(3);
					tm.Id.Y					= reader.GetInt32(4);
					if(reader.GetInt32(0) == 1) 
					{
						tm.TileExists		= true;
					} 
					else 
					{
						tm.TileExists		= false;
					}
					tm.NorthWest.Lon		= reader.GetFloat(21);
					tm.NorthWest.Lat		= reader.GetFloat(22);
					tm.NorthEast.Lon		= reader.GetFloat(23);
					tm.NorthEast.Lat		= reader.GetFloat(24);
					tm.SouthEast.Lon		= reader.GetFloat(25);
					tm.SouthEast.Lat		= reader.GetFloat(26);
					tm.SouthWest.Lon		= reader.GetFloat(27);
					tm.SouthWest.Lat		= reader.GetFloat(28);
					tm.Center.Lon			= reader.GetFloat(19);
					tm.Center.Lat			= reader.GetFloat(20);
					tm.Capture				= (DateTime)reader.GetSqlDateTime(29); //Convert.ToDateTime(reader["ImageDate"].ToString());
					break;
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				if (tsCon  != null) tsCon.Close();
			}
			return(tm);
		}
		/// <summary>
		/// GetTile returns a byte array containing the compressed pixels of the image tile.  The
		/// format is either Jpeg or GIF.  TerraServer only returns GIF tiles for Scale2m, Scale8m,
		/// and Scale32m Topographic map data.  All other tiles are Jpeg format.
		/// </summary>
		/// <param name="id">The five part unique tile identifier (Theme, Scale, X, Y, and Scene).</param>
		[WebMethod]
		public Byte[] GetTile(TileId id) 
		{
			int imglen;
			Byte[] imgdata = null;

			SqlDataReader reader = null;
			// Create a new Connection and DataSetCommand
			TerraServerConnection tsCon = new TerraServerConnection();

			string szQuery = "exec spTSTile " + (Int32)id.Theme + "," + (Int32)id.Scale + "," + id.X + "," + id.Y + "," + id.Scene;
			SqlCommand mySqlCommand = new SqlCommand(szQuery, tsCon.Connection);

			try
			{
				tsCon.Open(id.Theme, id.Scene);					// Open any Database partition
				reader = mySqlCommand.ExecuteReader();

				while (reader.Read())
				{
					imglen = Convert.ToInt32(reader[1].ToString());
					imgdata = (Byte[]) reader[2];
					break;
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				if (tsCon  != null) tsCon.Close();
			}

			return(imgdata);
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
