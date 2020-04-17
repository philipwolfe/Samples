//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;

namespace Checkbox2
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

	public partial class Pane1 : StackPanel
	{
		// To use PaneLoaded put Loaded="PaneLoaded" in root element of .xaml file.
		// private void PaneLoaded(object sender, EventArgs e) {}
		// Sample event handler:  
		// private void ButtonClick(object sender, ClickEventArgs e) {}
	private void HandleChange(object sender, RoutedEventArgs e)
	{
	    cb1.Content = "You clicked the check box";
	}

        private void HandleChange1(object sender, RoutedEventArgs e)
        {
            txt.FontSize = 16;
            txt.Text = "I took this photo yesterday.";
        }

        private void HandleChange2(object sender, RoutedEventArgs e)
	{
	    txt3.FontSize = 16;
	    txt3.Text = "My favorite photo.";
	}
   }
        
}