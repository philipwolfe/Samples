
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.ServiceModel;
using Microsoft.ServiceModel.Samples;
using System.Windows.Threading;

namespace AlbumClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        //Keep client for lifetime of Window
        private AlbumServiceClient client = new AlbumServiceClient();

        public Window1()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // Bind the data returned from the service to the myPanel UI element
            client.BeginGetAlbumList(GetAlbumListComplete, null);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Clean up client when Window closes
            // Closing the client gracefully closes the connection and cleans up resources
            client.Close();
        }


        private void OnAddNew(object sender, RoutedEventArgs e)
        {
            string value = newAlbumName.Text;
            client.BeginAddAlbum(value, AddAlbumComplete, null);

            // Bind the data returned from the service to the myPanel UI element
            myPanel.DataContext = client.BeginGetAlbumList(GetAlbumListComplete, null);
        }

        void AddAlbumComplete(IAsyncResult ar)
        {
            client.EndAddAlbum(ar);
            client.BeginGetAlbumList(GetAlbumListComplete, null);
        }

        // Show the result when call to web service completes
        void GetAlbumListComplete(IAsyncResult ar)
        {
            //This call back is not coming on the ui thread, so we must use the
            //Dispatcher to invoke on the ui thread
            Dispatcher.Invoke(DispatcherPriority.Normal, new AsyncCallback(BindResults), ar);
        }

        void BindResults(IAsyncResult ar)
        {
            myPanel.DataContext = client.GetAlbumList();
        }
    }


    public class TextLen2Bool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string text = (string)value;
            return (text.Length > 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

}