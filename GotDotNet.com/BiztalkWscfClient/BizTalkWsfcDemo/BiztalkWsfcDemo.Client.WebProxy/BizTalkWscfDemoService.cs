//------------------------------------------------------------------------------
// <autogenerated code>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated code>
//------------------------------------------------------------------------------
// File time 05-02-06 04:50 PM
//
// This source code was auto-generated by WsContractFirst, Version=0.5.1.5216


namespace BiztalkWsfcDemo.Client.WebProxy
{
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BiztalkWscfDemoService", Namespace="http://BizTalkWscfDemoService/BiztalkWscfDemoSrvcMsgs")]
    public class BiztalkWscfDemoServicePort : System.Web.Services.Protocols.SoapHttpClientProtocol, IBiztalkWscfDemoServicePort
    {
        
        /// <remarks/>
        public BiztalkWscfDemoServicePort()
        {
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://BizTalkWscfDemoService/BiztalkWscfDemoSrvcMsgs:getCompanyForPersonIn", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("getCompanyForPersonResponse", Namespace="http://BizTalkWscfDemoService/BiztalkWscfDemoSrvcMsgs.xsd")]
        public GetCompanyForPersonResponse GetCompanyForPerson([System.Xml.Serialization.XmlElementAttribute("getCompanyForPerson", Namespace="http://BizTalkWscfDemoService/BiztalkWscfDemoSrvcMsgs.xsd")] GetCompanyForPerson getCompanyForPerson1)
        {
            object[] results = this.Invoke("GetCompanyForPerson", new object[] {
                        getCompanyForPerson1});
            return ((GetCompanyForPersonResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetCompanyForPerson([System.Xml.Serialization.XmlElementAttribute(ElementName="getCompanyForPerson1")] GetCompanyForPerson getCompanyForPerson1, [System.Xml.Serialization.XmlElementAttribute(ElementName="callback")] System.AsyncCallback callback, [System.Xml.Serialization.XmlElementAttribute(ElementName="asyncState")] object asyncState)
        {
            return this.BeginInvoke("BegingetCompanyForPerson", new object[] {
                        getCompanyForPerson1}, callback, asyncState);
        }
        
        /// <remarks/>
        public GetCompanyForPersonResponse EndgetCompanyForPerson([System.Xml.Serialization.XmlElementAttribute(ElementName="asyncResult")] System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((GetCompanyForPersonResponse)(results[0]));
        }
    }
}
