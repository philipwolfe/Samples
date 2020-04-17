//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
//Using System.Windows.Input;

namespace Menus
{
	
	public partial class Pane1 : Canvas
	{
        System.Windows.Controls.Menu menu;
        System.Windows.Controls.MenuItem mi, mia, mib, mic;

        void OnClick(object sender, RoutedEventArgs e)
		{
                menu = new Menu();
                menu.Background = Brushes.LightBlue;
                mi = new MenuItem();
                mi.Width = 50;
                mi.Header = "_File";
                menu.Items.Add(mi);

                mia = new MenuItem();
                mia.Header = "_Cut";
                mia.InputGestureText = "Ctrl+X";
                mi.Items.Add(mia);

                mib = new MenuItem();
                mib.Command = System.Windows.Input.ApplicationCommands.Copy;
                mib.Header = "_Copy";
                mi.Items.Add(mib);

                mic = new MenuItem();
                mic.Command = System.Windows.Input.ApplicationCommands.Paste;
                mic.Header = "_Paste";
                mi.Items.Add(mic);
                cv2.Children.Add(menu);
		}

        void ExtraSnippet()
        {
            // Neil didn't want this in the main snippet in How to: Create a Menu
            // but since it was wrapped in its own snippet, I didn't want to delete it.
            // Will chack for references after RTM and change it.
            menu.Width = SystemParameters.CaptionWidth;
         
        }

	}
}