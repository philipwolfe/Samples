using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

namespace SpaceWar
{
	class PenCache
	{
		Hashtable pens = new Hashtable();

		public Pen GetPen(int rgbValue)
		{
			Pen pen = (Pen) pens[rgbValue];
			if (pen == null)
			{
				pen = new Pen(Color.FromArgb(rgbValue, 0, 0), 2.0f);
				pen.LineJoin = LineJoin.Miter;

				pens[rgbValue] = pen;
			}
			return(pen);
		}
	}
}
