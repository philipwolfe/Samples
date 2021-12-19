'------------------------------------------------------------------------------
'/ <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'/    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'/       
'/    This source code is intended only as a supplement to Microsoft
'/    Development Tools and/or on-line documentation.  See these other
'/    materials for detailed information regarding Microsoft code samples.
'/
'/ </copyright>                                                                
'/ 
'/  Typed DataSet for Customers generated using XSD tool
'/  TDGUtil.exe in the QuickStart Utils directory used to generate the XSD
'/ 
'------------------------------------------------------------------------------
Imports System
Imports System.Data
Imports System.Core

Namespace Microsoft.Samples.WinForms.VB.ComboBoxBinding.Data 

    Public Class CustomersDataSet
        Inherits DataSet
        
        Private tableCount As Integer
        Private relationCount As Integer
        Private tableCustomers As Customers
        
        Public Sub New()
            MyBase.New
            Me.InitClass
        End Sub
        
        Public Overridable ReadOnly Property <System.ComponentModel.PersistContentsAttribute(true)> Customers As Customers
            Get
                Return Me.tableCustomers
            End Get
        End Property
        
        Private Sub InitClass()
            Me.DataSetName = "CustomersDataSet"
            Me.Namespace = ""
            Me.tableCount = 1
            Me.relationCount = 0
            Me.tableCustomers = New Customers("Customers")
            Me.Tables.Add(Me.tableCustomers)
        End Sub
        Protected Overrides Function HasSchemaChanged() As Boolean
            Return ((((Me.tableCount) <> (Me.Tables.Count))) Or (((Me.relationCount) <> (Me.Relations.Count))))
        End Function
        Public Overrides Function ShouldPersistTables() As Boolean
            Return ((Me.tableCount) <> (Me.Tables.Count))
        End Function
        Public Overrides Function ShouldPersistRelations() As Boolean
            Return ((Me.relationCount) <> (Me.Relations.Count))
        End Function
        Public Overrides Sub ResetTables()
            Dim i As Integer = 0
            Do While ((i) < (Me.Tables.Count))
                If ((Me.Tables(i)) = (Me.tableCustomers)) Then
                Else
                    Me.Tables.Remove(Me.Tables(i))
                End If
                i = ((i) + (1))
            Loop
        End Sub
        Public Overrides Sub ResetRelations()
            Dim i As Integer = 0
            Do While ((i) < (Me.Relations.Count))
                Me.Relations.Remove(Me.Relations(i))
                i = ((i) + (1))
            Loop
        End Sub
        
    End Class
    Public Class Customers
        Inherits DataTable
        Implements System.Collections.ICollection
        
        Private columnCount As Integer
        Private constraintCount As Integer
        Private columnCustomerID As Customers_CustomerID
        Private columnCompanyName As Customers_CompanyName
        Private columnContactName As Customers_ContactName
        Private columnContactTitle As Customers_ContactTitle
        Private columnAddress As Customers_Address
        Private columnCity As Customers_City
        Private columnRegion As Customers_Region
        Private columnPostalCode As Customers_PostalCode
        Private columnCountry As Customers_Country
        Private columnPhone As Customers_Phone
        Private columnFax As Customers_Fax
        Public CustomersRowChanged As CustomersRowChangeEventHandler
        Public CustomersRowChanging As CustomersRowChangeEventHandler
        Public CustomerIDColumnChanging As DataColumnChangeEventHandler
        Public CompanyNameColumnChanging As DataColumnChangeEventHandler
        Public ContactNameColumnChanging As DataColumnChangeEventHandler
        Public ContactTitleColumnChanging As DataColumnChangeEventHandler
        Public AddressColumnChanging As DataColumnChangeEventHandler
        Public CityColumnChanging As DataColumnChangeEventHandler
        Public RegionColumnChanging As DataColumnChangeEventHandler
        Public PostalCodeColumnChanging As DataColumnChangeEventHandler
        Public CountryColumnChanging As DataColumnChangeEventHandler
        Public PhoneColumnChanging As DataColumnChangeEventHandler
        Public FaxColumnChanging As DataColumnChangeEventHandler
        
        	Public Default ReadOnly Property Item(ByVal index As Integer) As CustomersRow 
    		Get 
    			return CType(Me.Rows(index), CustomersRow)
    		End Get
    	End Property
        Public Overloads Sub New(ByVal name As [string])
            MyBase.New(name)
            Me.InitClass
        End Sub
        Public Overloads Sub New()
            MyBase.New("Customers")
            Me.InitClass
        End Sub
        
        Public Overridable ReadOnly Property Count As Integer Implements System.Collections.ICollection.Count
            Get
                Return Me.Rows.Count
            End Get
        End Property
        Public Overridable ReadOnly Property System_Collections_ICollection_IsReadOnly As Boolean Implements System.Collections.ICollection.IsReadOnly
            Get
                Return false
            End Get
        End Property
        Public Overridable ReadOnly Property System_Collections_ICollection_IsSynchronized As Boolean Implements System.Collections.ICollection.IsSynchronized
            Get
                Return false
            End Get
        End Property
        Public Overridable ReadOnly Property System_Collections_ICollection_SyncRoot As [object] Implements System.Collections.ICollection.SyncRoot
            Get
                Return Me
            End Get
        End Property
        Public Overridable ReadOnly Property CustomerIDColumn As Customers_CustomerID
            Get
                Return Me.columnCustomerID
            End Get
        End Property
        Public Overridable ReadOnly Property CompanyNameColumn As Customers_CompanyName
            Get
                Return Me.columnCompanyName
            End Get
        End Property
        Public Overridable ReadOnly Property ContactNameColumn As Customers_ContactName
            Get
                Return Me.columnContactName
            End Get
        End Property
        Public Overridable ReadOnly Property ContactTitleColumn As Customers_ContactTitle
            Get
                Return Me.columnContactTitle
            End Get
        End Property
        Public Overridable ReadOnly Property AddressColumn As Customers_Address
            Get
                Return Me.columnAddress
            End Get
        End Property
        Public Overridable ReadOnly Property CityColumn As Customers_City
            Get
                Return Me.columnCity
            End Get
        End Property
        Public Overridable ReadOnly Property RegionColumn As Customers_Region
            Get
                Return Me.columnRegion
            End Get
        End Property
        Public Overridable ReadOnly Property PostalCodeColumn As Customers_PostalCode
            Get
                Return Me.columnPostalCode
            End Get
        End Property
        Public Overridable ReadOnly Property CountryColumn As Customers_Country
            Get
                Return Me.columnCountry
            End Get
        End Property
        Public Overridable ReadOnly Property PhoneColumn As Customers_Phone
            Get
                Return Me.columnPhone
            End Get
        End Property
        Public Overridable ReadOnly Property FaxColumn As Customers_Fax
            Get
                Return Me.columnFax
            End Get
        End Property
        
        Public Overloads Overridable Sub AddCustomersRow(ByVal rowCustomersRow As CustomersRow)
            Me.Rows.Add(rowCustomersRow)
        End Sub
        Public Overloads Overridable Function AddCustomersRow(ByVal columnCustomerID As String, ByVal columnCompanyName As String, ByVal columnContactName As String, ByVal columnContactTitle As String, ByVal columnAddress As String, ByVal columnCity As String, ByVal columnRegion As String, ByVal columnPostalCode As String, ByVal columnCountry As String, ByVal columnPhone As String, ByVal columnFax As String) As CustomersRow
            Dim rowCustomersRow As CustomersRow
            rowCustomersRow = CType(Me.NewRow,CustomersRow)
            rowCustomersRow.ItemArray = New [Object]() {columnCustomerID, columnCompanyName, columnContactName, columnContactTitle, columnAddress, columnCity, columnRegion, columnPostalCode, columnCountry, columnPhone, columnFax}
            Me.Rows.Add(rowCustomersRow)
            Return rowCustomersRow
        End Function
        Public Overridable Sub System_Collections_ICollection_CopyTo(ByVal array As Array, ByVal offset As Integer) Implements System.Collections.ICollection.CopyTo
            Dim i As Integer = 0
            Do While ((i) < (Me.Rows.Count))
                array.SetValue(Me.Rows(i), ((i) + (offset)))
                i = ((i) + (1))
            Loop
        End Sub
        Public Overridable Function FindByCustomerID(ByVal columnCustomerID As String) As CustomersRow
            Return CType(Me.Rows.Find(New [Object]() {columnCustomerID}),CustomersRow)
        End Function
        Public Overridable Function System_Collections_IEnumerable_GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.All.GetEnumerator
        End Function
        Protected Overrides Function HasSchemaChanged() As Boolean
            Return ((Me.columnCount) = (Me.Columns.Count))
        End Function
        Private Sub InitClass()
            Me.columnCount = 11
            Me.constraintCount = 1
            Me.columnCustomerID = New Customers_CustomerID
            Me.Columns.Add(Me.columnCustomerID)
            Me.columnCompanyName = New Customers_CompanyName
            Me.Columns.Add(Me.columnCompanyName)
            Me.columnContactName = New Customers_ContactName
            Me.Columns.Add(Me.columnContactName)
            Me.columnContactTitle = New Customers_ContactTitle
            Me.Columns.Add(Me.columnContactTitle)
            Me.columnAddress = New Customers_Address
            Me.Columns.Add(Me.columnAddress)
            Me.columnCity = New Customers_City
            Me.Columns.Add(Me.columnCity)
            Me.columnRegion = New Customers_Region
            Me.Columns.Add(Me.columnRegion)
            Me.columnPostalCode = New Customers_PostalCode
            Me.Columns.Add(Me.columnPostalCode)
            Me.columnCountry = New Customers_Country
            Me.Columns.Add(Me.columnCountry)
            Me.columnPhone = New Customers_Phone
            Me.Columns.Add(Me.columnPhone)
            Me.columnFax = New Customers_Fax
            Me.Columns.Add(Me.columnFax)
            Me.PrimaryKey = New System.Data.DataColumn() {Me.columnCustomerID}
        End Sub
        Public Overridable Function NewCustomersRow() As CustomersRow
            Return CType(Me.NewRow,CustomersRow)
        End Function
        Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
            'We need to ensure that all Rows in the tabled are typed rows.
            'Table calls newRow whenever it needs to create a row.
            'So the following conditions are covered by Row newRow(Record record)
            '* Cursor calls table.addRecord(record) 
            '* table.addRow(object[] values) calls newRow(record)    
            Return New CustomersRow(builder)
        End Function
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(CustomersRow)
        End Function
        Protected Overrides Sub OnRemoveColumn(ByVal column As DataColumn)
            If ((((((((((((((((((((((column) = (Me.columnCustomerID))) Or (((column) = (Me.columnCompanyName))))) Or (((column) = (Me.columnContactName))))) Or (((column) = (Me.columnContactTitle))))) Or (((column) = (Me.columnAddress))))) Or (((column) = (Me.columnCity))))) Or (((column) = (Me.columnRegion))))) Or (((column) = (Me.columnPostalCode))))) Or (((column) = (Me.columnCountry))))) Or (((column) = (Me.columnPhone))))) Or (((column) = (Me.columnFax)))) Then
                Throw New ArgumentException("Can't remove column since it it built in to this dataSet")
            End If
        End Sub
        Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.CustomersRowChanged) Is Nothing) Then
                Me.CustomersRowChanged.Invoke(Me, New CustomersRowChangeEvent(CType(e.Row,CustomersRow), e.Action))
            End If
        End Sub
        Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
            If (Not (Me.CustomersRowChanging) Is Nothing) Then
                Me.CustomersRowChanging.Invoke(Me, New CustomersRowChangeEvent(CType(e.Row,CustomersRow), e.Action))
            End If
        End Sub
        Protected Overridable Sub OnCustomerIDColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.CustomerIDColumnChanging) Is Nothing) Then
                Me.CustomerIDColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnCompanyNameColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.CompanyNameColumnChanging) Is Nothing) Then
                Me.CompanyNameColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnContactNameColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.ContactNameColumnChanging) Is Nothing) Then
                Me.ContactNameColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnContactTitleColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.ContactTitleColumnChanging) Is Nothing) Then
                Me.ContactTitleColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnAddressColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.AddressColumnChanging) Is Nothing) Then
                Me.AddressColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnCityColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.CityColumnChanging) Is Nothing) Then
                Me.CityColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnRegionColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.RegionColumnChanging) Is Nothing) Then
                Me.RegionColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnPostalCodeColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.PostalCodeColumnChanging) Is Nothing) Then
                Me.PostalCodeColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnCountryColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.CountryColumnChanging) Is Nothing) Then
                Me.CountryColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnPhoneColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.PhoneColumnChanging) Is Nothing) Then
                Me.PhoneColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnFaxColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.FaxColumnChanging) Is Nothing) Then
                Me.FaxColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overrides Sub OnColumnChanging(ByVal e As DataColumnChangeEventArgs)
            MyBase.OnColumnChanging(e)
            If ((e.Column) = (Me.columnCustomerID)) Then
                Me.OnCustomerIDColumnChanging(e)
            Else
                If ((e.Column) = (Me.columnCompanyName)) Then
                    Me.OnCompanyNameColumnChanging(e)
                Else
                    If ((e.Column) = (Me.columnContactName)) Then
                        Me.OnContactNameColumnChanging(e)
                    Else
                        If ((e.Column) = (Me.columnContactTitle)) Then
                            Me.OnContactTitleColumnChanging(e)
                        Else
                            If ((e.Column) = (Me.columnAddress)) Then
                                Me.OnAddressColumnChanging(e)
                            Else
                                If ((e.Column) = (Me.columnCity)) Then
                                    Me.OnCityColumnChanging(e)
                                Else
                                    If ((e.Column) = (Me.columnRegion)) Then
                                        Me.OnRegionColumnChanging(e)
                                    Else
                                        If ((e.Column) = (Me.columnPostalCode)) Then
                                            Me.OnPostalCodeColumnChanging(e)
                                        Else
                                            If ((e.Column) = (Me.columnCountry)) Then
                                                Me.OnCountryColumnChanging(e)
                                            Else
                                                If ((e.Column) = (Me.columnPhone)) Then
                                                    Me.OnPhoneColumnChanging(e)
                                                Else
                                                    If ((e.Column) = (Me.columnFax)) Then
                                                        Me.OnFaxColumnChanging(e)
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End Sub
        Public Overridable Sub RemoveCustomersRow(ByVal rowCustomersRow As CustomersRow)
            Me.Rows.Remove(rowCustomersRow)
        End Sub
        Public Overrides Function ShouldPersistPrimaryKey() As Boolean
            Return false
        End Function
        Public Overrides Sub ResetPrimaryKey()
        End Sub
        Public Overrides Function ShouldPersistColumns() As Boolean
            Return ((Me.columnCount) <> (Me.Columns.Count))
        End Function
        Public Overrides Sub ResetColumns()
            Dim i As Integer = 0
            Do While ((i) < (Me.Columns.Count))
                If ((((Me.Columns(i)) = (Me.columnFax))) Or (((((Me.Columns(i)) = (Me.columnPhone))) Or (((((Me.Columns(i)) = (Me.columnCountry))) Or (((((Me.Columns(i)) = (Me.columnPostalCode))) Or (((((Me.Columns(i)) = (Me.columnRegion))) Or (((((Me.Columns(i)) = (Me.columnCity))) Or (((((Me.Columns(i)) = (Me.columnAddress))) Or (((((Me.Columns(i)) = (Me.columnContactTitle))) Or (((((Me.Columns(i)) = (Me.columnContactName))) Or (((((Me.Columns(i)) = (Me.columnCompanyName))) Or (((Me.Columns(i)) = (Me.columnCustomerID)))))))))))))))))))))) Then
                Else
                    Me.Columns.Remove(Me.Columns(i))
                End If
                i = ((i) + (1))
            Loop
        End Sub
        Public Overrides Function ShouldPersistConstraints() As Boolean
            Return ((Me.constraintCount) <> (Me.Constraints.Count))
        End Function
        Public Overrides Sub ResetConstraints()
            Dim i As Integer = Me.constraintCount
            Do While ((i) < (Me.Constraints.Count))
                Me.Constraints.Remove(Me.Constraints(i))
                i = ((i) + (1))
            Loop
        End Sub
        
    End Class
    Public Class Customers_CustomerID
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("CustomerID", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
            Me.AllowNull = false
            Me.Unique = true
        End Sub
        
    End Class
    Public Class Customers_CompanyName
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("CompanyName", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
            Me.AllowNull = false
        End Sub
        
    End Class
    Public Class Customers_ContactName
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("ContactName", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Customers_ContactTitle
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("ContactTitle", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Customers_Address
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("Address", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Customers_City
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("City", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Customers_Region
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("Region", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Customers_PostalCode
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("PostalCode", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Customers_Country
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("Country", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Customers_Phone
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("Phone", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Customers_Fax
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("Fax", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class CustomersRow
        Inherits DataRow
        
        Private tableCustomers As Customers
        
        Public Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.tableCustomers = CType(Me.Table,Customers)
        End Sub
        
        Public Overridable Property CustomerID As String
            Get
                Return CType(Me(Me.tableCustomers.CustomerIDColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.CustomerIDColumn) = value
            End Set
        End Property
        Public Overridable Property CompanyName As String
            Get
                Return CType(Me(Me.tableCustomers.CompanyNameColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.CompanyNameColumn) = value
            End Set
        End Property
        Public Overridable Property ContactName As String
            Get
                Return CType(Me(Me.tableCustomers.ContactNameColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.ContactNameColumn) = value
            End Set
        End Property
        Public Overridable Property ContactNameIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableCustomers.ContactNameColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableCustomers.ContactNameColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property ContactTitle As String
            Get
                Return CType(Me(Me.tableCustomers.ContactTitleColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.ContactTitleColumn) = value
            End Set
        End Property
        Public Overridable Property ContactTitleIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableCustomers.ContactTitleColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableCustomers.ContactTitleColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property Address As String
            Get
                Return CType(Me(Me.tableCustomers.AddressColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.AddressColumn) = value
            End Set
        End Property
        Public Overridable Property AddressIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableCustomers.AddressColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableCustomers.AddressColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property City As String
            Get
                Return CType(Me(Me.tableCustomers.CityColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.CityColumn) = value
            End Set
        End Property
        Public Overridable Property CityIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableCustomers.CityColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableCustomers.CityColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property _Region As String
            Get
                Return CType(Me(Me.tableCustomers.RegionColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.RegionColumn) = value
            End Set
        End Property
        Public Overridable Property RegionIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableCustomers.RegionColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableCustomers.RegionColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property PostalCode As String
            Get
                Return CType(Me(Me.tableCustomers.PostalCodeColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.PostalCodeColumn) = value
            End Set
        End Property
        Public Overridable Property PostalCodeIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableCustomers.PostalCodeColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableCustomers.PostalCodeColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property Country As String
            Get
                Return CType(Me(Me.tableCustomers.CountryColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.CountryColumn) = value
            End Set
        End Property
        Public Overridable Property CountryIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableCustomers.CountryColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableCustomers.CountryColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property Phone As String
            Get
                Return CType(Me(Me.tableCustomers.PhoneColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.PhoneColumn) = value
            End Set
        End Property
        Public Overridable Property PhoneIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableCustomers.PhoneColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableCustomers.PhoneColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property Fax As String
            Get
                Return CType(Me(Me.tableCustomers.FaxColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.FaxColumn) = value
            End Set
        End Property
        Public Overridable Property FaxIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableCustomers.FaxColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableCustomers.FaxColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        
    End Class
    Public Class CustomersRowChangeEvent
        Inherits EventArgs
        
        Private rowCustomersRow As CustomersRow
        Private actionValue As System.Data.DataRowAction
        
        Public Sub New(ByVal rowCustomersRowArg As CustomersRow, ByVal actionArg As DataRowAction)
            MyBase.New
            Me.rowCustomersRow = rowCustomersRowArg
            Me.actionValue = actionArg
        End Sub
        
        Public Overridable ReadOnly Property CustomersRow As CustomersRow
            Get
                Return Me.rowCustomersRow
            End Get
        End Property
        Public Overridable ReadOnly Property Action As DataRowAction
            Get
                Return Me.actionValue
            End Get
        End Property
        
    End Class
    Public Delegate Sub CustomersRowChangeEventHandler(ByVal sender As [object], ByVal e As CustomersRowChangeEvent)

End NameSpace
