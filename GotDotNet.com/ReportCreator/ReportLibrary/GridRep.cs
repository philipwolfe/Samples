using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Xml;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region GridRep
	[ToolboxItem(false)]
	public class GridRep:Control
	{
		#region class variables
		public Rep FSrcRep;
		int FCurrBandIdx;
		int FCurrCellIdx;
		int FLeftX;
		int FTopY;
		public List SelList;
		int FGutter;
		protected bool FInEditing;
		Units FUnits;
		int FFixedBands;
		int FFixedCells;
		double FGridX;
		double FGridY;
		bool FShowMargins;
		protected bool FShowBandTitle;
		SelectedCellStyle FSelectedCellStyle;
		FocusedCellStyle FFocusedCellStyle;
		RepOptions FOptions;
		bool FScrollUpdate;
		public PrintDocument prn;
		PageSettings pageset;
		PrinterSettings printset;
		public bool sender;
		Zoom FZoom;
		object FOwner;
		public int UserLeft;
		public int UserTop;
		Size Old;

		public static PaperSize OldSize;
		public static PrinterOrientation OldOrientation;
		#endregion

		#region class events
		public event DrawBandTitleEventHandler DrawBandTitle;
		public event EventHandler HScroll;
		public event EventHandler VScroll;
		public event SelectCellEventHandler GridSelectCell;
		#endregion

		#region class properties
		public Zoom Zoom
		{
			get
			{
				return FZoom;
			}
			set
			{
				TopY=0;
				LeftX=0;
				switch(FZoom)
				{
					case Zoom.hundred:
						Generic.OldZoomFactor=1.0F;
						break;
					case Zoom.fifty:
						Generic.OldZoomFactor=0.50F;
						break;
					case Zoom.seventyfive:
						Generic.OldZoomFactor=0.75F;
						break;
					case Zoom.hundredfifty:
						Generic.OldZoomFactor=1.50F;
						break;
					case Zoom.twohundred:
						Generic.OldZoomFactor=2.0F;
						break;
					case Zoom.wholepage:						
						if(SrcRep.PageSize.PaperSize.Width>=SrcRep.PageSize.PaperSize.Height)
							Generic.OldZoomFactor=(float)(Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Width;
						else
							Generic.OldZoomFactor=((float)Height-50.0F)/(float)SrcRep.PageSize.PaperSize.Height;
						break;
					case Zoom.pagewidth:
						if(SrcRep.Orientation==PrinterOrientation.Portrait)
							Generic.OldZoomFactor=(float)(Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Width;
						else
							Generic.OldZoomFactor=(float)(Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Height;
						break;
				}
				switch(value)
				{
					case Zoom.hundred:
						Generic.ZoomFactor=1.0F;
						break;
					case Zoom.fifty:
						Generic.ZoomFactor=0.50F;
						break;
					case Zoom.seventyfive:
						Generic.ZoomFactor=0.75F;
						break;
					case Zoom.hundredfifty:
						Generic.ZoomFactor=1.50F;
						break;
					case Zoom.twohundred:
						Generic.ZoomFactor=2.0F;
						break;
					case Zoom.wholepage:						
						if(SrcRep.PageSize.PaperSize.Width>=SrcRep.PageSize.PaperSize.Height)
							Generic.ZoomFactor=(float)(Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Width;
						else
							Generic.ZoomFactor=((float)Height-50.0F)/(float)SrcRep.PageSize.PaperSize.Height;
						break;
					case Zoom.pagewidth:
						if(SrcRep.Orientation==PrinterOrientation.Portrait)
							Generic.ZoomFactor=(float)(Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Width;
						else
							Generic.ZoomFactor=(float)(Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Height;
						break;
				}
				FZoom=value;
				ArrangeSize();
			}
		}

		void ArrangeSize()
		{
			if(SrcRep.Orientation==PrinterOrientation.Portrait)
			{
				SrcRep.OldGridHeight=(int)(SrcRep.PageSize.PaperSize.Height*Generic.OldZoomFactor);
				SrcRep.OldGridWidth=(int)(SrcRep.PageSize.PaperSize.Width*Generic.OldZoomFactor);					
				SrcRep.NewWidth=(int)(SrcRep.PageSize.PaperSize.Width*Generic.ZoomFactor);
				SrcRep.NewHeight=(int)(SrcRep.PageSize.PaperSize.Height*Generic.ZoomFactor);
			}
			else
			{
				SrcRep.OldGridHeight=(int)(SrcRep.PageSize.PaperSize.Width*Generic.OldZoomFactor);	
				SrcRep.OldGridWidth=(int)(SrcRep.PageSize.PaperSize.Height*Generic.OldZoomFactor);
				SrcRep.NewWidth=(int)(SrcRep.PageSize.PaperSize.Height*Generic.ZoomFactor);
				SrcRep.NewHeight=(int)(SrcRep.PageSize.PaperSize.Width*Generic.ZoomFactor);
			}
			SrcRep.OldLeftMargin=SrcRep.LeftMargin;
			SrcRep.OldRightMargin=SrcRep.RightMargin;				
			SrcRep.OldTopMargin=SrcRep.TopMargin;
			SrcRep.OldBottomMargin=SrcRep.BottomMargin;				
				
			SrcRep.FLeftMargin=((SrcRep.LeftMargin/Generic.OldZoomFactor)*Generic.ZoomFactor);
			SrcRep.FRightMargin=((SrcRep.RightMargin/Generic.OldZoomFactor)*Generic.ZoomFactor);
			SrcRep.FTopMargin=((SrcRep.TopMargin/Generic.OldZoomFactor)*Generic.ZoomFactor);
			SrcRep.FBottomMargin=((SrcRep.BottomMargin/Generic.OldZoomFactor)*Generic.ZoomFactor);
			SrcRep.CellArrangement();
		}

		public VirtualFileSystem FileSystem
		{
			get
			{
				if(SrcRep!=null)
					return SrcRep.FileSystem;
				else
					return null;
			}
			set
			{
				if(SrcRep!=null)
					SrcRep.FileSystem=value;
			}
		}

		protected override CreateParams CreateParams 
		{
			get 
			{
				CreateParams cp=base.CreateParams;
				cp.Style|=0x00200000|0x00100000|0x00010000;
				cp.ExStyle|=0x00000200;
				return cp;
			}
		}

		[Browsable(false)]
		public object Owner
		{
			get
			{
				return FOwner;
			}
			set
			{
				FOwner=value;
			}
		}

		[Browsable(false)]
		public Rep SrcRep
		{
			get
			{
				return FSrcRep;
			}
			set
			{
				FSrcRep=value;
			}
		}

		[Browsable(false)]
		public virtual StringList Template
		{
			get
			{
				return SrcRep.Template;
			}
			set
			{
				XmlNode node;
				StringReader reader=new StringReader(value.GetText());
				XmlDocument doc=new XmlDocument();
				doc.Load(reader);
				node=doc.SelectSingleNode("REP");
				SrcRep.ApplyRep(node,null);
				Invalidate();
			}
		}

		[Browsable(false)]
		public Cell CurrCell
		{
			get
			{
				Band cb;
				cb=CurrBand;
				if((cb!=null)&&(cb.CellCount>0))
				{
					FCurrCellIdx=Math.Max(0,Math.Min(cb.CellCount-1,FCurrCellIdx));
					return cb.GetCell(FCurrCellIdx);
				}
				else
					return null;
			}
		}

		[Browsable(false)]
		public Band CurrBand
		{
			get
			{
				if((SrcRep==null)|(SrcRep==null))
				{
					return null;
				}
				else
				{
					FCurrBandIdx=Math.Max(0,Math.Min(SrcRep.BandCount-1,FCurrBandIdx));
					return SrcRep.GetBand(CurrBandIdx);
				}
			}
		}

		[Browsable(false)]
		public int CurrBandIdx
		{
			get
			{
				return Math.Max(-1,Math.Min(FCurrBandIdx,SrcRep.BandCount-1));
			}
			set
			{
				int tmpidx;
				
				tmpidx=Math.Max(0,Math.Min(value,SrcRep.BandCount-1));
				if(FCurrBandIdx!=tmpidx)
				{
					if(CurrCell!=null)
						CurrCell.Focused=false;
					FCurrBandIdx=tmpidx;
					CurrCellIdx=CurrCellIdx;
					TopY=TopY;
					if(CurrCell!=null)
						CurrCell.Focused=true;
				}
			}
		}

		
		[Browsable(false)]
		public int CurrCellIdx
		{
			get
			{
				if(CurrBand!=null)
					return Math.Max(0,Math.Min(FCurrCellIdx,CurrBand.CellCount-1));
				else
					return -1;
			}
			set
			{
				int tmpidx;
				if(CurrBand!=null)
				{
					tmpidx=Math.Max(0,Math.Min(value,CurrBand.CellCount-1));
					if(FCurrCellIdx!=tmpidx)
					{
						if(CurrCell!=null)
							CurrCell.Focused=false;
						FCurrCellIdx=Math.Max(0,Math.Min(value,CurrBand.CellCount-1));
						LeftX=LeftX;
						if(CurrCell!=null)
							CurrCell.Focused=true;
					}
				}
			}
		}

		[Browsable(false)]
		public int LeftX
		{
			get
			{
				return FLeftX;
			}
			set
			{
				int x;
				x=Math.Max(Math.Min(Math.Max(value,0),HSMax-HSPage),0);
				if(FLeftX!=x)
				{
					FLeftX=x;
					Invalidate();
					HSPos=FLeftX;
				}
			}
		}

		protected int HSMax
		{
			get
			{
				tagScrollInfo si=new tagScrollInfo();
				si.cbSize=(int)Marshal.SizeOf(si);
				si.fMask=23;
				si.nMax=0;
				IntPtr hwnd=Handle;
				if((int)hwnd!=0)
					Generic.GetScrollInfo(hwnd,0,si);
				return si.nMax;
			}
			set
			{
				tagScrollInfo si=new tagScrollInfo();
				si.cbSize=(int)Marshal.SizeOf(si);
				si.fMask=1;
				si.nMin=0;
				si.nMax=value;
				IntPtr hwnd=Handle;
				if((int)hwnd!=0)
				{
					Generic.CheckScrollInfo(si);				
					Generic.SetScrollInfo(hwnd,0,si,true);
				}
			}
		}

		protected int HSPage
		{
			get
			{
				tagScrollInfo si=new tagScrollInfo();
				si.cbSize=(int)Marshal.SizeOf(si);
				si.fMask=23;
				si.nPage=0;
				IntPtr hwnd=Handle;
				if((int)hwnd!=0)
					Generic.GetScrollInfo(hwnd,0,si);
				return (int)si.nPage;
			}
			set
			{
				tagScrollInfo si=new tagScrollInfo();
				si.cbSize=(int)Marshal.SizeOf(si);
				si.fMask=2;
				si.nPage=(int)Math.Max(0,value);
				IntPtr hwnd=Handle;
				if((int)hwnd!=0)
				{
					Generic.CheckScrollInfo(si);				
					Generic.SetScrollInfo(hwnd,0,si,true);
				}
			}
		}

		protected int HSPos
		{
			get
			{
				tagScrollInfo si=new tagScrollInfo();
				si.cbSize=(int)Marshal.SizeOf(si);
				si.fMask=23;
				si.nPos=0;
				IntPtr hwnd=Handle;
				if((int)hwnd!=0)
					Generic.GetScrollInfo(hwnd,0,si);
				return si.nPos;
			}
			set
			{
				tagScrollInfo si=new tagScrollInfo();
				si.cbSize=(int)Marshal.SizeOf(si);
				si.fMask=4;
				si.nPos=value;
				IntPtr hwnd=Handle;
				if((int)hwnd!=0)
				{
					Generic.CheckScrollInfo(si);				
					Generic.SetScrollInfo(hwnd,0,si,true);
				}
			}
		}

		[Browsable(false)]
		public int TopY
		{
			get
			{
				return FTopY;
			}
			set
			{
				int y,dy;
				RectangleF r;

				y=Math.Max(0,Math.Min(value,VSMax-VSPage));
				if(FTopY!=y)
				{
					dy=FTopY-y;
					FTopY=y;
					if(Math.Abs(dy)<(Height-SrcRep.GetTops(FixedBands)))
					{
						r=new RectangleF(0,SrcRep.GetTops(FixedBands),Width,Height);
						IntPtr hwnd=Handle;
						if((int)hwnd!=0)
							Generic.ScrollWindow(hwnd,0,dy,r,r);
					}
					Invalidate();
					VSPos=FTopY;
				}
			}
		}

		protected int VSMax
		{
			get
			{
				tagScrollInfo si=new tagScrollInfo();
				si.cbSize=(int)Marshal.SizeOf(si);
				si.fMask=23;
				si.nMax=0;
				IntPtr hwnd=Handle;
				if((int)hwnd!=0)
					Generic.GetScrollInfo(hwnd,1,si);
				return si.nMax;
			}
			set
			{
				tagScrollInfo si=new tagScrollInfo();
				si.cbSize=(int)Marshal.SizeOf(si);
				si.fMask=1;
				si.nMin=0;
				si.nMax=value;
				IntPtr hwnd=Handle;
				if((int)hwnd!=0)
				{
					Generic.CheckScrollInfo(si);				
					Generic.SetScrollInfo(hwnd,1,si,true);
				}
			}
		}

		protected int VSPage
		{
			get
			{
				tagScrollInfo si=new tagScrollInfo();
				si.cbSize=(int)Marshal.SizeOf(si);
				si.fMask=23;
				si.nPage=0;
				IntPtr hwnd=Handle;
				if((int)hwnd!=0)
					Generic.GetScrollInfo(hwnd,1,si);
				return (int)si.nPage;
			}
			set
			{
				tagScrollInfo si=new tagScrollInfo();
				si.cbSize=(int)Marshal.SizeOf(si);
				si.fMask=2;
				si.nPage=(int)Math.Max(0,value);
				IntPtr hwnd=Handle;
				if((int)hwnd!=0)
				{
					Generic.CheckScrollInfo(si);				
					Generic.SetScrollInfo(hwnd,1,si,true);
				}
			}
		}

		[DefaultValue(0)]
		[Browsable(false)]
		protected int FixedBands
		{
			get
			{
				return FFixedBands;
			}
			set
			{
				FFixedBands=Math.Max(0,Math.Min(value,SrcRep.BandCount-1));
				Invalidate();
			}
		}

		[DefaultValue(0)]
		[Browsable(false)]
		protected int FixedCells
		{
			get
			{
				return FFixedCells;
			}
			set
			{
				FFixedCells=value;
				Invalidate();
			}
		}

		protected int VSPos
		{
			get
			{
				tagScrollInfo si=new tagScrollInfo();
				si.cbSize=(int)Marshal.SizeOf(si);
				si.fMask=23;
				si.nPos=0;
				IntPtr hwnd=Handle;
				if((int)hwnd!=0)
					Generic.GetScrollInfo(hwnd,1,si);
				return si.nPos;
			}
			set
			{
				tagScrollInfo si=new tagScrollInfo();
				si.cbSize=(int)Marshal.SizeOf(si);
				si.fMask=4;
				si.nPos=value;
				IntPtr hwnd=Handle;
				if((int)hwnd!=0)
				{
					Generic.CheckScrollInfo(si);				
					Generic.SetScrollInfo(hwnd,1,si,true);
				}
			}
		}

		[Browsable(false)]
		public int SelCount
		{
			get
			{
				return SelList.Count;
			}
		}

		public Cell this[int index]
		{
			get
			{
				return (Cell)SelList[index];
			}
		}

		[DefaultValue(100)]
		public int Gutter
		{
			get
			{
				return FGutter;
			}
			set
			{
				FGutter=Math.Max(value,0);
				Invalidate();
			}
		}

		[Browsable(false)]
		public bool InEditing
		{
			get
			{
				return FInEditing;
			}
			set
			{
				FInEditing=value;
			}
		}

		[Browsable(false)]
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
					GridX=Generic.ConvertUnits(GridX,FUnits,value);
					GridY=Generic.ConvertUnits(GridY,FUnits,value);
					FUnits=value;
				}
			}
		}

		[Browsable(false)]
		public double GridX
		{
			get
			{
				return FGridX;
			}
			set
			{
				FGridX=value;
			}
		}

		[Browsable(false)]
		public double GridY
		{
			get
			{
				return FGridY;
			}
			set
			{
				FGridY=value;
			}
		}

		public bool ShowMargins
		{
			get
			{
				return FShowMargins;
			}
			set
			{
				FShowMargins=value;
				Invalidate();
			}
		}

		[DefaultValue(true)]
		public bool ShowBandTitle
		{
			get
			{
				return FShowBandTitle;	
			}
			set
			{
				FShowBandTitle=value;
				Invalidate();
			}
		}

		[DefaultValue(SelectedCellStyle.Gray)]
		public SelectedCellStyle SelectedCellStyle
		{
			get
			{
				return FSelectedCellStyle;
			}
			set
			{
				if(FSelectedCellStyle!=value)
				{
					FSelectedCellStyle=value;
				}
			}
		}

		[DefaultValue(FocusedCellStyle.Rect)]
		public FocusedCellStyle FocusedCellStyle
		{
			get
			{
				return FFocusedCellStyle;
			}
			set
			{
				if(FFocusedCellStyle!=value)
				{
					FFocusedCellStyle=value;
					if(CurrCell!=null)
					{
						CurrCell.BeginUpdate();
						CurrCell.Changed=true;
						CurrCell.EndUpdate();
					}
				}
			}
		}

		[Browsable(false)]
		public RepOptions Options
		{
			get
			{
				return FOptions;
			}
			set
			{
				FOptions=value;
			}
		}
		#endregion

		#region class methods
		protected override void OnPaint(PaintEventArgs e)
		{
			int IdxBand;
			float T;
			Graphics gr=e.Graphics;
			if((int)Handle==0)
				return;
			UpdateScrolls();
			if(SrcRep.BandCount>0)
				DrawPage(gr);
			gr.FillRectangle(new SolidBrush(BackColor),0,0,Gutter,Generic.ToPix(SrcRep.TopMargin));
			if(SrcRep.Orientation==PrinterOrientation.Portrait)
				gr.FillRectangle(new SolidBrush(BackColor),0,1-TopY+UserTop+(int)(Generic.ToPix(SrcRep.PageSize.FHeight)*Generic.ZoomFactor)-Generic.ToPix(SrcRep.BottomMargin),Gutter,Generic.ToPix(SrcRep.BottomMargin)+3);
			else
				gr.FillRectangle(new SolidBrush(BackColor),0,1-TopY+UserTop+(int)(Generic.ToPix(SrcRep.PageSize.FWidth)*Generic.ZoomFactor)-Generic.ToPix(SrcRep.BottomMargin),Gutter,Generic.ToPix(SrcRep.BottomMargin)+3);
			a.r=new Rectangle(0,0,0,0);
			for(IdxBand=0;IdxBand<Math.Min(FixedBands,SrcRep.BandCount);IdxBand++)
			{
				if(!IntPaintBand(SrcRep.GetTops(IdxBand),gr,IdxBand))
					break;
			}
			if(SrcRep.BandCount>FixedBands)
			{
				a.FixedTop=SrcRep.GetTops(FixedBands);
				T=a.FixedTop-TopY+UserTop+Generic.ToPix(SrcRep.TopMargin);
				for(IdxBand=FixedBands;IdxBand<SrcRep.BandCount;IdxBand++)
				{
					if(T>Height)
						break;
					if(T+GetBandHeight(IdxBand)>=a.FixedTop)
					{
						if(!IntPaintBand(T,gr,IdxBand))
							break;
					}
					T=T+GetBandHeight(IdxBand);					
				}
			}
			else
			{
				T=SrcRep.GetTops(SrcRep.BandCount-1)+GetBandHeight(SrcRep.BandCount-1);
			}
			if(ShowMargins)
			{
				T=Gutter-LeftX+UserLeft+1;
				T=T+Generic.ToPix(SrcRep.LeftMargin);
				if(T>Gutter)
					gr.DrawLine(new Pen(Color.Red),T,0,T,Height);
				if(SrcRep.Orientation==PrinterOrientation.Portrait)
					T=Gutter-LeftX+UserLeft+1+(int)(Generic.ToPix(SrcRep.PageSize.FWidth)*Generic.ZoomFactor)-Generic.ToPix(SrcRep.RightMargin);
				else
					T=Gutter-LeftX+UserLeft+1+(int)(Generic.ToPix(SrcRep.PageSize.FHeight)*Generic.ZoomFactor)-Generic.ToPix(SrcRep.RightMargin);
				gr.DrawLine(new Pen(Color.Red),T,0,T,Height);

				T=1-TopY+UserTop+Generic.ToPix(SrcRep.TopMargin);
				gr.DrawLine(new Pen(Color.Red),Gutter,T,Width,T);
				if(SrcRep.Orientation==PrinterOrientation.Portrait)
					T=1-TopY+UserTop+(int)(Generic.ToPix(SrcRep.PageSize.FHeight)*Generic.ZoomFactor)-Generic.ToPix(SrcRep.BottomMargin);
				else
					T=1-TopY+UserTop+(int)(Generic.ToPix(SrcRep.PageSize.FWidth)*Generic.ZoomFactor)-Generic.ToPix(SrcRep.BottomMargin);
				gr.DrawLine(new Pen(Color.Red),Gutter,T,Width,T);
			}
		}
		

		protected bool IntPaintBand(float top,Graphics gr,int IdxBand)
		{
			Region region;
			int idxcell;
			if(top>Height)
				return false;
			bool freturn=true;
			PaintBandTitle(gr,IdxBand);
			a.left=0;
			for(idxcell=0;idxcell<SrcRep.GetBand(IdxBand).CellCount;idxcell++)
			{
				a.rc=CellClipRect(IdxBand,idxcell);
				a.left=Math.Max(a.left,a.rc.Right);
				
				region=new Region(a.rc);
				gr.IntersectClip(region);

				try
				{
					SrcRep.GetBand(IdxBand).GetCell(idxcell).PaintCell(gr,
						CellRect(IdxBand,idxcell),SelectedCellStyle,FocusedCellStyle,true,SrcRep.RenderingMode);
				}
				finally
				{
					gr.ResetClip();
				}
			}
			a.r=BandClipRect(IdxBand);
			a.r=new RectangleF(a.left+Generic.ToPix(SrcRep.RightMargin),0,a.r.Width,Height);
			region=new Region(a.r);
			gr.IntersectClip(region);
				
			try
			{
				Brush brush=new SolidBrush(BackColor);
				gr.FillRectangle(brush,a.r);
			}
			finally
			{
				gr.ResetClip();
			}
			return freturn;
		}

		public RectangleF CellClipRect(int idxband,int idxcell)
		{
			float FLeft=0,FTop=0,FRight=0,FBottom=0;
			RectangleF freturn;

			if((idxband>=0)&&(idxband<SrcRep.BandCount)&&
				(idxcell>=0)&&(idxcell<SrcRep.GetBand(idxband).CellCount))
			{
				freturn=CellRect(idxband,idxcell);
				FLeft=freturn.Left;
				FTop=freturn.Top;
				FRight=freturn.Right;
				FBottom=freturn.Bottom;

				if((FFixedCells==0)||(idxcell<FFixedCells))
					FLeft=Math.Max(FLeft,Gutter);
				else
					FLeft=Math.Max(FLeft,Generic.ToPix(SrcRep.LeftMargin)+Gutter+1+SrcRep.GetBand(idxband).GetRights(Math.Min(idxcell,Math.Max(0,FFixedCells-1))));
				FRight=Math.Min(FRight,Width);
				if(idxband>=FixedBands)
				{
					if(FixedBands==0)
						FTop=Math.Max(FTop,SrcRep.GetTops(FixedBands));
					else
						FTop=Math.Max(FTop,SrcRep.GetTops(FixedBands)+Generic.ToPix(SrcRep.TopMargin));
				}
				FBottom=Math.Min(FBottom,Height);
			}						
			freturn= new RectangleF(FLeft,FTop,Math.Abs(FRight-FLeft),Math.Abs(FBottom-FTop));
			return freturn;			
		}

		public float GetBandHeight(int IdxBand)
		{
			if((IdxBand>=0)&&(IdxBand<SrcRep.BandCount))
				return SrcRep.GetBand(IdxBand).Height;
			else
				return 0;
		}

		public void SetBandHeight(int IdxBand,float h)
		{
			SrcRep.GetBand(IdxBand).Height=h;
			Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if(!Focus())
				Focus();
		}

		protected double AsUnits(float pix)
		{
			return Generic.ConvertUnits(pix,Units.Pix,Units);
		}

		protected int AsPix(double u)
		{
			int i=(int)Generic.ConvertUnits(u,Units,Units.Pix);
			return i;
		}

		protected double AlignToGrid(double u,double grid)
		{
			if(grid==0)
				return u;
			else
			{
				double d=Math.Round(u/grid)*grid;
				return d;
			}
		}

		public Cell MouseToCell(int X,int Y,out int idxband,out int idxcell)
		{
			int ib,ic;
			float T;
			Cell freturn;

			idxband=-1;
			idxcell=-1;
			freturn=null;

			if(Y<SrcRep.GetTops(FixedBands))
			{
				for(ib=0;ib<FixedBands;ib++)
				{
					if(Generic.Between(Y,SrcRep.GetTops(ib),SrcRep.GetBand(ib).Height))
					{
						idxband=ib;
						if(X<=FGutter)
							return freturn;
						for(ic=0;ic<SrcRep.GetBand(ib).CellCount;ic++)
						{
							if(Generic.Between(X-FGutter+LeftX-UserLeft,SrcRep.GetBand(ib).GetLefts(ic),SrcRep.GetBand(ib).GetCell(ic).Width))
							{
								freturn=SrcRep.GetBand(ib).GetCell(ic);
								idxband=ib;
								idxcell=ic;
								return freturn;
							}
						}
					}
				}
			}
			else
			{
				T=SrcRep.GetTops(FixedBands)-TopY+UserTop+Generic.ToPix(SrcRep.TopMargin);
				for(ib=FixedBands;ib<SrcRep.BandCount;ib++)
				{
					if(Generic.Between(Y,T,SrcRep.GetBand(ib).Height))
					{
						idxband=ib;
						if(X<FGutter)
							return freturn;
						for(ic=0;ic<SrcRep.GetBand(ib).CellCount;ic++)
						{
							if(Generic.Between(X-FGutter+LeftX-UserLeft,SrcRep.GetBand(ib).GetLefts(ic)+Generic.ToPix(SrcRep.LeftMargin),SrcRep.GetBand(ib).GetCell(ic).Width))
							{
								freturn=SrcRep.GetBand(ib).GetCell(ic);
								idxcell=ic;
								return freturn;
							}
						}
					}
					T=T+GetBandHeight(ib);
				}
			}
			return freturn;
		}

		public void SelAdd(int idxband,int idxcell)
		{
			int idx;
			Cell cell;

			if((CurrBand!=null)&&(CurrCell!=null))
			{
				cell=SrcRep.GetBand(idxband).GetCell(idxcell);
				idx=SelList.IndexOf(cell);
				if(idx==-1)
				{
					SelList.Add(cell);
					cell.Selected=true;
				}
				else
				{
					SelList.RemoveAt(idx);
					cell.Selected=false;
				}
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			int n;
			float d,curtopy, curleftx;
			int OldCurrCellIdx, OldCurrBandIdx;
			RectangleF r;

			if(SrcRep.BandCount==0)
				return;
			OldCurrCellIdx=CurrCellIdx;
			OldCurrBandIdx=CurrBandIdx;
			
			switch(e.KeyData)
			{
				case Keys.Control|Keys.Up:
					TopY=TopY-30;
					break;
				case Keys.Control|Keys.Alt|Keys.Up:
					TopY=TopY-30;
					break;
				case Keys.Control|Keys.Down:
					TopY=TopY+30;
					break;
				case Keys.Control|Keys.Alt|Keys.Down:
					TopY=TopY+30;
					break;
				case Keys.Control|Keys.Left:
					LeftX=LeftX-30;
					break;
				case Keys.Control|Keys.Alt|Keys.Left:
					LeftX=LeftX-30;
					break;
				case Keys.Control|Keys.Right:
					LeftX=LeftX+30;
					break;
				case Keys.Control|Keys.Alt|Keys.Right:
					LeftX=LeftX+30;
					break;
				case Keys.Control|Keys.Home:
					TopY=0;
					CurrCellIdx=0;
					CurrBandIdx=0;
					break;
				case Keys.Control|Keys.End:
					CurrBandIdx=SrcRep.BandCount-1;
					CurrCellIdx=SrcRep.GetBand(CurrBandIdx).CellCount-1;
					break;
				case Keys.Control|Keys.Prior:
					n=CurrBandIdx;
					while(BandRect(n).Top>SrcRep.GetTops(FixedBands))
						n--;
					CurrBandIdx=n;
					CurrCellIdx=0;
					break;
				case Keys.Control|Keys.Next:
					n=CurrBandIdx;
					while((n<SrcRep.BandCount)&&(BandRect(n).Bottom<Height))
						n++;
					CurrBandIdx=n;
					CurrCellIdx=SrcRep.GetBand(CurrBandIdx).CellCount-1;
					break;
				case Keys.Up:
					MoveToPriorBand();
					break;
				case Keys.Shift|Keys.Up:
					MoveToPriorBand();
					break;
				case Keys.Down:
					MoveToNextBand();
					break;
				case Keys.Shift|Keys.Down:
					MoveToNextBand();
					break;
				case Keys.Left:
					CurrCellIdx=Math.Max(CurrCellIdx-1,0);
					break;
				case Keys.Shift|Keys.Left:
					CurrCellIdx=Math.Max(CurrCellIdx-1,0);
					break;
				case Keys.Right:
					CurrCellIdx=Math.Min(CurrCellIdx+1,SrcRep.GetBand(CurrBandIdx).CellCount-1);
					break;
				case Keys.Shift|Keys.Right:
					CurrCellIdx=Math.Min(CurrCellIdx+1,SrcRep.GetBand(CurrBandIdx).CellCount-1);
					break;
				case Keys.Home:
					CurrCellIdx=0;
					break;
				case Keys.End:
					CurrCellIdx=SrcRep.GetBand(CurrBandIdx).CellCount-1;
					break;
				case Keys.Shift|Keys.Home:
					CurrCellIdx=0;
					break;
				case Keys.Shift|Keys.End:
					CurrCellIdx=SrcRep.GetBand(CurrBandIdx).CellCount-1;
					break;
				case Keys.Prior:
					PageUp();
					break;
				case Keys.Next:
					PageDown();
					break;
				default:
					return;
			}
			CurrCellIdx=Math.Min(CurrCellIdx,SrcRep.GetBand(CurrBandIdx).CellCount-1);
			curleftx=LeftX;
			curtopy=TopY;
			r=CellRect(CurrBandIdx,CurrCellIdx);
			if(r.Bottom>Height)
			{
				d=r.Bottom-Height;
				curtopy=curtopy+d;
				r=new RectangleF(r.Left,r.Top-d,r.Width,Math.Abs(r.Bottom-(r.Top-d)));
			}
			if(r.Right>Width)
			{
				d=r.Right-Width;
				curleftx=curleftx+d;
				r=new RectangleF(r.Left-d,r.Top,Math.Abs(r.Right-(r.Left-d)),r.Height);
			}
			if(r.Top<SrcRep.GetTops(FixedBands))
				curtopy=curtopy+(r.Top-SrcRep.GetTops(FixedBands));
			if((FFixedCells==0)||(CurrCellIdx<FFixedCells))
			{
				if(r.Left<Gutter)
					curleftx=curleftx+(r.Left-Gutter-1);
			}
			else
			{
				if(r.Left<Gutter+SrcRep.GetBand(CurrBandIdx).GetRights(Math.Min(CurrCellIdx,Math.Max(0,FFixedCells-1))))
				{
					curleftx=curleftx+(r.Left-Gutter-SrcRep.GetBand(CurrBandIdx).GetRights(Math.Min(CurrCellIdx,Math.Max(0,FFixedCells-1))))-1;
				}
			}
			LeftX=(int)curleftx;
			TopY=(int)curtopy;
			base.OnKeyDown(e);
			if((OldCurrBandIdx!=CurrBandIdx)||(OldCurrCellIdx!=CurrCellIdx))
			{
				if(!((SelCount==1)&&(GetSel(0)==SrcRep.GetBand(CurrBandIdx).GetCell(CurrCellIdx))))
				{
					if(!(ModifierKeys==Keys.Shift))
						ClearSel();
					SelAdd(CurrBandIdx,CurrCellIdx);
				}
				SelectCellEventArgs selectcellarg=new SelectCellEventArgs();
				selectcellarg.idxband=CurrBandIdx;
				selectcellarg.idxcell=CurrCellIdx;
				if(GridSelectCell!=null)
					GridSelectCell(this,selectcellarg);

				UpdateScrolls();
				Invalidate();
			}
		}

		protected virtual void MoveToPriorBand()
		{
			CurrBandIdx=Math.Max(CurrBandIdx-1,0);
		}

		protected virtual void MoveToNextBand()
		{
			CurrBandIdx=Math.Min(CurrBandIdx+1,SrcRep.BandCount-1);
		}

		public Cell GetSel(int index)
		{
			return (Cell)SelList[index];
		}

		public void SelAll()
		{
			ClearSel();
			for(int idxband=0;idxband<SrcRep.BandCount;idxband++)
			{
				for(int idxcell=0;idxcell<SrcRep.GetBand(idxband).CellCount;idxcell++)
				{
					SelAdd(idxband,idxcell);
				}
			}
			Invalidate();
		}

		public bool MergeSelectedCells()
		{
			Band band;
			Cell cell;
			bool freturn=false;
			int idxcell;
			for(int idxband=0;idxband<SrcRep.BandCount;idxband++)
			{
				band=SrcRep.GetBand(idxband);
				idxcell=0;
				while(idxcell<band.CellCount)
				{
					if(band.GetCell(idxcell).Selected)
					{
						cell=band.GetCell(idxcell);
						idxcell++;
						while((idxcell<band.CellCount)&&(band.GetCell(idxcell).Selected))
						{
							cell.Value=cell.Value+band.GetCell(idxcell).Value;
							cell.Width=cell.Width+band.GetCell(idxcell).Width;
							SelAdd(idxband,idxcell);
							band.DeleteCell(idxcell);
							freturn=true;
						}
					}
					idxcell++;
				}
			}
			return freturn;
		}

		public void DeleteBand(int IdxBand)
		{
			int idx;
			if((IdxBand>=0)&&(IdxBand<SrcRep.BandCount))
			{
				for(int i=0;i<SrcRep.GetBand(IdxBand).CellCount;i++)
				{
					idx=SelList.IndexOf(SrcRep.GetBand(IdxBand).GetCell(i));
					if(idx!=-1)
						SelList.RemoveAt(idx);
				}
				float height=SrcRep.GetBand(IdxBand).Height;
				SrcRep.DeleteBand(IdxBand);
				CurrBandIdx=Math.Min(CurrBandIdx,SrcRep.BandCount-1);
				SrcRep.GetBand(CurrBandIdx).Height=SrcRep.GetBand(CurrBandIdx).Height+height;
				CurrCellIdx=Math.Min(CurrCellIdx,SrcRep.GetBand(CurrBandIdx).CellCount-1);
				UpdateScrolls();
				Invalidate();
			}
		}

		protected void DrawPage(Graphics gr)
		{
			Shape shape=new Shape();
			if(SrcRep.Orientation==PrinterOrientation.Portrait)
				shape.Size=new Size((int)(SrcRep.PageSize.PaperSize.Width*Generic.ZoomFactor),(int)(SrcRep.PageSize.PaperSize.Height*Generic.ZoomFactor));
			else
				shape.Size=new Size((int)(SrcRep.PageSize.PaperSize.Height*Generic.ZoomFactor),(int)(SrcRep.PageSize.PaperSize.Width*Generic.ZoomFactor));
			shape.Location=new Point(Gutter-LeftX+UserLeft,-TopY+UserTop);
			shape.BackGroundColor=Generic.FindColor(SrcRep.PageColor,SrcRep.RenderingMode);
			shape.Gradient=SrcRep.PageGraident;
			if(SrcRep.PageGraident)
			{
				shape.GradientColor=Generic.FindColor(SrcRep.PageGraidentColor,SrcRep.RenderingMode);
				shape.FillDirection=SrcRep.PageFillDirection;
			}
			shape.ShapeType=ShapeType.Rectangle;
			shape.Paint(gr);
			if(SrcRep.PagePicture!=null)
			{
				int x,y;
				int width,height;
				switch(SrcRep.PageImagePosition)
				{
					case ImagePosition.Center:
						Bitmap bitmap=new Bitmap(SrcRep.RenderingPagePicture,new Size((int)(SrcRep.RenderingPagePicture.Width*Generic.ZoomFactor),(int)(SrcRep.RenderingPagePicture.Height*Generic.ZoomFactor)));
						if(SrcRep.Orientation==PrinterOrientation.Portrait)
						{
							y=-TopY+UserTop+(((int)(SrcRep.PageSize.PaperSize.Height*Generic.ZoomFactor)-bitmap.Height)/2);
							x=-LeftX+UserLeft+Gutter+(((int)(SrcRep.PageSize.PaperSize.Width*Generic.ZoomFactor)-bitmap.Width)/2);
							gr.DrawImage(bitmap,new RectangleF(new PointF(x,y),new SizeF(bitmap.PhysicalDimension)));
						}
						else
						{
							y=-TopY+UserTop+(((int)(SrcRep.PageSize.PaperSize.Width*Generic.ZoomFactor)-bitmap.Height)/2);
							x=-LeftX+UserLeft+Gutter+(((int)(SrcRep.PageSize.PaperSize.Height*Generic.ZoomFactor)-bitmap.Width)/2);
							gr.DrawImage(bitmap,new RectangleF(new PointF(x,y),new SizeF(bitmap.PhysicalDimension)));
						}
						break;
					case ImagePosition.Stretch:
						if(SrcRep.Orientation==PrinterOrientation.Portrait)
						{
							y=-TopY+UserTop;
							x=-LeftX+UserLeft+Gutter;
							width=(int)(SrcRep.PageSize.PaperSize.Width*Generic.ZoomFactor);
							height=(int)(SrcRep.PageSize.PaperSize.Height*Generic.ZoomFactor);
							gr.DrawImage(SrcRep.RenderingPagePicture,new RectangleF(new PointF(x,y),new SizeF(width,height)));
						}
						else
						{
							y=-TopY+UserTop;
							x=-LeftX+UserLeft+Gutter;
							width=(int)(SrcRep.PageSize.PaperSize.Height*Generic.ZoomFactor);
							height=(int)(SrcRep.PageSize.PaperSize.Width*Generic.ZoomFactor);
							gr.DrawImage(SrcRep.RenderingPagePicture,new RectangleF(new PointF(x,y),new SizeF(width,height)));
						}
						break;
					case ImagePosition.Tile:
						bitmap=new Bitmap(SrcRep.RenderingPagePicture,new Size((int)(SrcRep.RenderingPagePicture.Width*Generic.ZoomFactor),(int)(SrcRep.RenderingPagePicture.Height*Generic.ZoomFactor)));
						TextureBrush brush=new TextureBrush(bitmap,System.Drawing.Drawing2D.WrapMode.Tile);
						if(SrcRep.Orientation==PrinterOrientation.Portrait)
						{
							y=-TopY+UserTop;
							x=-LeftX+UserLeft+Gutter;
							width=SrcRep.PageSize.PaperSize.Width;
							height=SrcRep.PageSize.PaperSize.Height;
							gr.FillRectangle(brush,new RectangleF(new PointF(x,y),new SizeF(width,height)));
						}
						else
						{
							y=-TopY+UserTop;
							x=-LeftX+UserLeft+Gutter;
							width=SrcRep.PageSize.PaperSize.Height;
							height=SrcRep.PageSize.PaperSize.Width;
							gr.FillRectangle(brush,new RectangleF(new PointF(x,y),new SizeF(width,height)));
						}
						break;
				}
			}
		}

		protected override  void WndProc(ref Message message)
		{
			base.WndProc(ref message);
			switch(message.Msg)
			{
					//Wm_size
					//case 0x0005:
					//	OnResize(EventArgs.Empty);
					//	break;
					//Wm_erasebkgnd
					//case 0x0014:
					//	message.Result=(IntPtr)1;
					//	break;
					//wm_hscroll
				case 0x0114:
					if(FScrollUpdate)
						break;
					FScrollUpdate=true;
				switch((int)message.WParam)
				{
						//sb_linedown
					case 1:
						LeftX=LeftX+30;
						break;
						//SB_LINEUP
					case 0:
						LeftX=LeftX-30;
						break;
						//SB_PAGEUP
					case 2:
						LeftX=LeftX-(Width+FGutter);
						break;
						//SB_PAGEDOWN
					case 3:
						LeftX=LeftX+(Width+FGutter);
						break;
						//SB_THUMBPOSITION
					case 8:
						LeftX=HSPos;
						break;
						//SB_THUMBTRACK
					default:
						LeftX=GetHSTrackPos();
						break;
				}
					if(HScroll!=null)
						HScroll(this,EventArgs.Empty);
					FScrollUpdate=false;
					break;

					//WM_GetDlgCode
				case 0x0087:
					message.Result=(IntPtr)(DialogCodes.DLGC_DEFPUSHBUTTON|DialogCodes.DLGC_WANTARROWS|DialogCodes.DLGC_WANTCHARS);
					break;
					//WM_VSCROLL
				case 0x0115:
					if(FScrollUpdate)
						break;
					FScrollUpdate=true;
				switch((int)message.WParam)
				{
						//sb_linedown
					case 1:
						TopY=TopY+30;
						break;
						//SB_LINEUP
					case 0:
						TopY=TopY - 30;
						break;
						//SB_PAGEUP
					case 2:
						PageUp();
						break;
						//SB_PAGEDOWN
					case 3:
						PageDown();
						break;
						//SB_THUMBPOSITION
					case 8:
						TopY=VSPos;
						break;
						//SB_THUMBTRACK
					default:
						TopY=GetVSTrackPos();
						break;
				}
					if(VScroll!=null)
						VScroll(this,EventArgs.Empty);
					FScrollUpdate=false;
					break;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if(!(Size.Width==0 && Size.Height==0))
			{
				if(Zoom==Zoom.pagewidth)
				{
					if(SrcRep.Orientation==PrinterOrientation.Portrait)
					{
						Generic.OldZoomFactor=(float)(Old.Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Width;
						Generic.ZoomFactor=(float)(Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Width;
					}
					else
					{
						Generic.OldZoomFactor=(float)(Old.Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Height;
						Generic.ZoomFactor=(float)(Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Height;
					}
					ArrangeSize();
				}
				if(Zoom==Zoom.wholepage)
				{
					if(SrcRep.PageSize.PaperSize.Width>=SrcRep.PageSize.PaperSize.Height)
					{
						Generic.OldZoomFactor=(float)(Old.Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Width;
						Generic.ZoomFactor=(float)(Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Width;
					}
					else
					{
						Generic.OldZoomFactor=((float)Old.Height-50.0F)/(float)SrcRep.PageSize.PaperSize.Height;
						Generic.ZoomFactor=((float)Height-50.0F)/(float)SrcRep.PageSize.PaperSize.Height;
					}
					ArrangeSize();
				}
				UpdateScrolls();
				Refresh();
				Old=this.Size;
			}
		}

		public int GetHSTrackPos()
		{
			tagScrollInfo si=new tagScrollInfo();
			si.cbSize=(int)Marshal.SizeOf(si);
			si.fMask=23;
			si.nTrackPos=0;
			IntPtr hwnd=Handle;
			if((int)hwnd!=0)
				Generic.GetScrollInfo(hwnd,0,si);
			return si.nTrackPos;
		}

		public int GetVSTrackPos()
		{
			tagScrollInfo si=new tagScrollInfo();
			si.cbSize=(int)Marshal.SizeOf(si);
			si.fMask=23;
			si.nTrackPos=0;
			IntPtr hwnd=Handle;
			if((int)hwnd!=0)
				Generic.GetScrollInfo(hwnd,1,si);
			return si.nTrackPos;
		}

		public void PageUp()
		{
			int idxband;
			float y;

			y=BandRect(CurrBandIdx).Top;
			TopY=TopY-(Height-(int)SrcRep.GetTops(FixedBands));
			idxband=CurrBandIdx;
			while((idxband>=0)&&(BandRect(idxband).Top>y))
			{
				idxband--;
			}
			CurrBandIdx=idxband;
		}

		public void PageDown()
		{
			int idxband;
			float y;

			if((CurrBandIdx>=0)&&(CurrBandIdx<SrcRep.BandCount))
			{
				y=BandRect(CurrBandIdx).Top;
				TopY=TopY+(Height-(int)SrcRep.GetTops(FixedBands));
				idxband=CurrBandIdx;
				while((idxband<SrcRep.BandCount)&&(BandRect(idxband).Top<y))
				{
					idxband++;
				}
				CurrBandIdx=idxband;
			}
		}

		public void PrintPage(object sender,PrintPageEventArgs e)
		{
			Rep CurrRep=null;
			if(Owner is EditRep)
			{
				if(!prn.DefaultPageSettings.Landscape)
				{
					b.LeftMargin=Generic.PrintToMM(prn.DefaultPageSettings.Margins.Left);
					b.RightMargin=prn.DefaultPageSettings.PaperSize.Width-b.LeftMargin;
					b.TopMargin=Generic.PrintToMM(prn.DefaultPageSettings.Margins.Top);
					b.BottomMargin=prn.DefaultPageSettings.PaperSize.Height-Generic.PrintToMM(prn.DefaultPageSettings.Margins.Bottom);
				}
				else
				{
					b.LeftMargin=Generic.PrintToMM(prn.DefaultPageSettings.Margins.Left);
					b.RightMargin=prn.DefaultPageSettings.PaperSize.Height-b.LeftMargin;
					b.TopMargin=Generic.PrintToMM(prn.DefaultPageSettings.Margins.Top);
					b.BottomMargin=prn.DefaultPageSettings.PaperSize.Width-Generic.PrintToMM(prn.DefaultPageSettings.Margins.Bottom);
				}
				if(SrcRep.BandCount>0)
				{
					b.CellRect=new Rectangle(b.LeftMargin,b.TopMargin,0,0);
					b.rLeft=b.LeftMargin;
				}

				Generic.NonPrinting=false;
				Graphics gr=e.Graphics;			
				PrintNewPage(gr,SrcRep);				
				ClearSel();
				b.rightmgn=0;				
			
				for(int idxband=0;idxband<SrcRep.BandCount;idxband++)
				{
					PrintBand(SrcRep.GetBand(idxband),e,SrcRep);
				}
				Generic.NonPrinting=true;
				e.HasMorePages=false;				
			}
			if(Owner is UserRep)
			{
				if(((UserRep)Owner).SourceRep.orientation==PrinterOrientation.Portrait)
				{
					b.LeftMargin=Generic.PrintToMM(((UserRep)Owner).SourceRep.LeftMargin);
					b.RightMargin=((UserRep)Owner).SourceRep.Width-b.LeftMargin;
					b.TopMargin=Generic.PrintToMM(((UserRep)Owner).SourceRep.TopMargin);
					b.BottomMargin=((UserRep)Owner).SourceRep.Height-Generic.PrintToMM(((UserRep)Owner).SourceRep.BottomMargin);
				}
				else
				{
					b.LeftMargin=Generic.PrintToMM(((UserRep)Owner).SourceRep.LeftMargin);
					b.RightMargin=((UserRep)Owner).SourceRep.Height-b.LeftMargin;
					b.TopMargin=Generic.PrintToMM(((UserRep)Owner).SourceRep.TopMargin);
					b.BottomMargin=((UserRep)Owner).SourceRep.Width-Generic.PrintToMM(((UserRep)Owner).SourceRep.BottomMargin);
				}
				
				b.CellRect=new Rectangle(b.LeftMargin,b.TopMargin,0,0);
				b.rLeft=b.LeftMargin;
				
				if(prn.PrinterSettings.FromPage!=0)
					if(Generic.page<prn.PrinterSettings.FromPage)
						Generic.page=prn.PrinterSettings.FromPage;
				
				ClearSel();
				b.rightmgn=0;
				
				int firstband;
				int lastband;
				
				firstband=0;
				lastband=0;
	
				for(int i=0;i<((UserRep)Owner).SourceRep.RepList.Count;i++)
				{
					CurrRep=((UserRep)Owner).SourceRep.GetSrcRep(i);
					for(int idxband=0;idxband<CurrRep.BandCount;idxband++)
					{
						if(CurrRep.GetBand(idxband).Pageno==Generic.page)
							firstband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
						if(CurrRep.GetBand(idxband).Pageno==Generic.page+1)
						{
							lastband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
							break;
						}
					}
					if(lastband!=0)
						break;
				}
				if(Generic.page!=CurrRep.LastPage-1)
					lastband=lastband-1;

				PrintNewPage(e.Graphics,CurrRep);
	
				for(int idxband=firstband;idxband<lastband+1;idxband++)
				{
					PrintBand(CurrRep.GetBand(idxband),e,CurrRep);
				}
				if((Generic.page==((UserRep)Owner).Pagecnt-1)||((Generic.page>=prn.PrinterSettings.ToPage)&&(prn.PrinterSettings.ToPage!=0)))
				{
					e.HasMorePages=false;
					Generic.page=1;
				}
				else
				{
					e.HasMorePages=true;
					Generic.page++;
				}
			}			
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

		void PrintBand(Band band,PrintPageEventArgs e,Rep CurrRep)
		{
			b.CellRect=new RectangleF(b.CellRect.Left,b.CellRect.Top,Math.Abs(b.CellRect.Left-b.CellRect.Right),Math.Abs((b.CellRect.Top+band.Height)-b.CellRect.Top));
			PrintClipBand(band,0,b.CellRect.Top,b.CellRect.Bottom,e,CurrRep);
		}

		void PrintClipBand(Band band,int PrintBandPos,float ClipTop,float ClipBottom,PrintPageEventArgs e,Rep CurrRep)
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
						e.Graphics.IntersectClip(region);
						try
						{
							band.GetCell(idxcell).PaintCell(e.Graphics,r,SelectedCellStyle.None,FocusedCellStyle.None,false,SrcRep.RenderingMode);
						}
						finally
						{
							e.Graphics.ResetClip();
						}
					}
					else
					{
						Region region=new Region(new RectangleF(b.CellRect.Left,ClipTop,Math.Abs(b.CellRect.Left-b.CellRect.Right),Math.Abs(ClipBottom-ClipTop)));
						e.Graphics.IntersectClip(region);
						try
						{
							band.GetCell(idxcell).PaintCell(e.Graphics,b.CellRect,SelectedCellStyle.None,FocusedCellStyle.None,false,SrcRep.RenderingMode);
						}
						finally
						{
							e.Graphics.ResetClip();
						}
					}
				}
				b.CellRect=new RectangleF(b.CellRect.Left+band.GetCell(idxcell).Width,b.CellRect.Top,Math.Abs((b.CellRect.Left+band.GetCell(idxcell).Width)-b.CellRect.Right),Math.Abs(b.CellRect.Top-b.CellRect.Bottom));
			}
			b.rightmgn=Math.Max(b.rightmgn,b.CellRect.Right);
			b.CellRect=new RectangleF(OldLeft,b.CellRect.Bottom,Math.Abs(OldLeft-b.CellRect.Right),0);
		}

		public virtual void SetInt32(string VarName,int VarValue)
		{
			
		}

		public void Preview()
		{
			Zoom zoom=Zoom;
			float zoomfactor=Generic.ZoomFactor;
			if(!(Owner is UserRep))
			{
				Zoom=Zoom.hundred;			
				pageset.Margins.Bottom=(int)SrcRep.BottomMargin;
				pageset.Margins.Left=(int)SrcRep.LeftMargin;
				pageset.Margins.Right=(int)SrcRep.RightMargin;
				pageset.Margins.Top=(int)SrcRep.TopMargin;
				pageset.Landscape=SrcRep.Orientation.ToString().IndexOf("Landscape")!=-1;
				pageset.PaperSize=SrcRep.PageSize.PaperSize;
			
				prn.DefaultPageSettings=pageset;
			
				printset.FromPage=0;
				printset.ToPage=0;
				prn.PrinterSettings=printset;		

				PrintPreviewDialog dlg=new PrintPreviewDialog();
			
				dlg.Document=prn;
				dlg.ShowDialog();
				Zoom=zoom;			
				Refresh();
			}
			else
			{	
				Generic.ZoomFactor=1;
				pageset.Margins.Bottom=((UserRep)Owner).SourceRep.BottomMargin;
				pageset.Margins.Left=((UserRep)Owner).SourceRep.LeftMargin;
				pageset.Margins.Right=((UserRep)Owner).SourceRep.RightMargin;
				pageset.Margins.Top=((UserRep)Owner).SourceRep.TopMargin;
				pageset.Landscape=((UserRep)Owner).SourceRep.orientation.ToString().IndexOf("Landscape")!=-1;
				pageset.PaperSize=((UserRep)Owner).SourceRep.PaperSize;
			
				prn.DefaultPageSettings=pageset;
			
				printset.FromPage=0;
				printset.ToPage=0;
				prn.PrinterSettings=printset;		

				PrintPreviewDialog dlg=new PrintPreviewDialog();
			
				dlg.Document=prn;
				dlg.ShowDialog();
				Generic.ZoomFactor=zoomfactor;
			}
		}

		public void Print()
		{
			Zoom zoom=Zoom;
			float zoomfactor=Generic.ZoomFactor;
			if(!(Owner is UserRep))
			{
				Zoom=Zoom.hundred;
				pageset.Margins.Bottom=(int)SrcRep.BottomMargin;
				pageset.Margins.Left=(int)SrcRep.LeftMargin;
				pageset.Margins.Right=(int)SrcRep.RightMargin;
				pageset.Margins.Top=(int)SrcRep.TopMargin;
				pageset.Landscape=SrcRep.Orientation.ToString().IndexOf("Landscape")!=-1;
				pageset.PaperSize=SrcRep.PageSize.PaperSize;
			
				prn.DefaultPageSettings=pageset;
			
				prn.PrinterSettings=printset;
				PrintDialog pdlg=new PrintDialog();
				pdlg.AllowSomePages=true;
				pdlg.AllowSelection=false;			

				pdlg.Document=prn;
				if(pdlg.ShowDialog()==DialogResult.OK)
				{
					prn.Print();
				}
				Zoom=zoom;				
				Refresh();
			}
			else
			{
				Generic.ZoomFactor=1;
				pageset.Margins.Bottom=((UserRep)Owner).SourceRep.BottomMargin;
				pageset.Margins.Left=((UserRep)Owner).SourceRep.LeftMargin;
				pageset.Margins.Right=((UserRep)Owner).SourceRep.RightMargin;
				pageset.Margins.Top=((UserRep)Owner).SourceRep.TopMargin;
				pageset.Landscape=((UserRep)Owner).SourceRep.orientation.ToString().IndexOf("Landscape")!=-1;
				pageset.PaperSize=((UserRep)Owner).SourceRep.PaperSize;
			
				prn.DefaultPageSettings=pageset;
			
				prn.PrinterSettings=printset;
				PrintDialog pdlg=new PrintDialog();
				pdlg.AllowSomePages=true;
				pdlg.AllowSelection=false;			

				pdlg.Document=prn;
				if(pdlg.ShowDialog()==DialogResult.OK)
				{
					prn.Print();
				}
				Generic.ZoomFactor=zoomfactor;
			}
		}

		public bool PageSettings()
		{
			PageSetupDialog psdlg=new PageSetupDialog();	
			psdlg.PageSettings=pageset;
			psdlg.PrinterSettings=printset;
			OldSize=SrcRep.PageSize.PaperSize;
			OldOrientation=SrcRep.Orientation;

			if(OldOrientation==PrinterOrientation.Portrait)
			{
				SrcRep.OldGridHeight=(int)(OldSize.Height*Generic.ZoomFactor);
				SrcRep.OldGridWidth=(int)(OldSize.Width*Generic.ZoomFactor);
			}
			else
			{
				SrcRep.OldGridHeight=(int)(OldSize.Width*Generic.ZoomFactor);
				SrcRep.OldGridWidth=(int)(OldSize.Height*Generic.ZoomFactor);
			}

			pageset.Margins.Left=(int)(SrcRep.LeftMargin/Generic.ZoomFactor);
			pageset.Margins.Right=(int)(SrcRep.RightMargin/Generic.ZoomFactor);
			pageset.Margins.Top=(int)(SrcRep.TopMargin/Generic.ZoomFactor);
			pageset.Margins.Bottom=(int)(SrcRep.BottomMargin/Generic.ZoomFactor);
			pageset.Landscape=SrcRep.Orientation.ToString().IndexOf("Landscape")!=-1;
			pageset.PaperSize=SrcRep.PageSize.PaperSize;

			if(psdlg.ShowDialog()==DialogResult.OK)
			{
				if(psdlg.PageSettings.Landscape)
				{
					if(Zoom==Zoom.pagewidth)
						Generic.ZoomFactor=(float)(Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Height;
					SrcRep.Orientation=PrinterOrientation.Landscape;
					SrcRep.NewHeight=(int)(psdlg.PageSettings.PaperSize.Width*Generic.ZoomFactor);
					SrcRep.NewWidth=(int)(psdlg.PageSettings.PaperSize.Height*Generic.ZoomFactor);
				}
				else
				{
					if(Zoom==Zoom.pagewidth)
						Generic.ZoomFactor=(float)(Width-Gutter-50)/(float)SrcRep.PageSize.PaperSize.Width;
					SrcRep.Orientation=PrinterOrientation.Portrait;
					SrcRep.NewHeight=(int)(psdlg.PageSettings.PaperSize.Height*Generic.ZoomFactor);
					SrcRep.NewWidth=(int)(psdlg.PageSettings.PaperSize.Width*Generic.ZoomFactor);	
				}
				SrcRep.PageSize.PaperSize=psdlg.PageSettings.PaperSize;

				SrcRep.OldLeftMargin=SrcRep.LeftMargin;
				SrcRep.OldRightMargin=SrcRep.RightMargin;
				SrcRep.OldTopMargin=SrcRep.TopMargin;
				SrcRep.OldBottomMargin=SrcRep.BottomMargin;
				RegionInfo inf=RegionInfo.CurrentRegion;
				if(inf.IsMetric)
				{
					SrcRep.FBottomMargin=(Generic.ZoomFactor*Generic.InchToMm(psdlg.PageSettings.Margins.Bottom)*10.0);
					SrcRep.FLeftMargin=(Generic.ZoomFactor*Generic.InchToMm(psdlg.PageSettings.Margins.Left)*10.0);
					SrcRep.FRightMargin=(Generic.ZoomFactor*Generic.InchToMm(psdlg.PageSettings.Margins.Right)*10.0);
					SrcRep.FTopMargin=(Generic.ZoomFactor*Generic.InchToMm(psdlg.PageSettings.Margins.Top)*10.0);
				}
				else
				{
					SrcRep.FBottomMargin=(Generic.ZoomFactor*psdlg.PageSettings.Margins.Bottom);
					SrcRep.FLeftMargin=(Generic.ZoomFactor*psdlg.PageSettings.Margins.Left);
					SrcRep.FRightMargin=(Generic.ZoomFactor*psdlg.PageSettings.Margins.Right);
					SrcRep.FTopMargin=(Generic.ZoomFactor*psdlg.PageSettings.Margins.Top);
				}

				SrcRep.CellArrangement();
				return true;
			}
			return false;
		}

		public RectangleF CellRect(int idxband,int idxcell)
		{
			int IdxTopBand,IdxBottomBand;
			Band band,topband,bottomband;
			Cell cell;
			float FLeft, FRight,FTop,FBottom;

			if((idxband>=0)&&(idxband<SrcRep.BandCount)&&
				(idxcell>=0)&&(idxcell<SrcRep.GetBand(idxband).CellCount))
			{
				band=SrcRep.GetBand(idxband);
				cell=band.GetCell(idxcell);
				FLeft=Gutter+Generic.ToPix(SrcRep.LeftMargin)+1+band.GetLefts(idxcell);
				if((FFixedCells==0)||(idxcell>=FFixedCells))
					FLeft=FLeft-LeftX+UserLeft;
				FRight=FLeft+cell.Width;

				topband=cell.GetTopBand();
				IdxTopBand=SrcRep.IndexOfBand(topband);
				bottomband=cell.GetBottomBand();
				IdxBottomBand=SrcRep.IndexOfBand(bottomband);

				FTop=SrcRep.GetTops(IdxTopBand)+Generic.ToPix(SrcRep.TopMargin);
				FBottom=SrcRep.GetTops(IdxBottomBand)+Generic.ToPix(SrcRep.TopMargin)+SrcRep.GetBand(IdxBottomBand).Height;
				if(idxband>=FixedBands)
				{
					FTop=FTop-TopY+UserTop;
					FBottom=FBottom-TopY+UserTop;
				}
				return new RectangleF(FLeft,FTop,Math.Abs(FRight-FLeft),Math.Abs(FTop-FBottom));
			}
			else
				return new RectangleF(0,0,0,0);
		}

		public void DeleteBands()
		{
			ClearSel();

			for(int idxband=0;idxband<SrcRep.BandCount;idxband++)
			{
				for(int idxcell=0;idxcell<SrcRep.GetBand(idxband).CellCount;idxcell++)
				{
					if(SrcRep.GetBand(idxband).GetCell(idxcell).Control!=null)
					{
						SrcRep.GetBand(idxband).GetCell(idxcell).Control.Visible=false;
						SrcRep.GetBand(idxband).GetCell(idxcell).Control.Location=SrcRep.GetBand(idxband).GetCell(idxcell).ControlLocation;
						SrcRep.GetBand(idxband).GetCell(idxcell).Control.Size=SrcRep.GetBand(idxband).GetCell(idxcell).ControlSize;
						SrcRep.GetBand(idxband).GetCell(idxcell).Control.Font=new Font(SrcRep.GetBand(idxband).GetCell(idxcell).Control.Font.Name,SrcRep.GetBand(idxband).GetCell(idxcell).ControlFontSize,SrcRep.GetBand(idxband).GetCell(idxcell).Control.Font.Style);						
					}
				}
			}
			SrcRep.DeleteAll();
			FixedBands=0;

			CurrBandIdx=0;
			CurrCellIdx=0;

			UpdateScrolls();
			FTopY=0;
			FLeftX=0;
			UpdateScrolls();
			Invalidate();
		}

		public void ClearSel()
		{
			int IdxBand, IdxCell;
			Cell cell;

			for(IdxBand=0;IdxBand<SrcRep.BandCount;IdxBand++)
			{
				for(IdxCell=0;IdxCell<SrcRep.GetBand(IdxBand).CellCount;IdxCell++)
				{
					cell=SrcRep.GetBand(IdxBand).GetCell(IdxCell);
					if(cell.Selected)
					{
						cell.Selected=false;
					}
				}
			}
			SelList.Clear();
		}

		protected void UpdateScrolls()
		{
			int IdxBand,maxwidth,cellcnt;
			IntPtr hwnd=Handle;
			if((int)hwnd==0)
				return;
			maxwidth=0;
			for(IdxBand=0;IdxBand<SrcRep.BandCount;IdxBand++)
			{
				cellcnt=SrcRep.GetBand(IdxBand).CellCount;
				if(cellcnt>0)
				{
					maxwidth=Math.Max(maxwidth,(int)SrcRep.GetBand(IdxBand).GetLefts(cellcnt-1)+
						(int)SrcRep.GetBand(IdxBand).GetCell(cellcnt-1).Width+Generic.ToPix(SrcRep.LeftMargin)+Generic.ToPix(SrcRep.RightMargin));
				}
			}
			maxwidth=maxwidth+50;
			SetHS(LeftX,Math.Max(0,Width-FGutter),maxwidth);
			if(SrcRep.BandCount>0)
			{
				SetVS(TopY,Height,
					(int)SrcRep.GetTops(SrcRep.BandCount-1)+(int)SrcRep.GetBand(SrcRep.BandCount-1).Height+50+Generic.ToPix(SrcRep.TopMargin)+Generic.ToPix(SrcRep.BottomMargin));
			}
		}

		void SetHS(int AHSPos,int AHSPage,int AHSMax)
		{
			tagScrollInfo si=new tagScrollInfo();
			si.cbSize=(int)Marshal.SizeOf(si);
			si.fMask=4|2|1;
			si.nPos=AHSPos;
			si.nPage=(int)Math.Max(0,AHSPage);
			si.nMin=0;
			si.nMax=AHSMax;
			IntPtr hwnd=Handle;
			if((int)hwnd!=0)
			{
				Generic.CheckScrollInfo(si);				
				Generic.SetScrollInfo(hwnd,0,si,true);
			}
		}

		void SetVS(int AVSPos,int AVSPage,int AVSMax)
		{
			tagScrollInfo si=new tagScrollInfo();
			si.cbSize=(int)Marshal.SizeOf(si);
			si.fMask=4|2|1;
			si.nPos=AVSPos;
			si.nPage=(int)Math.Max(0,AVSPage);
			si.nMin=0;
			si.nMax=AVSMax;
			IntPtr hwnd=Handle;
			if((int)hwnd!=0)
			{
				Generic.CheckScrollInfo(si);				
				Generic.SetScrollInfo(hwnd,1,si,true);
			}
		}

		public Band NewBand()
		{
			Band freturn=SrcRep.NewBand();
			float widthcount=0;
			float count=0;
			float height=0;
			if(sender)
			{
				height=SrcRep.GetBand(SrcRep.BandCount-2).Height;
				SrcRep.GetBand(SrcRep.BandCount-2).Height=SrcRep.GetBand(SrcRep.BandCount-2).Height/2;
				freturn.Height=height-SrcRep.GetBand(SrcRep.BandCount-2).Height;
				for(int idxcell=0;idxcell<SrcRep.GetBand(SrcRep.BandCount-2).CellCount;idxcell++)
				{
					widthcount=widthcount+SrcRep.GetBand(SrcRep.BandCount-2).GetCell(idxcell).Width;					
				}
				for(int idxcell=0;idxcell<freturn.CellCount;idxcell++)
				{
					if(idxcell==freturn.CellCount-1)
						freturn.GetCell(freturn.CellCount-1).Width=widthcount-count;
					else
					{
						freturn.GetCell(idxcell).Width=widthcount/4;
						count=count+freturn.GetCell(idxcell).Width;
					}
				}
			}
			freturn.OnBandChange+=new EventHandler(BandChange);
			freturn.OnCellChange+=new CellChangeEvent(CellChange);
			UpdateScrolls();
			Invalidate();
			return freturn;
		}

		void BandChange(object sender,EventArgs arg)
		{
			Invalidate();
		}

		void CellChange(object sender,CellChangeEventArgs arg)
		{
			int idxband, idxcell;
			
			idxband=SrcRep.IndexOfBand((BandList)sender);
			if(idxband!=-1)
			{
				Graphics gr=CreateGraphics();
				PaintBandTitle(gr,idxband);
				gr.Dispose();
				idxcell=((Band)sender).IndexOfCell((Cell)arg.cell);
				if(idxcell!=-1)
				{
					PaintCell(idxband,idxcell);
				}
			}
		}

		public void PaintCell(int idxband,int idxcell)
		{
			RectangleF r;

			if((InEditing)&&(idxband==CurrBandIdx)&&(idxcell==CurrCellIdx))
			{
				r=CellClipRect(idxband,idxcell);
				Graphics gr=CreateGraphics();
				Region region=new Region(r);
				gr.IntersectClip(region);
				try
				{
					Cell cell=SrcRep.GetBand(idxband).GetCell(idxcell);
					cell.PaintCell(gr,CellRect(idxband,idxcell),SelectedCellStyle,FocusedCellStyle,true,SrcRep.RenderingMode);
				}
				finally
				{
					gr.ResetClip();
				}
			}
		}

		public virtual void PaintBandTitle(Graphics gr,int IdxBand)
		{
			RectangleF r,textr;			
			Band band;

			if((FGutter==0)||(!((IdxBand>=0)&&(IdxBand<SrcRep.BandCount))))
				return;
			band=SrcRep.GetBand(IdxBand);
			r=BandClipRect(IdxBand);
			int Fright=FGutter+1;
			r=new RectangleF(new PointF(r.X,r.Y),new SizeF(Math.Abs(Fright-r.Left),Math.Abs(r.Top-r.Bottom)));
			
			textr=CellRect(IdxBand,0);
			int FLeft=5;
			float FTop=SrcRep.GetTops(IdxBand)-TopY+UserTop+(band.Height-Math.Abs(SrcRep.Font.Height)-3)/2-2+Generic.ToPix(SrcRep.TopMargin);
			Region region=new Region(r);
			gr.IntersectClip(region);
			System.Drawing.Font ffont;
			
			try
			{
				gr.FillRectangle(new SolidBrush(SystemColors.Control),r);				
				if(FShowBandTitle)
				{
					if(band.Selected)
					{
						ffont=new Font(SrcRep.Font.Name,SrcRep.Font.Size,SrcRep.Font.Style|FontStyle.Bold);	
						
						gr.DrawString(band.Name,ffont,new SolidBrush(Color.Black),
							FLeft-1,FTop+2);
					}
					else
					{
						ffont=new Font(SrcRep.Font.Name,SrcRep.Font.Size,FontStyle.Regular);

						gr.DrawString(band.Name,ffont,new SolidBrush(Color.Black),
							FLeft-1,FTop+2);
					}
				}
				else
				{
					DrawBandTitleEventArgs arg=new DrawBandTitleEventArgs();
					arg.IdxBand=IdxBand;
					arg.gr=gr;
					arg.r=r;
					if(DrawBandTitle!=null)
						DrawBandTitle(this,arg);
				}
				if(band.Selected)
				{
					gr.DrawLine(new Pen(SystemColors.ControlDark),r.Left + 0, r.Top,r.Left + 0,r.Bottom - 1);
					gr.DrawLine(new Pen(SystemColors.ControlDark),r.Left, r.Top,r.Right-3,r.Top);
					gr.DrawLine(new Pen(SystemColors.ControlLight),r.Left, r.Bottom-1,r.Right-3,r.Bottom - 1);
				}
				else
				{
					gr.DrawLine(new Pen(SystemColors.ControlLight),r.Left + 0, r.Top,r.Left + 0,r.Bottom - 1);
					gr.DrawLine(new Pen(SystemColors.ControlLight),r.Left, r.Top,r.Right-3,r.Top);
					gr.DrawLine(new Pen(SystemColors.ControlDark),r.Left, r.Bottom-1,r.Right-3,r.Bottom - 1);
				}
				gr.DrawLine(new Pen(Color.White),FGutter - 3, r.Top - 1,FGutter - 3, r.Bottom + 1);
				gr.DrawLine(new Pen(SystemColors.Control),FGutter - 2, r.Top - 1,FGutter - 2, r.Bottom + 1);
				gr.DrawLine(new Pen(Color.DarkGray),FGutter - 1, r.Top - 1,FGutter - 1, r.Bottom + 1);
			}
			finally
			{
				gr.ResetClip();
			}			
		}

		public RectangleF BandClipRect(int IdxBand)
		{
			RectangleF freturn;
			float FTop;
			if((IdxBand>=0)&&(IdxBand<SrcRep.BandCount))
			{
				freturn=BandRect(IdxBand);
				if(IdxBand>=FixedBands)
				{
					FTop=Math.Max(freturn.Top,SrcRep.GetTops(FixedBands));
					return new RectangleF(freturn.Left,FTop,freturn.Width,Math.Abs(freturn.Top-freturn.Bottom));
				}
				return freturn;
			}
			return new RectangleF(0,0,0,0);
		}

		protected RectangleF BandRect(int IdxBand)
		{
			float FRight,FLeft,FBottom,FTop;

			if((IdxBand>=0)&&(IdxBand<SrcRep.BandCount))
			{
				if(IdxBand<FixedBands)
				{
					FTop=SrcRep.GetTops(IdxBand);
					FBottom=FTop+SrcRep.GetBand(IdxBand).Height;
				}
				else
				{
					FTop=SrcRep.GetTops(IdxBand)-TopY+UserTop+Generic.ToPix(SrcRep.TopMargin);
					FBottom=FTop+SrcRep.GetBand(IdxBand).Height;
				}
				FLeft=0;
				FRight=Width;
				return new RectangleF(FLeft,FTop,Math.Abs(FRight-FLeft),Math.Abs(FTop-FBottom));
			}
			else
			{
				return new RectangleF(0,0,0,0);
			}
		}
		#endregion

		#region constructor
		public GridRep()
		{
			prn=new PrintDocument();
			prn.PrintPage+=new PrintPageEventHandler(PrintPage);
			SelectedCellStyle=SelectedCellStyle.Gray;
			FocusedCellStyle=FocusedCellStyle.Rect;
			SelList=new List("GridRep SelList");
			SrcRep=new Rep();
			SrcRep.OnBandChange+=new EventHandler(BandChange);
			SrcRep.OnCellChange+=new CellChangeEvent(CellChange);
			if(Width==0)
				Width=180;
			if(Height==0)
				Height=120;

			SetStyle(ControlStyles.UserPaint|ControlStyles.AllPaintingInWmPaint|ControlStyles.DoubleBuffer,true);

			if(FileSystem==null)
				FileSystem=new StandartFileSystem();
			LeftX=0;
			TopY=0;
			UserLeft=0;
			UserTop=0;
			printset=new PrinterSettings();
			SrcRep.NewWidth=827;
			SrcRep.NewHeight=1169;
			SrcRep.OldGridHeight=1169;
			SrcRep.OldGridWidth=827;
			pageset=new PageSettings();
			Old=this.Size;
		}
		#endregion

		#region a		
		public class a
		{
			public static float left, FixedTop;
			public static RectangleF r, rc;
			public const int pd = 4;
		}
		#endregion
	}	
		
		
	#endregion

	#region enums
	public enum RepOptions
	{
		Editing
	}

	public enum DialogCodes
	{
		DLGC_WANTARROWS			= 0x0001,
		DLGC_WANTTAB			= 0x0002,
		DLGC_WANTALLKEYS		= 0x0004,
		DLGC_WANTMESSAGE		= 0x0004,
		DLGC_HASSETSEL			= 0x0008,
		DLGC_DEFPUSHBUTTON		= 0x0010,
		DLGC_UNDEFPUSHBUTTON	= 0x0020,
		DLGC_RADIOBUTTON		= 0x0040,
		DLGC_WANTCHARS			= 0x0080,
		DLGC_STATIC				= 0x0100,
		DLGC_BUTTON				= 0x2000
	}

	public enum SelectedCellStyle
	{
		None,Gray,Selected
	}

	public enum FocusedCellStyle
	{
		None,Rect
	}

	public enum Zoom
	{
		hundred,fifty,seventyfive,hundredfifty,twohundred,wholepage,pagewidth
	}
	#endregion

	#region b
	public class b
	{
		public static int LeftMargin, TopMargin, RightMargin, BottomMargin;
		public static float rightmgn;
		public static int rLeft;
		public static RectangleF CellRect;
	}
	#endregion
}
