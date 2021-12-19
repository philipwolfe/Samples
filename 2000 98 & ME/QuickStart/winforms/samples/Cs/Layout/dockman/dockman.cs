//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
//------------------------------------------------------------------------------
namespace DockMan {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;

    public class DockMan : System.WinForms.Form {
        
        // rdbSet keeps track of which radio button is checked
        private System.WinForms.RadioButton rdbSet;

        // <doc>
        // <desc>
        //     Public Constructor
        // </desc>
        // </doc>
        //
        public DockMan () : base() {
             	
            // This call is required for support of the Windows Forms Designer.
            InitializeComponent();

            // Complete intialization of the form
            rdbSet = rdbNone;
            ApplyChanges(); 
        }

        // This class overrides dispose so it can clean up the
        // component list.
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }


        // <doc>
        // <desc>
        //      Update control with new anchor and dock settings.
        //      Note that anchor == NONE is the same as (TOP && LEFT).
        // </desc>
        // </doc>
        //
        private void ApplyChanges() {

            //Apply Anchoring Settings - maybe multiple
            AnchorStyles nSettings = AnchorStyles.None;
            if (chkTop.Checked)    nSettings |= AnchorStyles.Top;
            if (chkLeft.Checked)   nSettings |= AnchorStyles.Left;
            if (chkBottom.Checked) nSettings |= AnchorStyles.Bottom;
            if (chkRight.Checked)  nSettings |= AnchorStyles.Right;
            btnDemo.Anchor = nSettings ;

            //Apply Docking settings - one only
            if (rdbSet == rdbNone) 
                btnDemo.Dock = System.WinForms.DockStyle.None;
            else if (rdbSet == rdbTop)
                btnDemo.Dock = System.WinForms.DockStyle.Top;
            else if (rdbSet == rdbLeft)
                btnDemo.Dock = System.WinForms.DockStyle.Left;
            else if (rdbSet == rdbBottom)
                btnDemo.Dock = System.WinForms.DockStyle.Bottom;
            else if (rdbSet == rdbRight) 
                btnDemo.Dock = System.WinForms.DockStyle.Right;
            else // The default is: if (rdbSet is rbFill)
                btnDemo.Dock = System.WinForms.DockStyle.Fill;
        }

        // <doc>
        // <desc>
        //      Whenever a checkbox is clicked, apply the changes from all
        //      controls.  Note all checkboxes use this same handler.
        // </desc>
        // </doc>
        //
        protected void checkbox_Click(object sender, EventArgs e) {
            ApplyChanges();
        }

        // <doc>
        // <desc>
        //      Save the radio button that was clicked so we know which one is
        //      checked when we apply the changes.  Note, all radio buttons use
        //      this same click handler.
        // </desc>
        // </doc>
        //
        protected void radiobutton_Click(object sender, EventArgs e) {
            rdbSet = (RadioButton)sender;
            ApplyChanges();
        }


        // NOTE: The following code is required by the Windows Forms Designer
        // It can be modified using the Windows Forms Designer.  
        // Do not modify it using the code editor.
        private Container components;
    
        private System.WinForms.Panel panel1;
        private System.WinForms.Panel panel2;
        private System.WinForms.GroupBox groupBox1;
        private System.WinForms.GroupBox groupBox2;
        private System.WinForms.ToolTip toolTip1;
        private System.WinForms.Button btnDemo;
        private System.WinForms.RadioButton rdbNone;   
        private System.WinForms.RadioButton rdbTop;    
        private System.WinForms.RadioButton rdbLeft;   
        private System.WinForms.RadioButton rdbBottom; 
        private System.WinForms.RadioButton rdbRight;  
        private System.WinForms.RadioButton rdbFill;    
        private System.WinForms.CheckBox chkTop;
        private System.WinForms.CheckBox chkLeft;   
        private System.WinForms.CheckBox chkBottom; 
        private System.WinForms.CheckBox chkRight;
        private System.WinForms.Splitter splitter1;
        
