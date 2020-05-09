Imports System.Web
Imports System.Data
Imports System.Web.UI
Imports ASPEnterpriseManager
Imports System.Data.SQLClient
Imports System.Web.UI.WebControls

Public Class Table_Properties
	Inherits ASPEnterpriseManager.Page
	Protected WithEvents TableOwner As System.Web.UI.WebControls.Label
	Protected WithEvents DateCreated As System.Web.UI.WebControls.Label
	Protected WithEvents DropTable As System.Web.UI.WebControls.ImageButton
	Protected WithEvents Repeater1 As System.Web.UI.WebControls.Repeater
	
	Sub Page_Load(Sender As System.Object, E As System.EventArgs) 
		Dim _Context as HTTPContext = HTTPContext.Current
		If not Page.IsPostBack Then
			DropTable.Attributes("onclick") = "javascript: return confirm (""Are you sure you want to delelte this table?"");"
			Dim Table as New ASPEnterpriseManager.Table
			Table.Load(_Context.Request("Table"))
			TableOwner.Text = Table.Owner
			DateCreated.Text = Table.DateCreated
			_Context.Session("Table") = Table
			Repeater1.DataSource = Table.Columns
			Repeater1.DataBind()	
			Dim Item	
			For Each Item in Repeater1.Items
				Dim Button as System.Web.UI.WebControls.ImageButton = New System.Web.UI.WebControls.ImageButton
				Button = Item.FindControl("Drop")
				Button.Attributes("onclick") = "javascript: return confirm (""Are you sure you want to delelte this field?"");"
			Next
		End If
	End Sub

	
	Sub DropTable_Click(Source As System.Object, e As System.Web.UI.ImageClickEventArgs)
		Dim _Context as HTTPContext = HTTPContext.Current
		_Context.Session("Database").DropTable (session("Table").Name)
   End Sub
   
   Sub InsertData_Click(Source As System.Object, e As System.Web.UI.ImageClickEventArgs)
		Dim _Context as HTTPContext = HTTPContext.Current
		_Context.Response.redirect ("tables_insert.aspx?table=" & Session("Table").Name)
   End Sub
   
   Sub DesignTable_Click(Source As System.Object, e As System.Web.UI.ImageClickEventArgs)
		Dim _Context as HTTPContext = HTTPContext.Current
		_Context.Response.redirect ("tables_design.aspx?table=" & Session("Table").Name)
   End Sub
   
   Sub QueryTable_Click(Source As System.Object, e As System.Web.UI.ImageClickEventArgs)
		Dim _Context as HTTPContext = HTTPContext.Current
		_Context.Response.redirect ("query.aspx?table=" & Session("Table").Name)
   End Sub
   
   Sub R1_ItemCommand(Sender As Object, e As RepeaterCommandEventArgs)		
		Dim _Context as HTTPContext = HTTPContext.Current
		Dim Table as ASPEnterpriseManager.Table = New ASPEnterpriseManager.Table
		Table = _Context.Session("Table")
		Dim Row as Integer = Repeater1.Items(e.Item.ItemIndex).ItemIndex
		Table.DropColumn (Table.Columns(Row).Name) 
		_Context.Response.redirect ("tables_properties.aspx?Table=" & Table.Name)
	End Sub
	  
End Class