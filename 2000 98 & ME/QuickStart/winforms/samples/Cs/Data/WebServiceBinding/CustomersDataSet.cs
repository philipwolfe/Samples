//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
/// 
///  Typed DataSet for Customers generated using XSD tool
///  TDGUtil.exe in the QuickStart Utils directory used to generate the XSD
/// 
//------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.Cs.WebServiceBinding.Data {
    using System;
    using System.Data;
    using System.Core;
    
    public class CustomersDataSet : DataSet {
        private int tableCount;
        private int relationCount;
        private Customers tableCustomers;
        private Orders tableOrders;
        private DataRelation relationCustomersOrders;
        
        public CustomersDataSet() {
            this.InitClass();
        }
        
        [System.ComponentModel.PersistContentsAttribute(true)]
        public virtual Customers Customers {
            get {
                return this.tableCustomers;
            }
        }
        [System.ComponentModel.PersistContentsAttribute(true)]
        public virtual Orders Orders {
            get {
                return this.tableOrders;
            }
        }
        
        private void InitClass() {
            this.DataSetName = "CustomersDataSet";
            this.Namespace = "";
            this.tableCount = 2;
            this.relationCount = 1;
            this.tableCustomers = new Customers("Customers");
            this.Tables.Add(this.tableCustomers);
            this.tableOrders = new Orders("Orders");
            this.Tables.Add(this.tableOrders);
            this.Orders.Constraints.Add(new System.Data.ForeignKeyConstraint("CustomersOrders", new System.Data.DataColumn[] {this.tableCustomers.CustomerIDColumn}, new System.Data.DataColumn[] {this.tableOrders.CustomerIDColumn}));
            this.relationCustomersOrders = new DataRelation("CustomersOrders", new System.Data.DataColumn[] {this.tableCustomers.CustomerIDColumn}, new System.Data.DataColumn[] {this.tableOrders.CustomerIDColumn}, false);
            this.Relations.Add(this.relationCustomersOrders);
        }
        protected override bool HasSchemaChanged() {
            return ((((this.tableCount) != (this.Tables.Count))) || (((this.relationCount) != (this.Relations.Count))));
        }
        protected override void OnRemoveRelation(DataRelation relation) {
            if (((relation) == (this.relationCustomersOrders))) {
                throw new ArgumentException("Can't remove relation since it it built in to this dataSet");
            }
        }
        public override bool ShouldPersistTables() {
            return ((this.tableCount) != (this.Tables.Count));
        }
        public override bool ShouldPersistRelations() {
            return ((this.relationCount) != (this.Relations.Count));
        }
        public override void ResetTables() {
            for (int i = 0; ((i) < (this.Tables.Count)); i = ((i) + (1))) {
                if (((((this.Tables[i]) == (this.tableOrders))) || (((this.Tables[i]) == (this.tableCustomers))))) {
                }
                else {
                    this.Tables.Remove(this.Tables[i]);
                }
            }
        }
        public override void ResetRelations() {
            for (int i = 0; ((i) < (this.Relations.Count)); i = ((i) + (1))) {
                if (((this.Relations[i]) == (this.relationCustomersOrders))) {
                }
                else {
                    this.Relations.Remove(this.Relations[i]);
                }
            }
        }
        protected override void OnRemoveTable(DataTable table) {
            if (((((table) == (this.tableOrders))) || (((table) == (this.tableCustomers))))) {
                throw new ArgumentException("Can't remove relation since it it built in to this dataSet");
            }
        }
        
    }
    public class Customers : DataTable, System.Collections.ICollection {
        private int columnCount;
        private int constraintCount;
        private Customers_CustomerID columnCustomerID;
        private Customers_CompanyName columnCompanyName;
        private Customers_ContactName columnContactName;
        private Customers_ContactTitle columnContactTitle;
        private Customers_Address columnAddress;
        private Customers_City columnCity;
        private Customers_Region columnRegion;
        private Customers_PostalCode columnPostalCode;
        private Customers_Country columnCountry;
        private Customers_Phone columnPhone;
        private Customers_Fax columnFax;
        public CustomersRowChangeEventHandler CustomersRowChanged;
        public CustomersRowChangeEventHandler CustomersRowChanging;
        public DataColumnChangeEventHandler CustomerIDColumnChanging;
        public DataColumnChangeEventHandler CompanyNameColumnChanging;
        public DataColumnChangeEventHandler ContactNameColumnChanging;
        public DataColumnChangeEventHandler ContactTitleColumnChanging;
        public DataColumnChangeEventHandler AddressColumnChanging;
        public DataColumnChangeEventHandler CityColumnChanging;
        public DataColumnChangeEventHandler RegionColumnChanging;
        public DataColumnChangeEventHandler PostalCodeColumnChanging;
        public DataColumnChangeEventHandler CountryColumnChanging;
        public DataColumnChangeEventHandler PhoneColumnChanging;
        public DataColumnChangeEventHandler FaxColumnChanging;
        
        public Customers(string name) : 
                base(name) {
            this.InitClass();
        }
        public Customers() : 
                base("Customers") {
            this.InitClass();
        }
        
        public virtual int Count {
            get {
                return this.Rows.Count;
            }
        }
        bool System.Collections.ICollection.IsReadOnly {
            get {
                return false;
            }
        }
        bool System.Collections.ICollection.IsSynchronized {
            get {
                return false;
            }
        }
        object System.Collections.ICollection.SyncRoot {
            get {
                return this;
            }
        }
        public virtual Customers_CustomerID CustomerIDColumn {
            get {
                return this.columnCustomerID;
            }
        }
        public virtual Customers_CompanyName CompanyNameColumn {
            get {
                return this.columnCompanyName;
            }
        }
        public virtual Customers_ContactName ContactNameColumn {
            get {
                return this.columnContactName;
            }
        }
        public virtual Customers_ContactTitle ContactTitleColumn {
            get {
                return this.columnContactTitle;
            }
        }
        public virtual Customers_Address AddressColumn {
            get {
                return this.columnAddress;
            }
        }
        public virtual Customers_City CityColumn {
            get {
                return this.columnCity;
            }
        }
        public virtual Customers_Region RegionColumn {
            get {
                return this.columnRegion;
            }
        }
        public virtual Customers_PostalCode PostalCodeColumn {
            get {
                return this.columnPostalCode;
            }
        }
        public virtual Customers_Country CountryColumn {
            get {
                return this.columnCountry;
            }
        }
        public virtual Customers_Phone PhoneColumn {
            get {
                return this.columnPhone;
            }
        }
        public virtual Customers_Fax FaxColumn {
            get {
                return this.columnFax;
            }
        }
        public virtual CustomersRow this[int index] {
            get {
                return (CustomersRow)(this.Rows[index]);
            }
        }
        
        public virtual void AddCustomersRow(CustomersRow rowCustomersRow) {
            this.Rows.Add(rowCustomersRow);
        }
        public virtual CustomersRow AddCustomersRow(string columnCustomerID, string columnCompanyName, string columnContactName, string columnContactTitle, string columnAddress, string columnCity, string columnRegion, string columnPostalCode, string columnCountry, string columnPhone, string columnFax) {
            CustomersRow rowCustomersRow;
            rowCustomersRow = (CustomersRow)(this.NewRow());
            rowCustomersRow.ItemArray = new Object[] {columnCustomerID,
                    columnCompanyName,
                    columnContactName,
                    columnContactTitle,
                    columnAddress,
                    columnCity,
                    columnRegion,
                    columnPostalCode,
                    columnCountry,
                    columnPhone,
                    columnFax};
            this.Rows.Add(rowCustomersRow);
            return rowCustomersRow;
        }
        void System.Collections.ICollection.CopyTo(Array array, int offset) {
            for (int i = 0; ((i) < (this.Rows.Count)); i = ((i) + (1))) {
                array.SetValue(this.Rows[i], ((i) + (offset)));
            }
        }
        public virtual CustomersRow FindByCustomerID(string columnCustomerID) {
            return (CustomersRow)(this.Rows.Find(new Object[] {columnCustomerID}));
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.Rows.All.GetEnumerator();
        }
        protected override bool HasSchemaChanged() {
            return ((this.columnCount) == (this.Columns.Count));
        }
        private void InitClass() {
            this.columnCount = 11;
            this.constraintCount = 1;
            this.columnCustomerID = new Customers_CustomerID();
            this.Columns.Add(this.columnCustomerID);
            this.columnCompanyName = new Customers_CompanyName();
            this.Columns.Add(this.columnCompanyName);
            this.columnContactName = new Customers_ContactName();
            this.Columns.Add(this.columnContactName);
            this.columnContactTitle = new Customers_ContactTitle();
            this.Columns.Add(this.columnContactTitle);
            this.columnAddress = new Customers_Address();
            this.Columns.Add(this.columnAddress);
            this.columnCity = new Customers_City();
            this.Columns.Add(this.columnCity);
            this.columnRegion = new Customers_Region();
            this.Columns.Add(this.columnRegion);
            this.columnPostalCode = new Customers_PostalCode();
            this.Columns.Add(this.columnPostalCode);
            this.columnCountry = new Customers_Country();
            this.Columns.Add(this.columnCountry);
            this.columnPhone = new Customers_Phone();
            this.Columns.Add(this.columnPhone);
            this.columnFax = new Customers_Fax();
            this.Columns.Add(this.columnFax);
            this.PrimaryKey = new System.Data.DataColumn[] {this.columnCustomerID};
        }
        public virtual CustomersRow NewCustomersRow() {
            return (CustomersRow)(this.NewRow());
        }
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
            // We need to ensure that all Rows in the tabled are typed rows.
            // Table calls newRow whenever it needs to create a row.
            // So the following conditions are covered by Row newRow(Record record)
            // * Cursor calls table.addRecord(record) 
            // * table.addRow(object[] values) calls newRow(record)    
            return new CustomersRow(builder);
        }
        protected override System.Type GetRowType() {
            return typeof(CustomersRow);
        }
        protected override void OnRemoveColumn(DataColumn column) {
            if (((((((((((((((((((((((column) == (this.columnCustomerID))) || (((column) == (this.columnCompanyName))))) || (((column) == (this.columnContactName))))) || (((column) == (this.columnContactTitle))))) || (((column) == (this.columnAddress))))) || (((column) == (this.columnCity))))) || (((column) == (this.columnRegion))))) || (((column) == (this.columnPostalCode))))) || (((column) == (this.columnCountry))))) || (((column) == (this.columnPhone))))) || (((column) == (this.columnFax))))) {
                throw new ArgumentException("Can't remove column since it it built in to this dataSet");
            }
        }
        protected override void OnRowChanged(DataRowChangeEventArgs e) {
            base.OnRowChanged(e);
            if (((this.CustomersRowChanged) != (null))) {
                this.CustomersRowChanged(this, new CustomersRowChangeEvent((CustomersRow)(e.Row), e.Action));
            }
        }
        protected override void OnRowChanging(DataRowChangeEventArgs e) {
            if (((this.CustomersRowChanging) != (null))) {
                this.CustomersRowChanging(this, new CustomersRowChangeEvent((CustomersRow)(e.Row), e.Action));
            }
        }
        protected virtual void OnCustomerIDColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.CustomerIDColumnChanging) != (null))) {
                this.CustomerIDColumnChanging(this, e);
            }
        }
        protected virtual void OnCompanyNameColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.CompanyNameColumnChanging) != (null))) {
                this.CompanyNameColumnChanging(this, e);
            }
        }
        protected virtual void OnContactNameColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.ContactNameColumnChanging) != (null))) {
                this.ContactNameColumnChanging(this, e);
            }
        }
        protected virtual void OnContactTitleColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.ContactTitleColumnChanging) != (null))) {
                this.ContactTitleColumnChanging(this, e);
            }
        }
        protected virtual void OnAddressColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.AddressColumnChanging) != (null))) {
                this.AddressColumnChanging(this, e);
            }
        }
        protected virtual void OnCityColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.CityColumnChanging) != (null))) {
                this.CityColumnChanging(this, e);
            }
        }
        protected virtual void OnRegionColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.RegionColumnChanging) != (null))) {
                this.RegionColumnChanging(this, e);
            }
        }
        protected virtual void OnPostalCodeColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.PostalCodeColumnChanging) != (null))) {
                this.PostalCodeColumnChanging(this, e);
            }
        }
        protected virtual void OnCountryColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.CountryColumnChanging) != (null))) {
                this.CountryColumnChanging(this, e);
            }
        }
        protected virtual void OnPhoneColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.PhoneColumnChanging) != (null))) {
                this.PhoneColumnChanging(this, e);
            }
        }
        protected virtual void OnFaxColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.FaxColumnChanging) != (null))) {
                this.FaxColumnChanging(this, e);
            }
        }
        protected override void OnColumnChanging(DataColumnChangeEventArgs e) {
            base.OnColumnChanging(e);
            if (((e.Column) == (this.columnCustomerID))) {
                this.OnCustomerIDColumnChanging(e);
            }
            else {
                if (((e.Column) == (this.columnCompanyName))) {
                    this.OnCompanyNameColumnChanging(e);
                }
                else {
                    if (((e.Column) == (this.columnContactName))) {
                        this.OnContactNameColumnChanging(e);
                    }
                    else {
                        if (((e.Column) == (this.columnContactTitle))) {
                            this.OnContactTitleColumnChanging(e);
                        }
                        else {
                            if (((e.Column) == (this.columnAddress))) {
                                this.OnAddressColumnChanging(e);
                            }
                            else {
                                if (((e.Column) == (this.columnCity))) {
                                    this.OnCityColumnChanging(e);
                                }
                                else {
                                    if (((e.Column) == (this.columnRegion))) {
                                        this.OnRegionColumnChanging(e);
                                    }
                                    else {
                                        if (((e.Column) == (this.columnPostalCode))) {
                                            this.OnPostalCodeColumnChanging(e);
                                        }
                                        else {
                                            if (((e.Column) == (this.columnCountry))) {
                                                this.OnCountryColumnChanging(e);
                                            }
                                            else {
                                                if (((e.Column) == (this.columnPhone))) {
                                                    this.OnPhoneColumnChanging(e);
                                                }
                                                else {
                                                    if (((e.Column) == (this.columnFax))) {
                                                        this.OnFaxColumnChanging(e);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public virtual void RemoveCustomersRow(CustomersRow rowCustomersRow) {
            this.Rows.Remove(rowCustomersRow);
        }
        public override bool ShouldPersistPrimaryKey() {
            return false;
        }
        public override void ResetPrimaryKey() {
        }
        public override bool ShouldPersistColumns() {
            return ((this.columnCount) != (this.Columns.Count));
        }
        public override void ResetColumns() {
            for (int i = 0; ((i) < (this.Columns.Count)); i = ((i) + (1))) {
                if (((((this.Columns[i]) == (this.columnFax))) || (((((this.Columns[i]) == (this.columnPhone))) || (((((this.Columns[i]) == (this.columnCountry))) || (((((this.Columns[i]) == (this.columnPostalCode))) || (((((this.Columns[i]) == (this.columnRegion))) || (((((this.Columns[i]) == (this.columnCity))) || (((((this.Columns[i]) == (this.columnAddress))) || (((((this.Columns[i]) == (this.columnContactTitle))) || (((((this.Columns[i]) == (this.columnContactName))) || (((((this.Columns[i]) == (this.columnCompanyName))) || (((this.Columns[i]) == (this.columnCustomerID))))))))))))))))))))))) {
                }
                else {
                    this.Columns.Remove(this.Columns[i]);
                }
            }
        }
        public override bool ShouldPersistConstraints() {
            return ((this.constraintCount) != (this.Constraints.Count));
        }
        public override void ResetConstraints() {
            for (int i = this.constraintCount; ((i) < (this.Constraints.Count)); i = ((i) + (1))) {
                this.Constraints.Remove(this.Constraints[i]);
            }
        }
        
    }
    public class Customers_CustomerID : System.Data.DataColumn {
        public Customers_CustomerID() : 
                base("CustomerID", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
            this.AllowNull = false;
            this.Unique = true;
        }
        
    }
    public class Customers_CompanyName : System.Data.DataColumn {
        public Customers_CompanyName() : 
                base("CompanyName", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
            this.AllowNull = false;
        }
        
    }
    public class Customers_ContactName : System.Data.DataColumn {
        public Customers_ContactName() : 
                base("ContactName", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Customers_ContactTitle : System.Data.DataColumn {
        public Customers_ContactTitle() : 
                base("ContactTitle", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Customers_Address : System.Data.DataColumn {
        public Customers_Address() : 
                base("Address", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Customers_City : System.Data.DataColumn {
        public Customers_City() : 
                base("City", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Customers_Region : System.Data.DataColumn {
        public Customers_Region() : 
                base("Region", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Customers_PostalCode : System.Data.DataColumn {
        public Customers_PostalCode() : 
                base("PostalCode", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Customers_Country : System.Data.DataColumn {
        public Customers_Country() : 
                base("Country", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Customers_Phone : System.Data.DataColumn {
        public Customers_Phone() : 
                base("Phone", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Customers_Fax : System.Data.DataColumn {
        public Customers_Fax() : 
                base("Fax", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Orders : DataTable, System.Collections.ICollection {
        private int columnCount;
        private int constraintCount;
        private Orders_OrderID columnOrderID;
        private Orders_CustomerID columnCustomerID;
        private Orders_EmployeeID columnEmployeeID;
        private Orders_OrderDate columnOrderDate;
        private Orders_RequiredDate columnRequiredDate;
        private Orders_ShippedDate columnShippedDate;
        private Orders_ShipVia columnShipVia;
        private Orders_Freight columnFreight;
        private Orders_ShipName columnShipName;
        private Orders_ShipAddress columnShipAddress;
        private Orders_ShipCity columnShipCity;
        private Orders_ShipRegion columnShipRegion;
        private Orders_ShipPostalCode columnShipPostalCode;
        private Orders_ShipCountry columnShipCountry;
        public OrdersRowChangeEventHandler OrdersRowChanged;
        public OrdersRowChangeEventHandler OrdersRowChanging;
        public DataColumnChangeEventHandler OrderIDColumnChanging;
        public DataColumnChangeEventHandler CustomerIDColumnChanging;
        public DataColumnChangeEventHandler EmployeeIDColumnChanging;
        public DataColumnChangeEventHandler OrderDateColumnChanging;
        public DataColumnChangeEventHandler RequiredDateColumnChanging;
        public DataColumnChangeEventHandler ShippedDateColumnChanging;
        public DataColumnChangeEventHandler ShipViaColumnChanging;
        public DataColumnChangeEventHandler FreightColumnChanging;
        public DataColumnChangeEventHandler ShipNameColumnChanging;
        public DataColumnChangeEventHandler ShipAddressColumnChanging;
        public DataColumnChangeEventHandler ShipCityColumnChanging;
        public DataColumnChangeEventHandler ShipRegionColumnChanging;
        public DataColumnChangeEventHandler ShipPostalCodeColumnChanging;
        public DataColumnChangeEventHandler ShipCountryColumnChanging;
        
        public Orders(string name) : 
                base(name) {
            this.InitClass();
        }
        public Orders() : 
                base("Orders") {
            this.InitClass();
        }
        
        public virtual int Count {
            get {
                return this.Rows.Count;
            }
        }
        bool System.Collections.ICollection.IsReadOnly {
            get {
                return false;
            }
        }
        bool System.Collections.ICollection.IsSynchronized {
            get {
                return false;
            }
        }
        object System.Collections.ICollection.SyncRoot {
            get {
                return this;
            }
        }
        public virtual Orders_OrderID OrderIDColumn {
            get {
                return this.columnOrderID;
            }
        }
        public virtual Orders_CustomerID CustomerIDColumn {
            get {
                return this.columnCustomerID;
            }
        }
        public virtual Orders_EmployeeID EmployeeIDColumn {
            get {
                return this.columnEmployeeID;
            }
        }
        public virtual Orders_OrderDate OrderDateColumn {
            get {
                return this.columnOrderDate;
            }
        }
        public virtual Orders_RequiredDate RequiredDateColumn {
            get {
                return this.columnRequiredDate;
            }
        }
        public virtual Orders_ShippedDate ShippedDateColumn {
            get {
                return this.columnShippedDate;
            }
        }
        public virtual Orders_ShipVia ShipViaColumn {
            get {
                return this.columnShipVia;
            }
        }
        public virtual Orders_Freight FreightColumn {
            get {
                return this.columnFreight;
            }
        }
        public virtual Orders_ShipName ShipNameColumn {
            get {
                return this.columnShipName;
            }
        }
        public virtual Orders_ShipAddress ShipAddressColumn {
            get {
                return this.columnShipAddress;
            }
        }
        public virtual Orders_ShipCity ShipCityColumn {
            get {
                return this.columnShipCity;
            }
        }
        public virtual Orders_ShipRegion ShipRegionColumn {
            get {
                return this.columnShipRegion;
            }
        }
        public virtual Orders_ShipPostalCode ShipPostalCodeColumn {
            get {
                return this.columnShipPostalCode;
            }
        }
        public virtual Orders_ShipCountry ShipCountryColumn {
            get {
                return this.columnShipCountry;
            }
        }
        public virtual OrdersRow this[int index] {
            get {
                return (OrdersRow)(this.Rows[index]);
            }
        }
        
        public virtual void AddOrdersRow(OrdersRow rowOrdersRow) {
            this.Rows.Add(rowOrdersRow);
        }
        public virtual OrdersRow AddOrdersRow(CustomersRow parentCustomersRowByCustomersOrders, int columnEmployeeID, System.DateTime columnOrderDate, System.DateTime columnRequiredDate, System.DateTime columnShippedDate, int columnShipVia, System.Decimal columnFreight, string columnShipName, string columnShipAddress, string columnShipCity, string columnShipRegion, string columnShipPostalCode, string columnShipCountry) {
            OrdersRow rowOrdersRow;
            rowOrdersRow = (OrdersRow)(this.NewRow());
            rowOrdersRow.ItemArray = new Object[] {null,
                    parentCustomersRowByCustomersOrders.CustomerID,
                    columnEmployeeID,
                    columnOrderDate,
                    columnRequiredDate,
                    columnShippedDate,
                    columnShipVia,
                    columnFreight,
                    columnShipName,
                    columnShipAddress,
                    columnShipCity,
                    columnShipRegion,
                    columnShipPostalCode,
                    columnShipCountry};
            this.Rows.Add(rowOrdersRow);
            return rowOrdersRow;
        }
        void System.Collections.ICollection.CopyTo(Array array, int offset) {
            for (int i = 0; ((i) < (this.Rows.Count)); i = ((i) + (1))) {
                array.SetValue(this.Rows[i], ((i) + (offset)));
            }
        }
        public virtual OrdersRow FindByOrderID(int columnOrderID) {
            return (OrdersRow)(this.Rows.Find(new Object[] {columnOrderID}));
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.Rows.All.GetEnumerator();
        }
        protected override bool HasSchemaChanged() {
            return ((this.columnCount) == (this.Columns.Count));
        }
        private void InitClass() {
            this.columnCount = 14;
            this.constraintCount = 2;
            this.columnOrderID = new Orders_OrderID();
            this.Columns.Add(this.columnOrderID);
            this.columnCustomerID = new Orders_CustomerID();
            this.Columns.Add(this.columnCustomerID);
            this.columnEmployeeID = new Orders_EmployeeID();
            this.Columns.Add(this.columnEmployeeID);
            this.columnOrderDate = new Orders_OrderDate();
            this.Columns.Add(this.columnOrderDate);
            this.columnRequiredDate = new Orders_RequiredDate();
            this.Columns.Add(this.columnRequiredDate);
            this.columnShippedDate = new Orders_ShippedDate();
            this.Columns.Add(this.columnShippedDate);
            this.columnShipVia = new Orders_ShipVia();
            this.Columns.Add(this.columnShipVia);
            this.columnFreight = new Orders_Freight();
            this.Columns.Add(this.columnFreight);
            this.columnShipName = new Orders_ShipName();
            this.Columns.Add(this.columnShipName);
            this.columnShipAddress = new Orders_ShipAddress();
            this.Columns.Add(this.columnShipAddress);
            this.columnShipCity = new Orders_ShipCity();
            this.Columns.Add(this.columnShipCity);
            this.columnShipRegion = new Orders_ShipRegion();
            this.Columns.Add(this.columnShipRegion);
            this.columnShipPostalCode = new Orders_ShipPostalCode();
            this.Columns.Add(this.columnShipPostalCode);
            this.columnShipCountry = new Orders_ShipCountry();
            this.Columns.Add(this.columnShipCountry);
            this.PrimaryKey = new System.Data.DataColumn[] {this.columnOrderID};
        }
        public virtual OrdersRow NewOrdersRow() {
            return (OrdersRow)(this.NewRow());
        }
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
            // We need to ensure that all Rows in the tabled are typed rows.
            // Table calls newRow whenever it needs to create a row.
            // So the following conditions are covered by Row newRow(Record record)
            // * Cursor calls table.addRecord(record) 
            // * table.addRow(object[] values) calls newRow(record)    
            return new OrdersRow(builder);
        }
        protected override System.Type GetRowType() {
            return typeof(OrdersRow);
        }
        protected override void OnRemoveColumn(DataColumn column) {
            if (((((((((((((((((((((((((((((column) == (this.columnOrderID))) || (((column) == (this.columnCustomerID))))) || (((column) == (this.columnEmployeeID))))) || (((column) == (this.columnOrderDate))))) || (((column) == (this.columnRequiredDate))))) || (((column) == (this.columnShippedDate))))) || (((column) == (this.columnShipVia))))) || (((column) == (this.columnFreight))))) || (((column) == (this.columnShipName))))) || (((column) == (this.columnShipAddress))))) || (((column) == (this.columnShipCity))))) || (((column) == (this.columnShipRegion))))) || (((column) == (this.columnShipPostalCode))))) || (((column) == (this.columnShipCountry))))) {
                throw new ArgumentException("Can't remove column since it it built in to this dataSet");
            }
        }
        protected override void OnRowChanged(DataRowChangeEventArgs e) {
            base.OnRowChanged(e);
            if (((this.OrdersRowChanged) != (null))) {
                this.OrdersRowChanged(this, new OrdersRowChangeEvent((OrdersRow)(e.Row), e.Action));
            }
        }
        protected override void OnRowChanging(DataRowChangeEventArgs e) {
            if (((this.OrdersRowChanging) != (null))) {
                this.OrdersRowChanging(this, new OrdersRowChangeEvent((OrdersRow)(e.Row), e.Action));
            }
        }
        protected virtual void OnOrderIDColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.OrderIDColumnChanging) != (null))) {
                this.OrderIDColumnChanging(this, e);
            }
        }
        protected virtual void OnCustomerIDColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.CustomerIDColumnChanging) != (null))) {
                this.CustomerIDColumnChanging(this, e);
            }
        }
        protected virtual void OnEmployeeIDColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.EmployeeIDColumnChanging) != (null))) {
                this.EmployeeIDColumnChanging(this, e);
            }
        }
        protected virtual void OnOrderDateColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.OrderDateColumnChanging) != (null))) {
                this.OrderDateColumnChanging(this, e);
            }
        }
        protected virtual void OnRequiredDateColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.RequiredDateColumnChanging) != (null))) {
                this.RequiredDateColumnChanging(this, e);
            }
        }
        protected virtual void OnShippedDateColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.ShippedDateColumnChanging) != (null))) {
                this.ShippedDateColumnChanging(this, e);
            }
        }
        protected virtual void OnShipViaColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.ShipViaColumnChanging) != (null))) {
                this.ShipViaColumnChanging(this, e);
            }
        }
        protected virtual void OnFreightColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.FreightColumnChanging) != (null))) {
                this.FreightColumnChanging(this, e);
            }
        }
        protected virtual void OnShipNameColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.ShipNameColumnChanging) != (null))) {
                this.ShipNameColumnChanging(this, e);
            }
        }
        protected virtual void OnShipAddressColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.ShipAddressColumnChanging) != (null))) {
                this.ShipAddressColumnChanging(this, e);
            }
        }
        protected virtual void OnShipCityColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.ShipCityColumnChanging) != (null))) {
                this.ShipCityColumnChanging(this, e);
            }
        }
        protected virtual void OnShipRegionColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.ShipRegionColumnChanging) != (null))) {
                this.ShipRegionColumnChanging(this, e);
            }
        }
        protected virtual void OnShipPostalCodeColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.ShipPostalCodeColumnChanging) != (null))) {
                this.ShipPostalCodeColumnChanging(this, e);
            }
        }
        protected virtual void OnShipCountryColumnChanging(DataColumnChangeEventArgs e) {
            if (((this.ShipCountryColumnChanging) != (null))) {
                this.ShipCountryColumnChanging(this, e);
            }
        }
        protected override void OnColumnChanging(DataColumnChangeEventArgs e) {
            base.OnColumnChanging(e);
            if (((e.Column) == (this.columnOrderID))) {
                this.OnOrderIDColumnChanging(e);
            }
            else {
                if (((e.Column) == (this.columnCustomerID))) {
                    this.OnCustomerIDColumnChanging(e);
                }
                else {
                    if (((e.Column) == (this.columnEmployeeID))) {
                        this.OnEmployeeIDColumnChanging(e);
                    }
                    else {
                        if (((e.Column) == (this.columnOrderDate))) {
                            this.OnOrderDateColumnChanging(e);
                        }
                        else {
                            if (((e.Column) == (this.columnRequiredDate))) {
                                this.OnRequiredDateColumnChanging(e);
                            }
                            else {
                                if (((e.Column) == (this.columnShippedDate))) {
                                    this.OnShippedDateColumnChanging(e);
                                }
                                else {
                                    if (((e.Column) == (this.columnShipVia))) {
                                        this.OnShipViaColumnChanging(e);
                                    }
                                    else {
                                        if (((e.Column) == (this.columnFreight))) {
                                            this.OnFreightColumnChanging(e);
                                        }
                                        else {
                                            if (((e.Column) == (this.columnShipName))) {
                                                this.OnShipNameColumnChanging(e);
                                            }
                                            else {
                                                if (((e.Column) == (this.columnShipAddress))) {
                                                    this.OnShipAddressColumnChanging(e);
                                                }
                                                else {
                                                    if (((e.Column) == (this.columnShipCity))) {
                                                        this.OnShipCityColumnChanging(e);
                                                    }
                                                    else {
                                                        if (((e.Column) == (this.columnShipRegion))) {
                                                            this.OnShipRegionColumnChanging(e);
                                                        }
                                                        else {
                                                            if (((e.Column) == (this.columnShipPostalCode))) {
                                                                this.OnShipPostalCodeColumnChanging(e);
                                                            }
                                                            else {
                                                                if (((e.Column) == (this.columnShipCountry))) {
                                                                    this.OnShipCountryColumnChanging(e);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public virtual void RemoveOrdersRow(OrdersRow rowOrdersRow) {
            this.Rows.Remove(rowOrdersRow);
        }
        public override bool ShouldPersistPrimaryKey() {
            return false;
        }
        public override void ResetPrimaryKey() {
        }
        public override bool ShouldPersistColumns() {
            return ((this.columnCount) != (this.Columns.Count));
        }
        public override void ResetColumns() {
            for (int i = 0; ((i) < (this.Columns.Count)); i = ((i) + (1))) {
                if (((((this.Columns[i]) == (this.columnShipCountry))) || (((((this.Columns[i]) == (this.columnShipPostalCode))) || (((((this.Columns[i]) == (this.columnShipRegion))) || (((((this.Columns[i]) == (this.columnShipCity))) || (((((this.Columns[i]) == (this.columnShipAddress))) || (((((this.Columns[i]) == (this.columnShipName))) || (((((this.Columns[i]) == (this.columnFreight))) || (((((this.Columns[i]) == (this.columnShipVia))) || (((((this.Columns[i]) == (this.columnShippedDate))) || (((((this.Columns[i]) == (this.columnRequiredDate))) || (((((this.Columns[i]) == (this.columnOrderDate))) || (((((this.Columns[i]) == (this.columnEmployeeID))) || (((((this.Columns[i]) == (this.columnCustomerID))) || (((this.Columns[i]) == (this.columnOrderID))))))))))))))))))))))))))))) {
                }
                else {
                    this.Columns.Remove(this.Columns[i]);
                }
            }
        }
        public override bool ShouldPersistConstraints() {
            return ((this.constraintCount) != (this.Constraints.Count));
        }
        public override void ResetConstraints() {
            for (int i = this.constraintCount; ((i) < (this.Constraints.Count)); i = ((i) + (1))) {
                this.Constraints.Remove(this.Constraints[i]);
            }
        }
        
    }
    public class Orders_OrderID : System.Data.DataColumn {
        public Orders_OrderID() : 
                base("OrderID", typeof(int)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
            this.AutoIncrement = true;
            this.AllowNull = false;
            this.Unique = true;
        }
        
    }
    public class Orders_CustomerID : System.Data.DataColumn {
        public Orders_CustomerID() : 
                base("CustomerID", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Orders_EmployeeID : System.Data.DataColumn {
        public Orders_EmployeeID() : 
                base("EmployeeID", typeof(int)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Orders_OrderDate : System.Data.DataColumn {
        public Orders_OrderDate() : 
                base("OrderDate", typeof(System.DateTime)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Orders_RequiredDate : System.Data.DataColumn {
        public Orders_RequiredDate() : 
                base("RequiredDate", typeof(System.DateTime)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Orders_ShippedDate : System.Data.DataColumn {
        public Orders_ShippedDate() : 
                base("ShippedDate", typeof(System.DateTime)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Orders_ShipVia : System.Data.DataColumn {
        public Orders_ShipVia() : 
                base("ShipVia", typeof(int)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Orders_Freight : System.Data.DataColumn {
        public Orders_Freight() : 
                base("Freight", typeof(System.Decimal)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Orders_ShipName : System.Data.DataColumn {
        public Orders_ShipName() : 
                base("ShipName", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Orders_ShipAddress : System.Data.DataColumn {
        public Orders_ShipAddress() : 
                base("ShipAddress", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Orders_ShipCity : System.Data.DataColumn {
        public Orders_ShipCity() : 
                base("ShipCity", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Orders_ShipRegion : System.Data.DataColumn {
        public Orders_ShipRegion() : 
                base("ShipRegion", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Orders_ShipPostalCode : System.Data.DataColumn {
        public Orders_ShipPostalCode() : 
                base("ShipPostalCode", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class Orders_ShipCountry : System.Data.DataColumn {
        public Orders_ShipCountry() : 
                base("ShipCountry", typeof(string)) {
            this.InitClass();
        }
        
        public virtual void InitClass() {
        }
        
    }
    public class CustomersRow : DataRow {
        private Customers tableCustomers;
        
        public CustomersRow(DataRowBuilder rb) : 
                base(rb) {
            this.tableCustomers = (Customers)(this.Table);
        }
        
        public virtual string CustomerID {
            get {
                return (string)(this[this.tableCustomers.CustomerIDColumn]);
            }
            set {
                this[this.tableCustomers.CustomerIDColumn] = value;
            }
        }
        public virtual string CompanyName {
            get {
                return (string)(this[this.tableCustomers.CompanyNameColumn]);
            }
            set {
                this[this.tableCustomers.CompanyNameColumn] = value;
            }
        }
        public virtual string ContactName {
            get {
                return (string)(this[this.tableCustomers.ContactNameColumn]);
            }
            set {
                this[this.tableCustomers.ContactNameColumn] = value;
            }
        }
        public virtual bool ContactNameIsNull {
            get {
                return this.IsNull(this.tableCustomers.ContactNameColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableCustomers.ContactNameColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string ContactTitle {
            get {
                return (string)(this[this.tableCustomers.ContactTitleColumn]);
            }
            set {
                this[this.tableCustomers.ContactTitleColumn] = value;
            }
        }
        public virtual bool ContactTitleIsNull {
            get {
                return this.IsNull(this.tableCustomers.ContactTitleColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableCustomers.ContactTitleColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string Address {
            get {
                return (string)(this[this.tableCustomers.AddressColumn]);
            }
            set {
                this[this.tableCustomers.AddressColumn] = value;
            }
        }
        public virtual bool AddressIsNull {
            get {
                return this.IsNull(this.tableCustomers.AddressColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableCustomers.AddressColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string City {
            get {
                return (string)(this[this.tableCustomers.CityColumn]);
            }
            set {
                this[this.tableCustomers.CityColumn] = value;
            }
        }
        public virtual bool CityIsNull {
            get {
                return this.IsNull(this.tableCustomers.CityColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableCustomers.CityColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string Region {
            get {
                return (string)(this[this.tableCustomers.RegionColumn]);
            }
            set {
                this[this.tableCustomers.RegionColumn] = value;
            }
        }
        public virtual bool RegionIsNull {
            get {
                return this.IsNull(this.tableCustomers.RegionColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableCustomers.RegionColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string PostalCode {
            get {
                return (string)(this[this.tableCustomers.PostalCodeColumn]);
            }
            set {
                this[this.tableCustomers.PostalCodeColumn] = value;
            }
        }
        public virtual bool PostalCodeIsNull {
            get {
                return this.IsNull(this.tableCustomers.PostalCodeColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableCustomers.PostalCodeColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string Country {
            get {
                return (string)(this[this.tableCustomers.CountryColumn]);
            }
            set {
                this[this.tableCustomers.CountryColumn] = value;
            }
        }
        public virtual bool CountryIsNull {
            get {
                return this.IsNull(this.tableCustomers.CountryColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableCustomers.CountryColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string Phone {
            get {
                return (string)(this[this.tableCustomers.PhoneColumn]);
            }
            set {
                this[this.tableCustomers.PhoneColumn] = value;
            }
        }
        public virtual bool PhoneIsNull {
            get {
                return this.IsNull(this.tableCustomers.PhoneColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableCustomers.PhoneColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string Fax {
            get {
                return (string)(this[this.tableCustomers.FaxColumn]);
            }
            set {
                this[this.tableCustomers.FaxColumn] = value;
            }
        }
        public virtual bool FaxIsNull {
            get {
                return this.IsNull(this.tableCustomers.FaxColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableCustomers.FaxColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual OrdersRow[] OrdersByCustomersOrders {
            get {
                return (OrdersRow[])(this.GetChildRows(this.Table.ChildRelations["CustomersOrders"]));
            }
        }
        
    }
    public class OrdersRow : DataRow {
        private Orders tableOrders;
        
        public OrdersRow(DataRowBuilder rb) : 
                base(rb) {
            this.tableOrders = (Orders)(this.Table);
        }
        
        public virtual int OrderID {
            get {
                return (int)(this[this.tableOrders.OrderIDColumn]);
            }
            set {
                this[this.tableOrders.OrderIDColumn] = value;
            }
        }
        public virtual string CustomerID {
            get {
                return (string)(this[this.tableOrders.CustomerIDColumn]);
            }
            set {
                this[this.tableOrders.CustomerIDColumn] = value;
            }
        }
        public virtual bool CustomerIDIsNull {
            get {
                return this.IsNull(this.tableOrders.CustomerIDColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableOrders.CustomerIDColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual int EmployeeID {
            get {
                return (int)(this[this.tableOrders.EmployeeIDColumn]);
            }
            set {
                this[this.tableOrders.EmployeeIDColumn] = value;
            }
        }
        public virtual bool EmployeeIDIsNull {
            get {
                return this.IsNull(this.tableOrders.EmployeeIDColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableOrders.EmployeeIDColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual System.DateTime OrderDate {
            get {
                return (System.DateTime)(this[this.tableOrders.OrderDateColumn]);
            }
            set {
                this[this.tableOrders.OrderDateColumn] = value;
            }
        }
        public virtual bool OrderDateIsNull {
            get {
                return this.IsNull(this.tableOrders.OrderDateColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableOrders.OrderDateColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual System.DateTime RequiredDate {
            get {
                return (System.DateTime)(this[this.tableOrders.RequiredDateColumn]);
            }
            set {
                this[this.tableOrders.RequiredDateColumn] = value;
            }
        }
        public virtual bool RequiredDateIsNull {
            get {
                return this.IsNull(this.tableOrders.RequiredDateColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableOrders.RequiredDateColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual System.DateTime ShippedDate {
            get {
                return (System.DateTime)(this[this.tableOrders.ShippedDateColumn]);
            }
            set {
                this[this.tableOrders.ShippedDateColumn] = value;
            }
        }
        public virtual bool ShippedDateIsNull {
            get {
                return this.IsNull(this.tableOrders.ShippedDateColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableOrders.ShippedDateColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual int ShipVia {
            get {
                return (int)(this[this.tableOrders.ShipViaColumn]);
            }
            set {
                this[this.tableOrders.ShipViaColumn] = value;
            }
        }
        public virtual bool ShipViaIsNull {
            get {
                return this.IsNull(this.tableOrders.ShipViaColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableOrders.ShipViaColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual System.Decimal Freight {
            get {
                return (System.Decimal)(this[this.tableOrders.FreightColumn]);
            }
            set {
                this[this.tableOrders.FreightColumn] = value;
            }
        }
        public virtual bool FreightIsNull {
            get {
                return this.IsNull(this.tableOrders.FreightColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableOrders.FreightColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string ShipName {
            get {
                return (string)(this[this.tableOrders.ShipNameColumn]);
            }
            set {
                this[this.tableOrders.ShipNameColumn] = value;
            }
        }
        public virtual bool ShipNameIsNull {
            get {
                return this.IsNull(this.tableOrders.ShipNameColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableOrders.ShipNameColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string ShipAddress {
            get {
                return (string)(this[this.tableOrders.ShipAddressColumn]);
            }
            set {
                this[this.tableOrders.ShipAddressColumn] = value;
            }
        }
        public virtual bool ShipAddressIsNull {
            get {
                return this.IsNull(this.tableOrders.ShipAddressColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableOrders.ShipAddressColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string ShipCity {
            get {
                return (string)(this[this.tableOrders.ShipCityColumn]);
            }
            set {
                this[this.tableOrders.ShipCityColumn] = value;
            }
        }
        public virtual bool ShipCityIsNull {
            get {
                return this.IsNull(this.tableOrders.ShipCityColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableOrders.ShipCityColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string ShipRegion {
            get {
                return (string)(this[this.tableOrders.ShipRegionColumn]);
            }
            set {
                this[this.tableOrders.ShipRegionColumn] = value;
            }
        }
        public virtual bool ShipRegionIsNull {
            get {
                return this.IsNull(this.tableOrders.ShipRegionColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableOrders.ShipRegionColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string ShipPostalCode {
            get {
                return (string)(this[this.tableOrders.ShipPostalCodeColumn]);
            }
            set {
                this[this.tableOrders.ShipPostalCodeColumn] = value;
            }
        }
        public virtual bool ShipPostalCodeIsNull {
            get {
                return this.IsNull(this.tableOrders.ShipPostalCodeColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableOrders.ShipPostalCodeColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual string ShipCountry {
            get {
                return (string)(this[this.tableOrders.ShipCountryColumn]);
            }
            set {
                this[this.tableOrders.ShipCountryColumn] = value;
            }
        }
        public virtual bool ShipCountryIsNull {
            get {
                return this.IsNull(this.tableOrders.ShipCountryColumn);
            }
            set {
                if (((value) == (true))) {
                    this[this.tableOrders.ShipCountryColumn] = Convert.DBNull;
                }
                else {
                    throw new ArgumentException("Can only set this property to true");
                }
            }
        }
        public virtual CustomersRow CustomersRowByCustomersOrders {
            get {
                return (CustomersRow)(this.GetParentRow(this.Table.ParentRelations["CustomersOrders"]));
            }
            set {
                this.Table.ParentRelations["CustomersOrders"].SetParentRow(this, value);
            }
        }
        
    }
    public class CustomersRowChangeEvent : EventArgs {
        private CustomersRow rowCustomersRow;
        private System.Data.DataRowAction actionValue;
        
        public CustomersRowChangeEvent(CustomersRow rowCustomersRowArg, DataRowAction actionArg) {
            this.rowCustomersRow = rowCustomersRowArg;
            this.actionValue = actionArg;
        }
        
        public virtual CustomersRow CustomersRow {
            get {
                return this.rowCustomersRow;
            }
        }
        public virtual DataRowAction Action {
            get {
                return this.actionValue;
            }
        }
        
    }
    public class OrdersRowChangeEvent : EventArgs {
        private OrdersRow rowOrdersRow;
        private System.Data.DataRowAction actionValue;
        
        public OrdersRowChangeEvent(OrdersRow rowOrdersRowArg, DataRowAction actionArg) {
            this.rowOrdersRow = rowOrdersRowArg;
            this.actionValue = actionArg;
        }
        
        public virtual OrdersRow OrdersRow {
            get {
                return this.rowOrdersRow;
            }
        }
        public virtual DataRowAction Action {
            get {
                return this.actionValue;
            }
        }
        
    }
    public delegate void CustomersRowChangeEventHandler(object sender, CustomersRowChangeEvent e);
    public delegate void OrdersRowChangeEventHandler(object sender, OrdersRowChangeEvent e);
}
