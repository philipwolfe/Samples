<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:d="http://schemas.microsoft.com/office/infopath/2003/ado/dataFields" xmlns:dfs="http://schemas.microsoft.com/office/infopath/2003/dataFormSolution" xmlns:my="http://schemas.microsoft.com/office/infopath/2003/myXSD/2005-10-24T16-46-13" xmlns:xd="http://schemas.microsoft.com/office/infopath/2003" version="1.0">
	<xsl:output encoding="UTF-8" method="xml"/>
	<xsl:template match="/">
		<xsl:copy-of select="processing-instruction() | comment()"/>
		<xsl:choose>
			<xsl:when test="my:AdventureWorksProductsOrder">
				<xsl:apply-templates select="my:AdventureWorksProductsOrder" mode="_0"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:variable name="var">
					<xsl:element name="my:AdventureWorksProductsOrder"/>
				</xsl:variable>
				<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_0"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	<xsl:template match="my:Product" mode="_1">
		<xsl:copy>
			<xsl:element name="my:ID">
				<xsl:choose>
					<xsl:when test="my:ID/text()[1]">
						<xsl:copy-of select="my:ID/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:Name">
				<xsl:copy-of select="my:Name/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:Qty">
				<xsl:choose>
					<xsl:when test="my:Qty/text()[1]">
						<xsl:copy-of select="my:Qty/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>1</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:UnitPrice">
				<xsl:copy-of select="my:UnitPrice/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:ExtPrice">
				<xsl:copy-of select="my:ExtPrice/text()[1]"/>
			</xsl:element>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:AdventureWorksProductsOrder" mode="_0">
		<xsl:copy>
			<xsl:choose>
				<xsl:when test="my:Product">
					<xsl:apply-templates select="my:Product" mode="_1"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:Product"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_1"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:element name="my:SelectedCategory">
				<xsl:copy-of select="my:SelectedCategory/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:SubTotal">
				<xsl:choose>
					<xsl:when test="my:SubTotal/text()[1]">
						<xsl:copy-of select="my:SubTotal/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:Tax">
				<xsl:choose>
					<xsl:when test="my:Tax/text()[1]">
						<xsl:copy-of select="my:Tax/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:Total">
				<xsl:choose>
					<xsl:when test="my:Total/text()[1]">
						<xsl:copy-of select="my:Total/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>