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
    using Microsoft.Samples.WinForms.Cs.CustomerControl;

    public class HostApp : System.WinForms.Form {
        private System.ComponentModel.Container components;
    	private System.WinForms.Button buttonCancel;
	    private System.WinForms.Button buttonSave;
        private Microsoft.Samples.WinForms.Cs.CustomerControl.CustomerControl CustomerControl1;

        public HostApp() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call
            CustomerControl1.Customer = Customer.ReadCustomer();
            
            //Set the minimum form size to the client size + the height of the title bar
            this.MinTrackSize = new Size(400, (373 + SystemInformation.CaptionHeight));
        }

        public override void Dispose() {
            base.Dispose();
        }

        private void InitializeComponent() {
    		this.components = new System.ComponentModel.Container();
    		this.buttonSave = new System.WinForms.Button();
    		this.buttonCancel = new System.WinForms.Button();
    		this.CustomerControl1 = new Microsoft.Samples.WinForms.Cs.CustomerControl.CustomerControl();
    		
            buttonSave.Anchor = System.WinForms.AnchorStyles.BottomLeft;
    		buttonSave.DialogResult = System.WinForms.DialogResult.OK;
    		buttonSave.FlatStyle = System.WinForms.FlatStyle.Flat;
    		buttonSave.Size = new System.Drawing.Size(96, 24);
    		buttonSave.TabIndex = 1;
    		buttonSave.Text = "&Save";
    		buttonSave.Location = new System.Drawing.Point(8, 328);
            buttonSave.Click += new System.EventHandler(buttonSave_Click);

            buttonCancel.Anchor = System.WinForms.AnchorStyles.BottomLeft;
    		buttonCancel.Location = new System.Drawing.Point(120, 328);
    		buttonCancel.DialogResult = System.WinForms.DialogResult.Cancel;
    		buttonCancel.FlatStyle = System.WinForms.FlatStyle.Flat;
    		buttonCancel.Size = new System.Drawing.Size(96, 24);
    		buttonCancel.TabIndex = 2;
    		buttonCancel.Text = "Cancel";
            buttonCancel.Click += new System.EventHandler(buttonCancel_Click);
    		
    		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    		this.Text = "Control Example";
    		this.CancelButton = buttonCancel;
    		this.AcceptButton = buttonSave;
    		this.ClientSize = new System.Drawing.Size(400, 373);
    		
            CustomerControl1.Anchor=System.WinForms.AnchorStyles.All;
    		CustomerControl1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
    		CustomerControl1.Size = new System.Drawing.Size(400, 310);
    		CustomerControl1.TabIndex = 0;
    		CustomerControl1.Text = "Hello Windows Forms Control World";
    		
    		this.Controls.Add(buttonCancel);
    		this.Controls.Add(buttonSave);
    		this.Controls.Add(CustomerControl1);
    		
    	}

        private void buttonCancel_Click(object sender, System.EventArgs e) {
            CustomerControl1.RejectChanges();
        }

        private void buttonSave_Click(object sender, System.EventArgs e) {
            CustomerControl1.AcceptChanges();
            MessageBox.Show("Customer Changes Saved:\n" + CustomerControl1.Customer);

        }

        public static void Main(string[] args) {
            Application.Run(new HostApp());
        }

    }
}










