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
imports System.WinForms
imports System.Drawing
imports System.ComponentModel


namespace Microsoft.Samples.WinForms.VB.LicensedControl

    
    public class <LicenseProviderAttribute(GetType(LicFileLicenseProvider))> LicensedControl
	inherits RichControl

        private license As License = nothing

        public sub New()
            MyBase.New

            license = LicenseManager.Validate(GetType(LicensedControl), Me)
        end sub

        overrides public sub Dispose()
            if license <> nothing
                license.Dispose()
                license = nothing
            end if
        end sub

        overrides protected sub OnPaint(e As PaintEventArgs)
            ' Paint the Text property on the control
             e.Graphics.DrawString(Me.Text, Font, new SolidBrush(ForeColor), ClientRectangle.x, ClientRectangle.y)
        end sub
    end class	' LicensedControl

end namespace	' Microsoft.Samples.WinForms.VB.LicensedControl
