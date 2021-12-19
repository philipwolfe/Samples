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
namespace  Microsoft.Samples.WinForms.Cs.MasterDetails {
    
    using System.ComponentModel;
    using System.Diagnostics;
    using System;
    using Microsoft.Samples.WinForms.Cs.Data.MasterDetails.Data;
    using System.WinForms;
    using System.Drawing;
    using System.Data;
    using System.Data.ADO;
    using CustomersAndOrdersWebService;
    using System.Web.Services.Protocols;

    public class CustomersForm : System.WinForms.Form {
    	private System.ComponentModel.Container components;
    	private CustomersAndOrdersDataSet customersAndOrdersDataSet1;
    	private System.WinForms.StatusBar statusBar1;
    	private System.WinForms.Button buttonLoad;
    	private System.WinForms.Button buttonUpdate;
    	private System.WinForms.DataGrid dataGrid2;
    	private System.WinForms.DataGrid dataGrid1;
            

        public CustomersForm() {

            // Required for Win Form Designer support
            InitializeComponent();

        }

        private void LoadData() {
            Cursor currentCursor = Cursor.Current;
            try {
                Cursor.Current = Cursors.WaitCursor;

                statusBar1.Text ="Loading Customers...";

                //Execute the WebService to return a DataSet 
                CustomersAndOrders custList1 = new CustomersAndOrders();
                DataSet ds1 = custList1.GetCustomersAndOrders();

                //Merge the new dataset into our customersDataSet
                customersAndOrdersDataSet1.Merge(ds1);

                statusBar1.Text ="Updating Grid...";

                dataGrid1.PopulateColumns();
                dataGrid2.PopulateColumns();

            } finally {
                Cursor.Current = currentCursor;
                statusBar1.Text ="Done";
            }
           

        }


        private void buttonLoad_Click(object sender, System.EventArgs e) {
            LoadData();
        }


        private void buttonUpdate_Click(object sender, System.EventArgs e) {
            Cursor currentCursor = Cursor.Current;
            try {
                this.BindingManager[customersAndOrdersDataSet1, "Customers"].EndCurrentEdit();

                Cursor.Current = Cursors.WaitCursor;
                statusBar1.Text ="Updating Customers...";
                CustomersAndOrders custList1 = new CustomersAndOrders();

                DataSet changesDS = customersAndOrdersDataSet1.GetChanges();

                if (changesDS != null) {
                    //Execute the WebService to update the DataSet 
                    DataSet ds1 = custList1.UpdateCustomersAndOrders(changesDS);
                    statusBar1.Text = "Updating Grid...";
                    customersAndOrdersDataSet1.Merge(ds1,false);
                    
                    //Check for errors - if there are none accept the changes
                    if (customersAndOrdersDataSet1.HasErrors) {
                        MessageBox.Show("Save Failed - examine the row errors for details", "Save Failed", MessageBox.IconError);
                    } else {
                        //Accept all the changes - this puts all the rows in the dataset 
                        //back into unchanged or "Original" state
                        customersAndOrdersDataSet1.AcceptChanges();

                    }
                }

            } catch(Exception ex) {
                MessageBox.Show("Save Failed:\n\n" + ex.ToString(), "Save Failed", MessageBox.IconError);
            } finally {
                Cursor.Current = currentCursor;
                statusBar1.Text ="Done";
            }
        }

        /**
         * CustomersForm overrides dispose so it can clean up the
         * component list.
         */
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }


