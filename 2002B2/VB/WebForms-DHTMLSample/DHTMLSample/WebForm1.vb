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

Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    
#Region " Web Forms Designer Generated Code "

    Dim WithEvents WebForm1 As System.Web.UI.Page
    
    Sub New()
        WebForm1 = Me
    End Sub

    'CODEGEN: This procedure is required by the Web Form Designer
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()

    End Sub

#End Region
   
    Protected Sub WebForm1_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs)
        If Not IsPostback Then   ' Evals true first time browser hits the page	
        
        End If
    End Sub

    Protected Sub WebForm1_Init(ByVal Sender As System.Object, ByVal e As System.EventArgs)
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent
    End Sub

End Class
