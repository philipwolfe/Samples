// Copyright (C) Microsoft Corporation.  All Rights reserved.
// AreaCoordinate.cs
//

namespace TerraServer 
{

    using System;

    /// <summary>
    ///  A tile describing the corner or center of a "table" of tiles.  It is a sub-structure of the AreaBoundingBox structure. <see cref="TerraServer.AreaBoundingBox"/>
    /// </summary>

    public struct AreaCoordinate {
		/// <summary>
		/// Meta-data describing the TerraServer Tile
		/// </summary>
        public TileMeta TileMeta;
		/// <summary>
		/// Identifies the specific pixel of a longitude and latitude within "this" tile.  Use this information to "crop" a table of tiles into single well-known latitude and longitude range.
		/// </summary>
        public LonLatPtOffset Offset;

    }
}
