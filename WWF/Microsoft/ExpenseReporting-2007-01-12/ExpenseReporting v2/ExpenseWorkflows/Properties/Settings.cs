//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System.Configuration;
using System.Threading;

namespace ExpenseWorkflows {
    
    
    public partial class Settings : ApplicationSettingsBase {
        
        private static Settings m_DefaultInstance;
        
        private static object m_SyncObject = new object();
        
        public static Settings DefaultInstance {
            get {
                if ((m_DefaultInstance == null)) {
                    Monitor.Enter(m_SyncObject);
                    if ((m_DefaultInstance == null)) {
                        try {
                            m_DefaultInstance = new Settings();
                        }
                        finally {
                            Monitor.Exit(m_SyncObject);
                        }
                    }
                }
                return m_DefaultInstance;
            }
        }       
    }
}
