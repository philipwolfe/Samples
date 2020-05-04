using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using Windows.Forms.Reports.ReportLibrary;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Xml;
using System.IO;

namespace Windows.Forms.Designer
{
	#region EditorForm
	public class EditorForm:Control
	{
		#region class variables
		protected bool SelectBand;
		public EditRep EditRep;
		private System.ComponentModel.Container components = null;
		public RulerBar HRB;
		public RulerBar VRB;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem mnuapplystyle;
		private System.Windows.Forms.MenuItem mnucut;
		private System.Windows.Forms.MenuItem mnucopy;
		private System.Windows.Forms.MenuItem mnupaste;
		private System.Windows.Forms.MenuItem mnudelete;
		private System.Windows.Forms.MenuItem mnucellproperties;
		private System.Windows.Forms.MenuItem mnuCellLock;
		private System.Windows.Forms.MenuItem mnuBandLock;
		private System.Windows.Forms.MenuItem menuItem1;
		#endregion

		#region constructor
		public EditorForm()
		{
			InitializeComponent();
			EditRep.SrcRep.RenderingMode=RenderingMode.Normal;
		}
		#endregion

		#region class methods
		private void contextMenu1_Popup(object sender, EventArgs e)
		{
			if(CanPaste())
				mnupaste.Enabled=true;
			else
				mnupaste.Enabled=false;
			if(EditRep.CurrCell.LockWidth==false)
				mnuCellLock.Text="Lock cell width";
			else
				mnuCellLock.Text="Unlock cell width";
			if(EditRep.CurrBand.LockHeight==false)
				mnuBandLock.Text="Lock band height";
			else
				mnuBandLock.Text="Unlock band height";
		}

		protected void Copy()
		{
			if(SelectBand)
				CopyBands();
			else
				CopyCells();
		}

		protected void Delete()
		{
			if(SelectBand)
				DeleteBands();
			else
				DeleteCells();
		}

		void CopyBands()
		{
			StringList sl=new StringList("");
			for(int idxband=0;idxband<EditRep.SrcRep.BandCount;idxband++)
			{
				if(EditRep.SrcRep.GetBand(idxband).Selected)
				{
					sl.AddStrings(EditRep.SrcRep.GetBand(idxband).Template);
				}
			}
			Clipboard.SetDataObject(sl.GetText(),false);
		}

		void CopyCells()
		{
			StringList sl=new StringList("");
			for(int i=0;i<EditRep.SelCount;i++)
			{
				sl.AddStrings(EditRep.GetSel(i).Template);
			}
			Clipboard.SetDataObject(sl.GetText(),false);
		}

		void DeleteBands()
		{
			for(int idxband=EditRep.SrcRep.BandCount-1;idxband>-1;idxband--)
			{
				if(EditRep.SrcRep.GetBand(idxband).Selected)
				{
					EditRep.DeleteBand(idxband);
				}
			}
			EditRep.Invalidate();
			EditRep.OnChange();
		}

		void DeleteCells()
		{
			if(EditRep.SelCount>0)
			{
				EditRep.DeleteSelCells();
				EditRep.SelAdd(EditRep.CurrBandIdx,EditRep.CurrCellIdx);
				EditRep.Invalidate();
				EditRep.OnChange();
			}
		}

		protected bool CanPaste()
		{
			string s;
			if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
			{
				s=(string)Clipboard.GetDataObject().GetData(DataFormats.Text);
				if(s.Trim().Substring(0,6)=="<BAND>" || s.Trim().Substring(0,6)=="<CELL>")
					return true;
				else
					return false;
			}
			return false;
		}

		protected void Paste()
		{
			StringList sl=new StringList("");			
			
			if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
				sl.SetText((string)Clipboard.GetDataObject().GetData(DataFormats.Text));
			if((sl.Count>0)&&(Generic.CT(sl.GetString(0).Trim(),"<CELL>")))
			{
				PasteCells(sl);
			}
			else if((sl.Count>0)&&(Generic.CT(sl.GetString(0).Trim(),"<BAND>")))
			{
				PasteBands(sl);
			}
		}

