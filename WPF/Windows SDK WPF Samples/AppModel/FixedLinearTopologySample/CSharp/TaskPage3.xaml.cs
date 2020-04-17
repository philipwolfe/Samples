namespace FixedLinearTopologySample
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    public partial class TaskPage3 : PageFunction<TaskResult>
    {
        public TaskPage3(TaskData taskData)
        {
            InitializeComponent();

            // Bind task state to UI
            this.DataContext = taskData;
        }

        void backButton_Click(object sender, RoutedEventArgs e)
        {
            // Go to previous task page
            this.NavigationService.GoBack();
        }

        void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Cancel the task and don't return any data
            OnReturn(new ReturnEventArgs<TaskResult>(TaskResult.Canceled));
        }

        void finishButton_Click(object sender, RoutedEventArgs e)
        {
            // Finish the task and return bound data to calling page
            OnReturn(new ReturnEventArgs<TaskResult>(TaskResult.Finished));
        }
    }
}