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
namespace Microsoft.Samples.WinForms.Cs.ComboBoxBinding {
    
    public struct State {
        
        private string shortName, longName;

        public State(string longName , string shortName) { 
            this.shortName = shortName ; this.longName = longName ;
        }

        public string ShortName { get { return shortName; } }
        public string LongName { get { return longName; } }
    }

}
