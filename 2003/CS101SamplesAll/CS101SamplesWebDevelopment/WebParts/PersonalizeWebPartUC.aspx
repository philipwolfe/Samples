<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalizeWebPartUC.aspx.cs" Inherits="PersonalizeWebPartUC_aspx" %>
<%@ Register TagPrefix="uc1" TagName="CallCenterRepUC" Src="~/CallCenterRepUserControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Personalizing Web Parts with a User Control</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Personalizing Web Parts with a User Control</h1>
    <p><a href="start.aspx">Return to Start Page</a></p>
    
    <p>This page provides a standard form for fictitious call center agents to use in their daily
    activities, thus providing for personalization of standard agent data for each call center
    representative. Personalization is achieved by putting a user control inside a WebPartZone control
    and then applying the [Personalization] attribute to each form data element (as properties in the
    code-behind).</p>
    
    <p>Simply fill in the form data and click the Save button. All subsequent visits for each user
    will display their own data.</p>
    
    <asp:webpartmanager id="WebPartManager1" runat="server" />
    <asp:webpartzone id="zone1" runat="server" headertext="Main" BorderColor="#CCCCCC" Font-Names="Verdana" Padding="6">
        <zonetemplate>
            <uc1:CallCenterRepUC runat="server" id="CallCenterWebPart" Name="Call Center Agent Information" />
        </zonetemplate>
        <PartChromeStyle BackColor="#EFF3FB" BorderColor="#D1DDF1" Font-Names="Verdana" ForeColor="#333333" />
        <MenuLabelHoverStyle ForeColor="#D1DDF1" />
        <EmptyZoneTextStyle Font-Size="0.8em" />
        <MenuLabelStyle ForeColor="White" />
        <MenuVerbHoverStyle BackColor="#EFF3FB" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" />
        <HeaderStyle Font-Size="0.7em" ForeColor="#CCCCCC" HorizontalAlign="Center" />
        <MenuVerbStyle BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
        <PartStyle Font-Size="0.8em" ForeColor="#333333" />
        <TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White" />
        <MenuPopupStyle BackColor="#507CD1" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.6em" />
        <PartTitleStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
    </asp:webpartzone>

    </div>
    </form>
</body>
</html>
