using System;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Drawing.Imaging;

namespace Windows.Forms.Reports.Export
{
	#region EventArgs
	public class SDPrintChildPanelEventArgs:EventArgs
	{
		public SDCanvas ACanvas;
		public int ACol;
		public int ARow;
		public Rectangle Rect;
	}

	public class SDPrintPanelEventArgs:EventArgs
	{
		public SDCanvas ACanvas;
		public Rectangle Rect;
	}

	public class SDPrintPageEventArgs:EventArgs
	{
		public SDCanvas ACanvas;
	}
	#endregion

	#region delegates
	public delegate void SDPrintChildPanelEvent(object sender,SDPrintChildPanelEventArgs arg);
	public delegate void SDPrintPanelEvent(object sender,SDPrintPanelEventArgs arg);
	public delegate void SDPrintPageEvent(object sender,SDPrintPageEventArgs arg);
	#endregion	

	#region enums
	public enum PenStyle
	{
		Dash,DashDot,DashDotDot,Dot,Solid
	}

	public enum PdfDestinationType
	{
		/// <summary>
		/// Display the page with position and size indicated by
		/// Left,Top and Zoom properties.
		/// </summary>
		XYZ,
		/// <summary>
		/// Fit the page to the window.
		/// </summary>
		Fit,
		/// <summary>
		/// Fit the width of the page to the window. Only the 
		/// Top property is used to determine the top position.
		/// </summary>
		FitH,
		/// <summary>
		/// Fit the height of the page to the window. Only the 
		/// Left property is used to determine the position of 
		/// the left edge of the window.
		/// </summary>
		FitV,
		/// <summary>
		/// Fit the rectangle specified by Left Top, Right,
		/// Bottom properties.
		/// </summary>
		FitR,
		/// <summary>
		/// Fit the page•fs bounding box to the window.
		/// </summary>
		FitB,
		/// <summary>
		/// Fit the width of the page•fs bounding box to the 
		/// window.
		/// </summary>
		FitBH,
		/// <summary>
		/// Fit the height of the page•fs bounding box to the 
		/// window.
		/// </summary>
		FitBV
	}

	public enum SdFontName
	{FixedWidth,Arial,TimesRoman}

	public enum SDAlignment
	{
		LeftJustify,RightJustify,Center
	}

	public enum PrintDirection
	{
		Horizontal,Vertical
	}

	public enum SDPageMode
	{
		/// <summary>
		/// Both of outline and thumbnail images invisible
		/// </summary>
		UseNone,
		/// <summary>
		/// Document outline visible
		/// </summary>
		UseOutlines, 
		/// <summary>
		/// Thumbnail images visible
		/// </summary>
		UseThumbs, 
		/// <summary>
		/// Full-screen mode, with no menu bar.
		/// </summary>
		FullScreen
	}

	public enum SDPageLayout
	{
		/// <summary>
		/// Display the pages one page at a time.
		/// </summary>
		SinglePage,
		/// <summary>
		/// Display the pages in one column.
		/// </summary>
		OneColumn,
		/// <summary>
		/// Display the pages in two columns, with odd-numbered 
		/// pages on the left.
		/// </summary>
		TwoColumnLeft,
		/// <summary>
		/// Display the pages in two columns, with odd-numbered 
		/// pages on the right.
		/// </summary>
		TwoColumnRight
	}
	#endregion
	
	#region SDViewerPreference
	[ToolboxItem(false)]
	public class SDViewerPreference:Component
	{
		#region class variables
		private bool FHideToolBar;
		private bool FHideMenubar;
		private bool FHideWindowUI;
		private bool FFitWindow;
		private bool FCenterWindow;
		#endregion

		#region class properties
		/// <summary>
		/// Specifies that the toolbar should be hidden.
		/// </summary>
		[DefaultValue(false)]
		public bool HideToolbar
		{
			get
			{
				return FHideToolBar;
			}
			set
			{
				FHideToolBar=value;
			}
		}
		
		/// <summary>
		/// Specifies that the menubar should be hidden.
		/// </summary>
		[DefaultValue(false)]
		public bool HideMenubar
		{
			get
			{
				return FHideMenubar;
			}
			set
			{
				FHideMenubar=value;
			}
		}

		/// <summary>
		/// Specifies that the interfeces of the document window 
		/// should be hidden.
		/// </summary>
		[DefaultValue(false)]
		public bool HideWindowUI
		{
			get
			{
				return FHideWindowUI;
			}
			set
			{
				FHideWindowUI=value;
			}
		}

		/// <summary>
		/// Specifies that the viewer should resize the 
		/// document-window to the size of the first displayed 
		/// page of the document.
		/// </summary>
		[DefaultValue(false)]
		public bool FitWindow
		{
			get
			{
				return FFitWindow;
			}
			set
			{
				FFitWindow=value;
			}
		}

		/// <summary>
		/// Specifies that the viewer-window positioned in the 
		/// center of the screen.
		/// </summary>
		[DefaultValue(false)]
		public bool CenterWindow
		{
			get
			{
				return FCenterWindow;
			}
			set
			{
				FCenterWindow=value;
			}
		}
		#endregion
	}
	#endregion
	
	#region SDCanvas
	public class SDCanvas
	{
		#region class variables
		PdfCanvas FCanvas;
		#endregion

		#region constructor
		public SDCanvas()
		{
			FCanvas=null;
		}
		#endregion

		#region class properties
		public long PageHeight
		{
			get
			{
				return PdfCanvas.PageHeight;
			}
		}

		public long PageWidth
		{
			get
			{
				return PdfCanvas.PageWidth;
			}
		}

		public PdfCanvas PdfCanvas
		{
			get
			{
				return FCanvas;
			}
			set
			{
				FCanvas=value;
			}
		}
		#endregion

		#region class methods
		public void SetCharSpace(float CharSpace)
		{
			PdfCanvas.SetCharSpace(CharSpace);
		}

		public void SetFont(string FontName,float Size)
		{
			PdfCanvas.SetFont(FontName,Size);
		}

		public void SetHorizontalScaling(short hScaling)
		{
			PdfCanvas.SetHorizantalScaling(hScaling);
		}

		public void SetLeading(float leading)
		{
			PdfCanvas.SetLeading(leading);
		}

		public void SetTextRenderingMode(TextRenderingMode mode)
		{
			PdfCanvas.SetTextRenderingMode(mode);
		}

		public void SetTextRise(short rise)
		{
			PdfCanvas.SetTextRise(rise);
		}

		public void SetWordSpace(float WordSpace)
		{
			PdfCanvas.SetWordSpace(WordSpace);
		}

		public void TextOut(float X,float Y,string Text)
		{
			PdfCanvas.TextOut(X,(float)(PdfCanvas.PageHeight-Y-PdfCanvas.Attribute.FontSize*0.85),Text);
		}

		public float TextWidth(string Text)
		{
			return PdfCanvas.TextWidth(Text);
		}

		public void TextRect(Rectangle ARect,string Text,SDAlignment Alignment,bool Clipping)
		{
			PdfCanvas.TextRect(Generic.PdfRect(ARect.Left,PdfCanvas.PageHeight-ARect.Top,
				ARect.Right,PdfCanvas.PageHeight-ARect.Bottom),Text,(PdfAlignment)Alignment,Clipping);
		}
		#endregion	
	}
	#endregion
	
	#region SDPage
	/// <summary>
	/// SDPage represents a page to print.
	/// Use SDPage to create a page to print. To create a page, 
	/// To print a page, call print method of SDReport with 
	/// SDPage object. Use Width and Height property to 
	/// determine the physical size of the page.
	/// </summary>
	[ToolboxItem(false)]
	[DefaultEvent("PrintPage")]
	public class SDPage:ScrollableControl
	{
		#region class events
		/// <summary>
		/// OnPrintPage is called when a page is printed. You 
		/// can use it to initialize any local variables.
		/// </summary>
		public event SDPrintPageEvent PrintPage;
		#endregion

