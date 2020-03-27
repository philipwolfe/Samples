#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Diagnostics;

#endregion

namespace Working_with_XML_in_Word
{
	// To learn how to add an ActionsPage control to a Word project see
	// http://msdn2.microsoft.com/en-us/library/kfzd656e.
	partial class RssNavActionsPane : UserControl
	{
		XPathNavigator feedXPathNav = null;
		XPathNodeIterator feedXPathNodeIter = null;
		DataTable itemsDataTable = null;
		int itemIndex = 0;

		public RssNavActionsPane()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Event handler for the Go button, which starts the
        /// RSS feed retrieval process.
		/// </summary>		
		private void GoButton_Click(object sender, EventArgs e)
		{
            if (uRLTextBox.Text.Length > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                GetAndProcessRSSFeed();
                Cursor.Current = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please enter an RSS URL");
            }
		}

		/// <summary>
		/// Main method for retrieving and processing the
        /// RSS XML based on the URL entered by the user.  After the
        /// XML is retrieved, all of the "item" elements are retrieved
        /// and iterated over, pushing the desired child nodes into a
        /// DataTable for easier navigation and display.
		/// </summary>		
		private void GetAndProcessRSSFeed()
		{
            try
            {
                // Get the RSS feed.
                XPathDocument feedXPathDoc = new XPathDocument(uRLTextBox.Text);

                // Select all "item" elements, each of which represent a blog entry.
                feedXPathNav = feedXPathDoc.CreateNavigator();
                feedXPathNodeIter = feedXPathNav.Select("//item");

                // Create a DataTable to store the processed node values.
                itemsDataTable = new DataTable();
                itemsDataTable.Columns.Add("pubDate");
                itemsDataTable.Columns.Add("title");
                itemsDataTable.Columns.Add("link");
                itemsDataTable.Columns.Add("description");
                itemsDataTable.AcceptChanges();
                int i = 0;
                itemIndex = 0;

                // Process the item element to store the desired child nodes in
                // the DataTable.  This involves an outer and inner
                // XPathNodeIterator: one for the collection of item elements,
                // and one for the collection of child elements for each item
                // element.  Start the outer iteration...
                while (feedXPathNodeIter.MoveNext())
                {
                    if (feedXPathNodeIter.Current.Name == "item")
                    {
                        // Add a new row for each item element.
                        DataRow newItemRow = itemsDataTable.NewRow();
                        itemsDataTable.Rows.Add(newItemRow);
                        i += 1;
                    }

                    // Create an iterator for each item's child nodes and
                    // start the inner iteration...
                    XPathNodeIterator itemXPathNodeIter =
                        feedXPathNodeIter.Current.SelectDescendants(
                        XPathNodeType.Element, false);

                    while (itemXPathNodeIter.MoveNext())
                    {
                        string rssElementName = itemXPathNodeIter.Current.Name;
                        string rssElementValue = itemXPathNodeIter.Current.Value;

                        // If the node name is one of the four we want to store, 
                        if (rssElementName == "pubDate" | rssElementName == "title"
                            | rssElementName == "link" | rssElementName == "description")
                        {
                            // Add the child node value to the appropriate column in the new DataRow.
                            itemsDataTable.Rows[i - 1][rssElementName] = rssElementValue;
                        }
                    }

                    // Initialize the blog entry navigation buttons, which are disabled by default.
                    UpdateButtonAndLabelState();
                    // Set the bookmark values for the first item.
                    SetBookmarks();
                }
            }
            catch (System.Net.WebException webEx)
            {
                MessageBox.Show("RSS feed not available. Please check the URL and try again.");
                return;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                MessageBox.Show("The URL you entered does not contain RSS XML. " +
                    "Please check the URL and try again.");
                return;
            }
            catch
            {
                MessageBox.Show("An error was encountered reading this feed.  " +
                    "Please check the URL and try again.");
                return;
            }
		}

		/// <summary>
		/// Event handler for the button that navigates to the previous blog entry.
		/// </summary>		
		private void PreviousEntryButton_Click(object sender, EventArgs e)
		{
			itemIndex -= 1;
			SetBookmarks();
			UpdateButtonAndLabelState();
		}

		/// <summary>
		/// Event handler for the button that navigates to the next blog entry.
		/// </summary>		
		private void NextEntryButton_Click(object sender, EventArgs e)
		{
			itemIndex += 1;
			SetBookmarks();
			UpdateButtonAndLabelState();
		}

		/// <summary>
		/// Set the Enable property for the blog entry navigation buttons
        /// and the entry count label based on the current index.
		/// </summary>		
		private void UpdateButtonAndLabelState()
		{
			if (itemIndex < itemsDataTable.Rows.Count-1)
			{
				nextEntryButton.Enabled = true;
			}
			else
			{
				nextEntryButton.Enabled = false;
			}

			if (itemIndex > 0)
			{
				previousEntryButton.Enabled = true;
			}
			else
			{	
				previousEntryButton.Enabled = false;
			}

			blogEntryCountLabel.Text = string.Format(
                "{0} of {1} entries", (itemIndex + 1).ToString(),
                itemsDataTable.Rows.Count.ToString());
		}

		/// <summary>
		/// Set the Word document's Bookmark controls to the corresponding
        /// blog entry node value in the DataTable.
		/// 
		/// To learn more about how to assign values from an Actions Pane
        /// to a Word document, see the following walkthrough:
        /// http://msdn2.microsoft.com/en-us/library/d6sb8dyb.
		/// </summary>
		private void SetBookmarks()
		{
			// Get the row in the DataTable corresponding to the current blog entry.
			DataRow itemDataRow = itemsDataTable.Rows[itemIndex];

			// Set the bookmark values. 
			Globals.ThisDocument.PubDateBookmark.Text = itemDataRow["pubDate"].ToString();
			Globals.ThisDocument.TitleBookmark.Text = itemDataRow["title"].ToString();
			Globals.ThisDocument.LinkBookmark.Text = itemDataRow["link"].ToString();
			Globals.ThisDocument.DescriptionBookmark.Text = itemDataRow["description"].ToString();
		}
	}
}
