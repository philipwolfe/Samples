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
namespace DateTimePickerCtl {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;

    // <doc>
    // <desc>
    //     This form is used to customise the DateTime picker 
    //     It demonstrates how to use the common color dialog
    // </desc>
    // </doc>
    //
    public class ChangeColorDlg : System.WinForms.Form {
        private DateTimePicker dtp;

        // <doc>
        // <desc>
        //     Public Constructor
        // </desc>
        // </doc>
        //
        public ChangeColorDlg(DateTimePickerCtl parent) : base() {
            
            // This call is required for support of the Windows Forms Form Designer.
            InitializeComponent();

            dtp = parent.DTPicker;

            SynchronizePanelColors();
        }

        // <doc>
        // <desc>
        //     Make sure that the color display panels are displaying the 
        //     Color used by the date time picker
        // </desc>
        // </doc>
        //
        private void SynchronizePanelColors() {
            pnlForeColor.BackColor = dtp.CalendarForeColor;
            pnlMonthBackground.BackColor = dtp.CalendarMonthBackground;
            pnlTitleBackColor.BackColor = dtp.CalendarTitleBackColor;
            pnlTitleForeColor.BackColor = dtp.CalendarTitleForeColor;
            pnlTrailingForeColor.BackColor = dtp.CalendarTrailingForeColor;
        }

        // <doc>
        // <desc>
        //     ChangeColorDlg overrides dispose so it can clean up the
        //     component list.
        // </desc>
        // </doc>
        //
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        protected void btnForeColor_Click(object sender, EventArgs e) {
            colorDialog1.Color = dtp.CalendarForeColor;
            DialogResult res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK) {
                dtp.CalendarForeColor = colorDialog1.Color;
                SynchronizePanelColors();
            }
        }

