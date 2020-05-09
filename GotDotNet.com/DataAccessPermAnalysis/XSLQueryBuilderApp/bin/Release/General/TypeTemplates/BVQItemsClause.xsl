<?xml version="1.0" encoding="windows-1255"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!--
	Name:		BVQItemsClauseString.xsl

	Author: Gal Kahana
      
	Creation Date: 25.5.2003
  
	Last Modified: 25.5.2003
  
	Description:
		a simple tepmlate for multiple or single queries for BVQ params 
-->
<xsl:output method="text" omit-xml-declaration="yes"/>

<xsl:template name="BVQItemsClause">
	<xsl:choose>
		<xsl:when test = "count(Item) = 1">
			= ?
		</xsl:when>
		<xsl:otherwise>
			in (
			<xsl:for-each select="Item">
				<xsl:if test="position()!=1">, </xsl:if>
				?
			</xsl:for-each>
			)
		</xsl:otherwise>						
	</xsl:choose>
</xsl:template>

</xsl:stylesheet>