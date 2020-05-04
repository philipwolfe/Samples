using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region GdiRect
	internal class GdiRect
	{
		#region class variables
		int FTop;
		int FRight;
		int FBottom;
		int FLeft;
		#endregion

		#region class properties
		public int Top
		{
			get
			{
				return FTop;
			}
			set
			{
				FTop=value;
			}
		}
		public int Bottom
		{
			get
			{
				return FBottom;
			}
			set
			{
				FBottom=value;
			}
		}
		public int Left
		{
			get
			{
				return FLeft;
			}
			set
			{
				FLeft=value;
			}
		}
		public int Right
		{
			get
			{
				return FRight;
			}
			set
			{
				FRight=value;
			}
		}
		#endregion
	}
	#endregion

	#region enums
	public enum ShapeType
	{
		None, Rectangle,
		Ellipse, Circle, Valve,ValveUp,House,
		TriangleRight,TriangleUp,TriangleLeft,TriangleDown,
		ArrowRight,ArrowUp,ArrowLeft,ArrowDown,
		Diamond, Octagon,Hexagon,HexagonFlat,
		UBarUp,UBarLeft,UBarDown,UBarRight,
		ChairLeft,ChairRight,
		BowlLeft,BowlRight,BowlDown,BowlUp,
		IBar,HBar,fourPoint,Waggle,
		CloudLeft,CloudRight,DoubleOval,DoubleOvalV,
		Torus,Frame,FrameNarrow,
		LBarUpLeft,LBarUpRight,LBarLeft,LBarRight,
		twoHoleHoriz,twoHoleVert,
		CubeUpRight,CubeUpLeft,CubeDownRight,CubeDownLeft,
		CubeHalf,RoofRight,RoofLeft,RoofFront,RoofBack,
		Pyramid,Moret,Z,N,Matta,
		PistacheTop,PistacheBottom,PistacheLeft,PistacheRight,
		oneHole,oneHoleBig,flower
	}
	public enum FillDirection 
	{
		None, Up, Down, Left, Right,
		RectOut,RectIn, HorizCenter, VertCenter,
		CircOut,CircIn,NWSE,NESW,SENW,SWNE,
		Uright,ULeft,UUp,UDown,
		RCMix,RCModulo,Quatro,Duo,
		LNE,LNW,UpDown,LeftRight
	}
	#endregion

	#region Shape
	public class Shape
	{
		#region class variables
		ShapeType FShape;
		FillDirection FFillDirection;
		Color FGradientColor;
		bool FGradient;
		Color FBorderColor;
		DashStyle FBorderStyle;
		int FBorderWidth;
		Color FOldColor;
		Color FBackColor;
		Point FLocation;
		Size FSize;

		int x, y, w, h, s;
		int w2,w3,w4,w8,w16,h2,h3,h4,h8,h16,xw,yh;
		#endregion

		#region class properties
		public Point Location
		{
			get
			{
				return FLocation;
			}
			set
			{
				FLocation=value;
			}
		}

		public Size Size
		{
			get
			{
				return FSize;
			}
			set
			{
				FSize=value;
			}
		}

		public int Width
		{
			get
			{
				return Size.Width;
			}
			set
			{
				Size=new Size(value,Size.Height);
			}
		}

		public int Height
		{
			get
			{
				return Size.Height;
			}
			set
			{
				Size=new Size(Size.Height,value);
			}
		}

		public int X
		{
			get
			{
				return Location.X;
			}
		}

		public int Y
		{
			get
			{
				return Location.Y;
			}
		}

		public Brush BackBrush
		{
			get
			{
				return new SolidBrush(FBackColor);
			}
		}

		public Color BackGroundColor
		{
			get
			{
				return FBackColor;
			}
			set
			{
				if(FBackColor!=value)
				{
					FBackColor=value;
				}
			}
		}

		public Pen BorderPen
		{
			get
			{
				Pen freturn=new Pen(FBorderColor,FBorderWidth);
				freturn.DashStyle=FBorderStyle;
				return freturn;
			}
		}

		Brush GraidentBrush
		{
			get
			{
				return new SolidBrush(FOldColor);
			}
		}

		Color OldColor
		{
			get
			{
				return FOldColor;
			}
			set
			{
				FOldColor=value;
			}
		}

		public Color GradientColor
		{
			get
			{
				return FGradientColor;
			}
			set
			{
				
				if (value!=FGradientColor)
				{
					FGradientColor=value;
				}
			}			
		}

		public bool Gradient
		{
			get
			{
				return FGradient;
			}
			set
			{				
				if (value != FGradient) 
				{
					FGradient = value;
				}
			}
		}
		
		public Color BorderColor
		{
			get
			{
				return FBorderColor;
			}
			set
			{
				if(value!=FBorderColor)
				{
					FBorderColor=value;
				}
			}
		}

		public DashStyle BorderStyle
		{
			get
			{
				return FBorderStyle;
			}
			set
			{
				if(value!=FBorderStyle)
				{
					FBorderStyle=value;
				}
			}
		}

		public int BorderWidth
		{
			get
			{
				return FBorderWidth;
			}
			set
			{
				if(value!=FBorderWidth)
				{
					FBorderWidth=value;
				}
			}
		}

		public ShapeType ShapeType
		{
			get
			{
				return FShape;
			}
			set
			{	
				if (FShape != value )
				{
					FShape = value;
				}
			}
		}

		public FillDirection FillDirection
		{
			get
			{
				return FFillDirection;
			}
			set
			{
				if (value != FFillDirection)
				{
					FFillDirection = value;
				}
			}
		}
		#endregion
		
		#region constructor
		public Shape()
		{
			BorderColor=Color.Black;
			BorderStyle=DashStyle.Solid;
			BorderWidth=0;
			BackGroundColor=Color.White;
			GradientColor=Color.Black;
		}
		#endregion

		#region class methods
		public void Paint(Graphics gr)
		{
			x = Location.X+(int)(BorderPen.Width/2);
			y =Location.Y+(int)(BorderPen.Width/2);
			w = Width - (int)BorderPen.Width ;
			h = Height - (int)BorderPen.Width;
			if( BorderPen.Width == 0)
			{
				w--;
				h--;
			}
			if( w < h)
				s = w;
			else 
				s = h;
			if(FShape==ShapeType.Circle)
			{
				x=x+((w - s)/ 2);
				y=y+((h - s)/2);
				w = s;
				h = s;
			}
			// calcalute some often used values
			w2=w / 2;
			w3=w / 3;
			w4=w / 4;
			w8=w / 8;
			w16=w / 16;
			h2=h / 2;
			h3=h / 3;
			h4=h / 4;
			h8=h / 8;
			h16=h / 16;
			xw=x+w-1;
			yh=y+h-1;
			switch(FShape)
			{
				case ShapeType.Rectangle:
					DrawRectangle(gr);
					break;
				case ShapeType.Circle:
				case ShapeType.Ellipse:
					DrawEllipse(gr);
					break;
				case ShapeType.Valve:
				case ShapeType.ValveUp:
					DrawValve(gr);
					break;
				case ShapeType.House:
					DrawHouse(gr);
					break;
				case ShapeType.TriangleLeft:
				case ShapeType.TriangleRight:
				case ShapeType.TriangleUp:
				case ShapeType.TriangleDown:
					DrawTriangle(gr);
					break;
				case ShapeType.ArrowRight:
				case ShapeType.ArrowLeft:
				case ShapeType.ArrowDown:
				case ShapeType.ArrowUp:
					DrawArrow(gr);
					break;
				case ShapeType.Diamond:
					DrawDiamond(gr);
					break;
				case ShapeType.Octagon:
				case ShapeType.fourPoint:
					DrawOctagon(gr);
					break;
				case ShapeType.Hexagon:
				case ShapeType.HexagonFlat:
					DrawHexagon(gr);
					break;
				case ShapeType.UBarUp:
				case ShapeType.UBarDown:
				case ShapeType.UBarRight:
				case ShapeType.UBarLeft:
					DrawUBar(gr);
					break;
				case ShapeType.ChairLeft:
				case ShapeType.ChairRight:
					DrawChair(gr);
					break;
				case ShapeType.BowlLeft:
				case ShapeType.BowlRight:
				case ShapeType.BowlDown:
				case ShapeType.BowlUp:
					DrawBowl(gr);
					break;
				case ShapeType.IBar:
				case ShapeType.HBar:
					DrawIBar(gr);
					break;
				case ShapeType.Waggle:
					DrawWaggle(gr);
					break;
				case ShapeType.CloudLeft:
				case ShapeType.CloudRight:
				case ShapeType.DoubleOval:
				case ShapeType.DoubleOvalV:
					DrawCloud(gr);
					break;
				case ShapeType.Torus:
					DrawTorus(gr);
					break;
				case ShapeType.Frame:
				case ShapeType.FrameNarrow:
					DrawFrame(gr);
					break;
				case ShapeType.LBarUpLeft:
				case ShapeType.LBarUpRight:
				case ShapeType.LBarLeft:
				case ShapeType.LBarRight:
					DrawLBar(gr);
					break;
				case ShapeType.twoHoleHoriz:
				case ShapeType.twoHoleVert:
					Draw2Hole(gr);
					break;
				case ShapeType.CubeUpRight:
				case ShapeType.CubeUpLeft:
				case ShapeType.CubeDownRight:
				case ShapeType.CubeDownLeft:
				case ShapeType.CubeHalf:
					DrawCube(gr);
					break;
				case ShapeType.RoofRight:
				case ShapeType.RoofLeft:
				case ShapeType.RoofFront:
				case ShapeType.RoofBack:
					DrawRoof(gr);
					break;
				case ShapeType.Pyramid:
					DrawPyramid(gr);
					break;
				case ShapeType.Moret:
					DrawMoret(gr);
					break;
				case ShapeType.Z:
				case ShapeType.N:
					DrawZ(gr);
					break;
				case ShapeType.Matta:
					DrawMatta(gr);
					break;
				case ShapeType.PistacheTop:
				case ShapeType.PistacheBottom:
				case ShapeType.PistacheLeft:
				case ShapeType.PistacheRight:
					DrawPistache(gr);
					break;
				case ShapeType.oneHole:
				case ShapeType.oneHoleBig:
					Draw1Hole(gr);
					break;
				case ShapeType.flower:
					Drawflower(gr);
					break;
			}
		}

		void DrawRectangle(Graphics gr)
		{
			Region rgn;
			if (FGradient)
			{
				Rectangle rect=RectangleFromGdi(x,y,x+w,y+h);
				rgn=new Region(rect);
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawRectangle(BorderPen,RectangleFromGdi(x, y, x + w, y + h));
			}
			else
			{
				gr.FillRectangle(BackBrush,RectangleFromGdi(x, y, x + w, y + h));
				gr.DrawRectangle(BorderPen,RectangleFromGdi(x, y, x + w, y + h));
			}
		}

		void DrawTriangle(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[3];
			switch(FShape)
			{
				case ShapeType.TriangleRight:
					poly[0]=new Point(x,y);
					poly[1]=new Point(xw,y+h2);
					poly[2]=new Point(x,yh);
					break;
				case ShapeType.TriangleUp:
					poly[0]=new Point(x+w2,y);
					poly[1]=new Point(xw,yh);
					poly[2]=new Point(x,yh);
					break;
				case ShapeType.TriangleLeft:
					poly[0]=new Point(xw,y);
					poly[1]=new Point(xw,yh);
					poly[2]=new Point(x,y+h2);
					break;
				case ShapeType.TriangleDown:
					poly[0]=new Point(x,y);
					poly[1]=new Point(xw,y);
					poly[2]=new Point(x+w2,yh);
					break;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawArrow(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[7];
			switch(FShape)
			{
				case ShapeType.ArrowRight:
					poly[0]=new Point(x,y+(h / 2)-(h / 16));
					poly[1]=new Point(x+w-1-(w / 4),y+(h / 2)-(h / 16));
					poly[2]=new Point(x+w-1-(w / 4),y);
					poly[3]=new Point(x+w-1,y+(h / 2));
					poly[4]=new Point(x+w-1-(w / 4),y+h-1);
					poly[5]=new Point(x+w-1-(w / 4),y+(h / 2)+(h / 16));
					poly[6]=new Point(x,y+(h / 2)+(h / 16));
					break;
				case ShapeType.ArrowLeft:
					poly[0]=new Point(x+w-1,y+(h / 2)-(h / 16));
					poly[1]=new Point(x+(w / 4),y+(h / 2)-(h / 16));
					poly[2]=new Point(x+(w / 4),y);
					poly[3]=new Point(x,y+(h / 2));
					poly[4]=new Point(x+(w / 4),y+h-1);
					poly[5]=new Point(x+(w / 4),y+(h / 2)+(h / 16));
					poly[6]=new Point(x+w-1,y+(h / 2)+(h / 16));
					break;
				case ShapeType.ArrowUp:
					poly[0]=new Point(x+(w / 2)-(w / 16),y+h-1);
					poly[1]=new Point(x+(w / 2)-(w / 16),y+(h / 4));
					poly[2]=new Point(x,y+(h / 4));
					poly[3]=new Point(x+(w / 2),y);
					poly[4]=new Point(x+w-1,y+(h / 4));
					poly[5]=new Point(x+(w / 2)+(w / 16),y+(h / 4));
					poly[6]=new Point(x+(w / 2)+(w / 16),y+h-1);
					break;
				case ShapeType.ArrowDown:
					poly[0]=new Point(x+(w / 2)-(w / 16),y);
					poly[1]=new Point(x+(w / 2)-(w / 16),y+h-1-(h / 4));
					poly[2]=new Point(x,y+h-1-(h / 4));
					poly[3]=new Point(x+(w / 2),y+h-1);
					poly[4]=new Point(x+w-1,y+h-1-(h / 4));
					poly[5]=new Point(x+(w / 2)+(w / 16),y+h-1-(h / 4));
					poly[6]=new Point(x+(w / 2)+(w / 16),y);
					break;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawChair(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[10];			
			switch(FShape)
			{
				case ShapeType.ChairLeft:
					poly[0]=new Point(xw,y);
					poly[1]=new Point(xw-w4,y);
					poly[2]=new Point(xw-w4,y+h2);
					poly[3]=new Point(x,y+h2);
					poly[4]=new Point(x,yh);
					poly[5]=new Point(x+w4,yh);
					poly[6]=new Point(x+w4,yh-h4);
					poly[7]=new Point(xw-w4,yh-h4);
					poly[8]=new Point(xw-w4,yh);
					poly[9]=new Point(xw,yh);
					break;
				case ShapeType.ChairRight:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x+w4,y);
					poly[2]=new Point(x+w4,y+h2);
					poly[3]=new Point(xw,y+h2);
					poly[4]=new Point(xw,yh);
					poly[5]=new Point(xw-w4,yh);
					poly[6]=new Point(xw-w4,yh-h4);
					poly[7]=new Point(x+w4,yh-h4);
					poly[8]=new Point(x+w4,yh);
					poly[9]=new Point(x,yh);
					break;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawValve(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[4];
			switch(FShape)
			{	
				case ShapeType.Valve:
					poly[0]=new Point(x,y);
					poly[1]=new Point(xw,yh);
					poly[2]=new Point(xw,y);
					poly[3]=new Point(x,yh);
					break;
				case ShapeType.ValveUp:
					poly[0]=new Point(x,y);
					poly[1]=new Point(xw,y);
					poly[2]=new Point(x,yh);
					poly[3]=new Point(xw,yh);
					break;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawOctagon(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[8];
			switch(FShape)
			{
				case ShapeType.Octagon:
					poly[0]=new Point(x+(w / 3),y);
					poly[1]=new Point(x+w-1-(w / 3),y);
					poly[2]=new Point(x+w-1,y+(h / 3));
					poly[3]=new Point(x+w-1,y+h-1-(h / 3));
					poly[4]=new Point(x+w-1-(w / 3),y+h-1);
					poly[5]=new Point(x+(w / 3),y+h-1);
					poly[6]=new Point(x,y+h-1-(h / 3));
					poly[7]=new Point(x,y+(h / 3));
					break;
				case ShapeType.fourPoint:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x+w2,y+h4);
					poly[2]=new Point(xw,y);
					poly[3]=new Point(xw-w4,y+h2);
					poly[4]=new Point(xw,yh);
					poly[5]=new Point(x+w2,yh-h4);
					poly[6]=new Point(x,yh);
					poly[7]=new Point(x+w4,y+h2);
					break;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawCube(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[12];
			Point[] rpoly=new Point[6];
			int i;
			switch( FShape)
			{
				case ShapeType.CubeUpRight:
					poly[0]=new Point(x,yh);
					poly[1]=new Point(xw-w3,yh);
					poly[2]=new Point(xw,yh-h3);
					poly[3]=new Point(xw,y);
					poly[4]=new Point(x+w3,y);
					poly[5]=new Point(x,y+h3);
					break;
				case ShapeType.CubeHalf:
					poly[0]=new Point(x,yh);
					poly[1]=new Point(xw-w3,yh);
					poly[2]=new Point(xw,yh-h3);
					poly[3]=new Point(xw,yh-h3-h3);
					poly[4]=new Point(x+w3,yh-h3-h3);
					poly[5]=new Point(x,yh-h3);
					break;
				case ShapeType.CubeUpLeft:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x,yh-h3);
					poly[2]=new Point(x+w3,yh);
					poly[3]=new Point(xw,yh);
					poly[4]=new Point(xw,y+h3);
					poly[5]=new Point(xw-w3,y);
					break;
				case ShapeType.CubeDownLeft:
					poly[0]=new Point(x,y+h3);
					poly[1]=new Point(x,yh);
					poly[2]=new Point(xw-w3,yh);
					poly[3]=new Point(xw,yh-h3);
					poly[4]=new Point(xw,y);
					poly[5]=new Point(x+w3,y);
					break;
				case ShapeType.CubeDownRight:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x,yh-h3);
					poly[2]=new Point(x+w3,yh);
					poly[3]=new Point(xw,yh);
					poly[4]=new Point(xw,y+h3);
					poly[5]=new Point(xw-w3,y);
					break;
			}
			for (i = 0;i<6;i++)
			{
				rpoly[i].X = poly[i].X;
				rpoly[i].Y = poly[i].Y;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(rpoly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();				
			}
			switch( FShape)
			{
				case ShapeType.CubeUpRight:
					poly[0]=new Point(xw-w3,y+h3);
					poly[1]=new Point(x,y+h3);
					poly[2]=new Point(x,yh);
					poly[3]=new Point(xw-w3,yh);
					poly[4]=new Point(xw-w3,y+h3);
					poly[5]=new Point(xw,y);
					poly[6]=new Point(xw,yh-h3);
					poly[7]=new Point(xw-w3,yh);
					poly[8]=new Point(xw-w3,y+h3);
					poly[9]=new Point(x,y+h3);
					poly[10]=new Point(x+w3,y);
					poly[11]=new Point(xw,y);
					break;
				case ShapeType.CubeHalf:
					poly[0]=new Point(xw-w3,yh-h3);
					poly[1]=new Point(x,yh-h3);
					poly[2]=new Point(x,yh);
					poly[3]=new Point(xw-w3,yh);
					poly[4]=new Point(xw-w3,yh-h3);
					poly[5]=new Point(xw,yh-h3-h3);
					poly[6]=new Point(xw,yh-h3);
					poly[7]=new Point(xw-w3,yh);
					poly[8]=new Point(xw-w3,yh-h3);
					poly[9]=new Point(x,yh-h3);
					poly[10]=new Point(x+w3,yh-h3-h3);
					poly[11]=new Point(xw,yh-h3-h3);
					break;
				case ShapeType.CubeUpLeft:
					poly[0]=new Point(x+w3,y+h3);
					poly[1]=new Point(xw,y+h3);
					poly[2]=new Point(xw,yh);
					poly[3]=new Point(x+w3,yh);
					poly[4]=new Point(x+w3,y+h3);
					poly[5]=new Point(x,y);
					poly[6]=new Point(x,yh-h3);
					poly[7]=new Point(x+w3,yh);
					poly[8]=new Point(x+w3,y+h3);
					poly[9]=new Point(xw,y+h3);
					poly[10]=new Point(xw-w3,y);
					poly[11]=new Point(x,y);
					break;
				case ShapeType.CubeDownLeft:
					poly[0]=new Point(x+w3,yh-h3);
					poly[1]=new Point(xw,yh-h3);
					poly[2]=new Point(xw,y);
					poly[3]=new Point(x+w3,y);
					poly[4]=new Point(x+w3,yh-h3);
					poly[5]=new Point(x+w3,y);
					poly[6]=new Point(x,y+h3);
					poly[7]=new Point(x,yh);
					poly[8]=new Point(x+w3,yh-h3);
					poly[9]=new Point(xw,yh-h3);
					poly[10]=new Point(xw-w3,yh);
					poly[11]=new Point(x,yh);
					break;
				case ShapeType.CubeDownRight:
					poly[0]=new Point(xw-w3,yh-h3);
					poly[1]=new Point(x,yh-h3);
					poly[2]=new Point(x,y);
					poly[3]=new Point(xw-w3,y);
					poly[4]=new Point(xw-w3,yh-h3);
					poly[5]=new Point(xw-w3,y);
					poly[6]=new Point(xw,y+h3);
					poly[7]=new Point(xw,yh);
					poly[8]=new Point(xw-w3,yh-h3);
					poly[9]=new Point(x,yh-h3);
					poly[10]=new Point(x+w3,yh);
					poly[11]=new Point(xw,yh);
					break;
			}
			if(FGradient)
				gr.DrawPolygon(BorderPen,poly);
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawRoof(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[7];
			Point[] rpoly=new Point[5];
			int i;
			switch (FShape)
			{
				case ShapeType.RoofFront:
					poly[0]=new Point(x,yh);
					poly[1]=new Point(xw-w3,yh);
					poly[2]=new Point(xw,yh-h3);
					poly[3]=new Point(xw,y);
					poly[4]=new Point(x+w3,y);
					break;
				case ShapeType.RoofBack:
					poly[0]=new Point(x,yh);
					poly[1]=new Point(xw-w3,yh);
					poly[2]=new Point(xw,yh-h3);
					poly[3]=new Point(xw-w3,y);
					poly[4]=new Point(x,y);
					break;
				case ShapeType.RoofLeft:
					poly[0]=new Point(x,y+h3);
					poly[1]=new Point(x,yh);
					poly[2]=new Point(xw-w3,yh);
					poly[3]=new Point(xw,yh-h3);
					poly[4]=new Point(x+w3,y);
					break;
				case ShapeType.RoofRight:
					poly[0]=new Point(x,yh);
					poly[1]=new Point(xw-w3,yh);
					poly[2]=new Point(xw,yh-h3);
					poly[3]=new Point(xw,y);
					poly[4]=new Point(xw-w3,y+h3);
					break;
			}
			for (i = 0;i<5;i++)
			{
				rpoly[i].X = poly[i].X;
				rpoly[i].Y = poly[i].Y;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(rpoly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();	
			}
			switch(FShape)
			{
				case ShapeType.RoofFront:
					poly[0]=new Point(xw-w3,yh);
					poly[1]=new Point(xw,y);
					poly[2]=new Point(x+w3,y);
					poly[3]=new Point(x,yh);
					poly[4]=new Point(xw-w3,yh);
					poly[5]=new Point(xw,yh-h3);
					poly[6]=new Point(xw,y);
					break;
				case ShapeType.RoofBack:
					poly[0]=new Point(xw-w3,yh);
					poly[1]=new Point(xw-w3,y);
					poly[2]=new Point(x,y);
					poly[3]=new Point(x,yh);
					poly[4]=new Point(xw-w3,yh);
					poly[5]=new Point(xw,yh-h3);
					poly[6]=new Point(xw-w3,y);
					break;
				case ShapeType.RoofLeft:
					poly[0]=new Point(x,y+h3);
					poly[1]=new Point(x,yh);
					poly[2]=new Point(xw-w3,yh);
					poly[3]=new Point(x,y+h3);
					poly[4]=new Point(x+w3,y);
					poly[5]=new Point(xw,yh-h3);
					poly[6]=new Point(xw-w3,yh);
					break;
				case ShapeType.RoofRight:
					poly[0]=new Point(xw-w3,yh);
					poly[1]=new Point(xw-w3,y+h3);
					poly[2]=new Point(x,yh);
					poly[3]=new Point(xw-w3,yh);
					poly[4]=new Point(xw,yh-h3);
					poly[5]=new Point(xw,y);
					poly[6]=new Point(xw-w3,y+h3);
					break;
			}
			if(FGradient)
				gr.DrawPolygon(BorderPen,poly);
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawPyramid(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[6];
			Point[] rpoly=new Point[4];
			int i;
			switch( FShape)
			{
				case ShapeType.Pyramid:
					poly[0]=new Point(x,yh);
					poly[1]=new Point(xw-w3,yh);
					poly[2]=new Point(xw,yh-h3);
					poly[3]=new Point(x+w2,y);
					break;
			}
			for (i = 0;i<4;i++)
			{
				rpoly[i].X = poly[i].X;
				rpoly[i].Y = poly[i].Y;
			}
			if(FGradient)
			{
				rgn = new Region(new GraphicsPath(rpoly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();	
			}
			switch( FShape)
			{
				case ShapeType.Pyramid:
					poly[0]=new Point(xw-w3,yh);
					poly[1]=new Point(x+w2,y);
					poly[2]=new Point(x,yh);
					poly[3]=new Point(xw-w3,yh);
					poly[4]=new Point(xw,yh-h3);
					poly[5]=new Point(x+w2,y);
					break;
			}
			if(FGradient)
				gr.DrawPolygon(BorderPen,poly);
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawMoret(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[20];
			switch(FShape)
			{
				case ShapeType.Moret:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x,y+h4);
					poly[2]=new Point(x+w8,y+h4);
					poly[3]=new Point(x+w8,yh-h4);
					poly[4]=new Point(x,yh-h4);
					poly[5]=new Point(x,yh);
					poly[6]=new Point(x+w4,yh);
					poly[7]=new Point(x+w4,yh-h8);
					poly[8]=new Point(xw-w4,yh-h8);
					poly[9]=new Point(xw-w4,yh);
					poly[10]=new Point(xw,yh);
					poly[11]=new Point(xw,yh-h4);
					poly[12]=new Point(xw-w8,yh-h4);
					poly[13]=new Point(xw-w8,y+h4);
					poly[14]=new Point(xw,y+h4);
					poly[15]=new Point(xw,y);
					poly[16]=new Point(xw-w4,y);
					poly[17]=new Point(xw-w4,y+h8);
					poly[18]=new Point(x+w4,y+h8);
					poly[19]=new Point(x+w4,y);
					break;
			}
			if (FGradient)
			{	
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawZ(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[10];
			switch( FShape)
			{
				case ShapeType.Z:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x,y+h4);
					poly[2]=new Point(xw-w3,y+h4);
					poly[3]=new Point(x,yh-h4);
					poly[4]=new Point(x,yh);
					poly[5]=new Point(xw,yh);
					poly[6]=new Point(xw,yh-h4);
					poly[7]=new Point(x+w3,yh-h4);
					poly[8]=new Point(xw,y+h4);
					poly[9]=new Point(xw,y);
					break;
				case ShapeType.N:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x,yh);
					poly[2]=new Point(x+w4,yh);
					poly[3]=new Point(x+w4,y+h3);
					poly[4]=new Point(xw-w4,yh);
					poly[5]=new Point(xw,yh);
					poly[6]=new Point(xw,y);
					poly[7]=new Point(xw-w4,y);
					poly[8]=new Point(xw-w4,yh-h3);
					poly[9]=new Point(x+w4,y);
					break;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawMatta(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[16];
			switch(FShape)
			{
				case ShapeType.Matta:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x,y+h4);
					poly[2]=new Point(x+w2,y+h2);
					poly[3]=new Point(x,yh-h4);
					poly[4]=new Point(x,yh);
					poly[5]=new Point(x+w4,yh);
					poly[6]=new Point(x+w2,y+h2);
					poly[7]=new Point(xw-w4,yh);
					poly[8]=new Point(xw,yh);
					poly[9]=new Point(xw,yh-h4);
					poly[10]=new Point(x+w2,y+h2);
					poly[11]=new Point(xw,y+h4);
					poly[12]=new Point(xw,y);
					poly[13]=new Point(xw-w4,y);
					poly[14]=new Point(x+w2,y+h2);
					poly[15]=new Point(x+w4,y);
					break;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawHexagon(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[6];
			switch(FShape)
			{
				case ShapeType.Hexagon:
					poly[0]=new Point(x+w2,y);
					poly[1]=new Point(xw,y+h4);
					poly[2]=new Point(xw,yh-h4);
					poly[3]=new Point(x+w2,yh);
					poly[4]=new Point(x,yh-h4);
					poly[5]=new Point(x,y+h4);
					break;
				case ShapeType.HexagonFlat:
					poly[0]=new Point(x+w4,y);
					poly[1]=new Point(xw-w4,y);
					poly[2]=new Point(xw,y+h2);
					poly[3]=new Point(xw-w4,yh);
					poly[4]=new Point(x+w4,yh);
					poly[5]=new Point(x,y+h2);
					break;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawWaggle(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[16];
			switch(FShape)
			{
				case ShapeType.Waggle:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x+w4,y+h8);
					poly[2]=new Point(x+w2,y);
					poly[3]=new Point(xw-w4,y+h8);
					poly[4]=new Point(xw,y);
					poly[5]=new Point(xw-w8,y+h4);
					poly[6]=new Point(xw,y+h2);
					poly[7]=new Point(xw-w8,yh-h4);
					poly[8]=new Point(xw,yh);
					poly[9]=new Point(xw-w4,yh-h8);
					poly[10]=new Point(x+w2,yh);
					poly[11]=new Point(x+w4,yh-h8);
					poly[12]=new Point(x,yh);
					poly[13]=new Point(x+w8,yh-h4);
					poly[14]=new Point(x,y+h2);
					poly[15]=new Point(x+w8,y+h4);
					break;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawHouse(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[5];
			switch(FShape)
			{
				case ShapeType.House:
					poly[0]=new Point(x+w2,y);
					poly[1]=new Point(xw,y+h2);
					poly[2]=new Point(xw,yh);
					poly[3]=new Point(x,yh);
					poly[4]=new Point(x,y+h2);
					break;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawDiamond(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[4];
			switch( FShape)
			{
				case ShapeType.Diamond:
					poly[0]=new Point(x+(w / 2),y);
					poly[1]=new Point(x+w-1,y+(h / 2));
					poly[2]=new Point(x+(w / 2),y+h-1);
					poly[3]=new Point(x,y+(h / 2));
					break;
			}
			if( FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawEllipse(Graphics gr)
		{
			Region rgn;
			if (FGradient)
			{	
				GraphicsPath path=new GraphicsPath();
				path.AddEllipse(new Rectangle(x,y,w,h));
				rgn=new Region(path);
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();	
				gr.DrawEllipse(BorderPen,x, y, w, h);
			}
			else
			{
				gr.FillEllipse(BackBrush,x, y, w, h);
				gr.DrawEllipse(BorderPen,x, y, w, h);
			}
		}

		void DrawBowl(Graphics gr)
		{
			Region rgn;
			GraphicsPath path;
			switch(FShape)
			{
				case ShapeType.BowlLeft:
					if (FGradient)
					{	
						path=new GraphicsPath();
						path.AddEllipse(x,y,w,h);
						rgn=new Region(path);
						path.Reset();
						path.AddRectangle(new Rectangle(x,y,w2,h));
						rgn.Intersect(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();
						gr.DrawPie(BorderPen,x,y,w,h,90,180);
					}
					else
					{
						gr.FillPie(BackBrush,x,y,w,h,90,180);
						gr.DrawPie(BorderPen,x,y,w,h,90,180);
					}
					break;
				case ShapeType.BowlRight:
					if( FGradient)
					{
						path=new GraphicsPath();
						path.AddEllipse(x,y,w,h);
						rgn=new Region(path);
						path.Reset();
						path.AddRectangle(new Rectangle(x+w2,y,w+w2,h));
						rgn.Intersect(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();
						gr.DrawPie(BorderPen,x,y,w,h,-90,180);	
					}	
					else
					{
						gr.FillPie(BackBrush,x,y,w,h,-90,180);	
						gr.DrawPie(BorderPen,x,y,w,h,-90,180);	
					}
					break;
				case ShapeType.BowlUp:
					if (FGradient)
					{
						path=new GraphicsPath();
						path.AddEllipse(x,y,w,h);
						rgn=new Region(path);
						path.Reset();
						path.AddRectangle(new Rectangle(x,y,w,h2));
						rgn.Intersect(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();
						gr.DrawPie(BorderPen,x,y,w,h,180,180);	
					}
					else
					{
						gr.FillPie(BackBrush,x,y,w,h,180,180);	
						gr.DrawPie(BorderPen,x,y,w,h,180,180);	
					}
					break;
				case ShapeType.BowlDown:
					if (FGradient)
					{
						path=new GraphicsPath();
						path.AddEllipse(x,y,w,h);
						rgn=new Region(path);
						path.Reset();
						path.AddRectangle(new Rectangle(x,y+h2,w,h2+h));
						rgn.Intersect(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();
						gr.DrawPie(BorderPen,x,y,w,h,-180,-180);
					}
					else
					{
						gr.DrawPie(BorderPen,x,y,w,h,-180,-180);
					}
					break;
			}
		}

		Rectangle RectangleFromGdi(int x,int y,int x2,int y2)
		{
			return new Rectangle(x,y,Math.Abs(x2-x),Math.Abs(y2-y));
		}

		void DrawCloud(Graphics gr)
		{
			Region rgn;
			GraphicsPath path;
			switch (FShape)
			{
				case ShapeType.CloudLeft:
					if (FGradient)
					{
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw-w4,yh-h4));
						path = new GraphicsPath();						
						path.AddEllipse(RectangleFromGdi(x+((int)BorderPen.Width/2),y+((int)BorderPen.Width/2),xw-w4-((int)BorderPen.Width/2),yh-h4-((int)BorderPen.Width/2)));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w4,y+h4,xw,yh));
						rgn.Union(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();						
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w4,y+h4,xw,yh));	
					}
					else 
					{
						gr.FillEllipse(BackBrush,RectangleFromGdi(x,y,xw-w4,yh-h4));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw-w4,yh-h4));
						gr.FillEllipse(BackBrush,RectangleFromGdi(x+w4,y+h4,xw,yh));						
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w4,y+h4,xw,yh));	
					}
					break;
				case ShapeType.DoubleOval:
					if (FGradient)
					{
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,x+w2,yh));
						path = new GraphicsPath();
						path.AddEllipse(RectangleFromGdi(x+((int)BorderPen.Width/2),y+((int)BorderPen.Width/2),x+w2-((int)BorderPen.Width/2),yh-((int)BorderPen.Width/2)));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w2,y,xw,yh));
						rgn.Union(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();						
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w2,y,xw,yh));
					}
					else 
					{
						gr.FillEllipse(BackBrush,RectangleFromGdi(x,y,x+w2,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,x+w2,yh));
						gr.FillEllipse(BackBrush,RectangleFromGdi(x+w2,y,xw,yh));						
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w2,y,xw,yh));
					}
					break;
				case ShapeType.DoubleOvalV:
					if (FGradient)
					{
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,y+h2));
						path = new GraphicsPath();
						path.AddEllipse(RectangleFromGdi(x+((int)BorderPen.Width/2),y+((int)BorderPen.Width/2),xw-((int)BorderPen.Width/2),y+h2-((int)BorderPen.Width/2)));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x,y+h2,xw,yh));
						rgn.Union(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();						
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y+h2,xw,yh));
					}
					else 
					{
						gr.FillEllipse(BackBrush,RectangleFromGdi(x,y,xw,y+h2));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,y+h2));
						gr.FillEllipse(BackBrush,RectangleFromGdi(x,y+h2,xw,yh));						
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y+h2,xw,yh));
					}
					break;
				case ShapeType.CloudRight:
					if (FGradient)
					{
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w4,y,xw,yh-h4));
						path = new GraphicsPath();
						path.AddEllipse(RectangleFromGdi(x+w4+((int)BorderPen.Width/2),y+((int)BorderPen.Width/2),xw-((int)BorderPen.Width/2),yh-h4-((int)BorderPen.Width/2)));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x,y+h4,xw-w4,yh));
						rgn.Union(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();						
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y+h4,xw-w4,yh));
					}
					else 
					{
						gr.FillEllipse(BackBrush,RectangleFromGdi(x+w4,y,xw,yh-h4));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w4,y,xw,yh-h4));
						gr.FillEllipse(BackBrush,RectangleFromGdi(x,y+h4,xw-w4,yh));						
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y+h4,xw-w4,yh));
					}
					break;
			}
		}

		void DrawPistache(Graphics gr)
		{
			Region rgn;
			GraphicsPath path;
			switch( FShape)
			{
				case ShapeType.PistacheTop:
					if (FGradient)
					{
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,yh));
						path = new GraphicsPath();
						path.AddRectangle(RectangleFromGdi(x,y+h2,xw,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+((int)BorderPen.Width/2),y+((int)BorderPen.Width/2),xw-((int)BorderPen.Width/2),yh-((int)BorderPen.Width/2)));
						rgn.Union(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();						
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x,y+h2,xw,yh));
					}
					else 
					{
						gr.FillEllipse(BackBrush,RectangleFromGdi(x,y,xw,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.FillRectangle(BackBrush,RectangleFromGdi(x,y+h2,xw,yh));						
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x,y+h2,xw,yh));
					}
					break;
				case ShapeType.PistacheBottom:
					if (FGradient)
					{
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,yh));
						path = new GraphicsPath();
						path.AddRectangle(RectangleFromGdi(x,y,xw,y+h2));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+((int)BorderPen.Width/2),y+((int)BorderPen.Width/2),xw-((int)BorderPen.Width/2),yh-((int)BorderPen.Width/2)));
						rgn.Union(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();						
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x,y,xw,y+h2));
					}
					else 
					{
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.FillEllipse(BackBrush,RectangleFromGdi(x,y,xw,yh));
						gr.FillRectangle(BackBrush,RectangleFromGdi(x,y,xw,y+h2));						
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x,y,xw,y+h2));
					}
					break;
				case ShapeType.PistacheLeft:
					if (FGradient)
					{
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,yh));
						path = new GraphicsPath();
						path.AddRectangle(RectangleFromGdi(x+w2,y,xw,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+((int)BorderPen.Width/2),y+((int)BorderPen.Width/2),xw-((int)BorderPen.Width/2),yh-((int)BorderPen.Width/2)));
						rgn.Union(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();						
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x+w2,y,xw,yh));
					}
					else 
					{
						gr.FillEllipse(BackBrush,RectangleFromGdi(x,y,xw,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.FillRectangle(BackBrush,RectangleFromGdi(x+w2,y,xw,yh));						
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x+w2,y,xw,yh));
					}
					break;
				case ShapeType.PistacheRight:
					if (FGradient)
					{
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,yh));
						path = new GraphicsPath();
						path.AddRectangle(RectangleFromGdi(x,y,x+w2,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+((int)BorderPen.Width/2),y+((int)BorderPen.Width/2),xw-((int)BorderPen.Width/2),yh-((int)BorderPen.Width/2)));
						rgn.Union(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();						
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x,y,x+w2,yh));
					}
					else 
					{
						gr.FillEllipse(BackBrush,RectangleFromGdi(x,y,xw,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.FillRectangle(BackBrush,RectangleFromGdi(x,y,x+w2,yh));						
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x,y,x+w2,yh));
					}
					break;
			}
		}

		void Draw1Hole(Graphics gr)
		{
			Region rgn;
			GraphicsPath path;
			switch (FShape)
			{
				case ShapeType.oneHole:
					if (FGradient)
					{
						path = new GraphicsPath();
						path.AddRectangle(RectangleFromGdi(x,y,xw,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w4,y+h4,xw-w4,yh-h4));
						rgn.Xor(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w4,y+h4,xw-w4,yh-h4));
					}
					else 
					{
						path = new GraphicsPath();
						path.AddRectangle(RectangleFromGdi(x,y,xw,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w4,y+h4,xw-w4,yh-h4));
						rgn.Xor(path);
						path.Reset();
						gr.IntersectClip(rgn);
						gr.FillRectangle(BackBrush,RectangleFromGdi(x,y,xw,yh));
						gr.FillEllipse(BackBrush,RectangleFromGdi(x+w4,y+h4,xw-w4,yh-h4));
						gr.ResetClip();
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w4,y+h4,xw-w4,yh-h4));
					}
					break;
				case ShapeType.oneHoleBig:
					if (FGradient)
					{
						path = new GraphicsPath();
						path.AddRectangle(RectangleFromGdi(x,y,xw,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w8,y+h8,xw-w8,yh-h8));
						rgn.Xor(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w8,y+h8,xw-w8,yh-h8));
					}
					else 
					{
						path = new GraphicsPath();
						path.AddRectangle(RectangleFromGdi(x,y,xw,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w8,y+h8,xw-w8,yh-h8));
						rgn.Xor(path);
						path.Reset();
						gr.IntersectClip(rgn);
						gr.FillRectangle(BackBrush,RectangleFromGdi(x,y,xw,yh));
						gr.FillEllipse(BackBrush,RectangleFromGdi(x+w8,y+h8,xw-w8,yh-h8));
						gr.ResetClip();
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w8,y+h8,xw-w8,yh-h8));
					}
					break;
			}
		}

		void Draw2Hole(Graphics gr)
		{
			Region rgn;
			GraphicsPath path;
			switch (FShape)
			{
				case ShapeType.twoHoleHoriz:
					if (FGradient)
					{
						path = new GraphicsPath();
						path.AddEllipse(RectangleFromGdi(x,y,xw,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w8,y+h4,x+w2-w8,yh-h4));
						rgn.Xor(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w2+w8,y+h4,xw-w8,yh-h4));
						rgn.Xor(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w8,y+h4,x+w2-w8,yh-h4));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w2+w8,y+h4,xw-w8,yh-h4));
					}
					else 
					{
						path = new GraphicsPath();
						path.AddEllipse(RectangleFromGdi(x,y,xw,yh));
						rgn=new Region(path);
						path.AddEllipse(RectangleFromGdi(x+w8,y+h4,x+w2-w8,yh-h4));
						rgn.Xor(path);
						path.AddEllipse(RectangleFromGdi(x+w2+w8,y+h4,xw-w8,yh-h4));
						rgn.Xor(path);
						gr.IntersectClip(rgn);
						gr.FillPath(BackBrush,path);
						gr.ResetClip();
						gr.DrawPath(BorderPen,path);
					}
					break;
				case ShapeType.twoHoleVert:
					if (FGradient)
					{
						path = new GraphicsPath();
						path.AddEllipse(RectangleFromGdi(x,y,xw,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w4,y+h8,xw-w4,y+h2-h8));
						rgn.Xor(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w4,y+h2+h8,xw-w4,yh-h8));
						rgn.Xor(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w4,y+h8,xw-w4,y+h2-h8));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w4,y+h2+h8,xw-w4,yh-h8));
					}
					else 
					{
						path = new GraphicsPath();
						path.AddEllipse(RectangleFromGdi(x,y,xw,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w4,y+h8,xw-w4,y+h2-h8));
						rgn.Xor(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w4,y+h2+h8,xw-w4,yh-h8));
						rgn.Xor(path);
						path.Reset();
						gr.IntersectClip(rgn);
						gr.FillEllipse(BackBrush,RectangleFromGdi(x,y,xw,yh));
						gr.FillEllipse(BackBrush,RectangleFromGdi(x+w4,y+h8,xw-w4,y+h2-h8));
						gr.FillEllipse(BackBrush,RectangleFromGdi(x+w4,y+h2+h8,xw-w4,yh-h8));
						gr.ResetClip();
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w4,y+h8,xw-w4,y+h2-h8));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w4,y+h2+h8,xw-w4,yh-h8));
					}
					break;
			}
		}

		void Drawflower(Graphics gr)
		{
			Region rgn;
			GraphicsPath path;
			switch (FShape)
			{
				case ShapeType.flower:
					if (FGradient)
					{
						path = new GraphicsPath();
						path.AddEllipse(RectangleFromGdi(x,y+h3,x+w2,yh-h3));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w3,y,xw-w3,y+h2));
						rgn.Union(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w2,y+h3,xw,yh-h3));
						rgn.Union(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w3,y+h2,xw-w3,yh));
						rgn.Union(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y+h3,x+w2,yh-h3));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w3,y,xw-w3,y+h2));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w2,y+h3,xw,yh-h3));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w3,y+h2,xw-w3,yh));
					}
					else 
					{
						gr.FillEllipse(BackBrush,RectangleFromGdi(x,y+h3,x+w2,yh-h3));
						gr.FillEllipse(BackBrush,RectangleFromGdi(x+w3,y,xw-w3,y+h2));
						gr.FillEllipse(BackBrush,RectangleFromGdi(x+w2,y+h3,xw,yh-h3));
						gr.FillEllipse(BackBrush,RectangleFromGdi(x+w3,y+h2,xw-w3,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y+h3,x+w2,yh-h3));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w3,y,xw-w3,y+h2));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w2,y+h3,xw,yh-h3));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w3,y+h2,xw-w3,yh));
					}
					break;
			}
		}

		void DrawTorus(Graphics gr)
		{
			Region rgn;
			GraphicsPath path;
			switch (FShape)
			{
				case ShapeType.Torus:
					if (FGradient)
					{
						path=new GraphicsPath();
						path.AddEllipse(RectangleFromGdi(x,y,xw,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w4,y+h4,xw-w4,yh-h4));
						rgn.Xor(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w4,y+h4,xw-w4,yh-h4));
					}
					else 
					{
						path=new GraphicsPath();
						path.AddEllipse(RectangleFromGdi(x,y,xw,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddEllipse(RectangleFromGdi(x+w4,y+h4,xw-w4,yh-h4));
						rgn.Xor(path);
						path.Reset();
						gr.IntersectClip(rgn);
						gr.FillEllipse(BackBrush,RectangleFromGdi(x,y,xw,yh));
						gr.FillEllipse(BackBrush,RectangleFromGdi(x+w4,y+h4,xw-w4,yh-h4));
						gr.ResetClip();
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.DrawEllipse(BorderPen,RectangleFromGdi(x+w4,y+h4,xw-w4,yh-h4));
					}
					break;
			}
		}

		void DrawFrame(Graphics gr)
		{
			Region rgn;
			GraphicsPath path;
			int dw=0,dh=0;
			switch (FShape)
			{
				case ShapeType.Frame: 
					dw=w4;dh=h4;
					break;
				case ShapeType.FrameNarrow:
					dw=w8;dh=h8;
					break;
			}
			switch( FShape)
			{
				case ShapeType.Frame:
				case ShapeType.FrameNarrow:
					if (FGradient)
					{
						path=new GraphicsPath();
						path.AddRectangle(RectangleFromGdi(x,y,xw,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddRectangle(RectangleFromGdi(x+dw,y+dh,xw-dw,yh-dh));
						rgn.Xor(path);
						path.Reset();
						gr.IntersectClip(rgn);
						FillWithGradient(gr);
						gr.ResetClip();
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x+dw,y+dh,xw-dw,yh-dh));
					}
					else 
					{
						path=new GraphicsPath();
						path.AddRectangle(RectangleFromGdi(x,y,xw,yh));
						rgn=new Region(path);
						path.Reset();
						path.AddRectangle(RectangleFromGdi(x+dw,y+dh,xw-dw,yh-dh));
						rgn.Xor(path);
						path.Reset();
						gr.IntersectClip(rgn);
						gr.FillRectangle(BackBrush,RectangleFromGdi(x,y,xw,yh));
						gr.FillRectangle(BackBrush,RectangleFromGdi(x+dw,y+dh,xw-dw,yh-dh));
						gr.ResetClip();
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x,y,xw,yh));
						gr.DrawRectangle(BorderPen,RectangleFromGdi(x+dw,y+dh,xw-dw,yh-dh));
					}
					break;
			}
		}

		void DrawUBar(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[8];
			switch (FShape)
			{
				case ShapeType.UBarUp:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x,yh);
					poly[2]=new Point(xw,yh);
					poly[3]=new Point(xw,y);
					poly[4]=new Point(xw-w4,y);
					poly[5]=new Point(xw-w4,yh-h4);
					poly[6]=new Point(x+w4,yh-h4);
					poly[7]=new Point(x+w4,y);
					break;
				case ShapeType.UBarLeft:
					poly[0]=new Point(x,y);
					poly[1]=new Point(xw,y);
					poly[2]=new Point(xw,yh);
					poly[3]=new Point(x,yh);
					poly[4]=new Point(x,yh-h4);
					poly[5]=new Point(xw-w4,yh-h4);
					poly[6]=new Point(xw-w4,y+h4);
					poly[7]=new Point(x,y+h4);
					break;
				case ShapeType.UBarDown:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x,yh);
					poly[2]=new Point(x+w4,yh);
					poly[3]=new Point(x+w4,y+h4);
					poly[4]=new Point(xw-w4,y+h4);
					poly[5]=new Point(xw-w4,yh);
					poly[6]=new Point(xw,yh);
					poly[7]=new Point(xw,y);
					break;
				case ShapeType.UBarRight:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x,yh);
					poly[2]=new Point(xw,yh);
					poly[3]=new Point(xw,yh-h4);
					poly[4]=new Point(x+w4,yh-h4);
					poly[5]=new Point(x+w4,y+h4);
					poly[6]=new Point(xw,y+h4);
					poly[7]=new Point(xw,y);
					break;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawIBar(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[12];
			switch (FShape)
			{
				case ShapeType.IBar:
					poly[0]=new Point(x,y);
					poly[1]=new Point(xw,y);
					poly[2]=new Point(xw,y+h4);
					poly[3]=new Point(xw-w4,y+h4);
					poly[4]=new Point(xw-w4,yh-h4);
					poly[5]=new Point(xw,yh-h4);
					poly[6]=new Point(xw,yh);
					poly[7]=new Point(x,yh);
					poly[8]=new Point(x,yh-h4);
					poly[9]=new Point(x+w4,yh-h4);
					poly[10]=new Point(x+w4,y+h4);
					poly[11]=new Point(x,y+h4);
					break;
				case ShapeType.HBar:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x+w4,y);
					poly[2]=new Point(x+w4,y+h4);
					poly[3]=new Point(xw-h4,y+h4);
					poly[4]=new Point(xw-h4,y);
					poly[5]=new Point(xw,y);
					poly[6]=new Point(xw,yh);
					poly[7]=new Point(xw-w4,yh);
					poly[8]=new Point(xw-w4,yh-h4);
					poly[9]=new Point(x+w4,yh-h4);
					poly[10]=new Point(x+w4,yh);
					poly[11]=new Point(x,yh);
					break;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		void DrawLBar(Graphics gr)
		{
			Region rgn;
			Point[] poly=new Point[6];
			switch (FShape)
			{
				case ShapeType.LBarLeft:
					poly[0]=new Point(x,y);
					poly[1]=new Point(x,yh);
					poly[2]=new Point(xw,yh);
					poly[3]=new Point(xw,yh-h4);
					poly[4]=new Point(x+w4,yh-h4);
					poly[5]=new Point(x+w4,y);
					break;
				case ShapeType.LBarRight:
					poly[0]=new Point(xw,y);
					poly[1]=new Point(xw,yh);
					poly[2]=new Point(x,yh);
					poly[3]=new Point(x,yh-h4);
					poly[4]=new Point(xw-h4,yh-h4);
					poly[5]=new Point(xw-h4,y);
					break;
				case ShapeType.LBarUpLeft:
					poly[0]=new Point(x,y);
					poly[1]=new Point(xw,y);
					poly[2]=new Point(xw,y+h4);
					poly[3]=new Point(x+w4,y+h4);
					poly[4]=new Point(x+w4,yh);
					poly[5]=new Point(x,yh);
					break;
				case ShapeType.LBarUpRight:
					poly[0]=new Point(x,y);
					poly[1]=new Point(xw,y);
					poly[2]=new Point(xw,yh);
					poly[3]=new Point(xw-h4,yh);
					poly[4]=new Point(xw-h4,y+h4);
					poly[5]=new Point(x,y+h4);
					break;
			}
			if (FGradient)
			{
				rgn = new Region(new GraphicsPath(poly,
					new byte[] {
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
								   (byte)PathPointType.Line,
				},FillMode.Winding));
				gr.IntersectClip(rgn);
				FillWithGradient(gr);
				gr.ResetClip();
				gr.DrawPolygon(BorderPen,poly);
			}
			else
			{
				gr.FillPolygon(BackBrush,poly);
				gr.DrawPolygon(BorderPen,poly);
			}
		}

		int MulDiv(int Number,int Numerator,int Denominator)
		{
			if(Denominator==0)
				return -1;
			else
			{
				return (int)(Math.Round(((double)Number*(double)Numerator)/(double)Denominator,0));
			}
		}

		public void FillWithGradient(Graphics gr)
		{
			Color clrFrom,clrTo;
			byte RGBFromR,RGBFromG,RGBFromB;
			int RGBDiffR,RGBDiffG,RGBDiffB;
			LinearGradientBrush LinearBrush;

			OldColor=BackGroundColor;
			clrFrom = FGradientColor;
			clrTo = FGradientColor;

			switch( FFillDirection)
			{
				case FillDirection.Up: 
					clrFrom = BackGroundColor;
					break;
				case FillDirection.Down: 
					clrTo = BackGroundColor;
					break;
				case FillDirection.Left:
					clrFrom = BackGroundColor;
					break;
				case FillDirection.Right: 
					clrTo = BackGroundColor;
					break;
				case FillDirection.RectOut: 
					clrTo=BackGroundColor;
					break;
				case FillDirection.RectIn:
					clrFrom=BackGroundColor;
					break;
				case FillDirection.CircOut: 
					clrTo=BackGroundColor;
					break;
				case FillDirection.CircIn:
					clrFrom=BackGroundColor;
					break;
				case FillDirection.HorizCenter:
					clrFrom=BackGroundColor;
					break;
				case FillDirection.VertCenter:
					clrFrom=BackGroundColor;
					break;
				case FillDirection.NWSE:
				case FillDirection.NESW:
				case FillDirection.SENW:
				case FillDirection.SWNE:
					clrFrom=BackGroundColor;
					break;
				case FillDirection.Uright:
				case FillDirection.ULeft:
				case FillDirection.UUp:
				case FillDirection.UDown:
					clrFrom=BackGroundColor;
					break;
				case FillDirection.Duo:
				case FillDirection.Quatro:
				case FillDirection.RCMix:
				case FillDirection.RCModulo:
					clrFrom=BackGroundColor;
					break;
				case FillDirection.LNE:
				case FillDirection.LNW:
				case FillDirection.UpDown:
				case FillDirection.LeftRight:
					clrFrom=BackGroundColor;
					break;
			}

			RGBFromR = clrFrom.R;
			RGBFromG = clrFrom.G;
			RGBFromB = clrFrom.B;
			RGBDiffR = clrTo.R- RGBFromR;
			RGBDiffG = clrTo.G- RGBFromG;
			RGBDiffB = clrTo.B- RGBFromB;

			switch( FFillDirection)
			{
				case FillDirection.Left:
				case FillDirection.Right:
					LinearBrush=new LinearGradientBrush(new Rectangle(this.Location,this.Size),clrFrom,clrTo,LinearGradientMode.Horizontal);
					gr.FillRectangle(LinearBrush,new Rectangle(this.Location,this.Size));
					break;
				case FillDirection.Up:
				case FillDirection.Down:
					LinearBrush=new LinearGradientBrush(new Rectangle(this.Location,this.Size),clrFrom,clrTo,LinearGradientMode.Vertical);
					gr.FillRectangle(LinearBrush,new Rectangle(this.Location,this.Size));
					break;
				case FillDirection.RectOut:
				case FillDirection.RectIn:
					DoRectangle(gr, RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.CircOut:
				case FillDirection.CircIn:
					DoCircle(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.HorizCenter:
					DoHorizCenter(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.VertCenter: 
					DoVertCenter(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.NWSE: 
					doGradNWSE(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.NESW: 
					doGradNESW(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.SENW:
					doGradSENW(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.SWNE: 
					doGradSWNE(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.Uright:
					doGradURight(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.LNE:
					doGradLNE(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.LNW: 
					doGradLNW(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.ULeft: 
					doGradULeft(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.UUp:
					doGradUUp(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.UDown: 
					doGradUDown(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.RCMix: 
					doGradRCMix(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.RCModulo: 
					doGradRCModulo(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.Quatro: 
					doGradQuatro(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.Duo:
					doGradDuo(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.UpDown:
					doGradUpDown(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
				case FillDirection.LeftRight:
					doGradLeftRight(gr,RGBFromR,RGBFromG,RGBFromB,RGBDiffR,RGBDiffG,RGBDiffB);
					break;
			}
		}

		void DoRectangle(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double Pw, Ph;
			double x1,y1,x2,y2;
	
			x1 = 0;
			x2 = Width+2;
			y1 = 0;
			y2 = Height+2;
			Pw = ((double)Width) / 2 / 255;
			Ph = ((double)Height) / 2 / 255;
			for (I = 0;I<256;I++)
			{         //Make rectangles of color
				x1 = x1 + Pw;
				x2 = x2 - Pw;
				y1 = y1 + Ph;
				y2 = y2 - Ph;
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				Rectangle rect=RectangleFromGdi((int)(x1),(int)(y1),(int)(x2),(int)(y2));
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
			}
		}

		void DoCircle(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double Pw, Ph;
			double x1,y1,x2,y2;
	
			x1 = 0;
			x2 = Width+2;
			y1 = 0;
			y2 = Height+2;
			Pw = ((double)Width / 2) / 255;
			Ph = ((double)Height / 2) / 255;
			for (I = 0;I<256;I++)
			{         //Make cicles of color
				x1 = x1 + Pw;
				x2 = x2 - Pw;
				y1 = y1 + Ph;
				y2 = y2 - Ph;
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor =Color.FromArgb(R, G, B);   //Plug colors into brush
				Rectangle rect=RectangleFromGdi((int)(x1),(int)(y1),(int)(x2),(int)(y2));
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillEllipse(GraidentBrush,rect);
			}
		}

		Rectangle ConvertRectangleFromGdiRect(GdiRect Value)
		{
			return RectangleFromGdi(Value.Left,Value.Top,Value.Right,Value.Bottom);
		}

		void DoVertCenter(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			GdiRect ColorRect=new GdiRect();
			int I;
			int R, G, B;
			int Haf;
			Haf = Height / 2;
			ColorRect.Left = 0;
			ColorRect.Right = Width;
			for (I = 0;I<Haf+1;I++)
			{
				ColorRect.Top = MulDiv (I, Haf, Haf);
				ColorRect.Bottom = MulDiv (I + 1, Haf, Haf);
				R = fr + MulDiv(I, dr, Haf);
				G = fg + MulDiv(I, dg, Haf);
				B = fb + MulDiv(I, db, Haf);
				OldColor = Color.FromArgb(R, G, B);
				Rectangle rect=ConvertRectangleFromGdiRect(ColorRect);
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);		
				ColorRect.Top = Height - (MulDiv (I, Haf, Haf));
				ColorRect.Bottom = Height - (MulDiv (I + 1, Haf, Haf));
				rect=ConvertRectangleFromGdiRect(ColorRect);
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
			}
		}

		void DoHorizCenter(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			GdiRect ColorRect=new GdiRect();
			int I;
			int R, G, B;
			int Haf;

			Haf = Width / 2;
			ColorRect.Top = 0;
			ColorRect.Bottom = Height;
			for (I = 0;I<Haf+1;I++)
			{
				ColorRect.Left = MulDiv (I, Haf, Haf);
				ColorRect.Right = MulDiv (I + 1, Haf, Haf);
				R = fr + MulDiv(I, dr, Haf);
				G = fg + MulDiv(I, dg, Haf);
				B = fb + MulDiv(I, db, Haf);
				OldColor = Color.FromArgb(R, G, B);
				Rectangle rect=ConvertRectangleFromGdiRect(ColorRect);
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
				ColorRect.Left = Width - (MulDiv (I, Haf, Haf));
				ColorRect.Right =Width - (MulDiv (I + 1, Haf, Haf));
				rect=ConvertRectangleFromGdiRect(ColorRect);
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
			}
		}

		void doGradNWSE(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double pw;
			double x0,y0,x1,y1,x2,y2,x3,y3;
			Point[] points=new Point[4];
	
			pw = ((double)Width+(double)Height) / 255.0;
			for (I = 0;I<255;I++)
			{         //Make trapeziums of color
				x0 = I*pw;
				if (x0<Width)  
					y0=0; 
				else
				{
					y0=x0-Width;
					x0=Width-1;
				}
				x1=(I+1)*pw;
				if (x1<Width)
				{
					y1=0;
				}
				else 
				{
					y1=x1-Width;
					x1=Width-1;
				}
				y2=I*pw;
				if (y2<Height)  
					x2=0;
				else
				{
					x2=y2-Height;
					y2=Height-1;
				}
				y3=(I+1)*pw;
				if (y3<Height)  x3=0;
				else
				{
					x3=y3-Height;
					y3=Height-1;
				}
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				points[0]=new Point((int)(x0)+Location.X,(int)(y0)+Location.Y);
				points[1]=new Point((int)(x1)+Location.X,(int)(y1)+Location.Y);
				points[3]=new Point((int)(x2)+Location.X,(int)(y2)+Location.Y);
				points[2]=new Point((int)(x3)+Location.X,(int)(y3)+Location.Y);
				gr.FillPolygon(GraidentBrush,points);
			}
		}

		void doGradNESW(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double pw;
			double x0,y0,x1,y1,x2,y2,x3,y3;
			Point[] points=new Point[4];
	
			pw = ((double)Width+(double)Height) / 255;
			for (I = 0;I<255;I++)
			{         //Make trapeziums of color
				y0 = I*pw;
				if (y0<Height)
					x0=Width-1;
				else
				{
					x0=Width-1-(y0-Height);
					y0=Height-1;
				}
				y1=(I+1)*pw;
				if (y1<Height)  
					x1=Width-1; 
				else
				{
					x1=Width-1-(y1-Height);
					x1=Width-1;
				}
				x2=Width-1-(I*pw);
				if (x2>0) 
					y2=0;
				else
				{
					y2=-x2;
					x2=0;
				}
				x3=Width-1-((I+1)*pw);
				if (x3>0)  
					y3=0;
				else
				{
					y3=-x3;
					x3=0;
				}
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				points[0]=new Point((int)(x0)+Location.X,(int)(y0)+Location.Y);
				points[1]=new Point((int)(x1)+Location.X,(int)(y1)+Location.Y);
				points[3]=new Point((int)(x2)+Location.X,(int)(y2)+Location.Y);
				points[2]=new Point((int)(x3)+Location.X,(int)(y3)+Location.Y);
				gr.FillPolygon(GraidentBrush,points);
			}
		}

		void doGradSENW(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double pw;
			double x0,y0,x1,y1,x2,y2,x3,y3;
			Point[] points=new Point[4];
	
			pw = ((double)Width+(double)Height) / 255;
			for (I = 0;I<255;I++)
			{         //Make trapeziums of color
				y0 = Height-1-(I*pw);
				if (y0>0)
					x0=Width-1;
				else
				{
					x0=Width-1+y0;
					y0=0;
				}
				y1=Height-1-((I+1)*pw);
				if (y1>0)
					x1=Width-1;
				else
				{
					x1=Width-1+y1;
					y1=0;
				}
				x2=Width-1-(I*pw);
				if (x2>0) 
					y2=Height-1;
				else
				{
					y2=Height-1+x2;
					x2=0;
				}
				x3=Width-1-((I+1)*pw);
				if (x3>0)
					y3=Height-1;
				else
				{
					y3=Height-1+x3;
					x3=0;
				}
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				points[0]=new Point((int)(x0)+Location.X,(int)(y0)+Location.Y);
				points[1]=new Point((int)(x1)+Location.X,(int)(y1)+Location.Y);
				points[3]=new Point((int)(x2)+Location.X,(int)(y2)+Location.Y);
				points[2]=new Point((int)(x3)+Location.X,(int)(y3)+Location.Y);
				gr.FillPolygon(GraidentBrush,points);
			}
		}

		void doGradSWNE(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double pw;
			double x0,y0,x1,y1,x2,y2,x3,y3;
			Point[] points=new Point[4];
	
			pw = ((double)Width+(double)Height) / 255;
			for (I = 0;I<255;I++)
			{         //Make trapeziums of color
				y0 = Height-1-(I*pw);
				if (y0>0)
					x0=0;
				else
				{
					x0=-y0;
					y0=0;
				}
				y1=Height-1-((I+1)*pw);
				if (y1>0)  
					x1=0;
				else
				{
					x1=-y1;
					y1=0;
				}
				x2=(I*pw);
				if (x2<Width) 
					y2=Height-1;
				else
				{
					y2=Height-1-(x2-Width);
					x2=Width-1;
				}
				x3=(I+1)*pw;
				if (x3<Width)
					y3=Height-1;
				else
				{
					y3=Height-1-(x3-Width);
					x3=Width-1;
				}
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				points[0]=new Point((int)(x0)+Location.X,(int)(y0)+Location.Y);
				points[1]=new Point((int)(x1)+Location.X,(int)(y1)+Location.Y);
				points[3]=new Point((int)(x2)+Location.X,(int)(y2)+Location.Y);
				points[2]=new Point((int)(x3)+Location.X,(int)(y3)+Location.Y);
				gr.FillPolygon(GraidentBrush,points);
			}
		}

		void doGradURight(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double pw,ph;
			Point[] points=new Point[8];
	
			ph = ((double)Height/2) / 255;
			pw=(double)Width/255;
			for (I = 0;I<256;I++)
			{         //Make trapeziums of color
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				points[0]=new Point((int)(Width-1)+Location.X,(int)(I*ph)+Location.Y);
				points[1]=new Point((int)(I*pw)+Location.X,(int)(I*ph)+Location.Y);
				points[2]=new Point((int)(I*pw)+Location.X,(int)(Height-1-I*ph)+Location.Y);
				points[3]=new Point((int)(Width-1)+Location.X,(int)(Height-1-I*ph)+Location.Y);
				points[4]=new Point((int)(Width-1)+Location.X,(int)(Height-1-I*ph-ph)+Location.Y);
				points[5]=new Point((int)(I*pw+pw)+Location.X,(int)(Height-1-I*ph-ph)+Location.Y);
				points[6]=new Point((int)(I*pw+pw)+Location.X,(int)(I*ph+ph)+Location.Y);
				points[7]=new Point((int)(Width-1)+Location.X,(int)(I*ph+ph)+Location.Y);
				gr.FillPolygon(GraidentBrush,points);
			}
		}

		void doGradULeft(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double pw,ph;
			Point[] points=new Point[8];
	
			ph = ((double)Height/2) / 255;
			pw=(double)Width/255;
			for (I = 0;I<256;I++)
			{         //Make trapeziums of color
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				points[0]=new Point((int)(0)+Location.X,(int)(I*ph)+Location.Y);
				points[1]=new Point((int)(Width-1-I*pw)+Location.X,(int)(I*ph)+Location.Y);
				points[2]=new Point((int)(Width-1-I*pw)+Location.X,(int)(Height-1-I*ph)+Location.Y);
				points[3]=new Point((int)(0)+Location.X,(int)(Height-1-I*ph)+Location.Y);
				points[4]=new Point((int)(0)+Location.X,(int)(Height-1-I*ph-ph)+Location.Y);
				points[5]=new Point((int)(Width-1-I*pw-pw)+Location.X,(int)(Height-1-I*ph-ph)+Location.Y);
				points[6]=new Point((int)(Width-1-I*pw-pw)+Location.X,(int)(I*ph+ph)+Location.Y);
				points[7]=new Point((int)(0)+Location.X,(int)(I*ph+ph)+Location.Y);
				gr.FillPolygon(GraidentBrush,points);
			}
		}

		void doGradUDown(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double pw,ph;
			Point[] points=new Point[8];

			ph = (double)Height / 255;
			pw=(double)Width/2/255;
			for (I = 0;I<256;I++)
			{         //Make trapeziums of color
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				points[0]=new Point((int)(I*pw)+Location.X,(int)(Height-1)+Location.Y);
				points[1]=new Point((int)(I*pw)+Location.X,(int)(I*ph)+Location.Y);
				points[2]=new Point((int)(Width-1-I*pw)+Location.X,(int)(I*ph)+Location.Y);
				points[3]=new Point((int)(Width-1-I*pw)+Location.X,(int)(Height-1)+Location.Y);
				points[4]=new Point((int)(Width-1-I*pw-pw)+Location.X,(int)(Height-1)+Location.Y);
				points[5]=new Point((int)(Width-1-I*pw-pw)+Location.X,(int)(I*ph+ph)+Location.Y);
				points[6]=new Point((int)(I*pw+pw)+Location.X,(int)(I*ph+ph)+Location.Y);
				points[7]=new Point((int)(I*pw+pw)+Location.X,(int)(Height-1)+Location.Y);
				gr.FillPolygon(GraidentBrush,points);
			}
		}

		void doGradUUp(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double pw,ph;
			Point[] points=new Point[8];
	
			ph = (double)Height / 255;
			pw=(double)Width/2/255;
			for (I = 0;I<256;I++)
			{         //Make trapeziums of color
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				points[0]=new Point((int)(I*pw)+Location.X,(int)(0)+Location.Y);
				points[1]=new Point((int)(I*pw)+Location.X,(int)(Height-1-I*ph)+Location.Y);
				points[2]=new Point((int)(Width-1-I*pw)+Location.X,(int)(Height-1-I*ph)+Location.Y);
				points[3]=new Point((int)(Width-1-I*pw)+Location.X,(int)(0)+Location.Y);
				points[4]=new Point((int)(Width-1-I*pw-pw)+Location.X,(int)(0)+Location.Y);
				points[5]=new Point((int)(Width-1-I*pw-pw)+Location.X,(int)(Height-1-I*ph-ph)+Location.Y);
				points[6]=new Point((int)(I*pw+pw)+Location.X,(int)(Height-1-I*ph-ph)+Location.Y);
				points[7]=new Point((int)(I*pw+pw)+Location.X,(int)(0)+Location.Y);
				gr.FillPolygon(GraidentBrush,points);
			}
		}

		void doGradRCMix(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I,x3,y3;
			int R, G, B;
			double pw,ph;
			Rectangle rect;
	
			ph = ((double)Height/2) / 255;
			pw=((double)Width/2)/255;
			for (I = 0;I<256;I++)
			{         //Make trapeziums of color
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				x3=(int)(Width-2*I*pw) / 4;
				y3=(int)(Height-2*I*ph) / 4;
				if (I==0)
				{ x3=0;y3=0; }
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				if (I<63)
				{
					rect=RectangleFromGdi((int)(I*pw),(int)(I*ph),
						(int)(Width-I*pw),(int)(Height-1-I*ph));
					rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
					gr.FillRectangle(GraidentBrush,rect);
				}
				else
				{
					rect=RectangleFromGdi((int)(I*pw),(int)(I*ph),
						(int)(Width-I*pw),(int)(Height-1-I*ph));
					rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
					gr.FillEllipse(GraidentBrush,rect);
				}
			}
		}

		void doGradRCModulo(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I,x3,y3;
			int R, G, B;
			double pw,ph;
			bool IsRect;
			Rectangle rect;
	
			ph = ((double)Height/2) / 255;
			pw=((double)Width/2)/255;
			IsRect=false;
			for (I = 0;I<256;I++)
			{         //Make trapeziums of color
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				x3=(int)(Width-2*I*pw) / 4;
				y3=(int)(Height-2*I*ph) / 4;
				if (I==0)  
				{ x3=0;y3=0; }
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				if (I % 10==0)
					IsRect=!IsRect;
				if (IsRect) 
				{
					rect=RectangleFromGdi((int)(I*pw),(int)(I*ph),
						(int)(Width-I*pw),(int)(Height-1-I*ph));
					rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
					gr.FillRectangle(GraidentBrush,rect);
				}
				else
				{
					rect=RectangleFromGdi((int)(I*pw),(int)(I*ph),
						(int)(Width-I*pw),(int)(Height-1-I*ph));
					rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
					gr.FillEllipse(GraidentBrush,rect);
				}
			}
		}

		void doGradQuatro(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I,w2,h2;
			int R, G, B;
			double pw,ph;
			Rectangle rect;
	
			ph = ((double)Height/4) / 255;
			pw=((double)Width/4)/255;
			w2=Width / 2;
			h2=Height / 2;
			for (I = 0;I<256;I++)
			{         //Make trapeziums of color
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				rect=RectangleFromGdi((int)(I*pw),(int)(I*ph),
					(int)(w2+1-I*pw),(int)(h2+1-I*ph));
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
				rect=RectangleFromGdi((int)(w2-1+I*pw),(int)(I*ph),
					(int)(Width-1-I*pw),(int)(h2+1-I*ph));
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
				rect=RectangleFromGdi((int)(I*pw),(int)(h2-1+I*ph),
					(int)(w2+1-I*pw),(int)(Height-1-I*ph));
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
				rect=RectangleFromGdi((int)(w2-1+I*pw),(int)(h2-1+I*ph),
					(int)(Width-1-I*pw),(int)(Height-1-I*ph));
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
			}
		}

		void doGradDuo(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I,w2;
			int R, G, B;
			double pw,ph;
			Rectangle rect;
	
			ph = ((double)Height/2) / 255;
			pw=((double)Width/4)/255;
			w2=Width / 2;
			for (I = 0;I<256;I++)
			{         //Make trapeziums of color
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				rect=RectangleFromGdi((int)(I*pw),(int)(I*ph),
					(int)(w2+1-I*pw),(int)(Height-1-I*ph));
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
				rect=RectangleFromGdi((int)(w2-1+I*pw),(int)(I*ph),
					(int)(Width-1-I*pw),(int)(Height-1-I*ph));
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
			}
		}

		void doGradLNE(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double pw,ph;
			Point[] points=new Point[6];
	
			ph = (double)Height / 255;
			pw=(double)Width/255;
			for (I = 0;I<256;I++)
			{         //Make trapeziums of color
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				points[0]=new Point((int)(I*pw)+Location.X,0+Location.Y);
				points[1]=new Point((int)(I*pw)+Location.X,(int)(Height-1-I*ph)+Location.Y);
				points[2]=new Point((int)(Width-1)+Location.X,(int)(Height-1-I*ph)+Location.Y);
				points[3]=new Point((int)(Width-1)+Location.X,(int)(Height-1-I*ph-ph)+Location.Y);
				points[4]=new Point((int)(I*pw+pw)+Location.X,(int)(Height-1-I*ph-ph)+Location.Y);
				points[5]=new Point((int)(I*pw+pw)+Location.X,0+Location.Y);
				gr.FillPolygon(GraidentBrush,points);
			}
		}

		void doGradLNW(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double pw,ph;
			Point[] points=new Point[6];
	
			ph = (double)Height / 255;
			pw=(double)Width/255;
			for (I = 0;I<256;I++)
			{         //Make trapeziums of color
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				points[0]=new Point((int)(Width-1-I*pw)+Location.X,0+Location.Y);
				points[1]=new Point((int)(Width-1-I*pw)+Location.X,(int)(Height-1-I*ph)+Location.Y);
				points[2]=new Point(0+Location.X,(int)(Height-1-I*ph)+Location.X+Location.Y);
				points[3]=new Point(0+Location.X,(int)(Height-1-I*ph-ph)+Location.Y);
				points[4]=new Point((int)(Width-1-I*pw-pw)+Location.X,(int)(Height-1-I*ph-ph)+Location.Y);
				points[5]=new Point((int)(Width-1-I*pw-pw)+Location.X,0+Location.Y);
				gr.FillPolygon(GraidentBrush,points);
			}
		}

		void doGradUpDown(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double ph;
			int w2;
			Rectangle rect;
	
			ph = (double)Height / 255;
			w2=Width / 2;
			for (I = 0;I<256;I++)
			{         //Make trapeziums of color
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				rect=RectangleFromGdi(0,(int)(I*ph),w2,(int)(I*ph+ph));
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
				rect=RectangleFromGdi(w2,(int)(Height-1-I*ph-ph),Width-1,(int)(Height-1-I*ph));
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
			}
		}

		void doGradLeftRight(Graphics gr,int fr,int fg,int fb,int dr,int dg,int db)
		{
			int I;
			int R, G, B;
			double pw;
			int h2;
			Rectangle rect;
	
			pw = (double)Width / 255.0;
			h2=Height / 2;
			for (I = 0;I<256;I++)
			{         //Make trapeziums of color
				R = fr + MulDiv(I, dr, 255);    //Find the RGB values
				G = fg + MulDiv(I, dg, 255);
				B = fb + MulDiv(I, db, 255);
				OldColor = Color.FromArgb(R, G, B);   //Plug colors into brush
				rect=RectangleFromGdi((int)(I*pw),0,(int)(I*pw+pw),h2);
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
				rect=RectangleFromGdi((int)(Width-1-I*pw-pw),h2,(int)(Width-1-I*pw),Height-1);
				rect.Location=new Point(Location.X+rect.Location.X,Location.Y+rect.Location.Y);
				gr.FillRectangle(GraidentBrush,rect);
			}
		}
		#endregion
	}
	#endregion
}
