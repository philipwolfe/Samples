Imports System.Web
Imports System.Web.UI
Imports System.Collections
Imports ASPEnterpriseManager
Imports Microsoft.VisualBasic

Namespace ASPEnterpriseManager.Pages
	Public Class Databases_Edit
		Inherits ASPEnterpriseManager.Page
		Protected WithEvents DatabaseName As System.Web.UI.WebControls.TextBox
		
		
		Sub Save_Click (Sender As System.Object, E As System.EventArgs) 
			Dim DB as ASPEnterpriseManager.Database = New ASPEnterpriseManager.Database
			DB.Create (DatabaseName.text)
			Response.redirect ("setDatabase.aspx?sync=true")
		End Sub
		
	End Class
End Namespace