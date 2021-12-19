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
namespace Microsoft.Samples.WinForms.Cs.Accessible {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;

    public class Accessible : System.WinForms.Form {
        private System.ComponentModel.Container components;
        private System.WinForms.Button button1;
        private System.WinForms.TextBox textBox1;

        public Accessible() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call

            //Set the minimum form size to the client size + the height of the title bar
            this.MinTrackSize = new Size(392, (117 + SystemInformation.CaptionHeight));
        }

        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.WinForms.Button();
            this.textBox1 = new System.WinForms.TextBox();

            button1.AccessibleDescription = "Once you\'ve entered some text push this button";
            button1.Location = new System.Drawing.Point(256, 64);
            button1.Size = new System.Drawing.Size(120, 40);
            button1.TabIndex = 1;
            button1.Text = "Click Me!";
            button1.AccessibleName = "DefaultAction";
            button1.Click += new System.EventHandler(button1_Click);
            button1.Anchor = System.WinForms.AnchorStyles.BottomRight;

            textBox1.Location = new System.Drawing.Point(16, 24);
            textBox1.Text = "Hello WinForms World";
            textBox1.AccessibleName = "TextEntryField";
            textBox1.TabIndex = 0;
            textBox1.AccessibleDescription = "Please enter some text in the box";
            textBox1.Size = new System.Drawing.Size(360, 20);
            textBox1.Anchor = System.WinForms.AnchorStyles.TopLeftRight;

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.Text = "Accessibility";
            this.AccessibleRole = System.WinForms.AccessibleRoles.Window;
            this.AccessibleName = "AccessibleForm";
            this.AcceptButton = button1;
            this.AccessibleDescription = "Simple Form that demonstrates accessibility";
            this.ClientSize = new System.Drawing.Size(392, 117);

            this.Controls.Add(button1);
            this.Controls.Add(textBox1);

        }

        private void button1_Click(object sender, System.EventArgs e) {
            MessageBox.Show("Text is: '" + textBox1.Text + "'");
        }


        public static void Main(string[] args) {
            Application.Run(new Accessible());
        }

    }
}











