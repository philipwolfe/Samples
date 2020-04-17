//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.ExecutionProperties
{
    using System;
    using System.Activities;

    public sealed class ConsoleColorScope : NativeActivity
    {
        public ConsoleColorScope()
            : base()
        {
        }

        public ConsoleColor Color { get; set; }
        public WorkflowElement Body { get; set; }

        protected override void Execute(ActivityExecutionContext context)
        {
            context.Properties.Add(ConsoleColorProperty.Name, new ConsoleColorProperty(this.Color));

            if (this.Body != null)
            {
                context.ScheduleActivity(this.Body);
            }
        }

        class ConsoleColorProperty : IExecutionProperty
        {
            public const string Name = "ConsoleColorProperty";

            ConsoleColor original;
            ConsoleColor color;

            public ConsoleColorProperty(ConsoleColor color)
            {
                this.color = color;
            }

            void IExecutionProperty.SetupWorkflowThread()
            {
                original = Console.ForegroundColor;
                Console.ForegroundColor = color;
            }

            void IExecutionProperty.CleanupWorkflowThread()
            {
                Console.ForegroundColor = original;
            }
        }
    }
}