using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ExpenseVersion1
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cboExpenseType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtExpenseAmount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSubmit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

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
			base.Dispose();
			if(components != null)
				components.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cboExpenseType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtExpenseAmount = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.cboExpenseType.DropDownWidth = 120;
			this.cboExpenseType.Location = new System.Drawing.Point(112, 72);
			this.cboExpenseType.Size = new System.Drawing.Size(120, 21);
			this.cboExpenseType.TabIndex = 2;
			this.label2.Location = new System.Drawing.Point(8, 72);
			this.label2.Size = new System.Drawing.Size(96, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Expense Type:";
			this.txtExpenseAmount.Location = new System.Drawing.Point(112, 40);
			this.txtExpenseAmount.Size = new System.Drawing.Size(120, 20);
			this.txtExpenseAmount.TabIndex = 1;
			this.txtExpenseAmount.Text = "";
			this.label1.Location = new System.Drawing.Point(8, 40);
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Expense Amount:";
			this.btnSubmit.Location = new System.Drawing.Point(80, 112);
			this.btnSubmit.Size = new System.Drawing.Size(104, 24);
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "Submit Expense";
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(267, 160);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.label2,
																		  this.label1,
																		  this.txtExpenseAmount,
																		  this.btnSubmit,
																		  this.cboExpenseType});
			this.Text = "frmClientVersion1";
			this.Load += new System.EventHandler(this.Form1_Load);

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

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			ExpenseApproval.ExpenseApproval objExpense;
			string str;
			
			//Create the Expense object
			objExpense = new ExpenseApproval.ExpenseApproval();
			//Call Approve Expense
			str = objExpense.ApproveExpense(Convert.ToDouble(this.txtExpenseAmount.Text),this.cboExpenseType.SelectedItem.ToString());
			//Display the results
			MessageBox.Show(str,"Expense Approval");
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			string itemList;

			itemList = "Training";
			this.cboExpenseType.Items.Add(itemList);
			itemList = "Travel";
			this.cboExpenseType.Items.Add(itemList);
			itemList = "Software";
			this.cboExpenseType.Items.Add(itemList);
			itemList = "Hardware";
			this.cboExpenseType.Items.Add(itemList);
			itemList = "Entertainment";
			this.cboExpenseType.Items.Add(itemList);
			
		}
	}
}
