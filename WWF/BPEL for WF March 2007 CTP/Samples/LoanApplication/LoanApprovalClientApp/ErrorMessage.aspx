<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ErrorMessage.aspx.cs" Inherits="ErrorMessage" Title="Internation Bank" %>

<asp:Content ID="errMessageContent" ContentPlaceHolderID="mainPageContent" Runat="Server">

    

<table border="0" style="height:100%" width="100%" cellpadding="0" cellspacing="0">
   
   <tr>
        <td colspan="3" valign="top" style="height:30px;">&nbsp;</td>
   </tr>
   
     
  <tr>
        <td style="width:5%"></td>
		<td style="width:85%" class="HeaderLabel">
		    <asp:Literal ID="litMessage" runat="server" ></asp:Literal>
		</td>
		<td style="width:10%"></td>
   </tr>
   
   
   
  </table>

</asp:Content>


