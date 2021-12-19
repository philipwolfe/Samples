<%@ Register TagPrefix="UserControlSample" TagName="PairedListBox" Src="PairedListBox.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.vb" Inherits="UserControlSample.WebForm1"%>
<html><head>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0"></head>
  <body>
<h1>Demo page for PairedListBox user control</h1>
<p>All controls below are encapsulated in a single user control</p>
    <form id="WebForm1" method="post" runat="server">
    <!-- -->
<UserControlSample:PairedListBox id="AvailableSelected" runat="server"></UserControlSample:PairedListBox>
    </form>

  </body></html>
