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
imports System.ComponentModel
imports System.Drawing
imports System.WinForms
imports Microsoft.Samples.WinForms.VB.CustomerControl
imports Microsoft.VisualBasic.ControlChars

option explicit off

namespace Microsoft.Samples.WinForms.VB.HostApp

    public class HostApp
    inherits System.WinForms.Form

        private components As System.ComponentModel.Container
    	private buttonCancel As System.WinForms.Button
	private buttonSave As System.WinForms.Button
        private CustomerControl1 As Microsoft.Samples.WinForms.VB.CustomerControl.CustomerControl

        public Sub New()
            MyBase.New
            
            '  Required by the Win Forms Designer
            InitializeComponent()

            '  TODO: Add any constructor code after InitializeComponent call
            CustomerControl1.Customer = Customer.ReadCustomer()
            
            ' Set the minimum form size to the client size + the height of the title bar
            Me.MinTrackSize = new Size(400, (373 + SystemInformation.CaptionHeight))
        end sub

        overrides public Sub Dispose()
            MyBase.Dispose()
        end sub

        private sub InitializeComponent()
    		Me.components = new System.ComponentModel.Container()
    		Me.buttonSave = new System.WinForms.Button()
    		Me.buttonCancel = new System.WinForms.Button()
    		Me.CustomerControl1 = new Microsoft.Samples.WinForms.VB.CustomerControl.CustomerControl()
    		
            buttonSave.Anchor = System.WinForms.AnchorStyles.BottomLeft
    		buttonSave.DialogResult = System.WinForms.DialogResult.OK
    		buttonSave.FlatStyle = System.WinForms.FlatStyle.Flat
    		buttonSave.Size = new System.Drawing.Size(96, 24)
    		buttonSave.TabIndex = 1
    		buttonSave.Text = "&Save"
    		buttonSave.Location = new System.Drawing.Point(8, 328)
            buttonSave.AddOnClick(new System.EventHandler(AddressOf buttonSave_Click))

            buttonCancel.Anchor = System.WinForms.AnchorStyles.BottomLeft
    		buttonCancel.Location = new System.Drawing.Point(120, 328)
    		buttonCancel.DialogResult = System.WinForms.DialogResult.Cancel
    		buttonCancel.FlatStyle = System.WinForms.FlatStyle.Flat
    		buttonCancel.Size = new System.Drawing.Size(96, 24)
    		buttonCancel.TabIndex = 2
    		buttonCancel.Text = "Cancel"
            buttonCancel.AddOnClick(new System.EventHandler(AddressOf buttonCancel_Click))
    		
    		Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
    		Me.Text = "Control Example"
    		Me.CancelButton = buttonCancel
    		Me.AcceptButton = buttonSave
    		Me.ClientSize = new System.Drawing.Size(400, 373)
    		
            CustomerControl1.Anchor=System.WinForms.AnchorStyles.All
    		CustomerControl1.AutoScrollMinSize = new System.Drawing.Size(0, 0)
    		CustomerControl1.Size = new System.Drawing.Size(400, 310)
    		CustomerControl1.TabIndex = 0
    		CustomerControl1.Text = "Hello Win Forms Control World"
    		
    		Me.Controls.Add(buttonCancel)
    		Me.Controls.Add(buttonSave)
    		Me.Controls.Add(CustomerControl1)
    		
    	end sub

        private sub buttonCancel_Click(sender As object, e As System.EventArgs)
            CustomerControl1.RejectChanges()
        end sub

        private Sub buttonSave_Click(sender As object, e As System.EventArgs)
            CustomerControl1.AcceptChanges()
            MessageBox.Show("Customer Changes Saved: " & CrLf & CustomerControl1.Customer.ToString)

        end sub

        Shared Sub Main()
            Application.Run(new HostApp())
        End Sub

    end class	' HostApp

end namespace	' Microsoft.Samples.WinForms.VB.HostApp
