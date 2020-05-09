<html>

<head>

   <SCRIPT LANGUAGE="JavaScript">
      <!--
      
      function newImage(arg) {
      	if (document.images) {
      		rslt = new Image();
      		rslt.src = arg;
      		return rslt;
      	}
      }
      
      function changeImages() {
      	if (document.images && (preloadFlag == true)) {
      		for (var i=0; i<changeImages.arguments.length; i+=2) {
      			document[changeImages.arguments[i]].src = changeImages.arguments[i+1];
      		}
      	}
      }
      
      var preloadFlag = false;
      function preloadImages() {
      	if (document.images) {

			LeftNavImage1_over = newImage("images/navbar_button_logout_over.gif");
			LeftNavImage2_over = newImage("images/navbar_button_back_over.gif");
			LeftNavImage3_over = newImage("images/navbar_button_forward_over.gif");
			LeftNavImage4_over = newImage("images/navbar_button_refresh_over.gif");
			
			LeftNavImage6_over = newImage("images/navbar_button_Properties_ov.gif");
			LeftNavImage7_over = newImage("images/navbar_button_NewDb_over.gif");
			LeftNavImage8_over = newImage("images/navbar_button_NewLogin_over.gif");
			
			LeftNavImage18_over = newImage("images/navbar_button_Query_over.gif");
			
			LeftNavImage20_over = newImage("images/navbar_button_ToDo_over.gif");
		  	
         preloadFlag = true;
      	}
      }
      
      preloadImages();
      
      // -->
</SCRIPT>

</head>

<body topmargin=2 leftmargin=0 marginheight=0 marginwidth=0 background="images/navbar_background.gif">

<table cellpadding="0" cellspacing="0">
	<tr><td style="background-color: #CCCCCC;">
		<img src="images/spacer.gif" width="1"></td>
	
	<td style="background-color: #666666;">
		<img src="images/spacer.gif" width="1"></td>
	<td>
		&nbsp;&nbsp;&nbsp;
	</td><td>
		<a href="connect.aspx" target="_top"  ONMOUSEOVER="changeImages('NavBarImage1', 'images/navbar_button_logout_over.gif'); return true; "
 					ONMOUSEOUT="changeImages('NavBarImage1', 'images/navBar_button_logout.gif'); return true; ">
		<img src="images/navbar_button_logout.gif" border="0" name="NavBarImage1"></a>
	</td><td>
		&nbsp;&nbsp;&nbsp;&nbsp;
	</td><td>
		<a href="javascript:parent.history.back();"  ONMOUSEOVER="changeImages('NavBarImage2', 'images/navbar_button_back_over.gif'); return true; "
 					ONMOUSEOUT="changeImages('NavBarImage2', 'images/navBar_button_back.gif'); return true; ">
		<img src="images/navbar_button_back.gif" border="0" name="NavBarImage2"></a>
	</td><td>
		&nbsp;
	</td><td>
		<a href="javascript:parent.history.forward();" ONMOUSEOVER="changeImages('NavBarImage3', 'images/navbar_button_forward_over.gif'); return true; "
 					ONMOUSEOUT="changeImages('NavBarImage3', 'images/navBar_button_forward.gif'); return true; ">
		<img src="images/navbar_button_forward.gif" border="0" name="NavBarImage3"></a>
	</td><td>
		&nbsp;&nbsp;&nbsp;&nbsp;
	</td><td>
		<a href='database_properties.aspx' target="MainFrame" ONMOUSEOVER="changeImages('NavBarImage6', 'images/navbar_button_properties_ov.gif'); return true; "
 					ONMOUSEOUT="changeImages('NavBarImage6', 'images/navBar_button_properties.gif'); return true; ">
		<img src="images/navbar_button_Properties.gif" border="0" name="NavBarImage6" ALT="Database Properties"></a>
	</td><td>
		&nbsp;&nbsp;&nbsp;&nbsp;
	</td><td>
		<a href='javascript:parent.frames["MainFrame"].location.reload();'  ONMOUSEOVER="changeImages('NavBarImage4', 'images/navbar_button_refresh_over.gif'); return true; "
 					ONMOUSEOUT="changeImages('NavBarImage4', 'images/navBar_button_refresh.gif'); return true; ">
		<img src="images/navbar_button_refresh.gif" border="0" name="NavBarImage4"></a>
	</td><td>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	</td><td>
		<a href="databases_edit.aspx" target="MainFrame" ONMOUSEOVER="changeImages('NavBarImage7', 'images/navbar_button_NewDB_over.gif'); return true; "
 					ONMOUSEOUT="changeImages('NavBarImage7', 'images/navBar_button_NewDB.gif'); return true; ">
		<img src="images/navbar_button_NewDB.gif" border="0" name="NavBarImage7"></a>
	</td><td>
		<a href="logins_edit.aspx" target="MainFrame" ONMOUSEOVER="changeImages('NavBarImage8', 'images/navbar_button_NewLogin_over.gif'); return true; "
 					ONMOUSEOUT="changeImages('NavBarImage8', 'images/navBar_button_NewLogin.gif'); return true; ">
		<img src="images/navbar_button_NewLogin.gif" border="0" name="NavBarImage8"></a>
	</td><td>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	</td><td>
		<a href="query.aspx" target="MainFrame" ONMOUSEOVER="changeImages('NavBarImage18', 'images/navbar_button_Query_over.gif'); return true; "
 					ONMOUSEOUT="changeImages('NavBarImage18', 'images/navBar_button_Query.gif'); return true; ">
		<img src="images/navbar_button_Query.gif" border="0" name="NavBarImage18"></a>
	</td>
<!--	
	<td>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	</td><td>
		<a href="ToDo.aspx" target="MainFrame" ONMOUSEOVER="changeImages('NavBarImage20', 'images/navbar_button_ToDo_over.gif'); return true; "
 					ONMOUSEOUT="changeImages('NavBarImage20', 'images/navBar_button_ToDo.gif'); return true; ">
		<img src="images/navbar_button_ToDo.gif" border="0" name="NavBarImage20"></a>
	</td>
-->	
	<td>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	</td><td>
		<!-- Begin ReferralPlanet.com Referral Script -->
		<a onclick="refWindow=window.open('http://www.referralplanet.com/referral/windows/referralwindow.asp?id=18','referralWindow','width=350,height=520,scrollbars=yes,menubar=no,resizable=yes'); refWindow.focus(); return false;" target=_blank href="http://www.referralplanet.com/referral/windows/referralWindow.asp?id=17">
		<IMG alt="Click Here To Tell A Friend" src="images/tellafriend.gif" border=0></A>
		<!-- Begin ReferralPlanet.com Referral Script -->
	
		
	</td><td>
	
		
	
	</td></tr>
</table>

</body>
</html>