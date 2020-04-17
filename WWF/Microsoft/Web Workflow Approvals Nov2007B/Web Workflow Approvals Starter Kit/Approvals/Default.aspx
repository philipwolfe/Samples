<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="City Power &amp; Light" %>

<%@ Register Src="Controls/TaskList.ascx" TagName="TaskList" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="bodyContentPlaceHolder">
    <div class="box" style="width: 265px;">
        <div class="blueBox">
            <h4>
                Workflows
            </h4>
            <h5>
                <asp:LinkButton ID="approvalRequestLinkButton" runat="server" OnClick="approvalRequestLinkButton_Click"
                    Text="Start Approval Request" />
            </h5>
        </div>
    </div>
   <div> 
        <asp:LoginView ID="loginView" runat="server">
            <LoggedInTemplate>
                <div class="box right" style="width: 695px;">
                    <div class="blueBorderBox clearfix">
                        <asp:Image ID="refreshImage" runat="server" AlternateText=" " CssClass="icon" ImageUrl="~/images/icn-refresh.gif" />
                        <h4>
                            <asp:LinkButton ID="refreshTaskListsLinkButton" runat="server" OnClick="refreshTaskListsLinkButton_Click"
                                Text="Refresh Task Lists" />
                        </h4>
                    </div>
                    <uc1:TaskList ID="usersTaskList" runat="server" BodyCssClass="orangeBorderBox clearfix"
                        ImageUrl="~/images/icn-mytasks.gif" ListType="UsersTasks" Title="Tasks Assigned To Me">
                    </uc1:TaskList>
                    <uc1:TaskList ID="rolesTaskList" runat="server" BodyCssClass="greenBorderBox clearfix"
                        ImageUrl="~/images/icn-tasks.gif" ListType="RolesTasks" Title="Tasks For Anyone In Role">
                    </uc1:TaskList>
                </div>
            </LoggedInTemplate>
            <AnonymousTemplate>
                <div class="box right" style="width: 695px;">
                    <div class="blueBorderBox clearfix">
                        Click one of the workflow models in the list on the left to start a new workflow
                        instance.<br />
                        <br />
                        Login or register to see more options.<br />
                        <br />
                        For this starterkit you can login as Charles, Jane or Rachel. The password is password
                        for all users. Charles is the administrator, Jane is a manager and Rachel is data
                        entry.
                    </div>
                </div>
            </AnonymousTemplate>
        </asp:LoginView>
   </div> 
</asp:Content>
