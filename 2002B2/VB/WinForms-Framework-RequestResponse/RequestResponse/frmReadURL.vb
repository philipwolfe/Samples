Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmReadURL
    Inherits System.Windows.Forms.Form
    
    Public Sub New()
        MyBase.New()
        
        Form1 = Me
        
        'This call is required by the Win Form Designer.
        InitializeComponent()
        
        'TODO: Add any initialization after the InitializeComponent() call
    End Sub
    
    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtProxy As System.Windows.Forms.TextBox
    Private WithEvents txtHTML As System.Windows.Forms.TextBox
    Private WithEvents cmdGetHTML As System.Windows.Forms.Button
    Private WithEvents txtURL As System.Windows.Forms.TextBox

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHTML = New System.Windows.Forms.TextBox()
        Me.txtProxy = New System.Windows.Forms.TextBox()
        Me.cmdGetHTML = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        txtURL.Location = New System.Drawing.Point(36, 12)
        txtURL.Text = "http://www.microsoft.com"
        txtURL.TabIndex = 0
        txtURL.Size = New System.Drawing.Size(328, 20)

        Label1.Location = New System.Drawing.Point(12, 372)
        Label1.Text = "(optional) Proxy Server:"
        Label1.Size = New System.Drawing.Size(136, 16)
        Label1.TabIndex = 4

        txtHTML.Location = New System.Drawing.Point(8, 36)
        txtHTML.Text = "Hit Get HTML Button"
        txtHTML.Multiline = True
        txtHTML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        txtHTML.TabIndex = 2
        txtHTML.Size = New System.Drawing.Size(440, 328)

        txtProxy.Location = New System.Drawing.Point(148, 368)
        txtProxy.TabIndex = 3
        txtProxy.Size = New System.Drawing.Size(304, 20)

        cmdGetHTML.Location = New System.Drawing.Point(368, 8)
        cmdGetHTML.Size = New System.Drawing.Size(80, 24)
        cmdGetHTML.TabIndex = 1
        cmdGetHTML.Text = "Get HTML"

        Label2.Location = New System.Drawing.Point(8, 16)
        Label2.Text = "Url:"
        Label2.Size = New System.Drawing.Size(28, 16)
        Label2.TabIndex = 5
        Me.Text = "Web Request Demo: Getting HTML from URL"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(456, 401)

        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(txtProxy)
        Me.Controls.Add(txtHTML)
        Me.Controls.Add(cmdGetHTML)
        Me.Controls.Add(txtURL)
    End Sub

#End Region

    Protected Sub cmdGetHTML_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGetHTML.Click
        'Error Handling
        'Try Statement will execute, unless there's an error at which point the 
        'Catch Statement will execute
        'Get Proxy Value from Form
        Dim sProxy As String = Me.txtProxy.Text
        'If Proxy entered then Create a Proxy object pointed to the URL from the form over Port 80

        If sProxy <> "" Then
            Dim oProxy As New System.Net.WebProxy(sProxy, 80)
            'Set Proxy Selection to Proxy Object
            System.Net.GlobalProxySelection.Select = oProxy
        End If

        'Create a Request Object
        Dim oReq As System.Net.WebRequest

        'Request object = to Create of URL Request
        oReq = System.Net.WebRequest.Create(Me.txtURL.Text)


        'Create Response Object
        Dim oResp As System.Net.WebResponse

        'Set Response Object = GetResponse off of Request Object
        oResp = oReq.GetResponse()

        'Create a Stream Object
        Dim oStream As System.IO.Stream

        'Set Stream Object = Response Stream
        oStream = oResp.GetResponseStream

        'Dim Response Stream Reader
        Dim oReader As New System.IO.StreamReader(oStream)

        Dim sRet As String

        'Set String = Full Text of Reader
        sRet = oReader.ReadToEnd

        'Set Text Box = Full Text Stream
        Me.txtHTML.Text = sRet


    End Sub



End Class
