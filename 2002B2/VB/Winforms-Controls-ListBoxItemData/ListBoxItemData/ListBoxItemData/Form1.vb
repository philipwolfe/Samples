Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


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
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents Button3 As System.Windows.Forms.Button
    Private WithEvents Button2 As System.Windows.Forms.Button
    Private WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents ListBox1 As System.Windows.Forms.ListBox

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(264, 104)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(200, 40)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Populate using DataSource"
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(16, 16)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(224, 212)
        Me.ListBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(264, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 40)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Populate using Items Collection"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(264, 192)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(200, 40)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Display selected item info"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button3, Me.Button2, Me.Button1, Me.ListBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not (ListBox1.SelectedItem Is Nothing) Then
            Dim SelectedCustomer As Customer = CType(ListBox1.SelectedItem, Customer)
            MessageBox.Show(SelectedCustomer.LastName)
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        ListBox1.Items.Clear()
        ListBox1.DisplayMember = "FirstName"
        ListBox1.DataSource = Customer.LoadCustomers()
        ListBox1.SelectedIndex = 0
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Reset ListBox if Button3 has been clicked
        If Not (ListBox1.DataSource Is Nothing) Then
            ListBox1.DataSource = Nothing
            ListBox1.Items.Clear()
            ListBox1.DisplayMember = Nothing
        End If

        ListBox1.Items.Add(Customer.ReadCustomer1())
        ListBox1.Items.Add(Customer.ReadCustomer2())
        ListBox1.Items.Add(Customer.ReadCustomer3())
        ListBox1.SelectedIndex = 0
    End Sub

End Class
