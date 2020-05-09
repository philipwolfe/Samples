Imports System.Web
Imports System.Web.UI
Imports System.Collections
Imports ASPEnterpriseManager
Imports Microsoft.VisualBasic

Namespace ASPEnterpriseManager.Pages

	Public Class Users_Edit
		Inherits ASPEnterpriseManager.Page
		Protected WithEvents DBRoles As System.Web.UI.WebControls.CheckBoxList
		Protected WithEvents NewUser As System.Web.UI.WebControls.Panel
		Protected WithEvents CurUser As System.Web.UI.WebControls.Panel
		Protected WithEvents LoginName As System.Web.UI.WebControls.Label
		Protected WithEvents UserName As System.Web.UI.WebControls.Label
		Protected WithEvents NewLoginName As System.Web.UI.WebControls.DropDownList
		Protected WithEvents NewUserName As System.Web.UI.WebControls.TextBox
		
		Sub Page_Load(Sender As System.Object, E As System.EventArgs) 
			Dim chkbox
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Roles as ASPEnterpriseManager.Roles = New ASPEnterpriseManager.Roles
			If Not Page.IsPostBack Then
				DBROles.DataTextField = "RoleName"
				DBRoles.DataSource = Roles.List
				DBRoles.DataBind
				
				If Request("LoginName") <> "" Then
					Dim User as ASPEnterpriseManager.ExtendedUser = New ASPEnterpriseManager.ExtendedUser
					NewUser.Visible = False
					User.Load (Request("LoginName"))
					LoginName.Text = User.LoginName
					UserName.Text = User.UserName
					Dim X as Integer
					For X = 0 to User.Roles.Count - 1
						chkbox = DBRoles.Items.FindByValue(User.Roles(x))
						If Not IsNothing(chkbox) Then	chkbox.Selected = True
					Next
					Session("User") = User
				Else
					CurUser.Visible = False
					Dim Users as ASPEnterpriseManager.Users = New ASPEnterpriseManager.Users 
					NewLoginName.DataSource = Users.AvailableLogins
					NewLoginName.DataBind()
				End If
				chkbox = DBRoles.Items.FindByValue("public")
				chkbox.Selected = True
			End If
		End Sub
		
		Sub SaveUser_Click (Sender As System.Object, E As System.EventArgs) 
			Dim User as ASPEnterpriseManager.ExtendedUser = New ASPEnterpriseManager.ExtendedUser
			Dim CurRoles as ArrayList = New ArrayList
			Dim X as Integer
			For X = 0 to DBRoles.Items.Count - 1
				If DBRoles.Items(x).Selected Then 
					CurRoles.Add (DBRoles.Items(x).Value)
				End If
			Next
			If session("User") is Nothing Then
				User.Create (NewLoginName.SelectedItem.Text, NewUserName.Text, CurRoles)
			Else
				User = Session("User")
				User.Update(CurRoles)
			End If	
			Session("User") = Nothing
			Response.Redirect ("users.aspx")
		End Sub
		
		Sub UserPermissions_Click (Sender As System.Object, E As System.EventArgs) 
			Response.Redirect ("user_permissions.aspx?UserName=" & Session("User").UserName)
		End Sub
		
	End Class
End Namespace