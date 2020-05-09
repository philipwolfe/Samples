'***********************************************************************************************************
' From Spain: November 2002
'
' All code has been developed by:
' Jesús López is MCP SQL Server and Microsoft .NET MVP
' You can contact with Jesús in his web site (SqlRanger - http://www.sqlranger.com/)
'
' With a little contribution of:
' Jorge Serrano is Microsoft .NET MVP
' You can contact with Jorge in his web site (PortalVB.com - http://www.portalvb.com/)
'***********************************************************************************************************

Imports SqlRanger

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    Friend WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents ds As SqlRanger.DataSetEmployees
    Friend WithEvents dvEmployees As System.Data.DataView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents NavBar1 As SqlRanger.NavBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dvEmployees = New System.Data.DataView
        Me.ds = New SqlRanger.DataSetEmployees
        Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.NavBar1 = New SqlRanger.NavBar
        CType(Me.dvEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dvEmployees
        '
        Me.dvEmployees.ApplyDefaultSort = True
        Me.dvEmployees.Sort = "EmployeeID"
        Me.dvEmployees.Table = Me.ds.Employees
        '
        'ds
        '
        Me.ds.DataSetName = "DataSetEmployees"
        Me.ds.Locale = New System.Globalization.CultureInfo("es-ES")
        '
        'SqlDataAdapter1
        '
        Me.SqlDataAdapter1.DeleteCommand = Me.SqlDeleteCommand1
        Me.SqlDataAdapter1.InsertCommand = Me.SqlInsertCommand1
        Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
        Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Employees", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"), New System.Data.Common.DataColumnMapping("LastName", "LastName"), New System.Data.Common.DataColumnMapping("FirstName", "FirstName"), New System.Data.Common.DataColumnMapping("BirthDate", "BirthDate"), New System.Data.Common.DataColumnMapping("Address", "Address")})})
        Me.SqlDataAdapter1.UpdateCommand = Me.SqlUpdateCommand1
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM Employees WHERE (EmployeeID = @Original_EmployeeID) AND (Address = @O" & _
        "riginal_Address OR @Original_Address IS NULL AND Address IS NULL) AND (BirthDate" & _
        " = @Original_BirthDate OR @Original_BirthDate IS NULL AND BirthDate IS NULL) AND" & _
        " (FirstName = @Original_FirstName) AND (LastName = @Original_LastName)"
        Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_BirthDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BirthDate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_FirstName", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FirstName", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_LastName", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LastName", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "data source=localhost;initial catalog=Northwind;integrated security=SSPI;persist " & _
        "security info=False;workstation id=JLM;packet size=4096"
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, Address) VALUES (@LastName," & _
        " @FirstName, @BirthDate, @Address); SELECT EmployeeID, LastName, FirstName, Birt" & _
        "hDate, Address FROM Employees WHERE (EmployeeID = @@IDENTITY)"
        Me.SqlInsertCommand1.Connection = Me.SqlConnection1
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 20, "LastName"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 10, "FirstName"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BirthDate", System.Data.SqlDbType.DateTime, 8, "BirthDate"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, "Address"))
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT EmployeeID, LastName, FirstName, BirthDate, Address FROM Employees"
        Me.SqlSelectCommand1.Connection = Me.SqlConnection1
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, BirthDate = @B" & _
        "irthDate, Address = @Address WHERE (EmployeeID = @Original_EmployeeID) AND (Addr" & _
        "ess = @Original_Address OR @Original_Address IS NULL AND Address IS NULL) AND (B" & _
        "irthDate = @Original_BirthDate OR @Original_BirthDate IS NULL AND BirthDate IS N" & _
        "ULL) AND (FirstName = @Original_FirstName) AND (LastName = @Original_LastName); " & _
        "SELECT EmployeeID, LastName, FirstName, BirthDate, Address FROM Employees WHERE " & _
        "(EmployeeID = @EmployeeID)"
        Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 20, "LastName"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 10, "FirstName"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BirthDate", System.Data.SqlDbType.DateTime, 8, "BirthDate"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, "Address"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_BirthDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BirthDate", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_FirstName", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FirstName", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_LastName", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LastName", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"))
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "EmployeeID"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "LastName"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 23)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "FirstName"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 23)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "BirthDate"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(24, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 23)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Address"
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dvEmployees, "EmployeeID"))
        Me.TextBox1.Location = New System.Drawing.Point(112, 28)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(112, 20)
        Me.TextBox1.TabIndex = 10
        Me.TextBox1.Text = ""
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dvEmployees, "LastName"))
        Me.TextBox2.Location = New System.Drawing.Point(112, 60)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(112, 20)
        Me.TextBox2.TabIndex = 11
        Me.TextBox2.Text = ""
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dvEmployees, "FirstName"))
        Me.TextBox3.Location = New System.Drawing.Point(112, 92)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(112, 20)
        Me.TextBox3.TabIndex = 12
        Me.TextBox3.Text = ""
        '
        'TextBox5
        '
        Me.TextBox5.AcceptsReturn = True
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dvEmployees, "Address"))
        Me.TextBox5.Location = New System.Drawing.Point(112, 152)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(112, 36)
        Me.TextBox5.TabIndex = 14
        Me.TextBox5.Text = ""
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dvEmployees, "BirthDate"))
        Me.TextBox4.Location = New System.Drawing.Point(112, 120)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(112, 20)
        Me.TextBox4.TabIndex = 16
        Me.TextBox4.Text = ""
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.DataSource = Me.dvEmployees
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(256, 29)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(440, 168)
        Me.DataGrid1.TabIndex = 17
        '
        'NavBar1
        '
        Me.NavBar1.AllowAddNew = True
        Me.NavBar1.AllowDelete = True
        Me.NavBar1.DataView = Nothing
        Me.NavBar1.Location = New System.Drawing.Point(114, 219)
        Me.NavBar1.Name = "NavBar1"
        Me.NavBar1.Size = New System.Drawing.Size(328, 26)
        Me.NavBar1.TabIndex = 18
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(712, 249)
        Me.Controls.Add(Me.NavBar1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dvEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SqlDataAdapter1.Fill(Me.ds.Employees)
        Me.NavBar1.DataView = Me.dvEmployees
    End Sub

    Private Sub NavBar1_ErrorsOcurred(ByVal Sender As Object, ByVal e As SqlRanger.NavBarErrorEventArgs) Handles NavBar1.ErrorsOcurred
        MessageBox.Show(e.Errors.Message)
    End Sub

    Private Sub NavBar1_RowDeleting(ByVal Sender As Object, ByVal e As SqlRanger.NavBarDeletingRowEventArgs) Handles NavBar1.RowDeleting
        If MessageBox.Show("Do you want delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fb As New FilterBuilder
        If fb.ShowDialog(Me.ds.Employees, ConditionFormatEnum.ADO) = DialogResult.OK Then
            MessageBox.Show(fb.Filter)
            Me.dvEmployees.RowFilter = fb.Filter
        End If
    End Sub

End Class