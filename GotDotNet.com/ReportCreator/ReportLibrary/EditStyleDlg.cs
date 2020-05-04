using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region EditStyleDlg
	public class EditStyleDlg : System.Windows.Forms.Form
	{
		#region class variables
		public Style style;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		public System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		public System.Windows.Forms.ComboBox comboBox5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		public System.Windows.Forms.ComboBox comboBox6;
		public System.Windows.Forms.ComboBox comboBox7;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		public System.Windows.Forms.ComboBox comboBox8;
		public System.Windows.Forms.ComboBox comboBox9;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		public System.Windows.Forms.ComboBox comboBox10;
		public System.Windows.Forms.ComboBox comboBox11;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		public System.Windows.Forms.ComboBox comboBox12;
		public System.Windows.Forms.ComboBox comboBox13;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public EditStyleDlg()
		{
			InitializeComponent();

			LineStyle[] o=(LineStyle[])Enum.GetValues(typeof(LineStyle));
			for(int i=0;i<o.Length;i++)
			{
				LineStyle a=(LineStyle)o[i];
				comboBox7.Items.Add(a);
				comboBox9.Items.Add(a);
				comboBox11.Items.Add(a);
				comboBox13.Items.Add(a);
			}

			HAlign[] halign=(HAlign[])Enum.GetValues(typeof(HAlign));
			for(int i=0;i<halign.Length;i++)
			{
				HAlign a=(HAlign)halign[i];
				comboBox1.Items.Add(a);
			}

			VAlign[] valign=(VAlign[])Enum.GetValues(typeof(VAlign));
			for(int i=0;i<valign.Length;i++)
			{
				VAlign a=(VAlign)valign[i];
				comboBox2.Items.Add(a);
			}

			FillDirection[] fill=(FillDirection[])Enum.GetValues(typeof(FillDirection));
			for(int i=0;i<fill.Length;i++)
			{
				FillDirection a=(FillDirection)fill[i];
				comboBox5.Items.Add(a);
			}

			ShapeType[] shape=(ShapeType[])Enum.GetValues(typeof(ShapeType));
			for(int i=0;i<shape.Length;i++)
			{
				ShapeType a=(ShapeType)shape[i];
				comboBox4.Items.Add(a);
			}

			DashStyle[] dash=(DashStyle[])Enum.GetValues(typeof(DashStyle));
			for(int i=0;i<dash.Length;i++)
			{
				DashStyle a=(DashStyle)dash[i];
				if(a!=DashStyle.Custom)
					comboBox3.Items.Add(a);
			}
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button3 = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button5 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.button7 = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.comboBox5 = new System.Windows.Forms.ComboBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.button11 = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.comboBox12 = new System.Windows.Forms.ComboBox();
			this.comboBox13 = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.button10 = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.comboBox10 = new System.Windows.Forms.ComboBox();
			this.comboBox11 = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button9 = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.comboBox8 = new System.Windows.Forms.ComboBox();
			this.comboBox9 = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button8 = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.comboBox6 = new System.Windows.Forms.ComboBox();
			this.comboBox7 = new System.Windows.Forms.ComboBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(112, 296);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "&OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(208, 296);
			this.button2.Name = "button2";
			this.button2.TabIndex = 1;
			this.button2.Text = "&Cancel";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(448, 288);
			this.tabControl1.TabIndex = 2;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.comboBox2);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.comboBox1);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.checkBox1);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(440, 262);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Text";
			// 
			// comboBox2
			// 
			this.comboBox2.Location = new System.Drawing.Point(160, 112);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 21);
			this.comboBox2.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(160, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Vertical alignment";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Horizantal alignment";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(8, 112);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 4;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton4);
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox2.Location = new System.Drawing.Point(160, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(121, 57);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Text orientation";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(64, 32);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(48, 16);
			this.radioButton4.TabIndex = 3;
			this.radioButton4.Text = "&270";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(8, 32);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(40, 16);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Text = "&90";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(64, 16);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(48, 16);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "&180";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(8, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(32, 16);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "&0";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(296, 112);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Word wrap";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(16, 32);
			this.button3.Name = "button3";
			this.button3.TabIndex = 0;
			this.button3.Text = "Font";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.checkBox4);
			this.tabPage2.Controls.Add(this.checkBox3);
			this.tabPage2.Controls.Add(this.groupBox5);
			this.tabPage2.Controls.Add(this.checkBox2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(440, 262);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Picture";
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(280, 72);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(131, 17);
			this.checkBox4.TabIndex = 8;
			this.checkBox4.Text = "&Tiles picture";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(144, 72);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(131, 17);
			this.checkBox3.TabIndex = 7;
			this.checkBox3.Text = "&Fit to cell";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.button4);
			this.groupBox5.Controls.Add(this.textBox4);
			this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox5.Location = new System.Drawing.Point(8, 8);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(408, 49);
			this.groupBox5.TabIndex = 6;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "&Image";
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.button4.Location = new System.Drawing.Point(376, 16);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(23, 21);
			this.button4.TabIndex = 1;
			this.button4.Text = "...";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(8, 16);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(368, 20);
			this.textBox4.TabIndex = 0;
			this.textBox4.Text = "";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(8, 72);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(131, 17);
			this.checkBox2.TabIndex = 2;
			this.checkBox2.Text = "&Link to file";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.panel1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(440, 262);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Shape";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.button5);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.comboBox3);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.button6);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.comboBox4);
			this.panel1.Controls.Add(this.button7);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.comboBox5);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(440, 262);
			this.panel1.TabIndex = 30;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(280, 120);
			this.button5.Name = "button5";
			this.button5.TabIndex = 42;
			this.button5.Text = "Set color";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(280, 96);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 16);
			this.label7.TabIndex = 41;
			this.label7.Text = "Border color";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(280, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 16);
			this.label6.TabIndex = 40;
			this.label6.Text = "Border Style";
			// 
			// comboBox3
			// 
			this.comboBox3.Location = new System.Drawing.Point(280, 72);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(121, 21);
			this.comboBox3.TabIndex = 39;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(280, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 16);
			this.label5.TabIndex = 38;
			this.label5.Text = "Border Width";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(280, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 37;
			this.textBox1.Text = "";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(144, 120);
			this.button6.Name = "button6";
			this.button6.TabIndex = 36;
			this.button6.Text = "Set color";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 16);
			this.label4.TabIndex = 35;
			this.label4.Text = "Background color";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 34;
			this.label3.Text = "Shape type";
			// 
			// comboBox4
			// 
			this.comboBox4.Location = new System.Drawing.Point(8, 56);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(121, 21);
			this.comboBox4.TabIndex = 33;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(8, 120);
			this.button7.Name = "button7";
			this.button7.TabIndex = 32;
			this.button7.Text = "Set color";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(144, 96);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 16);
			this.label8.TabIndex = 31;
			this.label8.Text = "Graident color";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(144, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 16);
			this.label9.TabIndex = 30;
			this.label9.Text = "Fill Direction";
			// 
			// comboBox5
			// 
			this.comboBox5.Location = new System.Drawing.Point(144, 56);
			this.comboBox5.Name = "comboBox5";
			this.comboBox5.Size = new System.Drawing.Size(121, 21);
			this.comboBox5.TabIndex = 29;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.groupBox6);
			this.tabPage4.Controls.Add(this.groupBox4);
			this.tabPage4.Controls.Add(this.groupBox3);
			this.tabPage4.Controls.Add(this.groupBox1);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(440, 262);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Borders";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.button11);
			this.groupBox6.Controls.Add(this.label19);
			this.groupBox6.Controls.Add(this.label20);
			this.groupBox6.Controls.Add(this.label21);
			this.groupBox6.Controls.Add(this.comboBox12);
			this.groupBox6.Controls.Add(this.comboBox13);
			this.groupBox6.Location = new System.Drawing.Point(0, 192);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(376, 64);
			this.groupBox6.TabIndex = 3;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Bottom Border";
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(288, 32);
			this.button11.Name = "button11";
			this.button11.TabIndex = 16;
			this.button11.Text = "Set color";
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(288, 16);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(72, 16);
			this.label19.TabIndex = 15;
			this.label19.Text = "Border color";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(152, 16);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(100, 16);
			this.label20.TabIndex = 14;
			this.label20.Text = "Border style";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(8, 16);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(100, 16);
			this.label21.TabIndex = 13;
			this.label21.Text = "Border width";
			// 
			// comboBox12
			// 
			this.comboBox12.Items.AddRange(new object[] {
															"0",
															"1",
															"2",
															"3",
															"4",
															"5",
															"6",
															"7"});
			this.comboBox12.Location = new System.Drawing.Point(8, 32);
			this.comboBox12.Name = "comboBox12";
			this.comboBox12.Size = new System.Drawing.Size(121, 21);
			this.comboBox12.TabIndex = 12;
			// 
			// comboBox13
			// 
			this.comboBox13.Location = new System.Drawing.Point(152, 32);
			this.comboBox13.Name = "comboBox13";
			this.comboBox13.Size = new System.Drawing.Size(121, 21);
			this.comboBox13.TabIndex = 11;
			this.comboBox13.SelectedIndexChanged += new System.EventHandler(this.comboBox13_SelectedIndexChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.button10);
			this.groupBox4.Controls.Add(this.label16);
			this.groupBox4.Controls.Add(this.label17);
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.comboBox10);
			this.groupBox4.Controls.Add(this.comboBox11);
			this.groupBox4.Location = new System.Drawing.Point(0, 128);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(376, 64);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Top Border";
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(288, 32);
			this.button10.Name = "button10";
			this.button10.TabIndex = 16;
			this.button10.Text = "Set color";
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(288, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(72, 16);
			this.label16.TabIndex = 15;
			this.label16.Text = "Border color";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(152, 16);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(100, 16);
			this.label17.TabIndex = 14;
			this.label17.Text = "Border style";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(8, 16);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(100, 16);
			this.label18.TabIndex = 13;
			this.label18.Text = "Border width";
			// 
			// comboBox10
			// 
			this.comboBox10.Items.AddRange(new object[] {
															"0",
															"1",
															"2",
															"3",
															"4",
															"5",
															"6",
															"7"});
			this.comboBox10.Location = new System.Drawing.Point(8, 32);
			this.comboBox10.Name = "comboBox10";
			this.comboBox10.Size = new System.Drawing.Size(121, 21);
			this.comboBox10.TabIndex = 12;
			// 
			// comboBox11
			// 
			this.comboBox11.Location = new System.Drawing.Point(152, 32);
			this.comboBox11.Name = "comboBox11";
			this.comboBox11.Size = new System.Drawing.Size(121, 21);
			this.comboBox11.TabIndex = 11;
			this.comboBox11.SelectedIndexChanged += new System.EventHandler(this.comboBox11_SelectedIndexChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.button9);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.comboBox8);
			this.groupBox3.Controls.Add(this.comboBox9);
			this.groupBox3.Location = new System.Drawing.Point(0, 64);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(376, 64);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Right Border";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(288, 32);
			this.button9.Name = "button9";
			this.button9.TabIndex = 16;
			this.button9.Text = "Set color";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(288, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(72, 16);
			this.label13.TabIndex = 15;
			this.label13.Text = "Border color";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(152, 16);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(100, 16);
			this.label14.TabIndex = 14;
			this.label14.Text = "Border style";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(8, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(100, 16);
			this.label15.TabIndex = 13;
			this.label15.Text = "Border width";
			// 
			// comboBox8
			// 
			this.comboBox8.Items.AddRange(new object[] {
														   "0",
														   "1",
														   "2",
														   "3",
														   "4",
														   "5",
														   "6",
														   "7"});
			this.comboBox8.Location = new System.Drawing.Point(8, 32);
			this.comboBox8.Name = "comboBox8";
			this.comboBox8.Size = new System.Drawing.Size(121, 21);
			this.comboBox8.TabIndex = 12;
			// 
			// comboBox9
			// 
			this.comboBox9.Location = new System.Drawing.Point(152, 32);
			this.comboBox9.Name = "comboBox9";
			this.comboBox9.Size = new System.Drawing.Size(121, 21);
			this.comboBox9.TabIndex = 11;
			this.comboBox9.SelectedIndexChanged += new System.EventHandler(this.comboBox9_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button8);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.comboBox6);
			this.groupBox1.Controls.Add(this.comboBox7);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(376, 64);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Left Border";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(288, 32);
			this.button8.Name = "button8";
			this.button8.TabIndex = 16;
			this.button8.Text = "Set color";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(288, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 16);
			this.label10.TabIndex = 15;
			this.label10.Text = "Border color";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(152, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 16);
			this.label11.TabIndex = 14;
			this.label11.Text = "Border style";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 16);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 16);
			this.label12.TabIndex = 13;
			this.label12.Text = "Border width";
			// 
			// comboBox6
			// 
			this.comboBox6.Items.AddRange(new object[] {
														   "0",
														   "1",
														   "2",
														   "3",
														   "4",
														   "5",
														   "6",
														   "7"});
			this.comboBox6.Location = new System.Drawing.Point(8, 32);
			this.comboBox6.Name = "comboBox6";
			this.comboBox6.Size = new System.Drawing.Size(121, 21);
			this.comboBox6.TabIndex = 12;
			// 
			// comboBox7
			// 
			this.comboBox7.Location = new System.Drawing.Point(152, 32);
			this.comboBox7.Name = "comboBox7";
			this.comboBox7.Size = new System.Drawing.Size(121, 21);
			this.comboBox7.TabIndex = 11;
			this.comboBox7.SelectedIndexChanged += new System.EventHandler(this.comboBox7_SelectedIndexChanged);
			// 
			// EditStyleDlg
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(448, 342);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "EditStyleDlg";
			this.Text = "Edit style";
			this.Load += new System.EventHandler(this.EditStyleDlg_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		private void button11_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color=style.BottomColor;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				style.BottomColor=colorDialog1.Color;
			}
		}

		private void button10_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color=style.TopColor;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				style.TopColor=colorDialog1.Color;
			}
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color=style.RightColor;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				style.RightColor=colorDialog1.Color;
			}
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color=style.LeftColor;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				style.LeftColor=colorDialog1.Color;
			}
		}

		private void comboBox13_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if((LineStyle)comboBox13.SelectedItem==LineStyle.Dash)
			{
				comboBox12.SelectedItem="1";
				comboBox12.Enabled=false;
			}
			else if((LineStyle)comboBox13.SelectedItem==LineStyle.Dot)
			{
				comboBox12.SelectedItem="1";
				comboBox12.Enabled=false;
			}
			else if((LineStyle)comboBox13.SelectedItem==LineStyle.DashDot)
			{
				comboBox12.SelectedItem="1";
				comboBox12.Enabled=false;
			}
			else if((LineStyle)comboBox13.SelectedItem==LineStyle.DashDotDot)
			{
				comboBox12.SelectedItem="1";
				comboBox12.Enabled=false;
			}
			else if((LineStyle)comboBox13.SelectedItem==LineStyle.Double11)
			{
				comboBox12.SelectedItem="3";
				comboBox12.Enabled=false;
			}
			else if((LineStyle)comboBox13.SelectedItem==LineStyle.Double21)
			{
				comboBox12.SelectedItem="4";
				comboBox12.Enabled=false;
			}
			else if((LineStyle)comboBox13.SelectedItem==LineStyle.Double12)
			{
				comboBox12.SelectedItem="4";
				comboBox12.Enabled=false;
			}
			else
			{
				comboBox12.Enabled=true;
			}
		}

		private void comboBox11_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if((LineStyle)comboBox11.SelectedItem==LineStyle.Dash)
			{
				comboBox10.SelectedItem="1";
				comboBox10.Enabled=false;
			}
			else if((LineStyle)comboBox11.SelectedItem==LineStyle.Dot)
			{
				comboBox10.SelectedItem="1";
				comboBox10.Enabled=false;
			}
			else if((LineStyle)comboBox11.SelectedItem==LineStyle.DashDot)
			{
				comboBox10.SelectedItem="1";
				comboBox10.Enabled=false;
			}
			else if((LineStyle)comboBox11.SelectedItem==LineStyle.DashDotDot)
			{
				comboBox10.SelectedItem="1";
				comboBox10.Enabled=false;
			}
			else if((LineStyle)comboBox11.SelectedItem==LineStyle.Double11)
			{
				comboBox10.SelectedItem="3";
				comboBox10.Enabled=false;
			}
			else if((LineStyle)comboBox11.SelectedItem==LineStyle.Double21)
			{
				comboBox10.SelectedItem="4";
				comboBox10.Enabled=false;
			}
			else if((LineStyle)comboBox11.SelectedItem==LineStyle.Double12)
			{
				comboBox10.SelectedItem="4";
				comboBox10.Enabled=false;
			}
			else
			{
				comboBox10.Enabled=true;
			}
		}

		private void comboBox9_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if((LineStyle)comboBox9.SelectedItem==LineStyle.Dash)
			{
				comboBox8.SelectedItem="1";
				comboBox8.Enabled=false;
			}
			else if((LineStyle)comboBox9.SelectedItem==LineStyle.Dot)
			{
				comboBox8.SelectedItem="1";
				comboBox8.Enabled=false;
			}
			else if((LineStyle)comboBox9.SelectedItem==LineStyle.DashDot)
			{
				comboBox8.SelectedItem="1";
				comboBox8.Enabled=false;
			}
			else if((LineStyle)comboBox9.SelectedItem==LineStyle.DashDotDot)
			{
				comboBox8.SelectedItem="1";
				comboBox8.Enabled=false;
			}
			else if((LineStyle)comboBox9.SelectedItem==LineStyle.Double11)
			{
				comboBox8.SelectedItem="3";
				comboBox8.Enabled=false;
			}
			else if((LineStyle)comboBox9.SelectedItem==LineStyle.Double21)
			{
				comboBox8.SelectedItem="4";
				comboBox8.Enabled=false;
			}
			else if((LineStyle)comboBox9.SelectedItem==LineStyle.Double12)
			{
				comboBox8.SelectedItem="4";
				comboBox8.Enabled=false;
			}
			else
			{
				comboBox8.Enabled=true;
			}
		}

		private void comboBox7_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if((LineStyle)comboBox7.SelectedItem==LineStyle.Dash)
			{
				comboBox6.SelectedItem="1";
				comboBox6.Enabled=false;
			}
			else if((LineStyle)comboBox7.SelectedItem==LineStyle.Dot)
			{
				comboBox6.SelectedItem="1";
				comboBox6.Enabled=false;
			}
			else if((LineStyle)comboBox7.SelectedItem==LineStyle.DashDot)
			{
				comboBox6.SelectedItem="1";
				comboBox6.Enabled=false;
			}
			else if((LineStyle)comboBox7.SelectedItem==LineStyle.DashDotDot)
			{
				comboBox6.SelectedItem="1";
				comboBox6.Enabled=false;
			}
			else if((LineStyle)comboBox7.SelectedItem==LineStyle.Double11)
			{
				comboBox6.SelectedItem="3";
				comboBox6.Enabled=false;
			}
			else if((LineStyle)comboBox7.SelectedItem==LineStyle.Double21)
			{
				comboBox6.SelectedItem="4";
				comboBox6.Enabled=false;
			}
			else if((LineStyle)comboBox7.SelectedItem==LineStyle.Double12)
			{
				comboBox6.SelectedItem="4";
				comboBox6.Enabled=false;
			}
			else
			{
				comboBox6.Enabled=true;
			}
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color=style.ShapeBorderColor;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				style.ShapeBorderColor=colorDialog1.Color;
			}
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color=style.ShapeGraidentColor;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				style.ShapeGraidentColor=colorDialog1.Color;
			}
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color=style.ShapeColor;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				style.ShapeColor=colorDialog1.Color;
			}
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			openFileDialog1.Filter="All (*.bmp;*.jpeg;*.jpg*.ico)|*.bmp;*.jpeg;*.jpg*;.ico|Bitmaps (*.bmp)|*.bmp|Jpeg (*.jpeg;*.jpg*)|*.jpeg;*.jpg*;|Icons (*.ico)|*.ico";
			openFileDialog1.FileName=textBox4.Text;
			if(openFileDialog1.ShowDialog()==DialogResult.OK)
				textBox4.Text=openFileDialog1.FileName;
			openFileDialog1.Dispose();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			fontDialog1.Font=new Font(style.FontName,
				style.FontSize,style.FontStyle);
			fontDialog1.ShowColor=true;
			fontDialog1.Color=style.FontColor;
			if(fontDialog1.ShowDialog()==DialogResult.OK)
			{
				style.FontName=fontDialog1.Font.Name;
				style.FontSize=fontDialog1.Font.Size;
				style.FontStyle=fontDialog1.Font.Style;
				style.FontColor=fontDialog1.Color;
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(radioButton1.Checked)
				style.TextAngle=0;
			if(radioButton2.Checked)
				style.TextAngle=180;
			if(radioButton3.Checked)
				style.TextAngle=90;
			if(radioButton4.Checked)
				style.TextAngle=270;

			style.HAlign=(HAlign)comboBox1.SelectedItem;
			style.VAlign=(VAlign)comboBox2.SelectedItem;

			style.WordWrap=checkBox1.Checked;

			style.PictureFileName=textBox4.Text;

			style.LinkToFile=checkBox2.Checked;
			style.FitToCell=checkBox3.Checked;
			style.TilesPicture=checkBox4.Checked;

			if(comboBox4.SelectedIndex==0)
				style.Shape=false;
			else
			{
				style.Shape=true;
				style.ShapeType=(ShapeType)comboBox4.SelectedItem;
				style.ShapeBorderStyle=(DashStyle)comboBox3.SelectedItem;
				try
				{
					style.ShapeBorderWidth=Convert.ToInt32(textBox1.Text);
				}
				catch
				{
					style.ShapeBorderWidth=0;
				}
				if(comboBox5.SelectedIndex==0)
					style.ShapeGraident=false;
				else
				{
					style.ShapeGraident=true;
					style.ShapeFillDirection=(FillDirection)comboBox5.SelectedItem;
				}
			}
			style.LeftWidth=Convert.ToInt32(comboBox6.SelectedItem.ToString());
			style.LeftStyle=(LineStyle)comboBox7.SelectedItem;

			style.RightWidth=Convert.ToInt32(comboBox8.SelectedItem.ToString());
			style.RightStyle=(LineStyle)comboBox9.SelectedItem;

			style.TopWidth=Convert.ToInt32(comboBox10.SelectedItem.ToString());
			style.TopStyle=(LineStyle)comboBox11.SelectedItem;

			style.BottomWidth=Convert.ToInt32(comboBox12.SelectedItem.ToString());
			style.BottomStyle=(LineStyle)comboBox13.SelectedItem;
		}

		private void EditStyleDlg_Load(object sender, System.EventArgs e)
		{
			if(style.TextAngle==0)
				radioButton1.Checked=true;
			else if(style.TextAngle==90)
				radioButton3.Checked=true;
			else if(style.TextAngle==180)
				radioButton2.Checked=true;
			else if(style.TextAngle==270)
				radioButton4.Checked=true;

			comboBox1.SelectedItem=style.HAlign;
			comboBox2.SelectedItem=style.VAlign;

			checkBox1.Checked=style.WordWrap;

			textBox4.Text=style.PictureFileName;

			checkBox2.Checked=style.LinkToFile;
			checkBox3.Checked=style.FitToCell;
			checkBox4.Checked=style.TilesPicture;

			if(style.Shape==false)
			{
				comboBox3.SelectedIndex=0;
				comboBox4.SelectedIndex=0;
				comboBox5.SelectedIndex=0;
			}
			else
			{
				comboBox4.SelectedItem=style.ShapeType;
				textBox1.Text=style.ShapeBorderWidth.ToString();
				comboBox3.SelectedItem=style.ShapeBorderStyle;
				if(style.ShapeGraident==false)
					comboBox5.SelectedIndex=0;
				else
				{
					comboBox5.SelectedItem=style.ShapeFillDirection;
				}
			}
			comboBox6.SelectedItem=style.LeftWidth.ToString();
			comboBox7.SelectedItem=style.LeftStyle;

			comboBox8.SelectedItem=style.RightWidth.ToString();
			comboBox9.SelectedItem=style.RightStyle;

			comboBox10.SelectedItem=style.TopWidth.ToString();
			comboBox11.SelectedItem=style.TopStyle;

			comboBox12.SelectedItem=style.BottomWidth.ToString();
			comboBox13.SelectedItem=style.BottomStyle;
		}
		#endregion		
	}
	#endregion
}
