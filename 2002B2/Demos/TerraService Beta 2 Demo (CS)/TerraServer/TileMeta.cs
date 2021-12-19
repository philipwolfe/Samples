// Copyright (C) Microsoft Corporation.  All Rights reserved.
// TileMeta.cs
//

namespace TerraServer 
{

    using System;
	using GeoCoordinate;

    /// <summary>
    ///  Information about an individual tile in the database
    /// </summary>
    public struct TileMeta {
		/// <summary>
		/// The unique identifier for a tile within the TerraServer system.
		/// </summary>
        public TileId   Id;
		/// <summary>
		/// A boolean flag indicating the presence of the tile in the TerraServer database.  True means the tile exists and can be retrieved.
		/// False means the tile does not exist and cannot be retreived.
		/// </summary>
        public Boolean  TileExists;
		/// <summary>
		/// The longitude and latitude value of pixel 0,0 within the tile (top left corner point).
		/// </summary>
        public LonLatPt NorthWest;
		/// <summary>
		/// The longitude and latitude value of pixel 200,0 within the tile (top right corner point).
		/// </summary>
        public LonLatPt NorthEast;
		/// <summary>
		/// The longitude and latitude value of pixel 0,200 within the tile (lower left corner point).
		/// </summary>
        public LonLatPt SouthWest;
		/// <summary>
		/// The longitude and latitude value of pixel 200,200 within the tile (lower right corner point).
		/// </summary>
        public LonLatPt SouthEast;
		/// <summary>
		/// The longitude and latitude value of pixel 100,100 within the tile (center point).
		/// </summary>
        public LonLatPt Center;
		/// <summary>
		/// The capture or print date of the tile.
		/// </summary>
        public DateTime Capture;
    }
}
