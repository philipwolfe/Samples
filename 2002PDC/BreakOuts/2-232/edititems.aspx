
<%@ Page Inherits="MyCodeBehind" Src="edititems.cs" %>


<html>

<body style="font: 14pt verdana">

  <form runat="server">

    <h2><font face="Verdana">Reading, Binding to, Editing and Transforming a Purchase Order</font></h2><p>

    <h3><font face="Verdana">Order Items</font></h3>

    <span id="Message" MaintainState="false" style="font: arial 14pt;" runat="server"/><p>

    <ASP:DataGrid id="MyDataGrid" runat="server"
      Width="800"
      BackColor="#ccccff" 
      BorderColor="black"
      ShowFooter="false" 
      CellPadding=3 
      CellSpacing="0"
      Font-Name="Verdana"
      Font-Size="12pt"
      HeaderStyle-BackColor="#aaaadd"
      OnEditCommand="MyDataGrid_Edit"
      OnCancelCommand="MyDataGrid_Cancel"
      OnUpdateCommand="MyDataGrid_Update"
      AllowSorting="true"
      OnSortCommand="MyDataGrid_Sort"
    >

      <property name="Columns">
        <asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" ItemStyle-Wrap="false"/>
      </property>

    </ASP:DataGrid>

    <p>

    <input type="submit" value="Transform" style="font: 14pt verdana" OnServerClick="Submit_Click" runat="server"/>

    <a href="http://localhost/demo/ponew.xml" target="qwer">Output of transform</a>
  </form>

</body>
</html>
