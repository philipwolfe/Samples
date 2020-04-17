using System;
using System.Windows;
using System.Configuration;
using System.Reflection;
using System.IO;

namespace WPFPackUriSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            
            // Load two different versions an assembly with the same name
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Assembly.LoadFile(path + @"\VersionedReferencedAssembly.dll");
            Assembly.LoadFile(path + @"\Subfolder\VersionedReferencedAssembly.dll");
        }

    }
}