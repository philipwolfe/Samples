/* ****************************************************************************
 * AvalonLife 1.0
 * 
 * ALModelNameDlg.xaml.cs
 * 
 * Implements the code-beside for the model name edit dialog.
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

    public partial class ALModelNameDlg : System.Windows.Window, INotifyPropertyChanged
    {

        public ALModelNameDlg()
        {
            InitializeComponent();
        }

        public void On_ModelNameDlgLoaded(Object sender, EventArgs e)
        {
            ModelNameEdit.Text = ((LifeSim)this.Tag).Model.ModelName;
            ModelNameEdit.TextChanged += new TextChangedEventHandler(On_ModelNameEditChanged); 
            ModelNameDlgOKButton.DataContext = this;
        }

        public void On_ModelNameEditChanged(Object sender, RoutedEventArgs e)
        {
            Changed = true;
        }
        
        public void On_ModelNameDlgOKButton(Object sender, RoutedEventArgs e)
        {
            ((LifeSim)this.Tag).Model.ModelName = ModelNameEdit.Text;

            this.DialogResult = true;
            this.Close();
        }

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