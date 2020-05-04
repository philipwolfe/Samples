using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region RulerBar
	public class RulerBar:Control
	{
		#region class events
		public event EventHandler Change;
		#endregion

		#region class variables
		RulerBarOrientation FOrientation;
		int FGutter;
		bool FModified;
		int FInUpdate;
		double FPageWidth;
		double FLeftMargin;
		double FRightMargin;
		Units FUnits;
		double FSelBegin;
		double FSelEnd;
		int FCur;
		Color FSelColor;
		Color FRulerColor;
		int ControlFlag;

		static int DownX;
		static MovedMargin MovedMargin;
		static double DownMargin;
		#endregion
		
		#region constructor
		public RulerBar()
		{
			Dock=DockStyle.Top;			
			SetStyle(ControlStyles.UserPaint|ControlStyles.AllPaintingInWmPaint|ControlStyles.DoubleBuffer,true);
		}
		#endregion

		#region class properties
		public double PageWidth
		{
			get
			{
				return FPageWidth;
			}
			set
			{
				if(FPageWidth!=value)
				{
					FPageWidth=value;
					FModified=true;
					DoUpdate();
				}
			}
		}

		public double LeftMargin
		{
			get
			{
				return FLeftMargin;
			}
			set
			{
				if(FLeftMargin!=value)
				{
					FLeftMargin=value;
					FModified=true;
					DoUpdate();
				}
			}
		}

		public double RightMargin
		{
			get
			{
				return FRightMargin;
			}
			set
			{
				if(FRightMargin!=value)
				{
					FRightMargin=value;
					FModified=true;
					DoUpdate();
				}
			}
		}

		public Units Units
		{
			get
			{
				return FUnits;
			}
			set
			{
				if(FUnits!=value)
				{
					FUnits=value;
					FModified=true;
					DoUpdate();
				}
			}
		}

		public double SelBegin
		{
			get
			{
				return FSelBegin;
			}
			set
			{
				if(FSelBegin!=value)
				{
					FSelBegin=value;
					FModified=true;
					DoUpdate();
				}
			}
		}

		public double SelEnd
		{
			get
			{
				return FSelEnd;
			}
			set
			{
				if(FSelEnd!=value)
				{
					FSelEnd=value;
					FModified=true;
					DoUpdate();
				}
			}
		}

		public int Cur
		{
			get
			{
				return FCur;
			}
			set
			{
				if(FCur!=value)
				{
					FCur=value;
					FModified=true;
					DoUpdate();
				}
			}
		}

		public Color SelColor
		{
			get
			{
				return FSelColor;
			}
			set
			{
				if(FSelColor!=value)
				{
					FSelColor=value;
					FModified=true;
					DoUpdate();
				}
			}
		}

		public Color RulerColor
		{
			get
			{
				return FRulerColor;
			}
			set
			{
				if(FRulerColor!=value)
				{
					FRulerColor=value;
					FModified=true;
					DoUpdate();
				}
			}
		}

		public RulerBarOrientation Orientation
		{
			get
			{
				return FOrientation;
			}
			set
			{	
				if(FOrientation!=value)
				{
					FOrientation=value;
					switch(FOrientation)
					{
						case RulerBarOrientation.Horizontal:
							Dock=DockStyle.Top;
							Height=35;
							break;
						case RulerBarOrientation.Vertical:
							Dock=DockStyle.Left;
							Width=35;
							break;
					}
					Invalidate();
				}
			}
		}

		public int Gutter
		{
			get
			{
				return FGutter;
			}
			set
			{
				if(FGutter!=value)
				{
					FGutter=value;
					FModified=true;
					DoUpdate();
				}
			}
		}
		#endregion

		#region class methods
		protected override void OnMouseUp(MouseEventArgs e)
		{
			
			if(ControlFlag==1)
				if(Change!=null)
					Change(this,EventArgs.Empty);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if(Orientation==RulerBarOrientation.Horizontal)
			{
				if(e.Button.ToString().IndexOf("Left")!=-1)
					DownX=e.X;
			}
			else
			{
				if(e.Button.ToString().IndexOf("Left")!=-1)
					DownX=e.Y;
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			int d;
			ControlFlag=0;
			if(Orientation==RulerBarOrientation.Horizontal)
			{
				BeginUpdate();
				if(e.Button.ToString().IndexOf("Left")==-1)
				{
					if(Math.Abs(e.X-(Gutter+Generic.ToPix(LeftMargin)))<5)
					{
						Cursor=Cursors.VSplit;
						MovedMargin=MovedMargin.Left;
						DownMargin=LeftMargin;
					}
					else
					{
						if(Math.Abs(e.X-(Gutter+Generic.ToPix(PageWidth)-Generic.ToPix(RightMargin)))<5)
						{
							Cursor=Cursors.VSplit;
							MovedMargin=MovedMargin.Right;
							DownMargin=RightMargin;
						}
						else
						{
							Cursor=Cursors.Default;
							MovedMargin=MovedMargin.None;
						}
					}
				}
				else
				{
					if(e.Button.ToString().IndexOf("Left")!=-1)
					{
						d=e.X-DownX;
						switch(MovedMargin)
						{
							case MovedMargin.None:
								break;
							case MovedMargin.Left:
								LeftMargin=Math.Max((DownMargin+Generic.FromPix(d))/Generic.ZoomFactor,0);
								LeftMargin=LeftMargin*Generic.ZoomFactor;
								ControlFlag=1;
								break;
							case MovedMargin.Right:
								RightMargin=Math.Max((DownMargin-Generic.FromPix(d))/Generic.ZoomFactor,0);
								RightMargin=RightMargin*Generic.ZoomFactor;
								ControlFlag=1;
								break;
						}
					}
				}
				Cur=e.X;
				EndUpdate();
			}
			else
			{
				BeginUpdate();
				if(e.Button.ToString().IndexOf("Left")==-1)
				{
					if(Math.Abs(e.Y-(Gutter+Generic.ToPix(LeftMargin)))<5)
					{
						Cursor=Cursors.HSplit;
						MovedMargin=MovedMargin.Left;
						DownMargin=LeftMargin;
					}
					else
					{
						if(Math.Abs(e.Y-(Gutter+Generic.ToPix(PageWidth)-Generic.ToPix(RightMargin)))<5)
						{
							Cursor=Cursors.HSplit;
							MovedMargin=MovedMargin.Right;
							DownMargin=RightMargin;
						}
						else
						{
							Cursor=Cursors.Default;
							MovedMargin=MovedMargin.None;
						}
					}
				}
				else
				{
					if(e.Button.ToString().IndexOf("Left")!=-1)
					{
						d=e.Y-DownX;
						switch(MovedMargin)
						{
							case MovedMargin.None:
								break;
							case MovedMargin.Left:
								LeftMargin=Math.Max((DownMargin+Generic.FromPix(d))/Generic.ZoomFactor,0);
								LeftMargin=LeftMargin*Generic.ZoomFactor;
								ControlFlag=1;
								break;
							case MovedMargin.Right:
								RightMargin=Math.Max((DownMargin-Generic.FromPix(d))/Generic.ZoomFactor,0);
								RightMargin=RightMargin*Generic.ZoomFactor;
								ControlFlag=1;
								break;
						}
					}
				}
				Cur=e.Y;
				EndUpdate();
			}
		}

		public void BeginUpdate()
		{
			FInUpdate++;
		}

		public void EndUpdate()
		{
			FInUpdate--;
			DoUpdate();
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			int a, b, c, d;
			Graphics gr=e.Graphics;

			Brush brush=new SolidBrush(BackColor);
			Pen pen;
			gr.FillRectangle(brush,this.Left,this.Top,Width,Height);
			switch(Orientation)
			{
				case RulerBarOrientation.Horizontal:
				{
					a=Gutter+Generic.ToPix(LeftMargin);
					b=Gutter;
					c=Gutter+Generic.ToPix(PageWidth)-Generic.ToPix(RightMargin);
					d=Gutter+Generic.ToPix(PageWidth);

					brush=new SolidBrush(RulerColor);					
					gr.FillRectangle(brush,Gutter,2,Generic.ToPix(PageWidth),20);
					
					pen=new Pen(Color.Black);
					brush=new SolidBrush(Color.White);
					ShowGrid(gr,pen,brush);

					pen=new Pen(Color.Black);
					gr.DrawLine(pen,b,0,b,Height);					

					pen=new Pen(Color.Black);
					gr.DrawLine(pen,d,0,d,Height);

					pen=new Pen(Color.Red);
					gr.DrawLine(pen,c,0,c,Height);

					pen=new Pen(Color.Red);
					gr.DrawLine(pen,a,0,a,Height);

					brush=new SolidBrush(SelColor);
					gr.FillRectangle(brush,b+1,3,a-(b+1),18);
					gr.FillRectangle(brush,c+1,3,Math.Abs(d-(c+1)),18);
					gr.FillRectangle(brush,Gutter+Generic.ToPix(LeftMargin)+1+Generic.ToPix(SelBegin),22,
						Math.Abs(Generic.ToPix(SelBegin)-Generic.ToPix(SelEnd)),12);
					
					string s=String.Format("{0:F}",(LeftMargin/Generic.UnitRatio(Units))/Generic.ZoomFactor);
					RectangleF rect=new RectangleF(b+2,4,Math.Abs((b+2)-(a-1)),16);
					StringFormat drawFormat = new StringFormat();
					drawFormat.Alignment = StringAlignment.Center;
					brush=new SolidBrush(Color.Black);
					gr.DrawString(s,Font,brush,rect,drawFormat);

					s=String.Format("{0:F}",(RightMargin/Generic.UnitRatio(Units))/Generic.ZoomFactor);
					rect=new RectangleF(c+2,4,Math.Abs((d-1)-(c+2)),16);
					
					brush=new SolidBrush(Color.Black);
					gr.DrawString(s,Font,brush,rect,drawFormat);

					s=UnitsToText(((SelEnd-SelBegin)/Generic.ZoomFactor)/Generic.UnitRatio(Units));					
					rect=new RectangleF(Gutter+Generic.ToPix(LeftMargin)+1+Generic.ToPix(SelBegin),22,
						Math.Abs(Generic.ToPix(SelBegin)-Generic.ToPix(SelEnd)),12);
					
					brush=new SolidBrush(Color.Black);
					gr.DrawString(s,Font,brush,rect,drawFormat);
					

					s=UnitsToText((SelBegin/Generic.ZoomFactor)/Generic.UnitRatio(Units));
					brush=new SolidBrush(Color.Black);
					gr.DrawString(s,Font,brush,Gutter+Generic.ToPix(LeftMargin)+1+Generic.ToPix(SelBegin)-
						gr.MeasureString(s,Font).Width,21);


					pen=new Pen(Color.Green);
					gr.DrawLine(pen,FCur,0,FCur,Height);					
					break;
				}
				case RulerBarOrientation.Vertical:
				{
					a=Gutter+Generic.ToPix(LeftMargin)+2;
					b=Gutter+2;
					c=Gutter+Generic.ToPix(PageWidth)-Generic.ToPix(RightMargin)+3;
					d=Gutter+Generic.ToPix(PageWidth)+3;

					brush=new SolidBrush(RulerColor);
					gr.FillRectangle(brush,2,1,20,Height);

					pen=new Pen(Color.Black);
					brush=new SolidBrush(Color.Black);
					ShowGrid(gr,pen,brush);

					pen=new Pen(Color.Black);
					gr.DrawLine(pen,0,b,Width,b);

					pen=new Pen(Color.Black);
					gr.DrawLine(pen,0,d,Width,d);

					pen=new Pen(Color.Red);
					gr.DrawLine(pen,0,a,Width,a);

					pen=new Pen(Color.Red);
					gr.DrawLine(pen,0,c,Width,c);

					brush=new SolidBrush(SelColor);	
					gr.FillRectangle(brush,3,b+1,18,a-b-1);
					gr.FillRectangle(brush,3,c+1,18,Math.Abs(d-(c+1)));
					gr.FillRectangle(brush,22,Gutter+Generic.ToPix(SelBegin)+Generic.ToPix(LeftMargin),12,
						Math.Abs((Gutter+Generic.ToPix(SelEnd)+1)-(Gutter+Generic.ToPix(SelBegin))));						

					brush=Brushes.Black;
					string s=String.Format("{0:F}",(LeftMargin/Generic.UnitRatio(Units))/Generic.ZoomFactor);
					RectangleF rect=new RectangleF(4,b+2,16,Math.Abs((b+2)-(a-1)));
					Generic.ShowText(gr,brush,rect,s,Font);

					s=String.Format("{0:F}",(RightMargin/Generic.UnitRatio(Units))/Generic.ZoomFactor);
					rect=new RectangleF(4,c+2,16,Math.Abs((d-1)-(c+2)));
					Generic.ShowText(gr,brush,rect,s,Font);

					s=UnitsToText(((SelEnd-SelBegin)/Generic.ZoomFactor)/Generic.UnitRatio(Units));
					brush=Brushes.Black;
					rect=new RectangleF(21,Gutter+Generic.ToPix(SelBegin)+Generic.ToPix(LeftMargin),
						13,Math.Abs((Gutter+Generic.ToPix(SelBegin))-(Gutter+Generic.ToPix(SelEnd))));
					Generic.ShowText(gr,brush,rect,s,Font);

					s=UnitsToText((SelBegin/Generic.ZoomFactor)/Generic.UnitRatio(Units));
					SizeF th=gr.MeasureString(s,Font);
					rect=new RectangleF(new PointF(21,Gutter+Generic.ToPix(SelBegin)-th.Width+Generic.ToPix(LeftMargin)),
						new SizeF(th.Height,th.Width));
					Generic.ShowText(gr,brush,rect,s,Font);

					pen=new Pen(Color.Green);
					gr.DrawLine(pen,0,FCur,Width,FCur);					
					break;
				}
			}			
		}

		void ShowGrid(Graphics gr,Pen pen,Brush brush)
		{
			switch(Orientation)
			{
				case RulerBarOrientation.Horizontal:
				switch(Units)
				{
					case Units.Pix:
						HShowPixGrid(gr,pen,brush);
						break;
					case Units.Cm:
						HShowCmGrid(gr,pen,brush);
						break;
					case Units.MM:
						HShowMmGrid(gr,pen,brush);
						break;
					case Units.In:
						HShowInGrid(gr,pen,brush);
						break;
				}
					break;
				case RulerBarOrientation.Vertical:
				switch(Units)
				{
					case Units.Pix:
						VShowPixGrid(gr,pen,brush);
						break;
					case Units.MM:
						VShowMmGrid(gr,pen,brush);
						break;
					case Units.Cm:
						VShowCmGrid(gr,pen,brush);
						break;
					case Units.In:
						VShowInGrid(gr,pen,brush);
						break;
				}
					break;
			}
		}

		void HShowPixGrid(Graphics gr,Pen pen,Brush brush)
		{
			float k;			
			string s;
			int hun=0;
			
			for(k=0;k<Generic.ToPix(PageWidth);k=k+(10*Generic.ZoomFactor))
			{
				if(hun%10==0)
				{
					gr.DrawLine(pen,Gutter+k,8,Gutter+k,22);
					s=UnitsToText(hun*10);
					gr.DrawString(s,Font,new SolidBrush(Color.Black),Gutter+k+2,3);
				}
				else
				{
					if(hun%5==0)
					{
						gr.DrawLine(pen,Gutter+k,15,Gutter+k,22);
					}
					else
					{
						gr.DrawLine(pen,Gutter+k,19,Gutter+k,22);						
					}						
				}
				hun=hun+1;
			} 
		}

		void VShowPixGrid(Graphics gr,Pen pen, Brush brush)
		{			
			string s;			
			float k;
			int hun=0;
			for(k=0;k<Height-Gutter;k=k+(10*Generic.ZoomFactor))
			{
				if(hun%10==0)
				{
					gr.DrawLine(pen,8,Gutter+k,22,Gutter+k);
					s=UnitsToText(hun*10);
					RectangleF r;
					SizeF th=gr.MeasureString(s,Font);			
					r=new RectangleF(new PointF(3,Gutter+k+2),new SizeF(th.Height,th.Width));
					Generic.ShowText(gr,brush,r,s,Font);
				}
				else
				{
					if(hun%5==0)
					{
						gr.DrawLine(pen,15,Gutter+k,22,Gutter+k);
					}
					else
					{	
						gr.DrawLine(pen,19,Gutter+k,22,Gutter+k);						
					}
				}
				hun=hun+1;
			}            			
		}

		void HShowCmGrid(Graphics gr,Pen pen,Brush brush)
		{
			double u;
			int s=0;
			int i;
			u=0;
			do
			{
				i=Generic.ToPix(u);
				gr.DrawLine(pen,Gutter+i,8,Gutter+i,22);
				if((Generic.ZoomFactor>0.5F)||(s%2==0))
					gr.DrawString(s.ToString(),Font,new SolidBrush(Color.Black),Gutter+i+2,3);
				u=u+(50*Generic.ZoomFactor);
				i=Generic.ToPix(u);
				if(u > PageWidth)
					break;
				gr.DrawLine(pen,Gutter+i,15,Gutter+i,22);
				u=u+(50*Generic.ZoomFactor);
				s++;
			}while(u<PageWidth);
		}

		void VShowCmGrid(Graphics gr,Pen pen, Brush brush)
		{
			double u;
			int s=0;
			int i;
			u=0;i=0;
			do
			{
				gr.DrawLine(pen,8,Gutter+i,22,Gutter+i);
				
				if((Generic.ZoomFactor>0.5F)||(s%2==0))
				{
					RectangleF r;
					SizeF th=gr.MeasureString(s.ToString(),Font);					
					r=new RectangleF(new PointF(3,Gutter+i+2),new SizeF(th.Height,th.Width));
					Generic.ShowText(gr,brush,r,s.ToString(),Font);
				}

				u=u+(50*Generic.ZoomFactor);
				i=Generic.ToPix(u);
				if(i> Height-Gutter)
					break;
				gr.DrawLine(pen,15,Gutter+i,22,Gutter+i);
				u=u+(50*Generic.ZoomFactor);
				i=Generic.ToPix(u);
				s++;
			}while(i<Height-Gutter);
		}

		protected string UnitsToText(double Val)
		{
			if((Units==Units.Pix)||(Math.Round(Val)==Val))
				return Convert.ToString(Math.Round(Val));
			else
				return String.Format("{0:f2}",Val);
		}

		void HShowMmGrid(Graphics gr,Pen pen, Brush brush)
		{
			double u;
			int s=0;
			int i;
			u=0;
			do
			{
				i=Generic.ToPix(u);
				gr.DrawLine(pen,Gutter+i,8,Gutter+i,22);
				if((Generic.ZoomFactor>0.5F)||(s%2==0))
					gr.DrawString(Convert.ToString(s*10),Font,new SolidBrush(Color.Black),Gutter+i+2,3);
				u=u+(50*Generic.ZoomFactor);
				i=Generic.ToPix(u);
				if(u >PageWidth )
					break;
				gr.DrawLine(pen,Gutter+i,15,Gutter+i,22);
				u=u+(50*Generic.ZoomFactor);
				s++;
			}while(u<PageWidth );
		}

		void VShowMmGrid(Graphics gr,Pen pen, Brush brush)
		{
			double u;
			int s=0;
			int i;
			u=0;i=0;
			do
			{
				gr.DrawLine(pen,8,Gutter+i,22,Gutter+i);
				if((Generic.ZoomFactor>0.5F)||(s%2==0))
				{
					RectangleF r;
					SizeF th=gr.MeasureString(Convert.ToString(s*10),Font);					
					r=new RectangleF(new PointF(3,Gutter+i+2),new SizeF(th.Height,th.Width));
					Generic.ShowText(gr,brush,r,Convert.ToString(s*10),Font);
				}
				u=u+(50*Generic.ZoomFactor);
				i=Generic.ToPix(u);
				if(i> Height-Gutter)
					break;
				gr.DrawLine(pen,15,Gutter+i,22,Gutter+i);
				u=u+(50*Generic.ZoomFactor);
				i=Generic.ToPix(u);
				s++;
			}while(i<Height-Gutter);
		}

		void HShowInGrid(Graphics gr,Pen pen, Brush brush)
		{
			double u;
			double s=0;
			int i;
			int k;
			u=0;
			do
			{
				i=Generic.ToPix(u);
				gr.DrawLine(pen,Gutter+i,8,Gutter+i,22);
				gr.DrawString(string.Format("{0:F2}",s),Font,new SolidBrush(Color.Black),Gutter+i+2,3);

				for(k=1;k<5;k++)
				{
					u=u+((254.0/10.0)*Generic.ZoomFactor);
					i=Generic.ToPix(u);
					if(u>PageWidth)
						break;
					gr.DrawLine(pen,Gutter+i,19,Gutter+i,22);
				}
				u=u+((254.0/10.0)*Generic.ZoomFactor);
				i=Generic.ToPix(u);
				if(u>PageWidth)
					break;
				gr.DrawLine(pen,Gutter+i,15,Gutter+i,22);

				for(k=1;k<5;k++)
				{
					u=u+((254.0/10.0)*Generic.ZoomFactor);
					i=Generic.ToPix(u);
					if(u>PageWidth)
						break;
					gr.DrawLine(pen,Gutter+i,19,Gutter+i,22);
				}
				u=u+((254.0/10.0)*Generic.ZoomFactor);
				s++;
			}while(u < PageWidth );
		}

		void VShowInGrid(Graphics gr,Pen pen, Brush brush)
		{
			double u;
			double s=0;
			int i;
			int k;
			u=0;i=0;
			do
			{
				gr.DrawLine(pen,8,Gutter+i,22,Gutter+i);
				RectangleF r;
				SizeF th=gr.MeasureString(string.Format("{0:F2}",s),Font);					
				r=new RectangleF(new PointF(3,Gutter+i+2),new SizeF(th.Height,th.Width));
				Generic.ShowText(gr,brush,r,string.Format("{0:F2}",s),Font);

				for(k=1;k<5;k++)
				{
					u=u+((254.0/10.0)*Generic.ZoomFactor);
					i=Generic.ToPix(u);
					if(i>Height-Gutter)
						break;
					gr.DrawLine(pen,19,Gutter+i,22,Gutter+i);
				}
				u=u+((254.0/10.0)*Generic.ZoomFactor);
				i=Generic.ToPix(u);
				if(i>Height-Gutter)
					break;
				gr.DrawLine(pen,15,Gutter+i,22,Gutter+i);

				for(k=1;k<5;k++)
				{
					u=u+((254.0/10.0)*Generic.ZoomFactor);
					i=Generic.ToPix(u);
					if(i>Height-Gutter)
						break;
					gr.DrawLine(pen,19,Gutter+i,22,Gutter+i);
				}
				u=u+((254.0/10.0)*Generic.ZoomFactor);
				i=Generic.ToPix(u);
				s++;
			}while(i<Height-Gutter);
		}

		protected void DoUpdate()
		{
			if((!InUpdate())&&(FModified))
			{
				FModified=false;
				Invalidate();
			}
		}

		protected bool InUpdate()
		{
			if(FInUpdate!=0)
				return true;
			else
				return false;
		}
		#endregion	
	}
	#endregion

	#region enums
	public enum RulerBarOrientation
	{
		Horizontal,Vertical
	}

	public enum MovedMargin
	{
		None,Left,Right
	}
	#endregion
}
