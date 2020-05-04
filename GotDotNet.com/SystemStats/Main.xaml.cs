using System;
using System.Diagnostics;
using System.Threading;
using MSAvalon.Windows;
using MSAvalon.Windows.Controls;
using MSAvalon.Windows.Documents;
using MSAvalon.Windows.Design;
using MSAvalon.Windows.Navigation;
using MSAvalon.Windows.Shapes;
using MSAvalon.Windows.Media;
using MSAvalon.Windows.Media.Animation;
using MSAvalon.Threading;

namespace SystemStats
{
    public partial class Main : Window
    {
		private Point titleMovePoint = new Point(100, 100);
		private Point oldTitlePoint = new Point(0, 0);
		private bool titleMoved;
		private TransformDecorator oldTitle;
		private WMITransactor transactor = new WMITransactor();
		private PerformanceCounter performanceCounter;
		private UITimer timer;
		private UITimer timer2;
		private int processCounter;

		private void information_Click(object sender, ClickEventArgs e)
		{
			CleanUpArea();
			FadeTitle(1500);
			oldTitle = informationTransform;
			GetTitlePoint(informationTransform);

			informationTransform.Transform = GetTitleMoveTransformCollection(new Point(informationTransform.Width.Value / 2, 
				informationTransform.Height.Value / 2), oldTitlePoint.X, 
				oldTitlePoint.Y, new EventHandler(information_Ended), new Time(1500));	
		}

		private void performance_Click(object sender, ClickEventArgs e)
		{
			CleanUpArea();
			FadeTitle(1500);
			oldTitle = performanceTransform;
			GetTitlePoint(performanceTransform);

			performanceTransform.Transform = GetTitleMoveTransformCollection(new Point(performanceTransform.Width.Value / 2, 
				performanceTransform.Height.Value / 2), oldTitlePoint.X, 
				oldTitlePoint.Y, new EventHandler(performance_Ended), new Time(1500));
		}

		private void processes_Click(object sender, ClickEventArgs e)
		{
			CleanUpArea();
			FadeTitle(3000);
			oldTitle = processesTransform;
			GetTitlePoint(processesTransform);

			processesTransform.Transform = GetTitleMoveTransformCollection(new Point(processesTransform.Width.Value / 2, 
				processesTransform.Height.Value / 2), oldTitlePoint.X, 
				oldTitlePoint.Y, new EventHandler(processes_Ended), new Time(1500));
		}

		private void information_Ended(object sender, EventArgs e)
		{	
			SetTitlePoint(informationTransform);

			informationGridTransform.Visibility = Visibility.Visible;
			Canvas.SetLeft(informationGridTransform, new Length(titleMovePoint.X));
			Canvas.SetTop(informationGridTransform, new Length(titleMovePoint.Y));
			Time duration = new Time(1000);
			
			DoubleAnimation da = (DoubleAnimation)(informationGridTransform.GetAnimations(Rectangle.OpacityProperty))[0];
			da.Duration = duration;
			da.BeginIn(0);
			LengthAnimation la = (LengthAnimation)(informationGridTransform.GetAnimations(Canvas.WidthProperty))[0];
			la.Duration = duration;
			la.From = informationTransform.Width;
			la.To = new Length(this.Width.Value - 200);
			la.BeginIn(0);
			la = (LengthAnimation)(informationGridTransform.GetAnimations(Canvas.HeightProperty))[0];
			la.Duration = duration;
			la.From = informationTransform.Height;
			la.To = new Length(this.Height.Value - 225);
			la.BeginIn(0);
			informationGridTransform.Transform = GetMainContentTransformCollection(new Point(100, 150), 
				new EventHandler(informationGrid_Ended), duration);
		}

