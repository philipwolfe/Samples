using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace ComboBox_Index
{
	public partial class Window1 : Window
	{
	public Window1()
	{
	  InitializeComponent();
	}
        
        private void GetIndex0(object sender, RoutedEventArgs e)
        {
          ComboBoxItem cbi = (ComboBoxItem)
               (cb.ItemContainerGenerator.ContainerFromIndex(0));
          Item.Content = "The contents of the item at index 0 are: " +
               (cbi.Content.ToString()) + ".";
         }
         private void GetIndex1(object sender, RoutedEventArgs e)
        {
          ComboBoxItem cbi = (ComboBoxItem)
               (cb.ItemContainerGenerator.ContainerFromIndex(1));
          Item.Content = "The contents of the item at index 1 are: " +
               (cbi.Content.ToString()) + ".";
         } 
         private void GetIndex2(object sender, RoutedEventArgs e)
         {
          ComboBoxItem cbi = (ComboBoxItem)
               (cb.ItemContainerGenerator.ContainerFromIndex(2));
          Item.Content = "The contents of the item at index 2 are: " +
               (cbi.Content.ToString()) + ".";
         } 
         private void GetIndex3(object sender, RoutedEventArgs e)
         {
          ComboBoxItem cbi = (ComboBoxItem)
               (cb.ItemContainerGenerator.ContainerFromIndex(3));
          Item.Content = "The contents of the item at index 3 are: " +
               (cbi.Content.ToString()) + ".";
         } 
            
        
	}
}