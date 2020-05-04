<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/"
	xmlns:om="http://schemas.microsoft.com/BizTalk/2003/DesignerData">
<xsl:output method = "xml" indent = "yes" />
<xsl:param name="serviceUrl"/>
<xsl:param name="schemasNamespace"/>
<xsl:param name="serviceNamespace"/>
<xsl:param name="portNamespace"/>
<xsl:param name="targetNamespace"/>

<xsl:variable name="serviceName" select="wsdl:definitions/wsdl:service/@name"/>

<xsl:template match="/">#if __DESIGNER_DATA
#error Do not define __DESIGNER_DATA.
${the xml declaration}
<om:MetaModel MajorVersion="1" MinorVersion="3" Core="2b131234-7959-458d-834f-2dc0769ce683" ScheduleModel="66366196-361d-448d-976f-cab5e87496d2"
	xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/" xmlns:om="http://schemas.microsoft.com/BizTalk/2003/DesignerData">
    <om:Element Type="Module" OID="????????-????-????-????-????????????" LowerBound="1.1" HigherBound="1.1">
        <om:Property Name="ReportToAnalyst" Value="True" />
        <om:Property Name="Name" Value="{$serviceNamespace}.{$serviceName}_"/>  
        <om:Property Name="Signal" Value="False" />
        <om:Element Type="MethodMessageType" OID="00000000-0000-0000-0000-000000000000" ParentLink="Module_MessageType">        
            <om:Property Name="Url" Value="{$serviceUrl}" />        
            <om:Property Name="TypeModifier" Value="Public" />
            <om:Property Name="ReportToAnalyst" Value="True" />
            <om:Property Name="Name" Value="{$serviceNamespace}.{wsdl:definitions/wsdl:service/@name}" />            
            <om:Property Name="Signal" Value="False" />   
            
			<xsl:for-each select="wsdl:definitions/wsdl:portType/wsdl:operation">
				<xsl:if test="wsdl:input">
					<xsl:call-template name="methodMessageOperationTemplate">
						<xsl:with-param name="direction" select="'Request'"/>
						<xsl:with-param name="operationName" select="@name"/>
						<xsl:with-param name="messageName" select="./wsdl:input/@message"/>
					</xsl:call-template>
				</xsl:if>
				<xsl:if test="wsdl:output">
					<xsl:call-template name="methodMessageOperationTemplate">
						<xsl:with-param name="direction" select="'Response'"/>
						<xsl:with-param name="operationName" select="@name"/>						
						<xsl:with-param name="messageName" select="./wsdl:output/@message"/>
					</xsl:call-template>
				</xsl:if>       		
			</xsl:for-each>
		</om:Element>                          
		<om:Element Type="TargetXMLNamespaceAttribute" OID="????????-????-????-????-????????????" ParentLink="Module_CLRAttribute" LowerBound="2.1" HigherBound="3.1">
			<om:Property Name="TargetXMLNamespace" Value="{$targetNamespace}" />
			<om:Property Name="Signal" Value="False" />
		</om:Element>  		
    </om:Element>         
</om:MetaModel>
#endif // __DESIGNER_DATA
[Microsoft.XLANGs.BaseTypes.BPELExportable(true)]
[Microsoft.XLANGs.BaseTypes.TargetXmlNamespaceAttribute("<xsl:value-of select="$targetNamespace"/>")]
module <xsl:value-of select="$serviceNamespace"/>.<xsl:value-of select="$serviceName"/>_
{
    <xsl:for-each select="wsdl:definitions/wsdl:portType/wsdl:operation">
        <xsl:call-template name="xlangMessageTemplate">
			<xsl:with-param name="operationName" select="@name" />        
			<xsl:with-param name="messageName" select="substring-after(wsdl:input/@message, ':')" />			
			<xsl:with-param name="requestType" select="'eRequest'" />
		</xsl:call-template>  	
        <xsl:call-template name="xlangMessageTemplate">
			<xsl:with-param name="operationName" select="@name" />        
			<xsl:with-param name="messageName" select="substring-after(wsdl:output/@message, ':')" />
			<xsl:with-param name="requestType" select="'eResponse'" />
		</xsl:call-template>  	  		 				
	</xsl:for-each>	
    [Microsoft.XLANGs.BaseTypes.WSDLProxyName(typeof(<xsl:value-of select="$portNamespace"/>.<xsl:value-of select="$serviceName"/>))]
    public porttype <xsl:value-of select="$serviceName"/>
    {
	<xsl:for-each select="wsdl:definitions/wsdl:portType/wsdl:operation">
		<xsl:if test="wsdl:input/@message and wsdl:output/@message">
		
		<xsl:variable name="requestResponseName">
			<xsl:call-template name="firstLetterToUppercase">
				<xsl:with-param name="str" select="@name"/>
			</xsl:call-template>
		</xsl:variable>
		
		<xsl:variable name="operationNameFixPart">
			<xsl:value-of select="$serviceNamespace"/>.<xsl:value-of select="$serviceName"/>_.<xsl:value-of select="$requestResponseName"/>_</xsl:variable>requestresponse <xsl:value-of select="$requestResponseName"/>
	{
	    <xsl:value-of select="$operationNameFixPart"/>request, <xsl:value-of select="$operationNameFixPart"/>response
	};			
	</xsl:if>				  		 				
	</xsl:for-each>};	
}
</xsl:template>	

