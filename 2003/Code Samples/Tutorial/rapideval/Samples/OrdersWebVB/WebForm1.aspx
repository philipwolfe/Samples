<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="VBPromotion.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>OrdersTest</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id=dgOrders style="Z-INDEX: 101; LEFT: 22px; POSITION: absolute; TOP: 288px" runat="server" PageSize="5" Width="636px" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC" DataMember="Orders" DataKeyField="OrderID" DataSource="<%# dvOrders %>" AllowPaging="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<AlternatingItemStyle Font-Size="0.8em" VerticalAlign="Top"></AlternatingItemStyle>
				<ItemStyle Font-Size="0.8em" ForeColor="#000066" VerticalAlign="Top"></ItemStyle>
				<HeaderStyle Font-Size="0.8em" Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
				<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" HeaderText="Edit" CancelText="Cancel"
						EditText="Edit"></asp:EditCommandColumn>
				</Columns>
				<PagerStyle Font-Size="0.8em" Font-Bold="True" HorizontalAlign="Left" ForeColor="#000066" BackColor="White"
					Mode="NumericPages"></PagerStyle>
			</asp:datagrid><asp:dropdownlist id=ddlCustomers style="Z-INDEX: 102; LEFT: 19px; POSITION: absolute; TOP: 38px" runat="server" Width="174px" DataMember="Customers" DataSource="<%# dsOrders %>" DataValueField="CustomerID" DataTextField="CompanyName"></asp:dropdownlist><asp:calendar id="OrderDateStart" style="Z-INDEX: 103; LEFT: 232px; POSITION: absolute; TOP: 64px"
				runat="server" Width="175px" CellPadding="4" BackColor="White" BorderColor="#999999" VisibleDate="2000-07-01" SelectedDate="2000-07-01" Font-Names="Verdana" Font-Size="7pt" DayNameFormat="FirstLetter" Height="150px" ForeColor="Black">
				<TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
				<SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
				<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
				<DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
				<SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
				<TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
				<WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>
				<OtherMonthDayStyle ForeColor="Gray"></OtherMonthDayStyle>
			</asp:calendar><asp:calendar id="OrderDateEnd" style="Z-INDEX: 104; LEFT: 483px; POSITION: absolute; TOP: 63px"
				runat="server" Width="175px" CellPadding="4" BackColor="White" BorderColor="#999999" VisibleDate="2002-05-01"
				SelectedDate="2002-05-01" Font-Names="Verdana" Font-Size="7pt" DayNameFormat="FirstLetter" Height="150px"
				ForeColor="Black">
				<TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
				<SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
				<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
				<DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
				<SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
				<TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
				<WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>
				<OtherMonthDayStyle ForeColor="Gray"></OtherMonthDayStyle>
			</asp:calendar><asp:label id="Label1" style="Z-INDEX: 105; LEFT: 19px; POSITION: absolute; TOP: 19px" runat="server">Choose Customer</asp:label><asp:button id="cmdShow" style="Z-INDEX: 106; LEFT: 522px; POSITION: absolute; TOP: 243px" runat="server"
				Width="136px" Text="Show Orders"></asp:button><asp:textbox id="txtStartDate" style="Z-INDEX: 107; LEFT: 232px; POSITION: absolute; TOP: 38px"
				runat="server"></asp:textbox><asp:textbox id="txtEndDate" style="Z-INDEX: 108; LEFT: 483px; POSITION: absolute; TOP: 38px"
				runat="server"></asp:textbox><asp:label id="Label2" style="Z-INDEX: 109; LEFT: 232px; POSITION: absolute; TOP: 19px" runat="server">Choose Start Date</asp:label><asp:label id="Label3" style="Z-INDEX: 110; LEFT: 483px; POSITION: absolute; TOP: 19px" runat="server">Choose End Date</asp:label><asp:comparevalidator id="CompareVal_StartDate" style="Z-INDEX: 111; LEFT: 23px; POSITION: absolute; TOP: 77px"
				runat="server" Width="159px" Height="40px" Operator="LessThanEqual" ValueToCompare="1/1/2001" Type="Date" ErrorMessage="Start Date must be less than January 1, 2001" ControlToValidate="txtStartDate"></asp:comparevalidator>
			<asp:Label id="Label4" style="Z-INDEX: 112; LEFT: 32px; POSITION: absolute; TOP: 256px" runat="server"
				Width="424px" ForeColor="#FF8080" Font-Bold="True" EnableViewState="False"></asp:Label></form>
	</body>
</HTML>
