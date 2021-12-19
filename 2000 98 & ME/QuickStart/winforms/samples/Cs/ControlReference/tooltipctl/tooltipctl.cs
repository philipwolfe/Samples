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
namespace Microsoft.Samples.WinForms.Cs.ToolTipCtl {

    using System;
    using System.ComponentModel;
    using System.Core;
    using System.Drawing;
    using System.WinForms;
    using System.Diagnostics;

    public class ToolTipCtl : System.WinForms.Form {
        internal string[] toolTips = new string[] { "Open",
            "New",
            "Save",
            "Cut",
            "Copy",
            "Paste"};
        internal PictureBox[] picts = null;

        public ToolTipCtl()
            : base() {
            //
            // Required for Win Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            picts = new PictureBox[6];
            picts[0] = pictureBox1;
            picts[1] = pictureBox2;
            picts[2] = pictureBox3;
            picts[3] = pictureBox4;
            picts[4] = pictureBox5;
            picts[5] = pictureBox6;

            // Initialize all property ComboBox selections
            cmbAutomaticDelay.SelectedIndex = 1;
            cmbAutoPopDelay.SelectedIndex = 1;
            cmbInitialDelay.SelectedIndex = 1;
            cmbReshowDelay.SelectedIndex = 1;

            //BUG BUG: 31070
            imageList1.Images.Add((Bitmap)resources.GetObject("open"));
            imageList1.Images.Add((Bitmap)resources.GetObject("newbmp"));
            imageList1.Images.Add((Bitmap)resources.GetObject("save"));
            imageList1.Images.Add((Bitmap)resources.GetObject("cut"));
            imageList1.Images.Add((Bitmap)resources.GetObject("copy"));
            imageList1.Images.Add((Bitmap)resources.GetObject("paste"));



            // Set the images for the PictureBoxes
            SetImages();

            // Set the tooltips for the PictureBoxes
            SetToolTips();

        }

        private void SetImages() {
            Debug.Assert(picts.Length >= imageList1.Images.Count,
                         "Not enough PictureBoxes");

            for (int i = 0; i < imageList1.Images.Count; i++)
                picts[i].Image = imageList1.Images[i];
        }

        private void SetToolTips() {
            Debug.Assert(toolTips.Length >= picts.Length,
                         "Not enough tooltip text");

            for (int i = 0; i < picts.Length; i++)
                toolTip.SetToolTip(picts[i], toolTips[i]);
        }

        /*
         * Since rdbActivateTrue and rdbActivateFalse are in the same container in the
         * form designer, their states will be mutually exclusive.  We can use the same
         * code to handle their checkedChanged events.
         */
        private void RdbActivate_checkedChanged(object source, EventArgs e) {
            bool isTrue = rdbActivateTrue.Checked;
            toolTip.Active = isTrue;
        }

        /*
           Since rdbShowAlwaysTrue and rdbShowAlwaysFalse are in the same container in the
           form designer, their states will be mutually exclusive.  We can use the same
           code to handle their checkedChanged events.
        */
        private void RdbShowAlways_checkedChanged(object source, EventArgs e) {
            bool isTrue = rdbShowAlwaysTrue.Checked;
            toolTip.ShowAlways = isTrue;
        }

        // <doc>
        // <desc>
        //     Helper routine to retrieve the integer value of the selected item in
        //     a ComboBox object passed to it.
        // </desc>
        // </doc>
        //
        private static int GetCmbIntValue(object combo) {
            ComboBox cmb = (ComboBox)combo;
            return Int32.Parse((string)cmb.SelectedItem);
        }

        private void CmbAutomaticDelay_selectedIndexChanged(object source, EventArgs e) {
            try {
                toolTip.AutomaticDelay = GetCmbIntValue(source);
            }
            catch (FormatException) {
            }
        }

        private void CmbAutoPopDelay_selectedIndexChanged(object source, EventArgs e) {
            try {
                toolTip.AutoPopDelay = GetCmbIntValue(source);
            }
            catch (FormatException) {
            }
        }

