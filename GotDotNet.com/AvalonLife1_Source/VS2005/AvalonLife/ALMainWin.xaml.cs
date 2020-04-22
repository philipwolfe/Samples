/* ****************************************************************************
 * AvalonLife 1.0
 * 
 * ALMainWin.xaml.cs
 * 
 * Provides the code-beside implementation for the AvalonLife main window.
 * 
 * Written by Mark Betz - http://www.markbetz.net
 * 
 * This application and related source code is released to the public domain.
 * If you modify and redistribute this source or executable please indicate
 * the version in the application window title, and include a readme file
 * listing the changes you have made.
 * 
 * Aknowledgements -
 * 
 * Scott Allen's XAML implementation of Life provided several ideas and
 * implementation techniques that greatly accelerated my education. His article
 * on the project can be read at: http://www.odetocode.com/Articles/444.aspx
*/

using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace AvalonLife
{
    /// <summary>
    /// UIStateChanges
    /// 
    /// This enum provides indicators for the user interface states
    /// that the program can be in. Used to call UIStateChange().
    /// </summary>
    enum UIStateChanges
    {
        ModelCreated,
        ModelSaved,
        ModelSavedAs,
        ModelLoadedFromFile,
        ModelLoadedFromNet,
        ModelCellEdited,
        ModelRun,
        ModelPaused,
        ModelHalted,
        ModelReset,
        ModelPropertiesEdited    
    }
    
    /// <summary>
    /// Used to indicate the current type of cell brush used to pain
    /// the grid
    /// </summary>
    enum CellBrushType
    {
        Radial,
        Linear,
        Solid
    }
    
    enum ALFileType
    {
        None,
        AVL,
        Cells
    }
    
    public partial class ALMainWin : System.Windows.Window
    {

        #region ReticleAdorner class
        
        /// <summary>
        /// ReticleAdorner
        /// 
        /// This class is derived from Adorner, and renders the reticle (crosshairs)
        /// over the main game grid.
        /// </summary>
        public class ReticleAdorner : Adorner
        {
            public ReticleAdorner( UIElement target )
            : base(target)
            {
                _reticleColor = ALSettings.Default.ReticleColor;
                _reticlePen = new Pen(new SolidColorBrush(_reticleColor), 1);
            }
            
            protected override void OnRender( DrawingContext dctxt )
            {
                double height = ((Grid)(this.AdornedElement)).ActualHeight;
                double width = ((Grid)(this.AdornedElement)).ActualWidth;

                Point start = new Point( 0, height / 2 );
                Point end = new Point( width, height / 2 );
                dctxt.DrawLine( _reticlePen, start, end );
                
                start = new Point( width / 2, 0 );
                end = new Point( width / 2, height );
                dctxt.DrawLine( _reticlePen, start, end );
            }           
        
            /// <summary>
            /// Set this property to change the color of the reticle
            /// </summary>
            private Color _reticleColor;
            public Color ReticleColor
            {
                get
                {
                    return _reticleColor;
                }
                set
                {
                    _reticleColor = value;
                    ALSettings.Default.ReticleColor = _reticleColor;
                    _reticlePen = new Pen(new SolidColorBrush(_reticleColor), 1);
                }
            }
            
            private Pen _reticlePen;
        }
        
        #endregion
        
        public ALMainWin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// PrepMessage( string, int )
        /// 
        /// A simple function to insert line breaks into a string destined for a messagebox.
        /// MessageBox.Show() seems to work differently on XP and Vista. On Vista a long
        /// message is sensibly wrapped at word boundaries. On XP it is not. If you insert
        /// line breaks to look right in XP, they don't look right in Vista. So this is an
        /// attempt to get some consistency.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="lineLen"></param>
        /// <returns></returns>
        public string PrepMessage(string msg, int lineLen)
        {
            string strout = "";
            int j = 0;
            for (int i = 0; i < msg.Length; i++)
            {
                if ((j >= lineLen && msg[i] == ' ') || i == msg.Length - 1)
                {
                    strout += msg.Substring(i - j, j);
                    strout += "\n";
                    j = 0;
                }
                else j++;
            }
            return strout;
        }

        #region menu bar event handlers
        
        /// <summary>
        /// Menu_OnGameNew(Object, RoutedEventArgs)
        /// 
        /// Handles the click event for the game menu, new command. Prompts the user and
        /// on yes rebuilds the simulation and life models and resets the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnGameNew(Object sender, RoutedEventArgs e)
        {
            Cursor oldCursor = LifeGrid.Cursor;
            LifeGrid.Cursor = Cursors.Wait;
            
            bool paused = _ls.IsPaused;
            _ls.IsPaused = true;
            
            if ( ExecNew(false) )
                oldCursor = LifeGrid.Cursor;
            else
                _ls.IsPaused = paused;
        
            LifeGrid.Cursor = oldCursor;
        }
        
        /// <summary>
        /// Menu_OnGameReset(Object, RoutedEventArgs)
        /// 
        /// Handles a click event on the Game menu, Reset item. Prompts the user, and on 'Yes' 
        /// rebuilds the model and simulation controller, and resets various parameters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnGameReset(Object sender, RoutedEventArgs e)
        {
            Cursor oldCursor = LifeGrid.Cursor;
            LifeGrid.Cursor = Cursors.Wait;

            bool paused = _ls.IsPaused;
            _ls.IsPaused = true;
            
            if (MessageBox.Show(this, Properties.Resources.UI_MB_PromptText2, Properties.Resources.UI_MB_CaptionText2,
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ls.ResetSim();
                UIStateChange(UIStateChanges.ModelReset);
                oldCursor = LifeGrid.Cursor;
            }
            else
                _ls.IsPaused = paused;

            LifeGrid.Cursor = oldCursor;
        }
        
        /// <summary>
        /// Menu_OnGameSave(Object, RoutedEventArgs)
        /// 
        /// Handles the click event for the game menu, save command. Pauses the sim if
        /// it is not already, and then calls ExecSave()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnGameSave(Object sender, RoutedEventArgs e)
        {
            Cursor oldCursor = LifeGrid.Cursor;
            LifeGrid.Cursor = Cursors.Wait;

            bool paused = _ls.IsPaused;
            _ls.IsPaused = true;

            ExecSave(false);

            _ls.IsPaused = paused;

            LifeGrid.Cursor = oldCursor;
        }

        /// <summary>
        /// Menu_OnGameSaveAs(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the "save as" command in the Game menu. The only difference
        /// from the function above is that this one calls ExecSave with true, causing
        /// a new filename to be chosen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnGameSaveAs(Object sender, RoutedEventArgs e)
        {
            Cursor oldCursor = LifeGrid.Cursor;
            LifeGrid.Cursor = Cursors.Wait;

            bool paused = _ls.IsPaused;
            _ls.IsPaused = true;

            ExecSave(true);

            _ls.IsPaused = paused;

            LifeGrid.Cursor = oldCursor;
        }

        /// <summary>
        /// Menu_OnGameLoad(Object, RoutedEventArgs)
        /// 
        /// Handles the click event for the game menu, load command. Pauses the sim and
        /// then checks to see if the current game is dirty. If so it pops a save dialog 
        /// and calls ExecSave() if the user answers affirm. It then calls ExecLoad(). If
        /// load fails (ExecLoad returns false) the function unpauses the game (if it was
        /// paused on entry). 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnGameLoad(Object sender, RoutedEventArgs e)
        {
            Cursor oldCursor = LifeGrid.Cursor;
            LifeGrid.Cursor = Cursors.Wait;

            bool paused = _ls.IsPaused;
            _ls.IsPaused = true;
            bool final = false;

            System.Windows.Forms.OpenFileDialog opendlg =
                new System.Windows.Forms.OpenFileDialog();

            opendlg.DefaultExt = ".avl";
            opendlg.Filter = "AvalonLife Saved Games (.avl)|*.avl|Life Lexicon Cells (.cells)|*.cells";
            opendlg.Title = "Load Saved Model";
            if (opendlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ( ExecLoadFile(opendlg.FileName) )
                {
                    final = true;
                }
            }
            if ( !final )
                _ls.IsPaused = paused;

            LifeGrid.Cursor = oldCursor;
        }

        /// <summary>
        /// Menu_OnGameExit(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the game menu, exit command, and shuts down the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnGameExit(Object sender, RoutedEventArgs e)
        {
            bool paused = _ls.IsPaused;
            _ls.IsPaused = true;
            
            if ( CheckSave() == true )
                Application.Current.Shutdown();
            
            _ls.IsPaused = paused;
        }

        /// <summary>
        /// Menu_OnSettingsGridLines(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the settings menu, show grid command, and turns the
        /// grid lines on/off accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnSettingsGridLines(Object sender, RoutedEventArgs e)
        {
            if (MenuSettingsGridLines.IsChecked == false)
            {
                ALSettings.Default.GridOn = true;
                LifeGrid.ShowGridLines = true;
                MenuSettingsGridLines.IsChecked = true;
            }
            else
            {
                ALSettings.Default.GridOn = false;
                LifeGrid.ShowGridLines = false;
                MenuSettingsGridLines.IsChecked = false;
            }
        }

        /// <summary>
        /// Menu_OnSettingsReticle(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the settings menu, show reticle command, and turns the
        /// reticle (crosshairs) on/off accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnSettingsReticle(Object sender, RoutedEventArgs e)
        {
            if ( MenuSettingsReticle.IsChecked == false )
            {
                ALSettings.Default.ReticleOn = true;
                _gridAdornerLayer.GetAdorners(LifeGrid)[0].Visibility = Visibility.Visible;
                MenuSettingsReticle.IsChecked = true;
            }
            else
            {
                ALSettings.Default.ReticleOn = false;
                _gridAdornerLayer.GetAdorners(LifeGrid)[0].Visibility = Visibility.Hidden;
                MenuSettingsReticle.IsChecked = false;
            }
        }

        /// <summary>
        /// Menu_OnSettingsHaltStable(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the Settings | Halt Stable Model command. Flips the
        /// state of this property in ALSettings. Controls whether the simulation will
        /// halt when a model ceases evolving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnSettingsHaltStable(Object sender, RoutedEventArgs e)
        {
            if (MenuSettingsHaltStable.IsChecked == false)
            {    
                MenuSettingsHaltStable.IsChecked = true;
                ALSettings.Default.HaltOnStability = true;
            }
            else
            {
                MenuSettingsHaltStable.IsChecked = false;
                ALSettings.Default.HaltOnStability = false;
            }
        }

        /// <summary>
        /// Menu_OnSettingsGridBackground(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the settings menu, grid background command. Opens a color picker
        /// dialog to let the user choose the grid background color. I'm sure there must be an easier
        /// way to deal with the collision between System.Windows.Media.xxx, which is used by
        /// the WPF shapes and brushes, and System.Drawing.xxx which is used by the standard color
        /// dialog in System.Windows.Forms, but I haven't taken the time to research it yet. So
        /// for the moment this function is full of ugly conversions. Works, though.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnSettingsGridBackground(Object sender, RoutedEventArgs e)
        {
            bool paused = _ls.IsPaused;
            _ls.IsPaused = true;
            
            System.Windows.Forms.ColorDialog clrDlg = new System.Windows.Forms.ColorDialog();
            
            clrDlg.AllowFullOpen = true;
            clrDlg.SolidColorOnly = true;
            System.Drawing.Color origColor = System.Drawing.Color.FromArgb(
              ((SolidColorBrush)LifeGrid.Background).Color.A,
              ((SolidColorBrush)LifeGrid.Background).Color.R,
              ((SolidColorBrush)LifeGrid.Background).Color.G,
              ((SolidColorBrush)LifeGrid.Background).Color.B );
            
            clrDlg.Color = origColor;
            if ( clrDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
               Color newColor = Color.FromArgb(clrDlg.Color.A, clrDlg.Color.R, clrDlg.Color.G, clrDlg.Color.B);
               ALSettings.Default.GridBackground = newColor;
               SolidColorBrush gridBkgBrush = new SolidColorBrush( newColor );
               LifeGrid.Background = gridBkgBrush; 
            }
            _ls.IsPaused = paused;
        }
        
        /// <summary>
        /// Menu_OnSettingsReticleColor(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the settings menu, reticle color command. Opens a color
        /// picker and allows the user to choose a new color for drawing the reticle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnSettingsReticleColor(Object sender, RoutedEventArgs e)
        {
            bool paused = _ls.IsPaused;
            _ls.IsPaused = true;
            ReticleAdorner ad = _gridAdornerLayer.GetAdorners(LifeGrid)[0] as ReticleAdorner;

            System.Windows.Forms.ColorDialog clrDlg = new System.Windows.Forms.ColorDialog();
            
            clrDlg.AllowFullOpen = true;
            clrDlg.SolidColorOnly = true;

            if ( clrDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                Color newColor = Color.FromArgb(clrDlg.Color.A, clrDlg.Color.R, clrDlg.Color.G, clrDlg.Color.B);
                ad.ReticleColor = newColor;
                ALSettings.Default.ReticleColor = newColor;
                ad.InvalidateVisual();
            }
            _ls.IsPaused = paused;
        }

        /// <summary>
        /// Menu_OnSettingsCellBrush(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the Settings | Cell Brush command, and pops the brush definer
        /// dialog. Calls ApplyCellBrush on return if the user accepted the dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnSettingsCellBrush(Object sender, RoutedEventArgs e)
        {
            Cursor oldCursor = LifeGrid.Cursor;
            
            bool paused = _ls.IsPaused;
            _ls.IsPaused = true;
            
            ALBrushDlg dlg = new ALBrushDlg();
            
            dlg.Owner = this;
            if ( dlg.ShowDialog() == true )
            {
                LifeGrid.Cursor = Cursors.Wait;
                ApplyRectStyle();
                LifeGrid.Cursor = oldCursor;
            }    
            _ls.IsPaused = paused;
        }
        
        /// <summary>
        /// Menu_OnSettingsGridType(Object, RoutedEventArgs)
        /// 
        /// Handles a click on one of the grid type checkable menuitems in Settings | Grid Type.
        /// The Tag property of these controls has been set to the appropriate value from
        /// the GridType enumeration, so the tag can just be cast and passed through to
        /// SetGridType.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnSettingsGridType(Object sender, RoutedEventArgs e)
        {
            GridType gridType = (GridType)((MenuItem)sender).Tag;
            if (_ls.Model.LifeGridType != gridType)
            {
                _ls.Model.LifeGridType = gridType;
                SetGridType(gridType);
                UIStateChange(UIStateChanges.ModelPropertiesEdited);
            }
        }

        /// <summary>
        /// Menu_OnSettingsGridSize(Object, RoutedEventArgs)
        /// 
        /// Handles a click on one of the pre-defined grid sizes in the Settings | Grid Size
        /// | [predefined grid size] menu. Since the predefined model sizes are square we can
        /// just store one dimensionin the object tag at startup, grab it here, and use it to
        /// figure out what size was requested.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnSettingsGridSize(Object sender, RoutedEventArgs e)
        {
            Cursor oldCursor = LifeGrid.Cursor;
            LifeGrid.Cursor = Cursors.Wait;
            
            bool paused = _ls.IsPaused;
            _ls.IsPaused = true;
            
            int size = (int)(((MenuItem)sender).Tag);
            if ( _ls.Model.ResizeModel(size, size) )
            {
                InitUIState();
                UIStateChange(UIStateChanges.ModelPropertiesEdited);
            }
            else
                MessageBox.Show(this, Properties.Resources.UI_MB_ResizeFailedMsg, Properties.Resources.UI_MB_ResizeFailedCaption,
                    MessageBoxButton.OK, MessageBoxImage.Error);
            
            _ls.IsPaused = paused;
            LifeGrid.Cursor = oldCursor;    
        }

        /// <summary>
        /// Menu_OnSettingsGridSizeCustom(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the Settings | Grid Size | Custom menu. The dialog enforces type
        /// constraints on the edit, so we know we're getting ints, but we need to check how
        /// large a model the user has asked for. You can ask the sim to make a 1000 x 1000 grid.
        /// I did, and by the time I killed the process five minutes later it had a 1.7 gig
        /// working set. A grid that size requires the system to create about 3 million objects,
        /// plus or minus a couple hundred thousand. So we check to see if the aggregate grid
        /// size is greater than 10k cells, and pop a warning dialog. If the user wants to go
        /// ahead we let them. I've done a 200 x 200 grid and it loads relatively quickly and will
        /// actually run, but not smoothly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnSettingsGridSizeCustom(Object sender, RoutedEventArgs e)
        {
            Cursor oldCursor = LifeGrid.Cursor;
            LifeGrid.Cursor = Cursors.Wait;

            bool paused = _ls.IsPaused;
            _ls.IsPaused = true;

            ALModelSizeDlg dlg = new ALModelSizeDlg();
            dlg.Owner = this;
            dlg.Tag = _ls.Model;
            dlg.Resize = true;
            
            if ( dlg.ShowDialog() == true )
            {
            
                int rows = dlg.Rows;
                int cols = dlg.Columns;
                if ( rows * cols > 10000 )
                {
                    string msg = PrepMessage(Properties.Resources.UI_MB_LargeModelMsg, 80);
                    msg += "\n\nRequested model size will cause the program to create approximately " 
                        + Convert.ToString((rows * cols) * 3) + " objects.";
                    if ( MessageBox.Show(this, msg, Properties.Resources.UI_MB_LargeModelCaption, 
                        MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel )
                    {    
                        LifeGrid.Cursor = oldCursor;
                        return;
                    }
                }
                
                if (_ls.Model.ResizeModel(rows, cols))
                {
                    InitUIState();
                    UIStateChange(UIStateChanges.ModelPropertiesEdited);
                }
                else
                    MessageBox.Show(this, Properties.Resources.UI_MB_ResizeFailedMsg, Properties.Resources.UI_MB_ResizeFailedCaption,
                        MessageBoxButton.OK, MessageBoxImage.Error);
             }
            _ls.IsPaused = paused;
            LifeGrid.Cursor = oldCursor;
        }

        /// <summary>
        /// Menu_OnSettingsGridSizeShrink(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the Settings | Grid Size | Shrink to Model menu item. Calls
        /// the model to resize the grid to the model size. See LifeModel.ResizeModel() for
        /// failure conditions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnSettingsGridSizeShrink(Object sender, RoutedEventArgs e)
        {
            Cursor oldCursor = LifeGrid.Cursor;
            LifeGrid.Cursor = Cursors.Wait;

            bool paused = _ls.IsPaused;
            _ls.IsPaused = true;

            if (_ls.Model.ResizeModel(0, 0))
            {
                InitUIState();
                UIStateChange(UIStateChanges.ModelPropertiesEdited);
            }
            else
                MessageBox.Show(this, Properties.Resources.UI_MB_ResizeFailedMsg, Properties.Resources.UI_MB_ResizeFailedCaption,
                    MessageBoxButton.OK, MessageBoxImage.Error);

            _ls.IsPaused = paused;
            LifeGrid.Cursor = oldCursor;
        }

        /// <summary>
        /// Menu_OnSettingsGridSettings(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the grid settings menuitem in Settings | Grid Settings. Pops
        /// the grid settings dialog window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnSettingsGridSettings(Object sender, RoutedEventArgs e)
        {
            ALGridDlg dlg = new ALGridDlg();
            dlg.Owner = this;
            dlg.ShowDialog();
        }

        /// <summary>
        /// Menu_OnSettingsModelName(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the model name menuitem in Settings. Pops the model
        /// name dialog window. Tracks changes to the name of the model so it can
        /// update the window title bar after the dialog closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnSettingsModelName(Object sender, RoutedEventArgs e)
        {
            ALModelNameDlg dlg = new ALModelNameDlg();
            dlg.Owner = this;
            dlg.Tag = _ls;
            if ( dlg.ShowDialog() == true )
                UIStateChange(UIStateChanges.ModelPropertiesEdited);
        }

        /// <summary>
        /// Menu_OnHelpHowTo(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the help menu, How to Play command. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnHelpHowTo(Object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.HelpNavigator nav =
                System.Windows.Forms.HelpNavigator.TopicId;
           
            System.Windows.Forms.Help.ShowHelp(null, @"avalonlife.chm", nav, "1020");
        }

        /// <summary>
        /// Menu_OnHelpAbout(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the help menu, about AvalonLife command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnHelpAbout(Object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.HelpNavigator nav =
                System.Windows.Forms.HelpNavigator.TopicId;

            System.Windows.Forms.Help.ShowHelp(null, @"avalonlife.chm", nav, "1000");
        }

        /// <summary>
        /// Menu_OnHelpAboutLife(Object, RoutedEventArgs)
        /// 
        /// Handles a click on the help menu, about the Game of Life command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_OnHelpAboutLife(Object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.HelpNavigator nav =
                System.Windows.Forms.HelpNavigator.TopicId;

            System.Windows.Forms.Help.ShowHelp(null, @"avalonlife.chm", nav, "1010");
        }
        
        #endregion
        
        #region other ui event handlers

        /// <summary>
        /// ALMainWin_OnLoaded()
        /// 
        /// Handles the loaded event for the main window. Initializes the simulation
        /// model, controller, and display grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ALMainWin_OnLoaded(Object sender, RoutedEventArgs e)
        {
            ExecNew(true);
            RunSpeedSlider.ToolTip = Properties.Resources.UI_RunSpeedSlider_ToolTip;
            StatusGenCount.ToolTip = Properties.Resources.UI_StatusGenCount_ToolTip;
            CellBirthCount.ToolTip = Properties.Resources.UI_CellBirthCount_ToolTip;
            CellDeathCount.ToolTip = Properties.Resources.UI_CellDeathCount_ToolTip;
            PopulationCount.ToolTip = Properties.Resources.UI_PopulationCount_ToolTip;
            PeakPopulationCount.ToolTip = Properties.Resources.UI_PeakPopulationCount_ToolTip;
            MenuGridSizeText.ToolTip = Properties.Resources.UI_GridSize_ToolTip;
            
            _gridAdornerLayer = AdornerLayer.GetAdornerLayer(LifeGrid);
            ReticleAdorner ad = new ReticleAdorner(LifeGrid);
            _gridAdornerLayer.Add(ad);
            
            MenuSettingsReticle.IsChecked = ALSettings.Default.ReticleOn;
            if ( MenuSettingsReticle.IsChecked )
                ad.Visibility = Visibility.Visible;
            else    
                ad.Visibility = Visibility.Hidden;
            
            
            LifeGrid.Drop += new DragEventHandler( Grid_OnDrop );
            LifeGrid.MouseUp += new MouseButtonEventHandler( Grid_OnMouseUp );
            this.MouseLeave += new MouseEventHandler( Window_OnMouseLeave ); 
            this.Closing += new CancelEventHandler( ALMainWin_OnClosing );
            
            Application.Current.SessionEnding += new SessionEndingCancelEventHandler( ALMainWin_OnClosing );

            LifeGrid.Background = new SolidColorBrush(ALSettings.Default.GridBackground);
            LifeGrid.ShowGridLines = ALSettings.Default.GridOn;
            MenuSettingsGridLines.IsChecked = LifeGrid.ShowGridLines;
            
            MenuSettingsGridTorus.Tag = GridType.Torus;
            MenuSettingsGridXCyl.Tag = GridType.XCylinder;
            MenuSettingsGridYCyl.Tag = GridType.YCylinder;
            MenuSettingsGridFinite.Tag = GridType.Finite;
            
            MenuSettingsGrid40x40.Tag = 40;
            MenuSettingsGrid50x50.Tag = 50;
            MenuSettingsGrid60x60.Tag = 60;
            MenuSettingsGrid70x70.Tag = 70;

            if ( ALSettings.Default.HaltOnStability )
                MenuSettingsHaltStable.IsChecked = true;
            else
                MenuSettingsHaltStable.IsChecked = false;
        }
        
        /// <summary>
        /// ALMainWin_OnClosing(Object, CancelEventArgs)
        /// 
        /// This handles the closing event for the main window. If the game is not
        /// dirty or the user saves it using 'Ok' in CheckSave, then this handler
        /// will commit any settings changes and allow the close to continue. Other
        /// wise if the user clicks Cancel in CheckSave it will cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ALMainWin_OnClosing(Object sender, CancelEventArgs e )
        {
            bool paused = _ls.IsPaused;
            _ls.IsPaused = true;
            if ( CheckSave() == true )
            {
                if ( ALSettings.Default.Changed )
                    ALSettings.Default.Save();
            }
            else
            {
                e.Cancel = true;
            }
            _ls.IsPaused = paused;
        }

        /// <summary>
        /// RunButton_OnClick()
        /// 
        /// Handles the click event for the run button on the main window. The button
        /// changes state when it is clicked. The behavior of the sim drives off of
        /// the IsPaused property of _ls (LifeSim). When the sim is paused the UI allows
        /// editing of the grid cells.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RunButton_OnClick(Object sender, RoutedEventArgs e)
        {
            if ( _ls.IsPaused )
            {
                _ls.IsPaused = false;
                UIStateChange(UIStateChanges.ModelRun);
            }
            else
            {
                _ls.IsPaused = true;
                UIStateChange(UIStateChanges.ModelPaused);
            }
        }

        /// <summary>
        /// Rect_OnMouseDown(Object, MouseButtonEventArgs)
        /// 
        /// Handles the mouse down event on a Rectangle in the grid, and if the game is
        /// in the paused state (editable) flips the cell state. Since we allow dragging
        /// _lastMouseCell is used to avoid the effects of repeated MouseEnter events
        /// getting fired.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Rect_OnMouseDown(Object sender, MouseButtonEventArgs e)
        {
            if ( _ls.IsPaused && (_ls.Generation == 0) )
            {
                LifeCell lc = ((Rectangle)sender).DataContext as LifeCell;
                if ( lc != null )
                {
                    _startEdit = true;
                    _lastMouseCell = lc;
                    lc.IsAlive = !lc.IsAlive;
                    UIStateChange(UIStateChanges.ModelCellEdited);
                }
                else throw (new System.InvalidOperationException("Rect_OnMouseDown"));
            }
        }
        
        /// <summary>
        /// Rect_OnMouseEnter(Object, MouseEventArgs)
        /// 
        /// Handles the mouseover event for an Ellipse. If the game is paused and the mouse
        /// is entering a new cell, flip that cell's state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Rect_OnMouseEnter(Object sender, MouseEventArgs e)
        {
            if ( _startEdit )
            {
                LifeCell lc = ((Rectangle)sender).DataContext as LifeCell;
                if ( lc != null && lc != _lastMouseCell )
                {
                    _lastMouseCell = lc;
                    lc.IsAlive = !lc.IsAlive;    
                }
                else if ( lc == null )
                    throw (new System.InvalidOperationException("Rect_OnMouseEnter"));
            }
        }
        
        /// <summary>
        /// Grid_OnMouseUp(Object, MouseEventArgs)
        /// 
        /// Handles the mouse left button up event for the grid. We use it to check
        /// the grid state and enable/disable menu items accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Grid_OnMouseUp(Object sender, MouseButtonEventArgs e)
        {
            if ( _startEdit )
            {
                _startEdit = false;
                if ( _ls.Model.IsEmpty() )
                {
                    UIStateChange(UIStateChanges.ModelCreated);
                }
            }
        }

        /// <summary>
        /// Window_OnMouseLeave(Object, MouseEventArgs)
        /// 
        /// This function makes sure we handle things correctly if the user drags
        /// the mouse out of the window while drawing cells. Ordinarily you would
        /// capture the mouse and not release it until mouse up, but that's
        /// cumbersome here, because we're getting events at the rectangle level
        /// but can't capture the mouse there. If we capture it at the grid the
        /// rectangles stop getting events. So this is the next best alternative.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_OnMouseLeave(Object sender, MouseEventArgs e)
        {
            if ( _startEdit )
            {
                _startEdit = false;
                if (_ls.Model.IsEmpty())
                {
                    UIStateChange(UIStateChanges.ModelCreated);
                }
            }    
        }
        
        /// <summary>
        /// Grid_OnDrop(Object, DragEventArgs)
        /// 
        /// This function gets called when an object is dropped on the grid. It handles drops
        /// of .cells data from the Life Lexicon website, as well as .avl and .cells saved files.
        /// The first half of the function detects a drop of a link from the Lexicon, and calls
        /// ExecLoadWeb to get the data from the net. The second half detects file drops, and hands
        /// off to ExecFileLoad. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Grid_OnDrop(Object sender, DragEventArgs e)
        {
            Cursor old = this.Cursor;
            bool force = this.ForceCursor;
            this.ForceCursor = true;
            this.Cursor = Cursors.Wait;
            
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                if ( (e.AllowedEffects & DragDropEffects.Link) == DragDropEffects.Link )
                {    
                    string url = e.Data.GetData(DataFormats.Text) as string;
                    if ( Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute) )
                    {
                        ExecLoadWeb( url );
                    }
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop) )
            {
                string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
                ExecLoadFile(files[files.Length - 1]);
            }
            this.Cursor = old;
            this.ForceCursor = force;
        }

        /// <summary>
        /// SimStatusCallback()
        /// 
        /// This function handles a callback from the simulation controller when it detects
        /// that model evolution has halted. Will only be called if ALSettings.HaltOnStability
        /// is true.
        /// </summary>
        /// <returns></returns>
        public void SimStatusCallback()
        {
            string msg = null;
            
            if ( _ls.Model.EvolutionHalted )
            {
                msg = Properties.Resources.UI_SimStatus_HaltMsg;
                msg += " " + _ls.Generation.ToString();
                msg += "\n\nCell births: " + _ls.Model.CellBirths.ToString();
                msg += "\nCell deaths: " + _ls.Model.CellDeaths.ToString();
                msg += "\nPopulation: " + _ls.Model.Population.ToString();
                msg += "\nPeak population: " + _ls.Model.PeakPopulation.ToString();
                msg += "\n\nThe simulation has been halted.";
                
                MessageBox.Show(this, msg, "Simulation Status", MessageBoxButton.OK, MessageBoxImage.Information);
                
                UIStateChange(UIStateChanges.ModelHalted);
            }
        }
        
        #endregion
        
        #region ALMainWin private methods

        /// <summary>
        /// UIStateChange(UIStateChanges)
        /// 
        /// This function wraps up all the UI state changes that the program goes through.
        /// The possible states are defined in the AvalonLIfe.UIStateChanges enum. Each
        /// case of the switch statement handles setting the UI controls and some variables
        /// to appropriate settings for a given state.
        /// </summary>
        /// <param name="uis"></param>
        private void UIStateChange(UIStateChanges uis)
        {
            switch (uis)
            {
                case UIStateChanges.ModelCreated:
                    RunButton.Content = Properties.Resources.UI_RunButton_Content1;
                    RunButton.ToolTip = Properties.Resources.UI_RunButton_ToolTip1;
                    LifeGrid.ToolTip = Properties.Resources.UI_LifeGrid_ToolTip;
                    LifeGrid.Cursor = Cursors.Hand;
                    RunButton.IsEnabled = false;
                    MenuGameSave.IsEnabled = false;
                    MenuGameSaveAs.IsEnabled = false;
                    MenuGameReset.IsEnabled = false;
                    SetGameDirty(false);
                    _currentModelFileBase = null;
                    break;

                case UIStateChanges.ModelSaved:
                case UIStateChanges.ModelSavedAs:
                    MenuGameSave.IsEnabled = false;
                    SetGameDirty(false);
                    break;

                case UIStateChanges.ModelLoadedFromFile:
                    RunButton.Content = Properties.Resources.UI_RunButton_Content1;
                    RunButton.ToolTip = Properties.Resources.UI_RunButton_ToolTip1;
                    RunButton.IsEnabled = true;
                    LifeGrid.ToolTip = Properties.Resources.UI_LifeGrid_ToolTip;
                    LifeGrid.Cursor = Cursors.Hand;
                    MenuGameSave.IsEnabled = false;
                    MenuGameSaveAs.IsEnabled = true;
                    SetGameDirty(false);
                    break;

                case UIStateChanges.ModelLoadedFromNet:
                    RunButton.Content = Properties.Resources.UI_RunButton_Content1;
                    RunButton.ToolTip = Properties.Resources.UI_RunButton_ToolTip1;
                    RunButton.IsEnabled = true;
                    LifeGrid.ToolTip = Properties.Resources.UI_LifeGrid_ToolTip;
                    LifeGrid.Cursor = Cursors.Hand;
                    MenuGameSave.IsEnabled = true;
                    MenuGameSaveAs.IsEnabled = true;
                    SetGameDirty(true);
                    break;

                case UIStateChanges.ModelCellEdited:
                    RunButton.IsEnabled = true;
                    MenuGameSave.IsEnabled = true;
                    MenuGameSaveAs.IsEnabled = true;
                    SetGameDirty(true);
                    break;

                case UIStateChanges.ModelRun:
                    RunButton.Content = Properties.Resources.UI_RunButton_Content2;
                    RunButton.ToolTip = Properties.Resources.UI_RunButton_ToolTip2;
                    LifeGrid.Cursor = Cursors.Arrow;
                    LifeGrid.ToolTip = null;
                    MenuGameReset.IsEnabled = true;
                    break;

                case UIStateChanges.ModelPaused:
                    RunButton.Content = Properties.Resources.UI_RunButton_Content1;
                    RunButton.ToolTip = Properties.Resources.UI_RunButton_ToolTip1;
                    break;

                case UIStateChanges.ModelHalted:
                    RunButton.Content = Properties.Resources.UI_RunButton_Content1;
                    RunButton.ToolTip = Properties.Resources.UI_RunButton_ToolTip1;
                    RunButton.IsEnabled = false;
                    break;

                case UIStateChanges.ModelReset:
                    RunButton.Content = Properties.Resources.UI_RunButton_Content1;
                    RunButton.ToolTip = Properties.Resources.UI_RunButton_ToolTip1;
                    RunButton.IsEnabled = true;
                    LifeGrid.ToolTip = Properties.Resources.UI_LifeGrid_ToolTip;
                    LifeGrid.Cursor = Cursors.Hand;
                    MenuGameReset.IsEnabled = false;
                    break;

                case UIStateChanges.ModelPropertiesEdited:
                    MenuGameSave.IsEnabled = true;
                    SetGameDirty(true);
                    break;
            }
        }

        /// <summary>
        /// UpdateWrapInidicators(bool, bool, bool, bool)
        /// 
        /// This method is called from SetGridType() to enable/disable the wrap indicator
        /// bars that border the grid.
        /// </summary>
        /// <param name="left">True if the left bar is on, else false</param>
        /// <param name="top">True if the top bar is on, else false</param>
        /// <param name="right">True if the right bar is on, else false</param>
        /// <param name="bottom">True if the bottom bar is on, else false</param>
        private void UpdateWrapIndicators( bool left, bool top, bool right, bool bottom )
        {
            if ( left )
                LeftWrapIndicator.Width = 4;
            else
                LeftWrapIndicator.Width = 0;

            if (top)
                TopWrapIndicator.Height = 5;
            else
                TopWrapIndicator.Height = 0;

            if (right)
                RightWrapIndicator.Width = 4;
            else
                RightWrapIndicator.Width = 0;

            if (bottom)
                BottomWrapIndicator.Height = 5;
            else
                BottomWrapIndicator.Height = 0;
        }
        
        /// <summary>
        /// SetGridType( GridType )
        /// 
        /// This method is called from ExecLoad or Menu_OnGridXXX to update the menu and UI to
        /// correspond with the grid type of the loaded model. 
        /// </summary>
        /// <param name="gridType"></param>
        private void SetGridType( GridType gridType )
        {
            MenuSettingsGridTorus.IsChecked = false;
            MenuSettingsGridXCyl.IsChecked = false;
            MenuSettingsGridYCyl.IsChecked = false;
            MenuSettingsGridFinite.IsChecked = false;
            
            switch ( gridType )
            {
                case GridType.Torus:
                    MenuSettingsGridTorus.IsChecked = true;
                    UpdateWrapIndicators(false, false, false, false);
                    break;

                case GridType.XCylinder:
                    MenuSettingsGridXCyl.IsChecked = true;
                    UpdateWrapIndicators(false, true, false, true);
                    break;

                case GridType.YCylinder:
                    MenuSettingsGridYCyl.IsChecked = true;
                    UpdateWrapIndicators(true, false, true, false);
                    break;

                case GridType.Finite:
                    MenuSettingsGridFinite.IsChecked = true;
                    UpdateWrapIndicators(true, true, true, true);
                    break;
            }
        }
        
        /// <summary>
        /// SetWindowTitle()
        /// 
        /// Called from one or two spots to set the proper window title.
        /// </summary>
        private void SetWindowTitle()
        {
            this.Title = _winTitleBase;
            if (_ls.Model.ModelName != null && _ls.Model.ModelName.Length > 0)
                this.Title += " [" + _ls.Model.ModelName;
            else
                this.Title += " [Untitled";

            if (_gameIsDirty)
                this.Title += "*";
                
            this.Title += "]";
        }

        /// <summary>
        /// SetGameDirty(bool)
        /// 
        /// Called from various places where the current game becomes "dirty", or in need
        /// of saving to disk. Called with true if the game has become dirty. Updates
        /// the _gameIsDirty flag and window title on a state change.
        /// </summary>
        /// <param name="dirty"></param>
        private void SetGameDirty( bool dirty )
        {
            _gameIsDirty = dirty;
            SetWindowTitle();
        }
        
        /// <summary>
        /// SetGridSizeMenu()
        /// 
        /// Called from InitUIState to update the state of the grid size menu
        /// to reflect the size of a model.
        /// </summary>
        private void SetGridSizeMenu()
        {
            MenuSettingsGrid40x40.IsChecked = false;
            MenuSettingsGrid50x50.IsChecked = false;
            MenuSettingsGrid60x60.IsChecked = false;
            MenuSettingsGrid70x70.IsChecked = false;
            MenuSettingsGridCustom.IsChecked = false;

            if ((_ls.Model.Columns != _ls.Model.Rows) ||
                (_ls.Model.Columns != 40 && _ls.Model.Columns != 50 && 
                 _ls.Model.Columns != 60 && _ls.Model.Columns != 70))
            {
                MenuSettingsGridCustom.IsChecked = true;
            }
            else
            {
                switch (_ls.Model.Rows)
                {
                    case 40:
                        MenuSettingsGrid40x40.IsChecked = true;
                        break;
                    case 50:
                        MenuSettingsGrid50x50.IsChecked = true;
                        break;
                    case 60:
                        MenuSettingsGrid60x60.IsChecked = true;
                        break;
                    case 70:
                        MenuSettingsGrid70x70.IsChecked = true;
                        break;
                }
            }
            MenuGridSizeText.Text = "r:" + _ls.Model.Rows.ToString() + " c:" + _ls.Model.Columns.ToString();
        }
        
        /// <summary>
        /// InitUIState()
        /// 
        /// This function peforms common setup work when a game is created or loaded.
        /// Initializes the grid and populates it, sets up some data contexts, and sets
        /// the window title.
        /// </summary>
        private void InitUIState()
        {
            InitGrid();
            PopulateGrid();
            ApplyRectStyle();
            SetGridSizeMenu();
            SetWindowTitle();
            SetGridType(_ls.Model.LifeGridType);
            
            StatusGenCount.DataContext = _ls;
            RunSpeedSlider.DataContext = _ls;
            CellBirthCount.DataContext = _ls.Model;
            CellDeathCount.DataContext = _ls.Model;
            PopulationCount.DataContext = _ls.Model;
            PeakPopulationCount.DataContext = _ls.Model;
        }

        /// <summary>
        /// ExecNew()
        /// 
        /// Does the grunt work of initializing a new game with an empty grid. Initializes
        /// the model and controller, populates the grid, and wires up some UI fields by setting
        /// data contexts for items with property bindings.
        /// </summary>
        private bool ExecNew(bool defaults)
        {
            bool result = false;
            
            if ( CheckSave() == true )
            {
                if ( !defaults)
                {
                    ALModelSizeDlg dlg = new ALModelSizeDlg();
                    dlg.Owner = this;
                    dlg.Tag = _ls.Model;
                    if ( dlg.ShowDialog() == true )
                    {
                        int rows = dlg.Rows;
                        int cols = dlg.Columns;
                        if ( rows * cols > 10000 )
                        {
                            string msg = PrepMessage(Properties.Resources.UI_MB_LargeModelMsg, 80);
                            msg += "\n\nRequested model size will cause the program to create approximately " 
                                + Convert.ToString((rows * cols) * 3) + " objects.";
                            if ( MessageBox.Show(this, msg, Properties.Resources.UI_MB_LargeModelCaption, 
                                MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel )
                            {    
                                return result;
                            }
                        }
                        if (_ls == null)
                        {
                            _ls = new LifeSim(rows, cols);
                            _ls.UICallback = SimStatusCallback;
                        }
                        else
                            _ls.NewModel(rows, cols);
                    }
                    else return result;
                }
                else
                {
                    if (_ls == null)
                    {
                        _ls = new LifeSim();
                        _ls.UICallback = SimStatusCallback;
                    }
                    else
                        _ls.NewModel();
                }
                InitUIState();
                UIStateChange(UIStateChanges.ModelCreated);
                result = true;
            }
            return result;
        }
        
        /// <summary>
        /// ExecLoadWeb(string)
        /// 
        /// This function handles loading a stream of cells from the Life Lexicon website.
        /// Most of the work is actually done in LifeModel.LifeModel(Stream), which is called
        /// from LifeSim.NewModel(Stream).
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool ExecLoadWeb( string url )
        {
           bool result = false;
           if (CheckSave() == true)
           {
               Uri uri = new Uri(url);

               char[] sep = { '.' };
               string[] splitstr = uri.LocalPath.Split(sep);
               if (string.Compare("cells", splitstr[splitstr.Length - 1], true) == 0)
               {
                   HttpWebRequest cellReq = (HttpWebRequest)HttpWebRequest.Create(uri);
                   cellReq.Timeout = 10000;
                   cellReq.UserAgent = "AvalonLife_1_0";
                   try
                   {
                       HttpWebResponse cellRes = (HttpWebResponse)cellReq.GetResponse();
                       if ( _ls.NewModel(cellRes.GetResponseStream()) )
                       {
                           InitUIState();
                           UIStateChange(UIStateChanges.ModelLoadedFromNet);
                           _currentModelFileType = ALFileType.None;
                           result = true;
                       }
                       else
                           MessageBox.Show(this, "Failed to load model data.", "Load Error",
                              MessageBoxButton.OK, MessageBoxImage.Error);

                       cellRes.Close();
                   }
                   catch (WebException wex)
                   {
                       string msg = "Failed to retrieve cell data. Response: ";
                       msg += wex.Response;
                       MessageBox.Show(this, msg, "Network Error",
                           MessageBoxButton.OK, MessageBoxImage.Error);
                   }
               }
               else
               {
                   string msg = "Invalid data type: " + url;
                   MessageBox.Show(this, msg, "Invalid Data",
                       MessageBoxButton.OK, MessageBoxImage.Error);
               }
           }
           return result;
        }
       
        /// <summary>
        /// ExecLoadFile(string)
        /// 
        /// Does the work of loading a game from a file. Handles saved .avl files as
        /// well as .cells files saved from Life Lexicon data.
        /// </summary>
        /// <returns></returns>
        private bool ExecLoadFile(string fileName)
        {
            bool result = false;

            if (CheckSave() == true)
            {
                ALFileType ft = GetFileType(fileName);
                if ( ft == ALFileType.AVL )
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Stream str = File.OpenRead(fileName);
                    try
                    {
                        _ls = formatter.Deserialize(str) as LifeSim;
                        _ls.UICallback = SimStatusCallback;
                        SetFileType(fileName);
                        InitUIState();
                        UIStateChange(UIStateChanges.ModelLoadedFromFile);
                        result = true;
                    }
                    catch (System.Runtime.Serialization.SerializationException ex)
                    {
                        MessageBox.Show(this, Properties.Resources.UI_MB_LoadFailedMsg + " " + ex.Message,
                             Properties.Resources.UI_MB_LoadFailedCaption,
                             MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        str.Close();
                    }
                    SetGameDirty(false);
                }
                else if ( ft == ALFileType.Cells )
                {
                    Stream str = File.OpenRead(fileName);
                    if ( _ls.NewModel(str) )
                    {
                        SetFileType(fileName);
                        InitUIState();
                        UIStateChange(UIStateChanges.ModelLoadedFromFile);
                        result = true;
                    }
                    else
                        MessageBox.Show(this, "Failed to load model data.", "Load Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    str.Close();
                }
                else
                {
                    string msg = "Invalid file type: " + fileName;
                    MessageBox.Show(this, msg, "Invalid File",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }                      
            return result;
        }
        
        /// <summary>
        /// ExecSave()
        /// 
        /// Called from the menu savegame handler, or from the load game handler
        /// if necessary. Saves the current model to disk.
        /// </summary>
        private void ExecSave( bool saveAs )
        {
            System.Windows.Forms.SaveFileDialog savedlg =
                new System.Windows.Forms.SaveFileDialog();

            savedlg.AddExtension = true;
            savedlg.Filter = "AvalonLife Saved Games (.avl)|*.avl|Life Lexicon Cells (.cells)|*.cells";
            bool haveFile = false;

            if (_currentModelFileBase != null && _currentModelFileType != ALFileType.None)
            {
                haveFile = true;
                savedlg.FileName = _currentModelFileBase;
                if ( _currentModelFileType == ALFileType.Cells )
                {
                    savedlg.DefaultExt = ".cells";
                    savedlg.FilterIndex = 2;
                }
                else if ( _currentModelFileType == ALFileType.AVL )
                {    
                    savedlg.DefaultExt = ".avl";
                    savedlg.FilterIndex = 1;
                }
            }
            else
            {
                savedlg.FileName = "AvalonLife Saved Game";
                savedlg.DefaultExt = ".avl";
                savedlg.FilterIndex = 1;
            }
                
            if ( saveAs == true )
                savedlg.Title = "Save Model As";
            else
                savedlg.Title = "Save Model";

            if (savedlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                ALFileType ft = GetFileType(savedlg.FileName);
                
                if ( ft == ALFileType.AVL )
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Stream str = File.OpenWrite(savedlg.FileName);
                    try
                    {
                        formatter.Serialize(str, _ls);
                        if ( !saveAs || !haveFile )
                            SetFileType(savedlg.FileName);
                        UIStateChange(UIStateChanges.ModelSaved);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(this, Properties.Resources.UI_MB_SaveFailedMsg + " " + ex.InnerException.Message,
                             Properties.Resources.UI_MB_SaveFailedCaption,
                             MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        str.Close();
                    }
                }
                else if ( ft == ALFileType.Cells )
                {
                    Stream str = File.OpenWrite(savedlg.FileName);
                    try
                    {
                        _ls.Model.StreamCells(str);
                        if (!saveAs || !haveFile)
                            SetFileType(savedlg.FileName);
                        UIStateChange(UIStateChanges.ModelSaved);
                    }
                    catch (System.Exception)
                    {
                    }
                    finally
                    {
                        str.Close();
                    }
                }
                else
                {
                    string msg = "Invalid file type: " + savedlg.FileName;
                    MessageBox.Show(this, msg, "Invalid File",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        
        /// <summary>
        /// CheckSave()
        /// 
        /// This utility function checks to see if the current game is dirty. If it is
        /// it asks the user whether they want to save the game before continuing with
        /// whatever operation called this function. Returns true if the operation is
        /// good to proceed, false if the user clicks cancel.
        /// </summary>
        /// <returns></returns>
        private bool CheckSave()
        {
            bool result = true;
            
            if (_gameIsDirty)
            {
                MessageBoxResult mbres = MessageBox.Show( this, Properties.Resources.UI_MB_PromptText3, Properties.Resources.UI_MB_CaptionText3,
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Question );
                if ( mbres == MessageBoxResult.Yes )
                    ExecSave(false);
                else if ( mbres == MessageBoxResult.No )
                    SetGameDirty(false);
                else if ( mbres == MessageBoxResult.Cancel )
                    result = false;
            }
            return result;
        }
        
        /// <summary>
        /// InitGrid()
        /// 
        /// Called from the OnLoaded event handler for the main window to initialize the
        /// UI display grid with the appropriate number of rows and columns based on the
        /// _lm.Rows and _lm.Columns properties. It then adds an ellipse to each cell and
        /// sets its style.
        /// </summary>
        private void InitGrid()
        {
            LifeGrid.Children.Clear();
            LifeGrid.RowDefinitions.Clear();
            LifeGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < _ls.Model.Rows; i++)
            {
                LifeGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < _ls.Model.Columns; i++)
            {
                LifeGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
        
        /// <summary>
        /// GetCellBrush()
        /// 
        /// Constructs a brush from the settings in the config file.
        /// </summary>
        /// <returns></returns>
        private Brush GetCellBrush()
        {
           CellBrushType brushType = ALSettings.Default.LifeCellBrushType;
           
           if ( brushType == CellBrushType.Radial )
           {
                RadialGradientBrush brush = new RadialGradientBrush();
                brush.GradientOrigin = new Point(0.5, 0.5);
                brush.RadiusX = 0.5; 
                brush.RadiusY = 0.5;
                
                brush.GradientStops.Add( new GradientStop(ALSettings.Default.CellBrushC1, ALSettings.Default.CellBrushC1Off) );
                brush.GradientStops.Add(new GradientStop(ALSettings.Default.CellBrushC2, ALSettings.Default.CellBrushC2Off));
                brush.GradientStops.Add(new GradientStop(ALSettings.Default.CellBrushC3, ALSettings.Default.CellBrushC3Off));
                
                brush.Freeze();
                
                return brush;
           }
           else if ( brushType == CellBrushType.Linear )
           {
               LinearGradientBrush brush = new LinearGradientBrush();
               brush.StartPoint = new Point(0, 0);
               brush.EndPoint = new Point(1, 1);

               brush.GradientStops.Add(new GradientStop(ALSettings.Default.CellBrushC1, ALSettings.Default.CellBrushC1Off));
               brush.GradientStops.Add(new GradientStop(ALSettings.Default.CellBrushC2, ALSettings.Default.CellBrushC2Off));
               brush.GradientStops.Add(new GradientStop(ALSettings.Default.CellBrushC3, ALSettings.Default.CellBrushC3Off));

               brush.Freeze();

               return brush;
           }
           else if ( brushType == CellBrushType.Solid )
           {
               SolidColorBrush brush = new SolidColorBrush(ALSettings.Default.CellBrushC1);
               brush.Freeze();

               return brush;
           }
           else
           {    
               SolidColorBrush brush = new SolidColorBrush(Colors.Red);
               brush.Freeze();

               return brush;
           }
        }
        
        /// <summary>
        /// ApplyRectStyle()
        /// 
        /// If you look at the source you'll see that this function is only called when a new
        /// grid is being initialized, and when the cell brush has been changed. It builds a new
        /// style that sets the Fill property of a rectangle to the new brush, and then goes
        /// through the children of the grid setting this style. The style is based on an
        /// existing style that binds the opacity property to govern visibility. So why go to
        /// all this trouble to change fill brushes? Why not just set the fill property on the
        /// rects and be done with it? Here's the issue: again, opacity is controlled by a
        /// binding in a style. Element properties override style settings, and they happen at
        /// different times too. If in the process of creating a new grid I set the rectangle
        /// DataContext to point to a LifeCell, which will drive the opacity binding, and then
        /// set the Fill property directly, sometimes, depending on timing, I get a repaint
        /// before the opacity property is correctly set, and the grid renders all the cells
        /// visible. It looks messy, and I don't want the grid repainted until the state of all
        /// the cells is correct. I'm sure there must be other ways to handle suppressing the
        /// repaint, but the issue there is that the flash happens after I return control to
        /// the message pump. If I somehow surpress the repaint when will I unsurpress it? The
        /// best way around this that I have found so far is to do as I have below: change
        /// brushes by building a new style and then applying that style.
        /// </summary>
        private void ApplyRectStyle()
        {
            Brush cellBrush = GetCellBrush();

            Style style = new Style(typeof(Rectangle), (Style)LifeGrid.FindResource(typeof(Rectangle)));
            Setter setter = new Setter();
            setter.Property = Rectangle.FillProperty;
            setter.Value = cellBrush;
            style.Setters.Add(setter);
            LifeGrid.Resources.Remove("RectStyle");
            LifeGrid.Resources.Add("RectStyle", style);

            UIElementCollection rects = LifeGrid.Children;

            foreach (UIElement uie in rects)
                ((Rectangle)uie).Style = (Style)(LifeGrid.Resources["RectStyle"]);
        }
        
        /// <summary>
        /// PopulateGrid()
        /// 
        /// Does the work of setting up the rectangles in the cells of the life grid. Creates
        /// the rectangles and assigns them to the grid, adds them to the child collection,
        /// sets up rectangle data contexts for the rect->cell link, sets the rectangle style,
        /// and wires up the rectangle mouse events
        /// </summary>
        private void PopulateGrid()
        {
            for (int row = 0; row < _ls.Model.Rows; row++)
            {
                for (int col = 0; col < _ls.Model.Columns; col++)
                {
                    Rectangle rect = new Rectangle();
                    Grid.SetRow(rect, row);
                    Grid.SetColumn(rect, col);
                    LifeGrid.Children.Add(rect);
                    rect.DataContext = _ls.Model.CellGrid[row, col];
                    rect.MouseDown += new MouseButtonEventHandler(Rect_OnMouseDown);
                    rect.MouseMove += new MouseEventHandler(Rect_OnMouseEnter);
                }
            }
        }

        /// <summary>
        /// GetFileType(string)
        /// 
        /// Called from ExecSave to determine the type of file that the user selected.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private ALFileType GetFileType( string fileName )
        {
            string ext = System.IO.Path.GetExtension(fileName);
            ALFileType ft = ALFileType.None;
            
            if (string.Compare(".avl", ext, true) == 0)
                ft = ALFileType.AVL;
            else if (string.Compare(".cells", ext, true) == 0)
                ft = ALFileType.Cells;

            return ft;
        }
        
        /// <summary>
        /// SetFileType( string )
        /// 
        /// Called from the ExecSave and ExecLoad functions. Retrieves and stores
        /// the base filename and sets the file format type.
        /// </summary>
        /// <param name="fileName"></param>
        private ALFileType SetFileType( string fileName )
        {
            _currentModelFileBase = System.IO.Path.GetFileNameWithoutExtension(fileName);
            string ext = System.IO.Path.GetExtension(fileName);
            
            if ( string.Compare(".avl", ext, true) == 0 )
                _currentModelFileType = ALFileType.AVL;
            else if ( string.Compare(".cells", ext, true) == 0 )
                _currentModelFileType = ALFileType.Cells;
            else 
                _currentModelFileType = ALFileType.None;
        
            return _currentModelFileType;
        }
        
        #endregion
        
        /// <summary>
        /// Holds the instance of the simulation controller
        /// </summary>
        private LifeSim _ls = null;
        
        /// <summary>
        /// True if the game has been modified since last save
        /// </summary>
        private bool _gameIsDirty = false;
        
        /// <summary>
        /// Tracks the last cell that the mouse was in
        /// </summary>
        private LifeCell _lastMouseCell = null;
        
        /// <summary>
        /// Container for the ReticleAdorner
        /// </summary>
        private AdornerLayer _gridAdornerLayer = null;
        
        /// <summary>
        /// True if we are dragging across cells in edit mode
        /// </summary>
        private bool _startEdit = false;
        
        /// <summary>
        /// If not null contains the last file name used to load or
        /// save the current model.
        /// </summary>
        private string _currentModelFileBase = null;
        
        private ALFileType _currentModelFileType = ALFileType.AVL;
        
        /// <summary>
        /// Self-explanatory
        /// </summary>
        private string _winTitleBase = "AvalonLife 1.0";
        
    }
}