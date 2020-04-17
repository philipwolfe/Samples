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

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Globalization;
using System.Drawing;

namespace FileWatcherActivities
{
    /// <summary>
    /// Implements design-time services for the activity component.
    /// </summary>
    public sealed class FileSystemEventDesigner : ActivityDesigner
    {

        protected override void Initialize(Activity activity)
        {
            base.Initialize(activity);

            // Change the designer theme for this activity
            this.DesignerTheme.BackColorStart = Color.White;
            this.DesignerTheme.BackColorEnd = ColorTranslator.FromHtml("#F9CB5A");
            this.DesignerTheme.BackgroundStyle = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.DesignerTheme.BorderColor = ColorTranslator.FromHtml("#BF8311");
        }
    }
}
