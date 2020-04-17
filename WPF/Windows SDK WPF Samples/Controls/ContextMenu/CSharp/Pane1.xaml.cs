//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;

namespace ContextMenus
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

	public partial class Pane1 : Canvas
	{
        System.Windows.Controls.ContextMenu contextmenu;
        System.Windows.Controls.MenuItem mi, mia, mib, mib1, mib1a;
        System.Windows.Controls.Button btn;

        void OnOpened(object sender, RoutedEventArgs e)
                {
                 if(cm.IsOpen==true)
                   {
                    cmButton.Content = "The ContextMenu opened and the IsOpen property is true."; 
                   }
                 else
                   {
                    cmButton.Content = "The ContextMenu Opened"; 
                   }
                }
        void OnClosed(object sender, RoutedEventArgs e)
                {
                 cmButton.Content = "The ContextMenu Closed";
                }

        void OnClick(object sender, RoutedEventArgs e)
		{ 
                  btn = new Button();
                  btn.Content = "Created with C#";
                  contextmenu = new ContextMenu();
                  btn.ContextMenu = contextmenu;
                  mi = new MenuItem();
                  mi.Header = "File";
                  mia = new MenuItem();
                  mia.Header = "New";
                  mi.Items.Add(mia);
                  mib = new MenuItem();
                  mib.Header = "Open";
                  mi.Items.Add(mib);
                  mib1 = new MenuItem();
                  mib1.Header = "Recently Opened";
                  mib.Items.Add(mib1);
                  mib1a = new MenuItem();
                  mib1a.Header = "Text.xaml";
                  mib1.Items.Add(mib1a);
                  contextmenu.Items.Add(mi);
                  cv2.Children.Add(btn);
		}

	}
}