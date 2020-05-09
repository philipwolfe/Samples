Imports System.Web
Imports System.Web.UI
Imports System.Reflection
Imports System.Collections
Imports ASPEnterpriseManager
Imports Microsoft.VisualBasic
Imports System.Web.UI.WebControls

Namespace ASPEnterpriseManager.Pages

	Public Class User_Permissions
		Inherits ASPEnterpriseManager.Page
		Protected WithEvents Repeater1 As System.Web.UI.WebControls.Repeater
		Protected WithEvents UserName As System.Web.UI.WebControls.Label
		
		Sub Page_Load(Sender As System.Object, E As System.EventArgs) 
			
			If Not Page.IsPostBack Then
				Dim Permissions as ASPEnterpriseManager.DatabaseObjectPermissions = New ASPEnterpriseManager.DatabaseObjectPermissions
				Permissions.load (Request("UserName"))
				UserName.Text = Request("UserName")
				Session("Permissions") = Permissions
				Repeater1.DataSource = Permissions.List.Values
				Repeater1.DataBind
			End If
			
		End Sub
		
		Sub Save_Click(Source As System.Object, e As System.EventArgs)
			Dim CurPermissions as ASPEnterpriseManager.DatabaseObjectPermissions = New ASPEnterpriseManager.DatabaseObjectPermissions
			Dim NewPermissions as HashTable = New HashTable		
			
			CurPermissions = Session("Permissions")
			NewPermissions = LoadPermissionsFromForm()
			
			'Response.write (CurPermissions.UserName)
			
			'CurPermissions.Update (NewPermissions)
			
			'Response.redirect ("users_edit.aspx?loginName=" & UserName.Text)
			
		End Sub
		
		Private Function LoadPermissionsFromForm () as HashTable 
			Dim X as Integer
			Dim TextLabel as System.Web.UI.WebControls.Label = New System.Web.UI.WebControls.Label
			
			Dim myUC As Control
			Dim ucType as System.Type
			Dim ucValue as PropertyInfo
			Dim P as ASPEnterpriseManager.Permission
			Dim Permissions as HashTable = New HashTable 
			
			For X = 0 to Repeater1.Items.Count - 1
				P = New ASPEnterpriseManager.Permission
			
				TextLabel = Repeater1.items(X).FindControl("ObjectName")
				P.ObjectName = TextLabel.Text
				
				TextLabel = Repeater1.items(X).FindControl("ObjectType")
				P.ObjectType = TextLabel.Text
				
				MyUC = Repeater1.Items(X).FindControl("Select")
				ucType = myUC.GetType()
				ucValue = ucType.GetProperty("Value")
				P.PSelect = ucValue.GetValue(MyUC, Nothing)
				
				MyUC = Repeater1.Items(X).FindControl("Insert")
				P.PInsert = ucValue.GetValue(MyUC, Nothing)
				
				MyUC = Repeater1.Items(X).FindControl("Update")
				P.PUpdate = ucValue.GetValue(MyUC, Nothing)
				
				MyUC = Repeater1.Items(X).FindControl("Delete")
				P.PDelete = ucValue.GetValue(MyUC, Nothing)
				
				MyUC = Repeater1.Items(X).FindControl("Exec")
				P.PExec = ucValue.GetValue(MyUC, Nothing)
				
				MyUC = Repeater1.Items(X).FindControl("Dri")
				P.PDri = ucValue.GetValue(MyUC, Nothing)
				
				Permissions.Add (P.ObjectName, P)
				UserName.Text = UserName.Text & P.PSelect & "*"
			Next 
			
			Return (Permissions)
		
		End Function
		
	End Class
End Namespace