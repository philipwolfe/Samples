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
namespace Microsoft.Samples.WinForms.Cs.Data.Update {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;
    using System.Data;
    using System.Data.ADO;
    using System.IO;

    //Proxies to WebServices
    using ListCustomers;
    using UpdateCustomers;

    public class UpdateForm : System.WinForms.Form {
        private System.ComponentModel.Container components;
	    private System.WinForms.Label labelCountry;
	    private System.WinForms.TextBox textBoxCountry;
	    private System.WinForms.ErrorProvider errorProvider1;
    	private System.WinForms.StatusBar statusBar1;
    	private System.WinForms.Button buttonClose;
	    private System.WinForms.Button buttonNew;
	    private System.WinForms.Button buttonDiscard;
	    private System.WinForms.Button buttonDiscardAll;
	    private System.WinForms.Button buttonSave;
	    private System.WinForms.Button buttonLoad;
	    private Microsoft.Samples.WinForms.Cs.Data.Update.Data.CustomersDataSet customersDataSet1;
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
        
        private State[] States  = new State[] { 
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

        //Used to determine form state
        private bool dataSetHasChanges=false;
        private bool addingNew=false;

        public UpdateForm() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();

            //Set up the Combobox bindings
            comboBoxState.DataSource=States;            //Populate the list
            comboBoxState.DisplayMember="LongName";     //Define the field to be displayed
            comboBoxState.ValueMember="ShortName";      //Define the field to be used as the value

            //Bind the selected value of the the combobox to the Region field of the current
            //Customer
            comboBoxState.Bindings.Add("SelectedValue", customersDataSet1, "Customers.Region");

            //Set up the rest of the form bindings
            textBoxID.Bindings.Add("Text", customersDataSet1, "Customers.CustomerID");
            textBoxTitle.Bindings.Add("Text", customersDataSet1, "Customers.ContactTitle");
            textBoxAddress.Bindings.Add("Text", customersDataSet1, "Customers.Address");
            textBoxCity.Bindings.Add("Text", customersDataSet1, "Customers.City");
            textBoxCompany.Bindings.Add("Text", customersDataSet1, "Customers.CompanyName");
            textBoxContact.Bindings.Add("Text", customersDataSet1, "Customers.ContactName");
            textBoxZip.Bindings.Add("Text", customersDataSet1, "Customers.PostalCode");
            textBoxCountry.Bindings.Add("Text", customersDataSet1, "Customers.Country");
            
            //We want to handle position changing events for the DATA VCR Panel
            //Position is managed by the Form's BindingManager so hook the position changed
            //event on the BindingManager
            this.BindingManager[customersDataSet1, "Customers"].PositionChanged += new System.EventHandler(customers_PositionChanged);

            //Set the minimum form size 
            this.MinTrackSize = new Size(544, 380);
        }

        //*** Methods

        //Load the CustomersDataSet using the ListCustomers WebService
        private void LoadData() {

           //Make sure that we don't fire column changing events whilst we are loading the data
           this.customersDataSet1.Customers.ColumnChanging -=
                                new DataColumnChangeEventHandler(customers_ColumnChanging);

           //Execute the WebService to return a DataSet 
           ListCustomers custList1 = new ListCustomers();
           DataSet ds1 = custList1.GetCustomers();

           //Merge the new dataset into our customersDataSet
           customersDataSet1.Merge(ds1);

           //Make sure that the dataset is in "original" state
           customersDataSet1.AcceptChanges();

           //We want to know when any data fields have changed so hook the column changing 
           //event
           this.customersDataSet1.Customers.ColumnChanging += new DataColumnChangeEventHandler(customers_ColumnChanging);

           //Workaround - Error Provider DataSource and DataMember must be set after loading the data
           errorProvider1.DataMember = "Customers";
           errorProvider1.DataSource = customersDataSet1;


        }

        //Save any changes back to the database via the UpdateCustomers WebService
        //The WebService will return a set of rows that reflect the state of the 
        //database on completion of the save operation
        private void SaveData() {

            //Clear all old errors in the Customers table before 
            //we attempt to save
            DataRow[] errorRows = customersDataSet1.Customers.GetErrors();
            foreach (DataRow row in errorRows) {
                row.ClearErrors();
            }

            //Get a dataset containing just the changes
            DataSet changes = customersDataSet1.GetChanges();

            //Execute the WebService to perform the update
            UpdateCustomers custUpdate1 = new UpdateCustomers();
            
            //Save the changes back to the database
            DataSet updatesDS = custUpdate1.Save(changes);

            //Merge any changes that came back form the server into our dataset
            customersDataSet1.Merge(updatesDS,false);

            // PDC work around
            errorProvider1.UpdateBinding();
        }