        private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.groupBox1 = new System.WinForms.GroupBox();
		this.groupBox2 = new System.WinForms.GroupBox();
		this.rdbSet = new System.WinForms.RadioButton();
		this.rdbRight = new System.WinForms.RadioButton();
		this.splitter1 = new System.WinForms.Splitter();
		this.btnDemo = new System.WinForms.Button();
		this.rdbFill = new System.WinForms.RadioButton();
		this.toolTip1 = new System.WinForms.ToolTip(components);
		this.rdbBottom = new System.WinForms.RadioButton();
		this.rdbNone = new System.WinForms.RadioButton();
		this.rdbLeft = new System.WinForms.RadioButton();
		this.chkTop = new System.WinForms.CheckBox();
		this.chkLeft = new System.WinForms.CheckBox();
		this.panel1 = new System.WinForms.Panel();
		this.chkRight = new System.WinForms.CheckBox();
		this.chkBottom = new System.WinForms.CheckBox();
		this.panel2 = new System.WinForms.Panel();
		this.rdbTop = new System.WinForms.RadioButton();
		
		//@design this.TrayHeight = 90;
		//@design this.TrayLargeIcon = false;
		//@design this.TrayAutoArrange = true;
		this.Location = new System.Drawing.Point(100, 100);
		this.Text = "Docking and Anchoring Example";
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.SizeGripStyle = System.WinForms.SizeGripStyle.Show;
		this.ClientSize = new System.Drawing.Size(448, 400);
		
		groupBox1.Location = new System.Drawing.Point(16, 16);
		groupBox1.TabIndex = 0;
		groupBox1.TabStop = false;
		groupBox1.Text = "A&nchor";
		groupBox1.Size = new System.Drawing.Size(88, 128);
		
		groupBox2.Location = new System.Drawing.Point(16, 152);
		groupBox2.TabIndex = 1;
		groupBox2.TabStop = false;
		groupBox2.Text = "&Dock";
		groupBox2.Size = new System.Drawing.Size(88, 176);
		
		rdbSet.Text = "rdbSet";
		rdbSet.Size = new System.Drawing.Size(100, 23);
		rdbSet.TabIndex = 0;
		
		rdbRight.Location = new System.Drawing.Point(8, 120);
		rdbRight.Text = "&Right";
		rdbRight.Size = new System.Drawing.Size(72, 24);
		rdbRight.TabIndex = 4;
		rdbRight.Click += new System.EventHandler(radiobutton_Click);
		
		splitter1.BackColor = System.Drawing.Color.Blue;
		splitter1.Dock = System.WinForms.DockStyle.Right;
		splitter1.Location = new System.Drawing.Point(325, 0);
		splitter1.Size = new System.Drawing.Size(3, 400);
		splitter1.TabIndex = 2;
		splitter1.TabStop = false;
		
		btnDemo.BackColor = System.Drawing.SystemColors.Control;
		toolTip1.SetToolTip(btnDemo, "Nothing happens if you click this button.");
		btnDemo.FlatStyle = System.WinForms.FlatStyle.Popup;
		btnDemo.Size = new System.Drawing.Size(120, 24);
		btnDemo.TabIndex = 0;
		btnDemo.Anchor = System.WinForms.AnchorStyles.None;
		btnDemo.Text = "Demo Button";
		
		rdbFill.Location = new System.Drawing.Point(8, 144);
		rdbFill.Text = "&Fill";
		rdbFill.Size = new System.Drawing.Size(72, 24);
		rdbFill.TabIndex = 2;
		rdbFill.Click += new System.EventHandler(radiobutton_Click);
		
		//@design toolTip1.SetLocation(new System.Drawing.Point(7, 7));
		toolTip1.Active = true;
		
		rdbBottom.Location = new System.Drawing.Point(8, 96);
		rdbBottom.Text = "&Bottom";
		rdbBottom.Size = new System.Drawing.Size(72, 24);
		rdbBottom.TabIndex = 1;
		rdbBottom.Click += new System.EventHandler(radiobutton_Click);
		
