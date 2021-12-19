' ------------------------------------------------------------------------------
'  <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'     Copyright (c) Microsoft Corporation. All Rights Reserved.                
'        
'     This source code is intended only as a supplement to Microsoft
'     Development Tools and/or on-line documentation.  See these other
'     materials for detailed information regarding Microsoft code samples.
' 
'  </copyright>                                                                
' ------------------------------------------------------------------------------

imports System
imports System.WinForms
imports System.Drawing


namespace Microsoft.Samples.WinForms.VB.CustomerControl

   public class CustomerControl
       Inherits System.WinForms.UserControl

        private components As System.ComponentModel.Container 
    	private textBoxTitle As System.WinForms.TextBox 
	    private labelTitle As System.WinForms.Label 
	    private textBoxAddress As System.WinForms.TextBox 
	    private textBoxLastName As System.WinForms.TextBox 
	    private textBoxFirstName As System.WinForms.TextBox 
	    private textBoxID As System.WinForms.TextBox 
	    private labelAddress As System.WinForms.Label 
	    private labelLastName As System.WinForms.Label 
	    private labelFirstName As System.WinForms.Label 
	    private labelID As System.WinForms.Label 
        private customer1 As Customer 
	

        public sub New()
            MyBase.New()

            '  Required by the Windows Forms Designer
            InitializeComponent()

            '  TODO: Add any constructor code after InitializeComponent call
        end sub

        public property Customer() As Customer
            get 
                return customer1
            end get

            set
                customer1=value
                LoadCustomer()
            end set
        end property

        public sub AcceptChanges()
            customer1.Title = textBoxTitle.Text
            customer1.FirstName = textBoxFirstName.Text
            customer1.LastName = textBoxLastName.Text
            customer1.Address = textBoxAddress.Text
        end sub

        public sub RejectChanges()
            LoadCustomer()
        end sub

        private sub LoadCustomer()
            textBoxID.Text = customer1.ID
            textBoxTitle.Text = customer1.Title
            textBoxFirstName.Text = customer1.FirstName
            textBoxLastName.Text = customer1.LastName
            textBoxAddress.Text =  customer1.Address   
        end sub

        overrides public sub Dispose()
            MyBase.Dispose()
        end sub

        private sub InitializeComponent()
    		Me.components = new System.ComponentModel.Container()
    		Me.labelAddress = new System.WinForms.Label()
    		Me.labelLastName = new System.WinForms.Label()
    		Me.textBoxFirstName = new System.WinForms.TextBox()
    		Me.textBoxLastName = new System.WinForms.TextBox()
    		Me.labelFirstName = new System.WinForms.Label()
    		Me.labelTitle = new System.WinForms.Label()
    		Me.textBoxTitle = new System.WinForms.TextBox()
    		Me.textBoxAddress = new System.WinForms.TextBox()
    		Me.labelID = new System.WinForms.Label()
    		Me.textBoxID = new System.WinForms.TextBox()
    		
    		labelAddress.Size = new System.Drawing.Size(64, 16)
    		labelAddress.Location = new System.Drawing.Point(8, 194)
    		labelAddress.TabIndex = 9
    		labelAddress.Text = "Address:"
    		
    		labelLastName.Size = new System.Drawing.Size(64, 16)
    		labelLastName.Location = new System.Drawing.Point(8, 154)
    		labelLastName.TabIndex = 8
    		labelLastName.Text = "LastName:"
    		
            textBoxFirstName.Anchor = System.WinForms.AnchorStyles.TopLeftRight
    		textBoxFirstName.Text = ""
    		textBoxFirstName.TabIndex = 2
    		textBoxFirstName.Size = new System.Drawing.Size(240, 20)
    		textBoxFirstName.Location = new System.Drawing.Point(88, 112)
    		
    		Me.Text = "CustomerControl"
    		Me.Size = new System.Drawing.Size(384, 304)
    		
            textBoxLastName.Anchor = System.WinForms.AnchorStyles.TopLeftRight
    		textBoxLastName.Location = new System.Drawing.Point(88, 152)
    		textBoxLastName.Text = ""
    		textBoxLastName.TabIndex = 3
    		textBoxLastName.Size = new System.Drawing.Size(240, 20)
    		
    		labelFirstName.Location = new System.Drawing.Point(8, 112)
    		labelFirstName.Size = new System.Drawing.Size(64, 16)
    		labelFirstName.TabIndex = 7
    		labelFirstName.Text = "First Name:"
    		
    		labelTitle.Size = new System.Drawing.Size(64, 16)
    		labelTitle.Location = new System.Drawing.Point(8, 72)
    		labelTitle.TabIndex = 6
    		labelTitle.Text = "Title:"
    		
            textBoxTitle.Anchor = System.WinForms.AnchorStyles.TopLeftRight
    		textBoxTitle.Text = ""
    		textBoxTitle.TabIndex = 1
    		textBoxTitle.Size = new System.Drawing.Size(88, 20)
    		textBoxTitle.Location = new System.Drawing.Point(88, 70)
    		
            textBoxAddress.Anchor = System.WinForms.AnchorStyles.All
    		textBoxAddress.Text = ""
    		textBoxAddress.Multiline = true
    		textBoxAddress.TabIndex = 4
    		textBoxAddress.Size = new System.Drawing.Size(264, 96)
    		textBoxAddress.Location = new System.Drawing.Point(88, 192)
            textBoxAddress.AcceptsReturn = true
    		
    		labelID.Size = new System.Drawing.Size(64, 16)
    		labelID.Location = new System.Drawing.Point(8, 32)
    		labelID.TabIndex = 5
    		labelID.Text = "ID:"
    		
            textBoxID.Anchor = System.WinForms.AnchorStyles.TopLeftRight
    		textBoxID.Text = ""
    		textBoxID.ReadOnly = true
    		textBoxID.TabIndex = 0
    		textBoxID.Size = new System.Drawing.Size(200, 20)
    		textBoxID.Location = new System.Drawing.Point(88, 30)
    		textBoxID.Enabled = false
    		
    		Me.Controls.Add(textBoxTitle)
    		Me.Controls.Add(labelTitle)
    		Me.Controls.Add(textBoxAddress)
    		Me.Controls.Add(textBoxLastName)
    		Me.Controls.Add(textBoxFirstName)
    		Me.Controls.Add(textBoxID)
    		Me.Controls.Add(labelAddress)
    		Me.Controls.Add(labelLastName)
    		Me.Controls.Add(labelFirstName)
    		Me.Controls.Add(labelID)
    		
    	end sub

    End Class ' CustomerControl
End Namespace	' Microsoft.Samples.WinForms.VB.CustomerControl
