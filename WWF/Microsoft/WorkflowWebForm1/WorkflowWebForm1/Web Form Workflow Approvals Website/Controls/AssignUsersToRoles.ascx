<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssignUsersToRoles.ascx.cs"
	Inherits="Controls_AssignUsersToRoles" %>
<div class="blueBox">
	<div class="blueBoxTitle">
		Assign Users to Roles</div>
	<br />
	<div class="blueBoxSectionTitle">
		Users</div>
	<br />
	<asp:ListBox ID="usersListBox" runat="server" Width="98%" AutoPostBack="True" OnSelectedIndexChanged="usersListBox_SelectedIndexChanged" />
	<br />
	<br />
	<div class="blueBoxSectionTitle">
		Roles</div>
	<br />
	<asp:CheckBoxList RepeatLayout="Flow" BorderStyle="None" ID="rolesCheckedListBox"
		runat="server" />
	<br />
	<br />
	<asp:ImageButton runat="server" ID="saveImageButton" ImageUrl="~/Images/button_save.jpg"
		OnClick="Save" />&nbsp;
	<br />
</div>
