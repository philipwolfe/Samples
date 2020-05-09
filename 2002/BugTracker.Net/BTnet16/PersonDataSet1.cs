﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.0.3705.209
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace BTnet1 {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class PersonDataSet1 : DataSet {
        
        private BT_PERSONDataTable tableBT_PERSON;
        
        public PersonDataSet1() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected PersonDataSet1(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["BT_PERSON"] != null)) {
                    this.Tables.Add(new BT_PERSONDataTable(ds.Tables["BT_PERSON"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public BT_PERSONDataTable BT_PERSON {
            get {
                return this.tableBT_PERSON;
            }
        }
        
        public override DataSet Clone() {
            PersonDataSet1 cln = ((PersonDataSet1)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["BT_PERSON"] != null)) {
                this.Tables.Add(new BT_PERSONDataTable(ds.Tables["BT_PERSON"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tableBT_PERSON = ((BT_PERSONDataTable)(this.Tables["BT_PERSON"]));
            if ((this.tableBT_PERSON != null)) {
                this.tableBT_PERSON.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "PersonDataSet1";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/PersonDataSet1.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableBT_PERSON = new BT_PERSONDataTable();
            this.Tables.Add(this.tableBT_PERSON);
        }
        
        private bool ShouldSerializeBT_PERSON() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void BT_PERSONRowChangeEventHandler(object sender, BT_PERSONRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class BT_PERSONDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnemail;
            
            private DataColumn columnname;
            
            private DataColumn columnpersonOID;
            
            private DataColumn columnphone;
            
            internal BT_PERSONDataTable() : 
                    base("BT_PERSON") {
                this.InitClass();
            }
            
            internal BT_PERSONDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn emailColumn {
                get {
                    return this.columnemail;
                }
            }
            
            internal DataColumn nameColumn {
                get {
                    return this.columnname;
                }
            }
            
            internal DataColumn personOIDColumn {
                get {
                    return this.columnpersonOID;
                }
            }
            
            internal DataColumn phoneColumn {
                get {
                    return this.columnphone;
                }
            }
            
            public BT_PERSONRow this[int index] {
                get {
                    return ((BT_PERSONRow)(this.Rows[index]));
                }
            }
            
            public event BT_PERSONRowChangeEventHandler BT_PERSONRowChanged;
            
            public event BT_PERSONRowChangeEventHandler BT_PERSONRowChanging;
            
            public event BT_PERSONRowChangeEventHandler BT_PERSONRowDeleted;
            
            public event BT_PERSONRowChangeEventHandler BT_PERSONRowDeleting;
            
            public void AddBT_PERSONRow(BT_PERSONRow row) {
                this.Rows.Add(row);
            }
            
            public BT_PERSONRow AddBT_PERSONRow(string email, string name, string personOID, string phone) {
                BT_PERSONRow rowBT_PERSONRow = ((BT_PERSONRow)(this.NewRow()));
                rowBT_PERSONRow.ItemArray = new object[] {
                        email,
                        name,
                        personOID,
                        phone};
                this.Rows.Add(rowBT_PERSONRow);
                return rowBT_PERSONRow;
            }
            
            public BT_PERSONRow FindBypersonOID(string personOID) {
                return ((BT_PERSONRow)(this.Rows.Find(new object[] {
                            personOID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                BT_PERSONDataTable cln = ((BT_PERSONDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new BT_PERSONDataTable();
            }
            
            internal void InitVars() {
                this.columnemail = this.Columns["email"];
                this.columnname = this.Columns["name"];
                this.columnpersonOID = this.Columns["personOID"];
                this.columnphone = this.Columns["phone"];
            }
            
            private void InitClass() {
                this.columnemail = new DataColumn("email", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnemail);
                this.columnname = new DataColumn("name", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnname);
                this.columnpersonOID = new DataColumn("personOID", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnpersonOID);
                this.columnphone = new DataColumn("phone", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnphone);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnpersonOID}, true));
                this.columnpersonOID.AllowDBNull = false;
                this.columnpersonOID.Unique = true;
            }
            
            public BT_PERSONRow NewBT_PERSONRow() {
                return ((BT_PERSONRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new BT_PERSONRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(BT_PERSONRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.BT_PERSONRowChanged != null)) {
                    this.BT_PERSONRowChanged(this, new BT_PERSONRowChangeEvent(((BT_PERSONRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.BT_PERSONRowChanging != null)) {
                    this.BT_PERSONRowChanging(this, new BT_PERSONRowChangeEvent(((BT_PERSONRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.BT_PERSONRowDeleted != null)) {
                    this.BT_PERSONRowDeleted(this, new BT_PERSONRowChangeEvent(((BT_PERSONRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.BT_PERSONRowDeleting != null)) {
                    this.BT_PERSONRowDeleting(this, new BT_PERSONRowChangeEvent(((BT_PERSONRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveBT_PERSONRow(BT_PERSONRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class BT_PERSONRow : DataRow {
            
            private BT_PERSONDataTable tableBT_PERSON;
            
            internal BT_PERSONRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableBT_PERSON = ((BT_PERSONDataTable)(this.Table));
            }
            
            public string email {
                get {
                    try {
                        return ((string)(this[this.tableBT_PERSON.emailColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableBT_PERSON.emailColumn] = value;
                }
            }
            
            public string name {
                get {
                    try {
                        return ((string)(this[this.tableBT_PERSON.nameColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableBT_PERSON.nameColumn] = value;
                }
            }
            
            public string personOID {
                get {
                    return ((string)(this[this.tableBT_PERSON.personOIDColumn]));
                }
                set {
                    this[this.tableBT_PERSON.personOIDColumn] = value;
                }
            }
            
            public string phone {
                get {
                    try {
                        return ((string)(this[this.tableBT_PERSON.phoneColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableBT_PERSON.phoneColumn] = value;
                }
            }
            
            public bool IsemailNull() {
                return this.IsNull(this.tableBT_PERSON.emailColumn);
            }
            
            public void SetemailNull() {
                this[this.tableBT_PERSON.emailColumn] = System.Convert.DBNull;
            }
            
            public bool IsnameNull() {
                return this.IsNull(this.tableBT_PERSON.nameColumn);
            }
            
            public void SetnameNull() {
                this[this.tableBT_PERSON.nameColumn] = System.Convert.DBNull;
            }
            
            public bool IsphoneNull() {
                return this.IsNull(this.tableBT_PERSON.phoneColumn);
            }
            
            public void SetphoneNull() {
                this[this.tableBT_PERSON.phoneColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class BT_PERSONRowChangeEvent : EventArgs {
            
            private BT_PERSONRow eventRow;
            
            private DataRowAction eventAction;
            
            public BT_PERSONRowChangeEvent(BT_PERSONRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public BT_PERSONRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}