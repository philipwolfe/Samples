using System;
using Windows.Forms.Reports.ReportLibrary;
using System.ComponentModel;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Windows.Forms.Reports.Export
{
	#region HTMLExport
	[ToolboxItem(true)]
	public class HTMLExport:CustomExport
	{
		#region class variables
		StringList sl;
		ArrayList bl;
		FileInfo fi;
		int FileIdx;
		int imgidx;
		string ImgDir;
		string directoryname;
		#endregion

		#region class methods
		public override void Execute()
		{
			Rep CurrRep=null;
			FileIdx=1;

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

					bl=new ArrayList();
					PrepareBoundList(firstband,lastband,CurrRep);
					if((page>=FromPage)&&(page<=ToPage))
						NewPage(CurrRep);					
	
					for(int idxband=firstband;idxband<lastband+1;idxband++)
					{
						if((page>=FromPage)&&(page<=ToPage))
							PrintBand(CurrRep.GetBand(idxband),CurrRep,idxband);
						UserRep.ProgressStep();
					}
					if((page>=FromPage)&&(page<=ToPage))
						EndPage(CurrRep);
					FileIdx++;
				}				
			}
			UserRep.ProgressStop();
		}

		void EndPage(Rep CurrRep)
		{
			sl.Add("");
			sl.Add("    </table>");
			if((FileIdx==1)||(FileIdx==FromPage))
			{
				if(ToPage==FromPage)
				{
					sl.Add("  </center> </div> </body>");
					sl.Add("");
					sl.Add("</html>");
					if(FileName.Length>0)
						sl.SaveToFile(fi.Name);
					return;
				}
				if(FileIdx==1)
					sl.Add("<a href=\""+FileName.Remove(FileName.Length-5,5)+"2"+fi.Extension+"\""+">");
				if(FileIdx==FromPage)
					sl.Add("<a href=\""+FileName.Remove(FileName.Length-5,5)+((int)(FromPage+1)).ToString()+fi.Extension+"\""+">");
				sl.Add("Next");
				sl.Add("</a>");
				
			}
			else if((FileIdx==UserRep.Pagecnt-1)||(FileIdx==ToPage))
			{
				if(FileIdx==UserRep.Pagecnt-1)
					sl.Add("<a href=\""+FileName.Remove(FileName.Length-5,5)+((int)(UserRep.Pagecnt-2)).ToString()+fi.Extension+"\""+">");
				if(FileIdx==ToPage)
					sl.Add("<a href=\""+FileName.Remove(FileName.Length-5,5)+((int)(ToPage-1)).ToString()+fi.Extension+"\""+">");
				sl.Add("Previous");
				sl.Add("</a>");
			}
			else
			{
				sl.Add("<a href=\""+FileName.Remove(FileName.Length-5,5)+((int)(FileIdx-1)).ToString()+fi.Extension+"\""+">");
				sl.Add("Previous");
				sl.Add("</a>");

				sl.Add("&nbsp;&nbsp;&nbsp;");

				sl.Add("<a href=\""+FileName.Remove(FileName.Length-5,5)+((int)(FileIdx+1)).ToString()+fi.Extension+"\""+">");
				sl.Add("Next");
				sl.Add("</a>");
			}
			sl.Add("  </center> </div> </body>");
			sl.Add("");
			sl.Add("</html>");
			if(FileName.Length>0)
				sl.SaveToFile(fi.Name);
		}

		void PrintBand(Band band,Rep CurrRep,int idxband)
		{
			Band btmband;
			Cell cell;
			string s, halign, valign, width, height, colspan, rowspan, fontcolor;
			string imgname, n1,imgid;
			Bitmap bmp;

			height=band.Height.ToString();
			sl.Add("      <tr>");
			for(int idxcell=0;idxcell<band.CellCount;idxcell++)
			{
				cell=band.GetCell(idxcell);
				if(cell.Shared)
					continue;
				btmband=cell.GetBottomBand();
				if(btmband==band)
				{
					rowspan="1";
				}
				else
				{
					rowspan=((int)(btmband.Owner.IndexOfBand(btmband)-idxband+1)).ToString();
				}

				colspan=((int)(
					(bl.IndexOf((int)band.GetRights(idxcell)))-
					(bl.IndexOf((int)band.GetLefts(idxcell)))
					)).ToString();

				halign="";
				switch(cell.HAlign)
				{
					case HAlign.Left:
						halign="left";
						break;
					case HAlign.Center:
						halign="center";
						break;
					case HAlign.Right:
						halign="right";
						break;
				}
				valign="";
				switch(cell.VAlign)
				{
					case VAlign.Bottom:
						valign="bottom";
						break;
					case VAlign.Center:
						valign="middle";
						break;
					case VAlign.Top:
						valign="top";
						break;
				}
				width=cell.Width.ToString();
				s="<td align=\""+halign+"\""+
					" height=\""+height+"\""+
					" valign=\""+valign+"\"";

				if(colspan!="1")
				{
					s=s+" colspan=\""+colspan+"\"";
				}
				if(rowspan!="1")
				{
					s=s+" rowspan=\""+rowspan+"\"";
				}
				imgname="";
				if(cell.Shape)
				{
					bmp=new Bitmap(cell.ShapeToBitmap(RenderingMode));										
					imgname=string.Format("{0:d}",imgidx)+".bmp";
					imgidx++;
					imgname=ImgDir+"\\"+imgname;
					bmp.Save(imgname,ImageFormat.Bmp);

					FileInfo imgfi=new FileInfo(imgname);
					imgid=imgfi.Name;
					s=s+"background=\""+"./"+directoryname+"/"+imgid+"\"";
				}
				s=s+">";
							
				if((cell.LinkPictureToFile)&&(cell.PictureFileName.Length>0))
				{
					n1=cell.PictureFileName;
					FileInfo imgfi=new FileInfo(n1);

					imgname=string.Format("{0:d}",imgidx)+"."+imgfi.Extension;
					imgidx++;
					imgname=ImgDir+"\\"+imgname;
					File.Copy(n1,imgname,true);
				}
				else
				{
					if(cell.Picture!=null)
					{
						bmp=new Bitmap(cell.RenderingImage);										
						imgname=string.Format("{0:d}",imgidx)+".bmp";
						imgidx++;
						imgname=ImgDir+"\\"+imgname;
						bmp.Save(imgname,ImageFormat.Bmp);									
					}
				}
				if(imgname.Length>0)
				{
					if(cell.Shape)
					{
									
					}
					else
					{
						s=s+"<img border=\"0\"";
						FileInfo imgfi=new FileInfo(imgname);
						imgid=imgfi.Name;
						s=s+" src=\""+"./"+directoryname+"/"+imgid+"\"";

						if(cell.AutoSize)
						{
							s=s+" width=\""+cell.Width.ToString()+"\"";
							s=s+" height=\""+band.Height.ToString()+"\"";
						}
						else
						{
							s=s+" width=\""+cell.Picture.Width.ToString()+"\"";
							s=s+" height=\""+cell.Picture.Height.ToString()+"\"";
						}
						s=s+">";
					}
				}
				s=s+"<font face=\""+cell.FontName+"\"";
				if(cell.FontColor!=Color.Black)
				{
					byte[] b=BitConverter.GetBytes(ReportLibrary.Generic.FindColor(cell.FontColor,RenderingMode).ToArgb());
					fontcolor="";
					for(int i=b.Length-2;i>-1;i--)
						fontcolor=fontcolor+string.Format("{0:X2}",b[i]);
					s=s+" color=\"#"+fontcolor+"\"";
				}
				s=s+" size=\""+FontSize(cell.FontSize)+"\"";
				s=s+">";
				if(cell.FontStyle.ToString().IndexOf("Bold")!=-1)
					s=s+"<b>";
				if(cell.FontStyle.ToString().IndexOf("Italic")!=-1)
					s=s+"<i>";
				if(cell.FontStyle.ToString().IndexOf("Underline")!=-1)
					s=s+"<u>";
				s=s+cell.Value;
				if(cell.FontStyle.ToString().IndexOf("Bold")!=-1)
					s=s+"</b>";
				if(cell.FontStyle.ToString().IndexOf("Italic")!=-1)
					s=s+"</i>";
				if(cell.FontStyle.ToString().IndexOf("Underline")!=-1)
					s=s+"</u>";

				s=s+"</font></td>";
				sl.Add("        "+s);
			}
			sl.Add("      </tr>");
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

		void NewPage(Rep CurrRep)
		{
			fi=new FileInfo(FileName.Remove(FileName.Length-5,5)+FileIdx.ToString()+".html");
			imgidx=1;
			sl=new StringList("");

			int l=fi.Extension.Length;
			ImgDir=fi.Directory+"\\"+fi.Name.Remove(fi.Name.Length-5,5)+"_files";
			Directory.CreateDirectory(ImgDir);
			DirectoryInfo dirinf=new DirectoryInfo(ImgDir);
			directoryname=dirinf.Name;


			sl.Add("<html>");
			sl.Add("");
			sl.Add("  <head>");
			sl.Add("    <meta name=\"GENERATOR\" content=\"Report Generator\">");
			sl.Add("    <meta name=\"ProgId\" content=\"HTMLExport.Document\">");
			sl.Add("    <title>"+UserRep.Title+"</title>");
			sl.Add("  </head>");
			sl.Add("");
			sl.Add("  <body LINK=#cc3300> <div align=\"center\"> <center>");
			sl.Add("    <table border=\"1\" width=\""+CurrRep.GetBand(0).GetWidth().ToString()+"\" cellspacing=\"0\" cellpadding="+"\""+"0"+"\"");
			Bitmap bmp=new Bitmap(CurrRep.PageToBitmap());										
			string imgname=string.Format("{0:d}",imgidx)+".jpg";
			imgidx++;
			imgname=ImgDir+"\\"+imgname;
			bmp.Save(imgname,ImageFormat.Jpeg);

			FileInfo imgfi=new FileInfo(imgname);
			string imgid=imgfi.Name;
			sl.Add("background=\""+"./"+directoryname+"/"+imgid+"\"");
			sl.Add(">");
		}

		string FontSize(float size)
		{
			if((size>=1)&&(size<8))
				return "1";
			if((size>=8)&&(size<10))
				return "2";
			if((size>=10)&&(size<12))
				return "3";
			if((size>=12)&&(size<14))
				return "4";
			if((size>=14)&&(size<18))
				return "5";
			if((size>=18)&&(size<24))
				return "6";
			if((size>=24)&&(size<36))
				return "7";
			else
				return "7";
		}
		#endregion
	}
	#endregion
}
