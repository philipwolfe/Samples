using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net.Cache;
using System.Net;
using System.IO;

namespace ControllingCaching
{
    public partial class Form1 : Form
    {
        // Fill the strings for display on the form.  Text taken from the MSDN documentation.
        string[] policyDescriptions = 
        {
            "Satisfies a request by using the server. No entries are taken from caches, added to caches, or removed from caches between the client and server. This is the default cache behavior specified in the machine configuration file that ships with the .NET Framework.",
            "Satisfies a request for a resource from the cache if the resource is available; otherwise, sends a request for a resource to the server. If the requested item is available in any cache between the client and the server, the request might be satisfied by the intermediate cache.",
            "Satisfies a request using the locally cached resource; does not send a request for an item that is not in the cache. When this cache policy level is specified, a WebException exception is thrown if the item is not in the client cache.",
            "Satisfies a request for a resource either from the local computer's cache or a remote cache on the local area network. If the request cannot be satisfied, a WebException exception is thrown. In the HTTP caching protocol, this is achieved using the only-if-cached cache control directive.",
            "Satisfies a request for a resource either by using the cached copy of the resource or by sending a request for the resource to the server. The action taken is determined by the current cache policy and the age of the content in the cache.  This is the cache level that should be used by most applications.",
            "Never satisfies a request by using resources from the cache and does not cache resources. If the resource is present in the local cache, it is removed. This policy level indicates to intermediate caches that they should remove the resource. In the HTTP caching protocol, this is achieved using the no-cache cache control directive.",
            "Satisfies a request by using the server or a cache other than the local cache. Before the request can be satisfied by an intermediate cache, that cache must revalidate its cached entry with the server. In the HTTP caching protocol, this is achieved using the max-age = 0 cache control directive and the no-cache Pragma header.",
            "Satisfies a request by using the server. The response might be saved in the cache. In the HTTP caching protocol, this is achieved using the no-cache cache control directive and the no-cache Pragma header.",
            "Compares the copy of the resource in the cache with the copy on the server. If the copy on the server is newer, it is used to satisfy the request and replaces the copy in the cache. If the copy in the cache is the same as the server copy, the cached copy is used. In the HTTP caching protocol, this is achieved using a conditional request."
        };

        public Form1()
        {
            InitializeComponent();

            // Init the BypassCache policy (ships as default in .NET Framework)
            PolicyComboBox.SelectedIndex = 0;
        }

        private string ValidateURL(string url)
        {
            string str = url;
            //  Check for a valid URL
            if ((string.IsNullOrEmpty(str) || str.Equals("about:blank")))
            {
                throw new Exception("Invalid URL in TextBox");
            }
            //  Add Http as a convenience
            if (!str.StartsWith("http://"))
            {
                str = ("http://" + str);
            }
            return str;
        }

        private void PolicyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpRequestCachePolicy policy = null;
            switch (PolicyComboBox.SelectedIndex)
            {
                case 0:
                    //  BypassCache
                    //    Satisfies a request by using the server. No entries are taken from caches, 
                    //    added to caches, or removed from caches between the client and server. 
                    //    This is the default cache behavior specified in the machine configuration 
                    //    file that ships with the .NET Framework.
                    policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.BypassCache);
                    break;
                case 1:
                    //  CacheIfAvailable 
                    //    Satisfies a request for a resource from the cache if the resource is 
                    //    available; otherwise, sends a request for a resource to the server. 
                    //    If the requested item is available in any cache between the client and the server, 
                    //    the request might be satisfied by the intermediate cache.  
                    policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
                    break;
                case 2:
                    //  CacheOnly 
                    //    Satisfies a request using the locally cached resource; does not send a 
                    //    request for an item that is not in the cache. When this cache policy level is 
                    //    specified, a WebException exception is thrown if the item is not in the client cache.  
                    policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheOnly);
                    break;
                case 3:
                    //  CacheOrNextCacheOnly 
                    //    Satisfies a request for a resource either from the local computer's cache 
                    //    or a remote cache on the local area network. If the request cannot be satisfied, 
                    //    a WebException exception is thrown. In the HTTP caching protocol, this is 
                    //    achieved using the only-if-cached cache control directive.  
                    policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheOrNextCacheOnly);
                    break;
                case 4:
                    //  Default 
                    //    Satisfies a request for a resource either by using the cached copy of the 
                    //    resource or by sending a request for the resource to the server. The action 
                    //    taken is determined by the current cache policy and the age of the content in 
                    //    the cache.  This is the cache level that should be used by most applications.
                    policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
                    break;
                case 5:
                    //  NoCacheNoStore 
                    //    Never satisfies a request by using resources from the cache and does not cache 
                    //    resources. If the resource is present in the local cache, it is removed. This 
                    //    policy level indicates to intermediate caches that they should remove the resource. 
                    //    In the HTTP caching protocol, this is achieved using the no-cache cache control directive.  
                    policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                    break;
                case 6:
                    //  Refresh 
                    //    Satisfies a request by using the server or a cache other than the local cache. 
                    //    Before the request can be satisfied by an intermediate cache, that cache must 
                    //    revalidate its cached entry with the server. In the HTTP caching protocol, this is 
                    //    achieved using the max-age = 0 cache control directive and the no-cache Pragma header.  
                    policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Refresh);
                    break;
                case 7:
                    //  Reload 
                    //    Satisfies a request by using the server. The response might be saved in the cache. 
                    //    In the HTTP caching protocol, this is achieved using the no-cache cache control 
                    //    directive and the no-cache Pragma header.  
                    policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Reload);
                    break;
                case 8:
                    //  Revalidate 
                    //    Compares the copy of the resource in the cache with the copy on the server. 
                    //    If the copy on the server is newer, it is used to satisfy the request and replaces 
                    //    the copy in the cache. If the copy in the cache is the same as the server copy, the 
                    //    cached copy is used. In the HTTP caching protocol, this is achieved using a 
                    //    conditional request.
                    policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Revalidate);
                    break;
            }
            //  Set the policy for the Application Domain
            HttpWebRequest.DefaultCachePolicy = policy;

            //  Set Description
            PolicyDescTextBox.Text = policyDescriptions[PolicyComboBox.SelectedIndex];
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            try
            {
                //  Clear out text box
                RichTextBox1.Text = String.Empty;
                //  Show status
                StatusLabel.Text = "Finding URL...";
                Uri myURI = new Uri(ValidateURL(UrlTextBox.Text));
                //  Perform the webrequest
                WebRequest request = WebRequest.Create(myURI);
                //  Get the response
                WebResponse response = request.GetResponse();
                //  Alert user as to whether the reponse is cached or not
                StatusLabel.Text = ("IsFromCache? " + response.IsFromCache);
                StreamReader reader = new StreamReader(response.GetResponseStream());
                RichTextBox1.Text = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                StatusLabel.Text = "Error.";
            }
        }
    }
}