		void PasteCells(StringList sl)
		{
			sl.InsertString(0,"<BAND>");
			sl.Add("</BAND>");
			XmlNodeList nodelist;
			StringReader reader=new StringReader(sl.GetText());
			XmlDocument doc=new XmlDocument();
			doc.Load(reader);
			nodelist=doc.SelectNodes("BAND/CELL");

			int idxcell=EditRep.CurrCellIdx;
			for(int i=0;i<nodelist.Count;i++)
			{
				EditRep.CurrBand.NewCell();
				EditRep.CurrBand.MoveCell(EditRep.CurrBand.CellCount-1,idxcell);
				EditRep.CurrCellIdx=idxcell;
				EditRep.CurrCell.ApplyCell(nodelist[i]);
				idxcell++;
				EditRep.CurrCell.Width=(int)(EditRep.CurrCell.Width*Generic.ZoomFactor);
			}
			float widthcount=0;
			for(int i=0;i<EditRep.CurrBand.CellCount;i++)
			{
				widthcount=widthcount+EditRep.CurrBand.GetCell(i).Width;
			}
			float WidthCount;
			for(int i=0;i<EditRep.CurrBand.CellCount;i++)
			{
				if(i==EditRep.CurrBand.CellCount-1)
				{
					WidthCount=0;
					for(int idxcell2=0;idxcell2<EditRep.CurrBand.CellCount-1;idxcell2++)
					{
						WidthCount=WidthCount+EditRep.CurrBand.GetCell(idxcell2).Width;
					}
					EditRep.CurrBand.GetCell(i).Width=EditRep.SrcRep.NewWidth-WidthCount-Generic.ToPix(EditRep.SrcRep.LeftMargin)-Generic.ToPix(EditRep.SrcRep.RightMargin)-1;
				}
				else
				{
					double WidthRatio=(double)(widthcount)/(double)EditRep.CurrBand.GetCell(i).Width;
					EditRep.CurrBand.GetCell(i).Width=(int)Math.Round((double)(EditRep.SrcRep.NewWidth-Generic.ToPix(EditRep.SrcRep.LeftMargin)-Generic.ToPix(EditRep.SrcRep.RightMargin))/WidthRatio,0);
				}
			}
			EditRep.Invalidate();
			EditRep.OnChange();
		}

		void PasteBands(StringList sl)
		{
			sl.InsertString(0,"<REP>");
			sl.Add("</REP>");
			XmlNodeList nodelist;
			StringReader reader=new StringReader(sl.GetText());
			XmlDocument doc=new XmlDocument();
			doc.Load(reader);
			nodelist=doc.SelectNodes("REP/BAND");

			int idxband=EditRep.CurrBandIdx;
			for(int m=0;m<nodelist.Count;m++)
			{				
				EditRep.NewBand();
				EditRep.SrcRep.MoveBand(EditRep.SrcRep.BandCount-1,idxband);
				EditRep.CurrBandIdx=idxband;
				EditRep.CurrBand.ApplyBand(nodelist[m]);
				idxband++;
				EditRep.CurrBand.Height=(int)(EditRep.CurrBand.Height*Generic.ZoomFactor);
				float WidthCount;
				float widthcount=0;
				for(int i=0;i<EditRep.CurrBand.CellCount;i++)
				{
					widthcount=widthcount+EditRep.CurrBand.GetCell(i).Width;
				}
				for(int i=0;i<EditRep.CurrBand.CellCount;i++)
				{
					if(i==EditRep.CurrBand.CellCount-1)
					{
						WidthCount=0;
						for(int idxcell2=0;idxcell2<EditRep.CurrBand.CellCount-1;idxcell2++)
						{
							WidthCount=WidthCount+EditRep.CurrBand.GetCell(idxcell2).Width;
						}
						EditRep.CurrBand.GetCell(i).Width=EditRep.SrcRep.NewWidth-WidthCount-Generic.ToPix(EditRep.SrcRep.LeftMargin)-Generic.ToPix(EditRep.SrcRep.RightMargin)-1;
					}
					else
					{
						double WidthRatio=(double)(widthcount)/(double)EditRep.CurrBand.GetCell(i).Width;
						EditRep.CurrBand.GetCell(i).Width=(int)Math.Round((double)(EditRep.SrcRep.NewWidth-Generic.ToPix(EditRep.SrcRep.LeftMargin)-Generic.ToPix(EditRep.SrcRep.RightMargin))/WidthRatio,0);
					}
				}
			}
			float heigthcount=0;
			for(int i=0;i<EditRep.SrcRep.BandCount;i++)
			{
				heigthcount=heigthcount+EditRep.SrcRep.GetBand(i).Height;
			}
			float HeightCount=0;				
			for(int i=0;i<EditRep.SrcRep.BandCount;i++)
			{
				if(i==EditRep.SrcRep.BandCount-1)
				{
					for(int idxband2=0;idxband2<EditRep.SrcRep.BandCount-1;idxband2++)
					{
						HeightCount=HeightCount+EditRep.SrcRep.GetBand(idxband2).Height;
					}
					EditRep.SrcRep.GetBand(i).Height=EditRep.SrcRep.NewHeight-HeightCount-Generic.ToPix(EditRep.SrcRep.TopMargin)-Generic.ToPix(EditRep.SrcRep.BottomMargin)-1;							
				}
				else
				{
					double HeightRatio=(double)(heigthcount)/(double)EditRep.SrcRep.GetBand(i).Height;
					EditRep.SrcRep.GetBand(i).Height=(int)Math.Round((double)(EditRep.SrcRep.NewHeight-Generic.ToPix(EditRep.SrcRep.TopMargin)-Generic.ToPix(EditRep.SrcRep.BottomMargin))/HeightRatio,0);
				}
			}
			EditRep.Invalidate();
			EditRep.OnChange();
		}

