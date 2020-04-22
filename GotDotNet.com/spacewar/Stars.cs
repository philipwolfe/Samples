using System;
using System.Drawing;
using DxVBLib;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for Stars.
	/// </summary>
	public class Stars
	{
		Star[] stars;

		public Stars(Rectangle screenBounds, int count)
		{
			stars = new Star[count];

			for (int i = 0; i < count; i++)
			{
				stars[i] = new Star(screenBounds);
			}
		}

		public void Draw(DirectDrawSurface7 surface)
		{
			surface.SetForeColor(Constants.StarColorFull);
			foreach (Star star in stars)
			{
				star.Draw(surface);
			}
			int index = Constants.random.Next(stars.Length);
			surface.SetForeColor(Constants.StarColorDim);
			stars[index].Draw(surface);
		}
	}
}
