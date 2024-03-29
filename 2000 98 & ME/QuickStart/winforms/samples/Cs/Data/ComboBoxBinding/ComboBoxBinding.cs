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
namespace Microsoft.Samples.WinForms.Cs.ComboBoxBinding {
    
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;
    using System.Data;
    using System.Data.SQL;

    public class ComboBoxBinding : System.WinForms.Form {
        private System.ComponentModel.Container components;
	    private Microsoft.Samples.WinForms.Cs.ComboBoxBinding.Data.CustomersDataSet customersDataSet1;
	    private System.WinForms.TextBox textBoxZip;
	    private System.WinForms.ComboBox comboBoxState;
	    private System.WinForms.TextBox textBoxCity;
	    private System.WinForms.Label labelState;
	    private System.WinForms.Label labelZip;
	    private System.WinForms.Label labelCity;
	    private System.WinForms.TextBox textBoxPosition;
	    private System.WinForms.Button buttonMoveFirst;
	    private System.WinForms.Button buttonMovePrev;
	    private System.WinForms.Button buttonMoveNext;
	    private System.WinForms.Button buttonMoveLast;
        private System.WinForms.TextBox textBoxCompany;
        private System.WinForms.Label labelCompanyName;
        private System.WinForms.TextBox textBoxAddress;
        private System.WinForms.TextBox textBoxTitle;
        private System.WinForms.TextBox textBoxContact;
        private System.WinForms.TextBox textBoxID;
        private System.WinForms.Label labelAddress;
        private System.WinForms.Label labelContactTitle;
        private System.WinForms.Label labelContact;
        private System.WinForms.Label labelID;
        private System.WinForms.Panel panelVCRControl;

        //Define the array of states for the drop-down list
        public State[] States  = new State[] { 
            new State("Alabama","AL")
           ,new State("Alaska","AK")
           ,new State("Arizona" ,"AZ")
           ,new State("Arkansas","AR")
           ,new State("California" ,"CA")
           ,new State("Colorado","CO")
           ,new State("Connecticut","CT")
           ,new State("Delaware","DE")
           ,new State("District of Columbia","DC")
           ,new State("Florida" ,"FL")
           ,new State("Georgia" ,"GA")
           ,new State("Hawaii"  ,"HI")
           ,new State("Idaho","ID")
           ,new State("Illinois","IL")
           ,new State("Indiana" ,"IN")
           ,new State("Iowa","IA")
           ,new State("Kansas"  ,"KS")
           ,new State("Kentucky","KY")
           ,new State("Louisiana"  ,"LA")
           ,new State("Maine","ME")
           ,new State("Maryland","MD")
           ,new State("Massachusetts","MA")
           ,new State("Michigan","MI")
           ,new State("Minnesota"  ,"MN")
           ,new State("Mississippi","MS")
           ,new State("Missouri","MO")
           ,new State("Montana" ,"MT")
           ,new State("Nebraska","NE")
           ,new State("Nevada"  ,"NV")
           ,new State("New Hampshire","NH")
           ,new State("New Jersey" ,"NJ")
           ,new State("New Mexico" ,"NM")
           ,new State("New York","NY")
           ,new State("North Carolina","NC")
           ,new State("North Dakota" ,"ND")
           ,new State("Ohio","OH")
           ,new State("Oklahoma","OK")
           ,new State("Oregon"  ,"OR")
           ,new State("Pennsylvania" ,"PA")
           ,new State("Rhode Island" ,"RI")
           ,new State("South Carolina","SC")
           ,new State("South Dakota" ,"SD")
           ,new State("Tennessee"  ,"TN")
           ,new State("Texas","TX")
           ,new State("Utah","UT")
           ,new State("Vermont" ,"VT")
           ,new State("Virginia","VA")
           ,new State("Washington" ,"WA")
           ,new State("West Virginia","WV")
           ,new State("Wisconsin"  ,"WI")
           ,new State("Wyoming" ,"WY")
           } ;                                       

        public ComboBoxBinding() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();

            //Fill the DataSet
            SQLConnection con = new SQLConnection("server=localhost;uid=sa;pwd=;database=northwind");
            SQLDataSetCommand cmd = new SQLDataSetCommand("Select * from Customers where country='USA'", con);
            cmd.FillDataSet(customersDataSet1, "Customers");
            