        private void InitializeComponent() {
    		this.components = new System.ComponentModel.Container();
    		this.dataGrid2 = new System.WinForms.DataGrid();
    		this.customersAndOrdersDataSet1 = new Microsoft.Samples.WinForms.Cs.Data.MasterDetails.Data.CustomersAndOrdersDataSet();
    		this.dataGrid1 = new System.WinForms.DataGrid();
    		this.buttonLoad = new System.WinForms.Button();
    		this.buttonUpdate = new System.WinForms.Button();
    		this.statusBar1 = new System.WinForms.StatusBar();
    		
            dataGrid1.BeginInit();
            dataGrid2.BeginInit();

    		dataGrid2.Location = new System.Drawing.Point(8, 256);
    		dataGrid2.Text = "dataGrid2";
    		dataGrid2.Size = new System.Drawing.Size(584, 248);
    		dataGrid2.PreferredColumnWidth = 50;
    		dataGrid2.ForeColor = System.Drawing.SystemColors.WindowText;
    		dataGrid2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
    		dataGrid2.TabIndex = 1;
    		dataGrid2.BackColor = System.Drawing.SystemColors.Window;
    		dataGrid2.DataSource = customersAndOrdersDataSet1;
    		dataGrid2.DataMember = "Customers.CustomersOrders";
            dataGrid2.Anchor = System.WinForms.AnchorStyles.All;
    		
    		//@design customersAndOrdersDataSet1.SetLocation(new System.Drawing.Point(7, 7));
    		customersAndOrdersDataSet1.DataSetName = "CustomersAndOrdersDataSet";
    		
    		dataGrid1.Location = new System.Drawing.Point(8, 8);
    		dataGrid1.Text = "dataGrid1";
    		dataGrid1.Size = new System.Drawing.Size(584, 240);
    		dataGrid1.PreferredColumnWidth = 50;
    		dataGrid1.ForeColor = System.Drawing.SystemColors.WindowText;
    		dataGrid1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
    		dataGrid1.TabIndex = 0;
    		dataGrid1.BackColor = System.Drawing.SystemColors.Window;
            dataGrid1.NavigationMode = DataGridNavigationModes.None;
    		dataGrid1.DataSource = customersAndOrdersDataSet1;
    		dataGrid1.DataMember = "Customers";
            dataGrid1.Anchor = System.WinForms.AnchorStyles.All;
    		
    		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    		this.Text = "Customer Orders";
    		//@design this.TrayLargeIcon = true;
    		//@design this.TrayHeight = 93;
    		this.ClientSize = new System.Drawing.Size(600, 581);
    		
    		buttonLoad.Location = new System.Drawing.Point(376, 512);
    		buttonLoad.FlatStyle = System.WinForms.FlatStyle.Flat;
    		buttonLoad.Size = new System.Drawing.Size(104, 40);
    		buttonLoad.TabIndex = 2;
    		buttonLoad.Text = "&Load";
            buttonLoad.Anchor = System.WinForms.AnchorStyles.BottomRight;
            buttonLoad.Click += new System.EventHandler(buttonLoad_Click);

    		buttonUpdate.Location = new System.Drawing.Point(488, 512);
    		buttonUpdate.FlatStyle = System.WinForms.FlatStyle.Flat;
    		buttonUpdate.Size = new System.Drawing.Size(104, 40);
    		buttonUpdate.TabIndex = 2;
    		buttonUpdate.Text = "&Update";
            buttonUpdate.Anchor = System.WinForms.AnchorStyles.BottomRight;
            buttonUpdate.Click += new System.EventHandler(buttonUpdate_Click);
    		
    		statusBar1.Location = new System.Drawing.Point(0, 561);
    		statusBar1.BackColor = System.Drawing.SystemColors.Control;
    		statusBar1.TabIndex = 3;
    		statusBar1.Text = "Click on Load";
    		statusBar1.Size = new System.Drawing.Size(600, 20);
    		
    		this.Controls.Add(statusBar1);
    		this.Controls.Add(buttonLoad);
    		this.Controls.Add(buttonUpdate);
    		this.Controls.Add(dataGrid2);
    		this.Controls.Add(dataGrid1);		

            dataGrid1.EndInit();
            dataGrid2.EndInit();
    	}

        public static void Main(string[] args) {
            Application.Run(new CustomersForm());
        }
    }
}


