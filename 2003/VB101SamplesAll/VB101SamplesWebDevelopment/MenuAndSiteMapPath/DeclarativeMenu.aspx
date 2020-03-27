<%@ Page Language="VB" CodeFile="DeclarativeMenu.aspx.vb" Inherits="DeclarativeMenu_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Creating a Menu Declaratively</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="5" cellspacing="0">
        <tr>
            <td valign="top">
                <!--
                The Menu below is created using declarative syntax. You create menus and
                submenus by using the MenuItem control within the Menu control. To create
                submenus, simply nest MenuItem controls in other MenuItem controls.
                -->
                <asp:menu id="Menu"
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

                    <items>
                        <asp:menuitem text="Home" tooltip="Home" value="Home">
                            <asp:menuitem navigateurl="/MenuAndSiteMapPath/start.aspx" text="Start Page" value="Start Page" tooltip="Start Page" />
                            <asp:menuitem text="Sports" tooltip="Sports" value="Sports">
                                <asp:menuitem text="Baseball" tooltip="Baseball" value="Baseball">
                                    <asp:menuitem text="Major League" tooltip="Major League" value="Major League" />
                                    <asp:menuitem text="Minor League" tooltip="Minor League" value="Minor League" />
                                </asp:menuitem>
                                <asp:menuitem text="Basketball" tooltip="Basketball" value="Basketball" />
                                <asp:menuitem text="Football" tooltip="Football" value="Football">
                                    <asp:menuitem text="NFL" tooltip="NFL" value="NFL" />
                                    <asp:menuitem text="USFL" tooltip="USFL" value="USFL" />
                                </asp:menuitem>
                                <asp:menuitem text="Hockey" tooltip="Hockey" value="Hockey" />
                            </asp:menuitem>
                            <asp:menuitem text="Search Engines" tooltip="Search Engines" value="Search Engines">
                                <asp:menuitem text="Google" tooltip="Google" value="Google" navigateurl="http://www.google.com/" />
                                <asp:menuitem text="Yahoo" tooltip="Yahoo" value="Yahoo" navigateurl="http://www.yahoo.com/" />
                                <asp:menuitem text="MSN Search" tooltip="MSN Search" value="MSN Search" navigateurl="http://search.msn.com/" />
                            </asp:menuitem>
                        </asp:menuitem>
                    </items>
                </asp:menu>
            </td>
            <td valign="top">
                <h1>Creating a Menu Declaratively</h1>
                
                <p>This page shows how to declaratively create a menu on your Web page. In this example, both
                dynamic and static menu items are used; dynamic menus are the submenus that pop out when you
                hover over a static menu item.</p>
                
                <p>Each menu item in the menu has an attribute named navigateUrl. If you give this attribute
                a value, then when you click on an item in the menu, you will be transferred to the URL you
                specified. If the navaigateUrl attribute is ommitted, the menu creates a post back to the
                server.</p>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
