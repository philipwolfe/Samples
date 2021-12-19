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
    using Microsoft.Samples.WinForms.Cs.HelloWorldControl;

    public class HostApp : System.WinForms.Form {
        private System.ComponentModel.Container components;
	    private Microsoft.Samples.WinForms.Cs.HelloWorldControl.HelloWorldControl helloWorldControl1;

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
		    this.helloWorldControl1 = new Microsoft.Samples.WinForms.Cs.HelloWorldControl.HelloWorldControl();
		
		    helloWorldControl1.Dock = System.WinForms.DockStyle.Fill;
		    helloWorldControl1.Size = new System.Drawing.Size(600, 450);
		    helloWorldControl1.TabIndex = 0;
		    helloWorldControl1.Text = "Hello Windows Forms Control World";
		
		    this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		    this.Text = "Control Example";
		    this.ClientSize = new System.Drawing.Size(600, 450);
		
		    this.Controls.Add(helloWorldControl1);
	    }


        public static void Main(string[] args) {
            Application.Run(new HostApp());
        }

    }
}