        protected void btnMonthBackground_Click(object sender, EventArgs e) {
            colorDialog1.Color = dtp.CalendarMonthBackground;
            DialogResult res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK) {
                dtp.CalendarMonthBackground = colorDialog1.Color;
                SynchronizePanelColors();
            }
        }

        protected void btnTitleBackColor_Click(object sender, EventArgs e) {
            colorDialog1.Color = dtp.CalendarTitleBackColor;
            DialogResult res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK) {
                dtp.CalendarTitleBackColor = colorDialog1.Color;
                SynchronizePanelColors();
            }
        }

        protected void btnTitleForeColor_Click(object sender, EventArgs e) {
            colorDialog1.Color = dtp.CalendarTitleForeColor;
            DialogResult res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK) {
                dtp.CalendarTitleForeColor = colorDialog1.Color;
                SynchronizePanelColors();
            }
        }

        protected void btnTrailingForeColor_Click(object sender, EventArgs e) {
            colorDialog1.Color = dtp.CalendarTrailingForeColor;
            DialogResult res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK) {
                dtp.CalendarTrailingForeColor = colorDialog1.Color;
                SynchronizePanelColors();
            }
        }

        // NOTE: The following code is required by the Windows Forms Form Designer
        // It can be modified using the Windows Forms Form Designer.  
        // Do not modify it using the code editor.
        private System.ComponentModel.Container components;
    private System.WinForms.ColorDialog colorDialog1;
        private System.WinForms.Label label1;
        private System.WinForms.Label label2;
        private System.WinForms.Label label3;
        private System.WinForms.Label label4;
        private System.WinForms.Label label5;
        private System.WinForms.Button btnOK;
        private System.WinForms.Panel pnlForeColor;
        private System.WinForms.Panel pnlMonthBackground;
        private System.WinForms.Panel pnlTitleBackColor;
        private System.WinForms.Panel pnlTitleForeColor;
        private System.WinForms.Panel pnlTrailingForeColor;
        private System.WinForms.Button btnForeColor;
        private System.WinForms.Button btnMonthBackground;
        private System.WinForms.Button btnTitleBackColor;
        private System.WinForms.Button btnTitleForeColor;
        private System.WinForms.Button btnTrailingForeColor;
        //private System.WinForms.ColorDialog colorDialog;

        private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.btnTrailingForeColor = new System.WinForms.Button();
		this.btnOK = new System.WinForms.Button();
		this.pnlMonthBackground = new System.WinForms.Panel();
		this.btnTitleBackColor = new System.WinForms.Button();
		this.pnlForeColor = new System.WinForms.Panel();
		this.pnlTitleForeColor = new System.WinForms.Panel();
		this.btnMonthBackground = new System.WinForms.Button();
		this.pnlTitleBackColor = new System.WinForms.Panel();
		this.btnTitleForeColor = new System.WinForms.Button();
		this.label5 = new System.WinForms.Label();
		this.btnForeColor = new System.WinForms.Button();
		this.pnlTrailingForeColor = new System.WinForms.Panel();
		this.label4 = new System.WinForms.Label();
		this.colorDialog1 = new System.WinForms.ColorDialog();
		this.label2 = new System.WinForms.Label();
		this.label3 = new System.WinForms.Label();
		this.label1 = new System.WinForms.Label();
		
		//@design this.TrayHeight = 90;
		//@design this.TrayLargeIcon = false;
		//@design this.TrayAutoArrange = true;
		this.Text = "Change Color";
		this.MaximizeBox = false;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BorderStyle = System.WinForms.FormBorderStyle.FixedDialog;
		this.MinimizeBox = false;
		this.ClientSize = new System.Drawing.Size(406, 194);
		
		btnTrailingForeColor.Location = new System.Drawing.Point(232, 112);
		btnTrailingForeColor.Size = new System.Drawing.Size(75, 23);
		btnTrailingForeColor.TabIndex = 12;
		btnTrailingForeColor.Text = "Change";
		btnTrailingForeColor.Click += new System.EventHandler(btnTrailingForeColor_Click);
		
		btnOK.Location = new System.Drawing.Point(320, 160);
		btnOK.DialogResult = System.WinForms.DialogResult.OK;
		btnOK.Size = new System.Drawing.Size(75, 23);
		btnOK.TabIndex = 9;
		btnOK.Text = "&OK";
		
		pnlMonthBackground.BorderStyle = System.WinForms.BorderStyle.Fixed3D;
		pnlMonthBackground.Location = new System.Drawing.Point(160, 43);
		pnlMonthBackground.Size = new System.Drawing.Size(48, 16);
		pnlMonthBackground.TabIndex = 3;
		pnlMonthBackground.Text = "panel1";
		
		btnTitleBackColor.Location = new System.Drawing.Point(232, 64);
		btnTitleBackColor.Size = new System.Drawing.Size(75, 23);
		btnTitleBackColor.TabIndex = 14;
		btnTitleBackColor.Text = "Change";
		btnTitleBackColor.Click += new System.EventHandler(btnTitleBackColor_Click);
		
		pnlForeColor.BorderStyle = System.WinForms.BorderStyle.Fixed3D;
		pnlForeColor.Location = new System.Drawing.Point(160, 19);
		pnlForeColor.Size = new System.Drawing.Size(48, 16);
		pnlForeColor.TabIndex = 10;
		pnlForeColor.Text = "panel1";
		
		pnlTitleForeColor.BorderStyle = System.WinForms.BorderStyle.Fixed3D;
		pnlTitleForeColor.Location = new System.Drawing.Point(160, 91);
		pnlTitleForeColor.Size = new System.Drawing.Size(48, 16);
		pnlTitleForeColor.TabIndex = 1;
		pnlTitleForeColor.Text = "panel1";
		
		btnMonthBackground.Location = new System.Drawing.Point(232, 40);
		btnMonthBackground.Size = new System.Drawing.Size(75, 23);
		btnMonthBackground.TabIndex = 15;
		btnMonthBackground.Text = "Change";
		btnMonthBackground.Click += new System.EventHandler(btnMonthBackground_Click);
		
		pnlTitleBackColor.BorderStyle = System.WinForms.BorderStyle.Fixed3D;
		pnlTitleBackColor.Location = new System.Drawing.Point(160, 67);
		pnlTitleBackColor.Size = new System.Drawing.Size(48, 16);
		pnlTitleBackColor.TabIndex = 2;
		pnlTitleBackColor.Text = "panel1";
		
		btnTitleForeColor.Location = new System.Drawing.Point(232, 88);
		btnTitleForeColor.Size = new System.Drawing.Size(75, 23);
		btnTitleForeColor.TabIndex = 13;
		btnTitleForeColor.Text = "Change";
		btnTitleForeColor.Click += new System.EventHandler(btnTitleForeColor_Click);
		
		label5.Location = new System.Drawing.Point(16, 115);
		label5.Text = "CalendarTrailingForeColor:";
		label5.Size = new System.Drawing.Size(136, 16);
		label5.TabIndex = 4;
		
		btnForeColor.Location = new System.Drawing.Point(232, 16);
		btnForeColor.Size = new System.Drawing.Size(75, 23);
		btnForeColor.TabIndex = 11;
		btnForeColor.Text = "Change";
		btnForeColor.Click += new System.EventHandler(btnForeColor_Click);
		
		pnlTrailingForeColor.BorderStyle = System.WinForms.BorderStyle.Fixed3D;
		pnlTrailingForeColor.Location = new System.Drawing.Point(160, 115);
		pnlTrailingForeColor.Size = new System.Drawing.Size(48, 16);
		pnlTrailingForeColor.TabIndex = 0;
		pnlTrailingForeColor.Text = "panel1";
		
		label4.Location = new System.Drawing.Point(16, 91);
		label4.Text = "CalendarTitleForeColor:";
		label4.Size = new System.Drawing.Size(136, 16);
		label4.TabIndex = 5;
		
		//@design colorDialog1.SetLocation(new System.Drawing.Point(7, 7));
		
		label2.Location = new System.Drawing.Point(16, 43);
		label2.Text = "CalendarMonthBackground:";
		label2.Size = new System.Drawing.Size(144, 16);
		label2.TabIndex = 7;
		
		label3.Location = new System.Drawing.Point(16, 67);
		label3.Text = "CalendarTitleBackColor:";
		label3.Size = new System.Drawing.Size(136, 16);
		label3.TabIndex = 6;
		
		label1.Location = new System.Drawing.Point(16, 19);
		label1.Text = "CalendarForeColor:";
		label1.Size = new System.Drawing.Size(136, 16);
		label1.TabIndex = 8;
		this.Controls.Add(btnTrailingForeColor);
		this.Controls.Add(btnTitleForeColor);
		this.Controls.Add(btnTitleBackColor);
		this.Controls.Add(btnMonthBackground);
		this.Controls.Add(btnForeColor);
		this.Controls.Add(pnlTrailingForeColor);
		this.Controls.Add(pnlTitleForeColor);
		this.Controls.Add(pnlTitleBackColor);
		this.Controls.Add(pnlMonthBackground);
		this.Controls.Add(pnlForeColor);
		this.Controls.Add(btnOK);
		this.Controls.Add(label5);
		this.Controls.Add(label4);
		this.Controls.Add(label3);
		this.Controls.Add(label2);
		this.Controls.Add(label1);
	}              
    }
}
