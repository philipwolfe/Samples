using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomNavigationWindowChromeSample
{
    public partial class Page3 : Page, IProvideCustomContentState
    {
        // Journalable dependency property to remember datetime
        public static readonly DependencyProperty CreatedProperty;

        static Page3()
        {
            // Register the local property with the journalable dependency property
            Page3.CreatedProperty = DependencyProperty.Register("Created", typeof(DateTime), typeof(Page3), new FrameworkPropertyMetadata(DateTime.Now, FrameworkPropertyMetadataOptions.Journal));
        }

        public Page3()
        {
            InitializeComponent();

            this.timeTextBlock.Text = this.Created.ToLongTimeString();
        }

        // Property to register with the journalable dependency property
        public DateTime Created
        {
            get
            {
                return (DateTime)base.GetValue(Page3.CreatedProperty);
            }
            set
            {
                base.SetValue(Page3.CreatedProperty, value);
            }
        }

        #region IProvideCustomContentState Members

        public CustomContentState GetContentState()
        {
            return ContentImageCustomContentState.GetContentImageCustomContentState(this, (int)this.ActualWidth, (int)this.ActualHeight);
        }

        #endregion
    }
}