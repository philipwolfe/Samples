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
Imports System.IO

Imports System.Data
Imports CustomersAndOrdersWebService

Namespace Microsoft.Samples.WinForms.VB.MasterDetails 

public class CustomersForm 
    Inherits System.WinForms.Form 
	    
    private components As System.ComponentModel.Container 
    private customersAndOrdersDataSet1 As Microsoft.Samples.WinForms.VB.MasterDetails.Data.CustomersAndOrdersDataSet
	private statusBar1 As System.WinForms.StatusBar 
	private buttonLoad As System.WinForms.Button    
	private buttonUpdate As System.WinForms.Button    
	private dataGrid2 As System.WinForms.DataGrid  
	private dataGrid1 As System.WinForms.DataGrid  
        

    Public Sub New() 
        MyBase.New
        
        'Required for Win Form Designer support
        InitializeComponent()
        
    End Sub

    Private Sub LoadData() 
    
        Dim currentCursor as Cursor = Cursor.Current
        Try
            Cursor.Current = Cursors.WaitCursor

            statusBar1.Text ="Loading Customers..."

            'Execute the WebService to return a DataSet 
            Dim custList1 As New CustomersAndOrders
            Dim ds1 As DataSet = custList1.GetCustomersAndOrders()

            'Merge the new dataset into our customersDataSet
            customersAndOrdersDataSet1.Merge(ds1)

            statusBar1.Text ="Updating Grid..."

            dataGrid1.PopulateColumns()
            dataGrid2.PopulateColumns()
        
        Finally
            Cursor.Current = currentCursor
            statusBar1.Text ="Done"
        End Try
       

    End Sub


    Protected Sub buttonLoad_Click(sender As object, e As System.EventArgs) 
        LoadData()
    End Sub


    Protected Sub buttonUpdate_Click(sender As object, e As System.EventArgs) 
        Dim currentCursor as Cursor = Cursor.Current
        Try
            Cursor.Current = Cursors.WaitCursor
            
            Me.BindingManager(customersAndOrdersDataSet1, "Customers").EndCurrentEdit()

            statusBar1.Text ="Updating Customers..."
            Dim custList1 As New CustomersAndOrders

            Dim changesDS As DataSet = customersAndOrdersDataSet1.GetChanges()

            if (changesDS <> Nothing) Then
                'Execute the WebService to update the DataSet 
                Dim ds1 As DataSet = custList1.UpdateCustomersAndOrders(changesDS)
                statusBar1.Text = "Updating Grid..."
                
                customersAndOrdersDataSet1.Merge(ds1,false)
                
                'Check for errors - if there are none accept the changes
                If (customersAndOrdersDataSet1.HasErrors) Then
                    MessageBox.Show("Save Failed - examine the row errors for details", "Save Failed", MessageBox.IconError)
                Else
                    'Accept all the changes - this puts all the rows in the dataset 
                    'back into unchanged or "Original" state
                    customersAndOrdersDataSet1.AcceptChanges()
                End If 
                
            End If 

        Catch ex As Exception 
            Dim sw As StringWriter = new StringWriter()
            sw.WriteLine("Save Failed:")
            sw.WriteLine("")
            sw.WriteLine(ex.ToString())
            MessageBox.Show(sw.ToString(), "Save Failed", MessageBox.IconError)
        
        Finally
        
            Cursor.Current = currentCursor
            statusBar1.Text ="Done"
            
        End Try
        
    End Sub

    'Clean up any resources being used
    Overrides Public Sub Dispose()
        MyBase.Dispose
        components.Dispose
    End Sub 

    private Sub InitializeComponent() 
        Me.components = new System.ComponentModel.Container()
		Me.dataGrid2 = new System.WinForms.DataGrid()
		Me.customersAndOrdersDataSet1 = new  Microsoft.Samples.WinForms.VB.MasterDetails.Data.CustomersAndOrdersDataSet()
		Me.dataGrid1 = new System.WinForms.DataGrid()
		Me.buttonLoad = new System.WinForms.Button()
		Me.buttonUpdate = new System.WinForms.Button()
		Me.statusBar1 = new System.WinForms.StatusBar()

        dataGrid1.BeginInit()
        dataGrid2.BeginInit()
		
		dataGrid2.Location = new System.Drawing.Point(8, 256)
		dataGrid2.Text = "dataGrid2"
		dataGrid2.Size = new System.Drawing.Size(584, 248)
		dataGrid2.PreferredColumnWidth = 50
		dataGrid2.DataMember = ""
		dataGrid2.ForeColor = System.Drawing.SystemColors.WindowText
		dataGrid2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
		dataGrid2.TabIndex = 1
		dataGrid2.BackColor = System.Drawing.SystemColors.Window
		dataGrid2.DataSource = customersAndOrdersDataSet1
		dataGrid2.DataMember = "Customers.CustomersOrders"
        dataGrid2.Anchor = System.WinForms.AnchorStyles.All
		
		'@design customersAndOrdersDataSet1.SetLocation(new System.Drawing.Point(7, 7))
		customersAndOrdersDataSet1.DataSetName = "CustomersAndOrdersDataSet"
		
		dataGrid1.Location = new System.Drawing.Point(8, 8)
		dataGrid1.Text = "dataGrid1"
		dataGrid1.Size = new System.Drawing.Size(584, 240)
		dataGrid1.PreferredColumnWidth = 50
		dataGrid1.DataMember = ""
		dataGrid1.ForeColor = System.Drawing.SystemColors.WindowText
		dataGrid1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
		dataGrid1.TabIndex = 0
		dataGrid1.BackColor = System.Drawing.SystemColors.Window
        dataGrid1.NavigationMode = DataGridNavigationModes.None
		dataGrid1.DataSource = customersAndOrdersDataSet1
		dataGrid1.DataMember = "Customers"
        dataGrid1.Anchor = System.WinForms.AnchorStyles.All
		
		Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
		Me.Text = "Customer Orders"
		'@design Me.TrayLargeIcon = true
		'@design Me.TrayHeight = 93
		Me.ClientSize = new System.Drawing.Size(600, 581)
		
		buttonLoad.Location = new System.Drawing.Point(376, 512)
		buttonLoad.FlatStyle = System.WinForms.FlatStyle.Flat
		buttonLoad.Size = new System.Drawing.Size(104, 40)
		buttonLoad.TabIndex = 2
		buttonLoad.Text = "&Load"
        buttonLoad.Anchor = System.WinForms.AnchorStyles.BottomRight
        AddHandler buttonLoad.Click, new System.EventHandler(AddressOf buttonLoad_Click)

		buttonUpdate.Location = new System.Drawing.Point(488, 512)
		buttonUpdate.FlatStyle = System.WinForms.FlatStyle.Flat
		buttonUpdate.Size = new System.Drawing.Size(104, 40)
		buttonUpdate.TabIndex = 2
		buttonUpdate.Text = "&Update"
        buttonUpdate.Anchor = System.WinForms.AnchorStyles.BottomRight
        AddHandler buttonUpdate.Click, new System.EventHandler(AddressOf buttonUpdate_Click)
		
		statusBar1.Location = new System.Drawing.Point(0, 561)
		statusBar1.BackColor = System.Drawing.SystemColors.Control
		statusBar1.TabIndex = 3
		statusBar1.Text = "Click on Load"
		statusBar1.Size = new System.Drawing.Size(600, 20)
		
		Me.Controls.Add(statusBar1)
		Me.Controls.Add(buttonLoad)
		Me.Controls.Add(buttonUpdate)
		Me.Controls.Add(dataGrid1)		
		Me.Controls.Add(dataGrid2)
        
        dataGrid1.EndInit()
        dataGrid2.EndInit()
        
	End Sub

    'The main entry point for the application
    Shared Sub Main()
        System.WinForms.Application.Run(New CustomersForm())
    End Sub
             
             
    End Class

End Namespace



