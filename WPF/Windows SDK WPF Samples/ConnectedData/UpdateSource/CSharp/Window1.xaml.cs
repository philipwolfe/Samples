//This is a list of commonly used namespaces for a window.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Input;

namespace SDKSample
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

  public partial class Window1 : Window
  {
      public void Preview(object sender, RoutedEventArgs args)
      {
          // itemNameTextBox is an instance of a TextBox
          BindingExpression be = itemNameTextBox.GetBindingExpression(TextBox.TextProperty);
          be.UpdateSource();

          be = bidPriceTextBox.GetBindingExpression(TextBox.TextProperty);
          be.UpdateSource();
          
          userdata.Opacity = 1;
          Finish.Opacity = 1;
      }
      
      public void Submit(object sender, RoutedEventArgs args)
      {
          UserProfile userProfile = new UserProfile();
          userProfile = RootElem.DataContext as UserProfile;
          MessageBox.Show("Thank you for your bid of " + userProfile.BidPrice
                + " on item " + userProfile.ItemName);
          userdata.Opacity = 0;
          Finish.Opacity = 0;
      }
	}
}
