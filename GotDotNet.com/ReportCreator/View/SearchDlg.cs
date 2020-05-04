using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Windows.Forms.Reports.View
{
	#region SearchDlg
	public class SearchDlg : System.Windows.Forms.Form
	{
		#region class variables
		public string Find;
		public ArrayList FindList;
		public bool MatchCase;
		public bool ComboItem;
		public bool Down;
		public bool Up;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton DownButton;
		private System.Windows.Forms.RadioButton UpButton;
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public SearchDlg()
		{
			FindList=new ArrayList();
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.DownButton = new System.Windows.Forms.RadioButton();
			this.UpButton = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(24, 112);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(160, 112);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Text = "Cancel";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(24, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(208, 21);
			this.comboBox1.TabIndex = 3;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(24, 48);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(88, 24);
			this.checkBox1.TabIndex = 4;
			this.checkBox1.Text = "Match case";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.UpButton,
																					this.DownButton});
			this.groupBox1.Location = new System.Drawing.Point(112, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(120, 56);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// DownButton
			// 
			this.DownButton.Location = new System.Drawing.Point(8, 8);
			this.DownButton.Name = "DownButton";
			this.DownButton.Size = new System.Drawing.Size(104, 16);
			this.DownButton.TabIndex = 0;
			this.DownButton.Text = "Down";
			// 
			// UpButton
			// 
			this.UpButton.Location = new System.Drawing.Point(8, 32);
			this.UpButton.Name = "UpButton";
			this.UpButton.Size = new System.Drawing.Size(104, 16);
			this.UpButton.TabIndex = 1;
			this.UpButton.Text = "Up";
			// 
			// SearchDlg
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(248, 150);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox1,
																		  this.checkBox1,
																		  this.comboBox1,
																		  this.button2,
																		  this.button1});
			this.Name = "SearchDlg";
			this.Text = "Find";
			this.Load += new System.EventHandler(this.SearchDlg_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		private void button1_Click(object sender, System.EventArgs e)
		{
			Find=comboBox1.Text;
			MatchCase=checkBox1.Checked;
			for(int i=0;i<FindList.Count;i++)
			{
				if((string)FindList[i]==Find)
				{
					ComboItem=true;
					break;
				}
			}
			Down=DownButton.Checked;
			Up=UpButton.Checked;
		}

		private void SearchDlg_Load(object sender, System.EventArgs e)
		{
			for(int i=0;i<FindList.Count;i++)
				comboBox1.Items.Add(FindList[i]);
			DownButton.Checked=true;
		}
		#endregion
	}
	#endregion
}
