<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:d="http://schemas.microsoft.com/office/infopath/2003/ado/dataFields" xmlns:dfs="http://schemas.microsoft.com/office/infopath/2003/dataFormSolution" xmlns:my="http://schemas.microsoft.com/office/infopath/2003/myXSD/2005-10-24T16-46-13" xmlns:xd="http://schemas.microsoft.com/office/infopath/2003" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns:xdExtension="http://schemas.microsoft.com/office/infopath/2003/xslt/extension" xmlns:xdXDocument="http://schemas.microsoft.com/office/infopath/2003/xslt/xDocument" xmlns:xdSolution="http://schemas.microsoft.com/office/infopath/2003/xslt/solution" xmlns:xdFormatting="http://schemas.microsoft.com/office/infopath/2003/xslt/formatting" xmlns:xdImage="http://schemas.microsoft.com/office/infopath/2003/xslt/xImage" xmlns:xdUtil="http://schemas.microsoft.com/office/infopath/2003/xslt/Util" xmlns:xdMath="http://schemas.microsoft.com/office/infopath/2003/xslt/Math" xmlns:xdDate="http://schemas.microsoft.com/office/infopath/2003/xslt/Date" xmlns:sig="http://www.w3.org/2000/09/xmldsig#" xmlns:xdSignatureProperties="http://schemas.microsoft.com/office/infopath/2003/SignatureProperties">
	<xsl:output method="html" indent="no"/>
	<xsl:template match="my:AdventureWorksProductsOrder">
		<html>
			<head>
				<meta http-equiv="Content-Type" content="text/html"></meta>
				<style controlStyle="controlStyle">@media screen 			{ 			BODY{margin-left:21px;background-position:21px 0px;} 			} 		BODY{color:windowtext;background-color:window;layout-grid:none;} 		.xdListItem {display:inline-block;width:100%;vertical-align:text-top;} 		.xdListBox,.xdComboBox{margin:1px;} 		.xdInlinePicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) } 		.xdLinkedPicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) url(#default#urn::controls/Binder) } 		.xdSection{border:1pt solid #FFFFFF;margin:6px 0px 6px 0px;padding:1px 1px 1px 5px;} 		.xdRepeatingSection{border:1pt solid #FFFFFF;margin:6px 0px 6px 0px;padding:1px 1px 1px 5px;} 		.xdBehavior_Formatting {BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting);} 	 .xdBehavior_FormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting);} 	.xdExpressionBox{margin: 1px;padding:1px;word-wrap: break-word;text-overflow: ellipsis;overflow-x:hidden;}.xdBehavior_GhostedText,.xdBehavior_GhostedTextNoBUI{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#TextField) url(#default#GhostedText);}	.xdBehavior_GTFormatting{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_GTFormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_Boolean{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#BooleanHelper);}	.xdBehavior_Select{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#SelectHelper);}	.xdRepeatingTable{BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word;}.xdScrollableRegion{BEHAVIOR: url(#default#ScrollableRegion);} 		.xdMaster{BEHAVIOR: url(#default#MasterHelper);} 		.xdActiveX{margin:1px; BEHAVIOR: url(#default#ActiveX);} 		.xdFileAttachment{display:inline-block;margin:1px;BEHAVIOR:url(#default#urn::xdFileAttachment);} 		.xdPageBreak{display: none;}BODY{margin-right:21px;} 		.xdTextBoxRTL{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:right;} 		.xdRichTextBoxRTL{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-overflow:ellipsis;text-align:right;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTTextRTL{height:100%;width:100%;margin-left:22px;overflow:hidden;padding:0px;white-space:nowrap;} 		.xdDTButtonRTL{margin-right:-21px;height:18px;width:20px;behavior: url(#default#DTPicker);}.xdTextBox{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:left;} 		.xdRichTextBox{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-overflow:ellipsis;text-align:left;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTPicker{;display:inline;margin:1px;margin-bottom: 2px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;} 		.xdDTText{height:100%;width:100%;margin-right:22px;overflow:hidden;padding:0px;white-space:nowrap;} 		.xdDTButton{margin-left:-21px;height:18px;width:20px;behavior: url(#default#DTPicker);} 		.xdRepeatingTable TD {VERTICAL-ALIGN: top;}</style>
				<style tableEditor="TableStyleRulesID">TABLE.xdLayout TD {
	BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none
}
TABLE.msoUcTable TD {
	BORDER-RIGHT: 1pt solid; BORDER-TOP: 1pt solid; BORDER-LEFT: 1pt solid; BORDER-BOTTOM: 1pt solid
}
TABLE {
	BEHAVIOR: url (#default#urn::tables/NDTable)
}
</style>
				<style languageStyle="languageStyle">BODY {
	FONT-SIZE: 10pt; FONT-FAMILY: Verdana
}
TABLE {
	FONT-SIZE: 10pt; FONT-FAMILY: Verdana
}
SELECT {
	FONT-SIZE: 10pt; FONT-FAMILY: Verdana
}
.optionalPlaceholder {
	PADDING-LEFT: 20px; FONT-WEIGHT: normal; FONT-SIZE: xx-small; BEHAVIOR: url(#default#xOptional); COLOR: #333333; FONT-STYLE: normal; FONT-FAMILY: Verdana; TEXT-DECORATION: none
}
.langFont {
	FONT-FAMILY: Verdana
}
</style>
			</head>
			<body>
				<div>
					<table class="xdFormLayout xdLayout" style="TABLE-LAYOUT: fixed; WIDTH: 693px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1">
						<colgroup>
							<col style="WIDTH: 693px"></col>
						</colgroup>
						<tbody vAlign="top">
							<tr class="primaryVeryDark" style="MIN-HEIGHT: 40px">
								<td style="BORDER-TOP-STYLE: none; BORDER-BOTTOM: 5pt solid; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: #000080">
									<div>
										<font color="#ffffff" size="4">Adventure Works Order Form</font>
									</div>
								</td>
							</tr>
						</tbody>
					</table>
				</div>
				<div>
					<strong>
						<font style="FONT-SIZE: 15pt"></font>
					</strong> </div>
				<div>
					<strong>
						<font style="FONT-SIZE: 11pt">Available Products</font>
					</strong>
				</div>
				<div>
					<strong>
						<font style="FONT-SIZE: 11pt"></font>
					</strong> </div>
				<div>Category: <select class="xdComboBox xdBehavior_Select" title="" style="WIDTH: 130px" size="1" xd:binding="my:SelectedCategory" xd:boundProp="value" value="" xd:xctname="DropDown" xd:CtrlId="CTRL53" tabIndex="0">
						<xsl:attribute name="value">
							<xsl:value-of select="my:SelectedCategory"/>
						</xsl:attribute>
						<xsl:choose>
							<xsl:when test="function-available('xdXDocument:GetDOM')">
								<option/>
								<xsl:variable name="val" select="my:SelectedCategory"/>
								<xsl:if test="not(xdXDocument:GetDOM(&quot;ProductSubcategory&quot;)/dfs:myFields/dfs:dataFields/d:ProductSubcategory[@ProductSubcategoryID=$val] or $val='')">
									<option selected="selected">
										<xsl:attribute name="value">
											<xsl:value-of select="$val"/>
										</xsl:attribute>
										<xsl:value-of select="$val"/>
									</option>
								</xsl:if>
								<xsl:for-each select="xdXDocument:GetDOM(&quot;ProductSubcategory&quot;)/dfs:myFields/dfs:dataFields/d:ProductSubcategory">
									<option>
										<xsl:attribute name="value">
											<xsl:value-of select="@ProductSubcategoryID"/>
										</xsl:attribute>
										<xsl:if test="$val=@ProductSubcategoryID">
											<xsl:attribute name="selected">selected</xsl:attribute>
										</xsl:if>
										<xsl:value-of select="@Name"/>
									</option>
								</xsl:for-each>
							</xsl:when>
							<xsl:otherwise>
								<option>
									<xsl:value-of select="my:SelectedCategory"/>
								</option>
							</xsl:otherwise>
						</xsl:choose>
					</select> <input class="langFont" title="" type="button" value="Get Products" xd:xctname="Button" xd:CtrlId="getProductsButton" tabIndex="0">
						<xsl:choose>
							<xsl:when test="my:SelectedCategory = &quot;&quot;">
								<xsl:attribute name="disabled">true</xsl:attribute>
							</xsl:when>
						</xsl:choose>
					</input>
				</div>
				<div> </div>
				<div/>
				<div/>
				<div>
					<strong>
						<font style="FONT-SIZE: 13pt">
							<div class="xdSection xdScrollableRegion" title="" style="OVERFLOW-Y: auto; PADDING-LEFT: 1px; WIDTH: 693px; HEIGHT: 137px; BACKGROUND-COLOR: #fffbdf" align="left" xd:xctname="ScrollableRegion" xd:CtrlId="CTRL78_5">
								<div>
									<table class="xdRepeatingTable msoUcTable" title="" style="TABLE-LAYOUT: fixed; WIDTH: 686px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1" xd:CtrlId="CTRL64">
										<colgroup>
											<col style="WIDTH: 50px"></col>
											<col style="WIDTH: 300px"></col>
											<col style="WIDTH: 142px"></col>
											<col style="WIDTH: 101px"></col>
											<col style="WIDTH: 93px"></col>
										</colgroup>
										<tbody class="xdTableHeader">
											<tr>
												<td style="BACKGROUND-COLOR: #99ccff">
													<div>
														<strong>
															<font color="#333399">ID</font>
														</strong>
													</div>
												</td>
												<td style="BACKGROUND-COLOR: #99ccff">
													<div>
														<strong>
															<font color="#333399">Name</font>
														</strong>
													</div>
												</td>
												<td style="BACKGROUND-COLOR: #99ccff">
													<div>
														<strong>
															<font color="#333399">SKU</font>
														</strong>
													</div>
												</td>
												<td style="BACKGROUND-COLOR: #99ccff">
													<div>
														<strong>
															<font color="#333399">Color</font>
														</strong>
													</div>
												</td>
												<td style="BACKGROUND-COLOR: #99ccff">
													<div>
														<strong>
															<font color="#333399">List Price</font>
														</strong>
													</div>
												</td>
											</tr>
										</tbody><tbody xd:xctname="RepeatingTable">
											<xsl:if test="function-available('xdXDocument:GetDOM')">
												<xsl:for-each select="xdXDocument:GetDOM(&quot;Products&quot;)/dfs:myFields/dfs:dataFields/d:Product">
													<tr>
														<td><span class="xdExpressionBox xdDataBindingUI" title="" tabIndex="-1" xd:xctname="ExpressionBox" xd:CtrlId="CTRL73" xd:datafmt="&quot;number&quot;,&quot;numDigits:0;negativeOrder:1;&quot;" xd:disableEditing="yes" style="WIDTH: 100%">
																<xsl:choose>
																	<xsl:when test="function-available('xdFormatting:formatString')">
																		<xsl:value-of select="xdFormatting:formatString(@ProductID,&quot;number&quot;,&quot;numDigits:0;negativeOrder:1;&quot;)"/>
																	</xsl:when>
																	<xsl:otherwise>
																		<xsl:value-of select="@ProductID"/>
																	</xsl:otherwise>
																</xsl:choose>
															</span>
														</td>
														<td><span class="xdExpressionBox xdDataBindingUI" title="" tabIndex="-1" xd:xctname="ExpressionBox" xd:CtrlId="CTRL74" xd:disableEditing="yes" style="WIDTH: 100%">
																<xsl:value-of select="@Name"/>
															</span>
														</td>
														<td><span class="xdExpressionBox xdDataBindingUI" title="" tabIndex="-1" xd:xctname="ExpressionBox" xd:CtrlId="CTRL75" xd:disableEditing="yes" style="WIDTH: 100%">
																<xsl:value-of select="@ProductNumber"/>
															</span>
														</td>
														<td><span class="xdExpressionBox xdDataBindingUI" title="" tabIndex="-1" xd:xctname="ExpressionBox" xd:CtrlId="CTRL76" xd:disableEditing="yes" style="WIDTH: 100%">
																<xsl:value-of select="@Color"/>
															</span>
														</td>
														<td><span class="xdExpressionBox xdDataBindingUI xdBehavior_Formatting" title="" tabIndex="-1" xd:binding="@ListPrice" xd:xctname="ExpressionBox" xd:CtrlId="CTRL77" xd:datafmt="&quot;currency&quot;,&quot;numDigits:2;negativeOrder:0;positiveOrder:0;currencyLocale:1033;&quot;" xd:disableEditing="yes" style="WIDTH: 100%; WHITE-SPACE: normal; TEXT-ALIGN: right">
																<xsl:attribute name="xd:num">
																	<xsl:value-of select="@ListPrice"/>
																</xsl:attribute>
																<xsl:choose>
																	<xsl:when test="function-available('xdFormatting:formatString')">
																		<xsl:value-of select="xdFormatting:formatString(@ListPrice,&quot;currency&quot;,&quot;numDigits:2;negativeOrder:0;positiveOrder:0;currencyLocale:1033;&quot;)"/>
																	</xsl:when>
																	<xsl:otherwise>
																		<xsl:value-of select="@ListPrice"/>
																	</xsl:otherwise>
																</xsl:choose>
															</span>
														</td>
													</tr>
												</xsl:for-each>
											</xsl:if>
										</tbody>
									</table>
								</div>
								<div> </div>
								<div> </div>
								<div> </div>
							</div>
						</font>
					</strong>
				</div>
				<div>
					<strong>
						<font style="FONT-SIZE: 11pt">My Order</font>
					</strong>
				</div>
				<div>
					<font size="1"></font> </div>
				<div>
					<font size="1">Enter a Product ID from the list of products in the category you selected. Then enter a desired quantity:</font>
				</div>
				<div>
					<font size="1"></font> </div>
				<div>
					<table class="xdRepeatingTable msoUcTable" title="" style="TABLE-LAYOUT: fixed; WIDTH: 691px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1" xd:CtrlId="CTRL45">
						<colgroup>
							<col style="WIDTH: 54px"></col>
							<col style="WIDTH: 420px"></col>
							<col style="WIDTH: 49px"></col>
							<col style="WIDTH: 80px"></col>
							<col style="WIDTH: 88px"></col>
						</colgroup>
						<tbody class="xdTableHeader">
							<tr>
								<td>
									<div>
										<strong>ID</strong>
									</div>
								</td>
								<td>
									<div>
										<strong>Name</strong>
									</div>
								</td>
								<td>
									<div>
										<strong>Qty</strong>
									</div>
								</td>
								<td>
									<div>
										<strong>Unit Price</strong>
									</div>
								</td>
								<td>
									<div>
										<strong>Ext Price</strong>
									</div>
								</td>
							</tr>
						</tbody><tbody xd:xctname="RepeatingTable">
							<xsl:for-each select="my:Product">
								<tr>
									<td>
										<div><span class="xdTextBox xdBehavior_Formatting" hideFocus="1" title="" contentEditable="true" tabIndex="0" xd:binding="my:ID" xd:boundProp="xd:num" xd:xctname="PlainText" xd:CtrlId="CTRL63" xd:datafmt="&quot;number&quot;,&quot;numDigits:0;negativeOrder:1;&quot;" style="WIDTH: 100%">
												<xsl:attribute name="xd:num">
													<xsl:value-of select="my:ID"/>
												</xsl:attribute>
												<xsl:choose>
													<xsl:when test="function-available('xdFormatting:formatString')">
														<xsl:value-of select="xdFormatting:formatString(my:ID,&quot;number&quot;,&quot;numDigits:0;negativeOrder:1;&quot;)"/>
													</xsl:when>
													<xsl:otherwise>
														<xsl:value-of select="my:ID"/>
													</xsl:otherwise>
												</xsl:choose>
											</span>
										</div>
									</td>
									<td><span class="xdExpressionBox xdDataBindingUI" title="" tabIndex="-1" xd:xctname="ExpressionBox" xd:CtrlId="CTRL52" xd:disableEditing="yes" style="WIDTH: 100%">
											<xsl:value-of select="my:Name"/>
										</span>
									</td>
									<td><span class="xdTextBox xdBehavior_Formatting" hideFocus="1" title="" contentEditable="true" tabIndex="0" xd:binding="my:Qty" xd:boundProp="xd:num" xd:xctname="PlainText" xd:CtrlId="CTRL47" xd:datafmt="&quot;number&quot;,&quot;numDigits:0;negativeOrder:1;&quot;" style="WIDTH: 100%">
											<xsl:attribute name="xd:num">
												<xsl:value-of select="my:Qty"/>
											</xsl:attribute>
											<xsl:choose>
												<xsl:when test="function-available('xdFormatting:formatString')">
													<xsl:value-of select="xdFormatting:formatString(my:Qty,&quot;number&quot;,&quot;numDigits:0;negativeOrder:1;&quot;)"/>
												</xsl:when>
												<xsl:otherwise>
													<xsl:value-of select="my:Qty"/>
												</xsl:otherwise>
											</xsl:choose>
										</span>
									</td>
									<td><span class="xdExpressionBox xdDataBindingUI xdBehavior_Formatting" title="" tabIndex="-1" xd:binding="my:UnitPrice" xd:xctname="ExpressionBox" xd:CtrlId="CTRL51" xd:datafmt="&quot;currency&quot;,&quot;numDigits:2;negativeOrder:0;positiveOrder:0;currencyLocale:1033;&quot;" xd:disableEditing="yes" style="WIDTH: 100%; WHITE-SPACE: normal; TEXT-ALIGN: right">
											<xsl:attribute name="xd:num">
												<xsl:value-of select="my:UnitPrice"/>
											</xsl:attribute>
											<xsl:choose>
												<xsl:when test="function-available('xdFormatting:formatString')">
													<xsl:value-of select="xdFormatting:formatString(my:UnitPrice,&quot;currency&quot;,&quot;numDigits:2;negativeOrder:0;positiveOrder:0;currencyLocale:1033;&quot;)"/>
												</xsl:when>
												<xsl:otherwise>
													<xsl:value-of select="my:UnitPrice"/>
												</xsl:otherwise>
											</xsl:choose>
										</span>
									</td>
									<td><span class="xdExpressionBox xdDataBindingUI xdBehavior_Formatting" title="" tabIndex="-1" xd:binding="my:ExtPrice" xd:xctname="ExpressionBox" xd:CtrlId="CTRL50" xd:datafmt="&quot;currency&quot;,&quot;numDigits:2;negativeOrder:0;positiveOrder:0;currencyLocale:1033;&quot;" xd:disableEditing="yes" style="WIDTH: 100%; WHITE-SPACE: normal; TEXT-ALIGN: right">
											<xsl:attribute name="xd:num">
												<xsl:value-of select="my:ExtPrice"/>
											</xsl:attribute>
											<xsl:choose>
												<xsl:when test="function-available('xdFormatting:formatString')">
													<xsl:value-of select="xdFormatting:formatString(my:ExtPrice,&quot;currency&quot;,&quot;numDigits:2;negativeOrder:0;positiveOrder:0;currencyLocale:1033;&quot;)"/>
												</xsl:when>
												<xsl:otherwise>
													<xsl:value-of select="my:ExtPrice"/>
												</xsl:otherwise>
											</xsl:choose>
										</span>
									</td>
								</tr>
							</xsl:for-each>
						</tbody>
					</table>
					<div class="optionalPlaceholder" xd:xmlToEdit="Product_9" tabIndex="0" xd:action="xCollection::insert" style="WIDTH: 691px">Add another item to your order</div>
				</div>
				<div align="right">
					<table class="xdLayout" style="BORDER-RIGHT: medium none; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 706px; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word" borderColor="buttontext" border="1">
						<colgroup>
							<col style="WIDTH: 112px"></col>
							<col style="WIDTH: 95px"></col>
							<col style="WIDTH: 499px"></col>
						</colgroup>
						<tbody vAlign="top">
							<tr style="MIN-HEIGHT: 19px">
								<td style="BACKGROUND-COLOR: #3366ff">
									<div align="right">
										<font face="Verdana" color="#ffffff">
											<strong>Subtotal: </strong>
										</font>
									</div>
								</td>
								<td>
									<div>
										<font face="Verdana"><span class="xdExpressionBox xdDataBindingUI xdBehavior_Formatting" title="" tabIndex="-1" xd:binding="my:SubTotal" xd:xctname="ExpressionBox" xd:CtrlId="CTRL82" xd:datafmt="&quot;currency&quot;,&quot;numDigits:2;negativeOrder:0;positiveOrder:0;currencyLocale:1033;&quot;" xd:disableEditing="yes" style="FONT-WEIGHT: normal; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; WIDTH: 100%; WHITE-SPACE: normal; TEXT-ALIGN: right">
												<xsl:attribute name="xd:num">
													<xsl:value-of select="my:SubTotal"/>
												</xsl:attribute>
												<xsl:choose>
													<xsl:when test="function-available('xdFormatting:formatString')">
														<xsl:value-of select="xdFormatting:formatString(my:SubTotal,&quot;currency&quot;,&quot;numDigits:2;negativeOrder:0;positiveOrder:0;currencyLocale:1033;&quot;)"/>
													</xsl:when>
													<xsl:otherwise>
														<xsl:value-of select="my:SubTotal"/>
													</xsl:otherwise>
												</xsl:choose>
											</span>
										</font>
									</div>
								</td>
								<td>
									<div>
										<font face="Verdana"></font> </div>
								</td>
							</tr>
							<tr>
								<td style="BACKGROUND-COLOR: #3366ff">
									<div align="right">
										<font face="Verdana" color="#ffffff">
											<strong>Tax: </strong>
										</font>
									</div>
								</td>
								<td>
									<div>
										<font face="Verdana"><span class="xdExpressionBox xdDataBindingUI xdBehavior_Formatting" title="" tabIndex="-1" xd:binding="my:Tax" xd:xctname="ExpressionBox" xd:CtrlId="CTRL83" xd:datafmt="&quot;currency&quot;,&quot;numDigits:2;negativeOrder:0;positiveOrder:0;currencyLocale:1033;&quot;" xd:disableEditing="yes" style="FONT-WEIGHT: normal; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; WIDTH: 100%; WHITE-SPACE: normal; TEXT-ALIGN: right">
												<xsl:attribute name="xd:num">
													<xsl:value-of select="my:Tax"/>
												</xsl:attribute>
												<xsl:choose>
													<xsl:when test="function-available('xdFormatting:formatString')">
														<xsl:value-of select="xdFormatting:formatString(my:Tax,&quot;currency&quot;,&quot;numDigits:2;negativeOrder:0;positiveOrder:0;currencyLocale:1033;&quot;)"/>
													</xsl:when>
													<xsl:otherwise>
														<xsl:value-of select="my:Tax"/>
													</xsl:otherwise>
												</xsl:choose>
											</span>
										</font>
									</div>
								</td>
								<td>
									<div>
										<font face="Verdana"></font> </div>
								</td>
							</tr>
							<tr>
								<td style="BACKGROUND-COLOR: #000080">
									<div align="right">
										<font face="Verdana" color="#ffffff">
											<strong>Total: </strong>
										</font>
									</div>
								</td>
								<td>
									<div>
										<font face="Verdana"><span class="xdExpressionBox xdDataBindingUI xdBehavior_Formatting" title="" tabIndex="-1" xd:binding="my:Total" xd:xctname="ExpressionBox" xd:CtrlId="CTRL84" xd:datafmt="&quot;currency&quot;,&quot;numDigits:2;negativeOrder:0;positiveOrder:0;currencyLocale:1033;&quot;" xd:disableEditing="yes" style="FONT-WEIGHT: normal; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; WIDTH: 100%; WHITE-SPACE: normal; TEXT-ALIGN: right">
												<xsl:attribute name="xd:num">
													<xsl:value-of select="my:Total"/>
												</xsl:attribute>
												<xsl:choose>
													<xsl:when test="function-available('xdFormatting:formatString')">
														<xsl:value-of select="xdFormatting:formatString(my:Total,&quot;currency&quot;,&quot;numDigits:2;negativeOrder:0;positiveOrder:0;currencyLocale:1033;&quot;)"/>
													</xsl:when>
													<xsl:otherwise>
														<xsl:value-of select="my:Total"/>
													</xsl:otherwise>
												</xsl:choose>
											</span>
										</font>
									</div>
								</td>
								<td>
									<div>
										<font face="Verdana"></font> </div>
								</td>
							</tr>
						</tbody>
					</table>
				</div>
				<div> </div>
				<div> </div>
				<div> </div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
