Option Strict On

Imports System.Text ' For StringBuilder

Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Show an initial web page in the WebBrowser
        WebBrowser1.DocumentText = "<html><body><h1>WebBrowser</h1><br>Click Help Link or type URL to view information in browser.</body></html>"

        ' Display the OK button for closing the application.
        MinimizeBox = False
    End Sub

    Private Sub LoadUrl(ByVal url As String)
        ' Check for a valid URL
        If String.IsNullOrEmpty(url) Or url.Equals("about:blank") Then
            MessageBox.Show("Invalid URL in TextBox")
            Return
        End If

        ' Add Http as a convenience
        If Not url.StartsWith("http://") Then
            url = "http://" & url
        End If

        ' Navigate to the desired URL
        Try
            Cursor.Current = Cursors.WaitCursor ' Set Wait Cursor
            WebBrowser1.Navigate(New Uri(url)) ' Navigate to the desired URL
        Catch ex As System.UriFormatException
            MessageBox.Show("Error: Invalid URL in TextBox. " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default ' Restore Default Cursor
        End Try
    End Sub

    Private Sub GoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoButton.Click
        LoadUrl(URLTextBox.Text) ' Get URL from TextBox
    End Sub

    ' Show local content.  Most any html content can be displayed in the Web Browser.  This is a sample of help file content.
    Private Sub LocalContentLinkLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocalContentLinkLabel.Click
        ' build local content html
        Dim builder As New StringBuilder
        builder.Append("<html><body>")
        builder.Append("<h1>Help File</h1>")
        builder.Append("<p>You can use a WebBrowser control to show local content such as this.<br>")
        builder.Append("<b>Splitter: </b>Use the splitter to modify browser height.<br>")
        builder.Append("<b>URL: </b>Enter a URL into the text box and click GO button to load online content into the WebBrowser.  You must have internet access on a physical device to view online content in this example")
        builder.Append("</body></html>")
        WebBrowser1.DocumentText = builder.ToString()
    End Sub

    Private Sub PocketPCLinkLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PocketPCLinkLabel.Click
        LoadUrl("http://www.pocketpc.com")
    End Sub

End Class
