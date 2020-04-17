//--------------------------------------------------------------------------------
// This file is part of the Windows Workflow Foundation Sample Code
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

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.Samples.Workflow.CustomActivityFramework;
using System.Threading;

namespace DiagnosticsActivities
{
    public sealed partial class ProcessActivity : InputActivity
	{
		public ProcessActivity()
		{
			InitializeComponent();
		}

        #region Start Info properties

        public static DependencyProperty ArgumentsProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Arguments", typeof(string), typeof(ProcessActivity), new PropertyMetadata(string.Empty));

        [Description("Gets or sets the set of command line arguments to use when starting the application. File type-specific arguments that the system can associate with the application specified in the System.Diagnostics.ProcessStartInfo.FileName property. The default is an empty string (\"\"). The maximum string length is 2003 characters in .NET Framework applications and 488 characters in .NET Compact Framework applications.")]
        [Category("Start Info")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Arguments
        {
            get
            {
                return ((string)(base.GetValue(ProcessActivity.ArgumentsProperty)));
            }
            set
            {
                base.SetValue(ProcessActivity.ArgumentsProperty, value);
            }
        }

        public static DependencyProperty CreateNoWindowProperty = System.Workflow.ComponentModel.DependencyProperty.Register("CreateNoWindow", typeof(bool), typeof(ProcessActivity), new PropertyMetadata(false));

        [Description("Gets or sets a value indicating whether to start the process in a new window. true to start the process without creating a new window to contain it; otherwise, false. The default is false.")]
        [Category("Start Info")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool CreateNoWindow
        {
            get
            {
                return ((bool)(base.GetValue(ProcessActivity.CreateNoWindowProperty)));
            }
            set
            {
                base.SetValue(ProcessActivity.CreateNoWindowProperty, value);
            }
        }

        public static DependencyProperty FileNameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("FileName", typeof(string), typeof(ProcessActivity), new PropertyMetadata(string.Empty));

        [Description("Gets or sets the application or document to start. The name of the application to start, or the name of a document of a file type that is associated with an application and that has a default open action available to it. The default is an empty string (\"\").")]
        [Category("Start Info")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string FileName
        {
            get
            {
                return ((string)(base.GetValue(ProcessActivity.FileNameProperty)));
            }
            set
            {
                base.SetValue(ProcessActivity.FileNameProperty, value);
            }
        }

        public static DependencyProperty RedirectStandardOutputProperty = System.Workflow.ComponentModel.DependencyProperty.Register("RedirectStandardOutput", typeof(bool), typeof(ProcessActivity), new PropertyMetadata(false));

        [Description("Gets or sets a value indicating whether the output of an application is written to the System.Diagnostics.Process.StandardOutput stream. true to write output to System.Diagnostics.Process.StandardOutput; otherwise, false.")]
        [Category("Start Info")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool RedirectStandardOutput
        {
            get
            {
                return ((bool)(base.GetValue(ProcessActivity.RedirectStandardOutputProperty)));
            }
            set
            {
                base.SetValue(ProcessActivity.RedirectStandardOutputProperty, value);
            }
        }

        public static DependencyProperty RedirectStandardInputProperty = System.Workflow.ComponentModel.DependencyProperty.Register("RedirectStandardInput", typeof(bool), typeof(ProcessActivity), new PropertyMetadata(false));

        [Description("Gets or sets a value indicating whether the input for an application is read from the System.Diagnostics.Process.StandardInput stream. true to read input from System.Diagnostics.Process.StandardInput; otherwise, false.")]
        [Category("Start Info")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool RedirectStandardInput
        {
            get
            {
                return ((bool)(base.GetValue(ProcessActivity.RedirectStandardInputProperty)));
            }
            set
            {
                base.SetValue(ProcessActivity.RedirectStandardInputProperty, value);
            }
        }

        public static DependencyProperty RedirectStandardErrorProperty = System.Workflow.ComponentModel.DependencyProperty.Register("RedirectStandardError", typeof(bool), typeof(ProcessActivity), new PropertyMetadata(false));

        [Description("Gets or sets a value indicating whether the error output of an application is written to the System.Diagnostics.Process.StandardError stream. true to write error output to System.Diagnostics.Process.StandardError; otherwise, false.")]
        [Category("Start Info")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool RedirectStandardError
        {
            get
            {
                return ((bool)(base.GetValue(ProcessActivity.RedirectStandardErrorProperty)));
            }
            set
            {
                base.SetValue(ProcessActivity.RedirectStandardErrorProperty, value);
            }
        }

        public static DependencyProperty UseShellExecuteProperty = System.Workflow.ComponentModel.DependencyProperty.Register("UseShellExecute", typeof(bool), typeof(ProcessActivity), new PropertyMetadata(true));

        [Description("Gets or sets a value indicating whether to use the operating system shell to start the process. true to use the shell when starting the process; otherwise, the process is created directly from the executable file. The default is true.")]
        [Category("Start Info")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool UseShellExecute
        {
            get
            {
                return ((bool)(base.GetValue(ProcessActivity.UseShellExecuteProperty)));
            }
            set
            {
                base.SetValue(ProcessActivity.UseShellExecuteProperty, value);
            }
        } 

        #endregion Start Info properties

        #region Process properties

        public static DependencyProperty TimeoutLengthProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TimeoutLength", typeof(int), typeof(ProcessActivity), new PropertyMetadata(0));

        [Description("The amount of time, in milliseconds, to wait for the associated process to exit. The maximum is the largest possible value of a 32-bit integer, which represents infinity to the operating system.")]
        [Category("Process")]
        [Browsable(true)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int TimeoutLength
        {
            get
            {
                return ((int)(base.GetValue(ProcessActivity.TimeoutLengthProperty)));
            }
            set
            {
                base.SetValue(ProcessActivity.TimeoutLengthProperty, value);
            }
        }

        public static DependencyProperty TimeoutProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Timeout", typeof(bool), typeof(ProcessActivity), new PropertyMetadata(false));

        [Description("Should the process timeout or wait indefinitely. Default value is false, is set to true the process will wait the value of TimeoutLength property in milliseconds.")]
        [Category("Process")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Timeout
        {
            get
            {
                return ((bool)(base.GetValue(ProcessActivity.TimeoutProperty)));
            }
            set
            {
                base.SetValue(ProcessActivity.TimeoutProperty, value);
            }
        }

        public static DependencyProperty StandardErrorProperty = System.Workflow.ComponentModel.DependencyProperty.Register("StandardError", typeof(StreamReader), typeof(ProcessActivity), new PropertyMetadata(null, DependencyPropertyOptions.ReadOnly));

        [Description("Gets a stream used to read the error output of the application.")]
        [Category("Process")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StreamReader StandardError
        {
            get
            {
                return ((StreamReader)(base.GetValue(ProcessActivity.StandardErrorProperty)));
            }
            set
            {
                base.SetValue(ProcessActivity.StandardErrorProperty, value);
            }
        }

        public static DependencyProperty StandardInputProperty = System.Workflow.ComponentModel.DependencyProperty.Register("StandardInput", typeof(StreamWriter), typeof(ProcessActivity), new PropertyMetadata(null, DependencyPropertyOptions.ReadOnly));

        [Description("Gets a stream used to write the input of the application.")]
        [Category("Process")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StreamWriter StandardInput
        {
            get
            {
                return ((StreamWriter)(base.GetValue(ProcessActivity.StandardInputProperty)));
            }
        }

        public static DependencyProperty StandardOutputProperty = System.Workflow.ComponentModel.DependencyProperty.Register("StandardOutput", typeof(StreamReader), typeof(ProcessActivity), new PropertyMetadata(null, DependencyPropertyOptions.ReadOnly));

        [Description("Gets a stream used to read the output of the application.")]
        [Category("Process")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StreamReader StandardOutput
        {
            get
            {
                return ((StreamReader)(base.GetValue(ProcessActivity.StandardOutputProperty)));
            }
        }

        public static DependencyProperty ExitedProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Exited", typeof(bool), typeof(ProcessActivity));

        [Description("true if the associated process has exited; otherwise, false.")]
        [Category("Process")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Exited
        {
            get
            {
                return ((bool)(base.GetValue(ProcessActivity.ExitedProperty)));
            }
        }

        #endregion Process properties

        protected override bool ProcessQueueItem(ActivityExecutionContext context, object item)
        {
            return this.UnregisterListener(context);
        }

        protected override bool SubscribeExternalEvent(ActivityExecutionContext context)
        {
            // Get a reference to the ProcessEventService
            ProcessEventService processService = context.GetService<ProcessEventService>();

            if (processService == null)
            {
                throw new InvalidOperationException("ProcessEventService is not available.");
            }

            this.EventSubscriptionId = processService.RegisterListenerAndRunProcess((context.Activity as ProcessActivity), this.WorkflowInstanceId, this.QueueName);

            return true;
        }

        protected override bool UnsubscribeExternalEvent(ActivityExecutionContext context)
        {
            return this.UnregisterListener(context);
        }

        private bool UnregisterListener(ActivityExecutionContext context)
        {
            ProcessEventService processService = context.GetService<ProcessEventService>();
            processService.UnregisterListener(this.EventSubscriptionId);
            return true;
        }
    }
}
