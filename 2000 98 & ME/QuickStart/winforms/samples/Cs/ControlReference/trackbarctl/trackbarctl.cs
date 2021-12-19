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
namespace Microsoft.Samples.WinForms.Cs.TrackBarCtl {

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;

    public class TrackBarCtl : System.WinForms.Form {
        public TrackBarCtl() : base() {
            //
            // Required for Win Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            InitState();
        }

        // <doc>
        // <desc>
        //     Sets up the form so that the fields which drive the TrackBar
        //     show up with the correct initial fields.
        // </desc>
        // </doc>
        //
        private void InitState() {
            trackbar.TickFrequency = 5;
            cmbTickFreq.SelectedIndex = 2;

            trackbar.SmallChange = 5;
            cmbSmallChange.SelectedIndex = 2;

            trackbar.LargeChange = 25;
            cmbLargeChange.SelectedIndex = 1;

            trackbar.Minimum = 0;
            cmbMinimum.SelectedIndex = 0;

            trackbar.Maximum = 100;
            cmbMaximum.SelectedIndex = 0;

            trackbar.Orientation = Orientation.Horizontal;
            cmbOrientation.SelectedIndex = 0;

            trackbar.TickStyle = TickStyle.None;
            cmbTickStyle.SelectedIndex = 0;

            lblValue.Text = Single.ToString(trackbar.Value);
        }

        /// <summary>
        ///    Clean up any resources being used
        /// </summary>
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void CmbTickFreq_selectedIndexChanged(object source, EventArgs e) {
            try {
                String newVal1 = cmbTickFreq.SelectedItem.ToString();
                int newVal = newVal1.ToInt16();
                trackbar.TickFrequency = newVal;
            }
            catch (FormatException) {
            }
        }

        private void CmbLargeChange_selectedIndexChanged(object source, EventArgs e) {
            try {
                String newVal1 = cmbLargeChange.SelectedItem.ToString();
                int newVal = newVal1.ToInt16();
                trackbar.LargeChange = newVal;
            }
            catch (FormatException) {
            }
        }

        private void CmbSmallChange_selectedIndexChanged(object source, EventArgs e) {
            try {
                String newVal1 = cmbSmallChange.SelectedItem.ToString();
                int newVal = newVal1.ToInt16();
                trackbar.SmallChange = newVal;
            }
            catch (FormatException) {
            }
        }

        private void CmbMinimum_selectedIndexChanged(object source, EventArgs e) {
            try {
                String newVal1 = cmbMinimum.SelectedItem.ToString();
                int newVal = newVal1.ToInt16();
                if (newVal < trackbar.Maximum)
                    trackbar.Minimum = newVal;
            }
            catch (FormatException) {
            }
        }

        private void CmbMaximum_selectedIndexChanged(object source, EventArgs e) {
            try {
                String newVal1 = cmbMaximum.SelectedItem.ToString();
                int newVal = newVal1.ToInt16();
                if (newVal > trackbar.Minimum)
                    trackbar.Maximum = newVal;
            }
            catch (FormatException) {
            }
        }

        private void Trackbar_valueChanged(object source, EventArgs e) {
            lblValue.Text = Single.ToString(trackbar.Value);

        }

        private void CmbTickStyle_selectedIndexChanged(object source, EventArgs e) {
            ComboBox cmb = (ComboBox)source;
            string newSel = (string)cmb.SelectedItem;
            if (newSel.Equals("Both")) {
                trackbar.TickStyle = TickStyle.Both;
            }
            else if (newSel.Equals("Bottomright")) {
                trackbar.TickStyle = TickStyle.BottomRight;
            }
            else if (newSel.Equals("Topleft")) {
                trackbar.TickStyle = TickStyle.TopLeft;
            }
            else {
                trackbar.TickStyle = TickStyle.None;
            }

            if (trackbar.TickStyle == TickStyle.None)
                cmbTickFreq.Enabled = false;
            else
                cmbTickFreq.Enabled = true;
        }

        private void CmbOrientation_selectedIndexChanged(object source, EventArgs e) {
            ComboBox cmb = (ComboBox)source;
            string newSel = (string)cmb.SelectedItem;
            if (newSel.Equals("Horizontal")) {
                trackbar.Orientation = Orientation.Horizontal;
            }
            else {
                trackbar.Orientation = Orientation.Vertical;
            }
        }

