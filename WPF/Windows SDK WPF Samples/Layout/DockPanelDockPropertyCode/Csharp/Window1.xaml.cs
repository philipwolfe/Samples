using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace dockpanel_dockprop_cs
{
    public partial class Page1 : Page
    {

        public void OnClick1(object sender, RoutedEventArgs e)
        {
            DockPanel.SetDock(rect1, Dock.Left);
            Txt1.Text = "The Dock Property of the LightCoral Rectangle is set to Left";
        }
        
        public void OnClick2(object sender, RoutedEventArgs e)
        {
            DockPanel.SetDock(rect1, Dock.Right);
            Txt1.Text = "The Dock Property of the LightCoral Rectangle is set to Right";
        }

        public void OnClick3(object sender, RoutedEventArgs e)
        {
            DockPanel.SetDock(rect1, Dock.Top);
            Txt1.Text = "The Dock Property of the LightCoral Rectangle is set to Top";
        }

        public void OnClick4(object sender, RoutedEventArgs e)
        {
            DockPanel.SetDock(rect1, Dock.Bottom);
            Txt1.Text = "The Dock Property of the LightCoral Rectangle is set to Bottom";
        }

        public void OnClick5(object sender, RoutedEventArgs e)
        {
            DockPanel.SetDock(rect2, Dock.Left);
            Txt2.Text = "The Dock Property of the LightSkyBlue Rectangle is set to Left";
        }

        public void OnClick6(object sender, RoutedEventArgs e)
        {
            DockPanel.SetDock(rect2, Dock.Right);
            Txt2.Text = "The Dock Property of the LightSkyBlue Rectangle is set to Right";
        }

        public void OnClick7(object sender, RoutedEventArgs e)
        {
            DockPanel.SetDock(rect2, Dock.Top);
            Txt2.Text = "The Dock Property of the LightSkyBlue Rectangle is set to Top";
        }

        public void OnClick8(object sender, RoutedEventArgs e)
        {
            DockPanel.SetDock(rect2, Dock.Bottom);
            Txt2.Text = "The Dock Property of the LightSkyBlue Rectangle is set to Bottom";
        }

        public void OnClick9(object sender, RoutedEventArgs e)
        {
            myDP.LastChildFill = true;
            Txt3.Text = "The LastChildFill property is set to True (default)";
        }

        public void OnClick10(object sender, RoutedEventArgs e)
        {
            myDP.LastChildFill = false;
            Txt3.Text = "The LastChildFill property is set to True False";
        }


    }
}