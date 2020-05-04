using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Windows.Forms.Reports.ReportLibrary
{
	[ToolboxItem(false)]
	public class EditRep:GridRep
	{
		#region class variables
		public static int TmpBandIdx;
		public static int TmpCellIdx;

		public static int OldY;
		public static float OldHeight;

		public static int OldX;
		public static float OldWidth;
		public static bool InGutterShift;

		public bool Modified;
		public Undo Undo;
		public String FileName;

		public int ControlFlag;
		#endregion

		#region class events
		public event EventHandler ResizeGutter;
		public event ResizeBantEventHandler ResizeBant;
		public event ResizeCellEventHandler ResizeCell;		
		public event SelectBandEventHandler SelectBand;
		public event SelectCellEventHandler SelectCell;
		public event EventHandler Change;
		#endregion
		
		#region constructor
		public EditRep()
		{
			ShowMargins=true;
			FShowBandTitle=true;
			if(GridX==0)
				GridX=4;
			if(GridY==0)
				GridY=4;
			if(Gutter==0)
				Gutter=100;

			Arrange();
			Zoom=Zoom.hundred;
			Generic.OldZoomFactor=1;
			Generic.ZoomFactor=1.0F;
			SrcRep.CellArrangement();
			Owner=this;
		}

		void Arrange()
		{
			int height=1169;
			int width=827;
			for(int idxband=0;idxband<SrcRep.BandCount;idxband++)
			{
				SrcRep.GetBand(idxband).Height=height/SrcRep.BandCount;
				for(int idxcell=0;idxcell<SrcRep.GetBand(idxband).CellCount;idxcell++)
				{
					SrcRep.GetBand(idxband).GetCell(idxcell).Width=width/SrcRep.GetBand(idxband).CellCount;
				}
			}
		}
		#endregion

		#region methods
		public void OnChange()
		{
			if(Change!=null)
				Change(this,EventArgs.Empty);
		}

		public void Load(string AFileName)
		{
			try
			{
				SrcRep.Load(AFileName);
			}
			finally
			{
				Refresh();
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			int idxband, idxcell;
			double d, w, w1, w2, h, h1, h2;
			double stepx, stepy;
			Cell cell1, cell2=null;
			RectangleF r;
			Band band;

			base.OnMouseMove(e);
			ControlFlag=0;
			
			if(e.Button.ToString().IndexOf("Left")!=-1)
			{
				if(Cursor==Cursors.HSplit)
				{
					d=AsUnits(OldHeight+(e.Y-OldY));

					if(ModifierKeys==Keys.Shift)
					{
						stepy=AsUnits(1);
					}
					else
					{
						stepy=GridY;
					}
					h=Math.Max(d,stepy);
					h1=AsUnits(GetBandHeight(TmpBandIdx));
					if(TmpBandIdx<SrcRep.BandCount-1 && SrcRep.GetBand(TmpBandIdx).LockHeight==false)
					{
						band=null;
						for(int i=TmpBandIdx+1;i<SrcRep.BandCount;i++)
						{
							if(SrcRep.GetBand(i).LockHeight==false)
							{
								band=SrcRep.GetBand(i);
								break;
							}
						}
						if(band!=null)
						{
							h2=AsUnits(GetBandHeight(SrcRep.IndexOfBand(band)));
							if(Math.Round(h2-(h-h1)-stepy)>=0)
							{
								SetBandHeight(SrcRep.IndexOfBand(band),GetBandHeight(SrcRep.IndexOfBand(band))-(AsPix(AlignToGrid(h,stepy))-GetBandHeight(TmpBandIdx)));
								SetBandHeight(TmpBandIdx,AsPix(AlignToGrid(h,stepy)));
							}
							ControlFlag=1;
						}
					}
				}
				else
				{
					if(Cursor==Cursors.VSplit)
					{
						d=AsUnits(OldWidth+(e.X-OldX));
						if(ModifierKeys==Keys.Shift)
						{
							stepx=AsUnits(1);
						}
						else
						{
							stepx=GridY;
						}
						w=Math.Max(d,stepx);
						if(InGutterShift)
						{
							Gutter=AsPix(AlignToGrid(d,stepx));
							ControlFlag=2;
						}
						else
						{
							cell2=null;
							cell1=SrcRep.GetBand(TmpBandIdx).GetCell(TmpCellIdx);
							w1=AsUnits(cell1.Width);
							if(TmpCellIdx<SrcRep.GetBand(TmpBandIdx).CellCount-1 && SrcRep.GetBand(TmpBandIdx).GetCell(TmpCellIdx).LockWidth==false)
							{
								for(int i=TmpCellIdx+1;i<SrcRep.GetBand(TmpBandIdx).CellCount;i++)
								{
									if(SrcRep.GetBand(TmpBandIdx).GetCell(i).LockWidth==false)
									{
										cell2=SrcRep.GetBand(TmpBandIdx).GetCell(i);
										break;
									}
								}
								if(cell2!=null)
								{
									w2=AsUnits(cell2.Width);
									if(Math.Round(w2-(w-w1)-stepx)>=0)
									{
										SetCellWidth(cell2,cell2.Width-(AsPix(AlignToGrid(w,stepx))-cell1.Width));
										SetCellWidth(cell1,AsPix(AlignToGrid(w,stepx)));
									}
									Invalidate();
									ControlFlag=3;
								}
							}							
						}
					}
					else
					{
						cell1=MouseToCell(e.X,e.Y,out idxband,out idxcell);
						if((cell1!=null)&&(CurrCell!=cell1))
						{
							CurrBandIdx=idxband;
							CurrCellIdx=idxcell;

							SelAdd(CurrBandIdx,CurrCellIdx);

							ControlFlag=4;
						}
					}
				}
			}
			else
			{
				InGutterShift=false;				
				cell1=MouseToCell(e.X,e.Y,out idxband,out idxcell);
				if(Math.Abs(e.X-Gutter)<=5)
				{
					Cursor=Cursors.VSplit;
					InGutterShift=true;
				}
				else
				{
					if((cell1!=null)&&(Math.Abs(e.X-Gutter)>5))
					{
						r=CellRect(idxband,0);
						if((Math.Abs(r.Bottom-e.Y)<3)&&(idxband!=SrcRep.BandCount-1))
						{
							TmpBandIdx=idxband;
							Cursor=Cursors.HSplit;
						}
						else
						{
							Cursor=Cursors.Default;
							for(idxcell=0;idxcell<SrcRep.GetBand(idxband).CellCount;idxcell++)
							{
								d=SrcRep.GetBand(idxband).GetRights(idxcell)+Gutter+Generic.ToPix(SrcRep.LeftMargin)-LeftX-e.X;
								if((d>=0)&&(d<3)&&(idxcell!=SrcRep.GetBand(idxband).CellCount-1))
								{
									Cursor=Cursors.VSplit;
									TmpBandIdx=idxband;
									TmpCellIdx=idxcell;
									return;
								}
							}
						}
					}
					else
					{
						Cursor=Cursors.Default;
					}
				}
			}			
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			InGutterShift=false;
			if (ControlFlag==0)
				return;
			else if(ControlFlag==1)
			{
				UpdateScrolls();
				ResizeBantEventArgs arg=new ResizeBantEventArgs();
				arg.idxband=TmpBandIdx;
				if(ResizeBant!=null)
					ResizeBant(this,arg);
				OnChange();
			}

			else if(ControlFlag==2)
			{
				if(ResizeGutter!=null)
					ResizeGutter(this,EventArgs.Empty);
			}

			else if(ControlFlag==3)
			{
				UpdateScrolls();
				ResizeCellEventArgs cellresizearg=new ResizeCellEventArgs();
				cellresizearg.idxband=TmpBandIdx;
				cellresizearg.idxcell=TmpCellIdx;
				if(ResizeCell!=null)
					ResizeCell(this,cellresizearg);
				OnChange();
			}

			else if(ControlFlag==4)
			{
				SelectCellEventArgs selectcellargs=new SelectCellEventArgs();
				selectcellargs.idxband=CurrBandIdx;
				selectcellargs.idxcell=CurrCellIdx;
				if(SelectCell!=null)
					SelectCell(this,selectcellargs);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			int idx,idxband, idxcell;
			Cell cell;
			ControlFlag=0;

			base.OnMouseDown(e);
			if(e.Button.ToString().IndexOf("Right")!=-1)
				return;
			cell=MouseToCell(e.X,e.Y,out idxband,out idxcell);
			if(Math.Abs(e.X-Gutter)<=5)
			{
				if(Cursor==Cursors.VSplit)
				{
					OldX=e.X;
					OldWidth=Gutter;
				}
			}			
			else if(e.X<(Gutter-5))
			{
				if(ModifierKeys==Keys.Shift)					
				{
					int curr=CurrBandIdx;
					int minidx=Math.Min(curr,idxband);
					int maxidx=Math.Max(curr,idxband);
					for(idx=minidx;idx<maxidx+1;idx++)
					{
						SrcRep.GetBand(idx).Selected=true;
					}
				}
				else
				{
					if(ModifierKeys!=Keys.Control)
					{
						ClearSel();
					}
					SrcRep.GetBand(idxband).Selected=!SrcRep.GetBand(idxband).Selected;
					if(SrcRep.GetBand(idxband).Selected)
					{
						for(int i=0;i<SrcRep.GetBand(idxband).CellCount;i++)
							SelAdd(idxband,i);
					}
				}
				CurrBandIdx=idxband;
				SelectBandEventArgs selectbandargs=new SelectBandEventArgs();
				selectbandargs.idxband=CurrBandIdx;
				if(SelectBand!=null)
					SelectBand(this,selectbandargs);
			}
			else if(cell!=null)
			{
				if(Cursor==Cursors.HSplit)
				{
					OldY=e.Y;
					OldHeight=SrcRep.GetBand(TmpBandIdx).Height;
				}
				else
				{
					if(Cursor==Cursors.VSplit)
					{
						OldX=e.X;
						OldWidth=SrcRep.GetBand(TmpBandIdx).GetCell(TmpCellIdx).Width;
					}
					else
					{
						CurrBandIdx=idxband;
						CurrCellIdx=idxcell;
						if(ModifierKeys!=Keys.Control)
						{
							ClearSel();
						}
						SelAdd(CurrBandIdx,CurrCellIdx);

						float curleftx=LeftX;
						float curtopy=TopY;
						float d;
						RectangleF r=CellRect(CurrBandIdx,CurrCellIdx);
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
						if((FixedCells==0)||(CurrCellIdx<FixedCells))
						{
							if(r.Left<Gutter)
								curleftx=curleftx+(r.Left-Gutter-1);
						}
						else
						{
							if(r.Left<Gutter+SrcRep.GetBand(CurrBandIdx).GetRights(Math.Min(CurrCellIdx,Math.Max(0,FixedCells-1))))
							{
								curleftx=curleftx+(r.Left-Gutter-SrcRep.GetBand(CurrBandIdx).GetRights(Math.Min(CurrCellIdx,Math.Max(0,FixedCells-1))))-1;
							}
						}
						LeftX=(int)curleftx;
						TopY=(int)curtopy;

						SelectCellEventArgs selectcellargs=new SelectCellEventArgs();
						selectcellargs.idxband=CurrBandIdx;
						selectcellargs.idxcell=CurrCellIdx;
						if(SelectCell!=null)
							SelectCell(this,selectcellargs);
					}
				}
			}
			Invalidate();
		}

		public void SetCellWidth(Cell ACell,float AWidth)
		{
			ACell.Width=AWidth;
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			double stepx=0, stepy=0;
			double h, w;
			Cell cell, cell1=null;
			ResizeBantEventArgs resizebantarg;
			Band band;

			if((ModifierKeys==(Keys.Control|Keys.Alt))||(ModifierKeys==Keys.Control))
			{
				stepx=GridX;
				stepy=GridX;
			}
			if(ModifierKeys==(Keys.Shift|Keys.Control))
			{
				stepx=AsUnits(1);
				stepy=AsUnits(1);
			}
			switch(e.KeyData)
			{
				case Keys.Control|Keys.Up:
					if(CurrBandIdx<SrcRep.BandCount-1 && SrcRep.GetBand(CurrBandIdx).LockHeight==false)
					{
						band=null;
						for(int i=CurrBandIdx+1;i<SrcRep.BandCount;i++)
						{
							if(SrcRep.GetBand(i).LockHeight==false)
							{
								band=SrcRep.GetBand(i);
								break;
							}
						}
						if(band!=null)
						{
							h=AlignToGrid(Math.Max(AsUnits(GetBandHeight(CurrBandIdx))-stepy,stepy),stepy);
							SetBandHeight(SrcRep.IndexOfBand(band),GetBandHeight(SrcRep.IndexOfBand(band))-(AsPix(h)-GetBandHeight(CurrBandIdx)));
							SetBandHeight(CurrBandIdx,AsPix(h));
							resizebantarg=new ResizeBantEventArgs();
							resizebantarg.idxband=CurrBandIdx;
							if(ResizeBant!=null)
								ResizeBant(this,resizebantarg);
							OnChange();
							Invalidate();
						}
					}
					break;
				case Keys.Control|Keys.Down:
					if(CurrBandIdx<SrcRep.BandCount-1 && SrcRep.GetBand(CurrBandIdx).LockHeight==false)
					{
						band=null;
						for(int i=CurrBandIdx+1;i<SrcRep.BandCount;i++)
						{
							if(SrcRep.GetBand(i).LockHeight==false)
							{
								band=SrcRep.GetBand(i);
								break;
							}
						}
						if(band!=null)
						{
							h=AlignToGrid(AsUnits(GetBandHeight(CurrBandIdx))+stepy,stepy);
							if((AsUnits(GetBandHeight(CurrBandIdx+1))-(h-AsUnits(GetBandHeight(CurrBandIdx)))-stepy)>=0)
							{
								SetBandHeight(SrcRep.IndexOfBand(band),GetBandHeight(SrcRep.IndexOfBand(band))-(AsPix(h)-GetBandHeight(CurrBandIdx)));
								SetBandHeight(CurrBandIdx,AsPix(h));
							}						
							resizebantarg=new ResizeBantEventArgs();
							resizebantarg.idxband=CurrBandIdx;
							if(ResizeBant!=null)
								ResizeBant(this,resizebantarg);
							OnChange();
							Invalidate();
						}
					}
					break;
				case Keys.Control|Keys.Left:
					cell1=null;
					cell=SrcRep.GetBand(CurrBandIdx).GetCell(CurrCellIdx);					
					w=AlignToGrid(Math.Max(AsUnits(cell.Width)-stepx,stepx),stepx);
					if(CurrCellIdx<SrcRep.GetBand(CurrBandIdx).CellCount-1 && SrcRep.GetBand(CurrBandIdx).GetCell(CurrCellIdx).LockWidth==false)
					{
						for(int i=CurrCellIdx+1;i<SrcRep.GetBand(CurrBandIdx).CellCount;i++)
						{
							if(SrcRep.GetBand(CurrBandIdx).GetCell(i).LockWidth==false)
							{
								cell1=SrcRep.GetBand(CurrBandIdx).GetCell(i);
								break;
							}
						}
						if(cell1!=null)
						{
							SetCellWidth(cell1,cell1.Width-(AsPix(w)-cell.Width));
							SetCellWidth(cell,AsPix(w));
							resizebantarg=new ResizeBantEventArgs();
							resizebantarg.idxband=CurrBandIdx;
							if(ResizeBant!=null)
								ResizeBant(this,resizebantarg);
							OnChange();
							Invalidate();
						}
					}					
					break;
				case Keys.Control|Keys.Right:
					cell1=null;
					cell=SrcRep.GetBand(CurrBandIdx).GetCell(CurrCellIdx);
					w=AlignToGrid(AsUnits(cell.Width)+stepx,stepx);
					if(CurrCellIdx<SrcRep.GetBand(CurrBandIdx).CellCount-1 && SrcRep.GetBand(CurrBandIdx).GetCell(CurrCellIdx).LockWidth==false)
					{
						for(int i=CurrCellIdx+1;i<SrcRep.GetBand(CurrBandIdx).CellCount;i++)
						{
							if(SrcRep.GetBand(CurrBandIdx).GetCell(i).LockWidth==false)
							{
								cell1=SrcRep.GetBand(CurrBandIdx).GetCell(i);
								break;
							}
						}
						if(cell1!=null)
						{
							if((AsUnits(cell1.Width)-(w-AsUnits(cell.Width))-stepx)>=0)
							{
								SetCellWidth(cell1,cell1.Width-(AsPix(w)-cell.Width));
								SetCellWidth(cell,AsPix(w));
								resizebantarg=new ResizeBantEventArgs();
								resizebantarg.idxband=CurrBandIdx;
								if(ResizeBant!=null)
									ResizeBant(this,resizebantarg);
								OnChange();
								Invalidate();
							}
						}
					}					
					break;
			}
			base.OnKeyDown(e);
		}

		public void Save(string AFileName)
		{
			SrcRep.Save(AFileName);
		}

		public void DeleteSelCells()
		{
			for(int idxband=0;idxband<SrcRep.BandCount;idxband++)
			{
				if(SrcRep.GetBand(idxband).CellCount>1)
				{
					for(int idxcell=SrcRep.GetBand(idxband).CellCount-1;idxcell>-1;idxcell--)
					{
						if(SrcRep.GetBand(idxband).GetCell(idxcell).Selected)
						{
							if(idxcell>=1)
								SrcRep.GetBand(idxband).GetCell(idxcell-1).Width=SrcRep.GetBand(idxband).GetCell(idxcell).Width+SrcRep.GetBand(idxband).GetCell(idxcell-1).Width;
							else
								SrcRep.GetBand(idxband).GetCell(idxcell+1).Width=SrcRep.GetBand(idxband).GetCell(idxcell).Width+SrcRep.GetBand(idxband).GetCell(idxcell+1).Width;
							SrcRep.GetBand(idxband).DeleteCell(idxcell);
						}
					}
				}
			}
			SelList.Clear();
		}
		#endregion
	}
}
