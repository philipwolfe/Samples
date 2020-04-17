namespace AdaptiveTopologySample
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
        public TaskPage2(object taskData)
        {
            InitializeComponent();

            // Bind task state to UI
            this.DataContext = taskData;
            
            this.Loaded += new RoutedEventHandler(TaskPage2_Loaded);
        }

        void TaskPage2_Loaded(object sender, RoutedEventArgs e)
        {
            // Enable buttons based on position
            this.backButton.IsEnabled = TaskNavigationHub.Current.CanGoBack(this);
            this.nextButton.IsEnabled = TaskNavigationHub.Current.CanGoNext(this);
            this.nextButton.IsDefault = TaskNavigationHub.Current.CanGoNext(this);
            this.finishButton.IsEnabled = TaskNavigationHub.Current.CanFinish(this);
            this.finishButton.IsDefault = TaskNavigationHub.Current.CanFinish(this);
        }

        void backButton_Click(object sender, RoutedEventArgs e)
        {
            // Go to previous task page
            this.NavigationService.GoBack();
        }

        void nextButton_Click(object sender, RoutedEventArgs e)
        {
            // Go to next task page
            if (this.NavigationService.CanGoForward) this.NavigationService.GoForward();
            else
            {
                PageFunction<TaskResult> nextPage = TaskNavigationHub.Current.GetNextTaskPage(this);
                nextPage.Return += new ReturnEventHandler<TaskResult>(taskPage_Return);
                this.NavigationService.Navigate(nextPage);
            }
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

        public void taskPage_Return(object sender, ReturnEventArgs<TaskResult> e)
        {
            // This is called when the next page returns, so return what they are returning
            OnReturn(e);
        }
    }
}