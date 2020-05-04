using System;
using Windows.Forms.Reports.ReportLibrary;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Windows.Forms.Reports.BarcodePlugin
{
	#region Barcode
	[ToolboxItem(true)]
	public class Barcode:UserRepPlugIn
	{
		#region class variables
		double FAngle;
		double FRatio;
		int FModul;
		BarcodeType FTyp;
		bool FCheckSum;
		CheckSumMethod FCheckSumMethod;
		BarcodeOption FShowText;
		Color FColor;
		Color FColorBar;
		Color FForeColor;
		int FHeight;
		Font FShowTextFont;
		ShowTextPosition FShowTextPosition;
		#endregion

		#region constructor
		public Barcode()
		{
			FAngle=0;
			FRatio=2;
			FModul=1;
			FTyp=BarcodeType.Code_2_5_interleaved;
			FCheckSum=false;
			FCheckSumMethod=CheckSumMethod.Modulo10;
			FShowText=BarcodeOption.None;
			FColor=Color.White;
			FColorBar=Color.Black;
			FForeColor=SystemColors.ControlText;
			FShowTextFont=new Font("Arial",8.25F);;
			FShowTextPosition=ShowTextPosition.TopLeft;
		}
		#endregion

		#region class methods
		public override void ApplyValues()
		{
			Point p;
			Bitmap bitmap;
			for(int i=0;i<VarCount;i++)
			{
				GetBarCodesByIndex(i).Top=0;
				GetBarCodesByIndex(i).Left=0;
				p=CalcWH(GetBarCodesByIndex(i).Width,GetBarCodesByIndex(i).Height,GetBarCodesByIndex(i).Angle);
				bitmap=new Bitmap(p.X,p.Y,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				Graphics gr=Graphics.FromImage(bitmap);
				gr.FillRectangle(new SolidBrush(Color.White),0,0,bitmap.Width,bitmap.Height);
				GetBarCodesByIndex(i).DrawBarcode(gr);
				MemoryStream stream=new MemoryStream();
				bitmap.Save(stream,System.Drawing.Imaging.ImageFormat.Bmp);
				bitmap=new Bitmap(stream);
				UserRep.SetImage(GetVarNames(i),bitmap);
			}
		}

		Point CalcWH(int w,int h,double alpha)
		{
			double sinus, cosinus;
			int minx, miny, maxx, maxy;
			Point p;

			sinus=Math.Sin(alpha/180*Math.PI);
			cosinus=Math.Cos(alpha/180*Math.PI);
			minx=0; miny=0; maxx=0; maxy=0;

			p=Rotate2D(w,0,sinus,cosinus);
			minx=Math.Min(minx, p.X); miny=Math.Min(miny, p.Y); maxx=Math.Max(maxx, p.X); maxy=Math.Max(maxy, p.Y);

			p=Rotate2D(0, h,sinus,cosinus);
			minx=Math.Min(minx, p.X); miny=Math.Min(miny, p.Y); maxx=Math.Max(maxx, p.X); maxy=Math.Max(maxy, p.Y);

			p=Rotate2D(w, h,sinus,cosinus);
			minx=Math.Min(minx, p.X); miny=Math.Min(miny, p.Y); maxx=Math.Max(maxx, p.X); maxy=Math.Max(maxy, p.Y);

			return new Point(maxx - minx + 1,maxy - miny + 1);
		}

		Point Rotate2D(int x,int y,double sinus,double cosinus)
		{
			return new Point((int)(x*cosinus+y*sinus),(int)(-x*sinus+y*cosinus));
		}

		public AsBarcode GetBarCodesByIndex(int Index)
		{
			return (AsBarcode)GetVarByIndex(Index);
		}

		public AsBarcode GetBarCodesByName(string Name)
		{
			return (AsBarcode)GetObjectByName(Name);
		}

		protected override object CreateVar()
		{
			AsBarcode tmp=new AsBarcode();
			tmp.Angle=FAngle;
			tmp.CheckSum=FCheckSum;
			tmp.CheckSumMethod=FCheckSumMethod;
			tmp.Color=FColor;
			tmp.ColorBar=FColorBar;
			tmp.ForeColor=FForeColor;
			tmp.Height=FHeight;
			tmp.Modul=FModul;
			tmp.Ratio=FRatio;
			tmp.ShowText=FShowText;
			tmp.ShowTextFont=FShowTextFont;
			tmp.ShowTextPosition=FShowTextPosition;
			tmp.Typ=FTyp;
			return tmp;
		}
		#endregion

		#region class properties
		public double Angle
		{
			get
			{
				return FAngle;
			}
			set
			{
				FAngle=value;			
			}
		}

		[DefaultValue(false)]
		public bool CheckSum
		{
			get
			{
				return FCheckSum;
			}
			set
			{
				FCheckSum=value;
			}
		}

		[DefaultValue(CheckSumMethod.Modulo10)]
		public CheckSumMethod CheckSumMethod
		{
			get
			{
				return FCheckSumMethod;
			}
			set
			{
				FCheckSumMethod=value;
			}
		}

		public Color Color
		{
			get
			{
				return FColor;
			}
			set
			{
				FColor=value;
			}
		}

		public Color ColorBar
		{
			get
			{
				return FColorBar;
			}
			set
			{
				FColorBar=value;
			}
		}

		public int Height
		{
			get
			{
				return FHeight;
			}
			set
			{
				FHeight=value;
			}
		}

		public int Modul
		{
			get
			{
				return FModul;
			}
			set
			{
				if((value>=1)&&(value<50))
				{
					FModul=value;
				}
			}
		}

		public double Ratio
		{
			get
			{
				return FRatio;
			}
			set
			{
				FRatio=value;
			}
		}

		[DefaultValue(BarcodeOption.None)]
		public BarcodeOption ShowText
		{
			get
			{
				return FShowText;
			}
			set
			{
				FShowText=value;
			}
		}

		public Font ShowTextFont
		{
			get
			{
				return FShowTextFont;
			}
			set
			{
				FShowTextFont=value;
			}
		}

		public ShowTextPosition ShowTextPosition
		{
			get
			{
				return FShowTextPosition;
			}
			set
			{
				FShowTextPosition=value;
			}
		}

		[DefaultValue(BarcodeType.Code_2_5_interleaved)]
		public BarcodeType Typ
		{
			get
			{
				return FTyp;
			}
			set
			{
				FTyp=value;
			}
		}

		public Color ForeColor
		{
			get
			{
				return FForeColor;
			}
			set
			{
				FForeColor=value;
			}
		}
		#endregion
	}
	#endregion
}
