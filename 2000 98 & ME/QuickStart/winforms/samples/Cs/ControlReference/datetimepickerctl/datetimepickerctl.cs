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
    //     This sample control demonstrates various properties and
    //     methods for the DateTimePicker control.  Users should
    //     play with the various controls and then look at the code
    //     behind the behaviors that are most interesting.
    // </desc>
    // </doc>
    //
    public class DateTimePickerCtl : System.WinForms.Form {

        private System.ComponentModel.Container components;
        private System.WinForms.GroupBox groupBox1;
        private System.WinForms.Label label1;
        private System.WinForms.Label label2;
        private System.WinForms.Label label4;
        private System.WinForms.DateTimePicker dateTimePicker;
        private System.WinForms.DateTimePicker dtpMinDate;
        private System.WinForms.DateTimePicker dtpMaxDate;
        private System.WinForms.CheckBox chkShowUpDown;
        private System.WinForms.ComboBox cmbFormat;
        private System.WinForms.Button btnChangeFont;
        private System.WinForms.Button btnChangeColor;
        private System.WinForms.FontDialog fontDialog;
        private System.WinForms.ToolTip toolTip1;
        private System.WinForms.ErrorProvider errorMax;
        private System.WinForms.ErrorProvider errorMin;

        // <doc>
        // <desc>
        //     Public Constructor
        // </desc>
        // </doc>
        //
        public DateTimePickerCtl() : base() {
             	
            // This call is required for support of the Windows Forms Form Designer.
            InitializeComponent();

            // Make sure that we are starting in Long date format
            dateTimePicker.Format = DateTimePickerFormats.Long;
            cmbFormat.SelectedIndex = 0;

            // Initialize the control values
            DateTime now = DateTime.Now;
            dateTimePicker.Value = now;
            dtpMaxDate.Value = now.AddDays(30);
            dtpMinDate.Value = now.AddDays(-30);
            dateTimePicker.MaxDate = dtpMaxDate.Value;
            dateTimePicker.MinDate = dtpMinDate.Value;

            //Set the minimum form size to the client size + the height of the title bar
            this.MinTrackSize = new Size(504, (293 + SystemInformation.CaptionHeight));
        }


        // <doc>
        // <desc>
        //     DateTimePickerCtl overrides dispose so it can clean up the
        //     component list.
        // </desc>
        // </doc>
        //
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        // <doc>
        // <desc>
        //     Return the DateTimePicker control - used by the 
        //     ChangeColorDlg
        // </desc>
        // </doc>
        //
        internal DateTimePicker DTPicker {
            get {
                return dateTimePicker;
            }
        }

        protected void btnChangeFont_Click(object sender, EventArgs e) {
            fontDialog.ShowDialog();
            Font newFont = fontDialog.Font;
            dateTimePicker.Font = newFont;
        }

        protected void btnChangeColor_Click(object sender, EventArgs e) {
            ChangeColorDlg dlg = new ChangeColorDlg(this);
            dlg.ShowDialog();
        }

        protected void dtpMinDate_ValueChanged(object sender, EventArgs e) {
            
            if (dtpMinDate.Value < dtpMaxDate.Value) {
                errorMin.SetError(dtpMinDate,"");
                dateTimePicker.MinDate = dtpMinDate.Value;
                }
            else {
                dtpMinDate.Value = dateTimePicker.MinDate;
                errorMin.SetError(dtpMinDate,"Max Date must be greater than Min Date");
                }
        }

        protected void dtpMaxDate_ValueChanged(object sender, EventArgs e) {
            if (dtpMaxDate.Value > dtpMinDate.Value) {
                dateTimePicker.MaxDate = dtpMaxDate.Value;
                errorMax.SetError(dtpMaxDate,"");
                }
            else {
                dtpMaxDate.Value = dateTimePicker.MaxDate;
                errorMax.SetError(dtpMaxDate,"Max Date must be greater than Min Date"); 
                }
               
        }
                               
        protected void cmbFormat_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbFormat.SelectedIndex < 0)
                return;

            char firstChar = cmbFormat.SelectedItem.ToString()[0];
            DateTimePickerFormats format;
            switch (firstChar) {
                case 'S':
                    format = DateTimePickerFormats.Short;
                    break;
                case 'T':
                    format = DateTimePickerFormats.Time;
                    break;
                case 'C':
                    format = DateTimePickerFormats.Custom;
                    break;
                default:
                    format = DateTimePickerFormats.Long;
                    break;
            }
            dateTimePicker.Format = format;
        }

        protected void chkShowUpDown_Click(object sender, EventArgs e) {
            bool showUpDown = chkShowUpDown.Checked;
            this.dateTimePicker.ShowUpDown = showUpDown;
        }

        // NOTE: The following code is required by the Windows Forms Form Designer
        // It can be modified using the Windows Forms Form Designer.  
        // Do not modify it using the code editor.
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.WinForms.Label();
            this.errorMin = new System.WinForms.ErrorProvider();
            this.cmbFormat = new System.WinForms.ComboBox();
            this.dtpMinDate = new System.WinForms.DateTimePicker();
            this.label2 = new System.WinForms.Label();
            this.groupBox1 = new System.WinForms.GroupBox();
            this.label1 = new System.WinForms.Label();
            this.fontDialog = new System.WinForms.FontDialog();
            this.toolTip1 = new System.WinForms.ToolTip(components);
            this.btnChangeFont = new System.WinForms.Button();
            this.dateTimePicker = new System.WinForms.DateTimePicker();
            this.btnChangeColor = new System.WinForms.Button();
            this.errorMax = new System.WinForms.ErrorProvider();
            this.dtpMaxDate = new System.WinForms.DateTimePicker();
            this.chkShowUpDown = new System.WinForms.CheckBox();

            //@design this.TrayHeight = 58;
            //@design this.TrayLargeIcon = false;
            this.Text = "DateTimePicker";
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(504, 293);

            label4.Location = new System.Drawing.Point(16, 80);
            label4.Text = "Format:";
            label4.Size = new System.Drawing.Size(64, 16);
            label4.TabIndex = 0;

            //@design errorMin.SetLocation(new System.Drawing.Point(259, 7));
            errorMin.DataMember = "";
            errorMin.DataSource = null;
            errorMin.ContainerControl = null;

            cmbFormat.Location = new System.Drawing.Point(128, 72);
            cmbFormat.Size = new System.Drawing.Size(104, 21);
            cmbFormat.Style = System.WinForms.ComboBoxStyle.DropDownList;
            toolTip1.SetToolTip(cmbFormat, "A value indicating the whether the control displays date and" + 
            	" time\r\ninformation in long date Format(for example, \"Wedn" + 
            	"esday, April 7, 1999\"),\r\nshort date Format(for example, " + 
            	"\"4/7/99\"), time Format(for example,\r\n\"5:31:34 PM\"), or" + 
            	" custom format.");
            cmbFormat.TabIndex = 7;
            cmbFormat.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
            cmbFormat.Items.All = new object[] {"Long",
            	"Short",
            	"Time",
            	"Custom"};
            cmbFormat.SelectedIndexChanged += new EventHandler(cmbFormat_SelectedIndexChanged);

            dtpMinDate.Location = new System.Drawing.Point(128, 24);
            //dtpMinDate.CalendarFont = new System.Drawing.Font("Times New Roman", 8f);
            dtpMinDate.Size = new System.Drawing.Size(104, 20);
            dtpMinDate.CalendarForeColor = System.Drawing.SystemColors.WindowText;
            dtpMinDate.ValueSet = true;
            dtpMinDate.ForeColor = System.Drawing.SystemColors.WindowText;
            dtpMinDate.Format = System.WinForms.DateTimePickerFormats.Short;
            toolTip1.SetToolTip(dtpMinDate, "The value indicating the first date that\r\nthe control allows the user to select");
            dtpMinDate.TabIndex = 6;
            dtpMinDate.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
            dtpMinDate.BackColor = System.Drawing.SystemColors.Window;
            dtpMinDate.ValueChanged += new EventHandler(dtpMinDate_ValueChanged);

            label2.Location = new System.Drawing.Point(16, 56);
            label2.Text = "MaxDate:";
            label2.Size = new System.Drawing.Size(96, 16);
            label2.TabIndex = 1;

            groupBox1.Location = new System.Drawing.Point(248, 16);
            groupBox1.IMEMode = System.WinForms.IMEMode.Disable;
            groupBox1.TabIndex = 0;
            groupBox1.Anchor = System.WinForms.AnchorStyles.TopBottomRight;
            groupBox1.TabStop = false;
            groupBox1.Text = "DateTimePicker";
            groupBox1.Size = new System.Drawing.Size(248, 264);

            label1.Location = new System.Drawing.Point(16, 32);
            label1.Text = "MinDate:";
            label1.Size = new System.Drawing.Size(80, 16);
            label1.TabIndex = 3;

            //@design fontDialog.SetLocation(new System.Drawing.Point(7, 7));

            //@design toolTip1.SetLocation(new System.Drawing.Point(180, 7));
            toolTip1.Active = true;

            btnChangeFont.FlatStyle = System.WinForms.FlatStyle.Flat;
            btnChangeFont.Location = new System.Drawing.Point(16, 216);
            btnChangeFont.Text = "Change &Font";
            btnChangeFont.Size = new System.Drawing.Size(104, 32);
            btnChangeFont.TabIndex = 5;
            btnChangeFont.Anchor = System.WinForms.AnchorStyles.BottomRight;
            btnChangeFont.Click += new System.EventHandler(btnChangeFont_Click);

            dateTimePicker.Location = new System.Drawing.Point(24, 24);
            dateTimePicker.CalendarFont = new System.Drawing.Font("Times New Roman", 8f);
            dateTimePicker.Size = new System.Drawing.Size(200, 20);
            dateTimePicker.CalendarForeColor = System.Drawing.SystemColors.WindowText;
            dateTimePicker.ValueSet = true;
            dateTimePicker.ForeColor = System.Drawing.SystemColors.WindowText;
            dateTimePicker.Format = System.WinForms.DateTimePickerFormats.Custom;
            dateTimePicker.TabIndex = 1;
            dateTimePicker.BackColor = System.Drawing.SystemColors.Window;
            dateTimePicker.CustomFormat = "\'The date is: \'yy MM d - HH\':\'mm\':\'s ddd";
            dateTimePicker.Anchor = System.WinForms.AnchorStyles.All;

            btnChangeColor.FlatStyle = System.WinForms.FlatStyle.Flat;
            btnChangeColor.Location = new System.Drawing.Point(128, 216);
            btnChangeColor.Text = "Change &Color";
            btnChangeColor.Size = new System.Drawing.Size(104, 32);
            btnChangeColor.TabIndex = 2;
            btnChangeColor.Anchor = System.WinForms.AnchorStyles.BottomRight;
            btnChangeColor.Click += new System.EventHandler(btnChangeColor_Click);

            //@design errorMax.SetLocation(new System.Drawing.Point(97, 7));
            errorMax.DataMember = "";
            errorMax.DataSource = null;
            errorMax.ContainerControl = null;

            dtpMaxDate.Location = new System.Drawing.Point(128, 48);
            dtpMaxDate.CalendarFont = new System.Drawing.Font("Times New Roman", 8f);
            dtpMaxDate.Size = new System.Drawing.Size(104, 20);
            dtpMaxDate.CalendarForeColor = System.Drawing.SystemColors.WindowText;
            dtpMaxDate.ValueSet = true;
            dtpMaxDate.ForeColor = System.Drawing.SystemColors.WindowText;
            dtpMaxDate.Format = System.WinForms.DateTimePickerFormats.Short;
            toolTip1.SetToolTip(dtpMaxDate, "The value indicating the last date that \r\nthe control allo" + 
            	"ws the user to select");
            dtpMaxDate.TabIndex = 4;
            dtpMaxDate.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
            dtpMaxDate.BackColor = System.Drawing.SystemColors.Window;
            dtpMaxDate.ValueChanged += new EventHandler(dtpMaxDate_ValueChanged);

            chkShowUpDown.Location = new System.Drawing.Point(16, 104);
            chkShowUpDown.Text = "ShowUpDown:";
            chkShowUpDown.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkShowUpDown.Size = new System.Drawing.Size(100, 23);
            chkShowUpDown.AccessibleRole = System.WinForms.AccessibleRoles.CheckButton;
            chkShowUpDown.TabIndex = 8;
            chkShowUpDown.Click += new EventHandler(chkShowUpDown_Click);

            groupBox1.Controls.Add(chkShowUpDown);
            groupBox1.Controls.Add(btnChangeFont);
            groupBox1.Controls.Add(btnChangeColor);
            groupBox1.Controls.Add(dtpMaxDate);
            groupBox1.Controls.Add(dtpMinDate);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbFormat);
            this.Controls.Add(dateTimePicker);
            this.Controls.Add(groupBox1);
        }

        // The main entry point for the application.
        public static void Main(string[] args) {
            Application.Run(new DateTimePickerCtl());
        }


    }

}