        //Update the state of the form based on the current state 
        //of the dataset
        void UpdateViewState() {

            //If we are adding a new record then allow the user to 
            //set the Customer ID
            if (addingNew) {
                textBoxID.Enabled=true;
                textBoxID.ReadOnly=false;
            } else {
                textBoxID.Enabled=false;
                textBoxID.ReadOnly=true;
            }

            //If we have a DataSet with data in it then disable the 
            //Load button and enable all the update buttons
            //Also change the default button for the Form to be the 
            //Save Button
            if (customersDataSet1.Customers.Count != 0) {
                buttonLoad.Enabled=false;
                buttonNew.Enabled=true;
                buttonLoad.Enabled=false;
                buttonSave.Enabled=true;
                buttonDiscard.Enabled=true;
                buttonDiscardAll.Enabled=true;
                this.AcceptButton=buttonSave;
            }

            //If the dataset has changed then update the status bar
            if (dataSetHasChanges)
                statusBar1.Text ="Data has changed";
            else
                statusBar1.Text ="Customers";
        }


        //*** Event Handlers

        //Handle the Close Button Click
        protected void buttonClose_Click(object sender, System.EventArgs e) {
            this.Close();
        }


        //Handle the Discard Button Click - this discards only changes to the 
        //current item
        protected void buttonDiscard_Click(object sender, System.EventArgs e) {
            
            //Reset the item currently being edited
            this.BindingManager[customersDataSet1, "Customers"].CancelCurrentEdit();
            addingNew=false;
            
            //Clear errors
            DataRowView currentRowView = (DataRowView)(this.BindingManager[customersDataSet1, "Customers"].Current);
            currentRowView.Row.ClearErrors();

            //Update the state of the view
            UpdateViewState();
        }


        //Handle the Discard All Button Click - cancels all changes in the dataset
        protected void buttonDiscardAll_Click(object sender, System.EventArgs e) {
            
            //Reset the item currently being edited
            this.BindingManager[customersDataSet1, "Customers"].CancelCurrentEdit();
            
            //Clear all old errors
            DataRow[] errorRows = customersDataSet1.Customers.GetErrors();
            foreach (DataRow row in errorRows) {
                row.ClearErrors();
            }

            // PDC work around
            errorProvider1.UpdateBinding();


            //Reset the dataset
            customersDataSet1.RejectChanges();
            dataSetHasChanges = false;
            addingNew=false;

            //Update the state of the view
            UpdateViewState();
        }


        //Handle the Load Button Click
        protected void buttonLoad_Click(object sender, System.EventArgs e) {

            Cursor currentCursor = Cursor.Current;
            try {
                Cursor.Current = Cursors.WaitCursor;

                statusBar1.Text ="Loading Customers...";

                //Load the customers
                LoadData();

                //Update the state of the view
                UpdateViewState();
                
                //Set up the initial text for the DATA VCR Panel
                textBoxPosition.Text = "Record " + (this.BindingManager[customersDataSet1, "Customers"].Position + 1) + " of " + customersDataSet1.Customers.Count;

            } finally {
                Cursor.Current = currentCursor;
                statusBar1.Text ="Done";
            }

        }

        
        //When the MoveFirst button is clicked set the position for Customers
        //to the first record
        protected void buttonMoveFirst_Click(object sender, System.EventArgs e) {
            this.BindingManager[customersDataSet1, "Customers"].Position = 0 ;
        }


        //When the MoveLast button is clicked set the position for Customers
        //to the last record
        protected void buttonMoveLast_Click(object sender, System.EventArgs e) {
            this.BindingManager[customersDataSet1, "Customers"].Position = customersDataSet1.Customers.Count - 1;
        }


        //When the MoveNext button is clicked increment the position for Customers
        protected void buttonMoveNext_Click(object sender, System.EventArgs e) {
            if (this.BindingManager[customersDataSet1, "Customers"].Position < customersDataSet1.Customers.Count - 1) {
                this.BindingManager[customersDataSet1, "Customers"].Position++;
            }
        }


