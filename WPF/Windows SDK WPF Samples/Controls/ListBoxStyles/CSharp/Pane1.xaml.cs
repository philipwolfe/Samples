//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace ListBoxStyles
{

	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

	public partial class Pane1 : Canvas
	{
		void PrintText(object sender, SelectionChangedEventArgs args)
		{
			ListBoxItem li = ((sender as ListBox).SelectedItem as ListBoxItem);

			tb.Text = "   You selected " + li.Content.ToString() + ".";
		}
	}
}