		rdbNone.Checked = true;
		rdbNone.Location = new System.Drawing.Point(8, 24);
		rdbNone.Text = "&None";
		rdbNone.Size = new System.Drawing.Size(72, 24);
		rdbNone.TabIndex = 5;
		rdbNone.TabStop = true;
		rdbNone.Click += new System.EventHandler(radiobutton_Click);
		
		rdbLeft.Location = new System.Drawing.Point(8, 72);
		rdbLeft.Text = "&Left";
		rdbLeft.Size = new System.Drawing.Size(72, 24);
		rdbLeft.TabIndex = 3;
		rdbLeft.Click += new System.EventHandler(radiobutton_Click);
		
		chkTop.Location = new System.Drawing.Point(8, 24);
		chkTop.Text = "&Top";
		chkTop.Size = new System.Drawing.Size(72, 24);
		chkTop.TabIndex = 0;
		chkTop.Click += new System.EventHandler(checkbox_Click);
		
		chkLeft.Location = new System.Drawing.Point(8, 48);
		chkLeft.Text = "&Left";
		chkLeft.Size = new System.Drawing.Size(72, 24);
		chkLeft.TabIndex = 2;
		chkLeft.Click += new System.EventHandler(checkbox_Click);
		
		panel1.Text = "ButtonPanel";
		panel1.Size = new System.Drawing.Size(325, 400);
		panel1.BorderStyle = System.WinForms.BorderStyle.Fixed3D;
		panel1.Dock = System.WinForms.DockStyle.Fill;
		panel1.TabIndex = 1;
		panel1.BackColor = System.Drawing.Color.Green;
		
		chkRight.Location = new System.Drawing.Point(8, 96);
		chkRight.Text = "&Right";
		chkRight.Size = new System.Drawing.Size(72, 24);
		chkRight.TabIndex = 1;
		chkRight.Click += new System.EventHandler(checkbox_Click);
		
		chkBottom.Location = new System.Drawing.Point(8, 72);
		chkBottom.Text = "&Bottom";
		chkBottom.Size = new System.Drawing.Size(72, 24);
		chkBottom.TabIndex = 3;
		chkBottom.Click += new System.EventHandler(checkbox_Click);
		
		panel2.Location = new System.Drawing.Point(328, 0);
		panel2.Text = "ControlsPanel";
		panel2.Size = new System.Drawing.Size(120, 400);
		panel2.BorderStyle = System.WinForms.BorderStyle.Fixed3D;
		panel2.Dock = System.WinForms.DockStyle.Right;
		toolTip1.SetToolTip(panel2, "Resize the form to see the layout effects.");
		panel2.TabIndex = 0;
		
		rdbTop.Location = new System.Drawing.Point(8, 48);
		rdbTop.Text = "&Top";
		rdbTop.Size = new System.Drawing.Size(72, 24);
		rdbTop.TabIndex = 0;
		rdbTop.Click += new System.EventHandler(radiobutton_Click);
		this.Controls.Add(panel2);
		this.Controls.Add(splitter1);
		this.Controls.Add(panel1);
		panel1.Controls.Add(btnDemo);
		panel2.Controls.Add(groupBox1);
		panel2.Controls.Add(groupBox2);
		groupBox1.Controls.Add(chkRight);
		groupBox1.Controls.Add(chkBottom);
		groupBox1.Controls.Add(chkLeft);
		groupBox1.Controls.Add(chkTop);
		groupBox2.Controls.Add(rdbBottom);
		groupBox2.Controls.Add(rdbLeft);
		groupBox2.Controls.Add(rdbNone);
		groupBox2.Controls.Add(rdbRight);
		groupBox2.Controls.Add(rdbFill);
		groupBox2.Controls.Add(rdbTop);
	}
    
        // The main entry point for the application.
        public static void Main(string[] args) {
            Application.Run(new DockMan());
        }

    }

}





