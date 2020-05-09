<?xml version="1.0" encoding="Windows-1255"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:output omit-xml-declaration="yes"  method="text"/>
<xsl:template match="/">

	QUERY_SEPERATOR-DAApp-

	select
		'&lt;Item id="' &amp; PersonID &amp; '"&gt;' &amp;
			<xsl:for-each select="Request/Data/*">
				<xsl:choose>
					<xsl:when test="self::FirstName">
						'&lt;FirstName&gt;' &amp; 	FirstName &amp; '&lt;/FirstName&gt;'  &amp;
					</xsl:when>
					<xsl:when test="self::LastName">
						'&lt;LastName&gt;' &amp; 	LastName &amp; '&lt;/LastName&gt;'  &amp;
					</xsl:when>
					<xsl:when test="self::Settlement">
						'&lt;Settlement&gt;' &amp;  Settlement &amp; '&lt;/Settlement&gt;'  &amp;
					</xsl:when>
					<xsl:when test="self::Street">
						'&lt;Street&gt;' &amp; 	Street &amp; '&lt;/Street&gt;'  &amp;
					</xsl:when>
					<xsl:when test="self::HouseNumber">
						'&lt;HouseNumber&gt;' &amp; 	HouseNumber &amp; '&lt;/HouseNumber&gt;'  &amp;
					</xsl:when>
				</xsl:choose>
			</xsl:for-each>
		'&lt;/Item&gt;'
	from PeopleList
	<xsl:if test="Request/Profile">
		where
		<xsl:for-each select="Request/Profile/*">
			<xsl:if test="position()!=1"> AND </xsl:if>
			<xsl:choose>
				<xsl:when test="self::PersonID">
					PersonID
					<xsl:call-template name="simpleItemsQuery"/>
				</xsl:when>
			</xsl:choose>
		</xsl:for-each>
	</xsl:if>

</xsl:template>

<xsl:template name="simpleItemsQuery">
	<xsl:choose>
		<xsl:when test="count(Item) = 1">
			= <xsl:value-of select="Item"/>
		</xsl:when>
		<xsl:otherwise>
			in (
			<xsl:for-each select="Item">
				<xsl:if test="position()!=1">,</xsl:if>
				<xsl:value-of select="."/>
			</xsl:for-each>
			)
		</xsl:otherwise>
	</xsl:choose>
</xsl:template>
</xsl:stylesheet>
