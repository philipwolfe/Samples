// Copyright (C) Microsoft Corporation.  All Rights reserved.
// Theme.cs
//

namespace TerraServer 
{

    using System;

    /// <summary>
    ///  Identifies the Type of image data and the provider
    /// </summary>
    public enum Theme {

        /// <summary>
        ///  USGS Digital Ortho Quadrangle (Aerial photograph)
        /// </summary>
        Photo = 1,

        /// <summary>
        ///  USGS Digital Raster Graphic (topographical map)
        /// </summary>
        Topo = 2,

        /// <summary>
        ///  Encarta Shaded relief map
        /// </summary>
        Relief = 0
    }
}
