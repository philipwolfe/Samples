Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents daO As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlSelectCommand2 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand2 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand2 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand2 As System.Data.SqlClient.SqlCommand
    Friend WithEvents daC As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents Ds1 As Test.ds
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Grd1 As MyControls.grd
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.daO = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlSelectCommand2 = New System.Data.SqlClient.SqlCommand()
        Me.SqlInsertCommand2 = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand2 = New System.Data.SqlClient.SqlCommand()
        Me.SqlDeleteCommand2 = New System.Data.SqlClient.SqlCommand()
        Me.daC = New System.Data.SqlClient.SqlDataAdapter()
        Me.Ds1 = New Test.ds()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Grd1 = New MyControls.grd()
        CType(Me.Ds1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grd1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "data source=afsarsal;initial catalog=Northwind;integrated security=SSPI;persist s" & _
        "ecurity info=False;workstation id=AFSARSAL;packet size=4096"
        '
        'daO
        '
        Me.daO.DeleteCommand = Me.SqlDeleteCommand1
        Me.daO.InsertCommand = Me.SqlInsertCommand1
        Me.daO.SelectCommand = Me.SqlSelectCommand1
        Me.daO.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Orders", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("OrderID", "OrderID"), New System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"), New System.Data.Common.DataColumnMapping("OrderDate", "OrderDate"), New System.Data.Common.DataColumnMapping("boo", "boo"), New System.Data.Common.DataColumnMapping("ShipName", "ShipName"), New System.Data.Common.DataColumnMapping("IntCol", "IntCol")})})
        Me.daO.UpdateCommand = Me.SqlUpdateCommand1
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM Orders WHERE (OrderID = @Original_OrderID) AND (CustomerID = @Origina" & _
        "l_CustomerID OR @Original_CustomerID IS NULL AND CustomerID IS NULL) AND (IntCol" & _
        " = @Original_IntCol OR @Original_IntCol IS NULL AND IntCol IS NULL) AND (OrderDa" & _
        "te = @Original_OrderDate OR @Original_OrderDate IS NULL AND OrderDate IS NULL) A" & _
        "ND (ShipName = @Original_ShipName OR @Original_ShipName IS NULL AND ShipName IS " & _
        "NULL) AND (boo = @Original_boo OR @Original_boo IS NULL AND boo IS NULL)"
        Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_IntCol", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IntCol", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ShipName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_boo", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "boo", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = "INSERT INTO Orders(CustomerID, OrderDate, boo, ShipName, IntCol) VALUES (@Custome" & _
        "rID, @OrderDate, @boo, @ShipName, @IntCol); SELECT OrderID, CustomerID, OrderDat" & _
        "e, boo, ShipName, IntCol FROM Orders WHERE (OrderID = @@IDENTITY)"
        Me.SqlInsertCommand1.Connection = Me.SqlConnection1
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderDate", System.Data.SqlDbType.DateTime, 8, "OrderDate"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@boo", System.Data.SqlDbType.Bit, 1, "boo"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ShipName", System.Data.SqlDbType.NVarChar, 40, "ShipName"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IntCol", System.Data.SqlDbType.Int, 4, "IntCol"))
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT OrderID, CustomerID, OrderDate, boo, ShipName, IntCol FROM Orders WHERE (O" & _
        "rderID < 10260)"
        Me.SqlSelectCommand1.Connection = Me.SqlConnection1
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = "UPDATE Orders SET CustomerID = @CustomerID, OrderDate = @OrderDate, boo = @boo, S" & _
        "hipName = @ShipName, IntCol = @IntCol WHERE (OrderID = @Original_OrderID) AND (C" & _
        "ustomerID = @Original_CustomerID OR @Original_CustomerID IS NULL AND CustomerID " & _
        "IS NULL) AND (IntCol = @Original_IntCol OR @Original_IntCol IS NULL AND IntCol I" & _
        "S NULL) AND (OrderDate = @Original_OrderDate OR @Original_OrderDate IS NULL AND " & _
        "OrderDate IS NULL) AND (ShipName = @Original_ShipName OR @Original_ShipName IS N" & _
        "ULL AND ShipName IS NULL) AND (boo = @Original_boo OR @Original_boo IS NULL AND " & _
        "boo IS NULL); SELECT OrderID, CustomerID, OrderDate, boo, ShipName, IntCol FROM " & _
        "Orders WHERE (OrderID = @OrderID)"
        Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderDate", System.Data.SqlDbType.DateTime, 8, "OrderDate"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@boo", System.Data.SqlDbType.Bit, 1, "boo"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ShipName", System.Data.SqlDbType.NVarChar, 40, "ShipName"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IntCol", System.Data.SqlDbType.Int, 4, "IntCol"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_IntCol", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IntCol", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ShipName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_boo", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "boo", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderID", System.Data.SqlDbType.Int, 4, "OrderID"))
        '
        'SqlSelectCommand2
        '
        Me.SqlSelectCommand2.CommandText = "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region," & _
        " PostalCode, Country, Phone, Fax FROM Customers"
        Me.SqlSelectCommand2.Connection = Me.SqlConnection1
        '
        'SqlInsertCommand2
        '
        Me.SqlInsertCommand2.CommandText = "INSERT INTO Customers(CustomerID, CompanyName, ContactName, ContactTitle, Address" & _
        ", City, Region, PostalCode, Country, Phone, Fax) VALUES (@CustomerID, @CompanyNa" & _
        "me, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country" & _
        ", @Phone, @Fax); SELECT CustomerID, CompanyName, ContactName, ContactTitle, Addr" & _
        "ess, City, Region, PostalCode, Country, Phone, Fax FROM Customers WHERE (Custome" & _
        "rID = @CustomerID)"
        Me.SqlInsertCommand2.Connection = Me.SqlConnection1
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, "ContactName"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ContactTitle", System.Data.SqlDbType.NVarChar, 30, "ContactTitle"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, "Address"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Region", System.Data.SqlDbType.NVarChar, 15, "Region"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar, 10, "PostalCode"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 15, "Country"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 24, "Phone"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fax", System.Data.SqlDbType.NVarChar, 24, "Fax"))
        '
        'SqlUpdateCommand2
        '
        Me.SqlUpdateCommand2.CommandText = "UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName, Contac" & _
        "tName = @ContactName, ContactTitle = @ContactTitle, Address = @Address, City = @" & _
        "City, Region = @Region, PostalCode = @PostalCode, Country = @Country, Phone = @P" & _
        "hone, Fax = @Fax WHERE (CustomerID = @Original_CustomerID) AND (Address = @Origi" & _
        "nal_Address OR @Original_Address IS NULL AND Address IS NULL) AND (City = @Origi" & _
        "nal_City OR @Original_City IS NULL AND City IS NULL) AND (CompanyName = @Origina" & _
        "l_CompanyName) AND (ContactName = @Original_ContactName OR @Original_ContactName" & _
        " IS NULL AND ContactName IS NULL) AND (ContactTitle = @Original_ContactTitle OR " & _
        "@Original_ContactTitle IS NULL AND ContactTitle IS NULL) AND (Country = @Origina" & _
        "l_Country OR @Original_Country IS NULL AND Country IS NULL) AND (Fax = @Original" & _
        "_Fax OR @Original_Fax IS NULL AND Fax IS NULL) AND (Phone = @Original_Phone OR @" & _
        "Original_Phone IS NULL AND Phone IS NULL) AND (PostalCode = @Original_PostalCode" & _
        " OR @Original_PostalCode IS NULL AND PostalCode IS NULL) AND (Region = @Original" & _
        "_Region OR @Original_Region IS NULL AND Region IS NULL); SELECT CustomerID, Comp" & _
        "anyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, " & _
        "Phone, Fax FROM Customers WHERE (CustomerID = @CustomerID)"
        Me.SqlUpdateCommand2.Connection = Me.SqlConnection1
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, "ContactName"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ContactTitle", System.Data.SqlDbType.NVarChar, 30, "ContactTitle"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, "Address"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Region", System.Data.SqlDbType.NVarChar, 15, "Region"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar, 10, "PostalCode"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 15, "Country"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 24, "Phone"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fax", System.Data.SqlDbType.NVarChar, 24, "Fax"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CompanyName", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ContactTitle", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactTitle", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Fax", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Phone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Region", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlDeleteCommand2
        '
        Me.SqlDeleteCommand2.CommandText = "DELETE FROM Customers WHERE (CustomerID = @Original_CustomerID) AND (Address = @O" & _
        "riginal_Address OR @Original_Address IS NULL AND Address IS NULL) AND (City = @O" & _
        "riginal_City OR @Original_City IS NULL AND City IS NULL) AND (CompanyName = @Ori" & _
        "ginal_CompanyName) AND (ContactName = @Original_ContactName OR @Original_Contact" & _
        "Name IS NULL AND ContactName IS NULL) AND (ContactTitle = @Original_ContactTitle" & _
        " OR @Original_ContactTitle IS NULL AND ContactTitle IS NULL) AND (Country = @Ori" & _
        "ginal_Country OR @Original_Country IS NULL AND Country IS NULL) AND (Fax = @Orig" & _
        "inal_Fax OR @Original_Fax IS NULL AND Fax IS NULL) AND (Phone = @Original_Phone " & _
        "OR @Original_Phone IS NULL AND Phone IS NULL) AND (PostalCode = @Original_Postal" & _
        "Code OR @Original_PostalCode IS NULL AND PostalCode IS NULL) AND (Region = @Orig" & _
        "inal_Region OR @Original_Region IS NULL AND Region IS NULL)"
        Me.SqlDeleteCommand2.Connection = Me.SqlConnection1
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CompanyName", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ContactTitle", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactTitle", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Fax", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Phone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Region", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
        '
        'daC
        '
        Me.daC.DeleteCommand = Me.SqlDeleteCommand2
        Me.daC.InsertCommand = Me.SqlInsertCommand2
        Me.daC.SelectCommand = Me.SqlSelectCommand2
        Me.daC.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Customers", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"), New System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"), New System.Data.Common.DataColumnMapping("ContactName", "ContactName"), New System.Data.Common.DataColumnMapping("ContactTitle", "ContactTitle"), New System.Data.Common.DataColumnMapping("Address", "Address"), New System.Data.Common.DataColumnMapping("City", "City"), New System.Data.Common.DataColumnMapping("Region", "Region"), New System.Data.Common.DataColumnMapping("PostalCode", "PostalCode"), New System.Data.Common.DataColumnMapping("Country", "Country"), New System.Data.Common.DataColumnMapping("Phone", "Phone"), New System.Data.Common.DataColumnMapping("Fax", "Fax")})})
        Me.daC.UpdateCommand = Me.SqlUpdateCommand2
        '
        'Ds1
        '
        Me.Ds1.DataSetName = "ds"
        Me.Ds1.Locale = New System.Globalization.CultureInfo("tr-TR")
        Me.Ds1.Namespace = "http://www.tempuri.org/ds.xsd"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(428, 348)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(168, 40)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Get Data"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(112, 344)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(168, 40)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Update"
        '
        'Grd1
        '
        Me.Grd1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.Grd1.CaptionBackColor = System.Drawing.SystemColors.Window
        Me.Grd1.CaptionForeColor = System.Drawing.Color.DarkGray
        Me.Grd1.DataMember = ""
        Me.Grd1.DeleteMessageCaption = Nothing
        Me.Grd1.DeleteMessageEnabled = False
        Me.Grd1.DeleteMessageText = Nothing
        Me.Grd1.GridLineColor = System.Drawing.SystemColors.ControlDark
        Me.Grd1.HeaderBackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Grd1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Grd1.Location = New System.Drawing.Point(12, 16)
        Me.Grd1.Name = "Grd1"
        Me.Grd1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.Grd1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.Grd1.SelectionStyle = MyControls.grd.eSelectionStyle.Cell
        Me.Grd1.Size = New System.Drawing.Size(676, 292)
        Me.Grd1.TabIndex = 5
        Me.Grd1.WriteRowHeader = False
        Me.Grd1.WriteRowHeaderColor = System.Drawing.Color.Empty
        Me.Grd1.WriteRowHeaderText = Nothing
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(704, 462)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Grd1, Me.Button1, Me.Button2})
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Ds1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grd1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1_Click(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        daO.Fill(Ds1)
        daC.Fill(Ds1)
        Grd1.SetDataBinding(Ds1, "Orders")
        Grd1.BeginTableStyle(Ds1)
        Grd1.AddComboColumn(1, Grd1.DataSource, "Customers", "ContactName", "CustomerID")
        'Grd1.HideColumn(2)
        'Grd1.NonEditableColumn(5)
        'Grd1.WriteRowHeader = True
        'grd1.SelectionStyle =MyControls.grd.eSelectionStyle.Row 
        Grd1.SetMyColorStyle()
        Grd1.AddNewRowVisible(False)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        daO.Update(Ds1)
    End Sub
    Private Sub Grd1_DoubleClick2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        MsgBox(Grd1.CurrentValue)
    End Sub
    Private Sub Grd1_DoubleClick3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(Grd1.CurrentValue)
    End Sub

End Class
