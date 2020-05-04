using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using Windows.Forms.Reports.View;
using Windows.Forms.Reports.ReportLibrary;
using Buttons;

namespace Windows.Forms.Reports.Demo
{
	#region DemoDlg
	public class DemoDlg : System.Windows.Forms.Form
	{
		#region class variables
		OleDbConnection conn;		
		OleDbCommand command;
		OleDbDataAdapter adapter;
		public static DataSet dataset;
		PlugInButton PlugInButton;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private Windows.Forms.Reports.BarcodePlugin.Barcode barcode1;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public DemoDlg()
		{
			InitializeComponent();
		}
		#endregion

		#region destructor
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.barcode1 = new Windows.Forms.Reports.BarcodePlugin.Barcode();
			this.button9 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.button9);
			this.panel1.Controls.Add(this.button8);
			this.panel1.Controls.Add(this.button7);
			this.panel1.Controls.Add(this.button6);
			this.panel1.Controls.Add(this.button5);
			this.panel1.Controls.Add(this.button4);
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Location = new System.Drawing.Point(8, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(152, 296);
			this.panel1.TabIndex = 0;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(16, 232);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(120, 23);
			this.button8.TabIndex = 7;
			this.button8.Text = "Button Report";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(16, 200);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(120, 23);
			this.button7.TabIndex = 6;
			this.button7.Text = "All Reports";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(16, 168);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(120, 23);
			this.button6.TabIndex = 5;
			this.button6.Text = "Barcode Report";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(16, 136);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(120, 23);
			this.button5.TabIndex = 4;
			this.button5.Text = "SeveralGroup Report";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(16, 104);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(120, 23);
			this.button4.TabIndex = 3;
			this.button4.Text = "MasterDetail Report";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(16, 72);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(120, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "Groups Report";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "&Simple Report";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(16, 40);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(120, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Clients Report";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// barcode1
			// 
			this.barcode1.Angle = 0;
			this.barcode1.Color = System.Drawing.Color.White;
			this.barcode1.ColorBar = System.Drawing.Color.Black;
			this.barcode1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.barcode1.Height = 50;
			this.barcode1.Modul = 1;
			this.barcode1.Ratio = 2;
			this.barcode1.ShowText = Windows.Forms.Reports.BarcodePlugin.BarcodeOption.Code;
			this.barcode1.ShowTextFont = new System.Drawing.Font("Arial", 8.25F);
			this.barcode1.ShowTextPosition = Windows.Forms.Reports.BarcodePlugin.ShowTextPosition.TopLeft;
			this.barcode1.UserRep = null;
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(16, 264);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(120, 23);
			this.button9.TabIndex = 8;
			this.button9.Text = "Cross Band";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// DemoDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(168, 318);
			this.Controls.Add(this.panel1);
			this.Name = "DemoDlg";
			this.Text = "Demo";
			this.Load += new System.EventHandler(this.DemoDlg_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Main
		[STAThread]
		static void Main() 
		{
			Application.Run(new DemoDlg());
		}
		#endregion

		#region class methods
		private void DemoDlg_Load(object sender, System.EventArgs e)
		{
			conn=new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source="+Application.StartupPath+@"\data\dbdemos.mdb");
			adapter=new OleDbDataAdapter();
			dataset=new DataSet();					
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			PreviewForm view=new PreviewForm();
			UserRep rep=view.userRep;
			rep.DeleteBands();
			conn.Open();
			command=new OleDbCommand("select * from customer order by company",conn);
			adapter.SelectCommand=command;				
			adapter.Fill(dataset,"customer");
			conn.Close();
			simple.SimpleReport(rep);
			dataset.Reset();
			view.Show();
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			PreviewForm view=new PreviewForm();
			UserRep rep=view.userRep;
			rep.DeleteBands();
			CrossBand.CrossBandReport(rep);
			view.Show();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			PreviewForm view=new PreviewForm();
			UserRep rep=view.userRep;
			rep.DeleteBands();
			conn.Open();
			command=new OleDbCommand("SELECT * FROM CLIENTS",conn);
			adapter.SelectCommand=command;				
			adapter.Fill(dataset,"clients");
			conn.Close();
			Clients.ClientsReport(rep);
			dataset.Reset();
			view.Show();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			PreviewForm view=new PreviewForm();
			UserRep rep=view.userRep;
			rep.DeleteBands();
			conn.Open();
			command=new OleDbCommand("SELECT * FROM CUSTOMER ORDER BY COMPANY",conn);
			adapter.SelectCommand=command;				
			adapter.Fill(dataset,"customer");
			conn.Close();
			Groups.GroupsReport(rep);
			dataset.Reset();
			view.Show();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			PreviewForm view=new PreviewForm();
			UserRep rep=view.userRep;
			rep.DeleteBands();
			conn.Open();
			command=new OleDbCommand("SELECT * FROM CUSTOMER ORDER BY COMPANY",conn);
			OleDbCommand command2=new OleDbCommand("SELECT * FROM ORDERS",conn);
			adapter.SelectCommand=command;	
			OleDbDataAdapter adapter2=new OleDbDataAdapter();
			adapter2.SelectCommand=command2;
			adapter.Fill(dataset,"customer");
			adapter2.Fill(dataset,"orders");
			conn.Close();
			dataset.Relations.Add(dataset.Tables[0].Columns[0],dataset.Tables[1].Columns[1]);
			MasterDetail.MasterDetailReport(rep);
			dataset.Reset();
			view.Show();
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			PreviewForm view=new PreviewForm();
			UserRep rep=view.userRep;
			rep.DeleteBands();
			conn.Open();
			command=new OleDbCommand("SELECT * FROM CUSTOMER ORDER BY COMPANY",conn);
			OleDbCommand command2=new OleDbCommand("SELECT * FROM ORDERS ORDER BY ORDERNO",conn);
			OleDbCommand command3=new OleDbCommand("SELECT * FROM ITEMS",conn);
			OleDbCommand command4=new OleDbCommand("SELECT * FROM PARTS",conn); 
			
			adapter.SelectCommand=command;			
			adapter.Fill(dataset,"customer");
			OleDbDataAdapter adapter2=new OleDbDataAdapter();
			adapter2.SelectCommand=command2;
			adapter2.Fill(dataset,"orders");
			OleDbDataAdapter adapter3=new OleDbDataAdapter();
			adapter3.SelectCommand=command3;
			adapter3.Fill(dataset,"items");
			OleDbDataAdapter adapter4=new OleDbDataAdapter();
			adapter4.SelectCommand=command4;
			adapter4.Fill(dataset,"parts");


			conn.Close();
			dataset.Relations.Add(dataset.Tables[0].Columns[0],dataset.Tables[1].Columns[1]);
			dataset.Relations.Add(dataset.Tables[1].Columns[0],dataset.Tables[2].Columns[0]);
			dataset.Relations.Add(dataset.Tables[3].Columns[0],dataset.Tables[2].Columns[2]);
			SeveralGroups.SeveralGroupReport(rep);
			dataset.Reset();

			view.Show();
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			PreviewForm view=new PreviewForm();
			UserRep rep=view.userRep;
			barcode1.UserRep=rep;
			rep.DeleteBands();
			Barcode.BarcodeReport(rep,barcode1);
			view.Show();
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			PreviewForm view=new PreviewForm();
			UserRep rep=view.userRep;
			rep.DeleteBands();
			conn.Open();
			command=new OleDbCommand("select * from customer order by company",conn);
			adapter.SelectCommand=command;				
			adapter.Fill(dataset,"customer");
			conn.Close();
			AllReport.SimpleReport(rep);
			dataset.Reset();
			
			conn.Open();
			command=new OleDbCommand("SELECT * FROM CLIENTS",conn);
			adapter.SelectCommand=command;				
			adapter.Fill(dataset,"clients");
			conn.Close();
			AllReport.ClientsReport(rep);
			dataset.Reset();
			view.Show();
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			PlugInButton=new PlugInButton();

			conn=new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source="+Application.StartupPath+@"\data\dbdemos.mdb");
			adapter=new OleDbDataAdapter();
			dataset=new DataSet();	

			PreviewForm view=new PreviewForm();
			UserRep rep=view.userRep;
			rep.DeleteBands();			

			PlugInButton.UserRep=rep;				

			conn.Open();
			command=new OleDbCommand("select * from customer order by company",conn);
			adapter.SelectCommand=command;				
			adapter.Fill(dataset,"customer");
			conn.Close();
			ButtonReport(rep);	
			dataset.Reset();
			view.Show();
		}

		void ButtonReport(UserRep Rep)
		{
			Rep.BeginReport();
			Rep.Title="Button Report";
			
			Rep.Load(Application.StartupPath+@"..\..\..\Templates\Buttons.SD");

			PlugInButton.GetObjectByName("Button 1");
			PlugInButton.GetObjectByName("Button 2");
			PlugInButton.GetObjectByName("Button 3");

			Rep.AddBands("ButtonBand");
			Rep.UnRegisterPlugIn(PlugInButton);
			int Pos=0;
			Rep.ProgressStart(dataset.Tables[0].Rows.Count);
			Rep.AddBands("Title");
			Rep.AddBands("Header");
			while(Pos<dataset.Tables[0].Rows.Count)
			{
				Rep.SetDTValues(dataset.Tables[0],dataset.Tables[0].Rows[Pos]);
				Rep.AddBands("Band");
				Pos++;
				Rep.ProgressStep();
			}
			Rep.SetDateTime("CurrDate",DateTime.Now);
			Rep.ProgressStop();
			Rep.ShowReport();
		}
		#endregion
	}
	#endregion
}
