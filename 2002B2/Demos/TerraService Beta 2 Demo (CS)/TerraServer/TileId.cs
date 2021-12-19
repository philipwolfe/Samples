// Copyright (C) Microsoft Corporation.  All Rights reserved.
// TileId.cs
//

namespace TerraServer 
{

    using System;

    /// <summary>
    ///  Formal and unique address of an image tile within TerraServer
    /// </summary>
    public struct TileId {
		/// <summary>
		/// The data theme of an image tile.  <see cref="TerraServer.Theme"/>
		/// </summary>
        public Theme Theme;
		/// <summary>
		/// The image resolution as measured by the ground area covered by a single pixel.  <see cref="TerraServer.Scale"/>
		/// </summary>
        public Scale Scale;
		/// <summary>
		/// The unique scene identifier for the theme.  If the data theme's map projection is UTM, then this will be the UTM Zone id.
		/// </summary>
        public Int32 Scene;
		/// <summary>
		///  The tile's relative number position from the "left edge" of the scene.  The position begins with tile 0.
		/// </summary>
        public Int32 X;
		/// <summary>
		///  The tile's relative number position from the bottom-edge of the scene.  The bottom position begins with tile 0.
		/// </summary>
        public Int32 Y;
    }
}
