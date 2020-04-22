/* ****************************************************************************
 * AvalonLife 1.0
 * 
 * ALModelSizeDlg.xaml.cs
 * 
 * Implements the code-beside for the custom grid size dialog.
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
    /// Interaction logic for ALModelNameDlg.xaml
    /// </summary>

    public partial class ALModelSizeDlg : System.Windows.Window, INotifyPropertyChanged
    {

        public ALModelSizeDlg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On_ModelSizeDlgLoaded()
        /// 
        /// If the Resize property is true then this dialog was popped from the
        /// Menu | Grid Size | Custom menuitem, and it will take the default
        /// values form the current model. If Resize is false then it was popped
        /// from Game | New, and will get those defaults from the persistent
        /// settings. The OK button IsEnabled property is bound to the dialog's
        /// Changed property.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void On_ModelSizeDlgLoaded(Object sender, EventArgs e)
        {
            if ( _resize )
            {
                ModelSizeRows.Text = ((LifeModel)(this.Tag)).Rows.ToString();
                ModelSizeColumns.Text = ((LifeModel)(this.Tag)).Columns.ToString();
            }
            else
            {
                ModelSizeRows.Text = ALSettings.Default.GridHeight.ToString();
                ModelSizeColumns.Text = ALSettings.Default.GridWidth.ToString();
            }
            
            ModelSizeRows.TextChanged += new TextChangedEventHandler(On_ModelSizeEditChanged);
            ModelSizeColumns.TextChanged += new TextChangedEventHandler(On_ModelSizeEditChanged);
            
            ModelSizeDlgOKButton.DataContext = this;
        }

        /// <summary>
        /// This function just flips the Changed flag if the user touches the size edits.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void On_ModelSizeEditChanged(Object sender, RoutedEventArgs e)
        {
            Changed = true;
        }

        /// <summary>
        /// Just grabs the values from the edit, converts them, sticks them
        /// into the properties, and closes itsel. The exception wrapper is
        /// used to detect the user typing something that can't be converted.
        /// I know there's a way to do validation on the edits themselves,
        /// but I haven't looked into it yet. This method protects the model
        /// but isn't very informative.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void On_ModelSizeDlgOKButton(Object sender, RoutedEventArgs e)
        {
            bool result = false;
            try
            {
                int rows = Convert.ToInt32(ModelSizeRows.Text);
                int cols = Convert.ToInt32(ModelSizeColumns.Text);

                if (rows > 0 && cols > 0)
                {
                    _rows = rows;
                    _columns = cols;
                    result = true;
                }
            }
            catch (System.Exception)
            {
            }
            this.DialogResult = result;
            this.Close();
        }

        private int _rows = 0;
        public int Rows
        {
            get
            {
                return _rows;
            }
        }

        private int _columns = 0;
        public int Columns
        {
            get
            {
                return _columns;
            }
        }

        /// <summary>
        /// Bound to the OK button's IsEnabled property.
        /// </summary>
        private bool _changed = true;
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

        private bool _resize = false;
        public bool Resize
        {
            get
            {
                return _resize;
            }
            set
            {
                _resize = value;
            }
        }

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }
}