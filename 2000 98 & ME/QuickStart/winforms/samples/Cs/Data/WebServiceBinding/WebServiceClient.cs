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
namespace Microsoft.Samples.WinForms.Cs.WebServiceClient {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;

    using System.Data;
    using System.Data.ADO;
    using SimpleWebService;

    using System.Net;
    using System.IO;


    public class WebServiceClient : System.WinForms.Form {
        private System.ComponentModel.Container components;
    	private System.WinForms.StatusBar statusBar1;
    	private Microsoft.Samples.WinForms.Cs.WebServiceBinding.Data.CustomersDataSet customersDataSet1;
    	private System.WinForms.Button buttonLoad;
    	private System.WinForms.DataGrid dataGrid1;
	    
        public WebServiceClient() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();
        }

        protected void buttonLoad_Click(object sender, System.EventArgs e) {
            Cursor currentCursor = Cursor.Current;
            try {
                Cursor.Current = Cursors.WaitCursor;
                
                statusBar1.Text ="Loading Customers...";
                
                //Execute the WebService to return a DataSet 
                CustomersList custList1 = new CustomersList();
                DataSet ds1 = custList1.GetCustomers();

                //Merge the new dataset into our customersDataSet
                customersDataSet1.Merge(ds1);

                statusBar1.Text ="Updating Grid...";
                dataGrid1.PopulateColumns();
                
            } finally {
                Cursor.Current = currentCursor;
                statusBar1.Text ="Done";
            }
        }


        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.dataGrid1 = new System.WinForms.DataGrid();
            this.statusBar1 = new System.WinForms.StatusBar();
            this.customersDataSet1 = new Microsoft.Samples.WinForms.Cs.WebServiceBinding.Data.CustomersDataSet();
            this.buttonLoad = new System.WinForms.Button();

            dataGrid1.BeginInit();

            dataGrid1.Text = "dataGrid1";
            dataGrid1.PreferredRowHeight = 16;
            dataGrid1.Size = new System.Drawing.Size(584, 336);
            dataGrid1.DataSource = customersDataSet1;
            dataGrid1.DataMember = "Customers";
            dataGrid1.ForeColor = System.Drawing.Color.Navy;
            dataGrid1.TabIndex = 0;
            dataGrid1.Anchor = System.WinForms.AnchorStyles.All;
            dataGrid1.Location = new System.Drawing.Point(8, 8);
            dataGrid1.BackColor = System.Drawing.Color.Gainsboro;
            dataGrid1.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.Text = "Customer Details";
            this.AcceptButton = buttonLoad;
            this.ClientSize = new System.Drawing.Size(600, 413);

            statusBar1.BackColor = System.Drawing.SystemColors.Control;
            statusBar1.Size = new System.Drawing.Size(600, 16);
            statusBar1.TabIndex = 2;
            statusBar1.Text = "Click on Load";
            statusBar1.Location = new System.Drawing.Point(0, 397);

            //@design customersDataSet1.SetLocation(new System.Drawing.Point(7, 7));
            customersDataSet1.DataSetName = "CustomersDataSet";

            buttonLoad.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonLoad.Size = new System.Drawing.Size(112, 32);
            buttonLoad.TabIndex = 1;
            buttonLoad.Anchor = System.WinForms.AnchorStyles.BottomRight;
            buttonLoad.Text = "&Load";
            buttonLoad.Location = new System.Drawing.Point(480, 352);
            buttonLoad.Click += new System.EventHandler(buttonLoad_Click);

            this.Controls.Add(statusBar1);
            this.Controls.Add(buttonLoad);
            this.Controls.Add(dataGrid1);

            dataGrid1.EndInit();
        }


        public static void Main(string[] args) {
            Application.Run(new WebServiceClient());
        }

    }
}






















