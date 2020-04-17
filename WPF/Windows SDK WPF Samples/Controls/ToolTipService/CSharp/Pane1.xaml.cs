//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;
using System.Windows.Media;


namespace SDKSample
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

	public partial class Pane1 : Window
	{
                
        void OnLoad(object sender, RoutedEventArgs e)
        {
            //Create an ellipse with a tooltip that is a 
            //ToolTip control 
            Ellipse ellipse1 = new Ellipse();
            ellipse1.Height = 25;
            ellipse1.Width = 50;
            ellipse1.Fill = Brushes.Gray;
            ellipse1.HorizontalAlignment = HorizontalAlignment.Left;

            //set tooltip timing 

            ToolTipService.SetInitialShowDelay(ellipse1, 1000);

            ToolTipService.SetBetweenShowDelay(ellipse1, 2000);

            ToolTipService.SetShowDuration(ellipse1, 7000);


            //set tooltip placement
            ToolTip tooltip = new ToolTip();
            tooltip.Placement = PlacementMode.Right;
            tooltip.PlacementRectangle = new Rect(50, 0, 0, 0);
            tooltip.HorizontalOffset = 10;
            tooltip.VerticalOffset = 20;
            
            //set drop shadow effect
            tooltip.HasDropShadow = false;


            //Create BulletDecorator as tooltip content
            BulletDecorator bdec = new BulletDecorator();
            Ellipse littleEllipse = new Ellipse();
            littleEllipse.Height = 10;
            littleEllipse.Width = 20;
            littleEllipse.Fill = Brushes.Blue;
            bdec.Bullet = littleEllipse;
            TextBlock tipText = new TextBlock();
            tipText.Text = "Uses the ToolTip class";
            bdec.Child = tipText;
            tooltip.Content = bdec;

            //set event handlers for the Opened and Closed events
            tooltip.Opened +=
              new RoutedEventHandler(whenToolTipOpens);
            tooltip.Closed +=
              new RoutedEventHandler(whenToolTipCloses);

            //set tooltip on ellipse
            ellipse1.ToolTip = tooltip;
            stackPanel_1_1.Children.Add(ellipse1);

            //Create and Ellipse with the BulletDecorator as 
            //the tooltip 
            Ellipse ellipse2 = new Ellipse();
            ellipse2.Name = "ellipse2";
            this.RegisterName(ellipse2.Name,ellipse2);
            ellipse2.Height = 25;
            ellipse2.Width = 50;
            ellipse2.Fill = Brushes.Gray;
            ellipse2.HorizontalAlignment = HorizontalAlignment.Left;

            //set tooltip timing
            ToolTipService.SetInitialShowDelay(ellipse2, 1000);
            ToolTipService.SetBetweenShowDelay(ellipse2, 2000);
            ToolTipService.SetShowDuration(ellipse2, 7000);

            //set tooltip placement

            ToolTipService.SetPlacement(ellipse2, PlacementMode.Right);

            ToolTipService.SetPlacementRectangle(ellipse2,
                new Rect(50, 0, 0, 0));

            ToolTipService.SetHorizontalOffset(ellipse2, 10.0);

            ToolTipService.SetVerticalOffset(ellipse2, 20.0);


            ToolTipService.SetHasDropShadow(ellipse2, false);

            ToolTipService.SetIsEnabled(ellipse2, true);

            ToolTipService.SetShowOnDisabled(ellipse2, true);

            ellipse2.AddHandler(ToolTipService.ToolTipOpeningEvent,
                new RoutedEventHandler(whenToolTipOpens));
            ellipse2.AddHandler(ToolTipService.ToolTipClosingEvent,
                new RoutedEventHandler(whenToolTipCloses));
           
            //define tooltip content
            BulletDecorator bdec2 = new BulletDecorator();
            Ellipse littleEllipse2 = new Ellipse();
            littleEllipse2.Height = 10;
            littleEllipse2.Width = 20;
            littleEllipse2.Fill = Brushes.Blue;
            bdec2.Bullet = littleEllipse2;
            TextBlock tipText2 = new TextBlock();
            tipText2.Text = "Uses the ToolTipService class";
            bdec2.Child = tipText2;
            ToolTipService.SetToolTip(ellipse2, bdec2);
            stackPanel_1_2.Children.Add(ellipse2);

 
        }

        void whenToolTipOpens(object sender, RoutedEventArgs e)
        {
          Ellipse ell = new Ellipse();
          if (sender.GetType().FullName.Equals("System.Windows.Shapes.Ellipse"))
          {
              ell = (Ellipse)sender;
              ell.Fill = Brushes.Blue;
          }
          else if (sender.GetType().FullName.Equals(
                                   "System.Windows.Controls.ToolTip"))
          {
              ToolTip t = (ToolTip)sender;
              Popup p = (Popup)t.Parent;
              ell = (Ellipse)p.PlacementTarget;
              ell.Fill = Brushes.Blue;
          }           
        }

        void whenToolTipCloses(object sender, RoutedEventArgs e)
        {
            Ellipse ell = new Ellipse();
            if (sender.GetType().FullName.Equals(
                              "System.Windows.Shapes.Ellipse"))
            {
                ell = (Ellipse)sender;
                ell.Fill = Brushes.Gray;
            }
            else if (sender.GetType().FullName.Equals(
                                   "System.Windows.Controls.ToolTip"))
            {
                ToolTip t = (ToolTip)sender;
                Popup p = (Popup)t.Parent;
                ell = (Ellipse)p.PlacementTarget;
                ell.Fill = Brushes.Gray;
            }       
        }
        private void showProperties(object sender, RoutedEventArgs e)
        {
            ttProperties.ClearValue(TextBlock.TextProperty);
            ttPropertyValues.ClearValue(TextBlock.TextProperty);
            int myInt = ToolTipService.GetBetweenShowDelay(
                         (DependencyObject)FindName("ellipse2"));
            AddTextString(ttProperties, ttPropertyValues, "BetweenShowDelay",
                          myInt.ToString());
            myInt = ToolTipService.GetInitialShowDelay(
                         (DependencyObject)FindName("ellipse2"));
            AddTextString(ttProperties, ttPropertyValues, "InitialShowDelay",
                          myInt.ToString());
            myInt = ToolTipService.GetShowDuration(
                          (DependencyObject)FindName("ellipse2"));
            AddTextString(ttProperties, ttPropertyValues, "ShowDuration",
                          myInt.ToString());
            bool myBool = ToolTipService.GetHasDropShadow(
                         (DependencyObject)FindName("ellipse2"));
            AddTextString(ttProperties, ttPropertyValues, "HasDropShadow",
                          myBool.ToString());
            double myDouble = ToolTipService.GetHorizontalOffset(
             (DependencyObject)FindName("ellipse2"));
            AddTextString(ttProperties, ttPropertyValues, "HorizontalOffset",
                          myDouble.ToString());
            myDouble = ToolTipService.GetVerticalOffset(
                        (DependencyObject)FindName("ellipse2"));
            AddTextString(ttProperties, ttPropertyValues, "VerticalOffset",
                          myDouble.ToString());
            PlacementMode myMode = ToolTipService.GetPlacement(
             (DependencyObject)FindName("ellipse2"));
            AddTextString(ttProperties, ttPropertyValues, "Placement",
                          myMode.ToString());
            Rect myRect = ToolTipService.GetPlacementRectangle(
             (DependencyObject)FindName("ellipse2"));
            AddTextString(ttProperties, ttPropertyValues, "PlacementRectangle",
                          myRect.ToString());
            UIElement target = new UIElement();
            target = ToolTipService.GetPlacementTarget(
             (DependencyObject)FindName("ellipse2"));
            if (target == null)
                AddTextString(ttProperties, ttPropertyValues, "PlacementTarget",
                          "null");
            else
              AddTextString(ttProperties, ttPropertyValues, "PlacementTarget",
                          target.ToString());
            myBool = ToolTipService.GetHasDropShadow(
             (DependencyObject)FindName("ellipse2"));
            AddTextString(ttProperties, ttPropertyValues, "HasDropShadow",
                          myBool.ToString());
            myBool = ToolTipService.GetIsEnabled(
             (DependencyObject)FindName("ellipse2"));
            AddTextString(ttProperties, ttPropertyValues, "IsEnabled",
                          myBool.ToString());
            myBool = ToolTipService.GetIsOpen(
             (DependencyObject)FindName("ellipse2"));
            AddTextString(ttProperties, ttPropertyValues, "IsOpen",
                          myBool.ToString());
            myBool = ToolTipService.GetShowOnDisabled(
             (DependencyObject)FindName("ellipse2"));
            AddTextString(ttProperties, ttPropertyValues, "ShowOnDisabled",
                          myBool.ToString());
            target = (UIElement)ToolTipService.GetToolTip(
             (DependencyObject)FindName("ellipse2"));
            AddTextString(ttProperties, ttPropertyValues, "ToolTip",
                          target.ToString());

        }

        private void AddTextString(TextBlock tBlock, 
                                     string pName,
                                     string value)
        {
            tBlock.Text += pName + "\t" + value + "\n";
        }

        private void AddTextString(TextBlock tBlock, TextBlock vBlock,
                                     string pName,
                                     string value)
        {
            tBlock.Text += pName + "\n";
            vBlock.Text += value + "\n";
        }

	}
}