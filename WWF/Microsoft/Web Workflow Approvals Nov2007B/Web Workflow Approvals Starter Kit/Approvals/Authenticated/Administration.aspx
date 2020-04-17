<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Administration.aspx.cs" Inherits="Authenticated_Administration" Title="City Power &amp; Light - Administration" %>

<%@ Register Src="../Controls/Workflows.ascx" TagName="Workflows" TagPrefix="uc2" %>
<%@ Register Src="../Controls/AssignUsersToRoles.ascx" TagName="AssignUsersToRoles"
	TagPrefix="uc1" %>
<asp:Content ID="content" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">

   <div class="box" style="width: 645px;">
			<div class="box">
			
			<uc2:Workflows ID="workflows" runat="server" />
			
			</div>
		</div>
		<div class="box right" style="width: 230px;">
			<div class="blueBox clearfix">
			
				<uc1:AssignUsersToRoles ID="assignUsersToRoles" runat="server" />
				
			</div>
		</div>



   
  
   </asp:Content> 
