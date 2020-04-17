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

namespace POSchema {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class PO {
        
        private POHistory[] historyField;
        
        private POItems[] itemsField;
        
        private string pONumberField;
        
        private string orderTotalField;
        
        private string fulfillerTrackingNumberField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("history", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public POHistory[] history {
            get {
                return this.historyField;
            }
            set {
                this.historyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("items", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public POItems[] items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PONumber {
            get {
                return this.pONumberField;
            }
            set {
                this.pONumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string orderTotal {
            get {
                return this.orderTotalField;
            }
            set {
                this.orderTotalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string fulfillerTrackingNumber {
            get {
                return this.fulfillerTrackingNumberField;
            }
            set {
                this.fulfillerTrackingNumberField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class POHistory {
        
        private POHistoryStatus[] statusField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("status", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public POHistoryStatus[] status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class POHistoryStatus {
        
        private string nameField;
        
        private string timestampField;
        
        private string contactField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string timestamp {
            get {
                return this.timestampField;
            }
            set {
                this.timestampField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contact {
            get {
                return this.contactField;
            }
            set {
                this.contactField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class POItems {
        
        private POItemsItem[] itemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public POItemsItem[] item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class POItemsItem {
        
        private string skuField;
        
        private string amountField;
        
        private string priceField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sku {
            get {
                return this.skuField;
            }
            set {
                this.skuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string price {
            get {
                return this.priceField;
            }
            set {
                this.priceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class NewDataSet {
        
        private PO[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PO")]
        public PO[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
    }
}
