<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssignUsersToRoles.ascx.cs"
	Inherits="Controls_AssignUsersToRoles" %>

		<h4>Assign Users to Roles</h4>
	
		Users
	<br />
	<asp:ListBox ID="usersListBox" runat="server" Width="98%" AutoPostBack="True" OnSelectedIndexChanged="usersListBox_SelectedIndexChanged" />
	<br />
	<br />
		Roles
	<br />
	<asp:CheckBoxList RepeatLayout="Flow" BorderStyle="None" ID="rolesCheckedListBox"
		runat="server" />
	<br />
	<br />
	<asp:ImageButton runat="server" ID="saveImageButton" ImageUrl="~/Images/btn-save.gif"
		OnClick="Save" />
	<br />

