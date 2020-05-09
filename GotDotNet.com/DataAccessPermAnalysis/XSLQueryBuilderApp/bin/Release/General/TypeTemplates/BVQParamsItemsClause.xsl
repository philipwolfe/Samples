<?xml version="1.0" encoding="windows-1255"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!--
	Name:		BVQParamsItemsClause.xsl

	Author: Gal Kahana
      
	Creation Date: 25.5.2003
  
	Last Modified: 25.5.2003
  
	Description:
		a template for creating the parameter spec for a numeral item
-->
<xsl:output method="text" omit-xml-declaration="yes"/>

<xsl:template name="BVQParamsItemsClause">
	<xsl:param name="itemSeq"/>
	<xsl:for-each select="Item">
	    	<xsl:text>&lt;Param type="number" name="param_</xsl:text>	
	    	<xsl:value-of select="$itemSeq"/>
	    	<xsl:text>_</xsl:text>
	    	<xsl:value-of select="position()"/>
	    	<xsl:text>"&gt;</xsl:text>
		<xsl:value-of select="." />
	    	<xsl:text>&lt;/Param&gt;</xsl:text>		
	</xsl:for-each>
</xsl:template>

</xsl:stylesheet>