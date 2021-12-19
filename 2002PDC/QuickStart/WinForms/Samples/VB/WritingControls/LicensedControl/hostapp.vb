' ------------------------------------------------------------------------------
' <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'     Copyright (c) Microsoft Corporation. All Rights Reserved.                
'        
'     This source code is intended only as a supplement to Microsoft
'     Development Tools and/or on-line documentation.  See these other
'     materials for detailed information regarding Microsoft code samples.
' 
' </copyright>                                                                
' ------------------------------------------------------------------------------

imports System
imports System.ComponentModel
imports System.Drawing
imports System.WinForms
imports Microsoft.Samples.WinForms.VB.LicensedControl

option explicit on

namespace Microsoft.Samples.WinForms.VB.HostApp

    public class HostApp
        inherits System.WinForms.Form

        private components As System.ComponentModel.Container 
	private LicensedControl1 As Microsoft.Samples.WinForms.VB.LicensedControl.LicensedControl 

        public sub New()
            MyBase.New

            '  Required by the Win Forms Designer
            InitializeComponent()

            '  TODO: Add any constructor code after InitializeComponent call
        end sub

        overrides public sub Dispose()
            Mybase.Dispose()
            components.Dispose()
        end sub

        private sub InitializeComponent()
		    Me.components = new System.ComponentModel.Container()
		    Me.LicensedControl1 = new Microsoft.Samples.WinForms.VB.LicensedControl.LicensedControl()
		
		    LicensedControl1.Dock = System.WinForms.DockStyle.Fill
		    LicensedControl1.Size = new System.Drawing.Size(600, 450)
		    LicensedControl1.TabIndex = 0
		    LicensedControl1.Text = "Hello from the licensed control!"
		
		    Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
		    Me.Text = "Control Example"
		    Me.ClientSize = new System.Drawing.Size(600, 450)
		
		    Me.Controls.Add(LicensedControl1)
	end sub


        shared public sub Main()
            Application.Run(new HostApp())
        end sub

    end class	' HostApp

end namespace	' Microsoft.Samples.WinForms.VB.HostApp
