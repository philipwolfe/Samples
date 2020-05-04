<script Language="VB" runat="server">

	Public Sub Page_Load(Source As Object, E As EventArgs)
	
		response.write("Hello " & Request("txtRequest").ToString() & ", welcome to the world of AJAX!" )
		
	End Sub
	
	
</script>