		#region class variables
		PdfDoc FDoc;
		#endregion

		#region class methods
		protected override void OnPaint(PaintEventArgs e) 
		{
			SolidBrush brush = new SolidBrush(Color.White);
			e.Graphics.FillRectangle(brush,0,0,Width,Height);
			Font=new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			brush.Color=Color.Silver;
			
			int LineCount=0;
			int LinePos=0;
			while(LinePos<Width)
			{
				e.Graphics.DrawString(LineCount.ToString(),Font,brush,LinePos+1,1);
				LineCount++;
				LinePos=LineCount*Generic.LINE_PITCH/10;
			}

			LineCount=0;
			LinePos=0;
			while(LinePos<Height)
			{
				e.Graphics.DrawString(LineCount.ToString(),Font,brush,1,LinePos+1);
				LineCount++;
				LinePos=LineCount*Generic.LINE_PITCH/10;
			}
			brush.Color=Color.Black;
			e.Graphics.DrawString(Text,Font,brush,4,4);
		}

		protected override void OnTextChanged(EventArgs e)
		{
			this.Refresh();
		}

		public void Print(SDCanvas ACanvas)
		{
			SDPanel FPanel;
			SDPrintPageEventArgs arg=new SDPrintPageEventArgs();
			arg.ACanvas=ACanvas;

			ACanvas.PdfCanvas.PageHeight=Height;
			ACanvas.PdfCanvas.PageWidth=Width;
			if(PrintPage!=null)
				PrintPage(this,arg);
			for(int i=0;i<Controls.Count;i++)
			{
				if(Controls[i] is SDPanel)
				{
					FPanel=(SDPanel)Controls[i];
					FPanel.Print(ACanvas,new Rectangle(Controls[i].Location,Controls[i].Size));
				}
			}
		}
		#endregion

		#region constructor
		public SDPage()
		{
			Width=Generic.PDF_DEFAULT_PAGE_WIDTH;
			Height=Generic.PDF_DEFAULT_PAGE_HEIGHT;
			FDoc=new PdfDoc();
			FDoc.SetVirtualMode();
		}
		#endregion

		#region class properties
		[Browsable(false)]
		public PdfDoc InternalDoc
		{
			get
			{
				return FDoc;
			}
		}
		#endregion
	}
	#endregion

	#region SDOutlineRoot
	public class SDOutlineRoot:SDOutlineEntry
	{
		#region constructor
		public SDOutlineRoot(PdfDoc ADoc)
		{
			FData=ADoc.OutlineRoot;
			ADoc.OutlineRoot.Reference=this;
		}
		#endregion
	}
	#endregion

	#region SDOutlineEntry
	/// <summary>
	/// SDOutlineEntry is used to make outline tree of the 
	/// document.
	/// </summary>
	public class SDOutlineEntry
	{
		#region class variables
		public PdfOutlineEntry FData;
		#endregion

		#region class methods
		/// <summary>
		/// AddChild function add a new outline-entry at the 
		/// last sibling of the entry and return the new 
		/// outline-entry.
		/// </summary>
		/// <returns></returns>
		public SDOutlineEntry AddChild()
		{
			SDOutlineEntry FResult;
			FResult=new SDOutlineEntry();
			FResult.FData=this.FData.AddChild();
			FResult.FData.Reference=FResult;
			return FResult;
		}
		#endregion

		#region class properties
		/// <summary>
		/// Dest property is a SDDestination object which linkes
		/// to the entry.
		/// </summary>
		public SDDestination Dest
		{
			get
			{
				if(FData.Dest!=null)
					return (SDDestination)FData.Dest.Reference;
				else
					return null;
			}
			set
			{
				if(FData.Doc!=value.FData.Doc)
					throw new EPdfInvalidOperation("SetDest --internal docs are not equal.");
				FData.Dest=value.FData;
			}
		}

		/// <summary>
		/// Indicates the first entry of the children. If the 
		/// entry has no child entry, First property indicates 
		/// null.
		/// </summary>
		public SDOutlineEntry First
		{
			get
			{
				if(FData.First!=null)
					return (SDOutlineEntry)FData.First.Reference;
				else
					return null;
			}
		}

		/// <summary>
		/// Indicates the last entry of the children.
		/// </summary>
		public SDOutlineEntry Last
		{
			get
			{
				if(FData.Last!=null)
					return (SDOutlineEntry)FData.Last.Reference;
				else
					return null;
			}
		}

		/// <summary>
		/// Indicates the next sibiling entry of this entry.
		/// </summary>
		public SDOutlineEntry Next
		{
			get
			{
				if(FData.Next!=null)
					return (SDOutlineEntry)FData.Next.Reference;
				else
					return null;
			}
		}

		/// <summary>
		/// Use the Opened property to set whether the entry is 
		/// opened or not when the document is displaied.
		/// </summary>
		public bool Opened
		{
			get
			{
				return FData.Opened;
			}
			set
			{
				FData.Opened=value;
			}
		}

		/// <summary>
		/// Indicates the parent entry of this entry.
		/// </summary>
		public SDOutlineEntry Parent
		{
			get
			{
				if(FData.Parent!=null)
					return (SDOutlineEntry)FData.Parent.Reference;
				else
					return null;
			}
		}

		/// <summary>
		/// Indicates the previous sibiling entry of this entry.
		/// If the entry has no previous entry, Prev property 
		/// indicates null.
		/// </summary>
		public SDOutlineEntry Prev
		{
			get
			{
				if(FData.Prev!=null)
					return (SDOutlineEntry)FData.Prev.Reference;
				else
					return null;
			}
		}

		/// <summary>
		/// Use the Title property to modify the name of this 
		/// entry.
		/// </summary>
		public string Title
		{
			get
			{
				return FData.Title;
			}
			set
			{
				FData.Title=value;
			}
		}
		#endregion
	}
	#endregion

	#region SDPanel
	[ToolboxItem(false)]
	public class SDPanel:ScrollableControl
	{
		#region class methods
		protected override void OnPaint(PaintEventArgs e)
		{			
			Brush brush=new SolidBrush(Color.Black);
			e.Graphics.DrawString(Text,Font,brush,2,2);
			Pen pen=new Pen(Color.Green,5);
			pen.DashStyle=System.Drawing.Drawing2D.DashStyle.Dot;
			e.Graphics.DrawRectangle(pen,0,0,Width,Height);
			
			if(Parent is SDGridPanel)
			{
				SDGridPanel FPanel;
				FPanel=(SDGridPanel)Parent;
				Rectangle tmpRect=new Rectangle(0,0,FPanel.Width/FPanel.TableColCount,FPanel.Height/FPanel.TableRowCount);
				if(this.Location.X+Width>tmpRect.Size.Width)
					Location=new Point(tmpRect.Size.Width-Width,Location.Y);
				if(this.Location.Y+Height>tmpRect.Size.Height)
					Location=new Point(Location.Y,tmpRect.Size.Height-Height);				
			}
		}
		
		
		protected override void OnResize(EventArgs eventargs)
		{
			Refresh();
		}

		protected override void OnTextChanged(EventArgs e)
		{
			Refresh();
		}

		public virtual void Print(SDCanvas ACanvas,Rectangle ARect)
		{
			Rectangle tmpRect;
			SDPanel BaseRefPanel;
			SDItem BaseRefItem;

			for(int i=Controls.Count-1;i>-1;i--)
			{
				tmpRect=new Rectangle(ARect.Location.X+Controls[i].Location.X,
					ARect.Location.Y+Controls[i].Location.Y,
					Controls[i].Size.Width,Controls[i].Size.Height);				
				if(Controls[i] is SDPanel)
				{
					BaseRefPanel=(SDPanel)Controls[i];
					BaseRefPanel.Print(ACanvas,tmpRect);
				}
				else
				{
					if(Controls[i] is SDItem)
					{
						BaseRefItem=(SDItem)Controls[i];
						if(BaseRefItem.Printable)
							BaseRefItem.Print(ACanvas,tmpRect);
					}
				}
			}
		}	
		#endregion

