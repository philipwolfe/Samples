/* ****************************************************************************
 * AvalonLife 1.0
 * 
 * ALBrushDlg.xaml.cs
 * 
 * Implements the brush picker dialog used to define the appearance of live
 * cells.
 * 
 * Written by Mark Betz - http://www.markbetz.net
 * 
 * This application and related source code is released to the public domain.
 * If you modify and redistribute this source or executable please indicate
 * the version in the application window title, and include a readme file
 * listing the changes you have made.
 * 
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AvalonLife
{
    /// <summary>
    /// Interaction logic for ALBrushDlg.xaml
    /// </summary>

    public partial class ALBrushDlg : System.Windows.Window, INotifyPropertyChanged
    
    {

        public ALBrushDlg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets up brushes for the four fill areas on the UI: the three color
        /// swatches and the result swatch.
        /// </summary>
        private void SetupBrushes()
        {
            C1Swatch.Fill = new SolidColorBrush(_c1Color);
            if (_brushType == CellBrushType.Radial || _brushType == CellBrushType.Linear)
            {
                C1OffsetSlider.IsEnabled = true;
                C2Swatch.Fill = new SolidColorBrush(_c2Color);
                C2Swatch.IsEnabled = true;
                C2OffsetSlider.IsEnabled = true;
                C3Swatch.Fill = new SolidColorBrush(_c3Color);
                C3Swatch.IsEnabled = true;
                C3OffsetSlider.IsEnabled = true;
            }
            else
            {
                C1OffsetSlider.IsEnabled = false;
                C2Swatch.Fill = new SolidColorBrush(Colors.DarkGray);
                C2Swatch.IsEnabled = false;
                C2OffsetSlider.IsEnabled = false;
                
                C3Swatch.Fill = new SolidColorBrush(Colors.DarkGray);
                C3Swatch.IsEnabled = false;
                C3OffsetSlider.IsEnabled = false;
            }

            if (_brushType == CellBrushType.Solid)
            {
                ResultSwatch.Fill = C1Swatch.Fill;
            }
            else if (_brushType == CellBrushType.Radial)
            {
                RadialGradientBrush brush = new RadialGradientBrush();
                brush.GradientOrigin = new Point(0.5, 0.5);
                brush.GradientStops.Add( new GradientStop(_c1Color, _c1offset) );
                brush.GradientStops.Add(new GradientStop(_c2Color, _c2offset));
                brush.GradientStops.Add(new GradientStop(_c3Color, _c3offset));
                brush.RadiusX = 0.5;
                brush.RadiusY = 0.5;
                brush.Freeze();
                ResultSwatch.Fill = brush;
            }
            else if (_brushType == CellBrushType.Linear)
            {
                LinearGradientBrush brush = new LinearGradientBrush();
                brush.StartPoint = new Point(0, 0);
                brush.EndPoint = new Point(1, 1);

                brush.GradientStops.Add(new GradientStop(_c1Color, _c1offset));
                brush.GradientStops.Add(new GradientStop(_c2Color, _c2offset));
                brush.GradientStops.Add(new GradientStop(_c3Color, _c3offset));

                brush.Freeze();
                ResultSwatch.Fill = brush;
            }
        }
        
        public void On_BrushDlgLoaded(Object sender, RoutedEventArgs e)
        {
            _brushType = ALSettings.Default.LifeCellBrushType;
            
            BrushTypeRadialButton.Tag = CellBrushType.Radial;
            BrushTypeLinearButton.Tag = CellBrushType.Linear;
            BrushTypeSolidButton.Tag = CellBrushType.Solid;
            
            C1Swatch.Tag = 1;
            C2Swatch.Tag = 2;
            C3Swatch.Tag = 3;
            
            if ( _brushType == CellBrushType.Radial )
                BrushTypeRadialButton.IsChecked = true;
            else if ( _brushType == CellBrushType.Linear )
                BrushTypeLinearButton.IsChecked = true;
            else if ( _brushType == CellBrushType.Linear )
                BrushTypeSolidButton.IsChecked = true;
                
            C1OffsetSlider.DataContext = this;
            C2OffsetSlider.DataContext = this;
            C3OffsetSlider.DataContext = this;

            BrushDlgOKButton.DataContext = this;
                        
            _c1Color = ALSettings.Default.CellBrushC1;
            _c2Color = ALSettings.Default.CellBrushC2;
            _c3Color = ALSettings.Default.CellBrushC3;
            
            _c1offset = ALSettings.Default.CellBrushC1Off;
            _c2offset = ALSettings.Default.CellBrushC2Off;
            _c3offset = ALSettings.Default.CellBrushC3Off;

            SetupBrushes();
        }

        /// <summary>
        /// Handles a change of brush type and calls SetupBrushes()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void On_BrushTypeButtonClick(Object sender, RoutedEventArgs e)
        {
            switch( ((CellBrushType)((RadioButton)sender).Tag) )
            {
                case CellBrushType.Radial:
                    _brushType = CellBrushType.Radial;
                    SetupBrushes();
                    break;
                case CellBrushType.Linear:
                    _brushType = CellBrushType.Linear;
                    SetupBrushes();
                    break;
                case CellBrushType.Solid:
                    _brushType = CellBrushType.Solid;
                    SetupBrushes();
                    break;
            }
            Changed = true;
        }
        
        /// <summary>
        /// Catches a click on a primary color swatch and pops the color picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void On_SwatchMouseUp(Object sender, MouseButtonEventArgs e)
        {
            System.Windows.Forms.ColorDialog clrDlg = new System.Windows.Forms.ColorDialog();

            clrDlg.AllowFullOpen = true;
            clrDlg.SolidColorOnly = true;

            Color newColor;
            
            if (clrDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {    
                newColor = Color.FromArgb(clrDlg.Color.A, clrDlg.Color.R, clrDlg.Color.G, clrDlg.Color.B);
            
                switch( (int)((Rectangle)sender).Tag )
                {
                    case 1:
                        _c1Color = newColor;
                        SetupBrushes();
                        break;
                    case 2:
                        _c2Color = newColor;
                        SetupBrushes();
                        break;
                    case 3:
                        _c3Color = newColor;
                        SetupBrushes();
                        break;
                }
                Changed = true;
            }
        }

        /// <summary>
        /// Copies the current color selection to the persistent settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void On_BrushDlgOKButton(Object sender, RoutedEventArgs e)
        {
            ALSettings.Default.LifeCellBrushType = _brushType;
            ALSettings.Default.CellBrushC1 = _c1Color;
            ALSettings.Default.CellBrushC2 = _c2Color;
            ALSettings.Default.CellBrushC3 = _c3Color;
            ALSettings.Default.CellBrushC1Off = _c1offset;
            ALSettings.Default.CellBrushC2Off = _c2offset;
            ALSettings.Default.CellBrushC3Off = _c3offset;

            this.DialogResult = true;
            this.Close();
        }
        
        /// <summary>
        /// The OK button's IsEnabled property is bound to Changed
        /// </summary>
        private bool _changed = false;
        public bool Changed
        {
            get
            {
                return _changed;
            }
            set
            {
                _changed = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Changed"));
            }
        }
        
        private double _c1offset = 0;
        public double C1Offset
        {
            get
            {
                return _c1offset;
            }
            set
            {
                _c1offset = value;
                Changed = true;
                SetupBrushes();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("C1Offset"));
            }    
        }

        private double _c2offset = 0;
        public double C2Offset
        {
            get
            {
                return _c2offset;
            }
            set
            {
                _c2offset = value;
                Changed = true;
                SetupBrushes();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("C2Offset"));
            }
        }

        private double _c3offset = 0;
        public double C3Offset
        {
            get
            {
                return _c3offset;
            }
            set
            {
                _c3offset = value;
                Changed = true;
                SetupBrushes();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("C3Offset"));
            }
        }
        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
        
        private Color _c1Color;
        private Color _c2Color;
        private Color _c3Color;
        private CellBrushType _brushType;
    }
}