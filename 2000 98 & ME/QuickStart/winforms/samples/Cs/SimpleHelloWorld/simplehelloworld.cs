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
namespace Microsoft.Samples.WinForms.Cs.SimpleHelloWorld {
    using System;
    using System.WinForms;

    public class SimpleHelloWorld : Form {

        public static int Main(string[] args) {
            Application.Run(new SimpleHelloWorld());
            return 0;
        }

        public SimpleHelloWorld() {
            this.Text = "Hello World";
        }
    }
}






