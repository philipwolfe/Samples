//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace repeatbuttonstyles
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
		void Increase(object sender, RoutedEventArgs e)
		{
			Int32 Num = Convert.ToInt32(btn.Content);
			
			btn.Content = ((Num + 1).ToString());
		}

	}
}