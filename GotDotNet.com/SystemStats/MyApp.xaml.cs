#define Debug  //Workaround - This allows Debug.Write to work.

//This is a list of commonly used namespaces for an application class.
using System;
using MSAvalon.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace SystemStats
{
    /// <summary>
    /// Interaction logic for Application.xaml
    /// </summary>

    public partial class MyApp : Application
    {
		void AppStartingUp(object sender, StartingUpCancelEventArgs e)
		{
			Window mainWindow = new Main();
			mainWindow.Show();
		}

    }
}