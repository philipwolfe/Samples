Imports System.Drawing
Imports System.Windows.Forms
Imports system.xml


Imports System.ComponentModel


Public Class Forecast
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        Forecast = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent() call
        
        'populate the valid cities
        cboCity.Items.Add("Chicago")
        cboCity.Items.Add("Houston")
        cboCity.Items.Add("LA")
        
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents cboCity As System.Windows.Forms.ComboBox
    Private WithEvents Label1 As System.Windows.Forms.Label

    Private WithEvents btnGetWeather As System.Windows.Forms.Button

    Dim WithEvents Forecast As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnGetWeather = New System.Windows.Forms.Button()
        Me.cboCity = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnGetWeather.Location = New System.Drawing.Point(72, 56)
        btnGetWeather.Size = New System.Drawing.Size(104, 23)
        btnGetWeather.TabIndex = 0
        btnGetWeather.Text = "Get Weather"

        cboCity.Location = New System.Drawing.Point(56, 12)
        cboCity.Size = New System.Drawing.Size(121, 21)
        cboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cboCity.TabIndex = 3

        Label1.Location = New System.Drawing.Point(16, 16)
        Label1.Text = "City:"
        Label1.Size = New System.Drawing.Size(32, 23)
        Label1.TabIndex = 2
        Me.Text = "Forecast"
        Me.MaximizeBox = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(200, 93)

        Me.Controls.Add(cboCity)
        Me.Controls.Add(Label1)
        Me.Controls.Add(btnGetWeather)
    End Sub

#End Region

    Protected Sub btnGetWeather_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetWeather.Click

        'declarations
        Dim City As String = Me.cboCity.Text.Trim()
        Dim Weather As String
        Dim Doc As New XmlDocument()
        Dim Nav As XPath.XPathNavigator
        Dim Iterator As XPath.XPathNodeIterator

        'validation
        If City = "" Then
            Throw New ArgumentNullException("City", "You must enter a city.")
        End If

        'load document
        Doc.Load("..\xml\weather.xml")

        'set nav object
        Nav = CType(Doc, XPath.IXPathNavigable).CreateNavigator()

        'set node iterator
        Iterator = Nav.Select("weather/" & City)

        'move to the desired node
        Iterator.MoveNext()

        'get the value of the current node
        Weather = Iterator.Current.Value

        'display weather
        MessageBox.Show(Weather, "Today's Weather for: " & City)

    End Sub

End Class
