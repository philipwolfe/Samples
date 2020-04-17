using System;
using System.Windows;
using System.Windows.Controls;

namespace ThemedApplicationSample_CSharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Add choices to combo box
            this.themeComboBox.Items.Add("Blue");
            this.themeComboBox.Items.Add("Yellow");
            this.themeComboBox.SelectedIndex = 0;

            // Set initial theme
            MyThemedApp.Current.Resources = (ResourceDictionary)MyThemedApp.Current.Properties["Blue"];

            // Detect when theme changes
            this.themeComboBox.SelectionChanged += new SelectionChangedEventHandler(themeComboBox_SelectionChanged);
        }

        void newChildWindowButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new themed child window
            ChildWindow window = new ChildWindow();
            window.Show();
        }

        void themeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Change the theme
            string selectedValue = (string)e.AddedItems[0];
            MyThemedApp.Current.Resources = (ResourceDictionary)MyThemedApp.Current.Properties[selectedValue];
        }
    }
}