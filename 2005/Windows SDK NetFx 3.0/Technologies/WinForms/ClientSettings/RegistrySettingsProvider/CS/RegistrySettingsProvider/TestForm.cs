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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.RegistrySettingsProvider
{
    partial class formTestForm : Form
    {
        private TestSettings settings;

        public formTestForm()
        {
            InitializeComponent();
        }

        private void formTestForm_Load(object sender, EventArgs e)
        {
            // create a new instance of the settings wrapper class
            settings = new TestSettings();

            // pull values out of the settings class - the first property
            // access causes the underlying settings provider to "lazy load" 
            // all values - in this case, to access the registry
            textTextSetting.Text = settings.TextSetting;
            checkSetting1.Checked = settings.CheckSetting1;
            checkSetting2.Checked = settings.CheckSetting2;
            comboIntSetting.SelectedIndex = settings.ComboSetting;

        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            settings.TextSetting = textTextSetting.Text;
            settings.CheckSetting1 = checkSetting1.Checked;
            settings.CheckSetting2 = checkSetting2.Checked;
            settings.ComboSetting = comboIntSetting.SelectedIndex;

            settings.Save();
        }

        

        
    }
}
