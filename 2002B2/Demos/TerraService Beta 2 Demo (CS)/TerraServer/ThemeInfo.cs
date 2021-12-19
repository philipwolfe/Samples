// Copyright (C) Microsoft Corporation.  All Rights reserved.
// ThemeInfo.cs
//

namespace TerraServer 
{

    using System;

    /// <summary>
    ///  Formal description of a data theme
    /// </summary>
    public struct ThemeInfo {
		/// <summary>
		/// Enum assigned to the data theme.  <see cref="TerraServer.Theme"/>
		/// </summary>
        public Theme  Theme;
		/// <summary>
		/// Formal text string to use when displaying the data theme
		/// </summary>
        public String Name;
		/// <summary>
		/// Longer text description of the data theme
		/// </summary>
        public String Description;
		/// <summary>
		/// Formal name of the organization or company providing the data.
		/// </summary>
        public String Supplier;
		/// <summary>
		/// The lowest resolution maintained in the TerraServer database for this data theme.
		/// </summary>
        public Scale  LoScale;
		/// <summary>
		/// The highest resolution maintained in the TerraServer database for this data theme.
		/// </summary>
        public Scale  HiScale;
		/// <summary>
		/// The enum identifying the map projection of the data theme.
		/// </summary>
        public ProjectionType ProjectionId;
		/// <summary>
		/// A text description of the map projection of the data theme.
		/// </summary>
        public String ProjectionName;
		/// <summary>
		/// The copyright or courtesy notice to be displayed with the imagery as required by the Supplier.
		/// </summary>
        public String CopyrightNotice;
    }
}
