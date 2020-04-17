//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation Sample Code.
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using FileWatcherActivities;

namespace FileWatcherTest
{
    public sealed partial class StateMachineSetStateToSelf : StateMachineWorkflowActivity
    {
        public StateMachineSetStateToSelf()
        {
            InitializeComponent();
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {

        }

        private void FileSystemEventOccurred(object sender, FileSystemEventArgs e)
        {
            FileSystemEventActivity activity = sender as FileSystemEventActivity;
            Console.WriteLine("\n\nFileSystemEventActivity '{0}' is handling an event. "
                + "Filename={1}, Event={2}", activity.Name, e.Name, e.ChangeType.ToString());
        }

        public static DependencyProperty PathProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Path", typeof(string), typeof(StateMachineSetStateToSelf));

        [Description("This is the description which appears in the Property Browser")]
        [Category("This is the category which will be displayed in the Property Browser")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Path
        {
            get
            {
                return ((string)(base.GetValue(StateMachineSetStateToSelf.PathProperty)));
            }
            set
            {
                base.SetValue(StateMachineSetStateToSelf.PathProperty, value);
            }
        }
    }
}
