using System;
using Windows.Forms.Reports.ReportLibrary;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Buttons
{
	public class PlugInButton:UserRepPlugIn
	{
		public PlugInButton()
		{
			Type type=typeof(PlugInButton);
			//this is necessary
			AssemblyPath=type.Assembly.Location;			
		}

		protected override object CreateVar()
		{
			Button FButton=new Button();
			FButton.BackColor=SystemColors.Control;
			FButton.Size=new Size(150,23);	
			FButton.Location=new Point(10,10);
			return FButton;
		}

		public override void ApplyValues()
		{
			for(int i=0;i<VarCount;i++)
			{
				if(GetVarNames(i)=="Button 1")
				{
					((Button)FVarList.GetObject(i)).Click +=new EventHandler(button1_Click);
					((Button)FVarList.GetObject(i)).Text="Sort by contact name";
				}
				else if(GetVarNames(i)=="Button 2")
				{
					((Button)FVarList.GetObject(i)).Click +=new EventHandler(button2_Click);
					((Button)FVarList.GetObject(i)).Text="Sort by cust. no";
				}
				else if(GetVarNames(i)=="Button 3")
				{
					((Button)FVarList.GetObject(i)).Click+=new EventHandler(PlugInButton_Click);
					((Button)FVarList.GetObject(i)).Text="Sort by company";
				}
				UserRep.SetControl(GetVarNames(i),(Control)FVarList.GetObject(i));
			}
		}

		private void button1_Click(object sender,EventArgs e)
		{
			Sort("Band",1);
		}

		private void button2_Click(object sender,EventArgs e)
		{
			Sort("Band",4);
		}

		private void PlugInButton_Click(object sender, EventArgs e)
		{
			Sort("Band",0);
		}

		void Sort(string BandName,int CellIdx)
		{
			Band Previousband=null;
			Band band=null;
			Rep rep=(Rep)UserRep.SourceRep.RepList[0];
			for(int j=0;j<rep.BandCount;j++)
			{
				Previousband=null;
				for(int i=j;i<rep.BandCount;i++)
				{
					if(rep.GetBand(i).Name==BandName)
					{
						band=rep.GetBand(i);
						if(Previousband!=null)
						{
							if(band.GetCell(CellIdx).Value.CompareTo(Previousband.GetCell(CellIdx).Value)<0)
							{
								rep.MoveBand(i,rep.IndexOfBand(Previousband));
								Previousband=band;
							}
						}
						else
						{
							Previousband=band;
						}
					}
				}
			}
			UserRep.ShowPage(1,true);
		}
	}
}