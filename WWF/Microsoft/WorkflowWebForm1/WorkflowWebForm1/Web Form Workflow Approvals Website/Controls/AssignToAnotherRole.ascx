<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssignToAnotherRole.ascx.cs"
	Inherits="Controls_AssignToAnotherRole" %>
<div class="blueBox">
	<div class="blueBoxTitle">
		Assign another role<br />
		<asp:DropDownList ID="dropDownList" runat="server" />
	</div>
	<asp:RadioButtonList ID="radioButtonList" runat="server" /><br />
	<asp:ImageButton runat="server" ID="reassignImageButton" ImageUrl="~/Images/button_reassignTask.jpg"
		ImageAlign="Right" OnClick="reassignImageButton_Click" />
</div>
