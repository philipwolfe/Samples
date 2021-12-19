// Copyright (C) Microsoft Corporation.  All Rights reserved.
// CensusFacts.cs
//

namespace CensusServer 
{

    using System;
	using GeoCoordinate;

    /// <summary>
    ///  Census statistics returned from a query on a Census Political Unit
    /// </summary>

	public struct CensusFacts {
		/// <summary>
		/// Political Unit being reported
		/// </summary>
		public PoliticalUnit	Pu;
		/// <summary>
		/// The political unit's fips code
		/// </summary>
		public String		Fips;
		/// <summary>
		/// StateFips code, maybe = Fips code when pu = State
		/// </summary>
		public String		StateFips;
		/// <summary>
		/// County Fips code, maybe = Fips code when pu = County
		/// </summary>
		public String		CountyFips;	
		/// <summary>
		/// Name of the political unit, might be a Tract #
		/// </summary>
		public String		Name;
		/// <summary>
		/// Dependent on the Political Unit as to what this is
		/// </summary>
		public String		SecondaryName;
		/// <summary>
		/// Area in square miles
		/// </summary>
		public Double		Area; 
		/// <summary>
		/// Year of the census
		/// </summary>
		public Int32		Year;
		/// <summary>
		/// Population in 1990
		/// </summary>
		public Int32		Population1990;
		/// <summary>
		/// Population in 1999
		/// </summary>
		public Int32		Population1999;
		/// <summary>
		/// Population per square mile in 1990
		/// </summary>
		public Int32		Population1990_PerSquareMile;
		/// <summary>
		/// Number of households
		/// </summary>
		public Int32		Households;
		/// <summary>
		/// Number of males
		/// </summary>
		public Int32		Males;
		/// <summary>
		/// Number of females
		/// </summary>
		public Int32		Females;
		/// <summary>
		/// Number of whites
		/// </summary>
		public Int32		White;
		/// <summary>
		/// Number of Blacks
		/// </summary>
		public Int32		Black;
		/// <summary>
		/// Number of Native Americans
		/// </summary>
		public Int32		NativeAmericans;
		/// <summary>
		/// Number of Asian or Polynesian Islands
		/// </summary>
		public Int32		AsianPolynesianIslands;
		/// <summary>
		/// Number of Hispanics
		/// </summary>
		public Int32		Hispanic;
		/// <summary>
		/// Number of Other races
		/// </summary>
		public Int32		Other;
		/// <summary>
		/// Number under the age 0f 5
		/// </summary>
		public Int32		Age_Under5;
		/// <summary>
		/// Number between 5 and 17 inclusive
		/// </summary>
		public Int32		Age_5_17;
		/// <summary>
		///  Number between 18 and 29 inclusive
		/// </summary>
		public Int32		Age_18_29;
		/// <summary>
		/// Number between 30 and 49 inclusive
		/// </summary>
		public Int32		Age_30_49;
		/// <summary>
		/// Number between 50 and 64 inclusive
		/// </summary>
		public Int32		Age_50_64;
		/// <summary>
		/// Number 64 and over
		/// </summary>
		public Int32		Age_65_Up;
		/// <summary>
		/// Number that have never married
		/// </summary>
		public Int32		NeverMarry;
		/// <summary>
		///  Number of married individuals
		/// </summary>
		public Int32		Married;
		/// <summary>
		/// Number of separated individuals
		/// </summary>
		public Int32		Separated;
		/// <summary>
		/// Number of widowed individuals
		/// </summary>
		public Int32		Widowed;
		/// <summary>
		/// Number of divorced individuals
		/// </summary>
		public Int32		Divorced;
		/// <summary>
		///  Number of households with 1 male
		/// </summary>
		public Int32		HouseHolds_1Male;
		/// <summary>
		/// Number of households with 1 female
		/// </summary>
		public Int32		HouseHolds_1Female;
		/// <summary>
		/// Number of married households with 1 child
		/// </summary>
		public Int32		Married_Households_Child;
		/// <summary>
		/// Number of married households without children
		/// </summary>
		public Int32		Married_households_NoChild;
		/// <summary>
		/// Number of male head of households with child
		/// </summary>
		public Int32		Male_Households_Child;
		/// <summary>
		/// Number of female head of households with child
		/// </summary>
		public Int32		Female_HouseHolds_Child;
		/// <summary>
		/// Number of household units
		/// </summary>
		public Int32		Household_Units;
		/// <summary>
		/// Number of vacant dwellings
		/// </summary>
		public Int32		Vacant;
		/// <summary>
		/// Number of owner occupied dwellings
		/// </summary>
		public Int32		OwnerOccupied;
		/// <summary>
		/// Number of renter occupied dwellings
		/// </summary>
		public Int32		RenterOccupied;
		/// <summary>
		/// Median value of dwellings
		/// </summary>
		public Int32		MedianValue;
		/// <summary>
		/// Median value of rented dwellings
		/// </summary>
		public Int32		MedianRent;
		/// <summary>
		/// Number of single detached dwellings
		/// </summary>
		public Int32		Units_1Detach;
		/// <summary>
		/// Number of single attached dwellings
		/// </summary>
		public Int32		Units_1Attach;
		/// <summary>
		/// Number of 2 unit dwellings
		/// </summary>
		public Int32		Units_2;
		/// <summary>
		/// Number of 3 to 9 unit dwellings
		/// </summary>
		public Int32		Units_3_9;
		/// <summary>
		/// Number of 10 to 49 unit dwellings
		/// </summary>
		public Int32		Units_10_49;
		/// <summary>
		/// Number of 50 and higher unit dwellings
		/// </summary>
		public Int32		Units_50_Up;
		/// <summary>
		/// Number of mobile dwellings
		/// </summary>
		public Int32		MobileHome;
		/// <summary>
		/// Number of farms in 1987
		/// </summary>
		public Int32		No_Farms87;
		/// <summary>
		/// Average size in acres of 1987 farms
		/// </summary>
		public Int32		Avg_Farm_Size87;
		/// <summary>
		/// Average crops in acres in 1987
		/// </summary>
		public Int32		Crop_Acre87;
		/// <summary>
		/// Average sale price of a farm in 1987
		/// </summary>
		public Int32		Avg_Sale87;
		/// <summary>
		/// Type of shape when a polygon/point represents this object
		/// </summary>
		public ShapeType	Shape;
		/// <summary>
		/// Bounding geographic area of this political unit
		/// </summary>
		public BoundingRect	Rect;

	}
}