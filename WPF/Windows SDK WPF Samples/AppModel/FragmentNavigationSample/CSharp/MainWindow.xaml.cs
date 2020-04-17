using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FragmentNavigationSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void goButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Uri, with or with out fragment
            // NOTE - Uri with fragment looks like "DocumentPage.xaml#Fragment5"
            Uri uri = new Uri(this.addressTextBox.Text, UriKind.RelativeOrAbsolute);
            this.browserFrame.Navigate(uri);
        }
        void browserFrame_FragmentNavigation(object sender, FragmentNavigationEventArgs e)
        {
            object content = ((ContentControl)e.Navigator).Content;
            FrameworkElement fragmentElement = LogicalTreeHelper.FindLogicalNode((DependencyObject)content, e.Fragment) as FrameworkElement;
            if (fragmentElement != null)
            {
                // Go to fragment if found
                fragmentElement.BringIntoView();
            }
            else
            {
                // Redirect to error page
                this.browserFrame.Navigate(new Uri("FragmentNotFoundPage.xaml", UriKind.Relative));
            }
            e.Handled = true;
        }
    }
}