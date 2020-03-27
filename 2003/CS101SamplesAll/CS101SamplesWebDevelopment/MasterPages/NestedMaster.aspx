<%@ Page Language="C#" masterpagefile="~/NestedMasterChild.master" CodeFile="NestedMaster.aspx.cs" Inherits="NestedMaster_aspx" Title="Nested Master Pages" %>
<asp:content id="ContentTitle" contentplaceholderid="ContentTitle" runat="Server">

<h1>Nested Master Pages</h1>
<p><a href="start.aspx">Return to Start Page</a></p>

<h3>Content Title</h3>
</asp:content>

<asp:content id="ContentText" contentplaceholderid="ContentText" runat="Server">
<p>This page uses nested master pages: a parent master to control the overall site layout and a child
master control to handle the actual content of the page. Notice the parent master page contains the
site header, footer, and left navigation, while the child master control contains an area for the content
title, the actual text/forms/images/etc of the content, and a navigation area specific to the page.</p>
</asp:content>

<asp:content id="ContentNav" contentplaceholderid="ContentNav" runat="Server">
<p>This box would contain content-specifc navigational elements, tasks, or other related items.</p>
</asp:content>