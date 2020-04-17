using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PopupPosition
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

    DispatcherTimer closeTimer =
               new DispatcherTimer(DispatcherPriority.Normal);

    private void OnStart(object sender, EventArgs e)
    {
        closeTimer.Interval = TimeSpan.FromSeconds(2);
        closeTimer.Tick +=
               new EventHandler(TimeOutPopup);
        ColorBlue.IsChecked = true;
    }

    private void TimeOutPopup(object sender, EventArgs e)
    {
        myPopup.IsOpen = false;
        closeTimer.Stop();
    }
    
    //Changes the color of the Popup when a RadioButton is selected
    // and then starts the timer that closes the Popup 
    private void ColorChanged(object sender, RoutedEventArgs e)
    {
        if ((Boolean)ColorBlue.IsChecked)
        {
            PopupContent.Text = "The color of the ellipse is Blue";
            myEllipse.Fill = Brushes.Blue;
        }
        else if ((Boolean)ColorBrown.IsChecked)
        {
            PopupContent.Text = "The color of the ellipse is Brown";
            myEllipse.Fill = Brushes.Brown;
        }
        else if ((Boolean)ColorGreen.IsChecked)
        {
            PopupContent.Text = "The color of the ellipse is Green";
            myEllipse.Fill = Brushes.Green;
        }
            
        myPopup.IsOpen = true;
        closeTimer.Start();
    }

    

            

 





   }
}