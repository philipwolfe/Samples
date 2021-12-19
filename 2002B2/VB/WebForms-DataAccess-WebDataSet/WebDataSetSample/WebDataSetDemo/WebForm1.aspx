<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.vb" Inherits="WebDataSetDemo.WebForm1"%>
<html><head>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0"></head>
  <body>

    <form id="WebForm1" method="post" runat="server">
<p align=center><strong><font size=5>Web Form Data Access</font></strong></p>
<p>
<asp:Button id=btnLoadDSList runat="server" Text="Load DataSet Column into List Box"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button id=btnLoadDRList runat="server" Text="Load DataReader Column into List Box"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:Button id=btnLoadDSGrid runat="server" Text="Load DataSet into Data Grid"></asp:Button></p>
<p><strong>Company Name From Customers Table</strong></p>
<p>
<asp:ListBox id=ListBox runat="server" Width="304" Height="304"></asp:ListBox></p>
<p>
<asp:DataGrid id=DataGrid runat="server" ForeColor="Black">

	<ItemStyle BackColor="Gainsboro">
	</ItemStyle>

	<FooterStyle ForeColor="White" BackColor="Silver">
	</FooterStyle>

	<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Navy">
	</HeaderStyle>

</asp:DataGrid></p>
<p>&nbsp;</p>


    </form>

  </body></html>
