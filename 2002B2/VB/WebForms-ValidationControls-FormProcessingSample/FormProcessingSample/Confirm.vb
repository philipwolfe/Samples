Option Strict On
Option Explicit On 

'The following Imports statements were auto-generated
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

'The following Imports statements were manually added
Imports System.Text 'Added for the StringBuilder object

Public Class Confirm
    Inherits System.Web.UI.Page
    Protected WithEvents divSubscriberInfo As System.Web.UI.HtmlControls.HtmlGenericControl
    
    
    
    
    
    
#Region " Web Forms Designer Generated Code "
    
    Dim WithEvents Confirm As System.Web.UI.Page
    
    Sub New()
        Confirm = Me
    End Sub
    
    'CODEGEN: This procedure is required by the Web Form Designer
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        
        
    End Sub
    
#End Region
    
    Protected Sub Confirm_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles Confirm.load
        If Not IsPostBack Then   ' Evals true first time browser hits the page	
            Dim sbSubscriberInfo As New StringBuilder()
            With sbSubscriberInfo
                .Append(Server.HtmlEncode(Request.QueryString("txtName")))
                .Append("<BR>")
                .Append(Server.HtmlEncode(Request.QueryString("txtCity")))
                .Append(", ")
                .Append(Server.HtmlEncode(Request.QueryString("ddlState")))
                .Append(" ")
                .Append(Server.HtmlEncode(Request.QueryString("txtZipCode")))
                .Append("<BR>")
                .Append(Server.HtmlEncode(Request.QueryString("txtEmail")))
            End With
            divSubscriberInfo.InnerHtml = sbSubscriberInfo.ToString
        End If
    End Sub

    Protected Sub Subscribe_Init(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles Confirm.init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

End Class
