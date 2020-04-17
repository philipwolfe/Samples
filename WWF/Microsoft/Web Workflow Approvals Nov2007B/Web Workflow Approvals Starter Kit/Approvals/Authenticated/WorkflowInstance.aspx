<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="WorkflowInstance.aspx.cs" Inherits="Authenticated_WorkflowInstance"
    Title="City Power &amp; Light - Workflow Instance Details" %>

<%@ Register Src="../Controls/AssignAnotherUser.ascx" TagName="AssignAnotherUser"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/AssignToAnotherRole.ascx" TagName="AssignAnotherRole"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/TaskTracking.ascx" TagName="TaskTracking" TagPrefix="uc2" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="bodyContentPlaceHolder">
    <div class="box">
        <div class="blueBoxBlueBorder" style="padding: 0px;">
            <img alt="workflow image" src="../workflowImages/test.png?act=<%= activityName %>&type=<%= workflowTypeName %>" />
        </div>
    </div>
    <div style="width: 260px">
        <div class="box right" style="">
            <div class="blueBox clearfix">
                <uc2:AssignAnotherRole ID="assignAnotherRole" runat="server" />
            </div>
        </div>
        <div class="box right" style="">
            <div class="blueBox clearfix">
                <uc1:AssignAnotherUser ID="assignAnotherUser" runat="server" ShowActivitySelector="true" />
            </div>
        </div>
    </div>
   
   <div style="clear:both;margin-top:10px;"> 
        <uc2:TaskTracking ID="taskTracking" runat="server" />
   </div> 
   
</asp:Content>
