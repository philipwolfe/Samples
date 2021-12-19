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
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents btnCollection As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnCollection = New System.Windows.Forms.Button()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnCollection.Location = New System.Drawing.Point(32, 24)
        btnCollection.Size = New System.Drawing.Size(144, 24)
        btnCollection.TabIndex = 0
        btnCollection.Text = "Display Fruit Collection"

        Me.Text = "Fruit Collection"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(232, 77)

        Me.Controls.Add(btnCollection)
    End Sub

#End Region

    Protected Sub btnCollection_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCollection.click
        Dim Fruit As New ArrayList()
        Dim ReturnVal As String

        'populate the ArrayList
        Fruit.Add("Apple")
        Fruit.Add("Pear")
        Fruit.Add("Orange")
        Fruit.Add("Banana")

        'read the values out of the ArrayList
        Dim Item As String
        For Each Item In Fruit
            ReturnVal = ReturnVal & Item & Chr(10)
        Next Item

        'display the contents to the user
        MessageBox.Show(ReturnVal, "Fruit Collection")
    End Sub

End Class
