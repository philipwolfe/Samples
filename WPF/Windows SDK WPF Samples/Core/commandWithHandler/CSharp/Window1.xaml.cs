using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace WCSamples
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

        void OpenCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("The command has been invoked.");
        }
        void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

    }
}