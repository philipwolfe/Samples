//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace ImageElementExample
{
   public partial class FormatConvertedExample : Page
   {
      public FormatConvertedExample()
      {
      }

      public void PageLoaded(object sender, RoutedEventArgs args)
      {
         // Create an Image element.
         Image grayImage = new Image();
         grayImage.Width = 200;
         grayImage.Margin = new Thickness(5);

         // Create the image source using a xaml defined resource.
         FormatConvertedBitmap fcb = new FormatConvertedBitmap(
            (BitmapImage)this.Resources["masterImage"],PixelFormats.Gray4,null,0);
         // Set the image source.
         grayImage.Source = fcb;

         // Add Image to the UI.
         Grid.SetColumn(grayImage, 2);
         Grid.SetRow(grayImage, 1);
         convertedGrid.Children.Add(grayImage);
      }


   }
}