		private void informationGrid_Ended(object sender, EventArgs e)
		{
			informationGridTransform.Opacity = .72;
			Canvas.SetLeft(informationGridTransform, new Length(100));
			Canvas.SetTop(informationGridTransform, new Length(150));
			informationGridTransform.Width = new Length(this.Width.Value -200);
			informationGridTransform.Height = new Length(this.Height.Value - 225);

			Canvas.SetLeft(operatingSystem, new Length(50));
			Canvas.SetTop(operatingSystem, new Length(50));

			Canvas.SetLeft(computerSystem, new Length(90));
			Canvas.SetTop(computerSystem, new Length(90));

			Canvas.SetLeft(videoController, new Length(130));
			Canvas.SetTop(videoController, new Length(130));

			Canvas.SetLeft(systemProcessor, new Length(170));
			Canvas.SetTop(systemProcessor, new Length(170));
			
			Canvas.SetLeft(informationGridContent, new Length(300));
			Canvas.SetTop(informationGridContent, new Length(50));
		}

		private void performance_Ended(object sender, EventArgs e)
		{
			SetTitlePoint(performanceTransform);

			performanceGridTransform.Visibility = Visibility.Visible; 
			Canvas.SetLeft(performanceGridTransform, new Length(titleMovePoint.X)); 
			Canvas.SetTop(performanceGridTransform, new Length(titleMovePoint.Y)); 
			Time duration = new Time(1000); 
			
			DoubleAnimation da = (DoubleAnimation)(performanceGridTransform.GetAnimations(Rectangle.OpacityProperty))[0]; 
			da.Duration = duration; da.BeginIn(0); 
			
			LengthAnimation la = (LengthAnimation)(performanceGridTransform.GetAnimations(Canvas.WidthProperty))[0]; 
			la.Duration = duration; la.From = performanceTransform.Width; 
			la.To = new Length(this.Width.Value - 200);
			la.BeginIn(0);
			
			la = (LengthAnimation)(performanceGridTransform.GetAnimations(Canvas.HeightProperty))[0];
			la.Duration = duration;
			la.From = performanceTransform.Height;
			la.To = new Length(this.Height.Value - 225);
			la.BeginIn(0);
			
			performanceGridTransform.Transform = GetMainContentTransformCollection(new Point(100, 150), 
				new EventHandler(performanceGrid_Ended), duration);
		}

		private void performanceGrid_Ended(object sender, EventArgs e)
		{
			performanceGridTransform.Opacity = .72;
			Canvas.SetLeft(performanceGridTransform, new Length(100));
			Canvas.SetTop(performanceGridTransform, new Length(150));
			performanceGridTransform.Width = new Length(this.Width.Value - 200);
			performanceGridTransform.Height = new Length(this.Height.Value - 225);

			this.performanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

			double x = 0;
			Length width = new Length((this.Width.Value - 200) / 10);
			Length height = new Length(this.Height.Value - 225 - 40);
			foreach (Button b in performanceGridGraph.Children)
			{
				b.Width = width;
				b.Height = height;
				Canvas.SetLeft(b, new Length(x));
				Canvas.SetTop(b, new Length(0));
				x += width.Value;
			}

			Canvas.SetLeft(performanceCaption, new Length(((this.Width.Value - 200) / 2) - 10));
			Canvas.SetTop(performanceCaption, new Length(height.Value + 10));

			timer = new UITimer(new TimeSpan(1000000), UIContextPriority.Normal, new EventHandler(timer_Tick), UIContext.CurrentContext);
			timer.Start();
		}

		private void processes_Ended(object sender, EventArgs e)
		{
			SetTitlePoint(processesTransform);
			processesGridTransform.Visibility = Visibility.Visible;
			Canvas.SetLeft(processesGridTransform, new Length(titleMovePoint.X));
			Canvas.SetTop(processesGridTransform, new Length(titleMovePoint.Y));

			Time duration = new Time(1000);
			DoubleAnimation da = (DoubleAnimation)(processesGridTransform.GetAnimations(Rectangle.OpacityProperty))[0];

			da.Duration = duration; da.BeginIn(0);

			LengthAnimation la = (LengthAnimation)(processesGridTransform.GetAnimations(Canvas.WidthProperty))[0];

			la.Duration = duration; la.From = processesTransform.Width;
			la.To = new Length(this.Width.Value - 200);
			la.BeginIn(0);
			la = (LengthAnimation)(processesGridTransform.GetAnimations(Canvas.HeightProperty))[0];
			la.Duration = duration;
			la.From = performanceTransform.Height;
			la.To = new Length(this.Height.Value - 225);
			la.BeginIn(0);
			processesGridTransform.Transform = GetMainContentTransformCollection(new Point(100, 150), new EventHandler(processesGrid_Ended), duration);
		}


