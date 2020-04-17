<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" Trace="false"
    CodeFile="NonAtlasWFMonitor.aspx.cs" Inherits="DragDropTest2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.NET Based Workflow Monitor</title>
    <style type="text/css">
    body
    {
        font-family: verdana;
        font-size: 80%;
    }
    
    #list1, #list2
    {
        padding: 8px;
    }
    
    #list1
    {
        border: 1px solid #aaa;
        margin-bottom: 10px;
    }
    
    #list2
    {
        border: 1px solid #aaa;
    }
    
    ul
    {
        padding-left: 0px;
        margin: 0px 0px 0px 0px;
    }
    
    ul li
    {
        list-style: none none;
        margin-bottom: 10px;
    }
    
    .list
    {
        border: 1px solid #ccc;
        width: 100%;
    }
    
    .listTitle
    {
        background: #fff url('Images/gradient.gif') repeat-x;
        cursor: move;
        font-weight: bold;
        width: 100%;
    }
    
   
    .listBody
    {
        padding: 5px;
    }
    
    .dropCue
    {
        border-top: 1px solid #000;
    }
    
    .template
    {
        display: none;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
             
        <asp:Table ID="Table1" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ColumnSpan="2" HorizontalAlign="Center" BackColor="Control">Non-Ajax based Workflow Monitor</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" BackColor="Control" Height="500px" Width="150px" VerticalAlign="Top">
        <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="WorkflowInstanceInternalId" HeaderText="Id" SortExpression="WorkflowInstanceInternalId" />
                            <asp:BoundField DataField="WorkflowInstanceId" HeaderText="WorkflowInstanceId" SortExpression="WorkflowInstanceId" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetWorkflows"
                        TypeName="DataSource"></asp:ObjectDataSource>
                </asp:TableCell>
                <asp:TableCell runat="server" Height="500px" Width="700px" VerticalAlign="Top">
               
                            <wf:WorkflowVisibilityControlImageMap ID="atlasControl1" runat="server" HandlerURL="wfimages/test.png" />
                        </ContentTemplate>
                      
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>


</body>
</html>