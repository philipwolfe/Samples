Imports System.Web
Imports System.Web.UI
Imports System.Collections
Imports ASPEnterpriseManager
Imports Microsoft.VisualBasic

Namespace ASPEnterpriseManager.Pages
	Public Class Logins_Edit
		Inherits ASPEnterpriseManager.Page
		Protected WithEvents ServerRoles As System.Web.UI.WebControls.CheckBoxList
		Protected WithEvents DefDatabase As System.Web.UI.WebControls.DropDownList
		Protected WithEvents DefLanguage As System.Web.UI.WebControls.DropDownList
		Protected WithEvents EditLogin As System.Web.UI.WebControls.Panel
		Protected WithEvents NewLogin As System.Web.UI.WebControls.Panel
		Protected WithEvents NewLoginName As System.Web.UI.WebControls.TextBox
		Protected WithEvents UpdatePassword As System.Web.UI.WebControls.Panel
		Protected WithEvents cmdChangePassword As System.Web.UI.WebControls.Button
		Protected WithEvents ChangePasswordError As System.Web.UI.WebControls.Label
		Protected WithEvents ChangePassword As System.Web.UI.WebControls.TextBox
		Protected WithEvents ChangeConfirm As System.Web.UI.WebControls.TextBox
		Protected WithEvents OldPassword As System.Web.UI.WebControls.TextBox
		Protected WithEvents Password As System.Web.UI.WebControls.TextBox
		Protected WithEvents Confirm As System.Web.UI.WebControls.TextBox
		Protected WithEvents LoginName As System.Web.UI.WebControls.Label
		Protected WithEvents NewPassword As System.Web.UI.WebControls.Panel
		Protected WithEvents EditPassword As System.Web.UI.WebControls.Button
		
		
		Sub Page_Load(Sender As System.Object, E As System.EventArgs) 
			Dim _Context as HTTPContext = HTTPContext.Current
			If not Page.IsPostBack Then
				Dim SystemInfo as ASPEnterpriseManager.SystemInformation = New ASPEnterpriseManager.SystemInformation
				
				ServerRoles.DataSource = SystemInfo.ServerRoles
           	ServerRoles.DataBind()

				DefDatabase.DataSource = _Context.Session("Server").Databases
				DefDatabase.Databind()
				
				DefLanguage.DataSource = SystemInfo.Languages
				DefLanguage.DataBind()
				
				UpdatePassword.Visible = False
				
				If request("LoginName") <> "" Then
					Dim Login as ASPEnterpriseManager.ExtendedLogin = New ASPEnterpriseManager.ExtendedLogin					
					Login.Load (request("LoginName"))
					Session("Login") = Login
					DefDatabase.Items.FindByValue(Login.DefaultDB).Selected = true  
					DefLanguage.Items.FindByValue(Login.DefaultLanguage).Selected = true  
					LoginName.Text = Login.Name
					NewLogin.Visible = false
					NewPassword.Visible = false
					Dim s as String
					Dim chkbox 
					For Each s in Login.ServerRoles.Keys
						chkbox = ServerRoles.Items.FindByValue(S)
						If Not IsNothing(chkbox) Then	chkbox.Selected = True
					Next
				Else
					EditLogin.Visible = false
					EditPassword.Visible = false
				End If
			End If
		End Sub
		
		Sub EditPassword_click (Sender As System.Object, E As System.EventArgs) 
			 UpdatePassword.Visible = True
			 EditPAssword.Visible = False
		End Sub
		
		Sub CancelUpdate_click (Sender As System.Object, E As System.EventArgs) 
			 UpdatePassword.Visible = False
			 EditPassword.Visible = True
		End Sub
		
		Sub cmdChangePassword_click (Sender As System.Object, E As System.EventArgs) 
			Dim Login as ASPEnterpriseManager.ExtendedLogin = New ASPEnterpriseManager.ExtendedLogin
			Login = Session("Login")
			If ChangePassword.Text <> ChangeConfirm.Text Then
				ChangePasswordError.Text = "The password field and confirmation field did not match."
			Else 
				Login.ChangePassword (OldPassword.Text, ChangePassword.Text)
				UpdatePassword.Visible = False
				EditPAssword.Visible = True
			End If	
		End Sub
		
		Sub Save_Click (Sender As System.Object, E As System.EventArgs) 
			Dim Login as ASPEnterpriseManager.ExtendedLogin = New ASPEnterpriseManager.ExtendedLogin
			Dim Roles as HashTable = New HashTable
			Dim X as Integer
			For X = 0 to ServerRoles.Items.Count - 1
				If ServerRoles.Items(X).Selected Then Roles.Add (ServerRoles.Items(X).Value, "")
			Next
			If Not Session("Login") is Nothing Then	
				Login = Session("Login")
				Login.Update (DefDatabase.SelectedItem.Value, DefLanguage.SelectedItem.Value, Roles) 
			Else
				Login.Create (NewLoginName.Text, Password.Text, DefDatabase.SelectedItem.Value, DefLanguage.SelectedItem.Value, Roles)
			End If	
			Session("Login") = Nothing
			Response.redirect ("logins.aspx")
		End Sub
		
	End Class
End Namespace