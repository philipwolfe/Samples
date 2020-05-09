<%@ Page language="c#" Codebehind="FileUp.aspx.cs" AutoEventWireup="false" Inherits="VasesoftNet.FileUp" %>
<%@ Register TagPrefix="VaseWeb" Namespace="Vasesoft.WebControls" Assembly="FileUpLo"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>FileUpload web controls demo</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="FileUp" method="post" encType="multipart/form-data" runat="server">
			<P>
				<STRONG>FileUpload</STRONG> web controls demo:
			</P>
			<P>
				<asp:label id="Label1" runat="server">Select a file to upload</asp:label>
			</P>
			<P>
				<VASEWEB:FILEUPLOAD id="ClientFile" runat="server" SavePath="e:\upfile" RequiredField="True" MaxFileSize="100K" SaveMode="feedback" ValidFileExtensionName="jpg;jpeg;gif" />
				<br>
			</P>
			<P>
				<asp:button id="Button1" runat="server" Text="Upload"></asp:button>
			</P>
		</form>
	</body>
</HTML>
