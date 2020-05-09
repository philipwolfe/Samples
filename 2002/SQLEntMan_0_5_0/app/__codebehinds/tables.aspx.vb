Imports System.Web
Imports ASPEnterpriseManager

Namespace ASPEnterpriseManager.Pages
	Public Class Tables
		Inherits ASPEnterpriseManager.Page
		Protected WithEvents Repeater1 As System.Web.UI.WebControls.Repeater
		
		Sub Page_Load(Sender As System.Object, E As System.EventArgs) 
			Dim _Context as HTTPContext = HTTPContext.Current		
			if not Page.IsPostBack Then
				Repeater1.DataSource = Session("Database").Tables
			   Repeater1.DataBind()
			End If
		End Sub
	
	End Class
End Namespace