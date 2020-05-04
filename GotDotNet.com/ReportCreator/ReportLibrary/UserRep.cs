using System;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.Drawing;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region UserRep
	/// <summary>
	/// UserRep to representive for reports one page view. When you
	/// call ShowPage(int,bool) method you can view this page.
	/// </summary>
	[ToolboxItem(true)]
	public class UserRep:GridRep
	{
		#region class events
		/// <summary>
		/// Progress is called when you want to view a Progress form.
		/// </summary>
		public event ProgressEventHandler Progress;
		/// <summary>
		/// SelectCell is called after you select any cell
		/// </summary>
		public event SelectCellEventHandler SelectCell;
		/// <summary>
		/// SelectBand  is called after you select any band
		/// </summary>
		public event SelectBandEventHandler SelectBand;
		#endregion
		
		#region class variables
		public ArrayList NodeCollection;

		int FMax;
		int FPos;
		int FCurrPage;
		int OldX;
		int OldY;

		BandState NextTopBandState;		
		StringList GroupBands;
		bool FPan;
		public ArrayList FPlugInList;
		public StringList PlugInList;
		public SourceReport SourceRep;
		public int Pagecnt;
		
		public float FooterHeight;
		public float HeaderHeight;
		public float TopMargin;
		public float BottomMargin;
		public float BlankCellWidth;
		public int LeftMargin;
		public int RightMargin;
		#endregion

		#region constructor
		public UserRep()
		{
			NextTopBandState=(int)0;
			ShowBandTitle=true;
			Gutter=0;
			GroupBands=new StringList("UserRep.Create GroupBands");
			FPlugInList=new ArrayList();
			DeleteBands();
			Zoom=Zoom.hundred;
			Generic.ZoomFactor=1.0F;
			SourceRep=new SourceReport();
			SourceRep.Owner=this;
			PlugInList=new StringList("");
			SourceRep.Vars=new StringList("UserRep.Create Vars");
			SourceRep.PictureList=new StringList("UserRep.Create PictureList");
			SourceRep.ControlList=new StringList("UserRep ControlList");
			SourceRep.PictureList.Sorted=true;
			SourceRep.ControlList.Sorted=true;
			NodeCollection=new ArrayList();
			Owner=this;
			Pan=true;
		}
		#endregion

		#region class properties
		public bool Pan
		{
			get
			{
				return FPan;
			}
			set
			{
				FPan=value;
				if(value==true)
				{
					Cursor=new Cursor(GetType(),"cur200.cur");
				}
				else
				{
					Cursor=Cursors.Default;
				}
			}
		}
		/// <summary>
		/// This property represent current page.
		/// </summary>
		public int CurrPage
		{
			get
			{
				return FCurrPage;
			}
			set
			{
				FCurrPage=value;
			}
		}

		/// <summary>
		/// This property to describe a report title.
		/// </summary>
		public string Title
		{
			get
			{
				return SourceRep.Title;;
			}
			set
			{
				SourceRep.Title=value;
			}
		}

		/// <summary>
		/// This property return Plug in count.
		/// </summary>
		public int PlugInCount
		{
			get
			{
				return PlugInList.Count;
			}
		}
		#endregion

		#region class methods
		/// <summary>
		/// This method is called when you view a report page. 
		/// </summary>
		/// <param name="page">An integer that describes page number</param>
		/// <param name="refresh">Boolean for this page refreshing or not</param>
		public void ShowPage(int page,bool refresh)
		{
			Band band;
			DeleteBands();
			int firstband=0;
			int lastband=0;
			Rep CurrRep=null;
			CurrPage=page;
			Zoom oldzoom=Zoom;
			Zoom=Zoom.hundred;
			for(int i=0;i<SourceRep.RepList.Count;i++)
			{
				CurrRep=SourceRep.GetSrcRep(i);
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
				if(lastband!=0)
					break;
			}

			SrcRep.PageSize=CurrRep.PageSize;
			SrcRep.Orientation=CurrRep.Orientation;
			SrcRep.LeftMargin=CurrRep.LeftMargin;
			SrcRep.TopMargin=CurrRep.TopMargin;
			SrcRep.RightMargin=CurrRep.RightMargin;
			SrcRep.BottomMargin=CurrRep.BottomMargin;
			SrcRep.PageColor=CurrRep.PageColor;
			SrcRep.PageGraident=CurrRep.PageGraident;
			if(SrcRep.PageGraident)
			{
				SrcRep.PageGraidentColor=CurrRep.PageGraidentColor;
				SrcRep.PageFillDirection=CurrRep.PageFillDirection;
			}
			SrcRep.PageImage=CurrRep.PageImage;
			if(SrcRep.PageImage)
			{
				SrcRep.PageImagePosition=CurrRep.PageImagePosition;
				SrcRep.PageLinkPictureToFile=CurrRep.PageLinkPictureToFile;
				SrcRep.PagePicture=CurrRep.PagePicture;
				if(SrcRep.PageLinkPictureToFile)
					SrcRep.PagePictureFileName=CurrRep.PagePictureFileName;
			}

			if(page!=CurrRep.LastPage-1)
				lastband=lastband-1;
	
			for(int idxband=firstband;idxband<lastband+1;idxband++)
			{
				band=new Band(CurrRep);
				band.Assign(CurrRep.GetBand(idxband));
				SrcRep.Add(band);				
			}
			Zoom=oldzoom;			
			if(refresh)
				Invalidate();
		}

		// This method is called PrepareSourceRep method. A report
		// header displaying every page.
		void ShowHeader(int index,int page,out int headercount,Rep OrgRep,Rep CurrRep)
		{
			Band band;
			headercount=0;
			for(int idxband=0;idxband<OrgRep.BandCount;idxband++)
			{
				if(Generic.CT(OrgRep.GetBand(idxband).Name,"header"))
				{
					band=new Band(OrgRep);
					band.Assign(OrgRep.GetBand(idxband));
					for(int i=0;i<band.CellCount;i++)
					{
						ApplyValues(OrgRep.GetBand(idxband).GetCell(i),band.GetCell(i),CurrRep);
					}
					
					band.NewPage(page);					
					CurrRep.GetBand(index).Page=false;
					CurrRep.Insert(index,band);
					headercount++;
				}
			}
		}

		// This method is called PrepareSourceRep method. A report
		// footer displaying every page.
		void ShowFooter(int index,int page,out int footercount,Rep OrgRep,Rep CurrRep)
		{
			Band band;
			footercount=0;
			for(int idxband=0;idxband<OrgRep.BandCount;idxband++)
			{
				if(Generic.CT(OrgRep.GetBand(idxband).Name,"footer"))
				{
					band=new Band(OrgRep);
					band.Assign(OrgRep.GetBand(idxband));
					for(int i=0;i<band.CellCount;i++)
					{
						ApplyValues(OrgRep.GetBand(idxband).GetCell(i),band.GetCell(i),CurrRep);
					}
					if(page!=CurrRep.LastPage)
					{
						CurrRep.Insert(index,band);
						footercount++;
					}
					else
					{					
						band.NewPage(page);
						CurrRep.GetBand(index).Page=false;
						CurrRep.Add(band);	
						footercount++;
					}
				}
			}
		}

		// This method calculate every pages last band. If a band 
		// is  a pages first band call NewPage method.
		void CalculateLastBands()
		{
			float celltop=0;
			float curtop=0;
			int page=1;
			Rep CurrRep;

			for(int i=0;i<SourceRep.RepList.Count;i++)
			{
				SetRep(SourceRep.GetOrgRep(i));
				CurrRep=SourceRep.GetSrcRep(i);
				for(int idxband=0;idxband<CurrRep.BandCount;idxband++)
				{	
					if(idxband==0)
					{
						CurrRep.GetBand(idxband).NewPage(page);
						celltop=0;
						page++;
					}
					if(CurrRep.GetBand(idxband).BandState.ToString().IndexOf("PageBreak")!=-1)
					{
						CurrRep.GetBand(idxband).NewPage(page);
						page++;
						celltop=0;
					}

					if(CurrRep.GetBand(idxband).BandState.ToString().IndexOf("BeginPara")!=-1)
					{
						curtop=celltop;
						for(int idxband2=idxband;idxband2<CurrRep.BandCount;idxband2++)
						{
							curtop=curtop+CurrRep.GetBand(idxband2).Height;
							if(curtop>=BottomMargin)
							{
								CurrRep.GetBand(idxband).NewPage(page);
								page++;
								celltop=CurrRep.GetBand(idxband).Height;
								break;
							}
							else
							{
								if(CurrRep.GetBand(idxband2).BandState.ToString().IndexOf("EndPara")!=-1)
								{
									break;
								}
							}
						}
					}
					if((!Generic.CT(CurrRep.GetBand(idxband).Name,"header"))||
						(!Generic.CT(CurrRep.GetBand(idxband).Name,"footer")))
						celltop=celltop+CurrRep.GetBand(idxband).Height;
					if(celltop>=BottomMargin)
					{
						CurrRep.GetBand(idxband).NewPage(page);
						page++;
						celltop=CurrRep.GetBand(idxband).Height;
					}
					if(idxband==CurrRep.BandCount-1)
					{
						CurrRep.GetBand(idxband).NewPage(page);
					}
				}
			}
			Pagecnt=page;
		}

		// This method calculate FooterHeight, HeaderHeight, BlankCellWidth
		// and margins. Called from CalculateLastBands method.
		void SetRep(Rep OrgRep)
		{
			HeaderHeight=0;
			FooterHeight=0;
			TopMargin=0;
			BottomMargin=0;
			
			for(int idxband=0;idxband<OrgRep.BandCount;idxband++)
			{
				if(ReportLibrary.Generic.CT(OrgRep.GetBand(idxband).Name,"Footer"))
				{
					FooterHeight=FooterHeight+OrgRep.GetBand(idxband).Height;
				}
			}
			for(int idxband=0;idxband<OrgRep.BandCount;idxband++)
			{
				if(ReportLibrary.Generic.CT(OrgRep.GetBand(idxband).Name,"Header"))
				{
					HeaderHeight=HeaderHeight+OrgRep.GetBand(idxband).Height;
				}
			}
			if(OrgRep.Orientation==PrinterOrientation.Portrait)
			{
				TopMargin=Generic.PrintToMM((int)OrgRep.TopMargin);
				BottomMargin=OrgRep.PageSize.PaperSize.Height-FooterHeight-Generic.PrintToMM((int)OrgRep.BottomMargin)-HeaderHeight-TopMargin;
				BlankCellWidth=OrgRep.PageSize.PaperSize.Width-Generic.PrintToMM((int)OrgRep.LeftMargin)-Generic.PrintToMM((int)OrgRep.RightMargin);
			}
			else
			{
				TopMargin=Generic.PrintToMM((int)OrgRep.TopMargin);
				BottomMargin=OrgRep.PageSize.PaperSize.Width-FooterHeight-Generic.PrintToMM((int)OrgRep.BottomMargin)-HeaderHeight-TopMargin;
				BlankCellWidth=OrgRep.PageSize.PaperSize.Height-Generic.PrintToMM((int)OrgRep.LeftMargin)-Generic.PrintToMM((int)OrgRep.RightMargin);
			}
			LeftMargin=Generic.PrintToMM((int)OrgRep.LeftMargin);
			RightMargin=OrgRep.PageSize.PaperSize.Width-LeftMargin;
		}

		/// <summary>
		/// When UserRep Progress events isn't equal null, you can
		/// call this method.If you use standart Viewer application
		/// Progress event always usable, so you can call this method.
		/// </summary>
		/// <param name="AMax">Maximum number</param>
		public void ProgressStart(int AMax)
		{
			FMax=AMax;
			FPos=0;
			if(Progress!=null)
			{
				ProgressEventArgs e=new ProgressEventArgs();
				e.Stage=ProgressStage.Starting;
				e.PercentDone=0;
				Progress(this,e);
			}
		}

		/// <summary>
		/// When UserRep Progress events isn't equal null, you can
		/// call this method.If you use standart Viewer
		/// application Progress event always usable, so you can call 
		/// this method.
		/// </summary>
		public void ProgressStep()
		{
			FPos++;
			if(Progress!=null)
			{
				ProgressEventArgs e=new ProgressEventArgs();
				e.Stage=ProgressStage.Running;
				e.PercentDone=(FPos*100)/FMax;
				Progress(this,e);
			}
		}

		/// <summary>
		/// When UserRep Progress events isn't equal null, you can
		/// call this method.If you use standart Viewer
		/// application Progress event always usable, so you can call 
		/// this method.
		/// </summary>
		public void ProgressStop()
		{
			if(Progress!=null)
			{
				ProgressEventArgs e=new ProgressEventArgs();
				e.Stage=ProgressStage.Ending;
				e.PercentDone=100;
				Progress(this,e);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Size size;
			if(SrcRep.Orientation==PrinterOrientation.Portrait)
				size=new Size((int)(SrcRep.PageSize.PaperSize.Width*Generic.ZoomFactor),(int)(SrcRep.PageSize.PaperSize.Height*Generic.ZoomFactor));
			else
				size=new Size((int)(SrcRep.PageSize.PaperSize.Height*Generic.ZoomFactor),(int)(SrcRep.PageSize.PaperSize.Width*Generic.ZoomFactor));
			if(size.Width<Size.Width)
				UserLeft=(Size.Width-size.Width)/2;
			else
				UserLeft=25;
			if(size.Height<Size.Height)
				UserTop=(Size.Height-size.Height)/2;
			else
				UserTop=25;
			base.OnPaint(e);
		}

		/// <summary>
		/// If you not want displaying every page your Plugin control
		/// you can call this method.
		/// </summary>
		/// <param name="PlugIn">Unregistered Plugin</param>
		public void UnRegisterPlugIn(UserRepPlugIn PlugIn)
		{
			int idx=FPlugInList.IndexOf(PlugIn);
			if(idx!=-1)
			{
				FPlugInList.RemoveAt(idx);
			}
		}

		/// <summary>
		/// When you assigned your Plugin UserRep property this method
		/// called automatically.
		/// </summary>
		/// <param name="PlugIn">Registered plugin</param>
		public void RegisterPlugIn(UserRepPlugIn PlugIn)
		{
			if(FPlugInList.IndexOf(PlugIn)==-1)
			{
				FPlugInList.Add(PlugIn);
				PlugInList.AddObject(PlugIn.AssemblyPath,PlugIn);
			}
		}

		/// <summary>
		/// This method starts to create report document.
		/// </summary>
		public void BeginReport()
		{
			SourceRep.OrgRepList.RemoveRange(0,SourceRep.OrgRepList.Count);
			SourceRep.RepList.RemoveRange(0,SourceRep.RepList.Count);
			Zoom=Zoom.hundred;
		}

		/// <summary>
		/// When you finished your report you can call this method for
		/// viewing first page.
		/// </summary>
		public void ShowReport()
		{
			CalculateLastBands();
			PrepareSourceRep();
			ShowPage(1,true);
		}

		// This function prepare report pages.
		void PrepareSourceRep()
		{
			Band band;
			int firstband;
			int lastband;
			float heightcount;
			Rep CurrRep;
			Rep OrgRep;

			for(int i=0;i<SourceRep.RepList.Count;i++)
			{
				SetRep(SourceRep.GetOrgRep(i));
				CurrRep=SourceRep.GetSrcRep(i);
				OrgRep=SourceRep.GetOrgRep(i);
				for(int page=CurrRep.FirstPage;page<CurrRep.LastPage;page++)
				{
					heightcount=0;
					firstband=0;
					lastband=0;	
					SourceRep.SetInt32("Page",page);
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
				
					bool header=false;
					for(int idxband=firstband;idxband<lastband+1;idxband++)
					{
						if(Generic.CT(CurrRep.GetBand(idxband).Name,"header"))
						{
							header=true;
							break;
						}
					}
					if(!header)
					{
						int headercount;
						ShowHeader(firstband,page,out headercount,OrgRep,CurrRep);
						lastband=lastband+headercount;
					}
					int footercount;
					ShowFooter(lastband,page+1,out footercount,OrgRep,CurrRep);
					lastband=lastband+footercount;
				
					for(int idxband=firstband;idxband<lastband;idxband++)
					{
						if(!(Generic.CT(CurrRep.GetBand(idxband).Name,"header"))||
							(Generic.CT(CurrRep.GetBand(idxband).Name,"footer")))
							heightcount=heightcount+CurrRep.GetBand(idxband).Height;
					}
					if(page==CurrRep.LastPage-1)
						heightcount=heightcount+CurrRep.GetBand(lastband).Height;
					if(heightcount<BottomMargin)
					{
						if((Generic.CT(CurrRep.GetBand(lastband-1).Name,"Footer"))
							||(Generic.CT(CurrRep.GetBand(lastband).Name,"Footer")))
						{
							band=new Band(CurrRep);
							band.Name="Blank";
							while(band.CellCount>1)
								band.DeleteCell(0);
							band.GetCell(0).Width=BlankCellWidth;
							band.Height=BottomMargin-heightcount;
						
							if(page!=CurrRep.LastPage-1)
								CurrRep.Insert(lastband-1,band);
							else
								CurrRep.Insert(lastband,band);
						}
						else
						{
							band=new Band(CurrRep);
							band.Name="Blank";
							while(band.CellCount>1)
								band.DeleteCell(0);
							band.GetCell(0).Width=BlankCellWidth;
							band.Height=BottomMargin-heightcount;
						
							if(page!=CurrRep.LastPage-1)
								CurrRep.Insert(lastband,band);
							else
							{
								band.NewPage(page+1);					
								CurrRep.GetBand(lastband).Page=false;
								CurrRep.Add(band);
							}
						}
					}			
				}			
			}
		}

		/// <summary>
		/// If you call AddGroupBand method this method 
		/// adding a node to current NodeCollection.
		/// </summary>
		/// <param name="Value">Node's value</param>
		/// <param name="Node">Node's parent value. Must be greater 
		/// than zero</param>
		public void AddNode(string Value,int Node)
		{
			TreeNode node=new TreeNode(Value);
			try
			{
				if(Node>1)
				{
					TreeNodeCollection coll=((TreeNode)NodeCollection[NodeCollection.Count-1]).Nodes;
					if(Node==2)	
					{
						node.Tag=2;
						coll.Add(node);
						return;
					}
					coll=coll[coll.Count-1].Nodes;
					if(Node==3)
					{
						node.Tag=3;
						coll.Add(node);
						return;
					}
					coll=coll[coll.Count-1].Nodes;
					if(Node==4)
					{
						node.Tag=4;
						coll.Add(node);
						return;
					}
					coll=coll[coll.Count-1].Nodes;
					if(Node==5)
					{
						node.Tag=5;
						coll.Add(node);
						return;
					}
					coll=coll[coll.Count-1].Nodes;
					if(Node>=6)
					{
						node.Tag=6;
						coll.Add(node);
						return;
					}
				}
				else
				{
					node.Tag=1;
					NodeCollection.Add(node);
					return;
				}
			}
			catch
			{
				MessageBox.Show("Invalid nodes");
			}
		}

		/// <summary>
		/// When you want to added GroupBands to report with nodes you 
		/// can call this method. If Value parameter already exist in
		/// report this band isn't added.
		/// </summary>
		/// <param name="BandName">Adding band name</param>
		/// <param name="Value">Band value</param>
		/// <param name="Node">Node's parent value. Must be greater 
		/// than zero</param>
		/// <returns>This method returns adding group band</returns>
		public Band AddGroupBands(string BandName,string Value,int Node)
		{
			int idx;
			Band freturn=null;
			
			if(!(Generic.CT(GroupBands.GetValue(BandName),Value)))
			{
				SetString(BandName,Value);
				AddNode(Value,Node);				
				freturn=AddBands(BandName);
				freturn.Node=Node;
				freturn.NodeValue=Value;
				GroupBands.SetValue(BandName,Value);
				idx=GroupBands.IndexOfName(BandName);
				for(int j=idx+1;j<GroupBands.Count;j++)
					GroupBands.SetString(j,"");
			}
			return freturn;
		}

		/* This method added a band to current report */
		protected void InternalAddBands(string BandName,List bandlist,Rep OrgRep,Rep CurrRep)
		{
			Band B;
			float H;

			for(int idx=0;idx<FPlugInList.Count;idx++)
			{
				((UserRepPlugIn)FPlugInList[idx]).ApplyValues();
			}
			
			for(int idxband=0;idxband<OrgRep.BandCount;idxband++)
			{
				if(Generic.CT(OrgRep.GetBand(idxband).Name,BandName))
				{
					B=new Band(OrgRep);
					bandlist.Add(B);
					B.Assign(OrgRep.GetBand(idxband));
					for(int idxcell=0;idxcell<B.CellCount;idxcell++)
					{
						ApplyValues(OrgRep.GetBand(idxband).GetCell(idxcell),B.GetCell(idxcell),CurrRep);
					
						Graphics gr=CreateGraphics();
						Font font=new Font(B.GetCell(idxcell).FontName,B.GetCell(idxcell).FontSize,B.GetCell(idxcell).FontStyle);
						H=B.GetCell(idxcell).Height(gr,font);
						gr.Dispose();
						if(H>B.Height)
						{
							B.Height=H;
						}
					}
				}
			}
		}

		/// <summary>
		/// This method applies to a cell string, image, control values.
		/// </summary>
		/// <param name="src">Source cell</param>
		/// <param name="dst">Destination cell</param>
		/// <param name="CurrRep">Current Rep</param>
		public void ApplyValues(Cell src,Cell dst,Rep CurrRep)
		{
			dst.Value="";
			dst.MinWidth=src.Width;
			if(src.VarNameList!=null)
			{
				for(int i=0;i<src.VarNameList.Count;i++)
				{
					if((int)src.VarNameList.GetObject(i)==0)
					{
						dst.Value=dst.Value+src.VarNameList.GetString(i);
					}
					else
					{						
						if(GetImage(src.VarNameList.GetString(i))!=null)
						{
							dst.Picture=GetImage(src.VarNameList.GetString(i));
						}
						if(GetControl(src.VarNameList.GetString(i))!=null)
						{
							dst.Control=GetControl(src.VarNameList.GetString(i));
							dst.ControlName=src.VarNameList.GetString(i);
							dst.Control.Parent=this;
							dst.Control.Visible=false;
						}
						if((GetImage(src.VarNameList.GetString(i))==null)&&(GetControl(src.VarNameList.GetString(i))==null))
							dst.Value=dst.Value+GetString(src.VarNameList.GetString(i));
					}
				}
			}
		}

		/// <summary>
		/// When you creating a report you must call this function 
		/// with specified report template file.
		/// </summary>
		/// <param name="FileName">Report template file name</param>
		public void Load(string FileName)
		{
			SourceRep.Load(FileName);
		}

		/// <summary>
		/// If you want a band a pages last band you can call this
		/// method when after adding this band.
		/// </summary>
		public void PageBreak()
		{
			NextTopBandState|=BandState.PageBreak;
		}

		/// <summary>
		/// If you not want bands break a page call this method 
		/// </summary>
		public void BeginPara()
		{
			EndPara();
			NextTopBandState|=BandState.BeginPara;
		}

		public void EndPara()
		{
			if(SourceRep.CurrRep.BandCount>0)
			{
				SourceRep.CurrRep.GetBand(SourceRep.CurrRep.BandCount-1).BandState|=BandState.EndPara;
			}
			if(NextTopBandState.ToString().IndexOf("EndPara")!=-1)
				NextTopBandState=(BandState)((int)NextTopBandState-(int)BandState.EndPara);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			int idxband,idxcell;

			if(Pan)
			{
				Cursor=new Cursor(GetType(),"cur204.cur");
				ClearSel();
				OldX=e.X;
				OldY=e.Y;
			}
			else
			{
				if(MouseToCell(e.X,e.Y,out idxband,out idxcell)!=null)
				{
					if(!(ModifierKeys==Keys.Control))
						ClearSel();
					SelAdd(idxband,idxcell);
					CurrBandIdx=idxband;
					CurrCellIdx=idxcell;
				
					SelectCellEventArgs selectcellargs=new SelectCellEventArgs();
					selectcellargs.idxband=CurrBandIdx;
					selectcellargs.idxcell=CurrCellIdx;
					if(SelectCell!=null)
						SelectCell(this,selectcellargs);
					Invalidate();
				}
				else
				{
					if((idxband!=-1)&&(e.X<Gutter))
					{
						SelectBandEventArgs selarg=new SelectBandEventArgs();
						selarg.idxband=idxband;
						if(SelectBand!=null)
							SelectBand(this,selarg);					
					}
				}
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp (e);
			if(Pan)
			{
				Cursor=new Cursor(GetType(),"cur200.cur");
			}
		}


		protected override void OnMouseMove(MouseEventArgs e)
		{
			Cell cell;
			int idxband,idxcell;
			int NewX;
			int NewY;

			if(Pan)
			{
				if(e.Button==MouseButtons.Left)
				{
					NewX=e.X;
					NewY=e.Y;
					TopY=TopY-(NewY-OldY);
					LeftX=LeftX-(NewX-OldX);
				}
			}
			else
			{
				if(e.Button==MouseButtons.Left)
				{
					if(e.Y<0)
					{
						TopY=TopY-10;
					}
					else
					{
						if(e.Y>Height)
						{
							TopY=TopY+10;
						}
						else
						{
							cell=MouseToCell(e.X,e.Y,out idxband,out idxcell);
							if(cell!=null)
							{
								if(CurrCell!=cell)
								{
									SelAdd(idxband,idxcell);
									CurrBandIdx=idxband;
									CurrCellIdx=idxcell;
				
									SelectCellEventArgs selectcellargs=new SelectCellEventArgs();
									selectcellargs.idxband=CurrBandIdx;
									selectcellargs.idxcell=CurrCellIdx;
									if(SelectCell!=null)
										SelectCell(this,selectcellargs);
									Invalidate();
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// You can call this method when you want a datarow values
		/// to applies a band.
		/// </summary>
		/// <param name="DT">Associated data table</param>
		/// <param name="DR">Associated datarow</param>
		public void SetDTValues(DataTable DT,DataRow DR)
		{
			for(int i=0;i<DT.Columns.Count;i++)
			{
				if(DR[i]!=System.DBNull.Value)
				{
					if(DT.Columns[i].DataType==System.Type.GetType("System.Int32"))
						SetInt32(DT.Columns[i].ColumnName,(System.Int32)DR[i]);

					else if(DT.Columns[i].DataType==System.Type.GetType("System.Boolean"))
						SetBoolean(DT.Columns[i].ColumnName,(System.Boolean)DR[i]);

					else if(DT.Columns[i].DataType==System.Type.GetType("System.Byte"))
						SetByte(DT.Columns[i].ColumnName,(System.Byte)DR[i]);

					else if(DT.Columns[i].DataType==System.Type.GetType("System.Char"))
						SetChar(DT.Columns[i].ColumnName,(System.Char)DR[i]);

					else if(DT.Columns[i].DataType==System.Type.GetType("System.DateTime"))
						SetDateTime(DT.Columns[i].ColumnName,(System.DateTime)DR[i]);
                
					else if(DT.Columns[i].DataType==System.Type.GetType("System.Decimal"))
						SetDecimal(DT.Columns[i].ColumnName,(System.Decimal)DR[i]);

					else if(DT.Columns[i].DataType==System.Type.GetType("System.Double"))
						SetDouble(DT.Columns[i].ColumnName,(System.Double)DR[i]);

					else if(DT.Columns[i].DataType==System.Type.GetType("System.Int16"))
						SetInt16(DT.Columns[i].ColumnName,(System.Int16)DR[i]);

					else if(DT.Columns[i].DataType==System.Type.GetType("System.Int64"))
						SetInt64(DT.Columns[i].ColumnName,(System.Int64)DR[i]);

					else if(DT.Columns[i].DataType==System.Type.GetType("System.Single"))
						SetSingle(DT.Columns[i].ColumnName,(System.Single)DR[i]);

					else if(DT.Columns[i].DataType==System.Type.GetType("System.String"))
						SetString(DT.Columns[i].ColumnName,(System.String)DR[i]);

					else if(DT.Columns[i].DataType==System.Type.GetType("System.TimeSpan"))
						SetTimeSpan(DT.Columns[i].ColumnName,(System.TimeSpan)DR[i]);
				}
				else
				{
					CultureInfo inf=new CultureInfo("en");
					SourceRep.Vars.SetValue(DT.Columns[i].ColumnName.ToUpper(inf),"");
				}
			}
		}

		/// <summary>
		/// You can call this method when you want a int value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">An int value you want to applies 
		/// a cell </param>
		public override void SetInt32(string VarName,int VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			SourceRep.Vars.SetValue(VarName.ToUpper(inf),VarValue.ToString());
			SourceRep.Vars.InsertObject(SourceRep.Vars.IndexOfName(VarName.ToUpper(inf)),(int)ValueFlag.None);
		}

		/// <summary>
		/// You can call this method when you want a boolean value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">A boolean value you want to applies 
		/// a cell </param>
		public void SetBoolean(string VarName,bool VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			SourceRep.Vars.SetValue(VarName.ToUpper(inf),VarValue.ToString());
			SourceRep.Vars.InsertObject(SourceRep.Vars.IndexOfName(VarName.ToUpper(inf)),(int)ValueFlag.None);
		}

		/// <summary>
		/// You can call this method when you want a byte value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">A byte value you want to applies 
		/// a cell </param>
		public void SetByte(string VarName,byte VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			SourceRep.Vars.SetValue(VarName.ToUpper(inf),VarValue.ToString());
			SourceRep.Vars.InsertObject(SourceRep.Vars.IndexOfName(VarName.ToUpper(inf)),(int)ValueFlag.None);
		}

		/// <summary>
		/// You can call this method when you want a byte value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">A byte value you want to applies 
		/// a cell </param>
		public void SetChar(string VarName,char VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			SourceRep.Vars.SetValue(VarName.ToUpper(inf),VarValue.ToString());
			SourceRep.Vars.InsertObject(SourceRep.Vars.IndexOfName(VarName.ToUpper(inf)),(int)ValueFlag.None);
		}

		/// <summary>
		/// You can call this method when you want a DateTime value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">A DateTime value you want to applies 
		/// a cell </param>
		public void SetDateTime(string VarName,DateTime VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			SourceRep.Vars.SetValue(VarName.ToUpper(inf),string.Format("{0:d}",VarValue));
			SourceRep.Vars.InsertObject(SourceRep.Vars.IndexOfName(VarName.ToUpper(inf)),(int)ValueFlag.None);
		}

		/// <summary>
		/// You can call this method when you want a decimal value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">A decimal value you want to applies 
		/// a cell </param>
		public void SetDecimal(string VarName,decimal VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			SourceRep.Vars.SetValue(VarName.ToUpper(inf),VarValue.ToString("C2"));
			SourceRep.Vars.InsertObject(SourceRep.Vars.IndexOfName(VarName.ToUpper(inf)),(int)ValueFlag.Money);
		}

		/// <summary>
		/// You can call this method when you want a double value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">A double value you want to applies 
		/// a cell </param>
		public void SetDouble(string VarName,double VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			SourceRep.Vars.SetValue(VarName.ToUpper(inf),string.Format("{0:f2}",VarValue));
			SourceRep.Vars.InsertObject(SourceRep.Vars.IndexOfName(VarName.ToUpper(inf)),(int)ValueFlag.None);
		}

		/// <summary>
		/// You can call this method when you want a int16 value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">An int16 value you want to applies 
		/// a cell </param>
		public void SetInt16(string VarName,Int16 VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			SourceRep.Vars.SetValue(VarName.ToUpper(inf),VarValue.ToString());
			SourceRep.Vars.InsertObject(SourceRep.Vars.IndexOfName(VarName.ToUpper(inf)),(int)ValueFlag.None);
		}

		/// <summary>
		/// You can call this method when you want a int64 value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">An int64 value you want to applies 
		/// a cell </param>
		public void SetInt64(string VarName,Int64 VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			SourceRep.Vars.SetValue(VarName.ToUpper(inf),VarValue.ToString());
			SourceRep.Vars.InsertObject(SourceRep.Vars.IndexOfName(VarName.ToUpper(inf)),(int)ValueFlag.None);
		}

		/// <summary>
		/// You can call this method when you want a single value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">A single value you want to applies 
		/// a cell </param>
		public void SetSingle(string VarName,Single VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			SourceRep.Vars.SetValue(VarName.ToUpper(inf),VarValue.ToString());
			SourceRep.Vars.InsertObject(SourceRep.Vars.IndexOfName(VarName.ToUpper(inf)),(int)ValueFlag.None);
		}

		/// <summary>
		/// You can call this method when you want a string value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">A string value you want to applies 
		/// a cell </param>
		public void SetString(string VarName,string VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			SourceRep.Vars.SetValue(VarName.ToUpper(inf),VarValue);
			SourceRep.Vars.InsertObject(SourceRep.Vars.IndexOfName(VarName.ToUpper(inf)),(int)ValueFlag.None);
		}

		/// <summary>
		/// You can call this method when you want a TimeSpan value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">A TimeSpan value you want to applies 
		/// a cell </param>
		public void SetTimeSpan(string VarName,TimeSpan VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			SourceRep.Vars.SetValue(VarName.ToUpper(inf),VarValue.ToString());
			SourceRep.Vars.InsertObject(SourceRep.Vars.IndexOfName(VarName.ToUpper(inf)),(int)ValueFlag.None);
		}

		/// <summary>
		/// You can call this method when you want an image value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">An image value you want to applies 
		/// a cell </param>
		public void SetImage(string VarName,Image VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			VarName=VarName.ToUpper(inf);
			int idx=SourceRep.PictureList.IndexOf(VarName);
			if(idx==-1)
			{
				SourceRep.PictureList.AddObject(VarName,VarValue);
				idx=SourceRep.PictureList.IndexOf(VarName);
			}
			else
			{
				SourceRep.PictureList.RemoveAt(idx);
				SourceRep.PictureList.InsertAll(idx,VarName,VarValue);
			}
		}

		/// <summary>
		/// You can call this method when you want a System.WindowsForms.Control value
		/// to applies a band.
		/// </summary>
		/// <param name="VarName">Associated variable name</param>
		/// <param name="VarValue">A System.WindowsForms.Control value you want to applies 
		/// a cell </param>
		public void SetControl(string VarName,Control VarValue)
		{
			CultureInfo inf=new CultureInfo("en");
			VarName=VarName.ToUpper(inf);
			int idx=SourceRep.ControlList.IndexOf(VarName);
			if(idx==-1)
			{
				SourceRep.ControlList.AddObject(VarName,VarValue);
				idx=SourceRep.ControlList.IndexOf(VarName);
			}
			else
			{
				SourceRep.ControlList.RemoveAt(idx);
				SourceRep.ControlList.InsertAll(idx,VarName,VarValue);
			}
		}

		/// <summary>
		/// You can call this method when you want to learn a cell variables
		/// value.
		/// </summary>
		/// <param name="VarName">Associated variable name.</param>
		/// <returns>Variable value.</returns>
		public string GetString(string VarName)
		{
			CultureInfo inf=new CultureInfo("en");
			return SourceRep.Vars.GetValue(VarName.ToUpper(inf));
		}

		/// <summary>
		/// You can call this method when you want to learn a cell variables
		/// value.
		/// </summary>
		/// <param name="VarName">Associated variable name.</param>
		/// <returns>Variable value.</returns>
		public Int32 GetInt32(string VarName)
		{
			try
			{
				CultureInfo inf=new CultureInfo("en");
				return Convert.ToInt32(SourceRep.Vars.GetValue(VarName.ToUpper(inf)));
			}
			catch
			{
				return 0;
			}
		}

		/// <summary>
		/// You can call this method when you want to learn a cell variables
		/// value.
		/// </summary>
		/// <param name="VarName">Associated variable name.</param>
		/// <returns>Variable value.</returns>
		public bool GetBoolean(string VarName)
		{
			try
			{
				CultureInfo inf=new CultureInfo("en");
				return Convert.ToBoolean(SourceRep.Vars.GetValue(VarName.ToUpper(inf)));
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// You can call this method when you want to learn a cell variables
		/// value.
		/// </summary>
		/// <param name="VarName">Associated variable name.</param>
		/// <returns>Variable value.</returns>
		public System.Byte GetByte(string VarName)
		{
			try
			{
				CultureInfo inf=new CultureInfo("en");
				return Convert.ToByte(SourceRep.Vars.GetValue(VarName.ToUpper(inf)));
			}
			catch
			{
				return 0;
			}
		}

		/// <summary>
		/// You can call this method when you want to learn a cell variables
		/// value.
		/// </summary>
		/// <param name="VarName">Associated variable name.</param>
		/// <returns>Variable value.</returns>
		public Char GetChar(string VarName)
		{
			try
			{
				CultureInfo inf=new CultureInfo("en");
				return Convert.ToChar(SourceRep.Vars.GetValue(VarName.ToUpper(inf)));
			}
			catch
			{
				return (char)0;
			}
		}

		/// <summary>
		/// You can call this method when you want to learn a cell variables
		/// value.
		/// </summary>
		/// <param name="VarName">Associated variable name.</param>
		/// <returns>Variable value.</returns>
		public DateTime GetDateTime(string VarName)
		{
			try
			{
				CultureInfo inf=new CultureInfo("en");
				return Convert.ToDateTime(SourceRep.Vars.GetValue(VarName.ToUpper(inf)));
			}
			catch
			{
				return DateTime.Now;
			}
		}

		/// <summary>
		/// You can call this method when you want to learn a cell variables
		/// value.
		/// </summary>
		/// <param name="VarName">Associated variable name.</param>
		/// <returns>Variable value.</returns>
		public Decimal GetDecimal(string VarName)
		{
			try
			{
				CultureInfo inf=new CultureInfo("en");
				return Convert.ToDecimal(SourceRep.Vars.GetValue(VarName.ToUpper(inf)));
			}
			catch
			{
				return 0;
			}
		}

		/// <summary>
		/// You can call this method when you want to learn a cell variables
		/// value.
		/// </summary>
		/// <param name="VarName">Associated variable name.</param>
		/// <returns>Variable value.</returns>
		public Double GetDouble(string VarName)
		{
			try
			{
				CultureInfo inf=new CultureInfo("en");
				return Convert.ToDouble(SourceRep.Vars.GetValue(VarName.ToUpper(inf)));
			}
			catch
			{
				return 0;
			}
		}

		/// <summary>
		/// You can call this method when you want to learn a cell variables
		/// value.
		/// </summary>
		/// <param name="VarName">Associated variable name.</param>
		/// <returns>Variable value.</returns>
		public Int16 GetInt16(string VarName)
		{
			try
			{
				CultureInfo inf=new CultureInfo("en");
				return Convert.ToInt16(SourceRep.Vars.GetValue(VarName.ToUpper(inf)));
			}
			catch
			{
				return 0;
			}
		}

		/// <summary>
		/// You can call this method when you want to learn a cell variables
		/// value.
		/// </summary>
		/// <param name="VarName">Associated variable name.</param>
		/// <returns>Variable value.</returns>
		public Int64 GetInt64(string VarName)
		{
			try
			{
				CultureInfo inf=new CultureInfo("en");
				return Convert.ToInt64(SourceRep.Vars.GetValue(VarName.ToUpper(inf)));
			}
			catch
			{
				return 0;
			}
		}

		/// <summary>
		/// You can call this method when you want to learn a cell variables
		/// value.
		/// </summary>
		/// <param name="VarName">Associated variable name.</param>
		/// <returns>Variable value.</returns>
		public Single GetSingle(string VarName)
		{
			try
			{
				CultureInfo inf=new CultureInfo("en");
				return Convert.ToSingle(SourceRep.Vars.GetValue(VarName.ToUpper(inf)));
			}
			catch
			{
				return 0;
			}
		}

		/// <summary>
		/// You can call this method when you want to learn a cell variables
		/// value.
		/// </summary>
		/// <param name="VarName">Associated variable name.</param>
		/// <returns>Variable value.</returns>
		public Image GetImage(string VarName)
		{
			CultureInfo inf=new CultureInfo("en");
			int idx=SourceRep.PictureList.IndexOf(VarName.ToUpper(inf));
			if(idx!=-1)
				return (Image)SourceRep.PictureList.GetObject(idx);
			else
				return null;
		}

		/// <summary>
		/// You can call this method when you want to learn a cell variables
		/// value.
		/// </summary>
		/// <param name="VarName">Associated variable name.</param>
		/// <returns>Variable value.</returns>
		public Control GetControl(string VarName)
		{
			CultureInfo inf=new CultureInfo("en");
			int idx=SourceRep.ControlList.IndexOf(VarName.ToUpper(inf));
			if(idx!=-1)
				return (Control)SourceRep.ControlList.GetObject(idx);
			else
				return null;
		}

		/// <summary>
		/// When you want to add a band call this method.
		/// </summary>
		/// <param name="BandName">Band name</param>
		/// <returns>A band you added.</returns>
		public Band AddBands(string BandName)
		{
			Band freturn;
			Rep CurrRep=SourceRep.GetSrcRep(SourceRep.RepList.Count-1);
			Rep OrgRep=SourceRep.GetOrgRep(SourceRep.OrgRepList.Count-1);
			List bl=new List("UserRep.AddBands bl");

			freturn=null;
            
			InternalAddBands(BandName,bl,OrgRep,CurrRep);
			for(int i=0;i<bl.Count;i++)
			{
				CurrRep.Add((Band)bl[i]);
			}
			if(bl.Count>0)
			{
				freturn=(Band)bl[bl.Count-1];
				((Band)bl[0]).BandState=NextTopBandState;
				NextTopBandState=(BandState)0;
			}
			return freturn;
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
		}
		#endregion		
	}
	#endregion

	#region UserRepPlugIn
	/// <summary>
	/// This class is base class for your plugin
	/// </summary>
	[ToolboxItem(false)]
	public class UserRepPlugIn:Component
	{
		#region class variables
		public StringList FVarList;
		UserRep FUserRep;
		public string AssemblyPath;
		#endregion

		#region class methods
		/// <summary>
		/// You can override this method to create control.
		/// </summary>
		/// <returns>Must be your created control</returns>
		protected virtual object CreateVar()
		{
			return null;
		}

		/// <summary>
		/// You can use this method to return control with associated
		/// index.
		/// </summary>
		/// <param name="index">An int value</param>
		/// <returns>An object value</returns>
		protected object GetVarByIndex(int index)
		{			
			return FVarList.GetObject(index);			
		}

		/// <summary>
		/// You can use this method to return control with
		/// associated string value.
		/// </summary>
		/// <param name="VarName">A string value.</param>
		/// <returns>An object value.</returns>
		public object GetObjectByName(string VarName)
		{
			int idx;
			object tmp;

			if(FVarList==null)
			{
				FVarList=new StringList("");
				FVarList.Sorted=true;
			}

			idx=FVarList.IndexOf(VarName);
			if(idx==-1)
			{
				tmp=CreateVar();
				FVarList.AddObject(VarName,tmp);
				return tmp;
			}
			else
			{
				return FVarList.GetObject(idx);
			}
		}

		/// <summary>
		/// You can use this method to return variable name with
		/// associated index.
		/// </summary>
		/// <param name="index">An int value.</param>
		/// <returns>A string value.</returns>
		protected string GetVarNames(int index)
		{
			return FVarList.GetString(index);
		}

		/// <summary>
		/// You must override this method to adding new proterties 
		/// to your control.
		/// </summary>
		public virtual void ApplyValues()
		{
		}
		#endregion

		#region constructor
		/// <summary>
		/// You must assigned AssemblyPath value.
		/// </summary>
		public UserRepPlugIn()
		{
			FVarList=new StringList("");
			FVarList.Sorted=true;
		}
		#endregion

		#region class properties
		/// <summary>
		/// You must assigned an UserRep to your plugin control.
		/// </summary>
		public UserRep UserRep
		{
			get
			{
				return FUserRep;
			}
			set
			{
				if(FUserRep!=value)
				{
					if(FUserRep!=null)
					{
						FUserRep.UnRegisterPlugIn(this);
					}
					FUserRep=value;
					if(FUserRep!=null)
					{
						FUserRep.RegisterPlugIn(this);
					}
				}
			}
		}

		/// <summary>
		/// Returns control variable count.
		/// </summary>
		public int VarCount
		{
			get
			{
				return FVarList.Count;
			}
		}
		#endregion	
	}
	#endregion

	#region enums
	public enum ValueFlag
	{
		None,Money
	}

	public enum ProgressStage
	{
		Starting,Running,Ending
	}
	#endregion

	#region ProgressEventArgs
	public class ProgressEventArgs
	{
		public ProgressStage Stage;
		public int PercentDone;
	}
	#endregion

	#region delegates
	public delegate void ProgressEventHandler(object sender,ProgressEventArgs arg);
	#endregion
}
