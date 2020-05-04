using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Syncfusion.Windows.Forms.Reports.Export
{
	#region PdfImageCreator
	public class PdfImageCreator
	{
		#region class methods
		public virtual PdfImage CreateImage(Bitmap ABitmap)
		{
			return null;
		}
		#endregion
	}
	
	#endregion

	#region PdfBitmapImage
	public class PdfBitmapImage:PdfImageCreator
	{
		#region class methods
		public override PdfImage CreateImage(Bitmap ABitmap)
		{
			Color acolor;
			byte[]b;
			int i=0;
			
			PdfImage Freturn=new PdfImage(null);
			Freturn.Attributes.AddItem("Type",new PdfName("XObject"));
			Freturn.Attributes.AddItem("Subtype",new PdfName("Image"));
			
			if((ABitmap.PixelFormat==PixelFormat.Format1bppIndexed)||
				(ABitmap.PixelFormat==PixelFormat.Format4bppIndexed)||
				(ABitmap.PixelFormat==PixelFormat.Format8bppIndexed))
			{
				b=ScanLine(ABitmap);
				Freturn.Stream.Write(b,0,b.Length);
				Freturn.Attributes.AddItem("ColorSpace",CreateIndexedColorArray(ABitmap));
			}
			else
			{
				b=new byte[ABitmap.Width*ABitmap.Height*3];
				for(int y=0;y<ABitmap.Height;y++)
				{
					for(int x=0;x<ABitmap.Width;x++)
					{
						acolor=ABitmap.GetPixel(x,y);
						b[i]=acolor.R;
						b[i+1]=acolor.G;
						b[i+2]=acolor.B;
						i=i+3;
					}				
				}
				Freturn.Stream.Write(b,0,b.Length);
				Freturn.Attributes.AddItem("ColorSpace",new PdfName("DeviceRGB"));
			}
			Freturn.Attributes.AddItem("Width",new PdfNumber(ABitmap.Width));
			Freturn.Attributes.AddItem("Height",new PdfNumber(ABitmap.Height));
			Freturn.Attributes.AddItem("BitsPerComponent",new PdfNumber(8));

			Freturn.Attributes.PdfArrayByName("Filter").AddItem(new PdfName("FlateDecode"));
			return Freturn;			
		}
		
		byte[] ScanLine(Bitmap ABitmap)
		{
			Color[] Value=ABitmap.Palette.Entries;
			byte[] b=new byte[ABitmap.Height*ABitmap.Width];
			Color[] acolor=new Color[ABitmap.Height*ABitmap.Width];
			int s=0;
			
			for(int y=0;y<ABitmap.Height;y++)
				for(int x=0;x<ABitmap.Width;x++)
				{
					acolor[s]=ABitmap.GetPixel(x,y);
					s=s+1;					
				}

			for(int i=0;i<acolor.Length;i++)
			{
				for(int j=0;j<Value.Length;j++)
					if(acolor[i]==Value[j])
					{
						b[i]=(byte)j;						
						break;
					}					
			}
			return b;
		}

		public PdfArray CreateIndexedColorArray(Bitmap ABitmap)
		{
			PdfBinary ColorTable=new PdfBinary();
			Color[] acolor=null;
			string s="<";
			PdfArray Freturn=new PdfArray(null);

			for(int i=0;i<ABitmap.Palette.Entries.Length;i++)
			{		
				acolor=ABitmap.Palette.Entries;
				s=s+acolor[i].Name.Substring(2)+" ";				
			}
			Generic.WriteString(s+">",ColorTable.Stream);
			Freturn.AddItem(new PdfName("Indexed"));
			Freturn.AddItem(new PdfName("DeviceRGB"));
			AddIndexedColorNumber(Freturn,ABitmap);
			Freturn.AddItem(ColorTable);
			return Freturn;
		}

		void AddIndexedColorNumber(PdfArray Freturn,Bitmap ABitmap)
		{
			if(ABitmap.PixelFormat==PixelFormat.Format1bppIndexed)
				Freturn.AddItem(new PdfNumber(1));
			if(ABitmap.PixelFormat==PixelFormat.Format4bppIndexed)
				Freturn.AddItem(new PdfNumber(15));
			if(ABitmap.PixelFormat==PixelFormat.Format8bppIndexed)
				Freturn.AddItem(new PdfNumber(255));
		}
		#endregion
	}
	#endregion

	#region PdfJpegImage
	public class PdfJpegImage:PdfImageCreator
	{
		#region class methods
		public override PdfImage CreateImage(Bitmap ABitmap)
		{
			PdfImage Freturn=new PdfImage(null);
			ABitmap.Save(Freturn.Stream,ImageFormat.Jpeg);
			Freturn.Attributes.AddItem("Type",new PdfName("XObject"));
			Freturn.Attributes.AddItem("Subtype",new PdfName("Image"));
			Freturn.Attributes.AddItem("ColorSpace",new PdfName("DeviceRGB"));
			Freturn.Attributes.AddItem("Width",new PdfNumber(ABitmap.Width));
			Freturn.Attributes.AddItem("Height",new PdfNumber(ABitmap.Height));
			Freturn.Attributes.AddItem("BitsPerComponent",new PdfNumber(8));
			Freturn.Attributes.PdfArrayByName("Filter").AddItem(new PdfName("DCTDecode"));
			return Freturn;
		}
		#endregion
	}
	#endregion
}
