// Copyright (C) Microsoft Corporation.  All Rights reserved.
// PoliticalUnit.cs
//

namespace CensusServer 
{

    using System;

    /// <summary>
    ///  Type of Geo-Political "thing" for which there is census information
    /// </summary>


	public enum PoliticalUnit {	
		/// <summary>
		/// Unknown/unspecified PoliticalUnit
		/// </summary>
		Unknown,
		/// <summary>
		///  State government
		/// </summary>
		State,
		/// <summary>
		/// County government
		/// </summary>
		County,
		/// <summary>
		/// City
		/// </summary>
		City,
		/// <summary>
		/// Census Bureau Tract
		/// </summary>
		CensusTract
	}
}