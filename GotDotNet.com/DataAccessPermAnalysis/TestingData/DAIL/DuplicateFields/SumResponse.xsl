<?xml version="1.0" encoding="Windows-1255"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:output omit-xml-declaration="yes"  method="text"/>
<xsl:template match="/">

	QUERY_SEPERATOR-NULL-
	&lt;Response id="<xsl:value-of select="Request/@id"/>" action="<xsl:value-of select="Request/@action"/>"&gt;
		<xsl:for-each select="Request/Profile/A/Item">
			&lt;Item id="<xsl:value-of select="."/>"&gt;
				<xsl:variable name="aVal" select="."/>
				<xsl:for-each select="/Request/Data/*">
					<xsl:choose>
						<xsl:when test="self::A">
							&lt;A type="sum"&gt;<xsl:value-of select="$aVal"/>&lt;/A&gt;
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
			&lt;/Item&gt;
		</xsl:for-each>
	&lt;/Response&gt;

	QUERY_SEPERATOR-NULL-
	&lt;Response id="<xsl:value-of select="Request/@id"/>" action="<xsl:value-of select="Request/@action"/>"&gt;
		<xsl:for-each select="Request/Profile/A/Item">
			&lt;Item id="<xsl:value-of select="."/>"&gt;
				<xsl:variable name="cVal" select="."/>
				<xsl:for-each select="/Request/Data/*">
					<xsl:choose>
						<xsl:when test="self::A">
							&lt;A&gt;<xsl:value-of select="$cVal"/>&lt;/A&gt;
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
			&lt;/Item&gt;
		</xsl:for-each>
	&lt;/Response&gt;
</xsl:template>
</xsl:stylesheet>
