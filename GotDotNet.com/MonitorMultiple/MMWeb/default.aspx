<%@ Page language="c#" AutoEventWireup="false" Inherits="System.Web.UI.Page" %>

<script runat=server>
	override protected void OnInit(EventArgs e)
	{
		int i = 0;
		if(Session["counter"] != null)
			i = (int)Session["counter"];
			
		lblSession.Text = (i++).ToString();		
		
		Session["counter"] = i;
	}
</script>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>default</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			Testing, : <asp:Label Runat=server ID=lblSession />
		</form>
	</body>
</HTML>
