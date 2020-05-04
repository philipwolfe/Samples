using System;
using System.ComponentModel;
using System.IO;
using Windows.Forms.Reports.ReportLibrary;
using System.Drawing;
using System.Collections; 
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Windows.Forms.Reports.Export
{
	#region PdfExport
	[ToolboxItem(true)]
	public class PdfExport:CustomExport
	{
		#region class variables
		private string FAuthor;
		private PdfDoc FDoc;
		private DateTime FCreationDate;
		private SDCanvas FCanvas;
		private string FCreator;
		private string FKeyWords;
		private DateTime FModDate;
		private SDPageMode FNonFullScreenPageMode;
		private SDPageLayout FPageLayout;
		private SDPageMode FPageMode;
		private string FSubject;
		private string FTitle;
		private bool FUseOutlines;
		private SDViewerPreference FViewerPreference;
		private SDOutlineRoot FOutlineRoot;
		int FPage;
		private SDDestination FOpenAction;
		ArrayList PageList;
		PageSettings pageset;	
		SDOutlineEntry[] FCurrentOutline;
		#endregion
		
		#region constructor
		public PdfExport()
		{
			PageList=new ArrayList();
			FileName="Default.Pdf";
			FCreationDate=DateTime.Now;
			FDoc=null;
			FCanvas=new SDCanvas();
			FViewerPreference=new SDViewerPreference();
		}
		#endregion

		#region class properties
		[Browsable(false)]
		public SDOutlineRoot OutlineRoot
		{
			get
			{
				if((FDoc==null)||(!FDoc.HasDoc)||(!FUseOutlines))
					throw(new EPdfInvalidOperation("GetOutlineRoot --invalid operation."));
				else
					return FOutlineRoot;
			}
		}

		[Browsable(false)]
		public int PageNumber
		{
			get
			{
				return FPage;
			}
		}

		public string Author
		{			
			get
			{
				return FAuthor;
			}
			set
			{
				if(FDoc!=null)
					throw(new EPdfInvalidOperation("SetAuthor --invalid operation."));
				FAuthor=value;
			}
		}
		
		public DateTime CreationDate
		{
			get
			{
				return FCreationDate;
			}
			set
			{
				if(FDoc!=null)
					throw(new EPdfInvalidOperation("SetCreationDate --invalid operation."));
				FCreationDate=value;
			}
		}

		public string Creator
		{
			get
			{
				return FCreator;
			}
			set
			{
				if(FDoc!=null)
					throw (new EPdfInvalidOperation("SetCreator --invalid operation."));
				FCreator=value;
			}
		}

		public string Keywords
		{
			get
			{
				return FKeyWords;
			}
			set
			{
				if(FDoc!=null)
					throw (new EPdfInvalidOperation("SetKeyWords --invalid operation."));
				FKeyWords=value;
			}
		}

		public DateTime ModDate
		{
			get
			{
				return FModDate;
			}
			set
			{
				if(FDoc!=null)
					throw (new EPdfInvalidOperation("SetModDate --invalid operation."));
				FModDate=value;
			}
		}

		[DefaultValue(SDPageMode.UseNone)]
		public SDPageMode NonFullScreenPageMode
		{
			get
			{
				return FNonFullScreenPageMode;
			}
			set
			{
				if(FDoc!=null)
					throw (new EPdfInvalidOperation("SetNonFullScreenPageMode --invalid operation."));
				if(value==SDPageMode.FullScreen)
					FNonFullScreenPageMode=SDPageMode.UseNone;
				else
					FNonFullScreenPageMode=value;
			}
		}
		
		[DefaultValue(SDPageLayout.SinglePage)]
		public SDPageLayout PageLayout
		{
			get
			{
				return FPageLayout;
			}
			set
			{
				if(FDoc!=null)
					throw (new EPdfInvalidOperation("SetPageLayout --invalid operation."));
				FPageLayout=value;
			}
		}
		
		[DefaultValue(SDPageMode.UseNone)]
		public SDPageMode PageMode
		{
			get
			{
				return FPageMode;
			}
			set
			{
				if(FDoc!=null)
					throw (new EPdfInvalidOperation("SetPageMode --invalid operation."));
				FPageMode=value;
			}
		}
		
		public string Subject
		{
			get
			{
				return FSubject;
			}
			set
			{
				if(FDoc!=null)
					throw (new EPdfInvalidOperation("SetSubject --invalid operation."));
				FSubject=value;
			}
		}

		public string Title
		{
			get
			{
				return FTitle;
			}
			set
			{
				if(FDoc!=null)
					throw (new EPdfInvalidOperation("SetTitle --invalid operation."));
				FTitle=value;
			}
		}

		[DefaultValue(false)]
		public bool UseOutlines
		{
			get
			{
				return FUseOutlines;
			}
			set
			{
				if(FDoc!=null)
					throw (new EPdfInvalidOperation("SetUseOutlines --invalid operation."));
				FUseOutlines=value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public SDViewerPreference ViewerPreference
		{
			get
			{
				return FViewerPreference ;
			}			
		}
		#endregion

		#region class methods
		public override void Execute()
		{
			if(FromPage==0)
				FromPage=1;
			if(ToPage==0)
				ToPage=UserRep.Pagecnt-1;
			base.Execute();
			FCurrentOutline=new SDOutlineEntry[7];
			if(Rep!=null)
			{
				pageset=new PageSettings();
				pageset.Margins.Bottom=Rep.BottomMargin;
				pageset.Margins.Left=Rep.LeftMargin;
				pageset.Margins.Right=Rep.RightMargin;
				pageset.Margins.Top=Rep.TopMargin;
				pageset.Landscape=Rep.orientation.ToString().IndexOf("Landscape")!=-1;
				pageset.PaperSize=Rep.PaperSize;
			
				UserRep.prn.DefaultPageSettings=pageset;
	
				CreatePDFDocument();
				BeginDoc();
				if(UseOutlines)
					FCurrentOutline[0]=OutlineRoot;
				UserRep.ProgressStart(PageList.Count);
				for(int i=0;i<PageList.Count;i++)
				{
					Print((SDPage)PageList[i]);
					UserRep.ProgressStep();
				}
				
				EndDoc();
				UserRep.ProgressStop();
				PageList.Clear();
			}
		}

		void CreatePDFDocument()
		{
			Rep CurrRep=null;
			a.rightmgn=0;
			
			a.CellRect=new Rectangle(LeftMargin,TopMargin,0,0);
			a.rLeft=LeftMargin;
			
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
						NewPage();	
	
					for(int idxband=firstband;idxband<lastband+1;idxband++)
					{
						if((page>=FromPage)&&(page<=ToPage))
							PrintBand(CurrRep.GetBand(idxband),CurrRep);
						UserRep.ProgressStep();
					}
					if((page>=FromPage)&&(page<=ToPage))
						EndPage(CurrRep);
				}				
			}
			UserRep.ProgressStop();
		}

		void EndPage(Rep CurrRep)
		{
			if((CurrRep.PageGraident)||(CurrRep.PagePicture!=null))
			{
				Bitmap bitmap=CurrRep.PageToBitmap();
				MemoryStream stream=new MemoryStream();
				bitmap.Save(stream,System.Drawing.Imaging.ImageFormat.Jpeg);
				bitmap=new Bitmap(stream);
				SDJPegImage PdfImage=new SDJPegImage();
				PdfImage.Picture=bitmap;
				if(Rep.RepList.Count>1)
					PdfImage.SharedImage=false;
				else
					PdfImage.SharedImage=true;
				PdfImage.Stretch=true;
				PdfImage.Dock=DockStyle.Fill;
				((SDLayoutPanel)((SDPage)PageList[PageList.Count-1]).Controls[0]).Controls.Add(PdfImage);
			}
			else
			{
				SDRect rect= new SDRect();
				rect.FillColor=CurrRep.PageColor;
				rect.LineStyle=PenStyle.Solid;
				rect.LineWidth=0;
				rect.LineColor=Color.Black;
				rect.Dock=DockStyle.Fill;
				((SDLayoutPanel)((SDPage)PageList[PageList.Count-1]).Controls[0]).Controls.Add(rect);
			}	
		}

		void PrintBand(Band band,Rep CurrRep)
		{
			a.CellRect=new Rectangle(a.CellRect.Left,a.CellRect.Top,Math.Abs(a.CellRect.Left-a.CellRect.Right),Math.Abs((a.CellRect.Top+(int)band.Height)-a.CellRect.Top));
			PrintClipBand(band,0,a.CellRect.Top,a.CellRect.Bottom,CurrRep);
		}

		void NewPage()
		{	
			a.rightmgn=0;
			a.rLeft=LeftMargin;
			a.CellRect=new Rectangle(a.CellRect.Left,BottomMargin,Math.Abs(a.CellRect.Left-a.CellRect.Right),Math.Abs(BottomMargin-a.CellRect.Bottom));
			NewPdfPage();				
			a.CellRect=new Rectangle(LeftMargin,TopMargin,0,0);
		}

		void NewPdfPage()
		{
			SDPage page=new SDPage();
			if(Rep.orientation==PrinterOrientation.Portrait)
				page.Size=new Size(pageset.PaperSize.Width,pageset.PaperSize.Height);
			else
				page.Size=new Size(pageset.PaperSize.Height,pageset.PaperSize.Width);
			SDLayoutPanel panel=new SDLayoutPanel();
			panel.BeforePrint+=new SDPrintPanelEvent(sdlayotupanel_BeforePrint);
			page.Controls.Add(panel);
			panel.Dock=DockStyle.Fill;
			PageList.Add(page);
		}

		private void sdlayotupanel_BeforePrint(object sender,SDPrintPanelEventArgs arg)
		{
			ArrayList FControlList;
			SDPanel FPanel=(SDPanel)sender;
			int tmpYPos;
			int ItemIndex;
			Control FControl;
			SDText FText;
			int FLevel;
			SDDestination FDestination;

			FControlList=new ArrayList();
			for(int i=0;i<FPanel.Controls.Count;i++)			
				if((FPanel.Controls[i] is SDText)&&(FPanel.Controls[i].Tag.ToString()!="0"))
				{
					tmpYPos=FPanel.Controls[i].Top;
					ItemIndex=-1;
					for(int j=0;j<FControlList.Count;j++)
					{
						FControl=(Control)FControlList[j];
						if(FControl.Top>tmpYPos)
						{
							ItemIndex=j;
							break;
						}
					}
					if(ItemIndex==-1)
						FControlList.Add(FPanel.Controls[i]);
					else
						FControlList.Insert(ItemIndex,FPanel.Controls[i]);
				}

			for(int i=0;i<FControlList.Count;i++)
			{
				FText=(SDText)FControlList[i];
				if(FText.Tag.ToString()!="0")
				{
					FLevel=Convert.ToInt32(FText.Tag.ToString());
					if(FCurrentOutline[FLevel-1]!=null)
					{
						FCurrentOutline[FLevel]=FCurrentOutline[FLevel-1].AddChild();
						FCurrentOutline[FLevel].Title=FText.NodeValue;
						FDestination=CreateDestination();
						FCurrentOutline[FLevel].Dest=FDestination;

						FDestination.DestinationType=PdfDestinationType.XYZ;
						FDestination.Top=FText.Top;
						FDestination.Left=FText.Left;
						FDestination.Zoom=0;
					}
				}
			}
		}

		void PrintClipBand(Band band,int PrintBandPos,int ClipTop,int ClipBottom,Rep CurrRep)
		{
			int idxcell,OldLeft;
			Rectangle r;
			Band bottomband;

			OldLeft=a.CellRect.Left;
			a.CellRect=new Rectangle(a.CellRect.Left,a.CellRect.Top-PrintBandPos,0,Math.Abs((a.CellRect.Top-PrintBandPos)-((a.CellRect.Top-PrintBandPos)+(int)band.Height)));
			for(idxcell=0;idxcell<band.CellCount;idxcell++)
			{
				a.CellRect=new Rectangle(a.CellRect.Left,a.CellRect.Top,Math.Abs((a.CellRect.Right+(int)band.GetCell(idxcell).Width)-a.CellRect.Left),Math.Abs(a.CellRect.Top-a.CellRect.Bottom));
				if(!(band.GetCell(idxcell).InUse))
				{
					bottomband=band.GetCell(idxcell).GetBottomBand();
					if(bottomband!=band)
					{
						r=new Rectangle(a.CellRect.Left,a.CellRect.Top,Math.Abs(a.CellRect.Left-a.CellRect.Right),Math.Abs(((int)CurrRep.GetTops(CurrRep.IndexOfBand(bottomband))-(int)CurrRep.GetTops(CurrRep.IndexOfBand(band)))+(int)bottomband.Height));
						if(idxcell==0)
							PaintCell(band.GetCell(idxcell),r,band.Node,true,band.NodeValue);
						else
							PaintCell(band.GetCell(idxcell),r,band.Node,false,band.NodeValue);
					}
					else
					{
						if(idxcell==0)
							PaintCell(band.GetCell(idxcell),a.CellRect,band.Node,true,band.NodeValue);	
						else
							PaintCell(band.GetCell(idxcell),a.CellRect,band.Node,false,band.NodeValue);	
					}
				}
				a.CellRect=new Rectangle(a.CellRect.Left+(int)band.GetCell(idxcell).Width,a.CellRect.Top,Math.Abs((a.CellRect.Left+(int)band.GetCell(idxcell).Width)-a.CellRect.Right),Math.Abs(a.CellRect.Top-a.CellRect.Bottom));
			}
			a.rightmgn=Math.Max(a.rightmgn,a.CellRect.Right);
			a.CellRect=new Rectangle(OldLeft,a.CellRect.Bottom,Math.Abs(OldLeft-a.CellRect.Right),0);
		}

		void PaintCell(Cell cell,Rectangle r,int Tag,bool firstcell,string NodeValue)
		{
			Rectangle rf;

			if(r.Right<=0)
				return;
			else
			{
				rf=new Rectangle(r.Left+cell.FrameWidth,r.Top+cell.FrameWidth,Math.Abs((r.Right-cell.FrameWidth)-(r.Left+cell.FrameWidth)),Math.Abs((r.Bottom-cell.FrameWidth)-(r.Top+cell.FrameWidth)));
				if(cell.Picture!=null)
				{
					Bitmap cellpicture=(Bitmap)cell.RenderingImage;
					MemoryStream stream=new MemoryStream();
					cellpicture.Save(stream,System.Drawing.Imaging.ImageFormat.Jpeg);
					cellpicture=new Bitmap(stream);
					PaintGraphic(cellpicture,rf,cell);
				}

				System.Drawing.Font font=new Font("Arial",cell.FontSize,cell.FontStyle);

				DrawRectText(rf,cell.Value,cell.HAlign,cell.VAlign,cell.WordWrap,ReportLibrary.Generic.FindColor(cell.FontColor,RenderingMode),font,Tag,firstcell,NodeValue,cell.CellMargins);				

				PaintFrames(r,cell);

				if(cell.Shape)
				{
					Bitmap bitmap=cell.ShapeToBitmap(RenderingMode);
					MemoryStream stream=new MemoryStream();
					bitmap.Save(stream,System.Drawing.Imaging.ImageFormat.Jpeg);
					bitmap=new Bitmap(stream);
					SDJPegImage PdfImage=new SDJPegImage();
					PdfImage.Picture=bitmap;
					PdfImage.SharedImage=false;
					PdfImage.Stretch=true;
					PdfImage.Location=new Point(r.Left,r.Top);
					PdfImage.Size=new Size(r.Width,r.Height);
					((SDLayoutPanel)((SDPage)PageList[PageList.Count-1]).Controls[0]).Controls.Add(PdfImage);
				}
			}
		}

		void PaintFrames(Rectangle r,Cell cell)
		{
			if(cell.GetFrameWidths(0)>0)
				ShowBorder(0,cell.GetFrameWidths(1),cell.GetFrameWidths(3),r,cell);
			if(cell.GetFrameWidths(1)>0)
				ShowBorder(1,cell.GetFrameWidths(1),cell.GetFrameWidths(3),r,cell);
			if(cell.GetFrameWidths(2)>0)
				ShowBorder(2,cell.GetFrameWidths(0),cell.GetFrameWidths(2),r,cell);
			if(cell.GetFrameWidths(3)>0)
				ShowBorder(3,cell.GetFrameWidths(0),cell.GetFrameWidths(2),r,cell);
		}

		void ShowBorder(int fs,int WidthLeftTop,int WidthRightBottom,Rectangle r,Cell cell)
		{
			Rectangle Rect=new Rectangle(r.Left,r.Top,Math.Abs((r.Right-1)-r.Left),Math.Abs((r.Bottom-1)-r.Top));
			DrawBorder(Rect,cell.GetBorderStyles(fs),fs,ReportLibrary.Generic.FindColor(cell.GetFrameColors(fs),RenderingMode),cell.GetFrameWidths(fs),WidthLeftTop,WidthRightBottom);
		}

		void DrawBorder(Rectangle r,LineStyle ls,int fs,Color color,int Width,int WidthLefTop,int WidthRightBottom)
		{
			SDRect rect=new SDRect();
			rect.DrawLine=false;
			rect.LineColor=Color.Transparent;
			rect.FillColor=color;
			rect.LineStyle=PenStyle.Solid;

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

			switch(ls)
			{
				case LineStyle.Solid:
				{
					switch(fs)
					{
						case 0:
							rect.Location=new Point(r.Left,r.Top);
							rect.Size=new Size(Width,Math.Abs((r.Bottom+1)-r.Top));
							break;
						case 2:
							rect.Location=new Point(r.Right+1-Width,r.Top);
							rect.Size=new Size(Width,Math.Abs((r.Bottom+1)-r.Top));
							break;
						case 1:
							rect.Location=new Point(r.Left,r.Top);
							rect.Size=new Size(Math.Abs((r.Right+1)-r.Left),Width);
							break;
						case 3:
							rect.Location=new Point(r.Left,r.Bottom+1-Width);
							rect.Size=new Size(Math.Abs((r.Right+1)-r.Left),Width);
							break;
					}					
				}
					((SDLayoutPanel)((SDPage)PageList[PageList.Count-1]).Controls[0]).Controls.Add(rect);
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
							VerLine(color,r.Left,r.Top,r.Bottom,ls);
							break;
						case 2:
							VerLine(color,r.Right,r.Top,r.Bottom,ls);
							break;
						case 1:
							HorLine(color,r.Left,r.Right,r.Top,ls);
							break;
						case 3:
							HorLine(color,r.Left,r.Right,r.Bottom,ls);
							break;
					}
				}
					break;
				case LineStyle.Double11:
				{
					switch(fs)
					{
						case 0:
							VerLine(color,r.Left,r.Top,r.Bottom,ls);
							VerLine(color,r.Left+2,r.Top+wlt1,r.Bottom-wrb1,ls);
							break;
						case 2:
							VerLine(color,r.Right,r.Top,r.Bottom,ls);
							VerLine(color,r.Right-2,r.Top+wlt1,r.Bottom-wrb1,ls);
							break;
						case 1:
							HorLine(color,r.Left,r.Right,r.Top,ls);
							HorLine(color,r.Left+wlt1,r.Right-wrb1,r.Top+2,ls);
							break;
						case 3:
							HorLine(color,r.Left,r.Right,r.Bottom,ls);
							HorLine(color,r.Left+wlt1,r.Right-wrb1,r.Bottom-2,ls);
							break;
					}
				}
					break;
				case LineStyle.Double21:
				{
					switch(fs)
					{
						case 0:
							VerLine(color,r.Left,r.Top,r.Bottom,ls);
							VerLine(color,r.Left+1,r.Top,r.Bottom,ls);
							VerLine(color,r.Left+3,r.Top+wlt1,r.Bottom-wrb1,ls);
							break;
						case 2:
							VerLine(color,r.Right,r.Top,r.Bottom,ls);
							VerLine(color,r.Right-1,r.Top,r.Bottom,ls);
							VerLine(color,r.Right-3,r.Top+wlt1,r.Bottom-wrb1,ls);
							break;
						case 1:
							HorLine(color,r.Left,r.Right,r.Top,ls);
							HorLine(color,r.Left,r.Right,r.Top+1,ls);
							HorLine(color,r.Left+wlt1,r.Right-wrb1,r.Top+3,ls);
							break;
						case 3:
							HorLine(color,r.Left,r.Right,r.Bottom,ls);
							HorLine(color,r.Left,r.Right,r.Bottom-1,ls);
							HorLine(color,r.Left+wlt1,r.Right-wrb1,r.Bottom-3,ls);
							break;
					}
				}
					break;
				case LineStyle.Double12:
				{
					switch(fs)
					{						
						case 0:
							VerLine(color,r.Left,r.Top,r.Bottom,ls);
							VerLine(color,r.Left+2,r.Top+wlt2,r.Bottom-wrb2,ls);
							VerLine(color,r.Left+3,r.Top+wlt1,r.Bottom-wrb1,ls);
							break;
						case 2:
							VerLine(color,r.Right,r.Top,r.Bottom,ls);
							VerLine(color,r.Right-2,r.Top+wlt2,r.Bottom-wrb2,ls);
							VerLine(color,r.Right-3,r.Top+wlt1,r.Bottom-wrb1,ls);
							break;
						case 1:
							HorLine(color,r.Left,r.Right,r.Top,ls);
							HorLine(color,r.Left+wlt2,r.Right-wrb2,r.Top+2,ls);
							HorLine(color,r.Left+wlt1,r.Right-wrb1,r.Top+3,ls);
							break;
						case 3:
							HorLine(color,r.Left,r.Right,r.Bottom,ls);
							HorLine(color,r.Left+wlt2,r.Right-wrb2,r.Bottom-2,ls);
							HorLine(color,r.Left+wlt1,r.Right-wrb1,r.Bottom-3,ls);
							break;
					}
				}
					break;
			}
		}

		void VerLine(Color color,int x,int y1,int y2,LineStyle ls)
		{
			int n, cnt, y, yend;
			n=0;cnt=0;y=y1;
			while(y<y2)
			{
				yend=Math.Min(y+ReportLibrary.Generic.CellBorderDots[(int)ls,n],y2+1);
				SDRect rect=new SDRect();
				rect.LineStyle=PenStyle.Solid;
				rect.DrawLine=false;
				rect.LineColor=Color.Transparent;
				rect.FillColor=color;
				rect.Location=new Point(x,y);
				rect.Size=new Size(1,Math.Abs(yend-y));
				((SDLayoutPanel)((SDPage)PageList[PageList.Count-1]).Controls[0]).Controls.Add(rect);
				cnt=cnt+ReportLibrary.Generic.CellBorderDots[(int)ls,n]+ReportLibrary.Generic.CellBorderDots[(int)ls,n+1];
				y=y+ReportLibrary.Generic.CellBorderDots[(int)ls,n]+ReportLibrary.Generic.CellBorderDots[(int)ls,n+1];
				n=n+2;
				if(cnt>=24)
				{
					n=0;
					cnt=0;
				}
			}
		}

		void HorLine(Color color,int x1,int x2,int y,LineStyle ls)
		{
			int n, cnt, x, xend;
			n=0;cnt=0;x=x1;
			while(x<x2)
			{
				xend=Math.Min(x+ReportLibrary.Generic.CellBorderDots[(int)ls,n],x2+1);
				SDRect rect=new SDRect();
				rect.LineStyle=PenStyle.Solid;
				rect.DrawLine=false;
				rect.LineColor=Color.Transparent;
				rect.FillColor=color;
				rect.Location=new Point(x,y);
				rect.Size=new Size(Math.Abs(xend-x),1);
				((SDLayoutPanel)((SDPage)PageList[PageList.Count-1]).Controls[0]).Controls.Add(rect);
				cnt=cnt+ReportLibrary.Generic.CellBorderDots[(int)ls,n]+ReportLibrary.Generic.CellBorderDots[(int)ls,n+1];
				x=x+ReportLibrary.Generic.CellBorderDots[(int)ls,n]+ReportLibrary.Generic.CellBorderDots[(int)ls,n+1];
				n=n+2;
				if(cnt>=24)
				{
					n=0;
					cnt=0;
				}
			}
		}

		void DrawRectText(Rectangle r,string text,HAlign HA,VAlign VA,bool WordWrap,Color fontcolor,Font font,int Tag,bool firstcell,string NodeValue,CellMargins margins)
		{
			int X=0,Y=0;
			r=new Rectangle(r.X+margins.Left,r.Y+margins.Top,r.Width-(margins.Left+margins.Right),r.Height-(margins.Top+margins.Bottom));
			StringFormat sf=new StringFormat();
			if(!WordWrap)
			{
				sf.FormatFlags=StringFormatFlags.NoWrap;
			}
			Graphics gr=UserRep.CreateGraphics();
			SizeF size=gr.MeasureString(text,font,r.Width,sf);
			gr.Dispose();

			SDText pdftext=new SDText();
			if((Tag>=1)&&(firstcell))
			{
				pdftext.Tag=Tag;
				pdftext.NodeValue=NodeValue;
			}
			else
				pdftext.Tag=0;
			pdftext.WordWrap=WordWrap;
			pdftext.FontBold=font.Style.ToString().IndexOf("Bold")!=-1;
			pdftext.FontItalic=font.Style.ToString().IndexOf("Italic")!=-1;
			pdftext.FontName=SdFontName.Arial;
			pdftext.FontSize=font.Size;
			pdftext.Lines[0]=text;
			pdftext.FontColor=fontcolor;

			switch(HA)
			{
				case HAlign.Center:
					X=r.Location.X +(int)((r.Width-size.Width)/2);
					break;
				case HAlign.Left:
					X=r.Location.X;
					break;
				case HAlign.Right:
					X=r.Location.X+(int)(r.Width-size.Width);
					break;
			}
			switch (VA)
			{
				case VAlign.Bottom:
					Y=r.Location.Y+(int)(r.Height-size.Height);
					break;
				case VAlign.Center:
					Y=r.Location.Y+(int)((r.Height-size.Height)/2);
					break;
				case VAlign.Top:
					Y=r.Location.Y;
					break;
			}
			pdftext.Location=new Point(X,Y);
			pdftext.Size=Size.Round(new SizeF(size));
			((SDLayoutPanel)((SDPage)PageList[PageList.Count-1]).Controls[0]).Controls.Add(pdftext);
		}

		void PaintGraphic(Bitmap g,Rectangle r,Cell cell)
		{
			int xx, yy;
			int x,y;
			SDJPegImage PdfImage=new SDJPegImage();
			if(cell.AutoSize)
			{
				PdfImage.Picture=g;
				PdfImage.SharedImage=false;
				PdfImage.Stretch=true;
				PdfImage.Location=new Point(r.Left,r.Top);
				PdfImage.Size=new Size(r.Width,r.Height);
				((SDLayoutPanel)((SDPage)PageList[PageList.Count-1]).Controls[0]).Controls.Add(PdfImage);
			}
			else
			{
				if(cell.Tile)
				{
					for(xx=0;xx<(int)(((r.Right-r.Left)/(g.Width-1))+2);xx++)
					{
						for(yy=0;yy<(int)(((r.Bottom-r.Top)/(g.Height-1))+2);yy++)
						{
							PdfImage.Picture=g;
							PdfImage.SharedImage=false;
							PdfImage.Stretch=false;
							PdfImage.Location=new Point(r.Left+xx*(g.Width-1),r.Top+yy*(g.Height-1));
							PdfImage.Size=Size.Round(new SizeF(g.PhysicalDimension));
							((SDLayoutPanel)((SDPage)PageList[PageList.Count-1]).Controls[0]).Controls.Add(PdfImage);
						}
					}
				}
				else
				{
					switch(cell.VAlign)
					{
						case VAlign.Top:
							y=r.Top;
							break;
						case VAlign.Center:
							y=r.Top+(r.Bottom-r.Top-g.Height)/2;
							break;
						case VAlign.Bottom:
							y=r.Bottom-g.Height;
							break;
						default:
							y=r.Top;
							break;
					}
					switch (cell.HAlign)
					{
						case HAlign.Left:
							x=r.Left;
							break;
						case HAlign.Center:
							x=r.Left+(r.Right-r.Left-g.Width)/2;
							break;
						case HAlign.Right:
							x=r.Right-g.Width;
							break;
						default:
							x=r.Left;
							break;
					}
					PdfImage.Picture=g;
					PdfImage.SharedImage=false;
					PdfImage.Stretch=false;
					PdfImage.Location=new Point(x,y);
					PdfImage.Size=Size.Round(new SizeF(g.PhysicalDimension));
					((SDLayoutPanel)((SDPage)PageList[PageList.Count-1]).Controls[0]).Controls.Add(PdfImage);
				}
			}
		}

		public void Abort()
		{
			if(FDoc!=null)
				FDoc=null;
			FOutlineRoot=null;

		}

		public void BeginDoc()
		{
			if(FDoc!=null)
				Abort();
			FDoc=new PdfDoc();

			FDoc.UseOutlines=this.UseOutlines;
			FDoc.NewDoc();
			if(FDoc.UseOutlines)
				FOutlineRoot=new SDOutlineRoot(FDoc);
			FDoc.Root.PageMode=PageMode;
			FDoc.Root.PageLayout=PageLayout;
			if(NonFullScreenPageMode!=SDPageMode.UseNone)
				FDoc.Root.NonFullScreenPageMode=NonFullScreenPageMode;
			FDoc.Root.ViewerPreference=ViewerPreference;
			FDoc.Info.Author=Author;
			FDoc.Info.CreationDate=CreationDate;
			FDoc.Info.Creator=Creator;
			FDoc.Info.Keywords=Keywords;
			FDoc.Info.ModDate=ModDate;
			FDoc.Info.Subject=Subject;
			FDoc.Info.Title=Title;
			FPage=0;
		}

		public void Print(SDPage APage)
		{	
			FDoc.AddPage();
			FPage++;
			FCanvas.PdfCanvas=FDoc.Canvas;
			APage.Print(FCanvas);
		}

		public void EndDoc()
		{
			MemoryStream FStream;
			if(FDoc!=null)
			{
				FileStream st=new FileStream(FileName,FileMode.Create);
				FStream=new MemoryStream();
				FDoc.SaveToStream(FStream);
				FStream.WriteTo(st);
				FStream.Close();
				st.Close();
			}
		}

		public SDDestination CreateDestination()
		{
			SDDestination FDestination;

			if((FDoc==null)||(!FDoc.HasDoc))
				throw(new EPdfInvalidOperation("CreateDestination --invalid operation."));
			else
			{
				FDestination=new SDDestination(FDoc.CreateDestination());
				FDestination.Top=-10;
				FDestination.Zoom=1;
				return FDestination;
			}
		}

		public PdfDoc GetPdfDoc()
		{
			return FDoc;
		}

		public void OpenAction(SDDestination Value)
		{
			if((FDoc==null)&&(FDoc.HasDoc))				
				throw (new EPdfInvalidOperation("GetOpenAction --invalid operation."));
			else
			{
				FDoc.Root.OpenAction=Value.FData;
				FOpenAction=Value;	
			}
		}

		public SDDestination GetOpenAction()
		{
			if((FDoc==null)&&(FDoc.HasDoc))				
				throw (new EPdfInvalidOperation("GetOpenAction --invalid operation."));
			else
				return FOpenAction;
		}
		#endregion	
	}
	#endregion

	#region a
	class a
	{
		public static int rightmgn;
		public static int rLeft;
		public static Rectangle CellRect;
	}
	#endregion
}
