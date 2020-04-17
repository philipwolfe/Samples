<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssignAnotherUser.ascx.cs"
	Inherits="Controls_AssignAnotherUser" %>
<div class="blueBox">
	<div class="blueBoxTitle">
		Assign another user<br />
		<asp:DropDownList ID="dropDownList" runat="server" />
	</div>
	<asp:RadioButtonList ID="radioButtonList" runat="server" /><br />
	Comment<br />
	<asp:TextBox ID="commentTextBox" runat="server" Height="50px" Width="98%" TextMode="MultiLine" /><br />
	<asp:ImageButton runat="server" ID="reassignImageButton" ImageUrl="~/Images/button_reassignTask.jpg"
		ImageAlign="Right" OnClick="reassignImageButton_Click" />
</div>
