//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

namespace SMTPMailActivityLibrary {
    
    
    public partial class Settings : System.Configuration.ApplicationSettingsBase {
        
        private static Settings m_DefaultInstance;
        
        private static object m_SyncObject = new object();
        
        public static Settings DefaultInstance {
            get {
                if ((Settings.m_DefaultInstance == null)) {
                    System.Threading.Monitor.Enter(Settings.m_SyncObject);
                    if ((Settings.m_DefaultInstance == null)) {
                        try {
                            Settings.m_DefaultInstance = new Settings();
                        }
                        finally {
                            System.Threading.Monitor.Exit(Settings.m_SyncObject);
                        }
                    }
                }
                return Settings.m_DefaultInstance;
            }
        }       
    }
}
