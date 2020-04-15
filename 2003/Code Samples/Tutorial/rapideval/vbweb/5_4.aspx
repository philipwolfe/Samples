<%@ Register TagPrefix="uc" TagName="Footer" Src="../Inc/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="links" Src="../links.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Welcome to the Visual Studio .NET 2003 Rapid Evaluation</title>
		<LINK rel="stylesheet" type="text/css" href="../Inc/Styles.css">
			<script language="JavaScript">
<!--
  function mmLoadMenus() {

	if (window.mm_menu_Step6) return;

//menu 1
window.mm_menu_Step1 = new Menu("root",215,22,"Verdana, Arial, Helvetica, sans-serif",12,"#000000","#ffffff","#dcdcdc","#a9a9a9","left","middle",0,0,700,-5,7,true,true,true,10,false,false);
mm_menu_Step1.addMenuItem("<p class='drop'><a href='1_1.aspx'>Introduction</a></p>");
mm_menu_Step1.addMenuItem("<p class='drop'><a href='1_2.aspx'>Create Project</a></p>");
mm_menu_Step1.addMenuItem("<p class='drop'><a href='1_3.aspx'>Solution Explorer</a></p>");
mm_menu_Step1.hideOnMouseOut=true;
mm_menu_Step1.menuBorder=1;
mm_menu_Step1.menuLiteBgColor='#ffffff';
mm_menu_Step1.menuBorderBgColor='#000000';
mm_menu_Step1.bgColor='#333333';
//menu 2
window.mm_menu_Step2 = new Menu("root",215,22,"Verdana, Arial, Helvetica, sans-serif",12,"#000000","#ffffff","#dcdcdc","#a9a9a9","left","middle",0,0,700,-5,7,true,true,true,10,false,false);
mm_menu_Step2.addMenuItem("<p class='drop'><a href='2_1.aspx'>Introduction</a></p>");
mm_menu_Step2.addMenuItem("<p class='drop'><a href='2_2.aspx'>Add Labels and Dropdown</a></p>");
mm_menu_Step2.addMenuItem("<p class='drop'><a href='2_3.aspx'>Add Textboxes</a></p>");
mm_menu_Step2.addMenuItem("<p class='drop'><a href='2_4.aspx'>Add Calendars</a></p>");
mm_menu_Step2.addMenuItem("<p class='drop'><a href='2_5.aspx'>Add Button and Datagrid</a></p>");
mm_menu_Step2.hideOnMouseOut=true;
mm_menu_Step2.menuBorder=1;
mm_menu_Step2.menuLiteBgColor='#ffffff';
mm_menu_Step2.menuBorderBgColor='#000000';
mm_menu_Step2.bgColor='#333333';
//menu 3
window.mm_menu_Step3 = new Menu("root",215,22,"Verdana, Arial, Helvetica, sans-serif",12,"#000000","#ffffff","#dcdcdc","#a9a9a9","left","middle",0,0,700,-5,7,true,true,true,10,false,false);
mm_menu_Step3.addMenuItem("<p class='drop'><a href='3_1.aspx'>AutoFormat Calendar</a></p>");
mm_menu_Step3.addMenuItem("<p class='drop'><a href='3_2.aspx'>AutoFormat Datagrid</a></p>");
mm_menu_Step3.addMenuItem("<p class='drop'><a href='3_3.aspx'>PropertyBuilder</a></p>");
mm_menu_Step3.addMenuItem("<p class='drop'><a href='3_4.aspx'>Validation</a></p>");
mm_menu_Step3.hideOnMouseOut=true;
mm_menu_Step3.menuBorder=1;
mm_menu_Step3.menuLiteBgColor='#ffffff';
mm_menu_Step3.menuBorderBgColor='#000000';
mm_menu_Step3.bgColor='#333333';
//menu 4
window.mm_menu_Step4 = new Menu("root",215,22,"Verdana, Arial, Helvetica, sans-serif",12,"#000000","#ffffff","#dcdcdc","#a9a9a9","left","middle",0,0,700,-5,7,true,true,true,10,false,false);
mm_menu_Step4.addMenuItem("<p class='drop'><a href='4_1.aspx'>Introduction</a></p>");
mm_menu_Step4.addMenuItem("<p class='drop'><a href='4_2.aspx'>Add Data Files</a></p>");
mm_menu_Step4.addMenuItem("<p class='drop'><a href='4_3.aspx'>Define Dataset</a></p>");
mm_menu_Step4.addMenuItem("<p class='drop'><a href='4_4.aspx'>Dropdown Properties</a></p>");
mm_menu_Step4.addMenuItem("<p class='drop'><a href='4_5.aspx'>Dataset Properties</a></p>");
mm_menu_Step4.hideOnMouseOut=true;
mm_menu_Step4.menuBorder=1;
mm_menu_Step4.menuLiteBgColor='#ffffff';
mm_menu_Step4.menuBorderBgColor='#000000';
mm_menu_Step4.bgColor='#333333';
//menu 5
window.mm_menu_Step5 = new Menu("root",215,22,"Verdana, Arial, Helvetica, sans-serif",12,"#000000","#ffffff","#dcdcdc","#a9a9a9","left","middle",0,0,700,-5,7,true,true,true,10,false,false);
mm_menu_Step5.addMenuItem("<p class='drop'><a href='5_1.aspx'>Introduction</a></p>");
mm_menu_Step5.addMenuItem("<p class='drop'><a href='5_2.aspx'>Page Load</a></p>");
mm_menu_Step5.addMenuItem("<p class='drop'><a href='5_3.aspx'>Calendars</a></p>");
mm_menu_Step5.addMenuItem("<p class='drop'><a href='5_4.aspx'><img src='../images/arrow_dropdown.gif' border=0>&nbsp;<B>ButtonClick</B></a></p>");
mm_menu_Step5.addMenuItem("<p class='drop'><a href='5_5.aspx'>Format Date</a></p>");
mm_menu_Step5.addMenuItem("<p class='drop'><a href='5_6.aspx'>Datagrid Paging</a></p>");
mm_menu_Step5.addMenuItem("<p class='drop'><a href='5_7.aspx'>Datagrid Editing</a></p>");
mm_menu_Step5.hideOnMouseOut=true;
mm_menu_Step5.menuBorder=1;
mm_menu_Step5.menuLiteBgColor='#ffffff';
mm_menu_Step5.menuBorderBgColor='#000000';
mm_menu_Step5.bgColor='#333333';
//menu 6
window.mm_menu_Step6 = new Menu("root",215,22,"Verdana, Arial, Helvetica, sans-serif",12,"#000000","#ffffff","#dcdcdc","#a9a9a9","left","middle",0,0,700,-5,7,true,true,true,10,false,false);
mm_menu_Step6.addMenuItem("<p class='drop'><a href='6_1.aspx'>Launch Application</a></p>");
mm_menu_Step6.addMenuItem("<p class='drop'><a href='6_2.aspx'>Test Sample Validation</a></p>");
mm_menu_Step6.addMenuItem("<p class='drop'><a href='6_3.aspx'>Update Data</a></p>");
mm_menu_Step6.addMenuItem("<p class='drop'><a href='6_4.aspx'>Next Steps</a></p>");
mm_menu_Step6.hideOnMouseOut=true;
mm_menu_Step6.menuBorder=1;
mm_menu_Step6.menuLiteBgColor='#ffffff';
mm_menu_Step6.menuBorderBgColor='#000000';
mm_menu_Step6.bgColor='#333333';


	mm_menu_Step6.writeMenus();

} // mmLoadMenus()

