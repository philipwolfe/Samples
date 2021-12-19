' ------------------------------------------------------------------------------
' / <copyright from='1997' to='2001' company='Microsoft Corporation'>           
' /    Copyright (c) Microsoft Corporation. All Rights Reserved.                
' /       
' /    This source code is intended only as a supplement to Microsoft
' /    Development Tools and/or on-line documentation.  See these other
' /    materials for detailed information regarding Microsoft code samples.
' /
' / </copyright>                                                                
' /  Typed DataSet for Customers generated using XSD tool
' /  TDGUtil.exe in the QuickStart Utils directory used to generate the XSD
' / 
' ------------------------------------------------------------------------------
Imports System
Imports System.Data
Imports System.Core

Namespace Microsoft.Samples.WinForms.VB.MasterDetails.Data 

    Public Class CustomersAndOrdersDataSet
        Inherits DataSet
        
        Private tableCount As Integer
        Private relationCount As Integer
        Private tableCustomers As Customers
        Private tableOrders As Orders
        Private relationCustomersOrders As DataRelation
        
        Public Sub New()
            MyBase.New
            Me.InitClass
        End Sub
        
        Public Overridable ReadOnly Property <System.ComponentModel.PersistContentsAttribute(true)> Customers As Customers
            Get
                Return Me.tableCustomers
            End Get
        End Property
        Public Overridable ReadOnly Property <System.ComponentModel.PersistContentsAttribute(true)> Orders As Orders
            Get
                Return Me.tableOrders
            End Get
        End Property
        
        Private Sub InitClass()
            Me.DataSetName = "CustomersAndOrdersDataSet"
            Me.Namespace = ""
            Me.tableCount = 2
            Me.relationCount = 1
            Me.tableCustomers = New Customers("Customers")
            Me.Tables.Add(Me.tableCustomers)
            Me.tableOrders = New Orders("Orders")
            Me.Tables.Add(Me.tableOrders)
            Me.Orders.Constraints.Add(New System.Data.ForeignKeyConstraint("CustomersOrders", New System.Data.DataColumn() {Me.tableCustomers.CustomerIDColumn}, New System.Data.DataColumn() {Me.tableOrders.CustomerIDColumn}))
            Me.relationCustomersOrders = New DataRelation("CustomersOrders", New System.Data.DataColumn() {Me.tableCustomers.CustomerIDColumn}, New System.Data.DataColumn() {Me.tableOrders.CustomerIDColumn}, false)
            Me.Relations.Add(Me.relationCustomersOrders)
        End Sub
        Protected Overrides Function HasSchemaChanged() As Boolean
            Return ((((Me.tableCount) <> (Me.Tables.Count))) Or (((Me.relationCount) <> (Me.Relations.Count))))
        End Function
        Protected Overrides Sub OnRemoveRelation(ByVal relation As DataRelation)
            If ((relation) = (Me.relationCustomersOrders)) Then
                Throw New ArgumentException("Can't remove relation since it it built in to this dataSet")
            End If
        End Sub
        Public Overrides Function ShouldPersistTables() As Boolean
            Return ((Me.tableCount) <> (Me.Tables.Count))
        End Function
        Public Overrides Function ShouldPersistRelations() As Boolean
            Return ((Me.relationCount) <> (Me.Relations.Count))
        End Function
        Public Overrides Sub ResetTables()
            Dim i As Integer = 0
            Do While ((i) < (Me.Tables.Count))
                If ((((Me.Tables(i)) = (Me.tableOrders))) Or (((Me.Tables(i)) = (Me.tableCustomers)))) Then
                Else
                    Me.Tables.Remove(Me.Tables(i))
                End If
                i = ((i) + (1))
            Loop
        End Sub
        Public Overrides Sub ResetRelations()
            Dim i As Integer = 0
            Do While ((i) < (Me.Relations.Count))
                If ((Me.Relations(i)) = (Me.relationCustomersOrders)) Then
                Else
                    Me.Relations.Remove(Me.Relations(i))
                End If
                i = ((i) + (1))
            Loop
        End Sub
        Protected Overrides Sub OnRemoveTable(ByVal table As DataTable)
            If ((((table) = (Me.tableOrders))) Or (((table) = (Me.tableCustomers)))) Then
                Throw New ArgumentException("Can't remove relation since it it built in to this dataSet")
            End If
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
    Public Class Orders
        Inherits DataTable
        Implements System.Collections.ICollection
        
        Private columnCount As Integer
        Private constraintCount As Integer
        Private columnOrderID As Orders_OrderID
        Private columnCustomerID As Orders_CustomerID
        Private columnEmployeeID As Orders_EmployeeID
        Private columnOrderDate As Orders_OrderDate
        Private columnRequiredDate As Orders_RequiredDate
        Private columnShippedDate As Orders_ShippedDate
        Private columnShipVia As Orders_ShipVia
        Private columnFreight As Orders_Freight
        Private columnShipName As Orders_ShipName
        Private columnShipAddress As Orders_ShipAddress
        Private columnShipCity As Orders_ShipCity
        Private columnShipRegion As Orders_ShipRegion
        Private columnShipPostalCode As Orders_ShipPostalCode
        Private columnShipCountry As Orders_ShipCountry
        Public OrdersRowChanged As OrdersRowChangeEventHandler
        Public OrdersRowChanging As OrdersRowChangeEventHandler
        Public OrderIDColumnChanging As DataColumnChangeEventHandler
        Public CustomerIDColumnChanging As DataColumnChangeEventHandler
        Public EmployeeIDColumnChanging As DataColumnChangeEventHandler
        Public OrderDateColumnChanging As DataColumnChangeEventHandler
        Public RequiredDateColumnChanging As DataColumnChangeEventHandler
        Public ShippedDateColumnChanging As DataColumnChangeEventHandler
        Public ShipViaColumnChanging As DataColumnChangeEventHandler
        Public FreightColumnChanging As DataColumnChangeEventHandler
        Public ShipNameColumnChanging As DataColumnChangeEventHandler
        Public ShipAddressColumnChanging As DataColumnChangeEventHandler
        Public ShipCityColumnChanging As DataColumnChangeEventHandler
        Public ShipRegionColumnChanging As DataColumnChangeEventHandler
        Public ShipPostalCodeColumnChanging As DataColumnChangeEventHandler
        Public ShipCountryColumnChanging As DataColumnChangeEventHandler
        
        	Public Default ReadOnly Property Item(ByVal index As Integer) As OrdersRow 
    		Get 
    			return CType(Me.Rows(index), OrdersRow)
    		End Get
    	End Property
        Public Overloads Sub New(ByVal name As [string])
            MyBase.New(name)
            Me.InitClass
        End Sub
        Public Overloads Sub New()
            MyBase.New("Orders")
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
        Public Overridable ReadOnly Property OrderIDColumn As Orders_OrderID
            Get
                Return Me.columnOrderID
            End Get
        End Property
        Public Overridable ReadOnly Property CustomerIDColumn As Orders_CustomerID
            Get
                Return Me.columnCustomerID
            End Get
        End Property
        Public Overridable ReadOnly Property EmployeeIDColumn As Orders_EmployeeID
            Get
                Return Me.columnEmployeeID
            End Get
        End Property
        Public Overridable ReadOnly Property OrderDateColumn As Orders_OrderDate
            Get
                Return Me.columnOrderDate
            End Get
        End Property
        Public Overridable ReadOnly Property RequiredDateColumn As Orders_RequiredDate
            Get
                Return Me.columnRequiredDate
            End Get
        End Property
        Public Overridable ReadOnly Property ShippedDateColumn As Orders_ShippedDate
            Get
                Return Me.columnShippedDate
            End Get
        End Property
        Public Overridable ReadOnly Property ShipViaColumn As Orders_ShipVia
            Get
                Return Me.columnShipVia
            End Get
        End Property
        Public Overridable ReadOnly Property FreightColumn As Orders_Freight
            Get
                Return Me.columnFreight
            End Get
        End Property
        Public Overridable ReadOnly Property ShipNameColumn As Orders_ShipName
            Get
                Return Me.columnShipName
            End Get
        End Property
        Public Overridable ReadOnly Property ShipAddressColumn As Orders_ShipAddress
            Get
                Return Me.columnShipAddress
            End Get
        End Property
        Public Overridable ReadOnly Property ShipCityColumn As Orders_ShipCity
            Get
                Return Me.columnShipCity
            End Get
        End Property
        Public Overridable ReadOnly Property ShipRegionColumn As Orders_ShipRegion
            Get
                Return Me.columnShipRegion
            End Get
        End Property
        Public Overridable ReadOnly Property ShipPostalCodeColumn As Orders_ShipPostalCode
            Get
                Return Me.columnShipPostalCode
            End Get
        End Property
        Public Overridable ReadOnly Property ShipCountryColumn As Orders_ShipCountry
            Get
                Return Me.columnShipCountry
            End Get
        End Property
        
        Public Overloads Overridable Sub AddOrdersRow(ByVal rowOrdersRow As OrdersRow)
            Me.Rows.Add(rowOrdersRow)
        End Sub
        Public Overloads Overridable Function AddOrdersRow(ByVal parentCustomersRowByCustomersOrders As CustomersRow, ByVal columnEmployeeID As Integer, ByVal columnOrderDate As Date, ByVal columnRequiredDate As Date, ByVal columnShippedDate As Date, ByVal columnShipVia As Integer, ByVal columnFreight As Decimal, ByVal columnShipName As String, ByVal columnShipAddress As String, ByVal columnShipCity As String, ByVal columnShipRegion As String, ByVal columnShipPostalCode As String, ByVal columnShipCountry As String) As OrdersRow
            Dim rowOrdersRow As OrdersRow
            rowOrdersRow = CType(Me.NewRow,OrdersRow)
            rowOrdersRow.ItemArray = New [Object]() {Nothing, parentCustomersRowByCustomersOrders.CustomerID, columnEmployeeID, columnOrderDate, columnRequiredDate, columnShippedDate, columnShipVia, columnFreight, columnShipName, columnShipAddress, columnShipCity, columnShipRegion, columnShipPostalCode, columnShipCountry}
            Me.Rows.Add(rowOrdersRow)
            Return rowOrdersRow
        End Function
        Public Overridable Sub System_Collections_ICollection_CopyTo(ByVal array As Array, ByVal offset As Integer) Implements System.Collections.ICollection.CopyTo
            Dim i As Integer = 0
            Do While ((i) < (Me.Rows.Count))
                array.SetValue(Me.Rows(i), ((i) + (offset)))
                i = ((i) + (1))
            Loop
        End Sub
        Public Overridable Function FindByOrderID(ByVal columnOrderID As Integer) As OrdersRow
            Return CType(Me.Rows.Find(New [Object]() {columnOrderID}),OrdersRow)
        End Function
        Public Overridable Function System_Collections_IEnumerable_GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.All.GetEnumerator
        End Function
        Protected Overrides Function HasSchemaChanged() As Boolean
            Return ((Me.columnCount) = (Me.Columns.Count))
        End Function
        Private Sub InitClass()
            Me.columnCount = 14
            Me.constraintCount = 2
            Me.columnOrderID = New Orders_OrderID
            Me.Columns.Add(Me.columnOrderID)
            Me.columnCustomerID = New Orders_CustomerID
            Me.Columns.Add(Me.columnCustomerID)
            Me.columnEmployeeID = New Orders_EmployeeID
            Me.Columns.Add(Me.columnEmployeeID)
            Me.columnOrderDate = New Orders_OrderDate
            Me.Columns.Add(Me.columnOrderDate)
            Me.columnRequiredDate = New Orders_RequiredDate
            Me.Columns.Add(Me.columnRequiredDate)
            Me.columnShippedDate = New Orders_ShippedDate
            Me.Columns.Add(Me.columnShippedDate)
            Me.columnShipVia = New Orders_ShipVia
            Me.Columns.Add(Me.columnShipVia)
            Me.columnFreight = New Orders_Freight
            Me.Columns.Add(Me.columnFreight)
            Me.columnShipName = New Orders_ShipName
            Me.Columns.Add(Me.columnShipName)
            Me.columnShipAddress = New Orders_ShipAddress
            Me.Columns.Add(Me.columnShipAddress)
            Me.columnShipCity = New Orders_ShipCity
            Me.Columns.Add(Me.columnShipCity)
            Me.columnShipRegion = New Orders_ShipRegion
            Me.Columns.Add(Me.columnShipRegion)
            Me.columnShipPostalCode = New Orders_ShipPostalCode
            Me.Columns.Add(Me.columnShipPostalCode)
            Me.columnShipCountry = New Orders_ShipCountry
            Me.Columns.Add(Me.columnShipCountry)
            Me.PrimaryKey = New System.Data.DataColumn() {Me.columnOrderID}
        End Sub
        Public Overridable Function NewOrdersRow() As OrdersRow
            Return CType(Me.NewRow,OrdersRow)
        End Function
        Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
            'We need to ensure that all Rows in the tabled are typed rows.
            'Table calls newRow whenever it needs to create a row.
            'So the following conditions are covered by Row newRow(Record record)
            '* Cursor calls table.addRecord(record) 
            '* table.addRow(object[] values) calls newRow(record)    
            Return New OrdersRow(builder)
        End Function
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(OrdersRow)
        End Function
        Protected Overrides Sub OnRemoveColumn(ByVal column As DataColumn)
            If ((((((((((((((((((((((((((((column) = (Me.columnOrderID))) Or (((column) = (Me.columnCustomerID))))) Or (((column) = (Me.columnEmployeeID))))) Or (((column) = (Me.columnOrderDate))))) Or (((column) = (Me.columnRequiredDate))))) Or (((column) = (Me.columnShippedDate))))) Or (((column) = (Me.columnShipVia))))) Or (((column) = (Me.columnFreight))))) Or (((column) = (Me.columnShipName))))) Or (((column) = (Me.columnShipAddress))))) Or (((column) = (Me.columnShipCity))))) Or (((column) = (Me.columnShipRegion))))) Or (((column) = (Me.columnShipPostalCode))))) Or (((column) = (Me.columnShipCountry)))) Then
                Throw New ArgumentException("Can't remove column since it it built in to this dataSet")
            End If
        End Sub
        Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.OrdersRowChanged) Is Nothing) Then
                Me.OrdersRowChanged.Invoke(Me, New OrdersRowChangeEvent(CType(e.Row,OrdersRow), e.Action))
            End If
        End Sub
        Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
            If (Not (Me.OrdersRowChanging) Is Nothing) Then
                Me.OrdersRowChanging.Invoke(Me, New OrdersRowChangeEvent(CType(e.Row,OrdersRow), e.Action))
            End If
        End Sub
        Protected Overridable Sub OnOrderIDColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.OrderIDColumnChanging) Is Nothing) Then
                Me.OrderIDColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnCustomerIDColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.CustomerIDColumnChanging) Is Nothing) Then
                Me.CustomerIDColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnEmployeeIDColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.EmployeeIDColumnChanging) Is Nothing) Then
                Me.EmployeeIDColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnOrderDateColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.OrderDateColumnChanging) Is Nothing) Then
                Me.OrderDateColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnRequiredDateColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.RequiredDateColumnChanging) Is Nothing) Then
                Me.RequiredDateColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnShippedDateColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.ShippedDateColumnChanging) Is Nothing) Then
                Me.ShippedDateColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnShipViaColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.ShipViaColumnChanging) Is Nothing) Then
                Me.ShipViaColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnFreightColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.FreightColumnChanging) Is Nothing) Then
                Me.FreightColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnShipNameColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.ShipNameColumnChanging) Is Nothing) Then
                Me.ShipNameColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnShipAddressColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.ShipAddressColumnChanging) Is Nothing) Then
                Me.ShipAddressColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnShipCityColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.ShipCityColumnChanging) Is Nothing) Then
                Me.ShipCityColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnShipRegionColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.ShipRegionColumnChanging) Is Nothing) Then
                Me.ShipRegionColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnShipPostalCodeColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.ShipPostalCodeColumnChanging) Is Nothing) Then
                Me.ShipPostalCodeColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overridable Sub OnShipCountryColumnChanging(ByVal e As DataColumnChangeEventArgs)
            If (Not (Me.ShipCountryColumnChanging) Is Nothing) Then
                Me.ShipCountryColumnChanging.Invoke(Me, e)
            End If
        End Sub
        Protected Overrides Sub OnColumnChanging(ByVal e As DataColumnChangeEventArgs)
            MyBase.OnColumnChanging(e)
            If ((e.Column) = (Me.columnOrderID)) Then
                Me.OnOrderIDColumnChanging(e)
            Else
                If ((e.Column) = (Me.columnCustomerID)) Then
                    Me.OnCustomerIDColumnChanging(e)
                Else
                    If ((e.Column) = (Me.columnEmployeeID)) Then
                        Me.OnEmployeeIDColumnChanging(e)
                    Else
                        If ((e.Column) = (Me.columnOrderDate)) Then
                            Me.OnOrderDateColumnChanging(e)
                        Else
                            If ((e.Column) = (Me.columnRequiredDate)) Then
                                Me.OnRequiredDateColumnChanging(e)
                            Else
                                If ((e.Column) = (Me.columnShippedDate)) Then
                                    Me.OnShippedDateColumnChanging(e)
                                Else
                                    If ((e.Column) = (Me.columnShipVia)) Then
                                        Me.OnShipViaColumnChanging(e)
                                    Else
                                        If ((e.Column) = (Me.columnFreight)) Then
                                            Me.OnFreightColumnChanging(e)
                                        Else
                                            If ((e.Column) = (Me.columnShipName)) Then
                                                Me.OnShipNameColumnChanging(e)
                                            Else
                                                If ((e.Column) = (Me.columnShipAddress)) Then
                                                    Me.OnShipAddressColumnChanging(e)
                                                Else
                                                    If ((e.Column) = (Me.columnShipCity)) Then
                                                        Me.OnShipCityColumnChanging(e)
                                                    Else
                                                        If ((e.Column) = (Me.columnShipRegion)) Then
                                                            Me.OnShipRegionColumnChanging(e)
                                                        Else
                                                            If ((e.Column) = (Me.columnShipPostalCode)) Then
                                                                Me.OnShipPostalCodeColumnChanging(e)
                                                            Else
                                                                If ((e.Column) = (Me.columnShipCountry)) Then
                                                                    Me.OnShipCountryColumnChanging(e)
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
                    End If
                End If
            End If
        End Sub
        Public Overridable Sub RemoveOrdersRow(ByVal rowOrdersRow As OrdersRow)
            Me.Rows.Remove(rowOrdersRow)
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
                If ((((Me.Columns(i)) = (Me.columnShipCountry))) Or (((((Me.Columns(i)) = (Me.columnShipPostalCode))) Or (((((Me.Columns(i)) = (Me.columnShipRegion))) Or (((((Me.Columns(i)) = (Me.columnShipCity))) Or (((((Me.Columns(i)) = (Me.columnShipAddress))) Or (((((Me.Columns(i)) = (Me.columnShipName))) Or (((((Me.Columns(i)) = (Me.columnFreight))) Or (((((Me.Columns(i)) = (Me.columnShipVia))) Or (((((Me.Columns(i)) = (Me.columnShippedDate))) Or (((((Me.Columns(i)) = (Me.columnRequiredDate))) Or (((((Me.Columns(i)) = (Me.columnOrderDate))) Or (((((Me.Columns(i)) = (Me.columnEmployeeID))) Or (((((Me.Columns(i)) = (Me.columnCustomerID))) Or (((Me.Columns(i)) = (Me.columnOrderID)))))))))))))))))))))))))))) Then
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
    Public Class Orders_OrderID
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("OrderID", GetType(System.Int32))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
            Me.AutoIncrement = true
            Me.AllowNull = false
            Me.Unique = true
        End Sub
        
    End Class
    Public Class Orders_CustomerID
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("CustomerID", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Orders_EmployeeID
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("EmployeeID", GetType(System.Int32))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Orders_OrderDate
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("OrderDate", GetType(System.DateTime))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Orders_RequiredDate
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("RequiredDate", GetType(System.DateTime))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Orders_ShippedDate
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("ShippedDate", GetType(System.DateTime))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Orders_ShipVia
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("ShipVia", GetType(System.Int32))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Orders_Freight
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("Freight", GetType(System.Decimal))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Orders_ShipName
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("ShipName", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Orders_ShipAddress
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("ShipAddress", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Orders_ShipCity
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("ShipCity", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Orders_ShipRegion
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("ShipRegion", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Orders_ShipPostalCode
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("ShipPostalCode", GetType(System.String))
            Me.InitClass
        End Sub
        
        Public Overridable Sub InitClass()
        End Sub
        
    End Class
    Public Class Orders_ShipCountry
        Inherits System.Data.DataColumn
        
        Public Sub New()
            MyBase.New("ShipCountry", GetType(System.String))
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
        Public Overridable ReadOnly Property OrdersByCustomersOrders As OrdersRow()
            Get
                Return CType(Me.GetChildRows(Me.Table.ChildRelations("CustomersOrders")),OrdersRow())
            End Get
        End Property
        
    End Class
    Public Class OrdersRow
        Inherits DataRow
        
        Private tableOrders As Orders
        
        Public Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.tableOrders = CType(Me.Table,Orders)
        End Sub
        
        Public Overridable Property OrderID As Integer
            Get
                Return CType(Me(Me.tableOrders.OrderIDColumn),Integer)
            End Get
            Set
                Me(Me.tableOrders.OrderIDColumn) = value
            End Set
        End Property
        Public Overridable Property CustomerID As String
            Get
                Return CType(Me(Me.tableOrders.CustomerIDColumn),String)
            End Get
            Set
                Me(Me.tableOrders.CustomerIDColumn) = value
            End Set
        End Property
        Public Overridable Property CustomerIDIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableOrders.CustomerIDColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableOrders.CustomerIDColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property EmployeeID As Integer
            Get
                Return CType(Me(Me.tableOrders.EmployeeIDColumn),Integer)
            End Get
            Set
                Me(Me.tableOrders.EmployeeIDColumn) = value
            End Set
        End Property
        Public Overridable Property EmployeeIDIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableOrders.EmployeeIDColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableOrders.EmployeeIDColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property OrderDate As Date
            Get
                Return CType(Me(Me.tableOrders.OrderDateColumn),Date)
            End Get
            Set
                Me(Me.tableOrders.OrderDateColumn) = value
            End Set
        End Property
        Public Overridable Property OrderDateIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableOrders.OrderDateColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableOrders.OrderDateColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property RequiredDate As Date
            Get
                Return CType(Me(Me.tableOrders.RequiredDateColumn),Date)
            End Get
            Set
                Me(Me.tableOrders.RequiredDateColumn) = value
            End Set
        End Property
        Public Overridable Property RequiredDateIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableOrders.RequiredDateColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableOrders.RequiredDateColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property ShippedDate As Date
            Get
                Return CType(Me(Me.tableOrders.ShippedDateColumn),Date)
            End Get
            Set
                Me(Me.tableOrders.ShippedDateColumn) = value
            End Set
        End Property
        Public Overridable Property ShippedDateIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableOrders.ShippedDateColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableOrders.ShippedDateColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property ShipVia As Integer
            Get
                Return CType(Me(Me.tableOrders.ShipViaColumn),Integer)
            End Get
            Set
                Me(Me.tableOrders.ShipViaColumn) = value
            End Set
        End Property
        Public Overridable Property ShipViaIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableOrders.ShipViaColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableOrders.ShipViaColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property Freight As Decimal
            Get
                Return CType(Me(Me.tableOrders.FreightColumn),Decimal)
            End Get
            Set
                Me(Me.tableOrders.FreightColumn) = value
            End Set
        End Property
        Public Overridable Property FreightIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableOrders.FreightColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableOrders.FreightColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property ShipName As String
            Get
                Return CType(Me(Me.tableOrders.ShipNameColumn),String)
            End Get
            Set
                Me(Me.tableOrders.ShipNameColumn) = value
            End Set
        End Property
        Public Overridable Property ShipNameIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableOrders.ShipNameColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableOrders.ShipNameColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property ShipAddress As String
            Get
                Return CType(Me(Me.tableOrders.ShipAddressColumn),String)
            End Get
            Set
                Me(Me.tableOrders.ShipAddressColumn) = value
            End Set
        End Property
        Public Overridable Property ShipAddressIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableOrders.ShipAddressColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableOrders.ShipAddressColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property ShipCity As String
            Get
                Return CType(Me(Me.tableOrders.ShipCityColumn),String)
            End Get
            Set
                Me(Me.tableOrders.ShipCityColumn) = value
            End Set
        End Property
        Public Overridable Property ShipCityIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableOrders.ShipCityColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableOrders.ShipCityColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property ShipRegion As String
            Get
                Return CType(Me(Me.tableOrders.ShipRegionColumn),String)
            End Get
            Set
                Me(Me.tableOrders.ShipRegionColumn) = value
            End Set
        End Property
        Public Overridable Property ShipRegionIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableOrders.ShipRegionColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableOrders.ShipRegionColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property ShipPostalCode As String
            Get
                Return CType(Me(Me.tableOrders.ShipPostalCodeColumn),String)
            End Get
            Set
                Me(Me.tableOrders.ShipPostalCodeColumn) = value
            End Set
        End Property
        Public Overridable Property ShipPostalCodeIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableOrders.ShipPostalCodeColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableOrders.ShipPostalCodeColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property ShipCountry As String
            Get
                Return CType(Me(Me.tableOrders.ShipCountryColumn),String)
            End Get
            Set
                Me(Me.tableOrders.ShipCountryColumn) = value
            End Set
        End Property
        Public Overridable Property ShipCountryIsNull As Boolean
            Get
                Return Me.IsNull(Me.tableOrders.ShipCountryColumn)
            End Get
            Set
                If ((value) = (true)) Then
                    Me(Me.tableOrders.ShipCountryColumn) = [Convert].DBNull
                Else
                    Throw New ArgumentException("Can only set this property to true")
                End If
            End Set
        End Property
        Public Overridable Property CustomersRowByCustomersOrders As CustomersRow
            Get
                Return CType(Me.GetParentRow(Me.Table.ParentRelations("CustomersOrders")),CustomersRow)
            End Get
            Set
                Me.Table.ParentRelations("CustomersOrders").SetParentRow(Me, value)
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
    Public Class OrdersRowChangeEvent
        Inherits EventArgs
        
        Private rowOrdersRow As OrdersRow
        Private actionValue As System.Data.DataRowAction
        
        Public Sub New(ByVal rowOrdersRowArg As OrdersRow, ByVal actionArg As DataRowAction)
            MyBase.New
            Me.rowOrdersRow = rowOrdersRowArg
            Me.actionValue = actionArg
        End Sub
        
        Public Overridable ReadOnly Property OrdersRow As OrdersRow
            Get
                Return Me.rowOrdersRow
            End Get
        End Property
        Public Overridable ReadOnly Property Action As DataRowAction
            Get
                Return Me.actionValue
            End Get
        End Property
        
    End Class
    Public Delegate Sub CustomersRowChangeEventHandler(ByVal sender As [object], ByVal e As CustomersRowChangeEvent)
    Public Delegate Sub OrdersRowChangeEventHandler(ByVal sender As [object], ByVal e As OrdersRowChangeEvent)

End Namespace