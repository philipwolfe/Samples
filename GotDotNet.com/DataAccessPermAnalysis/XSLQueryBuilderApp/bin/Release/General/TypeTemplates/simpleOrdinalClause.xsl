<?xml version="1.0" encoding="windows-1255"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!--
	Name:		simpleOrdinalClause.xsl

	Author: Gal Kahana
      
	Creation Date: 21.11.2002
  
	Last Modified: 21.11.2002
  
	Description:
		a simple template for ordinal values
-->
<xsl:output method="text" omit-xml-declaration="yes"/>

<xsl:template name="simpleOrdinalClause">

	<xsl:choose>
		<xsl:when test = "count(Item) = 1">
			<xsl:choose>
				<xsl:when test="@type = 'before'"> &lt; </xsl:when>
				<xsl:when test="@type = 'before+'"> &lt;= </xsl:when>
				<xsl:when test="@type = 'after+'"> &gt;= </xsl:when>
				<xsl:when test="@type = 'after'"> &gt; </xsl:when>
				<xsl:otherwise> = </xsl:otherwise>
			</xsl:choose>
			<xsl:value-of select = "Item"/>
		</xsl:when>
		<xsl:otherwise>
			in (
			<xsl:for-each select="Item">
				<xsl:if test="position()!=1">, </xsl:if>
				<xsl:value-of select="." />
			</xsl:for-each>
			)
		</xsl:otherwise>						
	</xsl:choose>
</xsl:template>

</xsl:stylesheet>