		private void processesGrid_Ended(object sender, EventArgs e)
		{
			processesGridTransform.Opacity = .72;
			Canvas.SetLeft(processesGridTransform, new Length(100));
			Canvas.SetTop(processesGridTransform, new Length(150));
			processesGridTransform.Width = new Length(this.Width.Value - 200);
			processesGridTransform.Height = new Length(this.Height.Value - 225);

			processesBox.Items.Clear();
			System.Collections.ArrayList list = transactor.ProcessTransaction(WMITransactionType.Processes);
			for (int i = 0; i < list.Count;  i += 3)
			{
				processesBox.Items.Add(list[i] + "\t\t\t\t" + list[i + 1] + "\t\t" + list[i + 2]);
			}

			timer2 = new UITimer(new TimeSpan(1000000), UIContextPriority.Normal, new EventHandler(timer2_Tick), UIContext.CurrentContext);
			timer2.Start();
		}

		private void SetTitlePoint(DependencyObject e)
		{
			if(titleMoved)
			{
				Canvas.SetLeft(e, new Length(oldTitlePoint.X));
				Canvas.SetTop(e, new Length(oldTitlePoint.Y));
			}
			else
			{
				Canvas.SetLeft(e, new Length(titleMovePoint.X));
				Canvas.SetTop(e, new Length(titleMovePoint.Y));
			}
			titleMoved = !titleMoved;
		}

		private void GetTitlePoint(DependencyObject e)
		{
			oldTitlePoint.X = Canvas.GetLeft(e).Value;
			oldTitlePoint.Y = Canvas.GetTop(e).Value;
		}

		private TransformCollection GetTitleMoveTransformCollection(Point center, double canvasLeft, double canvasTop, 
			EventHandler ended, Time duration)
		{
			DoubleAnimation da = new DoubleAnimation(0, 360, duration);
			da.Begin = Time.CurrentGlobalTime;

			RotateTransform rt = new RotateTransform();
			rt.AngleAnimations = da;
			rt.Center = center;

			TransformCollection tc = new TransformCollection(2);
			tc.Add(rt);

			DoubleAnimation daX = new DoubleAnimation(0, titleMovePoint.X - canvasLeft, duration);
			daX.Ended += ended;
			daX.Begin = Time.CurrentGlobalTime;

			DoubleAnimation daY = new DoubleAnimation(0, titleMovePoint.Y - canvasTop, duration);
			daY.Begin = Time.CurrentGlobalTime;
			tc.Add(new TranslateTransform(0, daX, 0, daY));

			return tc;
		}

		private void FadeTitle(Time duration)
		{
			if (titleMoved)
			{
				DoubleAnimationCollection dac = new DoubleAnimationCollection();
				DoubleAnimation da = new DoubleAnimation(0, 1, duration, TimeFill.Transition);
				da.Begin = Time.CurrentGlobalTime;
				dac.Add(da);

				SetTitlePoint(oldTitle);
				oldTitle.SetAnimations(Button.OpacityProperty, dac);
			}
		}

		private TransformCollection GetMainContentTransformCollection(Point movePoint, EventHandler ended, Time duration)
		{
			TransformCollection tc = new TransformCollection(2);

			DoubleAnimation daX = new DoubleAnimation(0, movePoint.X - titleMovePoint.X, duration);
			daX.Ended += ended;
			daX.Begin = Time.CurrentGlobalTime;

			DoubleAnimation daY = new DoubleAnimation(0, movePoint.Y - titleMovePoint.Y, duration);
			daY.Begin = Time.CurrentGlobalTime;
			tc.Add(new TranslateTransform(0, daX, 0, daY));

			return tc;
		}

