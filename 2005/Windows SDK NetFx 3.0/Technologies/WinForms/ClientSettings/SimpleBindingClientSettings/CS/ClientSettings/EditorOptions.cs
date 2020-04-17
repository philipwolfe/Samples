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
using System.Text;
using System.Windows.Forms;

namespace ClientSettings
{
    public partial class EditorOptions : Form
    {
        public EditorOptions()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Reverse of EditorOptions_Load, but with an explicit Save() call required to 
            // propogate the new settings from the settings wrapper back to the app.config file
            // in which the settings are stored.
            Properties.Settings.Default.WordWrapSetting = checkWordWrap.Checked;
            Properties.Settings.Default.DetectURLsSetting = checkDetectURLs.Checked;
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void EditorOptions_Load(object sender, EventArgs e)
        {
            // Populate the options with settings from the settings class
            // The settings class "lazy loads" - it will access the user.config
            // file in which the settings are stored on the first access to a property
            // on the settings class.
            checkWordWrap.Checked = Properties.Settings.Default.WordWrapSetting;
            checkDetectURLs.Checked = Properties.Settings.Default.DetectURLsSetting;
        }
    }
}