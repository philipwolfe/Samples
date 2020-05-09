Imports System.Web
Imports ASPEnterpriseManager

Namespace ASPEnterpriseManager.Pages
	Public Class ServerRoles
		Inherits ASPEnterpriseManager.Page
		Protected WithEvents Repeater1 As System.Web.UI.WebControls.Repeater
		
		Sub Page_Load(Sender As System.Object, E As System.EventArgs) 
			Dim _Context as HTTPContext = HTTPContext.Current		
			if not Page.IsPostBack Then
				Dim Roles as ASPEnterpriseManager.ServerRoles = New ASPEnterpriseManager.ServerRoles
				Roles.Load()
				Repeater1.DataSource = Roles.List
			   Repeater1.DataBind()
			End If
		End Sub
	
	End Class
End Namespace