            //Set up the Combobox bindings
            comboBoxState.DataSource=States;            //Populate the list
            comboBoxState.DisplayMember="LongName";     //Define the field to be displayed
            comboBoxState.ValueMember="ShortName";      //Define the field to be used as the value

            //Bind the selected value of the the combobox to the Region field of the current
            //Customer
            comboBoxState.Bindings.Add("SelectedValue", customersDataSet1, "Customers.Region");

            //Set up the rest of the form bindings
            textBoxID.Bindings.Add("Text", customersDataSet1, "Customers.CustomerID");
            textBoxCity.Bindings.Add("Text", customersDataSet1, "Customers.City");
            textBoxTitle.Bindings.Add("Text", customersDataSet1, "Customers.ContactTitle");
            textBoxAddress.Bindings.Add("Text", customersDataSet1, "Customers.Address");
            textBoxCompany.Bindings.Add("Text", customersDataSet1, "Customers.CompanyName");
            textBoxContact.Bindings.Add("Text", customersDataSet1, "Customers.ContactName");
            textBoxZip.Bindings.Add("Text", customersDataSet1, "Customers.PostalCode");
            
            //We want to handle position changing events for the DATA VCR Panel
            this.BindingManager[customersDataSet1,"Customers"].PositionChanged += new System.EventHandler(customers_PositionChanged);

            //Set up the initial text for the DATA VCR Panel
            textBoxPosition.Text = "Record " + (this.BindingManager[customersDataSet1,"Customers"].Position + 1) + " of " + customersDataSet1.Customers.Count;

            //Set the minimum form size 
            this.MinTrackSize = new Size(375, 361);
        }


        //When the MoveFirst button is clicked set the position for the Customers table 
        //to the first record
        private void buttonMoveFirst_Click(object sender, System.EventArgs e) {
            this.BindingManager[customersDataSet1,"Customers"].Position = 0 ;
        }


        //When the MoveLast button is clicked set the position for the Customers table 
        //to the last record
        private void buttonMoveLast_Click(object sender, System.EventArgs e) {
            this.BindingManager[customersDataSet1,"Customers"].Position = customersDataSet1.Customers.Count - 1;
        }


        //When the MoveNext button is clicked increment the position for the Customers table 
        private void buttonMoveNext_Click(object sender, System.EventArgs e) {
            if (this.BindingManager[customersDataSet1,"Customers"].Position < customersDataSet1.Customers.Count - 1) {
                this.BindingManager[customersDataSet1,"Customers"].Position++;
            }
        }


        //When the MovePrev button is clicked decrement the position for the Customers table 
        private void buttonMovePrev_Click(object sender, System.EventArgs e) {
            if (this.BindingManager[customersDataSet1,"Customers"].Position > 0) {
                this.BindingManager[customersDataSet1,"Customers"].Position--;
            }
        }
        
        
        //Position has changed - update the DATA VCR panel
        private void customers_PositionChanged(object sender, System.EventArgs e) {
            textBoxPosition.Text = "Record " + (this.BindingManager[customersDataSet1,"Customers"].Position + 1) + " of " + customersDataSet1.Customers.Count;
        }

        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.labelCity = new System.WinForms.Label();
            this.buttonMoveNext = new System.WinForms.Button();
            this.customersDataSet1 = new Microsoft.Samples.WinForms.Cs.ComboBoxBinding.Data.CustomersDataSet();
            this.labelContact = new System.WinForms.Label();
            this.buttonMoveFirst = new System.WinForms.Button();
            this.textBoxID = new System.WinForms.TextBox();
            this.textBoxCity = new System.WinForms.TextBox();
            this.labelContactTitle = new System.WinForms.Label();
            this.labelCompanyName = new System.WinForms.Label();
            this.textBoxTitle = new System.WinForms.TextBox();
            this.textBoxPosition = new System.WinForms.TextBox();
            this.labelState = new System.WinForms.Label();
            this.buttonMovePrev = new System.WinForms.Button();
            this.labelZip = new System.WinForms.Label();
            this.textBoxAddress = new System.WinForms.TextBox();
            this.textBoxCompany = new System.WinForms.TextBox();
            this.panelVCRControl = new System.WinForms.Panel();
            this.comboBoxState = new System.WinForms.ComboBox();
            this.labelAddress = new System.WinForms.Label();
            this.labelID = new System.WinForms.Label();
            this.textBoxContact = new System.WinForms.TextBox();
            this.buttonMoveLast = new System.WinForms.Button();
            this.textBoxZip = new System.WinForms.TextBox();


