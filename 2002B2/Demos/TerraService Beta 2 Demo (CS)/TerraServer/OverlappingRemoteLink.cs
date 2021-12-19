// Copyright (C) Microsoft Corporation.  All Rights reserved.
// OverlappingRemoteLink.cs
//

namespace TerraServer 
{

    using System;

    /// <summary>
    ///  Link's to remote TerraServer web sites that overlap this point
    /// </summary>
    public struct OverlappingRemoteLink {
		/// <summary>
		/// Textual representation of the data Theme at the remote site
		/// </summary>
		public String   ThemeName;	
		/// <summary>
		/// Time the photo was captured, or topo map was printed
		/// </summary>
		public DateTime Capture;
		/// <summary>
		/// Link (URL) to the remote web server
		/// </summary>
		public String   Url; 
	}
}