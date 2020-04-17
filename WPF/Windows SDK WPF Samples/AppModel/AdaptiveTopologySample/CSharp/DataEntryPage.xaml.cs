namespace AdaptiveTopologySample
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    /// <summary>
    /// Interaction logic for DataEntryPage.xaml
    /// </summary>

    public partial class DataEntryPage : PageFunction<TaskContext>
    {
        public DataEntryPage()
        {
            InitializeComponent();
        }

        void okButton_Click(object sender, RoutedEventArgs e)
        {
            // Go to next task - as determined by the navigation hub
            TaskNavigationDirection direction = ((bool)this.forwardsRadioButton.IsChecked ? TaskNavigationDirection.Forwards : TaskNavigationDirection.Reverse);
            OnReturn(new ReturnEventArgs<TaskContext>(new TaskContext(TaskResult.Finished, direction)));
        }

        void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Cancel the task and don't return any data
            OnReturn(new ReturnEventArgs<TaskContext>(new TaskContext(TaskResult.Canceled, null)));
        }
    }
}