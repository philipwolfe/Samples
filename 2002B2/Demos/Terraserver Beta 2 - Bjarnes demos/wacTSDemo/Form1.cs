using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using wacTSDemo.net.terraservice;

namespace wacTSDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.ComboBox cbPU;
		internal System.Windows.Forms.Label lblResult;
		internal System.Windows.Forms.Button btnCheck;
		internal System.Windows.Forms.TextBox txtYear;
		internal System.Windows.Forms.Label lblYear;
		internal System.Windows.Forms.Label lblPU;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.cbPU = new System.Windows.Forms.ComboBox();
			this.lblResult = new System.Windows.Forms.Label();
			this.btnCheck = new System.Windows.Forms.Button();
			this.txtYear = new System.Windows.Forms.TextBox();
			this.lblYear = new System.Windows.Forms.Label();
			this.lblPU = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbPU
			// 
			this.cbPU.DropDownWidth = 121;
			this.cbPU.Items.AddRange(new object[] {
													  "City",
													  "County",
													  "State",
													  "CensusTract"});
			this.cbPU.Location = new System.Drawing.Point(176, 8);
			this.cbPU.Name = "cbPU";
			this.cbPU.Size = new System.Drawing.Size(121, 21);
			this.cbPU.TabIndex = 5;
			// 
			// lblResult
			// 
			this.lblResult.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblResult.Location = new System.Drawing.Point(16, 96);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(344, 192);
			this.lblResult.TabIndex = 1;
			this.lblResult.Text = "Value";
			this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnCheck
			// 
			this.btnCheck.Location = new System.Drawing.Point(144, 320);
			this.btnCheck.Name = "btnCheck";
			this.btnCheck.TabIndex = 0;
			this.btnCheck.Text = "&Check";
			this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
			// 
			// txtYear
			// 
			this.txtYear.Location = new System.Drawing.Point(176, 40);
			this.txtYear.Name = "txtYear";
			this.txtYear.TabIndex = 4;
			this.txtYear.Text = "1990";
			// 
			// lblYear
			// 
			this.lblYear.Location = new System.Drawing.Point(16, 40);
			this.lblYear.Name = "lblYear";
			this.lblYear.Size = new System.Drawing.Size(160, 23);
			this.lblYear.TabIndex = 3;
			this.lblYear.Text = "Year";
			// 
			// lblPU
			// 
			this.lblPU.Location = new System.Drawing.Point(16, 8);
			this.lblPU.Name = "lblPU";
			this.lblPU.Size = new System.Drawing.Size(152, 23);
			this.lblPU.TabIndex = 2;
			this.lblPU.Text = "Political Unit";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 366);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cbPU,
																		  this.lblResult,
																		  this.btnCheck,
																		  this.txtYear,
																		  this.lblYear,
																		  this.lblPU});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "TerraService - Visual C#.NET";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnCheck_Click(object sender, System.EventArgs e)
		{
			PoliticalUnit puType = new PoliticalUnit(); 
			CensusService tsService = new CensusService();
			string txtPU = cbPU.Text;
			int iYear;

			switch (txtPU)
			{
				case "CensusTract":
			
					puType = PoliticalUnit.CensusTract;
					break;

				case "City":
				
					puType = PoliticalUnit.City;
					break;

				case "State":
				
					puType = PoliticalUnit.State;
					break;

				case "County":
				
					puType = PoliticalUnit.County;
					break;
				
				case "Unknown":
					
					puType= PoliticalUnit.Unknown;
					break;

				default:
				
					puType = PoliticalUnit.Unknown;
					break;
			}

			iYear = Convert.ToInt32(txtYear.Text);

			
			lblResult.Text = (tsService.CountOfPoliticalUnit(puType,iYear)).ToString();


		}


	}
}
