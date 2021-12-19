Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System
Imports System.Resources

Imports Microsoft.VisualBasic
Imports System.Diagnostics


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
    Overrides Public Sub Dispose()
        MyBase.Dispose
        components.Dispose
    End Sub 

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents btnResource As System.Windows.Forms.Button
    
    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnResource = New System.Windows.Forms.Button()
        
        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnResource.Location = New System.Drawing.Point(32, 32)
        btnResource.Size = New System.Drawing.Size(112, 24)
        btnResource.TabIndex = 0
        btnResource.Text = "Create Resource"
        
        Me.Text = "ResourceWrite"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(176, 93)
        
        Me.Controls.Add(btnResource)
    End Sub
    
#End Region
    
    Protected Sub btnResource_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResource.click
        Dim ResourceWriter As ResourceWriter

        'Create a .resources file and add one string.
        ResourceWriter = New ResourceWriter("Greeting.resources")
        ResourceWriter.AddResource("Greeting", "Welcome to Microsoft .Net Framework !")
        ResourceWriter.Generate()
        ResourceWriter.Close()

        Dim RD As ResourceReader = New ResourceReader("Greeting.resources")
        Dim EN As IDictionaryEnumerator

        EN = RD.GetEnumerator()

        EN.MoveNext()

        ' Query resource for object.
        MsgBox("Resource Added to /bin directory of ResoruceWrite: " & EN.Value.ToString, , "Resource")


    End Sub

End Class
