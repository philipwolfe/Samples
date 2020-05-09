<?xml version="1.0" encoding="Windows-1255"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:output omit-xml-declaration="yes"  method="text"/>
<xsl:template match="/">

	QUERY_SEPERATOR-NULL-_paramRetrieve_dontMerge
	&lt;Response id="<xsl:value-of select="Request/@id"/>" action="<xsl:value-of select="Request/@action"/>"&gt;
			&lt;Item id="count"&gt;
				&lt;Count&gt;<xsl:value-of select="count(Request/Profile/A/Item)"/>&lt;/Count&gt;
				&lt;Saying&gt;Something stinks&lt;/Saying&gt;
			&lt;/Item&gt;
	&lt;/Response&gt;

	QUERY_SEPERATOR-NULL-
	&lt;Response id="<xsl:value-of select="Request/@id"/>" action="<xsl:value-of select="Request/@action"/>" items="PARAM_REF_0_"&gt;
		<xsl:for-each select="Request/Profile/A/Item">
			&lt;Item id="<xsl:value-of select="."/>"&gt;
				<xsl:variable name="cVal" select="."/>
				<xsl:for-each select="/Request/Data/*">
					<xsl:choose>
						<xsl:when test="self::C">
							&lt;C&gt;<xsl:value-of select="$cVal"/>_C&lt;/C&gt;
							&lt;F&gt;PARAM_REF_1_&lt;/F&gt;
						</xsl:when>
						<xsl:when test="self::D">
							&lt;D&gt;PARAM_REF_1_&lt;/D&gt;
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
			&lt;/Item&gt;
		</xsl:for-each>
	&lt;/Response&gt;
</xsl:template>
</xsl:stylesheet>