		#region constructor
		public SDPanel()
		{
			Height=100;
			Width=185;
			BackColor=SystemColors.Window;
		}
		#endregion

		#region class porperties
		[Browsable(false)]
		public SDPage Page
		{
			get
			{
				if(Parent is SDPage)
					return (SDPage)Parent; 
				else
				{
					SDPanel freturn;
					freturn=(SDPanel)Parent;
					return freturn.Page;
				}
			}
		}
		#endregion
	}
	#endregion

	#region SDItem
	[ToolboxItem(false)]
	public class SDItem:Control
	{
		#region class variables
		bool FPrintable;
		#endregion

		#region class properties
		protected SDPage Page
		{
			get
			{
				SDPanel fpanel=(SDPanel)Parent;
				return fpanel.Page;
			}
		}

		/// <summary>
		/// Determines whether the control will be printed or not.
		/// </summary>
		[DefaultValue(true)]
		public bool Printable
		{
			get
			{
				return FPrintable;
			}
			set
			{
				FPrintable=value;
			}
		}
		#endregion

		#region class methods
		protected override void OnCreateControl()
		{			
			if (!(Parent is SDPanel))
				throw (new Exception("This item must set on SDPanel"));
			base.OnCreateControl();
		}

		protected override void OnTextChanged(EventArgs e)
		{
			Refresh();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			Refresh();
		}

		protected override void OnLocationChanged(EventArgs e)
		{
			Refresh();
		}

		protected SDPage GetPage()
		{
			SDPanel FPanel;
			FPanel=(SDPanel)Parent;
			return FPanel.Page;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if(Parent is SDGridPanel)
			{
				SDGridPanel FPanel;
				FPanel=(SDGridPanel)Parent;
				Rectangle tmpRect=new Rectangle(0,0,FPanel.Width/FPanel.TableColCount,FPanel.Height/FPanel.TableRowCount);
				
				if(this.Location.X+Width>tmpRect.Size.Width)
					Location=new Point(tmpRect.Size.Width-Width,Location.Y);
				if(this.Location.Y+Height>tmpRect.Size.Height)
					Location=new Point(Location.Y,tmpRect.Size.Height-Height);				
			}
		}

		protected PdfDoc GetInternalDoc()
		{
			return Page.InternalDoc;
		}

		public virtual void Print(SDCanvas ACanvas,Rectangle ARect)
		{
		}
		#endregion

		#region constructor
		public SDItem()
		{			
			Width=100;
			Height=30;
			FPrintable=true;
			
		}
		#endregion	
	}
	#endregion

	#region SDDestination
	/// <summary>
	/// Use the SDDestination class to set the location of the 
	/// display window on that page, and the zoom level.
	/// </summary>
	public class SDDestination
	{
		#region class variables
		public PdfDestination FData;
		#endregion

		#region constructor
		public SDDestination(PdfDestination AData)
		{
			FData=AData;
			AData.Reference=this;
		}
		#endregion

		#region class properties
		public long Left
		{
			get
			{
				return FData.Left;
			}
			set
			{
				FData.Left=value;
			}
		}

		public long Top
		{
			get
			{
				return FData.Top;
			}
			set
			{
				FData.Top=FData.PageHeight-value;
			}
		}

		public long Right
		{
			get
			{
				return FData.Right;
			}
			set
			{
				FData.Right=value;
			}
		}
		
		public long Bottom
		{
			get
			{
				return FData.Bottom;
			}
			set
			{
				FData.Bottom=FData.PageHeight-value;
			}
		}

		public float Zoom
		{
			get
			{
				return FData.Zoom;
			}
			set
			{
				FData.Zoom=value;
			}
		}

		/// <summary>
		/// The DestinationType property determines the type of 
		/// destination.
		/// </summary>
		public PdfDestinationType DestinationType
		{
			get
			{
				return FData.DestinationType;
			}
			set
			{
				FData.DestinationType=value;
			}
		}
		#endregion
	}
	#endregion

	#region SDLayoutPanel
	/// <summary>
	/// SDLayoutPanel is main building block of a page. To make 
	/// a page, put SDPanel on the SDPage component and put 
	/// Item component (SDItem, SDImage and so on) on the 
	/// SDPanel.
	/// </summary>
	
	[DefaultEvent("BeforePrint")]
	public class SDLayoutPanel:SDPanel
	{
		#region class events
		/// <summary>
		/// BeforePrint is called before a page is about to be 
		/// printed. Typical use of this event is to set any 
		/// variables(SDText, SDImage).
		/// </summary>
		public event SDPrintPanelEvent BeforePrint;
		/// <summary>
		/// AfterPrint is called after a page was printed.
		/// </summary>
		public event SDPrintPanelEvent AfterPrint;
		#endregion

		#region class methods
		public override void Print(SDCanvas ACanvas,Rectangle ARect)
		{
			SDPrintPanelEventArgs arg=new SDPrintPanelEventArgs();
			arg.ACanvas=ACanvas;
			arg.Rect=ARect;

			if(BeforePrint!=null)
				BeforePrint(this,arg);
			base.Print(ACanvas,ARect);
			if(AfterPrint!=null)
				AfterPrint(this,arg);
		}

		protected override void OnCreateControl()
		{
			if (!((Parent is SDPage)||(Parent is SDPanel)))
				throw (new Exception("SDLayoutPanel can not set on "+this.Parent.GetType().ToString()));
		}
		#endregion
	}
	#endregion

	#region SDLabel
	/// <summary>
	/// SDLabel is used to print a single line text.
	/// </summary>
	[DefaultProperty("Text")]
	public class SDLabel:SDCustomLabel
	{
		#region class variables
		bool FAlignJustified;
		SDAlignment FAlignment;
		bool FClipping;
		#endregion

		#region class methods
		public override void Print(SDCanvas ACanvas,Rectangle ARect)
		{
			if(Text.Length==0)
				return;
			SetCanvasProperties(ACanvas.PdfCanvas);
			ACanvas.TextRect(ARect,Text,FAlignment,Clipping);
		}

		protected override void OnPaint(PaintEventArgs e)
		{			
			PdfCanvas pdfcanvas;
			string FText;
			float TmpWidth;
			int XPos=0;
			Font AFont;

			if(Text.Length==0)
				return;
			pdfcanvas=GetInternalDoc().Canvas;
			SetCanvasProperties(pdfcanvas);
			FText=Text;
			AFont=this.Font;
			Brush brush=new SolidBrush(this.ForeColor);

			TmpWidth=pdfcanvas.TextWidth(FText);

			switch(FAlignment)
			{
				case SDAlignment.Center:
					XPos=(int)((Width-TmpWidth)/2);
					break;
				case SDAlignment.RightJustify:
					XPos=Width-(int)TmpWidth-3;
					break;
				case SDAlignment.LeftJustify:
					XPos=0;
					break;
			}
			InternalTextOut(AFont,e,brush,pdfcanvas,FText,XPos,0);
			base.OnPaint(e);
		}

		void SetCanvasProperties(PdfCanvas ACanvas)
		{
			float TmpWidth;
			float TmpCharSpace;
			int CharCount;
			
			ACanvas.SetFont(GetFontClassName(),FontSize);
			ACanvas.SetRGBFillColor(FontColor);
			ACanvas.SetWordSpace(WordSpace);
			if(AlignJustified)
			{
				ACanvas.SetCharSpace(0);
				TmpWidth=ACanvas.TextWidth(Text);
				CharCount=Generic.GetCharCount(Text);
				if(CharCount>1)
					TmpCharSpace=(Width-TmpWidth)/(CharCount);
				else
					TmpCharSpace=0;
				if(TmpCharSpace>0)
					ACanvas.SetCharSpace(TmpCharSpace);
			}
			else
				ACanvas.SetCharSpace(CharSpace);
		}
		#endregion

