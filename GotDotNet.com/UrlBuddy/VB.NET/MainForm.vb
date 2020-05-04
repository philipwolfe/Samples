Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Web
Imports System.Xml.Serialization

Public Class MainForm

#Region "PInvoke declarations"

    <DllImport("User32.dll")> _
    Public Shared Function SetClipboardViewer(ByVal hWndNewViewer As IntPtr) As IntPtr
    End Function

    <DllImport("User32.dll")> _
    Public Shared Function ChangeClipboardChain(ByVal hWndRemove As IntPtr, ByVal hWndNewNext As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function

#End Region

    Private _url As String                          ' The last URL copied to the clipboard
    Private _text As String                         ' The text to show on the form
    Private _loading As Boolean = True              ' Indicates that we are loading
    Private _nextClipboardViewer As IntPtr          ' The next clipboard in the Windows clipboard chain
    Private Const c_recentUrlsMax As Integer = 10   ' Maximum number of entries in the Recent URLs menu

    Public Sub New()
        InitializeComponent()
        LoadRecentUrls()

        notifyIcon.Text = Application.ProductName
    End Sub

    Private Sub ShowForm()
        ' Set location every time in case they change resolution.
        Dim desktop As Screen = Screen.PrimaryScreen
        Location = New Point(desktop.WorkingArea.Width - Width - 10, desktop.WorkingArea.Height - Height - 10)

        Visible = True
        FadeUpTo(80)
        timer.Start()
    End Sub

    Private Sub notifyIcon_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles notifyIcon.DoubleClick
        If Not _url Is Nothing Then
            ShowForm()
        End If
    End Sub

    Private Sub exitMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitMenuItem.Click
        Close()
    End Sub

    Private Sub timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer.Tick
        timer.Stop()
        FadeDownTo(0)
    End Sub

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        FadeDownTo(0)
        Process.Start(_url)
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)

        Opacity = 0
        ' Sign up for clipboard change notifications from the operating system.
        _nextClipboardViewer = SetClipboardViewer(Handle)
        _loading = False
    End Sub

    Protected Overrides Sub OnClosed(ByVal e As System.EventArgs)
        ' Remove ourselves from OS clipboard notifications
        ChangeClipboardChain(Handle, _nextClipboardViewer)
        SaveRecentUrls()
        MyBase.OnClosed(e)
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        timer.Stop()
        FadeUpTo(100)
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        If Not Bounds.Contains(PointToScreen(System.Windows.Forms.Cursor.Position)) Then
            FadeDownTo(80)
            timer.Start()
        End If

        MyBase.OnMouseLeave(e)
    End Sub

    Private Sub FadeUpTo(ByVal max As Integer)
        For i As Integer = Int32Opacity To max Step 5
            SetOpacityAndWait(i)
        Next i
    End Sub

    Private Sub FadeDownTo(ByVal min As Integer)
        For i As Integer = Int32Opacity To min Step -1
            SetOpacityAndWait(i)
        Next i
    End Sub

    Private Sub SetOpacityAndWait(ByVal opacity As Integer)
        Me.Opacity = opacity / 100.0
        Application.DoEvents()
        Thread.Sleep(20)
    End Sub

    Private ReadOnly Property Int32Opacity() As Integer
        Get
            Return Fix(Opacity * 100)
        End Get
    End Property

    ''' <summary>
    ''' Checks the clipboard for a URL.
    ''' </summary>
    Private Sub CheckClipboard()
        Dim dataObject As IDataObject

        Try
            dataObject = Clipboard.GetDataObject()
        Catch
            ' Please don't try this at home.
            Return
        End Try

        If Not (dataObject Is Nothing) Then
            If dataObject.GetDataPresent(DataFormats.Text) Then
                Dim data As String = dataObject.GetData(DataFormats.Text)
                If Not (data Is Nothing) Then
                    data = data.Trim()

                    If data.StartsWith("http") Then
                        ' Replace carriage returns, linefeeds, the common "quote" character (>)
                        ' and spaces.
                        data = data.Replace(vbCr, "").Replace(vbLf, "")
                        data = data.Replace(">", "").Replace(" ", "")

                        ' If the data is different from the URL we captured last, 
                        ' 
                        If data <> _url Then
                            showLastUrlMenuItem.Enabled = True ' The menu is disabled when the app starts.
                            _url = data
                            _text = "Contacting web site..."
                            Refresh()
                            ShowForm()
                            SetPageTitle()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Gets the web page source and looks for the title. 
    ''' </summary>
    Private Sub SetPageTitle()
        Dim textIsTitle As Boolean = False

        Try
            Dim req As WebRequest = WebRequest.Create(_url)
            Using resp As WebResponse = req.GetResponse()
                Using stream As Stream = resp.GetResponseStream()
                    Using sr As New StreamReader(stream)
                        Dim html As String = sr.ReadToEnd().Replace(vbCr, "").Replace(vbLf, "")

                        Dim re As New Regex("<title>(?<title>.*)</title>", RegexOptions.IgnoreCase)
                        Dim m As Match = re.Match(html)

                        If m.Success Then
                            _text = HttpUtility.HtmlDecode(m.Groups("title").Value)
                            textIsTitle = True
                        Else
                            _text = "(No page title)"
                        End If
                    End Using
                End Using
            End Using
        Catch
            _text = "(Could not retrieve title)"
        End Try

        Invalidate(True)
        AddUrlToMenu(textIsTitle)
    End Sub

    ''' <summary>
    ''' Draws the icon and text onto the form.
    ''' </summary>
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' Determine where to position the form on the screen.
        Dim left As Integer = 64
        Dim width As Integer = Me.Width - left - 10

        ' Vertically center the page title and trim with a trailing ellipsis if necessary.
        Dim stringFormat As StringFormat = CType(System.Drawing.StringFormat.GenericDefault.Clone(), StringFormat)
        stringFormat.LineAlignment = StringAlignment.Center
        stringFormat.Trimming = StringTrimming.EllipsisWord

        ' Draw the page title.
        Dim rect As New RectangleF(left, 5, width, 30)
        e.Graphics.DrawString(_text, New Font(Font, FontStyle.Bold), SystemBrushes.WindowText, rect, stringFormat)

        ' Change the trimming to better handle paths.
        stringFormat.Trimming = StringTrimming.EllipsisPath

        ' Draw the URL.
        rect = New RectangleF(left, 34, width, 16)
        e.Graphics.DrawString(_url, Font, SystemBrushes.WindowText, rect, stringFormat)

        ' Finally, draw the icon.
        e.Graphics.DrawIcon(My.Resources.GlobeIconBig, 0, 3)
    End Sub

    ''' <summary>
    ''' Adds the URL to the Recent URLs menu.
    ''' </summary>
    ''' <param name="textIsTitle">Indicates that the _text field is the title of the web page.</param>
    Private Sub AddUrlToMenu(ByVal textIsTitle As Boolean)
        ' The Recent URLs menu item is disabled at launch.
        recentUrlsMenuItem.Enabled = True

        ' If the URL already exists in the menu, remove it. We'll be adding it
        ' to the top of the list.
        For Each menuItem As UrlMenuItem In recentUrlsMenuItem.DropDownItems
            If menuItem.UrlInfo.Url = _url Then
                recentUrlsMenuItem.DropDownItems.Remove(menuItem)
                Exit For
            End If
        Next menuItem

        Dim newMenuItem As UrlMenuItem

        If textIsTitle Then
            newMenuItem = New UrlMenuItem(New UrlInfo(_url, _text))
        Else
            newMenuItem = New UrlMenuItem(New UrlInfo(_url))
        End If

        ' Add new menu item to top of list.
        recentUrlsMenuItem.DropDownItems.Insert(0, newMenuItem)

        ' Remove the extra URL if we've added one too many.
        If recentUrlsMenuItem.DropDownItems.Count > c_recentUrlsMax Then
            recentUrlsMenuItem.DropDownItems.RemoveAt(c_recentUrlsMax)
        End If
    End Sub

    Private Sub SaveRecentUrls()
        Dim urlInfos As List(Of UrlInfo) = New List(Of UrlInfo)

        For Each menuItem As UrlMenuItem In recentUrlsMenuItem.DropDownItems
            urlInfos.Add(menuItem.UrlInfo)
        Next

        Dim xs As XmlSerializer = New XmlSerializer(GetType(List(Of UrlInfo)))
        Dim sw As StringWriter = New StringWriter()
        xs.Serialize(sw, urlInfos)

        Settings.Default.RecentUrls = sw.ToString()
        Settings.Default.Save()
    End Sub

    Private Sub LoadRecentUrls()
        Dim recentUrlsXml As String = Settings.Default.RecentUrls

        If Not String.IsNullOrEmpty(recentUrlsXml) Then
            Dim xs As XmlSerializer = New XmlSerializer(GetType(List(Of UrlInfo)))
            Dim urlInfos As List(Of UrlInfo) = CType(xs.Deserialize(New StringReader(recentUrlsXml)), List(Of UrlInfo))

            For Each aUrlInfo As UrlInfo In urlInfos
                recentUrlsMenuItem.DropDownItems.Add(New UrlMenuItem(aUrlInfo))
            Next

            recentUrlsMenuItem.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Handles the clipboard calls from the operating system and forwards them
    ''' to our methods when appropriate.
    ''' </summary>
    <DebuggerStepThrough()> _
    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case &H308 ' WM_DRAWCLIPBOARD
                If Not _loading Then
                    CheckClipboard()
                End If
                SendMessage(_nextClipboardViewer, m.Msg, m.WParam, m.LParam)

            Case &H30D ' WM_CHANGECBCHAIN
                If m.WParam = _nextClipboardViewer Then
                    _nextClipboardViewer = m.LParam
                Else
                    SendMessage(_nextClipboardViewer, m.Msg, m.WParam, m.LParam)
                End If

            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

    Private Sub showLastUrlMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles showLastUrlMenuItem.Click
        ShowForm()
    End Sub
End Class
