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
namespace Microsoft.Samples.WinForms.Cs.CustomerControl {
   using System;
   using System.WinForms;
   using System.Drawing;

   public class CustomerControl : System.WinForms.UserControl {
       private System.ComponentModel.Container components;
    	private System.WinForms.TextBox textBoxTitle;
	    private System.WinForms.Label labelTitle;
	    private System.WinForms.TextBox textBoxAddress;
	    private System.WinForms.TextBox textBoxLastName;
	    private System.WinForms.TextBox textBoxFirstName;
	    private System.WinForms.TextBox textBoxID;
	    private System.WinForms.Label labelAddress;
	    private System.WinForms.Label labelLastName;
	    private System.WinForms.Label labelFirstName;
	    private System.WinForms.Label labelID;
        private Customer customer1;
	

        public CustomerControl() {

            // Required by the Windows Forms Designer
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call
        }

        public Customer Customer {
            get {
                return customer1;
            }
            set {
                customer1=value;
                LoadCustomer();
            }
        }

        public void AcceptChanges() {
            customer1.Title = textBoxTitle.Text;
            customer1.FirstName = textBoxFirstName.Text;
            customer1.LastName = textBoxLastName.Text;
            customer1.Address = textBoxAddress.Text;
        }

        public void RejectChanges() {
            LoadCustomer();
        }

        private void LoadCustomer() {
            textBoxID.Text = customer1.ID;
            textBoxTitle.Text = customer1.Title;
            textBoxFirstName.Text = customer1.FirstName;
            textBoxLastName.Text = customer1.LastName;
            textBoxAddress.Text =  customer1.Address;   
        }

        public override void Dispose() {
            base.Dispose();
        }

        private void InitializeComponent() {
    		this.components = new System.ComponentModel.Container();
    		this.labelAddress = new System.WinForms.Label();
    		this.labelLastName = new System.WinForms.Label();
    		this.textBoxFirstName = new System.WinForms.TextBox();
    		this.textBoxLastName = new System.WinForms.TextBox();
    		this.labelFirstName = new System.WinForms.Label();
    		this.labelTitle = new System.WinForms.Label();
    		this.textBoxTitle = new System.WinForms.TextBox();
    		this.textBoxAddress = new System.WinForms.TextBox();
    		this.labelID = new System.WinForms.Label();
    		this.textBoxID = new System.WinForms.TextBox();
    		
    		labelAddress.Size = new System.Drawing.Size(64, 16);
    		labelAddress.Location = new System.Drawing.Point(8, 194);
    		labelAddress.TabIndex = 9;
    		labelAddress.Text = "Address:";
    		
    		labelLastName.Size = new System.Drawing.Size(64, 16);
    		labelLastName.Location = new System.Drawing.Point(8, 154);
    		labelLastName.TabIndex = 8;
    		labelLastName.Text = "LastName:";
    		
            textBoxFirstName.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
    		textBoxFirstName.Text = "";
    		textBoxFirstName.TabIndex = 2;
    		textBoxFirstName.Size = new System.Drawing.Size(240, 20);
    		textBoxFirstName.Location = new System.Drawing.Point(88, 112);
    		
    		this.Text = "CustomerControl";
    		this.Size = new System.Drawing.Size(384, 304);
    		
            textBoxLastName.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
    		textBoxLastName.Location = new System.Drawing.Point(88, 152);
    		textBoxLastName.Text = "";
    		textBoxLastName.TabIndex = 3;
    		textBoxLastName.Size = new System.Drawing.Size(240, 20);
    		
    		labelFirstName.Location = new System.Drawing.Point(8, 112);
    		labelFirstName.Size = new System.Drawing.Size(64, 16);
    		labelFirstName.TabIndex = 7;
    		labelFirstName.Text = "First Name:";
    		
    		labelTitle.Size = new System.Drawing.Size(64, 16);
    		labelTitle.Location = new System.Drawing.Point(8, 72);
    		labelTitle.TabIndex = 6;
    		labelTitle.Text = "Title:";
    		
            textBoxTitle.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
    		textBoxTitle.Text = "";
    		textBoxTitle.TabIndex = 1;
    		textBoxTitle.Size = new System.Drawing.Size(88, 20);
    		textBoxTitle.Location = new System.Drawing.Point(88, 70);
    		
            textBoxAddress.Anchor = System.WinForms.AnchorStyles.All;
    		textBoxAddress.Text = "";
    		textBoxAddress.Multiline = true;
    		textBoxAddress.TabIndex = 4;
    		textBoxAddress.Size = new System.Drawing.Size(264, 96);
    		textBoxAddress.Location = new System.Drawing.Point(88, 192);
            textBoxAddress.AcceptsReturn = true;
    		
    		labelID.Size = new System.Drawing.Size(64, 16);
    		labelID.Location = new System.Drawing.Point(8, 32);
    		labelID.TabIndex = 5;
    		labelID.Text = "ID:";
    		
            textBoxID.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
    		textBoxID.Text = "";
    		textBoxID.ReadOnly = true;
    		textBoxID.TabIndex = 0;
    		textBoxID.Size = new System.Drawing.Size(200, 20);
    		textBoxID.Location = new System.Drawing.Point(88, 30);
    		textBoxID.Enabled = false;
    		
    		this.Controls.Add(textBoxTitle);
    		this.Controls.Add(labelTitle);
    		this.Controls.Add(textBoxAddress);
    		this.Controls.Add(textBoxLastName);
    		this.Controls.Add(textBoxFirstName);
    		this.Controls.Add(textBoxID);
    		this.Controls.Add(labelAddress);
    		this.Controls.Add(labelLastName);
    		this.Controls.Add(labelFirstName);
    		this.Controls.Add(labelID);
    		
    	}

    }
}
