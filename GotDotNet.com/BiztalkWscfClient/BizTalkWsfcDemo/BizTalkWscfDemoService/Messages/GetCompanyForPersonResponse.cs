//------------------------------------------------------------------------------
// <autogenerated code>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated code>
//------------------------------------------------------------------------------
// File time 05-02-06 01:13 PM
//
// This source code was auto-generated by WsContractFirst, Version=0.5.1.5216


namespace BizTalkWscfDemo.Service
{
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://BizTalkWscfDemoService/BiztalkWscfDemoSrvcMsgs.xsd", TypeName="getCompanyForPersonResponse")]
    [System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    [Serializable()]
    public class GetCompanyForPersonResponse
    {
        
        /// <remarks/>
        private Company company;
        
        public GetCompanyForPersonResponse()
        {
        }
        
        public GetCompanyForPersonResponse(Company company)
        {
            this.company = company;
        }
        
        [System.Xml.Serialization.XmlElementAttribute(ElementName="company")]
        public Company Company
        {
            get
            {
                return this.company;
            }
            set
            {
                if ((value == null))
                {
                    throw new System.ArgumentNullException("Company");
                }
                this.company = value;
            }
        }
    }
}
