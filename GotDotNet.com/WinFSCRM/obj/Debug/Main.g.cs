//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version:1.2.30703.27
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace WinFSCRM {
    using System;
    using MSAvalon.Windows.Controls;
    using MSAvalon.Windows.Documents;
    using MSAvalon.Windows.Shapes;
    using MSAvalon.Windows.Media;
    using MSAvalon.Windows.Navigation;
    using MSAvalon.Windows.Data;
    using MSAvalon.Windows;
    using MSAvalon.Windows.Controls.Primitives;
    using MSAvalon.Windows.Media.Animation;
    
    
    /// <summary>
    /// Main
    /// </summary>
    public partial class Main : MSAvalon.Windows.Window {
        
        protected internal MSAvalon.Windows.Controls.TextBox query;
        
        protected internal MSAvalon.Windows.Controls.ListBox searchResults;
        
        protected internal MSAvalon.Windows.Controls.ComboBox clients;
        
        protected internal MSAvalon.Windows.Controls.ComboBox events;
        
        protected internal MSAvalon.Windows.Controls.ComboBox notes;
        
        protected internal MSAvalon.Windows.Controls.FlowPanel ContentArea;
        
        /// <summary>
        /// Main ctor Parent overload
        /// </summary>
        public Main(MSAvalon.Threading.UIContext context) : 
                base(context) {
            this._InitializeThis();
        }
        
        /// <summary>
        /// Main ctor
        /// </summary>
        public Main() {
            this._InitializeThis();
        }
        
        private WinFSCRM.MyApp Application {
            get {
                return ((WinFSCRM.MyApp)(MSAvalon.Windows.Application.Current));
            }
        }
        
        private void _InitializeThis() {
            MSAvalon.Windows.Window _Window_1_ = this;
            ((MSAvalon.Windows.Serialization.ILoaded)(_Window_1_)).DeferLoad();
            _Window_1_.Text = "WinFSCRM";
            _Window_1_.Visible = true;
            _Window_1_.Loaded += new System.EventHandler(this.LoadProgram);
            MSAvalon.Windows.Controls.DockPanel _DockPanel_2_ = new MSAvalon.Windows.Controls.DockPanel();
            ((MSAvalon.Windows.Serialization.ILoaded)(_DockPanel_2_)).DeferLoad();
            _DockPanel_2_.Width = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            _DockPanel_2_.Height = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Window_1_)).AddChild(_DockPanel_2_);
            MSAvalon.Windows.Controls.Border _Border_3_ = new MSAvalon.Windows.Controls.Border();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Border_3_)).DeferLoad();
            MSAvalon.Windows.Controls.DockPanel.SetDock(_Border_3_, MSAvalon.Windows.Controls.Dock.Top);
            _Border_3_.Width = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            _Border_3_.Height = new MSAvalon.Windows.Length(5, MSAvalon.Windows.UnitType.Percent);
            _Border_3_.BorderThickness = new MSAvalon.Windows.Thickness(new MSAvalon.Windows.Length(1, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(1, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(1, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(1, MSAvalon.Windows.UnitType.Pixel));
            _Border_3_.BorderBrush = new MSAvalon.Windows.Media.SolidColorBrush(MSAvalon.Windows.Media.Color.FromARGB(255, 255, 0, 0));
            ((MSAvalon.Windows.Serialization.IAddChild)(_DockPanel_2_)).AddChild(_Border_3_);
            MSAvalon.Windows.Controls.FlowPanel _FlowPanel_4_ = new MSAvalon.Windows.Controls.FlowPanel();
            ((MSAvalon.Windows.Serialization.ILoaded)(_FlowPanel_4_)).DeferLoad();
            _FlowPanel_4_.HorizontalAlignment = MSAvalon.Windows.HorizontalAlignment.Center;
            ((MSAvalon.Windows.Serialization.IAddChild)(_Border_3_)).AddChild(_FlowPanel_4_);
            MSAvalon.Windows.Controls.Text _Text_5_ = new MSAvalon.Windows.Controls.Text();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_5_)).DeferLoad();
            _Text_5_.Height = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            _Text_5_.Margin = new MSAvalon.Windows.Thickness(new MSAvalon.Windows.Length(0, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(0, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(10, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(0, MSAvalon.Windows.UnitType.Pixel));
            _Text_5_.VerticalAlignment = MSAvalon.Windows.Media.VerticalAlignment.Center;
            _Text_5_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Text_5_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_4_)).AddChild(_Text_5_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Text_5_)).AddText("Search");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_5_)).EndDeferLoad();
            MSAvalon.Windows.Controls.TextBox _TextBox_6_ = new MSAvalon.Windows.Controls.TextBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_6_)).DeferLoad();
            this.query = _TextBox_6_;
            _TextBox_6_.ID = "query";
            _TextBox_6_.Margin = new MSAvalon.Windows.Thickness(new MSAvalon.Windows.Length(0, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(0, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(10, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(0, MSAvalon.Windows.UnitType.Pixel));
            _TextBox_6_.Width = new MSAvalon.Windows.Length(40, MSAvalon.Windows.UnitType.Percent);
            _TextBox_6_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _TextBox_6_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_4_)).AddChild(_TextBox_6_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_6_)).EndDeferLoad();
            MSAvalon.Windows.Controls.Button _Button_7_ = new MSAvalon.Windows.Controls.Button();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_7_)).DeferLoad();
            _Button_7_.Height = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            _Button_7_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Button_7_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _Button_7_.Click += new MSAvalon.Windows.Controls.ClickEventHandler(this.RunSearch);
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_4_)).AddChild(_Button_7_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Button_7_)).AddText("Go");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_7_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_FlowPanel_4_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Border_3_)).EndDeferLoad();
            MSAvalon.Windows.Controls.Border _Border_8_ = new MSAvalon.Windows.Controls.Border();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Border_8_)).DeferLoad();
            MSAvalon.Windows.Controls.DockPanel.SetDock(_Border_8_, MSAvalon.Windows.Controls.Dock.Bottom);
            _Border_8_.Width = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            _Border_8_.Height = new MSAvalon.Windows.Length(20, MSAvalon.Windows.UnitType.Percent);
            _Border_8_.BorderThickness = new MSAvalon.Windows.Thickness(new MSAvalon.Windows.Length(4, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(4, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(4, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(4, MSAvalon.Windows.UnitType.Pixel));
            _Border_8_.BorderBrush = new MSAvalon.Windows.Media.SolidColorBrush(MSAvalon.Windows.Media.Color.FromARGB(255, 0, 0, 0));
            ((MSAvalon.Windows.Serialization.IAddChild)(_DockPanel_2_)).AddChild(_Border_8_);
            MSAvalon.Windows.Controls.ListBox _ListBox_9_ = new MSAvalon.Windows.Controls.ListBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_ListBox_9_)).DeferLoad();
            this.searchResults = _ListBox_9_;
            _ListBox_9_.ID = "searchResults";
            _ListBox_9_.Width = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            _ListBox_9_.Height = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Border_8_)).AddChild(_ListBox_9_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_ListBox_9_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Border_8_)).EndDeferLoad();
            MSAvalon.Windows.Controls.Border _Border_10_ = new MSAvalon.Windows.Controls.Border();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Border_10_)).DeferLoad();
            MSAvalon.Windows.Controls.DockPanel.SetDock(_Border_10_, MSAvalon.Windows.Controls.Dock.Left);
            _Border_10_.Width = new MSAvalon.Windows.Length(20, MSAvalon.Windows.UnitType.Percent);
            _Border_10_.Height = new MSAvalon.Windows.Length(75, MSAvalon.Windows.UnitType.Percent);
            _Border_10_.BorderThickness = new MSAvalon.Windows.Thickness(new MSAvalon.Windows.Length(2, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(2, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(2, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(2, MSAvalon.Windows.UnitType.Pixel));
            _Border_10_.BorderBrush = new MSAvalon.Windows.Media.SolidColorBrush(MSAvalon.Windows.Media.Color.FromARGB(255, 0, 0, 0));
            ((MSAvalon.Windows.Serialization.IAddChild)(_DockPanel_2_)).AddChild(_Border_10_);
            MSAvalon.Windows.Controls.FlowPanel _FlowPanel_11_ = new MSAvalon.Windows.Controls.FlowPanel();
            ((MSAvalon.Windows.Serialization.ILoaded)(_FlowPanel_11_)).DeferLoad();
            _FlowPanel_11_.Background = new MSAvalon.Windows.Media.SolidColorBrush(MSAvalon.Windows.Media.Color.FromARGB(255, 173, 216, 230));
            ((MSAvalon.Windows.Serialization.IAddChild)(_Border_10_)).AddChild(_FlowPanel_11_);
            MSAvalon.Windows.Controls.Button _Button_12_ = new MSAvalon.Windows.Controls.Button();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_12_)).DeferLoad();
            _Button_12_.Width = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            _Button_12_.HorizontalAlignment = MSAvalon.Windows.HorizontalAlignment.Right;
            _Button_12_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Button_12_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _Button_12_.Click += new MSAvalon.Windows.Controls.ClickEventHandler(this.clients_Click);
            _Button_12_.Content = "Clients";
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_11_)).AddChild(_Button_12_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_12_)).EndDeferLoad();
            MSAvalon.Windows.Controls.ComboBox _ComboBox_13_ = new MSAvalon.Windows.Controls.ComboBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_ComboBox_13_)).DeferLoad();
            this.clients = _ComboBox_13_;
            _ComboBox_13_.ID = "clients";
            _ComboBox_13_.Visibility = MSAvalon.Windows.Visibility.Hidden;
            _ComboBox_13_.SelectionChanged += new MSAvalon.Windows.Controls.SelectionChangedEventHandler(this.clients_SelectionChanged);
            _ComboBox_13_.Height = new MSAvalon.Windows.Length(0, MSAvalon.Windows.UnitType.Pixel);
            _ComboBox_13_.Width = new MSAvalon.Windows.Length(90, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_11_)).AddChild(_ComboBox_13_);
            MSAvalon.Windows.Media.Animation.LengthAnimationCollection _LengthAnimationCollection_14_ = new MSAvalon.Windows.Media.Animation.LengthAnimationCollection();
            MSAvalon.Windows.Media.Animation.LengthAnimation _LengthAnimation_15_ = new MSAvalon.Windows.Media.Animation.LengthAnimation();
            _LengthAnimation_15_.From = new MSAvalon.Windows.Length(0, MSAvalon.Windows.UnitType.Pixel);
            _LengthAnimation_15_.To = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Pixel);
            _LengthAnimation_15_.Begin = ((MSAvalon.Windows.Media.Animation.TimeSyncValue)(System.ComponentModel.TypeDescriptor.GetConverter(typeof(MSAvalon.Windows.Media.Animation.TimeSyncValue)).ConvertFromInvariantString("Indefinite")));
            _LengthAnimation_15_.Duration = ((MSAvalon.Windows.Media.Animation.Time)(System.ComponentModel.TypeDescriptor.GetConverter(typeof(MSAvalon.Windows.Media.Animation.Time)).ConvertFromInvariantString("3")));
            ((MSAvalon.Windows.Serialization.IAddChild)(_LengthAnimationCollection_14_)).AddChild(_LengthAnimation_15_);
            ((MSAvalon.Windows.IApplyValue)(_LengthAnimationCollection_14_)).Apply(_ComboBox_13_, MSAvalon.Windows.FrameworkElement.HeightProperty);
            ((MSAvalon.Windows.Serialization.ILoaded)(_ComboBox_13_)).EndDeferLoad();
            MSAvalon.Windows.Controls.Button _Button_16_ = new MSAvalon.Windows.Controls.Button();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_16_)).DeferLoad();
            _Button_16_.Width = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            _Button_16_.HorizontalAlignment = MSAvalon.Windows.HorizontalAlignment.Right;
            _Button_16_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Button_16_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _Button_16_.Click += new MSAvalon.Windows.Controls.ClickEventHandler(this.Events_Click);
            _Button_16_.Content = "Events";
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_11_)).AddChild(_Button_16_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_16_)).EndDeferLoad();
            MSAvalon.Windows.Controls.ComboBox _ComboBox_17_ = new MSAvalon.Windows.Controls.ComboBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_ComboBox_17_)).DeferLoad();
            this.events = _ComboBox_17_;
            _ComboBox_17_.ID = "events";
            _ComboBox_17_.Visibility = MSAvalon.Windows.Visibility.Hidden;
            _ComboBox_17_.SelectionChanged += new MSAvalon.Windows.Controls.SelectionChangedEventHandler(this.events_SelectionChanged);
            _ComboBox_17_.Height = new MSAvalon.Windows.Length(0, MSAvalon.Windows.UnitType.Pixel);
            _ComboBox_17_.Width = new MSAvalon.Windows.Length(90, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_11_)).AddChild(_ComboBox_17_);
            MSAvalon.Windows.Media.Animation.LengthAnimationCollection _LengthAnimationCollection_18_ = new MSAvalon.Windows.Media.Animation.LengthAnimationCollection();
            MSAvalon.Windows.Media.Animation.LengthAnimation _LengthAnimation_19_ = new MSAvalon.Windows.Media.Animation.LengthAnimation();
            _LengthAnimation_19_.From = new MSAvalon.Windows.Length(0, MSAvalon.Windows.UnitType.Pixel);
            _LengthAnimation_19_.To = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Pixel);
            _LengthAnimation_19_.Begin = ((MSAvalon.Windows.Media.Animation.TimeSyncValue)(System.ComponentModel.TypeDescriptor.GetConverter(typeof(MSAvalon.Windows.Media.Animation.TimeSyncValue)).ConvertFromInvariantString("Indefinite")));
            _LengthAnimation_19_.Duration = ((MSAvalon.Windows.Media.Animation.Time)(System.ComponentModel.TypeDescriptor.GetConverter(typeof(MSAvalon.Windows.Media.Animation.Time)).ConvertFromInvariantString("5")));
            ((MSAvalon.Windows.Serialization.IAddChild)(_LengthAnimationCollection_18_)).AddChild(_LengthAnimation_19_);
            ((MSAvalon.Windows.IApplyValue)(_LengthAnimationCollection_18_)).Apply(_ComboBox_17_, MSAvalon.Windows.FrameworkElement.HeightProperty);
            ((MSAvalon.Windows.Serialization.ILoaded)(_ComboBox_17_)).EndDeferLoad();
            MSAvalon.Windows.Controls.Button _Button_20_ = new MSAvalon.Windows.Controls.Button();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_20_)).DeferLoad();
            _Button_20_.Width = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            _Button_20_.HorizontalAlignment = MSAvalon.Windows.HorizontalAlignment.Right;
            _Button_20_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Button_20_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _Button_20_.Click += new MSAvalon.Windows.Controls.ClickEventHandler(this.Notes_Click);
            _Button_20_.Content = "Notes";
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_11_)).AddChild(_Button_20_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_20_)).EndDeferLoad();
            MSAvalon.Windows.Controls.ComboBox _ComboBox_21_ = new MSAvalon.Windows.Controls.ComboBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_ComboBox_21_)).DeferLoad();
            this.notes = _ComboBox_21_;
            _ComboBox_21_.ID = "notes";
            _ComboBox_21_.Visibility = MSAvalon.Windows.Visibility.Hidden;
            _ComboBox_21_.SelectionChanged += new MSAvalon.Windows.Controls.SelectionChangedEventHandler(this.notes_SelectionChanged);
            _ComboBox_21_.Height = new MSAvalon.Windows.Length(0, MSAvalon.Windows.UnitType.Pixel);
            _ComboBox_21_.Width = new MSAvalon.Windows.Length(90, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_11_)).AddChild(_ComboBox_21_);
            MSAvalon.Windows.Media.Animation.LengthAnimationCollection _LengthAnimationCollection_22_ = new MSAvalon.Windows.Media.Animation.LengthAnimationCollection();
            MSAvalon.Windows.Media.Animation.LengthAnimation _LengthAnimation_23_ = new MSAvalon.Windows.Media.Animation.LengthAnimation();
            _LengthAnimation_23_.From = new MSAvalon.Windows.Length(0, MSAvalon.Windows.UnitType.Pixel);
            _LengthAnimation_23_.To = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Pixel);
            _LengthAnimation_23_.Begin = ((MSAvalon.Windows.Media.Animation.TimeSyncValue)(System.ComponentModel.TypeDescriptor.GetConverter(typeof(MSAvalon.Windows.Media.Animation.TimeSyncValue)).ConvertFromInvariantString("Indefinite")));
            _LengthAnimation_23_.Duration = ((MSAvalon.Windows.Media.Animation.Time)(System.ComponentModel.TypeDescriptor.GetConverter(typeof(MSAvalon.Windows.Media.Animation.Time)).ConvertFromInvariantString("5")));
            ((MSAvalon.Windows.Serialization.IAddChild)(_LengthAnimationCollection_22_)).AddChild(_LengthAnimation_23_);
            ((MSAvalon.Windows.IApplyValue)(_LengthAnimationCollection_22_)).Apply(_ComboBox_21_, MSAvalon.Windows.FrameworkElement.HeightProperty);
            ((MSAvalon.Windows.Serialization.ILoaded)(_ComboBox_21_)).EndDeferLoad();
            MSAvalon.Windows.Controls.Button _Button_24_ = new MSAvalon.Windows.Controls.Button();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_24_)).DeferLoad();
            _Button_24_.Width = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            _Button_24_.HorizontalAlignment = MSAvalon.Windows.HorizontalAlignment.Right;
            _Button_24_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Button_24_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _Button_24_.Click += new MSAvalon.Windows.Controls.ClickEventHandler(this.Products_Click);
            _Button_24_.Content = "Products";
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_11_)).AddChild(_Button_24_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_24_)).EndDeferLoad();
            MSAvalon.Windows.Controls.Button _Button_25_ = new MSAvalon.Windows.Controls.Button();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_25_)).DeferLoad();
            _Button_25_.Width = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            _Button_25_.HorizontalAlignment = MSAvalon.Windows.HorizontalAlignment.Right;
            _Button_25_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Button_25_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _Button_25_.Click += new MSAvalon.Windows.Controls.ClickEventHandler(this.create_Click);
            _Button_25_.Content = "Create Sample Data";
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_11_)).AddChild(_Button_25_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_25_)).EndDeferLoad();
            MSAvalon.Windows.Shapes.Line _Line_26_ = new MSAvalon.Windows.Shapes.Line();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Line_26_)).DeferLoad();
            _Line_26_.Height = new MSAvalon.Windows.Length(40, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_11_)).AddChild(_Line_26_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_Line_26_)).EndDeferLoad();
            MSAvalon.Windows.Controls.Button _Button_27_ = new MSAvalon.Windows.Controls.Button();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_27_)).DeferLoad();
            _Button_27_.Width = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            _Button_27_.HorizontalAlignment = MSAvalon.Windows.HorizontalAlignment.Right;
            _Button_27_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Button_27_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _Button_27_.Click += new MSAvalon.Windows.Controls.ClickEventHandler(this.remove_Click);
            _Button_27_.Content = "Remove Sample Data";
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_11_)).AddChild(_Button_27_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_Button_27_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_FlowPanel_11_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Border_10_)).EndDeferLoad();
            MSAvalon.Windows.Controls.Border _Border_28_ = new MSAvalon.Windows.Controls.Border();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Border_28_)).DeferLoad();
            MSAvalon.Windows.Controls.DockPanel.SetDock(_Border_28_, MSAvalon.Windows.Controls.Dock.Right);
            _Border_28_.Width = new MSAvalon.Windows.Length(80, MSAvalon.Windows.UnitType.Percent);
            _Border_28_.Height = new MSAvalon.Windows.Length(75, MSAvalon.Windows.UnitType.Percent);
            _Border_28_.BorderThickness = new MSAvalon.Windows.Thickness(new MSAvalon.Windows.Length(4, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(4, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(4, MSAvalon.Windows.UnitType.Pixel), new MSAvalon.Windows.Length(4, MSAvalon.Windows.UnitType.Pixel));
            _Border_28_.BorderBrush = new MSAvalon.Windows.Media.SolidColorBrush(MSAvalon.Windows.Media.Color.FromARGB(255, 0, 0, 0));
            ((MSAvalon.Windows.Serialization.IAddChild)(_DockPanel_2_)).AddChild(_Border_28_);
            MSAvalon.Windows.Controls.FlowPanel _FlowPanel_29_ = new MSAvalon.Windows.Controls.FlowPanel();
            ((MSAvalon.Windows.Serialization.ILoaded)(_FlowPanel_29_)).DeferLoad();
            this.ContentArea = _FlowPanel_29_;
            _FlowPanel_29_.ID = "ContentArea";
            MSAvalon.Windows.Controls.DockPanel.SetDock(_FlowPanel_29_, MSAvalon.Windows.Controls.Dock.Right);
            _FlowPanel_29_.Background = new MSAvalon.Windows.Media.SolidColorBrush(MSAvalon.Windows.Media.Color.FromARGB(255, 255, 255, 255));
            ((MSAvalon.Windows.Serialization.IAddChild)(_Border_28_)).AddChild(_FlowPanel_29_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_FlowPanel_29_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Border_28_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_DockPanel_2_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Window_1_)).EndDeferLoad();
        }
    }
}
