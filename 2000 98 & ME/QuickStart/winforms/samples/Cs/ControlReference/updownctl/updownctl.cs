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
namespace Microsoft.Samples.WinForms.Cs.UpDownCtl {

    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;

    // <doc>
    // <desc>
    //     This sample demonstrates how to use NumericUpDown and DomainUpDown controls
    // </desc>
    // </doc>
    //
    public class UpDownCtl : System.WinForms.Form {

        public UpDownCtl() : base() {
            
            InitializeComponent();

            //Complete intialization of the Form
            this.updnTextAlign.Items.Add(new StringIntObject("Center",(int)HorizontalAlignment.Center));
            this.updnTextAlign.Items.Add(new StringIntObject("Left",(int)HorizontalAlignment.Left));
            this.updnTextAlign.Items.Add(new StringIntObject("Right",(int)HorizontalAlignment.Right));
            this.updnTextAlign.SelectedIndex = 1;
            
            this.updnUpDownAlignment.Items.Add(new StringIntObject("Left",(int)LeftRightAlignment.Left));
            this.updnUpDownAlignment.Items.Add(new StringIntObject("Right",(int)LeftRightAlignment.Right));
            this.updnUpDownAlignment.SelectedIndex = 1;
            
            this.domainUpDown1.Items.Add("King Kong");
            this.domainUpDown1.Items.Add("The Creature from the Black Lagoon");
            this.domainUpDown1.Items.Add("Dracula");
            this.domainUpDown1.Items.Add("Frankenstein's Monster");
            this.domainUpDown1.Items.Add("Godzilla");
            this.domainUpDown1.SelectedIndex = 0;

            this.updnDecimalPlaces.DecimalPlaces = 0;
        }

        // <doc>
        // <desc>
        //     UpDownCtl overrides dispose so it can clean up the
        //     component list.
        // </desc>
        // </doc>
        //
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void updnUpDownAlignment_SelectedItemChanged(object sender, EventArgs e) {
            StringIntObject sio = (StringIntObject)(updnUpDownAlignment.Items[updnUpDownAlignment.SelectedIndex]) ;
            numericUpDown1.UpDownAlign = (LeftRightAlignment)(sio.i);
            domainUpDown1.UpDownAlign = (LeftRightAlignment)(sio.i);
        }

        private void updnTextAlign_SelectedItemChanged(object sender, EventArgs e) {
            StringIntObject sio = (StringIntObject)(updnTextAlign.Items[updnTextAlign.SelectedIndex]) ;
            numericUpDown1.TextAlign = (HorizontalAlignment)(sio.i);
            domainUpDown1.TextAlign = (HorizontalAlignment)(sio.i);
        }

        private void chkInterceptArrowKeys_CheckedChanged(object sender, EventArgs e) {
            numericUpDown1.InterceptArrowKeys = chkInterceptArrowKeys.Checked;
            domainUpDown1.InterceptArrowKeys = chkInterceptArrowKeys.Checked;
        }

        private void chkSorted_CheckedChanged(object sender, EventArgs e) {
            domainUpDown1.Sorted = chkSorted.Checked;
        }

        private void chkWrap_CheckedChanged(object sender, EventArgs e) {
            domainUpDown1.Wrap = chkWrap.Checked;
        }

        private void updnIncrement_ValueChanged(object sender, EventArgs e) {
           numericUpDown1.Increment = updnIncrement.Value;
        }

        private void updnDecimalPlaces_ValueChanged(object sender, EventArgs e) {
            numericUpDown1.DecimalPlaces = (int)updnDecimalPlaces.Value;
            updnIncrement.Value = (int)updnIncrement.Value ; // Just so we don't increment by amounts we can't see.
            updnIncrement.DecimalPlaces = (int)updnDecimalPlaces.Value;
        }

        private System.ComponentModel.Container components;
        private System.WinForms.DomainUpDown updnUpDownAlignment; 
        private System.WinForms.DomainUpDown updnTextAlign;
        private System.WinForms.Label lblIncrement;
        private System.WinForms.NumericUpDown updnIncrement;
        private System.WinForms.Label lblDecimalPlaces;
        private System.WinForms.NumericUpDown updnDecimalPlaces;
        private System.WinForms.CheckBox chkSorted;
        private System.WinForms.Label lblUpDownAlignment;
        private System.WinForms.Label lblTextAlign;

