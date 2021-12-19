using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Calc
{
	/// <summary>
	/// Summary description for Calc.
	/// </summary>
	public class Calc : System.Windows.Forms.Form
	{
		// Data variables
		protected Double mOp1, mOp2;		// Previously input operand.
		protected Int32 mNumOps;			// Number of operands.
		protected Operation mLastInput;	// Indicate type of last keypress event.
		protected String mOpFlag;			// Indicate pending operation.
		protected String mOpPrev;			// Previous operation
		protected String mMinus = "-";		// Just like a #define for "-"

		private System.Windows.Forms.Button CalcDec;
		private System.Windows.Forms.Button Calc2;
		private System.Windows.Forms.Button Calc1;
		private System.Windows.Forms.Button Calc6;
		private System.Windows.Forms.Button Calc5;
		private System.Windows.Forms.Button Calc4;
		private System.Windows.Forms.Button CalcCE;
		private System.Windows.Forms.Button CalcPlus;
		private System.Windows.Forms.MenuItem ExitMenu;
		private System.Windows.Forms.Button CalcSub;
		private System.Windows.Forms.TextBox CalcField;
		private System.Windows.Forms.Button Calc7;
		private System.Windows.Forms.Button CalcCan;
		private System.Windows.Forms.Button CalcDiv;
		private System.Windows.Forms.Button Calc3;
		private System.Windows.Forms.MenuItem FileMenu;
		private System.Windows.Forms.Button Calc8;
		private System.Windows.Forms.Button CalcRes;
		private System.Windows.Forms.Button Calc0;
		private System.Windows.Forms.Button Calc9;
		private System.Windows.Forms.Button CalcMul;
		private System.Windows.Forms.Button CalcBS;
		private System.Windows.Forms.Button CalcSign;
		private System.Windows.Forms.MainMenu CalcMenu;

		protected enum Operation
		{
			None=0,
			Operand,
			Operator,
			CE,
			Cancel,
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>

		public Calc()
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
			base.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Calc));
			this.Calc9 = new System.Windows.Forms.Button();
			this.Calc8 = new System.Windows.Forms.Button();
			this.CalcRes = new System.Windows.Forms.Button();
			this.CalcCan = new System.Windows.Forms.Button();
			this.Calc7 = new System.Windows.Forms.Button();
			this.CalcCE = new System.Windows.Forms.Button();
			this.Calc5 = new System.Windows.Forms.Button();
			this.CalcDiv = new System.Windows.Forms.Button();
			this.Calc3 = new System.Windows.Forms.Button();
			this.CalcBS = new System.Windows.Forms.Button();
			this.Calc0 = new System.Windows.Forms.Button();
			this.CalcMenu = new System.Windows.Forms.MainMenu();
			this.CalcMul = new System.Windows.Forms.Button();
			this.CalcSign = new System.Windows.Forms.Button();
			this.Calc6 = new System.Windows.Forms.Button();
			this.FileMenu = new System.Windows.Forms.MenuItem();
			this.Calc4 = new System.Windows.Forms.Button();
			this.CalcDec = new System.Windows.Forms.Button();
			this.Calc2 = new System.Windows.Forms.Button();
			this.Calc1 = new System.Windows.Forms.Button();
			this.CalcSub = new System.Windows.Forms.Button();
			this.CalcField = new System.Windows.Forms.TextBox();
			this.CalcPlus = new System.Windows.Forms.Button();
			this.ExitMenu = new System.Windows.Forms.MenuItem();
			this.Calc9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc9.Location = new System.Drawing.Point(96, 48);
			this.Calc9.Size = new System.Drawing.Size(30, 30);
			this.Calc9.TabIndex = 3;
			this.Calc9.Text = "9";
			this.Calc9.Click += new System.EventHandler(this.Calc9_Click);
			this.Calc8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc8.Location = new System.Drawing.Point(56, 48);
			this.Calc8.Size = new System.Drawing.Size(30, 30);
			this.Calc8.TabIndex = 2;
			this.Calc8.Text = "8";
			this.Calc8.Click += new System.EventHandler(this.Calc8_Click);
			this.CalcRes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcRes.Location = new System.Drawing.Point(176, 168);
			this.CalcRes.Size = new System.Drawing.Size(30, 30);
			this.CalcRes.TabIndex = 20;
			this.CalcRes.Text = "=";
			this.CalcRes.Click += new System.EventHandler(this.CalcRes_Click);
			this.CalcCan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcCan.Location = new System.Drawing.Point(176, 128);
			this.CalcCan.Size = new System.Drawing.Size(30, 30);
			this.CalcCan.TabIndex = 15;
			this.CalcCan.Text = "C";
			this.CalcCan.Click += new System.EventHandler(this.CalcCan_Click);
			this.Calc7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc7.Location = new System.Drawing.Point(16, 48);
			this.Calc7.Size = new System.Drawing.Size(30, 30);
			this.Calc7.TabIndex = 1;
			this.Calc7.Text = "7";
			this.Calc7.Click += new System.EventHandler(this.Calc7_Click);
			this.CalcCE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcCE.Location = new System.Drawing.Point(176, 88);
			this.CalcCE.Size = new System.Drawing.Size(30, 30);
			this.CalcCE.TabIndex = 10;
			this.CalcCE.Text = "CE";
			this.CalcCE.Click += new System.EventHandler(this.CalcCE_Click);
			this.Calc5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc5.Location = new System.Drawing.Point(56, 88);
			this.Calc5.Size = new System.Drawing.Size(30, 30);
			this.Calc5.TabIndex = 7;
			this.Calc5.Text = "5";
			this.Calc5.Click += new System.EventHandler(this.Calc5_Click);
			this.CalcDiv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcDiv.Location = new System.Drawing.Point(136, 48);
			this.CalcDiv.Size = new System.Drawing.Size(30, 30);
			this.CalcDiv.TabIndex = 4;
			this.CalcDiv.Text = "/";
			this.CalcDiv.Click += new System.EventHandler(this.CalcDiv_Click);
			this.Calc3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc3.Location = new System.Drawing.Point(96, 128);
			this.Calc3.Size = new System.Drawing.Size(30, 30);
			this.Calc3.TabIndex = 13;
			this.Calc3.Text = "3";
			this.Calc3.Click += new System.EventHandler(this.Calc3_Click);
			this.CalcBS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcBS.Location = new System.Drawing.Point(176, 48);
			this.CalcBS.Size = new System.Drawing.Size(30, 30);
			this.CalcBS.TabIndex = 5;
			this.CalcBS.Text = "BS";
			this.CalcBS.Click += new System.EventHandler(this.CalcBS_Click);
			this.Calc0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc0.Location = new System.Drawing.Point(16, 168);
			this.Calc0.Size = new System.Drawing.Size(30, 30);
			this.Calc0.TabIndex = 16;
			this.Calc0.Text = "0";
			this.Calc0.Click += new System.EventHandler(this.Calc0_Click);
			this.CalcMul.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcMul.Location = new System.Drawing.Point(136, 88);
			this.CalcMul.Size = new System.Drawing.Size(30, 30);
			this.CalcMul.TabIndex = 9;
			this.CalcMul.Text = "*";
			this.CalcMul.Click += new System.EventHandler(this.CalcMul_Click);
			this.CalcSign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcSign.Location = new System.Drawing.Point(56, 168);
			this.CalcSign.Size = new System.Drawing.Size(30, 30);
			this.CalcSign.TabIndex = 17;
			this.CalcSign.Text = "+/-";
			this.CalcSign.Click += new System.EventHandler(this.CalcSign_Click);
			this.Calc6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc6.Location = new System.Drawing.Point(96, 88);
			this.Calc6.Size = new System.Drawing.Size(30, 30);
			this.Calc6.TabIndex = 8;
			this.Calc6.Text = "6";
			this.Calc6.Click += new System.EventHandler(this.Calc6_Click);
			this.FileMenu.Index = -1;
			this.FileMenu.Text = "&File";
			this.Calc4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc4.Location = new System.Drawing.Point(16, 88);
			this.Calc4.Size = new System.Drawing.Size(30, 30);
			this.Calc4.TabIndex = 6;
			this.Calc4.Text = "4";
			this.Calc4.Click += new System.EventHandler(this.Calc4_Click);
			this.CalcDec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcDec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.CalcDec.Location = new System.Drawing.Point(96, 168);
			this.CalcDec.Size = new System.Drawing.Size(30, 30);
			this.CalcDec.TabIndex = 18;
			this.CalcDec.Text = ".";
			this.CalcDec.Click += new System.EventHandler(this.CalcDec_Click);
			this.Calc2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc2.Location = new System.Drawing.Point(56, 128);
			this.Calc2.Size = new System.Drawing.Size(30, 30);
			this.Calc2.TabIndex = 12;
			this.Calc2.Text = "2";
			this.Calc2.Click += new System.EventHandler(this.Calc2_Click);
			this.Calc1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Calc1.Location = new System.Drawing.Point(16, 128);
			this.Calc1.Size = new System.Drawing.Size(30, 30);
			this.Calc1.TabIndex = 11;
			this.Calc1.Text = "1";
			this.Calc1.Click += new System.EventHandler(this.Calc1_Click);
			this.CalcSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcSub.Location = new System.Drawing.Point(136, 128);
			this.CalcSub.Size = new System.Drawing.Size(30, 30);
			this.CalcSub.TabIndex = 14;
			this.CalcSub.Text = "-";
			this.CalcSub.Click += new System.EventHandler(this.CalcSub_Click);
			this.CalcField.BackColor = System.Drawing.SystemColors.Window;
			this.CalcField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CalcField.Location = new System.Drawing.Point(16, 8);
			this.CalcField.ReadOnly = true;
			this.CalcField.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.CalcField.Size = new System.Drawing.Size(192, 20);
			this.CalcField.TabIndex = 0;
			this.CalcField.Text = "0.";
			this.CalcField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.CalcPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CalcPlus.Location = new System.Drawing.Point(136, 168);
			this.CalcPlus.Size = new System.Drawing.Size(30, 30);
			this.CalcPlus.TabIndex = 19;
			this.CalcPlus.Text = "+";
			this.CalcPlus.Click += new System.EventHandler(this.CalcPlus_Click);
			this.ExitMenu.Index = -1;
			this.ExitMenu.Text = "E&xit";
			this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(226, 211);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.CalcRes,
																		  this.CalcPlus,
																		  this.CalcDec,
																		  this.CalcSign,
																		  this.Calc0,
																		  this.CalcCan,
																		  this.CalcSub,
																		  this.Calc3,
																		  this.Calc2,
																		  this.Calc1,
																		  this.CalcCE,
																		  this.CalcMul,
																		  this.Calc6,
																		  this.Calc5,
																		  this.Calc4,
																		  this.CalcBS,
																		  this.CalcDiv,
																		  this.Calc9,
																		  this.Calc8,
																		  this.Calc7,
																		  this.CalcField});
			this.Font = new System.Drawing.Font("Arial", 8F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.CalcMenu;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Calculator";
			this.Load += new System.EventHandler(this.Calc_Load);

		}
		#endregion
		protected void CalcBS_Click(Object sender, System.EventArgs e)
		{ 
			string strValue = CalcField.Text;
			if ((strValue.CompareTo("0.") != 0) && (strValue.Length != 0))
			{
				strValue = strValue.Remove(strValue.Length - 1, 1);
			}
			if ((strValue.Length == 0) || (strValue == "-"))
			{
				strValue = "0.";
			}
			
			CalcField.Text = strValue;
		}
		protected void CalcCan_Click(Object sender, System.EventArgs e)
		{
			Reset();
		}
		protected void CalcCE_Click(Object sender, System.EventArgs e) 
		{
			if (mLastInput.Equals(Operation.Operand))
			{
				CalcField.Text = "0.";
			}
			else if (mLastInput.Equals(Operation.Operator))
			{
				mOpFlag = mOpPrev;
			}
			mLastInput = Operation.CE;
		}

		protected void CalcDiv_Click(Object sender, System.EventArgs e) 
		{
			CalcRes_Click(sender, e);
		}

		//+, -, *, /, = click event!    
		protected void CalcRes_Click(Object sender, System.EventArgs e)
		{
			if (CalcField.Text.Length == 0)
			{
				return;
			}
			if (mLastInput.Equals(Operation.Operand))
			{
				mNumOps++;
			}
			switch (mNumOps)
			{
				case 1:
					mOp1 = Double.Parse(CalcField.Text);
					break;

				case 2:
					mOp2 = Double.Parse(CalcField.Text);

				switch (mOpFlag)
				{
					case "+":
						mOp1 = mOp1 + mOp2;
						break;

					case "-":
						mOp1 = mOp1 - mOp2;
						break;

					case "*":
						mOp1 = mOp1 * mOp2;
						break;
					case "/":
						if (mOp2 == 0)
						{
							MessageBox.Show("Can't divide by zero!","Calculator", MessageBoxButtons.OK);
						}
						else
						{
							mOp1 = mOp1 / mOp2;
						}
						break;
					case "=":
						mOp1 = mOp2;
						break;
					default:
						break;
				}
				
					CalcField.Text = mOp1.ToString();
					mNumOps = 1;
					break;

				default:
					break;
			}
			
			mLastInput = Operation.Operator;
			mOpPrev = mOpFlag;
			Button SelButton = (Button)(sender);
			mOpFlag = SelButton.Text;
		}

		protected void CalcSub_Click(Object sender, System.EventArgs e)
		{
			CalcRes_Click(sender, e);
		}

		protected void CalcMul_Click(Object sender, System.EventArgs e)
		{
			CalcRes_Click(sender, e);
		}

		protected void CalcPlus_Click(Object sender,System.EventArgs e)
		{
			CalcRes_Click(sender, e);
		}

		//+/- click event    
		protected void CalcSign_Click(Object sender,System.EventArgs e)
		{
			if (CalcField.Text.Substring(0,1) == "-") 
			{
				CalcField.Text = CalcField.Text.TrimStart(mMinus.ToCharArray());
			}
			else
			{
				CalcField.Text = mMinus + CalcField.Text;
			}
			mLastInput = Operation.Operand;
		}

		protected void Calc5_Click(Object sender,System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		protected void Calc3_Click(Object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}
		
		protected void Calc1_Click(Object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		protected void Calc4_Click(Object sender, System.EventArgs e) 
		{
			CalcNum_Click(sender, e);
		}

		protected void Calc9_Click(Object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		protected void CalcDec_Click(Object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		protected void Calc8_Click(Object sender, System.EventArgs e) 
		{
			CalcNum_Click(sender, e);
		}

		protected void Calc2_Click(Object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		protected void Calc0_Click(Object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		protected void Calc7_Click(Object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		protected void Calc6_Click(Object sender, System.EventArgs e)
		{
			CalcNum_Click(sender, e);
		}

		//0 - 9, ., click event
		protected void CalcNum_Click(Object sender, System.EventArgs e)
		{
			if (mLastInput.Equals(Operation.Operand) == false)
			{
				CalcField.Text = "0.";
			}
			
			Button SelButton = (Button)(sender);
			FormatEditField(SelButton.Text);
			mLastInput = Operation.Operand;
		}

		// Exit menu handler    
		protected void ExitMenu_Click(Object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		//private helpers
		//helper to format the entry in the text box
		private void FormatEditField(string newChar)
		{
			string strValue;
			strValue = CalcField.Text;
			if (strValue.CompareTo("0.") == 0)
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

		// helper to initialize the vals
		private void Reset()
		{
			mOp1 = 0;
			mOp2 = 0;
			mNumOps = 0;
			mLastInput = Operation.None;
			mOpFlag = "";
			mOpPrev = "";
			CalcField.Text = "0.";
		}

		static void Main() 
		{
			Application.Run(new Calc());
		}

		private void Calc_Load(object sender, System.EventArgs e)
		{

		}
	}
}
