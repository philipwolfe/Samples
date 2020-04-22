Imports WSFun.Amazon

Public Class Form1
    ' Private members
    Private _subscriberID As String = String.Empty
    Private SearchMode As String = "books"

    ' Amazon subscriber identification.
    Private ReadOnly Property SubscriberID() As String
        Get
            If (_subscriberID.Length = 0) Then
                ' Retrieve Amazon subscriber id.
                _subscriberID = My.Settings.AmazonSubscriberID
            End If
            Return _subscriberID
        End Get
    End Property

    Private Sub goButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles goButton.Click
        Call CleanUpForm()
        Call PerformKeyWordSearch()
    End Sub
    Private Sub modeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dvdOption.CheckedChanged, musicOption.CheckedChanged, booksOption.CheckedChanged
        If (TypeOf (sender) Is RadioButton) Then
            Dim tempOption As RadioButton = sender
            If Not tempOption.Tag Is Nothing Then
                Me.SearchMode = tempOption.Tag.ToString()
            End If
        End If
    End Sub
    Private Sub searchResults_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchResults.SelectedIndexChanged
        Dim tempDetails As Details = DirectCast(Me.searchResults.SelectedItem, Details)
        Me.itemPicture.Image = tempDetails.ItemImage
        Me.listPriceLabel.Text = "Amazon price: " + tempDetails.OurPrice
        Me.usedPriceLabel.Text = "Used price: " + tempDetails.UsedPrice
        Me.availabilityLabel.Text = tempDetails.Availability
    End Sub

    ' Call Amazon search Web service.
    Private Sub PerformKeyWordSearch()
        Try
            Dim keywordReq As KeywordRequest = New KeywordRequest()
            keywordReq.locale = "us"
            keywordReq.type = "lite"
            keywordReq.sort = "reviewrank"
            keywordReq.mode = Me.SearchMode
            keywordReq.keyword = Me.searchText.Text
            keywordReq.tag = Me.SubscriberID
            keywordReq.devtag = Me.SubscriberID

            Dim amazonWS As AmazonSearchService = New AmazonSearchService()
            Dim productInfo As ProductInfo = amazonWS.KeywordSearchRequest(keywordReq)

            If (productInfo.Details.Length > 0) Then
                Me.searchResults.Items.AddRange(productInfo.Details)
            Else
                MessageBox.Show("No items found.")
            End If

        Catch sx As Web.Services.Protocols.SoapException
            MessageBox.Show(sx.Message, "SOAP Error")

        End Try
    End Sub

    ' Clear values in form controls.
    Private Sub CleanUpForm()
        Me.searchResults.Items.Clear()
        If Not (Me.itemPicture.Image Is Nothing) Then
            Me.itemPicture.Image = Nothing
            Me.listPriceLabel.Text = String.Empty
            Me.usedPriceLabel.Text = String.Empty
            Me.availabilityLabel.Text = String.Empty
            Me.Refresh()
        End If
    End Sub
End Class
