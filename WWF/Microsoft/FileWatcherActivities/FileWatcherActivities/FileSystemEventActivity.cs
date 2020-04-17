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
using Microsoft.Samples.Workflow.CustomActivityFramework;

namespace FileWatcherActivities
{
    [ToolboxBitmap(typeof(FileSystemEventActivity), "Resources.FileSystemEvent.png")]
    [Designer(typeof(FileSystemEventDesigner))]
    public partial class FileSystemEventActivity : InputActivity
	{
		public FileSystemEventActivity()
		{
			InitializeComponent();
		}

        #region Default values

        public const string FilterDefaultValue = "*.*";

        public const System.IO.NotifyFilters NotifyFilterDefaultValue =
            System.IO.NotifyFilters.LastWrite |
            System.IO.NotifyFilters.FileName |
            System.IO.NotifyFilters.DirectoryName;

        public const bool IncludeSubdirectoriesDefaultValue = true;

        #endregion

        #region Private data

        private Guid subscriptionId = Guid.Empty;

        #endregion

        #region Dependency Properties

        public static DependencyProperty PathProperty = DependencyProperty.Register("Path", typeof(string), typeof(FileSystemEventActivity));
        public static DependencyProperty FilterProperty = DependencyProperty.Register("Filter", typeof(string), typeof(FileSystemEventActivity), new PropertyMetadata(FileSystemEventActivity.FilterDefaultValue));
        public static DependencyProperty NotifyFilterProperty = DependencyProperty.Register("NotifyFilter", typeof(System.IO.NotifyFilters), typeof(FileSystemEventActivity), new PropertyMetadata(FileSystemEventActivity.NotifyFilterDefaultValue));
        public static DependencyProperty IncludeSubdirectoriesProperty = DependencyProperty.Register("IncludeSubdirectories", typeof(bool), typeof(FileSystemEventActivity), new PropertyMetadata(FileSystemEventActivity.IncludeSubdirectoriesDefaultValue));
        public static DependencyProperty FileSystemEventOccurredEvent = DependencyProperty.Register("FileSystemEventOccurred", typeof(EventHandler<FileSystemEventArgs>), typeof(FileSystemEventActivity));

        #endregion

        #region Activity Properties

        [Category("File System Watcher")]
        [DefaultValue(FileSystemEventActivity.FilterDefaultValue)]
        public string Filter
        {
            get
            {
                return ((string)(base.GetValue(FileSystemEventActivity.FilterProperty)));
            }
            set
            {
                base.SetValue(FileSystemEventActivity.FilterProperty, value);
            }
        }

        [Category("File System Watcher")]
        [TypeConverterAttribute("System.Diagnostics.Design.StringValueConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [EditorAttribute("System.Diagnostics.Design.FSWPathEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string Path
        {
            get
            {
                return ((string)(base.GetValue(FileSystemEventActivity.PathProperty)));
            }
            set
            {
                base.SetValue(FileSystemEventActivity.PathProperty, value);
            }
        }

        [Category("File System Watcher")]
        [DefaultValue(FileSystemEventActivity.IncludeSubdirectoriesDefaultValue)]
        public bool IncludeSubdirectories
        {
            get
            {
                return ((bool)(base.GetValue(FileSystemEventActivity.IncludeSubdirectoriesProperty)));
            }
            set
            {
                base.SetValue(FileSystemEventActivity.IncludeSubdirectoriesProperty, value);
            }
        }

        [Category("File System Watcher")]
        [DefaultValue(FileSystemEventActivity.NotifyFilterDefaultValue)]
        public System.IO.NotifyFilters NotifyFilter
        {
            get
            {
                return ((System.IO.NotifyFilters)(base.GetValue(FileSystemEventActivity.NotifyFilterProperty)));
            }
            set
            {
                base.SetValue(FileSystemEventActivity.NotifyFilterProperty, value);
            }
        }

        [Description("This event is raised when a file system event has occured.")]
        [Browsable(true)]
        [Category("Handlers")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event EventHandler<FileSystemEventArgs> FileSystemEventOccurred
        {
            add
            {
                base.AddHandler(FileSystemEventActivity.FileSystemEventOccurredEvent, value);
            }
            remove
            {
                base.RemoveHandler(FileSystemEventActivity.FileSystemEventOccurredEvent, value);
            }
        }
        #endregion

        #region Activity Execution Logic

        protected override bool SubscribeExternalEvent(ActivityExecutionContext context)
        {
            // Get a reference to the FileWatcherService
            FileSystemEventService eventService = 
                context.GetService<FileSystemEventService>();

            if (eventService == null)
            {
                throw new ApplicationException("FileWatcherService is not available.");
            }

            this.EventSubscriptionId = 
                eventService.RegisterListener(this.WorkflowInstanceId, this.QueueName, 
                this.Path, this.Filter, this.NotifyFilter, this.IncludeSubdirectories);

            return true;
        }


        protected override bool UnsubscribeExternalEvent(ActivityExecutionContext context)
        {

            // Unregister the FileWatcherEvent listener
            this.UnregisterListener(context);

            return true;
        }


        protected override bool ProcessQueueItem(ActivityExecutionContext context, object item)
        {

            // Unregister the WMI Event listener
            this.UnregisterListener(context);

            FileSystemEventArgs e = (FileSystemEventArgs)item;

            // Raise the FileSystemEvent
            base.RaiseGenericEvent<FileSystemEventArgs>(FileSystemEventActivity.FileSystemEventOccurredEvent, this, e);

            // Return true to indicate we processed the item successfully.
            return true;
        }


        private void UnregisterListener(ActivityExecutionContext context)
        {
            FileSystemEventService fileService = context.GetService<FileSystemEventService>();
            fileService.UnregisterListener(this.EventSubscriptionId);
        }

        #endregion

	}
}
