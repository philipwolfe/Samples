using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace Test_App
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Joaqs.UI.XpGroupBox groupBox1;
		private Joaqs.UI.XpButton button1;
		private Joaqs.UI.XpTextBox textBox1;
		private Joaqs.UI.XpCheckBox checkBox1;
		private Joaqs.UI.XpRadioButton radioButton1;
		private Joaqs.UI.XpListBox listBox1;
		private Joaqs.UI.XpComboBox comboBox1;
		private Joaqs.UI.XpDateTimePicker dateTimePicker1;
		private Joaqs.UI.XpMonthCalendar monthCalendar1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.MonthCalendar monthCalendar2;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button2;
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
			this.groupBox1 = new Joaqs.UI.XpGroupBox();
			this.monthCalendar1 = new Joaqs.UI.XpMonthCalendar();
			this.dateTimePicker1 = new Joaqs.UI.XpDateTimePicker();
			this.comboBox1 = new Joaqs.UI.XpComboBox();
			this.listBox1 = new Joaqs.UI.XpListBox();
			this.radioButton1 = new Joaqs.UI.XpRadioButton();
			this.checkBox1 = new Joaqs.UI.XpCheckBox();
			this.textBox1 = new Joaqs.UI.XpTextBox();
			this.button1 = new Joaqs.UI.XpButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.monthCalendar1,
																					this.dateTimePicker1,
																					this.comboBox1,
																					this.listBox1,
																					this.radioButton1,
																					this.checkBox1,
																					this.textBox1,
																					this.button1});
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(248, 456);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Windows XP";
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Location = new System.Drawing.Point(24, 280);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.TabIndex = 7;
			this.monthCalendar1.TitleBackColor = System.Drawing.SystemColors.ActiveCaption;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(24, 88);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(192, 21);
			this.dateTimePicker1.TabIndex = 6;
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(24, 56);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(192, 21);
			this.comboBox1.TabIndex = 5;
			this.comboBox1.Text = "comboBox1";
			// 
			// listBox1
			// 
			this.listBox1.Items.AddRange(new object[] {
														  "Item 1",
														  "Item 2",
														  "Item 3"});
			this.listBox1.Location = new System.Drawing.Point(24, 152);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(200, 121);
			this.listBox1.TabIndex = 4;
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(136, 120);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(88, 24);
			this.radioButton1.TabIndex = 3;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "radioButton1";
			// 
			// checkBox1
			// 
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(24, 120);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "checkBox1";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(24, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(112, 21);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "textBox1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(144, 24);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "&button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.monthCalendar2,
																					this.dateTimePicker2,
																					this.comboBox2,
																					this.listBox2,
																					this.radioButton2,
																					this.checkBox2,
																					this.textBox2,
																					this.button2});
			this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(296, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(248, 456);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Windows 95/98/ME/2000";
			// 
			// monthCalendar2
			// 
			this.monthCalendar2.Location = new System.Drawing.Point(24, 280);
			this.monthCalendar2.Name = "monthCalendar2";
			this.monthCalendar2.TabIndex = 7;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Location = new System.Drawing.Point(24, 88);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(192, 21);
			this.dateTimePicker2.TabIndex = 6;
			// 
			// comboBox2
			// 
			this.comboBox2.Location = new System.Drawing.Point(24, 56);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(192, 21);
			this.comboBox2.TabIndex = 5;
			this.comboBox2.Text = "comboBox2";
			// 
			// listBox2
			// 
			this.listBox2.Items.AddRange(new object[] {
														  "Item 1",
														  "Item 2",
														  "Item 3"});
			this.listBox2.Location = new System.Drawing.Point(24, 152);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(200, 121);
			this.listBox2.TabIndex = 4;
			// 
			// radioButton2
			// 
			this.radioButton2.Checked = true;
			this.radioButton2.Location = new System.Drawing.Point(136, 120);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(88, 24);
			this.radioButton2.TabIndex = 3;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "radioButton2";
			// 
			// checkBox2
			// 
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(24, 120);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.TabIndex = 2;
			this.checkBox2.Text = "checkBox2";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(24, 24);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(112, 21);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "textBox2";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(144, 24);
			this.button2.Name = "button2";
			this.button2.TabIndex = 0;
			this.button2.Text = "&button2";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 486);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox2,
																		  this.groupBox1});
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			textBox1.Enabled = !textBox1.Enabled;
		}
	}
}
