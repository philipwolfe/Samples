// Copyright (C) Microsoft Corporation.  All Rights reserved.
// AreaBoundingBox.cs
//

namespace TerraServer 
{

    using System;

    /// <summary>
    ///  The edges and center tiles of a tile "table".
    /// </summary>
    public struct AreaBoundingBox {
		/// <summary>
		/// Meta-data describing the top-left-corner of the Tile table.
		/// </summary>
        public AreaCoordinate         NorthWest;
		/// <summary>
		/// Meta-data describing the top-right-corner of the Tile table.
		/// </summary>
		public AreaCoordinate         NorthEast;
		/// <summary>
		/// Meta-data describing the bottom-left-corner of the Tile table.
		/// </summary>
		public AreaCoordinate         SouthWest;
		/// <summary>
		/// Meta-data describing the bottom-right-corner of the Tile table.
		/// </summary>
		public AreaCoordinate         SouthEast;
		/// <summary>
		/// Meta-data describing the center of the Tile table.
		/// </summary>
		public AreaCoordinate         Center;
		/// <summary>
		/// Text string identifying the nearest city/town to the longitude/latitude offset in the Center "tile".
		/// </summary>
		public String                 NearestPlace;
		/// <summary>
		/// Array of other imagery data themes available over the longitude/latitude offset in the Center "tile".
		/// </summary>
        public OverlappingThemeInfo[] OverlappingThemeInfos;

    }
}
