//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.RegistrySettingsProvider
{
    // Decorate the settings class with a SettingsProvider attribute
    // This tells ApplicationSettingsBase to use a non-default provider (e.g. not the 
    // LocalFileSettingsProvider, which targets the .config file)
    [SettingsProvider("Microsoft.Samples.Windows.Forms.RegistrySettingsProvider.RegistrySettingsProvider, RegistrySettingsProvider")]
    class TestSettings : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [DefaultSettingValue("Default text")]
        public string TextSetting
        {
            get { return (string)this["TextSetting"]; }
            set { this["TextSetting"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("0")]
        public int ComboSetting
        {
            get { return (int)this["ComboSetting"]; }
            set { this["ComboSetting"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("true")]
        public bool CheckSetting1
        {
            get { return (bool)this["CheckSetting1"]; }
            set { this["CheckSetting1"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("true")]
        public bool CheckSetting2
        {
            get { return (bool)this["CheckSetting2"]; }
            set { this["CheckSetting2"] = value; }
        }

    }
}
