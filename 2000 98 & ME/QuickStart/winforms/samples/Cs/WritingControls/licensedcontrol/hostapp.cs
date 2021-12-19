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
    using Microsoft.Samples.WinForms.Cs.LicensedControl;

    public class HostApp : System.WinForms.Form {
        private System.ComponentModel.Container components;
	    private Microsoft.Samples.WinForms.Cs.LicensedControl.LicensedControl LicensedControl1;

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
		    this.LicensedControl1 = new Microsoft.Samples.WinForms.Cs.LicensedControl.LicensedControl();
		
		    LicensedControl1.Dock = System.WinForms.DockStyle.Fill;
		    LicensedControl1.Size = new System.Drawing.Size(600, 450);
		    LicensedControl1.TabIndex = 0;
		    LicensedControl1.Text = "Hello from the licensed control!";
		
		    this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		    this.Text = "Control Example";
		    this.ClientSize = new System.Drawing.Size(600, 450);
		
		    this.Controls.Add(LicensedControl1);
	    }


        public static void Main(string[] args) {
            Application.Run(new HostApp());
        }

    }
}










