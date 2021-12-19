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
namespace Microsoft.Samples.WinForms.Cs.SimpleBinding {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;

    using System.Data;
    using System.Data.ADO;
    using Microsoft.Samples.WinForms.Cs.SimpleBinding.Data;

    public class SimpleBinding : System.WinForms.Form {
        private System.ComponentModel.Container components;
    
    	private System.WinForms.ComponentModel.DateTimeFormat dateTimeFormat1;
	    private System.WinForms.TextBox textBoxDOB;
	    private System.WinForms.Label labelDOB;
	    private System.WinForms.TextBox textBoxPosition;
	    private System.WinForms.Button buttonMoveFirst;
	    private System.WinForms.Button buttonMovePrev;
	    private System.WinForms.Button buttonMoveNext;
	    private System.WinForms.Button buttonMoveLast;
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
        private System.WinForms.Panel panelVCRControl;
        private CustomerList custList;

        public SimpleBinding() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call

            //Get the list of customers
            custList = CustomerList.GetCustomers();

            //Set up the bindings so that each field on the form is
            //bound to a property of Customer
            textBoxID.Bindings.Add("Text", custList, "ID");
            textBoxTitle.Bindings.Add("Text", custList, "Title");
            textBoxLastName.Bindings.Add("Text", custList, "LastName");
            textBoxFirstName.Bindings.Add("Text", custList, "FirstName");
            textBoxDOB.Bindings.Add("Value", custList, "DateOfBirth");
            textBoxAddress.Bindings.Add("Text", custList, "Address");

            //We want to handle position changing events for the DATA VCR Panel
            //Position is managed by the Form's BindingManager so hook the position changed
            //event on the BindingManager
            this.BindingManager[custList].PositionChanged += new System.EventHandler(customers_PositionChanged);
            
            //Set up the initial text for the DATA VCR Panel
            textBoxPosition.Text = "Record " + (this.BindingManager[custList].Position + 1) + " of " + custList.Count;
            
            //Set the minimum form size to the client size + the height of the title bar
            this.MinTrackSize = new Size(368, (413 + SystemInformation.CaptionHeight));

        }


        //When the MoveFirst button is clicked set the position for the CustomersList
        //to the first record
        private void buttonMoveFirst_Click(object sender, System.EventArgs e) {
            this.BindingManager[custList].Position = 0 ;
        }


        //When the MoveLast button is clicked set the position for the CustomersList 
        //to the last record
        private void buttonMoveLast_Click(object sender, System.EventArgs e) {
            this.BindingManager[custList].Position = custList.Count - 1;
        }


        //When the MoveNext button is clicked increment the position for the CustomersList
        private void buttonMoveNext_Click(object sender, System.EventArgs e) {
            if (this.BindingManager[custList].Position < custList.Count - 1) {
                this.BindingManager[custList].Position++;
            }
        }


        //When the MovePrev button is clicked decrement the position for the CustomersList
        private void buttonMovePrev_Click(object sender, System.EventArgs e) {
            if (this.BindingManager[custList].Position > 0) {
                this.BindingManager[custList].Position--;
            }
        }


