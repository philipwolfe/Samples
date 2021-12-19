<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebFormDHTMLDemo.vb" Inherits="WebFormDHTMLDemo.WebForm1"%>
<html><head>
<meta content="Microsoft Visual Studio.NET 7.0" name=GENERATOR>
<meta content="Visual Basic 7.0" name=CODE_LANGUAGE>
<script language=javascript>
function fillItems() {
	with (document.WebForm1.cboItem) {
		options[0] = new Option("Shirt","Shirt",true,true);
		options[1] = new Option("Pants","Pants");
	}
}
function fillSize() {
	with (document.WebForm1.cboSize) {
		length = 0;

		if (document.WebForm1.cboItem.value == 'Shirt') {
			options[0] = new Option("X-Large","X-Large");
			options[1] = new Option("Large","Large",true,true);
			options[2] = new Option("Medium","Medium");
			options[3] = new Option("Small","Small");
		}
		else if (document.WebForm1.cboItem.value == 'Pants') {
			options[0] = new Option("30W30L","30W30L",true);
			options[1] = new Option("30W32L","30W32L");
			options[2] = new Option("32W30L","32W30L");
			options[3] = new Option("32W32L","32W32L");
			options[4] = new Option("32W34L","32W34L");
			options[5] = new Option("34W30L","34W30L");
			options[6] = new Option("34W32L","34W32L");
			options[7] = new Option("34W34L","34W34L");
			options[8] = new Option("34W34L","34W34L");
			options[9] = new Option("36W32L","36W32L");
			options[10] = new Option("36W34L","36W34L");
			options[11] = new Option("38W32L","38W32L");
			options[12] = new Option("38W34L","38W34L");
			options[13] = new Option("38W36L","38W36L");
		}
	}
}
function fillMedSmallColors() {
	with (document.WebForm1.cboColor) {
		options[0] = new Option("White","White",true,true);
		options[1] = new Option("Gray","Gray");
		options[2] = new Option("Black","Black");
		options[3] = new Option("Red","Red");
		options[4] = new Option("Yellow","Yellow");
	}
}
function fillLargeColors() {
	with (document.WebForm1.cboColor) {
		options[0] = new Option("White","White",true,true);
		options[1] = new Option("Gray","Gray");
		options[2] = new Option("Black","Black");
		options[3] = new Option("Blue","Blue");
		options[4] = new Option("Green","Green");
		options[5] = new Option("Maroon","Maroon");
	}
}
function fillXLargeColors() {
	with (document.WebForm1.cboColor) {
		options[0] = new Option("White","White",true,true);
		options[1] = new Option("Gray","Gray");
		options[2] = new Option("Black","Black");
	}
}
function fillColor() {
	var theSize = document.WebForm1.cboSize.value;
	var theItem = document.WebForm1.cboItem.value;

	with (document.WebForm1.cboColor) {
		length = 0;
		
		if (theItem == 'Shirt') {
			switch(theSize) {
				case 'X-Large':
					fillXLargeColors();
					break;
				case 'Large':
					fillLargeColors();
					break;
				case 'Medium':
					fillMedSmallColors();
					break;
				case 'Small':
					fillMedSmallColors();
					break;
			}
		}
		else if (theItem == 'Pants') {
			theSize = theSize.substr(0,2);
		
			switch(theSize) {
				case '30':
					fill3032Colors();
					break;
				case '32':
					fill3032Colors();
					break;
				case '34':
					fill3436Colors();
					break;
				case '36':
					fill3436Colors();
					break;
				case '38':
					fill38Colors();
					break;
			}
		}
	}
}
function fill3032Colors() {
	with (document.WebForm1.cboColor) {
		options[0] = new Option("Green","Green");
		options[1] = new Option("Beige","Beige");
		options[2] = new Option("Cream","Cream");
		options[3] = new Option("Black","Black");
		options[4] = new Option("Gray","Gray");
	}
}
function fill3436Colors() {
	with (document.WebForm1.cboColor) {
		options[0] = new Option("Green","Green");
		options[1] = new Option("Beige","Beige");
		options[2] = new Option("Cream","Cream");
		options[3] = new Option("Black","Black");
		options[4] = new Option("Gray","Gray");
		options[5] = new Option("Dark Green","Dark Green");
		options[6] = new Option("Tan","Tan");
	}
}
function fill38Colors() {
	with (document.WebForm1.cboColor) {
		options[0] = new Option("Beige","Beige");
		options[1] = new Option("Black","Black");
		options[2] = new Option("Gray","Gray");
	}
}
function showItem() {
	var sMsg = 'Your selection:';
	
	with (document.WebForm1) {
		sMsg += '\n-----------------';
		sMsg += '\nItem: ' + cboItem.value;
		sMsg += '\nSize: ' + cboSize.value;
		sMsg += '\nColor: ' + cboColor.value;
	}
	alert(sMsg);
}
function body_onload() {
	fillItems();
	fillSize();
	fillColor();
}
</script>
</head>
<body onload=body_onload(); ms_positioning="GridLayout">
<table height=261 cellspacing=0 cellpadding=0 width=757 border=0 
ms_2d_layout="TRUE">
  <tr valign=top>
    <td width=10 height=15></td>
    <td width=747></td></tr>
  <tr valign=top>
    <td height=246></td>
    <td>
      <form id=WebForm1 method=post runat="server">
      <table height=207 cellspacing=0 cellpadding=0 width=580 border=0 
      ms_2d_layout="TRUE">
        <tr>
          <td width=0 height=0></td>
          <td width=1 height=0></td>
          <td width=1 height=0></td>
          <td width=1 height=0></td>
          <td width=579 height=0></td></tr>
        <tr valign=top>
          <td width=0 height=15></td>
          <td colspan=4 rowspan=2><asp:label id=Label1 runat="server" Width="564" Height="37" Font-Names="Verdana">When you choose an Item, the Size combo is populated with the available sizes using client-side script and DHTML</asp:Label></td></tr>
        <tr valign=top>
          <td width=0 height=33></td></tr>
        <tr valign=top>
          <td width=0 height=44></td>
          <td></td>
          <td colspan=3>
