<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="LoanRequest" Title="International bank - Personal Banking." %>

 <asp:Content ID="pageContent" ContentPlaceHolderID="mainPageContent" Runat="Server">

      <table width="100%"  border="0" cellspacing="0" cellpadding="0" style="height:100%" > 
    
              <tr>
                <td>
                
                 <table border="0" width="100%"  cellpadding="0" style="height:100%" id="tblUserDetails">
            
                    <tr>
                        <td colspan="5" style="height:1px;">
        		            
                        </td>
                    </tr>
        	
            
                    <tr>
                        <td align="center" valign="top" colspan="5" style="height: 14px">
                            <b>Loan Request Details</b>
                        </td>
                    </tr>
        	        
                    <tr>
                        <td colspan="5" style="height:5px;">
        		               
                        </td>
                    </tr>
        	        
                    <tr>
                        <td style="width: 20%;">&nbsp;</td>
                        <td align="right"  class="HeaderLabel" style="width: 25%; height: 25px;">User Name :</td>
                        <td style="width: 2%; height: 25px;">&nbsp;</td>
                        <td align="left" style="width: 53%; height: 25px;">
                            <asp:TextBox ID="txtUserName" runat="server" MaxLength="25" TabIndex="1" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                                ErrorMessage="* User Name is required." ToolTip="User Name is required." CssClass="Error" ></asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 20%;">&nbsp;</td>
                    </tr>

                    <tr>
                        <td style="width: 20%;">&nbsp;</td>
                        <td align="right"  class="HeaderLabel" style="width: 25%; height: 25px;">SSN :</td>
                        <td style="width: 2%; height: 25px;">&nbsp;</td>
                        <td align="left" style="width: 53%; height: 25px;">
                            <asp:TextBox ID="txtSSN" runat="server" MaxLength="25" TabIndex="1" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSSN" runat="server" ControlToValidate="txtSSN" 
                                ErrorMessage="* SSN is required." ToolTip="SSN is required." CssClass="Error" ></asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 20%;">&nbsp;</td>
                    </tr>
        	        
    	            <tr>
                        <td style="width: 20%;">&nbsp;</td>
                        <td align="right"  class="HeaderLabel" style="width: 25%; height: 25px;">Loan Amount :</td>
                        <td style="width: 2%; height: 25px;">&nbsp;</td>
                        <td align="left" style="width: 53%; height: 25px;">
                            <asp:TextBox ID="txtLoanAmount" runat="server" MaxLength="9" TabIndex="1" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLoanAmount" runat="server" ControlToValidate="txtLoanAmount"
                                CssClass="Error" ErrorMessage="* Amount is required." ToolTip="Amount is required."></asp:RequiredFieldValidator>
                            </td>
                        <td style="width: 20%;">&nbsp;</td>
                    </tr>
                    
                     
                    <tr>
                        <td style="width: 20%;">&nbsp;</td>
                        <td align="right" class="HeaderLabel" style="width: 25%; height: 25px;">Address :</td>
                        <td style="width: 2%; height: 25px;">&nbsp;</td>
                        <td align="left" style="width: 53%; height: 25px;">
                            <textarea id="txtAreaAddress" rows="4" cols="20" tabindex="6" runat="server"></textarea>
                            <asp:CustomValidator ID="cvAddress" runat="server" CssClass="Error" ControlToValidate="txtAreaAddress" 
                             ClientValidationFunction = "CheckAddress"
                             ErrorMessage="* Address size should not exceed 100 chars."></asp:CustomValidator>
                        </td>
                        <td style="width: 20%;">&nbsp;</td>
                    </tr>
        	
                     <tr>
                        <td class="TxtLabels" style="width: 20%"> &nbsp;</td>
                        <td style="width: 25%" align="right">
                            <asp:Button Text="Save"  CssClass ="Button" runat="server" id="btnSubmit" tabindex="5" OnClick="btnSubmit_Click" />
                        </td>
                        <td  class="TxtLabels" style="width: 2%"> &nbsp;</td>
                        <td  class="TxtLabels" style="width: 53%"> 
                            <input type="reset"  class ="Button" value="Reset" name="btnReset" tabindex="6" />
                        </td>
                        <td style="width: 20%;">&nbsp;</td>
                    </tr>
        	        
    	             <tr>
                        <td style="width: 20%;">&nbsp;</td>
                        <td align="left" style="height: 25px;" colspan="3">
                            <asp:RangeValidator ID="rvLoanAmount" runat="server" ErrorMessage="* Enter a Numeric value for Loan Amount less than 1000000" CssClass="Error"
                             ControlToValidate="txtLoanAmount" MaximumValue="1000000" MinimumValue="0" Type="Integer"></asp:RangeValidator>

                        </td>
                        <td style="width: 20%;">&nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td style="width: 20%;">&nbsp;</td>
                        <td align="center" style="height: 25px;" colspan="3" >
                            <asp:RegularExpressionValidator ID="revSSN" runat="server" CssClass="Error" 
                                 ErrorMessage="* Incorrect SSN Number" ControlToValidate="txtSSN"
                                 ValidationExpression="^\d{3}-\d{2}-\d{4}$" />

                        </td>
                        <td style="width: 20%;">&nbsp;</td>
                    </tr>
                                        
                    <tr>
                        <td align="center" valign="top" colspan="5">
                            <asp:Label id="lblCustomErrorMessage" runat="server" CssClass="Error" EnableViewState="False"></asp:Label>
                        </td>
                    </tr>
                                      
                 </table>
               
            </td>
        </tr>
    </table>
    
 </asp:Content>

