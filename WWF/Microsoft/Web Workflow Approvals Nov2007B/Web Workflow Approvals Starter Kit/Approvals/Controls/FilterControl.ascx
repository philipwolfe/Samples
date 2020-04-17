<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FilterControl.ascx.cs"
	Inherits="Controls_FilterControl" %>

Filter by

<asp:DropDownList ID="dropDownList" runat="server">
			</asp:DropDownList>
			
			&nbsp;=&nbsp;
			
			<asp:TextBox ID="filterTextBox" runat="server"></asp:TextBox>
			
			<asp:ImageButton ID="button" runat="server" ImageUrl="~/Images/btn-go.gif" OnClick="button_Click" ImageAlign="AbsMiddle" />
