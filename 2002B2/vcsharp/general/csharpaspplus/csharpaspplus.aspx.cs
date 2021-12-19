using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CSharpASPPlusSample
{
	/// <summary>
	/// Summary description for CSharpASPPlusSample.
	/// </summary>
	public class CSharpASPPlus : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList6;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.DropDownList DropDownList5;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.CheckBoxList CheckBoxList1;
		protected System.Web.UI.WebControls.Calendar Calendar1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label1;
		public DataTable dt;
		protected System.Data.DataView dataView1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		public DataRow dr1;	
	
		public CSharpASPPlus()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{

			if (!IsPostBack)
			{
				
				DropDownList1.DataBind();
				DropDownList5.DataBind();
				CheckBoxList1.DataBind();
				
			}
			
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Windows Form Designer.
			//
			InitializeComponent();
			dt = new DataTable();
			dt.Columns.Add(new DataColumn("Marke", typeof(string)));
			dt.Columns.Add(new DataColumn("Buick", typeof(string)));
			dt.Columns.Add(new DataColumn("Chevrolet", typeof(string)));
			dt.Columns.Add(new DataColumn("Pontiac", typeof(string)));
			dt.Columns.Add(new DataColumn("Toyota", typeof(string)));
			dt.Columns.Add(new DataColumn("Mileage", typeof(string)));
			dt.Columns.Add(new DataColumn("Featurs", typeof(string)));
			dr1 = dt.NewRow();
			dr1[0] = "Pick up A Model";
			dr1[1] = "";
			dr1[2] = "";
			dr1[3]= "";
			dr1[4]= "";
			dr1[5]= "";
			dr1[6]= "Power Seat";
			dt.Rows.Add(dr1);
		    
			dr1 = dt.NewRow();
			dr1[0] = "Buick";
			dr1[1] = "Century";
			dr1[2] = "Impala";
			dr1[3]= "Grand Am";
			dr1[4]= "Avalon";
			dr1[5]= "0-10000";
			dr1[6]= "Leather seat";
			dt.Rows.Add(dr1);

			dr1 = dt.NewRow();
			dr1[0] = "Chevrolet";
			dr1[1] = "LeSabre";
			dr1[2] = "Malibu";
			dr1[3]= "Grand Prix";
			dr1[4]= "Camry";
			dr1[5]= "10000-20000";
			dr1[6]= "Sun Roof";
			dt.Rows.Add(dr1);

			dr1 = dt.NewRow();
			dr1[0] = "Pontiac";
			dr1[1] = "Park Avenue";
			dr1[2] = "Metro";
			dr1[3]= "Montana";
			dr1[4]= "Camry Solara";
			dr1[5]= "20000-30000";
			dr1[6]= "CD Player";
			dt.Rows.Add(dr1);

			dr1 = dt.NewRow();
			dr1[0] = "Toyota";
			dr1[1] = "Regal";
			dr1[2] = "Prizm";
			dr1[3]= "Sunfire";
			dr1[4]= "Celica";
			dr1[5]= "30000 And More";
			dr1[6]= "ABS";
			dt.Rows.Add(dr1);
			for(int i=1993;i<2002;i++)
			{
				if(i==1993) DropDownList3.Items.Add(new ListItem("",""));
				else
				{
					string year = i.ToString();
					DropDownList3.Items.Add(new ListItem(year,year));
				}
			}

			this.dataView1.Table=this.dt;
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dataView1 = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
			this.Calendar1.SelectionChanged += new System.EventHandler(this.Calendar1_SelectionChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();

		}
		#endregion

		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string selected = DropDownList1.SelectedItem.Value;
			int select=this.DropDownList1.SelectedIndex;
			dataView1.Table=dt;
			switch(selected) 
			{
				case "Buick":
			  
			{
					this.dataView1.Table=this.dt;
					this.DropDownList2.DataSource=dataView1;
					DropDownList2.DataTextField="Buick";
					DropDownList2.DataValueField="Buick";
					DropDownList2.DataBind();
					break;
				}
				case "Chevrolet":
			  
			{
					this.DropDownList2.DataSource=dataView1;
					DropDownList2.DataTextField="Chevrolet";
					DropDownList2.DataValueField="Chevrolet";
					DropDownList2.DataBind();
					break;
				}
			
				case "Pontiac":
			  
			{
					this.DropDownList2.DataSource=dataView1;
					DropDownList2.DataTextField="Pontiac";
					DropDownList2.DataValueField="Pontiac";
					DropDownList2.DataBind();
					break;
				}
				case "Toyota":
			  
			{
					this.DropDownList2.DataSource=dataView1;
					DropDownList2.DataTextField="Toyota";
					DropDownList2.DataValueField="Toyota";
					DropDownList2.DataBind();
					break;
				}

		 
			}
			
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			
			if (this.Calendar1.SelectedDate<DateTime.Now)
				Label3.Text="No date has been selected or you have selected invalid date";
			else Label3.Text="The desired date for the car is  "+ Label2.Text ;
			Label1.Text="You Selection is a "+DropDownList6.SelectedItem.Value +"  " +DropDownList1.SelectedItem.Value+" "
				+" "+DropDownList2.SelectedItem.Value;
			if(DropDownList3.SelectedIndex==0)
				Label4.Text="No perferable year";
			else Label4.Text="perferable year is "+ DropDownList3.SelectedItem.Value;
			if(DropDownList4.SelectedIndex==0)
				Label5.Text="No perferable Color";
			else Label5.Text="perferable Color is "+ DropDownList4.SelectedItem.Value;
			if(DropDownList5.SelectedIndex==0)
				Label6.Text="No Milage restrection";
			else Label6.Text="perferable milage is "+ DropDownList5.SelectedItem.Value;
			for(int i=0;i<CheckBoxList1.Items.Count;i++)
			{
				if(CheckBoxList1.Items[i].Selected)
				{
					Label7.Text+=CheckBoxList1.Items[i].Value+" ,";
				}
			}




		}

		private void Calendar1_SelectionChanged(object sender, System.EventArgs e)
		{
			if(Calendar1.SelectedDate<DateTime.Now)
				Label2.Text="Incorrect date Slection";
			else if(Calendar1.SelectedDate.ToString()=="1/1/0001 12:00:00 AM")
				Label2.Text="";
			else Label2.Text= Calendar1.SelectedDate.ToString();
		}
	}
}
