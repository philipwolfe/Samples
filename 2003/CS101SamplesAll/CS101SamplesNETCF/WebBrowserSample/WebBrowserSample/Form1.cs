using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WebBrowserSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Show an initial web page in the WebBrowser
            WebBrowser1.DocumentText = "<html><body><h1>WebBrowser</h1><br>Click Help Link or type URL to view information in browser.</body></html>";

            // Display the OK button for closing the application.
            MinimizeBox = false;
        }

        private void LoadUrl(String url)
        {
            // Check for a valid URL
            if ((String.IsNullOrEmpty(url)) || (url.Equals("about:blank")))
            {
                MessageBox.Show("Invalid URL in TextBox");
                return;
            }

            // Add Http as a convenience
            if (!(url.StartsWith("http://")))
            {
                url = "http://" + url;
            }

            // Navigate to the desired URL
            try
            {
                Cursor.Current = Cursors.WaitCursor; // Set Wait Cursor
                WebBrowser1.Navigate(new Uri(url)); // Navigate to the desired URL
            }
            catch (System.UriFormatException ex)
            {
                MessageBox.Show("Error: Invalid URL in TextBox. " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default; // Restore Default Cursor
            }
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            LoadUrl(URLTextBox.Text); // Get URL from TextBox
        }

        // Show local content.  Most any html content can be displayed in the Web Browser.  This is a sample of help file content.
        private void LocalContentLinkLabel_Click(object sender, EventArgs e)
        {
            // build local content html
            StringBuilder builder = new StringBuilder();
            builder.Append("<html><body>");
            builder.Append("<h1>Help File</h1>");
            builder.Append("<p>You can use a WebBrowser control to show local content such as this.<br>");
            builder.Append("<b>Splitter: </b>Use the splitter to modify browser height.<br>");
            builder.Append("<b>URL: </b>Enter a URL into the text box and click GO button to load online content into the WebBrowser.  You must have internet access on a physical device to view online content in this example");
            builder.Append("</body></html>");
            WebBrowser1.DocumentText = builder.ToString();
        }

        private void PocketPCLinkLabel_Click(object sender, EventArgs e)
        {
            LoadUrl(@"http://www.pocketpc.com");
        }

    }
}