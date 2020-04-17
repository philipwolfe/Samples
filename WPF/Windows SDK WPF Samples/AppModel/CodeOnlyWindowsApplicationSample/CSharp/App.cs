using System;
using System.Windows;

namespace CodeOnlyWindowsApplicationSample {
  /// <summary>
  /// App derives from Application to inherit application services,
  /// and because developers typically need to influence its behavior
  /// such as handling events or overriding members. The most common
  /// reason is to configure the default UI resource to load, which 
  /// App does by overriding Startup.
  /// 
  /// NOTE: Since App is code-only (no markup) there is no need to
  ///       call the InitializeComponent method eg:
  /// 
  ///       public partial class App : Application {
  ///          public App() {
  ///            this.InitializeComponent();
  ///          }
  ///       }
  /// 
  ///       InitializeComponent is a method that is generated by the compiler 
  ///       when markup  exists to apply the App XAML to the actual App instance, 
  ///       eg to register event handlers. If XAML were used, this class
  ///       would also need to be a partial class, to merge with the
  ///       partial class definition that implements the InitializeComponent,
  ///       method that's generated by the compiler.
  /// </summary>
  public class App : Application {
    protected override void OnStartup(StartupEventArgs e) {
      base.OnStartup(e);
      
      // Show main application window.
      // NOTE: this window is automatically set as
      //       App.Current.MainWindow and App.Current.Windows[0]
      MainWindow window = new MainWindow();
      window.Show();
    }
  }
}
