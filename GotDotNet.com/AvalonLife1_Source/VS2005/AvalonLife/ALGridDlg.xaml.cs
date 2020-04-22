/* ****************************************************************************
 * AvalonLife 1.0
 * 
 * ALGridDlg.xaml.cs
 * 
 * Implements the code-beside for the grid settings dialog.
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
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for ALGridDlg.xaml
    /// </summary>

    public partial class ALGridDlg : System.Windows.Window, INotifyPropertyChanged
    {

        public ALGridDlg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets up the dialog UI according to the current set of persistent
        /// grid settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void On_GridDlgLoaded(Object sender, RoutedEventArgs e)
        {
            GridType gt = ALSettings.Default.DefaultGridType;
            switch ( gt )
            {
                case GridType.Torus :
                    GridTypeTorusButton.IsChecked = true;
                    break;
                case GridType.XCylinder:
                    GridTypeXCylButton.IsChecked = true;
                    break;
                case GridType.YCylinder:
                    GridTypeYCylButton.IsChecked = true;
                    break;
                case GridType.Finite:
                    GridTypeFiniteButton.IsChecked = true;
                    break;
            }
            
            int rows = ALSettings.Default.GridHeight;
            int cols = ALSettings.Default.GridWidth;
            
            RowsEdit.IsEnabled = false;
            ColsEdit.IsEnabled = false;
            
            if ( rows == 40 && cols == 40 )
                GridSize40Button.IsChecked = true;
            else if (rows == 50 && cols == 50)
                GridSize50Button.IsChecked = true;
            else if (rows == 60 && cols == 60)
                GridSize60Button.IsChecked = true;
            else if (rows == 70 && cols == 70)
                GridSize70Button.IsChecked = true;
            else
            {
                RowsEdit.IsEnabled = true;
                ColsEdit.IsEnabled = true;
                GridSize40Button.IsEnabled = false;
                GridSize50Button.IsEnabled = false;
                GridSize60Button.IsEnabled = false;
                GridSize70Button.IsEnabled = false;
                GridSizeCustomCheck.IsChecked = true;
                ColsEdit.Text = cols.ToString();
                RowsEdit.Text = rows.ToString();
            }
            
            if ( ALSettings.Default.ShrinkGridToModel )
                GridSizeShrink.IsChecked = true;
            else
                GridSizeCenter.IsChecked = true;
                
            GridDlgOK.DataContext = this;           
        }

        /// <summary>
        /// Used to flip the Changed flag if the user touches the
        /// settings. The OK button's IsEnabled property is bound to
        /// the dialog's Changed property.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void On_GridSettingsClick(Object sender, RoutedEventArgs e)
        {
            Changed = true;
        }
        
        /// <summary>
        /// Handles a click on the Custom check box under the grid size group.
        /// Changes the UI state to reflect a custom grid settings, i.e. disables
        /// the predefined sizes and enables the custom size edits, or vice versa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void On_GridSizeCustomCheck(Object sender, RoutedEventArgs e)
        {
            int rows = ALSettings.Default.GridHeight;
            int cols = ALSettings.Default.GridWidth;

            if (GridSizeCustomCheck.IsChecked == true)
            {
                GridSize40Button.IsEnabled = false;
                GridSize50Button.IsEnabled = false;
                GridSize60Button.IsEnabled = false;
                GridSize70Button.IsEnabled = false;
                ColsEdit.Text = cols.ToString();
                RowsEdit.Text = rows.ToString();
                RowsEdit.IsEnabled = true;
                ColsEdit.IsEnabled = true;
            }
            else
            {
                GridSize40Button.IsEnabled = true;
                GridSize50Button.IsEnabled = true;
                GridSize60Button.IsEnabled = true;
                GridSize70Button.IsEnabled = true;
                ColsEdit.Text = "";
                RowsEdit.Text = "";
                RowsEdit.IsEnabled = false;
                ColsEdit.IsEnabled = false;
         
                if ( rows == 40 && cols == 40 )
                    GridSize40Button.IsChecked = true;
                else if (rows == 50 && cols == 50)
                    GridSize50Button.IsChecked = true;
                else if (rows == 60 && cols == 60)
                    GridSize60Button.IsChecked = true;
                else if (rows == 70 && cols == 70)
                    GridSize70Button.IsChecked = true;
                else
                    GridSize50Button.IsChecked = true;
            }
            Changed = true;
        }
        
        /// <summary>
        /// Grabs the settings and writes them out. Uses the exception wrapper to detect 
        /// unconvertable text (stupid, I know, have to put validation on the edits, but
        /// I haven't taken time to figure it out yet). Warns the user if they request a
        /// huge custom model size (greater than 100 x 100 or equivalent).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void On_GridDlgOkButton(Object sender, RoutedEventArgs e)
        {
            if (GridSizeCustomCheck.IsChecked == true)
            {
                try
                {
                    int rows = Convert.ToInt32(RowsEdit.Text);
                    int cols = Convert.ToInt32(ColsEdit.Text);

                    if (rows * cols > 10000)
                    {
                        string msg = ((ALMainWin)this.Owner).PrepMessage(Properties.Resources.UI_MB_LargeModelMsg, 80);
                        msg += "\n\nRequested model size will cause the program to create approximately "
                            + Convert.ToString((rows * cols) * 3) + " objects.";
                        if (MessageBox.Show(this, msg, Properties.Resources.UI_MB_LargeModelCaption,
                            MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                        {
                            return;
                        }
                        else if (rows > 0 && cols > 0)
                        {
                            ALSettings.Default.GridHeight = rows;
                            ALSettings.Default.GridWidth = cols;
                        }
                    }
                }
                catch (System.Exception)
                {
                }
            }
            else if (GridSize40Button.IsChecked == true)
            {
                ALSettings.Default.GridHeight = 40;
                ALSettings.Default.GridWidth = 40;
            }
            else if (GridSize50Button.IsChecked == true)
            {
                ALSettings.Default.GridHeight = 50;
                ALSettings.Default.GridWidth = 50;
            }
            else if (GridSize60Button.IsChecked == true)
            {
                ALSettings.Default.GridHeight = 60;
                ALSettings.Default.GridWidth = 60;
            }
            else if (GridSize70Button.IsChecked == true)
            {
                ALSettings.Default.GridHeight = 70;
                ALSettings.Default.GridWidth = 70;
            }
            if (GridTypeTorusButton.IsChecked == true)
                ALSettings.Default.DefaultGridType = GridType.Torus;
            else if (GridTypeXCylButton.IsChecked == true )
                ALSettings.Default.DefaultGridType = GridType.XCylinder;
            else if (GridTypeYCylButton.IsChecked == true )
                ALSettings.Default.DefaultGridType = GridType.YCylinder;
            else if (GridTypeFiniteButton.IsChecked == true )
                ALSettings.Default.DefaultGridType = GridType.Finite;
                
            if ( GridSizeShrink.IsChecked == true )
                ALSettings.Default.ShrinkGridToModel = true;
            else 
                ALSettings.Default.ShrinkGridToModel = false;

            this.DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// The OK button's IsEnabled property is bound to the Changed property
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

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }
}