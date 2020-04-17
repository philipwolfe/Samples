<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" Trace="false"
    CodeFile="AtlasWFMonitor.aspx.cs" Inherits="DragDropTest2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Atlas Workflow Monitor</title>
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
        <asp:ScriptManager ID="ScriptManager1"  runat="server"
            EnablePartialRendering="true">
            <Scripts>
            </Scripts>
        </asp:ScriptManager>
        <table>
            <tr>
                <td colspan="3" align="center" style="background-color:Gray">
                    <asp:Label runat="server"  ID="name" Font-Bold="true" Font-Names="Tahoma" Font-Size="X-Large">Ajax based Workflow Monitor</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 500px;" valign="top">
                    <asp:UpdatePanel runat="server" ID="WFPanel">
                        <ContentTemplate>
                        <asp:Label runat="server" ID="grid1Title">Workflows</asp:Label>
                            <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False"
                                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="WorkflowInstanceId">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="WorkflowInstanceInternalId" HeaderText="Id" SortExpression="WorkflowInstanceInternalId" />
                                    <asp:BoundField  DataField="WorkflowInstanceId" HeaderText="WorkflowInstanceId" SortExpression="WorkflowInstanceId" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetWorkflows"
                                TypeName="DataSource"></asp:ObjectDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                  
                </td>
                <td style="height: 500px;width:300px" valign="top">
                    <asp:UpdatePanel runat="server" ID="panel1" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label runat="server" ID="_text" Visible="false" />
                            <wf:WorkflowVisibilityControlImageMap ID="atlasControl1" runat="server" HandlerURL="wfimages/test.png" />
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" /> 
                           
                            <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td valign="top" align="left">
                  <asp:UpdatePanel runat="server" ID="ActPanel">
                        <ContentTemplate>
                        <asp:Label runat="server" ID="Label1">Activities</asp:Label>
                        
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2"
                                OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="ParentContextGuid" HeaderText="ParentContextGuid" SortExpression="ParentContextGuid"
                                        Visible="False" />
                                    <asp:BoundField DataField="QualifiedName" HeaderText="QualifiedName" SortExpression="QualifiedName" />
                                    <asp:BoundField DataField="ExecutionStatus" HeaderText="Status" />
                                    <asp:BoundField DataField="EventOrder" HeaderText="EventOrder" SortExpression="EventOrder" />
                                    <asp:BoundField DataField="EventDateTime" HeaderText="EventDateTime" SortExpression="EventDateTime" />
                                    <asp:BoundField DataField="ContextGuid" HeaderText="ContextGuid" SortExpression="ContextGuid"
                                        Visible="False" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetWorkflowActivities"
                                TypeName="DataSource">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="GridView1" Name="id" PropertyName="SelectedValue"
                                        Type="Object" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </form>

  

</body>
</html>
