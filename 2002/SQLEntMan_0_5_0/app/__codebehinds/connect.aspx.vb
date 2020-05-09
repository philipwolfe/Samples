Imports System.Web
Imports ASPEnterpriseManager

Namespace ASPEnterpriseManager.Pages

		Public Class Connect
				Inherits System.Web.UI.Page
				Protected WithEvents DataSource As System.Web.UI.HtmlControls.HTMLInputText
				Protected WithEvents UID As System.Web.UI.HtmlControls.HTMLInputText
				Protected WithEvents PWD As System.Web.UI.HtmlControls.HTMLInputText
				
				Sub Page_Load(Sender As System.Object, E As System.EventArgs) 
					Dim _Context as HTTPContext = HTTPContext.Current
					if Page.IsPostBack then
						With _Context.Session.StaticObjects("ConnectionString")
							.DataSource = DataSource.Value
							.UID = UID.Value
							.PWD = PWD.Value
						End With
						Response.redirect ("default.aspx")
					Else
						With _Context.Session.StaticObjects("ConnectionString")
							DataSource.Value = "localhost" '.DataSource
							UID.Value = "test"  '.UID 
							PWD.Value = "test"  '.PWD
							.Clear
						End With
					end If
				End Sub
		End Class	


End Namespace	