// Copyright (C) Microsoft Corporation.  All Rights reserved.
// ThemeBoundingBox.cs
//

namespace TerraServer 
{

    using System;

    /// <summary>
    ///  The outside boundaries of a data Theme's scene.  More than one bounding box can exist per Theme.  
    ///  For example, USGS Aerial Photography has one ThemeBoundingBox per UTM Zone.
    /// </summary>
    public struct ThemeBoundingBox {
		/// <summary>
		/// Enum that identifies the imagery type and provider.  <see cref="TerraServer.Theme"/>
		/// </summary>
        public Theme      Theme;
		/// <summary>
		/// Text string/name of the imagery type and provider.
		/// </summary>
        public String     ThemeName;
		/// <summary>
		/// An integer percentage value, e.g. 10%, 25%, 100%, etc., identifying the amount of coverage in the bounding area.
		/// </summary>
        public Int32      Sparseness;
		/// <summary>
		/// The lowest image resolution maintained in the TerraServer database of this Theme and Bounding Area.  <see cref="TerraServer.Scale"/>
		/// </summary>
        public Scale      LoScale;
		/// <summary>
		/// The highest image resolution maintained in the TerraServer database of this Theme and Bounding Area.  <see cref="TerraServer.Scale"/>
		/// </summary>
        public Scale      HiScale;
		/// <summary>
		/// An enum identifying the map projection of the data theme.  <see cref="TerraServer.ProjectionType"/>
		/// </summary>
        public ProjectionType ProjectionId;
		/// <summary>
		/// Text string/description describing the map projection of the data theme.
		/// </summary>
        public String     ProjectionName;
		/// <summary>
		/// The west boundary's longitude value.
		/// </summary>
        public Double     WestLongitude;
		/// <summary>
		/// The north boundary's latitude value.
		/// </summary>
        public Double     NorthLatitude;
		/// <summary>
		/// The east boundary's longitude value.
		/// </summary>
        public Double     EastLongitude;
		/// <summary>
		/// The south boundary's latitude value.
		/// </summary>
        public Double     SouthLatitude;

    }
}
