// Copyright (C) Microsoft Corporation.  All Rights reserved.
// PlaceFacts.cs
//

namespace TerraServer 
{

    using System;
	using GeoCoordinate;

    /// <summary>
    ///  Information regarding a formal place entry in the TerraServer gazetteer.
    /// </summary>
    public struct PlaceFacts {
		/// <summary>
		/// Formal place name
		/// </summary>
        public Place     Place;
		/// <summary>
		/// The longitude and latitude recognized as the place's "center point" aka "centroid"
		/// </summary>
        public LonLatPt  Center;
		/// <summary>
		/// An enum/bit mask that identifies the available data themes in the TerraServer database for the named place's centroid.
		/// </summary>
        public Themes    AvailableThemeMask;
		/// <summary>
		/// An enum that identifies the type of named place, e.g. city, river, air/rail station, etc.
		/// </summary>
        public PlaceType PlaceTypeId;
		/// <summary>
		/// A rough estimate of the number of persons if this place represents a populated place.
		/// </summary>
        public Int32     Population;
    }
}