<xsl:template name="methodMessageOperationTemplate">
			<xsl:param name="direction"/>
			<xsl:param name="operationName"/>
			<xsl:param name="messageName"/>
			
			<xsl:variable name="rightOperationName">
				<xsl:call-template name="firstLetterToUppercase">
					<xsl:with-param name="str" select="$operationName" />
				</xsl:call-template>  
			</xsl:variable>	
			
			<xsl:variable name="operationNameSuffix">
				<xsl:choose>
					<xsl:when test="$direction='Request'">_request</xsl:when>
					<xsl:otherwise>_response</xsl:otherwise>
				</xsl:choose>
			</xsl:variable>				
    
            <om:Element Type="MethodMessageOperation" OID="????????-????-????-????-????????????" ParentLink="MethodMessageType_MethodMessageOperation">
                <om:Property Name="OperationName" Value="{$rightOperationName}" />
                <om:Property Name="OperationDirection" Value="{$direction}" />
                <om:Property Name="ReportToAnalyst" Value="True" />
                <om:Property Name="Name" Value="{$rightOperationName}{$operationNameSuffix}" />
                <om:Property Name="Signal" Value="False" />                															
    
				<xsl:for-each select="/wsdl:definitions/wsdl:message">	
					<xsl:if test="./@name=substring-after($messageName, ':')">	
						<xsl:for-each select="./wsdl:part">
							<xsl:variable name="webPartName">
								<xsl:call-template name="firstLetterToLowercase">
									<xsl:with-param name="str" select="substring-after(./@element, ':')" />
								</xsl:call-template>  
							</xsl:variable>						
							<om:Element Type="WebOperationPart" OID="????????-????-????-????-????????????" ParentLink="MethodMessageOperation_WebOperationPart">
								<om:Property Name="ClassName" Value="{$schemasNamespace}.{substring-after(./@element, ':')}" />
								<om:Property Name="ReportToAnalyst" Value="True" />                    
								<om:Property Name="Name" Value="{$webPartName}1" />  
								<om:Property Name="Signal" Value="False" />
							</om:Element>
						</xsl:for-each>  					
					</xsl:if>
				</xsl:for-each>	
												
            </om:Element>				                           
</xsl:template>

<xsl:template name="xlangMessageTemplate">
	<xsl:param name="operationName"/>
	<xsl:param name="messageName"/>
	<xsl:param name="requestType" select="."/>	
	<!--transform the first character to uppercase-->		

    <xsl:variable name="rightOperationName">
		<xsl:call-template name="firstLetterToUppercase">
			<xsl:with-param name="str" select="$operationName" />
		</xsl:call-template>  
    </xsl:variable>
    	
	<xsl:for-each select="/wsdl:definitions/wsdl:message">	
		<xsl:if test="./@name=$messageName">
    <xsl:for-each select="./wsdl:part">[Microsoft.XLANGs.BaseTypes.WebPortBinding(typeof(<xsl:value-of select="$portNamespace"/>.<xsl:value-of select="$serviceName"/>), "<xsl:value-of select="$rightOperationName"/>", Microsoft.XLANGs.BaseTypes.EXLangSMessageInfo. <xsl:value-of select="$requestType"/>)]
    public messagetype <xsl:value-of select="$rightOperationName"/>
    	<xsl:if test="$requestType='eRequest'">_request</xsl:if>
		<xsl:if test="$requestType='eResponse'">_response</xsl:if>	
		<xsl:variable name="msgVarName">
			<xsl:call-template name="firstLetterToLowercase">
				<xsl:with-param name="str" select="substring-after(./@element, ':')" />
			</xsl:call-template>  			
		</xsl:variable> 
    {		
        body <xsl:value-of select="$schemasNamespace"/>.<xsl:value-of select="substring-after(./@element, ':')"/><xsl:text> </xsl:text><xsl:value-of select="$msgVarName"/>1; 
    };
    </xsl:for-each>  					
		</xsl:if>
	</xsl:for-each>		
</xsl:template>

<xsl:variable name="lowercase" select="'abcdefghijklmnopqrstuvwxyz'" />	
<xsl:variable name="uppercase" select="'ABCDEFGHIJKLMNOPQRSTUVWXYZ'" />  
	
<xsl:template name="firstLetterToUppercase">
	<xsl:param name="str"/>	
		
    <xsl:choose>
        <xsl:when test="string-length($str) > 1"><xsl:value-of select="concat(translate(substring($str, 1, 1), $lowercase, $uppercase), substring($str, 2, string-length($str) - 1))"/></xsl:when>
        <xsl:otherwise><xsl:value-of select="translate($str, $lowercase, $uppercase)"/></xsl:otherwise>
    </xsl:choose>
     	
</xsl:template>

<xsl:template name="firstLetterToLowercase">
	<xsl:param name="str"/>		
	
    <xsl:choose>
        <xsl:when test="string-length($str) > 1"><xsl:value-of select="concat(translate(substring($str, 1, 1), $uppercase, $lowercase), substring($str, 2, string-length($str) - 1))"/></xsl:when>
        <xsl:otherwise><xsl:value-of select="translate($str, $uppercase, $lowercase)"/></xsl:otherwise>
    </xsl:choose>
     	
</xsl:template>

</xsl:stylesheet>

  