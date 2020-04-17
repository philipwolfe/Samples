Imports System.ServiceModel
Imports System.ServiceModel.Syndication
Imports System.ServiceModel.Web


<ServiceContract(Namespace:="")> _
<ServiceKnownType(GetType(Rss20FeedFormatter))> _
<ServiceKnownType(GetType(Atom10FeedFormatter))> _
Public Interface IPublishSystemInfo
    <OperationContract(), WebGet(UriTemplate:="/sysinfo/{type}/")> _
Function GetSystemInfo(ByVal type As String) As SyndicationFeedFormatter

End Interface


