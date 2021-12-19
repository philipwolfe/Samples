using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DockMan
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox chkLeft;
		private System.Windows.Forms.RadioButton rdbLeft;
		private System.Windows.Forms.CheckBox chkTop;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton rdbTop;
		private System.Windows.Forms.CheckBox chkRight;
		private System.Windows.Forms.CheckBox chkBottom;
		private System.Windows.Forms.RadioButton rdbNone;
		private System.Windows.Forms.RadioButton rdbSet;
		private System.Windows.Forms.RadioButton rdbRight;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.RadioButton rdbBottom;
		private System.Windows.Forms.Button btnDemo;
		private System.Windows.Forms.RadioButton rdbFill;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			// Wire up event handlers
			rdbRight.Click += new System.EventHandler(radiobutton_Click);
			rdbFill.Click += new System.EventHandler(radiobutton_Click);
			rdbBottom.Click += new System.EventHandler(radiobutton_Click);
			rdbNone.Click += new System.EventHandler(radiobutton_Click);
			rdbLeft.Click += new System.EventHandler(radiobutton_Click);
			chkTop.Click += new System.EventHandler(checkbox_Click);
			chkLeft.Click += new System.EventHandler(checkbox_Click);
			chkRight.Click += new System.EventHandler(checkbox_Click);
			chkBottom.Click += new System.EventHandler(checkbox_Click);
			rdbTop.Click += new System.EventHandler(radiobutton_Click);

			// Complete intialization of the form
			rdbSet = rdbNone;
			applyChanges();
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
			this.components = new System.ComponentModel.Container();
			this.chkLeft = new System.Windows.Forms.CheckBox();
			this.rdbLeft = new System.Windows.Forms.RadioButton();
			this.chkTop = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.rdbTop = new System.Windows.Forms.RadioButton();
			this.chkRight = new System.Windows.Forms.CheckBox();
			this.chkBottom = new System.Windows.Forms.CheckBox();
			this.rdbNone = new System.Windows.Forms.RadioButton();
			this.rdbSet = new System.Windows.Forms.RadioButton();
			this.rdbRight = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.rdbBottom = new System.Windows.Forms.RadioButton();
			this.btnDemo = new System.Windows.Forms.Button();
			this.rdbFill = new System.Windows.Forms.RadioButton();
			this.chkLeft.Location = new System.Drawing.Point(8, 48);
			this.chkLeft.Size = new System.Drawing.Size(72, 24);
			this.chkLeft.TabIndex = 2;
			this.chkLeft.Text = "&Left";
			this.rdbLeft.Location = new System.Drawing.Point(8, 72);
			this.rdbLeft.Size = new System.Drawing.Size(72, 24);
			this.rdbLeft.TabIndex = 3;
			this.rdbLeft.Text = "&Left";
			this.chkTop.Location = new System.Drawing.Point(8, 24);
			this.chkTop.Size = new System.Drawing.Size(72, 24);
			this.chkTop.TabIndex = 0;
			this.chkTop.Text = "&Top";
			this.panel1.BackColor = System.Drawing.Color.Green;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnDemo});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Size = new System.Drawing.Size(328, 400);
			this.panel1.TabIndex = 1;
			this.panel1.Text = "ButtonPanel";
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {this.groupBox1,
																				 this.groupBox2});
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(328, 0);
			this.panel2.Size = new System.Drawing.Size(120, 400);
			this.panel2.TabIndex = 0;
			this.panel2.Text = "ControlsPanel";
			this.toolTip1.SetToolTip(this.panel2, "Resize the form to see the layout effects.");
			this.rdbTop.Location = new System.Drawing.Point(8, 48);
			this.rdbTop.Size = new System.Drawing.Size(72, 24);
			this.rdbTop.TabIndex = 0;
			this.rdbTop.Text = "&Top";
			this.chkRight.Location = new System.Drawing.Point(8, 96);
			this.chkRight.Size = new System.Drawing.Size(72, 24);
			this.chkRight.TabIndex = 1;
			this.chkRight.Text = "&Right";
			this.chkBottom.Location = new System.Drawing.Point(8, 72);
			this.chkBottom.Size = new System.Drawing.Size(72, 24);
			this.chkBottom.TabIndex = 3;
			this.chkBottom.Text = "&Bottom";
			this.rdbNone.Checked = true;
			this.rdbNone.Location = new System.Drawing.Point(8, 24);
			this.rdbNone.Size = new System.Drawing.Size(72, 24);
			this.rdbNone.TabIndex = 5;
			this.rdbNone.TabStop = true;
			this.rdbNone.Text = "&None";
			this.rdbSet.Size = new System.Drawing.Size(100, 23);
			this.rdbSet.TabIndex = 0;
			this.rdbSet.Text = "rdbSet";
			this.rdbRight.Location = new System.Drawing.Point(8, 120);
			this.rdbRight.Size = new System.Drawing.Size(72, 24);
			this.rdbRight.TabIndex = 4;
			this.rdbRight.Text = "&Right";
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.chkRight,
																					this.chkBottom,
																					this.chkLeft,
																					this.chkTop});
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Size = new System.Drawing.Size(88, 128);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "A&nchor";
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {this.rdbBottom,
																					this.rdbLeft,
																					this.rdbNone,
																					this.rdbRight,
																					this.rdbFill,
																					this.rdbTop});
			this.groupBox2.Location = new System.Drawing.Point(16, 152);
			this.groupBox2.Size = new System.Drawing.Size(88, 176);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "&Dock";
			this.rdbBottom.Location = new System.Drawing.Point(8, 96);
			this.rdbBottom.Size = new System.Drawing.Size(72, 24);
			this.rdbBottom.TabIndex = 1;
			this.rdbBottom.Text = "&Bottom";
			this.btnDemo.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnDemo.BackColor = System.Drawing.SystemColors.Control;
			this.btnDemo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnDemo.Location = new System.Drawing.Point(62, 148);
			this.btnDemo.Size = new System.Drawing.Size(120, 24);
			this.btnDemo.TabIndex = 0;
			this.btnDemo.Text = "Demo Button";
			this.toolTip1.SetToolTip(this.btnDemo, "Nothing happens if you click this button.");
			this.rdbFill.Location = new System.Drawing.Point(8, 144);
			this.rdbFill.Size = new System.Drawing.Size(72, 24);
			this.rdbFill.TabIndex = 2;
			this.rdbFill.Text = "&Fill";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 400);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.panel1,
																		  this.panel2});
			this.Location = new System.Drawing.Point(100, 100);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Docking and Anchoring Example";
		}
		#endregion

		private void applyChanges() 
		{

			//Apply Anchoring Settings - maybe multiple
			AnchorStyles nSettings = AnchorStyles.None;
			if (chkTop.Checked)    nSettings |= AnchorStyles.Top;
			if (chkLeft.Checked)   nSettings |= AnchorStyles.Left;
			if (chkBottom.Checked) nSettings |= AnchorStyles.Bottom;
			if (chkRight.Checked)  nSettings |= AnchorStyles.Right;
			btnDemo.Anchor = nSettings ;

			//Apply Docking settings - one only
			if (rdbSet == rdbNone)
				btnDemo.Dock = System.Windows.Forms.DockStyle.None;
			else if (rdbSet == rdbTop)
				btnDemo.Dock = System.Windows.Forms.DockStyle.Top;
			else if (rdbSet == rdbLeft)
				btnDemo.Dock = System.Windows.Forms.DockStyle.Left;
			else if (rdbSet == rdbBottom)
				btnDemo.Dock = System.Windows.Forms.DockStyle.Bottom;
			else if (rdbSet == rdbRight)
				btnDemo.Dock = System.Windows.Forms.DockStyle.Right;
			else // The default is: if (rdbSet is rbFill)
				btnDemo.Dock = System.Windows.Forms.DockStyle.Fill;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		// <doc>
		// <desc>
		//      Whenever a checkbox is clicked, apply the changes from all
		//      controls.  Note all checkboxes use this same handler.
		// </desc>
		// </doc>
		//
		protected void checkbox_Click(object sender, EventArgs e) 
		{
			applyChanges();
		}

		// <doc>
		// <desc>
		//      Save the radio button that was clicked so we know which one is
		//      checked when we apply the changes.  Note, all radio buttons use
		//      this same click handler.
		// </desc>
		// </doc>
		//
		protected void radiobutton_Click(object sender, EventArgs e) 
		{
			rdbSet = (RadioButton)sender;
			applyChanges();
		}

		private void btnDemo_Click(object sender, System.EventArgs e)
		{

		}
	}
}
