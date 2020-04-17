using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



namespace ProgBar
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        
        private void MakeOne(object sender, RoutedEventArgs e)
        {
           sbar.Items.Clear();
           Button btn = new Button();
           btn.Background = new LinearGradientBrush(Colors.LightBlue, Colors.SlateBlue, 90);
           btn.Content = "Progress Bar";
           sbar.Items.Add(btn);
           ProgressBar progbar = new ProgressBar();
           progbar.IsIndeterminate = false;
           progbar.Orientation = Orientation.Horizontal;
           progbar.Width = 150;
           progbar.Height = 15;
           Duration duration = new Duration(TimeSpan.FromSeconds(10));
           DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
           progbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
           sbar.Items.Add(progbar);
          } 

         private void MakeThree(object sender, RoutedEventArgs e)
         {
           sbar.Items.Clear();
           Button btn = new Button();
           btn.Background = new LinearGradientBrush(Colors.Pink, Colors.Red, 90);
           btn.Content = "Progress Bar";
           sbar.Items.Add(btn);
           ProgressBar progbar = new ProgressBar();
           progbar.Background = Brushes.Gray;
           progbar.Foreground = Brushes.Red;
           progbar.Width = 150;
           progbar.Height = 15;
           Duration duration = new Duration(TimeSpan.FromMilliseconds(2000));
           DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
           doubleanimation.RepeatBehavior = new RepeatBehavior(3);
           progbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
           sbar.Items.Add(progbar);
         }
        private void MakeFive(object sender, RoutedEventArgs e)
        {
            sbar.Items.Clear();
            TextBlock txtb = new TextBlock();
            txtb.Text = "ProgressBar";
            sbar.Items.Add(txtb);
            Button btn = new Button();
            btn.Height = 50;
            btn.Width = 50;
            Image image = new Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(@"pack://application:,,,/data/cat.png");
            bi.EndInit();
            image.Source = bi;
            ImageBrush imagebrush = new ImageBrush(bi);
            btn.Background = imagebrush;

            ProgressBar progbar = new ProgressBar();
            progbar.Background = imagebrush;
            progbar.Width = 150;
            progbar.Height = 15;
            Duration duration = new Duration(TimeSpan.FromMilliseconds(2000));
            DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
            doubleanimation.RepeatBehavior = new RepeatBehavior(5);
            progbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
            btn.Content = progbar;
            sbar.Items.Add(btn);
         }
 
         private void MakeForever(object sender, RoutedEventArgs e)
         {
           sbar.Items.Clear();
           Button btn = new Button();
           btn.Background = new LinearGradientBrush(Colors.LightBlue,        
                                                    Colors.SlateBlue, 90);
           btn.Content = "Progress Bar - Forever";
           sbar.Items.Add(btn);
           ProgressBar progbar = new ProgressBar();
           progbar.Width = 150;
           progbar.Height = 15;
           Duration duration = new Duration(TimeSpan.FromSeconds(1));
           DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
           doubleanimation.RepeatBehavior = RepeatBehavior.Forever;
           progbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
           sbar.Items.Add(progbar);
          
         }
    }
}