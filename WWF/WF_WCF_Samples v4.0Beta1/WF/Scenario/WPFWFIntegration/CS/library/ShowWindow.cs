//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Activities.Samples
{
    using System;
    using System.Windows;
    using System.Windows.Markup;
    using System.Windows.Threading;
    using System.Activities;
    using System.Xaml;

    [ContentProperty("Window")]
    public sealed class ShowWindow : CodeActivity
    {
        Func<Window> windowTemplate;

        //need to defer loading here because you want a window to be created for each
        //activity execution - not when the activity is deserialized.
        [XamlDeferLoad(typeof(FuncFactoryDeferringLoader), typeof(Window))]
        public Func<Window> Window
        {
            get { return this.windowTemplate; }
            set { this.windowTemplate = value; }
        }


        protected override void Execute(CodeActivityContext context)
        {
            if (Application.Current == null)
            {
                throw new InvalidOperationException("Must have an application");
            }

            AsyncOperationContext asyncContext = context.SetupAsyncOperationBlock();
            DispatcherSynchronizationContext syncContext = new DispatcherSynchronizationContext(Application.Current.Dispatcher);
            syncContext.Post(Show, new WindowContext() { AsyncOperationContext = asyncContext, DataContext = context.DataContext });
        }

        void OnClose(ActivityExecutionContext context, Bookmark bookmark, object state) { }

        void Show(object state)
        {
            WindowContext windowContext = (WindowContext)state;

            Window window = this.windowTemplate();
            window.DataContext = windowContext.DataContext;
            window.Closed += delegate(object sender, EventArgs e)
            {
                windowContext.AsyncOperationContext.CompleteOperation(OnClose, null);
            };
            window.Show();
        }

        struct WindowContext
        {
            public AsyncOperationContext AsyncOperationContext { get; set; }
            public object DataContext { get; set; }
        }
    }
}
