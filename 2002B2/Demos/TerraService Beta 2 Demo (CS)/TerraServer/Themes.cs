// Copyright (C) Microsoft Corporation.  All Rights reserved.
// Themes.cs
//

namespace TerraServer 
{

    using System;

    /// <summary>
    ///  Bit mask identifying the data themes supported
    /// </summary>
    [Flags]
    public enum Themes {

        /// <summary>
        ///  USGS Digital Ortho Quadrangle (Aerial photograph)
        /// </summary>
        Photo = 1,

        /// <summary>
        ///  USGS Digital Raster Graphic (topographical map)
        /// </summary>
        Topo = 2,

        /// <summary>
        ///  Shaded relief map
        /// </summary>
        Relief = 4
    }
}
