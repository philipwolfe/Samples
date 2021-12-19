// Copyright (C) Microsoft Corporation.  All Rights Reserved.
// imageObj.cs

using System;
using System.Drawing;
using System.Drawing.Imaging;

class imageObj
{
	public Image tile;
	public Int32 x, y;

	public imageObj (Image i, Int32 xx, Int32 yy)
	{
		tile = i;			// Image tile to draw
		x = xx;				// pixel location of image
		y = yy;
	}
}