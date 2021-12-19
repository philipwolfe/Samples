// Copyright (C) Microsoft Corporation.  All Rights reserved.
// ProjectionType.cs
//

namespace TerraServer 
{

    using System;

    /// <summary>
	///	Identifies the map projection of a data theme within TerraServer
    /// </summary>
    public enum ProjectionType {

        /// <summary>
		///	Geographic projection is based on longitude and latitude
        /// </summary>
        Geographic = 0,

        /// <summary>
		/// UtmNad27 projection is Universe Transverse Mercator projection using the 
		/// North American Datum of 1927. 
        /// </summary>
        UtmNad27 = 27,

        /// <summary>
		/// UtmNad83 projection is Universe Transverse Mercator projection using the 
		/// North American Datum of 1983. 
        /// </summary>
        UtmNad83 = 83
    }
}
