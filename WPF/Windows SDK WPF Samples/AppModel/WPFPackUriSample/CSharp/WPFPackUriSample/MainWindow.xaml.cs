using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WPFPackUriSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        
        void click0(object sender, RoutedEventArgs e) {
            Uri uri = new Uri("/VersionedReferencedAssembly;v1.0.0.0;component/ResourceFile.xaml", UriKind.RelativeOrAbsolute);
            this.frame.Source = uri;
        }

        void click1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("/VersionedReferencedAssembly;v1.0.0.1;component/ResourceFile.xaml", UriKind.RelativeOrAbsolute);
            this.frame.Source = uri;
        }
    }
}