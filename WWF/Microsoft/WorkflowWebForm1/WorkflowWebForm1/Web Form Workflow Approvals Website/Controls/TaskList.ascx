<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TaskList.ascx.cs" Inherits="Controls_TaskList" %>
<div class="<%= BodyCssClass %>">
	<div class="<%= TitleCssClass %>">
		<asp:ImageButton ID="refreshImageButton" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/refresh.gif"
			OnClick="refreshImageButton_Click" />
		<asp:Image ID="taskImage" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/task.gif"
			Visible="false" />
		<asp:Label ID="titleLabel" runat="server" Text="[Title]" /><br />
		<asp:Repeater ID="repeater" runat="server">
			<ItemTemplate>
				<a href='<%# CreateEditTaskLink(DataBinder.Eval(Container.DataItem, "ActivityGuid"), DataBinder.Eval(Container.DataItem, "ActivityTypeName"), DataBinder.Eval(Container.DataItem, "WorkflowGuid")) %>'>
					<%# DataBinder.Eval(Container.DataItem, "Description") %>
				</a>
				<br />
			</ItemTemplate>
		</asp:Repeater>
	</div>
</div>
