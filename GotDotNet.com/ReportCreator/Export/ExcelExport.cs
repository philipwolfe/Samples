using System;
using System.ComponentModel;
using Windows.Forms.Reports.ReportLibrary;
using Excel;
using System.Collections;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace Windows.Forms.Reports.Export
{
	#region ExcelExport
	[ToolboxItem(true)]
	public class ExcelExport:CustomExport
	{
		#region class variables
		ArrayList bl;
		Excel.Application Ex;
		Excel._Workbook WBk;
		Excel._Worksheet WS;
		object A;
		int w;
		#endregion

		#region class methods
		public override void  Execute()
		{
			CultureInfo oldculture=System.Threading.Thread.CurrentThread.CurrentCulture;
			System.Threading.Thread.CurrentThread.CurrentCulture=System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

			if(FromPage==0)
				FromPage=1;
			if(ToPage==0)
				ToPage=UserRep.Pagecnt-1;
			Ex=new Excel.Application();
			
			Ex.Caption=UserRep.Title;
			WBk=(Excel._Workbook)(Ex.Workbooks.Add( Missing.Value ));

			Rep CurrRep=null;
			UserRep.ProgressStart(Rep.BandCount);
			int firstband;
			int lastband;
			firstband=0;
			lastband=0;
			int pagecnt=0;
			
			for(int i=0;i<Rep.RepList.Count;i++)
			{
				CurrRep=Rep.GetSrcRep(i);
				int bandcount=0;
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

					bl=new ArrayList();

					PrepareBoundList(firstband,lastband,CurrRep);
					if((page>=FromPage)&&(page<=ToPage))
						NewPage(pagecnt);
					
	
					int bandidx=0;					
					for(int idxband=firstband;idxband<lastband+1;idxband++)
					{
						if((page>=FromPage)&&(page<=ToPage))
							PrintBand(CurrRep.GetBand(idxband),CurrRep,bandidx,pagecnt,bandcount);
						UserRep.ProgressStep();
						bandidx++;
					}
					bandcount=bandcount+bandidx;
					if((page>=FromPage)&&(page<=ToPage))
						pagecnt++;
				}
			}
			if(FileName.Length>0)
				WBk.SaveAs(FileName,Excel.XlFileFormat.xlWorkbookNormal,null,null,null,null,Excel.XlSaveAsAccessMode.xlNoChange,null,null,null,null,null);
			UserRep.ProgressStop();
			Ex.Visible=true;
			Ex.UserControl=true;
			System.Threading.Thread.CurrentThread.CurrentCulture=oldculture;
		}

		void NewPage(int pagecnt)
		{
			if(pagecnt+1>3)
				WBk.Worksheets.Add(Missing.Value,WS,1,Missing.Value);
			WS=(Excel._Worksheet)WBk.Worksheets[pagecnt+1];
			A=null;
			for(int i=0;i<bl.Count-1;i++)
			{
				A=GetColumnName(i)+"1";
				w=(int)bl[i+1]-(int)bl[i];
				WS.get_Range(A,A).ColumnWidth=w/7;
			}
		}

		void PrintBand(Band band,Rep CurrRep,int idxband,int pagecnt,int bandcount)
		{
			object B,C,D;			
			Band btmBand;
			Cell cell;
			Excel.Range ExCell;
			string s;

			for(int idxcell=0;idxcell<band.CellCount;idxcell++)
			{
				cell=band.GetCell(idxcell);
				if(cell.Shared)
					continue;
				A=GetColumnName(bl.IndexOf((int)band.GetLefts(idxcell)))+((int)(idxband+1)).ToString();
				B=GetColumnName(bl.IndexOf((int)band.GetRights(idxcell))-1)+((int)(idxband+1)).ToString();
				ExCell=WS.get_Range(A,A);

				ExCell.Font.Color=ColorTranslator.ToWin32(ReportLibrary.Generic.FindColor(cell.FontColor,RenderingMode));
				ExCell.Font.Size=cell.FontSize;
				ExCell.Font.Bold=cell.FontStyle.ToString().IndexOf("Bold")!=-1;
				ExCell.Font.Italic=cell.FontStyle.ToString().IndexOf("Italic")!=-1;
				ExCell.Font.Name=cell.FontName;

				s=cell.S;
				s=s.Replace(',','.');
				if(!cell.Shape)
					ExCell.Formula=s;
					
				switch(cell.HAlign)
				{
					case HAlign.Left:
						ExCell.HorizontalAlignment=Excel.XlHAlign.xlHAlignLeft;
						break;
					case HAlign.Center:
						ExCell.HorizontalAlignment=Excel.XlHAlign.xlHAlignCenter;
						break;
					case HAlign.Right:
						ExCell.HorizontalAlignment=Excel.XlHAlign.xlHAlignRight;
						break;
				}

				switch(cell.VAlign)
				{
					case VAlign.Bottom:
						ExCell.VerticalAlignment=Excel.XlVAlign.xlVAlignBottom;
						break;
					case VAlign.Center:
						ExCell.VerticalAlignment=Excel.XlVAlign.xlVAlignCenter;
						break;
					case VAlign.Top:
						ExCell.VerticalAlignment=Excel.XlVAlign.xlVAlignTop;
						break;
				}
				switch (cell.TextAngle)
				{
					case 90:
						ExCell.Orientation=Excel.XlOrientation.xlUpward;
						break;
					case 270:
						ExCell.Orientation=Excel.XlOrientation.xlDownward;
						break;
				}

				btmBand=cell.GetBottomBand();
				if(btmBand==band)
				{
					C=A;
					D=B;
				}
				else
				{					
					C=GetColumnName(bl.IndexOf((int)band.GetLefts(idxcell)))+((int)(btmBand.Owner.IndexOfBand(btmBand)+1)-bandcount).ToString();
					D=GetColumnName(bl.IndexOf((int)band.GetRights(idxcell))-1)+((int)(btmBand.Owner.IndexOfBand(btmBand)+1)-bandcount).ToString();
				}				
				WS.get_Range(A,D).Merge(null);

				SetBorder(0,Excel.XlBordersIndex.xlEdgeLeft,cell,D);
				SetBorder(1,Excel.XlBordersIndex.xlEdgeTop,cell,D);
				SetBorder(2,Excel.XlBordersIndex.xlEdgeRight,cell,D);
				SetBorder(3,Excel.XlBordersIndex.xlEdgeBottom,cell,D);

				if(cell.Shape)
				{
					Clipboard.SetDataObject(cell.CellToBitmap(RenderingMode),true);
					WS.Paste(WS.get_Range(A,D),null);
				}
				if(cell.Picture!=null)
				{
					Clipboard.SetDataObject(cell.RenderingImage,true);
					WS.Paste(WS.get_Range(A,D),null);
				}
			}
			float rowheight=(band.Height*7)/9;
			if(rowheight>409)
				WS.get_Range(A,A).RowHeight=409;
			else
				WS.get_Range(A,A).RowHeight=rowheight;
		}

		void PrepareBoundList(int firstband,int lastband,Rep CurrRep)
		{
			int i;
			
			bl.Clear();
			bl.Add(0);
			for(int idxband=firstband;idxband<lastband+1;idxband++)
			{
				for(int idxcell=0;idxcell<CurrRep.GetBand(idxband).CellCount;idxcell++)
				{
					i=(int)CurrRep.GetBand(idxband).GetLefts(idxcell);
					if(bl.IndexOf(i)==-1)
					{
						bl.Add(i);
					}
				}
				i=(int)CurrRep.GetBand(idxband).GetRights(CurrRep.GetBand(idxband).CellCount-1);
				if(bl.IndexOf(i)==-1)
				{
					bl.Add(i);
				}
			}
			bl.Sort();
		}

		string GetColumnName(int n)
		{
			if(n<26)
				return ((char)((int)'A'+n)).ToString();
			else
				return ((char)((int)'A'+n/26-1)+((int)'A'+n%26)).ToString();
		}

		void SetBorder(int fr,Excel.XlBordersIndex xl,Cell cell,object D)
		{
			if(cell.GetFrameWidths(fr)>0)
			{
				WS.get_Range(A,D).Borders[xl].Color=ColorTranslator.ToWin32(ReportLibrary.Generic.FindColor(cell.GetFrameColors(fr),RenderingMode));
				switch(cell.GetBorderStyles(fr))
				{
					case LineStyle.Dash:
						WS.get_Range(A,D).Borders[xl].LineStyle=Excel.XlLineStyle.xlDash;
						break;
					case LineStyle.DashDot:
						WS.get_Range(A,D).Borders[xl].LineStyle=Excel.XlLineStyle.xlDashDot;
						break;
					case LineStyle.DashDotDot:
						WS.get_Range(A,D).Borders[xl].LineStyle=Excel.XlLineStyle.xlDashDotDot;
						break;
					case LineStyle.Dot:
						WS.get_Range(A,D).Borders[xl].LineStyle=Excel.XlLineStyle.xlDot;
						break;
					case LineStyle.Double11:
					case LineStyle.Double12:
					case LineStyle.Double21:
						WS.get_Range(A,D).Borders[xl].LineStyle=Excel.XlLineStyle.xlDouble;
						break;
					case LineStyle.Solid:
						WS.get_Range(A,D).Borders[xl].LineStyle=Excel.XlLineStyle.xlContinuous;
						break;
				}
				switch(cell.GetFrameWidths(fr))
				{
					case 1:
						WS.get_Range(A,D).Borders[xl].Weight=Excel.XlBorderWeight.xlThin;
						break;
					case 2:
						WS.get_Range(A,D).Borders[xl].Weight=Excel.XlBorderWeight.xlMedium;
						break;
					default:
						WS.get_Range(A,D).Borders[xl].Weight=Excel.XlBorderWeight.xlThick;
						break;
				}
			}
		}
		#endregion
	}
	#endregion
}
