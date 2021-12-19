// Copyright (C) Microsoft Corporation.  All Rights reserved.
// Scale.cs
//

namespace TerraServer 
{

    using System;

    /// <summary>
    ///  Identifies image resolution or ground area covered by each side of a pixel.
    /// </summary>
    public enum Scale {
		/// <summary>
		/// Image resolution of 1/1024th meter per pixel
		/// </summary>
        Scale1mm   =  0,	
		/// <summary>
		/// Image resolution of 1/512th meter per pixel
		/// </summary>
		Scale2mm   =  1,
		/// <summary>
		/// Image resolution of 1/256th meter per pixel
		/// </summary>
		Scale4mm   =  2,
		/// <summary>
		/// Image resolution of 1/128th meter per pixel
		/// </summary>
		Scale8mm   =  3,
		/// <summary>
		/// Image resolution of 1/64th meter per pixel
		/// </summary>
		Scale16mm  =  4,
		/// <summary>
		/// Image resolution of 1/32nd meter per pixel
		/// </summary>
		Scale32mm  =  5,
		/// <summary>
		/// Image resolution of 1/16th meter per pixel
		/// </summary>
		Scale63mm  =  6,
		/// <summary>
		/// Image resolution of 1/8th meter per pixel
		/// </summary>
		Scale125mm =  7,
		/// <summary>
		/// Image resolution of 1/4 meter per pixel
		/// </summary>
		Scale250mm =  8,
		/// <summary>
		/// Image resolution of 1/2 meter per pixel
		/// </summary>
		Scale500mm =  9,
		/// <summary>
		/// Image resolution of 1 meter per pixel
		/// </summary>
		Scale1m    = 10,
		/// <summary>
		/// Image resolution of 2 meters per pixel
		/// </summary>
		Scale2m    = 11,
		/// <summary>
		/// Image resolution of 4 meters per pixel
		/// </summary>
		Scale4m    = 12,
		/// <summary>
		/// Image resolution of 8 meters per pixel
		/// </summary>
		Scale8m    = 13,
		/// <summary>
		/// Image resolution of 16 meters per pixel
		/// </summary>
		Scale16m   = 14,
		/// <summary>
		/// Image resolution of 32 meters per pixel
		/// </summary>
		Scale32m   = 15,
		/// <summary>
		/// Image resolution of 64 meters per pixel
		/// </summary>
		Scale64m   = 16,
		/// <summary>
		/// Image resolution of 128 meters per pixel
		/// </summary>
		Scale128m  = 17,
		/// <summary>
		/// Image resolution of 256 meters per pixel
		/// </summary>
		Scale256m  = 18,
		/// <summary>
		/// Image resolution of 512 meters per pixel
		/// </summary>
		Scale512m  = 19,
		/// <summary>
		/// Image resolution of 1 kilometer per pixel
		/// </summary>
		Scale1km   = 20,
		/// <summary>
		/// Image resolution of 2 kilometers per pixel
		/// </summary>
		Scale2km   = 21,
		/// <summary>
		/// Image resolution of 4 kilometers per pixel
		/// </summary>
		Scale4km   = 22,
		/// <summary>
		/// Image resolution of 8 kilometers per pixel
		/// </summary>
		Scale8km   = 23,
		/// <summary>
		/// Image resolution of 16 kilometers per pixel
		/// </summary>
		Scale16km  = 24
    }
}
