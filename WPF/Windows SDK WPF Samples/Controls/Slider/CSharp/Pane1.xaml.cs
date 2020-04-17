//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;

namespace SliderExample
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

    public partial class Pane1 : StackPanel
    {
 
        void OnClick(object sender, RoutedEventArgs e)
        {
            Slider hslider = new Slider();
            hslider.Orientation = Orientation.Horizontal;
            hslider.AutoToolTipPlacement =
              AutoToolTipPlacement.TopLeft;
            hslider.AutoToolTipPrecision = 2;
            hslider.IsDirectionReversed = true;
            hslider.Width = 100;
            hslider.IsMoveToPointEnabled = false;
            hslider.SelectionStart = 1.1;
            hslider.SelectionEnd = 3;
            hslider.IsSelectionRangeEnabled = false;
            hslider.IsSnapToTickEnabled = false;
            hslider.TickFrequency = 3;
            hslider.TickPlacement = TickPlacement.Both;
            cv1.Children.Add(hslider);
       }

        void OnClickNonUniform(object sender, RoutedEventArgs e)
        {
            Slider hslider = new Slider();
            hslider.Orientation = Orientation.Horizontal;
            hslider.Width = 100;
            hslider.IsMoveToPointEnabled = false;
            DoubleCollection tickMarks = new DoubleCollection();
            tickMarks.Add(1.1);
            tickMarks.Add(1.3);
            tickMarks.Add(2.0);
            tickMarks.Add(7.0);
            tickMarks.Add(10.0);
            hslider.Ticks = tickMarks;
            hslider.TickPlacement = TickPlacement.BottomRight;
            hslider.AutoToolTipPlacement =
              AutoToolTipPlacement.TopLeft;
            hslider.AutoToolTipPrecision = 2;
            hslider.IsSnapToTickEnabled = true;
            cv2.Children.Add(hslider);
       }
     }
}