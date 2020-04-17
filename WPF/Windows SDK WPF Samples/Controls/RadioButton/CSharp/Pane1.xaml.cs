//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace RadioButtonSimple
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

	public partial class Pane1 : DockPanel
	{
		void WriteText(object sender, RoutedEventArgs e)
		{
		rb.Content = "You followed directions.";
		}

                void WriteText2(object sender, RoutedEventArgs e)
		{
	        RadioButton li = (sender as RadioButton);
                txtb.Text = "You clicked " + li.Content.ToString() + ".";
                }		
	}
}