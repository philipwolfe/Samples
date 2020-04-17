using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Viewbox_Stretch_Layout_Samp
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	public partial class Window1 : Window
	{
        public void stretchNone(object sender, RoutedEventArgs e)
        {
            vb1.Stretch = System.Windows.Media.Stretch.None;
            txt1.Text = "Stretch is now set to None.";
        }

        public void stretchFill(object sender, RoutedEventArgs e)
        {
            vb1.Stretch = System.Windows.Media.Stretch.Fill;
            txt1.Text = "Stretch is now set to Fill.";
        }

        public void stretchUni(object sender, RoutedEventArgs e)
        {
            vb1.Stretch = System.Windows.Media.Stretch.Uniform;
            txt1.Text = "Stretch is now set to Uniform.";
        }

        public void stretchUniFill(object sender, RoutedEventArgs e)
        {
            vb1.Stretch = System.Windows.Media.Stretch.UniformToFill;
            txt1.Text = "Stretch is now set to UniformToFill.";
        }

        public void sdUpOnly(object sender, RoutedEventArgs e)
        {
            vb1.StretchDirection = System.Windows.Controls.StretchDirection.UpOnly;
            txt2.Text = "StretchDirection is now UpOnly.";
        }

        public void sdDownOnly(object sender, RoutedEventArgs e)
        {
            vb1.StretchDirection = System.Windows.Controls.StretchDirection.DownOnly;
            txt2.Text = "StretchDirection is now DownOnly.";
        }

        public void sdBoth(object sender, RoutedEventArgs e)
        {
            vb1.StretchDirection = System.Windows.Controls.StretchDirection.Both;
            txt2.Text = "StretchDirection is now Both.";
        }

    }
}