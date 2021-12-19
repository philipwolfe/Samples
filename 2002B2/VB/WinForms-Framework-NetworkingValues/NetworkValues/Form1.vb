Option Strict Off
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Net.DNS


Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

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
    Private WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Private WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Private WithEvents txtIpAddress As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents btngetnames As System.Windows.Forms.Button
    Private WithEvents txthostname As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.btngetnames = New System.Windows.Forms.Button()
        Me.txthostname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIpAddress = New System.Windows.Forms.TextBox()
        Me.components = New System.ComponentModel.Container()
        Me.SuspendLayout()
        '
        'btngetnames
        '
        Me.btngetnames.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btngetnames.Location = New System.Drawing.Point(272, 192)
        Me.btngetnames.Name = "btngetnames"
        Me.btngetnames.Size = New System.Drawing.Size(112, 32)
        Me.btngetnames.TabIndex = 2
        Me.btngetnames.Text = "Get Values"
        '
        'txthostname
        '
        Me.txthostname.Location = New System.Drawing.Point(112, 32)
        Me.txthostname.Name = "txthostname"
        Me.txthostname.Size = New System.Drawing.Size(192, 20)
        Me.txthostname.TabIndex = 1
        Me.txthostname.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Computer Name"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(40, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "IP Address"
        '
        'txtIpAddress
        '
        Me.txtIpAddress.Location = New System.Drawing.Point(112, 72)
        Me.txtIpAddress.Name = "txtIpAddress"
        Me.txtIpAddress.Size = New System.Drawing.Size(192, 20)
        Me.txtIpAddress.TabIndex = 4
        Me.txtIpAddress.Text = ""
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(408, 253)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtIpAddress, Me.Label2, Me.btngetnames, Me.txthostname, Me.Label1})
        Me.Name = "Form1"
        Me.Text = "Networking Attributes"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Function GetIPAddress() As String
        Dim Addr As System.Net.IPAddress
        Dim AddrValue As String
        With System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName())
            'If there is an address then use the System IPAddress Object to grab the IP Address
            If .AddressList.Length > 0 Then
                Addr = New System.Net.IPAddress(.AddressList(0).Address)
                AddrValue = Addr.ToString
            End If
        End With
        GetIPAddress = AddrValue

    End Function

    Protected Sub btnGetNames_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngetnames.click
        Dim HostName As String
        'Set string equal to value of System DNS Object value for GetHostName
        'This should be the localhost computer name
        HostName = System.Net.Dns.GetHostName
        txthostname.Text = HostName
        'Call Get IPAddress
        txtIpAddress.Text = GetIPAddress()
    End Sub

End Class
