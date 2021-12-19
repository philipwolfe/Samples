using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Calc2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button Calc4;
		private System.Windows.Forms.Button Calc7;
		private System.Windows.Forms.Button Calc5;
		private System.Windows.Forms.Button Calc6;
		private System.Windows.Forms.Button CalcMul;
		private System.Windows.Forms.Button CalcCE;
		private System.Windows.Forms.Button Calc8;
		private System.Windows.Forms.Button Calc9;
		private System.Windows.Forms.Button CalcDiv;
		private System.Windows.Forms.Button CalcBS;
		private System.Windows.Forms.Button Calc0;
		private System.Windows.Forms.Button CalcSign;
		private System.Windows.Forms.Button CalcDec;
		private System.Windows.Forms.Button CalcPlus;
		private System.Windows.Forms.Button CalcRes;
		private System.Windows.Forms.Button Calc1;
		private System.Windows.Forms.Button Calc2;
		private System.Windows.Forms.Button Calc3;
		private System.Windows.Forms.Button CalcSub;
		private System.Windows.Forms.Button CalcCan;
		private System.Windows.Forms.TextBox CalcField;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		//Data variables
		private double m_Op1;
		private double m_Op2 ;					//Previously input operand.
		private int m_NumOps;		            //Number of operands.
		Operation m_LastInput;			        //Indicate type of last keypress event.
		private string m_OpFlag;	            //Indicate pending operation.
		private string m_OpPrev;	            //Previous operation
		private string m_Minus;			        //Just like a #define for "-"

		private enum Operation
		{
			None = 0,
			Operand,
			Operator,
			CE,
			Cancel
		}
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
			this.CalcSign = new System.Windows.Forms.Button();
			this.Calc7 = new System.Windows.Forms.Button();
			this.Calc6 = new System.Windows.Forms.Button();
			this.Calc5 = new System.Windows.Forms.Button();
			this.Calc4 = new System.Windows.Forms.Button();
			this.Calc3 = new System.Windows.Forms.Button();
			this.Calc2 = new System.Windows.Forms.Button();
			this.Calc1 = new System.Windows.Forms.Button();
			this.Calc0 = new System.Windows.Forms.Button();
			this.CalcSub = new System.Windows.Forms.Button();
			this.CalcDiv = new System.Windows.Forms.Button();
			this.Calc9 = new System.Windows.Forms.Button();
			this.Calc8 = new System.Windows.Forms.Button();
			this.CalcDec = new System.Windows.Forms.Button();
			this.CalcCE = new System.Windows.Forms.Button();
			this.CalcField = new System.Windows.Forms.TextBox();
			this.CalcCan = new System.Windows.Forms.Button();
			this.CalcPlus = new System.Windows.Forms.Button();
			this.CalcMul = new System.Windows.Forms.Button();
			this.CalcRes = new System.Windows.Forms.Button();
			this.CalcBS = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CalcSign
			// 
			this.CalcSign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcSign.Location = new System.Drawing.Point(56, 192);
			this.CalcSign.Name = "CalcSign";
			this.CalcSign.Size = new System.Drawing.Size(32, 32);
			this.CalcSign.TabIndex = 0;
			this.CalcSign.Text = "+/-";
			this.CalcSign.Click += new System.EventHandler(this.CalcSign_Click);
			// 
			// Calc7
			// 
			this.Calc7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc7.Location = new System.Drawing.Point(8, 48);
			this.Calc7.Name = "Calc7";
			this.Calc7.Size = new System.Drawing.Size(32, 32);
			this.Calc7.TabIndex = 0;
			this.Calc7.Text = "7";
			this.Calc7.Click += new System.EventHandler(this.Calc7_Click);
			// 
			// Calc6
			// 
			this.Calc6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc6.Location = new System.Drawing.Point(104, 96);
			this.Calc6.Name = "Calc6";
			this.Calc6.Size = new System.Drawing.Size(32, 32);
			this.Calc6.TabIndex = 0;
			this.Calc6.Text = "6";
			this.Calc6.Click += new System.EventHandler(this.Calc6_Click);
			// 
			// Calc5
			// 
			this.Calc5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc5.Location = new System.Drawing.Point(56, 96);
			this.Calc5.Name = "Calc5";
			this.Calc5.Size = new System.Drawing.Size(32, 32);
			this.Calc5.TabIndex = 0;
			this.Calc5.Text = "5";
			this.Calc5.Click += new System.EventHandler(this.Calc5_Click);
			// 
			// Calc4
			// 
			this.Calc4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc4.Location = new System.Drawing.Point(8, 96);
			this.Calc4.Name = "Calc4";
			this.Calc4.Size = new System.Drawing.Size(32, 32);
			this.Calc4.TabIndex = 0;
			this.Calc4.Text = "4";
			this.Calc4.Click += new System.EventHandler(this.Calc4_Click);
			// 
			// Calc3
			// 
			this.Calc3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc3.Location = new System.Drawing.Point(104, 144);
			this.Calc3.Name = "Calc3";
			this.Calc3.Size = new System.Drawing.Size(32, 32);
			this.Calc3.TabIndex = 0;
			this.Calc3.Text = "3";
			this.Calc3.Click += new System.EventHandler(this.Calc3_Click);
			// 
			// Calc2
			// 
			this.Calc2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc2.Location = new System.Drawing.Point(56, 144);
			this.Calc2.Name = "Calc2";
			this.Calc2.Size = new System.Drawing.Size(32, 32);
			this.Calc2.TabIndex = 0;
			this.Calc2.Text = "2";
			this.Calc2.Click += new System.EventHandler(this.Calc2_Click);
			// 
			// Calc1
			// 
			this.Calc1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc1.Location = new System.Drawing.Point(8, 144);
			this.Calc1.Name = "Calc1";
			this.Calc1.Size = new System.Drawing.Size(32, 32);
			this.Calc1.TabIndex = 0;
			this.Calc1.Text = "1";
			this.Calc1.Click += new System.EventHandler(this.Calc1_Click);
			// 
			// Calc0
			// 
			this.Calc0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc0.Location = new System.Drawing.Point(8, 192);
			this.Calc0.Name = "Calc0";
			this.Calc0.Size = new System.Drawing.Size(32, 32);
			this.Calc0.TabIndex = 0;
			this.Calc0.Text = "0";
			this.Calc0.Click += new System.EventHandler(this.Calc0_Click);
			// 
			// CalcSub
			// 
			this.CalcSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcSub.Location = new System.Drawing.Point(152, 144);
			this.CalcSub.Name = "CalcSub";
			this.CalcSub.Size = new System.Drawing.Size(32, 32);
			this.CalcSub.TabIndex = 0;
			this.CalcSub.Text = "-";
			this.CalcSub.Click += new System.EventHandler(this.CalcSub_Click);
			// 
			// CalcDiv
			// 
			this.CalcDiv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcDiv.Location = new System.Drawing.Point(152, 48);
			this.CalcDiv.Name = "CalcDiv";
			this.CalcDiv.Size = new System.Drawing.Size(32, 32);
			this.CalcDiv.TabIndex = 0;
			this.CalcDiv.Text = "/";
			this.CalcDiv.Click += new System.EventHandler(this.CalcDiv_Click);
			// 
			// Calc9
			// 
			this.Calc9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc9.Location = new System.Drawing.Point(104, 48);
			this.Calc9.Name = "Calc9";
			this.Calc9.Size = new System.Drawing.Size(32, 32);
			this.Calc9.TabIndex = 0;
			this.Calc9.Text = "9";
			this.Calc9.Click += new System.EventHandler(this.Calc9_Click);
			// 
			// Calc8
			// 
			this.Calc8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc8.Location = new System.Drawing.Point(56, 48);
			this.Calc8.Name = "Calc8";
			this.Calc8.Size = new System.Drawing.Size(32, 32);
			this.Calc8.TabIndex = 0;
			this.Calc8.Text = "8";
			this.Calc8.Click += new System.EventHandler(this.Calc8_Click);
			// 
			// CalcDec
			// 
			this.CalcDec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcDec.Location = new System.Drawing.Point(104, 192);
			this.CalcDec.Name = "CalcDec";
			this.CalcDec.Size = new System.Drawing.Size(32, 32);
			this.CalcDec.TabIndex = 0;
			this.CalcDec.Text = ".";
			this.CalcDec.Click += new System.EventHandler(this.CalcDec_Click);
			// 
			// CalcCE
			// 
			this.CalcCE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcCE.Location = new System.Drawing.Point(200, 96);
			this.CalcCE.Name = "CalcCE";
			this.CalcCE.Size = new System.Drawing.Size(32, 32);
			this.CalcCE.TabIndex = 0;
			this.CalcCE.Text = "CE";
			this.CalcCE.Click += new System.EventHandler(this.CalcCE_Click);
			// 
			// CalcField
			// 
			this.CalcField.Location = new System.Drawing.Point(8, 16);
			this.CalcField.Name = "CalcField";
			this.CalcField.Size = new System.Drawing.Size(224, 20);
			this.CalcField.TabIndex = 1;
			this.CalcField.Text = "";
			this.CalcField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// CalcCan
			// 
			this.CalcCan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcCan.Location = new System.Drawing.Point(200, 144);
			this.CalcCan.Name = "CalcCan";
			this.CalcCan.Size = new System.Drawing.Size(32, 32);
			this.CalcCan.TabIndex = 0;
			this.CalcCan.Text = "C";
			this.CalcCan.Click += new System.EventHandler(this.CalcCan_Click);
			// 
			// CalcPlus
			// 
			this.CalcPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcPlus.Location = new System.Drawing.Point(152, 192);
			this.CalcPlus.Name = "CalcPlus";
			this.CalcPlus.Size = new System.Drawing.Size(32, 32);
			this.CalcPlus.TabIndex = 0;
			this.CalcPlus.Text = "+";
			this.CalcPlus.Click += new System.EventHandler(this.CalcPlus_Click);
			// 
			// CalcMul
			// 
			this.CalcMul.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcMul.Location = new System.Drawing.Point(152, 96);
			this.CalcMul.Name = "CalcMul";
			this.CalcMul.Size = new System.Drawing.Size(32, 32);
			this.CalcMul.TabIndex = 0;
			this.CalcMul.Text = "*";
			this.CalcMul.Click += new System.EventHandler(this.CalcMul_Click);
			// 
			// CalcRes
			// 
			this.CalcRes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcRes.Location = new System.Drawing.Point(200, 192);
			this.CalcRes.Name = "CalcRes";
			this.CalcRes.Size = new System.Drawing.Size(32, 32);
			this.CalcRes.TabIndex = 0;
			this.CalcRes.Text = "=";
			this.CalcRes.Click += new System.EventHandler(this.CalcRes_Click);
			// 
			// CalcBS
			// 
			this.CalcBS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcBS.Location = new System.Drawing.Point(200, 48);
			this.CalcBS.Name = "CalcBS";
			this.CalcBS.Size = new System.Drawing.Size(32, 32);
			this.CalcBS.TabIndex = 0;
			this.CalcBS.Text = "BS";
			this.CalcBS.Click += new System.EventHandler(this.CalcBS_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(240, 237);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.CalcField,
																		  this.CalcCan,
																		  this.CalcSub,
																		  this.Calc3,
																		  this.Calc2,
																		  this.Calc1,
																		  this.CalcRes,
																		  this.CalcPlus,
																		  this.CalcDec,
																		  this.CalcSign,
																		  this.Calc0,
																		  this.CalcBS,
																		  this.CalcDiv,
																		  this.Calc9,
																		  this.Calc8,
																		  this.CalcCE,
																		  this.CalcMul,
																		  this.Calc6,
																		  this.Calc5,
																		  this.Calc7,
																		  this.Calc4});
			this.Name = "Form1";
			this.Text = "Calculator";
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

		private void Calc0_Click(object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		private void Calc1_Click(object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		private void Calc2_Click(object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		private void Calc3_Click(object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		private void Calc4_Click(object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		private void Calc5_Click(object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		private void Calc6_Click(object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		private void Calc7_Click(object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		private void Calc8_Click(object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		private void Calc9_Click(object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		//0 - 9, ., click event
		protected void CalcNum_Click(Object sender, System.EventArgs e)
		{
			
			if((m_LastInput.Equals(Operation.Operand) == false))
			{
				this.CalcField.Text = "0.";
			}
			Button SelButton;
			SelButton = (System.Windows.Forms.Button)(sender);
			FormatEditField(SelButton.Text);
			m_LastInput = Operation.Operand;
		}
	

	//private helpers
	//helper to format the entry in the text box!
	void FormatEditField(string newChar)
	{
		string strValue;
		strValue = CalcField.Text;

		if ((strValue.CompareTo("0.") == 0))
		{
			strValue = newChar;
		}
		else
		{
			//determine if there are more than one .'s
			if (newChar == ".")
			{
				//if it's found, return
				if (strValue.IndexOf(newChar) != -1)
				{
					//don't do anything
					return;
				}
			}
			strValue = strValue + newChar;
		}	
		CalcField.Text = strValue;
	}

		private void Reset()
		{
			m_Op1 = 0;
			m_Op2 = 0;
			m_NumOps = 0;
			m_LastInput = Operation.None;
			m_OpFlag = "";
			m_OpPrev = "";
			CalcField.Text = "0.";
		}

		private void CalcBS_Click(object sender, System.EventArgs e)
		{
			string strValue;
			strValue = this.CalcField.Text;

			if (((strValue.CompareTo("0.") != 0) && (strValue.Length != 0)))
			{
				strValue = strValue.Remove(strValue.Length - 1, 1);
			}

            if (((strValue.Length == 0) || (strValue == "-")))
			{
				strValue = "0.";
			}
			CalcField.Text = strValue;
		}

		private void CalcCan_Click(object sender, System.EventArgs e)
		{
			Reset();
		}

		private void CalcCE_Click(object sender, System.EventArgs e)
		{
				if ((m_LastInput.Equals(Operation.Operand)))
				{
					CalcField.Text = "0.";
				}
				else if (m_LastInput.Equals(Operation.Operator))
				{
					m_OpFlag = m_OpPrev;
				}
				m_LastInput = Operation.CE;
		}

		private void CalcRes_Click(object sender, System.EventArgs e)
		{
			if (CalcField.Text.Length == 0)
			{	
				return;
			}
			if (m_LastInput.Equals(Operation.Operand)) 
			{
				m_NumOps = m_NumOps + 1;
			}
     		switch (m_NumOps)
			{
				case 1:
					m_Op1 = Convert.ToDouble(CalcField.Text);
						break;
				case 2:
					m_Op2 = Convert.ToDouble(CalcField.Text);
						//break;
						switch (m_OpFlag)
						{
							case "+":
								m_Op1 = m_Op1 + m_Op2;
								break;
							case "-":
								m_Op1 = m_Op1 - m_Op2;
								break;
							case "*":
								m_Op1 = m_Op1 * m_Op2;
								break;
							case "/":
								if (m_Op2 == 0)
								{	
									MessageBox.Show("Can't divide by zero!", "Calculator");
								}
								else
								{
									m_Op1 = m_Op1 / m_Op2;
								}
								break;
							case "=":
								m_Op1 = m_Op2;
								break;
						}
						CalcField.Text = m_Op1.ToString();
						m_NumOps = 1;
					break;
			}
	        m_LastInput = Operation.Operator;
		    m_OpPrev = m_OpFlag;

			System.Windows.Forms.Button SelButton;
			SelButton = (System.Windows.Forms.Button)(sender); 
			m_OpFlag = SelButton.Text;

		}

		private void CalcDiv_Click(object sender, System.EventArgs e)
		{
			CalcRes_Click(sender, e);
		}

		private void CalcMul_Click(object sender, System.EventArgs e)
		{
			CalcRes_Click(sender, e);
		}

		private void CalcSub_Click(object sender, System.EventArgs e)
		{
			CalcRes_Click(sender, e);
		}

		private void CalcPlus_Click(object sender, System.EventArgs e)
		{
			CalcRes_Click(sender, e);
		}

		private void CalcDec_Click(object sender, System.EventArgs e)
		{
			  CalcNum_Click(sender, e);
		}

		private void CalcSign_Click(object sender, System.EventArgs e)
		{
			if (CalcField.Text == "-")
			{
				CalcField.Text = CalcField.Text.TrimStart(m_Minus.ToCharArray());
			}
			else
			{
				CalcField.Text = m_Minus + CalcField.Text;
			}
	        m_LastInput = Operation.Operand;
		}
}

}
