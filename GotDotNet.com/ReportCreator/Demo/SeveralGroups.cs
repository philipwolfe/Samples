using System;
using Windows.Forms.Reports.ReportLibrary;
using System.Data;
using System.Windows.Forms;

namespace Windows.Forms.Reports.Demo
{
	public class SeveralGroups
	{
		public static void SeveralGroupReport(UserRep Rep)
		{
			Rep.BeginReport();
			Rep.ProgressStart(DemoDlg.dataset.Tables[0].Rows.Count);
			decimal TotalPrice,TotalCustomer;

			Rep.Load(Application.StartupPath+@"..\..\..\Templates\SeveralGroup.SD");
			Rep.Title="Several group report";
			Rep.AddBands("Title");
			Rep.AddBands("Header");
			foreach(DataRow datarow1 in DemoDlg.dataset.Tables[0].Rows)
			{
				Rep.BeginPara();
				Rep.AddGroupBands("Company",(string)datarow1[1],1);
				TotalCustomer=0.0M;
				foreach(DataRow datarow2 in datarow1.GetChildRows(DemoDlg.dataset.Relations[0]))
				{
					TotalPrice=0.0M;
					Rep.SetDTValues(DemoDlg.dataset.Tables[1],datarow2);
					Rep.AddGroupBands("OrderNo",Convert.ToString(datarow2[0]),2);
					Rep.AddBands("PartHeader");
					foreach(DataRow datarow3 in datarow2.GetChildRows(DemoDlg.dataset.Relations[1]))
					{
						foreach(DataRow datarow4 in datarow3.GetParentRows(DemoDlg.dataset.Relations[2]))
						{							
							TotalPrice=TotalPrice+(decimal)datarow4[6];
							Rep.SetDTValues(DemoDlg.dataset.Tables[3],datarow4);
							Rep.AddBands("Detail");				
						}											
					}
					Rep.SetDecimal("TotalPrice",TotalPrice);
					Rep.AddBands("OrderFooter");
					TotalCustomer=TotalCustomer+TotalPrice;
				}
				Rep.SetDecimal("TotalCustomer",TotalCustomer);
				Rep.AddBands("CompanyFooter");
				Rep.ProgressStep();
			}
			Rep.ProgressStop();
			Rep.ShowReport();
		}
	}
}
