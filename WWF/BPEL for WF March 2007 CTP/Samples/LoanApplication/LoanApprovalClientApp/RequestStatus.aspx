<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RequestStatus.aspx.cs" Inherits="RequestStatus" Title="Check Loan Request Status" %>

<asp:Content ID="laonStatusContent" ContentPlaceHolderID="mainPageContent" Runat="Server">

     <table border="0" width="100%"  cellpadding="0" style="height:100%" id="Table3">
                        
        <tr>
            <td colspan="5" style="height:1px;">
	            
            </td>
        </tr>


        <tr>
            <td align="center" valign="top" colspan="5">
                <b>Loan Request Status</b>
            </td>
        </tr>
        
         <tr>
            <td align="center" valign="top" colspan="5" style="height: 14px">
                &nbsp;
            </td>
        </tr>
            
         <tr>
            <td style="width: 4%;">&nbsp;</td>
            <td align="right"  class="HeaderLabel" style="width: 15%; height: 25px;">Request Id :</td>
            <td style="width: 2%; height: 25px;">&nbsp;</td>
            <td align="left" style="width: 76%; height: 25px;">
                <asp:TextBox ID="txtRequestId" EnableViewState ="false" runat="server" MaxLength="36" TabIndex="1" Width="278px" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRequestId" runat="server" ControlToValidate="txtRequestId"
                    ErrorMessage="* Request Id is required." ToolTip="User Name is required." CssClass="Error" ></asp:RequiredFieldValidator>
            </td>
            <td style="width: 20%;">&nbsp;</td>
        </tr>
        
         <tr>
            <td style="width: 4%;">&nbsp;</td>
            <td align="right"  class="HeaderLabel" style="width: 15%; height: 25px;"></td>
            <td style="width: 2%; height: 25px;">&nbsp;</td>
            <td align="left" style="width: 76%; height: 25px;">
                <asp:RegularExpressionValidator ID="revRequestId" runat="server" 
                ErrorMessage="* The request id is invalid." ControlToValidate="txtRequestId" CssClass="Error" ValidationExpression="^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$"></asp:RegularExpressionValidator>
            </td>
            <td style="width: 20%;">&nbsp;</td>
        </tr>
        
         

        
        <tr>
            <td class="TxtLabels" style="width: 4%"> &nbsp;</td>
            <td style="width: 15%" align="right">
                
            </td>
            <td  class="TxtLabels" style="width: 2%"> &nbsp;</td>
            <td  class="TxtLabels" style="width: 76%"> 
                <asp:Button Text="Get Status"  CssClass ="Button" runat="server" id="btnLoanRequestStatus" tabindex="5" OnClick="btnLoanRequestStatus_Click"/>
            </td>
            <td style="width: 20%;">&nbsp;</td>
        </tr>
        
      
        
    </table>

</asp:Content>

