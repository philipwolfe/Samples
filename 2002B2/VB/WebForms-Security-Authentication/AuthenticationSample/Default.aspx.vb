Imports System.Drawing
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls


Public Class CDefault
    Inherits System.Web.UI.Page
    Protected WithEvents divMessage As System.Web.UI.HtmlControls.HtmlGenericControl
#Region " Web Forms Designer Generated Code "
    
    'CODEGEN: This procedure is required by the Web Form Designer
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        
    End Sub
    
#End Region

    Protected Sub Page_Init(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub
    
    Private Sub CDefault_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Display the authenticated user name from the User.Identity object
        divMessage.InnerHTML = "Authentication was successful for User:&nbsp;<STRONG>" & User().Identity.Name & "</STRONG>"
    End Sub
End Class
