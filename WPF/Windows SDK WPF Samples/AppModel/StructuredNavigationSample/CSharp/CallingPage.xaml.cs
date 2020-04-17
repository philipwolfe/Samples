using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace StructuredNavigationSample
{
    public partial class CallingPage : Page
    {
        public CallingPage()
        {
            InitializeComponent();
        }

        void callingPage_Loaded(object sender, RoutedEventArgs e)
        {
            // If a task happened, get task result
            if (Application.Current.Properties["TaskResult"] == null) return;
            bool taskResult = (bool)Application.Current.Properties["TaskResult"];

            // Display task result and data
            this.taskResultsTextBlock.Visibility = Visibility.Visible;

            // Display task result
            this.taskResultsTextBlock.Text = (taskResult == true ? "Accepted" : "Canceled");
            if (!taskResult) return;

            // If a task happened, display task data
            string taskData = (string)Application.Current.Properties["TaskData"];
            if (taskData == null) return;
            this.taskResultsTextBlock.Text += "\n" + taskData;

            // Remove result and data
            Application.Current.Properties["TaskResult"] = null;
            Application.Current.Properties["TaskData"] = null;
        }

        void startTaskUNHyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Instantiate and navigate to task page
            TaskPage taskPage = new TaskPage("Initial Data Item Value");
            this.NavigationService.Navigate(taskPage);
        }

        void startTaskSNHyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Instantiate and navigate to task page function
            TaskPageFunction taskPageFunction = new TaskPageFunction("Initial Data Item Value");
            taskPageFunction.Return += taskPageFunction_Return;
            this.NavigationService.Navigate(taskPageFunction);
        }

        void taskPageFunction_Return(object sender, ReturnEventArgs<string> e)
        {
            // Display task result and data
            this.taskResultsTextBlock.Visibility = Visibility.Visible;

            // Display task result
            this.taskResultsTextBlock.Text = (e != null ? "Accepted" : "Canceled");
            if (e == null) return;

            // If a task happened, display task data
            this.taskResultsTextBlock.Text += "\n" + e.Result;
        }
    }
}
