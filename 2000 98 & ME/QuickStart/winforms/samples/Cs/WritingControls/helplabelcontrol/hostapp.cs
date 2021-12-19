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
namespace Microsoft.Samples.WinForms.Cs.HostApp {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;
    using Microsoft.Samples.WinForms.Cs.HelpLabel;

    public class HostApp : System.WinForms.Form {
        private System.ComponentModel.Container components;
        private System.WinForms.Label label1;
        private System.WinForms.TextBox textBox1;
        private System.WinForms.Button button1;
        private Microsoft.Samples.WinForms.Cs.HelpLabel.HelpLabel helpLabel1;

        public HostApp() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call
        }

        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void InitializeComponent() {
	    	this.components = new System.ComponentModel.Container();
    		this.label1 = new System.WinForms.Label();
            this.helpLabel1 = new Microsoft.Samples.WinForms.Cs.HelpLabel.HelpLabel();
            this.button1 = new System.WinForms.Button();
            this.textBox1 = new System.WinForms.TextBox();

            label1.Location = new System.Drawing.Point(16, 16);
            label1.Text = "Name:";
            label1.Size = new System.Drawing.Size(56, 24);
            label1.TabIndex = 3;

            helpLabel1.Dock = System.WinForms.DockStyle.Bottom;
            helpLabel1.Size = new System.Drawing.Size(448, 40);
            helpLabel1.TabIndex = 0;
            helpLabel1.Location = new System.Drawing.Point(0, 117);

            button1.Anchor = System.WinForms.AnchorStyles.BottomRight;
            button1.Size = new System.Drawing.Size(104, 40);
            button1.TabIndex = 1;
            helpLabel1.SetHelpText(button1, "This is the Save Button. Press the Save Button to save your work.");
            button1.Text = "&Save";
            button1.Location = new System.Drawing.Point(336, 56);

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.Text = "Control Example";
            this.ClientSize = new System.Drawing.Size(448, 157);

            textBox1.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
            textBox1.Location = new System.Drawing.Point(80, 16);
            textBox1.Text = "<Name>";
            helpLabel1.SetHelpText(textBox1, "This is the name field. Please enter your name here.");
            textBox1.TabIndex = 2;
            textBox1.Size = new System.Drawing.Size(360, 20);

            this.Controls.Add(label1);
            this.Controls.Add(textBox1);
            this.Controls.Add(button1);
            this.Controls.Add(helpLabel1);
	    }
	

        public static void Main(string[] args) {
            Application.Run(new HostApp());
        }

    }
}










