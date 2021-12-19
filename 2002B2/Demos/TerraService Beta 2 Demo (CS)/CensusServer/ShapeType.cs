// Copyright (C) Microsoft Corporation.  All Rights reserved.
// ShapeType.cs
//

namespace CensusServer 
{

    using System;

    /// <summary>
    ///  Type of Geometric Shapes known to the Census Server
    /// </summary>



	public enum ShapeType {
		/// <summary>
		/// Unknown (null) shape
		/// </summary>
		Null = 0,
		/// <summary>
		/// Point shape
		/// </summary>
		Point = 1,
		/// <summary>
		/// PolyLine shape
		/// </summary>
		PolyLine = 3,	
		/// <summary>
		/// Polygon shape
		/// </summary>
		Polygon = 5
	}
}