		#region class properties
		/// <summary>
		/// Determines whether adjustment the char width to fit 
		/// the text to full-justified.
		/// </summary>
		[DefaultValue(false)]
		public bool AlignJustified
		{
			get
			{
				return FAlignJustified;
			}
			set
			{
				if(value!=FAlignJustified)
				{
					FAlignJustified=value;
					Refresh();
				}
			}
		}

		/// <summary>
		/// Controls the horizontal placement of the text within
		/// the label.
		/// </summary>
		[DefaultValue(SDAlignment.LeftJustify)]
		public SDAlignment Alignment
		{
			get
			{
				return FAlignment;
			}
			set
			{
				if(value!=FAlignment)
				{
					FAlignment=value;
					Refresh();
				}
			}
		}

		[DefaultValue(false)]
		public bool Clipping
		{
			get
			{
				return FClipping;
			}
			set
			{
				FClipping=value;
			}
		}
		#endregion
	}
	#endregion

	#region SDCustomLabel
	[ToolboxItem(false)]
	public class SDCustomLabel:SDItem
	{
		#region class variables
		SdFontName FFontName;
		float FFontSize;
		bool FFontBold;
		bool FFontItalic;
		Font FFont;
		Color FColor;
		Color FFontColor;
		float FWordSpace;
		float FCharSpace;
		#endregion

		#region class properties
		/// <summary>
		/// Identifies the typeface of the font.
		/// </summary>
		public SdFontName FontName
		{
			get
			{
				return FFontName;
			}
			set
			{
				if(FFontName!=value)
				{
					FFontName=value;
					SetFontStyle();
					Refresh();
				}
			}
		}

		/// <summary>
		/// Specifies whether the font is boldfaced or not.
		/// </summary>
		[DefaultValue(false)]
		public bool FontBold
		{
			get
			{
				return FFontBold;
			}
			set
			{
				if(FFontBold!=value)
				{
					FFontBold=value;
					SetFontStyle();
					Refresh();
				}
			}
		}

		[DefaultValue(false)]
		public bool FontItalic
		{
			get
			{
				return FFontItalic;
			}
			set
			{
				if(FFontItalic!=value)
				{
					FFontItalic=value;
					SetFontStyle();
					Refresh();
				}
			}
		}

		/// <summary>
		/// Specifies the height of the font in points.
		/// </summary>
		public float FontSize
		{
			get
			{
				return FFontSize;
			}
			set
			{
				if((FFontSize!=value)&&(value>0))
				{
					FFontSize=value;
					SetFontStyle();
					Refresh();
				}
			}
		}

		[Browsable(false)]
		public override Color ForeColor
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

		/// <summary>
		/// Specifies the color of the text.
		/// </summary>
		public Color FontColor
		{
			get
			{
				return FFontColor;
			}
			set
			{
				int i=value.ToArgb();
				if(i>16777215)
					throw (new EPdfInvalidValue("The color you selected is not allowed."));
				if(value!=FFontColor)
				{
					FFontColor=value;
					FColor=value;
					Refresh();
				}
			}
		}

		/// <summary>
		/// Specifies the word spacing of the text.
		/// </summary>
		public float WordSpace
		{
			get
			{
				return FWordSpace;
			}
			set
			{
				if((value!=FWordSpace)&&(value>=0))
				{
					FWordSpace=value;
					Refresh();
				}
			}
		}

		public float CharSpace
		{
			get
			{
				return FCharSpace;
			}
			set
			{
				if(value!=FCharSpace)
				{
					FCharSpace=value;
					Refresh();
				}
			}
		}

		[Browsable(false)]
		public override Font Font
		{
			get
			{
				return FFont;
			}
			set
			{
				FFont=value;
			}
		}
		#endregion

		#region constructor
		public SDCustomLabel()
		{
			FFontName=SdFontName.Arial;
			FFontSize=12;
			FFontBold=false;
			FFontItalic=false;
			FFont=new Font(Generic.ITEM_FONT_NAMES[(int)FFontName],(FFontSize*0.75F));			
			FontColor=Color.Black;	
			FontSize=12;			
		}
		#endregion

		#region class methods
		public void SetFontStyle()
		{
			if(FFontItalic)
			{
				if(FFontBold)
					FFont=new Font(Generic.ITEM_FONT_NAMES[(int)FFontName],(FFontSize*0.75F),(FontStyle.Bold|FontStyle.Italic),GraphicsUnit.Point);
				else
					FFont=new Font(Generic.ITEM_FONT_NAMES[(int)FFontName],(FFontSize*0.75F),FontStyle.Italic,GraphicsUnit.Point);
			}
			else
			{
				if(FFontBold)
					FFont=new Font(Generic.ITEM_FONT_NAMES[(int)FFontName],(FFontSize*0.75F),FontStyle.Bold,GraphicsUnit.Point);
				else
					FFont=new Font(Generic.ITEM_FONT_NAMES[(int)FFontName],(FFontSize*0.75F),GraphicsUnit.Point);
			}
		}

		public float InternalTextOut(Font AFont,PaintEventArgs e,Brush brush,PdfCanvas ApdfCanvas,
			string S,int X,int Y)
		{
			float Pos;
			int i;
			string Word;
			int ln;

			i=0;
			Pos=X;
			ln=S.Length;

			if((ln>=2)&&(S[ln-1]==(char)10)&&(S[ln-2]==(char)13))
				ln=ln-2;
			for(i=0;i<ln;i++)
			{
				Word=S[i].ToString();
				e.Graphics.DrawString(Word,AFont,brush,Pos,Y);
				Pos=Pos+ApdfCanvas.TextWidth(Word)+ApdfCanvas.Attribute.CharSpace;
				if(S[i]==' ')
					Pos=Pos+FWordSpace;				
			}
	
			return Pos;
		}

		protected string GetFontClassName()
		{
			if(FFontBold)
			{
				if(FFontItalic)
					return Generic.PDFFONT_CLASS_BOLDITALIC_NAMES[(int)FFontName];
				else
					return Generic.PDFFONT_CLASS_BOLD_NAMES[(int)FFontName];
			}
			else
			{
				if(FFontItalic)
					return Generic.PDFFONT_CLASS_ITALIC_NAMES[(int)FFontName];
				else
					return Generic.PDFFONT_CLASS_NAMES[(int)FFontName];
			}
		}
		#endregion	
	}
	#endregion

	#region SDGridPanel
	/// <summary>
	/// SDGridPanel is used to print a table. A typical use of 
	/// SDGridPanel is to print a table(like a database data). 
	/// set TableRowCount and TableColCount property to define 
	/// row count and column count.
	/// </summary>
	[DefaultEvent("BeforePrint")]
	public class SDGridPanel:SDPanel
	{
		#region class events
		/// <summary>
		/// BeforePrint is called before a page is about to be 
		/// printed. Typical use of this event is to set any 
		/// variables(SDText, SDImage).
		/// </summary>
		public event SDPrintPanelEvent BeforePrint;
		/// <summary>
		/// AfterPrint is called after a page was printed.
		/// </summary>
		public event SDPrintPanelEvent AfterPrint;
		/// <summary>
		/// AfterPrint is called every after panels were printed.
		/// </summary>
		public event SDPrintChildPanelEvent AfterPrintChild;
		/// <summary>
		/// BeforePrintChild is called every before child panels
		/// are about to be printed. Typical use of this event 
		/// is to set any variables(SDText, SDImage).
		/// </summary>
		public event SDPrintChildPanelEvent BeforePrintChild;
		#endregion
		
