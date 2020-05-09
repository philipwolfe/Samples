Imports System.Web
Imports ASPEnterpriseManager

Namespace ASPEnterpriseManager.Pages

		Public Class DatabaseProperties
				Inherits ASPEnterpriseManager.Page
				Protected WithEvents DBName As System.Web.UI.WebControls.Label
				Protected WithEvents Owner As System.Web.UI.WebControls.Label
				Protected WithEvents DateCreated As System.Web.UI.WebControls.Label
				Protected WithEvents DatabaseSize As System.Web.UI.WebControls.Label
				Protected WithEvents MaximumSize As System.Web.UI.WebControls.Label
				Protected WithEvents FileSize As System.Web.UI.WebControls.Label
				
				Sub Page_Load(Sender As System.Object, E As System.EventArgs) 
					Dim _Context as HTTPContext = HTTPContext.Current
					if not Page.IsPostBack then
						Dim DB as ASPEnterpriseManager.DatabaseInfo = New DatabaseInfo
						DB.Load (_Context.Session.StaticObjects("ConnectionString").InitialCatalog)
						DBName.Text = _Context.Session.StaticObjects("ConnectionString").InitialCatalog
						Owner.Text = DB.Owner
						DateCreated.Text = DB.DateCreated
						DatabaseSize.Text = DB.DatabaseSize
						MaximumSize.Text = DB.MaximumSize
						FileSize.Text = DB.FileSize
					end If
				End Sub
		End Class	


End Namespace	