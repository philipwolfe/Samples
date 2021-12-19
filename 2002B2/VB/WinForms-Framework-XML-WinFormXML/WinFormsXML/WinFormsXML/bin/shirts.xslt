<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<HTML>
			<BODY>
				<TABLE BORDER="1" CELLSPACING="0" CELLPADDING="0" WIDTH="100%">
							<TR>
								<TH>
									Names of all Available Shirts
								</TH>
							</TR>
					<xsl:for-each select="clothes/shirts">
							<TR>
								<TD>
									<xsl:value-of select="name"/>
								</TD>
							</TR>
					</xsl:for-each>
				</TABLE>
				<TABLE>
					<TR>
						<TD Height="20">
						</TD>
					</TR>
				</TABLE>
				<TABLE BORDER="1" CELLSPACING="0" CELLPADDING="0" WIDTH="100%">
					<TR>
						<TH>
							Shirts with Long Sleeves
						</TH>
						<TH>
							Color
						</TH>
					</TR>
					<xsl:for-each select="clothes/shirts[sleeves='long']">
					<TR>
						<TD>
							<xsl:value-of select="name"/>
						</TD>
						<TD>
							<xsl:value-of select="color"/>
						</TD>
					</TR>
					</xsl:for-each>
				</TABLE>
			</BODY>
		</HTML>
	</xsl:template>
</xsl:stylesheet>