		private void operatingSystem_Click(object sender, ClickEventArgs e)
		{
			operatingSystem.Transform = GetInformationSubItemTransformCollection(new Point(operatingSystem.Width.Value / 2, 
				operatingSystem.Height.Value / 2), null, new Time(1500));

			informationText.Clear();
			foreach(string s in transactor.ProcessTransaction(WMITransactionType.OperatingSystem))
			{
				informationText.AppendText(s + System.Environment.NewLine);
			}
		}

		private void computerSystem_Click(object sender, ClickEventArgs e)
		{
			computerSystem.Transform = GetInformationSubItemTransformCollection(new Point(computerSystem.Width.Value / 2, computerSystem.Height.Value / 2), null, new Time(1500));
			informationText.Clear();
			foreach (string s in transactor.ProcessTransaction(WMITransactionType.ComputerSystem))
			{
				informationText.AppendText(s + System.Environment.NewLine);
			}
		}

		private void videoController_Click(object sender, ClickEventArgs e)
		{
			videoController.Transform = GetInformationSubItemTransformCollection(new Point(videoController.Width.Value / 2, videoController.Height.Value / 2), null, new Time(1500));
			informationText.Clear();
			foreach (string s in transactor.ProcessTransaction(WMITransactionType.VideoController))
			{
				informationText.AppendText(s + System.Environment.NewLine);
			}
		}

		private void systemProcessor_Click(object sender, ClickEventArgs e)
		{
			systemProcessor.Transform = GetInformationSubItemTransformCollection(new Point(systemProcessor.Width.Value / 2, systemProcessor.Height.Value / 2), null, new Time(1500));
			informationText.Clear();
			foreach (string s in transactor.ProcessTransaction(WMITransactionType.SystemProcessor))
			{
				informationText.AppendText(s + System.Environment.NewLine);
			}
		}

		private TransformCollection GetInformationSubItemTransformCollection(Point center, EventHandler ended, Time duration)
		{
			DoubleAnimation da = new DoubleAnimation(0, 360, duration);
			da.Duration = duration;
			da.Begin = Time.CurrentGlobalTime;

			RotateTransform rt = new RotateTransform();
			rt.AngleAnimations = da;
			rt.Center = center;

			TransformCollection tc = new TransformCollection(1);
			tc.Add(rt);

			return tc;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			Length width = new Length((this.Width.Value - 200) / 10);
			Length height = new Length(this.Height.Value - 225 - 40);

			for (int i = 0; i < 9;  i++)
			{
				Button b = performanceGridGraph.Children[i] as Button;
				b.Height = (performanceGridGraph.Children[i + 1] as Button).Height;
				b.Background = (performanceGridGraph.Children[i + 1] as Button).Background;
				Canvas.SetTop(b, new Length(0));
			}

			float sample = this.performanceCounter.NextValue();
			double unit = height.Value / 100;
			Button button = performanceGridGraph.Children[9] as Button;
			button.Height = new Length(unit * sample);
			if (sample > 50)
			{
				if (sample > 80)
				{
					button.Background = Brushes.Red;
				}
				else
				{
					button.Background = Brushes.Orange;
				}
			}
			else
			{
				button.Background = Brushes.LimeGreen;
			}
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			if (processCounter + 1 < processesBox.Items.Count)
			{
				processCounter++;
				processesBox.SetSelected(processCounter, true);
			}
			else
			{
				processCounter = 0;
				processesBox.SetSelected(processCounter, true);
			}
		}

		private void CleanUpArea()
		{
			if (timer != null)
			{
				if (timer.IsEnabled)
				{
					timer.Stop();
				}
			}
			if (timer2 != null)
			{
				if (timer2.IsEnabled)
				{
					timer2.Stop();
				}
			}
			if (informationGridTransform.Visibility == Visibility.Visible)
			{
				informationGridTransform.Visibility = Visibility.Hidden;
			}
			if (performanceGridTransform.Visibility == Visibility.Visible)
			{
				performanceGridTransform.Visibility = Visibility.Hidden;
			}
			if (processesGridTransform.Visibility == Visibility.Visible)
			{
				processesGridTransform.Visibility = Visibility.Hidden;
			}
		}
    }
}