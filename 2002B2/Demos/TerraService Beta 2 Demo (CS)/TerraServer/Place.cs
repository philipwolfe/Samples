// Copyright (C) Microsoft Corporation.  All Rights reserved.
// Place.cs
//

namespace TerraServer 
{

    using System;

    /// <summary>
    ///  Formal components of a named place
    /// </summary>
    public struct Place {
		/// <summary>
		/// City or town's formal name
		/// </summary>
        public String City;
		/// <summary>
		/// The formal name of the State or Province
		/// </summary>
        public String State;
		/// <summary>
		/// The formal name of the Country 
		/// </summary>
        public String Country;
    }
}
