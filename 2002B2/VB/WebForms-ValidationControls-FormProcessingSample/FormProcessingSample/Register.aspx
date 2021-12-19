<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Register.vb" Inherits="FormProcessingSample.Register" %>
<html><head>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0"></head>
  <body>
<h1>Register for a new account</h1>
    <form id="WebForm1" method="post" action="Confirm.aspx" runat=server>
<table cellspacing=1 width="100%" border=0>
  <tr>
    <td align="right">Name:</td>
    <td>
<input id=txtName type=text maxlength=50 size=50 
      runat="server" name=txtName></td>
    <td>
<asp:RequiredFieldValidator id=txtNameValReq runat="server" ErrorMessage="Please enter your name" controltovalidate="txtName"></asp:RequiredFieldValidator></td></tr>
  <tr>
    <td align="right">City:</td>
    <td>
<input type=text maxlength=30 id=txtCity runat="server" size=30 name=txtCity></td>
    <td>
<asp:RequiredFieldValidator id=txtCityValReq runat="server" ErrorMessage="Please enter your city" controltovalidate="txtCity"></asp:RequiredFieldValidator></td></tr>
  <tr>
    <td align="right">State:</td>
    <td>
<asp:DropDownList id=ddlState runat="server"></asp:DropDownList></td>
    <td>
<asp:RequiredFieldValidator id=ddlStateValReq runat="server" ErrorMessage="Please select your state" controltovalidate="ddlState"></asp:RequiredFieldValidator></td></tr>
  <tr>
    <td align=right>Zip Code:</td>
    <td>
<input type=text maxlength=10 size=10 id=txtZipCode runat="server" name=txtZipCode></td>
    <td>
<asp:RequiredFieldValidator id=txtZipCodeValReq runat="server" ErrorMessage="Please enter your zip code" ControlToValidate="txtZipCode" Display="Dynamic"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=txtZipCodeValReg runat="server" ErrorMessage="Please enter your zip code in the format 99999 or 99999-9999" ControlToValidate="txtZipCode" ValidationExpression="\d{5}(-\d{4})?" display="Dynamic"></asp:RegularExpressionValidator></td></tr>
  <tr>
    <td align=right>Email Address:</td>
    <td>
<input type=text maxlength=50 size=50 id=txtEmail runat="server" name=txtEmail></td>
    <td>
<asp:RequiredFieldValidator id=txtEmailValReq runat="server" ErrorMessage="Please enter your email address" ControlToValidate="txtEmail" display="Dynamic"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=txtEmailValReg runat="server" ErrorMessage="Please enter your email address in the format xxxx@xxxx.xxx" controltovalidate="txtEmail" validationexpression="[\w-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+" display="Dynamic"></asp:RegularExpressionValidator></td></tr>
  <tr>
    <td align=right></td>
    <td align=middle>
<input type=submit value=Submit id=Submit1 runat="server"></td>
    <td></td></tr></table>

    </form>

  </body></html>
