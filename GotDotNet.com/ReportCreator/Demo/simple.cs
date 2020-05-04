using System;
using Windows.Forms.Reports.ReportLibrary;
using System.Windows.Forms;

namespace Windows.Forms.Reports.Demo
{
	public class simple
	{
		public static void SimpleReport(UserRep Rep)
		{
			Rep.BeginReport();
			int Pos=0;
			Rep.ProgressStart(DemoDlg.dataset.Tables[0].Rows.Count);
			Rep.Load(Application.StartupPath+@"..\..\..\Templates\simple.sd");
			Rep.Title="Simple Report";
			Rep.AddBands("Title");
			Rep.AddBands("Header");
			while(Pos<DemoDlg.dataset.Tables[0].Rows.Count)
			{
				Rep.SetDTValues(DemoDlg.dataset.Tables[0],DemoDlg.dataset.Tables[0].Rows[Pos]);
				Rep.AddBands("Band");
				Pos++;
				Rep.ProgressStep();
			}
			Rep.SetDateTime("CurrDate",DateTime.Now);
			Rep.ProgressStop();
			Rep.ShowReport();
		}
	}
}
