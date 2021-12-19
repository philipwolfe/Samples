// Copyright (C) Microsoft Corporation.  All Rights reserved.
// PlaceType.cs
//

namespace TerraServer 
{

    using System;

    /// <summary>
    ///  Type of named place maintained in the TerraServer gazetteer.
    /// </summary>
    public enum PlaceType {
		/// <summary>
		/// Unknown place type
		/// </summary>
        UnknownPlaceType	=  0,
		/// <summary>
		/// Named place is a Air or Railroad station
		/// </summary>
		AirRailStation		=  1,
		/// <summary>
		/// Named place is a bay or gulf
		/// </summary>
		BayGulf				=  2,
		/// <summary>
		/// Named place is a cape or peninsula
		/// </summary>
		CapePeninsula		=  3,
		/// <summary>
		/// Named place is a populated town, city or other muncipality
		/// </summary>
		CityTown			=  4,
		/// <summary>
		/// Named place is a mountain or hill
		/// </summary>
		HillMountain		=  5,
		/// <summary>
		/// Named place is an Island
		/// </summary>
		Island				=  6,
		/// <summary>
		/// Named place is a Lake
		/// </summary>
		Lake				=  7,
		/// <summary>
		/// Named place is a land feature other than town, city, municpality, island, cape or peninsula
		/// </summary>
		OtherLandFeature	=  8,
		/// <summary>
		/// Named place is a water feature other than a River or Lake
		/// </summary>
		OtherWaterFeature	=  9,
		/// <summary>
		/// Named place is a park or beach
		/// </summary>
		ParkBeach			= 10,
		/// <summary>
		/// Named place is a general point of interest
		/// </summary>
		PointOfInterest		= 11,
		/// <summary>
		/// Named place is a River
		/// </summary>
		River				= 12
    }
}