		private void mnuapplystyle_Click(object sender, System.EventArgs e)
		{
			StyleDlg dlg=new StyleDlg();
			dlg.StyleList.AddRange(EditRep.SrcRep.StyleList);
			dlg.Rep=EditRep;
			if(dlg.ShowDialog()==DialogResult.OK)
			{
				EditRep.SrcRep.StyleList.Clear();
				EditRep.SrcRep.StyleList.AddRange(dlg.StyleList);
				EditRep.OnChange();
				Refresh();
			}
		}

		private void mnucut_Click(object sender, System.EventArgs e)
		{
			Copy();
			Delete();
		}

		private void mnucopy_Click(object sender, System.EventArgs e)
		{
			Copy();
		}

		private void mnupaste_Click(object sender, System.EventArgs e)
		{
			Paste();
		}

		private void mnudelete_Click(object sender, System.EventArgs e)
		{
			Delete();
		}

		private void mnucellproperties_Click(object sender, System.EventArgs e)
		{
			CellPropDlg d=new CellPropDlg();
			d.Rep=EditRep;
			if(d.ShowDialog()==DialogResult.OK)
			{
				EditRep.OnChange();
				EditRep.Refresh();
			}
			d.Dispose();
		}

		public void RepSelectCell(object sender,SelectCellEventArgs arg)
		{
			if((arg.idxband<EditRep.SrcRep.BandCount)&&(arg.idxcell<EditRep.SrcRep.GetBand(arg.idxband).CellCount))
			{
				UpdateRulerBars();
			}
		}

		public void RepResizeGutter(object sender,EventArgs arg)
		{
			UpdateRulerBars();
		}

		public void RepMouseMove(object sender,MouseEventArgs arg)
		{
			HRB.Cur=arg.X+3;
			VRB.Cur=arg.Y+3+45;
		}

		public void RepScroll(object sender,EventArgs arg)
		{
			UpdateRulerBars();
			EditRep.Focus();
		}

		public void UpdateRulerBars()
		{
			int idxband, idxcell;
			float hselbegin, hselend, vselbegin, vselend;

			hselbegin=1000000;
			hselend=-1;
			vselbegin=1000000;
			vselend=-1;

			for(idxband=0;idxband<EditRep.SrcRep.BandCount;idxband++)
			{
				for(idxcell=0;idxcell<EditRep.SrcRep.GetBand(idxband).CellCount;idxcell++)
				{
					if(EditRep.SrcRep.GetBand(idxband).GetCell(idxcell).Selected)
					{
						hselbegin=Math.Min(hselbegin,EditRep.SrcRep.GetBand(idxband).GetLefts(idxcell));
						hselend=Math.Max(hselend,EditRep.SrcRep.GetBand(idxband).GetRights(idxcell));

						vselbegin=Math.Min(vselbegin,EditRep.SrcRep.GetTops(idxband));
						vselend=Math.Max(Math.Abs(vselend),EditRep.SrcRep.GetTops(idxband)+EditRep.SrcRep.GetBand(idxband).Height);
					}
				}
			}
			HRB.BeginUpdate();
			HRB.Gutter=EditRep.Gutter-EditRep.LeftX+3;
			if(EditRep.SrcRep.Orientation==PrinterOrientation.Portrait)
				HRB.PageWidth=EditRep.SrcRep.PageSize.FWidth*Generic.ZoomFactor;
			else
				HRB.PageWidth=EditRep.SrcRep.PageSize.FHeight*Generic.ZoomFactor;
			HRB.LeftMargin=EditRep.SrcRep.LeftMargin;
			HRB.RightMargin=EditRep.SrcRep.RightMargin;
			HRB.SelBegin=Generic.FromPix(hselbegin);
			HRB.SelEnd=Generic.FromPix(hselend);
			HRB.EndUpdate();

			VRB.BeginUpdate();
			VRB.Gutter=1-EditRep.TopY+45;
			if(EditRep.SrcRep.Orientation==PrinterOrientation.Portrait)
				VRB.PageWidth=EditRep.SrcRep.PageSize.FHeight*Generic.ZoomFactor;
			else
				VRB.PageWidth=EditRep.SrcRep.PageSize.FWidth*Generic.ZoomFactor;
			VRB.LeftMargin=EditRep.SrcRep.TopMargin;
			VRB.RightMargin=EditRep.SrcRep.BottomMargin;
			VRB.SelBegin=Generic.FromPix(vselbegin);
			VRB.SelEnd=Generic.FromPix(vselend);
			VRB.EndUpdate();
		}

		public void HRBChange(object source,EventArgs arg)
		{
			if(((RulerBar)source).Orientation==RulerBarOrientation.Horizontal)
			{
				EditRep.SrcRep.LeftMargin=HRB.LeftMargin;
				EditRep.SrcRep.RightMargin=HRB.RightMargin;
			}
			else
			{
				EditRep.SrcRep.TopMargin=VRB.LeftMargin;
				EditRep.SrcRep.BottomMargin=VRB.RightMargin;
			}
			Refresh();
		}