//-->
			</script>
			<script language="JavaScript1.2" src="../Inc/mm_menu.js"></script>
			<script language="JavaScript" type="text/JavaScript">
<!--
function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}
//-->
			</script>
	</HEAD>
	<body bgColor="#000066" leftMargin="0" topMargin="0" marginwidth="0" marginheight="0">
		<table cellSpacing="0" cellPadding="0" width="775" align="center" border="0">
			<tr>
				<td><IMG height="10" src="../images/spacer.gif" width="775"></td>
			</tr>
		</table>
		<table borderColor="#ffffff" cellSpacing="0" cellPadding="1" align="center" bgColor="#ffffff"
			border="0" ID="Table2">
			<TBODY>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" bgColor="#ffffff" border="0" ID="Table3">
							<TBODY>
								<tr>
									<td bgColor="#6699cc">
										<table cellSpacing="0" cellPadding="0" width="775" background="../images/headervb.jpg"
											border="0" ID="Table4">
											<tr>
												<td>
													<img src="../images/spacer.gif" height="80" width="1">
												</td>
												<td align="right" valign="bottom">&nbsp;
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td background="../../images/navigation/gradient.gif" bgColor="#ffffff" height="7"><IMG height="10" src="images/spacer.gif" width="1"></td>
								</tr>
								<tr>
									<td bgColor="#ffffff">
										<TABLE WIDTH="760" CELLPADDING="5" CELLSPACING="5">
											<!-- Top Header -->
											<TR>
												<td colspan="2">
													<TABLE WIDTH="756" BORDER="0" CELLPADDING="0" CELLSPACING="0">
														<TR valign="bottom">
															<TD ROWSPAN="2">
																<IMG SRC="../images/navigation/title_VB_web_app.gif" WIDTH="327" HEIGHT="73" ALT=""></TD>
															<TD><table width="429" border="0" cellspacing="0" cellpadding="0">
																	<tr>
																		<td width="1" height="26"><img src="../images/navigation/spacer.gif" width="1" height="51"></td>
																		<td width="15">&nbsp;</td>
																		<td valign="bottom">
																		<td><uc1:links id="uclinks" language="vb" hrefRun="../Samples/OrdersWebVB/WebForm1.aspx" hrefDownload="../Downloads/OrdersWebVB.zip"
																				runat="server"></uc1:links>
																		</td>
																	</tr>
																</table>
															</TD>
														</TR>
														<TR>
															<TD>
																<IMG SRC="../images/navigation/nav_table_top.gif" WIDTH="429" HEIGHT="22" ALT=""></TD>
														</TR>
														<TR>
															<TD colspan="2"><script language="JavaScript1.2">mmLoadMenus();</script><img name="navigation" src="../images/navigation/step_5_web.gif" width="756" height="61"
																	border="0" usemap="#m_navigation" alt=""><map name="m_navigation"><area shape="RECT" coords="5,22,134,52" href="1_1.aspx" alt="" onMouseOut="MM_startTimeout();"
																		onMouseOver="MM_showMenu(window.mm_menu_Step1,15,52,null,'navigation');"><area shape="RECT" coords="142,22,253,52" href="2_1.aspx" alt="" onMouseOut="MM_startTimeout();"
																		onMouseOver="MM_showMenu(window.mm_menu_Step2,145,52,null,'navigation');"><area shape="RECT" coords="260,22,380,52" href="3_1.aspx" alt="" onMouseOut="MM_startTimeout();"
																		onMouseOver="MM_showMenu(window.mm_menu_Step3,265,52,null,'navigation');"><area shape="RECT" coords="394,22,484,52" href="4_1.aspx" alt="" onMouseOut="MM_startTimeout();"
																		onMouseOver="MM_showMenu(window.mm_menu_Step4,400,52,null,'navigation');"><area shape="RECT" coords="495,22,586,52" href="5_1.aspx" alt="" onMouseOut="MM_startTimeout();"
																		onMouseOver="MM_showMenu(window.mm_menu_Step5,500,52,null,'navigation');"><area shape="RECT" coords="599,22,737,52" href="6_1.aspx" alt="" onMouseOut="MM_startTimeout();"
																		onMouseOver="MM_showMenu(window.mm_menu_Step6,605,52,null,'navigation');"></map></TD>
														</TR>
													</TABLE>
													<TABLE WIDTH="756" BORDER="0" CELLPADDING="0" CELLSPACING="0" background="../images/navigation/you_are_here_table.gif"
														ID="Table4">
														<TR>
															<TD width="20"><img src="../images/navigation/spacer.gif" width="20" height="40">
															</TD>
															<TD valign="top" class="maintext"><table width="500" border="0" cellspacing="0" cellpadding="0" ID="Table5">
																	<tr>
																		<td width="105" class="maintext"><img src="../images/navigation/you_are_here.gif" width="95" height="16"></td>
																		<td class="status"><strong>Step 4 of 7: ButtonClick</strong></td>
																	</tr>
																</table>
															</TD>
															<TD valign="top">
																<table width="150" border="0" cellspacing="0" cellpadding="0" ID="Table6">
																	<tr>
																		<td width="89" class="maintext"><a href="5_3.aspx"><img src="../images/navigation/previous.gif" width="89" height="24" border="0" alt="Previous Step"></a></td>
																		<td width="82" class="maintext"><a href="5_5.aspx"><img src="../images/navigation/next.gif" width="89" height="24" border="0" alt="Next Step"></a></td>
																	</tr>
																</table>
															</TD>
															<TD valign="top"><img src="../images/navigation/spacer.gif" width="25" height="1">
															</TD>
														</TR>
													</TABLE>
													<TABLE WIDTH="756" BORDER="0" CELLPADDING="0" CELLSPACING="0">
														<!-- spacer row to make the right gdn nav line up, also provides a spacer -->
														<tr>
															<td><img src="../images/spacer.gif" width="546" height="10"></td>
															<td><img src="../images/spacer.gif" width="200" height="10"></td>
														</tr>
														<!-- content and sidebar table row -->
														<tr valign="top">
															<td width="500">
																<p>Our DataGrid
																	<span class="propvalue">dgOrders</span>
																	will use data from the Orders table. However, we want to filter the data to 
																	show only the rows that match our Customer selection and our date criteria. To 
																	do this, we will utilize a <a href="javascript:openWindow('../Pops/DataView.htm')" class="poplink">
																		DataView</a>.</p>
																<p>In order to implement DataGrid logic like paging and updating, the code to 
																	filter the dataview will be called from more than one function. For this 
																	reason, we will put the FilterOrders logic in a separate function.</p>
																<p><b>Note:</b> When we use DataGrid paging, it is not necessary to load the data 
																	from the data source each time. To simplify the process, the
																	<span class="propValue">dvOrders</span>
																	dataview is placed in a Session variable when
																	<span class="menu">FilterOrders</span>
																	is called. The
																	<span class="menu">BindGrid</span>
																	function just loads the data from the Session variable. The data is not 
																	reloaded unless
																	<span class="menu">FilterOrders</span>
																	is called.</p>
																<P>The RowFilter uses syntax similar to a SQL statement WHERE clause to select 
																	matching rows from the DataSet. Note the use of the StringBuilder class which 
																	performs string concatenation more efficiently than using
																	<span class="propvalue">&amp;</span>
																	to concatenate strings.
																	<ol>
																		<li>
																			Paste the following block of code into the code-behind file.</li></ol>
																	<pre class="csharpcode">
    <span class="kwrd">Private</span> <span class="kwrd">Sub</span> cmdShow_Click(<span class="kwrd">ByVal</span> sender <span class="kwrd">As</span> System.<span 

class="kwrd">Object</span>, _
        <span class="kwrd">ByVal</span> e <span class="kwrd">As</span> System.EventArgs) <span class="kwrd">Handles</span> cmdShow.Click

        FilterOrders()

    <span class="kwrd">End</span> <span class="kwrd">Sub</span>

    <span class="kwrd">Private</span> <span class="kwrd">Sub</span> FilterOrders()

        <span class="kwrd">Dim</span> tableFilter <span class="kwrd">As</span> <span class="kwrd">New</span> System.Text.StringBuilder

        tableFilter.Append(<span class="str">"CustomerID='"</span>)
        tableFilter.Append(ddlCustomers.SelectedItem.Value.ToString())
        tableFilter.Append(<span class="str">"' AND OrderDate &gt;='"</span>)
        tableFilter.Append(txtStartDate.Text)
        tableFilter.Append(<span class="str">"' AND OrderDate &lt;='"</span>)
        tableFilter.Append(txtEndDate.Text)
        tableFilter.Append(<span class="str">"'"</span>)

        dvOrders = dsOrders.Orders.DefaultView
        dvOrders.RowFilter = tableFilter.ToString
        Session(<span class="str">"dvOrders"</span>) = dvOrders
        <span class="kwrd">If</span> dvOrders.Count &gt;  0 <span class="kwrd">Then</span>
            dgOrders.CurrentPageIndex = 0
            dgOrders.Visible = <span class="kwrd">True</span>
        <span class="kwrd">Else</span>
            dgOrders.Visible = <span class="kwrd">False</span>
        <span class="kwrd">End If</span>
        BindGrid()

    <span class="kwrd">End</span> Sub

    <span class="kwrd">Private</span> <span class="kwrd">Sub</span> BindGrid()

        <span class="kwrd">If</span> <span class="kwrd">Not</span> (Session(<span class="str">"dvOrders"</span>) <span class="kwrd">Is</span> <span 

class="kwrd">Nothing</span>) <span class="kwrd">Then</span>
            dvOrders = <span class="kwrd">CType</span>(Session(<span class="str">"dvOrders"</span>), DataView)
        <span class="kwrd">Else</span>
            dvOrders = dsOrders.Orders.DefaultView
        <span class="kwrd">End</span> <span class="kwrd">If</span>

        dgOrders.DataBind()

    <span class="kwrd">End</span> Sub</pre>
															</td>
															<td>
																<!-- Learn More table begin -->
																<TABLE WIDTH="200" BORDER="0" CELLPADDING="0" CELLSPACING="0">
																	<TR>
																		<TD><IMG SRC="../images/sidebar/Learn_more_UL.gif" WIDTH="12" HEIGHT="51"></TD>
																		<TD background="../images/sidebar/Learn_more_top_BG.gif"><div align="center"><IMG SRC="../images/sidebar/Learn_more_top.gif" WIDTH="134" HEIGHT="51"></div>
																		</TD>
																		<TD><IMG SRC="../images/sidebar/Learn_more_UR.gif" WIDTH="18" HEIGHT="51"></TD>
																	</TR>
																	<TR>
																		<TD background="../images/sidebar/Learn_more_left_bg.gif"><img src="../images/sidebar/spacer.gif" width="12" height="10"></TD>
																		<TD width="100%" valign="top" bgcolor="#e5f2ff" class="maintext"><div class="learn">
																				<p>Why use a <a target="_blank" class="vseval" href="http://msdn.microsoft.com/msdnnews/2001/sept/Classroom/Classroom.asp">
																						StringBuilder</a>?</p>
																				<p>
																					More details on <a target="_blank" class="vseval" href="http://msdn.microsoft.com/library/en-us/dv_vbCode/html/vbtskCodeExampleFilteringDataInDataView.asp">
																						Filtering Data in a DataView</a>
																				</p>
																				<p>
																					How do I <a target="_blank" class="vseval" href="http://msdn.microsoft.com/library/en-us/cpguide/html/cpconcreatingusingdataviews.asp">
																						create and use</a> a DataView
																				</p>
																			</div>
																		</TD>
																		<TD background="../images/sidebar/Learn_more_right_BG.gif"><img src="../images/sidebar/spacer.gif" width="18" height="10"></TD>
																	</TR>
																	<TR>
																		<TD><IMG SRC="../images/sidebar/Learn_more_LL.gif" WIDTH="12" HEIGHT="53"></TD>
																		<TD background="../images/sidebar/Learn_more_bottom_BG.gif"><A HREF="http://msdn.microsoft.com/vstudio/" target="_new"><div align="center"><IMG SRC="../images/sidebar/Learn_more_bottom.gif" WIDTH="134" HEIGHT="53" BORDER="0"></div>
																			</A>
																		</TD>
																		<TD><IMG SRC="../images/sidebar/Learn_more_LR.gif" WIDTH="18" HEIGHT="53"></TD>
																	</TR>
																</TABLE>
																<!-- Learn More table end -->
															</td>
														</tr>
														<!-- bottom Where I'm At & Prev/Next table row -->
														<tr valign="top">
															<td colspan="2">
																<table width="745" border="0" cellpadding="0" cellspacing="0" background="../images/navigation/bottom_bg.gif"
																	ID="Table1">
																	<tr>
																		<td width="20"><img src="../images/navigation/spacer.gif" width="20" height="51"></td>
																		<td><table width="500" border="0" cellspacing="0" cellpadding="0" ID="Table7">
																				<tr>
																					<td width="105" class="maintext"><img src="../images/navigation/you_are_here.gif" width="95" height="16"></td>
																					<td class="status"><strong>Step 4 of 7: ButtonClick</strong></td>
																				</tr>
																			</table>
																		</td>
																		<td><table width="150" border="0" cellspacing="0" cellpadding="0" ID="Table8">
																				<tr>
																					<td width="89" class="maintext"><a href="5_3.aspx"><img src="../images/navigation/previous.gif" width="89" height="24" border="0" alt="Previous Step"></a></td>
																					<td width="82" class="maintext"><a href="5_5.aspx"><img src="../images/navigation/next.gif" width="89" height="24" border="0" alt="Next Step"></a></td>
																				</tr>
																			</table>
																		</td>
																		<td width="15"><img src="../images/navigation/spacer.gif" width="15" height="51"></td>
																	</tr>
																</table>
															</td>
														</tr>
													</TABLE>
												</td>
											</TR>
										</TABLE>
									</td>
								</tr>
							</TBODY>
						</table>
						<uc:footer id="ucfooter" runat="server"></uc:footer>
					</td>
				</tr>
			</TBODY>
		</table>
		</FORM>
	</body>
</HTML>
