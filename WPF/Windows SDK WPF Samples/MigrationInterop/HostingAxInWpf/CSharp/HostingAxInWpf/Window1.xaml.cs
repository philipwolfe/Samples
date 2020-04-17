//<snippet10>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HostingAxInWpf
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e) 
        {
            // Create the interop host control.
            System.Windows.Forms.Integration.WindowsFormsHost host =
                new System.Windows.Forms.Integration.WindowsFormsHost();

            // Create the ActiveX control.
            AxWMPLib.AxWindowsMediaPlayer axWmp = new AxWMPLib.AxWindowsMediaPlayer();

            // Assign the ActiveX control as the host control's child.
            host.Child = axWmp;

            // Add the interop host control to the Grid
            // control's collection of child controls.
            this.grid1.Children.Add(host);

            // Play a .wav file with the ActiveX control.
            axWmp.URL = @"C:\WINDOWS\Media\Windows XP Startup.wav";
        }
    }
}
//</snippet10>