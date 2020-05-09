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
							&lt;A&gt;A&lt;/A&gt;
						</xsl:when>
						<xsl:when test="self::B">
							&lt;B order="1"&gt;1&lt;/B&gt;
							&lt;B order="3"&gt;3&lt;/B&gt;
							&lt;B order="5"&gt;5&lt;/B&gt;
						</xsl:when>
						<xsl:when test="self::C">
							&lt;C&gt;C&lt;/C&gt;
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
						<xsl:when test="self::D">
							&lt;D&gt;D&lt;/D&gt;
						</xsl:when>
						<xsl:when test="self::B">
							&lt;B order="2"&gt;2&lt;/B&gt;
							&lt;B order="4"&gt;4&lt;/B&gt;
						</xsl:when>
						<xsl:when test="self::E">
							&lt;E&gt;E&lt;/E&gt;
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
			&lt;/Item&gt;
		</xsl:for-each>
	&lt;/Response&gt;
</xsl:template>
</xsl:stylesheet>
