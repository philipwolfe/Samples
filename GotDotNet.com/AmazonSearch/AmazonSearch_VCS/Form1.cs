#region Using directives

using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Web.Services.Protocols;
// Namespace for Amazon Web service proxy class.
using WSFun.Amazon;

#endregion

namespace WSFun
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Call Amazon search Web service.
        private void PerformKeyWordSearch()
        {
            try
            {
                KeywordRequest keywordReq = new KeywordRequest();
                keywordReq.locale = "us";
                keywordReq.type = "lite";
                keywordReq.sort = "reviewrank";
                keywordReq.mode = this.SearchMode;
                keywordReq.keyword = this.searchText.Text;
                keywordReq.tag = this.SubscriberID;
                keywordReq.devtag = this.SubscriberID;

                AmazonSearchService amazonWS = new AmazonSearchService();
                ProductInfo productInfo = amazonWS.KeywordSearchRequest(keywordReq);

                if (productInfo.Details.Length > 0)
                {
                    this.searchResults.Items.AddRange(productInfo.Details);
                }
                else
                    MessageBox.Show("No items found.");
            }
            catch (SoapException sx)
            {
                MessageBox.Show(sx.Message, "SOAP Error");
            }
        }

        // Amazon subscriber identification.
        private string SubscriberID
        {
            get
            {
                if (_subscriberID.Length == 0)
                {
                    // Retrieve Amazon subscriber id from configuration file.
                    _subscriberID = ConfigurationSettings.AppSettings.Get("AmazonSubscriberID").ToString();
                }
                return _subscriberID;
           }
        }

        // Clear values in form controls.
        private void CleanUpForm()
        {
            this.searchResults.Items.Clear();
            if (this.itemPicture.Image != null)
                this.itemPicture.Image = null;
            this.listPriceLabel.Text = String.Empty;
            this.usedPriceLabel.Text = String.Empty;
            this.availabilityLabel.Text = String.Empty;
            this.Refresh();
        }

        // Handle Go button click event.
        private void goButton_Click(object sender, EventArgs e)
        {
            CleanUpForm();
            PerformKeyWordSearch();
        }

        // Handles event when user selects category to search.
        private void modeChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton tempOption = (RadioButton)sender;
                this.SearchMode = tempOption.Tag.ToString();
            }
        }

        // Handles event when user selects item from results list box to display
        // associated Details data.
        private void searchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
             Details tempDetails = (Details)this.searchResults.SelectedItem;
             this.itemPicture.Image = tempDetails.ItemImage;
             this.listPriceLabel.Text = "Amazon price: " + tempDetails.OurPrice;
             this.usedPriceLabel.Text = "Used price: " + tempDetails.UsedPrice;
             this.availabilityLabel.Text = tempDetails.Availability;
         }

         // Private members
         private string _subscriberID = String.Empty;
         private string SearchMode = "books";
     }
}