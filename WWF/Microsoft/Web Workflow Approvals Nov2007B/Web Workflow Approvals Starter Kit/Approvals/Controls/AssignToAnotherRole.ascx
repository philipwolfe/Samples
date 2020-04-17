<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssignToAnotherRole.ascx.cs"
	Inherits="Controls_AssignToAnotherRole" %>

		<h4>Assign another role</h4>
		<asp:DropDownList ID="dropDownList" runat="server" /><br />
	
	<asp:RadioButtonList ID="radioButtonList" runat="server" /><br />
	<asp:ImageButton runat="server" ID="reassignImageButton" ImageUrl="~/Images/btn-reassignTask.gif"
		ImageAlign="Right" OnClick="reassignImageButton_Click" />

