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
namespace Microsoft.Samples.WinForms.Cs.LicensedControl {
    using System;
    using System.WinForms;
    using System.Drawing;
    using System.ComponentModel;

    [LicenseProviderAttribute(typeof(LicFileLicenseProvider))]
    public class LicensedControl : RichControl {

        private License license = null;

        public LicensedControl () {
            license = LicenseManager.Validate(typeof(LicensedControl), this);
        }

        public override void Dispose() {
            if (license != null) {
                license.Dispose();
                license = null;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            //Paint the Text property on the control
            e.Graphics.DrawString(Text, 
                                  Font, 
                                  new SolidBrush(ForeColor), 
                                  ClientRectangle);
        }
    }
}
