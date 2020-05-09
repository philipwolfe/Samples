<?xml version="1.0" encoding="windows-1255"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!--
	Name:		BVQDateClause.xsl

	Author: Gal Kahana
      
	Creation Date: 25.5.2002
  
	Last Modified: 25.5.2002
  
	Description:
		a template for date values assiging BVQ params
-->
<xsl:output method="text" omit-xml-declaration="yes"/>

<xsl:template name="BVQDateClause">
	<xsl:choose>
		<xsl:when test="@type = 'before'"> &lt; </xsl:when>
		<xsl:when test="@type = 'before+'"> -1 &lt;= </xsl:when>
		<xsl:when test="@type = 'after+'"> &gt;= </xsl:when>
		<xsl:when test="@type = 'after'"> +1 &gt; </xsl:when>
		<xsl:otherwise> = </xsl:otherwise>
	</xsl:choose>
	to_date(?,'dd/mm/yyyy hh24:mi:ss')
</xsl:template>

</xsl:stylesheet>