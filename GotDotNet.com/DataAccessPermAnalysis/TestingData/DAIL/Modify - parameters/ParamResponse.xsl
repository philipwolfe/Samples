<?xml version="1.0" encoding="Windows-1255"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:output omit-xml-declaration="yes"  method="text"/>
<xsl:template match="/">

	QUERY_SEPERATOR-NULL-_paramRetrieve
	&lt;Response id="<xsl:value-of select="Request/@id"/>" action="<xsl:value-of select="Request/@action"/>"&gt;
			&lt;Item id="count"&gt;
				&lt;Count&gt;<xsl:value-of select="count(Request/Profile/A/Item)"/>&lt;/Count&gt;
				&lt;Saying&gt;Something stinks&lt;/Saying&gt;
			&lt;/Item&gt;
	&lt;/Response&gt;

	QUERY_SEPERATOR-NULL-
	this is a simple param retrieve : 1st param is PARAM_REF_0_ and 2nd param is PARAM_REF_1_. that's about
	it
</xsl:template>
</xsl:stylesheet>
