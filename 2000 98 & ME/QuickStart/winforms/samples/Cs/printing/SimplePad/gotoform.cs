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
namespace Microsoft.Samples.WinForms.Cs.SimplePad {
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.WinForms;


    public class GotoForm : Form {
        private System.ComponentModel.Container components;
        private Button button1;
        private TextBox edit1;
        private Size initSize;

        public GotoForm() {
            InitializeComponent();
            initSize = Size;
        }

        public int Line {
            get {
                if (edit1.Text == null || edit1.Text.Length < 0) {
                    edit1.Text = "1";
                }
                return int.Parse(edit1.Text);
            }
            set {
                edit1.Text = int.ToString(value);
            }
        }

        protected Size MinTrackSize {
            override get {
                return initSize;
            }
        }

        protected Size MaxTrackSize {
            override get {
                return new Size(300, initSize.Height);
            }
        }

        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.button1 = new Button();
            this.edit1 = new TextBox();
            this.StartPosition = FormStartPosition.CenterParent;

            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(120, 8);
            button1.Text = "Go";
            button1.Size = new Size(48, 24);
            button1.TabIndex = 1;
            button1.DialogResult = System.WinForms.DialogResult.OK;
            button1.Anchor = AnchorStyles.TopBottomRight;

            this.AcceptButton = button1;
            this.AutoScaleBaseSize = new Size(6, 16);
            this.Text = "Go To";
            this.MaximizeBox = false;
            this.BorderStyle = FormBorderStyle.SizableToolWindow;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Show;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new Size(184, 36);

            edit1.TabIndex = 0;
            edit1.Size = new Size(104, 23);
            edit1.Location = new Point(8, 8);
            edit1.Anchor = AnchorStyles.All;

            this.Controls.Add(button1);
            this.Controls.Add(edit1);
        }
    }
}