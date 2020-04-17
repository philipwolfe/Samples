namespace FixedLinearTopologySample
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    public partial class CallingPage : Page
    {
        public CallingPage()
        {
            InitializeComponent();
        }

        void startTaskHyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Launch the task
            TaskLauncher taskLauncher = new TaskLauncher();
            taskLauncher.Return += new ReturnEventHandler<TaskContext>(task_Return);
            this.NavigationService.Navigate(taskLauncher);
        }

        /// <summary>
        ///  Determine how the task completed and, if accepted, process the collected task state
        /// </summary>
        public void task_Return(object sender, ReturnEventArgs<TaskContext> e)
        {
            // Get task state
            TaskContext taskContext = e.Result;

            this.taskResultsTextBlock.Visibility = Visibility.Visible;
            
            // How did the task end?
            this.taskResultsTextBlock.Text += "\n" + taskContext.Result.ToString();
            
            // If the task completed by being accepted, display task data
            if (taskContext.Result == TaskResult.Finished)
            {
                this.taskResultsTextBlock.Text += "\nData Item 1: " + ((TaskData)taskContext.Data).DataItem1;
                this.taskResultsTextBlock.Text += "\nData Item 2: " + ((TaskData)taskContext.Data).DataItem2;
                this.taskResultsTextBlock.Text += "\nData Item 3: " + ((TaskData)taskContext.Data).DataItem3;
            }
        }
    }
}