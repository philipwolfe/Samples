using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.VisualBasic;

namespace CarValues
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.Label Label4;
		private System.Windows.Forms.ComboBox cboCondition;
		private System.Windows.Forms.TextBox txtYear;
		private System.Windows.Forms.TextBox txtModel;
		private System.Windows.Forms.TextBox txtMake;
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.GroupBox GroupBox2;
		private System.Windows.Forms.Label lblCurrentValue;
		private System.Windows.Forms.Button cmdBlueBook;
		private System.Windows.Forms.Button cmdBlackBook;
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
		public override void Dispose()
		{
			if (components != null) 
			{
				components.Dispose();
			}
			base.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.cmdBlackBook = new System.Windows.Forms.Button();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.cboCondition = new System.Windows.Forms.ComboBox();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtYear = new System.Windows.Forms.TextBox();
			this.txtMake = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.lblCurrentValue = new System.Windows.Forms.Label();
			this.cmdBlueBook = new System.Windows.Forms.Button();
			this.GroupBox1.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point(16, 48);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(48, 16);
			this.Label2.TabIndex = 4;
			this.Label2.Text = "Model";
			// 
			// Label3
			// 
			this.Label3.Location = new System.Drawing.Point(16, 72);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(48, 16);
			this.Label3.TabIndex = 5;
			this.Label3.Text = "Year";
			// 
			// cmdBlackBook
			// 
			this.cmdBlackBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdBlackBook.Location = new System.Drawing.Point(16, 32);
			this.cmdBlackBook.Name = "cmdBlackBook";
			this.cmdBlackBook.Size = new System.Drawing.Size(56, 40);
			this.cmdBlackBook.TabIndex = 0;
			this.cmdBlackBook.Text = "Black Book";
			this.cmdBlackBook.Click += new System.EventHandler(this.cmdBlackBook_Click);
			// 
			// txtModel
			// 
			this.txtModel.Location = new System.Drawing.Point(72, 48);
			this.txtModel.Name = "txtModel";
			this.txtModel.Size = new System.Drawing.Size(120, 20);
			this.txtModel.TabIndex = 7;
			this.txtModel.Text = "Avenger";
			// 
			// cboCondition
			// 
			this.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCondition.DropDownWidth = 120;
			this.cboCondition.Location = new System.Drawing.Point(72, 96);
			this.cboCondition.Name = "cboCondition";
			this.cboCondition.Size = new System.Drawing.Size(120, 21);
			this.cboCondition.TabIndex = 9;
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label4,
																					this.cboCondition,
																					this.txtYear,
																					this.txtModel,
																					this.txtMake,
																					this.Label3,
																					this.Label2,
																					this.Label1,
																					this.GroupBox2});
			this.GroupBox1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.GroupBox1.Location = new System.Drawing.Point(8, 8);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(272, 328);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Price A Car";
			// 
			// Label4
			// 
			this.Label4.Location = new System.Drawing.Point(16, 100);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(52, 16);
			this.Label4.TabIndex = 10;
			this.Label4.Text = "Condition";
			// 
			// txtYear
			// 
			this.txtYear.Location = new System.Drawing.Point(72, 72);
			this.txtYear.Name = "txtYear";
			this.txtYear.Size = new System.Drawing.Size(120, 20);
			this.txtYear.TabIndex = 8;
			this.txtYear.Text = "1996";
			// 
			// txtMake
			// 
			this.txtMake.Location = new System.Drawing.Point(72, 24);
			this.txtMake.Name = "txtMake";
			this.txtMake.Size = new System.Drawing.Size(120, 20);
			this.txtMake.TabIndex = 6;
			this.txtMake.Text = "Dodge";
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(16, 24);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(48, 16);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "Make";
			// 
			// GroupBox2
			// 
			this.GroupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblCurrentValue,
																					this.cmdBlueBook,
																					this.cmdBlackBook});
			this.GroupBox2.Location = new System.Drawing.Point(16, 144);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(232, 144);
			this.GroupBox2.TabIndex = 2;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Calculate Current Value Based on:";
			// 
			// lblCurrentValue
			// 
			this.lblCurrentValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.lblCurrentValue.Location = new System.Drawing.Point(104, 64);
			this.lblCurrentValue.Name = "lblCurrentValue";
			this.lblCurrentValue.Size = new System.Drawing.Size(120, 40);
			this.lblCurrentValue.TabIndex = 2;
			// 
			// cmdBlueBook
			// 
			this.cmdBlueBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdBlueBook.Location = new System.Drawing.Point(16, 88);
			this.cmdBlueBook.Name = "cmdBlueBook";
			this.cmdBlueBook.Size = new System.Drawing.Size(56, 40);
			this.cmdBlueBook.TabIndex = 1;
			this.cmdBlueBook.Text = "Blue Book";
			this.cmdBlueBook.Click += new System.EventHandler(this.cmdBlueBook_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 357);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.GroupBox1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox2.ResumeLayout(false);
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.cboCondition.Items.Add("MINT");
			this.cboCondition.Items.Add("VERY GOOD");
			this.cboCondition.Items.Add("GOOD");
			this.cboCondition.Items.Add("POOR");
			this.cboCondition.Items.Add("JUNK");
			
		}

		private void cmdBlackBook_Click(object sender, System.EventArgs e) 
		{
			Car objCar = new Car();
			Double dblValue;

			// In this Sub, a reference to the BlackBookValue method will be passed to the ***
			// delegate indicating that the total value of the car should be based on our  ***
			// calculated black book value                                                 ***

			// In the call below, we use a delegate to call the BlackBookValue method ***
			// on our behalf.  If, in the future, a new method of determining car     ***
			// values became avaliable (i.e. Red Book Values), we could add an add'l  ***
			// method without having to change our Cars component.                    ***

			switch(Microsoft.VisualBasic.Strings.UCase(this.cboCondition.Text))
			{
				case "MINT":
					dblValue = objCar.CalculateTotal(new CarValues.Car.BookValue(this.BlackBookValue), this.txtMake.Text, this.txtModel.Text, this.txtYear.Text, Car.ConditionEnum.condMint);
					break;
				case "VERY GOOD":
					dblValue = objCar.CalculateTotal(new CarValues.Car.BookValue(this.BlackBookValue), this.txtMake.Text, this.txtModel.Text, this.txtYear.Text, Car.ConditionEnum.condVeryGood);
					break;
				case "GOOD":
					dblValue = objCar.CalculateTotal(new CarValues.Car.BookValue(this.BlackBookValue), this.txtMake.Text, this.txtModel.Text, this.txtYear.Text, Car.ConditionEnum.condGood);
					break;
				case "POOR":
					dblValue = objCar.CalculateTotal(new CarValues.Car.BookValue(this.BlackBookValue), this.txtMake.Text, this.txtModel.Text, this.txtYear.Text, Car.ConditionEnum.condPoor);
					break;
				case "JUNK":
					dblValue = objCar.CalculateTotal(new CarValues.Car.BookValue(this.BlackBookValue), this.txtMake.Text, this.txtModel.Text, this.txtYear.Text, Car.ConditionEnum.condJunk);
					break;
				default:
					dblValue = 0;
					break;
			}

			this.lblCurrentValue.Text = dblValue.ToString("C");
		}
		private void cmdBlueBook_Click(object sender, System.EventArgs e)
		{
		Car objCar = new Car();
        Double dblValue;

        // In this Sub, a reference to the BlueBookValue method will be passed to the ***
        // delegate indicating that the total value of the car should be based on our  ***
        // calculated black book value                                                 ***

        // In the call below, we use a delegate to call the BlueBookValue method ***
        // on our behalf.  If, in the future, a new method of determining car     ***
        // values became avaliable (i.e. Red Book Values), we could add an add'l  ***
        // method without having to change our Cars component.                    ***

			switch(Microsoft.VisualBasic.Strings.UCase(this.cboCondition.Text))
			{
				case "MINT":
					dblValue = objCar.CalculateTotal(new CarValues.Car.BookValue(this.BlueBookValue), this.txtMake.Text, this.txtModel.Text, this.txtYear.Text, Car.ConditionEnum.condMint);
					break;
				case "VERY GOOD":
					dblValue = objCar.CalculateTotal(new CarValues.Car.BookValue(this.BlueBookValue), this.txtMake.Text, this.txtModel.Text, this.txtYear.Text, Car.ConditionEnum.condVeryGood);
					break;
				case "GOOD":
					dblValue = objCar.CalculateTotal(new CarValues.Car.BookValue(this.BlueBookValue), this.txtMake.Text, this.txtModel.Text, this.txtYear.Text, Car.ConditionEnum.condGood);
					break;
				case "POOR":
					dblValue = objCar.CalculateTotal(new CarValues.Car.BookValue(this.BlueBookValue), this.txtMake.Text, this.txtModel.Text, this.txtYear.Text, Car.ConditionEnum.condPoor);
					break;
				case "JUNK":
					dblValue = objCar.CalculateTotal(new CarValues.Car.BookValue(this.BlueBookValue), this.txtMake.Text, this.txtModel.Text, this.txtYear.Text, Car.ConditionEnum.condJunk);
					break;
				default:
					dblValue = 0;
					break;
			}

        this.lblCurrentValue.Text = dblValue.ToString("C");
		}
		
		private double BlackBookValue(string Make, string Model, string Year) 
		{
			// However, these values would typically be retrieved from a data source. ***
			// In this sample, the blue book value is hard-coded in the Function.     **

			switch (Microsoft.VisualBasic.Strings.UCase(Make))
			{
				case "DODGE":
				switch (Microsoft.VisualBasic.Strings.UCase(Model))
				{
					case "AVENGER":
					switch (Year)
					{
						case "1996":
							return 16520;	
						default:
							return 14520;
					}
					default:
						return 12520;
				}
				default:
					return 10520;
			}
		}
		private double BlueBookValue(string Make, string Model,string Year)
		{
			// However, these values would typically be retrieved from a data source. ***
			// In this sample, the blue book value is hard-coded in the Function.     **

			switch (Microsoft.VisualBasic.Strings.UCase(Make))
			{
				case "DODGE":
				switch (Microsoft.VisualBasic.Strings.UCase(Model))
				{
					case "AVENGER":
					switch (Year)
					{
						case "1996":
							return 14000;
									
						default:
							return 12000;
					}
					default:
						return 10000;

				}
				default:
					return 8000;
			}
		}		
	}
}

