<?xml version="1.0" encoding="windows-1255"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!--
	Name:		simpleDateClause.xsl

	Author: Gal Kahana
      
	Creation Date: 21.11.2002
  
	Last Modified: 21.11.2002
  
	Description:
		a simple template for date values
-->
<xsl:output method="text" omit-xml-declaration="yes"/>

<xsl:template name="simpleDateClause">
	<xsl:choose>
		<xsl:when test="@type = 'before'"> &lt; </xsl:when>
		<xsl:when test="@type = 'before+'"> -1 &lt;= </xsl:when>
		<xsl:when test="@type = 'after+'"> &gt;= </xsl:when>
		<xsl:when test="@type = 'after'"> +1 &gt; </xsl:when>
		<xsl:otherwise> = </xsl:otherwise>
	</xsl:choose>
	to_date('<xsl:value-of select="Item"/>','dd/mm/yyyy hh24:mi:ss')
</xsl:template>

</xsl:stylesheet>