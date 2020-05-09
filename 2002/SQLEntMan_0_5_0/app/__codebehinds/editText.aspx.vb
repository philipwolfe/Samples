Imports System.Web
Imports ASPEnterpriseManager

Namespace ASPEnterpriseManager.Pages
	Public Class EditText
		Inherits ASPEnterpriseManager.Page
		Protected WithEvents InputText As System.Web.UI.WebControls.TextBox
		Protected WithEvents Type As System.Web.UI.WebControls.Label
		Protected WithEvents Name As System.Web.UI.WebControls.Label
				
		Sub Page_Load(Sender As System.Object, E As System.EventArgs) 
			Dim _Context as HTTPContext = HTTPContext.Current		
			if not Page.IsPostBack Then
				Select Case Request("Type")
					Case "SP":
						Type.Text = "SP"
						If request("SP") = "" Then	
							InputText.Text = "CREATE PROCEDURE [OWNER].[PROCEDURE NAME] AS"
						Else
							Name.Text = Request("SP")
							Dim SP as ASPEnterpriseManager.StoredProcedure = New ASPEnterpriseManager.StoredProcedure
							SP.Load (Request("SP"))
							InputText.Text = SP.Text
						End If
					Case "View":
						Type.Text = "View"
						If request("View") = "" Then	
							InputText.Text = "CREATE VIEW [VIEW NAME] AS"
						Else
							Name.Text = Request("View")
							Dim View as ASPEnterpriseManager.View = New ASPEnterpriseManager.View
							View.Load (Request("View"))
							InputText.Text = View.Text
						End If
				End Select
					
			End If
		End Sub
		
		Sub Save_Click (Sender As System.Object, E As System.EventArgs) 
			Select Case Type.Text
				Case "SP":
					Dim SP as ASPEnterpriseManager.StoredProcedure = New ASPEnterpriseManager.StoredProcedure
					SP.name = Name.Text
					SP.Text = InputText.Text
					SP.Save()	
				Case "View":
					Dim View as ASPEnterpriseManager.View = New ASPEnterpriseManager.View
					View.name = Name.Text
					View.Text = InputText.Text
					View.Save()	
			End Select
			Response.Redirect ("setDatabase.aspx?Sync=True")
		End Sub
	
	End Class
End Namespace