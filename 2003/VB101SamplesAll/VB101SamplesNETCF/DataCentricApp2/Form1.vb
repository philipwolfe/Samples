Option Strict On

Imports Microsoft.WindowsCE.Forms ' For SystemSettings
Imports System.Data.SqlServerCe ' For Database
Imports System.IO ' For File IO

Public Class Form1

    Private conn As SqlCeConnection
    Private cmd As SqlCeCommand
    Private rs As SqlCeResultSet

    ' Initialize form
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Display the OK button for closing the application.
        MinimizeBox = False

        ' Init ScreenOrientation to Angle90 (standard landscape view)
        SystemSettings.ScreenOrientation = ScreenOrientation.Angle90

        ' Init Database
        CreateDatabase()

        ' Init Display
        InitDisplay()
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ' The SqlCeResultSet requires the connection to be open to perform 
        ' various functions so close only when the form goes away
        conn.Close()

        ' Reset the ScreenOrientation to default Angle0 (standard portrait view)
        ' so emulator or device isn't left in a landscape mode
        SystemSettings.ScreenOrientation = ScreenOrientation.Angle90
    End Sub

    ' Create the SQL Mobile 2005 Database with 2 tables
    ' Contact - Master Table
    ' Address - Detail Table
    Private Sub CreateDatabase()
        Try
            ' Delete the SQL Mobile 2005 Database file
            File.Delete("\My Documents\Personal\Contacts.sdf")

            ' Create a new database
            Dim engine As New SqlCeEngine("Data Source = \My Documents\Personal\Contacts.sdf")
            engine.CreateDatabase()

            ' Create and open connection.  The SqlCeResultSet requires the 
            ' connection to be open to perform various functions
            conn = New SqlCeConnection("Data Source = \My Documents\Personal\Contacts.sdf")
            conn.Open()

            ' Create Command
            cmd = conn.CreateCommand()

            ' Create Address Detail Table and insert rows
            cmd.CommandText = "CREATE TABLE Address (AddressID INT, Address1 NVARCHAR(30), City NVARCHAR(30), State NVARCHAR(2), Zip NVARCHAR(5))"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Address VALUES (1,'332 3rd Ave','Pasco','WA', '99301')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Address VALUES (3,'Ad112 A ST','Pasco','WA', '99301')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Address VALUES (2,'141 Oak PKWY','Pasco','WA', '99301')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Address VALUES (4,'332 N 40TH SE','Richland','WA','99352')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Address VALUES (5,'3329 Belfair','Burbank','WA','99331')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Address VALUES (6,'PO Box 332','Pasco','WA','99302')"
            cmd.ExecuteNonQuery()

            ' Create Contact Master Table and insert rows
            cmd.CommandText = "CREATE TABLE Contact (ContactID INT, AddressID INT, First NVARCHAR(20), Last NVARCHAR(30), Phone NVARCHAR(20))"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Contact VALUES (1, 1, 'Andy', 'Smith', '443-4343')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Contact VALUES (2, 1, 'Joan', 'Smith', '443-4344')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Contact VALUES (3, 2, 'Bob', 'Johnson', '333-4788')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Contact VALUES (4, 3, 'Willy', 'Williams', '443-0087')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Contact VALUES (5, 4, 'Jenny', 'Cowpoke', '443-7773')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Contact VALUES (6, 4, 'Jim', 'Cowpoke', '443-7773')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Contact VALUES (7, 5, 'Kate', 'Jones', '444-4338')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Contact VALUES (8, 6, 'Bill', 'Schultz', '440-2233')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO Contact VALUES (9, 6, 'Belinda', 'Schultz', '440-4568')"
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Select all the contacts from the contact table for display in the ListBox
    Private Sub InitDisplay()
        ' Create ResultSet
        cmd.CommandText = "SELECT AddressID, First, Last, Phone, First + ' ' + Last AS Name FROM Contact"
        rs = cmd.ExecuteResultSet(ResultSetOptions.Updatable Or ResultSetOptions.Scrollable)
        MasterListBox.DataSource = rs.ResultSetView
        MasterListBox.DisplayMember = "Name" ' What is displayed
        MasterListBox.ValueMember = "AddressID"
    End Sub

    ' When the contact is selected in the ListBox, update the detail view based
    ' on the Foreign key AddressID 
    Private Sub MasterListBox_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterListBox.SelectedValueChanged
        ' Sync list box with result set...in this case number of records in result set
        ' is the same as the number of rows in the ListBox
        rs.ReadAbsolute(MasterListBox.SelectedIndex)

        ' Set the First, Last and Phone based on result set
        FirstTextBox.Text = rs.GetString(1)
        LastTextBox.Text = rs.GetString(2)
        PhoneTextBox.Text = rs.GetString(3)

        ' Set up the Detail values using a DataReader and Foreign key AddressID in the select query
        cmd.CommandText = "SELECT * FROM Address WHERE AddressID = " & CStr(rs.GetInt32(0)) ' Get the Detail Table Foreign Key, AddressID
        Dim dr As SqlCeDataReader = Nothing
        Try
            dr = cmd.ExecuteReader()
            If dr.Read() Then
                AddressTextBox.Text = CStr(dr.Item("Address1"))
                CityTextBox.Text = CStr(dr.Item("City"))
                StateTextBox.Text = CStr(dr.Item("State"))
                ZipTextBox.Text = CStr(dr.Item("Zip"))
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If Not dr Is Nothing Then
                dr.Close()
            End If
        End Try
    End Sub
End Class
