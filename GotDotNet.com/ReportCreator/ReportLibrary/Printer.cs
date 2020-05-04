using System;
using System.Drawing.Printing;
using System.Collections;
using System.Xml;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region PageSize
	public class PageSize:PageSettings
	{
		#region class variables
		StringList FTemplate;
		int FFWith;
		int FFHeight;
		StringList PageNames;
		#endregion
		
		#region constructor
		public PageSize()
		{
			for(int i=0;i<PrinterSettings.PaperSizes.Count;i++)
			{
				if(PrinterSettings.PaperSizes[i].PaperName=="A4")
				{
					PaperSize=PrinterSettings.PaperSizes[i];
					break;
				}
			}
			PageNames=new StringList("Printer PageNames");
			ArrayList ar=new ArrayList(PrinterSettings.PaperSizes);
			for(int i=0;i<ar.Count;i++)
				PageNames.Add(((PaperSize)ar[i]).PaperName);
		}
		#endregion
		
		#region class properties
		public int FWidth
		{
			get
			{
				FFWith=(int)Generic.InchToMm(PaperSize.Width)*10;
				return FFWith;
			}
		}

		public int FHeight
		{
			get
			{
				FFHeight=(int)Generic.InchToMm(PaperSize.Height)*10;
				return FFHeight;
			}
		} 

		public StringList Template
		{
			get
			{
				StringList sl=new StringList("PageSize.GetTemplate sl");
				if(FTemplate==null)
				{
					FTemplate=new StringList("PageSize.FTemplate");
				}
				FTemplate.Clear();
				FTemplate.Add("  <PAGESIZE>");
				FTemplate.Add(String.Format("   <NAME>{0}</NAME>",PaperSize.PaperName));
				FTemplate.Add(String.Format("   <WIDTH>{0:D}</WIDTH>",FWidth));
				FTemplate.Add(String.Format("   <HEIGHT>{0:D}</HEIGHT>",FHeight));
				int y=PageNames.Count;
				for(int i=0;i<y;i++)
				{
					if(PageNames.GetString(i)==PaperSize.PaperName)
					{
						FTemplate.Add(String.Format("   <PAPERKIND>{0:D}</PAPERKIND>",i));
						break;
					}
				}
				FTemplate.Add("  </PAGESIZE>");
				return FTemplate;
			}
		}
		#endregion

		#region class methods
		public void ApplyPageSize(XmlNode node)
		{
			XmlNode childnode=node.SelectSingleNode("PAPERKIND");
			if(childnode!=null)
			{
				PaperSize=PrinterSettings.PaperSizes[Convert.ToInt32(childnode.InnerText)];
			}
		}
		#endregion
	}
	#endregion
}
