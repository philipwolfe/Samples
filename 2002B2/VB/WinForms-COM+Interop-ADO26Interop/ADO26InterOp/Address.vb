Imports System.ComponentModel


Public Class Address
    Inherits System.ComponentModel.Component

    Public Sub New()
        MyBase.New

        'This call is required by the Component Designer.
        InitializeComponent

        ' TODO: Add any initialization after the InitializeComponent() call

    End Sub
    
    'This function returns connection string
    Public Function GetConnectStr() As String
        GetConnectStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AddressBook.mdb;"
    End Function

    'This function returns an ADO 2.6 recordset object
    'The recordset contains the value of the name field of every record in the Address table.
    Public Function GetName() As ADODB.Recordset
        Dim SQL As String
        Dim Con As ADODB.Connection
        Dim Names As ADODB.Recordset
        SQL = "SELECT Name From Address"

        Con = New ADODB.Connection()
        Names = New ADODB.Recordset()
        Con.Open(GetConnectStr())

        With Names
            .CursorLocation = ADODB.CursorLocationEnum.adUseClient
            .CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly
            .Open(SQL, Con, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
            .ActiveConnection = Nothing
        End With

        GetName = Names

        Con.Close()

    End Function

    'This function returns an ADO 2.6 recordset object
    'The recordset contains all field values of a record in the Address table
    'where the Name field equals the strName.  This is used to populate the address
    'text boxes with data.
    Public Function GetAddress(ByVal strName As String) As ADODB.Recordset
        Dim SQL As String
        Dim Con As ADODB.Connection
        Dim Address As ADODB.Recordset
        SQL = "SELECT * From Address where Name = '" & strName & "'"

        Con = New ADODB.Connection()
        Address = New ADODB.Recordset()
        Con.Open(GetConnectStr())

        With Address
            .CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly
            .Open(SQL, Con, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        End With

        GetAddress = Address

    End Function

#Region " Component Designer generated code "

    'Required by the Component Designer
    Private components As Container

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

End Class
