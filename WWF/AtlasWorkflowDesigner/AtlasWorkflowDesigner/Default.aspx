<%@ Page Language="C#" EnableEventValidation="false" Theme="theme1" AutoEventWireup="true"
    Trace="false" CodeFile="Default.aspx.cs" Inherits="AtlasWFDesigner" %>

<%@ Register Namespace="WorkflowAtlasDesigner" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Atlas Workflow Designer</title>

    <script type="text/javascript">
  
    function quux()
    {
    return false;
    }
    
    </script>

</head>
<body>
    <form id="form1" runat="server" onsubmit="return quux()">
        <input type="hidden" id="data" />
        <input type="hidden" name="newactivity" />
        <atlas:ScriptManager ID="ScriptManager1" EnableScriptComponents="true" runat="server"
            EnablePartialRendering="true">
            <Services>
                <atlas:ServiceReference Path="ImageService.asmx" />
            </Services>
            <Scripts>
                <atlas:ScriptReference ScriptName="AtlasUIDragDrop" />
                <atlas:ScriptReference Path="Scripts/dropZoneBehavior.js" />
                <atlas:ScriptReference Path="Scripts/ModalPopupBehavior.js" />
            </Scripts>
        </atlas:ScriptManager>
        <div>
            <table id="Table1" border="1" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" align="center" style="height: 20px;" class="header">
                        Ajax based Workflow Designer</td>
                </tr>
                <tr>
                    <td colspan="3" align="left" style="height: 24px">
                    
                        <img id="_newWF" alt="New Workflow" src="realimages/NewDocumentHS.png"
                             />
                        <img id="_saveWF" alt="Save Workflow" src="realimages/saveHS.png"
                             />
                        <img id="_openWF" alt="Open Workflow" src="realimages/openHS.png"
                           />
                    </td>
                </tr>
                <tr>
                    <td style="height: 500px; background-color: ButtonFace" valign="top">
                        <div class="header">
                            Toolbox</div>
                        <wfa:ToolboxControl runat="server" ID="atlasControl2" ItemClassName="list">
                            <asp:ListItem>Suspend</asp:ListItem>
                            <asp:ListItem>Terminate</asp:ListItem>
                            <asp:ListItem>Throw</asp:ListItem>
                            <asp:ListItem>TransactionScope</asp:ListItem>
                            <asp:ListItem>SynchronizationScope</asp:ListItem>
                            <asp:ListItem>Compensate</asp:ListItem>
                            <asp:ListItem>FaultHandler</asp:ListItem>
                            <asp:ListItem>InvokeWebService</asp:ListItem>
                            <asp:ListItem>InvokeWorkflow</asp:ListItem>
                            <asp:ListItem>EventHandlingScope</asp:ListItem>
                            <asp:ListItem>Sequence</asp:ListItem>
                            <asp:ListItem>EventDriven</asp:ListItem>
                            <asp:ListItem>IfElse</asp:ListItem>
                            <asp:ListItem>Delay</asp:ListItem>
                            <asp:ListItem>Listen</asp:ListItem>
                            <asp:ListItem>Parallel</asp:ListItem>
                            <asp:ListItem>HandleExternalEvent</asp:ListItem>
                            <asp:ListItem>CallExternalMethod</asp:ListItem>
                            <asp:ListItem>SetState</asp:ListItem>
                            <asp:ListItem>State</asp:ListItem>
                            <asp:ListItem>StateFinalization</asp:ListItem>
                            <asp:ListItem>StateInitialization</asp:ListItem>
                            <asp:ListItem>Replicator</asp:ListItem>
                            <asp:ListItem>While</asp:ListItem>
                            <asp:ListItem>WebServiceInput</asp:ListItem>
                            <asp:ListItem>WebServiceOutput</asp:ListItem>
                            <asp:ListItem>WebServiceFault</asp:ListItem>
                        </wfa:ToolboxControl>
                        <wfa:DraggableControlExtender ID="DraggableControlExtender1" runat="server" ControlID="atlasControl2">
                        </wfa:DraggableControlExtender>
                    </td>
                    <td style="height: 500px; min-width: 700px" valign="top">
                        <asp:Label runat="server" ID="_text" Visible="false" />
                        <input type="image"  id="wfimage" src="wfimages/test.png" alt="workflow image" class="wfImage" />
                    </td>
                    <td valign="top">
                        <div style="display: none">
                            <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup">
                                <center>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="workflow_id"
                                        DataSourceID="SqlDataSource1" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" />
                                            <asp:BoundField DataField="workflow_id" HeaderText="workflow_id" ReadOnly="True"
                                                SortExpression="workflow_id" Visible="False" />
                                            <asp:BoundField DataField="workflow_name" HeaderText="Name" SortExpression="workflow_name" />
                                            <asp:BoundField DataField="workflow_description" HeaderText="Description" SortExpression="workflow_description" />
                                            <asp:BoundField DataField="workflow_version" HeaderText="Version" SortExpression="workflow_version" />
                                            <asp:BoundField DataField="workflow_xaml" HeaderText="workflow_xaml" SortExpression="workflow_xaml"
                                                Visible="False" />
                                            <asp:BoundField DataField="workflow_rules" HeaderText="workflow_rules" SortExpression="workflow_rules"
                                                Visible="False" />
                                            <asp:BoundField DataField="workflow_modified_by" HeaderText="User" SortExpression="workflow_modified_by" />
                                            <asp:BoundField DataField="workflow_modified_datetime" HeaderText="Modified" SortExpression="workflow_modified_datetime" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WorkflowPersistenceConnectionString %>"
                                        SelectCommand="SELECT * FROM [workflow]"></asp:SqlDataSource>
                                    <asp:Button ID="OkButton" runat="server" Text="OK"></asp:Button>
                                    <asp:Button ID="CancelButton" runat="server" Text="Cancel"></asp:Button>
                                </center>
                            </asp:Panel>
                        </div>
                        <div id="dataContents">
                        </div>
                        <div  id="propertyGrid" style="visibility: hidden; display: none">
                            <table id="masterTemplate" style="background-color: White" cellpadding="0" cellspacing="0"
                                border="1" class="tableborder">
                                <thead>
                                    <tr>
                                        <td class="header" colspan="2" align="center">
                                            Properties</td>
                                    </tr>
                                </thead>
                                <tbody id="masterItemTemplate">
                                    <tr>
                                        <td>
                                            <span id="masterName"></span>
                                        </td>
                                        <td style="width: 5px">
                                            <asp:TextBox runat="server" ID="masterDescription">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div id="masterNoDataTemplate" class="header">
                                Properties</div>
                            <br />
                              
                        </div>
                        <div id="errors" style="color:Red" ></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" valign="top">
                       
                    </td>
                </tr>
            </table>
        </div>
        <div class="template">
            <ul>
                <li id="dropCueTemplate" class="dropCue"></li>
            </ul>
        </div>
        <%-- menu --%>
        <div id="menu1" style="position:absolute;visibility:hidden;top:0px;left:0px;z-index:10000;">
        </div>
    </form>

    <script type="text/xml-script">
        <page xmlns:script="http://schemas.microsoft.com/xml-script/2005">
            <references>
            </references>
            <components>
     <control id="_openWF">
      <behaviors>
      <!--  <modalPopupBehavior CancelControlID="CancelButton" BackgroundCssClass="modalBackground" PopupControlID="Panel2" OkControlID="OkButton" OnOkScript="onOk()" DropShadow="False" />-->
        <clickBehavior>
     <click>

        <invokeMethod target="wfimagedesignerImage" method="openWF_Click"/>
                                   

    </click>
    </clickBehavior>
    
            <hoverBehavior>
             <hover><invokeMethod target="wfimagedesignerImage" method="openWFHover"/></hover>
                </hoverBehavior>

      </behaviors>
    </control>
         <control id="wfimage">
      <behaviors>
        <designerImage  id="wfimagedesignerImage"  baseurl="wfimages/test.png"/>
      </behaviors>
    </control>
     
      <control id="_saveWF">
    <behaviors>
     <clickBehavior>
     <click>

   <invokeMethod target="wfimagedesignerImage" method="saveWF_Click"/>
                                   

    </click>
    </clickBehavior>
    </behaviors>
    </control>
      <control id="_newWF">
    <behaviors>
     <clickBehavior>
     <click>

   <invokeMethod target="wfimagedesignerImage" method="newWF_Click"/>
                                   

    </click>
    </clickBehavior>
    </behaviors>
    </control>
    <control id="menu1">
    <behaviors>
        <popupMenu id="popupMenu1"  itemstyle="menuItem" hoveritemstyle="menuHoverItem"/>
    </behaviors>
    </control>
     <dataSource id="dataSource" serviceURL="PropertyGridService.asmx" 
           autoLoad="false" >
     
</dataSource>
          

     <listView id="dataContents" 
       itemTemplateParentElementId="masterTemplate" 
       propertyChanged="onChange">
       <bindings>
         <binding dataContext="dataSource" dataPath="data"
           property="data"/>
       </bindings>
       <layoutTemplate>
         <template layoutElement="masterTemplate"/>
       </layoutTemplate>
       <itemTemplate>
         <template layoutElement="masterItemTemplate">
           <label id="masterName">
             <bindings>
                 <binding dataPath="Name" property="text"/>
             </bindings>
           </label>
           <textBox id="masterDescription">
             <bindings>
                 <binding dataPath="Value" 
                     property="text"/>
             </bindings>
           </textBox>
         </template>
       </itemTemplate>
       <emptyTemplate>
         <template layoutElement="masterNoDataTemplate"/>
       </emptyTemplate>
     </listView>

<control id="atlasControl2">
    <behaviors>
<dragDropList dataType="HTML" acceptedDataTypes="'HTML'" dragMode="Copy">
 <dropCueTemplate>
                                    <template layoutElement="dropCueTemplate" />
                                </dropCueTemplate></dragDropList>
        

    </behaviors>
</control>
    

            </components>
        </page>
    </script>

</body>
</html>
