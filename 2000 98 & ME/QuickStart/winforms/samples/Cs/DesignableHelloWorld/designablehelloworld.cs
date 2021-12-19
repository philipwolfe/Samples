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
namespace Microsoft.Samples.WinForms.Cs.DesignableHelloWorld {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;

    public class DesignableHelloWorld : System.WinForms.Form {
        private System.ComponentModel.Container components;
        private System.WinForms.Button button1;
        private System.WinForms.TextBox textBox1;
        private System.Resources.ResourceManager resources;

        public DesignableHelloWorld() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call
                
            //BUG #47519   
            resources = new System.Resources.ResourceManager("DesignableHelloWorld", typeof(DesignableHelloWorld), null, true);
            
            //Set the minimum form size to the client size + the height of the title bar
            this.MinTrackSize = new Size(392, (117 + SystemInformation.CaptionHeight));
            
        }

        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void InitializeComponent() {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager("DesignableHelloWorld", typeof(DesignableHelloWorld), null, true);

            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.WinForms.TextBox();
            this.button1 = new System.WinForms.Button();

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.Text = "Built using the Designer";
            this.ClientSize = new System.Drawing.Size(392, 117);

            textBox1.Location = new System.Drawing.Point(16, 24);
            textBox1.Text = "Hello WinForms World";
            textBox1.TabIndex = 0;
            textBox1.Size = new System.Drawing.Size(360, 20);

            button1.ForeColor = System.Drawing.Color.LawnGreen;
            button1.BackgroundImage = (System.Drawing.Image)resources.GetObject("button1.BackgroundImage");
            button1.Size = new System.Drawing.Size(120, 40);
            button1.TabIndex = 1;
            button1.Font = new System.Drawing.Font("Times New Roman", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            button1.Text = "Click Me!";
            button1.Location = new System.Drawing.Point(256, 64);
            button1.Click += new System.EventHandler(button1_Click);

            this.Controls.Add(button1);
            this.Controls.Add(textBox1);
	    }

        private void button1_Click(object sender, System.EventArgs e) {
            MessageBox.Show("Text is: '" + textBox1.Text + "'");
        }


        public static void Main(string[] args) {
            Application.Run(new DesignableHelloWorld());
        }

    }
}










