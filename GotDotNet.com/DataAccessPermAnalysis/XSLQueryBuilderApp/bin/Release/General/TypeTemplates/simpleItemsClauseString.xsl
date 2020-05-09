<?xml version="1.0" encoding="windows-1255"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!--
	Name:		simpleItemsClauseString.xsl

	Author: Gal Kahana
      
	Creation Date: 21.11.2002
  
	Last Modified: 21.11.2002
  
	Description:
		a simple template for multiple or single queries for strings
-->
<xsl:output method="text" omit-xml-declaration="yes"/>

<xsl:template name="simpleItemsClauseString">
	<xsl:choose>
		<xsl:when test = "count(Item) = 1">
			= '<xsl:value-of select = "Item"/>'
		</xsl:when>
		<xsl:otherwise>
			in (
			<xsl:for-each select="Item">
				<xsl:if test="position()!=1">, </xsl:if>
				'<xsl:value-of select="." />'
			</xsl:for-each>
			)
		</xsl:otherwise>						
	</xsl:choose>
</xsl:template>

</xsl:stylesheet>