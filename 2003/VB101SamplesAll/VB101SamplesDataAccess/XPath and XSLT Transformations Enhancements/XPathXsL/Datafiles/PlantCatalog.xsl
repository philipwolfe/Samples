<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:msxsl ="urn:schemas-microsoft-com:xslt"
                xmlns="http://www.w3.org/TR/xhtml1/strict">

	<xsl:param name="parameter1"/>

	<xsl:template match="/">
		
		<html>
			<head>
				<title>My Plants</title>
			</head>
			<body>
				<table>
					<tr>
						<td bgcolor="#336699" colspan="2">
							<font face="Arial" size="3" color="#FFFFFF">
								<b>My Plants</b>
							</font>
						</td>
					</tr>
					<xsl:for-each select="$parameter1">
						<tr>
							<td>
								<font face="Arial" size="2">
									<b>
										Plant Name:
									</b>
								</font>
							</td>
							<td>
								<font face="Arial" size="2">
									<xsl:value-of select="COMMON"/>(<i>
										<xsl:value-of select="BOTANICAL"/>
									</i>)
								</font>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<hr size="1"></hr>
							</td>
						</tr>
						<tr>
							<td>
								<font face="Arial" size="2">
									<b>Zone/Light</b>
								</font>
							</td>
							<td>
								<font face="Arial" size="2">
									<xsl:value-of select="ZONE"/>/
									<xsl:value-of select="LIGHT"/>
								</font>
								
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<hr size="1"></hr>
							</td>
						</tr>

						<tr>
							<td>
								<font face="Arial" size="2">
									<b>Price/Availability</b>
								</font>
							</td>
							<td>
								<font face="Arial" size="2">
									$<xsl:value-of select="PRICE"/>/
									<xsl:value-of select="AVAILABILITY"/>
								</font>

							</td>
						</tr>
						<tr>
							<td colspan="2" bgColor="#000000">
								<hr size="2"></hr>
							</td>
						</tr>
					</xsl:for-each>
					
				</table>
				
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
	