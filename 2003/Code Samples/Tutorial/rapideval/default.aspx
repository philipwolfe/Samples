<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="VBPromotion._Default" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="Inc/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Welcome to the Visual Studio .NET 2003 Online Evaluation Center</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Inc\styles.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" type="text/JavaScript">
		<!--
	
		function RestoreText()
		{
			var outputText = "Welcome to the Visual Studio .NET 2003 Online Evaluation Center.  Here you will";
			outputText += " learn everything you need to know to quickly get started building ";
			outputText += " broad reaching Web Applications and powerful Windows Applications.";
			outputText += " We have provided step-by-step instructions for guiding you through the process";
			outputText += " of creating your first application. It's easy to get started - just start up your";
			outputText += " copy of Visual Studio .NET and";
			outputText += " click on one of the 2 Walkthroughs on the right.";
			outputText += " Let's create our first program!"
			document.all("divHeaderText").innerText= 'Online Evaluation Center';
			document.all("divBodyText").innerText= outputText;
			document.all("imgVBWin").src = 'images/vb_windows_apps.gif';
			document.all("imgVBWeb").src = 'images/vb_web_apps.gif';
		}
		
		function MouseOverAppImages(appType)
		{
			if(appType=="VBWin")
			{		
				var outputText = "This walkthrough demonstrates how to quickly build";
				outputText += " a Windows Application which implements the core functionality";
				outputText += " of typical applications: searching, retrieving, displaying, and updating"
				outputText += " data in a relational data store.  For those of you who have";
				outputText += " built applications with earlier versions of Visual Studio, you";
				outputText += " will find Visual Studio .NET 2003 provides a development environment";
				outputText += " that is both familiar and much more powerful.";
				document.all("divHeaderText").innerText = 'Visual Basic .NET Windows Applications';
				document.all("divBodyText").innerText= outputText;
				document.all("imgVBWin").src = 'images/vb_windows_over.gif';
			}
			if(appType=="VBWeb")
			{
				var outputText = "This walkthrough demonstrates how to quickly build";
				outputText += " a Web Application using ASP.NET Web Forms.  With ASP.NET, it is"
				outputText += " much easier to implement dynamic data-driven applications";
				outputText += " using techniques familiar to Visual Basic 6 developers, such as dragging";
				outputText += " controls to a form and setting properties.  Even veteran Web developers";
				outputText += " will find that using the ASP.NET built-in controls with Visual Studio"
				outputText += " .NET makes tasks such as creating powerful datagrids for displaying,"
				outputText += " paging and updating data simple and easy.  You'll also learn how very"
				outputText += " simple it is to incorporate XML into your applications."
				document.all("divHeaderText").innerText= 'Visual Basic .NET Web Applications';
				document.all("divBodyText").innerText= outputText;
				document.all("imgVBWeb").src = 'images/vb_web_over.gif';
			}				
		}
		//-->
		</script>
	</HEAD>
	<body bgColor="#000066" leftMargin="0" topMargin="0" marginwidth="0" marginheight="0"
		onload="RestoreText()">
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
										<table cellSpacing="0" cellPadding="0" width="775" background="images/headervb.jpg" border="0"
											ID="Table4" style="WIDTH: 775px; HEIGHT: 54px">
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
										<table cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td vAlign="top" align="left" width="748">
													<!--PAGE CODE GOES HERE-->
													<table onmouseout="RestoreText()" cellSpacing="0" cellPadding="0" width="748" border="0">
														<tr>
															<td width="15"></td>
															<td class="homedescriptiontext" vAlign="top" align="left" width="340" height="260">
																<div id="divHeaderText" class="homeheaders" align="center"></div>
																<br>
																<div id="divBodyText" class="hometext" align="justify"></div>
															</td>
															<td width="15"></td>
															<td bgColor="#cccccc"><IMG alt="" src="images/spacer.gif" width="1">
															</td>
															<td width="15"></td>
															<td>
																<A href="VBWin/1_1.aspx"><IMG id="imgVBWin" onmouseover="MouseOverAppImages('VBWin');" alt="" src="Images/VB_windows_apps.gif"
																		border="0"></A> <A href="VBWeb/1_1.aspx"><IMG id="imgVBWeb" onmouseover="MouseOverAppImages('VBWeb');" alt="" src="Images/VB_web_apps.gif"
																		border="0"></A>
															</td>
														</tr>
														<tr>
															<td colspan="6">
																<br>
																<p class="maintext"><b>Requirements:</b> To complete the walkthroughs you will need 
																	a machine with Visual Studio .NET 2003 Professional, Enterprise or Trial 
																	edition. If you don't already own a copy of Visual Studio .NET 2003, you can 
																	order the <a target="_blank" class="vseval" href="http://msdn.microsoft.com/vstudio/productinfo/trial/">
																		Trial edition on CD</a> or you can <a target="_blank" class="vseval" href="http://msdn.microsoft.com/vstudio/tryit/">
																		try it online</a> if you have a broadband Internet connection</A>. To 
																	complete the Web Application Walkthroughs, you will require access to a machine 
																	running Internet Information Services (IIS) 5.0 or higher.</p>
																<p>&nbsp;</p>
															</td>
														</tr>
													</table>
													<!--PAGE CODE ENDS HERE-->
												</td>
											</tr>
										</table>
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
