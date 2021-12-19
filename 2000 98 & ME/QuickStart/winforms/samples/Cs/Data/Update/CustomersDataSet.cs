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
namespace Microsoft.Samples.WinForms.Cs.Data.Update.Data {
    using System;
    using System.Data;
    using System.Core;
    
    public class CustomersDataSet : DataSet {
        private int tableCount;
        private int relationCount;
        private Customers tableCustomers;
        
        public CustomersDataSet() {
            this.InitClass();
        }
        
        [System.ComponentModel.PersistContentsAttribute(true)]
        public virtual Customers Customers {
            get {
                return this.tableCustomers;
            }
        }
        
        private void InitClass() {
            this.DataSetName = "CustomersDataSet";
            this.Namespace = "";
            this.tableCount = 1;
            this.relationCount = 0;
            this.tableCustomers = new Customers("Customers");
            this.Tables.Add(this.tableCustomers);
        }
        protected override bool HasSchemaChanged() {
            return ((((this.tableCount) != (this.Tables.Count))) || (((this.relationCount) != (this.Relations.Count))));
        }
        public override bool ShouldPersistTables() {
            return ((this.tableCount) != (this.Tables.Count));
        }
        public override bool ShouldPersistRelations() {
            return ((this.relationCount) != (this.Relations.Count));
        }
        public override void ResetTables() {
            for (int i = 0; ((i) < (this.Tables.Count)); i = ((i) + (1))) {
                if (((this.Tables[i]) == (this.tableCustomers))) {
                }
                else {
                    this.Tables.Remove(this.Tables[i]);
                }
            }
        }
        public override void ResetRelations() {
            for (int i = 0; ((i) < (this.Relations.Count)); i = ((i) + (1))) {
                this.Relations.Remove(this.Relations[i]);
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
    public delegate void CustomersRowChangeEventHandler(object sender, CustomersRowChangeEvent e);
}