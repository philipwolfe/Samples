<%@ Page Language="C#" CodeFile="BindMenuToSiteMap.aspx.cs" Inherits="BindMenuToSiteMap_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Binding a Menu to a SiteMapDataSource Control</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
    <table border="0" cellpadding="5" cellspacing="0">
        <tr>
            <td valign="top">
                <!--
                The Menu below is created by binding to the SiteMapDataSource control (below), which is
                done by setting the Menu's datasourceid attribute value to the id of the SiteMapDataSource
                control you wish to use.
                -->
                <asp:menu id="Menu"
                    datasourceid="SiteMapDataSource1"
                    disappearafter="500"
                    staticdisplaylevels="2"
                    staticsubmenuindent="20" 
                    orientation="Vertical"
                    font-names="Trebuchet MS, Arial" 
                    DynamicMenuItemStyle-Width="150"
                    Width="150"
                    runat="server">
                    
                    <staticmenuitemstyle backcolor="RoyalBlue" forecolor="WhiteSmoke" horizontalpadding="5" verticalpadding="2" />
                    <statichoverstyle backcolor="CornflowerBlue" forecolor="White" borderstyle="Solid" borderwidth="1px" />
                    <dynamicmenuitemstyle backcolor="RoyalBlue" forecolor="WhiteSmoke" horizontalpadding="5" verticalpadding="2" />
                    <dynamichoverstyle backcolor="CornflowerBlue" forecolor="White" borderstyle="Solid" borderwidth="1px" />
                </asp:menu>
            </td>
            <td valign="top">
                <h1>Binding a Menu to a SiteMapDataSource Control</h1>
                
                <p>This page demonstrates how to create a menu for your site based on a SiteMapDataSource
                control, which by default reads in the contents of the web.sitemap file (as it does in
                this sample). Notice that the layout and behavior of the menu is equivalent to that found
                in the <a href="DeclarativeMenu.aspx">declarative menu</a> example. The only difference 
                is that the menu data for this page is from the web.sitemap file.</p>
                
                <p>As with the declarative example, if you do not specify a value for the url attribute
                in the web.sitemap &lt;siteMapNode&gt; element, its corresponding menu item will
                perform a post back to the server instead of transferring you to a URL.</p>
            </td>
        </tr>
    </table>

    <asp:sitemapdatasource id="SiteMapDataSource1" runat="server" />
        
    </div>

    </form>
</body>
</html>
