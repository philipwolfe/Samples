<%	' if Session("DataSource") = "" then response.redirect("connect.aspx") %>

<frameset rows="30, *, 4"  border="0">
	<frame src="titlebar.aspx" scrolling="no" noresize scrolling=no frameborder=0>
	<frameset cols="4, *, 5">
		<frame src="windowDesign/leftside.aspx" noresize scrolling=no frameborder=0>
		<frameset rows="26, 1, *, 25" border="1">
			<frame src="navbar.aspx" scrolling="no" noresize frameborder=0>
			<frame frameborder="1">
			<frameset cols="210, *"  FRAMEBORDER="yes" BORDERCOLOR="#cccccc" border="0">
				<frame src="databases.aspx" Name="LeftFrame" frameborder=1>
				<frame src="setDatabase.aspx" Name="MainFrame"  frameborder=1>
			</frameset>
			<frame src="windowDesign/StatusBar.aspx" noresize scrolling=no frameborder=1>
		</frameset>
		<frame src="windowDesign/rightside.aspx" noresize scrolling=no	 frameborder=0>
	</frameset>	
	<frame src="windowDesign/bottom.aspx" noresize scrolling=no frameborder=0>
</frameset>