Option Strict On

Imports System.Net.Cache
Imports System.Net
Imports System.IO


Public Class Form1

    ' Fill the strings for display on the form.  Text taken from the MSDN documentation.
    Private policyDescriptions As String() = { _
"Satisfies a request by using the server. No entries are taken from caches, added to caches, or removed from caches between the client and server. This is the default cache behavior specified in the machine configuration file that ships with the .NET Framework.", _
"Satisfies a request for a resource from the cache if the resource is available; otherwise, sends a request for a resource to the server. If the requested item is available in any cache between the client and the server, the request might be satisfied by the intermediate cache.", _
"Satisfies a request using the locally cached resource; does not send a request for an item that is not in the cache. When this cache policy level is specified, a WebException exception is thrown if the item is not in the client cache.", _
"Satisfies a request for a resource either from the local computer's cache or a remote cache on the local area network. If the request cannot be satisfied, a WebException exception is thrown. In the HTTP caching protocol, this is achieved using the only-if-cached cache control directive.", _
"Satisfies a request for a resource either by using the cached copy of the resource or by sending a request for the resource to the server. The action taken is determined by the current cache policy and the age of the content in the cache.  This is the cache level that should be used by most applications.", _
"Never satisfies a request by using resources from the cache and does not cache resources. If the resource is present in the local cache, it is removed. This policy level indicates to intermediate caches that they should remove the resource. In the HTTP caching protocol, this is achieved using the no-cache cache control directive.", _
"Satisfies a request by using the server or a cache other than the local cache. Before the request can be satisfied by an intermediate cache, that cache must revalidate its cached entry with the server. In the HTTP caching protocol, this is achieved using the max-age = 0 cache control directive and the no-cache Pragma header.", _
"Satisfies a request by using the server. The response might be saved in the cache. In the HTTP caching protocol, this is achieved using the no-cache cache control directive and the no-cache Pragma header.", _
"Compares the copy of the resource in the cache with the copy on the server. If the copy on the server is newer, it is used to satisfy the request and replaces the copy in the cache. If the copy in the cache is the same as the server copy, the cached copy is used. In the HTTP caching protocol, this is achieved using a conditional request."}

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Init the BypassCache policy (ships as default in .NET Framework)
        PolicyComboBox.SelectedIndex = 0
    End Sub

    Private Function ValidateURL(ByVal url As String) As String
        Dim str As String = url

        ' Check for a valid URL
        If String.IsNullOrEmpty(str) Or str.Equals("about:blank") Then
            Throw New Exception("Invalid URL in TextBox")
        End If

        ' Add Http as a convenience
        If Not str.StartsWith("http://") Then
            str = "http://" & str
        End If

        Return str
    End Function

    Private Sub PolicyComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PolicyComboBox.SelectedIndexChanged
        Dim policy As HttpRequestCachePolicy = Nothing
        Select Case (PolicyComboBox.SelectedIndex)
            Case 0
                ' BypassCache
                '   Satisfies a request by using the server. No entries are taken from caches, 
                '   added to caches, or removed from caches between the client and server. 
                '   This is the default cache behavior specified in the machine configuration 
                '   file that ships with the .NET Framework.
                policy = New HttpRequestCachePolicy(HttpRequestCacheLevel.BypassCache)
            Case 1
                ' CacheIfAvailable 
                '   Satisfies a request for a resource from the cache if the resource is 
                '   available; otherwise, sends a request for a resource to the server. 
                '   If the requested item is available in any cache between the client and the server, 
                '   the request might be satisfied by the intermediate cache.  
                policy = New HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable)
            Case 2
                ' CacheOnly 
                '   Satisfies a request using the locally cached resource; does not send a 
                '   request for an item that is not in the cache. When this cache policy level is 
                '   specified, a WebException exception is thrown if the item is not in the client cache.  
                policy = New HttpRequestCachePolicy(HttpRequestCacheLevel.CacheOnly)
            Case 3
                ' CacheOrNextCacheOnly 
                '   Satisfies a request for a resource either from the local computer's cache 
                '   or a remote cache on the local area network. If the request cannot be satisfied, 
                '   a WebException exception is thrown. In the HTTP caching protocol, this is 
                '   achieved using the only-if-cached cache control directive.  

                policy = New HttpRequestCachePolicy(HttpRequestCacheLevel.CacheOrNextCacheOnly)
            Case 4
                ' Default 
                '   Satisfies a request for a resource either by using the cached copy of the 
                '   resource or by sending a request for the resource to the server. The action 
                '   taken is determined by the current cache policy and the age of the content in 
                '   the cache.  This is the cache level that should be used by most applications.
                policy = New HttpRequestCachePolicy(HttpRequestCacheLevel.Default)
            Case 5
                ' NoCacheNoStore 
                '   Never satisfies a request by using resources from the cache and does not cache 
                '   resources. If the resource is present in the local cache, it is removed. This 
                '   policy level indicates to intermediate caches that they should remove the resource. 
                '   In the HTTP caching protocol, this is achieved using the no-cache cache control directive.  
                policy = New HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore)
            Case 6
                ' Refresh 
                '   Satisfies a request by using the server or a cache other than the local cache. 
                '   Before the request can be satisfied by an intermediate cache, that cache must 
                '   revalidate its cached entry with the server. In the HTTP caching protocol, this is 
                '   achieved using the max-age = 0 cache control directive and the no-cache Pragma header.  
                policy = New HttpRequestCachePolicy(HttpRequestCacheLevel.Refresh)
            Case 7
                ' Reload 
                '   Satisfies a request by using the server. The response might be saved in the cache. 
                '   In the HTTP caching protocol, this is achieved using the no-cache cache control 
                '   directive and the no-cache Pragma header.  
                policy = New HttpRequestCachePolicy(HttpRequestCacheLevel.Reload)
            Case 8
                ' Revalidate 
                '   Compares the copy of the resource in the cache with the copy on the server. 
                '   If the copy on the server is newer, it is used to satisfy the request and replaces 
                '   the copy in the cache. If the copy in the cache is the same as the server copy, the 
                '   cached copy is used. In the HTTP caching protocol, this is achieved using a 
                '   conditional request.
                policy = New HttpRequestCachePolicy(HttpRequestCacheLevel.Revalidate)
        End Select

        ' Set the policy for the Application Domain
        HttpWebRequest.DefaultCachePolicy = policy

        ' Set Description
        PolicyDescTextBox.Text = policyDescriptions(PolicyComboBox.SelectedIndex)
    End Sub

    Private Sub GoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoButton.Click
        Try
            ' Clear out text box
            RichTextBox1.Text = String.Empty

            ' Show status
            StatusLabel.Text = "Finding URL..."

            ' Get the desired URL into a URI
            Dim myURI As New Uri(ValidateURL(UrlTextBox.Text))

            ' Perform the webrequest
            Dim request As WebRequest = WebRequest.Create(myURI)

            ' Get the response
            Dim response As WebResponse = request.GetResponse

            ' Alert user as to whether the reponse is cached or not
            StatusLabel.Text = ("IsFromCache? " & response.IsFromCache)

            ' Display the response into a richTextBox to show what was actually in the response stream
            Dim reader As New StreamReader(response.GetResponseStream)
            RichTextBox1.Text = reader.ReadToEnd()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            StatusLabel.Text = "Error."
        End Try
    End Sub

End Class
