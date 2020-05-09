Imports System.Web
Imports ASPEnterpriseManager
Imports Microsoft.VisualBasic
Imports System.Web.UI.WebControls



Namespace ASPEnterpriseManager.Pages
	Public Class Tables_Design
		Inherits ASPEnterpriseManager.Page
		Protected WithEvents Repeater1 As System.Web.UI.WebControls.Repeater
		Protected ColumnsToAdd As System.Web.UI.WebControls.Textbox
		Protected TableName As System.Web.UI.HTMLControls.HTMLInputText
		
		
		Sub Page_Load(Sender As System.Object, E As System.EventArgs) 
			If not Page.IsPostBack Then
				Dim Table as ASPEnterpriseManager.Table  = New ASPEnterpriseManager.Table
				If request("NewTable") = "true" Then Session("Table") = Nothing
				If not Session("Table") is Nothing Then
					Table = Session("Table")
					TableName.Value = Table.Name
				Else
					Table.AddColumns(5)	
				End If
				Repeater1.DataSource = Table.Columns
			   Repeater1.DataBind()			
			End If
		End Sub
	
		
	
	' ************* HANDLER FOR REPEATER INSERT BUTTONS *****************************
		 Sub R1_ItemCommand(Sender As Object, e As RepeaterCommandEventArgs)
		   Dim Table as ASPEnterpriseManager.Table = New ASPEnterpriseManager.Table
		   Dim NewTable as ASPEnterpriseManager.Table = New ASPEnterpriseManager.Table
			Table = Session("Table")
			NewTable = LoadTableFromForm()
		 	Table.InsertColumn(Repeater1.Items(e.Item.ItemIndex).ItemIndex)
		 	NewTable.InsertColumn(Repeater1.Items(e.Item.ItemIndex).ItemIndex)
		 	TableName.Value = NewTable.Name
	    	Repeater1.DataSource = NewTable.Columns
			Repeater1.DataBind()
	    End Sub
	  
	  
	  
	' ******************* COMMAND BUTTON EVENTS *************************************  
	  	Sub Save_Click(Source As System.Object, e As System.EventArgs)
	  		Dim NewTable as ASPEnterpriseManager.Table = New ASPEnterpriseManager.Table
  			NewTable = LoadTableFromForm()
	  		If not Session("Table") Is Nothing Then
	  			Dim Table as ASPEnterpriseManager.Table = New ASPEnterpriseManager.Table
	  			Table = Session("Table")
	  			Table.ConvertTo (NewTable)
	  		Else
	  			NewTable.Create (NewTable.Name)
	  		End If  			
	  		Response.redirect("tables_properties.aspx?Table=" & TableName.Value & "&sync=true")
	  	End Sub
	
	
	  	Sub AddColumns_Click(Source As System.Object, e As System.EventArgs)
			Dim NewTable as ASPEnterpriseManager.Table = New ASPEnterpriseManager.Table
  			NewTable = LoadTableFromForm()
	  		If not Session("Table") Is Nothing Then
	  			Dim Table as ASPEnterpriseManager.Table = New ASPEnterpriseManager.Table
	  			Table = Session("Table")
	  			Table.AddColumns (ColumnsToAdd.Text)
	  			NewTable.AddColumns (ColumnsToAdd.Text)
	  		Else
	  			NewTable.AddColumns (ColumnsToAdd.Text)
	  		End If  			
			Repeater1.DataSource = NewTable.Columns
			Repeater1.DataBind()
		End Sub
		
		
		
		
	' *************** BUILD A TABLE FROM THE FORM ************************************	  
	  	Function LoadTableFromForm() as ASPEnterpriseManager.Table
	  		Dim X as Integer
	  		Dim Name as String
	  		Dim Type as String
	  		Dim Length as Integer
	  		Dim Precision as Integer
	  		Dim Scale as Integer
	  		Dim Nulls as Boolean
	  		Dim Key as Boolean
	  		Dim DefaultValue as String
	  		Dim Identity as Boolean
	  		Dim Seed as Integer
	  		Dim Increment as Integer
	  		Dim NewTable as ASPEnterpriseManager.Table = New ASPEnterpriseManager.Table
	  		NewTable.Name = TableName.Value
	  		Dim TB as System.Web.UI.HTMLControls.HTMLInputText = New System.Web.UI.HTMLControls.HTMLInputText
	  		Dim SB as System.Web.UI.WebControls.DropDownList = New System.Web.UI.WebControls.DropDownList
	  		Dim CB as System.Web.UI.WebControls.CheckBox = New System.Web.UI.WebControls.CheckBox
	  		For X = 0 to Repeater1.Items.Count - 1
	  			CB = Repeater1.items(X).FindControl("Key")
	  			Key = IIf(CB.Checked.ToString() = "True", true, false) 
	  			
	  			TB = Repeater1.items(X).FindControl("Name")
	  			Name = TB.Value
	  			
	  			SB = Repeater1.items(X).FindControl("Type")
	  			Type = SB.SelectedItem.Text
	  			
	  			TB = Repeater1.items(X).FindControl("Length")
	  			Length = IIf(TB.Value="", 0, TB.Value) 
	  			
	  			TB = Repeater1.items(X).FindControl("Precision")
	  			Precision = IIf(TB.Value="", 0, TB.Value) 
	  			
	  			TB = Repeater1.items(X).FindControl("Scale")
	  			Scale = IIf(TB.Value="", 0, TB.Value) 
	  			
	  			CB = Repeater1.items(X).FindControl("Nulls")
	  			Nulls = IIf(CB.Checked.ToString() = "True", true, false) 
	  			
	  			TB = Repeater1.items(X).FindControl("DefaultValue")
	  			DefaultValue = TB.Value 
	  			
				CB = Repeater1.items(X).FindControl("Identity")
	  			Identity = IIf(CB.Checked.ToString() = "True", true, false) 
	  			
	  			TB = Repeater1.items(X).FindControl("Seed")
	  			Seed = IIf(TB.Value="", 0, TB.Value) 
	  			
	  			TB = Repeater1.items(X).FindControl("Increment")
	  			Increment = IIf(TB.Value="", 0, TB.Value) 
	  			
	  			NewTable.CreateColumn(Key, Name, Type, Length, Precision, Scale, Nulls, DefaultValue, Identity, Seed, Increment)
	  		Next
	  		LoadTableFromForm = NewTable
		End Function
	
	End Class
End Namespace