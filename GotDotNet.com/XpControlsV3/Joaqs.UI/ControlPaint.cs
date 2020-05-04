using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Joaqs.UI
{
	internal sealed class ControlPaint
	{
		private ControlPaint()
		{
		}



		public static Color BorderColor
		{
			get { return Color.FromArgb(127, 157, 185); }
		}

		public static Color DisabledBorderColor
		{
			get { return Color.FromArgb(201, 199, 186); }
		}

		public static Color ButtonBorderColor
		{
			get { return Color.FromArgb(28, 81, 128); }
		}

		public static Color DisabledButtonBorderColor
		{
			get { return Color.FromArgb(202, 200, 187); }
		}

		public static Color DisabledBackColor
		{
			get { return Color.FromArgb(236, 233, 216); }
		}

		public static Color DisabledForeColor
		{
			get { return Color.FromArgb(161, 161, 146); }
		}



		public static StringFormat GetStringFormat(ContentAlignment contentAlignment)
		{
			if (!Enum.IsDefined(typeof(ContentAlignment), (int) contentAlignment))
				throw new System.ComponentModel.InvalidEnumArgumentException(
					"contentAlignment", (int) contentAlignment, typeof(ContentAlignment));

			StringFormat stringFormat = new StringFormat();
			
			switch (contentAlignment)
			{
				case ContentAlignment.MiddleCenter:
					stringFormat.LineAlignment = StringAlignment.Center;
					stringFormat.Alignment = StringAlignment.Center;
					break;

				case ContentAlignment.MiddleLeft:
					stringFormat.LineAlignment = StringAlignment.Center;
					stringFormat.Alignment = StringAlignment.Near;
					break;

				case ContentAlignment.MiddleRight:
					stringFormat.LineAlignment = StringAlignment.Center;
					stringFormat.Alignment = StringAlignment.Far;
					break;

				case ContentAlignment.TopCenter:
					stringFormat.LineAlignment = StringAlignment.Near;
					stringFormat.Alignment = StringAlignment.Center;
					break;

				case ContentAlignment.TopLeft:
					stringFormat.LineAlignment = StringAlignment.Near;
					stringFormat.Alignment = StringAlignment.Near;
					break;

				case ContentAlignment.TopRight:
					stringFormat.LineAlignment = StringAlignment.Near;
					stringFormat.Alignment = StringAlignment.Far;
					break;

				case ContentAlignment.BottomCenter:
					stringFormat.LineAlignment = StringAlignment.Far;
					stringFormat.Alignment = StringAlignment.Center;
					break;

				case ContentAlignment.BottomLeft:
					stringFormat.LineAlignment = StringAlignment.Far;
					stringFormat.Alignment = StringAlignment.Near;
					break;

				case ContentAlignment.BottomRight:
					stringFormat.LineAlignment = StringAlignment.Far;
					stringFormat.Alignment = StringAlignment.Far;
					break;
			}

			return stringFormat;
		}

		/// <summary>
		/// Draws a rectangle with rounded edges.
		/// </summary>
		/// <param name="g">The System.Drawing.Graphics object to be used to draw the rectangle.</param>
		/// <param name="p">A System.Drawing.Pen object that determines the color, width, and style of the rectangle.</param>
		/// <param name="rc">A System.Drawing.Rectangle structure that represents the rectangle to draw.</param>
		/// <param name="size">Pixel indentation that determines the roundness of the corners.</param>
		public static void DrawRoundedRectangle(Graphics g, Pen p, Rectangle rc, Size size)
		{
			// 1 pixel indent in all sides = Size(4, 4)
			// To make pixel indentation larger, change by a factor of 4,
			// i. e., 2 pixels indent = Size(8, 8);

			SmoothingMode oldSmoothingMode = g.SmoothingMode;
			g.SmoothingMode = SmoothingMode.AntiAlias;
		
			g.DrawLine(p, rc.Left  + size.Width / 2, rc.Top,
				rc.Right - size.Width / 2, rc.Top);
			g.DrawArc(p, rc.Right - size.Width, rc.Top,
				size.Width, size.Height, 270, 90);

			g.DrawLine(p, rc.Right, rc.Top + size.Height / 2,
				rc.Right, rc.Bottom - size.Height / 2);
			g.DrawArc(p, rc.Right - size.Width, rc.Bottom - size.Height,
				size.Width, size.Height, 0, 90);

			g.DrawLine(p, rc.Right - size.Width / 2, rc.Bottom,
				rc.Left  + size.Width / 2, rc.Bottom);
			g.DrawArc(p, rc.Left, rc.Bottom - size.Height, 
				size.Width, size.Height, 90, 90);

			g.DrawLine(p, rc.Left, rc.Bottom - size.Height / 2,
				rc.Left, rc.Top + size.Height / 2);
			g.DrawArc(p, rc.Left, rc.Top,
				size.Width, size.Height, 180, 90);

			g.SmoothingMode = oldSmoothingMode;
		}

		public static void DrawBorder(Graphics g, int x, int y, int width, int height)
		{
			g.DrawRectangle(new Pen(ControlPaint.BorderColor, 0), x, y, 
				width, height);
		}

		public static void EraseExcessOldDropDown(Graphics g, Rectangle newButton)
		{
			g.FillRectangle(new SolidBrush(SystemColors.Window), newButton.X - 2, newButton.Y,
				2, newButton.Height + 1);
		}

		public static void DrawArrow(Graphics g, Rectangle rc, ArrowDirection ad, ControlState cs)
		{
			DropDownColors colors = new DropDownColors(cs);

			Rectangle rcClip = new Rectangle(rc.X, rc.Y, rc.Width + 2, rc.Height + 1);
			Region oldClip = g.Clip;
			g.SetClip(new Region(rcClip), CombineMode.Replace);

			// Border
			LinearGradientBrush brsBorderTop = new LinearGradientBrush(
				rc, colors.TopLeft1, colors.TopLeft2, LinearGradientMode.Horizontal);
			g.DrawLine(new Pen(brsBorderTop, 0), rc.Left, rc.Top, rc.Right, rc.Top);
			brsBorderTop.Dispose();

			LinearGradientBrush brsBorderLeft = new LinearGradientBrush(
				rc, colors.TopLeft1, colors.TopLeft2, LinearGradientMode.Vertical);
			g.DrawLine(new Pen(brsBorderLeft, 0), rc.Left, rc.Top, rc.Left, rc.Bottom);
			brsBorderLeft.Dispose();

			g.DrawLines(new Pen(colors.BottomRight), new Point[] {
				new Point(rc.Right, rc.Top), new Point(rc.Right, rc.Bottom),
				new Point(rc.Left, rc.Bottom) });

			// Corners
			Pen corner = new Pen(colors.Corner, 0);
			g.DrawLine(corner, rc.Left, rc.Top - 1, rc.Left, rc.Top);
			g.DrawLine(corner, rc.Right, rc.Top - 1, rc.Right, rc.Top);
			g.DrawLine(corner, rc.Left, rc.Bottom, rc.Left, rc.Bottom + 1);
			g.DrawLine(corner, rc.Right, rc.Bottom, rc.Right, rc.Bottom + 1);

			// Body
			Rectangle rcBody = new Rectangle(rc.Left + 1, rc.Top + 1, rc.Width - 1,
				rc.Height - 1);
			LinearGradientBrush brsBody = new LinearGradientBrush(rcBody, 
				colors.Body1, colors.Body2, LinearGradientMode.ForwardDiagonal);
			g.FillRectangle(brsBody, rcBody);

			// Arrow
			System.Text.StringBuilder img = new System.Text.StringBuilder(
				"Joaqs.UI.Arrows." + ad.ToString(), 64);
			if (cs == ControlState.Disabled)
				img.Append(" Disabled");
			img.Append(".gif");

			Bitmap b = new Bitmap(typeof(ControlPaint).Assembly.GetManifestResourceStream(img.ToString()));
			int x = rc.X + ((rc.Width - b.Width) / 2);
			int y = rc.Y + ((rc.Height - b.Height) / 2);
			
			if (rc.Width > b.Width) x++;
			if (rc.Height > b.Height) y++;
			
			g.DrawImage(b, x, y);
			b.Dispose();
			
			g.Clip = oldClip;
		}

	}

}
