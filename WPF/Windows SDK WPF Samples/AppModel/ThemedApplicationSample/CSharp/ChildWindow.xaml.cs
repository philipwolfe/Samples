using System;
using System.Windows;

namespace ThemedApplicationSample_CSharp
{
    public partial class ChildWindow : Window
    {
        public ChildWindow()
        {
            InitializeComponent();

            // Bind Background property to "background" resource
            //this.SetResourceReference(Window.BackgroundProperty, "background");
        }
    }
}