using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Controls.Primitives;


namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        private void OnStart(object sender, EventArgs e)
        {
            //these properties are already set in XAML, but 
            //shown here to demonstrate how to set them in code
            mytt.Placement = PlacementMode.Bottom;
            LengthConverter myLengthConverter = new LengthConverter();
            mytt.HorizontalOffset =
                (double)myLengthConverter.ConvertFromString("0.1in");
            mytt.VerticalOffset =
                (double)myLengthConverter.ConvertFromString("0.1in");
            Rect placementRect = new Rect(50, 50, 0, 0);
            mytt.PlacementRectangle = placementRect;
        }
        public void OnOpen(object sender, RoutedEventArgs e)
        {
            tipText.Text = tip.Text;
        }

        public void OnClose(object sender, RoutedEventArgs e)
        {
            tip.Text = "";
        }


    }
}
