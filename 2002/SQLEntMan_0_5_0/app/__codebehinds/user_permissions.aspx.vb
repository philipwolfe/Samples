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
			
			CurPermissions.Update (NewPermissions)
			
			Response.redirect ("users_edit.aspx?loginName=" & UserName.Text)
			
		End Sub
		
		
		' ************* HANDLER FOR REPEATER INSERT BUTTONS *****************************
		 Sub R1_ItemCommand(Sender As Object, e As RepeaterCommandEventArgs)
			 	Dim IURL as String = CType(e.CommandSource, ImageButton).ImageURL
			 	Select Case LCase(IURL):
			 		Case "__controls/tristate_unchecked.gif": CType(e.CommandSource, ImageButton).ImageURL = "__Controls/tristate_checked.gif"
			 		Case "__controls/tristate_checked.gif": CType(e.CommandSource, ImageButton).ImageURL = "__Controls/tristate_redx.gif"
			 		Case Else: CType(e.CommandSource, ImageButton).ImageURL = "__Controls/tristate_unchecked.gif"	
			 	End Select
			 
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
				
				Dim IURL as String = CType(Repeater1.Items(X).FindControl("Select"), ImageButton).ImageURL
				Select Case LCase(IURL)
					Case "__controls/tristate_checked.gif": P.PSelect = "GRANT"
			 		Case "__controls/tristate_redx.gif": P.PSelect = "DENY"
			 		Case Else: P.PSelect = ""	
			 	End Select
			 	
				IURL = CType(Repeater1.Items(X).FindControl("Insert"), ImageButton).ImageURL
				Select Case LCase(IURL)
					Case "__controls/tristate_checked.gif": P.PInsert = "GRANT"
			 		Case "__controls/tristate_redx.gif": P.PInsert = "DENY"
			 		Case Else: P.PInsert = ""	
			 	End Select
				
				IURL = CType(Repeater1.Items(X).FindControl("Update"), ImageButton).ImageURL
				Select Case LCase(IURL)
					Case "__controls/tristate_checked.gif": P.PUpdate = "GRANT"
			 		Case "__controls/tristate_redx.gif": P.PUpdate = "DENY"
			 		Case Else: P.PUpdate = ""	
			 	End Select
			 	
				IURL = CType(Repeater1.Items(X).FindControl("Delete"), ImageButton).ImageURL
				Select Case LCase(IURL)
					Case "__controls/tristate_checked.gif": P.PDelete = "GRANT"
			 		Case "__controls/tristate_redx.gif": P.PDelete = "DENY"
			 		Case Else: P.PDelete = ""	
			 	End Select
			 	
				IURL = CType(Repeater1.Items(X).FindControl("Exec"), ImageButton).ImageURL
				Select Case LCase(IURL)
					Case "__controls/tristate_checked.gif": P.PExec = "GRANT"
			 		Case "__controls/tristate_redx.gif": P.PExec = "DENY"
			 		Case Else: P.PExec = ""	
			 	End Select
				
				IURL = CType(Repeater1.Items(X).FindControl("Dri"), ImageButton).ImageURL
				Select Case LCase(IURL)
					Case "__controls/tristate_checked.gif": P.PDri = "GRANT"
			 		Case "__controls/tristate_redx.gif": P.PDri = "DENY"
			 		Case Else: P.PDri = ""	
			 	End Select
				
				Permissions.Add (P.ObjectName, P)
				' UserName.Text = UserName.Text & P.PSelect & "*"
			Next 
			
			Return (Permissions)
		
		End Function
		
	End Class
End Namespace