using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SDKSample
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}

        private void WindowLoaded(object sender, EventArgs e)
        {
            CreateOutlinedText01();
            CreateOutlinedText02();
        }

        private void CreateOutlinedText01()
        {
            OutlinedText outlinedText = new OutlinedText("Fancy Outlined Text");
            outlinedText.FontFamily = "Georgia Italic";
            outlinedText.FontSize = 96;
            outlinedText.Fill = Brushes.Gold;
            outlinedText.Stroke = Brushes.Green;
            outlinedText.CreateText();
            MyStackPanel.Children.Add(outlinedText);
        }

        private void CreateOutlinedText02()
        {
            OutlinedText outlinedText = new OutlinedText("Spectrum Outline");
            outlinedText.FontWeight = FontWeights.Bold;
            outlinedText.StrokeThickness = 4;
            outlinedText.Stroke = CreateLinearGradientSpectrumBrush();
            outlinedText.CreateText();
            MyStackPanel.Children.Add(outlinedText);
        }

        private LinearGradientBrush CreateLinearGradientSpectrumBrush()
        {
            GradientStopCollection gsc = new GradientStopCollection();
            gsc.Add(new GradientStop(Colors.Red, 0));
            gsc.Add(new GradientStop(Colors.Orange, 0.2));
            gsc.Add(new GradientStop(Colors.Yellow, 0.4));
            gsc.Add(new GradientStop(Colors.Green, 0.6));
            gsc.Add(new GradientStop(Colors.Blue, 0.8));
            gsc.Add(new GradientStop(Colors.Indigo, 1));
            return new LinearGradientBrush(gsc);
        }
    }
}