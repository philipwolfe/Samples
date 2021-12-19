<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="/">
	<root>
		<xsl:apply-templates/>
	</root>
	</xsl:template>

	<xsl:template match="Item">
		<OrderItem>
			<xsl:attribute name="line">
				<xsl:value-of select="@line"/>
			</xsl:attribute>
			<PartNum><xsl:value-of select="@partno"/></PartNum>
			<Quantity><xsl:value-of select="@qty"/></Quantity>
			<Price><xsl:value-of select="@unitPrice"/></Price>
		</OrderItem>
	</xsl:template>

</xsl:stylesheet>