            labelCity.Size = new System.Drawing.Size(64, 16);
            labelCity.Location = new System.Drawing.Point(16, 176);
            labelCity.TabIndex = 11;
            labelCity.Text = "City:";

            buttonMoveNext.Location = new System.Drawing.Point(280, 8);
            buttonMoveNext.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonMoveNext.Size = new System.Drawing.Size(32, 32);
            buttonMoveNext.TabIndex = 2;
            buttonMoveNext.Anchor = System.WinForms.AnchorStyles.TopRight;
            buttonMoveNext.Text = ">";
            buttonMoveNext.Click += new System.EventHandler(buttonMoveNext_Click);

            //@design customersDataSet1.SetLocation(new System.Drawing.Point(7, 7));
            customersDataSet1.DataSetName = "CustomersDataSet";

            labelContact.Size = new System.Drawing.Size(64, 16);
            labelContact.Location = new System.Drawing.Point(16, 80);
            labelContact.TabIndex = 7;
            labelContact.Text = "Contact:";

            buttonMoveFirst.Location = new System.Drawing.Point(8, 8);
            buttonMoveFirst.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonMoveFirst.Size = new System.Drawing.Size(32, 32);
            buttonMoveFirst.TabIndex = 0;
            buttonMoveFirst.Text = "|<";
            buttonMoveFirst.Click += new System.EventHandler(buttonMoveFirst_Click);

            textBoxID.Text = "";
            textBoxID.Enabled = false;
            textBoxID.ReadOnly = true;
            textBoxID.TabIndex = 0;
            textBoxID.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
            textBoxID.Size = new System.Drawing.Size(299, 20);
            textBoxID.Location = new System.Drawing.Point(88, 16);
            //textBoxID.Bindings.All = new System.WinForms.ListBinding[] {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.CustomerID")};

            textBoxCity.Text = "";
            textBoxCity.TabIndex = 5;
            textBoxCity.Size = new System.Drawing.Size(216, 20);
            textBoxCity.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
            textBoxCity.Location = new System.Drawing.Point(88, 176);
            //textBoxCity.Bindings.All = new System.WinForms.ListBinding[] {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.City")};

            labelContactTitle.Size = new System.Drawing.Size(64, 16);
            labelContactTitle.Location = new System.Drawing.Point(16, 112);
            labelContactTitle.TabIndex = 8;
            labelContactTitle.Text = "Title:";

            labelCompanyName.Size = new System.Drawing.Size(64, 16);
            labelCompanyName.Location = new System.Drawing.Point(16, 48);
            labelCompanyName.TabIndex = 6;
            labelCompanyName.Text = "Company:";

            textBoxTitle.Text = "";
            textBoxTitle.TabIndex = 3;
            textBoxTitle.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
            textBoxTitle.Size = new System.Drawing.Size(216, 20);
            textBoxTitle.Location = new System.Drawing.Point(88, 112);
            //textBoxTitle.Bindings.All = new System.WinForms.ListBinding[] {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.ContactTitle")};

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.Text = "Customer Details";
            this.ClientSize = new System.Drawing.Size(464, 357);

            textBoxPosition.Text = "";
            textBoxPosition.BorderStyle = System.WinForms.BorderStyle.FixedSingle;
            textBoxPosition.Enabled = false;
            textBoxPosition.ReadOnly = true;
            textBoxPosition.TabIndex = 1;
            textBoxPosition.Anchor = System.WinForms.AnchorStyles.LeftRight;
            textBoxPosition.Size = new System.Drawing.Size(184, 20);
            textBoxPosition.Location = new System.Drawing.Point(88, 14);

            labelState.Size = new System.Drawing.Size(64, 16);
            labelState.Location = new System.Drawing.Point(16, 208);
            labelState.TabIndex = 13;
            labelState.Text = "State:";

            buttonMovePrev.Location = new System.Drawing.Point(48, 8);
            buttonMovePrev.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonMovePrev.Size = new System.Drawing.Size(32, 32);
            buttonMovePrev.TabIndex = 1;
            buttonMovePrev.Text = "<";
            buttonMovePrev.Click += new System.EventHandler(buttonMovePrev_Click);

            labelZip.Size = new System.Drawing.Size(64, 16);
            labelZip.Location = new System.Drawing.Point(16, 240);
            labelZip.TabIndex = 12;
            labelZip.Text = "Zip:";