        private System.WinForms.CheckBox chkInterceptArrowKeys;
        private System.WinForms.CheckBox chkWrap;
        private System.WinForms.GroupBox grpCommonProperties;
        private System.WinForms.NumericUpDown numericUpDown1;
        private System.WinForms.DomainUpDown domainUpDown1;
        private System.WinForms.GroupBox grpDomainUpDown;
        private System.WinForms.GroupBox grpNumericUpDown;

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.grpDomainUpDown = new System.WinForms.GroupBox();
            this.updnDecimalPlaces = new System.WinForms.NumericUpDown();
            this.chkWrap = new System.WinForms.CheckBox();
            this.grpNumericUpDown = new System.WinForms.GroupBox();
            this.chkSorted = new System.WinForms.CheckBox();
            this.lblUpDownAlignment = new System.WinForms.Label();
            this.lblIncrement = new System.WinForms.Label();
            this.chkInterceptArrowKeys = new System.WinForms.CheckBox();
            this.grpCommonProperties = new System.WinForms.GroupBox();
            this.lblTextAlign = new System.WinForms.Label();
            this.domainUpDown1 = new System.WinForms.DomainUpDown();
            this.updnTextAlign = new System.WinForms.DomainUpDown();
            this.updnIncrement = new System.WinForms.NumericUpDown();
            this.lblDecimalPlaces = new System.WinForms.Label();
            this.updnUpDownAlignment = new System.WinForms.DomainUpDown();
            this.numericUpDown1 = new System.WinForms.NumericUpDown();

            grpDomainUpDown.Location = new System.Drawing.Point(280, 24);
            grpDomainUpDown.TabIndex = 1;
            grpDomainUpDown.TabStop = false;
            grpDomainUpDown.Text = "DomainUpDown";
            grpDomainUpDown.Size = new System.Drawing.Size(208, 176);

            updnDecimalPlaces.Location = new System.Drawing.Point(152, 80);
            updnDecimalPlaces.Maximum = new System.Decimal(10d);
            updnDecimalPlaces.Minimum = new System.Decimal(0d);
            updnDecimalPlaces.DecimalPlaces = 0;
            updnDecimalPlaces.TabIndex = 1;
            updnDecimalPlaces.Text = "2";
            updnDecimalPlaces.Size = new System.Drawing.Size(56, 23);
            updnDecimalPlaces.ValueChanged += new EventHandler(this.updnDecimalPlaces_ValueChanged);

            chkWrap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkWrap.Location = new System.Drawing.Point(32, 80);
            chkWrap.TabIndex = 1;
            chkWrap.Text = "Wrap";
            chkWrap.Size = new System.Drawing.Size(104, 24);
            chkWrap.CheckedChanged += new EventHandler(this.chkWrap_CheckedChanged);

            grpNumericUpDown.Location = new System.Drawing.Point(16, 24);
            grpNumericUpDown.TabIndex = 0;
            grpNumericUpDown.TabStop = false;
            grpNumericUpDown.Text = "NumericUpDown";
            grpNumericUpDown.Size = new System.Drawing.Size(232, 176);

            chkSorted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkSorted.Location = new System.Drawing.Point(32, 120);
            chkSorted.TabIndex = 2;
            chkSorted.Text = "Sorted";
            chkSorted.Size = new System.Drawing.Size(104, 24);
            chkSorted.CheckedChanged += new EventHandler(this.chkSorted_CheckedChanged);

            lblUpDownAlignment.Location = new System.Drawing.Point(16, 64);
            lblUpDownAlignment.TabIndex = 2;
            lblUpDownAlignment.TabStop = false;
            lblUpDownAlignment.Text = "UpDownAlignment";
            lblUpDownAlignment.Size = new System.Drawing.Size(120, 24);

            lblIncrement.Location = new System.Drawing.Point(32, 120);
            lblIncrement.TabIndex = 4;
            lblIncrement.TabStop = false;
            lblIncrement.Text = "Increment";
            lblIncrement.Size = new System.Drawing.Size(72, 24);

            chkInterceptArrowKeys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkInterceptArrowKeys.Location = new System.Drawing.Point(304, 32);
            chkInterceptArrowKeys.TabIndex = 0;
            chkInterceptArrowKeys.CheckState = System.WinForms.CheckState.Checked;
            chkInterceptArrowKeys.Text = "InterceptArrowKeys";
            chkInterceptArrowKeys.Size = new System.Drawing.Size(144, 24);
            chkInterceptArrowKeys.Checked = true;
            chkInterceptArrowKeys.CheckedChanged += new EventHandler(this.chkInterceptArrowKeys_CheckedChanged);

