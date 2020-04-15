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
mm_menu_Step5.addMenuItem("<p class='drop'><a href='5_4.aspx'>ButtonClick</a></p>");
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
mm_menu_Step6.addMenuItem("<p class='drop'><a href='6_4.aspx'><img src='../images/arrow_dropdown.gif' border=0>&nbsp;<B>Next Steps</B></a></p>");
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
															<TD colspan="2"><script language="JavaScript1.2">mmLoadMenus();</script><img name="navigation" src="../images/navigation/step_6_web.gif" width="756" height="61"
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
																		<td class="status"><strong>Step 4 of 4: Next Steps</strong></td>
																	</tr>
																</table>
															</TD>
															<TD valign="top">
																<table width="150" border="0" cellspacing="0" cellpadding="0" ID="Table6">
																	<tr>
																		<td width="89" class="maintext"><a href="4_3.aspx"><img src="../images/navigation/previous.gif" width="89" height="24" border="0" alt="Previous Step"></a></td>
																		<td width="82" class="maintext"></td>
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
														</tr>
														<!-- content and sidebar table row -->
														<tr valign="top">
															<td width="500">
																<p>
																That completes the Visual Basic .NET Web Application walkthrough. We hope 
																you've found the walkthrough useful to bring you up to speed on the features of 
																Visual Studio .NET and the .NET Framework. We'd like to recommend a few options 
																for where you go from here:<p>
																	<ul>
																		<li>
																			Try another <a class="vseval" href="../">rapid evaluation walkthrough.</a>
																		<li>
																			Send us <a class="vseval" href="mailto:vseval@microsoft.com">feedback</a>
																		on the walkthroughs.
																		<li>
																			<a class="vseval" href="http://msdn.microsoft.com/vstudio/howtobuy/default.aspx">Purchase</a>
																		a copy of Visual Studio .NET 2003 so you can use its powerful features to build 
																		applications.
																		<li>
																			Learn more about Visual Studio .NET and the .NET Framework using the references 
																			below.</li>
																	</ul>
																	<table cellSpacing="0" cellPadding="0" border="0">
																		<tr>
																			<td colSpan="3">
																				<IMG height="30" src="spacer.gif" width="1">
																			</td>
																		<TR>
																			<TD vAlign="top" rowSpan="2">
																				<IMG height="123" width="188" alt="" src="../images/helpful_ref_links_1.jpg" border="0">
																			</TD>
																			<TD valign="top" align="left">
																				<IMG alt="" src="../images/helpful_ref_links2.gif">
																			</TD>
																			<td width="100%">&nbsp;</td>
																		</TR>
																		<TR>
																			<TD class="hometext" vAlign="top" colspan="2">There are a lot of great resources 
																				out there for helping you develop .NET applications. Here are a few of them.
																				<table border="0" cellpadding="3" cellspacing="1">
																					<tr valign="top">
																						<td>
																							<IMG height="7" src="../images/imgArwrt.gif" width="7">
																						</td>
																						<td>
																							<A href="http://msdn.microsoft.com/vstudio/">Visual Studio Homepage</A>
																						</td>
																						<td><p>Your first stop to learn about everything Visual Studio .NET</p>
																						</td>
																					</tr>
																					<tr valign="top">
																						<td>
																							<IMG height="7" src="../images/imgArwrt.gif" width="7">
																						</td>
																						<td>
																							<A href="http://msdn.microsoft.com/vstudio/productinfo/vstudio03/overview/whatsnew.asp">
																								What's New in Visual Studio .NET 2003</A>
																						</td>
																						<td>
																							<P>Learn about the range of new features and enhancements for every type of 
																								developer, as well as key improvements directed at mobile device developers and 
																								enterprise developers.</P>
																						</td>
																					</tr>
																					<tr valign="top">
																						<td>
																							<IMG height="7" src="../images/imgArwrt.gif" width="7">
																						</td>
																						<td><A href="http://msdn.microsoft.com/vstudio/productinfo/vstudio03/topten/upgrade.asp">
																								10 Reasons to Upgrade to Visual Studio .NET 2003</A></A></td>
																						<td>
																							<P>See why enhanced support for mobile developers, an improved debugger, and new 
																								ADO.NET managed providers are great reasons to upgrade.
																							</P>
																						</td>
																					</tr>
																					<tr valign="top">
																						<td>
																							<IMG height="7" src="../images/imgArwrt.gif" width="7">
																						</td>
																						<td>
																							<A href="http://www.asp.net">ASP.NET</A>
																						</td>
																						<td>Starting place for ASP.NET information, including the ASP.NET Forums, sample 
																							applications, and QuickStarts.</td>
																					</tr>
																					<tr valign="top">
																						<td>
																							<IMG height="7" src="../images/imgArwrt.gif" width="7">
																						</td>
																						<td>
																							<A href="http://www.windowsforms.org">WindowsForms.org</A>
																						</td>
																						<td>The place for Windows Forms articles, samples, forums, and Windows Forms 
																							community links.</td>
																					</tr>
																					<tr valign="top">
																						<td>
																							<IMG height="7" src="../images/imgArwrt.gif" width="7">
																						</td>
																						<td>
																							<a href="http://msdn.microsoft.com">MSDN</a>
																						</td>
																						<td>The Microsoft Developer Network has a vast array of resources including 
																							webcasts, articles and documentation updated regularly to help you master .NET.</td>
																					</tr>
																					<tr>
																						<td></td>
																						<td></td>
																					</tr>
																				</table>
																			</TD>
																		</TR>
																		<tr>
																			<td colspan="3">
																				<IMG height="15" src="spacer.gif" width="1">
																			</td>
																		</tr>
																		<TR>
																			<TD class="hometext" vAlign="top" colSpan="3">Click on any of the links above to 
																				learn more about developing .NET applications.
																			</TD>
																		</TR>
																		<tr>
																			<td colSpan="3">
																				<IMG height="30" src="../spacer.gif" width="1">
																			</td>
																		</tr>
																		<tr>
																			<td class="hometext" colSpan="3">
																				<P>We hope you find these walkthroughs useful for learning how to build your first 
																					applications using Visual Studio .NET 2003. If you run into issues with the 
																					walkthroughs or have questions or comments, please <A class="vseval" href="mailto:vseval@microsoft.com">
																						send us feedback</A>.</P>
																			</td>
																		</tr>
																	</table>
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
																					<td class="status"><strong>Step 4 of 4: Next Steps</strong></td>
																				</tr>
																			</table>
																		</td>
																		<td><table width="150" border="0" cellspacing="0" cellpadding="0" ID="Table8">
																				<tr>
																					<td width="89" class="maintext"><a href="4_3.aspx"><img src="../images/navigation/previous.gif" width="89" height="24" border="0" alt="Previous Step"></a></td>
																					<td width="82" class="maintext"></td>
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
