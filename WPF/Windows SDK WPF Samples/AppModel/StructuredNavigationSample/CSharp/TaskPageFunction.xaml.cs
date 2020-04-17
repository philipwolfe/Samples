using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace StructuredNavigationSample
{
    public partial class TaskPageFunction : PageFunction<String>
    {
        public TaskPageFunction(string initialDataItem1Value)
        {
            InitializeComponent();

            // Set initial value
            this.dataItem1TextBox.Text = initialDataItem1Value;
        }

        void okButton_Click(object sender, RoutedEventArgs e)
        {
            // Accept task when Ok button is clicked
            OnReturn(new ReturnEventArgs<string>(this.dataItem1TextBox.Text));
        }

        void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Cancel task
            OnReturn(null);
        }
    }
}