using System;
using Windows.Forms.Reports.ReportLibrary;
using System.Windows.Forms;
using System.Drawing;

namespace Windows.Forms.Reports.Demo
{
	public class CrossBand
	{
		public static void CrossBandReport(UserRep Rep)
		{
			Rep.BeginReport();
			Rep.ProgressStart(11);
			Rep.Load(Application.StartupPath+@"..\..\..\Templates\CrossBand.SD");
			Rep.Title="Cross band report";
			Rep.AddBands("Header");
			Band band=Rep.AddBands("Band 1");
			for(int i=1;i<11;i++)
			{
				band.GetCell(i+1).Value=i.ToString();
			}
			Rep.ProgressStep();
			for(int i=1;i<11;i++)
			{
				Band band2=Rep.AddBands("Band 2");
				band2.GetCell(1).Value=i.ToString();
				for(int y=2;y<12;y++)
				{
					band2.GetCell(y).Value=((int)((y-1)*i)).ToString();
				}
				Rep.ProgressStep();
			}
			Rep.SetDateTime("CurrDate",DateTime.Now);			
			Rep.ProgressStop();
			Rep.ShowReport();
		}
	}
}
			