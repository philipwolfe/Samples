Imports System.Web
Imports ASPEnterpriseManager

Namespace ASPEnterpriseManager.Pages
	Public Class Logins
		Inherits ASPEnterpriseManager.Page
		Protected WithEvents Repeater1 As System.Web.UI.WebControls.Repeater
		
		
		Sub Page_Load(Sender As System.Object, E As System.EventArgs) 
			Dim _Context as HTTPContext = HTTPContext.Current		
			if Page.IsPostBack Then
				
				
			Else
				Dim Logins as New AspEnterpriseManager.Logins
				Logins.Load()
				Repeater1.DataSource = Logins.List
			   Repeater1.DataBind()
			End If
		End Sub
	
	End Class
End Namespace