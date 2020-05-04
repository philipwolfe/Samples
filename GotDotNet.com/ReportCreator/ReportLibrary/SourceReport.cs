using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Globalization;
using System.Reflection;
using System.Xml;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region SourceReport
	public class SourceReport
	{
		#region class variables
		public ArrayList RepList;
		public ArrayList OrgRepList;
		public StringList PictureList;
		public StringList ControlList;
		public StringList Vars;

		PageSettings pageset;
		PrinterSettings printset;

		public int LeftMargin;
		public int RightMargin;
		public int TopMargin;
		public int BottomMargin;
		public PrinterOrientation orientation;
		public PaperSize PaperSize;
		public int Width;
		public int Height;
		int FPageCount;
		string FTitle;
		UserRep FOwner;

		object reflectOb;
		Type t;
		#endregion

		#region constructor
		public SourceReport()
		{
			RepList=new ArrayList();
			OrgRepList=new ArrayList();
			pageset=new PageSettings();
			printset=new PrinterSettings();
		}
		#endregion

		#region class methods
		public Rep FindRep(int Page)
		{
			for(int i=0;i<RepList.Count;i++)
			{
				if((Page>=((Rep)RepList[i]).FirstPage)&&(Page<((Rep)RepList[i]).LastPage))
					return (Rep)RepList[i];
			}
			return null;
		}

		public bool Save(string FileName,VirtualFileSystem FileSystem,string Title)
		{
			bool freturn=false;
			FileSystem.FileName=Title;
			StringList source=new StringList("");
			FileSystem.FileMode=System.IO.FileMode.Create;
			if(FileSystem.SaveDialogExecute())
			{
				source.AddObjectNoChange("<DOCUMENT>",null);
				source.AddObjectNoChange(" <TITLE>"+Title+"</TITLE>",null);
				for(int i=0;i<RepList.Count;i++)
				{
					((Rep)RepList[i]).FileSystem=FileSystem;
					StringList sl=new StringList("");
					sl.AddStringsNoChange(((Rep)RepList[i]).Template);

					if(i==RepList.Count-1)
					{
						for(int y=0;y<Owner.PlugInCount;y++)
						{
							if(Owner.PlugInList.GetString(y)==null || Owner.PlugInList.GetString(y)=="")
								continue;
							sl.AddObjectNoChange(" <PLUGIN>",null);
							sl.AddObjectNoChange("  <ASSEMBLYPATH>"+Owner.PlugInList.GetString(y)+"</ASSEMBLYPATH>",null);
							for(int var=0;var<((UserRepPlugIn)Owner.PlugInList.GetObject(y)).VarCount;var++)
							{
								sl.AddObjectNoChange("  <VARNAME>"+((UserRepPlugIn)Owner.PlugInList.GetObject(y)).FVarList.GetString(var)+"</VARNAME>",null);
							}
							sl.AddObjectNoChange(" </PLUGIN>",null);
						}
					}
					source.AddStringsNoChange(sl);
				}
				try
				{
					source.AddObjectNoChange("</DOCUMENT>",null);
					source.SaveToStream(FileSystem.CreateWriteStream(FileSystem.FileName));
				}
				finally
				{
					FileSystem.CloseWriteStream();
				}
				freturn=true;	
			}			
			return freturn;
		}

		public bool Open(VirtualFileSystem FileSystem,UserRep Rep)
		{
			bool freturn=false;
			FileSystem.MultiSelect=false;
			if(FileSystem.OpenDialogExecute())
			{
				RepList.Clear();
				OrgRepList.Clear();
				LoadReport(FileSystem.Files.GetString(0),FileSystem,Rep);
				freturn=true;
			}
			return freturn;
		}

		public void LoadReport(string FileName,VirtualFileSystem FileSystem,UserRep Rep)
		{
			int page=0;
			XmlNodeReader reader;
			XmlNodeList list;
			XmlDocument document=new XmlDocument();
			document.Load(FileName);
			list=document.SelectNodes("DOCUMENT/REP/BAND");
			Owner.ProgressStart(list.Count);
			XmlNode node=document.SelectSingleNode("DOCUMENT/TITLE");
			if(node!=null)
			{
				Title=node.InnerText;
			}

			XmlNodeList nodelist=document.SelectNodes("DOCUMENT/REP");
			for(int i=0;i<nodelist.Count;i++)
			{
				Rep rep=new Rep();
				rep.ApplyRep(nodelist[i],Owner);
				page=rep.LastPage-1;
				RepList.Add(rep);
				if(RepList.Count==1)
				{
					LeftMargin=(int)Math.Round(rep.LeftMargin,0);
					RightMargin=(int)Math.Round(rep.RightMargin,0);
					TopMargin=(int)Math.Round(rep.TopMargin,0);
					BottomMargin=(int)Math.Round(rep.BottomMargin,0);
					orientation=rep.Orientation;
					PaperSize=rep.PageSize.PaperSize;
					Width=rep.PageSize.PaperSize.Width;
					Height=rep.PageSize.PaperSize.Height;
				}
			}

			nodelist=document.SelectNodes("DOCUMENT/PLUGIN");
			for(int i=0;i<nodelist.Count;i++)
			{
				reader=new XmlNodeReader(nodelist[i]);
				reflectOb=null;
				while(reader.Read())
				{
					if(reader.Name=="ASSEMBLYPATH" && reader.NodeType==XmlNodeType.Element)
					{
						reader.Read();
						AssemblyLoad(reader.Value);
					}
					else if(reader.Name=="VARNAME" && reader.NodeType==XmlNodeType.Element)
					{
						reader.Read();
						GetVarByName(reader.Value);
					}
				}
				ApplyPlugin();
			}			
			ApplyValues();
			PageCount=page;
			Owner.ProgressStop();
		}

		void AssemblyLoad(string AssemblyName)
		{
			Assembly asm=Assembly.LoadFrom(AssemblyName);
			Type[] alltype=asm.GetTypes();
			t=alltype[0];
			ConstructorInfo[] ci=t.GetConstructors();
			reflectOb=ci[0].Invoke(null);
			((UserRepPlugIn)reflectOb).UserRep=Owner;
		}

		void GetVarByName(string VarName)
		{
			((UserRepPlugIn)reflectOb).GetObjectByName(VarName);
		}

		void ApplyPlugin()
		{
			((UserRepPlugIn)reflectOb).ApplyValues();
		}

		void ApplyValues()
		{
			for(int i=0;i<RepList.Count;i++)
			{
				for(int idxband=0;idxband<((Rep)RepList[i]).BandCount;idxband++)
				{
					for(int idxcell=0;idxcell<((Rep)RepList[i]).GetBand(idxband).CellCount;idxcell++)
					{
						if(((Rep)RepList[i]).GetBand(idxband).GetCell(idxcell).ControlName!=null)
						{
							if(Owner.GetControl(((Rep)RepList[i]).GetBand(idxband).GetCell(idxcell).ControlName)!=null)
							{
								Cell cell=((Rep)RepList[i]).GetBand(idxband).GetCell(idxcell);
								cell.Control=Owner.GetControl(cell.ControlName);
								cell.Control.Parent=Owner;
								cell.Control.Visible=false;
							}
						}
					}
				}
			}
		}

		public void SetInt32(string VarName,int VarValue)
		{
			System.Globalization.CultureInfo inf=new System.Globalization.CultureInfo("en");
			Vars.SetValue(VarName.ToUpper(inf),VarValue.ToString());
			Vars.InsertObject(Vars.IndexOfName(VarName.ToUpper(inf)),(int)ValueFlag.None);
		}
		
		public Rep GetOrgRep(int index)
		{
			return (Rep)OrgRepList[index];
		}

		public Rep GetSrcRep(int index)
		{
			return (Rep)RepList[index];
		}

		public Rep CurrRep
		{
			get
			{
				return GetSrcRep(RepList.Count-1);
			}
		}

		public void Load(string FileName)
		{
			Rep orgrep=new Rep();
			orgrep.Load(FileName);
			OrgRepList.Add(orgrep);
			Rep rep=new Rep();
			rep.DeleteAll();
			RepList.Add(rep);

			Rep SrcRep=GetSrcRep(RepList.Count-1);
			Rep OrgRep=GetOrgRep(OrgRepList.Count-1);
			SrcRep.PageSize=OrgRep.PageSize;
			SrcRep.Orientation=OrgRep.Orientation;
			SrcRep.LeftMargin=OrgRep.LeftMargin;
			SrcRep.TopMargin=OrgRep.TopMargin;
			SrcRep.RightMargin=OrgRep.RightMargin;
			SrcRep.BottomMargin=OrgRep.BottomMargin;
			SrcRep.PageColor=OrgRep.PageColor;
			SrcRep.PageGraident=OrgRep.PageGraident;
			if(SrcRep.PageGraident)
			{
				SrcRep.PageGraidentColor=OrgRep.PageGraidentColor;
				SrcRep.PageFillDirection=OrgRep.PageFillDirection;
			}
			SrcRep.PageImage=OrgRep.PageImage;
			if(SrcRep.PageImage)
			{
				SrcRep.PageImagePosition=OrgRep.PageImagePosition;
				SrcRep.PageLinkPictureToFile=OrgRep.PageLinkPictureToFile;
				SrcRep.PagePicture=OrgRep.PagePicture;
				if(SrcRep.PageLinkPictureToFile)
					SrcRep.PagePictureFileName=OrgRep.PagePictureFileName;
			}
			PrepareTemplate();
			if(RepList.Count==1)
			{
				LeftMargin=(int)Math.Round(SrcRep.LeftMargin,0);
				RightMargin=(int)Math.Round(SrcRep.RightMargin,0);
				TopMargin=(int)Math.Round(SrcRep.TopMargin,0);
				BottomMargin=(int)Math.Round(SrcRep.BottomMargin,0);
				orientation=SrcRep.Orientation;
				PaperSize=SrcRep.PageSize.PaperSize;
				Width=SrcRep.PageSize.PaperSize.Width;
				Height=SrcRep.PageSize.PaperSize.Height;
			}
		}

		public void PrepareTemplate()
		{
			Rep OrgRep=GetOrgRep(OrgRepList.Count-1);
			Rep SrcRep=GetSrcRep(RepList.Count-1);
			for(int idxband=0;idxband<OrgRep.BandCount;idxband++)
			{
				for(int idxcell=0;idxcell<OrgRep.GetBand(idxband).CellCount;idxcell++)
				{
					OrgRep.GetBand(idxband).GetCell(idxcell).CreateVarNameList();
				}
			}
			SrcRep.Font=OrgRep.Font;
		}

		public void PageSettings()
		{
			PageSetupDialog psdlg=new PageSetupDialog();	
			psdlg.PageSettings=pageset;
			psdlg.PrinterSettings=printset;

			pageset.Margins.Left=LeftMargin;
			pageset.Margins.Right=RightMargin;
			pageset.Margins.Top=TopMargin;
			pageset.Margins.Bottom=BottomMargin;
			pageset.Landscape=orientation.ToString().IndexOf("Landscape")!=-1;
			pageset.PaperSize=PaperSize;

			if(psdlg.ShowDialog()==DialogResult.OK)
			{
				if(psdlg.PageSettings.Landscape)
				{
					orientation=PrinterOrientation.Landscape;
					Height=psdlg.PageSettings.PaperSize.Width;
					Width=psdlg.PageSettings.PaperSize.Height;
				}
				else
				{
					orientation=PrinterOrientation.Portrait;
					Height=psdlg.PageSettings.PaperSize.Height;
					Width=psdlg.PageSettings.PaperSize.Width;	
				}
				PaperSize=psdlg.PageSettings.PaperSize;

				RegionInfo inf=RegionInfo.CurrentRegion;
				if(inf.IsMetric)
				{
					BottomMargin=(int)(Generic.InchToMm(psdlg.PageSettings.Margins.Bottom)*10.0);
					LeftMargin=(int)(Generic.InchToMm(psdlg.PageSettings.Margins.Left)*10.0);
					RightMargin=(int)(Generic.InchToMm(psdlg.PageSettings.Margins.Right)*10.0);
					TopMargin=(int)(Generic.InchToMm(psdlg.PageSettings.Margins.Top)*10.0);
				}
				else
				{
					BottomMargin=psdlg.PageSettings.Margins.Bottom;
					LeftMargin=psdlg.PageSettings.Margins.Left;
					RightMargin=psdlg.PageSettings.Margins.Right;
					TopMargin=psdlg.PageSettings.Margins.Top;
				}
			}
		}
		#endregion

		#region class properties
		public int PageCount
		{
			get
			{
				return FPageCount;
			}
			set
			{
				FPageCount=value;
			}
		}

		public int BandCount
		{
			get
			{
				int count=0;
				for(int i=0;i<RepList.Count;i++)
				{
					count=count+GetSrcRep(i).BandCount;
				}
				return count;
			}
		}

		public UserRep Owner
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

		public string Title
		{
			get
			{
				return FTitle;
			}
			set
			{
				FTitle=value;
			}
		}
		#endregion	
	}
	#endregion
}
