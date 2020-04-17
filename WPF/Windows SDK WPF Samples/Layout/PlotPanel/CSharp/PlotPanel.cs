using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Threading;

namespace PlotPanel
{
	public class app : System.Windows.Application
	{
        PlotPanel plot1;
        Window mainWindow;
        Rectangle rect1;

        protected override void OnStartup (StartupEventArgs e)
		{
		base.OnStartup (e);
		CreateAndShowMainWindow ();
		}

		private void CreateAndShowMainWindow()
		{
		// Create the application's main window
		mainWindow = new System.Windows.Window();
        plot1 = new PlotPanel();
        plot1.Background = Brushes.White;
  
        rect1 = new Rectangle();
        rect1.Fill = Brushes.CornflowerBlue;
        rect1.Width = 200;
        rect1.Height = 200;
        mainWindow.Content = plot1;
        plot1.Children.Add(rect1);
        mainWindow.Title = "Custom Panel Sample";
        mainWindow.Show();
		}
        public class PlotPanel : Panel
        {
            // Default public constructor
            public PlotPanel()
                : base()
            {
            }

            // Override the default Measure method of Panel
            protected override Size MeasureOverride(Size availableSize)
            {
                Size childSize = availableSize;
                foreach (UIElement child in InternalChildren)
                {
                    child.Measure(childSize);
                }
                return availableSize;
            }
            protected override Size ArrangeOverride(Size finalSize)
            {
                foreach (UIElement child in InternalChildren)
                {
                    double x = 50;
                    double y = 50;

                    child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
                }
                return finalSize; // Returns the final Arranged size
            }
        }
    }

	internal static class EntryClass
	{
		[System.STAThread()]
		private static void Main()
		{
			app app = new app();
			app.Run();
		}
	}
}
