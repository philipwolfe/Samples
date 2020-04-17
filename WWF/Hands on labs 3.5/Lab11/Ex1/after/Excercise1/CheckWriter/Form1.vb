Public Class Form1
    Private svc As CheckServices.CheckOperationsClient

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        svc.Close()
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        svc = New CheckServices.CheckOperationsClient
        svc.Open()

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Text = svc.Write(CDec(TextBox1.Text))
    End Sub
End Class
