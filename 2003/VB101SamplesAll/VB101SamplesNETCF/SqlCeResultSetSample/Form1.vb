Option Strict On

Imports System.Data.SqlServerCe
Imports System.IO

Public Class Form1
    Private conn As SqlCeConnection
    Private cmd As SqlCeCommand
    Private rs As SqlCeResultSet
    Private id As Integer = 0 ' simple way to auto increment id (primary key) for record

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CreateDatabase()
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        ' The SqlCeResultSet requires the connection to be open to perform 
        ' various functions so close only when the form goes away
        conn.Close()
    End Sub

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
            cmd.CommandText = "CREATE TABLE Contact (ID INT, First NVARCHAR(20), Last NVARCHAR(30), Phone NVARCHAR(20), EntryDate DATETIME)"
            cmd.ExecuteNonQuery()

            ' Create ResultSet
            cmd.CommandText = "SELECT * FROM Contact"
            rs = cmd.ExecuteResultSet(ResultSetOptions.Updatable Or ResultSetOptions.Scrollable)

            ' Bind the result set to the DataGrid
            ContactDataGrid.DataSource = rs.ResultSetView

            ' Add records for demonstration purposes
            Dim i As Integer
            For i = 0 To 9
                Dim idxStr As String = i.ToString()
                AddRecord(rs, "First" & idxStr, "Last" & idxStr, "555-100" & idxStr)
            Next i
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub

    Private Sub AddRecord(ByVal rs As SqlCeResultSet, ByVal first As String, ByVal last As String, ByVal phone As String)
        ' Create a Record
        Dim rec As SqlCeUpdatableRecord = rs.CreateRecord()

        ' Stuff record with data
        id += 1 ' increment id
        rec.SetInt32(0, id)
        rec.SetString(1, first)
        rec.SetString(2, last)
        rec.SetString(3, phone)
        rec.SetDateTime(4, Now())

        ' Insert record into result set
        rs.Insert(rec)
    End Sub

    ' Populate the textboxes based on the current record in the result set
    Private Sub DataToForm()
        FirstTextBox.Text = rs.GetString(1)
        LastTextBox.Text = rs.GetString(2)
        PhoneTextBox.Text = rs.GetString(3)
    End Sub

    Private Sub AddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton.Click
        AddRecord(rs, FirstTextBox.Text, LastTextBox.Text, PhoneTextBox.Text)
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Try
            rs.Delete()
            ' Make sure that the cursor in the result set is set to the current row index of the grid
            ' this is necessary to keep synchronization between the result set and data grid
            rs.ReadAbsolute(ContactDataGrid.CurrentRowIndex)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Write pending changes in the result set to the database
        Try
            rs.Update()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PrevButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ContactDataGrid.CurrentRowIndex > 0 Then
            ContactDataGrid.CurrentRowIndex = ContactDataGrid.CurrentRowIndex - 1
        End If
    End Sub

    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click
        ' There doesn't appear to be any efficient way to determine the index of the last row of the data
        ' or the number of records in the result set, so just catch and swallow the obvious exception of stepping
        ' over the end.
        Try
            ContactDataGrid.CurrentRowIndex = ContactDataGrid.CurrentRowIndex + 1
        Catch
            rs.ReadLast() ' sync up ResultSet with DataGrid
        End Try
    End Sub

    Private Sub ContactDataGrid_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContactDataGrid.CurrentCellChanged
        rs.ReadAbsolute(ContactDataGrid.CurrentRowIndex)
        DataToForm()
    End Sub

End Class
