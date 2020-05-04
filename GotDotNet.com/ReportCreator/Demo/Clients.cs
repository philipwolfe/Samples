using System;
using Windows.Forms.Reports.ReportLibrary;
using System.Drawing;
using System.Windows.Forms;

namespace Windows.Forms.Reports.Demo
{
	public class Clients
	{
		public static void ClientsReport(UserRep Rep)
		{
			Rep.BeginReport();			
			Rep.ProgressStart(DemoDlg.dataset.Tables[0].Rows.Count);
			int Pos=0;
			Rep.Load(Application.StartupPath+@"..\..\..\Templates\Clients.sd");
			Rep.Title="Clients report";
			Rep.AddBands("Header");
			while(Pos<DemoDlg.dataset.Tables[0].Rows.Count)
			{
				Rep.BeginPara();
				Rep.SetDTValues(DemoDlg.dataset.Tables[0],DemoDlg.dataset.Tables[0].Rows[Pos]);
				Rep.SetImage("PICTURE",new Bitmap(Application.StartupPath+@"\images\"+(string)DemoDlg.dataset.Tables[0].Rows[Pos]["PICTURE"]));				
				Rep.AddBands("Band");
				Pos++;
				Rep.ProgressStep();
			}
			Rep.ProgressStop();
			Rep.ShowReport();
		}
	}
}
