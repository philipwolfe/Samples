<%@ Page ClientTarget="Uplevel" Inherits="AWS.FilePickerPage" autoeventwireup="false" CodeBehind="FilePicker.aspx.cs" EnableViewState="True" Debug="True" Trace="False" Language="c#" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
	<head>
		<title>Select a File</title> 
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
		<style>
			.inputArea {
				FONT-SIZE: 12px; COLOR: #000000; FONT-FAMILY: tahoma; HEIGHT: 20px;
			}
			Body {
				margin: 0 0 0 0;
			}
		</style>
	</head>

	<body topmargin=0 leftmargin=0 >
		<form id="Form1" enctype="multipart/form-data" runat="server">
			<table height="100%" cellspacing="0" cellpadding="0" width="100%" border=0>
				<tbody>
					<tr>
						<td valign="top" width="100%" colspan="2" backcolor="#000066">
							<img hspace="0" src="img/icon.gif" align="left" /> 
							<asp:label id="Header" style="TEXT-ALIGN: center" runat="server" BackColor="#000066" EnableViewState="False" Width="100%" font-size="12px" font-name="Arial" ForeColor="#ffffff" Height="20px"></asp:label>
							<asp:imagebutton id="UpBtn" runat="server" EnableViewState="False" CommandArgument="../" CommandName="ChangePath" ImageUrl="img/Up.gif" ToolTip="Up one level"></asp:imagebutton>
							<asp:imagebutton id="GoRoot" runat="server" EnableViewState="False" CommandArgument="/" CommandName="ChangePath" ImageUrl="img/Home.gif" AlternateText="Back to Root Directory"></asp:imagebutton>
						</td>
					</tr>
					<tr>
						<td valign="top" align="left" colspan="2" height="100%" width="100%">
							<asp:DataGrid id="dgFSList" runat="server" BackColor="White" EnableViewState="False" Width="100%" PagerStyle-PrevPageText="<< Prev" PagerStyle-NextPageText="Next >>" PagerStyle-HorizontalAlign="Center" PageSize="20" AllowSorting="True" AllowPaging="True" AutoGenerateColumns="False" CellPadding="3" BorderColor="#E7E7FF" BorderWidth="1px" BorderStyle="None" GridLines="Horizontal">
								<FooterStyle forecolor="#4A3C8C" backcolor="#B5C7DE"></FooterStyle>
								<HeaderStyle font-size="13px" horizontalalign="Center" font-names="Arial" font-bold="True" forecolor="#F7F7F7" backcolor="#4A3C8C"></HeaderStyle>
								<PagerStyle nextpagetext="Next &gt;&gt;" font-size="12px" font-names="Arial" prevpagetext="&lt;&lt; Prev" horizontalalign="Center" mode="NumericPages"  forecolor="#F7F7F7" backcolor="#4A3C8C"></PagerStyle>
								<SelectedItemStyle font-bold="True" forecolor="#F7F7F7" backcolor="#738A9C"></SelectedItemStyle>
								<EditItemStyle font-names="Arial" horizontalalign="Center" forecolor="Black" backcolor="Ivory"></EditItemStyle>
								<AlternatingItemStyle backcolor="#F7F7F7"></AlternatingItemStyle>
								<ItemStyle font-size="12px" font-names="Tahoma" forecolor="#4A3C8C" backcolor="#E7E7FF"></ItemStyle>
								<EditItemStyle font-size="12px" font-names="Tahoma" forecolor="#4A3C8C" backcolor="#FFFF99"></EditItemStyle>
								<Columns>
									<asp:TemplateColumn SortExpression="IsFile">
										<ItemTemplate>
											<asp:Image runat="server" id="imgFSObject" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="FileName" HeaderText="File Name">
										<ItemTemplate>
											<asp:LinkButton runat="server" id="lbFileName" CommandName="FSOClick" />
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox runat="server" id="txtFileName" Text='<%# DataBinder.Eval(Container.DataItem, "FileName") %>' />
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Size" HeaderText="Size">
										<ItemTemplate>
											<asp:Label runat="server" id="lblSize" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Modified" HeaderText="Modified">
										<ItemTemplate>
											<asp:Label runat="server" id="lbModified" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Action">
										<ItemTemplate>
											<asp:HyperLink runat="server" id="hlView" ImageUrl="img/view.gif" ToolTip="View" Target="_Blank" />
											<asp:LinkButton CommandName="Rename" runat="server" id="imbRen" Text="<img src='img/ren.gif' border='0' align='center'/>" ToolTip="Rename" Visible="False" />
											<asp:LinkButton CommandName="Del" runat="server" id="imbDel" Text="<img src='img/del.gif' border='0' align='center'/>" ToolTip="Delete" Visible="False" />
										</ItemTemplate>
										<EditItemTemplate>
											<asp:LinkButton CommandName="Update" runat="server" id="imbUpdate" Text="<img src='img/update.gif' border='0' align='center'/>" ToolTip="Update" />
											<asp:LinkButton CommandName="Cancel" runat="server" id="imbCancel" Text="<img src='img/cancel.gif' border='0' align='center'/>" ToolTip="Cancel" />
										</EditItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid>
						</td>
					</tr>
					<asp:PlaceHolder id="UploadArea" runat="server" EnableViewState="False" Visible="false">
						<tr>
							<td bgcolor="#000066" height="30">
								<img src="img/upload.gif" align="left" /><font face="Arial" color="#ffffff" size="2">Upload
								a file</font></td>
							<td bgcolor="#000066" height="30">
								<input class="inputArea" id="fileToUpload" type="file" size="15" name="fileToUpload" runat="server" />
								<asp:button id="UploadBtn" runat="server" Text="Upload"></asp:button>
							</td>
						</tr>
					</asp:PlaceHolder>
					<asp:PlaceHolder id="CreateDirArea" runat="server" EnableViewState="False" Visible="false">
						<tr>
							<td bgcolor="#000066" height="30">
								<img src="img/CreateFolder.gif" align="left" /><font face="Arial" color="#ffffff" size="2">Create
								new folder</font></td>
							<td bgcolor="#000066" height="30">
								<asp:textbox class="inputArea" id="NewFolderText" runat="server" EnableViewState="False" Size="15"></asp:textbox>
								&nbsp; 
								<asp:button id="NewFolderBtn" runat="server" EnableViewState="False" Text="New Folder"></asp:button>
							</td>
						</tr>
					</asp:PlaceHolder>
				</tbody>
			</table>
		</form>
	</body>
</html>
