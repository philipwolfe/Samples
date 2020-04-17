//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Samples.WF.WorkflowInstances
{
    using System;
    using System.Activities;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Threading;
    using Microsoft.Win32;

    public partial class HostView : Window, IHostView
    {
        List<WorkflowInstanceInfo> instanceInfos;
        WorkflowInstanceManager manager;
        WindowTextWriter outputWriter;
        WindowTextWriter errorWriter;
        bool usePersistence;
        bool useActivityTracking;
        ICollectionView defaultView;

        public HostView()
        {
            this.instanceInfos = new List<WorkflowInstanceInfo>();
            InitializeComponent();
            this.outputWriter = new WindowTextWriter(this.outputTextBox);
            this.errorWriter = new WindowTextWriter(this.errorTextBox);
        }

        public TextWriter OutputWriter
        {
            get
            {
                return this.outputWriter;
            }
        }

        public TextWriter ErrorWriter
        {
            get
            {
                return this.errorWriter;
            }
        }

        public bool UsePersistence
        {
            get
            {
                return this.usePersistence;
            }
        }

        public bool UseActivityTracking
        {
            get
            {
                return this.useActivityTracking;
            }
        }

        public void Initialize(WorkflowInstanceManager manager)
        {
            this.manager = manager;
            this.manager.LoadExistingInstances();
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(OnDataContextChanged);
            this.defaultView = CollectionViewSource.GetDefaultView(this.instanceInfos);
            this.DataContext = this.instanceInfos;
            this.defaultView.CurrentChanged += new EventHandler(OnCurrentChanged);
        }

        public void UpdateInstances(List<WorkflowInstanceInfo> instances)
        {
            this.Dispatcher.BeginInvoke(
                new Action(() =>
                {
                    WorkflowInstanceInfo originalInstanceInfo = CurrentWorkflowInstanceInfo;

                    this.instanceInfos = instances;
                    this.DataContext = instanceInfos;

                    if (originalInstanceInfo != null)
                    {
                        originalInstanceInfo = instances.Find(instanceInfo => instanceInfo.Id == originalInstanceInfo.Id);
                        if (originalInstanceInfo != null && this.defaultView != null)
                        {
                            this.defaultView.MoveCurrentTo(originalInstanceInfo);
                        }
                    }

                }), DispatcherPriority.DataBind);
        }

        public TextWriter CreateInstanceWriter()
        {
            return new WindowTextWriter(this.instanceOutputTextBox);
        }

        public void SelectInstance(Guid id)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.DataBind, new Action(() =>
                {
                    //make the InstanceInfo with the matching id the current item                    
                    this.defaultView.MoveCurrentTo(this.instanceInfos.Find(instanceInfo => instanceInfo.Id == id));
                }));
        }

        public void Dispatch(Action work)
        {
            this.Dispatcher.BeginInvoke(work, DispatcherPriority.Background);
        }

        void SetUiState()
        {
            if (this.IsInitialized)
            {
                WorkflowInstanceInfo currentInstanceInfo = CurrentWorkflowInstanceInfo;
                bool currentInstanceInfoIsNull = currentInstanceInfo == null;
                bool currentInstanceInfoIsLoaded = !currentInstanceInfoIsNull && currentInstanceInfo.IsLoaded;

                this.abortButton.IsEnabled = currentInstanceInfoIsLoaded;
                this.cancelButton.IsEnabled = currentInstanceInfoIsLoaded;
                this.terminateButton.IsEnabled = currentInstanceInfoIsLoaded;
                SetResumeBookmarkButtonState();
            }
        }

        void SetResumeBookmarkButtonState()
        {
            if (this.IsInitialized)
            {
                this.resumeBookmarkButton.IsEnabled = (this.bookmarksComboBox.SelectedIndex != -1) && !string.IsNullOrEmpty(this.bookmarkValueTextBox.Text);
            }
        }

        WorkflowInstanceInfo CurrentWorkflowInstanceInfo
        {
            get
            {
                return CollectionViewSource.GetDefaultView(this.DataContext).CurrentItem as WorkflowInstanceInfo;
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            if (this.manager == null)
            {
                throw new InvalidOperationException("The HostView must be initialized with a WorkflowInstanceHost before being activated.");
            }
            base.OnActivated(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            this.manager.Close();
            this.outputWriter.Close();
            this.errorWriter.Close();
            base.OnClosed(e);
        }

        void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.defaultView.CurrentChanged -= new EventHandler(OnCurrentChanged);
            this.defaultView = CollectionViewSource.GetDefaultView(this.DataContext);
            this.defaultView.CurrentChanged += new EventHandler(OnCurrentChanged);
        }

        void OnCurrentChanged(object sender, EventArgs e)
        {
            WorkflowInstanceInfo currentInstanceInfo = CurrentWorkflowInstanceInfo;

            if (currentInstanceInfo != null)
            {
                this.instanceOutputTextBox.Text = currentInstanceInfo.InstanceWriter.ToString();
            }
            SetUiState();
        }

        void OnRunButtonClicked(object sender, RoutedEventArgs e)
        {
            string path = this.definitionPathTextBox.Text;
            if (string.IsNullOrEmpty(path))
            {
                this.ErrorWriter.WriteLine("Please specify a valid path to a xaml workflow definition.");
            }
            else
            {
                this.manager.Run(this.definitionPathTextBox.Text);
            }
        }

        void OnBrowseDefinitionsButtonClicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Xaml files (*.xaml, *.xamlx)|*.xaml;*.xamlx",
                Multiselect = false,
                Title = "Open Workflow Definition"
            };
            Nullable<bool> fileSelected = openFileDialog.ShowDialog();
            if (fileSelected.HasValue && fileSelected.Value)
            {
                this.definitionPathTextBox.Text = openFileDialog.FileName;
            }
        }

        void OnCancelButtonClicked(object sender, RoutedEventArgs e)
        {
            WorkflowInstanceInfo instanceInfo = this.CurrentWorkflowInstanceInfo;
            this.manager.Cancel(instanceInfo.Id);
        }

        void OnTerminateButtonClicked(object sender, RoutedEventArgs e)
        {
            WorkflowInstanceInfo instanceInfo = this.CurrentWorkflowInstanceInfo;
            this.manager.Terminate(instanceInfo.Id, "User initiated Terminate");
        }

        void OnAbortButtonClicked(object sender, RoutedEventArgs e)
        {
            WorkflowInstanceInfo instanceInfo = this.CurrentWorkflowInstanceInfo;
            this.manager.Abort(instanceInfo.Id, "User requested Abort");
        }

        void OnResumeBookmarkButtonClicked(object sender, RoutedEventArgs e)
        {
            WorkflowInstanceInfo instanceInfo = this.CurrentWorkflowInstanceInfo;
            BookmarkInfo bookmarkInfo = this.bookmarksComboBox.SelectedItem as BookmarkInfo;

            if (instanceInfo != null && bookmarkInfo != null)
            {
                this.manager.ResumeBookmark(instanceInfo.Id, bookmarkInfo.BookmarkName, this.bookmarkValueTextBox.Text);
            }
            this.bookmarkValueTextBox.Text = string.Empty;
        }

        void UsePersistenceCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            this.usePersistence = this.usePersistenceCheckBox.IsChecked.HasValue && this.usePersistenceCheckBox.IsChecked.Value;
        }

        void UseActivityTrackingCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            this.useActivityTracking = this.useActivityTrackingCheckBox.IsChecked.HasValue && this.useActivityTrackingCheckBox.IsChecked.Value;
        }

        void OnBookmarksComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetResumeBookmarkButtonState();
        }

        void OnBookmarkValueTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            SetResumeBookmarkButtonState();
        }

        void OnScrollableTextChanged(object sender, TextChangedEventArgs e)
        {
            ((TextBox)sender).ScrollToEnd();
        }
    }
}
