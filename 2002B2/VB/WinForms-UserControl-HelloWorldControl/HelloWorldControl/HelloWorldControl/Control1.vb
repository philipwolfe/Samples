Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class Control1
    Inherits System.Windows.Forms.UserControl
    

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        
        'Paint the Text property on the control
        Dim backBrush As SolidBrush = New SolidBrush(BackColor)
        Dim foreBrush As SolidBrush = New SolidBrush(ForeColor)
        e.Graphics.FillRectangle(backBrush, ClientRectangle)
        e.Graphics.DrawString(Me.Text, Font, foreBrush, 10, 10)
        
    End Sub
    
    
    Private Sub InitializeComponent()
'
'Control1
        '
        Me.ClientSize = New System.Drawing.Size(292, 273)
        'Me.Name = "Control1"
    End Sub
End Class
