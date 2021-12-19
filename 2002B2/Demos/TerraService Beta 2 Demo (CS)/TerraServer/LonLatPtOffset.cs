// Copyright (C) Microsoft Corporation.  All Rights reserved.
// LonLatPtOffset.cs
//

namespace TerraServer 
{

    using System;
	using GeoCoordinate;
	/// <summary>
    ///  Location within a tile of a longitude and latitude
    /// </summary>
    public struct LonLatPtOffset 
	{
		/// <summary>
		/// Longitude and Latitude on the ground of the specified pixel
		/// </summary>
        public LonLatPt Point;
		/// <summary>
		/// Pixel offset within a TerraServer tile from the left edge of the Longitude and Latitude
		/// </summary>
        public Int32    XOffset;
		/// <summary>
		/// Pixel offset within a TerraServer tile from the top edge of the Longitude and Latitude
		/// </summary>
        public Int32    YOffset;
    }
}
