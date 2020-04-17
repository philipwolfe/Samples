Imports System.ServiceModel
Imports System.ServiceModel.Syndication


Public Class PublishSystemInfo
    Implements IPublishSystemInfo


    Public Function GetSystemInfo(ByVal type As String) As System.ServiceModel.Syndication.SyndicationFeedFormatter Implements IPublishSystemInfo.GetSystemInfo
        Dim si As New SystemInfo
        Dim feed As New SyndicationFeed()

        feed.Title = SyndicationContent.CreatePlaintextContent( _
            String.Format("System Information for {0}", si.MachineName))
        feed.Links.Add( _
            SyndicationLink.CreateSelfLink( _
            OperationContext.Current.IncomingMessageHeaders.To))

        Dim item As New SyndicationItem
        item.Title = SyndicationContent.CreatePlaintextContent( _
            si.MachineName & " as of " & Now)
        item.Summary = New TextSyndicationContent( _
            si.GetHTMLContent(), TextSyndicationContentKind.Html)
        item.Content = SyndicationContent.CreateXmlContent(si)
        item.PublishDate = Now
        item.LastUpdatedTime = Now

        Dim items As List(Of SyndicationItem) = _
            New List(Of SyndicationItem)()
        items.Add(item)
        feed.Items = items
        Dim feedWrapper As SyndicationFeedFormatter
        If type = "rss" Then
            feedWrapper = New Rss20FeedFormatter(feed)
        Else
            feedWrapper = New Atom10FeedFormatter(feed)
        End If
        Return feedWrapper

    End Function
End Class

