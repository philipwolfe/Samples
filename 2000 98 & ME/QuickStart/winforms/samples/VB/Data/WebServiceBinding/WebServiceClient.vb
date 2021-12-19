'------------------------------------------------------------------------------
'/ <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'/    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'/       
'/    This source code is intended only as a supplement to Microsoft
'/    Development Tools and/or on-line documentation.  See these other
'/    materials for detailed information regarding Microsoft code samples.
'/
'/ </copyright>                                                                
'------------------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms

Imports System.Data
Imports SimpleWebService

Imports Microsoft.Samples.WinForms.VB.WebServiceBinding.Data 

Namespace Microsoft.Samples.WinForms.VB.WebServiceClient 

    public class WebServiceClient 
        Inherits System.WinForms.Form 
        
        private components As System.ComponentModel.Container 
    	private statusBar1 As System.WinForms.StatusBar 
    	private buttonLoad As System.WinForms.Button 
    	private dataGrid1 As System.WinForms.DataGrid 
        private customersDataSet1 As Microsoft.Samples.WinForms.VB.WebServiceBinding.Data.CustomersDataSet
	    
        public Sub New() 
            MyBase.New
            
            ' Required by the Windows Forms Designer
            InitializeComponent()
        End Sub
                                             
        'Handle the Load Button Click
        'Load the Customers, Orders and OrderDetails Tables and display in the Grid
        Protected Sub buttonLoad_Click(sender As object, e As System.EventArgs) 
            Dim currentCursor As Cursor = Cursor.Current
            Try 
                Cursor.Current = Cursors.WaitCursor
                
                statusBar1.Text ="Loading Customers..."
                
                'Execute the WebService to return a DataSet 
                Dim custList1 As New CustomersList
                Dim ds1 As DataSet = custList1.GetCustomers()
                
                'Merge the new dataset into our customersDataSet
                customersDataSet1.Merge(ds1)

                statusBar1.Text ="Updating Grid..."
                dataGrid1.PopulateColumns()
                
            Finally 
                statusBar1.Text ="Done"
                Cursor.Current = currentCursor
            End Try
        End Sub

        'Clean up any resources being used
        Overrides Public Sub Dispose()
            MyBase.Dispose
            components.Dispose
        End Sub 

        private Sub InitializeComponent() 
            Me.components = new System.ComponentModel.Container()
            Me.dataGrid1 = new System.WinForms.DataGrid()
            Me.statusBar1 = new System.WinForms.StatusBar()
            Me.buttonLoad = new System.WinForms.Button()
            Me.customersDataSet1 = new Microsoft.Samples.WinForms.VB.WebServiceBinding.Data.CustomersDataSet()

            dataGrid1.BeginInit()

            dataGrid1.Text = "dataGrid1"
            dataGrid1.PreferredRowHeight = 16
            dataGrid1.Size = new System.Drawing.Size(584, 336)
            dataGrid1.ForeColor = System.Drawing.Color.Navy
            dataGrid1.TabIndex = 0
            dataGrid1.Anchor = System.WinForms.AnchorStyles.All
            dataGrid1.Location = new System.Drawing.Point(8, 8)
            dataGrid1.BackColor = System.Drawing.Color.Gainsboro
            dataGrid1.AlternatingBackColor = System.Drawing.Color.WhiteSmoke
            dataGrid1.DataSource = customersDataSet1
            dataGrid1.DataMember = "Customers"

            Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
            Me.Text = "Customer Details"
            Me.AcceptButton = buttonLoad
            Me.ClientSize = new System.Drawing.Size(600, 413)

            statusBar1.BackColor = System.Drawing.SystemColors.Control
            statusBar1.Size = new System.Drawing.Size(600, 16)
            statusBar1.TabIndex = 2
            statusBar1.Text = "Click on Load"
            statusBar1.Location = new System.Drawing.Point(0, 397)

            buttonLoad.FlatStyle = System.WinForms.FlatStyle.Flat
            buttonLoad.Size = new System.Drawing.Size(112, 32)
            buttonLoad.TabIndex = 1
            buttonLoad.Anchor = System.WinForms.AnchorStyles.BottomRight
            buttonLoad.Text = "&Load"
            buttonLoad.Location = new System.Drawing.Point(480, 352)
            AddHandler buttonLoad.Click, new System.EventHandler(AddressOf buttonLoad_Click)

            Me.Controls.Add(statusBar1)
            Me.Controls.Add(buttonLoad)
            Me.Controls.Add(dataGrid1)

            dataGrid1.EndInit()
        End Sub
        
        'The main entry point for the application
        Shared Sub Main()
            System.WinForms.Application.Run(New WebServiceClient())
        End Sub

    End Class
    
end Namespace