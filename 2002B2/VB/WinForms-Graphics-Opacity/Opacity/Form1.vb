Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()
        
        'This calls the Fadein() Sub
        Fadein()
        
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

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        Me.Text = "Form1"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Red
        Me.ClientSize = New System.Drawing.Size(536, 285)
        
    End Sub
    
#End Region
    
    
    'The Form Property .Opacity is set to gradually show the form appear
    Public Sub FadeIn()
        Dim i As Integer
        
        form1.Opacity = 0
        form1.Visible = True
        form1.Refresh()
        For i = 0 To 100 'Step 5
            form1.Opacity = i / 100
            form1.Refresh()
        Next
    End Sub
End Class
