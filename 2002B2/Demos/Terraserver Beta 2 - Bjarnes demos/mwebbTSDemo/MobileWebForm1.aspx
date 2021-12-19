<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MobileWebForm1.aspx.vb" Inherits="mwebbTSDemo.MobileWebForm1" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
<meta content="Mobile Web Page" name="vs_targetSchema">
<body xmlns:mobile="Mobile Web Form Controls">
	<mobile:form id="Form1" title="TerraServer Demo" runat="server">
		<mobile:Image id="imgLogo" runat="server" ImageURL="images/bnrWindowsNgws1_sm.gif"></mobile:Image>
		<mobile:Label id="Label1" runat="server" StyleReference="title" Font-Bold="True" Font-Size="Large" Font-Name="Verdana">TerraServer Demo</mobile:Label>
		<mobile:Label id="lblPU" runat="server" Font-Bold="False" Font-Size="Normal" Font-Name="Verdana">Political Unit</mobile:Label>
		<mobile:SelectionList id="slPU" runat="server" Font-Size="Normal" Font-Name="Verdana">
			<Item Value="County" Text="County"></Item>
			<Item Value="City" Text="City"></Item>
			<Item Value="State" Text="State"></Item>
			<Item Value="CensusTract" Text="CensusTract"></Item>
		</mobile:SelectionList>
		<mobile:Label id="Label2" runat="server" Font-Bold="False" Font-Size="Normal" Font-Name="Verdana">Year</mobile:Label>
		<mobile:TextBox id="txtYear" runat="server" Font-Size="Normal" Font-Name="Verdana">1990</mobile:TextBox>
		<mobile:Label id="lblResultLabel" runat="server" Font-Bold="False" Font-Size="Normal" Font-Name="Verdana">Result</mobile:Label>
		<mobile:Label id="lblResult" runat="server" Font-Bold="True" Font-Size="Large" Font-Name="Verdana" Wrapping="Wrap"></mobile:Label>
		<mobile:Panel id="Panel1" runat="server"></mobile:Panel>
		<mobile:Command id="btnCheck" runat="server" Font-Name="Verdana" SoftkeyLabel="Check">Check</mobile:Command>
	</mobile:form>
</body>