        //Position has changed - update the DATA VCR panel
        private void customers_PositionChanged(object sender, System.EventArgs e) {
            textBoxPosition.Text = "Record " + (this.BindingManager[custList].Position + 1) + " of " + custList.Count;
        }


        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }


        private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.textBoxTitle = new System.WinForms.TextBox();
		this.labelFirstName = new System.WinForms.Label();
		this.dateTimeFormat1 = new System.WinForms.ComponentModel.DateTimeFormat();
		this.textBoxID = new System.WinForms.TextBox();
		this.buttonMoveNext = new System.WinForms.Button();
		this.buttonMovePrev = new System.WinForms.Button();
		this.labelTitle = new System.WinForms.Label();
		this.textBoxLastName = new System.WinForms.TextBox();
		this.labelDOB = new System.WinForms.Label();
		this.textBoxPosition = new System.WinForms.TextBox();
		this.textBoxDOB = new System.WinForms.TextBox();
		this.panelVCRControl = new System.WinForms.Panel();
		this.textBoxAddress = new System.WinForms.TextBox();
		this.labelLastName = new System.WinForms.Label();
		this.labelID = new System.WinForms.Label();
		this.buttonMoveFirst = new System.WinForms.Button();
		this.labelAddress = new System.WinForms.Label();
		this.textBoxFirstName = new System.WinForms.TextBox();
		this.buttonMoveLast = new System.WinForms.Button();
		
		//@design this.TrayHeight = 181;
		//@design this.TrayLargeIcon = true;
		//@design this.TrayAutoArrange = true;
		this.Text = "Customer Details";
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(368, 413);
		
		textBoxTitle.Location = new System.Drawing.Point(88, 70);
		textBoxTitle.TabIndex = 1;
		textBoxTitle.Size = new System.Drawing.Size(70, 20);
		
		labelFirstName.Location = new System.Drawing.Point(8, 112);
		labelFirstName.Text = "&First Name:";
		labelFirstName.Size = new System.Drawing.Size(64, 16);
		labelFirstName.TabIndex = 7;
		
		//@design dateTimeFormat1.SetLocation(new System.Drawing.Point(7, 7));
		dateTimeFormat1.DisplayFormat = "D";
		
		textBoxID.Location = new System.Drawing.Point(88, 30);
		textBoxID.ReadOnly = true;
		textBoxID.Enabled = false;
		textBoxID.TabIndex = 0;
		textBoxID.Size = new System.Drawing.Size(203, 20);
		
		buttonMoveNext.Location = new System.Drawing.Point(184, 8);
		buttonMoveNext.FlatStyle = System.WinForms.FlatStyle.Flat;
		buttonMoveNext.Size = new System.Drawing.Size(32, 32);
		buttonMoveNext.TabIndex = 11;
		buttonMoveNext.Anchor = System.WinForms.AnchorStyles.Top;
		buttonMoveNext.Font = new System.Drawing.Font("Times New Roman", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
		buttonMoveNext.Text = ">";
		buttonMoveNext.Click += new System.EventHandler(buttonMoveNext_Click);
		
		buttonMovePrev.Location = new System.Drawing.Point(48, 8);
		buttonMovePrev.FlatStyle = System.WinForms.FlatStyle.Flat;
		buttonMovePrev.Size = new System.Drawing.Size(32, 32);
		buttonMovePrev.TabIndex = 12;
		buttonMovePrev.Font = new System.Drawing.Font("Times New Roman", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
		buttonMovePrev.Text = "<";
		buttonMovePrev.Click += new System.EventHandler(buttonMovePrev_Click);
		
		labelTitle.Location = new System.Drawing.Point(8, 72);
		labelTitle.Text = "&Title:";
		labelTitle.Size = new System.Drawing.Size(64, 16);
		labelTitle.TabIndex = 6;
		
		textBoxLastName.Location = new System.Drawing.Point(88, 152);
		textBoxLastName.TabIndex = 3;
		textBoxLastName.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
		textBoxLastName.Size = new System.Drawing.Size(243, 20);
		
		labelDOB.Location = new System.Drawing.Point(8, 194);
		labelDOB.Text = "&Date of Birth:";
		labelDOB.Size = new System.Drawing.Size(72, 16);
		labelDOB.TabIndex = 16;
		
		textBoxPosition.Location = new System.Drawing.Point(88, 14);
		textBoxPosition.ReadOnly = true;
		textBoxPosition.BorderStyle = System.WinForms.BorderStyle.FixedSingle;
		textBoxPosition.Enabled = false;
		textBoxPosition.TabIndex = 14;
		textBoxPosition.Anchor = System.WinForms.AnchorStyles.Left;
		textBoxPosition.Size = new System.Drawing.Size(88, 20);
		
		textBoxDOB.Location = new System.Drawing.Point(88, 192);
		textBoxDOB.Format = dateTimeFormat1;
		textBoxDOB.TabIndex = 17;
		textBoxDOB.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
		textBoxDOB.Size = new System.Drawing.Size(243, 20);
		
		panelVCRControl.BorderStyle = System.WinForms.BorderStyle.FixedSingle;
		panelVCRControl.Location = new System.Drawing.Point(88, 344);
		panelVCRControl.Size = new System.Drawing.Size(264, 48);
		panelVCRControl.TabIndex = 15;
		panelVCRControl.Anchor = System.WinForms.AnchorStyles.Bottom;
		panelVCRControl.Text = "panel1";
		
		textBoxAddress.Location = new System.Drawing.Point(88, 232);
		textBoxAddress.Multiline = true;
		textBoxAddress.AcceptsReturn = true;
		textBoxAddress.TabIndex = 4;
		textBoxAddress.Anchor = System.WinForms.AnchorStyles.All;
		textBoxAddress.Size = new System.Drawing.Size(264, 88);
		
		labelLastName.Location = new System.Drawing.Point(8, 154);
		labelLastName.Text = "&Last Name:";
		labelLastName.Size = new System.Drawing.Size(64, 16);
		labelLastName.TabIndex = 8;
		
		labelID.Location = new System.Drawing.Point(8, 32);
		labelID.Text = "ID:";
		labelID.Size = new System.Drawing.Size(64, 16);
		labelID.TabIndex = 5;
		
		buttonMoveFirst.Location = new System.Drawing.Point(8, 8);
		buttonMoveFirst.FlatStyle = System.WinForms.FlatStyle.Flat;
		buttonMoveFirst.Size = new System.Drawing.Size(32, 32);
		buttonMoveFirst.TabIndex = 13;
		buttonMoveFirst.Font = new System.Drawing.Font("Times New Roman", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
		buttonMoveFirst.Text = "|<";
		buttonMoveFirst.Click += new System.EventHandler(buttonMoveFirst_Click);
		
		labelAddress.Location = new System.Drawing.Point(8, 232);
		labelAddress.Text = "&Address:";
		labelAddress.Size = new System.Drawing.Size(64, 16);
		labelAddress.TabIndex = 9;
		
		textBoxFirstName.Location = new System.Drawing.Point(88, 112);
		textBoxFirstName.TabIndex = 2;
		textBoxFirstName.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
		textBoxFirstName.Size = new System.Drawing.Size(243, 20);
		
		buttonMoveLast.Location = new System.Drawing.Point(224, 8);
		buttonMoveLast.FlatStyle = System.WinForms.FlatStyle.Flat;
		buttonMoveLast.Size = new System.Drawing.Size(32, 32);
		buttonMoveLast.TabIndex = 10;
		buttonMoveLast.Anchor = System.WinForms.AnchorStyles.Top;
		buttonMoveLast.Font = new System.Drawing.Font("Times New Roman", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
		buttonMoveLast.Text = ">|";
		buttonMoveLast.Click += new System.EventHandler(buttonMoveLast_Click);
		panelVCRControl.Controls.Add(textBoxPosition);
		panelVCRControl.Controls.Add(buttonMoveFirst);
		panelVCRControl.Controls.Add(buttonMovePrev);
		panelVCRControl.Controls.Add(buttonMoveNext);
		panelVCRControl.Controls.Add(buttonMoveLast);
		this.Controls.Add(textBoxDOB);
		this.Controls.Add(labelDOB);
		this.Controls.Add(panelVCRControl);
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


        public static void Main(string[] args) {
            Application.Run(new SimpleBinding());
        }

    }
}
















