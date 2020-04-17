//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
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

namespace FabrikamWorkflows {
    
    
    public partial class Settings : System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance;
        
        private static object syncObject = new object();
        
        public static Settings DefaultInstance {
            get {
                if ((Settings.defaultInstance == null)) {
                    System.Threading.Monitor.Enter(Settings.syncObject);
                    if ((Settings.defaultInstance == null)) {
                        try {
                            Settings.defaultInstance = new Settings();
                        }
                        finally {
                            System.Threading.Monitor.Exit(Settings.syncObject);
                        }
                    }
                }
                return Settings.defaultInstance;
            }
        }       
    }
}
