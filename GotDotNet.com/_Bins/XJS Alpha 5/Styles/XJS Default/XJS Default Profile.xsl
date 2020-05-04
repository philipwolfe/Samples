<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
 <xsl:template match="/">
  <html>
  <head>
  <title>XML Journal System Reader</title>
  <link href="basestyles.css" rel="stylesheet" type="text/css" />
  </head>
   <body>
   <table id="top" cellpadding="0" cellspacing="0">
	<tr>
		<td class="topside"><div class="center"><img src="Images/logo-opp.gif"/></div></td>
		<td class="center"><xsl:value-of select="XJP/PageInfo/Name"/><br/>
		<div class="smalltxt"><xsl:value-of select="XJP/PageInfo/Description"/></div></td>
	</tr>
</table>
<table id="main" cellpadding="0" cellspacing="0">
	<tr>
		<td class="sidebar" valign="top">
		<div class="center"><img alt="XJS Logo" src="Images/logo.jpg"/></div>
<xsl:for-each select="XJP/XEL">
    <xsl:for-each select="Index">
    <font size="-1"><b>Index:</b></font><br/><a href="{Link}"><xsl:value-of select="Name"/></a><br/>
    </xsl:for-each>
    <xsl:for-each select="Archive">
    <xsl:if test="@Value='Yes'"><font size="-1"><b>Archive Pages:</b></font><br/></xsl:if>
<xsl:for-each select="Page">
<a href="{Link}"><xsl:value-of select="Name"/></a><br/>
</xsl:for-each>
</xsl:for-each>
<font size="-1"><b>Profile:</b></font><br/><a href="{Profile}">Profile Page</a><br/>
</xsl:for-each>
</td>
 <td id="content" valign="top">
<xsl:for-each select="XJP">
<div class="center"><table class="infobox" cellspacing="0">
    <xsl:for-each select="Picture"><xsl:if test="@Exists='Yes'">
    <tr class="fullwidth">
      <td class="center" colspan="2">
        <p/><p><img alt="Profile Image" src="Images/{current()}"/></p>
      </td>
	</tr>
    </xsl:if></xsl:for-each>
    <tr class="fullwidth">
      <td class="center" colspan="2">
		<p/><p><img alt="Profile Logo" src="Images/profile-logo.gif"/></p><p/>
	  </td>
	</tr>
    <xsl:for-each select="Info/Data">
    <xsl:if test="@Exists='Yes'">
    <tr>
	  <td class="infoboxprofilefield"><xsl:value-of select="@Value"/></td>
	  <td class="infoboxprofiledata"><xsl:value-of select="."/></td>
	</tr>
    </xsl:if>
    </xsl:for-each>
    </table></div>
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