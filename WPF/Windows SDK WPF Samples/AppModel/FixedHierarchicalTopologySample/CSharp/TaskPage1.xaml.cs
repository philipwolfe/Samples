namespace FixedHierarchicalTopologySample
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    /// <summary>
    /// Interaction logic for TaskPage1.xaml
    /// </summary>

    public partial class TaskPage1 : PageFunction<TaskResult>
    {
        public TaskPage1(TaskData taskData)
        {
            InitializeComponent();

            // Bind task state to UI
            this.DataContext = taskData;
        }

        void nextButton_Click(object sender, RoutedEventArgs e)
        {
            // Go to next task page
            TaskPage2 taskPage2 = new TaskPage2((TaskData)this.DataContext);
            taskPage2.Return += new ReturnEventHandler<TaskResult>(taskPage_Return);
            this.NavigationService.Navigate(taskPage2);
        }

        void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Cancel the task and don't return any data
            OnReturn(new ReturnEventArgs<TaskResult>(TaskResult.Canceled)); ;
        }

        public void taskPage_Return(object sender, ReturnEventArgs<TaskResult> e)
        {
            // If returning, task was completed (finished or canceled),
            // so continue returning to calling page
            OnReturn(e);
        }
    }
}