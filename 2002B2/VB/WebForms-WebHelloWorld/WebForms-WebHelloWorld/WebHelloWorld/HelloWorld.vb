Imports System
Imports System.ComponentModel.Design
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Microsoft.VisualBasic

Public Class HelloWorld
    Inherits System.Web.UI.Page
    Protected WithEvents txtGreeting As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents txtName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    
#Region " Web Forms Designer Generated Code "

    Dim WithEvents HelloWorld As System.Web.UI.Page
    
    Sub New()
        HelloWorld = Me
    End Sub

    'CODEGEN: This procedure is required by the Web Form Designer
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        
        
        
        
        
    End Sub
    
#End Region
    
    Public Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.click
        'place the greeting in the second text box
        txtGreeting.Text = "Hello " & txtName.Text & "!"
    End Sub

    Protected Sub HelloWorld_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs)
        If Not IsPostBack Then   ' Evals true first time browser hits the page	

        End If
    End Sub

    Protected Sub HelloWorld_Init(ByVal Sender As System.Object, ByVal e As System.EventArgs)
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

End Class
