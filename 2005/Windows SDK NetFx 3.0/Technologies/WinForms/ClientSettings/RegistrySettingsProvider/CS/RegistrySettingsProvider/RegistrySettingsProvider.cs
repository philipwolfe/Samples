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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Specialized;
using Microsoft.Win32;

// NOTE: This provider uses Assembly metadata such as ProductName, etc. 
// to determine a workable registry path in which to store settings. 
// Note that these are NOT secure metadata elements, however they are 
// reasonably safe from collision but not at all safe from malicious tampering.  
// A robust implementation of the provider would include a better pathing algorithm.

namespace Microsoft.Samples.Windows.Forms.RegistrySettingsProvider
{
    class RegistrySettingsProvider : SettingsProvider
    {
        public RegistrySettingsProvider()
        {

        }

        public override string ApplicationName
        {
            get { return Application.ProductName; }
            set { }
        }

        public override void Initialize(string name, NameValueCollection col)
        {
            base.Initialize(this.ApplicationName, col);
        }

        // SetPropertyValue is invoked when ApplicationSettingsBase.Save is called
        // ASB makes sure to pass each provider only the values marked for that provider -
        // though in this sample, since the entire settings class was marked with a SettingsProvider
        // attribute, all settings in that class map to this provider
        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection propvals)
        {
            // Iterate through the settings to be stored
            // Only IsDirty=true properties should be included in propvals
            foreach (SettingsPropertyValue propval in propvals)
            {
                // NOTE: this provider allows setting to both user- and application-scoped
                // settings. The default provider for ApplicationSettingsBase - 
                // LocalFileSettingsProvider - is read-only for application-scoped setting. This 
                // is an example of a policy that a provider may need to enforce for implementation,
                // security or other reasons.
                GetRegKey(propval.Property).SetValue(propval.Name, propval.SerializedValue);
            }
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection props)
        {

            // Create new collection of values
            SettingsPropertyValueCollection values = new SettingsPropertyValueCollection();

            // Iterate through the settings to be retrieved
            foreach (SettingsProperty setting in props)
            {
                SettingsPropertyValue value = new SettingsPropertyValue(setting);
                value.IsDirty = false;
                value.SerializedValue = GetRegKey(setting).GetValue(setting.Name);
                values.Add(value);
            }
            return values;
        }

        // Helper method: fetches correct registry subkey.
        // HKLM is used for settings marked as application-scoped.
        // HKLU is used for settings marked as user-scoped.
        private RegistryKey GetRegKey(SettingsProperty prop)
        {
            RegistryKey regKey;

            if (IsUserScoped(prop))
            {
                regKey = Registry.CurrentUser;
            }
            else
            {
                regKey = Registry.LocalMachine;
            }

            regKey = regKey.CreateSubKey(GetSubKeyPath());
            return regKey;

        }

        // Helper method: walks the "attribute bag" for a given property
        // to determine if it is user-scoped or not.
        // Note that this provider does not enforce other rules, such as 
        //   - unknown attributes
        //   - improper attribute combinations (e.g. both user and app - this implementation
        //     would say true for user-scoped regardless of existence of app-scoped)
        private bool IsUserScoped(SettingsProperty prop)
        {
            foreach (DictionaryEntry d in prop.Attributes)
            {
                Attribute a = (Attribute)d.Value;
                if (a.GetType() == typeof(UserScopedSettingAttribute))
                    return true;
            }
            return false;
        }

        // Builds a key path based on the CompanyName, ProductName, and ProductVersion attributes in 
        // the AssemblyInfo file (editable directly or within the Project Properties UI)
        private string GetSubKeyPath()
        {
            return "Software\\" + Application.CompanyName + "\\" + Application.ProductName + "\\" + Application.ProductVersion;
        }

        

        
 
    }
}
