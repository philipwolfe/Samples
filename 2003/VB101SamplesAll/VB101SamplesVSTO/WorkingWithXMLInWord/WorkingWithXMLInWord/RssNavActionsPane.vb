Imports System.Xml.XPath

Public Class RssNavActionsPane
    Dim feedXPathNav As XPathNavigator = Nothing
    Dim feedXPathNodeIter As XPathNodeIterator = Nothing
    Dim itemsDataTable As DataTable = Nothing
    Dim itemIndex As Integer = 0

    ''' <summary>
    ''' Event handler for the Go button, which starts
    ''' the RSS feed retrieval process.
    ''' </summary>	
    Private Sub goButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles goButton.Click
        If uRLTextBox.Text.Length > 0 Then
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
            GetAndProcessRSSFeed()
            System.Windows.Forms.Cursor.Current = Cursors.Default
        Else
            MessageBox.Show("Please enter an RSS URL")
        End If
    End Sub

    ''' <summary>
    ''' Main method for retrieving and processing the RSS XML based
    ''' on the URL entered by the user.  After the XML is retrieved, all of
    ''' the "item" elements are retrieved and iterated over, pushing the 
    ''' desired child nodes into a DataTable for easier navigation and display.
    ''' </summary>	
    Private Sub GetAndProcessRSSFeed()
        Try
            ' Get the RSS feed.
            Dim feedXPathDoc As XPathDocument = New XPathDocument(uRLTextBox.Text)

            ' Select all "item" elements, each of which represent a blog entry.
            feedXPathNav = feedXPathDoc.CreateNavigator()
            feedXPathNodeIter = feedXPathNav.Select("//item")

            ' Create a DataTable to store the processed node values.
            itemsDataTable = New DataTable()
            itemsDataTable.Columns.Add("pubDate")
            itemsDataTable.Columns.Add("title")
            itemsDataTable.Columns.Add("link")
            itemsDataTable.Columns.Add("description")
            itemsDataTable.AcceptChanges()
            Dim i As Integer = 0
            itemIndex = 0

            ' Process the item element to store the desired child nodes
            ' in the DataTable.  This involves an outer and inner
            ' XPathNodeIterator: one for the collection of item elements,
            ' and one for the collection of child elements for each item
            ' element.  Start the outer iteration...
            While feedXPathNodeIter.MoveNext()
                If feedXPathNodeIter.Current.Name = "item" Then
                    ' Add a new row for each item element.
                    Dim NewItemRow As DataRow = itemsDataTable.NewRow()
                    itemsDataTable.Rows.Add(NewItemRow)
                    i += 1
                End If

                ' Create an iterator for each item's child nodes and start the inner iteration...
                Dim itemXPathNodeIter As XPathNodeIterator = _
                feedXPathNodeIter.Current.SelectDescendants(XPathNodeType.Element, False)

                While itemXPathNodeIter.MoveNext()
                    Dim rssElementName As String = itemXPathNodeIter.Current.Name
                    Dim rssElementValue As String = itemXPathNodeIter.Current.Value

                    ' If the node name is one of the four we want to store, 
                    If rssElementName = "pubDate" Or rssElementName = "title" Or _
                    rssElementName = "link" Or rssElementName = "description" Then
                        ' Add the child node value to the appropriate column
                        ' in the new DataRow.
                        itemsDataTable.Rows(i - 1)(rssElementName) = rssElementValue
                    End If
                End While

                ' Initialize the blog entry navigation buttons, which are disabled by default.
                UpdateButtonAndLabelState()
                ' Set the bookmark values for the first item.
                SetBookmarks()
            End While
        Catch webEx As System.Net.WebException
            MessageBox.Show("RSS feed not available. Please check the URL and try again.")
            Return
        Catch xmlEx As System.Xml.XmlException
            MessageBox.Show("The URL you entered does not contain RSS XML. " & _
                "Please check the URL and try again.")
            Return
        Catch
            MessageBox.Show("An error was encountered reading this feed.  " & _
                "Please check the URL and try again.")
            Return
        End Try
    End Sub

    ''' <summary>
    ''' Event handler for the button that navigates to the previous blog entry.
    ''' </summary>	
    Private Sub previousEntryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles previousEntryButton.Click
        itemIndex -= 1
        SetBookmarks()
        UpdateButtonAndLabelState()
    End Sub

    ''' <summary>
    ''' Event handler for the button that navigates to the next blog entry.
    ''' </summary>		
    Private Sub nextEntryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nextEntryButton.Click
        itemIndex += 1
        SetBookmarks()
        UpdateButtonAndLabelState()
    End Sub

    ''' <summary>
    ''' Set the Enable property for the blog entry navigation buttons and the entry count label 
    ''' based on the current index.
    ''' </summary>
    Private Sub UpdateButtonAndLabelState()
        If itemIndex < itemsDataTable.Rows.Count - 1 Then
            nextEntryButton.Enabled = True
        Else
            nextEntryButton.Enabled = False
        End If

        If itemIndex > 0 Then
            previousEntryButton.Enabled = True
        Else
            previousEntryButton.Enabled = False
        End If

        blogEntryCountLabel.Text = _
            String.Format("{0} of {1} entries", _
            (itemIndex + 1).ToString(), itemsDataTable.Rows.Count.ToString())
    End Sub

    ''' <summary>
    ''' Set the Word document's Bookmark controls to the corresponding blog
    ''' entry node value in the DataTable.
    ''' 
    ''' To learn more about how to assign values from an Actions Pane to a
    ''' Word document, see the following walkthrough:
    ''' http://msdn2.microsoft.com/en-us/library/d6sb8dyb.
    ''' </summary>
    Private Sub SetBookmarks()
        ' Get the row in the DataTable corresponding to the current blog entry.
        Dim itemDataRow As DataRow = itemsDataTable.Rows(itemIndex)

        ' Set the bookmark values. 
        Globals.ThisDocument.PubDateBookmark.Text = itemDataRow("pubDate").ToString()
        Globals.ThisDocument.TitleBookmark.Text = itemDataRow("title").ToString()
        Globals.ThisDocument.LinkBookmark.Text = itemDataRow("link").ToString()
        Globals.ThisDocument.DescriptionBookmark.Text = itemDataRow("description").ToString()
    End Sub
End Class
