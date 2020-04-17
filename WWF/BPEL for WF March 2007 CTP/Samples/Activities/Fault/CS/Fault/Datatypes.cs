//---------------------------------------------------------------------
//  This file is part of the  BPEL for Windows Workflow Foundation Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

namespace ns0
{
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="FileServiceSoap", Namespace="http://tempuri.org/")]
    [Microsoft.Workflow.Bpel.Activities.WsdlBindingPortTypeAttribute("FileServiceSoap", "http://tempuri.org/")]
    public partial class FileService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public FileService() {
            this.Url = "http://localhost:8081/FileService/FileService.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/writeLine", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void writeLine(string message) {
            this.Invoke("writeLine", new object[] {
                        message});
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    [Microsoft.Workflow.Bpel.Activities.XsdComplexTypeAttribute()]
    public partial class writeLine {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string message;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    [Microsoft.Workflow.Bpel.Activities.XsdComplexTypeAttribute()]
    public partial class writeLineResponse {
    }
    
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/")]
    [Microsoft.Workflow.Bpel.Activities.WsdlMessageTypeAttribute()]
    public class writeLineSoapIn {
        
        public ns0.writeLine parameters;
    }
    
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/")]
    [Microsoft.Workflow.Bpel.Activities.WsdlMessageTypeAttribute()]
    public class writeLineSoapOut {
        
        public ns0.writeLineResponse parameters;
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    [Microsoft.Workflow.Bpel.Activities.WsdlPortTypeAttribute()]
    public interface FileServiceSoap {
        
        ns0.writeLineSoapOut writeLine(ns0.writeLineSoapIn param1);
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    [Microsoft.Workflow.Bpel.Activities.RoleAttribute("application", typeof(ns0.FileServiceSoap))]
    public interface FileLinkType {
    }
}


public class NamespaceMapping {
    
    private System.Collections.Hashtable nsTable;
    
    public NamespaceMapping() {
        nsTable = new System.Collections.Hashtable();
        nsTable.Add("http://tempuri.org/", "ns0");
    }
    
    public virtual System.Collections.Hashtable GetMapping() {
        return nsTable;
    }
}
