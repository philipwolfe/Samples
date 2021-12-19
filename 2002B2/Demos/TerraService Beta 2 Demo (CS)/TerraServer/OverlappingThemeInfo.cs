// Copyright (C) Microsoft Corporation.  All Rights reserved.
// OverlappingThemeInfo.cs
//
namespace TerraServer 
{

    using System;
	using GeoCoordinate;
    /// <summary>
    ///  The other Theme's at this web site that overlap another 
    /// </summary>
	public struct OverlappingThemeInfo {
		/// <summary>
		/// True if the data theme is stored within the local TerraServer database.  It
		/// can be assumed that the Url field contains the same baseref.  False implies that the Url field
		/// points to a remote web server in the "network" of cooperating TerraServers.
		/// </summary>
		public Boolean    LocalTheme;
		/// <summary>
		/// An Enum that identifies the type of imagery.  <see cref="TerraServer.Theme"/>
		/// </summary>
		public Theme      Theme;
		/// <summary>
		/// Longitude and Latitude point described by this OverlappingThemeInfo structure. 
		/// </summary>
		public LonLatPt   Point;
		/// <summary>
		/// Text description/name for the imagery data theme.  
		/// </summary>
		public String     ThemeName;
		/// <summary>
		/// Date and time the imagery was captured or printed.
		/// </summary>
		public DateTime   Capture;
		/// <summary>
		/// Enum that identifies the map projection of the data theme.  <see cref="TerraServer.ProjectionType"/>
		/// </summary>
		public ProjectionType ProjectionId;
		/// <summary>
		/// Identifies the lowest image resolution scale value for the data theme maintained within the database.  <see cref="TerraServer.Scale"/>
		/// </summary>
		public Scale      LoScale;
		/// <summary>
		/// Identifies the highest image resolution scale value for the data theme maintained within the database.  <see cref="TerraServer.Scale"/>
		/// </summary>
		public Scale      HiScale;
		/// <summary>
		/// Identifies the baseref of the cooperating TerraServer web site.  Applicable only when LocalTheme is false.
		/// </summary>
		public String     Url;				// Link to the remote web server

	}
}