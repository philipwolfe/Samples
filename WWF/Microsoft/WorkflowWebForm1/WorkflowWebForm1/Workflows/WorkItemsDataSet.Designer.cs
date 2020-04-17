//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
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

namespace Workflows {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [System.Xml.Serialization.XmlRootAttribute("WorkItemsDataSet")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class WorkItemsDataSet : System.Data.DataSet {
        
        private WorkItemsDataTable tableWorkItems;
        
        private WorkTypesDataTable tableWorkTypes;
        
        private UserActivitiesWorkItemsDataTable tableUserActivitiesWorkItems;
        
        private System.Data.DataRelation relationFK_WorkItems_WorkTypes;
        
        private System.Data.DataRelation relationFK_UserActivitiesWorkItems_WorkItems;
        
        private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public WorkItemsDataSet() {
            this.BeginInit();
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected WorkItemsDataSet(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context, false) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)) {
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["WorkItems"] != null)) {
                    base.Tables.Add(new WorkItemsDataTable(ds.Tables["WorkItems"]));
                }
                if ((ds.Tables["WorkTypes"] != null)) {
                    base.Tables.Add(new WorkTypesDataTable(ds.Tables["WorkTypes"]));
                }
                if ((ds.Tables["UserActivitiesWorkItems"] != null)) {
                    base.Tables.Add(new UserActivitiesWorkItemsDataTable(ds.Tables["UserActivitiesWorkItems"]));
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
                this.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public WorkItemsDataTable WorkItems {
            get {
                return this.tableWorkItems;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public WorkTypesDataTable WorkTypes {
            get {
                return this.tableWorkTypes;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public UserActivitiesWorkItemsDataTable UserActivitiesWorkItems {
            get {
                return this.tableUserActivitiesWorkItems;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.BrowsableAttribute(true)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode {
            get {
                return this._schemaSerializationMode;
            }
            set {
                this._schemaSerializationMode = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void InitializeDerivedDataSet() {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override System.Data.DataSet Clone() {
            WorkItemsDataSet cln = ((WorkItemsDataSet)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void ReadXmlSerializable(System.Xml.XmlReader reader) {
            if ((this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)) {
                this.Reset();
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["WorkItems"] != null)) {
                    base.Tables.Add(new WorkItemsDataTable(ds.Tables["WorkItems"]));
                }
                if ((ds.Tables["WorkTypes"] != null)) {
                    base.Tables.Add(new WorkTypesDataTable(ds.Tables["WorkTypes"]));
                }
                if ((ds.Tables["UserActivitiesWorkItems"] != null)) {
                    base.Tables.Add(new UserActivitiesWorkItemsDataTable(ds.Tables["UserActivitiesWorkItems"]));
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
                this.ReadXml(reader);
                this.InitVars();
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new System.Xml.XmlTextReader(stream), null);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars() {
            this.InitVars(true);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars(bool initTable) {
            this.tableWorkItems = ((WorkItemsDataTable)(base.Tables["WorkItems"]));
            if ((initTable == true)) {
                if ((this.tableWorkItems != null)) {
                    this.tableWorkItems.InitVars();
                }
            }
            this.tableWorkTypes = ((WorkTypesDataTable)(base.Tables["WorkTypes"]));
            if ((initTable == true)) {
                if ((this.tableWorkTypes != null)) {
                    this.tableWorkTypes.InitVars();
                }
            }
            this.tableUserActivitiesWorkItems = ((UserActivitiesWorkItemsDataTable)(base.Tables["UserActivitiesWorkItems"]));
            if ((initTable == true)) {
                if ((this.tableUserActivitiesWorkItems != null)) {
                    this.tableUserActivitiesWorkItems.InitVars();
                }
            }
            this.relationFK_WorkItems_WorkTypes = this.Relations["FK_WorkItems_WorkTypes"];
            this.relationFK_UserActivitiesWorkItems_WorkItems = this.Relations["FK_UserActivitiesWorkItems_WorkItems"];
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            this.DataSetName = "WorkItemsDataSet";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/WorkItemsDataSet.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableWorkItems = new WorkItemsDataTable();
            base.Tables.Add(this.tableWorkItems);
            this.tableWorkTypes = new WorkTypesDataTable();
            base.Tables.Add(this.tableWorkTypes);
            this.tableUserActivitiesWorkItems = new UserActivitiesWorkItemsDataTable();
            base.Tables.Add(this.tableUserActivitiesWorkItems);
            this.relationFK_WorkItems_WorkTypes = new System.Data.DataRelation("FK_WorkItems_WorkTypes", new System.Data.DataColumn[] {
                        this.tableWorkTypes.WorkTypeNameColumn}, new System.Data.DataColumn[] {
                        this.tableWorkItems.WorkItemTypeColumn}, false);
            this.Relations.Add(this.relationFK_WorkItems_WorkTypes);
            this.relationFK_UserActivitiesWorkItems_WorkItems = new System.Data.DataRelation("FK_UserActivitiesWorkItems_WorkItems", new System.Data.DataColumn[] {
                        this.tableWorkItems.WorkItemNameColumn}, new System.Data.DataColumn[] {
                        this.tableUserActivitiesWorkItems.WorkItemNameColumn}, false);
            this.Relations.Add(this.relationFK_UserActivitiesWorkItems_WorkItems);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeWorkItems() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeWorkTypes() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeUserActivitiesWorkItems() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(System.Xml.Schema.XmlSchemaSet xs) {
            WorkItemsDataSet ds = new WorkItemsDataSet();
            System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
            System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
            xs.Add(ds.GetSchemaSerializable());
            System.Xml.Schema.XmlSchemaAny any = new System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            return type;
        }
        
        public delegate void WorkItemsRowChangeEventHandler(object sender, WorkItemsRowChangeEvent e);
        
        public delegate void WorkTypesRowChangeEventHandler(object sender, WorkTypesRowChangeEvent e);
        
        public delegate void UserActivitiesWorkItemsRowChangeEventHandler(object sender, UserActivitiesWorkItemsRowChangeEvent e);
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class WorkItemsDataTable : System.Data.DataTable, System.Collections.IEnumerable {
            
            private System.Data.DataColumn columnWorkItemName;
            
            private System.Data.DataColumn columnWorkItemType;
            
            private System.Data.DataColumn columnDescription;
            
            private System.Data.DataColumn columnReason;
            
            private System.Data.DataColumn columnDateRequested;
            
            private System.Data.DataColumn columnFundingCostCenter;
            
            private System.Data.DataColumn columnAreaAffected;
            
            private System.Data.DataColumn columnApproved;
            
            private System.Data.DataColumn columnResult;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkItemsDataTable() {
                this.TableName = "WorkItems";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal WorkItemsDataTable(System.Data.DataTable table) {
                this.TableName = table.TableName;
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
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected WorkItemsDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn WorkItemNameColumn {
                get {
                    return this.columnWorkItemName;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn WorkItemTypeColumn {
                get {
                    return this.columnWorkItemType;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn DescriptionColumn {
                get {
                    return this.columnDescription;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn ReasonColumn {
                get {
                    return this.columnReason;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn DateRequestedColumn {
                get {
                    return this.columnDateRequested;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn FundingCostCenterColumn {
                get {
                    return this.columnFundingCostCenter;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn AreaAffectedColumn {
                get {
                    return this.columnAreaAffected;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn ApprovedColumn {
                get {
                    return this.columnApproved;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn ResultColumn {
                get {
                    return this.columnResult;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkItemsRow this[int index] {
                get {
                    return ((WorkItemsRow)(this.Rows[index]));
                }
            }
            
            public event WorkItemsRowChangeEventHandler WorkItemsRowChanging;
            
            public event WorkItemsRowChangeEventHandler WorkItemsRowChanged;
            
            public event WorkItemsRowChangeEventHandler WorkItemsRowDeleting;
            
            public event WorkItemsRowChangeEventHandler WorkItemsRowDeleted;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddWorkItemsRow(WorkItemsRow row) {
                this.Rows.Add(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkItemsRow AddWorkItemsRow(string WorkItemName, WorkTypesRow parentWorkTypesRowByFK_WorkItems_WorkTypes, string Description, string Reason, System.DateTime DateRequested, string FundingCostCenter, string AreaAffected, bool Approved, string Result) {
                WorkItemsRow rowWorkItemsRow = ((WorkItemsRow)(this.NewRow()));
                rowWorkItemsRow.ItemArray = new object[] {
                        WorkItemName,
                        parentWorkTypesRowByFK_WorkItems_WorkTypes[0],
                        Description,
                        Reason,
                        DateRequested,
                        FundingCostCenter,
                        AreaAffected,
                        Approved,
                        Result};
                this.Rows.Add(rowWorkItemsRow);
                return rowWorkItemsRow;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkItemsRow FindByWorkItemName(string WorkItemName) {
                return ((WorkItemsRow)(this.Rows.Find(new object[] {
                            WorkItemName})));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override System.Data.DataTable Clone() {
                WorkItemsDataTable cln = ((WorkItemsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataTable CreateInstance() {
                return new WorkItemsDataTable();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnWorkItemName = base.Columns["WorkItemName"];
                this.columnWorkItemType = base.Columns["WorkItemType"];
                this.columnDescription = base.Columns["Description"];
                this.columnReason = base.Columns["Reason"];
                this.columnDateRequested = base.Columns["DateRequested"];
                this.columnFundingCostCenter = base.Columns["FundingCostCenter"];
                this.columnAreaAffected = base.Columns["AreaAffected"];
                this.columnApproved = base.Columns["Approved"];
                this.columnResult = base.Columns["Result"];
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnWorkItemName = new System.Data.DataColumn("WorkItemName", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnWorkItemName);
                this.columnWorkItemType = new System.Data.DataColumn("WorkItemType", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnWorkItemType);
                this.columnDescription = new System.Data.DataColumn("Description", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnDescription);
                this.columnReason = new System.Data.DataColumn("Reason", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnReason);
                this.columnDateRequested = new System.Data.DataColumn("DateRequested", typeof(System.DateTime), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnDateRequested);
                this.columnFundingCostCenter = new System.Data.DataColumn("FundingCostCenter", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnFundingCostCenter);
                this.columnAreaAffected = new System.Data.DataColumn("AreaAffected", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnAreaAffected);
                this.columnApproved = new System.Data.DataColumn("Approved", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnApproved);
                this.columnResult = new System.Data.DataColumn("Result", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnResult);
                this.Constraints.Add(new System.Data.UniqueConstraint("Constraint1", new System.Data.DataColumn[] {
                                this.columnWorkItemName}, true));
                this.columnWorkItemName.AllowDBNull = false;
                this.columnWorkItemName.Unique = true;
                this.columnWorkItemName.MaxLength = 256;
                this.columnWorkItemType.AllowDBNull = false;
                this.columnWorkItemType.MaxLength = 50;
                this.columnDescription.AllowDBNull = false;
                this.columnDescription.MaxLength = 2147483647;
                this.columnReason.AllowDBNull = false;
                this.columnReason.MaxLength = 256;
                this.columnDateRequested.AllowDBNull = false;
                this.columnFundingCostCenter.AllowDBNull = false;
                this.columnFundingCostCenter.MaxLength = 50;
                this.columnAreaAffected.AllowDBNull = false;
                this.columnAreaAffected.MaxLength = 50;
                this.columnResult.MaxLength = 256;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkItemsRow NewWorkItemsRow() {
                return ((WorkItemsRow)(this.NewRow()));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
                return new WorkItemsRow(builder);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Type GetRowType() {
                return typeof(WorkItemsRow);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.WorkItemsRowChanged != null)) {
                    this.WorkItemsRowChanged(this, new WorkItemsRowChangeEvent(((WorkItemsRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.WorkItemsRowChanging != null)) {
                    this.WorkItemsRowChanging(this, new WorkItemsRowChangeEvent(((WorkItemsRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.WorkItemsRowDeleted != null)) {
                    this.WorkItemsRowDeleted(this, new WorkItemsRowChangeEvent(((WorkItemsRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.WorkItemsRowDeleting != null)) {
                    this.WorkItemsRowDeleting(this, new WorkItemsRowChangeEvent(((WorkItemsRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveWorkItemsRow(WorkItemsRow row) {
                this.Rows.Remove(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs) {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                WorkItemsDataSet ds = new WorkItemsDataSet();
                xs.Add(ds.GetSchemaSerializable());
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "WorkItemsDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class WorkTypesDataTable : System.Data.DataTable, System.Collections.IEnumerable {
            
            private System.Data.DataColumn columnWorkTypeName;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkTypesDataTable() {
                this.TableName = "WorkTypes";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal WorkTypesDataTable(System.Data.DataTable table) {
                this.TableName = table.TableName;
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
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected WorkTypesDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn WorkTypeNameColumn {
                get {
                    return this.columnWorkTypeName;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkTypesRow this[int index] {
                get {
                    return ((WorkTypesRow)(this.Rows[index]));
                }
            }
            
            public event WorkTypesRowChangeEventHandler WorkTypesRowChanging;
            
            public event WorkTypesRowChangeEventHandler WorkTypesRowChanged;
            
            public event WorkTypesRowChangeEventHandler WorkTypesRowDeleting;
            
            public event WorkTypesRowChangeEventHandler WorkTypesRowDeleted;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddWorkTypesRow(WorkTypesRow row) {
                this.Rows.Add(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkTypesRow AddWorkTypesRow(string WorkTypeName) {
                WorkTypesRow rowWorkTypesRow = ((WorkTypesRow)(this.NewRow()));
                rowWorkTypesRow.ItemArray = new object[] {
                        WorkTypeName};
                this.Rows.Add(rowWorkTypesRow);
                return rowWorkTypesRow;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkTypesRow FindByWorkTypeName(string WorkTypeName) {
                return ((WorkTypesRow)(this.Rows.Find(new object[] {
                            WorkTypeName})));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override System.Data.DataTable Clone() {
                WorkTypesDataTable cln = ((WorkTypesDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataTable CreateInstance() {
                return new WorkTypesDataTable();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnWorkTypeName = base.Columns["WorkTypeName"];
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnWorkTypeName = new System.Data.DataColumn("WorkTypeName", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnWorkTypeName);
                this.Constraints.Add(new System.Data.UniqueConstraint("Constraint1", new System.Data.DataColumn[] {
                                this.columnWorkTypeName}, true));
                this.columnWorkTypeName.AllowDBNull = false;
                this.columnWorkTypeName.Unique = true;
                this.columnWorkTypeName.MaxLength = 50;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkTypesRow NewWorkTypesRow() {
                return ((WorkTypesRow)(this.NewRow()));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
                return new WorkTypesRow(builder);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Type GetRowType() {
                return typeof(WorkTypesRow);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.WorkTypesRowChanged != null)) {
                    this.WorkTypesRowChanged(this, new WorkTypesRowChangeEvent(((WorkTypesRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.WorkTypesRowChanging != null)) {
                    this.WorkTypesRowChanging(this, new WorkTypesRowChangeEvent(((WorkTypesRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.WorkTypesRowDeleted != null)) {
                    this.WorkTypesRowDeleted(this, new WorkTypesRowChangeEvent(((WorkTypesRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.WorkTypesRowDeleting != null)) {
                    this.WorkTypesRowDeleting(this, new WorkTypesRowChangeEvent(((WorkTypesRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveWorkTypesRow(WorkTypesRow row) {
                this.Rows.Remove(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs) {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                WorkItemsDataSet ds = new WorkItemsDataSet();
                xs.Add(ds.GetSchemaSerializable());
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "WorkTypesDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class UserActivitiesWorkItemsDataTable : System.Data.DataTable, System.Collections.IEnumerable {
            
            private System.Data.DataColumn columnActivityGuid;
            
            private System.Data.DataColumn columnWorkItemName;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public UserActivitiesWorkItemsDataTable() {
                this.TableName = "UserActivitiesWorkItems";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal UserActivitiesWorkItemsDataTable(System.Data.DataTable table) {
                this.TableName = table.TableName;
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
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected UserActivitiesWorkItemsDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn ActivityGuidColumn {
                get {
                    return this.columnActivityGuid;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn WorkItemNameColumn {
                get {
                    return this.columnWorkItemName;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public UserActivitiesWorkItemsRow this[int index] {
                get {
                    return ((UserActivitiesWorkItemsRow)(this.Rows[index]));
                }
            }
            
            public event UserActivitiesWorkItemsRowChangeEventHandler UserActivitiesWorkItemsRowChanging;
            
            public event UserActivitiesWorkItemsRowChangeEventHandler UserActivitiesWorkItemsRowChanged;
            
            public event UserActivitiesWorkItemsRowChangeEventHandler UserActivitiesWorkItemsRowDeleting;
            
            public event UserActivitiesWorkItemsRowChangeEventHandler UserActivitiesWorkItemsRowDeleted;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddUserActivitiesWorkItemsRow(UserActivitiesWorkItemsRow row) {
                this.Rows.Add(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public UserActivitiesWorkItemsRow AddUserActivitiesWorkItemsRow(string ActivityGuid, WorkItemsRow parentWorkItemsRowByFK_UserActivitiesWorkItems_WorkItems) {
                UserActivitiesWorkItemsRow rowUserActivitiesWorkItemsRow = ((UserActivitiesWorkItemsRow)(this.NewRow()));
                rowUserActivitiesWorkItemsRow.ItemArray = new object[] {
                        ActivityGuid,
                        parentWorkItemsRowByFK_UserActivitiesWorkItems_WorkItems[0]};
                this.Rows.Add(rowUserActivitiesWorkItemsRow);
                return rowUserActivitiesWorkItemsRow;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public UserActivitiesWorkItemsRow FindByActivityGuidWorkItemName(string ActivityGuid, string WorkItemName) {
                return ((UserActivitiesWorkItemsRow)(this.Rows.Find(new object[] {
                            ActivityGuid,
                            WorkItemName})));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override System.Data.DataTable Clone() {
                UserActivitiesWorkItemsDataTable cln = ((UserActivitiesWorkItemsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataTable CreateInstance() {
                return new UserActivitiesWorkItemsDataTable();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnActivityGuid = base.Columns["ActivityGuid"];
                this.columnWorkItemName = base.Columns["WorkItemName"];
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnActivityGuid = new System.Data.DataColumn("ActivityGuid", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnActivityGuid);
                this.columnWorkItemName = new System.Data.DataColumn("WorkItemName", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnWorkItemName);
                this.Constraints.Add(new System.Data.UniqueConstraint("Constraint1", new System.Data.DataColumn[] {
                                this.columnActivityGuid,
                                this.columnWorkItemName}, true));
                this.columnActivityGuid.AllowDBNull = false;
                this.columnActivityGuid.MaxLength = 36;
                this.columnWorkItemName.AllowDBNull = false;
                this.columnWorkItemName.MaxLength = 256;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public UserActivitiesWorkItemsRow NewUserActivitiesWorkItemsRow() {
                return ((UserActivitiesWorkItemsRow)(this.NewRow()));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
                return new UserActivitiesWorkItemsRow(builder);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Type GetRowType() {
                return typeof(UserActivitiesWorkItemsRow);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.UserActivitiesWorkItemsRowChanged != null)) {
                    this.UserActivitiesWorkItemsRowChanged(this, new UserActivitiesWorkItemsRowChangeEvent(((UserActivitiesWorkItemsRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.UserActivitiesWorkItemsRowChanging != null)) {
                    this.UserActivitiesWorkItemsRowChanging(this, new UserActivitiesWorkItemsRowChangeEvent(((UserActivitiesWorkItemsRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.UserActivitiesWorkItemsRowDeleted != null)) {
                    this.UserActivitiesWorkItemsRowDeleted(this, new UserActivitiesWorkItemsRowChangeEvent(((UserActivitiesWorkItemsRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.UserActivitiesWorkItemsRowDeleting != null)) {
                    this.UserActivitiesWorkItemsRowDeleting(this, new UserActivitiesWorkItemsRowChangeEvent(((UserActivitiesWorkItemsRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveUserActivitiesWorkItemsRow(UserActivitiesWorkItemsRow row) {
                this.Rows.Remove(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs) {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                WorkItemsDataSet ds = new WorkItemsDataSet();
                xs.Add(ds.GetSchemaSerializable());
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "UserActivitiesWorkItemsDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class WorkItemsRow : System.Data.DataRow {
            
            private WorkItemsDataTable tableWorkItems;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal WorkItemsRow(System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableWorkItems = ((WorkItemsDataTable)(this.Table));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string WorkItemName {
                get {
                    return ((string)(this[this.tableWorkItems.WorkItemNameColumn]));
                }
                set {
                    this[this.tableWorkItems.WorkItemNameColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string WorkItemType {
                get {
                    return ((string)(this[this.tableWorkItems.WorkItemTypeColumn]));
                }
                set {
                    this[this.tableWorkItems.WorkItemTypeColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Description {
                get {
                    return ((string)(this[this.tableWorkItems.DescriptionColumn]));
                }
                set {
                    this[this.tableWorkItems.DescriptionColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Reason {
                get {
                    return ((string)(this[this.tableWorkItems.ReasonColumn]));
                }
                set {
                    this[this.tableWorkItems.ReasonColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.DateTime DateRequested {
                get {
                    return ((System.DateTime)(this[this.tableWorkItems.DateRequestedColumn]));
                }
                set {
                    this[this.tableWorkItems.DateRequestedColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string FundingCostCenter {
                get {
                    return ((string)(this[this.tableWorkItems.FundingCostCenterColumn]));
                }
                set {
                    this[this.tableWorkItems.FundingCostCenterColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string AreaAffected {
                get {
                    return ((string)(this[this.tableWorkItems.AreaAffectedColumn]));
                }
                set {
                    this[this.tableWorkItems.AreaAffectedColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool Approved {
                get {
                    try {
                        return ((bool)(this[this.tableWorkItems.ApprovedColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'Approved\' in table \'WorkItems\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableWorkItems.ApprovedColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Result {
                get {
                    try {
                        return ((string)(this[this.tableWorkItems.ResultColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'Result\' in table \'WorkItems\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableWorkItems.ResultColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkTypesRow WorkTypesRow {
                get {
                    return ((WorkTypesRow)(this.GetParentRow(this.Table.ParentRelations["FK_WorkItems_WorkTypes"])));
                }
                set {
                    this.SetParentRow(value, this.Table.ParentRelations["FK_WorkItems_WorkTypes"]);
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsApprovedNull() {
                return this.IsNull(this.tableWorkItems.ApprovedColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetApprovedNull() {
                this[this.tableWorkItems.ApprovedColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsResultNull() {
                return this.IsNull(this.tableWorkItems.ResultColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetResultNull() {
                this[this.tableWorkItems.ResultColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public UserActivitiesWorkItemsRow[] GetUserActivitiesWorkItemsRows() {
                return ((UserActivitiesWorkItemsRow[])(base.GetChildRows(this.Table.ChildRelations["FK_UserActivitiesWorkItems_WorkItems"])));
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class WorkTypesRow : System.Data.DataRow {
            
            private WorkTypesDataTable tableWorkTypes;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal WorkTypesRow(System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableWorkTypes = ((WorkTypesDataTable)(this.Table));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string WorkTypeName {
                get {
                    return ((string)(this[this.tableWorkTypes.WorkTypeNameColumn]));
                }
                set {
                    this[this.tableWorkTypes.WorkTypeNameColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkItemsRow[] GetWorkItemsRows() {
                return ((WorkItemsRow[])(base.GetChildRows(this.Table.ChildRelations["FK_WorkItems_WorkTypes"])));
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class UserActivitiesWorkItemsRow : System.Data.DataRow {
            
            private UserActivitiesWorkItemsDataTable tableUserActivitiesWorkItems;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal UserActivitiesWorkItemsRow(System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableUserActivitiesWorkItems = ((UserActivitiesWorkItemsDataTable)(this.Table));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string ActivityGuid {
                get {
                    return ((string)(this[this.tableUserActivitiesWorkItems.ActivityGuidColumn]));
                }
                set {
                    this[this.tableUserActivitiesWorkItems.ActivityGuidColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string WorkItemName {
                get {
                    return ((string)(this[this.tableUserActivitiesWorkItems.WorkItemNameColumn]));
                }
                set {
                    this[this.tableUserActivitiesWorkItems.WorkItemNameColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkItemsRow WorkItemsRow {
                get {
                    return ((WorkItemsRow)(this.GetParentRow(this.Table.ParentRelations["FK_UserActivitiesWorkItems_WorkItems"])));
                }
                set {
                    this.SetParentRow(value, this.Table.ParentRelations["FK_UserActivitiesWorkItems_WorkItems"]);
                }
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class WorkItemsRowChangeEvent : System.EventArgs {
            
            private WorkItemsRow eventRow;
            
            private System.Data.DataRowAction eventAction;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkItemsRowChangeEvent(WorkItemsRow row, System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkItemsRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class WorkTypesRowChangeEvent : System.EventArgs {
            
            private WorkTypesRow eventRow;
            
            private System.Data.DataRowAction eventAction;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkTypesRowChangeEvent(WorkTypesRow row, System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkTypesRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class UserActivitiesWorkItemsRowChangeEvent : System.EventArgs {
            
            private UserActivitiesWorkItemsRow eventRow;
            
            private System.Data.DataRowAction eventAction;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public UserActivitiesWorkItemsRowChangeEvent(UserActivitiesWorkItemsRow row, System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public UserActivitiesWorkItemsRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}
namespace Workflows.WorkItemsDataSetTableAdapters {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.ComponentModel.DataObjectAttribute(true)]
    [System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" +
        ", Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
    public partial class WorkItemsTableAdapter : System.ComponentModel.Component {
        
        private System.Data.SqlClient.SqlDataAdapter _adapter;
        
        private System.Data.SqlClient.SqlConnection _connection;
        
        private System.Data.SqlClient.SqlCommand[] _commandCollection;
        
        private bool _clearBeforeFill;
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public WorkItemsTableAdapter() {
            this.ClearBeforeFill = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private System.Data.SqlClient.SqlDataAdapter Adapter {
            get {
                if ((this._adapter == null)) {
                    this.InitAdapter();
                }
                return this._adapter;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal System.Data.SqlClient.SqlConnection Connection {
            get {
                if ((this._connection == null)) {
                    this.InitConnection();
                }
                return this._connection;
            }
            set {
                this._connection = value;
                if ((this.Adapter.InsertCommand != null)) {
                    this.Adapter.InsertCommand.Connection = value;
                }
                if ((this.Adapter.DeleteCommand != null)) {
                    this.Adapter.DeleteCommand.Connection = value;
                }
                if ((this.Adapter.UpdateCommand != null)) {
                    this.Adapter.UpdateCommand.Connection = value;
                }
                for (int i = 0; (i < this.CommandCollection.Length); i = (i + 1)) {
                    if ((this.CommandCollection[i] != null)) {
                        ((System.Data.SqlClient.SqlCommand)(this.CommandCollection[i])).Connection = value;
                    }
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected System.Data.SqlClient.SqlCommand[] CommandCollection {
            get {
                if ((this._commandCollection == null)) {
                    this.InitCommandCollection();
                }
                return this._commandCollection;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public bool ClearBeforeFill {
            get {
                return this._clearBeforeFill;
            }
            set {
                this._clearBeforeFill = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitAdapter() {
            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "WorkItems";
            tableMapping.ColumnMappings.Add("WorkItemName", "WorkItemName");
            tableMapping.ColumnMappings.Add("WorkItemType", "WorkItemType");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("Reason", "Reason");
            tableMapping.ColumnMappings.Add("DateRequested", "DateRequested");
            tableMapping.ColumnMappings.Add("FundingCostCenter", "FundingCostCenter");
            tableMapping.ColumnMappings.Add("AreaAffected", "AreaAffected");
            tableMapping.ColumnMappings.Add("Approved", "Approved");
            tableMapping.ColumnMappings.Add("Result", "Result");
            this._adapter.TableMappings.Add(tableMapping);
            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[WorkItems] WHERE (([WorkItemName] = @Original_WorkItemName) AND ([WorkItemType] = @Original_WorkItemType) AND ([Reason] = @Original_Reason) AND ([DateRequested] = @Original_DateRequested) AND ([FundingCostCenter] = @Original_FundingCostCenter) AND ([AreaAffected] = @Original_AreaAffected) AND ((@IsNull_Approved = 1 AND [Approved] IS NULL) OR ([Approved] = @Original_Approved)) AND ((@IsNull_Result = 1 AND [Result] IS NULL) OR ([Result] = @Original_Result)))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_WorkItemName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkItemName", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_WorkItemType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkItemType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Reason", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Reason", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DateRequested", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateRequested", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FundingCostCenter", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "FundingCostCenter", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AreaAffected", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "AreaAffected", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Approved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Approved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Approved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Approved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Result", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Result", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Result", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Result", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[WorkItems] ([WorkItemName], [WorkItemType], [Description], [Reason], [DateRequested], [FundingCostCenter], [AreaAffected], [Approved], [Result]) VALUES (@WorkItemName, @WorkItemType, @Description, @Reason, @DateRequested, @FundingCostCenter, @AreaAffected, @Approved, @Result);
SELECT WorkItemName, WorkItemType, Description, Reason, DateRequested, FundingCostCenter, AreaAffected, Approved, Result FROM WorkItems WHERE (WorkItemName = @WorkItemName)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@WorkItemName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkItemName", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@WorkItemType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkItemType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.Text, 0, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Reason", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Reason", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateRequested", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateRequested", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FundingCostCenter", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "FundingCostCenter", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AreaAffected", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "AreaAffected", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Approved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Approved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Result", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Result", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[WorkItems] SET [WorkItemName] = @WorkItemName, [WorkItemType] = @WorkItemType, [Description] = @Description, [Reason] = @Reason, [DateRequested] = @DateRequested, [FundingCostCenter] = @FundingCostCenter, [AreaAffected] = @AreaAffected, [Approved] = @Approved, [Result] = @Result WHERE (([WorkItemName] = @Original_WorkItemName) AND ([WorkItemType] = @Original_WorkItemType) AND ([Reason] = @Original_Reason) AND ([DateRequested] = @Original_DateRequested) AND ([FundingCostCenter] = @Original_FundingCostCenter) AND ([AreaAffected] = @Original_AreaAffected) AND ((@IsNull_Approved = 1 AND [Approved] IS NULL) OR ([Approved] = @Original_Approved)) AND ((@IsNull_Result = 1 AND [Result] IS NULL) OR ([Result] = @Original_Result)));
SELECT WorkItemName, WorkItemType, Description, Reason, DateRequested, FundingCostCenter, AreaAffected, Approved, Result FROM WorkItems WHERE (WorkItemName = @WorkItemName)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@WorkItemName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkItemName", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@WorkItemType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkItemType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.Text, 0, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Reason", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Reason", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateRequested", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateRequested", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FundingCostCenter", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "FundingCostCenter", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AreaAffected", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "AreaAffected", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Approved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Approved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Result", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Result", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_WorkItemName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkItemName", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_WorkItemType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkItemType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Reason", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Reason", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DateRequested", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateRequested", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FundingCostCenter", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "FundingCostCenter", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AreaAffected", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "AreaAffected", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Approved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Approved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Approved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Approved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Result", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Result", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Result", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Result", System.Data.DataRowVersion.Original, false, null, "", "", ""));
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitConnection() {
            this._connection = new System.Data.SqlClient.SqlConnection();
            this._connection.ConnectionString = global::Workflows.Properties.Settings.Default.ASPNETDBConnectionString;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitCommandCollection() {
            this._commandCollection = new System.Data.SqlClient.SqlCommand[2];
            this._commandCollection[0] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT WorkItemName, WorkItemType, Description, Reason, DateRequested, FundingCos" +
                "tCenter, AreaAffected, Approved, Result FROM dbo.WorkItems";
            this._commandCollection[0].CommandType = System.Data.CommandType.Text;
            this._commandCollection[1] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "SELECT WorkItemName, WorkItemType, Description, Reason, DateRequested, FundingCos" +
                "tCenter, AreaAffected, Approved, Result FROM dbo.WorkItems WHERE (WorkItemName I" +
                "N (SELECT WorkItemName FROM UserActivitiesWorkItems WHERE (ActivityGuid = @activ" +
                "ityGuid)))";
            this._commandCollection[1].CommandType = System.Data.CommandType.Text;
            this._commandCollection[1].Parameters.Add(new System.Data.SqlClient.SqlParameter("@activityGuid", System.Data.SqlDbType.NVarChar, 36, System.Data.ParameterDirection.Input, 0, 0, "", System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Fill, true)]
        public virtual int Fill(WorkItemsDataSet.WorkItemsDataTable dataTable) {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if ((this.ClearBeforeFill == true)) {
                dataTable.Clear();
            }
            int returnValue = this.Adapter.Fill(dataTable);
            return returnValue;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public virtual WorkItemsDataSet.WorkItemsDataTable GetData() {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            WorkItemsDataSet.WorkItemsDataTable dataTable = new WorkItemsDataSet.WorkItemsDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Fill, false)]
        public virtual int FillByActivityGuid(WorkItemsDataSet.WorkItemsDataTable dataTable, string activityGuid) {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            if ((activityGuid == null)) {
                throw new System.ArgumentNullException("activityGuid");
            }
            else {
                this.Adapter.SelectCommand.Parameters[0].Value = ((string)(activityGuid));
            }
            if ((this.ClearBeforeFill == true)) {
                dataTable.Clear();
            }
            int returnValue = this.Adapter.Fill(dataTable);
            return returnValue;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public virtual WorkItemsDataSet.WorkItemsDataTable GetDataByActivityGuid(string activityGuid) {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            if ((activityGuid == null)) {
                throw new System.ArgumentNullException("activityGuid");
            }
            else {
                this.Adapter.SelectCommand.Parameters[0].Value = ((string)(activityGuid));
            }
            WorkItemsDataSet.WorkItemsDataTable dataTable = new WorkItemsDataSet.WorkItemsDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(WorkItemsDataSet.WorkItemsDataTable dataTable) {
            return this.Adapter.Update(dataTable);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(WorkItemsDataSet dataSet) {
            return this.Adapter.Update(dataSet, "WorkItems");
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(System.Data.DataRow dataRow) {
            return this.Adapter.Update(new System.Data.DataRow[] {
                        dataRow});
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(System.Data.DataRow[] dataRows) {
            return this.Adapter.Update(dataRows);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public virtual int Delete(string Original_WorkItemName, string Original_WorkItemType, string Original_Reason, System.DateTime Original_DateRequested, string Original_FundingCostCenter, string Original_AreaAffected, System.Nullable<bool> Original_Approved, string Original_Result) {
            if ((Original_WorkItemName == null)) {
                throw new System.ArgumentNullException("Original_WorkItemName");
            }
            else {
                this.Adapter.DeleteCommand.Parameters[0].Value = ((string)(Original_WorkItemName));
            }
            if ((Original_WorkItemType == null)) {
                throw new System.ArgumentNullException("Original_WorkItemType");
            }
            else {
                this.Adapter.DeleteCommand.Parameters[1].Value = ((string)(Original_WorkItemType));
            }
            if ((Original_Reason == null)) {
                throw new System.ArgumentNullException("Original_Reason");
            }
            else {
                this.Adapter.DeleteCommand.Parameters[2].Value = ((string)(Original_Reason));
            }
            this.Adapter.DeleteCommand.Parameters[3].Value = ((System.DateTime)(Original_DateRequested));
            if ((Original_FundingCostCenter == null)) {
                throw new System.ArgumentNullException("Original_FundingCostCenter");
            }
            else {
                this.Adapter.DeleteCommand.Parameters[4].Value = ((string)(Original_FundingCostCenter));
            }
            if ((Original_AreaAffected == null)) {
                throw new System.ArgumentNullException("Original_AreaAffected");
            }
            else {
                this.Adapter.DeleteCommand.Parameters[5].Value = ((string)(Original_AreaAffected));
            }
            if ((Original_Approved.HasValue == true)) {
                this.Adapter.DeleteCommand.Parameters[6].Value = ((object)(0));
                this.Adapter.DeleteCommand.Parameters[7].Value = ((bool)(Original_Approved.Value));
            }
            else {
                this.Adapter.DeleteCommand.Parameters[6].Value = ((object)(1));
                this.Adapter.DeleteCommand.Parameters[7].Value = System.DBNull.Value;
            }
            if ((Original_Result == null)) {
                this.Adapter.DeleteCommand.Parameters[8].Value = ((object)(1));
                this.Adapter.DeleteCommand.Parameters[9].Value = System.DBNull.Value;
            }
            else {
                this.Adapter.DeleteCommand.Parameters[8].Value = ((object)(0));
                this.Adapter.DeleteCommand.Parameters[9].Value = ((string)(Original_Result));
            }
            System.Data.ConnectionState previousConnectionState = this.Adapter.DeleteCommand.Connection.State;
            if (((this.Adapter.DeleteCommand.Connection.State & System.Data.ConnectionState.Open) 
                        != System.Data.ConnectionState.Open)) {
                this.Adapter.DeleteCommand.Connection.Open();
            }
            try {
                int returnValue = this.Adapter.DeleteCommand.ExecuteNonQuery();
                return returnValue;
            }
            finally {
                if ((previousConnectionState == System.Data.ConnectionState.Closed)) {
                    this.Adapter.DeleteCommand.Connection.Close();
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public virtual int Insert(string WorkItemName, string WorkItemType, string Description, string Reason, System.DateTime DateRequested, string FundingCostCenter, string AreaAffected, System.Nullable<bool> Approved, string Result) {
            if ((WorkItemName == null)) {
                throw new System.ArgumentNullException("WorkItemName");
            }
            else {
                this.Adapter.InsertCommand.Parameters[0].Value = ((string)(WorkItemName));
            }
            if ((WorkItemType == null)) {
                throw new System.ArgumentNullException("WorkItemType");
            }
            else {
                this.Adapter.InsertCommand.Parameters[1].Value = ((string)(WorkItemType));
            }
            if ((Description == null)) {
                throw new System.ArgumentNullException("Description");
            }
            else {
                this.Adapter.InsertCommand.Parameters[2].Value = ((string)(Description));
            }
            if ((Reason == null)) {
                throw new System.ArgumentNullException("Reason");
            }
            else {
                this.Adapter.InsertCommand.Parameters[3].Value = ((string)(Reason));
            }
            this.Adapter.InsertCommand.Parameters[4].Value = ((System.DateTime)(DateRequested));
            if ((FundingCostCenter == null)) {
                throw new System.ArgumentNullException("FundingCostCenter");
            }
            else {
                this.Adapter.InsertCommand.Parameters[5].Value = ((string)(FundingCostCenter));
            }
            if ((AreaAffected == null)) {
                throw new System.ArgumentNullException("AreaAffected");
            }
            else {
                this.Adapter.InsertCommand.Parameters[6].Value = ((string)(AreaAffected));
            }
            if ((Approved.HasValue == true)) {
                this.Adapter.InsertCommand.Parameters[7].Value = ((bool)(Approved.Value));
            }
            else {
                this.Adapter.InsertCommand.Parameters[7].Value = System.DBNull.Value;
            }
            if ((Result == null)) {
                this.Adapter.InsertCommand.Parameters[8].Value = System.DBNull.Value;
            }
            else {
                this.Adapter.InsertCommand.Parameters[8].Value = ((string)(Result));
            }
            System.Data.ConnectionState previousConnectionState = this.Adapter.InsertCommand.Connection.State;
            if (((this.Adapter.InsertCommand.Connection.State & System.Data.ConnectionState.Open) 
                        != System.Data.ConnectionState.Open)) {
                this.Adapter.InsertCommand.Connection.Open();
            }
            try {
                int returnValue = this.Adapter.InsertCommand.ExecuteNonQuery();
                return returnValue;
            }
            finally {
                if ((previousConnectionState == System.Data.ConnectionState.Closed)) {
                    this.Adapter.InsertCommand.Connection.Close();
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public virtual int Update(
                    string WorkItemName, 
                    string WorkItemType, 
                    string Description, 
                    string Reason, 
                    System.DateTime DateRequested, 
                    string FundingCostCenter, 
                    string AreaAffected, 
                    System.Nullable<bool> Approved, 
                    string Result, 
                    string Original_WorkItemName, 
                    string Original_WorkItemType, 
                    string Original_Reason, 
                    System.DateTime Original_DateRequested, 
                    string Original_FundingCostCenter, 
                    string Original_AreaAffected, 
                    System.Nullable<bool> Original_Approved, 
                    string Original_Result) {
            if ((WorkItemName == null)) {
                throw new System.ArgumentNullException("WorkItemName");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[0].Value = ((string)(WorkItemName));
            }
            if ((WorkItemType == null)) {
                throw new System.ArgumentNullException("WorkItemType");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[1].Value = ((string)(WorkItemType));
            }
            if ((Description == null)) {
                throw new System.ArgumentNullException("Description");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[2].Value = ((string)(Description));
            }
            if ((Reason == null)) {
                throw new System.ArgumentNullException("Reason");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[3].Value = ((string)(Reason));
            }
            this.Adapter.UpdateCommand.Parameters[4].Value = ((System.DateTime)(DateRequested));
            if ((FundingCostCenter == null)) {
                throw new System.ArgumentNullException("FundingCostCenter");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[5].Value = ((string)(FundingCostCenter));
            }
            if ((AreaAffected == null)) {
                throw new System.ArgumentNullException("AreaAffected");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[6].Value = ((string)(AreaAffected));
            }
            if ((Approved.HasValue == true)) {
                this.Adapter.UpdateCommand.Parameters[7].Value = ((bool)(Approved.Value));
            }
            else {
                this.Adapter.UpdateCommand.Parameters[7].Value = System.DBNull.Value;
            }
            if ((Result == null)) {
                this.Adapter.UpdateCommand.Parameters[8].Value = System.DBNull.Value;
            }
            else {
                this.Adapter.UpdateCommand.Parameters[8].Value = ((string)(Result));
            }
            if ((Original_WorkItemName == null)) {
                throw new System.ArgumentNullException("Original_WorkItemName");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[9].Value = ((string)(Original_WorkItemName));
            }
            if ((Original_WorkItemType == null)) {
                throw new System.ArgumentNullException("Original_WorkItemType");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[10].Value = ((string)(Original_WorkItemType));
            }
            if ((Original_Reason == null)) {
                throw new System.ArgumentNullException("Original_Reason");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[11].Value = ((string)(Original_Reason));
            }
            this.Adapter.UpdateCommand.Parameters[12].Value = ((System.DateTime)(Original_DateRequested));
            if ((Original_FundingCostCenter == null)) {
                throw new System.ArgumentNullException("Original_FundingCostCenter");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[13].Value = ((string)(Original_FundingCostCenter));
            }
            if ((Original_AreaAffected == null)) {
                throw new System.ArgumentNullException("Original_AreaAffected");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[14].Value = ((string)(Original_AreaAffected));
            }
            if ((Original_Approved.HasValue == true)) {
                this.Adapter.UpdateCommand.Parameters[15].Value = ((object)(0));
                this.Adapter.UpdateCommand.Parameters[16].Value = ((bool)(Original_Approved.Value));
            }
            else {
                this.Adapter.UpdateCommand.Parameters[15].Value = ((object)(1));
                this.Adapter.UpdateCommand.Parameters[16].Value = System.DBNull.Value;
            }
            if ((Original_Result == null)) {
                this.Adapter.UpdateCommand.Parameters[17].Value = ((object)(1));
                this.Adapter.UpdateCommand.Parameters[18].Value = System.DBNull.Value;
            }
            else {
                this.Adapter.UpdateCommand.Parameters[17].Value = ((object)(0));
                this.Adapter.UpdateCommand.Parameters[18].Value = ((string)(Original_Result));
            }
            System.Data.ConnectionState previousConnectionState = this.Adapter.UpdateCommand.Connection.State;
            if (((this.Adapter.UpdateCommand.Connection.State & System.Data.ConnectionState.Open) 
                        != System.Data.ConnectionState.Open)) {
                this.Adapter.UpdateCommand.Connection.Open();
            }
            try {
                int returnValue = this.Adapter.UpdateCommand.ExecuteNonQuery();
                return returnValue;
            }
            finally {
                if ((previousConnectionState == System.Data.ConnectionState.Closed)) {
                    this.Adapter.UpdateCommand.Connection.Close();
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.ComponentModel.DataObjectAttribute(true)]
    [System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" +
        ", Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
    public partial class WorkTypesTableAdapter : System.ComponentModel.Component {
        
        private System.Data.SqlClient.SqlDataAdapter _adapter;
        
        private System.Data.SqlClient.SqlConnection _connection;
        
        private System.Data.SqlClient.SqlCommand[] _commandCollection;
        
        private bool _clearBeforeFill;
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public WorkTypesTableAdapter() {
            this.ClearBeforeFill = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private System.Data.SqlClient.SqlDataAdapter Adapter {
            get {
                if ((this._adapter == null)) {
                    this.InitAdapter();
                }
                return this._adapter;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal System.Data.SqlClient.SqlConnection Connection {
            get {
                if ((this._connection == null)) {
                    this.InitConnection();
                }
                return this._connection;
            }
            set {
                this._connection = value;
                if ((this.Adapter.InsertCommand != null)) {
                    this.Adapter.InsertCommand.Connection = value;
                }
                if ((this.Adapter.DeleteCommand != null)) {
                    this.Adapter.DeleteCommand.Connection = value;
                }
                if ((this.Adapter.UpdateCommand != null)) {
                    this.Adapter.UpdateCommand.Connection = value;
                }
                for (int i = 0; (i < this.CommandCollection.Length); i = (i + 1)) {
                    if ((this.CommandCollection[i] != null)) {
                        ((System.Data.SqlClient.SqlCommand)(this.CommandCollection[i])).Connection = value;
                    }
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected System.Data.SqlClient.SqlCommand[] CommandCollection {
            get {
                if ((this._commandCollection == null)) {
                    this.InitCommandCollection();
                }
                return this._commandCollection;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public bool ClearBeforeFill {
            get {
                return this._clearBeforeFill;
            }
            set {
                this._clearBeforeFill = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitAdapter() {
            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "WorkTypes";
            tableMapping.ColumnMappings.Add("WorkTypeName", "WorkTypeName");
            this._adapter.TableMappings.Add(tableMapping);
            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[WorkTypes] WHERE (([WorkTypeName] = @Original_WorkTypeName))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_WorkTypeName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkTypeName", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[WorkTypes] ([WorkTypeName]) VALUES (@WorkTypeName);\r\nSELECT Wo" +
                "rkTypeName FROM WorkTypes WHERE (WorkTypeName = @WorkTypeName)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@WorkTypeName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkTypeName", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[WorkTypes] SET [WorkTypeName] = @WorkTypeName WHERE (([WorkTypeName" +
                "] = @Original_WorkTypeName));\r\nSELECT WorkTypeName FROM WorkTypes WHERE (WorkTyp" +
                "eName = @WorkTypeName)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@WorkTypeName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkTypeName", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_WorkTypeName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkTypeName", System.Data.DataRowVersion.Original, false, null, "", "", ""));
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitConnection() {
            this._connection = new System.Data.SqlClient.SqlConnection();
            this._connection.ConnectionString = global::Workflows.Properties.Settings.Default.ASPNETDBConnectionString;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitCommandCollection() {
            this._commandCollection = new System.Data.SqlClient.SqlCommand[1];
            this._commandCollection[0] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT WorkTypeName FROM dbo.WorkTypes";
            this._commandCollection[0].CommandType = System.Data.CommandType.Text;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Fill, true)]
        public virtual int Fill(WorkItemsDataSet.WorkTypesDataTable dataTable) {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if ((this.ClearBeforeFill == true)) {
                dataTable.Clear();
            }
            int returnValue = this.Adapter.Fill(dataTable);
            return returnValue;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public virtual WorkItemsDataSet.WorkTypesDataTable GetData() {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            WorkItemsDataSet.WorkTypesDataTable dataTable = new WorkItemsDataSet.WorkTypesDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(WorkItemsDataSet.WorkTypesDataTable dataTable) {
            return this.Adapter.Update(dataTable);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(WorkItemsDataSet dataSet) {
            return this.Adapter.Update(dataSet, "WorkTypes");
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(System.Data.DataRow dataRow) {
            return this.Adapter.Update(new System.Data.DataRow[] {
                        dataRow});
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(System.Data.DataRow[] dataRows) {
            return this.Adapter.Update(dataRows);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public virtual int Delete(string Original_WorkTypeName) {
            if ((Original_WorkTypeName == null)) {
                throw new System.ArgumentNullException("Original_WorkTypeName");
            }
            else {
                this.Adapter.DeleteCommand.Parameters[0].Value = ((string)(Original_WorkTypeName));
            }
            System.Data.ConnectionState previousConnectionState = this.Adapter.DeleteCommand.Connection.State;
            if (((this.Adapter.DeleteCommand.Connection.State & System.Data.ConnectionState.Open) 
                        != System.Data.ConnectionState.Open)) {
                this.Adapter.DeleteCommand.Connection.Open();
            }
            try {
                int returnValue = this.Adapter.DeleteCommand.ExecuteNonQuery();
                return returnValue;
            }
            finally {
                if ((previousConnectionState == System.Data.ConnectionState.Closed)) {
                    this.Adapter.DeleteCommand.Connection.Close();
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public virtual int Insert(string WorkTypeName) {
            if ((WorkTypeName == null)) {
                throw new System.ArgumentNullException("WorkTypeName");
            }
            else {
                this.Adapter.InsertCommand.Parameters[0].Value = ((string)(WorkTypeName));
            }
            System.Data.ConnectionState previousConnectionState = this.Adapter.InsertCommand.Connection.State;
            if (((this.Adapter.InsertCommand.Connection.State & System.Data.ConnectionState.Open) 
                        != System.Data.ConnectionState.Open)) {
                this.Adapter.InsertCommand.Connection.Open();
            }
            try {
                int returnValue = this.Adapter.InsertCommand.ExecuteNonQuery();
                return returnValue;
            }
            finally {
                if ((previousConnectionState == System.Data.ConnectionState.Closed)) {
                    this.Adapter.InsertCommand.Connection.Close();
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public virtual int Update(string WorkTypeName, string Original_WorkTypeName) {
            if ((WorkTypeName == null)) {
                throw new System.ArgumentNullException("WorkTypeName");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[0].Value = ((string)(WorkTypeName));
            }
            if ((Original_WorkTypeName == null)) {
                throw new System.ArgumentNullException("Original_WorkTypeName");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[1].Value = ((string)(Original_WorkTypeName));
            }
            System.Data.ConnectionState previousConnectionState = this.Adapter.UpdateCommand.Connection.State;
            if (((this.Adapter.UpdateCommand.Connection.State & System.Data.ConnectionState.Open) 
                        != System.Data.ConnectionState.Open)) {
                this.Adapter.UpdateCommand.Connection.Open();
            }
            try {
                int returnValue = this.Adapter.UpdateCommand.ExecuteNonQuery();
                return returnValue;
            }
            finally {
                if ((previousConnectionState == System.Data.ConnectionState.Closed)) {
                    this.Adapter.UpdateCommand.Connection.Close();
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.ComponentModel.DataObjectAttribute(true)]
    [System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" +
        ", Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
    public partial class UserActivitiesWorkItemsTableAdapter : System.ComponentModel.Component {
        
        private System.Data.SqlClient.SqlDataAdapter _adapter;
        
        private System.Data.SqlClient.SqlConnection _connection;
        
        private System.Data.SqlClient.SqlCommand[] _commandCollection;
        
        private bool _clearBeforeFill;
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public UserActivitiesWorkItemsTableAdapter() {
            this.ClearBeforeFill = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private System.Data.SqlClient.SqlDataAdapter Adapter {
            get {
                if ((this._adapter == null)) {
                    this.InitAdapter();
                }
                return this._adapter;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal System.Data.SqlClient.SqlConnection Connection {
            get {
                if ((this._connection == null)) {
                    this.InitConnection();
                }
                return this._connection;
            }
            set {
                this._connection = value;
                if ((this.Adapter.InsertCommand != null)) {
                    this.Adapter.InsertCommand.Connection = value;
                }
                if ((this.Adapter.DeleteCommand != null)) {
                    this.Adapter.DeleteCommand.Connection = value;
                }
                if ((this.Adapter.UpdateCommand != null)) {
                    this.Adapter.UpdateCommand.Connection = value;
                }
                for (int i = 0; (i < this.CommandCollection.Length); i = (i + 1)) {
                    if ((this.CommandCollection[i] != null)) {
                        ((System.Data.SqlClient.SqlCommand)(this.CommandCollection[i])).Connection = value;
                    }
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected System.Data.SqlClient.SqlCommand[] CommandCollection {
            get {
                if ((this._commandCollection == null)) {
                    this.InitCommandCollection();
                }
                return this._commandCollection;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public bool ClearBeforeFill {
            get {
                return this._clearBeforeFill;
            }
            set {
                this._clearBeforeFill = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitAdapter() {
            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "UserActivitiesWorkItems";
            tableMapping.ColumnMappings.Add("ActivityGuid", "ActivityGuid");
            tableMapping.ColumnMappings.Add("WorkItemName", "WorkItemName");
            this._adapter.TableMappings.Add(tableMapping);
            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[UserActivitiesWorkItems] WHERE (([ActivityGuid] = @Original_Ac" +
                "tivityGuid) AND ([WorkItemName] = @Original_WorkItemName))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ActivityGuid", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ActivityGuid", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_WorkItemName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkItemName", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[UserActivitiesWorkItems] ([ActivityGuid], [WorkItemName]) VALU" +
                "ES (@ActivityGuid, @WorkItemName);\r\nSELECT ActivityGuid, WorkItemName FROM UserA" +
                "ctivitiesWorkItems WHERE (ActivityGuid = @ActivityGuid) AND (WorkItemName = @Wor" +
                "kItemName)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ActivityGuid", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ActivityGuid", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@WorkItemName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkItemName", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[UserActivitiesWorkItems] SET [ActivityGuid] = @ActivityGuid, [WorkItemName] = @WorkItemName WHERE (([ActivityGuid] = @Original_ActivityGuid) AND ([WorkItemName] = @Original_WorkItemName));
SELECT ActivityGuid, WorkItemName FROM UserActivitiesWorkItems WHERE (ActivityGuid = @ActivityGuid) AND (WorkItemName = @WorkItemName)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ActivityGuid", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ActivityGuid", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@WorkItemName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkItemName", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ActivityGuid", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ActivityGuid", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_WorkItemName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "WorkItemName", System.Data.DataRowVersion.Original, false, null, "", "", ""));
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitConnection() {
            this._connection = new System.Data.SqlClient.SqlConnection();
            this._connection.ConnectionString = global::Workflows.Properties.Settings.Default.ASPNETDBConnectionString;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitCommandCollection() {
            this._commandCollection = new System.Data.SqlClient.SqlCommand[2];
            this._commandCollection[0] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT ActivityGuid, WorkItemName FROM dbo.UserActivitiesWorkItems";
            this._commandCollection[0].CommandType = System.Data.CommandType.Text;
            this._commandCollection[1] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "SELECT ActivityGuid, WorkItemName FROM dbo.UserActivitiesWorkItems WHERE (Activit" +
                "yGuid = @activityGuid)";
            this._commandCollection[1].CommandType = System.Data.CommandType.Text;
            this._commandCollection[1].Parameters.Add(new System.Data.SqlClient.SqlParameter("@activityGuid", System.Data.SqlDbType.NChar, 36, System.Data.ParameterDirection.Input, 0, 0, "ActivityGuid", System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Fill, true)]
        public virtual int Fill(WorkItemsDataSet.UserActivitiesWorkItemsDataTable dataTable) {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if ((this.ClearBeforeFill == true)) {
                dataTable.Clear();
            }
            int returnValue = this.Adapter.Fill(dataTable);
            return returnValue;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public virtual WorkItemsDataSet.UserActivitiesWorkItemsDataTable GetData() {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            WorkItemsDataSet.UserActivitiesWorkItemsDataTable dataTable = new WorkItemsDataSet.UserActivitiesWorkItemsDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Fill, false)]
        public virtual int FillByActivityGuid(WorkItemsDataSet.UserActivitiesWorkItemsDataTable dataTable, string activityGuid) {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            if ((activityGuid == null)) {
                throw new System.ArgumentNullException("activityGuid");
            }
            else {
                this.Adapter.SelectCommand.Parameters[0].Value = ((string)(activityGuid));
            }
            if ((this.ClearBeforeFill == true)) {
                dataTable.Clear();
            }
            int returnValue = this.Adapter.Fill(dataTable);
            return returnValue;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public virtual WorkItemsDataSet.UserActivitiesWorkItemsDataTable GetDataByActivityGuid(string activityGuid) {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            if ((activityGuid == null)) {
                throw new System.ArgumentNullException("activityGuid");
            }
            else {
                this.Adapter.SelectCommand.Parameters[0].Value = ((string)(activityGuid));
            }
            WorkItemsDataSet.UserActivitiesWorkItemsDataTable dataTable = new WorkItemsDataSet.UserActivitiesWorkItemsDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(WorkItemsDataSet.UserActivitiesWorkItemsDataTable dataTable) {
            return this.Adapter.Update(dataTable);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(WorkItemsDataSet dataSet) {
            return this.Adapter.Update(dataSet, "UserActivitiesWorkItems");
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(System.Data.DataRow dataRow) {
            return this.Adapter.Update(new System.Data.DataRow[] {
                        dataRow});
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(System.Data.DataRow[] dataRows) {
            return this.Adapter.Update(dataRows);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public virtual int Delete(string Original_ActivityGuid, string Original_WorkItemName) {
            if ((Original_ActivityGuid == null)) {
                throw new System.ArgumentNullException("Original_ActivityGuid");
            }
            else {
                this.Adapter.DeleteCommand.Parameters[0].Value = ((string)(Original_ActivityGuid));
            }
            if ((Original_WorkItemName == null)) {
                throw new System.ArgumentNullException("Original_WorkItemName");
            }
            else {
                this.Adapter.DeleteCommand.Parameters[1].Value = ((string)(Original_WorkItemName));
            }
            System.Data.ConnectionState previousConnectionState = this.Adapter.DeleteCommand.Connection.State;
            if (((this.Adapter.DeleteCommand.Connection.State & System.Data.ConnectionState.Open) 
                        != System.Data.ConnectionState.Open)) {
                this.Adapter.DeleteCommand.Connection.Open();
            }
            try {
                int returnValue = this.Adapter.DeleteCommand.ExecuteNonQuery();
                return returnValue;
            }
            finally {
                if ((previousConnectionState == System.Data.ConnectionState.Closed)) {
                    this.Adapter.DeleteCommand.Connection.Close();
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public virtual int Insert(string ActivityGuid, string WorkItemName) {
            if ((ActivityGuid == null)) {
                throw new System.ArgumentNullException("ActivityGuid");
            }
            else {
                this.Adapter.InsertCommand.Parameters[0].Value = ((string)(ActivityGuid));
            }
            if ((WorkItemName == null)) {
                throw new System.ArgumentNullException("WorkItemName");
            }
            else {
                this.Adapter.InsertCommand.Parameters[1].Value = ((string)(WorkItemName));
            }
            System.Data.ConnectionState previousConnectionState = this.Adapter.InsertCommand.Connection.State;
            if (((this.Adapter.InsertCommand.Connection.State & System.Data.ConnectionState.Open) 
                        != System.Data.ConnectionState.Open)) {
                this.Adapter.InsertCommand.Connection.Open();
            }
            try {
                int returnValue = this.Adapter.InsertCommand.ExecuteNonQuery();
                return returnValue;
            }
            finally {
                if ((previousConnectionState == System.Data.ConnectionState.Closed)) {
                    this.Adapter.InsertCommand.Connection.Close();
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public virtual int Update(string ActivityGuid, string WorkItemName, string Original_ActivityGuid, string Original_WorkItemName) {
            if ((ActivityGuid == null)) {
                throw new System.ArgumentNullException("ActivityGuid");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[0].Value = ((string)(ActivityGuid));
            }
            if ((WorkItemName == null)) {
                throw new System.ArgumentNullException("WorkItemName");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[1].Value = ((string)(WorkItemName));
            }
            if ((Original_ActivityGuid == null)) {
                throw new System.ArgumentNullException("Original_ActivityGuid");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[2].Value = ((string)(Original_ActivityGuid));
            }
            if ((Original_WorkItemName == null)) {
                throw new System.ArgumentNullException("Original_WorkItemName");
            }
            else {
                this.Adapter.UpdateCommand.Parameters[3].Value = ((string)(Original_WorkItemName));
            }
            System.Data.ConnectionState previousConnectionState = this.Adapter.UpdateCommand.Connection.State;
            if (((this.Adapter.UpdateCommand.Connection.State & System.Data.ConnectionState.Open) 
                        != System.Data.ConnectionState.Open)) {
                this.Adapter.UpdateCommand.Connection.Open();
            }
            try {
                int returnValue = this.Adapter.UpdateCommand.ExecuteNonQuery();
                return returnValue;
            }
            finally {
                if ((previousConnectionState == System.Data.ConnectionState.Closed)) {
                    this.Adapter.UpdateCommand.Connection.Close();
                }
            }
        }
    }
}

#pragma warning restore 1591