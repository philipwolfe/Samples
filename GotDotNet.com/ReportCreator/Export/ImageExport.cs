using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing;
using Windows.Forms.Reports.ReportLibrary;
using System.IO;

namespace Windows.Forms.Reports.Export
{
	#region ImageExport
	[ToolboxItem(true)]
	public class ImageExport:CustomExport
	{
		#region class variables
		ImageType FImageType;
		#endregion

		#region class methods
		public override void Execute()
		{
			Zoom OldZoom=UserRep.Zoom;
			UserRep.Zoom=Zoom.hundred;
			base.Execute();
			string imgdir;
			string imgname="";
			Rep CurrRep=null;
			Bitmap bitmap=null;
			Graphics gr=null;

			FileInfo fi=new FileInfo(FileName);
			int l=fi.Extension.Length;
			imgdir=fi.Directory+"\\"+fi.Name.Remove(fi.Name.Length-l,l);
	
			UserRep.ProgressStart(Rep.BandCount);
			int firstband;
			int lastband;
			firstband=0;
			lastband=0;
			for(int i=0;i<Rep.RepList.Count;i++)
			{
				CurrRep=Rep.GetSrcRep(i);
				for(int page=CurrRep.FirstPage;page<CurrRep.LastPage;page++)
				{
					for(int idxband=0;idxband<CurrRep.BandCount;idxband++)
					{
						if(CurrRep.GetBand(idxband).Pageno==page)
							firstband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
						if(CurrRep.GetBand(idxband).Pageno==page+1)
						{
							lastband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
							break;
						}
					}

					if(page!=CurrRep.LastPage-1)
						lastband=lastband-1;
					if((page>=FromPage)&&(page<=ToPage))
					{
						int width,height;
						if(!(CurrRep.Orientation==PrinterOrientation.Landscape))
						{
							width=CurrRep.PageSize.PaperSize.Width;
							height=CurrRep.PageSize.PaperSize.Height;
						}
						else
						{
							width=CurrRep.PageSize.PaperSize.Height;
							height=CurrRep.PageSize.PaperSize.Width;
						}

						b.rightmgn=0;
						b.rLeft=LeftMargin;
						b.CellRect=new RectangleF(LeftMargin,TopMargin,0,0);
						bitmap=new Bitmap(width,height);
						gr=Graphics.FromImage(bitmap);
						PrintNewPage(gr,CurrRep);
						switch(ImageType)
						{
							case ImageType.bmp:
								imgname=imgdir+page.ToString()+".bmp";
								break;
							case ImageType.emf:
								imgname=imgdir+page.ToString()+".emf";
								break;
							case ImageType.gif:
								imgname=imgdir+page.ToString()+".gif";
								break;
							case ImageType.jpg:
								imgname=imgdir+page.ToString()+".jpg";
								break;
							case ImageType.png:
								imgname=imgdir+page.ToString()+".png";
								break;
							case ImageType.tiff:
								imgname=imgdir+page.ToString()+".tiff";
								break;
							case ImageType.wmf:
								imgname=imgdir+page.ToString()+".wmf";
								break;
						}
					}
					for(int idxband=firstband;idxband<lastband+1;idxband++)
					{
						if((page>=FromPage)&&(page<=ToPage))						
							PrintBand(CurrRep.GetBand(idxband),CurrRep,gr);
						UserRep.ProgressStep();
					}
					if((page>=FromPage)&&(page<=ToPage))
					{
						switch(ImageType)
						{
							case ImageType.bmp:
								bitmap.Save(imgname,ImageFormat.Bmp);
								break;
							case ImageType.emf:
								bitmap.Save(imgname,ImageFormat.Emf);
								break;
							case ImageType.gif:
								bitmap.Save(imgname,ImageFormat.Gif);
								break;
							case ImageType.jpg:
								bitmap.Save(imgname,ImageFormat.Jpeg);
								break;
							case ImageType.png:
								bitmap.Save(imgname,ImageFormat.Png);
								break;
							case ImageType.tiff:
								bitmap.Save(imgname,ImageFormat.Tiff);
								break;
							case ImageType.wmf:
								bitmap.Save(imgname,ImageFormat.Wmf);
								break;
						}
					}
				}
			}
			UserRep.ProgressStop();
			UserRep.Zoom=OldZoom;
		}

