<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TaskList.ascx.cs" Inherits="Controls_TaskList" %>

<asp:Panel ID="panel" runat="server">
	<asp:Image ID="image" runat="server" AlternateText=" " CssClass="icon" />
	
	<h4>
	    <asp:Label ID="label" runat="server" />
    </h4>
	
	<asp:Repeater ID="repeater" runat="server">
		<ItemTemplate>
		    <hr />
			<a class="task" href='<%# QueryStringHelper.CreateEditTaskLink(DataBinder.Eval(Container.DataItem, "ActivityGuid"), DataBinder.Eval(Container.DataItem, "ActivityTypeName"), DataBinder.Eval(Container.DataItem, "WorkflowGuid")) %>'>
				<%# DataBinder.Eval(Container.DataItem, "Description") %>
			</a>
			<br />
		</ItemTemplate>
	</asp:Repeater>
</asp:Panel>

