//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace ContextMenuStyles
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

	public partial class Pane1 : StackPanel
	{
        string status;

        void StatusClick(object sender, RoutedEventArgs e)
        {

            MenuItem menu = (MenuItem)sender;

            status = (string)menu.Header;
            if (status.Equals("Online"))
            {
                mi1.IsChecked = true;
                mi2.IsChecked = false;
                mi3.IsChecked = false;
                mi4.IsChecked = false;
            }
            else if (status.Equals("Busy"))
            {
                mi1.IsChecked = false;
                mi2.IsChecked = true;
                mi3.IsChecked = false;
                mi4.IsChecked = false;
            }
            else if (status.Equals("Be Right Back"))
            {
                mi1.IsChecked = false;
                mi2.IsChecked = false;
                mi3.IsChecked = true;
                mi4.IsChecked = false;
            }
            else if (status.Equals("Away"))
            {
                mi1.IsChecked = false;
                mi2.IsChecked = false;
                mi3.IsChecked = false;
                mi4.IsChecked = true;
            }

        }

    }
}