<asp:Label id=Label2 runat="server" Width="560" Height="38" Font-Names="Verdana">When you choose a Size, the Color combo is populated with the available sizes using client-side script and DHTML</asp:Label></td></tr>
        <tr valign=top>
          <td width=0 height=43></td>
          <td colspan=3></td>
          <td>
<asp:Label id=Label3 runat="server" Width="554" Height="36" Font-Names="Verdana">The Buy Item button displays the current selection using an Alert Dialog</asp:Label></td></tr>
        <tr valign=top>
          <td width=0 height=87></td>
          <td colspan=4>
<asp:table id="Table1" runat="server" Height="71" Width="571" font-names="Verdana">
<asp:TableRow>
<asp:TableCell Text="Item:"></asp:TableCell>
<asp:TableCell Text="<select id=cboItem onchange=fillSize(); size=1 name=cboItem></select>"></asp:TableCell>
<asp:TableCell Text="Size:"></asp:TableCell>
<asp:TableCell Text="
<select id=cboSize name=cboSize onchange=fillColor();></select>"></asp:TableCell>
<asp:TableCell Text="Color:"></asp:TableCell>
<asp:TableCell Text="<select id=cboColor name=cboColor></select>"></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell></asp:TableCell>
<asp:TableCell Text="<input id=btnBuy onclick=showItem(); type=submit value='Buy Item' name=btnBuy>"></asp:TableCell>
<asp:TableCell></asp:TableCell>
<asp:TableCell></asp:TableCell>
<asp:TableCell></asp:TableCell>
<asp:TableCell></asp:TableCell>
</asp:TableRow>
</asp:table></td></tr></table></FORM></td></tr></table>
</body></html>
