' ------------------------------------------------------------------------------
' / <copyright from='1997' to='2001' company='Microsoft Corporation'>           
' /    Copyright (c) Microsoft Corporation. All Rights Reserved.                
' /       
' /    This source code is intended only as a supplement to Microsoft
' /    Development Tools and/or on-line documentation.  See these other
' /    materials for detailed information regarding Microsoft code samples.
' /
' / </copyright>                                                                
' ------------------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms
Imports System.Data
Imports System.Data.SQL

namespace Microsoft.Samples.WinForms.VB.ComboBoxBinding 
    
	public class ComboBoxBinding
	Inherits Form
	 
	private components As System.ComponentModel.Container 
	private customersDataSet1 As Microsoft.Samples.WinForms.VB.ComboBoxBinding.Data.CustomersDataSet 
	private textBoxZip As System.WinForms.TextBox 
	private comboBoxUSState As System.WinForms.ComboBox 
	private textBoxCity As System.WinForms.TextBox 
	private labelUSState As System.WinForms.Label
	private labelZip As System.WinForms.Label 
	private labelCity As System.WinForms.Label 
	private textBoxPosition As System.WinForms.TextBox 
	private buttonMoveFirst As System.WinForms.Button
	private buttonMovePrev As System.WinForms.Button 
	private buttonMoveNext As System.WinForms.Button
	private buttonMoveLast As System.WinForms.Button 
	private textBoxCompany As System.WinForms.TextBox 
	private labelCompanyName As System.WinForms.Label
	private textBoxAddress As System.WinForms.TextBox 
	private textBoxTitle As System.WinForms.TextBox 
	private textBoxContact As System.WinForms.TextBox 
	private textBoxID As System.WinForms.TextBox 
	private labelAddress As System.WinForms.Label 
	private labelContactTitle As System.WinForms.Label 
	private labelContact As System.WinForms.Label 
	private labelID As System.WinForms.Label 
	private panelVCRControl As System.WinForms.Panel 

    ' Define the array of states for the drop-down list
    Public USStates() As USState = new USState(){ _
         new USState("Alabama","AL") _
        ,new USState("Alaska","AK") _
        ,new USState("Arizona" ,"AZ") _
        ,new USState("Arkansas","AR") _
        ,new USState("California" ,"CA") _
        ,new USState("Colorado","CO") _
        ,new USState("Connecticut","CT") _
        ,new USState("Delaware","DE") _
        ,new USState("District of Columbia","DC") _
        ,new USState("Florida" ,"FL") _
        ,new USState("Georgia" ,"GA") _
        ,new USState("Hawaii"  ,"HI") _
        ,new USState("Idaho","ID") _
        ,new USState("Illinois","IL") _
        ,new USState("Indiana" ,"IN") _
        ,new USState("Iowa","IA") _
        ,new USState("Kansas"  ,"KS") _
        ,new USState("Kentucky","KY") _
        ,new USState("Louisiana"  ,"LA") _
        ,new USState("Maine","ME") _
        ,new USState("Maryland","MD") _
        ,new USState("Massachusetts","MA") _
        ,new USState("Michigan","MI") _
        ,new USState("Minnesota"  ,"MN") _
        ,new USState("Mississippi","MS") _
        ,new USState("Missouri","MO") _
        ,new USState("Montana" ,"MT") _
        ,new USState("Nebraska","NE") _
        ,new USState("Nevada"  ,"NV") _
        ,new USState("New Hampshire","NH") _
        ,new USState("New Jersey" ,"NJ") _
        ,new USState("New Mexico" ,"NM") _
        ,new USState("New York","NY") _
        ,new USState("North Carolina","NC") _
        ,new USState("North Dakota" ,"ND") _
        ,new USState("Ohio","OH") _
        ,new USState("Oklahoma","OK") _
        ,new USState("Oregon"  ,"OR") _
        ,new USState("Pennsylvania" ,"PA") _
        ,new USState("Rhode Island" ,"RI") _
        ,new USState("South Carolina","SC") _
        ,new USState("South Dakota" ,"SD") _
        ,new USState("Tennessee"  ,"TN") _
        ,new USState("Texas","TX") _
        ,new USState("Utah","UT") _
        ,new USState("Vermont" ,"VT") _
        ,new USState("Virginia","VA") _
        ,new USState("Washington" ,"WA") _
        ,new USState("West Virginia","WV") _
        ,new USState("Wisconsin"  ,"WI") _
        ,new USState("Wyoming" ,"WY") }                                        

    Shared Sub Main() 
        Application.Run(new ComboBoxBinding())
    End Sub


	public Sub New() 
        MyBase.New()
            
        '  Required by the Windows Forms Designer
        InitializeComponent()

        ' Fill the DataSet
        Dim con As SQLConnection = new SQLConnection("server=localhost;uid=sa;pwd=;database=northwind")
        Dim cmd As SQLDataSetCommand = new SQLDataSetCommand("Select * from Customers where country='USA'", con)
        cmd.FillDataSet(customersDataSet1, "Customers")
        
        ' Set up the Combobox bindings
        comboBoxUSState.DataSource = USStates            ' Populate the list
        comboBoxUSState.DisplayMember = "LongName"     ' Define the field to be displayed
        comboBoxUSState.ValueMember = "ShortName"      ' Define the field to be used as the value

        ' Bind the selected value of the the combobox to the Region field of the current
        ' Customer
        comboBoxUSState.Bindings.Add("SelectedValue", customersDataSet1, "Customers.Region")

        ' Set up the rest of the form bindings
        textBoxID.Bindings.Add("Text", customersDataSet1, "Customers.CustomerID")
        textBoxCity.Bindings.Add("Text", customersDataSet1, "Customers.City")
        textBoxTitle.Bindings.Add("Text", customersDataSet1, "Customers.ContactTitle")
        textBoxAddress.Bindings.Add("Text", customersDataSet1, "Customers.Address")
        textBoxCompany.Bindings.Add("Text", customersDataSet1, "Customers.CompanyName")
        textBoxContact.Bindings.Add("Text", customersDataSet1, "Customers.ContactName")
        textBoxZip.Bindings.Add("Text", customersDataSet1, "Customers.PostalCode")
        
        ' We want to handle position changing events for the DATA VCR Panel
        AddHandler Me.BindingManager(customersDataSet1,"Customers").PositionChanged, new System.EventHandler(AddressOf customers_PositionChanged)

        ' Set up the initial text for the DATA VCR Panel
        textBoxPosition.Text = "Record " + (Me.BindingManager(customersDataSet1,"Customers").Position + 1).ToString() + " of " + customersDataSet1.Customers.Count.ToString()

        ' Set the minimum form size 
        Me.MinTrackSize = new Size(375, 361)
    End Sub


        ' When the MoveFirst button is clicked set the position for the Customers table 
        ' to the first record
        protected Sub buttonMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) 
            Me.BindingManager(customersDataSet1,"Customers").Position = 0 
        End Sub


        ' When the MoveLast button is clicked set the position for the Customers table 
        ' to the last record
        protected Sub buttonMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) 
            Me.BindingManager(customersDataSet1,"Customers").Position = customersDataSet1.Customers.Count - 1
        End Sub


        ' When the MoveNext button is clicked increment the position for the Customers table 
        protected Sub buttonMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) 
            if Me.BindingManager(customersDataSet1,"Customers").Position < customersDataSet1.Customers.Count - 1 Then 
                Me.BindingManager(customersDataSet1,"Customers").Position += 1
            End If
        End Sub


        ' When the MovePrev button is clicked decrement the position for the Customers table 
        protected Sub buttonMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) 
            if Me.BindingManager(customersDataSet1,"Customers").Position > 0 Then
                Me.BindingManager(customersDataSet1,"Customers").Position -= 1
            End If
        End Sub
        
        
        ' Position has changed - update the DATA VCR panel
        protected Sub customers_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) 
            textBoxPosition.Text = "Record " + (Me.BindingManager(customersDataSet1,"Customers").Position + 1).ToString() + " of " + customersDataSet1.Customers.Count.ToString()
        End Sub

        public overrides Sub Dispose() 
            MyBase.Dispose()
            components.Dispose()
        End Sub

        private Sub InitializeComponent() 
            Me.components = new System.ComponentModel.Container()
            Me.labelCity = new System.WinForms.Label()
            Me.buttonMoveNext = new System.WinForms.Button()
            Me.customersDataSet1 = new Microsoft.Samples.WinForms.VB.ComboBoxBinding.Data.CustomersDataSet()
            Me.labelContact = new System.WinForms.Label()
            Me.buttonMoveFirst = new System.WinForms.Button()
            Me.textBoxID = new System.WinForms.TextBox()
            Me.textBoxCity = new System.WinForms.TextBox()
            Me.labelContactTitle = new System.WinForms.Label()
            Me.labelCompanyName = new System.WinForms.Label()
            Me.textBoxTitle = new System.WinForms.TextBox()
            Me.textBoxPosition = new System.WinForms.TextBox()
            Me.labelUSState = new System.WinForms.Label()
            Me.buttonMovePrev = new System.WinForms.Button()
            Me.labelZip = new System.WinForms.Label()
            Me.textBoxAddress = new System.WinForms.TextBox()
            Me.textBoxCompany = new System.WinForms.TextBox()
            Me.panelVCRControl = new System.WinForms.Panel()
            Me.comboBoxUSState = new System.WinForms.ComboBox()
            Me.labelAddress = new System.WinForms.Label()
            Me.labelID = new System.WinForms.Label()
            Me.textBoxContact = new System.WinForms.TextBox()
            Me.buttonMoveLast = new System.WinForms.Button()
            Me.textBoxZip = new System.WinForms.TextBox()


            labelCity.Size = new System.Drawing.Size(64, 16)
            labelCity.Location = new System.Drawing.Point(16, 176)
            labelCity.TabIndex = 11
            labelCity.Text = "City:"

            buttonMoveNext.Location = new System.Drawing.Point(280, 8)
            buttonMoveNext.FlatStyle = System.WinForms.FlatStyle.Flat
            buttonMoveNext.Size = new System.Drawing.Size(32, 32)
            buttonMoveNext.TabIndex = 2
            buttonMoveNext.Anchor = System.WinForms.AnchorStyles.TopRight
            buttonMoveNext.Font = new System.Drawing.Font("TAHOMA", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
            buttonMoveNext.Text = ">"
            AddHandler buttonMoveNext.Click, new System.EventHandler(AddressOf buttonMoveNext_Click)

            customersDataSet1.DataSetName = "CustomersDataSet"

            labelContact.Size = new System.Drawing.Size(64, 16)
            labelContact.Location = new System.Drawing.Point(16, 80)
            labelContact.TabIndex = 7
            labelContact.Text = "Contact:"

            buttonMoveFirst.Location = new System.Drawing.Point(8, 8)
            buttonMoveFirst.FlatStyle = System.WinForms.FlatStyle.Flat
            buttonMoveFirst.Size = new System.Drawing.Size(32, 32)
            buttonMoveFirst.TabIndex = 0
            buttonMoveFirst.Font = new System.Drawing.Font("TAHOMA", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
            buttonMoveFirst.Text = "|<"
            AddHandler buttonMoveFirst.Click, new System.EventHandler(AddressOf buttonMoveFirst_Click)

            textBoxID.Text = ""
            textBoxID.Enabled = false
            textBoxID.ReadOnly = true
            textBoxID.TabIndex = 0
            textBoxID.Anchor = System.WinForms.AnchorStyles.TopLeftRight
            textBoxID.Size = new System.Drawing.Size(299, 20)
            textBoxID.Location = new System.Drawing.Point(88, 16)
            ' textBoxID.Bindings.All = new System.WinForms.ListBinding() {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.CustomerID")}

            textBoxCity.Text = ""
            textBoxCity.TabIndex = 5
            textBoxCity.Size = new System.Drawing.Size(216, 20)
            textBoxCity.Anchor = System.WinForms.AnchorStyles.TopLeftRight
            textBoxCity.Location = new System.Drawing.Point(88, 176)
            ' textBoxCity.Bindings.All = new System.WinForms.ListBinding() {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.City")}

            labelContactTitle.Size = new System.Drawing.Size(64, 16)
            labelContactTitle.Location = new System.Drawing.Point(16, 112)
            labelContactTitle.TabIndex = 8
            labelContactTitle.Text = "Title:"

            labelCompanyName.Size = new System.Drawing.Size(64, 16)
            labelCompanyName.Location = new System.Drawing.Point(16, 48)
            labelCompanyName.TabIndex = 6
            labelCompanyName.Text = "Company:"

            textBoxTitle.Text = ""
            textBoxTitle.TabIndex = 3
            textBoxTitle.Anchor = System.WinForms.AnchorStyles.TopLeftRight
            textBoxTitle.Size = new System.Drawing.Size(216, 20)
            textBoxTitle.Location = new System.Drawing.Point(88, 112)
            ' textBoxTitle.Bindings.All = new System.WinForms.ListBinding() {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.ContactTitle")}

            Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
            Me.Text = "Customer Details"
            Me.ClientSize = new System.Drawing.Size(464, 357)

            textBoxPosition.Text = ""
            textBoxPosition.BorderStyle = System.WinForms.BorderStyle.FixedSingle
            textBoxPosition.Enabled = false
            textBoxPosition.ReadOnly = true
            textBoxPosition.TabIndex = 1
            textBoxPosition.Anchor = System.WinForms.AnchorStyles.LeftRight
            textBoxPosition.Size = new System.Drawing.Size(184, 20)
            textBoxPosition.Location = new System.Drawing.Point(88, 14)

            labelUSState.Size = new System.Drawing.Size(64, 16)
            labelUSState.Location = new System.Drawing.Point(16, 208)
            labelUSState.TabIndex = 13
            labelUSState.Text = "USState:"

            buttonMovePrev.Location = new System.Drawing.Point(48, 8)
            buttonMovePrev.FlatStyle = System.WinForms.FlatStyle.Flat
            buttonMovePrev.Size = new System.Drawing.Size(32, 32)
            buttonMovePrev.TabIndex = 1
            buttonMovePrev.Font = new System.Drawing.Font("TAHOMA", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
            buttonMovePrev.Text = "<"
            AddHandler buttonMovePrev.Click, new System.EventHandler(AddressOf buttonMovePrev_Click)

            labelZip.Size = new System.Drawing.Size(64, 16)
            labelZip.Location = new System.Drawing.Point(16, 240)
            labelZip.TabIndex = 12
            labelZip.Text = "Zip:"

            textBoxAddress.Text = ""
            textBoxAddress.AcceptsReturn = true
            textBoxAddress.TabIndex = 4
            textBoxAddress.Anchor = System.WinForms.AnchorStyles.All
            textBoxAddress.Size = new System.Drawing.Size(360, 20)
            textBoxAddress.Location = new System.Drawing.Point(88, 144)
            ' textBoxAddress.Bindings.All = new System.WinForms.ListBinding() {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.Address")}

            textBoxCompany.Text = ""
            textBoxCompany.TabIndex = 1
            textBoxCompany.Anchor = System.WinForms.AnchorStyles.TopLeftRight
            textBoxCompany.Size = new System.Drawing.Size(296, 20)
            textBoxCompany.Location = new System.Drawing.Point(88, 48)
            ' textBoxCompany.Bindings.All = new System.WinForms.ListBinding() {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.CompanyName")}

            panelVCRControl.BorderStyle = System.WinForms.BorderStyle.FixedSingle
            panelVCRControl.Location = new System.Drawing.Point(88, 288)
            panelVCRControl.AutoScrollMinSize = new System.Drawing.Size(0, 0)
            panelVCRControl.Size = new System.Drawing.Size(360, 48)
            panelVCRControl.TabIndex = 8
            panelVCRControl.Anchor = System.WinForms.AnchorStyles.BottomLeftRight
            panelVCRControl.Text = "panel1"

            comboBoxUSState.Text = ""
            comboBoxUSState.TabIndex = 6
            comboBoxUSState.Size = new System.Drawing.Size(176, 20)
            comboBoxUSState.Location = new System.Drawing.Point(88, 208)
            ' comboBoxUSState.Bindings.All = new System.WinForms.ListBinding() {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.Region")}

            labelAddress.Size = new System.Drawing.Size(64, 16)
            labelAddress.Location = new System.Drawing.Point(16, 144)
            labelAddress.TabIndex = 9
            labelAddress.Text = "Address:"

            labelID.Size = new System.Drawing.Size(64, 16)
            labelID.Location = new System.Drawing.Point(16, 16)
            labelID.TabIndex = 5
            labelID.Text = "ID:"

            textBoxContact.Text = ""
            textBoxContact.TabIndex = 2
            textBoxContact.Anchor = System.WinForms.AnchorStyles.TopLeftRight
            textBoxContact.Size = new System.Drawing.Size(339, 20)
            textBoxContact.Location = new System.Drawing.Point(88, 80)
            ' textBoxContact.Bindings.All = new System.WinForms.ListBinding() {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.ContactName")}

            buttonMoveLast.Location = new System.Drawing.Point(320, 8)
            buttonMoveLast.FlatStyle = System.WinForms.FlatStyle.Flat
            buttonMoveLast.Size = new System.Drawing.Size(32, 32)
            buttonMoveLast.TabIndex = 3
            buttonMoveLast.Anchor = System.WinForms.AnchorStyles.TopRight
            buttonMoveLast.Font = new System.Drawing.Font("TAHOMA", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
            buttonMoveLast.Text = ">|"
            AddHandler buttonMoveLast.Click, new System.EventHandler(AddressOf buttonMoveLast_Click)

            textBoxZip.Text = ""
            textBoxZip.TabIndex = 7
            textBoxZip.Size = new System.Drawing.Size(112, 20)
            textBoxZip.Location = new System.Drawing.Point(88, 240)
            ' textBoxZip.Bindings.All = new System.WinForms.ListBinding() {new System.WinForms.ListBinding("Text", customersDataSet1, "Customers.PostalCode")}

            panelVCRControl.Controls.Add(textBoxPosition)
            panelVCRControl.Controls.Add(buttonMoveFirst)
            panelVCRControl.Controls.Add(buttonMovePrev)
            panelVCRControl.Controls.Add(buttonMoveNext)
            panelVCRControl.Controls.Add(buttonMoveLast)
            Me.Controls.Add(textBoxZip)
            Me.Controls.Add(comboBoxUSState)
            Me.Controls.Add(textBoxCity)
            Me.Controls.Add(labelUSState)
            Me.Controls.Add(labelZip)
            Me.Controls.Add(labelCity)
            Me.Controls.Add(panelVCRControl)
            Me.Controls.Add(textBoxCompany)
            Me.Controls.Add(labelCompanyName)
            Me.Controls.Add(textBoxAddress)
            Me.Controls.Add(textBoxTitle)
            Me.Controls.Add(textBoxContact)
            Me.Controls.Add(textBoxID)
            Me.Controls.Add(labelAddress)
            Me.Controls.Add(labelContactTitle)
            Me.Controls.Add(labelContact)
            Me.Controls.Add(labelID)
        End Sub
    End Class
End Namespace

