        //When the MovePrev button is clicked decrement the position for Customers
        protected void buttonMovePrev_Click(object sender, System.EventArgs e) {
            if (this.BindingManager[customersDataSet1, "Customers"].Position > 0) {
                this.BindingManager[customersDataSet1, "Customers"].Position--;
            }
        }

        
        //Handle the New Button Click
        protected void buttonNew_Click(object sender, System.EventArgs e) {
            
            //Ask the BindingManager to create a new record 
            this.BindingManager[customersDataSet1, "Customers"].AddNew();

            //Update the state of the view
            addingNew=true;
            UpdateViewState();
        }


        //Handle the Save Button Click
        protected void buttonSave_Click(object sender, System.EventArgs e) {

            Cursor currentCursor = Cursor.Current;
            try {
                Cursor.Current = Cursors.WaitCursor;

                statusBar1.Text ="Saving Customers...";

                //Make sure we've flushed any changes in the current row back into the 
                //dataset
                this.BindingManager[customersDataSet1, "Customers"].EndCurrentEdit();

                //If the dataset has changes then save them
                if (dataSetHasChanges) {

                    //Save the changes to the dataset
                    this.SaveData();

                    //Check for errors - if there are none accept the changes
                    if (customersDataSet1.HasErrors) {

                        DataRow[] errorRows = customersDataSet1.Customers.GetErrors();
                        StringWriter sw = new StringWriter();
                        sw.WriteLine("Your changes were not saved. Examine the individual records for detailed information. Errors occurred in the following records:\n");

                        foreach (DataRow row in errorRows) {
                            sw.Write(row["CompanyName"]);
                            sw.Write(" - ");
                            sw.WriteLine(row.RowError);
                        }

                        MessageBox.Show(sw.ToString(), "Save Failed", MessageBox.IconError);

                    } else {
                        //Accept all the changes - this puts all the rows in the dataset 
                        //back into unchanged or "Original" state
                        customersDataSet1.AcceptChanges();
                        dataSetHasChanges=false;
                    }

                    //Update the view state 
                    UpdateViewState();
                }

            } catch (Exception ex) {
                MessageBox.Show("Save Failed:\n\n" + ex.ToString(), "Save Failed", MessageBox.IconError);
            } finally {
                Cursor.Current = currentCursor;
                statusBar1.Text ="Done";
            }

        }

        //Handle the column changing event on the Customers table
        //We use this to determine whether any changes have been made to 
        //the dataset
        protected void customers_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e) {
            dataSetHasChanges = true;
            UpdateViewState();
        }

        //Position has changed - update the DATA VCR panel
        protected void customers_PositionChanged(object sender, System.EventArgs e) {
            textBoxPosition.Text = "Record " + (this.BindingManager[customersDataSet1, "Customers"].Position + 1) + " of " + customersDataSet1.Customers.Count;
        }

        //The form is closing - if there are unsaved changed then confirm that this is OK
      	protected void UpdateForm_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            
            //Make sure we've flushed any changes in the current row back into the 
            //dataset
            this.BindingManager[customersDataSet1, "Customers"].EndCurrentEdit();

