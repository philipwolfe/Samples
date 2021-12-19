<%@ Page language="c#" Codebehind="DataSetDemo.aspx.cs" AutoEventWireup="false" Inherits="WebDataSetDemo.WebForm1" %>

<HTML>
	<HEAD>
		<meta name=vs_targetSchema content="Internet Explorer 5.0">
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
	</HEAD>
	<body>
		<form id="WebForm1" method="post" runat="server">
			<p align=center>
				<strong><font size=5>Web Form Data Access</font></strong>
			</p>
			<p>
				<asp:Button id=btnLoadDSList runat="server" Text="Load DataSet Column into List Box">
				</asp:Button>
				&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Button id=btnLoadDRList runat="server" Text="Load DataReader Column into List Box">
				</asp:Button>
				&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Button id=btnLoadDSGrid runat="server" Text="Load DataSet into Data Grid">
				</asp:Button>
			</p>
			<p>
				<strong>Company Name From Customers Table</strong>
			</p>
			<p>
				<asp:ListBox id=ListBox runat="server" Width="304" Height="304" NAME="ListBox">
				</asp:ListBox>
			</p>
			<p>
				<asp:DataGrid id=DataGrid runat="server" ForeColor="Black">
					<ItemStyle BackColor="Gainsboro">
					</ItemStyle>
					<FooterStyle ForeColor="White" BackColor="Silver">
					</FooterStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Navy">
					</HeaderStyle>
				</asp:DataGrid>
			</p>
			<p>
				&nbsp;
			</p>
		</form>
	</body>
</HTML>
