using System;
using Windows.Forms.Reports.ReportLibrary;
using System.Windows.Forms;

namespace Windows.Forms.Reports.Demo
{
	public class Groups
	{
		public static void GroupsReport(UserRep Rep)
		{
			Rep.BeginReport();	
			Rep.ProgressStart(DemoDlg.dataset.Tables[0].Rows.Count);
			int Pos=0;
			Rep.Load(Application.StartupPath+@"..\..\..\Templates\Groups.sd");
			Rep.Title="Group Report";
			Rep.AddBands("Title");
			Rep.AddBands("Header");
			while(Pos<DemoDlg.dataset.Tables[0].Rows.Count)
			{
				Rep.AddGroupBands("Alpha",((string)DemoDlg.dataset.Tables[0].Rows[Pos]["COMPANY"])[0].ToString(),1);
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
