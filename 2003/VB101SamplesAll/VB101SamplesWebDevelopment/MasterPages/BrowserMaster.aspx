<%@ Page Language="VB" MasterPageFile="~/BrowserMasterDefault.master" Opera:masterpagefile="~/BrowserMasterOpera.master" CodeFile="BrowserMaster.aspx.vb" Inherits="BrowserMaster_aspx" Title="Browser-Specific Master Pages" %>
<asp:content contentplaceholderid="PageContent" runat="Server">

<h3>Content Area</h3>

<p>This page shows how to use browser-specific master pages. This page was setup to have a default master
page and a master page for the Opera browser. To see the default master page in use, open this page with
a browser other than Opera, such as Internet Explorer or Firefox. To see the Opera master page in use, open
this page with the Opera browser.</p>

<p>For the default master page, the site navigation is on the left side of the page. The Opera master page
has the site navigation on the right side of the page.</p>
</asp:content>