            if (dataSetHasChanges) {
		        DialogResult res = MessageBox.Show(  "Do you want to save your changes?"
                                                   , "Changes not Saved"
                                                   , MessageBox.YesNoCancel|MessageBox.IconWarning);

                if (res==DialogResult.Yes || res==DialogResult.Cancel) {
                    //If the user chose Save or Cancel then cancel the form close
                    e.Cancel=true;
                }
            }
	    }

        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        protected void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.textBoxAddress = new System.WinForms.TextBox();
            this.labelContactTitle = new System.WinForms.Label();
            this.comboBoxState = new System.WinForms.ComboBox();
            this.textBoxCountry = new System.WinForms.TextBox();
            this.panelVCRControl = new System.WinForms.Panel();
            this.textBoxID = new System.WinForms.TextBox();
            this.labelCountry = new System.WinForms.Label();
            this.statusBar1 = new System.WinForms.StatusBar();
            this.errorProvider1 = new System.WinForms.ErrorProvider();
            this.buttonNew = new System.WinForms.Button();
            this.buttonDiscardAll = new System.WinForms.Button();
            this.labelCity = new System.WinForms.Label();
            this.labelState = new System.WinForms.Label();
            this.buttonSave = new System.WinForms.Button();
            this.buttonDiscard = new System.WinForms.Button();
            this.labelID = new System.WinForms.Label();
            this.labelCompanyName = new System.WinForms.Label();
            this.textBoxTitle = new System.WinForms.TextBox();
            this.textBoxCompany = new System.WinForms.TextBox();
            this.buttonMoveLast = new System.WinForms.Button();
            this.textBoxCity = new System.WinForms.TextBox();
            this.buttonMovePrev = new System.WinForms.Button();
            this.customersDataSet1 = new Microsoft.Samples.WinForms.Cs.Data.Update.Data.CustomersDataSet();
            this.labelContact = new System.WinForms.Label();
            this.buttonLoad = new System.WinForms.Button();
            this.buttonMoveFirst = new System.WinForms.Button();
            this.labelAddress = new System.WinForms.Label();
            this.textBoxPosition = new System.WinForms.TextBox();
            this.buttonMoveNext = new System.WinForms.Button();
            this.textBoxZip = new System.WinForms.TextBox();
            this.labelZip = new System.WinForms.Label();
            this.textBoxContact = new System.WinForms.TextBox();
            this.buttonClose = new System.WinForms.Button();

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.Text = "Customer Details";
            //@design this.TrayLargeIcon = true;
            this.AcceptButton = buttonLoad;
            //@design this.TrayHeight = 93;
            this.ClientSize = new System.Drawing.Size(544, 357);
            this.Closing += new System.ComponentModel.CancelEventHandler(UpdateForm_Closing);

            textBoxAddress.Location = new System.Drawing.Point(88, 144);
            textBoxAddress.Text="";
            textBoxAddress.Anchor = System.WinForms.AnchorStyles.All;
            textBoxAddress.AcceptsReturn = true;
            textBoxAddress.TabIndex = 4;
            textBoxAddress.Size = new System.Drawing.Size(344, 20);

            labelContactTitle.Location = new System.Drawing.Point(16, 112);
            labelContactTitle.Text = "Title:";
            labelContactTitle.Size = new System.Drawing.Size(64, 16);
            labelContactTitle.TabIndex = 8;

            comboBoxState.Text="";
            comboBoxState.Location = new System.Drawing.Point(88, 208);
            comboBoxState.Size = new System.Drawing.Size(176, 21);
            comboBoxState.TabIndex = 6;

            textBoxCountry.Location = new System.Drawing.Point(288, 240);
            textBoxCountry.Text="";
            textBoxCountry.TabIndex = 20;
            textBoxCountry.Size = new System.Drawing.Size(112, 20);

            panelVCRControl.Location = new System.Drawing.Point(32, 280);
            panelVCRControl.Text = "panel1";
            panelVCRControl.Anchor = System.WinForms.AnchorStyles.BottomLeftRight;
            panelVCRControl.Size = new System.Drawing.Size(488, 48);
            panelVCRControl.BorderStyle = System.WinForms.BorderStyle.FixedSingle;
            panelVCRControl.TabIndex = 8;

            textBoxID.Location = new System.Drawing.Point(88, 16);
            textBoxID.Text="";
            textBoxID.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
            textBoxID.Enabled = false;
            textBoxID.ReadOnly = true;
            textBoxID.TabIndex = 0;
            textBoxID.Size = new System.Drawing.Size(168, 20);

            labelCountry.Location = new System.Drawing.Point(232, 242);
            labelCountry.Text = "Country:";
            labelCountry.Size = new System.Drawing.Size(56, 16);
            labelCountry.TabIndex = 21;

            statusBar1.BackColor = System.Drawing.SystemColors.Control;
            statusBar1.Location = new System.Drawing.Point(0, 337);
            statusBar1.Size = new System.Drawing.Size(544, 20);
            statusBar1.TabIndex = 19;
            statusBar1.Text = "Click on Load";

            errorProvider1.ContainerControl = this;
            //@design errorProvider1.SetLocation(new System.Drawing.Point(125, 7));

            buttonNew.Location = new System.Drawing.Point(448, 88);
            buttonNew.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonNew.Size = new System.Drawing.Size(80, 32);
            buttonNew.TabIndex = 17;
            buttonNew.Anchor = System.WinForms.AnchorStyles.TopRight;
            buttonNew.Enabled = false;
            buttonNew.Text = "&New";
            buttonNew.Click += new System.EventHandler(buttonNew_Click);

            buttonDiscardAll.Location = new System.Drawing.Point(448, 168);
            buttonDiscardAll.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonDiscardAll.Size = new System.Drawing.Size(80, 32);
            buttonDiscardAll.TabIndex = 17;
            buttonDiscardAll.Anchor = System.WinForms.AnchorStyles.TopRight;
            buttonDiscardAll.Enabled = false;
            buttonDiscardAll.Text = "Discard &All";
            buttonDiscardAll.Click += new System.EventHandler(buttonDiscardAll_Click);

            labelCity.Location = new System.Drawing.Point(16, 176);
            labelCity.Text = "City:";
            labelCity.Size = new System.Drawing.Size(64, 16);
            labelCity.TabIndex = 11;

            labelState.Location = new System.Drawing.Point(16, 208);
            labelState.Text = "State:";
            labelState.Size = new System.Drawing.Size(64, 16);
            labelState.TabIndex = 13;

            buttonSave.Location = new System.Drawing.Point(448, 48);
            buttonSave.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonSave.Size = new System.Drawing.Size(80, 32);
            buttonSave.TabIndex = 15;
            buttonSave.Anchor = System.WinForms.AnchorStyles.TopRight;
            buttonSave.Enabled = false;
            buttonSave.Text = "&Save";
            buttonSave.Click += new System.EventHandler(buttonSave_Click);

            buttonDiscard.Location = new System.Drawing.Point(448, 128);
            buttonDiscard.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonDiscard.Size = new System.Drawing.Size(80, 32);
            buttonDiscard.TabIndex = 16;
            buttonDiscard.Anchor = System.WinForms.AnchorStyles.TopRight;
            buttonDiscard.Enabled = false;
            buttonDiscard.Text = "&Discard";
            buttonDiscard.Click += new System.EventHandler(buttonDiscard_Click);

            labelID.Location = new System.Drawing.Point(16, 16);
            labelID.Text = "ID:";
            labelID.Size = new System.Drawing.Size(64, 16);
            labelID.TabIndex = 5;

            labelCompanyName.Location = new System.Drawing.Point(16, 48);
            labelCompanyName.Text = "Company:";
            labelCompanyName.Size = new System.Drawing.Size(64, 16);
            labelCompanyName.TabIndex = 6;

            textBoxTitle.Location = new System.Drawing.Point(88, 112);
            textBoxTitle.Text="";
            textBoxTitle.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
            textBoxTitle.TabIndex = 3;
            textBoxTitle.Size = new System.Drawing.Size(264, 20);

            textBoxCompany.Location = new System.Drawing.Point(88, 48);
            textBoxCompany.Text="";
            textBoxCompany.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
            textBoxCompany.TabIndex = 1;
            textBoxCompany.Size = new System.Drawing.Size(304, 20);

            buttonMoveLast.Location = new System.Drawing.Point(446, 8);
            buttonMoveLast.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonMoveLast.Size = new System.Drawing.Size(32, 32);
            buttonMoveLast.TabIndex = 3;
            buttonMoveLast.Anchor = System.WinForms.AnchorStyles.TopRight;
            buttonMoveLast.Font = new System.Drawing.Font("Tahoma", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            buttonMoveLast.Text = ">|";
            buttonMoveLast.Click += new System.EventHandler(buttonMoveLast_Click);

            textBoxCity.Location = new System.Drawing.Point(88, 176);
            textBoxCity.Text="";
            textBoxCity.TabIndex = 5;
            textBoxCity.Size = new System.Drawing.Size(216, 20);

            buttonMovePrev.Location = new System.Drawing.Point(48, 8);
            buttonMovePrev.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonMovePrev.Size = new System.Drawing.Size(32, 32);
            buttonMovePrev.TabIndex = 1;
            buttonMovePrev.Font = new System.Drawing.Font("Tahoma", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            buttonMovePrev.Text = "<";
            buttonMovePrev.Click += new System.EventHandler(buttonMovePrev_Click);

            //@design customersDataSet1.SetLocation(new System.Drawing.Point(7, 7));
            customersDataSet1.DataSetName = "CustomersDataSet";

            labelContact.Location = new System.Drawing.Point(16, 80);
            labelContact.Text = "Contact:";
            labelContact.Size = new System.Drawing.Size(64, 16);
            labelContact.TabIndex = 7;

            buttonLoad.Location = new System.Drawing.Point(448, 8);
            buttonLoad.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonLoad.Size = new System.Drawing.Size(80, 32);
            buttonLoad.TabIndex = 14;
            buttonLoad.Anchor = System.WinForms.AnchorStyles.TopRight;
            buttonLoad.Text = "&Load";
            buttonLoad.Click += new System.EventHandler(buttonLoad_Click);

            buttonMoveFirst.Location = new System.Drawing.Point(8, 8);
            buttonMoveFirst.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonMoveFirst.Size = new System.Drawing.Size(32, 32);
            buttonMoveFirst.TabIndex = 0;
            buttonMoveFirst.Font = new System.Drawing.Font("Tahoma", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            buttonMoveFirst.Text = "|<";
            buttonMoveFirst.Click += new System.EventHandler(buttonMoveFirst_Click);

            labelAddress.Location = new System.Drawing.Point(16, 144);
            labelAddress.Text = "Address:";
            labelAddress.Size = new System.Drawing.Size(64, 16);
            labelAddress.TabIndex = 9;

            textBoxPosition.Location = new System.Drawing.Point(88, 13);
            textBoxPosition.Text="";
            textBoxPosition.Anchor = System.WinForms.AnchorStyles.LeftRight;
            textBoxPosition.BorderStyle = System.WinForms.BorderStyle.FixedSingle;
            textBoxPosition.Enabled = false;
            textBoxPosition.ReadOnly = true;
            textBoxPosition.TabIndex = 1;
            textBoxPosition.Size = new System.Drawing.Size(310, 20);

            buttonMoveNext.Location = new System.Drawing.Point(406, 8);
            buttonMoveNext.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonMoveNext.Size = new System.Drawing.Size(32, 32);
            buttonMoveNext.TabIndex = 2;
            buttonMoveNext.Anchor = System.WinForms.AnchorStyles.TopRight;
            buttonMoveNext.Font = new System.Drawing.Font("Tahoma", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            buttonMoveNext.Text = ">";
            buttonMoveNext.Click += new System.EventHandler(buttonMoveNext_Click);

            textBoxZip.Location = new System.Drawing.Point(88, 240);
            textBoxZip.Text="";
            textBoxZip.TabIndex = 7;
            textBoxZip.Size = new System.Drawing.Size(112, 20);

            labelZip.Location = new System.Drawing.Point(16, 240);
            labelZip.Text = "Zip:";
            labelZip.Size = new System.Drawing.Size(64, 16);
            labelZip.TabIndex = 12;

            textBoxContact.Location = new System.Drawing.Point(88, 80);
            textBoxContact.Text="";
            textBoxContact.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
            textBoxContact.TabIndex = 2;
            textBoxContact.Size = new System.Drawing.Size(304, 20);

            buttonClose.Location = new System.Drawing.Point(448, 204);
            buttonClose.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonClose.Size = new System.Drawing.Size(80, 32);
            buttonClose.TabIndex = 18;
            buttonClose.Anchor = System.WinForms.AnchorStyles.TopRight;
            buttonClose.Text = "Close";
            buttonClose.Click += new System.EventHandler(buttonClose_Click);

            panelVCRControl.Controls.Add(textBoxPosition);
            panelVCRControl.Controls.Add(buttonMoveFirst);
            panelVCRControl.Controls.Add(buttonMovePrev);
            panelVCRControl.Controls.Add(buttonMoveNext);
            panelVCRControl.Controls.Add(buttonMoveLast);
            this.Controls.Add(labelCountry);
            this.Controls.Add(textBoxCountry);
            this.Controls.Add(statusBar1);
            this.Controls.Add(buttonClose);
            this.Controls.Add(buttonNew);
            this.Controls.Add(buttonDiscard);
            this.Controls.Add(buttonDiscardAll);
            this.Controls.Add(buttonSave);
            this.Controls.Add(buttonLoad);
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
            Application.Run(new UpdateForm());
        }

    }

}




