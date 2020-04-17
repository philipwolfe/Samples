#region Using directives

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Collections;
using System.Windows.Shapes;

#endregion

namespace FontDialog
{
    /// <summary>
    /// Define a item for chosing texty color 
    /// </summary>
    public class ColorSelectionItem : System.Windows.Controls.ListBoxItem
    {
        private SolidColorBrush color;
        private string colorName;
        private int height = 17;

        public ColorSelectionItem(string ColorName, SolidColorBrush c)
        {
            StackPanel panel = new StackPanel();
            panel.Height = height;
            panel.Orientation = Orientation.Horizontal;
            Label l1 = new Label();
            l1.Height = height;
            l1.Width = 25;
            l1.Margin = new Thickness(1, 1, 1, 1);
            color = c;
            l1.Background = color;
            Label l2 = new Label();
            l2.Content = "  " + ColorName.Trim();
            l2.Height = height;
            l2.Width = 75;
            l2.Margin = new Thickness(1, 1, 1, 1);
            l2.Padding = new Thickness(0, 0, 0, 0);
            panel.Children.Add(l1);
            panel.Children.Add(l2);
            //IsSelectable = true;
            Content = panel;
            colorName = ColorName;
        }
        /// <summary>
        /// return the name of a color
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return colorName;
        }
        /// <summary>
        /// Return the color as a solid colorBrush
        /// </summary>
        public SolidColorBrush Color
        {
            get
            {
                return color;
            }
        }
    }
}
