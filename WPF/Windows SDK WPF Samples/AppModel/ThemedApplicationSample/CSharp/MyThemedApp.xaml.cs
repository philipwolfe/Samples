using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace ThemedApplicationSample_CSharp
{
    public partial class MyThemedApp : Application
    {
        void MyThemedApp_Startup(object sender, StartupEventArgs e)
        {
            Properties["Blue"] = (ResourceDictionary)Application.LoadComponent(new Uri("BlueTheme.xaml", UriKind.Relative));
            Properties["Yellow"] = (ResourceDictionary)Application.LoadComponent(new Uri("YellowTheme.xaml", UriKind.Relative));

            // Note: you can also use the following syntax:
            //   Themes["Yellow"] = new YellowTheme()
            // But only as long as you implement the ResourceDictionary using markup and code-behind,
            // use the x:Class attribute in markup, and call InitializeComponent() from code-behind, eg:
            //
            //   <!-- Markup -->
            //   <ResourceDictionary
            //     xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            //     xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            //     xmlns:local="clr-namespace:ThemedApplicationSample_CSharp" 
            //     x:Class="ThemedApplicationSample_CSharp.YellowTheme">
            //        ...
            //   </ResourceDictionary>
            //
            //   // Code-behind
            //   public partial class YellowTheme : ResourceDictionary
            //   {
            //     public YellowTheme() { InitializeComponent(); }
            //   }
        }
    }
}