<%@ Page language="c#" Codebehind="CSharpASPPlus.aspx.cs" AutoEventWireup="false" Inherits="CSharpASPPlusSample.CSharpASPPlus" %>
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
	</HEAD>
	<body bgColor="#3366ff">
		<form method="post" runat="server">
			<p>
				&nbsp;
			</p>
			<p>
				<asp:dropdownlist id="DropDownList6" runat="server">
					<asp:ListItem Value="New">New</asp:ListItem>
					<asp:ListItem Value="Used">Used</asp:ListItem>
				</asp:dropdownlist>
			</p>
			<p>
				<strong><em><font color="#ffff66"><U>Brand</U>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </font></em></strong>
				<asp:dropdownlist id="DropDownList1" runat="server" DataValueField="Marke" DataTextField="Marke" AutoPostBack="True" DataSource="<%# dataView1%>"></asp:dropdownlist>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ControlToValidate="DropDownList1"></asp:requiredfieldvalidator>
				&nbsp;&nbsp; <strong><em><font color="#ffff66"><u>Model</u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							
							<asp:dropdownlist id="DropDownList2" runat="server" DataSource="<%# dataView1%>"></asp:dropdownlist>
							&nbsp;&nbsp;
							<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ControlToValidate="DropDownList2"></asp:requiredfieldvalidator>
						</font></em></strong>
			</p>
			<p>
				<font color="#ffff66"><strong><em><u>Year&nbsp;</u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </em></strong>
					<asp:dropdownlist id="DropDownList3" runat="server"></asp:dropdownlist>
					&nbsp;&nbsp; </font>
			</p>
			<p>
				<font color="#ffff66"><font color="#000000">&nbsp;</font><u><font color="#ffff66"><strong><em>Color</em></strong></font></u><font color="#000000">
						&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:dropdownlist id="DropDownList4" runat="server">
							<asp:ListItem></asp:ListItem>
							<asp:ListItem Value="Red">Red</asp:ListItem>
							<asp:ListItem Value="Black">Black</asp:ListItem>
							<asp:ListItem Value="White">White</asp:ListItem>
							<asp:ListItem Value="Blue">Blue</asp:ListItem>
							<asp:ListItem Value="Silver">Silver</asp:ListItem>
						</asp:dropdownlist>
					</font></font>
			</p>
			<p>
				<font color="#ffff66"><font color="#000000"><span style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><font color="#ffff66"><strong><em><u>
											Mileage</u>&nbsp; </em></strong></font>
							<asp:dropdownlist id="DropDownList5" runat="server" DataValueField="Mileage" DataTextField="Mileage" DataSource="<%# dataView1%>"></asp:dropdownlist>
						</span></font></font>
			</p>
			<p>
				<font color="#ffff66"><font color="#000000"><span style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><u><strong><em><font color="#ffff66">
											Your Email</font> (</em></strong></u><span style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><font color="#ff0066">
									Required</font></span>)&nbsp;
							<asp:textbox id="TextBox1" runat="server"></asp:textbox>
						</span></font></font>
				<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter your Email" ControlToValidate="TextBox1"></asp:requiredfieldvalidator>
			<p>
				<font color="#ffff66"><font color="#000000"><span style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><strong><em><u><font color="#ffff66">
											Features desired</font></u></em></strong>&nbsp;&nbsp;</span></font></font></p>
			<p>
				<font color="#ffff66"><font color="#000000"><span style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
							<asp:checkboxlist id="CheckBoxList1" runat="server" DataTextField="Featurs" DataSource="<%# dataView1%>" DataMember="Featurs"></asp:checkboxlist>
						</span></font></font>
			</p>
			<p>
				<font color="#ffff66"><font color="#000000"><span style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><span style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><font color="#ffff66"><strong><em><u>
												Desired Available Date: </u></em></strong>(<font color="#ff0066">Not</font> <span style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><font color="#ff0066">
											Required)</font></span></font></span></span></font></font></p>
			<font color="#ffff66"><font color="#000000"><span style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><span style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><font color="#ffff66"><span style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
									<p>
										<asp:calendar id="Calendar1" runat="server"></asp:calendar>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:label id="Label2" runat="server"></asp:label>
									</p>
									<p>
										<asp:button id="Button1" runat="server" Text="Submit Request"></asp:button>
									</p>
									<P>
										&nbsp;
										<asp:label id="Label3" runat="server"></asp:label>
									</P>
									<p>
										<asp:label id="Label1" runat="server"></asp:label>
									</p>
									<P>
										<asp:label id="Label4" runat="server"></asp:label>
									</P>
									<P>
										<asp:label id="Label5" runat="server"></asp:label>
									</P>
									<P>
										<asp:label id="Label6" runat="server"></asp:label>
									</P>
									<P>
										<asp:label id="Label7" runat="server"></asp:label>
									</P>
								</span></font></span></span></font></font>
		</form>
	</body>
</HTML>
