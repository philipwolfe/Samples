using System;
using Windows.Forms.Reports.ReportLibrary;
using System.Data;
using System.Windows.Forms;

namespace Windows.Forms.Reports.Demo
{
	public class MasterDetail
	{
		public static void MasterDetailReport(UserRep Rep)
		{
			Rep.BeginReport();	
			Rep.ProgressStart(DemoDlg.dataset.Tables[0].Rows.Count);
			Rep.Load(Application.StartupPath+@"..\..\..\Templates\MasterDetail.sd");
			Rep.Title="Master-Detail Report";
			Rep.AddBands("Title");
			Rep.AddBands("Header");
			foreach(DataRow datarow1 in DemoDlg.dataset.Tables[0].Rows)
			{
				Rep.BeginPara();
				Rep.SetDTValues(DemoDlg.dataset.Tables[0],datarow1);				
				Rep.AddBands("Company");
				decimal amount=0;
				int total=0;
				foreach(DataRow datarow2 in datarow1.GetChildRows(DemoDlg.dataset.Relations[0]))
				{
					total++;
					amount=amount+(decimal)datarow2["AmountPaid"];
					Rep.SetDTValues(DemoDlg.dataset.Tables[1],datarow2);
					Rep.AddBands("Amount");
				}
				Rep.SetInt32("TotalOrders",total);
				Rep.SetDecimal("totalamount",amount);
				Rep.AddBands("Total");
				Rep.ProgressStep();
			}
			Rep.SetDateTime("CurrDate",DateTime.Now);
			Rep.ProgressStop();
			Rep.ShowReport();
		}
	}
}