		#region class variables
		int FColCount;
		int FRowCount;
		PrintDirection FPrintDirection;
		#endregion

		#region constructor
		public SDGridPanel()
		{
			FColCount=1;
			FRowCount=1;				
		}
		#endregion

		#region class methods
		protected override void OnPaint(PaintEventArgs e)
		{
			int tmpWidth;
			int tmpHeight;					

			if((FColCount>1)||(FRowCount>1))
			{
				Brush brush=new SolidBrush(Generic.PROTECT_AREA_COLOR);
				e.Graphics.FillRectangle(brush,0,0,Width,Height);
			}
			tmpWidth=(int)(Width/FColCount);
			tmpHeight=(int)(Height/FRowCount);			
			Brush WhiteBrush=new SolidBrush(Color.White);
			e.Graphics.FillRectangle(WhiteBrush,0,0,tmpWidth,tmpHeight);

			Brush BlueBrush=new SolidBrush(Color.Blue);
			Pen pen=new Pen(BlueBrush,1);
			pen.DashStyle=System.Drawing.Drawing2D.DashStyle.Dot;
			for(int i=0;i<FRowCount;i++)
			{
				tmpHeight=(int)(Height*i/FRowCount);
				if(tmpHeight==Height)
					tmpHeight--;
				e.Graphics.DrawLine(pen,new Point(0,tmpHeight),new Point(Width,tmpHeight));
			}
			for(int i=0;i<FColCount;i++)
			{
				tmpWidth=(int)(Width*i/FColCount);
				if(tmpWidth==Width)
					tmpWidth--;
				e.Graphics.DrawLine(pen,new Point(tmpWidth,0),new Point(tmpWidth,Height));
			}
			base.OnPaint(e);
		}

		public override void Print(SDCanvas ACanvas,Rectangle ARect)
		{
			SDPrintPanelEventArgs arg=new SDPrintPanelEventArgs();
			arg.ACanvas=ACanvas;
			arg.Rect=ARect;

			if(BeforePrint!=null)
				BeforePrint(this,arg);
			if(FPrintDirection==PrintDirection.Vertical)
				for(int i=0;i<FColCount;i++)
					for(int j=0;j<FRowCount;j++)
						PrintSubPanel(j,i,ACanvas,ARect);
			else
				for(int j=0;j<FRowCount;j++)
					for(int i=0;i<FColCount;i++)
						PrintSubPanel(i,j,ACanvas,ARect);
			if(AfterPrint!=null)
				AfterPrint(this,arg);
		}

		void PrintSubPanel(int ACol,int ARow,SDCanvas ACanvas,Rectangle ARect)
		{
			Rectangle Rect;			
			Rect=Generic.GridPanelBounds(TableColCount,TableRowCount,Location.X,Location.Y,Width,Height);
			int OffsetX=(int)(Width*ACol/TableColCount);
			int OffsetY=(int)(Height*ARow/TableRowCount);
			Rect.Offset(OffsetX,OffsetY);

			SDPrintChildPanelEventArgs arg=new SDPrintChildPanelEventArgs();
			arg.ACanvas=ACanvas;
			arg.ACol=ACol;
			arg.ARow=ARow;
			arg.Rect=Rect;
			if(BeforePrintChild!=null)
				BeforePrintChild(this,arg);
			base.Print(ACanvas,Rect);
			if(AfterPrintChild!=null)
				AfterPrintChild(this,arg);
		}

		protected override void OnCreateControl()
		{
			if (!((Parent is SDPage)||(Parent is SDPanel)))
				throw (new Exception("SDGridPanel can not set on "+this.Parent.GetType().ToString()));
		}
		#endregion

		#region class properties
		/// <summary>
		/// TableColCount determines how many numbers of columns 
		/// in this panel.
		/// </summary>
		public int TableColCount
		{
			get
			{
				return FColCount;
			}
			set
			{
				if(value!=FColCount)
				{
					FColCount=value;
					if((value<1)||((int)(Width/value)<Generic.MIN_PANEL_SIZE))
						throw(new Exception("Invalid colcount"));                    
					Refresh();
				}
			}
		}

		/// <summary>
		/// TableRowCount determines how many numbers of rows in
		/// this panel.
		/// </summary>
		public int TableRowCount
		{
			get
			{
				return FRowCount;
			}
			set
			{
				if(value!=FRowCount)
				{
					FRowCount=value;
					if((value<1)||((int)(Height/value)<Generic.MIN_PANEL_SIZE))
						throw(new Exception("Invalid rowcount"));					
					Refresh();
				}
			}
		}

		/// <summary>
		/// PrintDirection determins the direction of printing 
		/// grid.
		/// </summary>
		[DefaultValue(PrintDirection.Horizontal)]
		public PrintDirection PrintDirection
		{
			get
			{
				return FPrintDirection;
			}
			set
			{
				FPrintDirection=value;
			}
		}
		#endregion
	}
	#endregion

	#region SDText
	/// <summary>
	/// SDText is used to print a text.
	/// </summary>
	
	[DefaultProperty("Lines")]
	public class SDText:SDCustomLabel
	{
		#region class variables
		string[] FLines;
		float FLeading;
		bool FWordWrap;
		string FNodeValue;
		#endregion
	
		#region class properties
		/// <summary>
		/// Determines whether the text inserts soft carriage 
		/// returns so text wraps at the right margin.
		/// </summary>
		[DefaultValue(false)]
		public bool WordWrap
		{
			get
			{
				return FWordWrap;
			}
			set
			{
				if(value!=FWordWrap)
				{
					FWordWrap=value;
					Refresh();
				}
			}
		}

		/// <summary>
		/// Contains the individual lines of text.
		/// </summary>
		public string[] Lines
		{
			get
			{				
				return FLines;
			}
			set
			{
				FLines=value;													
				Refresh();				
			}
		}

		[Browsable(false)]
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

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string Text
		{
			get
			{
				return FLines.ToString();
			}
			set
			{
				string s;
				s=FLines.ToString();
				s=value;
			}
		}

		/// <summary>
		/// Specifies the text leading.
		/// </summary>
		public float Leading
		{
			get
			{
				return FLeading;
			}
			set
			{
				if((value!=FLeading)&&(value>=0))
				{
					FLeading=value;
					Refresh();
				}
			}
		}
		#endregion

		#region constructor
		public SDText()
		{
			FLines=new string[1];			
			FLeading=14F;			
		}
		#endregion