            grpCommonProperties.Location = new System.Drawing.Point(16, 224);
            grpCommonProperties.TabIndex = 2;
            grpCommonProperties.TabStop = false;
            grpCommonProperties.Text = "CommonProperties";
            grpCommonProperties.Size = new System.Drawing.Size(472, 112);

            lblTextAlign.Location = new System.Drawing.Point(16, 32);
            lblTextAlign.TabIndex = 1;
            lblTextAlign.TabStop = false;
            lblTextAlign.Text = "TextAlign";
            lblTextAlign.Size = new System.Drawing.Size(120, 24);

            domainUpDown1.Location = new System.Drawing.Point(32, 32);
            domainUpDown1.TabIndex = 0;
            domainUpDown1.Size = new System.Drawing.Size(96, 23);

            updnTextAlign.Location = new System.Drawing.Point(152, 32);
            updnTextAlign.TabIndex = 3;
            updnTextAlign.Size = new System.Drawing.Size(120, 23);
            updnTextAlign.SelectedItemChanged += new EventHandler(this.updnTextAlign_SelectedItemChanged);

            updnIncrement.Location = new System.Drawing.Point(152, 120);
            updnIncrement.Maximum = new System.Decimal(100d);
            updnIncrement.Minimum = new System.Decimal(1d);
            updnIncrement.TabIndex = 2;
            updnIncrement.DecimalPlaces = 0;
            updnIncrement.Text = "1";
            updnIncrement.Size = new System.Drawing.Size(56, 23);
            updnIncrement.ValueChanged += new EventHandler(this.updnIncrement_ValueChanged);

            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.ClientSize = new System.Drawing.Size(504, 352);
            this.Text = "UpDownCtlForm";

            lblDecimalPlaces.Location = new System.Drawing.Point(32, 80);
            lblDecimalPlaces.TabIndex = 3;
            lblDecimalPlaces.TabStop = false;
            lblDecimalPlaces.Text = "DecimalPlaces";
            lblDecimalPlaces.Size = new System.Drawing.Size(96, 24);

            updnUpDownAlignment.Location = new System.Drawing.Point(152, 64);
            updnUpDownAlignment.TabIndex = 4;
            updnUpDownAlignment.Size = new System.Drawing.Size(120, 23);
            updnUpDownAlignment.SelectedItemChanged += new EventHandler(this.updnUpDownAlignment_SelectedItemChanged);

            numericUpDown1.Location = new System.Drawing.Point(32, 32);
            numericUpDown1.Maximum = new System.Decimal(100d);
            numericUpDown1.Minimum = new System.Decimal(0d);
            numericUpDown1.TabIndex = 0;
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Text = "0.00";
            numericUpDown1.Size = new System.Drawing.Size(104, 23);

            this.Controls.Add(grpCommonProperties);
            this.Controls.Add(grpDomainUpDown);
            this.Controls.Add(grpNumericUpDown);
            grpCommonProperties.Controls.Add(updnUpDownAlignment);
            grpCommonProperties.Controls.Add(updnTextAlign);
            grpCommonProperties.Controls.Add(lblUpDownAlignment);
            grpCommonProperties.Controls.Add(lblTextAlign);
            grpCommonProperties.Controls.Add(chkInterceptArrowKeys);
            grpNumericUpDown.Controls.Add(lblIncrement);
            grpNumericUpDown.Controls.Add(updnIncrement);
            grpNumericUpDown.Controls.Add(lblDecimalPlaces);
            grpNumericUpDown.Controls.Add(updnDecimalPlaces);
            grpNumericUpDown.Controls.Add(numericUpDown1);
            grpDomainUpDown.Controls.Add(chkSorted);
            grpDomainUpDown.Controls.Add(chkWrap);
            grpDomainUpDown.Controls.Add(domainUpDown1);
        }

        // <doc>
        // <desc>
        //        The main entry point for the application. 
        // </desc>
        // <param term='args'>
        //        Array of parameters passed to the application via the command line.
        // </param>
        // </doc>
        //
        public static void Main(string[] args) { 
            Application.Run(new UpDownCtl());
        }

        // <doc>
        // <desc>
        //     This class defines the objects in the DomainUpDown controls that drive
        //     the properties of the UpDown controls ComboBoxes.
        // </desc>
        // </doc>
        //
        private class StringIntObject {
            public string s;
            public int i;

            public StringIntObject(string sz, int n) {
                s=sz;
                i=n;
            }

            public override string ToString() {
                return s;
            }
        }
    }
}