            textBoxAddress.Text = "";
            textBoxAddress.AcceptsReturn = true;
            textBoxAddress.TabIndex = 4;
            textBoxAddress.Anchor = System.WinForms.AnchorStyles.All;
            textBoxAddress.Size = new System.Drawing.Size(360, 20);
            textBoxAddress.Location = new System.Drawing.Point(88, 144);
            //textBoxAddress.Bindings.All = new System.WinForms.ListBinding[] {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.Address")};

            textBoxCompany.Text = "";
            textBoxCompany.TabIndex = 1;
            textBoxCompany.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
            textBoxCompany.Size = new System.Drawing.Size(296, 20);
            textBoxCompany.Location = new System.Drawing.Point(88, 48);
            //textBoxCompany.Bindings.All = new System.WinForms.ListBinding[] {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.CompanyName")};

            panelVCRControl.BorderStyle = System.WinForms.BorderStyle.FixedSingle;
            panelVCRControl.Location = new System.Drawing.Point(88, 288);
            panelVCRControl.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            panelVCRControl.Size = new System.Drawing.Size(360, 48);
            panelVCRControl.TabIndex = 8;
            panelVCRControl.Anchor = System.WinForms.AnchorStyles.BottomLeftRight;
            panelVCRControl.Text = "panel1";

            comboBoxState.Text = "";
            comboBoxState.TabIndex = 6;
            comboBoxState.Size = new System.Drawing.Size(176, 20);
            comboBoxState.Location = new System.Drawing.Point(88, 208);
            //comboBoxState.Bindings.All = new System.WinForms.ListBinding[] {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.Region")};

            labelAddress.Size = new System.Drawing.Size(64, 16);
            labelAddress.Location = new System.Drawing.Point(16, 144);
            labelAddress.TabIndex = 9;
            labelAddress.Text = "Address:";

            labelID.Size = new System.Drawing.Size(64, 16);
            labelID.Location = new System.Drawing.Point(16, 16);
            labelID.TabIndex = 5;
            labelID.Text = "ID:";

            textBoxContact.Text = "";
            textBoxContact.TabIndex = 2;
            textBoxContact.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
            textBoxContact.Size = new System.Drawing.Size(339, 20);
            textBoxContact.Location = new System.Drawing.Point(88, 80);
            //textBoxContact.Bindings.All = new System.WinForms.ListBinding[] {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.ContactName")};

            buttonMoveLast.Location = new System.Drawing.Point(320, 8);
            buttonMoveLast.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonMoveLast.Size = new System.Drawing.Size(32, 32);
            buttonMoveLast.TabIndex = 3;
            buttonMoveLast.Anchor = System.WinForms.AnchorStyles.TopRight;
            buttonMoveLast.Text = ">|";
            buttonMoveLast.Click += new System.EventHandler(buttonMoveLast_Click);

            textBoxZip.Text = "";
            textBoxZip.TabIndex = 7;
            textBoxZip.Size = new System.Drawing.Size(112, 20);
            textBoxZip.Location = new System.Drawing.Point(88, 240);
            //textBoxZip.Bindings.All = new System.WinForms.ListBinding[] {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.PostalCode")};

            panelVCRControl.Controls.Add(textBoxPosition);
            panelVCRControl.Controls.Add(buttonMoveFirst);
            panelVCRControl.Controls.Add(buttonMovePrev);
            panelVCRControl.Controls.Add(buttonMoveNext);
            panelVCRControl.Controls.Add(buttonMoveLast);
            this.Controls.Add(textBoxZip);
            this.Controls.Add(comboBoxState);
            this.Controls.Add(textBoxCity);
            this.Controls.Add(labelState);
            this.Controls.Add(labelZip);
            this.Controls.Add(labelCity);
            this.Controls.Add(panelVCRControl);
            this.Controls.Add(textBoxCompany);
            this.Controls.Add(labelCompanyName);
            this.Controls.Add(textBoxAddress);
            this.Controls.Add(textBoxTitle);
            this.Controls.Add(textBoxContact);
            this.Controls.Add(textBoxID);
            this.Controls.Add(labelAddress);
            this.Controls.Add(labelContactTitle);
            this.Controls.Add(labelContact);
            this.Controls.Add(labelID);
        }

        public static void Main(string[] args) {
            Application.Run(new ComboBoxBinding());
        }

    }
}

















