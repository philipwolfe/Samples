Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ControlChars

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents txtProcessID As System.Windows.Forms.TextBox
    Private WithEvents btnGetProcessByID As System.Windows.Forms.Button



    Private WithEvents btnGetProcessList As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.btnGetProcessList = New System.Windows.Forms.Button()
        Me.btnGetProcessByID = New System.Windows.Forms.Button()
        Me.txtProcessID = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnGetProcessList
        '
        Me.btnGetProcessList.Location = New System.Drawing.Point(16, 16)
        Me.btnGetProcessList.Name = "btnGetProcessList"
        Me.btnGetProcessList.Size = New System.Drawing.Size(216, 23)
        Me.btnGetProcessList.TabIndex = 0
        Me.btnGetProcessList.Text = "Click Me first to get the Processes List"
        '
        'btnGetProcessByID
        '
        Me.btnGetProcessByID.Location = New System.Drawing.Point(16, 72)
        Me.btnGetProcessByID.Name = "btnGetProcessByID"
        Me.btnGetProcessByID.Size = New System.Drawing.Size(144, 23)
        Me.btnGetProcessByID.TabIndex = 4
        Me.btnGetProcessByID.Text = "Get Process Info for ID ->"
        '
        'txtProcessID
        '
        Me.txtProcessID.Location = New System.Drawing.Point(168, 72)
        Me.txtProcessID.Name = "txtProcessID"
        Me.txtProcessID.Size = New System.Drawing.Size(128, 20)
        Me.txtProcessID.TabIndex = 5
        Me.txtProcessID.Text = ""
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(320, 133)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtProcessID, Me.btnGetProcessByID, Me.btnGetProcessList})
        Me.Name = "Form1"
        Me.Text = "Process Info"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Sub btnGetProcessByID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetProcessByID.Click
        Try
            Dim s As String
            Dim ProcessId As Int32
            Dim Process As Process

            ProcessId = Int32.Parse(txtProcessID.Text)
            Process = Process.GetProcessById(ProcessId)

            s = s & "Priority Class         :" & CStr(Process.PriorityClass) & Chr(10)
            s = s & "Handle Count           :" & Process.HandleCount & Chr(10)
            s = s & "Main Window Title      :" & Process.MainWindowTitle & Chr(10)
            s = s & "Min Working Set        :" & Process.MinWorkingSet.ToString & Chr(10)
            s = s & "Max Working Set        :" & Process.MaxWorkingSet.ToString & Chr(10)
            s = s & "Paged Memory Size      :" & Process.PagedMemorySize & Chr(10)
            s = s & "Peak Paged Memory Size :" & Process.PeakPagedMemorySize & Chr(10)

            'display the list of processes
            MessageBox.Show(s)


        Catch
            MessageBox.Show("Invalid Process ID")
        End Try
    End Sub

    Protected Sub btnGetProcessList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetProcessList.Click

        Dim s As String
        Dim Processes() As Process

        'get the list of current processes
        Processes = System.Diagnostics.Process.GetProcesses()

        'grab some basic information for each process
        Dim Process As Process
        Dim i As Integer
        For i = 0 To Processes.Length - 1
            Process = Processes(i)
            s = s & CStr(Process.Id) & "    : " & Process.ProcessName & Microsoft.VisualBasic.Chr(10)
        Next

        'display the process information to the user
        MessageBox.Show(s)

        'default the textbox value to the first process id - for the GetByID button
        txtProcessID.Text = Processes(0).Id.ToString
    End Sub

End Class
