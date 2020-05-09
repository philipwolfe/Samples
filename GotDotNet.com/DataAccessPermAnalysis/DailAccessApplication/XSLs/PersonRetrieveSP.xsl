<?xml version="1.0" encoding="Windows-1255"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:output omit-xml-declaration="yes"  method="text"/>
<xsl:template match="/">

	QUERY_SEPERATOR-DAApp-

	DB_FUNC_START
	&lt;Function type='procedure'&gt;
	&lt;Return type="recordSet" name="result" /&gt;
	&lt;Param type="integer" name="personID"&gt;<xsl:value-of select="Request/Profile/PersonID/Item"/>&lt;/Param&gt;
	&lt;Text&gt;SinglePersonSelect&lt;/Text&gt;		
	&lt;/Function&gt;
	DB_FUNC_END


</xsl:template>

</xsl:stylesheet>
