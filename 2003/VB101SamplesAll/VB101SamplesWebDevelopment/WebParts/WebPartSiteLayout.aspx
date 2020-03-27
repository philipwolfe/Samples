<%@ Page Language="VB" AutoEventWireup="true" CodeFile="WebPartSiteLayout.aspx.vb" Inherits="WebPartSiteLayout_aspx" %>
<%@ Register Src="SearchUserControl.ascx" TagName="SearchUserControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Using and Customizing WebPartZone Controls for Site Layout</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Using and Customizing WebPartZone Controls for Site Layout</h1>
    <p><a href="start.aspx">Return to Start Page</a></p>
    
        <asp:WebPartManager ID="WebPartManager1" runat="server">
        </asp:WebPartManager>
    
    </div>
        <table>
            <tr>
                <td style="width: 150px" valign="top">
                    <asp:WebPartZone BorderColor="#CCCCCC" Font-Names="Verdana" HeaderText="Left Sidebar" ID="LeftSidebarZone" Padding="6" Height="150px" Width="150px" runat="server">
                        <PartChromeStyle BackColor="#E3EAEB" BorderColor="#C5BBAF" Font-Names="Verdana" ForeColor="#333333" />
                        <MenuLabelHoverStyle ForeColor="Yellow" />
                        <EmptyZoneTextStyle Font-Size="0.8em" />
                        <MenuLabelStyle ForeColor="#333333" />
                        <MenuVerbHoverStyle BackColor="#E3EAEB" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" />
                        <HeaderStyle Font-Size="0.7em" ForeColor="#CCCCCC" HorizontalAlign="Center" />
                        <ZoneTemplate>
                            <asp:Label ID="Label1" runat="server" Name="My Links">
                                <a href="http://www.asp.net">ASP.NET</a><br />
                                <a href="http://www.gotdotnet.com">GotDotNet</a><br />
                                <a href="http://www.theserverside.net">TheServerSide</a>
                            </asp:Label>
                        </ZoneTemplate>
                        <MenuVerbStyle BorderColor="#1C5E55" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
                        <PartStyle Font-Size="0.8em" ForeColor="#333333" />
                        <TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White" />
                        <MenuPopupStyle BackColor="#1C5E55" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.6em" />
                        <PartTitleStyle BackColor="#1C5E55" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
                    </asp:WebPartZone>
                </td>
                <td style="width: 450px" valign="top">
                    <asp:WebPartZone BorderColor="#CCCCCC" Font-Names="Verdana" HeaderText="Main" ID="MainZone" Padding="6" runat="server" Height="150px" Width="450px">
                        <PartChromeStyle BackColor="#FFFBD6" BorderColor="#FFCC66" Font-Names="Verdana" ForeColor="#333333" />
                        <MenuLabelHoverStyle ForeColor="#FFCC66" />
                        <EmptyZoneTextStyle Font-Size="0.8em" />
                        <MenuLabelStyle ForeColor="White" />
                        <MenuVerbHoverStyle BackColor="#FFFBD6" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" />
                        <HeaderStyle Font-Size="0.7em" ForeColor="#CCCCCC" HorizontalAlign="Center" />
                        <ZoneTemplate>
                            <asp:Label ID="Label2" runat="server" Name="Content"><h3>This is the MainZone web part.</h3></asp:Label>
                        </ZoneTemplate>
                        <MenuVerbStyle BorderColor="#990000" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
                        <PartStyle Font-Size="0.8em" ForeColor="#333333" />
                        <TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White" />
                        <MenuPopupStyle BackColor="#990000" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.6em" />
                        <PartTitleStyle BackColor="#990000" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
                    </asp:WebPartZone>
                </td>
                <td style="width: 150px" valign="top">
                    <asp:WebPartZone BorderColor="#CCCCCC" Font-Names="Verdana" HeaderText="Right Sidebar" ID="RightSidebarZone" Padding="6" Height="150px" Width="150px" runat="server">
                        <PartChromeStyle BackColor="#EFF3FB" BorderColor="#D1DDF1" Font-Names="Verdana" ForeColor="#333333" />
                        <MenuLabelHoverStyle ForeColor="#D1DDF1" />
                        <EmptyZoneTextStyle Font-Size="0.8em" />
                        <MenuLabelStyle ForeColor="White" />
                        <MenuVerbHoverStyle BackColor="#EFF3FB" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" />
                        <HeaderStyle Font-Size="0.7em" ForeColor="#CCCCCC" HorizontalAlign="Center" />
                        <ZoneTemplate>
                            <uc1:SearchUserControl ID="SearchUserControl1" runat="server" />
                        </ZoneTemplate>
                        <MenuVerbStyle BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
                        <PartStyle Font-Size="0.8em" ForeColor="#333333" />
                        <TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White" />
                        <MenuPopupStyle BackColor="#507CD1" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.6em" />
                        <PartTitleStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
                    </asp:WebPartZone>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