        // <doc>
        // <desc>
        //     All KeyPresses that are not digits are ignored.
        //     Other non-letter keys (such as ENTER) are accepted.
        //     The edit boxes which require numerical input wire up to
        //     this handler.
        // </desc>
        // </doc>
        //
        private void NumberKeyPressFilter(object source, KeyPressEventArgs e) {
            if (Char.IsLetterOrDigit(e.KeyChar)
                && !Char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void GrpAppearance_enter(object source, EventArgs e) {

        }

        private System.ComponentModel.Container components;
        private System.WinForms.TrackBar trackbar;
        private System.WinForms.GroupBox grpAppearance;
        private System.WinForms.Label label3;
        private System.WinForms.Label label1;
        private System.WinForms.Label label8;
        private System.WinForms.Label label7;
        private System.WinForms.Label label4;
        private System.WinForms.Label label5;
        private System.WinForms.ComboBox cmbOrientation;
        private System.WinForms.ComboBox cmbTickStyle;
        private System.WinForms.ComboBox cmbTickFreq;
        private System.WinForms.Label label6;
        private System.WinForms.ComboBox cmbMaximum;
        private System.WinForms.Label lblValue;
        private System.WinForms.ComboBox cmbMinimum;
        private System.WinForms.ComboBox cmbSmallChange;
        private System.WinForms.Label label2;
        private System.WinForms.ComboBox cmbLargeChange;
        private System.WinForms.ToolTip toolTip1;

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.trackbar = new System.WinForms.TrackBar();
            this.grpAppearance = new System.WinForms.GroupBox();
            this.label3 = new System.WinForms.Label();
            this.label1 = new System.WinForms.Label();
            this.label8 = new System.WinForms.Label();
            this.label7 = new System.WinForms.Label();
            this.label4 = new System.WinForms.Label();
            this.label5 = new System.WinForms.Label();
            this.cmbOrientation = new System.WinForms.ComboBox();
            this.cmbTickStyle = new System.WinForms.ComboBox();
            this.cmbTickFreq = new System.WinForms.ComboBox();
            this.label6 = new System.WinForms.Label();
            this.cmbMaximum = new System.WinForms.ComboBox();
            this.lblValue = new System.WinForms.Label();
            this.cmbMinimum = new System.WinForms.ComboBox();
            this.cmbSmallChange = new System.WinForms.ComboBox();
            this.label2 = new System.WinForms.Label();
            this.cmbLargeChange = new System.WinForms.ComboBox();
            this.toolTip1 = new System.WinForms.ToolTip(components);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.Size = new System.Drawing.Size(512, 320);
            this.Text = "TrackBar";

            trackbar.Location = new System.Drawing.Point(8, 24);
            trackbar.Size = new System.Drawing.Size(200, 42);
            trackbar.TabIndex = 1;
            trackbar.Text = "trackBar1";
            trackbar.ValueChanged += new EventHandler(this.Trackbar_valueChanged);
            trackbar.BackColor = System.Drawing.SystemColors.Control;

            grpAppearance.Location = new System.Drawing.Point(248, 16);
            grpAppearance.Size = new System.Drawing.Size(248, 264);
            grpAppearance.TabIndex = 0;
            grpAppearance.TabStop = false;
            grpAppearance.Text = "TrackBar";
            grpAppearance.Enter += new EventHandler(this.GrpAppearance_enter);

            label3.Location = new System.Drawing.Point(16, 96);
            label3.Size = new System.Drawing.Size(88, 16);
            label3.TabIndex = 0;
            label3.TabStop = false;
            label3.Text = "largeChange:";

            label1.Location = new System.Drawing.Point(16, 24);
            label1.Size = new System.Drawing.Size(88, 17);
            label1.TabIndex = 10;
            label1.TabStop = false;
            label1.Text = "orientation:";

            label8.Location = new System.Drawing.Point(16, 192);
            label8.Size = new System.Drawing.Size(88, 16);
            label8.TabIndex = 8;
            label8.TabStop = false;
            label8.Text = "value:";

            label7.Location = new System.Drawing.Point(16, 168);
            label7.Size = new System.Drawing.Size(88, 16);
            label7.TabIndex = 6;
            label7.TabStop = false;
            label7.Text = "Maximum:";

            label4.Location = new System.Drawing.Point(16, 48);
            label4.Size = new System.Drawing.Size(88, 17);
            label4.TabIndex = 12;
            label4.TabStop = false;
            label4.Text = "tickFrequency:";

            label5.Location = new System.Drawing.Point(16, 72);
            label5.Size = new System.Drawing.Size(88, 17);
            label5.TabIndex = 14;
            label5.TabStop = false;
            label5.Text = "tickStyle:";

            cmbOrientation.Location = new System.Drawing.Point(112, 16);
            cmbOrientation.Size = new System.Drawing.Size(120, 21);
            cmbOrientation.TabIndex = 11;
            cmbOrientation.Text = "";
            cmbOrientation.Style = System.WinForms.ComboBoxStyle.DropDownList;
            cmbOrientation.Items.All = new object[] {
                "Horizontal",
                "Vertical"};
            cmbOrientation.SelectedIndexChanged += new EventHandler(this.CmbOrientation_selectedIndexChanged);

            cmbTickStyle.Location = new System.Drawing.Point(112, 64);
            cmbTickStyle.Size = new System.Drawing.Size(120, 21);
            cmbTickStyle.TabIndex = 15;
            cmbTickStyle.Text = "";
            cmbTickStyle.Style = System.WinForms.ComboBoxStyle.DropDownList;
            cmbTickStyle.Items.All = new object[] {
                "None",
                "Bottomright",
                "Topleft",
                "Both"};
            cmbTickStyle.SelectedIndexChanged += new EventHandler(this.CmbTickStyle_selectedIndexChanged);

            cmbTickFreq.Location = new System.Drawing.Point(112, 40);
            cmbTickFreq.Size = new System.Drawing.Size(120, 21);
            cmbTickFreq.TabIndex = 13;
            cmbTickFreq.Text = "";
            cmbTickFreq.Style = System.WinForms.ComboBoxStyle.DropDownList;
            cmbTickFreq.Items.All = new object[] {
                "1",
                "2",
                "5",
                "10",
                "20",
                "25",
                "50"};
            cmbTickFreq.SelectedIndexChanged += new EventHandler(this.CmbTickFreq_selectedIndexChanged);

            label6.Location = new System.Drawing.Point(16, 144);
            label6.Size = new System.Drawing.Size(88, 16);
            label6.TabIndex = 4;
            label6.TabStop = false;
            label6.Text = "minimum:";

            cmbMaximum.Location = new System.Drawing.Point(112, 160);
            cmbMaximum.Size = new System.Drawing.Size(121, 21);
            cmbMaximum.TabIndex = 7;
            cmbMaximum.Text = "";
            cmbMaximum.Style = System.WinForms.ComboBoxStyle.DropDownList;
            cmbMaximum.Items.All = new object[] {
                "100",
                "150",
                "200"};
            cmbMaximum.SelectedIndexChanged += new EventHandler(this.CmbMaximum_selectedIndexChanged);

            lblValue.Location = new System.Drawing.Point(112, 192);
            lblValue.Size = new System.Drawing.Size(120, 16);
            lblValue.TabIndex = 9;
            lblValue.TabStop = false;
            lblValue.Text = "";
            lblValue.BorderStyle = System.WinForms.BorderStyle.Fixed3D;

            cmbMinimum.Location = new System.Drawing.Point(112, 136);
            cmbMinimum.Size = new System.Drawing.Size(121, 21);
            cmbMinimum.TabIndex = 5;
            cmbMinimum.Text = "";
            cmbMinimum.Style = System.WinForms.ComboBoxStyle.DropDownList; 
            cmbMinimum.Items.All = new object[] {
                "0",
                "25",
                "50"};
            cmbMinimum.SelectedIndexChanged += new EventHandler(this.CmbMinimum_selectedIndexChanged);
            cmbSmallChange.Location = new System.Drawing.Point(112, 112);
            cmbSmallChange.Size = new System.Drawing.Size(121, 21);
            cmbSmallChange.TabIndex = 3;
            cmbSmallChange.Text = "";
            cmbSmallChange.Style = System.WinForms.ComboBoxStyle.DropDownList;
            cmbSmallChange.Items.All = new object[] {
                "1",
                "2",
                "5",
                "10"};
            cmbSmallChange.SelectedIndexChanged += new EventHandler(this.CmbSmallChange_selectedIndexChanged);

            label2.Location = new System.Drawing.Point(16, 120);
            label2.Size = new System.Drawing.Size(88, 16);
            label2.TabIndex = 2;
            label2.TabStop = false;
            label2.Text = "smallChange:";

            cmbLargeChange.Location = new System.Drawing.Point(112, 88);
            cmbLargeChange.Size = new System.Drawing.Size(121, 21);
            cmbLargeChange.TabIndex = 1;
            cmbLargeChange.Text = "";
            cmbLargeChange.Style = System.WinForms.ComboBoxStyle.DropDownList;
            cmbLargeChange.Items.All = new object[] {
                "10",
                "20",
                "50"};
            cmbLargeChange.SelectedIndexChanged += new EventHandler(this.CmbLargeChange_selectedIndexChanged);

            toolTip1.Active = true;
            toolTip1.SetToolTip(cmbTickStyle, "The location of the tick marks.");
            toolTip1.SetToolTip(cmbTickFreq, "The number of units betwen tick marks");
            /* @designTimeOnly toolTip1.setLocation(new System.Drawing.Point(48, 152)); */

            this.Controls.Add(grpAppearance);
            this.Controls.Add(trackbar);
            grpAppearance.Controls.Add(lblValue);
            grpAppearance.Controls.Add(label8); 
            grpAppearance.Controls.Add(cmbMaximum);
            grpAppearance.Controls.Add(label7);
            grpAppearance.Controls.Add(cmbMinimum);
            grpAppearance.Controls.Add(label6);
            grpAppearance.Controls.Add(cmbSmallChange);
            grpAppearance.Controls.Add(label2);
            grpAppearance.Controls.Add(cmbLargeChange);
            grpAppearance.Controls.Add(label3);
            grpAppearance.Controls.Add(cmbTickFreq);
            grpAppearance.Controls.Add(cmbTickStyle);
            grpAppearance.Controls.Add(cmbOrientation);
            grpAppearance.Controls.Add(label5);
            grpAppearance.Controls.Add(label1);
            grpAppearance.Controls.Add(label4);
        }

        // The main entry point for the application.
        public static void Main(string[] args) {
            Application.Run(new TrackBarCtl());
        }
    }
}