		#region class methods
		public override void Print(SDCanvas ACanvas,Rectangle ARect)
		{
			ACanvas.PdfCanvas.SetFont(GetFontClassName(),FontSize);
			ACanvas.PdfCanvas.SetRGBFillColor(FontColor);
			ACanvas.PdfCanvas.SetCharSpace(CharSpace);
			ACanvas.PdfCanvas.SetWordSpace(WordSpace);
			ACanvas.PdfCanvas.SetLeading(Leading);
			
			ACanvas.PdfCanvas.MultilineTextRect(Generic.PdfRect(ARect.Left,
				GetPage().Height-ARect.Top,ARect.Right,GetPage().Height-ARect.Bottom),
				Generic.DrawGetText(FLines).Trim(),WordWrap);
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if(FLines.Length!=0)
				if(FLines[0]==null)
					FLines.SetValue(Name,0);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			int i;
			string S1, S2;
			int ln;
			PdfCanvas PdfCanvas;
			string FText;
			bool ForceReturn;
			int FTop=0;
			Rectangle ARect=new Rectangle(Location,Size);
			float XPos;
			float tmpWidth;
			float tmpXPos;
		
			Brush brush=new SolidBrush(this.ForeColor);
			PdfCanvas=GetInternalDoc().Canvas;

			PdfCanvas.SetFont(GetFontClassName(),FontSize);
			PdfCanvas.SetLeading(Leading);
			PdfCanvas.SetWordSpace(WordSpace);
			PdfCanvas.SetCharSpace(CharSpace);

			FText=Generic.DrawGetText(Lines);
			i=0;
			S2=PdfCanvas.GetNextWord(FText,ref i);
			XPos=ARect.Left+PdfCanvas.TextWidth(S2);
			if((S2!="")&&(S2[S2.Length-1]==' '))
				XPos=XPos+WordSpace;
			
			while(i<FText.Length)
			{
				ln=S2.Length-1;
				if((ln>=2)&&(S2[ln]==(char)10)&&(S2[ln-1]==(char)13))
				{
					S2=S2.Substring(0,ln-1);
					ForceReturn=true;
				}
				else
					ForceReturn=false;
				S1=PdfCanvas.GetNextWord(FText,ref i);
				tmpWidth=PdfCanvas.TextWidth(S1);
				tmpXPos=XPos+tmpWidth;
				
				if(((FWordWrap)&(tmpXPos>ARect.Right))|(ForceReturn))
				{
					if(S2!="")
						InternalTextOut(Font,e,brush,PdfCanvas,S2,0,FTop);
					S2="";					
					FTop=(int)Leading+FTop;	
					if(FTop>ARect.Bottom-FontSize)
						break;
					XPos=ARect.Left;
				}
				XPos=XPos+tmpWidth;
				if(S1[S1.Length-1]==' ')
					XPos=XPos+WordSpace;
				S2=S2+S1;
			}
			if(S2!="")				
				InternalTextOut(Font,e,brush,PdfCanvas,S2,0,FTop);
			
			Pen pen=new Pen(Color.Navy,2);
			pen.DashStyle=System.Drawing.Drawing2D.DashStyle.Dot;
			e.Graphics.DrawRectangle(pen,0,0,Width,Height);
			base.OnPaint(e);
		}
		#endregion	
	}
	#endregion

	#region SDShape
	public class SDShape:SDItem
	{
		#region class variables
		Color FLineColor;
		public Color FFillColor;
		PenStyle FLineStyle;
		float FLineWidth;
		#endregion

		#region constructor
		public SDShape()
		{
			FLineColor=Color.Black;
			FFillColor=Color.Transparent;
		}
		#endregion

		#region class properties
		/// <summary>
		/// FillColor determines fill style for the shape.
		/// </summary>
		[Browsable(true)]
		public virtual Color FillColor
		{
			get
			{
				return FFillColor;
			}
			set
			{
				if(value!=FFillColor)
				{
					FFillColor=value;
					Refresh();
				}
			}
		}

		/// <summary>
		/// LineColor determines color of the lines for the shape
		/// </summary>
		public Color LineColor
		{
			get
			{
				return FLineColor;
			}
			set
			{
				if(value!=FLineColor)
				{
					FLineColor=value;
					Refresh();
				}
			}
		}

		/// <summary>
		/// LineStyle determines the style in which the pen 
		/// draws lines.
		/// </summary>
		public PenStyle LineStyle
		{
			get
			{
				return FLineStyle;
			}
			set
			{
				if(value!=FLineStyle)
				{
					FLineStyle=value;
					Refresh();
				}
			}
		}

		public float LineWidth
		{
			get
			{
				return FLineWidth;
			}
			set
			{
				if((value!=FLineWidth)&&(value>=0))
				{
					FLineWidth=value;
					Refresh();
				}
			}
		}
		#endregion

		#region class methods
		protected void SetDash(PdfCanvas ACanvas,PenStyle APattern)
		{			
			switch(APattern)
			{
				case PenStyle.Solid:
					byte[] FSolid={0};
					ACanvas.SetDash(FSolid,0);
					break;
				case PenStyle.Dash:
					byte[] FDash={16,8};
					ACanvas.SetDash(FDash,0);
					break;
				case PenStyle.DashDot:
					byte[] FDashDot={8, 7, 2, 7};
					ACanvas.SetDash(FDashDot,0);
					break;
				case PenStyle.DashDotDot:
					byte[] FDashDotDot={8, 4, 2, 4, 2, 4};
					ACanvas.SetDash(FDashDotDot,0);
					break;
				case PenStyle.Dot:
					byte[] FDot={3};
					ACanvas.SetDash(FDot,0);
					break;
			}
		}
		#endregion
	}
	#endregion

	#region SDRect
	/// <summary>
	/// SDRect is used to draw rectangles and lines on a report.
	/// </summary>
	
	[DefaultProperty("LineStyle")]
	public class SDRect:SDShape
	{
		#region class variables
		bool FDrawLine;
		#endregion

		#region class properties
		/// <summary>
		/// Draw vertical lines
		/// </summary>
		[DefaultValue(false)]
		public bool DrawLine
		{
			get
			{
				return FDrawLine;
			}
			set
			{
				if(value!=FDrawLine)
				{
					FDrawLine=value;
					Refresh();
				}
			}
		}
		#endregion

		#region class methods
		protected override void OnPaint(PaintEventArgs e)
		{
			Brush brush=new SolidBrush(LineColor);
			Pen pen=new Pen(brush);			
			pen.DashStyle=Generic.PenStyleToDashStyle((int)LineStyle);
			pen.Width=LineWidth;
			if(DrawLine==true)
			{
				Height=(int)LineWidth+1;				
				e.Graphics.DrawLine(pen,0,LineWidth/2,Width,LineWidth/2);
			}
			else
			{
				if(LineColor==Color.Transparent)
				{
					brush=new SolidBrush(FillColor);
					e.Graphics.FillRectangle(brush,0,0,Width,Height);
				}
				if(LineWidth>=2)
				{
					e.Graphics.DrawRectangle(pen,(float)(LineWidth/2),(float)(LineWidth/2),(float)(Width-LineWidth),(float)(Height-LineWidth));	
					brush=new SolidBrush(FillColor);
					e.Graphics.FillRectangle(brush,(float)(LineWidth),(float)(LineWidth),(float)(Width-(LineWidth*2)),(float)(Height-(2*LineWidth)));
				}
				else
				{
					e.Graphics.DrawRectangle(pen,0,0,Width-1,Height-1);
					brush=new SolidBrush(FillColor);
					e.Graphics.FillRectangle(brush,1,1,Width-2,Height-2);
				}
			}
			base.OnPaint(e);
		}		

		public override void Print(SDCanvas ACanvas,Rectangle ARect)
		{
			int PageHeight;
			int FBottom,FRight,FTop,FLeft;
			FRight=ARect.Right;
			FLeft=ARect.Left;

			PageHeight=GetPage().Height;
			FTop=PageHeight-ARect.Top;
			if(Height>1)
				FBottom=PageHeight-ARect.Bottom+1;
			else
				FBottom=PageHeight-ARect.Bottom;
			if(Width>1)
				FRight=ARect.Right-1;
			if((Height<=1)&&(Width<=1))
				return;
			if(LineColor==Color.Transparent)
				if((Height<=1)&&(Width<=1))
					return;
			SetDash(ACanvas.PdfCanvas,LineStyle);
			ACanvas.PdfCanvas.MoveTo(FLeft,FTop);
			if(Width>1)
			{
				ACanvas.PdfCanvas.LineTo(FRight,FTop);
				if((Height>1)&&(DrawLine==false))
					ACanvas.PdfCanvas.LineTo(FRight,FBottom);
			}
			if((Height>1)&&(DrawLine==false))
				ACanvas.PdfCanvas.LineTo(FLeft,FBottom);
			if((FillColor!=Color.Transparent)&&(Width>1)&&(Height>1))
				ACanvas.PdfCanvas.SetRGBFillColor(FillColor);
			if(LineColor!=Color.Transparent)
			{
				ACanvas.PdfCanvas.SetRGBStrokeColor(LineColor);
				ACanvas.PdfCanvas.SetLineWidth(LineWidth);
			}

			if((FillColor!=Color.Transparent)&&(DrawLine==false))
			{
				if((Width>1)&&(Height>1))
				{
					if(LineColor!=Color.Transparent)
						ACanvas.PdfCanvas.ClosePathFillStroke();
					else
					{
						ACanvas.PdfCanvas.ClosePath();
						ACanvas.PdfCanvas.Fill();
					}
				}
				else
				{
					ACanvas.PdfCanvas.Stroke();
					ACanvas.PdfCanvas.NewPath();
				}				
			}
			else
			{
				if((Width>1)&&(Height>1)&&(DrawLine==false))
					ACanvas.PdfCanvas.ClosePathStroke();
				else
				{
					ACanvas.PdfCanvas.Stroke();
					ACanvas.PdfCanvas.NewPath();
				}
			}			
		}
		#endregion
	}
	#endregion

