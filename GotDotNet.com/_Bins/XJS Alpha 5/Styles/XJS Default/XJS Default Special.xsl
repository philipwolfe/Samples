<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
 <xsl:template match="/">
  <html>
  <head>
  <title>XML Journal System Reader</title>
  <link href="basestyles.css" rel="stylesheet" type="text/css" />
  <link href="favicon.ico" rel="SHORTCUT icon"/>
  </head>
   <body>
 <table id="top" cellpadding="0" cellspacing="0">
	<tr>
		<td class="topside"><div class="center"><img src="Images/logo-opp.gif"/></div></td>
		<td class="center"><xsl:value-of select="XESP/Info/Name"/><br/>
		<div class="smalltxt"><xsl:value-of select="XESP/Info/Description"/></div></td>
	</tr>
</table>
<table id="main" cellpadding="0" cellspacing="0">
	<tr>
		<td class="sidebar" valign="top">
		<div class="center"><img alt="XJS Logo" src="Images/logo.jpg"/></div>
 <xsl:for-each select="XESP/XEL">
 <xsl:for-each select="Index">
    <font size="-1"><b>Main:</b></font><br/><a href="{Link}"><xsl:value-of select="Name"/></a>
    </xsl:for-each>
    <xsl:for-each select="Archive">
    <xsl:if test="@Value='Yes'"><font size="-1"><b>Archive Pages:</b></font><br/></xsl:if>
<xsl:for-each select="Page">
<a href="{Link}"><xsl:value-of select="Name"/></a>
</xsl:for-each>
</xsl:for-each>

<xsl:for-each select="Special">
    <xsl:for-each select="Category"><font size="-1"><b><xsl:value-of select="@Value"/>:</b></font><br/>
      <xsl:for-each select="Page">
        <a href="{Link}"><xsl:value-of select="Name"/></a>
     </xsl:for-each>
    </xsl:for-each>
    </xsl:for-each>

</xsl:for-each>
</td>
<td id="content" valign="top">
<xsl:for-each select="XESP/XJE">
    <br/><div class="center"><div class="infobox">
		<div class="infoboxspecialheader"><xsl:value-of select="Subject"/></div>
     <div class="infoboxcontent"><xsl:value-of select="Body" disable-output-escaping="yes"/></div>
     <xsl:for-each select="Attachments">
      <xsl:if test="@Value='Yes'">
     <div class="infoboxattach">
		<div class="smalltxt">
		Attachments:
		<ul>
		<xsl:for-each select="Attachment">
			<li><a href="Attachments/{current()}"><xsl:value-of select="current()"/></a></li>
		</xsl:for-each>
		</ul>
     </div></div>
     </xsl:if>
     </xsl:for-each>
    </div></div>
<br/>
   </xsl:for-each>
  </td>
	</tr>
	<tr>
		<td colspan="3" id="bottom"><hr class="partwidth" color="#1E4D57"/>
		<p class="center">.: 'XJS Default' style designed by Matt Strum :.</p>
		<p class="center">.: Any content that is not mine may be copyright to the respective party :.</p>
		<p/>
		</td>
	</tr>
</table>
   </body>
  </html>
 </xsl:template>
</xsl:stylesheet>