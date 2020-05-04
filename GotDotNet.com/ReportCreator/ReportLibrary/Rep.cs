using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Imaging;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Xml;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region enums
	[Flags]
	public enum CellOption
	{
		WordWrap=2,AutoStretch=4,AutoSize=8,Tile=16,Selected=32,
		Focused=64,Changed=128,IsMoneyValue=256,
		Shared=512,InUse=1024
	}

	public enum ImagePosition
	{
		Center,Tile,Stretch
	}

	public enum PrinterOrientation
	{
		Landscape,Portrait
	}
	#endregion

	#region Rep
	public class Rep:BandList
	{
		#region class variables
		public Image RenderingPagePicture;
		RenderingMode FRenderingMode;
		public ArrayList StyleList;
		public double FLeftMargin;
		public double FRightMargin;
		public double FTopMargin;
		public double FBottomMargin;
		Font FFont;
		Color FFontColor;
		public PrinterOrientation Orientation;
		PageSize FPageSize;
		public VirtualFileSystem FileSystem;
		Color FPageColor;
		bool FPageGraident;
		Color FPageGraidentColor;
		FillDirection FPageFillDirection;
		ImagePosition FPageImagePosition;
		bool FPageLinkPictureToFile;
		Image FPagePicture;
		string FPagePictureFileName;
		bool FPageImage;

		public int NewWidth;
		public int NewHeight;
		public int OldGridWidth;
		public int OldGridHeight;
		public double OldLeftMargin;
		public double OldRightMargin;
		public double OldTopMargin;
		public double OldBottomMargin;
		#endregion

		#region constructor
		public Rep()
		{
			BeginUpdate();
			Generic.RepCnt++;
			FFont=new Font("Arial",9.75f,FontStyle.Regular);
			FFontColor=Color.Black;
			Orientation=PrinterOrientation.Portrait;
			LeftMargin=0;
			TopMargin=0;
			RightMargin=0;
			BottomMargin=0;
			PageColor=Color.White;
			PageGraident=false;
			PageGraidentColor=Color.Black;
			PageGraident=false;
			PageFillDirection=FillDirection.None;
			NewBand();
			NewBand();
			NewBand();
			NewBand();
			StyleList=new ArrayList();
			Changed=true;
			EndUpdate();
		}
		#endregion

		#region class methods
		void PrepareRender()
		{					
			if(PagePicture!=null)
				RenderingPagePicture=Generic.FindImage(PagePicture,RenderingMode);
			for(int Bandidx=0;Bandidx<BandCount;Bandidx++)
			{
				for(int CellIdx=0;CellIdx<GetBand(Bandidx).CellCount;CellIdx++)
				{
					if(GetBand(Bandidx).GetCell(CellIdx).Picture!=null)
						GetBand(Bandidx).GetCell(CellIdx).RenderingImage=Generic.FindImage(GetBand(Bandidx).GetCell(CellIdx).Picture,RenderingMode);
				}
			}
		}

		public Cell GetCell(int idxband,int idxcell)
		{
			if(GetBand(idxband)!=null)
				return GetBand(idxband).GetCell(idxcell);
			else
				return null;
		}

		public void DeleteBand(int IdxBand)
		{
			BeginUpdate();
			Delete(IdxBand);
			Changed=true;
			EndUpdate();
		}

		public Band GetBand(int idxband)
		{			
			if(BandCount>0)
			{
				return (Band)this[Math.Min(Math.Max(idxband,0),BandCount-1)];
			}
			else
				return null;			
		}

		public float GetTops(int idxband)
		{
			if((idxband>=0)&&(idxband<BandCount))
			{
				Band band=GetBand(idxband);
				return band.FTop;
			}
			else
				return 0;
		}

		public void Load(string AFileName)
		{
			StringList L=new StringList("Rep.Load L");
			if(FileSystem==null)
			{
				L.LoadFromFile(AFileName);
			}
			else
			{
				L.LoadFromStream(FileSystem.CreateReadStream(AFileName));
			}
			XmlNode node;
			StringReader reader=new StringReader(L.GetText());
			XmlDocument doc=new XmlDocument();
			doc.Load(reader);
			node=doc.SelectSingleNode("REP");
			ApplyRep(node,null);
		}

		public float MaxHeight(Band ABand)
		{
			int ib, ic;
			float freturn,top;
			Band bottomband;

			freturn=ABand.Height;
			ib=IndexOfBand(ABand);
			top=GetTops(ib);
			for(ic=0;ic<ABand.CellCount;ic++)
			{
				bottomband=ABand.GetCell(ic).GetBottomBand();
				if(bottomband!=ABand)
				{
					freturn=Math.Max(freturn,GetTops(IndexOfBand(bottomband))+bottomband.Height-top);
				}
			}
			return freturn;
		}

		protected override StringList GetTemplate()
		{
			StringList sl;
			if(FTemplate==null)
			{
				FTemplate=new StringList("Rep.FTemplate");
			}
			sl=new StringList("Rep.GetTemplate sl");
			FTemplate.Clear();

			FTemplate.Add(" <REP>");
			if(Orientation==PrinterOrientation.Landscape)
				FTemplate.Add("  <ORIENTATION>LANDSCAPE</ORIENTATION>");
			if(LeftMargin!=0)
				FTemplate.Add(String.Format(Generic.inf,"  <LEFTMARGIN>{0:F}</LEFTMARGIN>",(float)(LeftMargin/Generic.ZoomFactor)));
			if(TopMargin!=0)
				FTemplate.Add(String.Format(Generic.inf,"  <TOPMARGIN>{0:F}</TOPMARGIN>",(float)(TopMargin/Generic.ZoomFactor)));
			if(RightMargin!=0)
				FTemplate.Add(String.Format(Generic.inf,"  <RIGHTMARGIN>{0:F}</RIGHTMARGIN>",(float)(RightMargin/Generic.ZoomFactor)));
			if(BottomMargin!=0)
				FTemplate.Add(String.Format(Generic.inf,"  <BOTTOMMARGIN>{0:F}</BOTTOMMARGIN>",(float)(BottomMargin/Generic.ZoomFactor)));

			if(PageColor.ToArgb()!=Color.White.ToArgb())
				FTemplate.Add(string.Format("  <PAGECOLOR>{0:D}</PAGECOLOR>",PageColor.ToArgb()));
			if(PageGraident!=false)
				FTemplate.Add(string.Format("  <PAGEGRAIDENT>{0:D}</PAGEGRAIDENT>",Convert.ToInt32(PageGraident)));
			if(PageGraident)
			{
				if(PageGraidentColor.ToArgb()!=Color.Black.ToArgb())
					FTemplate.Add(string.Format("  <PAGEGRAIDENTCOLOR>{0:D}</PAGEGRAIDENTCOLOR>",PageGraidentColor.ToArgb()));
				if(PageFillDirection!=FillDirection.None)
					FTemplate.Add(string.Format("  <PAGEFILLDIRECTION>{0:D}</PAGEFILLDIRECTION>",(int)PageFillDirection));
			}
			if(PageImage!=false)
				FTemplate.Add(string.Format("  <PAGEIMAGE>{0:D}</PAGEIMAGE>",Convert.ToInt32(PageImage)));
			if(PageImage)
			{
				if(PagePicture!=null)
				{
					if(PageLinkPictureToFile!=false)
						FTemplate.Add(string.Format("  <PAGELINKPICTURETOFILE>{0:d}</PAGELINKPICTURETOFILE>",Convert.ToInt32(PageLinkPictureToFile)));
					if(PageImagePosition!=ImagePosition.Center)
						FTemplate.Add(string.Format("  <PAGEPICTUREPOSITION>{0:D}</PAGEPICTUREPOSITION>",(int)PageImagePosition));
				}
				if(PageLinkPictureToFile)
					FTemplate.Add(string.Format("  <PAGEPICTUREFILENAME>{0}</PAGEPICTUREFILENAME>",PagePictureFileName));
				
				if((!PageLinkPictureToFile)&&(PagePicture!=null))
				{
					FTemplate.Add(string.Format("  <PAGEPICTURE>{0}</PAGEPICTURE>",Generic.GraphicToString(PagePicture)));
				}
			}

			if(Font.Name!="Arial")
				FTemplate.Add(String.Format("  <FONTNAME>{0}</FONTNAME>",Font.Name));
			if(Font.Size!=9.75F)
				FTemplate.Add(String.Format(Generic.inf,"  <FONTSIZE>{0:f2}</FONTSIZE>",Font.Size));
			if(FontColor.ToArgb()!=Color.Black.ToArgb())
				FTemplate.Add(String.Format("  <FONTCOLOR>{0:D}</FONTCOLOR>",FontColor.ToArgb()));
			if(Font.Style!=FontStyle.Regular)
				FTemplate.Add(String.Format("  <FONTSTYLE>{0:D}</FONTSTYLE>",(int)Font.Style));

			FTemplate.AddStrings(PageSize.Template);
			for(int i=0;i<StyleList.Count;i++)
				FTemplate.AddStrings(((Style)StyleList[i]).Template);

			Band band;
			for(int i=0;i<BandCount;i++)
			{
				band=GetBand(i);
				FTemplate.AddStrings(band.Template);
			}
			FTemplate.Add(" </REP>");
			return FTemplate;
		}

		public void ApplyRep(XmlNode node,UserRep userrep)
		{
			XmlNode childnode;
			XmlNodeList childnodelist;
			XmlNodeReader reader;
			Band band;

			PageFillDirection=FillDirection.None;
			PageGraident=false;
			PageColor=Color.White;
			PageGraidentColor=Color.Black;
			PageImage=false;
			PagePictureFileName="";
			PagePicture=null;
			PageLinkPictureToFile=false;
			PageImagePosition=ImagePosition.Center;
			LeftMargin=0;
			RightMargin=0;
			TopMargin=0;
			BottomMargin=0;

			BeginUpdate();
			DeleteAll();
			Font=new Font(this.Font,FontStyle.Regular);

			reader=new XmlNodeReader(node);
			while(reader.Read())
			{
				if(reader.Name=="ORIENTATION" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					if(reader.Value=="LANDSCAPE")
						Orientation=PrinterOrientation.Landscape;
					else
						Orientation=PrinterOrientation.Portrait;
				}
				else if(reader.Name=="LEFTMARGIN" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					LeftMargin=Generic.ZoomFactor*Convert.ToDouble(reader.Value,Generic.inf);
				}
				else if(reader.Name=="TOPMARGIN" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					TopMargin=Generic.ZoomFactor*Convert.ToDouble(reader.Value,Generic.inf);
				}
				else if(reader.Name=="RIGHTMARGIN" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					RightMargin=Generic.ZoomFactor*Convert.ToDouble(reader.Value,Generic.inf);
				}
				else if(reader.Name=="BOTTOMMARGIN" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					BottomMargin=Generic.ZoomFactor*Convert.ToDouble(reader.Value,Generic.inf);
				}
				else if(reader.Name=="PAGECOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					PageColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="PAGEGRAIDENT" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					PageGraident=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="PAGEGRAIDENTCOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					PageGraidentColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="PAGEFILLDIRECTION" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					PageFillDirection=(FillDirection)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="PAGEIMAGE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					PageImage=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="PAGEPICTUREFILENAME" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					PagePictureFileName=reader.Value;
				}
				else if(reader.Name=="PAGELINKPICTURETOFILE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					PageLinkPictureToFile=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="PAGEPICTUREPOSITION" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					PageImagePosition=(ImagePosition)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="PAGEPICTURE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					MemoryStream ms=new MemoryStream();
					for(int j=0;j<reader.Value.Length;j++)
					{							
						byte b;
						b=Convert.ToByte(Generic.StringToInt(reader.Value[j].ToString(),reader.Value[j+1].ToString()));
						ms.WriteByte(b);
						j++;
						j++;
					}
					PagePicture=new Bitmap(ms);
				}
				else if(reader.Name=="FONTNAME" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					Font=new Font(reader.Value,Font.Size);
				}
				else if(reader.Name=="FONTSIZE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					Font=new Font(Font.Name,Convert.ToSingle(reader.Value,Generic.inf));
				}
				else if(reader.Name=="FONTCOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					FontColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="FONTSTYLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					Font=new Font(Font.Name,Font.Size,(FontStyle)Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="PAGESIZE" && reader.NodeType==XmlNodeType.Element)
				{
					break;
				}
			}
			childnode=node.SelectSingleNode("PAGESIZE");
			PageSize.ApplyPageSize(childnode);

			childnodelist=node.SelectNodes("STYLE");
			StyleList.Clear();
			for(int i=0;i<childnodelist.Count;i++)
			{
				Style style=new Style();
				style.ApplyStyle(childnodelist[i]);
				StyleList.Add(style);
			}

			childnodelist=node.SelectNodes("BAND");
			for(int i=0;i<childnodelist.Count;i++)
			{
				band=NewBand();
				band.ApplyBand(childnodelist[i]);
				if(userrep!=null)
					userrep.ProgressStep();
			}
			EndUpdate();
		}

		public Band NewBand()
		{
			BeginUpdate();
			Band freturn;

			freturn=new Band(null);
			freturn.OnBandChange+=new EventHandler(base.BandChange);
			freturn.OnCellChange+=new CellChangeEvent(base.CellChange);
			freturn.Name=String.Format("{0} {1:D}",freturn.Name,BandCount);
			Add(freturn);
			Changed=true;
			EndUpdate();
			return freturn;
		}

		public void Save(string AFileName)
		{
			StringList L;
			L=Template;
			if(FileSystem==null)
				L.SaveToFile(AFileName);
			else
			{
				try
				{
					L.SaveToStream(FileSystem.CreateWriteStream(AFileName));
				}
				finally
				{
					FileSystem.CloseWriteStream();
				}
			}
		}

		public void CellArrangement()
		{
			float WidthCount=0;
			float HeightCount=0;
				
			for(int idxband=0;idxband<BandCount;idxband++)
			{
				if(idxband==BandCount-1)
				{
					for(int idxband2=0;idxband2<BandCount-1;idxband2++)
					{
						HeightCount=HeightCount+GetBand(idxband2).Height;
					}					
					GetBand(idxband).Height=NewHeight-HeightCount-Generic.ToPix(TopMargin)-Generic.ToPix(BottomMargin)-1;							
				}
				else
				{
					float HeightRatio=(OldGridHeight-Generic.ToPix(OldTopMargin)-Generic.ToPix(OldBottomMargin))/GetBand(idxband).Height;
					float height=(NewHeight-Generic.ToPix(TopMargin)-Generic.ToPix(BottomMargin))/HeightRatio;
					GetBand(idxband).Height=height;					
				}
				for(int idxcell=0;idxcell<GetBand(idxband).CellCount;idxcell++)
				{
					if(idxcell==GetBand(idxband).CellCount-1)
					{
						WidthCount=0;
						for(int idxcell2=0;idxcell2<GetBand(idxband).CellCount-1;idxcell2++)
						{
							WidthCount=WidthCount+GetBand(idxband).GetCell(idxcell2).Width;
						}
						GetBand(idxband).GetCell(idxcell).Width=NewWidth-WidthCount-Generic.ToPix(LeftMargin)-Generic.ToPix(RightMargin)-1;
					}
					else
					{
						float WidthRatio=(OldGridWidth-Generic.ToPix(OldLeftMargin)-Generic.ToPix(OldRightMargin))/GetBand(idxband).GetCell(idxcell).Width;
						GetBand(idxband).GetCell(idxcell).Width=((NewWidth-Generic.ToPix(LeftMargin)-Generic.ToPix(RightMargin))/WidthRatio);
					}
				}
			}
		}

		public Bitmap PageToBitmap()
		{
			Bitmap freturn;
			Shape shape=new Shape();
			if(Orientation==PrinterOrientation.Portrait)
			{
				freturn=new Bitmap(PageSize.PaperSize.Width,PageSize.PaperSize.Height,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				shape.Size=new Size(PageSize.PaperSize.Width,PageSize.PaperSize.Height);
			}
			else
			{
				freturn=new Bitmap(PageSize.PaperSize.Height,PageSize.PaperSize.Width,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				shape.Size=new Size(PageSize.PaperSize.Height,PageSize.PaperSize.Width);
			}
			Graphics gr=Graphics.FromImage(freturn);
			gr.Clear(Color.White);
			shape.Location=new Point(0,0);
			shape.BorderColor=Color.White;
			shape.BackGroundColor=Generic.FindColor(PageColor,RenderingMode);
			shape.Gradient=PageGraident;
			if(PageGraident)
			{
				shape.GradientColor=Generic.FindColor(PageGraidentColor,RenderingMode);
				shape.FillDirection=PageFillDirection;
			}
			shape.ShapeType=ShapeType.Rectangle;
			shape.Paint(gr);
			if(PagePicture!=null)
			{
				int x,y;
				int width,height;
				switch(PageImagePosition)
				{
					case ImagePosition.Center:
						Bitmap bitmap=new Bitmap(RenderingPagePicture,PagePicture.PhysicalDimension.ToSize());
						if(Orientation==PrinterOrientation.Portrait)
						{
							y=(PageSize.PaperSize.Height-bitmap.Height)/2;
							x=(PageSize.PaperSize.Width-bitmap.Width)/2;
							gr.DrawImage(bitmap,new RectangleF(new PointF(x,y),new SizeF(bitmap.PhysicalDimension)));
						}
						else
						{
							y=(PageSize.PaperSize.Width-bitmap.Height)/2;
							x=(PageSize.PaperSize.Height-bitmap.Width)/2;
							gr.DrawImage(bitmap,new RectangleF(new PointF(x,y),new SizeF(bitmap.PhysicalDimension)));
						}
						break;
					case ImagePosition.Stretch:
						if(Orientation==PrinterOrientation.Portrait)
						{
							y=0;
							x=0;
							width=PageSize.PaperSize.Width;
							height=PageSize.PaperSize.Height;
							gr.DrawImage(RenderingPagePicture,new RectangleF(new PointF(x,y),new SizeF(width,height)));
						}
						else
						{
							y=0;
							x=0;
							width=PageSize.PaperSize.Height;
							height=PageSize.PaperSize.Width;
							gr.DrawImage(RenderingPagePicture,new RectangleF(new PointF(x,y),new SizeF(width,height)));
						}
						break;
					case ImagePosition.Tile:
						bitmap=new Bitmap(RenderingPagePicture,PagePicture.PhysicalDimension.ToSize());
						TextureBrush brush=new TextureBrush(bitmap,System.Drawing.Drawing2D.WrapMode.Tile);
						if(Orientation==PrinterOrientation.Portrait)
						{
							y=0;
							x=0;
							width=PageSize.PaperSize.Width;
							height=PageSize.PaperSize.Height;
							gr.FillRectangle(brush,new RectangleF(new PointF(x,y),new SizeF(width,height)));
						}
						else
						{
							y=0;
							x=0;
							width=PageSize.PaperSize.Height;
							height=PageSize.PaperSize.Width;
							gr.FillRectangle(brush,new RectangleF(new PointF(x,y),new SizeF(width,height)));
						}
						break;
				}
			}
			return freturn;
		}
		#endregion

		#region class properties
		public RenderingMode RenderingMode
		{
			get
			{
				return FRenderingMode;
			}
			set
			{
				FRenderingMode=value;
				PrepareRender();
			}
		}

		public PageSize PageSize
		{
			get
			{
				if(FPageSize==null)
					FPageSize=new PageSize();
				return FPageSize;
			}
			set
			{
				if(FPageSize!=value)
				{
					FPageSize=value;
				}
			}
		}

		public Color FontColor
		{
			get
			{
				return FFontColor;
			}
			set
			{
				BeginUpdate();
				FFontColor=value;
				Changed=true;
				EndUpdate();
			}
		}
		public Font Font
		{
			get
			{
				return FFont;
			}
			set
			{
				BeginUpdate();
				FFont=value;
				Changed=true;
				EndUpdate();
			}
		}

		public bool PageImage
		{
			get
			{
				return FPageImage;
			}
			set
			{
				if(FPageImage!=value)
				{
					if(value==false)
					{
						BeginUpdate();
						FPageImage=value;
						PagePicture=null;
						PagePictureFileName="";
						Changed=true;
						EndUpdate();
					}
					else
					{
						BeginUpdate();
						FPageImage=value;
						Changed=true;
						EndUpdate();
					}
				}
			}
		}

		public ImagePosition PageImagePosition
		{
			get
			{
				return FPageImagePosition;
			}
			set
			{
				if(FPageImagePosition!=value)
				{
					BeginUpdate();
					FPageImagePosition=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public bool PageLinkPictureToFile
		{
			get
			{
				return FPageLinkPictureToFile;
			}
			set
			{
				if(FPageLinkPictureToFile!=value)
				{
					BeginUpdate();
					FPageLinkPictureToFile=value;
					Changed=true;
					EndUpdate();					
				}
			}
		}

		public Image PagePicture
		{
			get
			{
				return FPagePicture;
			}
			set
			{
				if(FPagePicture!=value)
				{
					BeginUpdate();
					FPagePicture=value;
					if(RenderingPagePicture==null || RenderingPagePicture!=value)
						RenderingPagePicture=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public string PagePictureFileName
		{
			get
			{
				return  FPagePictureFileName;
			}
			set
			{
				if(FPagePictureFileName!=value.Trim())
				{
					BeginUpdate();
					FPagePictureFileName=value.Trim();
					try
					{
						PagePicture=new Bitmap(FPagePictureFileName);
					}
					catch
					{
					}
					Changed=true;
					EndUpdate();
				}
			}
		}

		public Color PageColor
		{
			get
			{
				return FPageColor;
			}
			set
			{
				if(FPageColor!=value)
				{
					BeginUpdate();
					FPageColor=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public bool PageGraident
		{
			get
			{
				return FPageGraident;
			}
			set
			{
				if(FPageGraident!=value)
				{
					BeginUpdate();
					FPageGraident=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public Color PageGraidentColor
		{
			get
			{
				return FPageGraidentColor;
			}
			set
			{
				if(FPageGraidentColor!=value)
				{
					BeginUpdate();
					FPageGraidentColor=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public FillDirection PageFillDirection
		{
			get
			{
				return FPageFillDirection;
			}
			set
			{
				if(FPageFillDirection!=value)
				{
					BeginUpdate();
					FPageFillDirection=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public int FirstPage
		{
			get
			{
				return GetBand(0).Pageno;
			}
		}

		public int LastPage
		{
			get
			{
				return GetBand(BandCount-1).Pageno;
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
				if(value!=FLeftMargin)
				{
					OldLeftMargin=FLeftMargin;
					FLeftMargin=value;					
					if(Orientation==PrinterOrientation.Portrait)
					{
						OldGridHeight=(int)(PageSize.PaperSize.Height*Generic.ZoomFactor);
						OldGridWidth=(int)(PageSize.PaperSize.Width*Generic.ZoomFactor);
					}
					else
					{
						OldGridHeight=(int)(PageSize.PaperSize.Width*Generic.ZoomFactor);
						OldGridWidth=(int)(PageSize.PaperSize.Height*Generic.ZoomFactor);
					}					
					CellArrangement();
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
				if(value!=FRightMargin)
				{
					OldRightMargin=FRightMargin;
					FRightMargin=value;					
					if(Orientation==PrinterOrientation.Portrait)
					{
						OldGridHeight=(int)(PageSize.PaperSize.Height*Generic.ZoomFactor);
						OldGridWidth=(int)(PageSize.PaperSize.Width*Generic.ZoomFactor);
					}
					else
					{
						OldGridHeight=(int)(PageSize.PaperSize.Width*Generic.ZoomFactor);
						OldGridWidth=(int)(PageSize.PaperSize.Height*Generic.ZoomFactor);
					}
					CellArrangement();
				}
			}
		}

		public double TopMargin
		{
			get
			{
				return FTopMargin;
			}
			set
			{
				if(value!=FTopMargin)
				{
					OldTopMargin=FTopMargin;
					FTopMargin=value;
					if(Orientation==PrinterOrientation.Portrait)
					{
						OldGridHeight=(int)(PageSize.PaperSize.Height*Generic.ZoomFactor);
						OldGridWidth=(int)(PageSize.PaperSize.Width*Generic.ZoomFactor);
					}
					else
					{
						OldGridHeight=(int)(PageSize.PaperSize.Width*Generic.ZoomFactor);
						OldGridWidth=(int)(PageSize.PaperSize.Height*Generic.ZoomFactor);
					}
					CellArrangement();
				}
			}
		}

		public double BottomMargin
		{
			get
			{
				return FBottomMargin;
			}
			set
			{
				if(value!=FBottomMargin)
				{	
					OldBottomMargin=FBottomMargin;
					FBottomMargin=value;					
					if(Orientation==PrinterOrientation.Portrait)
					{
						OldGridHeight=(int)(PageSize.PaperSize.Height*Generic.ZoomFactor);
						OldGridWidth=(int)(PageSize.PaperSize.Width*Generic.ZoomFactor);
					}
					else
					{
						OldGridHeight=(int)(PageSize.PaperSize.Width*Generic.ZoomFactor);
						OldGridWidth=(int)(PageSize.PaperSize.Height*Generic.ZoomFactor);
					}
					CellArrangement();
				}
			}
		}
		#endregion		
	}
	#endregion

	#region BandList
	public class BandList
	{
		#region class events
		public event EventHandler Change;
		public event CellChangeEvent OnCellChange;
		public event EventHandler OnBandChange;
		#endregion

		#region class variables
		protected StringList FTemplate;
		int InUpdateCnt;
		protected bool Changed;
		BandList FOwner;
		List FBands;
		public float FTop;
		float FHeight;
		string FName;
		int FId;
		#endregion

		#region constructor
		public BandList()
		{
			FBands=new List("BandList.bands");
			Owner=null;
		}
		#endregion

		#region class properties
		public BandList this[int index]
		{
			get
			{
				return (BandList)FBands[index];
			}
		}

		public float Height
		{
			get
			{
				return FHeight;
			}
			set
			{
				if(FHeight!=value)
				{
					BeginUpdate();
					FHeight=value;
					if(Owner!=null)
					{
						Owner.ReculcTops(Owner.FBands.IndexOf(this)+1);
					}
					Changed=true;
					EndUpdate();
				}
			}
		}

		public string Name
		{
			get
			{
				return FName;
			}
			set
			{
				if(FName!=value)
				{
					BeginUpdate();
					FName=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public BandList Owner
		{
			get
			{
				return FOwner;
			}
			set
			{
				int idx;

				if(FOwner!=value)
				{
					BeginUpdate();
					FOwner=value;
					if(Owner!=null)
					{
						idx=Owner.FBands.IndexOf(this);
						if(idx!=-1)
						{
							for(int i=Owner.FBands.IndexOf(this);i<Owner.FBands.Count;i++)
							{
								BandList fband=(BandList)Owner.FBands[i];
								fband.FTop=fband.FTop+FHeight;
							}
						}
					}
					else
					{
						FTop=0;
					}
					Changed=true;
					EndUpdate();
				}
			}
		}

		public int BandCount
		{
			get
			{
				return FBands.Count;
			}
		}

		public int Id
		{
			get
			{
				return FId;
			}
			set
			{
				FId=value;
			}
		}

		public virtual StringList Template
		{
			get
			{
				return GetTemplate();
			}
		}
		#endregion

		#region class methods
		public void Delete(int Index)
		{
			BeginUpdate();
			FBands.RemoveAt(Index);
			ReculcTops(Index);
			Changed=true;
			EndUpdate();
		}

		public bool MoveBand(int CurIndex,int NewIndex)
		{
			bool freturn;
			freturn=false;
			if((CurIndex!=NewIndex)&&(NewIndex>=0)&&(NewIndex<BandCount))
			{
				BeginUpdate();
				FBands.Move(CurIndex,NewIndex);
				ReculcTops(0);
				Changed=true;
				EndUpdate();
				freturn=true;
			}
			return freturn;
		}

		public void CellChange(object source,CellChangeEventArgs arg)
		{
			if(!InUpdate())
			{
				if(OnCellChange!=null)
					OnCellChange(source,arg);
			}
		}

		public void BandChange(object source,EventArgs arg)
		{
			if(!InUpdate())
			{
				if(OnBandChange!=null)
					OnBandChange(source,EventArgs.Empty);
			}
		}

		public void Add(BandList ABand)
		{
			BandList flist;
			BeginUpdate();
			ABand.Owner=this;
			FBands.Add(ABand);
			if(FBands.Count==1)
				ABand.FTop=0;
			else
			{
				flist=(BandList)FBands[FBands.Count-2];
				ABand.FTop=flist.FTop+flist.Height;
			}
			ABand.OnBandChange+=new EventHandler(BandChange);
			ABand.OnCellChange+=new CellChangeEvent(CellChange);
			Changed=true;
			EndUpdate();
		}

		public void Insert(int index,BandList ABand)
		{
			BandList flist;
			BeginUpdate();
			ABand.Owner=this;
			FBands.Insert(index,ABand);
			if(FBands.Count==1)
				ABand.FTop=0;
			else
			{
				flist=(BandList)FBands[FBands.Count-2];
				ABand.FTop=flist.FTop+flist.Height;
			}
			ABand.OnBandChange+=new EventHandler(BandChange);
			ABand.OnCellChange+=new CellChangeEvent(CellChange);
			Changed=true;
			EndUpdate();
		}

		public int IndexOfBand(BandList ABand)
		{
			return FBands.IndexOf(ABand);
		}

		void ReculcTops(int idxband)
		{
			float oldtop;

			if((idxband>=0)&&(idxband<FBands.Count))
			{
				if(idxband==0)
				{
					oldtop=0;
				}
				else
				{
					oldtop=((BandList)FBands[idxband-1]).FTop+((BandList)FBands[idxband-1]).Height;
				}
				for(int i=idxband;i<FBands.Count;i++)
				{
					((BandList)FBands[i]).FTop=oldtop;
					oldtop=oldtop+((BandList)FBands[i]).Height;
				}
			}
		}

		public void DeleteAll()
		{
			BeginUpdate();
			while(FBands.Count>0)
			{
				FBands.RemoveAt(0);
			}
			Changed=true;
			EndUpdate();
		}

		public virtual void BeginUpdate()
		{
			InUpdateCnt++;
		}

		public virtual void EndUpdate()
		{
			InUpdateCnt--;
			Invalidate();
		}

		protected virtual void Invalidate()
		{
			if((Changed)&&(!InUpdate()))
			{
				if(Change!=null)
					Change(this,EventArgs.Empty);
				Changed=false;
			}
		}

		protected bool InUpdate()
		{
			if(InUpdateCnt!=0)
				return true;
			else
				return false;
		}

		protected virtual StringList GetTemplate()
		{
			if(FTemplate==null)
			{
				FTemplate=new StringList("BandList.FTemplate");
			}
			return FTemplate;
		}
		#endregion		
	}
	#endregion

	#region Band
	public class Band:BandList
	{
		#region class variables
		bool FLockHeight;
		Rep FOrgRep;
		List CellList;
		BandState FBandState;
		public bool sender;
		public int Pageno;
		bool FPage;
		int FNode;
		string FNodeValue;
		#endregion

		#region constructor
		public Band(Rep AOrgRep)
		{
			BeginUpdate();
			FOrgRep=AOrgRep;
			Generic.BandCnt++;
			CellList=new List("Band.CellList");
			Name="Band";
			Height=25;
			NewCell();
			NewCell();
			NewCell();
			NewCell();
			Page=false;
			LockHeight=false;
			Changed=true;
			EndUpdate();
		}
		#endregion

		#region class properties
		public bool LockHeight
		{
			get
			{
				return FLockHeight;
			}
			set
			{
				FLockHeight=value;
			}
		}

		public bool Selected
		{
			get
			{
				bool freturn;
				freturn=false;
				for(int i=0;i<CellCount;i++)
				{
					freturn=(freturn||(GetCell(i).Selected));
					if(freturn==true)
						break;
				}
				return freturn;
			}
			set
			{
				for(int i=0;i<CellCount;i++)
					GetCell(i).Selected=value;
			}
		}

		public int CellCount
		{
			get
			{
				try
				{
					if(CellList!=null)
						return CellList.Count;
					else
						return 0;
				}
				catch
				{
					return 0;
				}
			}
		}

		public bool Page
		{
			get
			{
				return FPage;
			}
			set
			{
				FPage=value;
				if(value==false)
					Pageno=0;
			}
		}

		public BandState BandState
		{
			get
			{
				return FBandState;
			}
			set
			{
				FBandState=value;
			}
		}

		public Rep OrgRep
		{
			get
			{
				return FOrgRep;
			}
		}

		public int Node
		{
			get
			{
				return FNode;
			}
			set
			{
				FNode=value;
			}
		}

		public string NodeValue
		{
			get
			{
				return FNodeValue;
			}
			set
			{
				FNodeValue=value;
			}
		}
		#endregion

		#region class methods
		public void DeleteCell(int idxcell)
		{
			BeginUpdate();
			if(idxcell<CellCount)
			{
				CellList.RemoveAt(idxcell);
			}
			if(CellCount==0)
				NewCell();
			Changed=true;
			EndUpdate();
		}

		public void MoveCell(int idxcellfrom,int idxcellto)
		{
			BeginUpdate();
			CellList.Move(idxcellfrom,idxcellto);
			Changed=true;
			EndUpdate();
		}

		public void Split(Cell ACell)
		{
			int idxcell;
			float w;
			Cell ncell;

			BeginUpdate();
			idxcell=IndexOfCell(ACell);
			if(idxcell>=0)
			{
				w=ACell.Width;
				ncell=NewCell();
				ncell.Assign(ACell);
				ncell.Width=w/2;
				ACell.Width=(w/2)+(w%2);
				CellList.Move(CellCount-1,idxcell+1);
			}
			Changed=true;
			EndUpdate();
		}

		public Cell GetCell(int index)
		{
			
			if(index<CellCount)
			{
				return (Cell)CellList[index];
			}
			else
				return null;
		}
			
		public void SetCell(int index,Cell Value)
		{
			CellList[index]=Value;
		}
		
		public float GetLefts(int index)
		{
			float freturn=0;
			float left;

			if((CellCount>1)&&(index<CellCount))
			{
				left=0;
				for(int i=0;i<CellCount;i++)
				{
					if(i==index)
					{
						return left;
					}
					else
					{
						left=left+GetCell(i).Width;
					}
				}
			}
			return freturn;
		}

		public float GetRights(int index)
		{
			return GetLefts(index)+GetCell(index).Width;
		}

		public float GetWidth()
		{
			float freturn=0;
			for(int idxcell=0;idxcell<CellCount;idxcell++)
			{
				freturn=freturn+GetCell(idxcell).Width+1;
			}
			return freturn;
		}

		public int IndexOfCell(Cell ACell)
		{
			return CellList.IndexOf(ACell);
		}

		public void ApplyBand(XmlNode node)
		{
			XmlNodeReader reader;
			XmlNodeList childnodelist;
			Cell cell;

			reader=new XmlNodeReader(node);
			BeginUpdate();
			DeleteCells();
			while(reader.Read())
			{
				if(reader.Name=="NAME" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					Name=Generic.GetXMLString(reader.Value);
				}
				else if(reader.Name=="HEIGHT" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					Height=Generic.ZoomFactor*Convert.ToSingle(reader.Value,Generic.inf);
				}
				else if(reader.Name=="BANDSTATE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					BandState=(BandState)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="PAGENO" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					Page=true;
					Pageno=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="NODE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					Node=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="NODEVALUE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					NodeValue=Generic.GetXMLString(reader.Value);
				}
				else if(reader.Name=="LOCKHEIGHT" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					LockHeight=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="CELL" && reader.NodeType==XmlNodeType.Element)
				{
					break;
				}
			}
			childnodelist=node.SelectNodes("CELL");
			for(int i=0;i<childnodelist.Count;i++)
			{
				cell=NewCell();
				cell.ApplyCell(childnodelist[i]);
			}
			EndUpdate();
		}

		protected override StringList GetTemplate()
		{
			int idxcell;

			if(FTemplate==null)
			{
				FTemplate=new StringList("Band.FTemplate");
			}
			FTemplate.Clear();

			FTemplate.Add("  <BAND>");
			string name=Generic.GetXMLEscapes(Name);
			FTemplate.Add(string.Format("   <NAME>{0}</NAME>",name));
			FTemplate.Add(string.Format(Generic.inf,"   <HEIGHT>{0:F2}</HEIGHT>",Height/Generic.ZoomFactor));
			if(BandState!=(BandState)0)
				FTemplate.Add(string.Format("   <BANDSTATE>{0:D}</BANDSTATE>",(int)BandState));
			if(Page)
				FTemplate.Add(string.Format("   <PAGENO>{0:D}</PAGENO>",(int)Pageno));
			FTemplate.Add(string.Format("   <NODE>{0:D}</NODE>",Node));
			string nodevalue="";
			if(NodeValue!=null)
				nodevalue=Generic.GetXMLEscapes(NodeValue);
			FTemplate.Add(string.Format("   <NODEVALUE>{0}</NODEVALUE>",nodevalue));
			if(LockHeight!=false)
				FTemplate.Add("   <LOCKHEIGHT>1</LOCKHEIGHT>");
			for(idxcell=0;idxcell<CellCount;idxcell++)
			{
				FTemplate.AddStrings(GetCell(idxcell).Template);
			}
			FTemplate.Add("  </BAND>");
			return FTemplate;
		}

		public void DeleteCells()
		{
			BeginUpdate();
			while(CellList.Count>0)
			{
				CellList.RemoveAt(0);
			}
			Changed=true;
			EndUpdate();
		}

		public Cell NewCell()
		{
			BeginUpdate();
			float width=0;
			Cell FReturn=new Cell();
			if(sender)
			{
				width=GetCell(CellCount-1).Width;
				GetCell(CellCount-1).Width=GetCell(CellCount-1).Width/2;
				FReturn.Width=width-GetCell(CellCount-1).Width;
			}
			FReturn.Owner=this;
			CellList.Add(FReturn);
			FReturn.Change+=new EventHandler(CellChange);
			Changed=true;
			EndUpdate();
			return FReturn;
		}

		void CellChange(object source,EventArgs arg)
		{
			CellChangeEventArgs a=new CellChangeEventArgs();
			a.cell=source;
			if(!InUpdate())
			{
				base.CellChange(this,a);
			}
		}

		public void NewPage(int page)
		{
			if(page!=0)
			{
				Pageno=page;
				Page=true;
			}
		}

		public void Assign(Band ABand)
		{
			BeginUpdate();
			DeleteCells();
			for(int i=0;i<ABand.CellList.Count;i++)
			{
				NewCell().Assign((Cell)ABand.CellList[i]);
			}
			Name=ABand.Name;
			Height=ABand.Height;
			BandState=ABand.BandState;
			Changed=true;
			EndUpdate();
		}
		#endregion		
	}
	#endregion

	#region delegates
	public delegate void CellChangeEvent(object sender,CellChangeEventArgs arg);
	#endregion

	#region CellChangeEventArgs
	public class CellChangeEventArgs:EventArgs
	{
		public Object cell;
	}
	#endregion

	#region Cell
	public class Cell
	{
		#region class variables
		CellMargins FCellMargins;
		public Image RenderingImage;
		bool FLockWidth;
		int InUpdateCnt;
		int[] FFrameWidths=new int[4];
		Color[] FFrameColors=new Color[4];
		public bool Changed;
		LineStyle[] FBorderStyles=new LineStyle[4];
		string FFontName;
		float FFontSize;
		Color FFontColor;
		FontStyle FFontStyle;
		int FTextAngle;
		HAlign FHAlign;
		VAlign FVAlign;
		float FWidth;
		CellOption Options;
		string FPictureFileName;
		Image FPicture;
		Control FControl;
		public Size ControlSize;
		public float ControlFontSize;
		public Point ControlLocation;
		bool FLinkPictureToFile;
		string FValue;
		StringList FTemplate;
		bool FShape;
		ShapeType FShapeType;
		bool FShapeGraident;
		Color FShapeColor;
		Color FShapeGraidentColor;
		FillDirection FShapeFillDirection;
		int FShapeBorderWidth;
		DashStyle FShapeBorderStyle;
		Color FShapeBorderColor;
		string FControlName;
		float FMinWidth;
		public int TextPos;
		public StringList VarNameList;

		public Band Owner;
		#endregion

		#region constructor
		public Cell()
		{
			Generic.CellCnt++;
			BeginUpdate();

			FontName="Arial";
			FontSize=9.75f;
			FontColor=Color.Black;
			FontStyle=0;
			TextAngle=0;
			Width=100;
			HAlign=HAlign.Center;
			VAlign=VAlign.Center;
			WordWrap=true;
			Tile=false;
			Shared=false;

			PictureFileName="";
			LinkPictureToFile=true;

			Value="";
			ShapeColor=Color.Black;
			ShapeBorderColor=Color.Black;
			ShapeGraidentColor=Color.Black;
			FrameColor=Color.Black;
			LockWidth=false;
			CellMargins=new CellMargins();
			EndUpdate();
		}
		#endregion

		#region class properties
		public CellMargins CellMargins
		{
			get
			{
				return FCellMargins;
			}
			set
			{
				BeginUpdate();				
				FCellMargins=value;
				Changed=true;
				EndUpdate();
			}
		}

		public bool LockWidth
		{
			get
			{
				return FLockWidth;
			}
			set
			{
				FLockWidth=value;
			}
		}

		public string S
		{
			get
			{
				return Value;
			}
			set
			{
				Value=value;
			}
		}

		public string ControlName
		{
			get
			{
				return FControlName;
			}
			set
			{
				FControlName=value;
			}
		}

		public LineStyle BorderStyle
		{
			get
			{
				if((FBorderStyles[0]==FBorderStyles[1])&&
					(FBorderStyles[1]==FBorderStyles[2])&&
					(FBorderStyles[2]==FBorderStyles[3]))
				{
					return FBorderStyles[0];
				}
				else
					return LineStyle.Solid;
			}
			set
			{
				BeginUpdate();
				for(int index=0;index<4;index++)
				{
					FBorderStyles[index]=value;
					if(value!=LineStyle.Solid)
					{
						FFrameWidths[index]=Generic.CellBorderWidths[(int)value];
					}
				}
				Changed=true;
				EndUpdate();
			}
		}

		[Browsable(false)]
		public StringList Template
		{
			get
			{
				StringList sl=new StringList("Cell.GetTemplate sl");

				if(FTemplate==null)
				{
					FTemplate=new StringList("Cell.FTemplate");
				}
				FTemplate.Clear();
                
				FTemplate.Add("   <CELL>");
				if(Shared)
					FTemplate.Add("    <SHARED>1</SHARED>");
				if(FontName!="Arial")
					FTemplate.Add(string.Format("    <FONTNAME>{0}</FONTNAME>",FontName));
				if(FontSize!=9.75F)
					FTemplate.Add(string.Format(Generic.inf,"    <FONTSIZE>{0:F2}</FONTSIZE>",FontSize));
				if(FontColor.ToArgb()!=Color.Black.ToArgb())
					FTemplate.Add(string.Format("    <FONTCOLOR>{0:D}</FONTCOLOR>",FontColor.ToArgb()));
				if(TextAngle!=0)
					FTemplate.Add(string.Format("    <TEXTANGLE>{0:D}</TEXTANGLE>",TextAngle));
				if(CellMargins.Left!=0)
					FTemplate.Add(string.Format("	 <LEFTMARGIN>{0:D}</LEFTMARGIN>",CellMargins.Left));
				if(CellMargins.Right!=0)
					FTemplate.Add(string.Format("	 <RIGHTMARGIN>{0:D}</RIGHTMARGIN>",CellMargins.Right));
				if(CellMargins.Top!=0)
					FTemplate.Add(string.Format("	 <TOPMARGIN>{0:D}</TOPMARGIN>",CellMargins.Top));
				if(CellMargins.Bottom!=0)
					FTemplate.Add(string.Format("	 <BOTTOMMARGIN>{0:D}</BOTTOMMARGIN>",CellMargins.Bottom));
				if(Shape)
				{
					FTemplate.Add(string.Format("    <SHAPE>{0:D}</SHAPE>",Convert.ToInt32(Shape)));
					if(ShapeType!=ShapeType.None)
						FTemplate.Add(string.Format("     <SHAPETYPE>{0:D}</SHAPETYPE>",Convert.ToInt32(ShapeType)));
					if(ShapeColor.ToArgb()!=Color.Black.ToArgb())
						FTemplate.Add(string.Format("     <SHAPECOLOR>{0:D}</SHAPECOLOR>",ShapeColor.ToArgb()));
					if(ShapeBorderWidth!=0)
						FTemplate.Add(string.Format("     <SHAPEBORDERWIDTH>{0:D}</SHAPEBORDERWIDTH>",ShapeBorderWidth));
					if(ShapeBorderStyle!=DashStyle.Solid)
						FTemplate.Add(string.Format("     <SHAPEBORDERSTYLE>{0:D}</SHAPEBORDERSTYLE>",Convert.ToInt32(ShapeBorderStyle)));
					if(ShapeBorderColor.ToArgb()!=Color.Black.ToArgb())
						FTemplate.Add(string.Format("     <SHAPEBORDERCOLOR>{0:D}</SHAPEBORDERCOLOR>",ShapeBorderColor.ToArgb()));

					if(ShapeGraident)
					{
						FTemplate.Add(String.Format( "    <SHAPEGRAIDENT>{0:D}</SHAPEGRAIDENT>",Convert.ToInt32(ShapeGraident)));
					
						if(ShapeGraidentColor.ToArgb()!=Color.Black.ToArgb())
							FTemplate.Add(string.Format("      <SHAPEGRAIDENTCOLOR>{0:D}</SHAPEGRAIDENTCOLOR>",ShapeGraidentColor.ToArgb()));
						if(ShapeFillDirection!=FillDirection.None)
							FTemplate.Add(string.Format("      <SHAPEFILLDIRECTION>{0:D}</SHAPEFILLDIRECTION>",Convert.ToInt32(ShapeFillDirection)));
					}
				}

				if(FontStyle!=FontStyle.Regular)
					FTemplate.Add(string.Format("    <FONTSTYLE>{0:D}</FONTSTYLE>",(int)FontStyle));

				if(GetFrameWidths(0)>0)
				{
					FTemplate.Add(string.Format("    <FRAMELEFT>{0:D},{1:D}</FRAMELEFT>",GetFrameWidths(0),GetFrameColors(0).ToArgb()));
					if(GetBorderStyles(0)!=LineStyle.Solid)
						FTemplate.Add(string.Format("    <LEFTFRAMESTYLE>{0}</LEFTFRAMESTYLE>",Generic.CellBorderNames[(int)GetBorderStyles(0)]));
				}
				if(GetFrameWidths(2)>0)
				{
					FTemplate.Add(string.Format("    <FRAMERIGHT>{0:D},{1:D}</FRAMERIGHT>",GetFrameWidths(2),GetFrameColors(2).ToArgb()));
					if(GetBorderStyles(2)!=LineStyle.Solid)
						FTemplate.Add(string.Format("    <RIGHTFRAMESTYLE>{0}</RIGHTFRAMESTYLE>",Generic.CellBorderNames[(int)GetBorderStyles(2)]));
				}
				if(GetFrameWidths(1)>0)
				{
					FTemplate.Add(string.Format("    <FRAMETOP>{0:D},{1:D}</FRAMETOP>",GetFrameWidths(1),GetFrameColors(1).ToArgb()));
					if(GetBorderStyles(1)!=LineStyle.Solid)
						FTemplate.Add(string.Format("    <TOPFRAMESTYLE>{0}</TOPFRAMESTYLE>",Generic.CellBorderNames[(int)GetBorderStyles(1)]));
				}
				if(GetFrameWidths(3)>0)
				{
					FTemplate.Add(string.Format("    <FRAMEBOTTOM>{0:D},{1:D}</FRAMEBOTTOM>",GetFrameWidths(3),GetFrameColors(3).ToArgb()));
					if(GetBorderStyles(3)!=LineStyle.Solid)
						FTemplate.Add(string.Format("    <BOTTOMFRAMESTYLE>{0}</BOTTOMFRAMESTYLE>",Generic.CellBorderNames[(int)GetBorderStyles(3)]));
				}

				if(!((FrameColor.ToArgb()!=Color.Black.ToArgb()) || FrameColor.ToArgb()!=0))
					FTemplate.Add(string.Format("    <FRAMECOLOR>{0:D}</FRAMECOLOR>",FrameColor.ToArgb()));
				if(FrameWidth!=0)
					FTemplate.Add(string.Format("    <FRAMEWIDTH>{0:D}</FRAMEWIDTH>",FrameWidth));

				if(Value!="")
				{
					string s=Generic.GetXMLEscapes(Value);
					sl.SetText(s);
					if(sl.Count<=1)
						FTemplate.Add(string.Format("    <VALUE>{0}</VALUE>",s));
					else
						FTemplate.Add(string.Format("    <COMMAVALUE>{0}</COMMAVALUE>",sl.GetCommaText()));
				}

				if(HAlign!=HAlign.Center)
					FTemplate.Add(string.Format("    <HALIGN>{0:D}</HALIGN>",(int)HAlign));
				if(VAlign!=VAlign.Center)
					FTemplate.Add(string.Format("    <VALIGN>{0:D}</VALIGN>",(int)VAlign));
				FTemplate.Add(string.Format(Generic.inf,"    <WIDTH>{0:F2}</WIDTH>",Width/Generic.ZoomFactor));

				if(WordWrap!=true)
					FTemplate.Add(string.Format("    <WORDWRAP>{0:D}</WORDWRAP>",Convert.ToInt32(WordWrap)));

				if(LinkPictureToFile && PictureFileName!="")
					FTemplate.Add(string.Format("    <PICTUREFILENAME>{0}</PICTUREFILENAME>",PictureFileName));

				if(LinkPictureToFile!=true)
					FTemplate.Add(string.Format("    <LINKPICTURETOFILE>{0:D}</LINKPICTURETOFILE>",Convert.ToInt32(LinkPictureToFile)));
				if(Picture!=null)
				{
					if(AutoSize!=false)
					{
						FTemplate.Add(string.Format("    <FITTOCELL>{0:D}</FITTOCELL>",Convert.ToInt32(AutoSize)));
						FTemplate.Add(string.Format("    <AUTOSIZE>{0:D}</AUTOSIZE>",Convert.ToInt32(AutoSize)));
					}
					if(Tile!=false)
						FTemplate.Add(string.Format("    <TILE>{0:D}</TILE>",Convert.ToInt32(Tile)));
				}

				if((!LinkPictureToFile)&&(Picture!=null))
				{
					FTemplate.Add(string.Format("    <PICTURE>{0}</PICTURE>",Generic.GraphicToString(Picture)));
				}

				if((ControlName!=null)&&(ControlName!=""))
					FTemplate.Add(string.Format("    <CONTROLNAME>{0}</CONTROLNAME>",ControlName));
				if(LockWidth!=false)
					FTemplate.Add("    <LOCKWIDTH>1</LOCKWIDTH>");
				FTemplate.Add("   </CELL>");
				return FTemplate;
			}
		}

		public bool InUse
		{
			get
			{
				return ((Owner!=null)&&(Owner!=GetTopBand()));
			}
		}

		public bool AutoSize
		{
			get
			{
				if(Options.ToString().IndexOf("AutoSize")!=-1)
					return true;
				else
					return false;
			}
			set
			{
				if(value!=(Options.ToString().IndexOf("AutoSize")!=-1))
				{
					BeginUpdate();
					if(value)
						Options=Options|CellOption.AutoSize;
					else
						Options=Options-(int)CellOption.AutoSize;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public bool Selected
		{
			get
			{
				if(Options.ToString().IndexOf("Selected")!=-1)
					return true;
				else
					return false;
			}
			set
			{
				if(value!=(Options.ToString().IndexOf("Selected")!=-1))
				{
					BeginUpdate();
					if(value)
						Options=Options|CellOption.Selected;
					else
						Options=Options-(int)CellOption.Selected;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public bool Shared
		{
			get
			{
				if(Options.ToString().IndexOf("Shared")!=-1)
					return true;
				else
					return false;
			}
			set
			{
				if(value!=(Options.ToString().IndexOf("Shared")!=-1))
				{
					BeginUpdate();
					if(value)
						Options=Options|CellOption.Shared;
					else
						Options=Options-(int)CellOption.Shared;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public string PictureFileName
		{
			get
			{
				return FPictureFileName;
			}
			set
			{
				if(FPictureFileName!=value.Trim())
				{
					BeginUpdate();
					FPictureFileName=value.Trim();
					if(FPictureFileName!="")
					{
						try
						{
							Picture=new Bitmap(FPictureFileName);
						}
						catch
						{
							Picture=null;
						}
					}
					else
					{
						Picture=null;
					}
					Changed=true;
					EndUpdate();
				}
			}
		}

		public Image Picture
		{
			get
			{
				return FPicture;
			}
			set
			{
				BeginUpdate();
				
				FPicture=value;
				if(RenderingImage==null || RenderingImage!=value)
					RenderingImage=value;
				Changed=true;
				EndUpdate();
			}
		}
		
		public Control Control
		{
			get
			{
				return FControl;
			}
			set
			{
				BeginUpdate();				
				FControl=value;				
				ControlSize=FControl.Size;
				ControlFontSize=FControl.Font.Size;
				ControlLocation=FControl.Location;
				Changed=true;
				EndUpdate();				
			}
		}

		public bool LinkPictureToFile
		{
			get
			{
				return FLinkPictureToFile;
			}
			set
			{
				BeginUpdate();
				FLinkPictureToFile=value;
				Changed=true;
				EndUpdate();
			}
		}

		public string Value
		{
			get
			{
				return FValue;
			}
			set
			{
				if(FValue!=value)
				{
					BeginUpdate();
					FValue=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public bool Focused
		{
			get
			{
				if(Options.ToString().IndexOf("Focused")!=-1)
					return true;
				else
					return false;
			}
			set
			{
				if(value!=(Options.ToString().IndexOf("Focused")!=-1))
				{
					BeginUpdate();
					if(value)
						Options=Options|CellOption.Focused;
					else
						Options=Options-(int)CellOption.Focused;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public Color FrameColor
		{
			get
			{
				if((FFrameColors[0]==FFrameColors[2])&&
					(FFrameColors[2]==FFrameColors[1])&&
					(FFrameColors[1]==FFrameColors[3]))
					return FFrameColors[0];
				else
					return Color.Black;
			}
			set
			{
				if(FrameColor!=value)
				{					
					BeginUpdate();
					for(int i=0;i<FFrameColors.Length;i++)
					{						
						FFrameColors[i]=value;						
					}
					Changed=true;
					EndUpdate();
				}
			}
		}

		public int FrameWidth
		{
			get
			{
				if((FFrameWidths[0]==FFrameWidths[2])&&
					(FFrameWidths[2]==FFrameWidths[1])&&
					(FFrameWidths[1]==FFrameWidths[3]))
					return FFrameWidths[0];
				else
					return 1;
			}
			set
			{
				BeginUpdate();
				int z=0;
				foreach(int i in FFrameWidths)
				{
					if(i>0)
					{
						FFrameWidths[z]=value;
						FBorderStyles[z]=LineStyle.Solid;
					}
					z++;
				}
				Changed=true;
				EndUpdate();
			}
		}

		public string FontName
		{
			get
			{
				return FFontName;
			}
			set
			{
				if(FFontName!=value)
				{
					BeginUpdate();
					FFontName=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public float FontSize
		{
			get
			{
				return FFontSize;
			}
			set
			{
				if(FFontSize!=value)
				{
					BeginUpdate();
					FFontSize=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public Color FontColor
		{
			get
			{
				return FFontColor;
			}
			set
			{
				if(FFontColor!=value)
				{
					BeginUpdate();
					FFontColor=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public FontStyle FontStyle
		{
			get
			{
				return FFontStyle;
			}
			set
			{
				if(FFontStyle!=value)
				{
					BeginUpdate();
					FFontStyle=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public int TextAngle
		{
			get
			{
				return FTextAngle;
			}
			set
			{
				if(FTextAngle!=value)
				{
					BeginUpdate();
					FTextAngle=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public HAlign HAlign
		{
			get
			{
				return FHAlign;
			}
			set
			{
				if(FHAlign!=value)
				{
					BeginUpdate();
					FHAlign=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public VAlign VAlign
		{
			get
			{
				return FVAlign;
			}
			set
			{
				if(FVAlign!=value)
				{
					BeginUpdate();
					FVAlign=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public float Width
		{
			get
			{
				return FWidth;
			}
			set
			{
				if(FWidth!=value)
				{
					BeginUpdate();
					FWidth=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public bool WordWrap
		{
			get
			{
				if(Options.ToString().IndexOf("WordWrap")!=-1)
					return true;
				else
					return false;
			}
			set
			{
				if(value!=(Options.ToString().IndexOf("WordWrap")!=-1))
				{
					BeginUpdate();
					if(value)
						Options=Options|CellOption.WordWrap;
					else
						Options=Options-(int)CellOption.WordWrap;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public bool Tile
		{
			get
			{
				if(Options.ToString().IndexOf("Tile")!=-1)
					return true;
				else
					return false;
			}
			set
			{
				if(value!=(Options.ToString().IndexOf("Tile")!=-1))
				{
					BeginUpdate();
					if(value)
						Options=Options|CellOption.Tile;
					else
						Options=Options-(int)CellOption.Tile;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public FrameStyles FrameStyle
		{
			get
			{
				FrameStyles fs=(FrameStyles)0;
				for(int i=1;i<5;i++)
				{
					if(FFrameWidths[i-1]>0)
						fs|=(FrameStyles)((int)Math.Pow(2,i));
				}
				return fs;
			}
			set
			{
				BeginUpdate();
				for(int i=1;i<5;i++)
				{
					if(value.ToString().IndexOf(Enum.GetName(typeof(FrameStyles),(int)Math.Pow(2,i)))!=-1)
					{
						if(FFrameWidths[i-1]==0)
							FFrameWidths[i-1]=1;
					}
					else
					{
						if(FFrameWidths[i-1]>0)
							FFrameWidths[i-1]=0;
					}
				}
				
				Changed=true;
				EndUpdate();
			}
		}

		public float MinWidth
		{
			get
			{
				return FMinWidth;
			}
			set
			{
				FMinWidth=value;
			}
		}

		public ShapeType ShapeType
		{
			get
			{
				return FShapeType;
			}
			set
			{
				if(FShapeType!=value)
				{
					BeginUpdate();
					FShapeType=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public Color ShapeColor
		{
			get
			{
				return FShapeColor;
			}
			set
			{
				if(FShapeColor!=value)
				{
					BeginUpdate();
					FShapeColor=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public Color ShapeGraidentColor
		{
			get
			{
				return FShapeGraidentColor;
			}
			set
			{
				if(FShapeGraidentColor!=value)
				{
					BeginUpdate();
					FShapeGraidentColor=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public bool ShapeGraident
		{
			get
			{
				return FShapeGraident;
			}
			set
			{
				if(FShapeGraident!=value)
				{
					BeginUpdate();
					FShapeGraident=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public FillDirection ShapeFillDirection
		{
			get
			{
				return FShapeFillDirection;
			}
			set
			{
				if(FShapeFillDirection!=value)
				{
					BeginUpdate();
					FShapeFillDirection=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public int ShapeBorderWidth
		{
			get
			{
				return FShapeBorderWidth;
			}
			set
			{
				if(FShapeBorderWidth!=value)
				{
					BeginUpdate();
					FShapeBorderWidth=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public DashStyle ShapeBorderStyle
		{
			get
			{
				return FShapeBorderStyle;
			}
			set
			{
				if(FShapeBorderStyle!=value)
				{
					BeginUpdate();
					FShapeBorderStyle=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public Color ShapeBorderColor
		{
			get
			{
				return FShapeBorderColor;
			}
			set
			{
				if(FShapeBorderColor!=value)
				{
					BeginUpdate();
					FShapeBorderColor=value;
					Changed=true;
					EndUpdate();
				}
			}
		}

		public bool Shape
		{
			get
			{
				return FShape;
			}
			set
			{
				if(FShape!=value)
				{
					BeginUpdate();
					FShape=value;
					Changed=true;
					EndUpdate();
				}
			}
		}
		#endregion

		#region class methods
		public void CreateVarNameList()
		{
			int p;string v;

			if(VarNameList==null)
				VarNameList=new StringList("Cell.VarNameList");
			VarNameList.Clear();
			v=Value;
			while(v.Length>0)
			{
				p=v.IndexOf("[");
				if(p==-1)
				{
					VarNameList.AddObject(v,0);
					break;
				}
				else
				{
					if(p>1)
					{
						VarNameList.AddObject(v.Substring(0,p),0);						
					}
					v=v.Remove(0,p+1);
					p=FindEndVarToken(v,"[","]");
					if(p==0)
					{
						break;
					}
					else
					{
						VarNameList.AddObject(v.Substring(0,p),1);
						v=v.Remove(0,p+1);
					}
				}
			}
		}

		public int FindEndVarToken(string v,string btok,string etok)
		{
			int count=1;
			int freturn=0;

			for(int i=0;i<v.Length;i++)
			{
				if(v[i]==btok[0])
					count++;
				if(v[i]==etok[0])
					count--;
				if(count==0)
				{
					return i;
				}
			}
			return freturn;
		}

		public void Assign(Cell ACell)
		{
			BeginUpdate();
			FrameStyle=ACell.FrameStyle;
			for(int i=0;i<4;i++)
			{
				SetFrameColors(i,ACell.GetFrameColors(i));
				SetFrameWidths(i,ACell.GetFrameWidths(i));
				SetBorderStyles(i,ACell.GetBorderStyles(i));
			}
			FontName=ACell.FontName;
			FontSize=ACell.FontSize;
			FontColor=ACell.FontColor;
			FontStyle=ACell.FontStyle;
			TextAngle=ACell.TextAngle;
			CellMargins=ACell.CellMargins;

			Shape=ACell.Shape;
			ShapeType=ACell.ShapeType;
			ShapeGraident=ACell.ShapeGraident;
			ShapeColor=ACell.ShapeColor;
			ShapeGraidentColor=ACell.ShapeGraidentColor;
			ShapeFillDirection=ACell.ShapeFillDirection;
			ShapeBorderWidth=ACell.ShapeBorderWidth;
			ShapeBorderStyle=ACell.ShapeBorderStyle;
			ShapeBorderColor=ACell.ShapeBorderColor;

			HAlign=ACell.HAlign;
			VAlign=ACell.VAlign;
			Width=ACell.Width;
			WordWrap=ACell.WordWrap;
			Tile=ACell.Tile;

			AutoSize=ACell.AutoSize;

			Value=ACell.Value;
			Shared=ACell.Shared;

			PictureFileName=ACell.PictureFileName;
			LinkPictureToFile=ACell.LinkPictureToFile;
			if(ACell.FPicture!=null)
			{
				object picture=ACell.FPicture.Clone();
				Picture=(Image)picture;
			}
			if(ACell.Control!=null)
			{
				Control=ACell.Control;
			}
			EndUpdate();
		}

		public void ApplyCell(XmlNode node)
		{
			bool newversion;
			XmlNodeReader reader;
			int var1;
			int var2;
			StringList sl=new StringList("Cell.ApplyCell sl");

			newversion=false;
			BeginUpdate();
			BorderStyle=LineStyle.Solid;
			FontStyle=FontStyle.Regular;
			FrameWidth=0;
			FrameColor=Color.FromArgb(0);
			TextAngle=0;
			FrameStyle=(FrameStyles)0;
			reader=new XmlNodeReader(node);
			CellMargins=new CellMargins();
			while(reader.Read())
			{
				if(reader.Name=="SHARED" && reader.NodeType==XmlNodeType.Element)
				{
					Shared=true;
				}
				else if(reader.Name=="FONTNAME" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					FontName=reader.Value;
				}
				else if(reader.Name=="FONTSIZE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					FontSize=Convert.ToSingle(reader.Value,Generic.inf);
				}
				else if(reader.Name=="FONTCOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					FontColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="TEXTANGLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					TextAngle=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="LEFTMARGIN" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					CellMargins.Left=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="RIGHTMARGIN" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					CellMargins.Right=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="TOPMARGIN" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					CellMargins.Top=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="BOTTOMMARGIN" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					CellMargins.Bottom=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="SHAPE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					Shape=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="SHAPETYPE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeType=(ShapeType)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="SHAPECOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="SHAPEBORDERWIDTH" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeBorderWidth=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="SHAPEBORDERSTYLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeBorderStyle=(DashStyle)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="SHAPEBORDERCOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeBorderColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="SHAPEGRAIDENT" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeGraident=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="SHAPEGRAIDENTCOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeGraidentColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="SHAPEFILLDIRECTION" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeFillDirection=(FillDirection)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="FONTSTYLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					FontStyle=(FontStyle)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="FRAMECOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					if(!newversion)
						FrameColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="FRAMEWIDTH" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					if(!newversion)
						FrameWidth=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="FRAMELEFT" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					newversion=true;
					Generic.SeparateInt(reader.Value,out var1,out var2);
					if(var1==-1)
						var1=1;
					SetFrameWidths(0,var1);
					SetFrameColors(0,Color.FromArgb(var2));						
				}
				else if(reader.Name=="FRAMERIGHT" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					newversion=true;
					Generic.SeparateInt(reader.Value,out var1,out var2);
					if(var1==-1)
						var1=1;
					SetFrameWidths(2,var1);
					SetFrameColors(2,Color.FromArgb(var2));						
				}
				else if(reader.Name=="FRAMETOP" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					newversion=true;
					Generic.SeparateInt(reader.Value,out var1,out var2);
					if(var1==-1)
						var1=1;
					SetFrameWidths(1,var1);
					SetFrameColors(1,Color.FromArgb(var2));						
				}
				else if(reader.Name=="FRAMEBOTTOM" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					newversion=true;
					Generic.SeparateInt(reader.Value,out var1,out var2);
					if(var1==-1)
						var1=1;
					SetFrameWidths(3,var1);
					SetFrameColors(3,Color.FromArgb(var2));						
				}
				else if(reader.Name=="LEFTFRAMESTYLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					SetBorderStyles(0,Generic.GetBorderStyleByName(reader.Value));					
				}
				else if(reader.Name=="RIGHTFRAMESTYLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					SetBorderStyles(2,Generic.GetBorderStyleByName(reader.Value));					
				}
				else if(reader.Name=="TOPFRAMESTYLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					SetBorderStyles(1,Generic.GetBorderStyleByName(reader.Value));					
				}
				else if(reader.Name=="BOTTOMFRAMESTYLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					SetBorderStyles(3,Generic.GetBorderStyleByName(reader.Value));					
				}
				else if(reader.Name=="VALUE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					Value=Generic.GetXMLString(reader.Value);
				}
				else if(reader.Name=="COMMAVALUE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					sl.SetCommaText(reader.Value);
					Value=Generic.GetXMLString(sl.GetText());
				}
				else if(reader.Name=="HALIGN" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					HAlign=(HAlign)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="VALIGN" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					VAlign=(VAlign)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="WIDTH" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					Width=Generic.ZoomFactor*Convert.ToSingle(reader.Value,Generic.inf);
				}
				else if(reader.Name=="WORDWRAP" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					WordWrap=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="AUTOSIZE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					AutoSize=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="TILE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					Tile=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="PICTUREFILENAME" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					PictureFileName=reader.Value;
				}
				else if(reader.Name=="LINKPICTURETOFILE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					LinkPictureToFile=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="CONTROLNAME" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ControlName=reader.Value;
				}
				else if(reader.Name=="PICTURE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					MemoryStream ms=new MemoryStream();
					for(int j=0;j<reader.Value.Length;j++)
					{							
						byte b;
						b=Convert.ToByte(Generic.StringToInt(reader.Value[j].ToString(),reader.Value[j+1].ToString()));
						ms.WriteByte(b);
						j++;
						j++;
					}
					Picture=new Bitmap(ms);
				}
				else if(reader.Name=="LOCKWIDTH" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					LockWidth=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
			}
			Changed=true;
			EndUpdate();
		}

		public Cell GetTopCell()
		{
			int ib, ic;
			float L;
			Band band;
			BandList bandlist;
			bool found;
			Cell Freturn;

			Freturn=this;
			if(Shared)
			{
				band=Owner;
				if(band!=null)
				{
					bandlist=band.Owner;
					if(bandlist!=null)
					{
						L=band.GetLefts(band.IndexOfCell(this));
						for(ib=bandlist.IndexOfBand(band)-1;ib>-1;ib--)
						{
							found=false;
							for(ic=0;ic<((Band)bandlist[ib]).CellCount;ic++)
							{
								if((L==((Band)bandlist[ib]).GetLefts(ic))&&
									(Width==((Band)bandlist[ib]).GetCell(ic).Width))
								{
									Freturn=((Band)bandlist[ib]).GetCell(ic);
									found=((Band)bandlist[ib]).GetCell(ic).Shared;
									break;
								}
							}
							if(!found)
								break;
						}
					}
				}
			}
			return Freturn;
		}

		protected void PaintFrames(Graphics gr,RectangleF r,RenderingMode Mode)
		{
			if(GetFrameWidths(0)>0)
				ShowBorder(gr,0,GetFrameWidths(1),GetFrameWidths(3),r,Mode);
			if(GetFrameWidths(1)>0)
				ShowBorder(gr,1,GetFrameWidths(1),GetFrameWidths(3),r,Mode);
			if(GetFrameWidths(2)>0)
				ShowBorder(gr,2,GetFrameWidths(0),GetFrameWidths(2),r,Mode);
			if(GetFrameWidths(3)>0)
				ShowBorder(gr,3,GetFrameWidths(0),GetFrameWidths(2),r,Mode);
		}

		void ShowBorder(Graphics gr,int fs,int WidthLeftTop,int WidthRightBottom,RectangleF r,RenderingMode Mode)
		{
			RectangleF Rect=new RectangleF(r.Left,r.Top,Math.Abs((r.Right-1)-r.Left),Math.Abs((r.Bottom-1)-r.Top));
			Generic.DrawBorder(gr,Rectangle.Round(Rect),GetBorderStyles(fs),fs,Generic.FindColor(GetFrameColors(fs),Mode),GetFrameWidths(fs),WidthLeftTop,WidthRightBottom);
		}

		public Band GetTopBand()
		{
			int ib,ic;
			float L;
			BandList bandlist;
			bool found;
			Band freturn;

			freturn=this.Owner;
			if(Shared)
			{
				if(freturn!=null)
				{
					bandlist=freturn.Owner;
					if(bandlist!=null)
					{
						L=freturn.GetLefts(freturn.IndexOfCell(this));
						for(ib=bandlist.IndexOfBand(freturn)-1;ib>-1;ib--)
						{
							found=false;
							for(ic=0;ic<((Band)(bandlist[ib])).CellCount;ic++)
							{
								if((L==((Band)(bandlist[ib])).GetLefts(ic))&&
									(Width==((Band)(bandlist[ib])).GetCell(ic).Width))
								{
									freturn=(Band)bandlist[ib];
									found=((Band)(bandlist[ib])).GetCell(ic).Shared;
									break;
								}
							}
							if(!found)
								break;
						}
					}
				}
			}
			return freturn;
		}

		public Band GetBottomBand()
		{
			int ib, ic;
			float L;
			BandList bandlist;
			bool found;
			Band freturn;

			freturn=Owner;
			if(freturn!=null)
			{
				bandlist=freturn.Owner;
				if(bandlist!=null)
				{
					L=freturn.GetLefts(freturn.IndexOfCell(this));
					for(ib=bandlist.IndexOfBand(freturn)+1;ib<bandlist.BandCount;ib++)
					{
						found=false;
						for(ic=0;ic<((Band)(bandlist[ib])).CellCount;ic++)
						{
							if((((Band)(bandlist[ib])).GetCell(ic).Shared)&&
								(L==((Band)(bandlist[ib])).GetLefts(ic))&&
								(Width==((Band)(bandlist[ib])).GetCell(ic).Width))
							{
								freturn=(Band)bandlist[ib];
								found=true;
								break;
							}
						}
						if(!found)
							break;
					}
				}
			}
			return freturn;
		}

		public void PaintCell(Graphics gr,RectangleF r,SelectedCellStyle SelectedCellStyle,FocusedCellStyle FocusedCellStyle,bool ControlVisible,RenderingMode Mode)
		{
			RectangleF rf;
			Cell cell;
			Brush brush;
			Pen pen;
			Color BrushColor;

			if(r.Right<=0)
				return;
			if(InUse)
			{
				cell=GetTopCell();
				if(cell!=this)
				{
					GetTopCell().PaintCell(gr,r,SelectedCellStyle,FocusedCellStyle,true,Mode);
				}
			}
			else
			{
				if((Selected)&&(SelectedCellStyle==ReportLibrary.SelectedCellStyle.Selected))
				{
					BrushColor=SystemColors.Highlight;
					brush=new SolidBrush(BrushColor);
					gr.FillRectangle(brush,r.Left,r.Top,Width,Math.Abs(r.Bottom-r.Top));
				}

				if(Shared)
				{
					pen=new Pen(Color.Black);
					gr.DrawLine(pen,r.Left,r.Top,r.Left+Width,r.Bottom);
					gr.DrawLine(pen,r.Left+Width,r.Top,r.Left,r.Bottom);
				}
				else
				{
					if((Selected)&&(SelectedCellStyle==ReportLibrary.SelectedCellStyle.Selected))
					{
						BrushColor=SystemColors.Highlight;
						brush=new SolidBrush(BrushColor);
						gr.FillRectangle(brush,r.Left,r.Top,Width,Math.Abs(r.Bottom-r.Top));
					}
					if(Shape)
					{
						Shape shape=new Shape();
						shape.Size=new Size((int)Width,(int)Math.Abs(r.Bottom-r.Top));
						shape.Location=new Point((int)r.Left,(int)r.Top);
						shape.BackGroundColor=Generic.FindColor(ShapeColor,Mode);
						shape.Gradient=ShapeGraident;
						if(ShapeGraident)
						{
							shape.GradientColor=Generic.FindColor(ShapeGraidentColor,Mode);
							shape.FillDirection=ShapeFillDirection;
						}
						shape.ShapeType=ShapeType;
						shape.BorderColor=Generic.FindColor(ShapeBorderColor,Mode);
						shape.BorderWidth=ShapeBorderWidth;
						shape.BorderStyle=ShapeBorderStyle;
						shape.Paint(gr);
						if((Selected)&&(SelectedCellStyle==ReportLibrary.SelectedCellStyle.Selected))
						{
							BrushColor=Color.FromArgb(70,SystemColors.Highlight);
							brush=new SolidBrush(BrushColor);
							gr.FillRectangle(brush,r.Left,r.Top,Width,Math.Abs(r.Bottom-r.Top));
						}
					}
					rf=new RectangleF(r.Left+FrameWidth,r.Top+FrameWidth,Math.Abs((r.Right-FrameWidth)-(r.Left+FrameWidth)),Math.Abs((r.Bottom-FrameWidth)-(r.Top+FrameWidth)));
					if(FPicture!=null)
					{
						PaintGraphic(RenderingImage,gr,rf);
					}

					if(ControlVisible)
					{
						if(Control!=null)
						{
							Control.Visible=true;
							Control.Location=new Point((int)rf.X+(int)(ControlLocation.X*Generic.ZoomFactor),(int)rf.Y+(int)(ControlLocation.Y*Generic.ZoomFactor));
							Control.Size=new Size((int)(ControlSize.Width*Generic.ZoomFactor),(int)(ControlSize.Height*Generic.ZoomFactor));
							Control.Font=new Font(Control.Font.Name,ControlFontSize*Generic.ZoomFactor,Control.Font.Style);
							Control.Refresh();
						}
					}

					System.Drawing.Font font=new Font(FontName,FontSize,FontStyle);
					if((Selected)&&(SelectedCellStyle==ReportLibrary.SelectedCellStyle.Selected))
					{
						BrushColor=SystemColors.HighlightText;
						brush=new SolidBrush(BrushColor);
					}
					else
					{
						BrushColor=Generic.FindColor(FontColor,Mode);
						brush=new SolidBrush(BrushColor);
					}

					Generic.DrawRectText(gr,Value,rf,HAlign,VAlign,WordWrap,TextAngle,brush,font,CellMargins);

					if(Generic.ShowHiddenItems && Generic.NonPrinting)
					{
						BrushColor=Color.Gray;
						brush=new HatchBrush(HatchStyle.DiagonalCross,BrushColor);
						gr.DrawRectangle(new Pen(brush),Rectangle.Round(r));
						brush=new SolidBrush(BrushColor);
					}
					PaintFrames(gr,r,Mode);
					if(Selected)
					{
						switch(SelectedCellStyle)
						{
							case ReportLibrary.SelectedCellStyle.Gray:
								BrushColor=Color.FromArgb(70,Color.Gray);
								brush=new SolidBrush(BrushColor);
								r=new RectangleF(r.Left+1,r.Top+1,r.Width,r.Height);
								gr.FillRectangle(brush,r);
								break;
						}
					}
					if(Focused)
					{
						switch(FocusedCellStyle)
						{
							case ReportLibrary.FocusedCellStyle.Rect:
								pen=new Pen(Color.Black,3.0f);
								gr.DrawRectangle(pen,r.Left,r.Top,Math.Abs((r.Right-3)-r.Left),Math.Abs(r.Bottom-r.Top-3));
								break;
						}
					}
				}
			}
		}

		protected void PaintGraphic(Image g,Graphics gr,RectangleF r)
		{
			int xx, yy;
			float x,y;
			Bitmap bitmap;

			bitmap=new Bitmap(g,new Size((int)(g.Width*Generic.ZoomFactor),(int)(g.Height*Generic.ZoomFactor)));
			if(AutoSize)
			{
				gr.DrawImage(bitmap,r);
			}
			else
			{
				if(Tile)
				{
					for(xx=0;xx<(int)(((r.Right-r.Left)/(bitmap.Width-1))+2);xx++)
					{
						for(yy=0;yy<(int)(((r.Bottom-r.Top)/(bitmap.Height-1))+2);yy++)
						{
							gr.DrawImage(bitmap,new RectangleF(new PointF(r.Left+xx*(bitmap.Width-1),r.Top+yy*(bitmap.Height-1)),new SizeF(bitmap.PhysicalDimension)));
						}
					}
				}
				else
				{
					switch(VAlign)
					{
						case VAlign.Top:
							y=r.Top;
							break;
						case VAlign.Center:
							y=r.Top+(r.Bottom-r.Top-bitmap.Height)/2;
							break;
						case VAlign.Bottom:
							y=r.Bottom-bitmap.Height;
							break;
						default:
							y=r.Top;
							break;
					}
					switch (HAlign)
					{
						case HAlign.Left:
							x=r.Left;
							break;
						case HAlign.Center:
							x=r.Left+(r.Right-r.Left-bitmap.Width)/2;
							break;
						case HAlign.Right:
							x=r.Right-bitmap.Width;
							break;
						default:
							x=r.Left;
							break;
					}
					
					gr.DrawImage(bitmap,new RectangleF(new PointF(x,y),new SizeF(bitmap.PhysicalDimension)));
				}
			}
		}

		public int GetFrameWidths(int index)
		{
			return FFrameWidths[index];
		}
		
		public void SetFrameWidths(int index,int AFrameWidth)
		{
			if(FFrameWidths[index]!=AFrameWidth)
			{
				BeginUpdate();
				FFrameWidths[index]=AFrameWidth;
				Changed=true;
				EndUpdate();
			}
		}

		public Color GetFrameColors(int index)
		{
			return FFrameColors[index];
		}
		
		public void SetFrameColors(int index,Color AFrameColor)
		{
			if(FFrameColors[index]!=AFrameColor)
			{
				BeginUpdate();
				FFrameColors[index]=AFrameColor;
				Changed=true;
				EndUpdate();
			}
		}

		public LineStyle GetBorderStyles(int index)
		{
			return FBorderStyles[index];
		}
		
		public void SetBorderStyles(int index,LineStyle ABorderStyle)
		{
			if(FBorderStyles[index]!=ABorderStyle)
			{
				BeginUpdate();
				FBorderStyles[index]=ABorderStyle;
				Changed=true;
				EndUpdate();
			}
		}

		public void PreparePrint()
		{
			TextPos=0;
		}

		public void EndUpdate()
		{
			InUpdateCnt--;
			Invalidate();
		}

		protected void Invalidate()
		{
			if((Changed)&&(!InUpdate()))
			{
				if(Change!=null)
					Change(this,EventArgs.Empty);
				Changed=false;
			}
		}

		protected bool InUpdate()
		{
			if(InUpdateCnt!=0)
				return true;
			else
				return false;
		}

		public void BeginUpdate()
		{
			InUpdateCnt++;
		}

		public float Height(Graphics gr,Font font)
		{
			float freturn;
			freturn=Generic.TextHeight(gr,Value,Width-FrameWidth*2,HAlign,VAlign,WordWrap,TextPos,font)+FrameWidth*2+2;
			return freturn;
		}

		public Bitmap ShapeToBitmap(RenderingMode Mode)
		{
			Bitmap freturn=new Bitmap((int)Width,(int)Owner.Height,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics gr=Graphics.FromImage(freturn);
			gr.Clear(Color.White);
			Shape shape=new Shape();
			shape.Size=new Size((int)Width,(int)Owner.Height);
			shape.Location=new Point(0,0);
			shape.BackGroundColor=Generic.FindColor(ShapeColor,Mode);
			shape.Gradient=ShapeGraident;
			if(ShapeGraident)
			{
				shape.GradientColor=Generic.FindColor(ShapeGraidentColor,Mode);
				shape.FillDirection=ShapeFillDirection;
			}
			shape.ShapeType=ShapeType;
			shape.BorderColor=Generic.FindColor(ShapeBorderColor,Mode);
			shape.BorderWidth=ShapeBorderWidth;
			shape.BorderStyle=ShapeBorderStyle;
			shape.Paint(gr);
			return freturn;
		}

		public Bitmap CellToBitmap(RenderingMode Mode)
		{
			Bitmap freturn=new Bitmap((int)Width,(int)Owner.Height,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics gr=Graphics.FromImage(freturn);
			gr.Clear(Color.White);
			Rectangle r=new Rectangle(new Point(0,0),freturn.Size);
			Rectangle rf=new Rectangle(r.Left+FrameWidth,r.Top+FrameWidth,Math.Abs((r.Right-FrameWidth)-(r.Left+FrameWidth)),Math.Abs((r.Bottom-FrameWidth)-(r.Top+FrameWidth)));
			Shape shape=new Shape();
			shape.Size=new Size((int)Width,(int)Owner.Height);
			shape.Location=new Point(0,0);
			shape.BackGroundColor=Generic.FindColor(ShapeColor,Mode);
			shape.Gradient=ShapeGraident;
			if(ShapeGraident)
			{
				shape.GradientColor=Generic.FindColor(ShapeGraidentColor,Mode);
				shape.FillDirection=ShapeFillDirection;
			}
			shape.ShapeType=ShapeType;
			shape.BorderColor=Generic.FindColor(ShapeBorderColor,Mode);
			shape.BorderWidth=ShapeBorderWidth;
			shape.BorderStyle=ShapeBorderStyle;
			shape.Paint(gr);
			Generic.DrawAngleText(gr,rf,Value,HAlign,VAlign,WordWrap,TextAngle,new Font(FontName,FontSize,FontStyle),new SolidBrush(FontColor),CellMargins);
			return freturn;
		}
		#endregion

		#region class events
		public event EventHandler Change;
		#endregion		
	}
	#endregion	

	#region Style
	public class Style
	{
		#region class variables
		StringList FTemplate;
		string FName;
		string FPictureFileName;
		bool FLinkToFile;
		bool FFitToCell;
		bool FTilesPicture;
		ShapeType FShapeType;
		Color FShapeColor;
		Color FShapeBorderColor;
		bool FShape;
		DashStyle FShapeBorderStyle;
		int FShapeBorderWidth;
		bool FShapeGraident;
		Color FShapeGraidentColor;
		FillDirection FShapeFillDirection;
		bool FWordWrap;
		int FTextAngle;
		string FFontName;
		float FFontSize;
		FontStyle FFontStyle;
		Color  FFontColor;
		HAlign FHAlign;
		VAlign FVAlign;
		LineStyle FLeftStyle;
		Color FLeftColor;
		int FLeftWidth;
		LineStyle FRightStyle;
		Color FRightColor;
		int FRightWidth;
		LineStyle FTopStyle;
		Color FTopColor;
		int FTopWidth;
		LineStyle FBottomStyle;
		Color FBottomColor;
		int FBottomWidth;
		#endregion

		#region constructor
		public Style()
		{
			FPictureFileName="";
			FLinkToFile=true;
			FFitToCell=false;
			FTilesPicture=false;
			FShapeColor=Color.Black;
			FShapeBorderColor=Color.Black;
			FShape=false;
			FShapeBorderStyle=DashStyle.Solid;
			FShapeBorderWidth=0;
			FShapeGraident=false;
			FShapeGraidentColor=Color.Black;
			FWordWrap=true;
			FTextAngle=0;
			FFontName="Arial";
			FFontSize=9.75F;
			FFontStyle=FontStyle.Regular;
			FFontColor=SystemColors.ControlText;
			FHAlign=HAlign.Center;
			FVAlign=VAlign.Center;
			FLeftStyle=LineStyle.Solid;
			FLeftColor=Color.Black;
			FLeftWidth=0;
			FRightStyle=LineStyle.Solid;
			FRightColor=Color.Black;
			FRightWidth=0;
			FTopStyle=LineStyle.Solid;
			FTopColor=Color.Black;
			FTopWidth=0;
			FBottomStyle=LineStyle.Solid;
			FBottomColor=Color.Black;
			FBottomWidth=0;
		}

		public Style(string name):this()
		{
			Name=name; 
		}
		#endregion

		#region class properties
		public StringList Template
		{
			get
			{
				StringList sl=new StringList("Style.GetTemplate sl");
				if(FTemplate==null)
				{
					FTemplate=new StringList("PageSize.FTemplate");
				}
				FTemplate.Clear();
				FTemplate.Add("  <STYLE>");
				FTemplate.Add(String.Format("   <NAME>{0}</NAME>",Name));
				if(PictureFileName!="")
					FTemplate.Add(string.Format("   <PICTUREFILENAME>{0}</PICTUREFILENAME>",PictureFileName));
				if(LinkToFile!=true)
					FTemplate.Add(string.Format("   <LINKTOFILE>{0:D}</LINKTOFILE>",Convert.ToInt32(LinkToFile)));				
				if(FitToCell!=false)
					FTemplate.Add(string.Format("   <FITTOCELL>{0:D}</FITTOCELL>",Convert.ToInt32(FitToCell)));
				if(TilesPicture!=false)
					FTemplate.Add(string.Format("   <TILESPICTURE>{0:D}</TILESPICTURE>",Convert.ToInt32(TilesPicture)));

				if(Shape!=false)
				{
					FTemplate.Add("   <SHAPE>");
					FTemplate.Add(string.Format("    <SHAPETYPE>{0:D}</SHAPETYPE>",Convert.ToInt32(ShapeType)));
					if(ShapeColor.ToArgb()!=Color.Black.ToArgb())
						FTemplate.Add(string.Format("    <SHAPECOLOR>{0:D}</SHAPECOLOR>",ShapeColor.ToArgb()));
					if(ShapeBorderWidth!=0)
						FTemplate.Add(string.Format("    <SHAPEBORDERWIDTH>{0:D}</SHAPEBORDERWIDTH>",ShapeBorderWidth));
					if(ShapeBorderStyle!=DashStyle.Solid)
						FTemplate.Add(string.Format("    <SHAPEBORDERSTYLE>{0:D}</SHAPEBORDERSTYLE>",Convert.ToInt32(ShapeBorderStyle)));
					if(ShapeBorderColor.ToArgb()!=Color.Black.ToArgb())
						FTemplate.Add(string.Format("    <SHAPEBORDERCOLOR>{0:D}</SHAPEBORDERCOLOR>",ShapeBorderColor.ToArgb()));
					if(ShapeGraident!=false)
					{
						FTemplate.Add("    <SHAPEGRAIDENT>");
						if(ShapeGraidentColor.ToArgb()!=Color.Black.ToArgb())
							FTemplate.Add(string.Format("     <SHAPEGRAIDENTCOLOR>{0:D}</SHAPEGRAIDENTCOLOR>",ShapeGraidentColor.ToArgb()));
						FTemplate.Add(string.Format("     <SHAPEFILLDIRECTION>{0:D}</SHAPEFILLDIRECTION>",Convert.ToInt32(ShapeFillDirection)));
						FTemplate.Add("    </SHAPEGRAIDENT>");
					}
					FTemplate.Add("   </SHAPE>");
				}

				if(WordWrap!=true)
					FTemplate.Add(string.Format("   <WORDWRAP>{0:D}</WORDWRAP>",Convert.ToInt32(WordWrap)));
				if(FontName!="Arial")
					FTemplate.Add(string.Format("   <FONTNAME>{0}</FONTNAME>",FontName));
				if(FontSize!=9.75F)
					FTemplate.Add(string.Format("   <FONTSIZE>{0:F2}</FONTSIZE>",FontSize));
				if(FontColor.ToArgb()!=SystemColors.ControlText.ToArgb())
					FTemplate.Add(string.Format("   <FONTCOLOR>{0:D}</FONTCOLOR>",FontColor.ToArgb()));
				if(TextAngle!=0)
					FTemplate.Add(string.Format("   <TEXTANGLE>{0:D}</TEXTANGLE>",TextAngle));
				if(FontStyle!=FontStyle.Regular)
					FTemplate.Add(string.Format("   <FONTSTYLE>{0:D}</FONTSTYLE>",(int)FontStyle));

				if(HAlign!=HAlign.Center)
					FTemplate.Add(string.Format("   <HALIGN>{0:D}</HALIGN>",(int)HAlign));
				if(VAlign!=VAlign.Center)
					FTemplate.Add(string.Format("   <VALIGN>{0:D}</VALIGN>",(int)VAlign));

				if(LeftStyle!=LineStyle.Solid)
					FTemplate.Add(String.Format("   <LEFTSTYLE>{0:D}</LEFTSTYLE>",(int)LeftStyle));
				if(LeftColor.ToArgb()!=Color.Black.ToArgb())
					FTemplate.Add(String.Format("   <LEFTCOLOR>{0:D}</LEFTCOLOR>",LeftColor.ToArgb()));
				if(LeftWidth!=0)
					FTemplate.Add(String.Format("   <LEFTWIDTH>{0:D}</LEFTWIDTH>",LeftWidth));

				if(RightStyle!=LineStyle.Solid)
					FTemplate.Add(String.Format("   <RIGHTSTYLE>{0:D}</RIGHTSTYLE>",(int)RightStyle));
				if(RightColor.ToArgb()!=Color.Black.ToArgb())
					FTemplate.Add(String.Format("   <RIGHTCOLOR>{0:D}</RIGHTCOLOR>",RightColor.ToArgb()));
				if(RightWidth!=0)
					FTemplate.Add(String.Format("   <RIGHTWIDTH>{0:D}</RIGHTWIDTH>",RightWidth));

				if(TopStyle!=LineStyle.Solid)
					FTemplate.Add(String.Format("   <TOPSTYLE>{0:D}</TOPSTYLE>",(int)TopStyle));
				if(TopColor.ToArgb()!=Color.Black.ToArgb())
					FTemplate.Add(String.Format("   <TOPCOLOR>{0:D}</TOPCOLOR>",TopColor.ToArgb()));
				if(TopWidth!=0)
					FTemplate.Add(String.Format("   <TOPWIDTH>{0:D}</TOPWIDTH>",TopWidth));

				if(BottomStyle!=LineStyle.Solid)
					FTemplate.Add(String.Format("   <BOTTOMSTYLE>{0:D}</BOTTOMSTYLE>",(int)BottomStyle));
				if(BottomColor.ToArgb()!=Color.Black.ToArgb())
					FTemplate.Add(String.Format("   <BOTTOMCOLOR>{0:D}</BOTTOMCOLOR>",BottomColor.ToArgb()));
				if(BottomWidth!=0)
					FTemplate.Add(String.Format("   <BOTTOMWIDTH>{0:D}</BOTTOMWIDTH>",BottomWidth));
				
				FTemplate.Add("  </STYLE>");
				return FTemplate;
			}
		}

		public string PictureFileName
		{
			get
			{
				return FPictureFileName;
			}
			set
			{
				FPictureFileName=value;
			}
		}

		public bool LinkToFile
		{
			get
			{
				return FLinkToFile;
			}
			set
			{
				FLinkToFile=value;
			}
		}

		public bool FitToCell
		{
			get
			{
				return FFitToCell;
			}
			set
			{
				FFitToCell=value;
			}
		}

		public bool TilesPicture
		{
			get
			{
				return FTilesPicture;
			}
			set
			{
				FTilesPicture=value;
			}
		}

		public ShapeType ShapeType
		{
			get
			{
				return FShapeType;
			}
			set
			{
				FShapeType=value;
			}
		}

		public Color ShapeColor
		{
			get
			{
				return FShapeColor;
			}
			set
			{
				FShapeColor=value;
			}
		}

		public Color ShapeBorderColor
		{
			get
			{
				return FShapeBorderColor;
			}
			set
			{
				FShapeBorderColor=value;
			}
		}

		public bool  Shape
		{
			get
			{
				return FShape;
			}
			set
			{
				FShape=value;
			}
		}

		public DashStyle ShapeBorderStyle
		{
			get
			{
				return FShapeBorderStyle;
			}
			set
			{
				FShapeBorderStyle=value;
			}
		}

		public int ShapeBorderWidth
		{
			get
			{
				return FShapeBorderWidth;
			}
			set
			{
				FShapeBorderWidth=value;
			}
		}

		public bool ShapeGraident
		{
			get
			{
				return FShapeGraident;
			}
			set
			{
				FShapeGraident=value;
			}
		}

		public Color ShapeGraidentColor
		{
			get
			{
				return FShapeGraidentColor;
			}
			set
			{
				FShapeGraidentColor=value;
			}
		}

		public FillDirection ShapeFillDirection
		{
			get
			{
				return FShapeFillDirection;
			}
			set
			{
				FShapeFillDirection=value;
			}
		}

		public bool WordWrap
		{
			get
			{
				return FWordWrap;
			}
			set
			{
				FWordWrap=value;
			}
		}

		public int TextAngle
		{
			get
			{
				return FTextAngle;
			}
			set
			{
				FTextAngle=value;
			}
		}

		public string FontName
		{
			get
			{
				return FFontName;
			}
			set
			{
				FFontName=value;
			}
		}

		public float FontSize
		{
			get
			{
				return FFontSize;
			}
			set
			{
				FFontSize=value;
			}
		}

		public FontStyle FontStyle
		{
			get
			{
				return FFontStyle;
			}
			set
			{
				FFontStyle=value;
			}
		}

		public Color FontColor
		{
			get
			{
				return FFontColor;
			}
			set
			{
				FFontColor=value;
			}
		}

		public HAlign HAlign
		{
			get
			{
				return FHAlign;
			}
			set
			{
				FHAlign=value;
			}
		}

		public VAlign VAlign
		{
			get
			{
				return FVAlign;
			}
			set
			{
				FVAlign=value;
			}
		}

		public LineStyle LeftStyle
		{
			get
			{
				return FLeftStyle;
			}
			set
			{
				FLeftStyle=value;
			}
		}

		public Color LeftColor
		{
			get
			{
				return FLeftColor;
			}
			set
			{
				FLeftColor=value;
			}
		}

		public int LeftWidth
		{
			get
			{
				return FLeftWidth;
			}
			set
			{
				FLeftWidth=value;
			}
		}

		public LineStyle RightStyle
		{
			get
			{
				return FRightStyle;
			}
			set
			{
				FRightStyle=value;
			}
		}

		public Color RightColor
		{
			get
			{
				return FRightColor;
			}
			set
			{
				FRightColor=value;
			}
		}

		public int RightWidth
		{
			get
			{
				return FRightWidth;
			}
			set
			{
				FRightWidth=value;
			}
		}

		public LineStyle TopStyle
		{
			get
			{
				return FTopStyle;
			}
			set
			{
				FTopStyle=value;
			}
		}

		public Color TopColor
		{
			get
			{
				return FTopColor;
			}
			set
			{
				FTopColor=value;
			}
		}

		public int TopWidth
		{
			get
			{
				return  FTopWidth;
			}
			set
			{
				FTopWidth=value;
			}
		}

		public LineStyle BottomStyle
		{
			get
			{
				return FBottomStyle;
			}
			set
			{
				FBottomStyle=value;
			}
		}

		public Color BottomColor
		{
			get
			{
				return FBottomColor;
			}
			set
			{
				FBottomColor=value;
			}
		}

		public int BottomWidth
		{
			get
			{
				return FBottomWidth;
			}
			set
			{
				FBottomWidth=value;
			}
		}

		public string Name
		{
			get
			{
				return FName;
			}
			set
			{
				FName=value;
			}
		}
		#endregion

		#region class methods
		public void ApplyStyle(XmlNode node)
		{
			XmlNodeReader reader;

			reader=new XmlNodeReader(node);
			while(reader.Read())
			{
				if(reader.Name=="NAME" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					Name=reader.Value;
				}
				else if(reader.Name=="FITTOCELL" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					FitToCell=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="TILESPICTURE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					TilesPicture=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="PICTUREFILENAME" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					PictureFileName=reader.Value;
				}
				else if(reader.Name=="LINKTOFILE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					LinkToFile=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="SHAPE" && reader.NodeType==XmlNodeType.Element)
				{
					Shape=true;
				}
				else if(reader.Name=="SHAPETYPE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeType=(ShapeType)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="SHAPECOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="SHAPEBORDERWIDTH" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeBorderWidth=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="SHAPEBORDERSTYLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeBorderStyle=(DashStyle)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="SHAPEBORDERCOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeBorderColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="SHAPEGRAIDENT" && reader.NodeType==XmlNodeType.Element)
				{
					ShapeGraident=true;
				}
				else if(reader.Name=="SHAPEGRAIDENTCOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeGraidentColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="SHAPEFILLDIRECTION" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					ShapeFillDirection=(FillDirection)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="FONTNAME" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					FontName=reader.Value;
				}
				else if(reader.Name=="FONTSIZE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					FontSize=Convert.ToSingle(reader.Value);
				}
				else if(reader.Name=="FONTCOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					FontColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="TEXTANGLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					TextAngle=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="FONTSTYLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					FontStyle=(FontStyle)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="WORDWRAP" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					WordWrap=Convert.ToBoolean(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="HALIGN" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					HAlign=(HAlign)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="VALIGN" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					VAlign=(VAlign)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="LEFTSTYLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					LeftStyle=(LineStyle)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="LEFTCOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					LeftColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="LEFTWIDTH" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					LeftWidth=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="RIGHTSTYLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					RightStyle=(LineStyle)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="RIGHTCOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					RightColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="RIGHTWIDTH" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					RightWidth=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="TOPSTYLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					TopStyle=(LineStyle)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="TOPCOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					TopColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="TOPWIDTH" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					TopWidth=Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="BOTTOMSTYLE" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					BottomStyle=(LineStyle)Convert.ToInt32(reader.Value);
				}
				else if(reader.Name=="BOTTOMCOLOR" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					BottomColor=Color.FromArgb(Convert.ToInt32(reader.Value));
				}
				else if(reader.Name=="BOTTOMWIDTH" && reader.NodeType==XmlNodeType.Element)
				{
					reader.Read();
					BottomWidth=Convert.ToInt32(reader.Value);
				}
			}
		}
		#endregion
	}
	#endregion

	#region CellMargins
	public class CellMargins
	{
		public int Top;
		public int Left;
		public int Bottom;
		public int Right;

		public CellMargins()
		{
			Top=0;
			Left=0;
			Bottom=0;
			Right=0;
		}
	}
	#endregion
}