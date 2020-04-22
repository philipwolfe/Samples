using System;
using System.Drawing;
using DxVBLib;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for Star.
	/// </summary>
	public class Star
	{
		Point location;

		public Star(Rectangle screenBounds)
		{
			location.X = Constants.random.Next(screenBounds.Width) + screenBounds.X;
			location.Y = Constants.random.Next(screenBounds.Height) + screenBounds.Y;
		}

		public void Draw(DirectDrawSurface7 surface)
		{
			surface.DrawLine(location.X, location.Y, location.X + 1, location.Y + 1);
		}
	}
}