		void PrintNewPage(Graphics gr,Rep CurrRep)
		{
			int width,height;
			if(!(CurrRep.Orientation==PrinterOrientation.Landscape))
			{
				width=CurrRep.PageSize.PaperSize.Width;
				height=CurrRep.PageSize.PaperSize.Height;
			}
			else
			{
				width=CurrRep.PageSize.PaperSize.Height;
				height=CurrRep.PageSize.PaperSize.Width;
			}
			Shape shape=new Shape();
			shape.Size=new Size(width,height);
			shape.Location=new Point(0,0);
			shape.BackGroundColor=CurrRep.PageColor;
			shape.BorderColor=Color.White;
			shape.Gradient=CurrRep.PageGraident;
			if(CurrRep.PageGraident)
			{
				shape.GradientColor=CurrRep.PageGraidentColor;
				shape.FillDirection=CurrRep.PageFillDirection;
			}
			shape.ShapeType=ShapeType.Rectangle;
			shape.Paint(gr);
			if(CurrRep.PagePicture!=null)
			{
				int x,y;
				switch(CurrRep.PageImagePosition)
				{
					case ImagePosition.Center:						
						y=(height-CurrRep.PagePicture.Height)/2;
						x=(width-CurrRep.PagePicture.Width)/2;
						gr.DrawImage(CurrRep.PagePicture,new RectangleF(new PointF(x,y),new SizeF(CurrRep.PagePicture.PhysicalDimension)));						
						break;
					case ImagePosition.Stretch:	
						gr.DrawImage(CurrRep.PagePicture,new RectangleF(new PointF(0,0),new SizeF(width,height)));
						break;
					case ImagePosition.Tile:
						TextureBrush brush=new TextureBrush(CurrRep.PagePicture,System.Drawing.Drawing2D.WrapMode.Tile);
						gr.FillRectangle(brush,new RectangleF(new PointF(0,0),new SizeF(width,height)));
						break;
				}
			}
		}

		void PrintBand(Band band,Rep CurrRep,Graphics gr)
		{
			b.CellRect=new RectangleF(b.CellRect.Left,b.CellRect.Top,Math.Abs(b.CellRect.Left-b.CellRect.Right),Math.Abs((b.CellRect.Top+band.Height)-b.CellRect.Top));
			PrintClipBand(band,0,b.CellRect.Top,b.CellRect.Bottom,gr,CurrRep);
		}

		void PrintClipBand(Band band,int PrintBandPos,float ClipTop,float ClipBottom,Graphics gr,Rep CurrRep)
		{
			float OldLeft;
			int idxcell;
			RectangleF r;
			Band bottomband;

			OldLeft=b.CellRect.Left;
			b.CellRect=new RectangleF(b.CellRect.Left,b.CellRect.Top-PrintBandPos,0,Math.Abs((b.CellRect.Top-PrintBandPos)-((b.CellRect.Top-PrintBandPos)+band.Height)));
			for(idxcell=0;idxcell<band.CellCount;idxcell++)
			{
				b.CellRect=new RectangleF(b.CellRect.Left,b.CellRect.Top,Math.Abs((b.CellRect.Right+band.GetCell(idxcell).Width)-b.CellRect.Left),Math.Abs(b.CellRect.Top-b.CellRect.Bottom));
				if(!(band.GetCell(idxcell).InUse))
				{
					bottomband=band.GetCell(idxcell).GetBottomBand();
					if(bottomband!=band)
					{
						r=new RectangleF(b.CellRect.Left,b.CellRect.Top,Math.Abs(b.CellRect.Left-b.CellRect.Right),Math.Abs((CurrRep.GetTops(CurrRep.IndexOfBand(bottomband))-CurrRep.GetTops(CurrRep.IndexOfBand(band)))+bottomband.Height));
						Region region=new Region(new RectangleF(b.CellRect.Left,r.Top,Math.Abs(b.CellRect.Left-b.CellRect.Right),Math.Abs(r.Bottom-r.Top)));
						gr.IntersectClip(region);
						try
						{
							band.GetCell(idxcell).PaintCell(gr,r,SelectedCellStyle.None,FocusedCellStyle.None,false,RenderingMode);
						}
						finally
						{
							gr.ResetClip();
						}
					}
					else
					{
						Region region=new Region(new RectangleF(b.CellRect.Left,ClipTop,Math.Abs(b.CellRect.Left-b.CellRect.Right),Math.Abs(ClipBottom-ClipTop)));
						gr.IntersectClip(region);
						try
						{
							band.GetCell(idxcell).PaintCell(gr,b.CellRect,SelectedCellStyle.None,FocusedCellStyle.None,false,RenderingMode);
						}
						finally
						{
							gr.ResetClip();
						}
					}
				}
				b.CellRect=new RectangleF(b.CellRect.Left+band.GetCell(idxcell).Width,b.CellRect.Top,Math.Abs((b.CellRect.Left+band.GetCell(idxcell).Width)-b.CellRect.Right),Math.Abs(b.CellRect.Top-b.CellRect.Bottom));
			}
			b.rightmgn=Math.Max(b.rightmgn,b.CellRect.Right);
			b.CellRect=new RectangleF(OldLeft,b.CellRect.Bottom,Math.Abs(OldLeft-b.CellRect.Right),0);
		}
		#endregion

		#region class properties
		public ImageType ImageType
		{
			get
			{
				return FImageType;
			}
			set
			{
				FImageType=value;
			}
		}
		#endregion
	}
	#endregion

	#region enums
	public enum ImageType
	{
		bmp,
		emf,
		gif,
		jpg,
		png,
		tiff,
		wmf
	}
	#endregion
}
