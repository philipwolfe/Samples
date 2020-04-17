using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace SDKSample
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

        
        public void onClick(object sender, RoutedEventArgs args)
        {
            myPopup.CustomPopupPlacementCallback =
                new CustomPopupPlacementCallback(placePopup);
            myPopup.IsOpen = true;

        }

        public CustomPopupPlacement[] placePopup(Size popupSize,
                                                   Size targetSize,
                                                   Point offset)
        {
            CustomPopupPlacement[] ttplaces =
                    new CustomPopupPlacement[] { new CustomPopupPlacement() };
            ttplaces[0].Point = new Point(-50,90);
            ttplaces[0].PrimaryAxis = PopupPrimaryAxis.Vertical;
            return ttplaces;
        }


    }
  
}