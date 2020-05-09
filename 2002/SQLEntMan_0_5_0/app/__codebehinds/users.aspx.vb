Imports System.Web
Imports System.Collections
Imports ASPEnterpriseManager

Namespace ASPEnterpriseManager.Pages
	Public Class Users
		Inherits ASPEnterpriseManager.Page
		Protected WithEvents Repeater1 As System.Web.UI.WebControls.Repeater
				
		Sub Page_Load(Sender As System.Object, E As System.EventArgs) 
			Dim _Context as HTTPContext = HTTPContext.Current		
			if not Page.IsPostBack Then
				Dim UserList as ArrayList = New ArrayList
				Dim Users as New AspEnterpriseManager.Users
				UserList = Users.List
				Repeater1.DataSource = UserList
			   Repeater1.DataBind()
			End If
		End Sub
	
	End Class
End Namespace