<%@ Page language="c#" Codebehind="Report.aspx.cs" AutoEventWireup="True" Inherits="AppRestart.Report" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Report</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 2px; POSITION: absolute; TOP: 265px" runat="server"
				Width="888px" Height="223px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White"
				CellPadding="4">
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:DataGrid>
            <div style="text-align: left">
                <table>
                    <tr>
                        <td align="left" style="width: 100px; background-color: #99ffff">
                            AppName</td>
                        <td align="left" style="width: 473px; background-color: #99ffff">
                            <asp:TextBox ID="txtAppName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100px; background-color: #99ffff">
                            Begin Date</td>
                        <td align="left" style="width: 473px; background-color: #99ffff">
                            &nbsp;<asp:TextBox ID="dtBeginDate" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100px; background-color: #99ffff; height: 25px;">
                            End Date</td>
                        <td align="left" style="width: 473px; background-color: #99ffff; height: 25px;">
                            &nbsp;<asp:TextBox ID="dtEndDate" runat="server"></asp:TextBox></td>
                    </tr>
                    
                    <tr>
                        <td align="left" style="width: 100px; background-color: #99ffff">
                            Message</td>
                        <td align="left" style="width: 473px; background-color: #99ffff">
                            <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100px; background-color: #99ffff">
                            Target Site</td>
                        <td align="left" style="width: 473px; background-color: #99ffff">
                            <asp:TextBox ID="txtTargetSite" runat="server"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td align="left" style="width: 100px; background-color: #99ffff">
                            Stack Trace</td>
                        <td align="left" style="width: 473px; background-color: #99ffff">
                            <asp:TextBox ID="txtStackTrace" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100px; background-color: #99ffff">
                            Referer</td>
                        <td align="left" style="width: 473px; background-color: #99ffff">
                            <asp:TextBox ID="txtReferer" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="Button2"
                                runat="server" OnClick="Button2_Click" Text="Show Provider Events" />&nbsp;<asp:Button
                                    ID="Button3" runat="server" OnClick="Button3_Click" Text="Truncate Events" Width="117px" /></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100px; background-color: #99ffff">
                            Path</td>
                        <td align="left" style="width: 473px; background-color: #99ffff">
                            <asp:TextBox ID="txtPath" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="Button1"
                                runat="server" OnClick="Button1_Click" Text="Search!" />&nbsp;<asp:Button ID="btnException"
                                    runat="server" OnClick="btnException_Click" Text="Test Exception" />
                            <asp:Button ID="btnTruncate" runat="server" OnClick="btnTruncate_Click" Text="Truncate Log" Width="108px" /></td>
                    </tr>
                </table>
                <br />
            </div>
        </form>
	</body>
</HTML>