		private void mnuCellLock_Click(object sender, EventArgs e)
		{
			if(EditRep.CurrCell.LockWidth==false)
			{
				for(int i=0;i<EditRep.SelCount;i++)
				{
					EditRep.GetSel(i).LockWidth=true;
				}
			}
			else
			{
				for(int i=0;i<EditRep.SelCount;i++)
				{
					EditRep.GetSel(i).LockWidth=false;
				}
			}
			EditRep.OnChange();
		}

		private void mnuBandLock_Click(object sender, EventArgs e)
		{
			if(EditRep.CurrBand.LockHeight==false)
				EditRep.CurrBand.LockHeight=true;
			else
				EditRep.CurrBand.LockHeight=false;
			EditRep.OnChange();
		}
		#endregion

		#region destructor
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mnuapplystyle = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mnucut = new System.Windows.Forms.MenuItem();
			this.mnucopy = new System.Windows.Forms.MenuItem();
			this.mnupaste = new System.Windows.Forms.MenuItem();
			this.mnudelete = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.mnucellproperties = new System.Windows.Forms.MenuItem();
			this.mnuCellLock=new MenuItem();
			this.mnuBandLock=new MenuItem();
			this.menuItem1=new MenuItem();
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuapplystyle,
																						 this.menuItem2,
																						 this.mnucut,
																						 this.mnucopy,
																						 this.mnupaste,
																						 this.mnudelete,
																						 this.menuItem1,
																						 this.mnuCellLock,
																						 this.mnuBandLock,
																						 this.menuItem7,
																						 this.mnucellproperties});
			this.contextMenu1.Popup+=new EventHandler(contextMenu1_Popup);
			// 
			// mnuapplystyle
			// 
			this.mnuapplystyle.Index = 0;
			this.mnuapplystyle.Text = "Apply styles";
			this.mnuapplystyle.Click += new System.EventHandler(this.mnuapplystyle_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// mnucut
			// 
			this.mnucut.Index = 2;
			this.mnucut.Text = "Cut";
			this.mnucut.Click += new System.EventHandler(this.mnucut_Click);
			// 
			// mnucopy
			// 
			this.mnucopy.Index = 3;
			this.mnucopy.Text = "Copy";
			this.mnucopy.Click += new System.EventHandler(this.mnucopy_Click);
			// 
			// mnupaste
			// 
			this.mnupaste.Index = 4;
			this.mnupaste.Text = "Paste";
			this.mnupaste.Click += new System.EventHandler(this.mnupaste_Click);
			// 
			// mnudelete
			// 
			this.mnudelete.Index = 5;
			this.mnudelete.Text = "Delete";
			this.mnudelete.Click += new System.EventHandler(this.mnudelete_Click);
			//
			// menuItem1
			//
			this.menuItem1.Index=6;
			this.menuItem1.Text="-";
			//
			// mnuCellLock
			//
			this.mnuCellLock.Index=7;
			this.mnuCellLock.Text="Lock cell width";
			this.mnuCellLock.Click+=new EventHandler(mnuCellLock_Click);
			//
			// mnuBandLock
			//
			this.mnuBandLock.Index=8;
			this.mnuBandLock.Text="Lock band height";
			this.mnuBandLock.Click+=new EventHandler(mnuBandLock_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 9;
			this.menuItem7.Text = "-";
			// 
			// mnucellproperties
			// 
			this.mnucellproperties.Index = 10;
			this.mnucellproperties.Text = "Cell properties";
			this.mnucellproperties.Click += new System.EventHandler(this.mnucellproperties_Click);
			HRB=new RulerBar();
			VRB=new RulerBar();
			
			this.SuspendLayout();

			
			this.Dock=DockStyle.Fill;
			//this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			
			//this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			
			HRB.Size=new Size(702,45);
			HRB.Orientation=RulerBarOrientation.Horizontal;
			HRB.Location=new Point(0,20);
			
			
			HRB.Gutter=100;
			HRB.PageWidth=1500;
			HRB.LeftMargin=0;
			HRB.RightMargin=0;
			HRB.Units=Units.Cm;
			HRB.SelBegin=100;
			HRB.SelEnd=300;
			HRB.Cur=0;
			HRB.SelColor=Color.Aqua;
			HRB.RulerColor=SystemColors.Info;
			HRB.Font=new Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
			HRB.ForeColor=SystemColors.ControlText;
			HRB.Change+=new EventHandler(HRBChange);
			this.Controls.Add(HRB);			
			
			VRB.Location=new Point(0,55);
			VRB.Size=new Size(45,417);
			VRB.Orientation=RulerBarOrientation.Vertical;
			VRB.Gutter=45;
			VRB.PageWidth=1500;
			VRB.LeftMargin=0;
			VRB.RightMargin=0;
			VRB.Units=Units.Cm;
			VRB.SelBegin=100;
			VRB.SelEnd=300;
			VRB.Cur=0;
			VRB.SelColor=Color.Aqua;
			VRB.RulerColor=SystemColors.Info;
			VRB.Font=new Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
			VRB.ForeColor=SystemColors.ControlText;
			VRB.Change+=new EventHandler(HRBChange);
			this.Controls.Add(VRB);	
			this.EditRep= new EditRep();
			this.Controls.Add(this.EditRep);
			this.EditRep.Dock=DockStyle.Fill;
			EditRep.BringToFront();
			EditRep.HScroll+=new EventHandler(RepScroll);
			EditRep.VScroll+=new EventHandler(RepScroll);
			EditRep.MouseMove+=new MouseEventHandler(RepMouseMove);
			EditRep.ResizeGutter+=new EventHandler(RepResizeGutter);
			EditRep.SelectCell+=new SelectCellEventHandler(RepSelectCell);
			EditRep.GridSelectCell+=new SelectCellEventHandler(RepSelectCell);
			EditRep.DoubleClick+=new EventHandler(mnucellproperties_Click);
			this.ContextMenu=contextMenu1;
			this.ResumeLayout(false);
		}
		#endregion
	}
	#endregion

	#region EditorProperties
	public class EditorProperties
	{
		#region class variables
		EditRep FEditor;
		EditorForm FForm;
		#endregion

		#region constructor
		public EditorProperties(EditRep Editor,EditorForm form)
		{
			FEditor = Editor;
			FForm=form;
		}
		#endregion

		#region class properties
		[Category("View")]
		public FocusedCellStyle FocusedCellStyle
		{
			get
			{
				return FEditor.FocusedCellStyle;
			}
			set
			{
				FEditor.FocusedCellStyle=value;
				FEditor.Refresh();
			}
		}

		[Category("View")]
		public int Gutter
		{
			get
			{
				return FEditor.Gutter;
			}
			set
			{
				FEditor.Gutter=value;
				FForm.UpdateRulerBars();					
			}
		}

		[Category("View")]
		public Zoom Zoom
		{
			get
			{
				return FEditor.Zoom;
			}
			set
			{
				FEditor.Zoom=value;
				FForm.UpdateRulerBars();
				FForm.Refresh();
			}
		}

		[Category("View")]
		public bool ShowMargins
		{
			get
			{
				return FEditor.ShowMargins;
			}
			set
			{
				FEditor.ShowMargins=value;
			}
		}

		[Category("View")]
		public bool ShowBandTitle
		{
			get
			{
				return FEditor.ShowBandTitle;
			}
			set
			{
				FEditor.ShowBandTitle=value;
			}
		}

		[Category("View")]
		public SelectedCellStyle SelectedCellStyle
		{
			get
			{
				return FEditor.SelectedCellStyle;
			}
			set
			{
				FEditor.SelectedCellStyle=value;
				FEditor.Refresh();
			}
		}

		[Category("View")]
		public bool ShowAll
		{
			get
			{
				return Generic.ShowHiddenItems;
			}
			set
			{
				Generic.ShowHiddenItems=value;
				Generic.NonPrinting=true;
				FEditor.Refresh();
			}
		}

		[Category("View")]
		public Units Units
		{
			get
			{
				return FEditor.Units;
			}
			set
			{
				FEditor.Units=value;
				FForm.HRB.Units=value;
				FForm.VRB.Units=value;
			}
		}

		[Category("View")]
		public Color RulerColor
		{
			get
			{
				return FForm.HRB.RulerColor;
			}
			set
			{
				FForm.HRB.RulerColor=value;
				FForm.VRB.RulerColor=value;
				FForm.UpdateRulerBars();
			}
		}

		[Category("View")]
		public Color RulerSelColor
		{
			get
			{
				return FForm.HRB.SelColor;
			}
			set
			{
				FForm.HRB.SelColor=value;
				FForm.VRB.SelColor=value;
				FForm.UpdateRulerBars();
			}
		}

		public Style[] Style
		{
			get
			{
				return (Style[])FEditor.SrcRep.StyleList.ToArray(typeof(Style));
			}
			set
			{
				if(value!=(Style[])FEditor.SrcRep.StyleList.ToArray(typeof(Style)))
				{
					FEditor.SrcRep.StyleList=new ArrayList(value);
					FForm.EditRep.OnChange();
				}
			}
		}

		[Category("Page")]
		public FillDirection FillDirection
		{
			get
			{
				return FEditor.SrcRep.PageFillDirection;
			}
			set
			{
				if(value!=FEditor.SrcRep.PageFillDirection)
				{
					FEditor.SrcRep.PageFillDirection=value;
					if(value==FillDirection.None)
						FEditor.SrcRep.PageGraident=false;
					else
						FEditor.SrcRep.PageGraident=true;
					FForm.EditRep.OnChange();
					FEditor.Refresh();
				}
			}
		}

		[Category("Page")]
		public Color BackColor
		{
			get
			{
				return FEditor.SrcRep.PageColor;
			}
			set
			{
				if(value!=FEditor.SrcRep.PageColor)
				{
					FEditor.SrcRep.PageColor=value;
					FForm.EditRep.OnChange();
					FEditor.Refresh();
				}
			}
		}

		[Category("Page")]
		public Color GraidentColor
		{
			get
			{
				return FEditor.SrcRep.PageGraidentColor;
			}
			set
			{
				if(value!=FEditor.SrcRep.PageGraidentColor)
				{
					FEditor.SrcRep.PageGraidentColor=value;
					FForm.EditRep.OnChange();
					FEditor.Refresh();
				}
			}
		}

		[Category("Page")]
		public string PictureFileName
		{
			get
			{
				return FEditor.SrcRep.PagePictureFileName;
			}
			set
			{
				if(value!=FEditor.SrcRep.PagePictureFileName)
				{
					if(value!="")
						FEditor.SrcRep.PageImage=true;
					else
					{
						FEditor.SrcRep.PageImage=false;
					}
					FEditor.SrcRep.PagePictureFileName=value;
					FEditor.OnChange();
					FEditor.Refresh();
				}
			}
		}

		[Category("Page")]
		public bool LinkPicture
		{
			get
			{
				return FEditor.SrcRep.PageLinkPictureToFile;
			}
			set
			{
				if(value!=FEditor.SrcRep.PageLinkPictureToFile)
				{
					FEditor.SrcRep.PageLinkPictureToFile=value;
					FForm.EditRep.OnChange();
				}
			}
		}

		[Category("Page")]
		public ImagePosition ImagePosition
		{
			get
			{
				return FEditor.SrcRep.PageImagePosition;
			}
			set
			{
				if(value!=FEditor.SrcRep.PageImagePosition)
				{
					FEditor.SrcRep.PageImagePosition=value;
					FForm.EditRep.OnChange();
					FEditor.Refresh();
				}
			}
		}
		
		[Category("View")]
		public double GridX
		{
			get
			{
				return FEditor.GridX;
			}
			set
			{
				FEditor.GridX=value;
			}
		}

		[Category("View")]
		public double GridY
		{
			get
			{
				return FEditor.GridY;
			}
			set
			{
				FEditor.GridY=value;
			}
		}
		
		#endregion
	}
	#endregion

	#region BandProperties
	public class BandProperties
	{
		#region class variables
		Band FBand;
		EditorForm FForm;
		#endregion

		#region constructor
		public BandProperties(Band band,EditorForm form)
		{
			FBand=band;
			FForm=form;
		}
		#endregion

		#region class properties
		public string Name
		{
			get
			{
				return FBand.Name;
			}
			set
			{
				if(value!=FBand.Name)
				{
					FBand.Name=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		public bool LockHeight
		{
			get
			{
				return FBand.LockHeight;
			}
			set
			{
				FBand.LockHeight=value;
			}
		}

		public float Height
		{
			get
			{
				return (float)Math.Round(FBand.Height/Generic.ZoomFactor,0);
			}
			set
			{
				Band band=null;
				if(FBand.LockHeight!=true)
				{
					for(int i=FForm.EditRep.CurrBandIdx+1;i<FForm.EditRep.SrcRep.BandCount;i++)
					{
						if(FForm.EditRep.SrcRep.GetBand(i).LockHeight==false)
						{
							band=FForm.EditRep.SrcRep.GetBand(i);
							break;
						}
					}
					if(band==null)
					{
						for(int i=0;i<FForm.EditRep.CurrBandIdx;i++)
						{
							if(FForm.EditRep.SrcRep.GetBand(i).LockHeight==false)
							{
								band=FForm.EditRep.SrcRep.GetBand(i);
								break;
							}
						}
					}
					if(band!=null)
					{
						int bandidx=FForm.EditRep.SrcRep.IndexOfBand(band);
						float DifferenceBand=value-(FForm.EditRep.CurrBand.Height/Generic.ZoomFactor);
						FBand.Height=value*Generic.ZoomFactor;
						FForm.EditRep.SetBandHeight(bandidx,(((band.Height/Generic.ZoomFactor)-DifferenceBand)*Generic.ZoomFactor));
						FForm.EditRep.OnChange();
						FForm.Refresh();
					}
				}
			}
		}
		#endregion
	}
	#endregion

	#region CellProperties
	public class CellProperties
	{
		#region class variables
		Cell FCell;
		EditorForm FForm;
		BorderS FLeftBorder;
		BorderS FRightBorder;
		BorderS FTopBorder;
		BorderS FBottomBorder;
		#endregion

		#region constructor
		public CellProperties(Cell cell,EditorForm form)
		{
			FCell=cell;
			FForm=form;
			FLeftBorder=new BorderS(FCell,FForm,0);
			FRightBorder=new BorderS(FCell,FForm,2);
			FTopBorder=new BorderS(FCell,FForm,1);
			FBottomBorder=new BorderS(FCell,FForm,3);
		}
		#endregion

		#region class properties
		[Category("Appearance")]
		public string Value
		{
			get
			{
				return FCell.Value;
			}
			set
			{
				if(value!=FCell.Value)
				{
					FCell.Value=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}	
	
		[Category("Borders")]
		public BorderS LeftBorder
		{
			get
			{
				return FLeftBorder;
			}
		}

		[Category("Borders")]
		public BorderS RightBorder
		{
			get
			{
				return FRightBorder;
			}
		}

		[Category("Borders")]
		public BorderS TopBorder
		{
			get
			{
				return FTopBorder;
			}
		}

		[Category("Borders")]
		public BorderS BottomBorder
		{
			get
			{
				return FBottomBorder;
			}
		}

		[Category("Picture")]
		public bool FitToCell
		{
			get
			{
				return FCell.AutoSize;
			}
			set
			{
				if(value!=FCell.AutoSize)
				{
					FCell.AutoSize=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Picture")]
		public string PictureFileName
		{
			get
			{
				return FCell.PictureFileName;
			}
			set
			{
				if(value!=FCell.PictureFileName)
				{
					FCell.PictureFileName=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Picture")]
		public bool LinkPictureToFile
		{
			get
			{
				return FCell.LinkPictureToFile;
			}
			set
			{
				if(value!=FCell.LinkPictureToFile)
				{
					FCell.LinkPictureToFile=value;
					FForm.EditRep.OnChange();
				}
			}
		}

		[Category("Picture")]
		public bool Tile
		{
			get
			{
				return FCell.Tile;
			}
			set
			{
				if(value!=FCell.Tile)
				{
					FCell.Tile=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Appearance")]
		public Font Font
		{
			get
			{
				return new Font(FCell.FontName,FCell.FontSize,FCell.FontStyle);
			}
			set
			{
				if(value!=new Font(FCell.FontName,FCell.FontSize,FCell.FontStyle))
				{
					FCell.FontName=value.Name;
					FCell.FontSize=value.Size;
					FCell.FontStyle=value.Style;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Appearance")]
		public Color FontColor
		{
			get
			{
				return FCell.FontColor;
			}
			set
			{
				if(value!=FCell.FontColor)
				{
					FCell.FontColor=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Appearance")]
		public int TextAngle
		{
			get
			{
				return FCell.TextAngle;
			}
			set
			{
				if(value!=FCell.TextAngle)
				{
					if(value<90)
						FCell.TextAngle=0;
					else if(value==90 || value<180)
						FCell.TextAngle=90;
					else if(value==180 || value<270)
						FCell.TextAngle=180;
					else if(value==270 || value>270)
						FCell.TextAngle=270;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Margins")]
		public int LeftMargin
		{
			get
			{
				return FCell.CellMargins.Left;
			}
			set
			{
				if(value!=FCell.CellMargins.Left)
				{
					FCell.CellMargins.Left=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Margins")]
		public int RightMargin
		{
			get
			{
				return FCell.CellMargins.Right;
			}
			set
			{
				if(value!=FCell.CellMargins.Right)
				{
					FCell.CellMargins.Right=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Margins")]
		public int TopMargin
		{
			get
			{
				return FCell.CellMargins.Top;
			}
			set
			{
				if(value!=FCell.CellMargins.Top)
				{
					FCell.CellMargins.Top=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Margins")]
		public int BottomMargin
		{
			get
			{
				return FCell.CellMargins.Bottom;
			}
			set
			{
				if(value!=FCell.CellMargins.Bottom)
				{
					FCell.CellMargins.Bottom=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Appearance")]
		public VAlign VAlign
		{
			get
			{
				return FCell.VAlign;
			}
			set
			{
				if(value!=FCell.VAlign)
				{
					FCell.VAlign=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Appearance")]
		public HAlign HAlign
		{
			get
			{
				return FCell.HAlign;
			}
			set
			{
				if(value!=FCell.HAlign)
				{
					FCell.HAlign=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Layout")]
		public bool LockWidth
		{
			get
			{
				return FCell.LockWidth;
			}
			set
			{
				FCell.LockWidth=value;
			}
		}

		[Category("Layout")]
		public float Width
		{
			get
			{
				return (float) Math.Round(FCell.Width/Generic.ZoomFactor,0);
			}
			set
			{
				int cellidx=FForm.EditRep.CurrCellIdx;
				if(FCell.LockWidth!=true)
				{
					Cell cell2=null;
					
					for(int i=cellidx+1;i<FForm.EditRep.CurrBand.CellCount;i++)
					{
						if(FForm.EditRep.CurrBand.GetCell(i).LockWidth==false)
						{
							cell2=FForm.EditRep.CurrBand.GetCell(i);
							break;
						}
					}
					if(cell2==null)
					{
						for(int i=0;i<cellidx;i++)
						{
							if(FForm.EditRep.CurrBand.GetCell(i).LockWidth==false)
							{
								cell2=FForm.EditRep.CurrBand.GetCell(i);
								break;
							}
						}
					}
					if(cell2!=null)
					{
						float DifferenceCell=value-(FCell.Width/Generic.ZoomFactor);
						FCell.Width=value*Generic.ZoomFactor;
						FForm.EditRep.SetCellWidth(cell2,(((cell2.Width/Generic.ZoomFactor)-DifferenceCell)*Generic.ZoomFactor));
						FForm.EditRep.OnChange();
						FForm.Refresh();
					}
				}
			}
		}

		[Category("Appearance")]
		public bool WordWrap
		{
			get
			{
				return FCell.WordWrap;
			}
			set
			{
				if(value!=FCell.WordWrap)
				{
					FCell.WordWrap=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Shape")]
		public ShapeType ShapeType
		{
			get
			{
				return FCell.ShapeType;
			}
			set
			{
				if(value!=FCell.ShapeType)
				{
					FCell.ShapeType=value;
					if(value==ShapeType.None)
						FCell.Shape=false;
					else
						FCell.Shape=true;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Shape")]
		public Color ShapeColor
		{
			get
			{
				return FCell.ShapeColor;
			}
			set
			{
				if(value!=FCell.ShapeColor)
				{
					FCell.ShapeColor=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Shape")]
		public Color ShapeGraidentColor
		{
			get
			{
				return FCell.ShapeGraidentColor;
			}
			set
			{
				if(value!=FCell.ShapeGraidentColor)
				{
					FCell.ShapeGraidentColor=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Shape")]
		public FillDirection FillDirection
		{
			get
			{
				return FCell.ShapeFillDirection;
			}
			set
			{
				if(value!=FCell.ShapeFillDirection)
				{
					FCell.ShapeFillDirection=value;
					if(value==FillDirection.None)
						FCell.ShapeGraident=false;
					else
						FCell.ShapeGraident=true;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Shape")]
		public int  ShapeBorderWidth
		{
			get
			{
				return FCell.ShapeBorderWidth;
			}
			set
			{
				if(value!=FCell.ShapeBorderWidth)
				{
					FCell.ShapeBorderWidth=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Shape")]
		public DashStyle ShapeBorderStyle
		{
			get
			{
				return FCell.ShapeBorderStyle;
			}
			set
			{
				if(value!=FCell.ShapeBorderStyle)
				{
					FCell.ShapeBorderStyle=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		[Category("Shape")]
		public Color ShapeBorderColor
		{
			get
			{
				return FCell.ShapeBorderColor;
			}
			set
			{
				if(value!=FCell.ShapeBorderColor)
				{
					FCell.ShapeBorderColor=value;
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}
		#endregion
	}
	#endregion

	#region BorderStyle
	[ToolboxItem(false)]
	public class BorderS:Component
	{
		Cell FCell;
		EditorForm FForm;
		int FBorder;

		public BorderS(Cell cell,EditorForm form,int border)
		{
			FCell=cell;
			FForm=form;
			FBorder=border;
		}

		public LineStyle LineStyle
		{
			get
			{
				return FCell.GetBorderStyles(FBorder);
			}
			set
			{
				if(value!=FCell.GetBorderStyles(FBorder))
				{
					if(value==LineStyle.Dash)
					{
						FCell.SetFrameWidths(FBorder,1);
					}
					else if(value==LineStyle.Dot)
					{
						FCell.SetFrameWidths(FBorder,1);
					}
					else if(value==LineStyle.DashDot)
					{
						FCell.SetFrameWidths(FBorder,1);
					}
					else if(value==LineStyle.DashDotDot)
					{
						FCell.SetFrameWidths(FBorder,1);
					}
					else if(value==LineStyle.Double11)
					{
						FCell.SetFrameWidths(FBorder,3);
					}
					else if(value==LineStyle.Double21)
					{
						FCell.SetFrameWidths(FBorder,4);
					}
					else if(value==LineStyle.Double12)
					{
						FCell.SetFrameWidths(FBorder,4);
					}
					FCell.SetBorderStyles(FBorder,value);
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		public Color BorderColor
		{
			get
			{
				return FCell.GetFrameColors(FBorder);
			}
			set
			{
				if(value!=FCell.GetFrameColors(FBorder))
				{
					FCell.SetFrameColors(FBorder,value);
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}

		public int BorderWidth
		{
			get
			{
				return FCell.GetFrameWidths(FBorder);
			}
			set
			{
				if(value!=FCell.GetFrameWidths(FBorder))
				{
					if(LineStyle==LineStyle.Dash)
					{
						FCell.SetFrameWidths(FBorder,1);					
					}
					else if(LineStyle==LineStyle.Dot)
					{
						FCell.SetFrameWidths(FBorder,1);					
					}
					else if(LineStyle==LineStyle.DashDot)
					{
						FCell.SetFrameWidths(FBorder,1);					
					}
					else if(LineStyle==LineStyle.DashDotDot)
					{
						FCell.SetFrameWidths(FBorder,1);					
					}
					else if(LineStyle==LineStyle.Double11)
					{
						FCell.SetFrameWidths(FBorder,3);					
					}
					else if(LineStyle==LineStyle.Double21)
					{
						FCell.SetFrameWidths(FBorder,4);					
					}
					else if(LineStyle==LineStyle.Double12)
					{
						FCell.SetFrameWidths(FBorder,4);
					}
					else
					{
						if(value>7)
							FCell.SetFrameWidths(FBorder,7);
						else
							FCell.SetFrameWidths(FBorder,value);
					}
					FForm.EditRep.OnChange();
					FForm.Refresh();
				}
			}
		}
	}
	#endregion
	
}