	#region SDEllipse
	/// <summary>
	/// SDEllipse is used to draw ellipse on a report.
	/// </summary>
	[DefaultProperty("LineStyle")]
	public class SDEllipse:SDShape
	{
		#region class methods
		protected override void OnPaint(PaintEventArgs e)
		{
			Brush brush=new SolidBrush(LineColor);
			Pen pen=new Pen(brush);			
			pen.DashStyle=Generic.PenStyleToDashStyle((int)LineStyle);
			pen.Width=LineWidth;

			if(LineColor==Color.Transparent)
			{
				brush=new SolidBrush(FillColor);
				e.Graphics.FillEllipse(brush,0,0,Width,Height);
			}
			if(LineWidth>=2)
			{
				e.Graphics.DrawEllipse(pen,(float)(LineWidth/2),(float)(LineWidth/2),(float)(Width-LineWidth),(float)(Height-LineWidth));	
				brush=new SolidBrush(FillColor);
				e.Graphics.FillEllipse(brush,(float)(LineWidth),(float)(LineWidth),(float)(Width-(LineWidth*2)),(float)(Height-(2*LineWidth)));
			}
			else
			{
				e.Graphics.DrawEllipse(pen,0,0,Width-1,Height-1);
				brush=new SolidBrush(FillColor);
				e.Graphics.FillEllipse(brush,1,1,Width-2,Height-2);
			}
			base.OnPaint(e);
		}

		public override void Print(SDCanvas ACanvas,Rectangle ARect)
		{
			int PageHeight;
			int FBottom,FRight,FTop,FLeft;
			FRight=ARect.Right;
			FLeft=ARect.Left;

			PageHeight=GetPage().Height;
			FTop=PageHeight-ARect.Top;
			if(Height>1)
				FBottom=PageHeight-ARect.Bottom+1;
			else
				FBottom=PageHeight-ARect.Bottom;
			if(Width>1)
				FRight=ARect.Right-1;
			if((Height<=1)&&(Width<=1))
				return;
			if(LineColor==Color.Transparent)
				if((Height<=1)&&(Width<=1))
					return;
			SetDash(ACanvas.PdfCanvas,LineStyle);
			ACanvas.PdfCanvas.Ellipse(FLeft,FTop,FRight-FLeft,FBottom-FTop);
			
			if((FillColor!=Color.Transparent)&&(Width>1)&&(Height>1))
				ACanvas.PdfCanvas.SetRGBFillColor(FillColor);
			if(LineColor!=Color.Transparent)
			{
				ACanvas.PdfCanvas.SetRGBStrokeColor(LineColor);
				ACanvas.PdfCanvas.SetLineWidth(LineWidth);
			}

			if(FillColor!=Color.Transparent)
			{
				if((Width>1)&&(Height>1))
				{
					if(LineColor!=Color.Transparent)
						ACanvas.PdfCanvas.ClosePathFillStroke();
					else
					{
						ACanvas.PdfCanvas.ClosePath();
						ACanvas.PdfCanvas.Fill();
					}
				}
				else
				{
					ACanvas.PdfCanvas.Stroke();
					ACanvas.PdfCanvas.NewPath();
				}				
			}
			else
			{
				if((Width>1)&&(Height>1))
					ACanvas.PdfCanvas.ClosePathStroke();
				else
				{
					ACanvas.PdfCanvas.Stroke();
					ACanvas.PdfCanvas.NewPath();
				}
			}			
		}
		#endregion
	}
	#endregion

	#region SDImage
	/// <summary>
	/// Use of SDImage to print a image. SDImage only support 
	/// bitmap image.
	/// </summary>
	[DefaultProperty("Picture")]
	public class SDImage:SDItem
	{
		#region class variables
		protected Bitmap FPicture;
		protected bool FSharedImage;
		protected bool FStretch;
		#endregion

		#region constructor
		public SDImage()
		{
			FSharedImage=true;
			FStretch=true;
		}
		#endregion
		
		#region class properties
		/// <summary>
		/// Specifies the image that appears on the control.
		/// </summary>
		public virtual Bitmap Picture
		{
			get
			{
				return FPicture;
			}
			set
			{				
				if((value==null)||(value.RawFormat.Guid==ImageFormat.Bmp.Guid))
				{
					FPicture=value;
					Refresh();
				}
				else
					throw(new Exception("Only bitmap image is allowed."));
			}
		}

		/// <summary>
		/// Determines whether the image data will be shared in 
		/// the document or not. if this property is set true, 
		/// the PDF file has only one image, This means disk 
		/// capacity can be saved. But if the image of each page 
		/// is different, SharedImage property must be set false.
		/// </summary>
		[DefaultValue(true)]
		public bool SharedImage
		{
			get
			{
				return FSharedImage;
			}
			set
			{
				FSharedImage=value;
			}
		}

		/// <summary>
		/// Determines whether resizing the height and width of 
		/// the image to fit to the client area or not.
		/// </summary>
		[DefaultValue(true)]
		public bool Stretch
		{
			get
			{
				return FStretch;
			}
			set
			{
				if(value==FStretch)
					return;
				FStretch=value;
				Refresh();
			}
		}
		#endregion

		#region class methods
		protected override void OnPaint(PaintEventArgs e)
		{
			Image pThumbnail;
			if(FPicture==null)
			{
				Brush brush=new SolidBrush(Color.Black);
				e.Graphics.DrawString(Text,Font,brush,2,2);
				Pen pen=new Pen(Color.Green,5);
				pen.DashStyle=System.Drawing.Drawing2D.DashStyle.Dot;
				e.Graphics.DrawRectangle(pen,0,0,Width,Height);
			}
			else
			{
				if(Stretch)
				{
					pThumbnail=Picture.GetThumbnailImage(Width,Height,null,new IntPtr());
					e.Graphics.DrawImage(pThumbnail,0,0,pThumbnail.Width,pThumbnail.Height);
				}
				else
					e.Graphics.DrawImage(Picture,0,0);
			}
			base.OnPaint(e);
		}

