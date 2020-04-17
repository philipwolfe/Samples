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
public sealed partial class SequentialWithWhile : SequentialWorkflowActivity
{
    public SequentialWithWhile()
	{
		InitializeComponent();
	}

    private void FileSystemEventOccurred(object sender, FileSystemEventArgs e)
    {
        FileSystemEventActivity activity = sender as FileSystemEventActivity;
        Console.WriteLine("\n\nFileSystemEventActivity '{0}' is handling an event. "
            + "Filename={1}, Event={2}", activity.Name, e.Name, e.ChangeType.ToString());
    }

    private void AlwaysRun(object sender, ConditionalEventArgs e)
    {
        e.Result = true;
    }

    private String path = default(System.String);

    private void Before_Invoking(object sender, EventArgs e)
    {
        path = @"C:\temp2";
    }

}

}
