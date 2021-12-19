<%@ Page language="c#" Codebehind="Register.aspx.cs" AutoEventWireup="false" Inherits="FormProcessingSample.Register" %>
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
	</HEAD>
	<body>
		<h1>
			Register for a new account
		</h1>
		<form id="WebForm1" action="Confirm.aspx" method="post" runat="server">
			<table cellSpacing="1" width="100%" border="0">
				<tr>
					<td align="right">
						Name:
					</td>
					<td>
						<input id="txtName" type="text" maxLength="50" size="50" name="txtName" runat="server">
					</td>
					<td>
						<asp:requiredfieldvalidator id="txtNameValReq" runat="server" NAME="txtNameValReq" controltovalidate="txtName" ErrorMessage="Please enter your name"></asp:requiredfieldvalidator>
					</td>
				</tr>
				<tr>
					<td align="right">
						City:
					</td>
					<td>
						<input id="txtCity" type="text" maxLength="30" size="30" name="txtCity" runat="server">
					</td>
					<td>
						<asp:requiredfieldvalidator id="txtCityValReq" runat="server" NAME="txtCityValReq" controltovalidate="txtCity" ErrorMessage="Please enter your city"></asp:requiredfieldvalidator>
					</td>
				</tr>
				<tr>
					<td align="right">
						State:
					</td>
					<td>
						<asp:dropdownlist id="ddlState" runat="server"></asp:dropdownlist>
					</td>
					<td>
						<asp:requiredfieldvalidator id="ddlStateValReq" runat="server" controltovalidate="ddlState" ErrorMessage="Please select your state"></asp:requiredfieldvalidator>
					</td>
				</tr>
				<tr>
					<td align="right">
						Zip Code:
					</td>
					<td>
						<input id="txtZipCode" type="text" maxLength="10" size="10" name="txtZipCode" runat="server">
					</td>
					<td>
						<asp:requiredfieldvalidator id="txtZipCodeValReq" runat="server" ErrorMessage="Please enter your zip code" Display="Dynamic" ControlToValidate="txtZipCode"></asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="txtZipCodeValReg" runat="server" ErrorMessage="Please enter your zip code in the format 99999 or 99999-9999" ControlToValidate="txtZipCode" display="Dynamic" ValidationExpression="\d{5}(-\d{4})?"></asp:regularexpressionvalidator>
					</td>
				</tr>
				<tr>
					<td align="right">
						Email Address:
					</td>
					<td>
						<input id="txtEmail" type="text" maxLength="50" size="50" name="txtEmail" runat="server">
					</td>
					<td>
						<asp:requiredfieldvalidator id="txtEmailValReq" runat="server" ErrorMessage="Please enter your email address" ControlToValidate="txtEmail" display="Dynamic"></asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="txtEmailValReg" runat="server" controltovalidate="txtEmail" ErrorMessage="Please enter your email address in the format xxxx@xxxx.xxx" display="Dynamic" validationexpression="[\w-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"></asp:regularexpressionvalidator>
					</td>
				</tr>
				<tr>
					<td align="right">
					</td>
					<td align="middle">
						<input type="submit" value="Submit" id="Submit1" runat="server" NAME="Submit1">
					</td>
					<td>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