		public override void Print(SDCanvas ACanvas,Rectangle ARect)
		{
			PdfDoc FDoc;
			string FXObjectName;
			int FIdx;
			Random r=new Random();

			if(Picture==null)
				return;
			FDoc=ACanvas.PdfCanvas.Doc;
			FXObjectName=this.Name;
			if(SharedImage)
			{				
				if(FDoc.GetXObject(FXObjectName)==null)
					FDoc.AddXObject(FXObjectName,Generic.CreatePdfImage(FPicture,"Pdf-Bitmap"));
			}
			else
			{
				FIdx=r.Next(0,Generic.MAX_IMAGE_NUMBER-1);
				for(int i=0;i<Generic.MAX_IMAGE_NUMBER;i++)
				{
					FXObjectName=this.Name+FIdx.ToString();
					if(FDoc.GetXObject(FXObjectName)==null)
						break;
					FIdx++;
					if(FIdx>=Generic.MAX_IMAGE_NUMBER)
						FIdx=0;
				}
				FDoc.AddXObject(FXObjectName,Generic.CreatePdfImage(FPicture,"Pdf-Bitmap"));
			}
			if(Stretch)
			{
				ACanvas.PdfCanvas.DrawXObject(ARect.Left,GetPage().Height-ARect.Bottom,
					Width,Height,FXObjectName);
			}
			else
			{
				ACanvas.PdfCanvas.DrawXObjectEx(ARect.Left,GetPage().Height-ARect.Top-FPicture.Height,
					FPicture.Width,FPicture.Height,
					ARect.Left,GetPage().Height-ARect.Top-Height,Width,Height,
					FXObjectName);
			}
		}
		#endregion
	}
	#endregion

	#region SDJpegImage
	/// <summary>
	/// Use of SDJpegImage to print a image with JPEG encoding.
	/// </summary>
	[DefaultProperty("Picture")]
	public class SDJPegImage:SDImage
	{
		#region class properties
		/// <summary>
		/// Specifies the image that appears on the control. 
		/// Only Jpeg image is allowed.
		/// </summary>
		public override Bitmap Picture
		{
			get
			{
				return FPicture;
			}
			set
			{				
				if((value==null)||(value.RawFormat.Guid==ImageFormat.Jpeg.Guid))
				{
					FPicture=value;
					Refresh();
				}
				else
					throw(new Exception("Only Jpeg image is allowed."));
			}
		}
		#endregion

		#region class methods
		public override void Print(SDCanvas ACanvas,Rectangle ARect)
		{
			PdfDoc FDoc;
			string FXObjectName;
			int FIdx;
			Random r=new Random();

			if(!Printable)
				return;
			if(FPicture==null)
				return;
			FDoc=ACanvas.PdfCanvas.Doc;
			FXObjectName=this.Name;
			if(SharedImage)
			{
				if(FDoc.GetXObject(FXObjectName)==null)
					FDoc.AddXObject(FXObjectName,Generic.CreatePdfImage(FPicture,"Pdf-Jpeg"));
			}
			else
			{
				FIdx=r.Next(0,Generic.MAX_IMAGE_NUMBER-1);
				for(int i=0;i<Generic.MAX_IMAGE_NUMBER;i++)
				{
					FXObjectName=this.Name+FIdx.ToString();
					if(FDoc.GetXObject(FXObjectName)==null)
						break;
					FIdx++;
					if(FIdx>=Generic.MAX_IMAGE_NUMBER)
						FIdx=0;
				}
				FDoc.AddXObject(FXObjectName,Generic.CreatePdfImage(FPicture,"Pdf-Bitmap"));
			}

			if(Stretch)
				ACanvas.PdfCanvas.DrawXObject(ARect.Left,GetPage().Height-ARect.Bottom,
					Width,Height,FXObjectName);
			else
				ACanvas.PdfCanvas.DrawXObjectEx(ARect.Left,GetPage().Height-ARect.Top-FPicture.Height,
					FPicture.Width,FPicture.Height,
					ARect.Left,GetPage().Height-ARect.Top-Height,Width,Height,
					FXObjectName);
		}
		#endregion
	}
	#endregion

	#region SDAnnotation
	/// <summary>
	/// SDAnnotation is used to add annotations to a page
	/// </summary>
	[DefaultProperty("Opened")]
	public class SDAnnotation:SDItem
	{
		#region class variables
		string[] FLines;
		bool FOpened;
		string FCaption;
		Button button=new Button();
		Rectangle FRect;
		#endregion

		#region constructor
		public SDAnnotation()
		{
			FLines=new string[1];
			FLines[0]="";
			Opened=true;
			this.Size=new Size(136,96);
			Rect=new Rectangle(this.Location,this.Size);
		}
		#endregion 

		#region class properties
		/// <summary>
		/// Caption determines the title of annotation window.
		/// </summary>
		public string Caption
		{
			get
			{
				return FCaption;
			}
			set
			{
				FCaption=value;
				Refresh();
			}
		}

		[Browsable(false)]
		public Rectangle Rect
		{
			get
			{
				return FRect;
			}
			set
			{
				FRect=value;
			}
		}

		/// <summary>
		/// Lines determines the text to be displayed in a 
		/// pop-up window.
		/// </summary>
		public string[] Lines
		{
			get
			{				
				return FLines;
			}
			set
			{
				FLines=value;													
				Refresh();				
			}
		}

		public bool Opened
		{
			get
			{
				return FOpened;
			}
			set
			{
				FOpened=value;
				if(value)
					Size=new Size(Rect.Width,Rect.Height);
				Refresh();
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string Text
		{
			get
			{
				return FLines.ToString();
			}
			set
			{
				string s;
				s=FLines.ToString();
				s=value;
			}
		}
		#endregion

		#region class methods
		public override void Print(SDCanvas ACanvas,Rectangle ARect)
		{
			PdfDictionary FAnnotation;
			string S;
			Rectangle tmpRect=new Rectangle(Parent.Location.X+FRect.Location.X,
				Parent.Location.Y+FRect.Location.Y,
				FRect.Size.Width,FRect.Size.Height);
			S=Generic.GetText(Lines);
			FAnnotation=ACanvas.PdfCanvas.Doc.CreateAnnotation(PdfAnnotationSubType.asTextNotes,
				Generic.PdfRect(tmpRect.Left,Page.Height-tmpRect.Bottom,tmpRect.Right,Page.Height-tmpRect.Top));
			FAnnotation.AddItem("Contents",new PdfText(S));
			FAnnotation.AddItem("S",new PdfText(Caption));
			if(Opened)
				FAnnotation.AddItem("Open",new PdfBoolean(true));
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if(FCaption==null)
				FCaption=Name;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if(Opened)
			{
				int PDF_ANNOT_TITLE_HEIGHT = 20;
				Pen pen=new Pen(Color.Black,1);

				Brush brush=new SolidBrush(Color.Yellow);
				e.Graphics.FillRectangle(brush,0,0,Width,PDF_ANNOT_TITLE_HEIGHT);
				e.Graphics.DrawLine(pen,0,PDF_ANNOT_TITLE_HEIGHT,Width,PDF_ANNOT_TITLE_HEIGHT);
				brush=new SolidBrush(Color.Black);
				Font font=new Font("Microsoft Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(162)));
				e.Graphics.DrawString(Caption,font,brush,new PointF(0,(float)4));
				
				font=new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, ((System.Byte)(162)));
				string Ftext=Generic.DrawGetText(Lines);

				if(Lines[0]!="")
					e.Graphics.DrawString(Ftext,font,brush,new RectangleF(0,PDF_ANNOT_TITLE_HEIGHT+1,Width,Height-PDF_ANNOT_TITLE_HEIGHT));

				pen.DashStyle=System.Drawing.Drawing2D.DashStyle.Solid;
				e.Graphics.DrawRectangle(pen,0,0,Width-1,Height-1);

				FRect.Size=this.Size;
				FRect.Location=this.Location;
			}
			else
			{	
				this.Size=new Size(40,40);
				Brush brush=new SolidBrush(Color.Yellow);
				e.Graphics.FillRectangle(brush,0,0,Width,Height);
				Pen pen=new Pen(Color.Black);
				e.Graphics.DrawRectangle(pen,0,0,Width-1,Height-1);
				Font font=new Font("Microsoft Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(162)));
				brush=new SolidBrush(Color.Black);
				e.Graphics.DrawString("Annot",font,brush,2,10);
				FRect.Location=new Point(this.Location.X,Location.Y);
				
			}
			base.OnPaint(e);
		}
		#endregion	
	}
		#endregion
}