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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/POSchema.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/POSchema.xsd", IsNullable=false)]
    public partial class PO {
        
        private double orderTotalField;
        
        private bool orderTotalFieldSpecified;
        
        private POStatus[] historyField;
        
        private POItem[] itemsField;
        
        private string pONumberField;
        
        private string fulfillerTrackingNumberField;
        
        /// <remarks/>
        public double orderTotal {
            get {
                return this.orderTotalField;
            }
            set {
                this.orderTotalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool orderTotalSpecified {
            get {
                return this.orderTotalFieldSpecified;
            }
            set {
                this.orderTotalFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("status", IsNullable=false)]
        public POStatus[] history {
            get {
                return this.historyField;
            }
            set {
                this.historyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable=false)]
        public POItem[] items {
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/POSchema.xsd")]
    public partial class POStatus {
        
        private string poStatusField;
        
        private System.DateTime timestampField;
        
        private bool timestampFieldSpecified;
        
        private string contactField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string poStatus {
            get {
                return this.poStatusField;
            }
            set {
                this.poStatusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime timestamp {
            get {
                return this.timestampField;
            }
            set {
                this.timestampField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool timestampSpecified {
            get {
                return this.timestampFieldSpecified;
            }
            set {
                this.timestampFieldSpecified = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/POSchema.xsd")]
    public partial class POItem {
        
        private double amountField;
        
        private bool amountFieldSpecified;
        
        private double priceField;
        
        private bool priceFieldSpecified;
        
        private string skuField;
        
        /// <remarks/>
        public double amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool amountSpecified {
            get {
                return this.amountFieldSpecified;
            }
            set {
                this.amountFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public double price {
            get {
                return this.priceField;
            }
            set {
                this.priceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool priceSpecified {
            get {
                return this.priceFieldSpecified;
            }
            set {
                this.priceFieldSpecified = value;
            }
        }
        
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
    }
}
