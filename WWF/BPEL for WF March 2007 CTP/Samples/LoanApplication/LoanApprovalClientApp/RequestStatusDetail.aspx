<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RequestStatusDetail.aspx.cs" Inherits="RequestStatusDetail" Title="Loan Request Status and Quote Details" %>

<asp:Content ID="requestStatusDetail" ContentPlaceHolderID="mainPageContent" Runat="Server">

 <table border="0" width="100%"  cellpadding="0" style="height:100%" id="Table1">
                        
    <tr>
        <td colspan="5" style="height:1px;">
            
        </td>
    </tr>


    <tr>
        <td align="center" valign="top" colspan="5">
            <b>Loan Approval - Request Detail</b>
        </td>
    </tr>
    
     <tr>
        <td align="center" valign="top" colspan="5">
            &nbsp;
        </td>
    </tr>
    
    <tr>
        <td valign="top" colspan="5" align="left" class="HeaderLabel">
            Your request has been submitted.
        </td>
     </tr>
    
    
    <tr>
        <td valign="top" colspan="5" align="left" class="HeaderLabel">
            Your request id is :- &nbsp;
            <asp:Label id="lblReqId" runat="server" CssClass="HeaderLabel"></asp:Label>
        </td>
     </tr>
     
     <tr>
         <td  style="width: 40%" align="left" colspan="5" class="HeaderLabel">
            Request Status :-&nbsp;<asp:Label id="lblReqStatus" runat="server" ForeColor="Red" CssClass="HeaderLabel"></asp:Label>
         </td>
    </tr>
    
    <tr>
        <td align="center" valign="top" colspan="5">
                &nbsp;
        </td>
    </tr>
    
    <tr>
        <td align="center" valign="top" colspan="5">
            <b>Loan Quotes</b>
        </td>
    </tr>
    
    <tr>
        <td align="center" valign="top" colspan="5">
            &nbsp;
        </td>
    </tr>
        
      <tr>
            <td align="center" valign="top" colspan="5">
                <asp:Label id="lblLoanQuotes" runat="server" CssClass="HeaderLabel"></asp:Label>
            </td>
        </tr>
    
    
      <tr>
        <td class="TxtLabels" style="width: 100%;height:200px;vertical-align:top;" colspan="5"> 
        
          <asp:GridView  ID="gridViewLoanQuote" runat="server" 
               BackColor="White" BorderColor="White"  EnableViewState ="false"
               BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" 
               AllowPaging="True" GridLines="None" AutoGenerateColumns="False"
               Width="100%"  EnableTheming="False" PageSize="20">

                  <Columns>
                      
                    <asp:BoundField  HeaderText="Interest Rate(%)" DataField="InterestRate">
                        <ItemStyle  Width="20%" Font-Size="XX-Small" HorizontalAlign="Center" CssClass="ListColumnHeader" />
                    </asp:BoundField>
                    
                    <asp:BoundField HeaderText="Time Period (months)" DataField="TimePeriod">
                        <ItemStyle  Width="20%" Font-Size="XX-Small" HorizontalAlign="Center" CssClass="ListColumnHeader" />
                    </asp:BoundField>
                    
                    <asp:BoundField HeaderText="Amount Sanctioned (USD)" DataField="AmountSanctioned" >
                        <ItemStyle  Width="20%" Font-Size="XX-Small" HorizontalAlign="Center" CssClass="ListColumnHeader"  />
                    </asp:BoundField>
                     
                    <asp:BoundField HeaderText="Start Date" DataField="StartDate">
                        <ItemStyle  Width="20%"  Font-Size="XX-Small" HorizontalAlign="Center" CssClass="ListColumnHeader"  />
                    </asp:BoundField>
                    
                 </Columns>

                    <FooterStyle BackColor="White" ForeColor="Black" />
                    <RowStyle BackColor="White" ForeColor="Black" Width="100%" Height="20px"/>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6F93CF" Font-Bold="true" ForeColor="White" Font-Size="Smaller" Height="15px" />
                    <AlternatingRowStyle BackColor="WhiteSmoke" Font-Size="Smaller" Width="100%" Height="20px"/>
                    
                </asp:GridView>
                
           </td>
        </tr>
        
       
    
</table>

</asp:Content>

