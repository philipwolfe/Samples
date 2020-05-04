using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.IO;
using System.Drawing.Imaging;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region Generic
	public class Generic
	{
		#region class variables
		public static int BandCnt=0;
		public static int CellCnt=0;
		public static int RepCnt=0;
		public static Form CurPopupForm;
		public static int[] CellBorderWidths=
			{
				1, 1, 1, 1, 1, 3, 4, 4
			};

		public static int[,] CellBorderDots=
			{
				{ 10000000,  10000000,  0,  0,  0,  0,  0,  0},
				{       18,         6,  0,  0,  0,  0,  0,  0},
				{        3,         3,  3,  3,  3,  3,  3,  3},
				{        9,         6,  3,  6,  0,  0,  0,  0},
				{        9,         3,  3,  3,  3,  3,  0,  0},
				{ 10000000,  10000000,  0,  0,  0,  0,  0,  0},
				{ 10000000,  10000000,  0,  0,  0,  0,  0,  0},
				{ 10000000,  10000000,  0,  0,  0,  0,  0,  0}
			};

		public static string[] CellBorderNames=
			{
				"Solid","Dash","Dot","DashDot","DashDotDot",
				"Double11","Double21","Double12"
			};

		public static ArrayList ListStringList=new ArrayList();

		public static int GridRepCnt=0;

		public static bool ShowHiddenItems;
		public static bool NonPrinting;

		public static float ZoomFactor;
		public static float OldZoomFactor;

		public static int page=1;

		public static CultureInfo inf=new CultureInfo("en-US");
		#endregion

		#region class methods
		public static Color FindColor(Color BaseColor,RenderingMode Mode)
		{
			int Average;
			switch(Mode)
			{
				case RenderingMode.Normal:
					return BaseColor;
				case RenderingMode.BlackAndWhite:
					Average=(BaseColor.R+BaseColor.G+BaseColor.B)/3;
					if(Average<=128)
						return Color.Black;
					else
						return Color.White;
				case RenderingMode.Gray:
					Average=(BaseColor.R+BaseColor.G+BaseColor.B)/3;
					return Color.FromArgb(Average,Average,Average);
			}
			return BaseColor;
		}

		public static Image FindImage(Image BaseImage,RenderingMode Mode)
		{
			if(Mode==RenderingMode.Normal)
				return BaseImage;
			else
			{
				Bitmap bitmap=new Bitmap(BaseImage);
				int width=bitmap.Width;
				int height=bitmap.Height;
				Bitmap bitmap2=new Bitmap(width,height,PixelFormat.Format32bppArgb);
				Graphics gr=Graphics.FromImage(bitmap2);
				gr.DrawImage(bitmap,0,0);
				for(int i=0;i<bitmap.Width;i++)
				{
					for(int y=0;y<bitmap.Height;y++)
					{
						Color c=bitmap.GetPixel(i,y);
						Color d=FindColor(c,Mode);
						bitmap2.SetPixel(i,y,d);
					}
				}
				return bitmap2;
			}
		}

		public static void  SeparateInt(string s,out int var1, out int var2)
		{
			int p;
			int l;
			
			p=s.IndexOf(",");
			try
			{
				var1=Convert.ToInt32(s.Substring(0,p));
				l=s.Length;
				var2=Convert.ToInt32(s.Substring(p+1,l-p-1));
			}
			catch
			{
				var1=-1;
				var2=-1;
			}
		}

		public static string GetXMLEscapes(string s)
		{
			string freturn;
			freturn=s.Replace("&","&amp;");
			freturn=freturn.Replace("<","&lt;");
			freturn=freturn.Replace(">","&gt;");
			freturn=freturn.Replace("'","&apos;");
			freturn=freturn.Replace("\"","&quot;");
			return freturn;
		}

		public static string GetXMLString(string s)
		{
			string freturn;
			freturn=s.Replace("&amp;","&");
			freturn=freturn.Replace("&lt;","<");
			freturn=freturn.Replace("&gt;",">");
			freturn=freturn.Replace("&apos;","'");
			freturn=freturn.Replace("&quot;","\"");
			return freturn;
		}

		public static bool CT(string s1,string s2)
		{
			CultureInfo inf=new CultureInfo("en");
			if(s1.ToUpper(inf)==s2.ToUpper(inf))
				return true;
			else
				return false;
		}
		
		public static void CloseupAllPopupForms()
		{
			if(CurPopupForm!=null)
			{
				CurPopupForm.Close();
				CurPopupForm=null;
			}
		}		

		[DllImport("user32.dll")]
		public static extern bool GetScrollInfo(IntPtr hwnd,int fnBar, [In,Out] tagScrollInfo lpsi);  

		public static void CheckScrollInfo(tagScrollInfo si)
		{
			si.nMin=0;
			si.nPage=Math.Max(0,si.nPage);
			si.nPos=Math.Max(0,si.nPos);
		}

		[DllImport("user32.dll")]
		public static extern int SetScrollInfo(IntPtr hwnd,int fnBar,tagScrollInfo lpsi,bool fRedraw);

		[DllImport("user32.dll")]
		public static extern bool ScrollWindow(IntPtr hwnd,int XAmount,int YAmount,RectangleF lpRect,RectangleF lpClipRect);  

		public static string Flat(string s)
		{
			int idx;
            string freturn;

			freturn=s;
			idx=freturn.IndexOf("&");
			while(idx>0)
			{
				freturn.Remove(idx,1);
				idx=freturn.IndexOf("&");
			}
			idx=freturn.IndexOf(" ");
			while(idx>0)
			{
				freturn.Remove(idx,1);
				if(idx<=freturn.Length)
					Char.ToUpper(freturn[idx]);
				idx=freturn.IndexOf(" ");
			}
			return freturn;
		}		

		public static double ConvertUnits(double Val,Units UnitsFrom,Units UnitsTo)
		{
			double freturn;
			if(UnitsFrom==UnitsTo)
				freturn=Val;
			else
				freturn=Val*UnitRatio(UnitsFrom)/UnitRatio(UnitsTo);
			return freturn;
		}

		public static double UnitRatio(Units units)
		{
			switch(units)
			{
				case Units.Pix:
					return 2.5487;
				case Units.MM:
					return 10;
				case Units.Cm:
					return 100;
				case Units.In:
					return 254;
				default:
					return 100;
			}
		}

		public static string UnitsShortName(Units units)
		{
			switch(units)
			{
				case Units.Pix:
					return "pixels";
				case Units.MM:
					return "millimeters";
				case Units.Cm:
					return "centimeters";
				case Units.In:
					return "inches";
				default:
					return "";
			}
		}		

		public static double FromPix(double Val)
		{
			return (UnitRatio(Units.Pix)*Val);
		}		

		[DllImport("gdi32.dll")]
		public static extern bool InvalidateRect(IntPtr hwnd,Rectangle rect,bool bErase);

		public static int ToPix(double Val)
		{
			return (int)Math.Round(Val/UnitRatio(Units.Pix),0);
		}

		public static int MmToInch(int val)
		{
			return (int)Math.Round(val*3.94,0);
		}

		public static double InchToMm(int val)
		{
			return (double)val/(double)3.94;
		}

		public static int PrintToMM(int val)
		{
			return (int)Math.Round(val/2.6);
		}

		public static void ShowText(Graphics gr,Brush brush,RectangleF r,string text,Font font)
		{
			gr.RotateTransform(270.0F);
			StringFormat sf=new StringFormat();
			sf.Alignment=StringAlignment.Center;
			sf.FormatFlags=StringFormatFlags.NoWrap;
			r=new RectangleF(-r.Y-r.Height,r.X,r.Height,r.Width);
			gr.DrawString(text,font,brush,r,sf);
			gr.ResetTransform();
		}

		public static void DrawAngleText(Graphics gr,RectangleF r,string text,HAlign HA,VAlign VA,bool WordWrap,int angle,Font font,Brush brush,CellMargins margins)
		{
			RectangleF Rect;
			float left=margins.Left*Generic.ZoomFactor;
			float right=margins.Right*Generic.ZoomFactor;
			float top=margins.Top*Generic.ZoomFactor;
			float bottom=margins.Bottom*Generic.ZoomFactor;
			r=new RectangleF(r.X+left,r.Y+top,r.Width-(left+right),r.Height-(top+bottom));
			StringFormat sf=new StringFormat();
			font=new Font(font.Name,font.Size*ZoomFactor,font.Style);
			if(!WordWrap)
			{
				sf.FormatFlags=StringFormatFlags.NoWrap;
			}

			if(angle==0)
			{
				Rect=new RectangleF(r.X,r.Y,r.Width,r.Height);
				switch(HA)
				{
					case HAlign.Center:
						sf.Alignment=StringAlignment.Center;
						break;
					case HAlign.Left:
						sf.Alignment=StringAlignment.Near;
						break;
					case HAlign.Right:
						sf.Alignment=StringAlignment.Far;
						break;
				}
				switch (VA)
				{
					case VAlign.Bottom:
						sf.LineAlignment=StringAlignment.Far;
						break;
					case VAlign.Center:
						sf.LineAlignment=StringAlignment.Center;
						break;
					case VAlign.Top:
						sf.LineAlignment=StringAlignment.Near;
						break;
				}
				gr.DrawString(text,font,brush,Rect,sf);
			}

			if(angle==90)
			{
				gr.RotateTransform(90.0F);
				Rect=new RectangleF(r.Y,-r.X-r.Width,r.Height,r.Width);
				switch(HA)
				{
					case HAlign.Center:
						sf.LineAlignment=StringAlignment.Center;
						break;
					case HAlign.Left:
						sf.LineAlignment=StringAlignment.Far;
						break;
					case HAlign.Right:
						sf.LineAlignment=StringAlignment.Near;
						break;
				}
				switch (VA)
				{
					case VAlign.Bottom:
						sf.Alignment=StringAlignment.Far;
						break;
					case VAlign.Center:
						sf.Alignment=StringAlignment.Center;
						break;
					case VAlign.Top:
						sf.Alignment=StringAlignment.Near;
						break;
				}
				gr.DrawString(text,font,brush,Rect,sf);
				gr.ResetTransform();
			}

			if(angle==180)
			{
				gr.RotateTransform(180.0F);
				Rect=new RectangleF(-r.X-r.Width,-r.Y-r.Height,r.Width,r.Height);
				switch(HA)
				{
					case HAlign.Center:
						sf.Alignment=StringAlignment.Center;
						break;
					case HAlign.Left:
						sf.Alignment=StringAlignment.Far;
						break;
					case HAlign.Right:
						sf.Alignment=StringAlignment.Near;
						break;
				}
				switch (VA)
				{
					case VAlign.Bottom:
						sf.LineAlignment=StringAlignment.Near;
						break;
					case VAlign.Center:
						sf.LineAlignment=StringAlignment.Center;
						break;
					case VAlign.Top:
						sf.LineAlignment=StringAlignment.Far;
						break;
				}
				gr.DrawString(text,font,brush,Rect,sf);
				gr.ResetTransform();
			}

			if(angle==270)
			{
				gr.RotateTransform(270.0F);
				Rect=new RectangleF(-r.Y-r.Height,r.X,r.Height,r.Width);
				switch(HA)
				{
					case HAlign.Center:
						sf.LineAlignment=StringAlignment.Center;
						break;
					case HAlign.Left:
						sf.LineAlignment=StringAlignment.Near;
						break;
					case HAlign.Right:
						sf.LineAlignment=StringAlignment.Far;
						break;
				}
				switch (VA)
				{
					case VAlign.Bottom:
						sf.Alignment=StringAlignment.Near;
						break;
					case VAlign.Center:
						sf.Alignment=StringAlignment.Center;
						break;
					case VAlign.Top:
						sf.Alignment=StringAlignment.Far;
						break;
				}
				gr.DrawString(text,font,brush,Rect,sf);
				gr.ResetTransform();
			}
		}

		public static void DrawRectText(Graphics gr,string s,RectangleF r,HAlign HA,VAlign VA,bool WordWrap,int TextAngle,Brush brush,Font font,CellMargins margins)
		{
			DrawAngleText(gr,r,s,HA,VA,WordWrap,TextAngle,font,brush,margins);			
		}	

		public static void DrawBorder(Graphics gr,Rectangle r,LineStyle ls,int fs,Color Color,int Width,int WidthLefTop,int WidthRightBottom)
		{
			int wlt1, wlt2, wrb1, wrb2;
			if(WidthLefTop<=0)
			{
				wlt1=0;
				wlt2=0;
			}
			else
			{
				wlt1=WidthLefTop-1;
				wlt2=WidthLefTop-2;
			}
			if(WidthRightBottom<=0)
			{
				wrb1=0;
				wrb2=0;
			}
			else
			{
				wrb1=WidthRightBottom-1;
				wrb2=WidthRightBottom-2;
			}

			Brush brush=new SolidBrush(Color);
			switch(ls)
			{
				case LineStyle.Solid:
				{
					switch(fs)
					{
						case 0:
							gr.FillRectangle(brush,r.Left,r.Top,Width,Math.Abs((r.Bottom+1)-r.Top));
							break;
						case 2:
							gr.FillRectangle(brush,r.Right+1-Width,r.Top,Width,Math.Abs((r.Bottom+1)-r.Top));
							break;
						case 1:
							gr.FillRectangle(brush,r.Left,r.Top,Math.Abs((r.Right+1)-r.Left),Width);
							break;
						case 3:
							gr.FillRectangle(brush,r.Left,r.Bottom+1-Width,Math.Abs((r.Right+1)-r.Left),Width);
							break;
					}					
				}
					break;
				case LineStyle.Dash:
					goto case LineStyle.DashDotDot;
				case LineStyle.Dot:
					goto case LineStyle.DashDotDot;
				case LineStyle.DashDot:
					goto case LineStyle.DashDotDot;
				case LineStyle.DashDotDot:
				{
					switch(fs)
					{
						case 0:
							VerLine(gr,brush,r.Left,r.Top,r.Bottom,ls);
							break;
						case 2:
							VerLine(gr,brush,r.Right,r.Top,r.Bottom,ls);
							break;
						case 1:
							HorLine(gr,brush,r.Left,r.Right,r.Top,ls);
							break;
						case 3:
							HorLine(gr,brush,r.Left,r.Right,r.Bottom,ls);
							break;
					}
				}
						break;
				case LineStyle.Double11:
				{
					switch(fs)
					{
						case 0:
							VerLine(gr,brush,r.Left,r.Top,r.Bottom,ls);
							VerLine(gr,brush,r.Left+2,r.Top+wlt1,r.Bottom-wrb1,ls);
							break;
						case 2:
							VerLine(gr,brush,r.Right,r.Top,r.Bottom,ls);
							VerLine(gr,brush,r.Right-2,r.Top+wlt1,r.Bottom-wrb1,ls);
							break;
						case 1:
							HorLine(gr,brush,r.Left,r.Right,r.Top,ls);
							HorLine(gr,brush,r.Left+wlt1,r.Right-wrb1,r.Top+2,ls);
							break;
						case 3:
							HorLine(gr,brush,r.Left,r.Right,r.Bottom,ls);
							HorLine(gr,brush,r.Left+wlt1,r.Right-wrb1,r.Bottom-2,ls);
							break;
					}
				}
					break;
				case LineStyle.Double21:
				{
					switch(fs)
					{
						case 0:
							VerLine(gr,brush,r.Left,r.Top,r.Bottom,ls);
							VerLine(gr,brush,r.Left+1,r.Top,r.Bottom,ls);
							VerLine(gr,brush,r.Left+3,r.Top+wlt1,r.Bottom-wrb1,ls);
							break;
						case 2:
							VerLine(gr,brush,r.Right,r.Top,r.Bottom,ls);
							VerLine(gr,brush,r.Right-1,r.Top,r.Bottom,ls);
							VerLine(gr,brush,r.Right-3,r.Top+wlt1,r.Bottom-wrb1,ls);
							break;
						case 1:
							HorLine(gr,brush,r.Left,r.Right,r.Top,ls);
							HorLine(gr,brush,r.Left,r.Right,r.Top+1,ls);
							HorLine(gr,brush,r.Left+wlt1,r.Right-wrb1,r.Top+3,ls);
							break;
						case 3:
							HorLine(gr,brush,r.Left,r.Right,r.Bottom,ls);
							HorLine(gr,brush,r.Left,r.Right,r.Bottom-1,ls);
							HorLine(gr,brush,r.Left+wlt1,r.Right-wrb1,r.Bottom-3,ls);
							break;
					}
				}
					break;
				case LineStyle.Double12:
				{
					switch(fs)
					{						
						case 0:
							VerLine(gr,brush,r.Left,r.Top,r.Bottom,ls);
							VerLine(gr,brush,r.Left+2,r.Top+wlt2,r.Bottom-wrb2,ls);
							VerLine(gr,brush,r.Left+3,r.Top+wlt1,r.Bottom-wrb1,ls);
							break;
						case 2:
							VerLine(gr,brush,r.Right,r.Top,r.Bottom,ls);
							VerLine(gr,brush,r.Right-2,r.Top+wlt2,r.Bottom-wrb2,ls);
							VerLine(gr,brush,r.Right-3,r.Top+wlt1,r.Bottom-wrb1,ls);
							break;
						case 1:
							HorLine(gr,brush,r.Left,r.Right,r.Top,ls);
							HorLine(gr,brush,r.Left+wlt2,r.Right-wrb2,r.Top+2,ls);
							HorLine(gr,brush,r.Left+wlt1,r.Right-wrb1,r.Top+3,ls);
							break;
						case 3:
							HorLine(gr,brush,r.Left,r.Right,r.Bottom,ls);
							HorLine(gr,brush,r.Left+wlt2,r.Right-wrb2,r.Bottom-2,ls);
							HorLine(gr,brush,r.Left+wlt1,r.Right-wrb1,r.Bottom-3,ls);
							break;
					}
				}
					break;
			}
		}

		static void VerLine(Graphics gr,Brush brush,int x,int y1,int y2,LineStyle ls)
		{
			int n, cnt, y, yend;
			n=0;cnt=0;y=y1;
			while(y<y2)
			{
				yend=Math.Min(y+CellBorderDots[(int)ls,n],y2+1);
				gr.FillRectangle(brush,x,y,1,Math.Abs(yend-y));
				cnt=cnt+CellBorderDots[(int)ls,n]+CellBorderDots[(int)ls,n+1];
				y=y+CellBorderDots[(int)ls,n]+CellBorderDots[(int)ls,n+1];
				n=n+2;
				if(cnt>=24)
				{
					n=0;
					cnt=0;
				}
			}
		}

		static void HorLine(Graphics gr,Brush brush,int x1,int x2,int y,LineStyle ls)
		{
			int n, cnt, x, xend;
			n=0;cnt=0;x=x1;
			while(x<x2)
			{
				xend=Math.Min(x+CellBorderDots[(int)ls,n],x2+1);
				gr.FillRectangle(brush,x,y,Math.Abs(xend-x),1);
				cnt=cnt+CellBorderDots[(int)ls,n]+CellBorderDots[(int)ls,n+1];
				x=x+CellBorderDots[(int)ls,n]+CellBorderDots[(int)ls,n+1];
				n=n+2;
				if(cnt>=24)
				{
					n=0;
					cnt=0;
				}
			}
		}

		public static bool Between(int a,float amin,float adelta)
		{
			if((a>=amin)&&(a<=(amin+adelta)))
				return true;
			else
				return false;
		}

		public static LineStyle GetBorderStyleByName(string Name)
		{
			for(int i=0;i<8;i++)
			{
				if(CT(Name,CellBorderNames[i]))
					return (LineStyle)i;
			}
			return LineStyle.Solid;
		}

		public static float TextHeight(Graphics gr,string s,float width,HAlign HA,VAlign VA,bool WordWrap,int FirstChar,Font font)
		{
			StringList sl;
			int freturn;
			sl=new StringList("TextHeight sl");
			sl.SetText(s);
			if(WordWrap)
			{
				WrapString(sl,gr,width,font);
			}
			freturn=0;
			if(sl.Count>0)
			{
				freturn=sl.Count*((int)gr.MeasureString(sl.GetString(0),font).Height+1);
			}
			return freturn;
		}

		public static void WrapString(StringList sl,Graphics gr,float width,Font font)
		{
			int i;
			string c,c1;
			StringList cl;

			if(sl.Count==0)
				return;
			cl=new StringList("WrapString cl");
			i=0;
			while(i<sl.Count)
			{
				if(gr.MeasureString(sl.GetString(i),font).Width>width)
				{
					SplitStringSpace(sl.GetString(i),cl);
					sl.RemoveAt(i);
					while(cl.Count>0)
					{
						c=cl.GetString(0);
						c1=cl.GetString(0);
						cl.RemoveAt(0);
						while(cl.Count>0)
						{
							c=c+cl.GetString(0);
							if(gr.MeasureString(c,font).Width>width)
								break;
							c1=c1+cl.GetString(0);
							cl.RemoveAt(0);
						}
						sl.InsertString(i,c1);
						i++;
					}
				}
				else
				{
					i++;
				}
			}
		}

		public static void SplitStringSpace(string s,StringList sl)
		{
			int n, len;
			string ss;

			sl.Clear();
			len=s.Length;
			if(len>0)
			{
				n=0;
				ss="";
				do
				{
					if(s[n]>' ')
					{
						ss=ss+s[n].ToString();
						n++;
						if((n<len)&&(s[n]==' '))
						{
							sl.Add(ss);
							ss="";
						}
					}
					else
					{
						sl.Add(" ");
						ss="";
						n++;
					}
				}while(n<len);
				if(ss.Length>0)
					sl.Add(ss);
			}
		}

		public static string GraphicToString(Image Graphic)
		{
			MemoryStream ms=new MemoryStream();
			string s;
			try
			{
				s="";
				Graphic.Save(ms,ImageFormat.Jpeg);
				s=BitConverter.ToString(ms.ToArray());
			}
			finally
			{
				ms.Close();
			}
			return s;
		}

		public static int StringToInt(string s1,string s2)
		{
			int i1;
			int i2;
			if(s1=="A")
			{
				i1=16*10;
			}
			else if(s1=="B")
			{
				i1=16*11;
			}
			else if(s1=="C")
			{
				i1=16*12;
			}
			else if(s1=="D")
			{
				i1=16*13;
			}
			else if(s1=="E")
			{
				i1=16*14;
			}
			else if(s1=="F")
			{
				i1=16*15;
			}
			else
			{
				i1=Convert.ToInt16(s1)*16;
			}
			if(s2=="A")
			{
				i2=10;
			}
			else if(s2=="B")
			{
				i2=11;
			}
			else if(s2=="C")
			{
				i2=12;
			}
			else if(s2=="D")
			{
				i2=13;
			}
			else if(s2=="E")
			{
				i2=14;
			}
			else if(s2=="F")
			{
				i2=15;
			}
			else
			{
				i2=Convert.ToInt16(s2);
			}
			
			return i1+i2;			
		}
		#endregion
	}
	#endregion

	#region tagScrollInfo
	[StructLayout(LayoutKind.Sequential)]
	public class tagScrollInfo
	{
		public int cbSize; 
		public int fMask; 
		public int  nMin; 
		public int  nMax; 
		public int nPage; 
		public int  nPos; 
		public int  nTrackPos; 
	}
	#endregion
}
