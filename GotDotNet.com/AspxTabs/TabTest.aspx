<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TabTest.aspx.vb" Inherits="AspxTabs.TabTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ASPX Tabs</title> 
		<!-- 
' Author:  Syed Javed Hashmi
' Created: 15/05/2006
' Email: softech.systems@gmail.com
' Modification History
' --------------------------------------------------------------------------------------------
' Date        Author             Description
' 15/05/2006  Syed Javed Hashmi  Created
' ??/??/????  <     name      >  ?????????????????????????????????????????????????????????????
'                                ?????????????????????????????????????????????????????????????
'                                ?????????????????????????????????????????????????????????????
-->
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<script language="javascript">
			function pageLoaded()
			{
			 tabContainer_selectTab(3);
			}		
			
			function tab_Clicked(tabContainerID, tabID, tabNumber)
			{
			  //alert (tabContainerID + ' - ' + tabID + ' - ' + tabNumber);
			}
		</script>
	</HEAD>
	<body onload="pageLoaded();">
		<form id="Form1" runat="server">
			<div id="tabContainer" runat="server"><FONT face="Verdana" color="maroon" size="2">Tab 
					Container</FONT></div>
			<div id="tabPage1" style="DISPLAY: none; WIDTH: 1035px; HEIGHT: 182px">
				<P><select size="1" name="D1">
						<option selected>Area 1</option>
					</select><INPUT type="submit" value="Submit" id="Submit1" name="Submit1" runat="server"></P>
				<P><asp:label id="Label1" runat="server" Width="256px" BackColor="Gainsboro" ForeColor="DimGray">XXXXXXXXXXXXXXXXX</asp:label></P>
				<P><asp:label id="Label2" runat="server" Width="256px" BackColor="DimGray" ForeColor="Silver">XXXXXXXXXXXXXXXXX</asp:label></P>
			</div>
			<div id="tabPage2" style="DISPLAY: none; WIDTH: 1035px; HEIGHT: 182px">
				<input type="button" value="Area 2" name="B1"> <INPUT type="submit" value="Submit">
			</div>
			<div id="tabPage3" style="DISPLAY: none; WIDTH: 1035px; HEIGHT: 182px">
				<fieldset style="PADDING-RIGHT: 2px; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; PADDING-TOP: 2px">
					<P>
						<legend>Group box</legend>Area 3
						<asp:DropDownList id="DropDownList1" runat="server"></asp:DropDownList></P>
					<P>&nbsp;</P>
					<P><INPUT type="submit" value="Submit">cxcxc</P>
				</fieldset>
			</div>
			<div id='tabPage4' style="DISPLAY: none; WIDTH: 1035px; HEIGHT: 182px">
				<input type="text" name="T1" size="20" value="Area 4"></div>
			<div id="tabContainer1" runat="server"><FONT face="Verdana" color="maroon" size="2">Tab 
					Container1</FONT></div>
			<div id="TP1" style="DISPLAY: none; WIDTH: 1035px; HEIGHT: 182px">
				<input type="button" value="Area 2" name="B1"> <INPUT type="submit" value="Submit">
			</div>
			<div id="TP2" style="DISPLAY: none; WIDTH: 1035px; HEIGHT: 182px">
				<fieldset style="PADDING-RIGHT: 2px; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; PADDING-TOP: 2px">
					<P>
						<legend>Group box</legend>Area 3
						<asp:DropDownList id="Dropdownlist2" runat="server"></asp:DropDownList></P>
					<P>&nbsp;</P>
					<P><INPUT type="submit" value="Submit">cxcxc</P>
				</fieldset>
			</div>
		</form>
	</body>
</HTML>
