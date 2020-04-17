using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace StructuredNavigationSample
{
    public partial class TaskPage : Page
    {
        public TaskPage(string initialDataItem1Value)
        {
            InitializeComponent();

            // Set initial value
            this.dataItem1TextBox.Text = initialDataItem1Value;
        }

        void okButton_Click(object sender, RoutedEventArgs e)
        {
            // Accept task when Ok button is clicked
            TaskPageReturn(true);
        }

        void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Cancel task
            TaskPageReturn(false);
        }

        void TaskPageReturn(bool taskResult)
        {
            Application.Current.Properties["TaskResult"] = taskResult;
            Application.Current.Properties["TaskData"] = this.dataItem1TextBox.Text;

            // Return to calling page
            this.NavigationService.GoBack();

            // Removing this page from navigation history 
            this.NavigationService.RemoveBackEntry();
        }
    }
}