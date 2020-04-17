namespace FixedHierarchicalTopologySample
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    /// <summary>
    /// Interaction logic for TaskPage2.xaml
    /// </summary>

    public partial class TaskPage2 : PageFunction<TaskResult>
    {
        public TaskPage2(TaskData taskData)
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

        void nextButton_Click(object sender, RoutedEventArgs e)
        {
            // If young, go to TaskPage3, else go to TaskPage4
            if ((bool)this.youngRadioButton.IsChecked)
            {
                // Clear data that may have been collected if users went to TaskPage4,
                // entered data, clicked Back to come here, and now wants to go to TaskPage3
                ((TaskData)this.DataContext).DataItem4 = null;

                TaskPage3 taskPage3 = new TaskPage3((TaskData)this.DataContext);
                taskPage3.Return += new ReturnEventHandler<TaskResult>(taskPage_Return);
                this.NavigationService.Navigate(taskPage3);
            }
            else
            {
                // Clear data that may have been collected if users went to TaskPage4,
                // entered data, clicked Back to come here, and now wants to go to TaskPage3
                ((TaskData)this.DataContext).DataItem3 = null;

                TaskPage4 taskPage4 = new TaskPage4((TaskData)this.DataContext);
                taskPage4.Return += new ReturnEventHandler<TaskResult>(taskPage_Return);
                this.NavigationService.Navigate(taskPage4);
            }
        }

        void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Cancel the task and don't return any data
            OnReturn(new ReturnEventArgs<TaskResult>(TaskResult.Canceled));
        }

        public void taskPage_Return(object sender, ReturnEventArgs<TaskResult> e)
        {
            // If returning, task was completed (finished or canceled),
            // so continue returning to calling page
            OnReturn(e);
        }
    }
}