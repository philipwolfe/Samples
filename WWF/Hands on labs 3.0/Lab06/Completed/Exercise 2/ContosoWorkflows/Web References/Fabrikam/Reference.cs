//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

#pragma warning disable 1591

namespace ContosoWorkflows.Fabrikam {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="processPOWorkflow_WebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class processPOWorkflow_WebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ReceiveAndProcessPOOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public processPOWorkflow_WebService() {
            this.Url = global::ContosoWorkflows.Properties.Settings.Default.ContosoWorkflows_Fabrikam_processPOWorkflow_WebService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ReceiveAndProcessPOCompletedEventHandler ReceiveAndProcessPOCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ReceiveAndProcessPO", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public PO ReceiveAndProcessPO(PO aPO) {
            object[] results = this.Invoke("ReceiveAndProcessPO", new object[] {
                        aPO});
            return ((PO)(results[0]));
        }
        
        /// <remarks/>
        public void ReceiveAndProcessPOAsync(PO aPO) {
            this.ReceiveAndProcessPOAsync(aPO, null);
        }
        
        /// <remarks/>
        public void ReceiveAndProcessPOAsync(PO aPO, object userState) {
            if ((this.ReceiveAndProcessPOOperationCompleted == null)) {
                this.ReceiveAndProcessPOOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReceiveAndProcessPOOperationCompleted);
            }
            this.InvokeAsync("ReceiveAndProcessPO", new object[] {
                        aPO}, this.ReceiveAndProcessPOOperationCompleted, userState);
        }
        
        private void OnReceiveAndProcessPOOperationCompleted(object arg) {
            if ((this.ReceiveAndProcessPOCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReceiveAndProcessPOCompleted(this, new ReceiveAndProcessPOCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class PO {
        
        private string pONumberField;
        
        private string fulfillerTrackingNumberField;
        
        private double orderTotalField;
        
        private POItem[] itemsField;
        
        private POStatus[] historyField;
        
        /// <remarks/>
        public string PONumber {
            get {
                return this.pONumberField;
            }
            set {
                this.pONumberField = value;
            }
        }
        
        /// <remarks/>
        public string FulfillerTrackingNumber {
            get {
                return this.fulfillerTrackingNumberField;
            }
            set {
                this.fulfillerTrackingNumberField = value;
            }
        }
        
        /// <remarks/>
        public double OrderTotal {
            get {
                return this.orderTotalField;
            }
            set {
                this.orderTotalField = value;
            }
        }
        
        /// <remarks/>
        public POItem[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
        
        /// <remarks/>
        public POStatus[] History {
            get {
                return this.historyField;
            }
            set {
                this.historyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class POItem {
        
        private string skuField;
        
        private double amountField;
        
        private double priceField;
        
        /// <remarks/>
        public string Sku {
            get {
                return this.skuField;
            }
            set {
                this.skuField = value;
            }
        }
        
        /// <remarks/>
        public double Amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
            }
        }
        
        /// <remarks/>
        public double Price {
            get {
                return this.priceField;
            }
            set {
                this.priceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class POStatus {
        
        private string contactField;
        
        private string poStatusField;
        
        private System.DateTime timestampField;
        
        /// <remarks/>
        public string Contact {
            get {
                return this.contactField;
            }
            set {
                this.contactField = value;
            }
        }
        
        /// <remarks/>
        public string PoStatus {
            get {
                return this.poStatusField;
            }
            set {
                this.poStatusField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime Timestamp {
            get {
                return this.timestampField;
            }
            set {
                this.timestampField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void ReceiveAndProcessPOCompletedEventHandler(object sender, ReceiveAndProcessPOCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReceiveAndProcessPOCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReceiveAndProcessPOCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public PO Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((PO)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591