        private void CmbInitialDelay_selectedIndexChanged(object source, EventArgs e) {
            try {
                toolTip.InitialDelay = GetCmbIntValue(source);
            }
            catch (FormatException) {
            }
        }

        private void CmbReshowDelay_selectedIndexChanged(object source, EventArgs e) {
            try {
                toolTip.ReshowDelay = GetCmbIntValue(source);
            }
            catch (FormatException) {
            }
        }

        private void BtnChange_click(object source, EventArgs e) {
            ChangeToolTips dlg = new ChangeToolTips(imageList1, toolTips);
            DialogResult res = dlg.ShowDialog();

            if (res == DialogResult.Cancel)
                return;
            else {
                toolTips = dlg.GetToolTips();
                SetToolTips();
            }
        }

        private System.ComponentModel.Container components;
        private System.WinForms.ToolTip toolTip;
        private System.WinForms.GroupBox groupBox1 ;
        private System.WinForms.RadioButton rdbActivateTrue;
        private System.WinForms.RadioButton rdbActivateFalse;
        private System.WinForms.GroupBox grpActivate;
        private System.WinForms.GroupBox grpShowAlways;
        private System.WinForms.RadioButton rdbShowAlwaysFalse;
        private System.WinForms.RadioButton rdbShowAlwaysTrue;
        private System.WinForms.Label label1;
        private System.WinForms.Label label2;
        private System.WinForms.Label label3;
        private System.WinForms.Label label4;
        private System.WinForms.ComboBox cmbAutomaticDelay;
        private System.WinForms.ComboBox cmbAutoPopDelay;
        private System.WinForms.ComboBox cmbInitialDelay;
        private System.WinForms.ComboBox cmbReshowDelay;
        private System.WinForms.Panel panel;
        private System.WinForms.ToolBarButton toolBarButton1;
        private System.WinForms.ToolBarButton toolBarButton2;
        private System.WinForms.ToolBarButton toolBarButton3;
        private System.WinForms.ToolBarButton toolBarButton4;
        private System.WinForms.ToolBarButton toolBarButton5;
        private System.WinForms.PictureBox pictureBox1;
        private System.WinForms.PictureBox pictureBox2;
        private System.WinForms.PictureBox pictureBox3;
        private System.WinForms.PictureBox pictureBox4;
        private System.WinForms.PictureBox pictureBox5;
        private System.WinForms.ImageList imageList1;
        private System.WinForms.PictureBox pictureBox6;
        private System.WinForms.ToolTip propertyTips;
        private System.WinForms.Button btnChange;
        private System.Resources.ResourceManager resources;

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor
        /// </summary>
        private void InitializeComponent() {
            resources = new System.Resources.ResourceManager("ToolTipCtl", typeof(ToolTipCtl), null, true);
            
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.WinForms.GroupBox();
            this.toolTip = new System.WinForms.ToolTip(components);
            this.rdbActivateTrue = new System.WinForms.RadioButton();
            this.panel = new System.WinForms.Panel();
            this.toolBarButton3 = new System.WinForms.ToolBarButton();
            this.cmbInitialDelay = new System.WinForms.ComboBox();
            this.propertyTips = new System.WinForms.ToolTip(components);
            this.cmbAutoPopDelay = new System.WinForms.ComboBox();
            this.toolBarButton2 = new System.WinForms.ToolBarButton();
            this.rdbShowAlwaysFalse = new System.WinForms.RadioButton();
            this.btnChange = new System.WinForms.Button();
            this.rdbShowAlwaysTrue = new System.WinForms.RadioButton();
            this.rdbActivateFalse = new System.WinForms.RadioButton();
            this.grpActivate = new System.WinForms.GroupBox();
            this.toolBarButton1 = new System.WinForms.ToolBarButton();
            this.pictureBox4 = new System.WinForms.PictureBox();
            this.label4 = new System.WinForms.Label();
            this.toolBarButton5 = new System.WinForms.ToolBarButton();
            this.pictureBox3 = new System.WinForms.PictureBox();
            this.pictureBox5 = new System.WinForms.PictureBox();
            this.imageList1 = new System.WinForms.ImageList();
            this.pictureBox2 = new System.WinForms.PictureBox();
            this.grpShowAlways = new System.WinForms.GroupBox();
            this.cmbAutomaticDelay = new System.WinForms.ComboBox();
            this.pictureBox1 = new System.WinForms.PictureBox();
            this.pictureBox6 = new System.WinForms.PictureBox();
            this.cmbReshowDelay = new System.WinForms.ComboBox();
            this.label1 = new System.WinForms.Label();
            this.toolBarButton4 = new System.WinForms.ToolBarButton();
            this.label3 = new System.WinForms.Label();
            this.label2 = new System.WinForms.Label();
            
            groupBox1.Location = new System.Drawing.Point(248, 16);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "ToolTip";
            groupBox1.Size = new System.Drawing.Size(248, 264);
            
            toolTip.Active = true;
            //@design toolTip.SetLocation(new System.Drawing.Point(20, 10));
            
            rdbActivateTrue.Location = new System.Drawing.Point(8, 16);
            rdbActivateTrue.TabIndex = 0;
            rdbActivateTrue.TabStop = true;
            rdbActivateTrue.Text = "true";
            rdbActivateTrue.Size = new System.Drawing.Size(88, 16);
            rdbActivateTrue.Checked = true;
            toolTip.SetToolTip(rdbActivateTrue, "Indicates whether the ToolTip\r\ncontrol is currently active");
            rdbActivateTrue.CheckedChanged += new EventHandler(RdbActivate_checkedChanged);
            
            this.TabIndex = 0;
            this.Text = "ToolTip";
            this.Size = new System.Drawing.Size(512, 300);
            
            panel.BorderStyle = System.WinForms.BorderStyle.Fixed3D;
            panel.Location = new System.Drawing.Point(24, 24);
            panel.TabIndex = 0;
            panel.Text = "panel1";
            panel.Size = new System.Drawing.Size(208, 40);
            
            toolBarButton3.ImageIndex = 2;
            toolBarButton3.Text = "toolBarButton3";
            
            cmbInitialDelay.ForeColor = (Color)System.Drawing.SystemColors.WindowText;
            cmbInitialDelay.Location = new System.Drawing.Point(112, 160);
            cmbInitialDelay.Style = System.WinForms.ComboBoxStyle.DropDownList;
            cmbInitialDelay.TabIndex = 7;
            cmbInitialDelay.Text = "";
            cmbInitialDelay.Size = new System.Drawing.Size(121, 21);
            toolTip.SetToolTip(cmbInitialDelay, "The period of time, in milliseconds, that the\r\nmouse pointer must remain stationary within the\r\ntooltip region before the tooltip text is displayed");
            cmbInitialDelay.SelectedIndexChanged += new EventHandler(CmbInitialDelay_selectedIndexChanged);
            cmbInitialDelay.Items.All = (object[])new object[] {"250", "500", "750", "1000", "5000"};
            
            propertyTips.Active = true;
            //@design propertyTips.SetLocation(new System.Drawing.Point(20, 70));
            
            cmbAutoPopDelay.ForeColor = (Color)System.Drawing.SystemColors.WindowText;
            cmbAutoPopDelay.Location = new System.Drawing.Point(112, 136);
            cmbAutoPopDelay.Style = System.WinForms.ComboBoxStyle.DropDownList;
            cmbAutoPopDelay.TabIndex = 4;
            cmbAutoPopDelay.Text = "";
            cmbAutoPopDelay.Size = new System.Drawing.Size(121, 21);
            toolTip.SetToolTip(cmbAutoPopDelay, "The period of time, in milliseconds, that \r\nthe tooltip remains visible when the mouse\r\npointer is stationary within the tooltip region");
            cmbAutoPopDelay.SelectedIndexChanged += new EventHandler(CmbAutoPopDelay_selectedIndexChanged);
            cmbAutoPopDelay.Items.All = (object[])new object[] {"2500", "5000", "7500", "10000"};
            
            toolBarButton2.ImageIndex = 1;
            toolBarButton2.Text = "toolBarButton2";
            
            rdbShowAlwaysFalse.Location = new System.Drawing.Point(112, 16);
            rdbShowAlwaysFalse.TabIndex = 1;
            rdbShowAlwaysFalse.TabStop = true;
            rdbShowAlwaysFalse.Text = "false";
            rdbShowAlwaysFalse.Size = new System.Drawing.Size(80, 16);
            rdbShowAlwaysFalse.Checked = true;
            toolTip.SetToolTip(rdbShowAlwaysFalse, "Indicates whether the tooltip window is \r\ndisplayed even when its parent control \r\nis not active");
            rdbShowAlwaysFalse.CheckedChanged += new EventHandler(RdbShowAlways_checkedChanged);
            
            btnChange.Location = new System.Drawing.Point(264, 240);
            btnChange.TabIndex = 1;
            btnChange.Text = "&Change ToolTips...";
            btnChange.Size = new System.Drawing.Size(104, 23);
            btnChange.Click += new EventHandler(BtnChange_click);
            
            rdbShowAlwaysTrue.Location = new System.Drawing.Point(8, 16);
            rdbShowAlwaysTrue.TabIndex = 0;
            rdbShowAlwaysTrue.Text = "true";
            rdbShowAlwaysTrue.Size = new System.Drawing.Size(88, 16);
            toolTip.SetToolTip(rdbShowAlwaysTrue, "Indicates whether the tooltip window is \r\ndisplayed even when its parent control \r\nis not active");
            rdbShowAlwaysTrue.CheckedChanged += new EventHandler(RdbShowAlways_checkedChanged);
            
            rdbActivateFalse.Location = new System.Drawing.Point(112, 16);
            rdbActivateFalse.TabIndex = 1;
            rdbActivateFalse.Text = "false";
            rdbActivateFalse.Size = new System.Drawing.Size(80, 16);
            toolTip.SetToolTip(rdbActivateFalse, "Indicates whether the ToolTip\r\ncontrol is currently active");
            rdbActivateFalse.CheckedChanged += new EventHandler(RdbActivate_checkedChanged);
            
            grpActivate.Location = new System.Drawing.Point(16, 16);
            grpActivate.TabIndex = 0;
            grpActivate.TabStop = false;
            grpActivate.Text = "Active";
            grpActivate.Size = new System.Drawing.Size(216, 40);
            
            toolBarButton1.ImageIndex = 0;
            toolBarButton1.Text = "toolBarButton1";
            
            pictureBox4.Location = new System.Drawing.Point(68, 7);
            pictureBox4.TabIndex = 2;
            pictureBox4.TabStop = false;
            pictureBox4.Text = "pictureBox1";
            pictureBox4.Size = new System.Drawing.Size(20, 20);
            
            label4.Location = new System.Drawing.Point(16, 186);
            label4.TabIndex = 8;
            label4.TabStop = false;
            label4.Text = "reshowDelay:";
            label4.Size = new System.Drawing.Size(88, 16);
            
            toolBarButton5.ImageIndex = 5;
            toolBarButton5.Text = "toolBarButton5";
            
            pictureBox3.Location = new System.Drawing.Point(48, 7);
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            pictureBox3.Text = "pictureBox1";
            pictureBox3.Size = new System.Drawing.Size(20, 20);
            
            pictureBox5.Location = new System.Drawing.Point(88, 7);
            pictureBox5.TabIndex = 1;
            pictureBox5.TabStop = false;
            pictureBox5.Text = "pictureBox1";
            pictureBox5.Size = new System.Drawing.Size(20, 20);
            
            imageList1.ImageSize = new System.Drawing.Size(16, 15);
            //BUG imageList1.ImageStream = (System.WinForms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = (Color)System.Drawing.Color.Transparent;
            //@design imageList1.SetLocation(new System.Drawing.Point(20, 40));
            
            pictureBox2.Location = new System.Drawing.Point(28, 7);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Text = "pictureBox1";
            pictureBox2.Size = new System.Drawing.Size(20, 20);
            
            grpShowAlways.Location = new System.Drawing.Point(16, 58);
            grpShowAlways.TabIndex = 1;
            grpShowAlways.TabStop = false;
            grpShowAlways.Text = "showAlways";
            grpShowAlways.Size = new System.Drawing.Size(216, 40);
            
            cmbAutomaticDelay.ForeColor = (Color)System.Drawing.SystemColors.WindowText;
            cmbAutomaticDelay.Location = new System.Drawing.Point(112, 112);
            cmbAutomaticDelay.Style = System.WinForms.ComboBoxStyle.DropDownList;
            cmbAutomaticDelay.TabIndex = 3;
            cmbAutomaticDelay.Text = "";
            cmbAutomaticDelay.Size = new System.Drawing.Size(121, 21);
            toolTip.SetToolTip(cmbAutomaticDelay, "The amount of time in milliseconds that\r\npasses before the tooltip is displayed");
            cmbAutomaticDelay.SelectedIndexChanged += new EventHandler(CmbAutomaticDelay_selectedIndexChanged);
            cmbAutomaticDelay.Items.All = (object[])new object[] {"250", "500", "750", "1000"};
            
            pictureBox1.Location = new System.Drawing.Point(8, 7);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Text = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(20, 20);
            
            pictureBox6.Location = new System.Drawing.Point(108, 7);
            pictureBox6.TabIndex = 0;
            pictureBox6.TabStop = false;
            pictureBox6.Text = "pictureBox1";
            pictureBox6.Size = new System.Drawing.Size(20, 20);
            
            cmbReshowDelay.ForeColor = (Color)System.Drawing.SystemColors.WindowText;
            cmbReshowDelay.Location = new System.Drawing.Point(112, 184);
            cmbReshowDelay.Style = System.WinForms.ComboBoxStyle.DropDownList;
            cmbReshowDelay.TabIndex = 9;
            cmbReshowDelay.Text = "";
            cmbReshowDelay.Size = new System.Drawing.Size(121, 21);
            toolTip.SetToolTip(cmbReshowDelay, "The period, in milliseconds, that must transpire\r\nbefore subsequent tooltip windows appear as the\r\nmouse pointer moves from one tooltip region to another");
            cmbReshowDelay.SelectedIndexChanged += new EventHandler(CmbReshowDelay_selectedIndexChanged);
            cmbReshowDelay.Items.All = (object[])new object[] {"50", "100", "200", "300", "500", "1000"};
            
            label1.Location = new System.Drawing.Point(16, 114);
            label1.TabIndex = 2;
            label1.TabStop = false;
            label1.Text = "automaticDelay:";
            label1.Size = new System.Drawing.Size(88, 16);
            
            toolBarButton4.ImageIndex = 3;
            toolBarButton4.Text = "toolBarButton4";
            
            label3.Location = new System.Drawing.Point(16, 162);
            label3.TabIndex = 6;
            label3.TabStop = false;
            label3.Text = "initialDelay";
            label3.Size = new System.Drawing.Size(88, 16);
            
            label2.Location = new System.Drawing.Point(16, 138);
            label2.TabIndex = 5;
            label2.TabStop = false;
            label2.Text = "autoPopDelay";
            label2.Size = new System.Drawing.Size(88, 16);
            
            grpShowAlways.Controls.Add(rdbShowAlwaysFalse);
            grpShowAlways.Controls.Add(rdbShowAlwaysTrue);
            panel.Controls.Add(pictureBox6);
            panel.Controls.Add(pictureBox5);
            panel.Controls.Add(pictureBox4);
            panel.Controls.Add(pictureBox3);
            panel.Controls.Add(pictureBox2);
            panel.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(cmbReshowDelay);
            groupBox1.Controls.Add(cmbInitialDelay);
            groupBox1.Controls.Add(cmbAutoPopDelay);
            groupBox1.Controls.Add(cmbAutomaticDelay);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(grpShowAlways);
            groupBox1.Controls.Add(grpActivate);
            this.Controls.Add(btnChange);
            this.Controls.Add(panel);
            this.Controls.Add(groupBox1);
            grpActivate.Controls.Add(rdbActivateFalse);
            grpActivate.Controls.Add(rdbActivateTrue);
            
        }

        // The main entry point for the application.
        public static void Main(string[] args) {
            Application.Run(new ToolTipCtl());
        }

    }
}

