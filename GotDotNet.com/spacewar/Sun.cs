using System;
using System.Drawing;
using DxVBLib;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for Sun.
	/// </summary>
	public class Sun
	{
		const int NumPoints = 16;
		const int NumLines = 8;
		
		Point center;
		Point[] ends = new Point[NumPoints];

		public Sun(Point center, int radius)
		{
			this.center = center;

			double angle = 0;
			double inc = 3.1415926535 * 2 / NumPoints;
			for (int i = 0; i < NumPoints; i++)
			{
				ends[i].X = (int) Math.Round(Math.Cos(angle) * radius) + center.X;
				ends[i].Y = (int) Math.Round(Math.Sin(angle) * radius) + center.Y;
				//Console.WriteLine("{0} {1}", i, ends[i]);
				angle += inc;
			}
		}

		public void Draw(DirectDrawSurface7 surface)
		{
			int dimLine = Constants.random.Next(NumLines);
			for (int i = 0; i < NumLines; i++)
			{
				if (i == dimLine)
					surface.SetForeColor(0x00AAAA);
				else
					surface.SetForeColor(0x00FFFF);
				surface.DrawLine(ends[i].X, ends[i].Y,
								 ends[i + NumLines].X, ends[i + NumLines].Y);
			}
		}
	}
}
